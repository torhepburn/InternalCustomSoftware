using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Timers;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace T_Ovens
{
    class Tr71
    {
        static Process p = new Process();
        static string site = "10.213.71.76";
        private static Timer timer;
        static string log;
        static int i;
        
        static void Main(string[] args)
        {
            timer = new Timer((1000) * (60) * (.5));
            timer.Enabled = true;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Interval = (1000) * (60) * (5);

            Console.WriteLine(site);
            Console.ReadLine();
        }

        private static void timer_Elapsed(object source, ElapsedEventArgs e)
        {
            i = 0;
            GetReading();

            while (!File.Exists(@"c:\TnH\" + site + ".txt"))
            {
                if (i < 5)
                {
                    File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " Data File Missing " +
                    site + Environment.NewLine);
                    GetReading();
                    File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " Retry " +
                    site + Environment.NewLine + Environment.NewLine);
                    i++;
                }
                else
                {
                    return;
                }
            }

            
            while (File.Exists(@"c:\TnH\" + site + ".txt"))
            {

                 string data = File.ReadAllText(@"c:\TnH\" + site + ".txt");
                
                if (data != "")
                {
                    string temperature = data.Substring((data.IndexOf("e1") + 3), 4);

                    double tmprtr1 = Convert.ToDouble(temperature);
                    tmprtr1 = (tmprtr1 * 1.8) + 32;

                    temperature = "";

                    temperature = data.Substring((data.IndexOf("e2") + 3), 4);

                    double tmprtr2 = Convert.ToDouble(temperature);
                    tmprtr2 = (tmprtr2 * 1.8) + 32;

                    try
                    {
                        SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL11; " +
                            "user = readWrite; password = Read+Write!; database = TnH;");
                        SqlCommand cmd = new SqlCommand("Insert into TnHdata " +
                            " (log, address, tempf, rh) values ('" +
                        log + "','" +
                        site + "'," +
                        tmprtr1 + "," +
                        tmprtr2 + " )", cnxn);
                        cnxn.Open();
                        cmd.ExecuteNonQuery();
                        cnxn.Close();
                        File.Delete(@"c:\TnH\" + site + ".txt");
                    }
                    catch (SqlException ex)
                    {
                        File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " SQL " + site +
                                            ex.Message + Environment.NewLine);
                        File.Delete(@"c:\TnH\" + site + ".txt");
                        return;
                    }
                }
                else
                {
                    File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " SQL " + site +
                                            "Failed to get data." + Environment.NewLine);
                }
            }
        }


        private static void GetReading()
        {
            p.Close();
            log = "";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "ftp";
            p.StartInfo.Arguments = @"-d -s:c:\tnh\" + site + "_ftp_script.txt";

            p.Start();
            p.WaitForExit((1000) * (1));

            string error = p.StandardError.ReadToEnd();

            string output = p.StandardOutput.ReadToEnd();

            log = p.ExitTime.ToString();
            
            if (!p.HasExited)
            {
                p.Close();
            }

            if (error != "")
            {
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " Error " + site + " " + error);
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " Output " + site + " " + output);
                if (error.IndexOf("local") > 0)
                {
                    Process[] All = Process.GetProcessesByName("ftp");

                    foreach (Process pFTP in All)
                    {
                        pFTP.Kill();
                        File.AppendAllText(@"C:\tnh\tnh_log.txt", log + "  " + site + "  pFTP.Kill " +
                            Environment.NewLine);
                    }
                    return;
                }
            }

        }

    }
}
