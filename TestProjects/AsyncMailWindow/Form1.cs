using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace AsyncMailWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SmtpClient client = new SmtpClient("128.1.9.20", 25);
            MailMessage message = new MailMessage("thepburn@zygo.com", "thepburn@zygo.com");
            message.Body = "This is a test e-mail message sent by an application. ";
            string userState = "test message1";
            client.SendAsync(message, userState);
            //string answer = Console.ReadLine();
        }
    }
}