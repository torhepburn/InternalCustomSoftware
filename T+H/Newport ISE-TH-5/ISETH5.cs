using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;

namespace Newport_ISE_TH_5
{
    class ISETH5
    {
        private static Timer timer;
        static Process P = new Process();
        static double H;
        static double T;
        static string site = "10.213.71.97";
        static string Terror;
        static string oTemp;
        static string Herror;
        static string oHum;
        static string log;
        static string cmdText;
        static int i;

        static void Main(string[] args)
        {
            Console.Title = site + "  Omega/Newport";

            timer = new Timer((1000) * (60) * (.5));
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
            timer.Interval = (1000) * (60) * (5);
            Console.ReadLine();
        }

        private static void timer_Elapsed(object source, ElapsedEventArgs e)
        {
            oTemp = "";
            Terror = "";
            oHum = "";
            Herror = "";
            cmdText = "";

            i = 0;
            temperature();

            while (oTemp == "")
            {
                if( i < 5 )
                {
                    File.AppendAllText(@"C:\tnh\tnh_log.txt", Environment.NewLine + log +
                      " " + site + " Temperature Retry.  Length: " + oTemp.Length.ToString()
                      + Environment.NewLine);
                    System.Threading.Thread.Sleep(5000);
                    temperature();
                    i++;
                }
                else
                {
                    return;
                }
                
            }

            T = Convert.ToDouble(oTemp);

            System.Threading.Thread.Sleep(5000);

            i = 0;
            humidity();

            if (oHum != "")
            {
                H = Convert.ToDouble(oHum);
            }

            while (H == 0)
            {
                if (i < 5)
                {
                    File.AppendAllText(@"C:\tnh\tnh_log.txt", Environment.NewLine + log +
                    " " + site + " Humidity = 0" + Environment.NewLine);
                    System.Threading.Thread.Sleep(5000);
                    humidity();
                    i++;
                }
                else
                {
                    return;
                }
            }

            if (oHum != "")
            {
                H = Convert.ToDouble(oHum);
            }

            try
            {
                SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL11; " +
                    "user = readWrite; password = Read+Write!; database = TnH;");
                SqlCommand cmd = new SqlCommand("Insert into TnHdata " +
                    " (log, address, tempf, rh) values ('" +
                log + "','" +
                site + "'," +
                T + ",'" +
                H + "')", cnxn);
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();

            }
            catch (SqlException ex)
            {
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " SQL " + site + " " +
                                    ex.Message + Environment.NewLine);

                return;
            }
        }

        private static void humidity()
        {
            //P.StartInfo.FileName = @"C:\tnh\httpget18.exe";
            P.StartInfo.FileName = @"C:\tnh\httpget.exe";
            //P.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            P.StartInfo.UseShellExecute = false;
            P.StartInfo.RedirectStandardOutput = true;
            //P.StartInfo.CreateNoWindow = true;
            //P.StartInfo.RedirectStandardError = true;
            //P.StartInfo.Arguments = @" -r -S ""*SRH\r"" " + site + ":2000";  // for the new units use port 2000
            P.StartInfo.Arguments = @" -r -S ""*SRH\r"" " + site + ":1000";
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
            /*  */
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
