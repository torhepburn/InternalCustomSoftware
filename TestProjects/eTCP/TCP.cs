using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Net.NetworkInformation;

namespace eTCP
{
    public partial class TCP : Form
    {
        
        public TCP()
        {
            InitializeComponent();
        }

        private void TCP_Load(object sender, EventArgs e)
        {
            //System.Net.IPAddress IP = new IPAddress();
            //if (IP.TryParse("128.1.9.232", out IP))
            //{
            //    Socket s = new Socket(AddressFamily.InterNetwork,
            //        SocketType.Stream, ProtocolType.Tcp);
            //    try
            //    {
            //        s.Connect(IPs[0], port);

            //    }
            //    catch (Exception ex)
            //    {

            //        // something went wrong    
            //    }

            //}

            
            //System.Net.IPAddress[] IPs = System.Net.Dns.GetHostAddresses();

            //Socket s = new Socket(AddressFamily.InterNetwork,
            //    SocketType.Stream,
            //    ProtocolType.Tcp);
            //s.Blocking = true;
            //s.SendTimeout = 1000;
            
            ////s.Connect("128.1.4.233", 502);
            
            //s.Connect("128.1.4.233", 502);
            //byte[] b = new byte[10];
            //s.Receive(b);
            ////int x = s.ReceiveBufferSize;
            ////Console.WriteLine("Establishing Connection to {0}",
            //    host);
            //s.Connect(IPs[0], port);
            //Console.WriteLine("Connection established");

            
            //Ping pingSender = new Ping();
            //IPAddress address = "128.1.9.232";
            //PingReply reply = pingSender.Send("128.1.9.232");



            TcpClient tcpClient = new TcpClient("128.1.9.233", 502);
            ////tcpClient.Connect("128.1.9.233", 21);
            tcpClient.ReceiveTimeout = 1000;
            NetworkStream stream = tcpClient.GetStream();
            
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            //string message = "0, 03, 00, 00, 00, 01";
            //byte[] bytes = Encoding.ASCII.GetBytes(message);
            //stream.Write(bytes, 0, 8);
            ////StreamReader reader = new StreamReader(stream, Encoding.UTF8);

            //Ping ping = new Ping();
            //PingReply pingreply = ping.Send("128.1.9.230");
            //StreamWriter sw = new StreamWriter(@"c:\a\ping.txt");
            //StringBuilder sb = new StringBuilder();
            //sb.Append("Address: " + pingreply.Address + "\r\n");
            //sb.Append("Roundtrip Time: " + pingreply.RoundtripTime + "\r\n");
            //sb.Append("Buffer: " + pingreply.Buffer.Length.ToString());
            //sw.Write(sb.ToString());
            //sw.Close();
            
        }
    }
}