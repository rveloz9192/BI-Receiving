using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace RSSI
{
    public partial class Main : Form
    {
        private bool isFormBeingDragged;

        string netPath = @"\\exaculog02\ET1-Logs\", RSSI, SerialNumber, fileName= $@"Q:\Roberto\Excel\Test.xlsx";
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        DirectoryInfo Folder;
        private int mouseDownX, mouseDownY;
        DateTime time;
        List<int> RSSIs = new List<int>();
        int rssi, numSeries = 0;
        Microsoft.Office.Interop.Excel.Application xlApp;
        Workbook xlWorkBook;
        Worksheet xlWorkSheet;
        Range xlRange;

        public Main()
        {
            InitializeComponent();
            chart1.Series.Clear();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            SerialNumber = txtSerialNumber.Text;

            if (SerialNumber.Length != 7)
            {
                MessageBox.Show("Incorrect Serial Number", "ERROR");
                goto _end;
            }

            try
            {
                Folder = new DirectoryInfo(netPath).GetDirectories(SerialNumber).First();
            }
            catch
            {
                MessageBox.Show("Folder Not Found", "Folders");
                goto _end;
            }
            //if (Folder == null)
            //{
            //    MessageBox.Show("Folder Not Found", "Folders");
            //    goto _end;
            //}

            openFile();

            if (!chcklstEnabled.Items.Contains(SerialNumber))
            {
                chcklstEnabled.Items.Add(SerialNumber);

                chart1.Series.Add(SerialNumber);
                chart1.Series[numSeries].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                chart1.Series[numSeries].BorderWidth = 2;
                chart1.Series[numSeries].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;


                var Files = new DirectoryInfo(Folder.FullName).GetFiles().Where(f => (f.Length > 0)).OrderBy(f => f.CreationTime);
                int i = 1; 
                foreach (var file in Files)
                {
                    int j = 1;
                    time = file.LastWriteTime;
                    xlWorkSheet.Cells[i, j++] = time.ToString("MM-dd-yyyy HH.mm.ss");

                    doc.Load(file.FullName);
                    var Nodes = doc.DocumentNode.SelectNodes("//text()[normalize-space(.) !='']").Where(n => n.InnerText.Contains("RSSI:"));
                    if (Nodes.Count() > 0)
                    {
                        foreach (var node in Nodes)
                        {
                            rssi = Int32.Parse(node.InnerText.Substring(node.InnerText.IndexOf("RSSI:") + 5, 2));

                            xlWorkSheet.Cells[i, j++] = rssi;
                            RSSIs.Add(rssi);
                        }

                        RSSI = RSSIs.Average().ToString();
                        RSSIs.Clear();

                        chart1.Series[numSeries].Points.AddXY(time, Double.Parse(RSSI)); ;
                        i++;
                   
                    }
                }
                numSeries++;
            }

            xlApp.ScreenUpdating = false;
            xlApp.DisplayAlerts = false;

            xlWorkBook.Close(true, fileName);

            xlApp.ScreenUpdating = true;
            xlApp.DisplayAlerts = true;
_end:
            Cursor.Current = Cursors.Default;
            txtSerialNumber.Focus();
            txtSerialNumber.SelectAll();
        }

        private void openFile()
        {
            // Opening or creating new file for unit
            fileName = $@"Q:\Roberto\Excel\{SerialNumber}.xlsx";
            xlApp = new ApplicationClass();
            if (File.Exists(fileName))
            {
                xlWorkBook = xlApp.Workbooks.Open(fileName);
            }
            else
            {
                xlWorkBook = xlApp.Workbooks.Add();
            }
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.Add();

            xlWorkSheet.Name = DateTime.Now.ToString("MM-dd-yyyy HH.mm.ss");
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void TxtSerialNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) BtnAdd_Click(sender, e);
        }

        private void PnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (isFormBeingDragged)
            {
                System.Drawing.Point temp = new System.Drawing.Point();

                temp.X = this.Location.X + (e.X - mouseDownX);
                temp.Y = this.Location.Y + (e.Y - mouseDownY);
                this.Location = temp;
                temp = new System.Drawing.Point();
            }
        }

        private void PnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isFormBeingDragged = false;
            }
        }

        private void BtnEnable_Click(object sender, EventArgs e)
        {
            foreach (int i in chcklstEnabled.CheckedIndices)
            {
                chart1.Series[chcklstEnabled.Items[i].ToString()].Enabled = true;
                chcklstEnabled.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void BtnDisable_Click(object sender, EventArgs e)
        {
            foreach (int i in chcklstEnabled.CheckedIndices)
            {
                chart1.Series[chcklstEnabled.Items[i].ToString()].Enabled = false;
                chcklstEnabled.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
    }
}
