using System;
using System.Windows.Forms;

namespace BISync_Receiving
{
    public partial class FrmPopup : Form
    {
        public FrmPopup(string msg)
        {
            InitializeComponent();

            if (msg.Contains("1053") || msg.Contains("fa "))
            {
                Text = "Failure Analysis";
                txtMsg.ForeColor = System.Drawing.Color.FromArgb(255, 60, 60);
                button1.ForeColor = System.Drawing.Color.FromArgb(255, 60, 60);
            }
            else if (msg.Contains("1059"))
            {
                Text = "Code 1059";
                txtMsg.ForeColor = System.Drawing.Color.FromArgb(0, 200, 30);
                button1.ForeColor = System.Drawing.Color.FromArgb(0, 200, 30);
            }
            else if (msg.Contains("1125") || msg.Contains("bug"))
            {
                Text = "Bug Infested";
                txtMsg.ForeColor = System.Drawing.Color.FromArgb(255, 90, 170);
                button1.ForeColor = System.Drawing.Color.FromArgb(255, 90, 170);
            }
            else if (msg.Contains("7777") || msg.Contains("bio"))
            {
                Text = "Biohazard";
                txtMsg.ForeColor = System.Drawing.Color.FromArgb(255, 0, 255);
                button1.ForeColor = System.Drawing.Color.FromArgb(255, 0, 255); ;
            }
            else
            {
                txtMsg.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                button1.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            }
            txtMsg.Text = msg;
        }

        public event EventHandler<EventArgs> PrepMainFormForPopupForm;

        private void FrmPopup_Load(object sender, EventArgs e)
        {
            PrepMainFormForPopupForm(this, EventArgs.Empty);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
