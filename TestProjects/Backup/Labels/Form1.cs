using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Labels
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = @"C:\Program Files\Seagull\BarTender 6.20\" +
                @"Professional\bartend.exe";
            p.StartInfo.Arguments = @"/P /X /F=c:\labels\zebrageneric1text_prric718.btw " +
                @" /D=c:\labels\generic\genericlabel.txt";
            p.Start();
        }
    }
}