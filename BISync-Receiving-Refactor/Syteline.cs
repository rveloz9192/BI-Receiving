using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using FlaUI.UIA3;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Input;
using BISyncAutomation;
using FlaUI.Core.WindowsAPI;

namespace BISync_Receiving
{
    /// <summary>
    /// Class to automate operations in Syteline.
    /// </summary>
    public class Syteline
    {
        Application app;
        Window SLMainWin, SROTrans, SROOps, Units;
        UIA3Automation auto;
        TextBox serNum;
        Button filter, save, saveClose;
        TabItem svcHistory;
        DataGridView sroDGV;

        bool loaded = false;
        bool cancel = false;
        bool isDangerUnit = false;

        public System.Windows.Forms.ListBox lst;

        /// <summary>
        /// Syteline class constructor.
        /// </summary>
        public Syteline()
        {}
        
        public event EventHandler<EventArgs> PrepMainFormForMessageBox;

        /// <summary>
        /// Finds ui controls for Syteline.
        /// </summary>
        public void Initialize()
        {
            do
            {
                GetControls();
            } while (!loaded && !cancel);
        }

        /// <summary>
        /// Finds the Syteline window and gets the ui controls for the Units form.
        /// </summary>
        /// <remarks>Can't access lst because the control may not be loaded yet.</remarks>
        public void GetControls()
        {
            try
            {
                app = Application.Attach(Process.GetProcesses().FirstOrDefault(w => w.ProcessName == "WinStudio").Id);
            }
            catch (NullReferenceException)
            {
                PrepMainFormForMessageBox(this, EventArgs.Empty);
                System.Windows.Forms.DialogResult dr = System.Windows.Forms.MessageBox.Show("Syteline cannot be found.\nMake sure Syteline has loaded before pressing 'Retry'.", "Syteline Missing", System.Windows.Forms.MessageBoxButtons.RetryCancel);
                lst.ConsoleOut(dr.ToString());
                if (dr == System.Windows.Forms.DialogResult.Cancel)
                {
                    cancel = true;
                    return;
                }
                GetControls(); 
            }

            auto = new UIA3Automation();
            SLMainWin = app.GetMainWindow(auto, TimeSpan.FromSeconds(3));
            Thread.Sleep(1000);
            while (SLMainWin == null)
            {
                PrepMainFormForMessageBox(this, EventArgs.Empty);
                System.Windows.Forms.DialogResult dr = System.Windows.Forms.MessageBox.Show("Syteline window cannot be found.\nSign in to Syteline and open the Units form before pressing 'Retry'.", "Window Missing", System.Windows.Forms.MessageBoxButtons.RetryCancel);
                if (dr == System.Windows.Forms.DialogResult.Cancel)
                {
                    cancel = true;
                    return;
                }
                SLMainWin = app.GetMainWindow(auto, TimeSpan.FromSeconds(3));
            }

            Stopwatch sw = Stopwatch.StartNew();
            while (SLMainWin.ModalWindows.Count() != 0)
            {
                if (sw.Elapsed > TimeSpan.FromSeconds(10))
                {
                    PrepMainFormForMessageBox(this, EventArgs.Empty);
                    System.Windows.Forms.MessageBox.Show("Syteline popup window must be closed in order to continue.", "Syteline Popup");
                }
                //lst.ConsoleOut("Waiting for modal window to be closed.");
            }

            SLMainWin.SwitchUIFocus();

            Units = SLMainWin.GetWindow("Units (Filter In Place)", "Units");
            while (Units == null)
            {
                PrepMainFormForMessageBox(this, EventArgs.Empty);
                System.Windows.Forms.DialogResult dr = System.Windows.Forms.MessageBox.Show("Units form cannot be found.\nOpen the Units form before pressing 'Retry'.", "Units Missing", System.Windows.Forms.MessageBoxButtons.RetryCancel);
                lst.ConsoleOut(dr.ToString());
                if (dr == System.Windows.Forms.DialogResult.Cancel)
                {
                    cancel = true;
                    return;
                }
                Units = SLMainWin.GetWindow("Units (Filter In Place)", "Units");
            }

            Units.SwitchUIFocus();

            //lst.ConsoleOut("Searching for Filter in Place button");
            filter = SLMainWin.FindFirstDescendant("toolStrip").FindFirstChild(b => b.ByName("FiP")).AsButton();
            //lst.ConsoleOut("Searching for save button");
            save = SLMainWin.FindFirstDescendant("toolStrip").FindFirstChild(b => b.ByName("Save")).AsButton();
            //lst.ConsoleOut("Searching for save and close form button");
            saveClose = SLMainWin.FindFirstDescendant("toolStrip").FindFirstChild(b => b.ByName("Save  Close")).AsButton();

            //lst.ConsoleOut("Searching for Serial Number textbox");
            serNum = SLMainWin.GetMaskedEdit(autoID: "SerNumEdit").AsTextBox();
            //lst.ConsoleOut("Searching for Service History tab");
            var UnitTabs = SLMainWin.FindFirstDescendant("Notebook").AsTab();
            svcHistory = UnitTabs.TabItems.First(ti => ti.Name == "Service History").AsTabItem();
            svcHistory.DoDef();

            loaded = true;
            lst.ConsoleOut("Syteline controls aquired");
        }

        /// <summary>
        /// Enters a serial number in Syteline.
        /// </summary>
        /// <param name="serialNumber">The serial number to enter in syteline.</param>
        public string SetSN(string serialNumber)
        {
            Units.SwitchUIFocus();
            if (serNum.IsReadOnly)
            {
                serNum.Click();
                filter.Invoke();
            }
            serNum.Text = serialNumber;
            filter.Invoke();
            return SLMainWin.GetMaskedEdit(autoID: "ItemEdit").Patterns.Value.Pattern.Value.Value.ToString();
        }

        /// <summary>
        /// Selects an sro in Syteline.
        /// </summary>
        /// <param name="sro">The sro to select in Syteline.</param>
        /// <param name="line">The line that the unit belong to in the sro.</param>
        /// <param name="index">The row index that is expected to correspond to the sro in the DataGridView in Syteline.</param>
        public void SelectSRO(string sro, string line, int index)
        {
            Units.SwitchUIFocus();
            svcHistory.Focus();
            sroDGV = SLMainWin.FindFirstDescendant("fsTmpSROLineViewsGrid").AsDataGridView();
            var selRow = sroDGV.Rows[index];
            if (selRow.Cells[0].Value == sro && selRow.Cells[1].Value == line)
            {
                selRow.Cells[0].DoDef();

                return;
            }
            for (int i = 0; i < sroDGV.Rows.Count(); i++)
            {
                var row = sroDGV.Rows[i];
                if (row.Cells[0].Value == sro && row.Cells[1].Value == line)
                {
                    row.Cells[0].DoDef();

                    return;
                }
            }
        }

        /// <summary>
        /// Goes through the process of creating a new sro in Syteline and then selects it.
        /// </summary>
        /// <returns>Name of the sro that has been created.</returns>
        public string CreateSRO()
        {
            lst.ConsoleOut("Creating new sro");
            Stopwatch sw = Stopwatch.StartNew();
            while (SLMainWin.ModalWindows.Count() == 0)
            {
                if (sw.Elapsed > TimeSpan.FromSeconds(15)) throw new InvalidOperationException("Unable to find New SRO popup.");
                lst.ConsoleOut("Clicking Create SRO button");
                SLMainWin.FindFirstDescendant("uf_CreateSROforUnit").AsButton().Click();
            }
            try
            {
                HandlePopup(SLMainWin, "Yes");
            }
            catch (NullReferenceException)
            {
                lst.ConsoleOut("Yes button not found");
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message == "Syteline Error") throw new InvalidOperationException("Syteline error when creating new SRO.");
                else throw;
            }

            sw.Restart();
            while (SLMainWin.ModalWindows.Count() == 0)
            {
                if (sw.Elapsed > TimeSpan.FromSeconds(15)) throw new InvalidOperationException("Unable to find New SRO popup.");
            }
            try
            {
                HandlePopup(SLMainWin, "OK");
            }
            catch (NullReferenceException)
            {
                lst.ConsoleOut("OK button not found");
                throw;
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message == "Syteline Error") throw new InvalidOperationException("Syteline error when creating new SRO.");
                else throw;
            }

            svcHistory.Focus();
            try
            {
                SLMainWin.FindFirstDescendant("fsTmpSROLineViewsGrid").AsDataGridView().Rows[0].Cells[0].DoDef();
            }
            catch   // It does not matter if this fails
            { }
            return SLMainWin.FindFirstDescendant("Notebook").FindFirstDescendant(x => x.ByName("SRO Row 0")).Patterns.Value.Pattern.Value.Value.ToString();
        }

        /// <summary>
        /// Opens an sro in Syteline, then automates the process of submitting the opened sro in Syteline.
        /// </summary>
        /// <remarks>Need to go slow when going from Units form to Transactions since Syteline does not always accept .Click() or can be slow to load a window.</remarks>
        /// <param name="travelerNeeded">Indicates whether a traveler is needed.</param>
        /// <param name="index">The row index that is expected to correspond to the sro in the DataGridView in Syteline.</param>
        /// <param name="unit">The unit code for the selected sro.</param>
        /// <param name="isDirectUnit">Indicates whether the unit is a direct unit.</param>
        /// <param name="isFaUnit">Indicates whether the unit has been received for a Failure Analysis.</param>
        public void SubmitSro(bool travelerNeeded, int index, string unit, bool isDirectUnit, bool isFaUnit)
        {
            lst.ConsoleOut("SubmitSro()");

            AutomationElement solTrans = null;
            AutomationElement solOps = null;

            Units.SwitchUIFocus();

            AutomationElement openSroRow = null;
            Stopwatch sw = Stopwatch.StartNew();
            do
            {
                try
                {
                    openSroRow = GetRowSelector(index);
                }
                // TODO: Determine the expected exception, catch only the expected exception
                catch
                {
                    if (sw.Elapsed > TimeSpan.FromSeconds(5)) throw new InvalidOperationException("Unable to find UI control to open Service Order Lines form.");
                    openSroRow = null;
                    lst.ConsoleOut("");
                    lst.ConsoleOut("Exception when looking for double click location");
                    lst.ConsoleOut("");
                }
            } while (openSroRow == null);
            sw.Start();
            do
            {
                lst.ConsoleOut("Double clicking open sro row");
                try
                {
                    openSroRow.DoubleClick();
                }
                catch (FlaUI.Core.Exceptions.NoClickablePointException) // FLAUI exception is sometimes thrown even when double click is successful
                {
                    lst.ConsoleOut("");
                    lst.ConsoleOut("FLAUI exception when double clicking");
                    lst.ConsoleOut("");
                }
                Wait.UntilResponsive(SLMainWin);
                try
                {
                    solTrans = SLMainWin.FindFirstDescendant("SROLineTransButton");
                    solOps = SLMainWin.FindFirstDescendant("SROOpersButton");
                }
                catch (NullReferenceException)
                {
                    if (sw.Elapsed > TimeSpan.FromSeconds(5)) throw new InvalidOperationException("Unable to find SRO Operations button or SRO Transaction button.");
                    solTrans = null;
                    solOps = null;
                }
            } while (solTrans == null || solOps == null);

            Wait.UntilResponsive(SLMainWin);
            if (isDirectUnit || isFaUnit)
            {
                travelerNeeded = DirectOps(solOps);
                if (isDangerUnit)   // Redundant, should be caught in SqlCli.CheckSROCodes() during UpdateInfoGroupBox() in MainFormPresenter
                {
                    isDangerUnit = false;
                    return;
                }
            }
            SroTrans(unit, travelerNeeded, isDirectUnit, solTrans);
        }

        /// <summary>
        /// Opens the SRO Transactions Form then automates the process of posting a transaction in Syteline.
        /// </summary>
        /// <param name="unit">The unit code for the sro to be submitted.</param>
        /// <param name="travelerNeeded">Indicates whether a traveler is needed.</param>
        /// <param name="isDirectUnit">Indicates whether the unit is a direct unit.</param>
        /// <param name="solTrans">The button in Syteline to open the SRO Transactions Form.</param>
        private void SroTrans(string unit, bool travelerNeeded, bool isDirectUnit, AutomationElement solTrans)
        {
            lst.ConsoleOut("SroTrans()");
            Stopwatch sw = Stopwatch.StartNew();
            do
            {
                if (sw.Elapsed > TimeSpan.FromSeconds(5)) throw new InvalidOperationException("Unable to find SRO Transactions Form.");
                lst.ConsoleOut("Pressing SRO Trans button");
                solTrans.AsButton().DoDef();
                Wait.UntilResponsive(SLMainWin);
                SROTrans = SLMainWin.GetWindow("SRO Transactions ", "SRO ");
            } while (SROTrans == null);
            Wait.UntilResponsive(SLMainWin);
            SROTrans.SwitchUIFocus();

            var MaterialTabs = SLMainWin.FindFirstDescendant("Notebook").AsTab();
            MaterialTabs.TabItems.First(ti => ti.Name == "Line Material").AsTabItem().DoDef();

            CheckNotes();

            var reasonCode = MaterialTabs.GetMaskedEdit(autoID: "uf_SROOperReason").Patterns.Value.Pattern.Value.Value.ToString();
            if (reasonCode == "1125" || reasonCode == "7777")   // Redundant, these codes should be caught in SqlCli.CheckSROCodes() during UpdateInfoGroupBox() in MainFormPresenter
            {
                FrmPopup popup = new FrmPopup($"Code {reasonCode}");
                popup.PrepMainFormForPopupForm += PrepMainFormForMessageBox;
                popup.ShowDialog();
                return;
            }

            string loc;
            if (isDirectUnit)
            {
                loc = GetDirectLocation(reasonCode);
            }
            else
            {
                loc = GetMonLocation(unit, reasonCode);
            }

            var location = MaterialTabs.FindFirstDescendant(tb => tb.ByName("Location Row 0"));
            location.SetVal(SLMainWin, loc);

            var traveler = MaterialTabs.FindFirstDescendant("uf_PrintSROTravelerButton").AsButton();
            var postTrans = SLMainWin.FindFirstDescendant("PostLineButton").AsButton();
            if (save.IsEnabled)
            {
                lst.ConsoleOut("Saving");
                save.DoDef();
                Wait.UntilResponsive(SLMainWin);
                if (postTrans.IsEnabled)
                {
                    lst.ConsoleOut("Posting");
                    postTrans.DoDef();
                    Wait.UntilResponsive(SLMainWin);
                }

                if (travelerNeeded)
                {
                    traveler.Click();
                    sw.Start();
                    while (SLMainWin.ModalWindows.Count() == 0)
                    {
                        if (sw.Elapsed > TimeSpan.FromSeconds(8)) throw new InvalidOperationException("Print Traveler button not working.");
                    }
                    try
                    {
                        HandlePopup(SLMainWin, "OK");
                    }
                    catch (NullReferenceException)
                    {
                        lst.ConsoleOut("OK button not found");
                        throw;
                    }
                    catch (InvalidOperationException ex)
                    {
                        if (ex.Message == "Syteline Error") throw new InvalidOperationException("Syteline error when printing traveler.");
                        else throw;
                    }
                    Wait.UntilResponsive(SLMainWin);
                }
                lst.ConsoleOut("Transaction has been posted");
                var unpostTrans = SLMainWin.FindFirstDescendant("UnpostLineButton").AsButton(); ;
                if (unpostTrans.IsEnabled)
                {
                    saveClose.DoDef();
                    Wait.UntilResponsive(SLMainWin);
                    try
                    {
                        Units.SwitchUIFocus();
                        lst.ConsoleOut("Resetting serial number in syteline");
                        if (serNum.IsReadOnly)
                        {
                            serNum.Focus();
                            try
                            {
                                serNum.Click();
                                filter.DoDef();
                            }
                            catch
                            {
                                lst.ConsoleOut("Failed to toggle filter");
                                return;
                            }
                        }
                        serNum.Text = "";
                    }
                    // TODO: Determine the expected exception, catch only the expected exception
                    catch
                    {
                        lst.ConsoleOut("Failed to clear serial number on Units");
                    }
                }
            }
            else
            {
                lst.ConsoleOut("Transaction NOT posted");
                if (travelerNeeded)
                {
                    PrepMainFormForMessageBox(this, EventArgs.Empty);
                    System.Windows.Forms.MessageBox.Show("Unable to save and/or Post transaction. Please contact Supervisor." +
                        "\n\nThis unit requires a traveler be printed.");
                }
                else
                {
                    PrepMainFormForMessageBox(this, EventArgs.Empty);
                    System.Windows.Forms.MessageBox.Show("Unable to save and/or Post transaction. Please contact Supervisor.");
                }
            }
        }

        /// <summary>
        /// Opens the SRO Operations Form then closes the sro or pauses so the user can enter notes in Syteline.
        /// </summary>
        /// <param name="solOps">The button in Syteline to open the SRO Operations Form.</param>
        /// <returns>Bool indicating whether a traveler is needed for the sro to be submitted.</returns>
        private bool DirectOps(AutomationElement solOps)
        {
            lst.ConsoleOut("DirectOps");
            Stopwatch sw = Stopwatch.StartNew();
            do
            {
                if (sw.Elapsed > TimeSpan.FromSeconds(5)) throw new InvalidOperationException("Unable to find Service Order Operations Form.");
                lst.ConsoleOut("Pressing SRO Ops button");
                solOps.AsButton().DoDef();
                Wait.UntilResponsive(SLMainWin);
                SROOps = SLMainWin.GetWindow("Service Order Operations (Linked)", "Service ");
            } while (SROOps == null);
            Wait.UntilResponsive(SLMainWin);
            SROOps.SwitchUIFocus();

            var today = DateTime.Now.ToString();
            var receivedDate = SLMainWin.GetMaskedEdit(autoID: "OpenDateEdit");
            var floorDate = SLMainWin.GetMaskedEdit(autoID: "CloseDateEdit");
            receivedDate.SetVal(SLMainWin, today);
            floorDate.SetVal(SLMainWin, today);

            var reasons = SLMainWin.FindFirstDescendant("Notebook").AsTab();
            reasons.TabItems.First(ti => ti.Name == "Reasons").AsTabItem().DoDef();

            bool traveler = false;
            var status = SLMainWin.GetMaskedEdit(autoID: "StatEdit");
            var reasonCode = reasons.FindFirstDescendant(x => x.ByName("General Reason Row 0")).AsGridCell().Patterns.Value.Pattern.Value.Value.ToString();
            switch (reasonCode)
            {
                case "7777":    // Redundant, this code should be caught in SqlCli.CheckSROCodes() during UpdateInfoGroupBox() in MainFormPresenter
                    FrmPopup popup = new FrmPopup($"Code {reasonCode}");
                    popup.PrepMainFormForPopupForm += PrepMainFormForMessageBox;
                    popup.ShowDialog();
                    isDangerUnit = true;
                    break;
                case "1125":    // Redundant, this code should be caught in SqlCli.CheckSROCodes() during UpdateInfoGroupBox() in MainFormPresenter
                    popup = new FrmPopup($"Code {reasonCode}");
                    popup.PrepMainFormForPopupForm += PrepMainFormForMessageBox;
                    popup.ShowDialog();
                    isDangerUnit = true;
                    break;
                case "1048":
                    status.SetVal(SLMainWin, "Closed");
                    break;
                case "1050":
                    status.SetVal(SLMainWin, "Closed");
                    break;
                case "1052":
                    status.SetVal(SLMainWin, "Closed");
                    break;
                default:
                    PrepMainFormForMessageBox(this, EventArgs.Empty);
                    System.Windows.Forms.MessageBox.Show("In Reason Notes block, scan or enter the serial number of any paired units.\n\n" +
                        "In Resolution Notes block, scan or enter all included accessories from Accessories Sheet.\n\n" +
                        "When finished entering Notes press 'OK'.", "Fill Notes");
                    traveler = true;
                    break;
            }
            sw.Restart();
            saveClose.DoDef();
            if (sw.Elapsed > TimeSpan.FromMilliseconds(1500))   // Needs real world testing
            {
                PrepMainFormForMessageBox(this, EventArgs.Empty);
                System.Windows.Forms.MessageBox.Show("If Syteline popup indicating an invalid date came up, " +
                    "go to general tab and manual select todays date for 'Received' and clear 'Floor' before clicking 'OK'.\n\n" +
                    "If there was no popup from Syteline then click 'OK' to continue.", "Syteline Date Issue");
                saveClose.DoDef();
            }
            
            Thread.Sleep(1000);
            if (SLMainWin.ModalWindows.Count() > 0) // Needs real world testing
            {
                HandlePopup(SLMainWin, "OK");
            }
            return traveler;
        }

        /// <summary>
        /// Displays notes if they contain a keyword.
        /// </summary>
        private void CheckNotes()
        {
            lst.ConsoleOut("Checking notes");
            SROTrans.SwitchUIFocus();
            string note = SLMainWin.FindFirstDescendant("uf_SROOperReasonNotes").Patterns.Value.Pattern.Value.Value.ToString().ToLower();
            List<string> keywords = new List<string> { "route", "bio", "biohazard", "bug", "fa ", "f/a", "fail", "anal", "hepc", "hep c", "hepat", "hiv", "h.i.v.", "mrsa", "staph", "death", "dead", "deceased", "fluid", "blood", "poo", "feces", "danger" };
            if (note == "") return;
            if (keywords.Any(x => note.Contains(x)))
            {
                lst.ConsoleOut("Keyword found, opening popup window to display note");
                FrmPopup popup = new FrmPopup(note);
                popup.PrepMainFormForPopupForm += PrepMainFormForMessageBox;
                popup.ShowDialog();
            }
        }

        /// <summary>
        /// Finds the ui control, for the selected row, that will allow the sro to be opened.
        /// </summary>
        /// <param name="index">The row index that is expected to correspond to the sro in the DataGridView in Syteline.</param>
        /// <returns>Automation element needed to open an sro in syteline</returns>
        private AutomationElement GetRowSelector(int index)
        {
            lst.ConsoleOut("Searching for control to view SRO.");

            string cellName = $"SRO Row {index}";
            AutomationElement cellElement = SLMainWin.FindFirstDescendant(c => c.ByName(cellName));
            AutomationElement targetElement = null;

            if (cellElement.Patterns.LegacyIAccessible.Pattern.State.Value.ToString().Contains("SELECTED"))
            {
                targetElement = cellElement.Parent.FindFirstChild();
            }
            else
            {
                for (int i = 0; i < sroDGV.Rows.Count(); i++)
                {
                    if (sroDGV.Rows[i].Cells[0].Patterns.LegacyIAccessible.Pattern.State.Value.ToString().Contains("SELECTED"))
                    {
                        cellName = $"SRO Row {i}";
                        cellElement = SLMainWin.FindFirstDescendant(c => c.ByName(cellName));
                        targetElement = cellElement.Parent.FindFirstChild();
                        continue;
                    }
                }
            }

            return targetElement;
        }

        /// <summary>
        /// Determines the location to set in Syteline based on the given unit code or reason code.
        /// </summary>
        /// <param name="unit">The unit code for the sro to be submitted</param>
        /// <param name="reasonCode">The reason code for the sro to be submitted.</param>
        /// <returns>Location that the unit will go to.</returns>
        private string GetMonLocation(string unit, string reasonCode)
        {
            if (reasonCode == "1053")
            {
                return "ZZFA-FLOOR";
            }
            else if (unit == "EX-650-M")
            {
                return "ZZTIG";
            }
            else if (unit == "EX-600V-M" || unit == "EX-600S-M" || unit == "EX-600-M" || unit == "EX-625V-M" || unit == "EX-625S-M" || unit == "EX-625-M")
            {
                return "ZZSVC-ET1CAL";
            }

            return "ZZService";
        }

        /// <summary>
        /// Determines the location to set in Syteline based on the given reason code.
        /// </summary>
        /// <param name="reasonCode">The reason code for the sro to be submitted.</param>
        /// <returns>Location that the unit will go to.</returns>
        private string GetDirectLocation(string reasonCode)
        {
            switch (reasonCode)
            {
                case "1053":
                    return "ZZFA-FLOOR";
                case "1050":
                    return "ZZRTS";
                case "1052":
                    return "ZZRTS";
                default:
                    return "ZZService";
            }
        }

        /// <summary>
        /// Click specified button for the first modal window belonging to a given window.
        /// </summary>
        /// <param name="mainWin">The parent window for the expected modal window.</param>
        /// <param name="buttonText">The text of the button to be clicked.</param>
        private void HandlePopup(Window mainWin, string buttonText)
        {
            lst.ConsoleOut($"Checking for {buttonText} button");
            var modalWin = mainWin.ModalWindows[0];
            modalWin.SwitchUIFocus();
            if (modalWin.FindChildAt(1).Name.Contains("ERROR"))
            {
                lst.ConsoleOut("ERROR message from Syteline");
                throw new InvalidOperationException("Syteline Error");
            }
            lst.ConsoleOut($"Clicking {buttonText} button");
            modalWin.FindFirstDescendant(b => b.ByName(buttonText)).AsButton().DoDef();
        }

        public void WaitForReceivingWS()
        {
            string procPath = @"\\bldrsyte8ut01\Syteline\SLClientDeploy\Syteline.application";
            Automator syteline = new Automator("WinStudio", "Sign In", procPath);
            Application app = Application.Attach(Process.GetProcesses().FirstOrDefault(w => w.ProcessName == "WinStudio").Id);
            auto = new UIA3Automation();
            SLMainWin = app.GetMainWindow(auto, TimeSpan.FromSeconds(3));
            while (SLMainWin == null)
            {
                SLMainWin = app.GetMainWindow(auto, TimeSpan.FromSeconds(3));
            }
            syteline.RefreshMain("Infor ERP SL (EM)", "WinStudio");                    
            Keyboard.TypeSimultaneously(VirtualKeyShort.CONTROL, VirtualKeyShort.KEY_W);
            //syteline.GetWindow("Workspaces - Infor ERP SL");
            syteline.GetControl("Receiving");
            syteline.DoDefault("Receiving");
            syteline.GetControl("Open and Exit");
            syteline.PressButton("Open and Exit", 2);

        }
    }
}
