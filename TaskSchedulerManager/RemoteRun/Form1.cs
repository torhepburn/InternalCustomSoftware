using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace RemoteRun
{
    public partial class Form1 : Form
    {
        private Process p = new Process();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.StartInfo.FileName = @"\\MIDSQL01\c$\temp\writetestfilelocal.exe";
            //p.StartInfo.FileName = @"\\MIDfile01\users\thepburn\writetestfile.exe";
            //p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit(1000);
            p.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
