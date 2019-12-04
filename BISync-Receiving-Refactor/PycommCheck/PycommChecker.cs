using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PycommCheck
{
    public partial class PycommChecker : Form
    {
        private bool isFormBeingDragged;
        private int mouseDownY;
        private int mouseDownX;
        public static string conString = "Data Source=172.16.4.27;Initial Catalog=MfgTraveler;Persist Security Info=True;User ID=travelmfg;Password=Tr@vel@mfg";
        private SqlConnection con = new SqlConnection(conString);
        private string sqlCompletedIDsQuery = $@"   
                                                DROP TABLE Completed

                                                CREATE TABLE Completed
	                                                (
		                                                Id varchar(max)
	                                                )

                                                INSERT INTO Completed
	                                                SELECT  Id
	                                                From PyComm
	                                                Where Status LIKE 'C_'";

        private string sqlNewCompletedQuery = $@"SELECT *
	                                                FROM PyComm
	                                                WHERE Id NOT IN (Select Id FROM Completed)
	                                                AND Status like 'C_'";
        

        public PycommChecker()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
        }

        private void UpdateCompletedIDs()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand(sqlCompletedIDsQuery, con);
            cmd.ExecuteNonQuery();

            con.Close();

        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand(sqlNewCompletedQuery, con);
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataTable dtNew = new DataTable();
            DA.Fill(dtNew);

            con.Close();

            if (dtNew.Rows.Count > 0)
            {
                UpdateCompletedIDs();

                foreach (DataRow dr in dtNew.Rows)
                {
                    lstbxUnits.Invoke(new MethodInvoker(delegate { lstbxUnits.Items.Add(dr[1].ToString() + " " + DateTime.Now.ToString()); }));
                }

            }

           
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void PnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isFormBeingDragged = true;
                mouseDownX = e.X;
                mouseDownY = e.Y;
            }
        }

        private void PnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (isFormBeingDragged)
            {
                Point temp = new Point();

                temp.X = this.Location.X + (e.X - mouseDownX);
                temp.Y = this.Location.Y + (e.Y - mouseDownY);
                this.Location = temp;
                temp = new Point();
            }
        }

        private void PnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isFormBeingDragged = false;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LblHeader_MouseDown(object sender, MouseEventArgs e)
        {
            PnlHeader_MouseDown(sender,e);
        }

        private void LblHeader_MouseMove(object sender, MouseEventArgs e)
        {
            PnlHeader_MouseMove(sender, e);
        }

        private void LblHeader_MouseUp(object sender, MouseEventArgs e)
        {
            PnlHeader_MouseUp(sender, e);
        }


    }
}
