using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BISync_Receiving
{
    public class MainFormPresenter
    {
        private IMainView view;

        private Dictionary<int, Label> labelDict;
        private Dictionary<string, bool> statDict;
        private Dictionary<string, string[]> prodDict;
        private Dictionary<string, string[]> syteInfoDict;
        private Dictionary<string, string> scannerDict;

        private enum SyteInfo { Sro, Line, Date, Item, Code, Status, Reason, Index, Note };

        private List<string> expectedUnits; // Not actually used

        private bool isDirectUnit;
        private bool isDangerUnit;
        private bool isFaUnit;

        private Scanner scanner;
        private Syteline syteline;
        private Unit unit;

        /// <summary>
        /// MainFormPresenter class constructor.
        /// </summary>
        /// <param name="view"></param>
        public MainFormPresenter(IMainView view)
        {
            this.view = view;
        }

        public event EventHandler<EventArgs> ResetMainForm;
        public event EventHandler<EventArgs> BringMainFormToForeground;

        /// <summary>
        /// Initializes dictionaries and helper classes for the MainFormPresenter class and sets up events for the view.
        /// </summary>
        public void Initialize()
        {
            scanner = new Scanner();
            syteline = new Syteline() { lst = view.ListOutput };
            syteline.PrepMainFormForMessageBox += BringMainFormToForeground;
            syteline.Initialize();

            labelDict = new Dictionary<int, Label>();
            statDict = new Dictionary<string, bool>();
            prodDict = new Dictionary<string, string[]>();
            scannerDict = new Dictionary<string, string>();

            SetLabelDict();
            SetProdDict();
            SetScannerDict();

            expectedUnits = SqlCli.LoadExpectedUnits(); // Never used, data from LoadExpectedUnits() is not worth using

            view.GetSerialNumber += GetSerialNumber;
            view.GetSroStatus += GetSroStatus;
            view.UpdateInfoGroupBox += UpdateInfoGroupBox;
            view.SubmitUnitManual += SubmitUnitManual;
            view.ResetInfoGroupLabels += ResetInfoGroupLabels;
        }

        //
        // Events
        //

        /// <summary>
        /// Activates scanner or Calls LookUpUnit using the serial number entered by user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetSerialNumber(object sender, EventArgs e)
        {
            ResetLabelsInLabelDict();

            switch (view.RunButtonText)
            {
                case "Lookup":
                    try
                    {
                        LookUpUnit(view.SerialNumber);
                        BringMainFormToForeground(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        BringMainFormToForeground(this, EventArgs.Empty);
                        MessageBox.Show("An error has occured.\n" +
                            "The issue is with the GetSerialNumber function.\n\n" + 
                            "Close all Syteline forms, other than the Units form, before pressing 'OK'.\n\n" +
                            "Details:\n" + ex.Message, "Unhandled Exception");
                        view.ListOutput.ConsoleOut("");
                        view.ListOutput.ConsoleOut("Exception requiring fresh start");
                        view.ListOutput.ConsoleOut("");

                        view.SytelineActive = true;
                        syteline.GetControls();
                        view.SytelineActive = false;

                        ResetMainForm(this, EventArgs.Empty);
                    }
                    break;
                case "Scan":
                    view.RunButtonText = "Cancel";
                    //string bank = prodDict[view.Product][0];
                    //ScanBarcode(bank);
                    ScanBarcode(null);
                    break;
                case "Cancel":
                    scanner.Cancel(scannerDict[view.SelectedScanner]);
                    view.RunButtonText = "Scan";
                    break;
            }
        }

        /// <summary>
        /// Submits the selected sro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitUnitManual(object sender, EventArgs e)
        {
            if (isDangerUnit)
            {
                BringMainFormToForeground(this, EventArgs.Empty);
                MessageBox.Show("This unit cannot be submitted. Check the reason code to determine if it is a Biohazard or Bug Infested.", "Hazardous Unit");
                return;
            }

            var sro = view.SelectedSro;
            var openDate = syteInfoDict[sro][(int)SyteInfo.Date].Split(' ')[0].Split(' ')[0];

            if (!statDict[sro])
            {
                BringMainFormToForeground(this, EventArgs.Empty);
                MessageBox.Show($"The selected SRO, {sro}, is not open.", "SRO Closed");
                return;
            }
            else if (!CheckSroDate(openDate))
            {
                BringMainFormToForeground(this, EventArgs.Empty);
                DialogResult dr = MessageBox.Show("The selected SRO is older than 35 days.\n\n" +
                    "Continue with the selected SRO?", "Outdated SRO", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                {
                    return;
                }

                var isTravelerNeeded = prodDict[unit.product][1] == "traveler";
                var selectedSroIndex = view.SroList.IndexOf(sro);

                view.SytelineActive = true;
                syteline.SubmitSro(isTravelerNeeded, selectedSroIndex, unit.item, isDirectUnit, isFaUnit);
                view.SytelineActive = false;

                ResetMainForm(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fills labels in the MainForm.infoGroupBox with data associated with the selected sro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateInfoGroupBox(object sender, EventArgs e)
        {
            ResetLabelsInLabelDict();

            var sro = view.SelectedSro;
            var info = syteInfoDict[sro];
            var line = info[(int)SyteInfo.Line];
            var index = int.Parse(info[(int)SyteInfo.Index]);

            for (int i = 0; i < info.Count(); i++)
            {
                if (!labelDict.ContainsKey(i))
                    continue;
                var lbl = labelDict[i];
                lbl.Text += info[i];
            }
            view.Notes = info[(int)SyteInfo.Note];
            view.ListOutput.ConsoleOut("Calling CheckSROCodes");
            SqlCli.PrepMainFormForMessageBox += BringMainFormToForeground;
            var reasonCode = SqlCli.CheckSROCodes(sro, line);
            SqlCli.PrepMainFormForMessageBox -= BringMainFormToForeground;

            switch (reasonCode)
            {
                case "1125":
                    isDangerUnit = true;
                    return;
                case "7777":
                    isDangerUnit = true;
                    return;
                case "1053":
                    isFaUnit = true;
                    break;
                default:
                    break;
            }

            if (!view.SytelineActive)
            {
                view.SytelineActive = true;
                syteline.SelectSRO(sro, line, index);
                view.SytelineActive = false;
            }
        }

        /// <summary>
        /// Calls ResetLabelsInLabelDict.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetInfoGroupLabels(object sender, EventArgs e)
        {
            ResetLabelsInLabelDict();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetSroStatus(object sender, CustomEventArgs e)
        {
            view.SroStatus = statDict[e.Message];
        }

        //
        // Methods
        //

        /// <summary>
        /// Activates scanner then calls LookUpUnit with the serial number received from scanner.
        /// </summary>
        /// <param name="bank"></param>
        private void ScanBarcode(string bank)
        {
           if (view.SelectedScanner == "Select Scanner")
            {
                MessageBox.Show("Select station number in order to connect to scanner.", "Station not selected");
                view.RunButtonText = "Scan";
                return;
            }
            //var value = scanner.SendMessage($"LON{bank}", scannerDict[view.SelectedScanner]);
            var value = scanner.SendMessage($"LON{bank}", scannerDict[view.SelectedScanner]);
            switch (value)
            {
                case "Read Error":
                    view.RunButtonText = "Scan";
                    BringMainFormToForeground(this, EventArgs.Empty);
                    MessageBox.Show("Read error when scanning Unit.");
                    break;
                case "Socket":
                    view.RunButtonText = "Scan";
                    BringMainFormToForeground(this, EventArgs.Empty);
                    MessageBox.Show("Unable to connect to scanner.");
                    break;
                case "":
                    view.RunButtonText = "Scan";
                    break;
                default:
                    view.SerialNumber = value;
                    try
                    {
                        view.RunButtonText = "Lookup";
                        LookUpUnit(view.SerialNumber);
                    }
                    catch (Exception ex)
                    {
                        BringMainFormToForeground(this, EventArgs.Empty);
                        MessageBox.Show("An error has occured.\n" +
                            "The issue is with the ScanBarcode function.\n\n" +
                            "Close all Syteline forms, other than the Units form, before pressing 'OK'.\n\n" +
                            "Details:\n" + ex.Message, "Unhandled Exception");
                        view.ListOutput.ConsoleOut("");
                        view.ListOutput.ConsoleOut("Exception requiring fresh start");
                        view.ListOutput.ConsoleOut("");

                        view.SytelineActive = true;
                        syteline.GetControls();
                        view.SytelineActive = false;
                        ResetMainForm(this, EventArgs.Empty);
                    }
                    break;
            }
        }

        /// <summary>
        /// Gets all sro's associated with serialNumber.
        /// </summary>
        /// <param name="serialNumber"></param>
        private void LookUpUnit(string serialNumber)
        {
            view.ListOutput.ConsoleOut($"Looking up unit: {serialNumber}");
            unit = new Unit(serialNumber, view.Username, BringMainFormToForeground);
            if (unit.serialNumber == null)
            {
                unit = new Unit("*" + serialNumber.Substring(3), view.Username, BringMainFormToForeground);
                    if (unit.serialNumber == null)
                {
                    return;
                }
            }

            view.SytelineActive = true;
            unit.item = syteline.SetSN(unit.serialWithPref);
            view.SytelineActive = false;
            isDirectUnit = !unit.item.ToLower().Contains("-m");

            view.SerialNumber = unit.serialNumber;
            view.SerialNumberSet = true;
            view.ListOutput.ConsoleOut("Calling LoadSyteInfo");
            syteInfoDict = SqlCli.LoadSyteInfo(unit.serialWithPref);
            int openSroCount = 0;
            if (syteInfoDict.Count > 0)
            {
                unit.productCode = syteInfoDict.Values.First()[(int)SyteInfo.Code];

                statDict.Clear();
                foreach (var sro in syteInfoDict)
                {
                    bool isOpen = false;
                    if (sro.Value[(int)SyteInfo.Status] == "Open")
                    {
                        isOpen = true;
                        openSroCount++;
                    }
                    statDict.Add(sro.Key, isOpen);
                }
                view.SroList = syteInfoDict.Keys.ToList();

                if (isDirectUnit && openSroCount == 0)
                {
                    BringMainFormToForeground(this, EventArgs.Empty);
                    MessageBox.Show("This unit does not have a valid SRO, add to NO SRO spreadsheet(found on desktop).", "No SRO");
                    return;
                }
            }
            else
            {
                if (isDirectUnit)
                {
                    BringMainFormToForeground(this, EventArgs.Empty);
                    MessageBox.Show("This unit does not have a valid SRO, add to NO SRO spreadsheet(found on desktop).", "No SRO");
                    return;
                }

                statDict.Clear();
                CreateNewSro();
                openSroCount ++;
            }

            if (!view.ManualSelection)
            {
                SubmitUnitAuto(openSroCount);
            }
        }

        /// <summary>
        /// Calls Syteline.SubmitSro after checking if the selected sro is valid.
        /// </summary>
        /// <param name="openSroCount"></param>
        private void SubmitUnitAuto(int openSroCount)
        {
            if (isDangerUnit)
            {
                BringMainFormToForeground(this, EventArgs.Empty);
                MessageBox.Show("This unit cannot be submitted. Check the reason code to determine if it is a Biohazard or Bug Infested.", "Hazardous Unit");
                return;
            }

            string openSro;
            if (openSroCount == 0)
            {
                openSro = CreateNewSro();
            }
            else
            {
                openSro = GetOpenSro();
                view.SelectedSro = openSro;
                var openDate = syteInfoDict[openSro][(int)SyteInfo.Date].Split(' ')[0];
                if (!CheckSroDate(openDate))
                {
                    if (isDirectUnit)
                    {
                        BringMainFormToForeground(this, EventArgs.Empty);
                        MessageBox.Show("This unit does not have a valid SRO, add to NO SRO spreadsheet(found on desktop).", "No SRO");
                        return;
                    }

                    openSro = CreateNewSro();
                }
            }

            var isTravelerNeeded = prodDict[unit.product][1] == "traveler";
            var selectedSroIndex = view.SroList.IndexOf(openSro);

            view.SytelineActive = true;
            syteline.SubmitSro(isTravelerNeeded, selectedSroIndex, unit.item, isDirectUnit, isFaUnit);
            view.SytelineActive = false;

            ResetMainForm(this, EventArgs.Empty);
        }

        /// <summary>
        /// Gets the first open sro associated with the selected serial number.
        /// </summary>
        /// <returns></returns>
        private string GetOpenSro()
        {
            foreach (var sro in view.SroList)
            {
                if (statDict[sro] == true)
                {
                    return sro;
                }
            }
            throw new InvalidOperationException("No open SRO exist.");
        }

        private bool CheckSroDate(string openDate)
        {
            var oD = openDate.Split('/').Select(x => Convert.ToInt32(x)).ToArray();
            return (DateTime.Today - new DateTime(oD[2], oD[0], oD[1])).Days <= 35 ? true : false;
        }

        /// <summary>
        /// Creates new sro in Syteline.
        /// </summary>
        /// <returns></returns>
        private string CreateNewSro()
        {
            view.SytelineActive = true;
            var sro = syteline.CreateSRO();
            view.SytelineActive = false;

            syteInfoDict.Add(sro, new string[] { sro, "1", DateTime.Now.ToString(), unit.item, unit.productCode, "Open", "1000", "0", "" });
            statDict.Add(sro, true);
            view.NewSro = sro;

            return sro;
        }

        /// <summary>
        /// Adds labels with tags from MainForm.infoGroupBox to labelDict.
        /// </summary>
        /// <remarks>
        /// Keys are the number stored in tags which correspond to the indexes from SqlCli.LoadSyteInfo.
        /// Values are the labels.
        /// </remarks>
        private void SetLabelDict()
        {
            foreach (var label in view.InfoLabels)
            {
                if ((string)label.Tag != "" && label.Tag != null)
                {
                    labelDict.Add(Convert.ToInt32(label.Tag), label);
                }
            }
        }

        /// <summary>
        /// Adds products from dictionary in app.config to prodDict.
        /// </summary>
        /// <remarks>
        /// Keys are the products.
        /// Values are the corresponding scanner bank and if a traveler is needed.
        /// </remarks>
        private void SetProdDict()
        {
            var products = new List<string>();
            foreach (string key in System.Configuration.ConfigurationManager.AppSettings.Keys)
            {
                if (key.Contains("St.") || key == "XMT" || key == "BI9010 XMTR") continue;
                var data = System.Configuration.ConfigurationManager.AppSettings[key];
                var sdata = data.Split('|');
                prodDict.Add(key, sdata);
                products.Add(key);
            }
            view.ProductList = products;
        }

        private void SetScannerDict()
        {
            var scanners = new List<string>();
            scanners.Add("Select Scanner");
            foreach (string key in System.Configuration.ConfigurationManager.AppSettings.Keys)
            {
                if (key.Contains("St."))
                {
                    var data = System.Configuration.ConfigurationManager.AppSettings[key];
                    scannerDict.Add(key, data);
                    scanners.Add(key);
                }
            }
            view.ScannerList = scanners;
        }

        /// <summary>
        /// Clears text from labels in the MainForm.infoGroupBox.
        /// </summary>
        private void ResetLabelsInLabelDict()
        {
            isDangerUnit = false;
            isFaUnit = false;

            foreach (var label in labelDict.Values)
            {
                label.Text = "";
            }
            view.Notes = "";
        }
    }
}
