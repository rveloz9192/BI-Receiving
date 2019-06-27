using System;
using System.Windows.Forms;
using BISync_Receiving;
using BISyncAutomation;
using DYMO.Label.Framework;


namespace GreenLabel
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
                Application.Run(new Form1(frmLogin.UserName));
            }
        }
    }
}
