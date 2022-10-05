using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;
using System.Net.Mail;

namespace CostaMesa
{
    class Program
    {
        //private static Timer timer;
        static Process p = new Process();
        static int H;
        static string site = "172.16.1.11";
        static string SQLtable = "172_16_1_11";
        //static string site = "128.7.0.73";
        //static string SQLtable = "128_7_0_73";
        
        static string log;
        
        static void Main(string[] args)
        {
        //    timer = new Timer((1000)*(60)*(.5));
        //    timer.Enabled = true;
        //    timer.Elapsed +=new ElapsedEventHandler(timer_Elapsed);
        //    //timer.Interval = (1000)*(60)*(5);

        //    Console.WriteLine(site);
        //    Console.ReadLine();
        //}

        //private static void timer_Elapsed(object source, ElapsedEventArgs e)
        //{
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "ftp";
            p.StartInfo.Arguments = @"-d -s:c:\tnh\" + site + "_ftp_script.txt";

            //if (File.Exists(@"c:\tnh\" + site + "_ftp_script.txt") == false)
            //{
            //    File.AppendAllText(@"C:\tnh\tnh_log.txt", @"c:\tnh\" + site +
            //        "_ftp_script.txt missing");
            //}
            
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
           
            //if (error != "")
            //{
            //    File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " E " + site + " " + error);
            //    File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " E " + site + " " + output);
            //    if (error.IndexOf("Error opening local file") > 0)
            //    {
            //        MailMessage mail = new MailMessage("thepburn@zygo.com", "thepburn@zygo.com",
            //            "FTP hangup", site);
            //        MailAddress copy = new MailAddress("tor.hepburn@gmail.com");
            //        mail.CC.Add(copy);
            
            //        SmtpClient client = new SmtpClient("128.1.9.20", 25);
            //        client.UseDefaultCredentials = true;
            //        client.Send(mail);
            //        p.Kill();
            //        return;
            //    }
            //}

            //if (!File.Exists(@"c:\TnH\" + site + ".txt"))
            //{
            //    File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " Data File Missing " + site );
            //}
           
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
                }
            }   
        }
    }

