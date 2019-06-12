using System;
using System.Windows.Forms;

namespace BISync_Receiving
{
    public partial class FrmLogin : Form
    {
        public string UserName { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
            KeyDown += FrmLogin_KeyDown;
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtUser.Text.Trim() != "" && txtPass.Text.Trim() != "")
                cmdLogin.Enabled = true;
            else
                cmdLogin.Enabled = false;
        }

        private void CmdLogin_Click(object sender, EventArgs e)
        {
            bool authenticate = false;
            try
            {
                authenticate = SqlCli.Login(txtUser.Text, txtPass.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected exception caught. Program may require a restart.\n\n" +
                    $"Exception Message: {ex.Message}", "Unhandled Exception");
            }

            if (authenticate)
                {
                    UserName = txtUser.Text;
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    txtPass.Clear();
                    txtUser.Focus();
                    txtUser.SelectAll();
                }
        }

        private void LnkReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegister reg = new FrmRegister();
            reg.Show();
        }
    }
}
