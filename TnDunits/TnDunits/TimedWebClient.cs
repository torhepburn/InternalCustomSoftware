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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string s = new TimedWebClient { Timeout = 500 }.DownloadString("http://128.1.10.79/#floatWindow");
            File.AppendAllText(@"c:\a\abwebtest.txt", s);
        }
    }

    public class TimedWebClient : WebClient
    {
        public int Timeout { get; set; }

        public TimedWebClient()
        {
            this.Timeout = 500;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
 	        var objWebRequest= base.GetWebRequest(address);
            objWebRequest.Timeout = this.Timeout;
            return objWebRequest;
        }
        

        
        
    
    }

}
