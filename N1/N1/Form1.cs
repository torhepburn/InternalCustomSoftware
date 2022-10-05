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

namespace N1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient nc = new WebClient();

            string html = nc.DownloadString("http://10.213.131.8/current.inc");
            string html1 = nc.DownloadString("http://10.213.131.8/current.inc");

        }
    }
}
