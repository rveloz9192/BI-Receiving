using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engraver.TAD.ADM
{
    public partial class HOME : Form
    {
        public string BLK = "001", SN;
        private bool isFormBeingDragged = false;
        private int mouseDownX;
        private int mouseDownY;
        private Engraver engraver = new Engraver();
        public string PRGM = "3";
        public string Product = "TAD";

        public HOME()
        {
            InitializeComponent();
        }

        private void TADADM_Load(object sender, EventArgs e)
        {
            BtnTAD_Click(sender, e);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            engraver.Disconnect();
            this.Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void PnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isFormBeingDragged = false;
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

        private void BtnTAD_Click(object sender, EventArgs e)
        {

            //Set the side panel for selected button
            pnlSide.Height = btnTAD.Height;
            pnlSide.Top = btnTAD.Top;
            lblHeader.Text = "TAD Engraver";

            // Set the Product
            Product = "TAD";

            

            //Formating layout
                //Formating Labels
                lblUnit1.Text = "TAD,1";
                lblUnit2.Text = "TAD,2";
                lblUnit3.Text = "TAD,3";
                lblUnit4.Text = "TAD,4";
            numUnits.Value = 3;
            Thread.Sleep(100);

            //Resetting timers
            timerGetSettings.Enabled = false;
            timerReady.Enabled = false;            
            timerGetSettings.Enabled = true;
            Thread.Sleep(250);
            timerReady.Enabled = true;
        }

        private void BtnADM_Click(object sender, EventArgs e)
        {
            //Set the side panel for selected button
            pnlSide.Height = btnADM.Height;
            pnlSide.Top = btnADM.Top;
            lblHeader.Text = "ADM Engraver";

            // Set the Product and the program;
            Product = "ADM";
            



            //Formating layout
                //Formating Labels
                lblUnit1.Text = "ADM,1";
                lblUnit2.Text = "ADM,2";
                lblUnit3.Text = "ADM,3";
                lblUnit4.Text = "ADM,4";
            numUnits.Value = 3;
            Thread.Sleep(100);

            //Resetting timers
            timerGetSettings.Enabled = false;
            timerReady.Enabled = false;
            timerGetSettings.Enabled = true;
            Thread.Sleep(250);
            timerReady.Enabled = true;
        }



        private void TimerGetSettings_Tick(object sender, EventArgs e)
        {
            engraver.RequestString(PRGM);
            if (lblReady.Text == "READY ON")
            {
                btnStart.Enabled = true;
            }
            else
            {
                btnStart.Enabled = false;
            }
        }

        private void TxtUnit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Enabled = false;

                if (Product == "TAD")
                {
                    if (txtUnit1.Text.Length == 9 && txtUnit1.Text.Substring(2, 7).All(char.IsDigit) && txtUnit1.Text.StartsWith("TD"))
                    {
                        BLK = "000";
                        SN = txtUnit1.Text;
                        engraver.ChangeSN(PRGM, BLK, SN);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid Serial Number for {lblUnit1.Text}: {txtUnit1.Text}");
                    }
                }
                else
                {
                    if (txtUnit1.Text.Length == 7 && txtUnit1.Text.All(char.IsDigit))
                    {
                        BLK = "000";
                        SN = txtUnit1.Text;
                        engraver.ChangeSN(PRGM, BLK, SN);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid Serial Number for {lblUnit1.Text}: {txtUnit1.Text}");
                    }
                }
                Enabled = true;
                txtUnit2.Focus();
                txtUnit2.SelectAll();
            }
        }

        private void TxtUnit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Enabled = false;
                if (Product == "TAD")
                {
                    if (txtUnit2.Text.Length == 9 && txtUnit2.Text.Substring(2, 7).All(char.IsDigit) && txtUnit2.Text.StartsWith("TD"))
                    {
                        BLK = "001";
                        SN = txtUnit2.Text;
                        engraver.ChangeSN(PRGM, BLK, SN);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid Serial Number for {lblUnit2.Text} {txtUnit2.Text}");
                    }
                }
                else
                {
                    if (txtUnit2.Text.Length == 7 && txtUnit2.Text.All(char.IsDigit))
                    {
                        BLK = "001";
                        SN = txtUnit2.Text;
                        engraver.ChangeSN(PRGM, BLK, SN);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid Serial Number for {lblUnit2.Text} {txtUnit2.Text}");
                    }
                }
                Enabled = true;
                txtUnit3.Focus();
                txtUnit3.SelectAll();


            }
        }

        private void TxtUnit3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Enabled = false;
                if (Product == "TAD")
                {
                    if (txtUnit3.Text.Length == 9 && txtUnit3.Text.Substring(2, 7).All(char.IsDigit) && txtUnit3.Text.StartsWith("TD"))
                    {
                        BLK = "002";
                        SN = txtUnit3.Text;
                        engraver.ChangeSN(PRGM, BLK, SN);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid Serial Number for {lblUnit3.Text} {txtUnit3.Text}");
                    }
                }
                else
                {
                    if (txtUnit3.Text.Length == 7 && txtUnit3.Text.All(char.IsDigit))
                    {
                        BLK = "002";
                        SN = txtUnit3.Text;
                        engraver.ChangeSN(PRGM, BLK, SN);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid Serial Number for {lblUnit3.Text} {txtUnit3.Text}");
                    }
                }
                Enabled = true;
                txtUnit4.Focus();
                txtUnit4.SelectAll();

            }
        }

        private void TxtUnit4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Enabled = false;
                if (Product == "TAD")
                {
                    if (txtUnit4.Text.Length == 9 && txtUnit4.Text.Substring(2, 7).All(char.IsDigit) && txtUnit4.Text.StartsWith("TD"))
                    {
                        BLK = "003";
                        SN = txtUnit4.Text;
                        engraver.ChangeSN(PRGM, BLK, SN);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid Serial Number for {lblUnit4.Text} {txtUnit4.Text}");
                    }
                }
                else
                {
                    if (txtUnit4.Text.Length == 7 && txtUnit4.Text.All(char.IsDigit))
                    {
                        BLK = "003";
                        SN = txtUnit4.Text;
                        engraver.ChangeSN(PRGM, BLK, SN);
                    }
                    else
                    {
                        MessageBox.Show($"Invalid Serial Number for {lblUnit4.Text} {txtUnit4.Text}");
                    }
                }
                Enabled = true;
                txtUnit1.Focus();
                txtUnit1.SelectAll();


            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            engraver.MarkingStart();
        }

        private void NumUnits_ValueChanged(object sender, EventArgs e)
        {
            
                switch (numUnits.Value)
                {
                    case 1:
                        if (Product == "TAD")
                        {
                            PRGM = "2";
                        }
                        else
                        {
                            PRGM = "0";
                        }
                        //Setting visibility
                        lblUnit2.Visible = false;
                        lblUnit3.Visible = false;
                        lblUnit4.Visible = false;
                        txtUnit2.Visible = false;
                        txtUnit3.Visible = false;
                        txtUnit4.Visible = false;
                        lblCurrent2.Visible = false;
                        lblCurrent3.Visible = false;
                        lblCurrent4.Visible = false;
                        break;
                    case 4:
                        if (Product == "TAD")
                        {
                            PRGM = "3";
                        }
                        else
                        {
                            PRGM = "1";
                        }
                        //Setting visibility
                        lblUnit2.Visible = true;
                        lblUnit3.Visible = true;
                        lblUnit4.Visible = true;
                        txtUnit2.Visible = true;
                        txtUnit3.Visible = true;
                        txtUnit4.Visible = true;
                        lblCurrent2.Visible = true;
                        lblCurrent3.Visible = true;
                        lblCurrent4.Visible = true;
                        break;
                    default:
                        numUnits.Value = 4;
                        return;

                }
           
            
            //Clearing all txtboxes
            txtUnit1.Clear();
            txtUnit2.Clear();
            txtUnit3.Clear();
            txtUnit4.Clear();

            //Setting the program
            engraver.SetProgram(PRGM);
        }

        private void TimerReady_Tick(object sender, EventArgs e)
        {
            engraver.ReadyStateCheck();
        }

        
        

        
    }

   
}
