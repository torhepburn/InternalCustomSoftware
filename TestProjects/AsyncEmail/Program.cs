using System;
//using System.Collections.Generic;
//using System.Text;
using System.Net.Mail;
//using System.Net;
//using System.Net.Mime;
//using System.Threading;
//using System.ComponentModel;

namespace AsyncEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            //SmtpClient client = new SmtpClient("128.1.9.20", 25);
            ////MailAddress from = new MailAddress("bsilvert@zygo.com");
            ////MailAddress to = new MailAddress("thepburn@zygo.com");
            //MailMessage email = new MailMessage("thepburn@zygo.com", "thepburn@zygo.com");
            //email.Body = "Test";
            //email.Subject = "Atom";
            ////email.BodyEncoding = System.Text.Encoding.UTF8;
            ////client.UseDefaultCredentials = true;
            //string token = "test";
            ////client.SendCompleted += new SendCompletedEventHandler(client_SendCompleted);
            //client.SendAsync(email, token);
            ////client.Send(email);
            //string answer = Console.ReadLine();
            //Console.WriteLine();


            SmtpClient client = new SmtpClient("128.1.9.20", 25);
            MailMessage message = new MailMessage("thepburn@zygo.com", "thepburn@zygo.com");
            message.Body = "This is a test e-mail message sent by an application. ";
            string userState = "test message1";
            client.SendAsync(message, userState);
            string answer = Console.ReadLine();
        }

        static void client_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        
    }
}
