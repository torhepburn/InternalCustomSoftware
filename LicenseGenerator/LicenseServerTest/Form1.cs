using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace LicenseServerTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string output = ;
            byte[] WriteBuffer = Encoding.ASCII.GetBytes("<EOF>Some text that will be echoed");
            
            TcpClient client = new TcpClient("midsrv07", 50000);
            NetworkStream stream = client.GetStream();
            stream.Write(WriteBuffer, 0, WriteBuffer.Length);

            byte[] ReadBuffer = new byte[34];
            

            stream.Read(ReadBuffer, 0, ReadBuffer.Length);
            client.Close();

            string write = Encoding.ASCII.GetString(WriteBuffer);
            string read = Encoding.ASCII.GetString(ReadBuffer);
            
            bool success = (read == write);
        }
    }
}