using System;
using System.Windows.Forms;
using BISync_Receiving;
using BISyncAutomation;
using DYMO.Label.Framework;


namespace GreenLabel
{
    static class programGL
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
                // Application.Run(new QA(frmLogin.UserName));
                Application.Run(new Main(frmLogin.UserName));
             


            }
        }
    }
}
