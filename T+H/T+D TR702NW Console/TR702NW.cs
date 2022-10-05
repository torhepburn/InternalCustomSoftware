using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.IO;
using System.Data.SqlClient;
using System.Net;
using System.Net.NetworkInformation;

namespace T_D_TR702NW_Console
{
    class TR702NW
    {
        private static Timer timer;
        static string site = "10.213.71.61";
        static DateTime log;
        private static string data;
        private static string humidity;
        private static string temperature;
        private static int ReadingReceived;
        private static int i;

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
            ReadingReceived = 0;
            GetReading();

            while (ReadingReceived == 0)
            {
                if(i < 5)
                {
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


            try
            {
                SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL11; " +
                    "user = readWrite; password = Read+Write!; database = TnH;");
                SqlCommand cmd = new SqlCommand("Insert into TnHdata " +
                    " (log, address, tempf, rh) values ('" +
                log + "','" +
                site + "','" +
                temperature + "','" +
                humidity + "')", cnxn);
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();
            }
            //try
            //{
            //    SqlConnection cnxn = new SqlConnection("server = midprj01; " +
            //        "user = views; password = views; database = tandh;");
            //    SqlCommand cmd = new SqlCommand("Insert into tbl_readings_" + SQLtable +
            //        " (dtetime, tempf, rh, error) values ('" +
            //    log + "'," +
            //    temperature + ",'" +
            //    humidity + "', 0)", cnxn);
            //    cnxn.Open();
            //    cmd.ExecuteNonQuery();
            //    cnxn.Close();
            //    File.Delete(@"c:\TnH\" + site + ".txt");
            //}
            catch (SqlException ex)
            {
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " SQL " + site + " " +
                                    ex.Message + Environment.NewLine);

                return;
            }
        }

        private static void GetReading()
        {
            log = DateTime.Now;

            if (site.Substring(7, 3) == "131")
            {
                log = log.AddHours(-3);
            }


            WebClient client = new WebClient();
            try
            {
                string html = client.DownloadString("http://" + site + "/current.inc");
                data = html.Substring((html.IndexOf("D20") + 8), 76);
                ReadingReceived = 1;
            }
            catch (Exception ex)
            {
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " Web Client Exception " + site + " " +
                    ex.ToString() + Environment.NewLine + Environment.NewLine);
                ReadingReceived = 0;
                return;
            }

            byte[] binaryData;
            binaryData = System.Convert.FromBase64String(data);

            int T1 = binaryData[26];
            int T2 = binaryData[27];

            string THex1 = T1.ToString("x");
            string THex2 = T2.ToString("x");
            string T3 = THex2 + THex1;
            int T4 = Int16.Parse(T3, System.Globalization.NumberStyles.HexNumber);
            T4 = T4 - 1000;
            double T5 = T4 * 1.8 + 320;
            T5 = Math.Abs(T5);
            string T5A = Convert.ToString(Math.Floor(Convert.ToDecimal(T5) / 10));
            string T5B = Convert.ToString(Math.Floor(Convert.ToDecimal(T5 % 10)));
            temperature = T5A + "." + T5B;

            int H1 = binaryData[42];
            int H2 = binaryData[43];

            string hex1 = H1.ToString("x");
            string hex2 = H2.ToString("x");
            string H3 = hex2 + hex1;
            int H4 = Int16.Parse(H3, System.Globalization.NumberStyles.HexNumber);
            int H5 = H4 - 1000;
            H5 = Math.Abs(H5);
            humidity = Convert.ToString(Math.Floor(Convert.ToDecimal(H5) / 10));

            if (humidity == "92")
            {
                humidity = "28";
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " SQL " + site + " " +
                    "H92-28" + Environment.NewLine);
            }

            if (humidity == "91")
            {
                humidity = "29";
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " SQL " + site + " " +
                    "H91-29" + Environment.NewLine);
            }

            if (humidity == "90")
            {
                humidity = "54";
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " SQL " + site + " " +
                    "H90-54" + Environment.NewLine);
            }

            if (humidity == "89")
            {
                humidity = "55";
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " SQL " + site + " " +
                    "H89-55" + Environment.NewLine);
            }
        }
    }
}

