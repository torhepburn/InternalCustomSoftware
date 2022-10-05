using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TnHnStartStop
{
    public partial class TnHStartStop : Form
    {
        Process pCRM;
        Process p73;
        Process p74;
        Process p79;
        Process p81;
       
        public TnHStartStop()
        {
            InitializeComponent();
        }

        private void TnHStartStop_Load(object sender, EventArgs e)
        {
            timer1.Interval = (1000) * (1);
            timer1.Enabled = true;
            timer1.Start();
        }

         private void timer1_Tick(object sender, EventArgs e)
        {
            bCRM.BackColor = Color.Red;
            b73.BackColor = Color.Red;
            b74.BackColor = Color.Red;
            b79.BackColor = Color.Red;
            b81.BackColor = Color.Red;

            foreach (Process p in Process.GetProcesses(Environment.MachineName))
            {
                timer1.Interval = (1000) * (60);

                if (p.ProcessName == "CurrentMonitor")
                {
                    bCRM.BackColor = Color.Green;
                }
                if (p.ProcessName == "12811073_Console")
                {
                    b73.BackColor = Color.Green;
                }
                if (p.ProcessName == "12811074_Console")
                {
                    b74.BackColor = Color.Green;
                }
                if (p.ProcessName == "12811079_Console")
                {
                    b79.BackColor = Color.Green;
                }
                if (p.ProcessName == "12811081_Console")
                {
                    b81.BackColor = Color.Green;
                }

            }
        }

        private void bCRM_Click(object sender, EventArgs e)
        {
            pCRM = new Process();
            pCRM.StartInfo.FileName = @"C:\Program Files (x86)\Current Readings Monitor\CurrentMonitor.exe";
            pCRM.StartInfo.CreateNoWindow = true;
            pCRM.StartInfo.UseShellExecute = false;
            pCRM.Start(); 
        }
        
        private void b73_Click(object sender, EventArgs e)
        {
            if (b73.BackColor == Color.Green)
            {
                { 
                    p73.Kill();
                    b73.BackColor = Color.Red;
                }
            }
            else
            {
                p73 = new Process();
                p73.StartInfo.FileName = @"c:\tnh\12811073_Console.exe";
                p73.StartInfo.CreateNoWindow = true;
                p73.StartInfo.UseShellExecute = false;
                p73.Start();
                b73.BackColor = Color.Green;
            }
        }

        private void b74_Click(object sender, EventArgs e)
        {
            if (b74.BackColor == Color.Green)
            {
                {
                    p74.Kill();
                    b74.BackColor = Color.Red;
                }
            }
            else
            {
                p74 = new Process();
                p74.StartInfo.FileName = @"c:\tnh\12811074_Console.exe";
                p74.StartInfo.CreateNoWindow = true;
                p74.StartInfo.UseShellExecute = false;
                p74.Start();
                b74.BackColor = Color.Green;
            }
        }

        private void b79_Click(object sender, EventArgs e)
        {
            if (b79.BackColor == Color.Green)
            {
                {
                    p79.Kill();
                    b79.BackColor = Color.Red;
                }
            }
            else
            {
                p79 = new Process();
                p79.StartInfo.FileName = @"c:\tnh\12811079_Console.exe";
                p79.StartInfo.CreateNoWindow = true;
                p79.StartInfo.UseShellExecute = false;
                p79.Start();
                b79.BackColor = Color.Green;
            }
        }

        private void b81_Click(object sender, EventArgs e)
        {
            if (b81.BackColor == Color.Green)
            {
                {
                    p81.Kill();
                    b81.BackColor = Color.Red;
                }
            }
            else
            {
                p81 = new Process();
                p81.StartInfo.FileName = @"c:\tnh\12811081_Console.exe";
                p81.StartInfo.CreateNoWindow = true;
                p81.StartInfo.UseShellExecute = false;
                p81.Start();
                b81.BackColor = Color.Green;
            }
        }

    }
}
