using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DYMO.Label.Framework;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Printing;

namespace GreenLabel
{
    public partial class QA : Form
    {
        string rcvrNum;
        string rev;
        SqlConnection con = new SqlConnection(sCon);
        bool printerSelected = false;
        String printerName;
        String Username { get; }
        //ILabel lbl = DYMO.Label.Framework.Label.Open("C:\\Users\\rveloz\\source\\repos\\roger-maddocks-bi\\GreenLabel\\Resources\\Lbl.label");
        private static readonly string sCon = "Data Source=bldrsyte8db01;Initial Catalog=EM_App;Persist Security Info=True;User ID=Travelmfg;Password=Tr@vel@mfg";


        public QA(string username)
        {

            Username = username;
            InitializeComponent();
            this.Show();
        }

        private void TxtReceiverNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtReceiverNumber.Text.All(char.IsDigit))
            {
                rcvrNum = txtReceiverNumber.Text;
                SqlCommand cmd = new SqlCommand(@"SELECT rcvr_num, item, ref_num, ref_line
                                                    FROM [EM_App].[dbo].[RS_QCRcvr]
                                                    Where rcvr_num = @RCVRNUM", con);
                cmd.Parameters.AddWithValue("@RCVRNUM", rcvrNum);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string PN = dt.Rows[0][1].ToString();
                    string PO = dt.Rows[0][2].ToString();
                    string POline = dt.Rows[0][3].ToString();

                    //Command to retrieve revision
                    SqlCommand cmd0 = new SqlCommand(@"SELECT TOP 1 revision
                                                                    FROM [EM_App].[dbo].[poitem_all]
                                                                    where po_num = @PO and item = @PN and po_line = @POline", con);

                    cmd0.Parameters.AddWithValue("@PO", PO);
                    cmd0.Parameters.AddWithValue("@PN", PN);
                    cmd0.Parameters.AddWithValue("@POline", POline);

                    SqlDataAdapter da0 = new SqlDataAdapter(cmd0);
                    DataTable dt0 = new DataTable();

                    da0.Fill(dt0);

                    rev = dt0.Rows[0][0].ToString();
                    txtRevision.Text = rev;
                }

                con.Close();
            }
            else
            {
                txtReceiverNumber.Clear();
            }
        }







        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            rcvrNum = txtReceiverNumber.Text;
            string numCopies = numberCopies.Value.ToString();
            rev = txtRevision.Text;





            //Connect to syteline database and command to retrieve Part Number and PO#

            SqlCommand cmd1 = new SqlCommand(@"SELECT rcvr_num, item, ref_num, ref_line
                                            FROM [EM_App].[dbo].[RS_QCRcvr]
                                            Where rcvr_num = @RCVRNUM", con);
            cmd1.Parameters.AddWithValue("@RCVRNUM", rcvrNum);




            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();

            da1.Fill(dt1);

            // Check to see if receiver number returned information
            if (dt1.Rows.Count > 0)
            {
                string PN = dt1.Rows[0][1].ToString();
                string PO = dt1.Rows[0][2].ToString();
                string POline = dt1.Rows[0][3].ToString();




                //--------------------------Logic for printing from a Zebra------------------------

                //string s = $"^XA^PW700\n^FO250,50^ADN,30,20^FDBI ACCEPTED^FS\n^FO0,150^ADN,90,40^FDPN:{PN}^FS\n^FO0,250^ADN,50,30^FDPO#:{PO}^FS\n^FO0,310^ADN,90,30^FDDate:{time}^FS\n^FO0,410^ADN,50,30^FDINSP:{Username.Substring(0,2)}^FS\n^FO0,470^ADN,90,30^FDREV:{rev}^FS\n^XZ";

                string s =  $"^XA^PW609^LL406\n" +
                            $"^FO205,20^CF0,40,40^FDBI ACCEPTED^FS\n" +
                            $"^FO10,100^CF0,60,40^FDPN:^FS\n" +
                            $"^FO80,60^CF0,120,60^FD{PN}^FS\n" +
                            $"^FO10,160^CF0,30,25^FDPO#:^FS\n" +
                            $"^FO10,220^FDREV:^FS\n" +
                            $"^FO10,280^FDDATE:^FS\n" +
                            $"^FO10,340^FDINSP:^FS\n" +
                            $"^FO80,340^FD{Username.Substring(0, 2).ToUpper()}^FS\n" +
                            $"^FO80,200^CF0,60,60^FD{rev.ToUpper()}^FS\n" +
                            $"^FO80,270^FD{DateTime.Today.ToString("MM/dd/yyyy")}^FS\n" +
                            $"^FO80,160^CF0,30,25^FD{PO}^FS\n" +
                            $"^PQ{numCopies}\n"+
                            $"^XZ";



                if (printerSelected == false)
                {
                    PrintDialog pd = new PrintDialog();
                    pd.PrinterSettings = new PrinterSettings();
                    if (DialogResult.OK == pd.ShowDialog(this))
                    {
                        printerName = pd.PrinterSettings.PrinterName;
                        printerSelected = true;
                    }
                }

                if (printerSelected == true) { RawPrinterHelper.SendStringToPrinter(printerName, s); }
                //------------------Logic for printing from a DYNO-------------
                //lbl.SetObjectText("lblFirstName", PN);
                //lbl.SetObjectText("lblLastName", PO);
                //lbl.Print("DYMO LabelWriter 450 Turbo");
            }
            else//if receiver number didnt return results
            {
                Console.WriteLine($"Receiver Number {rcvrNum} not found");
                MessageBox.Show("Receiver Number " + rcvrNum + " was not found", "ERROR");
            }


            con.Close();
            txtRevision.Clear();
            txtReceiverNumber.Clear();
            txtReceiverNumber.Focus();


        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Misc2Stock misc2Stock = new Misc2Stock(Username);
        }
    }
}
