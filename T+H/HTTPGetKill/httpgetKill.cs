using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Diagnostics;
using System.IO;


namespace HTTPGetKill
{
    class httpgetKill
    {
        private static Timer timer;
        static string log;
        
        static void Main(string[] args)
        {
            timer = new Timer((1000) * (60) * (.5));
            timer.Enabled = true;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            //timer.Interval = (1000) * (60) * (120);

            Console.WriteLine("httpgetKill");
            Console.ReadLine();
        }

        private static void timer_Elapsed(object source, ElapsedEventArgs e)
        {
            Process[] All = Process.GetProcessesByName("httpget.exe");
            log = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();

            foreach (Process pHttpget in All)
            {
                pHttpget.Kill();
                File.AppendAllText(@"C:\tnh\httpgetKill_log.txt", log + "  httpget.Kill " +
                    Environment.NewLine);
            }
            return;
        }
    }
}
