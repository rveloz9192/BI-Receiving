using System;
using System.Windows.Forms;



namespace BISync_Receiving
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmLogin frmLogin = new FrmLogin();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                Syteline syteline = new Syteline();
                syteline.WaitForReceivingWS();
                Application.Run(new MainForm(frmLogin.UserName));
            }
        }
    }
}
