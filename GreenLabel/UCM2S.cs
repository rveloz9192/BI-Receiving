﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace GreenLabel
{
    public partial class UCM2S : UserControl
    {
        string insp;
        string rev;
        string partNum;
        private static readonly string sCon = "Data Source=bldrsyte8db01;Initial Catalog=EM_App;Persist Security Info=True;User ID=Travelmfg;Password=Tr@vel@mfg";
        SqlConnection con = new SqlConnection(sCon);

        public UCM2S(string username)
        {
            insp = username;
            InitializeComponent();
            this.Show();
        }

       

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            partNum = txtPartNumber.Text;
            string numCopies = numberCopies.Value.ToString();
            rev = txtRevision.Text;


            //--------------------------Logic for printing from a Zebra------------------------

            //string s = $"^XA^PW700\n^FO250,50^ADN,30,20^FDBI ACCEPTED^FS\n^FO0,150^ADN,90,40^FDPN:{PN}^FS\n^FO0,250^ADN,50,30^FDPO#:{PO}^FS\n^FO0,310^ADN,90,30^FDDate:{time}^FS\n^FO0,410^ADN,50,30^FDINSP:{Username.Substring(0,2)}^FS\n^FO0,470^ADN,90,30^FDREV:{rev}^FS\n^XZ";

            string s = $"^XA^PW609^LL406\n" +
                        $"^FO205,20^CF0,40,40^FDBI ACCEPTED^FS\n" +
                        $"^FO10,100^CF0,60,40^FDPN:^FS\n" +
                        $"^FO80,60^CF0,120,60^FD{partNum}^FS\n" +
                        $"^FO10,160^CF0,30,25^FDPO#:^FS\n" +
                        $"^FO10,220^FDREV:^FS\n" +
                        $"^FO10,280^FDDATE:^FS\n" +
                        $"^FO10,340^FDINSP:^FS\n" +
                        $"^FO80,340^FD{insp.Substring(0, 2).ToUpper()}^FS\n" +
                        $"^FO80,200^CF0,60,60^FD{rev.ToUpper()}^FS\n" +
                        $"^FO80,270^FD{DateTime.Today.ToString("MM/dd/yyyy")}^FS\n" +
                        $"^FO80,160^CF0,30,25^FDMISC TO STOCK^FS\n" +
                        $"^PQ{numCopies}\n" +
                        $"^XZ";


            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog(this))
            {
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s);
            }

            //------------------Logic for printing from a DYNO-------------
            //lbl.SetObjectText("lblFirstName", PN);
            //lbl.SetObjectText("lblLastName", PO);
            //lbl.Print("DYMO LabelWriter 450 Turbo");

            con.Close();
            txtRevision.Text = "A";
            numberCopies.Value = 1;
            txtPartNumber.Clear();
            txtPartNumber.Focus();
        }

        private void TxtPartNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnPrint_Click(this, new EventArgs());
            }
        }

        private void TxtRevision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnPrint_Click(this, new EventArgs());
            }
        }

        private void NumberCopies_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnPrint_Click(this, new EventArgs());
            }
        }

        private void UCM2S_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnPrint_Click(this, new EventArgs());
            }
        }
    }
}
