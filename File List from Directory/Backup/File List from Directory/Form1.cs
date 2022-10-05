using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace File_List_from_Directory
{
    public partial class Form1 : Form
    {
        private string LookIn;
        private string PrintHere;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LookIn = textBox1.Text;
            PrintHere = textBox2.Text + ".txt";
            
            string[] result = Directory.GetFiles(LookIn);

            foreach (string x in result)
            {
                FileInfo fi = new FileInfo(x);
                string fileName = fi.Name.Trim();
                File.AppendAllText(PrintHere, fileName + Environment.NewLine);
            }
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}