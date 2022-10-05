using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace ProcessDiagnostic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // get processes on remote computeer
            //Process[] All = Process.GetProcesses("midws0026");

            Process[] All = Process.GetProcessesByName("notepad");

            foreach (Process p in All)
            {
                p.Kill();
                //File.AppendAllText(@"c:\a\p26list.txt",  p.ProcessName + p.Id + Environment.NewLine);
            }
        }
    }
}
