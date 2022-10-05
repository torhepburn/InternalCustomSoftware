using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace TnHTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string html = client.DownloadString("http://172.18.106.186/current.inc");
            //string html = client.DownloadString("http://172.18.106.186");
            //File.WriteAllText(@"C:\a\TR702Web.txt", html);
            
            string data = html.Substring((html.IndexOf("D20") + 8), 76);
            //string data = "AAAFBBBKBdQqVBHUKlSRcSpUDQCCCCCCCCC2BADwC9QgVNAAAAAAAAAABAYA8AvUIFTAECwBAAA=";
            //string HH = "this";
            byte[] binaryData;
            binaryData = System.Convert.FromBase64String(data);

            int H1 = binaryData[42];
            int H2 = binaryData[43];
            //int H1 = 0;
            //int H2 = 44;

            string hex1 = H1.ToString("x");
            string hex2 = H2.ToString("x");
            string H3 = hex2 + hex1;
            //string H3 = "776";
            int H4 = Int16.Parse(H3, System.Globalization.NumberStyles.HexNumber);
            int H5 = H4 - 1000;
            H5 = Math.Abs(H5);
            string Humidity = Convert.ToString(Math.Floor(Convert.ToDecimal(H5) / 10));
            string next;
        }
    }
}
