using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenLabel
{
    public partial class Main : Form
    {
        static Main _obj;

        private bool isFormBeingDragged = false;
        private int mouseDownX;
        private int mouseDownY;
        public string Usrname;




        public Main(string username)
        {
            Usrname = username;
            InitializeComponent();

            var uc0 = new UCHome(Usrname);
            uc0.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc0);

            var uc1 = new UCM2S(Usrname);
            uc1.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc1);

            var uc2 = new UCISAP(Usrname);
            uc2.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc2);

            pnlContainer.Controls["UCHome"].BringToFront();
        }




        private void BtnHome_Click(object sender, EventArgs e)
        {
            
            pnlSide.Height = btnHome.Height;
            pnlSide.Top = btnHome.Top;
            lblHeader.Text = btnHome.Text;

            pnlContainer.Controls["UCHome"].BringToFront();
            
        }

        private void BtnM2S_Click(object sender, EventArgs e)
        {

            pnlSide.Height = btnM2S.Height;
            pnlSide.Top = btnM2S.Top;
            lblHeader.Text = btnM2S.Text;

            pnlContainer.Controls["UCM2S"].BringToFront();
        }

        private void BtnISAP_Click(object sender, EventArgs e)
        {

                pnlSide.Height = btnISAP.Height;
                pnlSide.Top = btnISAP.Top;
                lblHeader.Text = btnISAP.Text;

                pnlContainer.Controls["UCISAP"].BringToFront();
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
