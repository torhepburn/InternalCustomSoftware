using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TnHWriter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            StreamReader file = new StreamReader("c:\\a\\ise-th-5-template.txt");


            string text = file.ReadToEnd();

            int h = text.IndexOf("10.213.71.70");
            text = text.Replace("10.213.71.70", "10.213.71.65");


            File.WriteAllText(@"C:\a\tnh_.txt", text);
        }
    }
}
