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
    public partial class Form1 : Form
    {
        static Form1 _obj;

        private bool isFormBeingDragged = false;
        private int mouseDownX;
        private int mouseDownY;
        public string Usrname;



        public Form1(string username)
        {
            Usrname = username;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _obj = this;

            UCHome uc = new UCHome(Usrname);
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);

        }



        public static Form1 Instance
        {
            get
            {
                //if (_obj == null)
                //{
                //    _obj = new Form1();
                //}
                return _obj;
            }
        }

        public Panel PanelContainer
        {
            get { return pnlContainer; }
            set { pnlContainer = value; }
        }

        public Button HomeButton
        {
            get { return btnHome; }
            set { btnHome = value; }
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

            if (!pnlContainer.Controls.ContainsKey("UCM2S"))
            {
                UCM2S uc = new UCM2S(Usrname);
                uc.Dock = DockStyle.Fill;
                pnlContainer.Controls.Add(uc);
            }
            pnlContainer.Controls["UCM2S"].BringToFront();
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
