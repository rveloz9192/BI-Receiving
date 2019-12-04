using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleTCP;


namespace Engraver
{
    public class Engraver
    {
        SimpleTcpClient client;
        readonly string ip = "192.168.5.101";
        readonly int port = 50002;
        public bool Ready = false;
        public Engraver()
        {
            client = new SimpleTcpClient();
            client.Connect(ip, port);
            client.StringEncoder = Encoding.ASCII;
            client.DataReceived += Client_DataReceived;


        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            string response = e.MessageString;
            if (response.Substring(0, 2) == "B3")
            {
                if (response.Substring(5,7).Contains("TD"))
                {
                    Application.OpenForms["HOME"].Controls.OfType<Label>().First(x => x.Name == "lblCurrent1").Text = response.Substring(5, 9);
                    Application.OpenForms["HOME"].Controls.OfType<Label>().First(x => x.Name == "lblCurrent2").Text = response.Substring(15, 9);
                    Application.OpenForms["HOME"].Controls.OfType<Label>().First(x => x.Name == "lblCurrent3").Text = response.Substring(25, 9);
                    Application.OpenForms["HOME"].Controls.OfType<Label>().First(x => x.Name == "lblCurrent4").Text = response.Substring(35, 9);
                }
                else
                {
                    Application.OpenForms["HOME"].Controls.OfType<Label>().First(x => x.Name == "lblCurrent1").Text = response.Substring(5, 7);
                    Application.OpenForms["HOME"].Controls.OfType<Label>().First(x => x.Name == "lblCurrent2").Text = response.Substring(13, 7);
                    Application.OpenForms["HOME"].Controls.OfType<Label>().First(x => x.Name == "lblCurrent3").Text = response.Substring(21, 7);
                    Application.OpenForms["HOME"].Controls.OfType<Label>().First(x => x.Name == "lblCurrent4").Text = response.Substring(29, 7);
                }

            }
            else if (response.Substring(0, 2) == "RE")
            {
                if (response.Substring(3, 1) == "0")
                {
                    if (response.Substring(5, 1) == "0")
                    {
                        Application.OpenForms["HOME"].Controls.OfType<Label>().First(x => x.Name == "lblReady").Text = "READY ON";
                        Application.OpenForms["HOME"].Controls.OfType<Label>().First(x => x.Name == "lblReady").ForeColor = System.Drawing.Color.FromArgb(0,255,0);

                    }
                    else if (response.Substring(5, 1) == "1")
                    {
                        Application.OpenForms["HOME"].Controls.OfType<Label>().First(x => x.Name == "lblReady").Text = "READY OFF";
                        Application.OpenForms["HOME"].Controls.OfType<Label>().First(x => x.Name == "lblReady").ForeColor = System.Drawing.Color.FromArgb(255,0 , 0);
                    }
                    else if (response.Substring(5, 1) == "2")
                    {
                        Application.OpenForms["HOME"].Controls.OfType<Label>().First(x => x.Name == "lblReady").Text = "READY OFF";
                        Application.OpenForms["HOME"].Controls.OfType<Label>().First(x => x.Name == "lblReady").ForeColor = System.Drawing.Color.FromArgb(255, 0, 0);
                    }
                }
                else
                {
                    MessageBox.Show("An error has ocurred. Please Restart", "Error Status");
                    client.Disconnect();
                    Application.OpenForms["HOME"].Close();
                }
                
            }
        }

        public void ChangeSN(string PRGM, string BLK, string SN)
        {
            client.WriteLine($"C2,000{PRGM},{BLK},{SN}\r");

        }

        public void ReadyStateCheck()
        {
            client.WriteLine($"RE\r");
        }

        public void RequestString(string prog)
        {
           
            switch (prog)
            {
                case "0":
                    client.WriteLine($"B3,0000,000\r");
                    break;
                case "1":
                    client.WriteLine($"B3,0001,000,001,002,003\r");
                    break;
                case "2":
                    client.WriteLine($"B3,0002,000\r");
                    break;
                case "3":
                    client.WriteLine($"B3,0003,000,001,002,003\r");
                    break;
                default:
                    break;
            }
        }

        public void MarkingStart()
        {
            client.WriteLine($"NT\r");
        }

        public void SetProgram(string numLOC8)
        {
            client.WriteLine($"GA,000{numLOC8}\r");
        }

        public void Disconnect()
        {
            client.Disconnect();
        }
    }
}
