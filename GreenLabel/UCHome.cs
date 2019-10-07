using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace GreenLabel
{
    public partial class UCHome : UserControl
    {
        string rcvrNum;
        string rev, PO, PN, RcvdDate;
        SqlConnection con = new SqlConnection(sCon);
        bool printerSelected = false;
        String printerName;
        String Username { get; }
        //ILabel lbl = DYMO.Label.Framework.Label.Open("C:\\Users\\rveloz\\source\\repos\\roger-maddocks-bi\\GreenLabel\\Resources\\Lbl.label");
        private static readonly string sCon = "Data Source=bldrsyte8db01;Initial Catalog=EM_App;Persist Security Info=True;User ID=Travelmfg;Password=Tr@vel@mfg";

        

        public UCHome(string username)
        {
            Username = username;
            InitializeComponent();
            this.Show();
        }

       

        

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            rcvrNum = txtReceiverNumber.Text;
            string numCopies = numberCopies.Value.ToString();
            rev = txtRevision.Text;
            PN = txtPartNumber.Text;
            PO = txtPO.Text;


            // Check to see if receiver number returned information
            if (PO != "") //dt1.Rows.Count > 0)
            {
                




                //--------------------------Logic for printing from a Zebra------------------------


                string s = $"^XA^PW609^LL406\n" +
                            $"^FO205,20^CF0,40,40^FDBI ACCEPTED^FS\n" +
                            $"^FO10,100^CF0,60,40^FDPN:^FS\n" +
                            $"^FO80,60^CF0,120,60^FD{PN}^FS\n" +
                            $"^FO10,160^CF0,30,25^FDPO#:^FS\n" +
                            $"^FO80,160^CF0,30,25^FD{PO}^FS\n" +
                            $"^FO10,220^FDREV:^FS\n" +
                            $"^FO80,200^CF0,60,60^FD{rev.ToUpper()}^FS\n" +
                            $"^FO80,270^FD{RcvdDate}^FS\n" +
                            $"^FO10,280^CF0,30,25^FDDATE:^FS\n" +
                            $"^FO10,340^FDINSP:^FS\n" +
                            $"^FO80,340^FD{Username.Substring(0, 2).ToUpper()}^FS\n" +
                            $"^PQ{numCopies}\n" +
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
            txtReceiverNumber.Clear();
            txtRevision.Text = "A";
            txtPO.Clear();
            txtPartNumber.Clear();
            numberCopies.Value = 1;
            txtReceiverNumber.Focus();


        }

        private void TxtReceiverNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnPrint_Click(this, new EventArgs());
            }
        }
        private void TxtPartNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnPrint_Click(this, new EventArgs());
            }
        }

        private void TxtPO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnPrint_Click(this, new EventArgs());
            }
        }

        private void TxtReceiverNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtReceiverNumber.Text.All(char.IsDigit))
            {
                rcvrNum = txtReceiverNumber.Text;
                SqlCommand cmd = new SqlCommand(@"Select r.item, r.ref_num, p.revision, p.rcvd_date
	                                                From RS_QCRcvr r
	                                                LEFT JOIN poitem p
		                                                ON r.ref_num = p.po_num and r.item = p.item and r.ref_line = p.po_line
	                                                Where rcvr_num = @RCVRNUM", con);
                cmd.Parameters.AddWithValue("@RCVRNUM", rcvrNum);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        PN = dt.Rows[0][0].ToString();
                        PO = dt.Rows[0][1].ToString();
                        rev = dt.Rows[0][2].ToString();
                        RcvdDate = Convert.ToDateTime(dt.Rows[0][3].ToString()).ToString("MM/dd/yyyy");
                    }
                    catch
                    {
                        Console.WriteLine($"Information incomplete for receiver {rcvrNum}");
                    }



                }
                else
                {
                    rev = RcvdDate = PO = PN = "";
                }

                con.Close();
                txtRevision.Text = rev;
                txtPO.Text = PO;
                txtPartNumber.Text = PN;
            }
            else
            {
                txtReceiverNumber.Clear();
            }
        }

        private void TxtRevision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnPrint_Click(this, new EventArgs());
            }
        }

        private void NumberCopies_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnPrint_Click(this, new EventArgs());
            }
        }

        private void UCHome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnPrint_Click(this, new EventArgs());
            }
        }

    }
    
}
