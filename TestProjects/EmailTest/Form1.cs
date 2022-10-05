using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;

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
            string emailto;
            string emailFrom;
            emailFrom = "tor.hepburn@ametek.com";
            emailto = "tor.hepburn@ametek.com";


            MailMessage email = new MailMessage(emailFrom, emailto);
            email.Subject = " Email TEST";
            email.IsBodyHtml = true;
            string emailBody;
            emailBody = 
                "<html><body><table border='1' cellpadding='1'>" +
                "<tr>" +
                "<th> Location </th>" +
                "<th> ID </th>" +
                "<th> Description </th>" +
                //"<th>" + "Manufacturer" + "</th>" +
                //"<th>" + "Model" + "</th>" +
                //"<th>" + "Size" + "</th>" +
                //"<th>" + "Owner" + "</th>" +
                //"<th>" + "User" + "</th>" +
                //"<th>" + "Due Date" + "</th>" +
                "</tr>";

            email.Body = emailBody;
            //SmtpClient client = new SmtpClient("128.1.9.20", 25);
            SmtpClient client = new SmtpClient("mail.zygo.com", 25);
            client.UseDefaultCredentials = true;  //needed for plain .Send(email)
            client.Send(email);
                    
        }
    }
}
