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

namespace WebClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Net.WebClient client = new System.Net.WebClient();

            //    /*
            //     * look for the place where I split the data and put it in an array
            //     * */


            string html = client.DownloadString("http://10.213.131.8/current.inc");

            //string webdata = client.DownloadString("http://www.zygo.com/zygomxlicense/data1.txt");

        }
    }
}
