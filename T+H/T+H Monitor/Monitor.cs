
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
        Process p97;
        Process p207;
        Process p208;
        Process p209;
        Process p210;
        Process p212;
        Process p217;
        Process p219;
        Process p220;
        Process p221;
        Process p222;
        Process p223;
        Process p224;
        Process p225;
        Process p226;
        Process p227;
        Process p228;
        Process p229;
        Process p230;
        Process p231;
        Process p232;
        Process p72;
        Process p73;
        Process p7020;
        Process p7021;
        Process p7023;
        Process p17216111;
        Process p17216112;
        Process p17218106180;
        Process p17218106181;
        Process p12870131;
        Process p12870132;

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
            b230.BackColor = Color.Red;
            b231.BackColor = Color.Red;
            b232.BackColor = Color.Red;
            b72.BackColor = Color.Red;
            b73.BackColor = Color.Red;
            b7020.BackColor = Color.Red;
            b7021.BackColor = Color.Red;
            b7023.BackColor = Color.Red;
            b17216111.BackColor = Color.Red;
            b17216112.BackColor = Color.Red;
            
            //find the processes running on the local machine
            foreach (Process p in Process.GetProcesses(Environment.MachineName))
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
                if (p.ProcessName == "230 T+H ThermoWorks Console")
                {
                    b230.BackColor = Color.Green;
                }
                if (p.ProcessName == "231 T+H ThermoWorks Console")
                {
                    b231.BackColor = Color.Green;
                }
                if (p.ProcessName == "232 T+H ThermoWorks Console")
                {
                    b232.BackColor = Color.Green;
                }
                if (p.ProcessName == "72 T+H ThermoWorks Console")
                {
                    b72.BackColor = Color.Green;
                }
                if (p.ProcessName == "73 T+H ThermoWorks Console")
                {
                    b73.BackColor = Color.Green;
                }
                if (p.ProcessName == "7.0.20 T+H Data")
                {
                    b7020.BackColor = Color.Green;
                }
                if (p.ProcessName == "7.0.21 T+H Data")
                {
                    b7021.BackColor = Color.Green;
                }
                if (p.ProcessName == "7023 T+H ThermoWorks Console")
                {
                    b7023.BackColor = Color.Green;
                }
                if (p.ProcessName == "172.11 T+H")
                {
                    b17216111.BackColor = Color.Green;
                }
                if (p.ProcessName == "172.12 T+H")
                {
                    b17216112.BackColor = Color.Green;
                }
            }
        }

        private void b96_Click(object sender, EventArgs e)
        {
            //try code to repeat this with just the number being different.
            
            //if (b73.BackColor == Color.Green)
            //{
            //    {
            //        p73.Kill();
            //        b73.BackColor = Color.Red;
            //    }
            //}
            //else
            //{
            //    p73 = new Process();
            //    p73.StartInfo.FileName = @"c:\tnh\12811073_Console.exe";
            //    p73.StartInfo.CreateNoWindow = true;
            //    p73.StartInfo.UseShellExecute = false;
            //    p73.Start();
            //    b73.BackColor = Color.Green;
            //}
            
            p96 = new Process();
            p96.StartInfo.FileName = @"c:\tnh\96 T+H data.exe";
            p96.StartInfo.CreateNoWindow = true;
            p96.StartInfo.UseShellExecute = false;
            p96.Start();
        }

        private void b97_Click(object sender, EventArgs e)
        {
            p97 = new Process();
            p97.StartInfo.FileName = @"c:\tnh\97 T+H data.exe";
            p97.StartInfo.CreateNoWindow = true;
            p97.StartInfo.UseShellExecute = false;
            p97.Start();
        }

        private void b207_Click(object sender, EventArgs e)
        {
            p207 = new Process();
            p207.StartInfo.FileName = @"c:\tnh\207 T+H data.exe";
            p207.StartInfo.CreateNoWindow = true;
            p207.StartInfo.UseShellExecute = false;
            p207.Start();
        }

        private void b208_Click(object sender, EventArgs e)
        {
            p208 = new Process();
            p208.StartInfo.FileName = @"c:\tnh\208 T+H data.exe";
            p208.StartInfo.CreateNoWindow = true;
            p208.StartInfo.UseShellExecute = false;
            p208.Start();
        }

        private void b209_Click(object sender, EventArgs e)
        {
            p209 = new Process();
            p209.StartInfo.FileName = @"c:\tnh\209 T+H data.exe";
            p209.StartInfo.CreateNoWindow = true;
            p209.StartInfo.UseShellExecute = false;
            p209.Start();
        }

        private void b210_Click(object sender, EventArgs e)
        {
            p210 = new Process();
            p210.StartInfo.FileName = @"c:\tnh\210 T+H data.exe";
            p210.StartInfo.CreateNoWindow = true;
            p210.StartInfo.UseShellExecute = false;
            p210.Start();
        }

        private void b212_Click(object sender, EventArgs e)
        {
            p212 = new Process();
            p212.StartInfo.FileName = @"c:\tnh\212 T+H data.exe";
            p212.StartInfo.CreateNoWindow = true;
            p212.StartInfo.UseShellExecute = false;
            p212.Start();
        }

        private void b217_Click(object sender, EventArgs e)
        {
            p217 = new Process();
            p217.StartInfo.FileName = @"c:\tnh\217 T+H data.exe";
            p217.StartInfo.CreateNoWindow = true;
            p217.StartInfo.UseShellExecute = false;
            p217.Start();
        }

        private void b219_Click(object sender, EventArgs e)
        {
            p219 = new Process();
            p219.StartInfo.FileName = @"c:\tnh\219 T+H ThermoWorks.exe";
            p219.StartInfo.CreateNoWindow = true;
            p219.StartInfo.UseShellExecute = false;
            p219.Start();
        }

        private void b220_Click(object sender, EventArgs e)
        {
            p220 = new Process();
            p220.StartInfo.FileName = @"c:\tnh\220 T+H ThermoWorks.exe";
            p220.StartInfo.CreateNoWindow = true;
            p220.StartInfo.UseShellExecute = false;
            p220.Start();
        }

        private void b221_Click(object sender, EventArgs e)
        {
            p221 = new Process();
            p221.StartInfo.FileName = @"c:\tnh\221 T+H ThermoWorks.exe";
            p221.StartInfo.CreateNoWindow = true;
            p221.StartInfo.UseShellExecute = false;
            p221.Start();
        }

        private void b222_Click(object sender, EventArgs e)
        {
            p222 = new Process();
            p222.StartInfo.FileName = @"c:\tnh\222 T+H ThermoWorks.exe";
            p222.StartInfo.CreateNoWindow = true;
            p222.StartInfo.UseShellExecute = false;
            p222.Start();
        }

        private void b223_Click(object sender, EventArgs e)
        {
            p223 = new Process();
            p223.StartInfo.FileName = @"c:\tnh\223 T+H.exe";
            p223.StartInfo.CreateNoWindow = true;
            p223.StartInfo.UseShellExecute = false;
            p223.Start();
        }

        private void b224_Click(object sender, EventArgs e)
        {
            p224 = new Process();
            p224.StartInfo.FileName = @"c:\tnh\224 T+H.exe";
            p224.StartInfo.CreateNoWindow = true;
            p224.StartInfo.UseShellExecute = false;
            p224.Start();
        }

        private void b225_Click(object sender, EventArgs e)
        {
            p225 = new Process();
            p225.StartInfo.FileName = @"c:\tnh\225 T+H ThermoWorks Console.exe";
            p225.StartInfo.CreateNoWindow = true;
            p225.StartInfo.UseShellExecute = false;
            p225.Start();
        }

        private void b226_Click(object sender, EventArgs e)
        {
            p226 = new Process();
            p226.StartInfo.FileName = @"c:\tnh\226 T+H ThermoWorks Console.exe";
            p226.StartInfo.CreateNoWindow = true;
            p226.StartInfo.UseShellExecute = false;
            p226.Start();
        }

        private void b227_Click(object sender, EventArgs e)
        {
            p227 = new Process();
            p227.StartInfo.FileName = @"c:\tnh\227 T+H ThermoWorks Console.exe";
            p227.StartInfo.CreateNoWindow = true;
            p227.StartInfo.UseShellExecute = false;
            p227.Start();
        }

        private void b228_Click(object sender, EventArgs e)
        {
            p228 = new Process();
            p228.StartInfo.FileName = @"c:\tnh\228 T+H ThermoWorks.exe";
            p228.StartInfo.CreateNoWindow = true;
            p228.StartInfo.UseShellExecute = false;
            p228.Start();
        }

        private void b229_Click(object sender, EventArgs e)
        {
            p229 = new Process();
            p229.StartInfo.FileName = @"c:\tnh\229 T+H ThermoWorks Console.exe";
            p229.StartInfo.CreateNoWindow = true;
            p229.StartInfo.UseShellExecute = false;
            p229.Start();
        }

        private void b230_Click(object sender, EventArgs e)
        {
            p230 = new Process();
            p230.StartInfo.FileName = @"c:\tnh\230 T+H ThermoWorks Console.exe";
            p230.StartInfo.CreateNoWindow = true;
            p230.StartInfo.UseShellExecute = false;
            p230.Start();
        }

        private void b231_Click(object sender, EventArgs e)
        {
            p231 = new Process();
            p231.StartInfo.FileName = @"c:\tnh\231 T+H ThermoWorks Console.exe";
            p231.StartInfo.CreateNoWindow = true;
            p231.StartInfo.UseShellExecute = false;
            p231.Start();
        }

        private void b72_Click(object sender, EventArgs e)
        {
            p72 = new Process();
            p72.StartInfo.FileName = @"c:\tnh\72 T+H ThermoWorks Console.exe";
            p72.StartInfo.CreateNoWindow = true;
            p72.StartInfo.UseShellExecute = false;
            p72.Start();
        }

        private void b73_Click(object sender, EventArgs e)
        {
            p73 = new Process();
            p73.StartInfo.FileName = @"c:\tnh\73 T+H ThermoWorks Console.exe";
            p73.StartInfo.CreateNoWindow = true;
            p73.StartInfo.UseShellExecute = false;
            p73.Start();
        }


        private void b232_Click(object sender, EventArgs e)
        {
            p232 = new Process();
            p232.StartInfo.FileName = @"c:\tnh\232 T+H ThermoWorks Console.exe";
            p232.StartInfo.CreateNoWindow = true;
            p232.StartInfo.UseShellExecute = false;
            p232.Start();
        }
        
        private void b7020_Click(object sender, EventArgs e)
        {
            p7020 = new Process();
            p7020.StartInfo.FileName = @"c:\tnh\7.0.20 T+H Data.exe";
            p7020.StartInfo.CreateNoWindow = true;
            p7020.StartInfo.UseShellExecute = false;
            p7020.Start(); 
        }

        private void b7021_Click(object sender, EventArgs e)
        {
            p7021 = new Process();
            p7021.StartInfo.FileName = @"c:\tnh\7.0.21 T+H Data.exe";
            p7021.StartInfo.CreateNoWindow = true;
            p7021.StartInfo.UseShellExecute = false;
            p7021.Start();
        }

        private void b7023_Click(object sender, EventArgs e)
        {
            p7023 = new Process();
            p7023.StartInfo.FileName = @"c:\tnh\7023 T+H ThermoWorks Console.exe";
            p7023.StartInfo.CreateNoWindow = true;
            p7023.StartInfo.UseShellExecute = false;
            p7023.Start();
        }

        private void b17216111_Click(object sender, EventArgs e)
        {
            p17216111 = new Process();
            p17216111.StartInfo.FileName = @"c:\tnh\172.11 T+H.exe";
            p17216111.StartInfo.CreateNoWindow = true;
            p17216111.StartInfo.UseShellExecute = false;
            p17216111.Start();
        }

        private void b17216112_Click(object sender, EventArgs e)
        {
            p17216112 = new Process();
            p17216112.StartInfo.FileName = @"c:\tnh\172.12 T+H.exe";
            p17216112.StartInfo.CreateNoWindow = true;
            p17216112.StartInfo.UseShellExecute = false;
            p17216112.Start();
        }


        private void bStop_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to stop everything ?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(this, message,"" ,buttons, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                if (p96 != null) { p96.Kill(); }
                if (p97 != null) {p97.Kill();}
                if (p207 != null) {p207.Kill();}
                if (p208 != null) {p208.Kill();}
                if (p209 != null) {p209.Kill();}
                if (p210 != null) {p210.Kill();}
                if (p212 != null) {p212.Kill();}
                if (p217 != null) {p217.Kill();}
                if (p219 != null) {p219.Kill();}
                if (p220 != null) {p220.Kill();}
                if (p221 != null) {p221.Kill();}
                if (p222 != null) {p222.Kill();}
                if (p223 != null) {p223.Kill();}
                if (p224 != null) {p224.Kill();}
                if (p225 != null) {p225.Kill();}
                if (p226 != null) {p226.Kill();}
                if (p227 != null) {p227.Kill();}
                if (p228 != null) {p228.Kill();}
                if (p229 != null) {p229.Kill();}
                if (p230 != null) {p230.Kill();}
                if (p231 != null) {p231.Kill();}
                if (p232 != null) {p232.Kill();}
                if (p72 != null) {p72.Kill();}
                if (p73 != null) { p73.Kill(); }
                if (p7020 != null) { p7020.Kill(); }
                if (p7021 != null) { p7021.Kill(); }
                if (p7023 != null) { p7023.Kill(); }
                if (p17216111 != null) { p17216111.Kill(); }
                if (p17216112 != null) { p17216112.Kill(); }

            }
            else
            {
                return;
            }


        }
        
    }
}