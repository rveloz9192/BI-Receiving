using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BISync_Receiving
{
    public partial class FrmRegister : Form
    {
        List<string> userlist = new List<string>();
        List<TextBox> fields = new List<TextBox>();

        public FrmRegister()
        {
            InitializeComponent();
            userlist = SqlCli.LoadUsernames();
            foreach(TextBox txt in this.Controls.OfType<TextBox>())
            {
                txt.Tag = false;
                fields.Add(txt);
                txt.BackColorChanged += Txt_BackColorChanged;
            }
        }

        private void Txt_BackColorChanged(object sender, EventArgs e)
        {
            int counter = 0;
            foreach (TextBox txt in fields)
            {
                if (txt.BackColor == Color.FromArgb(192,255,192))
                {
                    counter++;
                }
            }

            if (counter == fields.Count)
            {
                cmdSubmit.Enabled = true;
                cmdSubmit.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 192);
            }
            else
            {
                cmdSubmit.Enabled = false;
                cmdSubmit.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            }
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        private void txtFirst_TextChanged(object sender, EventArgs e)
        {
            if (txtFirst.Text.Length < 2)
            {
                txtFirst.BackColor = Color.FromKnownColor(KnownColor.Window);
                txtFirst.Tag = false;
                return;
            }
            else
            {
                txtFirst.BackColor = Color.FromArgb(192, 255, 192);
                txtFirst.Tag = true;
            }
            
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            string user = txtUser.Text.ToUpper();
            if (user.Length < 4)
            {
                txtUser.BackColor = Color.FromKnownColor(KnownColor.Window);
                txtUser.Tag = false;
                return;
            }
            if (!userlist.Contains(user))
            {
                txtUser.BackColor = Color.FromArgb(192, 255, 192);
                txtUser.Tag = true;
            }
            else
            {
                txtUser.BackColor = Color.FromArgb(255, 192, 192);
                Console.WriteLine($"Username {user} exists at index {userlist.IndexOf(user)}");
                txtUser.Tag = false;
            }
        }

        private void txtLast_TextChanged(object sender, EventArgs e)
        {
            if (txtLast.Text.Length < 2)
            {
                txtLast.BackColor = Color.FromKnownColor(KnownColor.Window);
                txtLast.Tag = false;
                return;
            }
            else
            {
                txtLast.BackColor = Color.FromArgb(192, 255, 192);
                txtLast.Tag = true;
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (txtPass.Text.Length < 6)
            {
                txtPass.BackColor = Color.FromKnownColor(KnownColor.Window);
                txtPass.Tag = false;
                return;
            }
           else
            {
                txtPass.BackColor = Color.FromArgb(192, 255, 192);
                txtPass.Tag = true;
                txtConf_TextChanged(sender, e);
            }
           
        }

        private void txtConf_TextChanged(object sender, EventArgs e)
        {
            if (txtConf.Text.Length < 1)
            {
                txtConf.BackColor = Color.FromKnownColor(KnownColor.Window);
                txtConf.Tag = false;
                return;
            }

            if (txtConf.Text == txtPass.Text)
            {
                txtConf.BackColor = Color.FromArgb(192, 255, 192);
                txtConf.Tag = true;

            }
            else
            {
                txtConf.BackColor = Color.FromArgb(255, 192, 192);
                txtConf.Tag = false;
            }
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            string first = txtFirst.Text.CapFirstLetter();
            string last = txtLast.Text.CapFirstLetter();
            string user = txtUser.Text;
            string pass = txtPass.Text;
            string full = string.Format($"{first} {last}");
            SqlCli.RegisterUser(first, last, user, pass, full);
            Close();
        }
    }
}
