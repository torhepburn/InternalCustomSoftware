using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace vs12test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string from = "thepburn@zygo.com";
            string emailto = "thepburn@zygo.com, 8603068700@vtext.com";
            MailMessage email = new MailMessage(from, emailto);
            email.Subject = "PM test";
            email.Body = "Call Tor 860-343-8915 if you get this message.";
            SmtpClient client = new SmtpClient("128.1.9.20", 25);
            client.UseDefaultCredentials = true;
            client.Send(email);

            //from = "mainrequest@zygo.com";
            //emailto = "thepburn@zygo.com, darmitage@zygo.com";
            //email = new MailMessage(from, emailto);
            //email.Subject = "Second message test";
            //email.Body = "I am trying to find a solution to a problem.  Your email address has been appropriated for this purpose.";
            //client = new SmtpClient("128.1.9.20", 25);
            //client.UseDefaultCredentials = true;
            //client.Send(email);

            
            Close();
        }
    }
}
