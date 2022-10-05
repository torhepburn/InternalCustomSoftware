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
using System.Net.Mail;

namespace T_H_Progress_Monitor
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
            p.StartInfo.FileName = "notepad.exe";
            //p.StartInfo.Arguments = "Notepad.exe";
            p.Start();

            if (p.HasExited)
            {
                label1.Text = "This Worked";
            }

            
            //string data = File.ReadAllText(@"c:\A\tnh.txt");

            //int temperature = data.IndexOf("Error opening local file");

            //File.AppendAllText(@"c:\A\tnh.txt", "  FOUND  ");
            //MailMessage mail = new MailMessage("thepburn@zygo.com", "thepburn@zygo.com",
            //            "FTP hangup", "T+H error");
            //MailAddress copy = new MailAddress("tor.hepburn@gmail.com");
            //mail.CC.Add(copy);
            //SmtpClient client = new SmtpClient("128.1.9.20", 25);
            //client.UseDefaultCredentials = true;
            //client.Send(mail);
            //Process[] localAll = Process.GetProcesses();
            //foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName("Excel"))
            //{
            //    p.Kill();
            //}
        }
    }
}
