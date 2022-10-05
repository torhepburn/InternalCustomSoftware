using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WebExtractTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //WebClient client = new WebClient();
            string url = (@"http://www.mcmaster.com/#catalog/120/3024/#tul1i8");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //string html = client.DownloadString(@"http://www.mcmaster.com/#catalog/120/3024/#tul1i8");
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            response.Close();
            
            string test;
        }
    }
}
