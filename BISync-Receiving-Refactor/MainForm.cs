using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BISync_Receiving
{
    /// <summary>
    /// Main form for the BISync Receiving application.
    /// </summary>
    public partial class MainForm : Form, IMainView
    {
        private MainFormPresenter presenter;

        /// <summary>
        /// Initializes a new instance of the MainForm class.
        /// </summary>
        /// <param name="username">The username for the user that is logged in.</param>
        public MainForm(string username)
        {
            Username = username;
            InitializeComponent();
            this.Show();
        }

        public string Username { get; }

        public string Product
        {
            get { return productComboBox.SelectedItem.ToString(); }
        }

        public string SerialNumber
        {
            get { return serialNumberTextBox.Text; }
            set { serialNumberTextBox.Text = value; serialNumberTextBox.Refresh(); }
        }

        public string RunButtonText
        {
            get { return runButton.Text; }
            set { runButton.Text = value; runButton.Refresh(); }
        }

        public string SelectedSro
        {
            get { return sroListBox.SelectedItem.ToString(); }
            set
            {
                foreach (var sro in sroListBox.Items)
                {
                    if (sroListBox.GetItemText(sro) == value)
                    {
                        sroListBox.SelectedItem = sro;
                        sroListBox.Refresh();
                        return;
                    }
                }
            }
        }

        public string NewSro
        {
            set
            {
                sroListBox.Items.Insert(0, value);
                sroListBox.Refresh();
            }
        }

        public string Date
        {
            get { return dateDataLabel.Text; }
        }

        public string Notes
        {
            set { notesTextBox.Text = value; notesTextBox.Refresh(); }
        }

        public string SelectedScanner
        {
            get { return stationComboBox.SelectedItem.ToString(); }
        }
        
        public bool ManualSelection
        {
            get { return manualCheckBox.Checked; }
            set { manualCheckBox.Checked = value; }
        }

        public bool SerialNumberSet { get; set; } = false;

        public bool SytelineActive { get; set; } = false;

        public bool? SroStatus { get; set; } = null;

        public List<string> ProductList
        {
            set
            {
                productComboBox.InvokeIfRequired(() => { foreach (var product in value) { productComboBox.Items.Add(product); } productComboBox.SelectedIndex = 0; });
            }
        }

        public List<string> SroList
        {
            get
            {
                return sroListBox.Items.OfType<string>().ToList();
            }
            set
            {
                foreach (var sro in value)
                {
                    sroListBox.Items.Add(sro);
                }
                sroListBox.Refresh();
            }
        }

        public List<string> ScannerList
        {
            set
            {
                stationComboBox.InvokeIfRequired(() => { foreach (var scanner in value) { stationComboBox.Items.Add(scanner); } stationComboBox.SelectedIndex = 0; });
            }
        }

        public IEnumerable<Label> InfoLabels
        {
            get { return infoGroupBox.Controls.OfType<Label>(); }
        }

        public ListBox ListOutput
        {
            get { return listOutput; }
        }

        public event EventHandler<EventArgs> UpdateInfoGroupBox;
        public event EventHandler<EventArgs> GetSerialNumber;
        public event EventHandler<EventArgs> ResetInfoGroupLabels;
        public event EventHandler<EventArgs> SubmitUnitManual;
        public event EventHandler<CustomEventArgs> GetSroStatus;

        //
        // Events
        //

        private void SerialNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SerialNumberSet)
            {
                SerialNumberSet = false;
                sroListBox.Items.Clear();
                ResetInfoGroupLabels(this, EventArgs.Empty);
            }
            if (serialNumberTextBox.Text.Length == 0)
            {
                runButton.Text = "Scan";
            }
            else
            {
                runButton.Text = "Lookup";
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            presenter = new MainFormPresenter(this);
            presenter.ResetMainForm += ResetMainForm;
            presenter.BringMainFormToForeground += PrepareForMessageBox;
            presenter.Initialize();

            serialNumberTextBox.Enter += SerialNumberTextBox_Enter;
            sroListBox.DrawItem += SroListBox_DrawItem;
            sroListBox.SelectedIndexChanged += SroListBox_SelectedIndexChanged;

            serialNumberTextBox.Enabled = true;
            serialNumberTextBox.Focus();
            this.BringToForeground();
            runButton.Enabled = true;
        }

        private void SerialNumberTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            sroListBox.Items.Clear();
            GetSerialNumber(this, EventArgs.Empty);
        }

        private void SroListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            int index = e.Index;
            if (index < 0) return;
            string sro = sroListBox.Items[index].ToString();

            GetSroStatus(sender, new CustomEventArgs(sro));
            while (SroStatus == null) // wait for GetSroStatus to finish
            {
                Console.WriteLine("Waiting on GetSroStatus");
            }
            Graphics g = e.Graphics;

            SolidBrush brush = new SolidBrush((bool)SroStatus ? Color.FromArgb(192, 255, 192) : Color.FromArgb(255, 192, 192));
            g.FillRectangle(brush, e.Bounds);

            SolidBrush foreground = new SolidBrush(selected ? Color.Black : Color.LightGray);
            g.DrawString(sro, e.Font, foreground, sroListBox.GetItemRectangle(index).Location);

            g.DrawRectangle(new Pen(foreground), e.Bounds);

            e.DrawFocusRectangle();

            SroStatus = null; // reset SroStatus
        }
        
        private void SroListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateInfoGroupBox(sender, EventArgs.Empty);
        }

        private void ManualCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (manualCheckBox.Checked)
            {
                sroListBox.MouseDoubleClick += SroListBox_MouseDoubleClick;
            }
            else
            {
                sroListBox.MouseDoubleClick += null;
            }
        }

        private void SroListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = sroListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                SubmitUnitManual(sender, EventArgs.Empty);
            }
        }

        private void ResetMainForm(object sender, EventArgs e)
        {
            this.BringToForeground();
            serialNumberTextBox.Clear();
            serialNumberTextBox.Focus();
        }

        private void PrepareForMessageBox(object sender, EventArgs e)
        {
            this.BringToForeground();
        }
    }
}
