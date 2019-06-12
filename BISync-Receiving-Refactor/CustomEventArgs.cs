using System;

namespace BISync_Receiving
{
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string s)
        {
            msg = s;
        }
        private readonly string msg;
        public string Message
        {
            get { return msg; }
        }
    }
}
