using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;

namespace BISyncAutomation
{
    public class Automator
    {

        Application app;
        public Window mainWindow;
        public List<Window> windows = new List<Window>();
        public List<Window> subWindows = new List<Window>();
        public Dictionary<string, AutomationElement> controls = new Dictionary<string, AutomationElement>();

        public Automator(string appName, string windowName, string procPath = null)
        {
            CloseApplication(appName);
            if(procPath != null) { LaunchProcess(procPath); }
            bool procLoaded = false;
            do
            {
                procLoaded = Process.GetProcesses().Any(p => p.ProcessName == appName);
            } while (!procLoaded);
            app = app.GetApplication(appName);
            mainWindow = app.GetMain(windowName);
            mainWindow.Focus();
        }

        public void LaunchProcess(string procPath)
        {
            Process.Start(procPath);
        }

        public void CloseApplication(string appName)
        {
            var procs = Process.GetProcessesByName(appName);
            if(procs != null) {
                for(int i = 0; i < procs.Count(); i++)
                {
                    procs[i].Kill();
                }
            }
        }

        public void RefreshMain(string windowName, string appname = null)
        {


            UIA3Automation auto = new UIA3Automation();
            
            bool windowExists;

            do
            {
                Console.WriteLine($"Searching for '{windowName}' on desktop");
                windowExists = auto.GetDesktop().FindAllDescendants().Any(w => w.Name == windowName);
            } while (!windowExists);
                
            

            if (appname != null)
            {
                app = app.GetApplication(appname);




            }
            mainWindow = app.GetMain(windowName);
            mainWindow.Focus();
        }

        public void ReAcquireApp(string appName)
        {
            Console.WriteLine("Searching for Syteline process");
            app = Application.Attach(Process.GetProcesses().FirstOrDefault(w => w.ProcessName == appName).Id);

            Console.WriteLine("Searching for primary workspace");
            var auto = new UIA3Automation();
            mainWindow = app.GetMainWindow(auto);

            mainWindow.Patterns.Window.Pattern.SetWindowVisualState(WindowVisualState.Normal);
            mainWindow.Focus();

        }

        public void GetRequiredWindows(List<string> windowNames)
        {
            windowNames.ForEach(w => windows.Add(mainWindow.GetWindow(w)));
        }

        public void GetWindow(string windowName)
        {
            Console.WriteLine($"Getting window {windowName}");
            windows.Add(mainWindow.GetWindow(windowName));
        }

        public void GetRequiredControls(List<string> controlNames)
        {
            controlNames.ForEach(c => controls.Add(c, mainWindow.GetElement(c, c)));

        }

        public void GetModalWindow(string windowName)
        {
            windows.Add(mainWindow.ModalWindows.First(w => w.Name == windowName));
        }

        public void GetWindowFromDesktop(string windowName)
        {
            windows.Add(app.GetDesktopWindow(windowName));
        }

        public void GetControl(string controlName, string altWinName = null)
        {
            controls.Add(controlName, mainWindow.GetElement(controlName, controlName));
        }
        public void EnterText(string elementName, string text, int enterType = 0)
        {

            TextBox txt = controls[elementName].AsTextBox();

            text = text.Trim();
            string txtVal = null;
            bool gotVal = txt.Patterns.Value.Pattern.Value.TryGetValue(out txtVal);
            txt.Focus();
            //txt.Click();


            if (txt.IsReadOnly)
            {
                Console.WriteLine($"field is read only - cannot enter value {text}");
                return;
            }
            else if (txtVal != null && txtVal == text)
            {
                Console.WriteLine($"field text already = {text}. Skipping field");
                return;
            }
            else if(text == "" || text == null)
            {
                Console.WriteLine("Text value to enter is empty - skipping field");
            }


            txt.LegacySelect();
            switch (enterType)
            {
                case 0:
                    txt.Text = text;
                    Wait.UntilInputIsProcessed();
                    break;
                case 1:
                    txt.Enter(text);
                    Wait.UntilInputIsProcessed();
                    break;
                case 2:
                    txt.Text = "";
                    Keyboard.Type(text);
                    Wait.UntilInputIsProcessed();
                    break;
                case 3:
                    txt.Patterns.Value.Pattern.SetValue(text);
                    Wait.UntilInputIsProcessed();
                    break;


            }

            Wait.UntilInputIsProcessed();
        }
        public void EnterDirectText(AutomationElement elementName, string text, int enterType = 0)
        {

            TextBox txt = elementName.AsTextBox();

            text = text.Trim();
            string txtVal = null;
            bool gotVal = txt.Patterns.Value.Pattern.Value.TryGetValue(out txtVal);
            txt.Focus();
            //txt.Click();


            if (txt.IsReadOnly)
            {
                Console.WriteLine($"field is read only - cannot enter value {text}");
                return;
            }
            else if (txtVal != null && txtVal == text)
            {
                Console.WriteLine($"field text already = {text}. Skipping field");
                return;
            }
            else if (text == "" || text == null)
            {
                Console.WriteLine("Text value to enter is empty - skipping field");
            }


            txt.LegacySelect();
            switch (enterType)
            {
                case 0:
                    txt.Text = text;
                    Wait.UntilInputIsProcessed();
                    break;
                case 1:
                    txt.Enter(text);
                    Wait.UntilInputIsProcessed();
                    break;
                case 2:
                    txt.Text = "";
                    Keyboard.Type(text);
                    Wait.UntilInputIsProcessed();
                    break;
                case 3:
                    txt.Patterns.Value.Pattern.SetValue(text);
                    Wait.UntilInputIsProcessed();
                    break;


            }

            Wait.UntilInputIsProcessed();
        }

        public void EnterNewText(string elementName, string text)
        {
            TextBox txt = mainWindow.FindFirstDescendant(s => s.ByAutomationId(elementName).Or(s.ByName(elementName))).FindFirstDescendant().AsTextBox();
            txt.Text = text;
        }
        /// <summary>
        /// 0 - Click, 
        /// 1 - Double Click, 
        /// 2 - Invoke, 
        /// 3 - DefaultAction
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="pressType"></param>
        public void PressButton(string elementName, int pressType = 0)
        {
            Button btn = controls[elementName].AsButton();
            switch (pressType)
            {
                case 0:
                    btn.Click();
                    break;
                case 1:
                    btn.DoubleClick();
                    break;
                case 2:
                    btn.Invoke();
                    break;
                case 3:
                    btn.PreformDefaultAction();
                    break;
            }

            Wait.UntilInputIsProcessed();
            Wait.UntilResponsive(mainWindow);

        }

        /// <summary>
        /// 0 - Click, 
        /// 1 - Double Click, 
        /// 2 - Invoke, 
        /// 3 - DefaultAction
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="pressType"></param>
        public void PressMenuItem(string elementName, int pressType)
        {
            MenuItem item = controls[elementName].AsMenuItem();
            switch (pressType)
            {
                case 0:
                    item.Click();
                    break;
                case 1:
                    item.DoubleClick();
                    break;
                case 2:
                    item.Invoke();
                    break;
                case 3:
                    item.PreformDefaultAction();
                    break;
            }
        }

        /// <summary>
        /// 0 - Click, 
        /// 1 - Double Click, 
        /// 2 - Invoke, 
        /// 3 - DefaultAction
        /// </summary>
        /// <param name="menuName"></param>
        /// <param name="itemName"></param>
        /// <param name="pressType"></param>
        public void PressSubMenuItem(string menuName, string itemName, int pressType)
        {
            Menu menu = controls[menuName].AsMenu();
            Console.WriteLine($"MenuItemCount - {menu.Items.Count}");
            menu.Items.ForEach(m => Console.WriteLine($"MenuItem: {m.Name} - {menu.Items.IndexOf(m)}"));

            //MenuItem item = menu.Items.First(i => i.Name == itemName).AsMenuItem();
            //switch (pressType)
            //{
            //    case 0:
            //        item.Click();
            //        break;
            //    case 1:
            //        item.DoubleClick();
            //        break;
            //    case 2:
            //        item.Invoke();
            //        break;
            //    case 3:
            //        item.PreformDefaultAction();
            //        break;
            //}
        }

        public void SelectItemInList(string elementName, string item, int? index)
        {
            ListBox list = controls[elementName].AsListBox();
            list.Items.First(i => i.Name == item).AsListBoxItem().Select();
        }

        public void openWorkSpaces()
        {
            Keyboard.TypeSimultaneously(VirtualKeyShort.CONTROL, VirtualKeyShort.KEY_W);
        }

        public void DoDefault(string elementName)
        {
            Console.WriteLine($"Preforming default action on control {elementName}");
            controls[elementName].PreformDefaultAction();
        }

        public void GetEdit(string paneName)
        {
            var pane = mainWindow.GetElement(paneName, paneName);
            var edit = pane.GetChildElement(0);
            controls.Add(paneName, edit);
        }

        public void HandlePopupWindows()
        {
            int counter = 0;
            Console.WriteLine($"Modal Count: {mainWindow.ModalWindows.Count()}");
            while (counter < 2)
            {
                if (mainWindow.ModalWindows.Count() > 0)
                {
                    Console.WriteLine("Syteline blocked by popup - resetting counter to 0");
                    counter = 0;
                    var modal = mainWindow.ModalWindows[0];
                    var button = mainWindow.FindFirstChild(b => b.ByControlType(ControlType.Button)).AsButton();
                    button.PreformDefaultAction();
                }
                else
                {
                    counter += 1;
                    System.Threading.Thread.Sleep(500);
                }
                Console.WriteLine($"Counter - {counter}");
            }

        }

        public void GetSubWindows(bool closeWindows = false, string keepWindow = null)
        {
            var subWins = mainWindow.FindAllDescendants(w => w.ByControlType(ControlType.Window));
                for (int i = 0; i < subWins.Count(); i++)
                {
                    if (closeWindows && !subWins[i].Name.Contains(keepWindow))
                    {
                        var win = subWins[i].AsWindow();
                        win.Switch();
                        win.Close();
                    }
                    else
                    {
                        subWindows.Add(subWins[i].AsWindow());
                    }
                }

        }

        public void FocusSubWindow(string winName)
        {
            //subWindows.ForEach(w => Console.WriteLine($"WinName: {w.Name}"));
            var subw = subWindows.First(w => w.Name.Contains(winName));
            subw.Focus();
        }

        public void GetDatarow(string elementName, int rowIndex, bool action = false, int? cellIndex = null)
        {
            DataGridView dataGrid = controls[elementName].AsDataGridView();
            var dataRow = dataGrid.Rows[rowIndex];
            if(action && cellIndex != null)
            {
                int idx = cellIndex ?? default(int);
                dataRow.Cells[idx].PreformDefaultAction();
            }
        }

        /// <summary>
        /// Wait for element enable / disable
        /// 
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="state"> 0 = enabled | 1 = disabled </param>
        /// <returns></returns>
        public bool WaitForStateChange(string elementName, int state, bool clickWhile = false)
        {
            var ele = controls[elementName];

            bool enabled = state == 0 ? true : false;
            Console.WriteLine($"Waiting for {elementName} state - {(state == 0 ? "Disabled" : "Enabled")}");
            while(ele.IsEnabled == enabled)
            {
                //if (clickWhile) { ele.PreformDefaultAction(); }
                
                //Thread.Sleep(100);
            }
            return true;

        }

        public void WaitForTextboxReadOnly(string elementName)
        {
            var ele = controls[elementName].AsTextBox();
            while(!ele.IsReadOnly)
            {
                Console.WriteLine($"Waiting for textbox {elementName} to be read only");
                Thread.Sleep(100);
            }

        }

        /// <summary>
        /// 0 - Click, 
        /// 1 - Double Click, 
        /// 2 - Focus, 
        /// 3 - DefaultAction
        /// </summary>
        /// <param name="elementName"> Name of control </param>
        /// <param name="selectMethod"> 0 - Click, 1 - Double Click, 2 - Focus, 3 - DefaultAction</param>
        public void SelectControl(string elementName, int selectMethod = 0)
        {
            var ele = controls[elementName];
            switch (selectMethod)
            {
                case 0:
                    ele.Click();
                    break;
                case 1:
                    ele.DoubleClick();
                    break;
                case 2:
                    ele.Focus();
                    break;
                case 3:
                    ele.PreformDefaultAction();
                    break;
            }
        }

        public void WaitForTextValue(string elementName)
        {
            var ele = controls[elementName].AsTextBox();
            while(ele.Text == "")
            {
                Console.WriteLine($"Waiting for text to be populated in field {elementName}");
                Thread.Sleep(100);
            }
        }

        public bool ControlEnabled(string elementName)
        {
            var ele = controls[elementName];

            return ele.IsEnabled ? true : false;
        }

        public void PressTab()
        {
            Keyboard.Type(VirtualKeyShort.TAB);
        }

        public void PressSubMenuItem(string elementName, string itemName)
        {
            PressMenuItem(elementName,3 );
            var ele = controls[elementName].AsMenuItem();
            var item = ele.Items.FirstOrDefault(m => m.Name == itemName).AsMenuItem();
            item.PreformDefaultAction();

        }

        public void SetValue(string elementName, string value)
        {
            var ele = controls[elementName].AsTextBox();
            ele.Focus();
            ele.SetLegacyValue(value);
        }

        public void PressV()
        {
            Keyboard.Type(VirtualKeyShort.KEY_V);
        }

        public string GetTextBoxValue(string elementName)
        {
             var ele = controls[elementName].AsTextBox();
            return ele.Text;
        }

        public void PressF4()
        {
            Keyboard.Type(VirtualKeyShort.F4);
        }

        public void SetUnit(string SN, bool filter = true)
        {
            //Unit.Focus();
            //Unit.Switch();

            var subw = subWindows.First(w => w.Name.Contains("Units"));
            subw.Switch();
            var FSunit = controls["SerNumEdit"].AsTextBox();
            var FOP = controls["FiP"].AsButton();
            var REF = controls["Refresh"].AsButton();

            FSunit.Click();

            if (FSunit.IsReadOnly) { FOP.Invoke(); do { } while (FSunit.IsReadOnly);


            FSunit.Text = SN;

                if (filter)
                {
                    FOP.Invoke();
                    do { } while (!REF.IsEnabled);
                }
            }

        }

        public void AddUnitNotes(string note)
        {
            var win = mainWindow.FindFirstDescendant(w => w.ByName("Object Notes (Linked)")).AsWindow();
            win.Focus();
            var dgv = mainWindow.FindFirstDescendant(d => d.ByName("DataGridView")).AsDataGridView();

            var row = dgv.NewRow();
            row.Cells[0].AsTextBox().Text = "Unit Converted";
            row.Cells[4].AsTextBox().Text = note;
            //var subject = mainWindow.FindFirstDescendant(s => s.ByName("Filename:")).FindFirstDescendant().AsTextBox();

            //EnterDirectText(subject, "Unit Converted");

            //var notes = mainWindow.FindFirstDescendant(n => n.ByAutomationId("DerContentEdit")).AsTextBox();
            //var noteVal = notes.Text;

            //if(noteVal != "")
            //{
            //    //notes.Enter($"{noteVal}{Environment.NewLine}{note}");
            //    EnterDirectText(notes, $"{noteVal}{Environment.NewLine}{note}");
            //}
            //else
            //{
            //    //notes.Enter(note);
            //    EnterDirectText(notes, note);
            //}
            //subject.DoubleClick();
            //Validate();
            //notes.DoubleClick();
            //Validate();

            //PressButton("Save", 3);

            Validate();
            int saveCounter = 0;
            int retryCounter = 0;
            Keyboard.TypeSimultaneously(VirtualKeyShort.CONTROL, VirtualKeyShort.KEY_V);
            do
            {
                Console.WriteLine($"Waiting for save button to be disabled");
                Thread.Sleep(100);
                saveCounter += 1;
                if(saveCounter >= 5)
                {
                    retryCounter += 3;
                    Keyboard.TypeSimultaneously(VirtualKeyShort.CONTROL, VirtualKeyShort.KEY_V);
                    saveCounter = 0;
                }

            } while (controls["Save"].AsButton().IsEnabled || retryCounter < 4);

            win.Close();
        }

        public void PressF5()
        {
            Keyboard.Type(VirtualKeyShort.F5);
        }

        bool filtered = false;
        
        public void Filter()
        {

            var filter = controls["FiP"].AsButton();
            if(!filtered)
            {
                Console.WriteLine($"Setting filter");
                filter.Invoke();
                filtered = true;
                return;
            }
            else
            {
                Console.WriteLine("Removing filter");
                filter.Invoke();
                filtered = false;
                PressF5();
                return;
            }

        }

        public void Validate()
        {
            //var actions = controls["Actions"].AsMenuItem();
            var actions = mainWindow.FindFirstDescendant(a => a.ByName("Actions")).AsMenuItem();
            actions.PreformDefaultAction();
            PressV();
            //var validate = actions.Items.FirstOrDefault(v => v.Name == "Validate").AsMenuItem();
            //validate.PreformDefaultAction();
            //actions.Items.ForEach(i => Console.WriteLine($"Item: {i.Name} - {actions.Items.IndexOf(i)}"));

            //controls["Validate"].AsMenuItem().Invoke();


        }


    }
}
