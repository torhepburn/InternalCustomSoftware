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

namespace TnDunits
{
    public partial class XXHttpWebRequest : Form
    {
        private string aaa;
        
        public XXHttpWebRequest()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string target = @"http://128.1.10.79";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(target);
            request.Method = "GET";
            WebResponse myresponse = request.GetResponse();
            StreamReader sr = new StreamReader(myresponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            File.AppendAllText(@"C:\a\aaa.txt", result);
            myresponse.Close();
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //using (Stream responseStream = response.GetResponseStream())
            //using (StreamReader htmlStream = new StreamReader(responseStream, Encoding.UTF8))
            //    aaa = htmlStream.ReadToEnd();
            
            
            //File.AppendAllText(@"C:\a\aa.txt", aaa);
        }
    }
}
