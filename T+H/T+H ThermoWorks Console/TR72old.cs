using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net.NetworkInformation;

namespace T_H_ThermoWorks_Console
{
    class TR72old
    {
        private static Timer timer;
        static Process p = new Process();
        static int H;
        static string site = "10.213.71.84";
        static string SQLtable = "128_1_9_231";
        static string log;
        
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
            //Ping png = new Ping();
            //PingReply r;

            //r = png.Send("10.213.131.1");

            //if (r.Status == IPStatus.Success)
            //{
            //    site = "10.213.131.1";
            //}

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
                    MailMessage mail = new MailMessage("thepburn@zygo.com", "thepburn@zygo.com",
                        "FTP hangup " + site, site);

                    SmtpClient client = new SmtpClient("mail.zygo.com", 25);
                    client.UseDefaultCredentials = true;
                    client.Send(mail);

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

            if (!File.Exists(@"c:\TnH\" + site + ".txt"))
            {
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " Data File Missing " +
                    site + Environment.NewLine);
            }

            while (File.Exists(@"c:\TnH\" + site + ".txt"))
            {
                string data = File.ReadAllText(@"c:\TnH\" + site + ".txt");

                string temperature = data.Substring((data.IndexOf("e1") + 3), 4);

                double tmprtr = Convert.ToDouble(temperature);
                tmprtr = (tmprtr * 1.8) + 32;

                if (data.IndexOf("w") == data.IndexOf("y=") + 6)
                {
                    H = 2;
                }
                else
                {
                    H = 1;
                }

                string humidity = data.Substring((data.IndexOf("y=") + 2), H);

                try
                {
                    SqlConnection cnxn = new SqlConnection("server = midprj01; " +
                        "user = views; password = views; database = tandh;");
                    SqlCommand cmd = new SqlCommand("Insert into tbl_readings_" + SQLtable +
                        " (dtetime, tempf, rh, error) values ('" +
                    log + "'," +
                    tmprtr + ",'" +
                    humidity + "', 0)", cnxn);
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

                //try
                //{
                //    SqlConnection cnxn = new SqlConnection("server = midsql01; " +
                //        "user = readWrite; password = Read+Write!; database = TnH;");
                //    SqlCommand cmd = new SqlCommand("Insert into TnHdata " +
                //        " (log, address, tempf, rh) values ('" +
                //    log + "','" +
                //    site + "'," +
                //    tmprtr + ",'" +
                //    humidity + "')", cnxn);
                //    cnxn.Open();
                //    cmd.ExecuteNonQuery();
                //    cnxn.Close();

                //}
                //catch (SqlException ex)
                //{
                //    File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " SQL " + site + " " +
                //                        ex.Message + Environment.NewLine);
                //    return;
                //}

            }
        }
    }
    }

