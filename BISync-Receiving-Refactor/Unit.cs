using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace BISync_Receiving
{
    public class Unit
    {
        public string serialNumber, prefix, product, serialWithPref, item, productCode;

        public Unit(string sn, string username, EventHandler<EventArgs> presEvent)
        {
            string ser = Regex.Replace(sn, "[^A-Za-z0-9]", "");
            string[] prefixInfo = null;
            // TODO: Roger:    This if statement contains the chanages made to not confirm the serial number prefix for HGS and HGM units
            if (ser.ToLower().Substring(0,3) == "hgm" || ser.ToLower().Substring(0, 3) == "hgs")
            {
                serialNumber = ser.Substring(3);
                prefix = ser.ToUpper().Substring(0, 3);
                product = "XMTR";                           // TODO: Roger: Product could actually be an XMT, it only affects SqlCli.InsertIntoOperations(), which is for tracking what users are doing, and should not matter.
                serialWithPref = prefix + serialNumber;
                item = productCode = "Unknown";
            }
            else
            {
                prefixInfo = SqlCli.GetPrefsAndProducts(ser);
                if (prefixInfo[0] == null) prefixInfo = SqlCli.FindPrefAndProduct(ser);
                if (prefixInfo[0] == null)
                {
                    MessageBox.Show("Unable to find format information for unit. Please route unit to Dom Walker");
                    return;
                }

                serialNumber = prefixInfo[0];
                prefix = prefixInfo[1];
                product = prefixInfo[2];
                serialWithPref = prefix + serialNumber;
                item = productCode = "Unknown";
            }
            

            SqlCli.PrepMainFormForMessageBox += presEvent;
            SqlCli.CheckUnitFlag(serialNumber, username);
            SqlCli.PrepMainFormForMessageBox -= presEvent;
            SqlCli.InsertIntoOperations(serialNumber, username, product);   // TODO: Roger: This is a wierd place to call this method, because of the manual selection option, it makes more sense to call it when Syteline.SubmitSro() is called, but this is how Dom Walker originally designed it.
        }
    }
}
