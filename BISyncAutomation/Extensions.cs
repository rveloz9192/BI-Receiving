using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Patterns;
using FlaUI.Core.Shapes;
using FlaUI.UIA3;

namespace BISyncAutomation
{
    public static class Extensions
    {
        public static Application GetApplication(this Application app, string appName)
        {
            Application application;
            do
            {
                Console.WriteLine($"Searching for application '{appName}'");
                application = Application.Attach(Process.GetProcesses().FirstOrDefault(w => w.ProcessName == appName).Id);
            }
            while (application == null);
            return application;
        }

        public static Window GetDesktopWindow(this Application application, string windowName)
        {
            Window window;
            using (UIA3Automation auto = new UIA3Automation())
            {
                window = auto.GetDesktop().FindFirstDescendant(w => w.ByName(windowName)).AsWindow();
            }
            return window;
        }
        public static Window GetMain(this Application application, string windowName)
        {
            Window window;
            using (UIA3Automation auto = new UIA3Automation())
            {
                    do
                    {
                        Console.WriteLine("Searching for primary workspace");
                        try
                        {
                            window = application.GetAllTopLevelWindows(auto)[0];
                            window.Patterns.Window.Pattern.SetWindowVisualState(WindowVisualState.Normal);
                            window.Focus();
                        }
                        catch
                        {
                            window = auto.GetDesktop().FindFirstDescendant(w => w.ByName(windowName)).AsWindow();
                        }
  
                    }
                    while (window == null);
            }
            Console.WriteLine($"Got main window - {window.Name}");
            return window;
        }

        public static Window GetWindow(this Window mainWindow, string windowName, string partialName = null)
        {
            Window win;
            var wins = mainWindow.FindAllDescendants(w => w.ByControlType(ControlType.Window));
            win = wins.First(w => w.Name == windowName || (partialName != null && w.Name.Contains(partialName))).AsWindow();
            return win;
        }

        public static AutomationElement GetElement(this Window mainWindow, string aid = null, string name = null, bool write = true, Window altWindow = null)
        {
            if (write) { Console.WriteLine("Searching for element '{0}'", aid == null ? name : aid); }
            var child = mainWindow.FindFirstDescendant(e => e.ByAutomationId(aid).Or(e.ByName(name)));
            return child;
        }

        public static void PreformDefaultAction(this AutomationElement element)
        {
            ILegacyIAccessiblePattern defAction = element.Patterns.LegacyIAccessible.Pattern;
            defAction.DoDefaultAction();
        }

        public static void SetLegacyValue(this AutomationElement element, string value)
        {
            ILegacyIAccessiblePattern setval = element.Patterns.LegacyIAccessible.Pattern;
            setval.SetValue(value);
        }

        public static AutomationElement GetChildElement(this AutomationElement element, int index)
        {
            return element.FindChildAt(index);
        }

        public static void Switch(this Window win)
        {
                win.Focus();
                Wait.UntilResponsive(win);   
        }

        public static void LegacySelect(this AutomationElement element)
        {
            ILegacyIAccessiblePattern pattern = element.Patterns.LegacyIAccessible.Pattern;
            pattern.Select(2);
        }

        public static DataGridViewRow NewRow(this DataGridView dgv)
        {
            var rLast = dgv.Rows.Last().Cells[0];
            rLast.PreformDefaultAction();
            int rcount = dgv.Rows.Count() - 2;
            var r = dgv.Rows[rcount];
            return r;
        }

        public static void SetVal(this DataGridViewCell cell, string val)
        {
            //int retry = 0;
            //_Set:
            //try
            //{
            //    cell.PreformDefaultAction();
            //    Point clickPoint;
            //    if (cell.TryGetClickablePoint(out clickPoint))
            //    {
            //        cell.Click(false);
            //    }
            //    else
            //    {

            //    }


            //    cell.PreformDefaultAction();


            //    if (cell.Value.Trim() != val)
            //    {
            //        Console.WriteLine("Setting val: {0}", val);
            //        cell.PreformDefaultAction();
            //        if (cell.TryGetClickablePoint(out clickPoint))
            //        {
            //            cell.Click(false);
            //        }
            //        var ctrl = GettingStuff.GetChild("UberControl").AsTextBox();
            //        ctrl.Text = val;

            //        cell.DoDef();

            //    }

            //    cell.DoDef();

            //}
            //catch
            //{
            //    Keyboard.Release(VirtualKeyShort.CONTROL);
            //    Keyboard.Release(VirtualKeyShort.KEY_S);
            //    retry += 1;

            //    if (retry == 1)
            //    {
            //        Keyboard.Type(VirtualKeyShort.DOWN);
            //        Keyboard.Type(VirtualKeyShort.UP);
            //    }

            //    if (retry <= 3) { goto _Set; }
            //}
        }


    }
}

