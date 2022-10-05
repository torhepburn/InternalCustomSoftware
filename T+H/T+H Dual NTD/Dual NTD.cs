using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;


namespace T_H_Dual_NTD
{
    class Program
    {
        private static Timer timer;
        static Process p = new Process();
        static string site = "10.213.83.9";
        static string log;
        static int i;
        static int h;
        static double H;
        static double T;
        static string Terror;
        static string oTemp;
        static string Herror;
        static string oHum;

        static void Main(string[] args)
        {
            Console.Title = site + "  Dual Newport/TD";

            timer = new Timer((1000) * (60) * (.5));
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
            timer.Interval = (1000) * (60) * (.5);
            Console.ReadLine();
        }

        private static void timer_Elapsed(object source, ElapsedEventArgs e)
        {
            i = 0;
            GetReading();

            if (File.Exists(@"c:\TnH\" + site + ".txt") == false)
            {
                oTemp = "";
                Terror = "";
                oHum = "";
                Herror = "";
                //cmdText = "";

                i = 0;
                temperature();

                while (oTemp == "")
                {
                    if (i < 5)
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
                    SqlConnection cnxn = new SqlConnection("server = midsql01; " +
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

            while (File.Exists(@"c:\TnH\" + site + ".txt"))
            {
                string data = File.ReadAllText(@"c:\TnH\" + site + ".txt");

                string temperature = data.Substring((data.IndexOf("e1") + 3), 4);

                double tmprtr = Convert.ToDouble(temperature);
                tmprtr = (tmprtr * 1.8) + 32;

                if (data.IndexOf("w") == data.IndexOf("y=") + 6)
                {
                    h = 2;
                }
                else
                {
                    h = 1;
                }

                string humidity = data.Substring((data.IndexOf("y=") + 2), h);

                try
                {
                    SqlConnection cnxn = new SqlConnection("server = midsql01; " +
                        "user = readWrite; password = Read+Write!; database = TnH;" +
                        "Connect Timeout = 20;");
                    SqlCommand cmd = new SqlCommand("Insert into TnHdata " +
                        " (log, address, tempf, rh) values ('" +
                    log + "','" +
                    site + "'," +
                    tmprtr + ",'" +
                    humidity + "')", cnxn);
                    cnxn.Open();
                    cmd.ExecuteNonQuery();
                    cnxn.Close();
                    File.Delete(@"c:\TnH\" + site + ".txt");
                }
                catch (SqlException ex)
                {
                    File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " SQL " + site + " " +
                                        ex.Message + Environment.NewLine);
                    File.Delete(@"c:\TnH\" + site + ".txt");
                    return;
                }
            }

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

            if (File.Exists(@"c:\tnh\" + site + "_ftp_script.txt") == false)
            {
                File.AppendAllText(@"C:\tnh\tnh_log.txt", @"c:\tnh\" + site +
                    "_ftp_script.txt missing" + Environment.NewLine);
            }

            p.Start();
            p.WaitForExit((1000) * (1));

            string error = p.StandardError.ReadToEnd();

            string output = p.StandardOutput.ReadToEnd();

            if (site.Substring(0, 9) == "10.213.83")
            {
                log = DateTime.UtcNow.AddHours(-7).ToString();
            }
            else if ((site.Substring(0, 9) == "10.213.97") | (site.Substring(0, 10) == "10.213.131"))
            {
                log = p.ExitTime.AddHours(-3).ToString();
            }
            else
            {
                log = p.ExitTime.ToString();
            }

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

        private static void humidity()
        {
            p.StartInfo.FileName = @"C:\tnh\httpget.exe";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.Arguments = @"-r -S ""*SRH\r"" " + site + ":1000";
            p.Start();
            p.WaitForExit(1000);
            oHum = p.StandardOutput.ReadToEnd();
            Herror = p.StandardError.ReadToEnd();
            if (site.Substring(0, 9) == "10.213.83")
            {
                log = DateTime.UtcNow.AddHours(-7).ToString();
            }
            else
            {
                log = p.ExitTime.ToString();
            }
            p.Close();
        }

        private static void temperature()
        {
            p.StartInfo.FileName = @"C:\tnh\httpget.exe";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.Arguments = @"-r -S ""*SRTF\r"" " + site + ":1000";
            p.Start();
            p.WaitForExit(1000);
            oTemp = p.StandardOutput.ReadToEnd();
            Terror = p.StandardError.ReadToEnd();
            if (site.Substring(0, 9) == "10.213.83")
            {
                log = DateTime.UtcNow.AddHours(-7).ToString();
            }
            else
            {
                log = p.ExitTime.ToString();
            }
            p.Close();
        }

    }

}