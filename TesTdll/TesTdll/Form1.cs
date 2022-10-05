using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PCClib;

namespace TesTdll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string test = ProduControlchart.Input(@"\\middbweb\ddrive\wwwroot\zto\app\metrology\data\documents\33588\CE.00618041.ZMI-TEST-1.00047.xml");
            //    @"data\documents\" + folder + @"\";33588");
            //string path = @"\\middbweb\ddrive\wwwroot\zto\app\metrology\" +
            //    @"data\documents\" + folder + @"\";
            string test = ProduControlchart.Input(@"c:\\a\CE.00618041.ZMI-TEST-1.99999.xml");

        }
    }
}