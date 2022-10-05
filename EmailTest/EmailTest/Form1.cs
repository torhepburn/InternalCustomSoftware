using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace EmailTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MailAddress emailto = new MailAddress("thepburn@zygo.com");
            MailAddress emailfrom = new MailAddress("tor.hepburn@ametek.com");
            MailMessage email = new MailMessage(emailfrom, emailto);
            email.Subject = "Test SMTP";
            email.Body = "Test of email system";
            //SmtpClient aclient = new SmtpClient("mail.zygo.com", 25);
            SmtpClient aclient = new SmtpClient("10.213.70.13", 25);
            aclient.UseDefaultCredentials = true;
            aclient.Send(email);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
