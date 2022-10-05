using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;
using System.Net.Mail;


namespace TnH_CM_from_Mfd
{
    class Program
    {
        static string site = "172.16.1.11";
        //static string SQLtable = "172_16_1_11";
        //static string site = "128.7.0.73";
        //static string SQLtable = "128_7_0_73";

        static string log;

        private static Timer timer;
        static Process p = new Process();
        static int H;
        //static string site;
        static string type;
        //static string SQLtable = "128_1_9_96";

        static string Terror;
        //static string oTemp;
        //static string Herror;
        //static string oHum;
        //static string log;
        static string cmdText;

        static SqlConnection cnxn;
        static SqlCommand cmd;
  

        static void Main(string[] args)
        {
            timer = new Timer((1000) * (60) * (.5));
            timer.Enabled = true;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Interval = (1000)*(60)*(1);

            Console.WriteLine(site);
            Console.ReadLine();
        }

        private static void timer_Elapsed(object source, ElapsedEventArgs e)
        {
            //site = "172.16.1.11";
            //routine();

            site = "172.16.1.12";
            routine();

            //site = "128.7.0.23";
            //routine();

            //site = "128.7.0.72";
            //routine();

            //site = "128.7.0.73";
            //routine();

            //site = "128.7.0.132";
            //routine();

            //site = "128.1.9.219";
            //routine();

            //site = "128.1.9.220";
            //routine();

            //site = "128.1.9.221";
            //routine();

            //site = "128.1.9.222";
            //routine();

            //site = "128.1.9.225";
            //routine();

            //site = "128.1.9.226";
            //routine();

            //site = "128.1.9.227";
            //routine();

            //site = "128.1.9.228";
            //routine();

            //site = "128.1.9.229";
            //routine();

            //site = "128.1.9.230";
            //routine();

            //site = "128.1.9.231";
            //routine();

            //site = "128.1.9.232";
            //routine();
        }

        private static void routine()
        {
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "ftp";
            p.StartInfo.Arguments = @"-d -s:c:\tnh\" + site + "_ftp_script.txt";

            if (File.Exists(@"c:\tnh\" + site + "_ftp_script.txt") == false)
            {
                File.AppendAllText(@"C:\tnh\tnh_log.txt", @"c:\tnh\" + site +
                    "_ftp_script.txt missing");
            }

            p.Start();

            p.WaitForExit((1000) * (1));

            string error = p.StandardError.ReadToEnd();
            Console.WriteLine(error);

            string output = p.StandardOutput.ReadToEnd();

            if (site.Substring(0, 5) == "128.7")
            {
                log = p.ExitTime.AddHours(-3).ToString();
            }
            else if (site.Substring(0, 6) == "172.16")
            {
                log = p.ExitTime.AddHours(-3).ToString();
            }
            else
            {
                log = p.ExitTime.ToString();
            }

            if (error != "")
            {
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " E " + site + " " + error + Environment.NewLine);
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " E " + site + " " + output + Environment.NewLine);
                if (error.IndexOf("opening") > 0)
                {
                    MailMessage mail = new MailMessage("thepburn@zygo.com", "thepburn@zygo.com",
                        "Mtest FTP hangup " + site, site);

                    SmtpClient client = new SmtpClient("128.1.9.20", 25);
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
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " Data File Missing " + site + Environment.NewLine);
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
                    SqlConnection cnxn = new SqlConnection("server = midsql01; " +
                        "user = readwrite; password = Read+Write!; database = TnH;");
                    cmd = new SqlCommand("Insert into TnHdata " +
                    " (log, address, tempf, rh) values ('" +
                    log + "','" +
                    site + "'," +
                    tmprtr + "," +
                    humidity + ")", cnxn);
                    cmdText = cmd.CommandText;
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
        }
    }
}

