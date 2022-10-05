using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;


namespace TnH_test
{
    class Program
    {
        private static Timer timer;
        static Process P = new Process();
        static int H;
        static string site;
        static string type;
        //static string SQLtable = "128_1_9_96";

        static string Terror;
        static string oTemp;
        static string Herror;
        static string oHum;
        static string log;
        static string cmdText;

        static SqlConnection cnxn;
        static SqlCommand cmd;
        
        static void Main(string[] args)
        {
            timer = new Timer((1000) * (60) * (.5));
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
            //timer.AutoReset = false;
            
            Console.ReadLine();
        }

        private static void timer_Elapsed(object source, ElapsedEventArgs e)
        {
                log = DateTime.Now.ToString();
                //site = "10.213.71.65";
                //routine();
                //site = "10.213.71.66";
                //routine();
                //site = "10.213.71.67";
                //routine();
                //site = "10.213.71.68";
                //routine();
                //site = "10.213.71.69";
                //routine();
                //site = "10.213.71.71";
                //routine();
                //site = "10.213.71.86";
                //routine();
                //site = "10.213.71.87";
                //routine();
                site = "10.213.71.74";
                routine();
                
        }

        private static void routine()
        {
            temperature();
            if (oTemp == "")
            {
                File.AppendAllText(@"C:\tnh\new_tnh_log.txt", Environment.NewLine);
                File.AppendAllText(@"C:\tnh\new_tnh_log.txt", Environment.NewLine + log +
                    " " + site + " Temperature Retry." + Environment.NewLine);
                System.Threading.Thread.Sleep(5000);
                temperature();
            }

            humidity();
            if (oHum == "")
            {
                File.AppendAllText(@"C:\tnh\new_tnh_log.txt", Environment.NewLine);
                File.AppendAllText(@"C:\tnh\new_tnh_log.txt", Environment.NewLine + log +
                    " " + site + " Humidity Retry." + Environment.NewLine);
                System.Threading.Thread.Sleep(5000);
                humidity();
            }

            SQL();
        }
        
        private static void SQL()
        {
            try
            {
                cnxn = new SqlConnection("server = midsql01; " +
                    "user = readwrite; password = Read+Write!; database = tnh;");
                cmd = new SqlCommand("Insert into TnH1 " +
                    " (log, address, tempf, rh) values ('" +
                    log + "','" +
                    site + "'," +
                    oTemp + "," +
                    oHum + ")", cnxn);
                cmdText = cmd.CommandText;
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();
            }
            catch (SqlException ex)
            {
                File.AppendAllText(@"C:\tnh\New_tnh_log.txt", Environment.NewLine);
                File.AppendAllText(@"C:\tnh\New_tnh_log.txt", Environment.NewLine);
                File.AppendAllText(@"C:\tnh\New_tnh_log.txt", log + " " + site + " SQL " + ex.Message + Environment.NewLine);
                if (Terror == "") { Terror = Environment.NewLine; }
                File.AppendAllText(@"C:\tnh\New_tnh_log.txt", Environment.NewLine + log + " " + site + " TE " + Terror);
                if (Herror == "") { Herror = Environment.NewLine; }
                File.AppendAllText(@"C:\tnh\New_tnh_log.txt", log + " " + site + " HE " + Herror);
                return;
            }
        }

       

        private static void humidity()
        {
            oHum = "";
            Herror = "";
            log = "";
            P.StartInfo.FileName = @"C:\tnh\httpget.exe";
            P.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            P.StartInfo.UseShellExecute = false;
            P.StartInfo.RedirectStandardOutput = true;
            P.StartInfo.CreateNoWindow = true;
            P.StartInfo.RedirectStandardError = true;
            P.StartInfo.Arguments = @"-r -S ""*SRH\r"" " + site + ":1000";
            P.Start();
            P.WaitForExit(1000);
            oHum = P.StandardOutput.ReadToEnd();
            Herror = P.StandardError.ReadToEnd();
            log = P.ExitTime.ToString();
            P.Close();
        }

        private static void temperature()
        {
            oTemp = "";
            Terror = "";
            log = "";
            P.StartInfo.FileName = @"C:\tnh\httpget.exe";
            P.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            P.StartInfo.UseShellExecute = false;
            P.StartInfo.RedirectStandardOutput = true;
            P.StartInfo.CreateNoWindow = true;
            P.StartInfo.RedirectStandardError = true;
            P.StartInfo.Arguments = @"-r -S ""*SRTF\r"" " + site + ":1000";
            P.Start();
            P.WaitForExit(1000);
            oTemp = P.StandardOutput.ReadToEnd();
            Terror = P.StandardError.ReadToEnd();
            log = P.ExitTime.ToString();
            P.Close();
        }

    }
}
