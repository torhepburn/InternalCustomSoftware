using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace T_H_Newport_Console
{
    class Newport
    {
        private static Timer timer;
        static Process P = new Process();
        static double H;
        static double T;
        static string site = "10.213.83.1";
        static string SQLtable = "128_7_0_20";

        static string Terror;
        static string oTemp;
        static string Herror;
        static string oHum;
        static string log;
        static string cmdText;

        static void Main(string[] args)
        {
            Console.Title = site + "  Omega/Newport";
            
            timer = new Timer((1000) * (60) * (.5));
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
            timer.Interval = (1000) * (60) * (.5);

            //timer.AutoReset = false;

            File.AppendAllText(@"C:\tnh\tnh_log.txt", Environment.NewLine +
                    DateTime.Now.ToString() + "  " + site +
                    "  program starting." + Environment.NewLine);

            Console.ReadLine();
        }


        private static void timer_Elapsed(object source, ElapsedEventArgs e)
        {
            //Ping png = new Ping();
            //PingReply r;

            //r = png.Send("10.213.71.74");

            //if (r.Status == IPStatus.Success)
            //{
            //    site = "10.213.71.69";
            //}


            //oTemp = "";
            //Terror = "";
            //oHum = "";
            //Herror = "";
            //cmdText = "";

            //temperature();


            //if (oTemp == "")
            //{
            //    File.AppendAllText(@"C:\tnh\tnh_log.txt", Environment.NewLine + log +
            //        " " + site + " Temperature Retry.  Length: " + oTemp.Length.ToString()
            //        + Environment.NewLine);
            //    System.Threading.Thread.Sleep(5000);
            //    temperature();
            //}

            //T = Convert.ToDouble(oTemp);

            //System.Threading.Thread.Sleep(5000);

            humidity();

            if (oHum != "")
            {
                H = Convert.ToDouble(oHum);
            }

            if (H == 0)
            {
                File.AppendAllText(@"C:\tnh\tnh_log.txt", Environment.NewLine + log +
                    " " + site + " Humidity = 0" + Environment.NewLine);
                System.Threading.Thread.Sleep(5000);
                humidity();
            }

            if (oHum != "")
            {
                H = Convert.ToDouble(oHum);
            }

            try
            {
                SqlConnection cnxn = new SqlConnection("server = midprj01; " +
                    "user = views; password = views; database = tandh;");
                SqlCommand cmd = new SqlCommand("Insert into tbl_readings_" + SQLtable +
                    " (dtetime, tempf, rh, error) values ('" +
                    log + "'," +
                    T + ",'" +
                    H + "',0 )", cnxn);
                cmdText = cmd.CommandText;
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();
            }
            catch (SqlException ex)
            {
                if (Terror == "") { Terror = Environment.NewLine; }
                File.AppendAllText(@"C:\tnh\tnh_log.txt", Environment.NewLine + log + " " + site + " TE " + Terror);
                if (Herror == "") { Herror = Environment.NewLine; }
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " " + site + " HE " + Herror);
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " " + site + " SQL " + ex.Message + Environment.NewLine);
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " " + site + " SQL " + cmdText + Environment.NewLine);
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " oTemp = XX" + oTemp + "XX" + Environment.NewLine);
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " TempLength = " + oTemp.Length + Environment.NewLine);
                return;
            }
        }

        private static void humidity()
        {
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
            if (site.Substring(0, 9) == "10.213.83")
            {
                log = DateTime.UtcNow.AddHours(-7).ToString();
            }
            else
            {
                log = P.ExitTime.ToString();
            }
            P.Close();
        }

        private static void temperature()
        {
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
            if (site.Substring(0, 9) == "10.213.83")
            {
                log = DateTime.UtcNow.AddHours(-7).ToString();
            }
            else
            {
                log = P.ExitTime.ToString();
            }
            P.Close();
        }
 
    }
}
