using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BISync_Receiving
{
    public interface IMainView
    {
        string Username { get; }
        string Product { get; }
        string SerialNumber { get; set; }
        string RunButtonText { get; set; }
        string SelectedSro { get; set; }
        string NewSro { set; }
        string Notes { set; }
        string SelectedScanner { get; }
        bool SerialNumberSet { get; set; }
        bool ManualSelection { get; set; }
        bool SytelineActive { get; set; }
        bool? SroStatus { set; }
        List<string> ProductList { set; }
        List<string> SroList { get; set; }
        List<string> ScannerList { set; }
        IEnumerable<Label> InfoLabels { get; }
        ListBox ListOutput { get; }

        event EventHandler<EventArgs> UpdateInfoGroupBox;
        event EventHandler<EventArgs> GetSerialNumber;
        event EventHandler<EventArgs> ResetInfoGroupLabels;
        event EventHandler<EventArgs> SubmitUnitManual;
        event EventHandler<CustomEventArgs> GetSroStatus;
    }
}
