using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DtsxXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.FileStream fs = new FileStream("C:\\a\\mkshortageplannedstock90d.dtsx", System.IO.FileMode.Open);

            System.Xml.XmlTextReader xmlReader = new System.Xml.XmlTextReader(fs);
        }
    }
}
