using SimpleTCP;
using System;
using System.Net.Sockets;

namespace BISync_Receiving
{
    public class Scanner
    {
        SimpleTcpClient client;
        readonly string ip = System.Configuration.ConfigurationManager.ConnectionStrings["Scanner_IP"].ToString();
        readonly int port = int.Parse(System.Configuration.ConfigurationManager.ConnectionStrings["Scanner_Port"].ToString());

        public Scanner()
        {
            client = new SimpleTcpClient();
            client.Disconnect();
        }

        public string SendMessage(string msg, string suffix)
        {
            string value = "";
            try
            {
                client.Connect(ip + suffix, port);
                Console.WriteLine($"Scanner_IP: {ip + suffix} | Scanner_Port: {port} | msg: {msg}");
                value = client.WriteLineAndGetReply($"{msg}\r", TimeSpan.FromSeconds(5)).MessageString;
                client.Disconnect();

                return value.Contains("ER") ? "Read Error" : value.Replace("\r", "");
            }
            catch (SocketException)
            {
                return "Socket";
            }
            catch (NullReferenceException)
            {
                client.Disconnect();
                client = new SimpleTcpClient().Connect(ip + suffix, port);
                client.WriteLineAndGetReply("LOFF\r", TimeSpan.FromSeconds(3));
                client.Disconnect();
                return "";
            }
            catch
            {
                client.Disconnect();
                client = new SimpleTcpClient().Connect(ip + suffix, port);
                client.WriteLineAndGetReply("LOFF\r", TimeSpan.FromSeconds(3));
                client.Disconnect();
                return "Read Error";
            }
        }

        public string Cancel(string suffix)  // TODO: Roger:    In it's current form Cancel button can not be called, SendMessage() locks the thread
        {
            string response = "";
            try
            {
                client.Disconnect();
                client.Connect(ip + suffix, port);
                Console.WriteLine($"Scanner_IP: {ip + suffix} | Scanner_Port: {port} | msg: CANCEL");
                response = client.WriteLineAndGetReply("CANCEL\r", TimeSpan.FromSeconds(3)).ToString();
                client.Disconnect();

                return response.Contains("ER") ? "Failed to cancel" : "Success";
            }
            catch (SocketException)
            {
                return "Socket";
            }
            catch (NullReferenceException)
            {
                client.Disconnect();
                client = new SimpleTcpClient().Connect(ip + suffix, port);
                client.WriteLineAndGetReply("LOFF\r", TimeSpan.FromSeconds(3));
                client.Disconnect();
                return "Null Reference";
            }
            catch
            {
                client.Disconnect();
                client = new SimpleTcpClient().Connect(ip + suffix, port);
                client.WriteLineAndGetReply("LOFF\r", TimeSpan.FromSeconds(3));
                client.Disconnect();
                return "Unknown Error";
            }
        }
    }
}
