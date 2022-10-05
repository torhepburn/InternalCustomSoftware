
using System;
//using System.Net;
using System.Net.Mail;
//using System.Net.Mime;
//using System.Threading;
//using System.ComponentModel;

namespace Async2
{
    public class SimpleAsynchronousExample
    {
        public static void Main(string[] args)
        {
            SmtpClient client = new SmtpClient("128.1.9.20", 25);
            MailMessage message = new MailMessage("thepburn@zygo.com", "thepburn@zygo.com");
            message.Body = "This is a test e-mail message sent by an application. ";
            string userState = "test message1";
            client.SendAsync(message, userState);
            string answer = Console.ReadLine();
        
        }
    }
}


