using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace T_H_Monitor
{
    public partial class Monitor : Form
    {
        Process p96;

        public Monitor()
        {
            InitializeComponent();
        }

        private void Monitor_Load(object sender, EventArgs e)
        {
            timer1.Interval = (1000) * (1);
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            b96.BackColor = Color.Red;
            b97.BackColor = Color.Red;
            b207.BackColor = Color.Red;
            b208.BackColor = Color.Red;
            b209.BackColor = Color.Red;
            b210.BackColor = Color.Red;
            b212.BackColor = Color.Red;
            b217.BackColor = Color.Red;
            b219.BackColor = Color.Red;
            b220.BackColor = Color.Red;
            b221.BackColor = Color.Red;
            b222.BackColor = Color.Red;
            b223.BackColor = Color.Red;
            b224.BackColor = Color.Red;
            b225.BackColor = Color.Red;
            b226.BackColor = Color.Red;
            b227.BackColor = Color.Red;
            b228.BackColor = Color.Red;
            b229.BackColor = Color.Red;
            
            foreach (Process p in Process.GetProcesses("midws0026.zygo.com"))
            //foreach (Process p in Process.GetProcesses("midws0167.zygo.com"))
            {
                timer1.Interval = (1000) * (60);
                
                if (p.ProcessName == "96 T+H data")
                {
                    b96.BackColor = Color.Green;
                }
                if (p.ProcessName == "97 T+H data")
                {
                    b97.BackColor = Color.Green;
                }
                if (p.ProcessName == "207 T+H data")
                {
                    b207.BackColor = Color.Green;
                }
                if (p.ProcessName == "208 T+H data")
                {
                    b208.BackColor = Color.Green;
                }
                if (p.ProcessName == "209 T+H data")
                {
                    b209.BackColor = Color.Green;
                }
                if (p.ProcessName == "210 T+H data")
                {
                    b210.BackColor = Color.Green;
                }
                if (p.ProcessName == "212 T+H data")
                {
                    b212.BackColor = Color.Green;
                }
                if (p.ProcessName == "217 T+H data")
                {
                    b217.BackColor = Color.Green;
                }
                if (p.ProcessName == "219 T+H ThermoWorks")
                {
                    b219.BackColor = Color.Green;
                }
                if (p.ProcessName == "220 T+H ThermoWorks")
                {
                    b220.BackColor = Color.Green;
                }
                if (p.ProcessName == "221 T+H ThermoWorks")
                {
                    b221.BackColor = Color.Green;
                }
                if (p.ProcessName == "222 T+H ThermoWorks")
                {
                    b222.BackColor = Color.Green;
                }
                if (p.ProcessName == "223 T+H")
                {
                    b223.BackColor = Color.Green;
                }
                if (p.ProcessName == "224 T+H")
                {
                    b224.BackColor = Color.Green;
                }
                if (p.ProcessName == "225 T+H ThermoWorks Console")
                {
                    b225.BackColor = Color.Green;
                }
                if (p.ProcessName == "226 T+H ThermoWorks Console")
                {
                    b226.BackColor = Color.Green;
                }
                if (p.ProcessName == "227 T+H ThermoWorks Console")
                {
                    b227.BackColor = Color.Green;
                }
                if (p.ProcessName == "228 T+H ThermoWorks")
                {
                    b228.BackColor = Color.Green;
                }
                if (p.ProcessName == "229 T+H ThermoWorks Console")
                {
                    b229.BackColor = Color.Green;
                }
            }
        }

        private void b96_Click(object sender, EventArgs e)
        {
            p96 = new Process();
            p96.StartInfo.FileName = @"c:\tnh\96 T+H data.exe";
            p96.StartInfo.CreateNoWindow = true;
            p96.StartInfo.UseShellExecute = false;
            p96.Start();
        }

        private void b97_Click(object sender, EventArgs e)
        {
            Process p97 = new Process();
            p97.StartInfo.FileName = @"c:\tnh\97 T+H data.exe";
            p97.StartInfo.CreateNoWindow = true;
            p97.StartInfo.UseShellExecute = false;
            p97.Start();
        }

        private void b207_Click(object sender, EventArgs e)
        {
            Process p207 = new Process();
            p207.StartInfo.FileName = @"c:\tnh\207 T+H data.exe";
            p207.StartInfo.CreateNoWindow = true;
            p207.StartInfo.UseShellExecute = false;
            p207.Start();
        }

        private void b208_Click(object sender, EventArgs e)
        {
            Process p208 = new Process();
            p208.StartInfo.FileName = @"c:\tnh\208 T+H data.exe";
            p208.StartInfo.CreateNoWindow = true;
            p208.StartInfo.UseShellExecute = false;
            p208.Start();
        }

        private void b209_Click(object sender, EventArgs e)
        {
            Process p209 = new Process();
            p209.StartInfo.FileName = @"c:\tnh\209 T+H data.exe";
            p209.StartInfo.CreateNoWindow = true;
            p209.StartInfo.UseShellExecute = false;
            p209.Start();
        }

        private void b210_Click(object sender, EventArgs e)
        {
            Process p210 = new Process();
            p210.StartInfo.FileName = @"c:\tnh\210 T+H data.exe";
            p210.StartInfo.CreateNoWindow = true;
            p210.StartInfo.UseShellExecute = false;
            p210.Start();
        }

        private void b212_Click(object sender, EventArgs e)
        {
            Process p212 = new Process();
            p212.StartInfo.FileName = @"c:\tnh\212 T+H data.exe";
            p212.StartInfo.CreateNoWindow = true;
            p212.StartInfo.UseShellExecute = false;
            p212.Start();
        }

        private void b217_Click(object sender, EventArgs e)
        {
            Process p217 = new Process();
            p217.StartInfo.FileName = @"c:\tnh\217 T+H data.exe";
            p217.StartInfo.CreateNoWindow = true;
            p217.StartInfo.UseShellExecute = false;
            p217.Start();
        }

        private void b219_Click(object sender, EventArgs e)
        {
            Process p219 = new Process();
            p219.StartInfo.FileName = @"c:\tnh\219 T+H ThermoWorks.exe";
            p219.StartInfo.CreateNoWindow = true;
            p219.StartInfo.UseShellExecute = false;
            p219.Start();
        }

        private void b220_Click(object sender, EventArgs e)
        {
            Process p220 = new Process();
            p220.StartInfo.FileName = @"c:\tnh\220 T+H ThermoWorks.exe";
            p220.StartInfo.CreateNoWindow = true;
            p220.StartInfo.UseShellExecute = false;
            p220.Start();
        }

        private void b221_Click(object sender, EventArgs e)
        {
            Process p221 = new Process();
            p221.StartInfo.FileName = @"c:\tnh\221 T+H ThermoWorks.exe";
            p221.StartInfo.CreateNoWindow = true;
            p221.StartInfo.UseShellExecute = false;
            p221.Start();
        }

        private void b222_Click(object sender, EventArgs e)
        {
            Process p222 = new Process();
            p222.StartInfo.FileName = @"c:\tnh\222 T+H ThermoWorks.exe";
            p222.StartInfo.CreateNoWindow = true;
            p222.StartInfo.UseShellExecute = false;
            p222.Start();
        }

        private void b223_Click(object sender, EventArgs e)
        {
            Process p223 = new Process();
            p223.StartInfo.FileName = @"c:\tnh\223 T+H.exe";
            p223.StartInfo.CreateNoWindow = true;
            p223.StartInfo.UseShellExecute = false;
            p223.Start();
        }

        private void b224_Click(object sender, EventArgs e)
        {
            Process p224 = new Process();
            p224.StartInfo.FileName = @"c:\tnh\224 T+H.exe";
            p224.StartInfo.CreateNoWindow = true;
            p224.StartInfo.UseShellExecute = false;
            p224.Start();
        }

        private void b225_Click(object sender, EventArgs e)
        {
            Process p225 = new Process();
            p225.StartInfo.FileName = @"c:\tnh\225 T+H ThermoWorks Console.exe";
            p225.StartInfo.CreateNoWindow = true;
            p225.StartInfo.UseShellExecute = false;
            p225.Start();
        }

       

        private void b226_Click(object sender, EventArgs e)
        {
            Process p226 = new Process();
            p226.StartInfo.FileName = @"c:\tnh\226 T+H ThermoWorks Console.exe";
            p226.StartInfo.CreateNoWindow = true;
            p226.StartInfo.UseShellExecute = false;
            p226.Start();
        }

        private void b227_Click(object sender, EventArgs e)
        {
            Process p227 = new Process();
            p227.StartInfo.FileName = @"c:\tnh\227 T+H ThermoWorks Console.exe";
            p227.StartInfo.CreateNoWindow = true;
            p227.StartInfo.UseShellExecute = false;
            p227.Start();
        }

        private void b228_Click(object sender, EventArgs e)
        {
            Process p228 = new Process();
            p228.StartInfo.FileName = @"c:\tnh\228 T+H ThermoWorks.exe";
            p228.StartInfo.CreateNoWindow = true;
            p228.StartInfo.UseShellExecute = false;
            p228.Start();
        }

        private void b229_Click(object sender, EventArgs e)
        {
            Process p229 = new Process();
            p229.StartInfo.FileName = @"c:\tnh\229 T+H ThermoWorks Console.exe";
            p229.StartInfo.CreateNoWindow = true;
            p229.StartInfo.UseShellExecute = false;
            p229.Start();
        }

        private void b230_Click(object sender, EventArgs e)
        {
            Process p230 = new Process();
            p230.StartInfo.FileName = @"c:\tnh\230 T+H ThermoWorks Console.exe";
            p230.StartInfo.CreateNoWindow = true;
            p230.StartInfo.UseShellExecute = false;
            p230.Start();
        }
        
    }
}