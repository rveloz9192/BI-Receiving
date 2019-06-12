using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BISync_Receiving
{
    public static class SqlCli
    {
        private static readonly string sCon = System.Configuration.ConfigurationManager.ConnectionStrings["Syteline"].ConnectionString;
        private static readonly string bCon = System.Configuration.ConfigurationManager.ConnectionStrings["BISync"].ConnectionString;
        private static readonly string tCon = System.Configuration.ConfigurationManager.ConnectionStrings["TA"].ConnectionString;

        public static event EventHandler<EventArgs> PrepMainFormForMessageBox;

        public static Dictionary<string, string[]> LoadSyteInfo(string sn)
        {
            var values = new Dictionary<string, string[]>();
            SqlConnection con = new SqlConnection(sCon);

            SqlCommand cmd = new SqlCommand(@"
            Select
    s.sro_num,
    s.sro_line,
    s.open_date,
    s.item,
    o.product_code,
    CASE WHEN o.stat = 'O' Then 'Open' Else 'Closed' End [Stat],
    r.reason_gen,
    ROW_NUMBER() OVER(Order By s.open_date DESC) - 1,
    r.reason_notes
    From fs_tmp_sro_line_view s (nolock)
    Left join fs_sro_oper o (nolock)
    on s.sro_num = o.sro_num and s.sro_line = o.sro_line
    Left join fs_sro_reason r (nolock)
    on s.sro_num = r.sro_num and s.sro_line = r.sro_line and r.seq = 1
    Where s.ser_num = @SN 
    Order by s.open_date DESC", con);
            cmd.AddParam("@SN", sn);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var csv = string.Join("|", dt.Rows[i].ItemArray.Select(c => c.ToString()).ToArray());
                var row = csv.Split('|');
                if (!values.ContainsKey(row[0]))
                    values.Add(row[0], row);
            }

            return values;
        }

        public static string[] GetPrefsAndProducts(string sn)
        {
            SqlConnection con = new SqlConnection(bCon);
            SqlCommand cmd = new SqlCommand("Select distinct Prefix, Product, LEN(Prefix) [LenPref]  from Prefixes where Type = 'P' Order by LenPref DESC", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Dictionary<string, string> Prefs = new Dictionary<string, string>();

            string serial = null, prefix = null, product = null;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (sn.StartsWith(dr.GetString(0)))
                    {
                        serial = sn.Remove(0, dr.GetString(0).Length);
                        prefix = dr.GetString(0);
                        product = dr.GetString(1);

                        break;
                    }
                }
            }
            con.Close();

            return new string[] { serial, prefix, product };
        }

        public static string[] FindPrefAndProduct(string sn)
        {
            SqlConnection con = new SqlConnection(bCon);
            SqlCommand cmd = new SqlCommand(@"
Declare @PrefID int
Set @PrefID = (Select prefID from DeviceInfo Where SerialNumber = @SN)
if @PrefID IS NULL
Begin
	;with t as
	(
	Select Top 1 p.Prefix, p.Product, LEN(REPLACE(@SN, p.Prefix,'')) [MatchLen]
	From Prefixes p
	Where LEFT(@SN, LEN(p.Prefix)) = p.Prefix
	Order by MatchLen DESC
	)
	Select p.Prefix, p.Product 
	from Prefixes p
	Inner join t
	on p.Product = t.Product and p.Type = 'P'
End
Else
Begin
	Select p.Prefix, p.Product From Prefixes p where ID = @PrefID
End
", con);
            cmd.AddParam("@SN", sn);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            string prefix = null, product = null;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    prefix = dr.GetString(0);
                    product = dr.GetString(1);
                }
            }
            con.Close();

            return new string[] { sn, prefix, product };
        }

        public static List<string> LoadExpectedUnits()
        {
            var values = new List<string>();
            SqlConnection con = new SqlConnection(sCon);
            SqlCommand cmd = new SqlCommand(@"Select Distinct UPPER([ser_num]) [SN] from fs_sro_line (nolock) where stat = 'O' order by [SN] DESC", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    values.Add(dr[0].ToString());
                }
            }
            con.Close();

            return values;
        }

        public static string CheckSROCodes(string sro, string line)
        {
            SqlConnection con = new SqlConnection(sCon);
            SqlCommand cmd = new SqlCommand(@"
Select Distinct r.reason_gen, g.description 
From fs_sro_reason r (nolock)
Inner join fs_reas_gen g (nolock)
on r.reason_gen = g.reason_gen
Where r.sro_num = @sro and r.sro_line = @line
and r.reason_gen IN (1053, 1059, 1125, 7777)", con);

            cmd.AddParam("@sro", sro);
            cmd.AddParam("@line", line);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            string reasonCode = "";
            string msg = "Unit has return code:" + Environment.NewLine;
            if (dr.HasRows)
            {
                int iteration = 0;
                while (dr.Read())
                {
                    if (iteration == 0) { reasonCode = dr[0].ToString(); }
                    iteration++;
                    msg += string.Format($"{dr[0].ToString()} - {dr[1].ToString()}{Environment.NewLine}");
                }
                con.Close();
                FrmPopup popup = new FrmPopup(msg);
                popup.PrepMainFormForPopupForm += PrepMainFormForMessageBox;
                popup.ShowDialog();
                popup.PrepMainFormForPopupForm -= PrepMainFormForMessageBox;
                Console.WriteLine($"CheckSROCodes had {iteration - 1} lines.");
            }
            if (con.State == ConnectionState.Open)
                con.Close();

            return reasonCode;
        }

        public static bool Login(string user, string pass)
        {
            SqlConnection con = new SqlConnection(bCon);
            SqlCommand cmd = new SqlCommand("Select password from Users where UPPER(Username) = @User", con);
            cmd.AddParam("@User", user.ToUpper());
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            bool match = false;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (pass.Encrypt() == dr[0].ToString())
                        match = true;
                    else
                        System.Windows.Forms.MessageBox.Show("Incorrect username or password");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No account with that username is registered");
            }
            con.Close();

            return match;
        }

        public static void InsertIntoOperations(string sn, string username, string product)
        {
            SqlConnection con = new SqlConnection(bCon);
            SqlCommand cmd = new SqlCommand(@"
Insert into Operations([Serial Number], [Operation],[Resolution],[Operator],[DateTime],[Product])
VALUES(@SN, 'Receiving', 'Pass', @user, GETDATE(), @prod)", con);
            cmd.AddParam("@SN", sn);
            cmd.AddParam("@user", username);
            cmd.AddParam("@prod", product);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void CheckUnitFlag(string sn, string username)
        {
            SqlConnection con = new SqlConnection(bCon);
            SqlCommand cmd = new SqlCommand(@"
                Update Unit_Flags
                Set Acknowledged_By = @USER,
                Acknowledge_Date = GETDATE()
                OUTPUT
                Inserted.[Message],
                Inserted.[Flagged_By],
                Inserted.[Flag_Date]
                Where [SerialNumber] = @SN
                AND Removed_By IS NULL", con);
            cmd.AddParam("@SN", sn);
            cmd.AddParam("@USER", username);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    PrepMainFormForMessageBox(null, EventArgs.Empty);
                    System.Windows.Forms.MessageBox.Show(dr[0].ToString(), "Flagged Unit", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                }
            }
            con.Close();
        }

        public static List<string> LoadUsernames()
        {
            SqlConnection con = new SqlConnection(bCon);
            SqlCommand cmd = new SqlCommand("Select Distinct UPPER(Username) From Users", con);
            List<string> userlist = new List<string>();
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    userlist.Add(dr[0].ToString());
                }
            }
            con.Close();

            return userlist;
        }

        public static void RegisterUser(string firstname, string lastname, string username, string password, string fullname)
        {
            SqlConnection con = new SqlConnection(bCon);
            SqlCommand cmd = new SqlCommand(@"
Insert into Users(FirstName, LastName, UserName, Password, Level, Fullname)
Values (@First, @Last, @User, @Pass, 1, @Full)", con);
            cmd.AddParam("@First", firstname);
            cmd.AddParam("@Last", lastname);
            cmd.AddParam("@User", username);
            cmd.AddParam("@Pass", password.Encrypt());
            cmd.AddParam("@Full", fullname);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            System.Windows.Forms.MessageBox.Show("Registered");
        }
    }
}
