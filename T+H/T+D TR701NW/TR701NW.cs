using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.IO;
using System.Data.SqlClient;
using System.Net;
using System.Net.NetworkInformation;

namespace T_D_TR701NW
{
    class TR701NW
    {
        private static Timer timer;
        static string site = "10.213.131.8";
        //static string SQLtable = "172_18_106_187";
        static DateTime log;
        private static string data;
        private static string temperature1;
        private static string temperature10;
        private static int ReadingReceived;
        private static int i;
        
        static void Main(string[] args)
        {

            GetReading();
            Console.Title = site + "  T&D TR701NW";
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
                if (i < 5)
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

            //try
            //{
            //    SqlConnection cnxn = new SqlConnection("server = midprj01; " +
            //        "user = views; password = views; database = tandh;");
            //    SqlCommand cmd = new SqlCommand("Insert into tbl_readings_" + SQLtable +
            //        " (dtetime, temp1f, temp2f, error) values ('" +
            //    log + "'," +
            //    temperature1 + ",'" +
            //    temperature10 + "', 0)", cnxn);
            //    cnxn.Open();
            //    cmd.ExecuteNonQuery();
            //    cnxn.Close();

            //}
            try
            {
                SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL11; " +
                    "user = readWrite; password = Read+Write!; database = TnH;");
                SqlCommand cmd = new SqlCommand("Insert into TnHdata " +
                    " (log, address, tempF, rh) values ('" +
                log + "','" +
                site + "','" +
                temperature1 + "','" +
                temperature10 + "')", cnxn);
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

        private static void GetReading()
        {

            log = DateTime.Now;

            if (site.Substring(7, 3) == "131")
            {
                log = DateTime.UtcNow.AddHours(-7);
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
            //double T5 = T4;
            T5 = Math.Abs(T5);
            string T5A = Convert.ToString(Math.Floor(Convert.ToDecimal(T5) / 10));
            string T5B = Convert.ToString(Math.Floor(Convert.ToDecimal(T5 % 10)));
            temperature1 = T5A + "." + T5B;

            int T10 = binaryData[42];
            int T20 = binaryData[43];

            string THex10 = T10.ToString("x");
            string THex20 = T20.ToString("x");
            string T30 = THex20 + THex10;
            int T40 = Int16.Parse(T30, System.Globalization.NumberStyles.HexNumber);
            T40 = T40 - 1000;
            double T50 = T40 * 1.8 + 320;
            T50 = Math.Abs(T50);
            string T50A = Convert.ToString(Math.Floor(Convert.ToDecimal(T50) / 10));
            string T50B = Convert.ToString(Math.Floor(Convert.ToDecimal(T50 % 10)));
            temperature10 = T50A + "." + T50B;

        }
    }
}

