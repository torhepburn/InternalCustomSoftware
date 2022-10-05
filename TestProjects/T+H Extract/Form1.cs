using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace T_H_Extract
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            
            string html = wc.DownloadString("http://172.18.106.184/current.inc");
            string data = html.Substring((html.IndexOf("D20") + 8), 76);
            byte[] binaryData;
            binaryData = System.Convert.FromBase64String(data);

            int H1 = binaryData[42];
            int H2 = binaryData[43];

            string hex1 = H1.ToString("x");
            string hex2 = H2.ToString("x");
            string H3 = hex2 + hex1;
            int H4 = Int16.Parse(H3, System.Globalization.NumberStyles.HexNumber);
            int H5 = H4 - 1000;
            H5 = Math.Abs(H5);
            string humidity = Convert.ToString(Math.Floor(Convert.ToDecimal(H5) / 10));

            string wait;

            //string webData = System.Text.Encoding.UTF8.GetString(raw);

        }
    }
}
