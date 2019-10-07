using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace GreenLabel
{
    public partial class UCISAP : UserControl
    {
        string insp, numCopies, po, partNum, dateReceived;
        private void NumberCopies_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnPrint_Click(sender, e);
            }
        }

        private void TxtPO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnPrint_Click(sender, e);
            }
        }

        private void TxtPartNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnPrint_Click(sender, e);
            }
        }

        public UCISAP(string username)
        {
            insp = username;
            InitializeComponent();
            dateDateReceived.Value = DateTime.Today;
            this.Show();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            partNum = txtPartNumber.Text;
            po = txtPO.Text;
            numCopies = numberCopies.Value.ToString();
            dateReceived = dateDateReceived.Value.ToString("d");

            //Logic for printing from a Zebra

            string s = $"^XA^PW609^LL406\n" +
                        $"^FO205,20^CF0,40,40^FDBI ACCEPTED^FS\n" +
                        $"^FO10,100^CF0,60,40^FDPN:^FS\n" +
                        $"^FO80,60^CF0,120,60^FD{partNum}^FS\n" +
                        $"^FO10,160^CF0,30,25^FDPO#:^FS\n" +
                        $"^FO80,160^CF0,30,25^FD{po}^FS\n" +
                        $"^FO10,220^FDDATE:^FS\n" +
                        $"^FO80,210^FD{dateReceived}^FS\n" +
                        $"^FO10,280^FDINSP:^FS\n" +
                        $"^FO80,280^FD{insp.Substring(0, 2).ToUpper()}^FS\n" +
                        $"^PQ{numCopies}\n" +
                        $"^XZ";


            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog(this))
            {
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s);
            }


            numberCopies.Value = 1;
            txtPartNumber.Clear();
            txtPartNumber.Focus();
        }
    }
}
