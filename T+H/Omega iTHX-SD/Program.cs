using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;
//using System.Threading;

namespace Omega_iTHX_SD
{
    class Program
    {
        private static System.Timers.Timer timer;
        static Process P = new Process();
        static string site = "10.213.71.65";
        static string receivedData;
        static string log;
        

        static void Main(string[] args)
        {
            Console.Title = site + "  Omega iTHX-SD";

            timer = new System.Timers.Timer((1000) * (60) * (.5));
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
            timer.Interval = (1000) * (60) * (5);
            Console.ReadLine();
        }

        private static void timer_Elapsed(object source, ElapsedEventArgs e)
        {
            getData();
            
        }



        private static void getData()
        {
            P.StartInfo.FileName = @"C:\tnh\httpget.exe";
            P.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            P.StartInfo.UseShellExecute = false;
            P.StartInfo.RedirectStandardOutput = true;
            P.StartInfo.CreateNoWindow = true;
            P.StartInfo.RedirectStandardError = true;
            P.StartInfo.Arguments = @" -r -S ""*SRBF"" " + site + ":2000";
            P.Start();
            //int milliseconds = 10000;
            //Thread.Sleep(milliseconds);
            receivedData = P.StandardOutput.ReadToEnd();
            log = P.ExitTime.ToString();
            
            if ((site.Substring(0, 9) == "10.213.97") | (site.Substring(0, 10) == "10.213.131"))
            {
                log = P.ExitTime.AddHours(-3).ToString();
            }
            else
            {
                log = P.ExitTime.ToString();
            }

            P.Close();

            string T = receivedData.Substring(0, 5);
            string H = receivedData.Substring(6, 5);
            
            SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL11; " +
                    "user = readWrite; password = Read+Write!; database = TnH;");
            /*
            SqlParameter pSite = new SqlParameter("@site", SqlDbType.VarChar);
            pSite.Value = site;
            */
            try
            {
                
                SqlCommand cmd = new SqlCommand("Insert into TnHdata " +
                    " (log, address, tempf, rh) values ('" +
                log + "','" +
                site + "','" +
                T + "','" +
                H + "')", cnxn);
                cnxn.Open();
                //cmd.Parameters.Add(pSite);
                cmd.ExecuteNonQuery();
                cnxn.Close();

            }
            catch (SqlException ex)
            {
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " SQL " + site + " " +
                                    ex.Message + Environment.NewLine);

                return;
            }
            finally
            {
                cnxn.Close();
            }

            log = string.Empty;
            
        }
    }
}
