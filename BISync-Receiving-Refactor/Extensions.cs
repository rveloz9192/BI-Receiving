using FlaUI.Core.AutomationElements;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BISync_Receiving
{
    public static class Extensions
    {
        public static void AddParam(this SqlCommand cmd, string var, string val)
        {
            cmd.Parameters.AddWithValue(var, val);
        }

        public static void InvokeIfRequired(this ISynchronizeInvoke obj, System.Windows.Forms.MethodInvoker action)
        {

            if (obj.InvokeRequired)
            {
                var args = new object[0];
                obj.Invoke(action, args);
            }
            else
            {
                action();
            }
        }

        public static Window GetWindow(this Window mainWin, string title, string startTitle = null)
        {
            Console.WriteLine($"Searching for window: {title}");
            var windows = mainWin.FindAllDescendants(w => w.ByControlType(FlaUI.Core.Definitions.ControlType.Window));
            try
            {
                var window = windows.First(w =>
                                       startTitle == null ? w.Name == title
                                       : w.Name == title || w.Name.StartsWith(startTitle)
                                      ).AsWindow();
                return window;
            }
            catch (InvalidOperationException) { return null; }
            catch (NullReferenceException) { return null; }
        }

        public static void SwitchUIFocus(this Window window)
        {
            window.Focus();
            FlaUI.Core.Input.Wait.UntilResponsive(window);
        }

        public static AutomationElement GetMaskedEdit(this AutomationElement topElement, string name = "", string autoID = "")
        {
            AutomationElement currentElement;
            try
            {
                if (name == "")
                {
                    currentElement = topElement.FindFirstDescendant(autoID);
                }
                else
                {
                    currentElement = topElement.FindFirstDescendant(x => x.ByName(name));
                }

                return currentElement.FindFirstChild("maskedEdit"); ;
            }
            catch (NullReferenceException) { return null; }
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static void DoDef(this AutomationElement ele)
        {
            FlaUI.Core.Patterns.ILegacyIAccessiblePattern defAction = ele.Patterns.LegacyIAccessible.Pattern;
            defAction.DoDefaultAction();
        }

        public static string Encrypt(this string plainText)
        {
            {
                string passPhrase = "aeiou1357";
                string saltValue = "QxLUF1bgIAdeQX";
                string hashAlgorithm = "MD5";

                int passwordIterations = 2;
                string initVector = "@1B2c3D4e5F6g7H8";
                int keySize = 256;

                byte[] initVectorBytes = System.Text.Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                PasswordDeriveBytes password = new PasswordDeriveBytes(plainText, saltValueBytes, hashAlgorithm, passwordIterations);

                byte[] keyBytes = password.GetBytes(keySize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();

                symmetricKey.Mode = CipherMode.CBC;
                symmetricKey.Padding = PaddingMode.PKCS7;
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                string cipherText = Convert.ToBase64String(cipherTextBytes);
                return cipherText;
            }
        }

        public static string CapFirstLetter(this string title)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title);
        }

        public static void SetVal(this AutomationElement ele, Window mainWin, string val)
        {
            TextBox edit = null;
            if (ele.Patterns.Value.Pattern.Value.Value.ToString().Trim() == val) { return; }
            ele.DoDef();
            Point clickPoint;
            if (ele.TryGetClickablePoint(out clickPoint)) { ele.Click(false); do { edit = mainWin.Automation.FocusedElement().AsTextBox(); } while (edit == null); }
            edit.Text = val;
            ele.Focus();
        }

        public static void ConsoleOut(this System.Windows.Forms.ListBox lst, string message)
        {
            Console.WriteLine(message);

            lst.InvokeIfRequired(() => { lst.Items.Insert(0, message); lst.Refresh(); });
        }

        public static void BringToForeground(this System.Windows.Forms.Form form)
        {
            form.InvokeIfRequired(() => {
                form.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                form.Show();
                form.WindowState = System.Windows.Forms.FormWindowState.Normal;
            });

        }

        public static List<string> KeyListFromStringyDict(this Dictionary<string, string[]> dict)
        {
            List<string> result = new List<string>();
            foreach (var key in dict)
            {
                result.Add(key.ToString());
            }
            return result;
        }

        //
        // Not used in this application
        //

        /*public static int Compute(this string s, string t)
        {
            s = Reverse(s);
            t = Reverse(t);
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }

        public static void ToggleOnOff(this AutomationElement ele)
        {
            do
            {
                ele.DoDef();
            } while (ele.Patterns.Value.Pattern.Value.Value == "false");
            System.Threading.Thread.Sleep(1500);
            do
            {
                ele.DoDef();
            } while (ele.Patterns.Value.Pattern.Value.Value == "true");
        }*/
    }
}
