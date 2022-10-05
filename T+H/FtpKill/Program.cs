using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Diagnostics;
using System.IO;


namespace FtpKill
{
    class Program
    {
        private static Timer timer;
        static string log;

        static void Main(string[] args)
        {
            timer = new Timer((1000) * (60) * (.5));
            timer.Enabled = true;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            //timer.Interval = (1000) * (60) * (120);
            timer.Interval = (1000) * (60) * (.5);

            Console.WriteLine("ftpKill");
            Console.ReadLine();
        }

        private static void timer_Elapsed(object source, ElapsedEventArgs e)
        {
            Process[] All = Process.GetProcessesByName("ftp");
            log = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();

            foreach (Process pFTP in All)
            {
                pFTP.Kill();
                File.AppendAllText(@"C:\tnh\ftpKill_log.txt", log + "  pFTP.Kill " +
                    Environment.NewLine);
            }
            return;
        }
    }
}

