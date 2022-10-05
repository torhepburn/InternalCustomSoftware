using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;

namespace T_H_data
{
    public partial class Form1 : Form
    {
        string Terror;
        string oTemp;
        string Herror;
        string oHum;
        string log;

        Process P = new Process();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool go = true;

            while (go == true)
            {
                GetData();
                System.Threading.Thread.Sleep(300000);
            }
        }

        private void GetData()
        {
            oTemp = "";
            Terror = "";
            oHum = "";
            Herror = "";

            P.StartInfo.Arguments = @"-r -S ""*SRTF\r"" 128.1.9.217:1000";

            P.StartInfo.FileName = @"C:\program files\newport\ilog\httpget.exe";
            P.StartInfo.UseShellExecute = false;
            P.StartInfo.RedirectStandardOutput = true;
            P.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            P.StartInfo.CreateNoWindow = true;
            P.StartInfo.RedirectStandardError = true;
            P.Start();
            Terror = P.StandardError.ReadToEnd();
            oTemp = P.StandardOutput.ReadToEnd();
            P.Close();
            P.StartInfo.Arguments = @"-r -S ""*SRH\r"" 128.1.9.217:1000";

            P.StartInfo.FileName = @"C:\program files\newport\ilog\httpget.exe";
            P.StartInfo.UseShellExecute = false;
            P.StartInfo.RedirectStandardOutput = true;
            P.StartInfo.CreateNoWindow = true;
            P.StartInfo.RedirectStandardError = true;
            P.Start();
            Herror = P.StandardError.ReadToEnd();
            oHum = P.StandardOutput.ReadToEnd();
            log = P.ExitTime.ToString();
            P.Close();
            
            try
            {
                SqlConnection cnxn = new SqlConnection("server = midprj01; " +
                    "user = views; password = views; database = tandh;");
                SqlCommand cmd = new SqlCommand("Insert into tbl_readings_128_1_9_217 " +
                    " (dtetime, tempf, rh, error) values ('" +
                    log + "'," +
                    oTemp + ",'" +
                    oHum + "',0 )", cnxn);
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();
            }
            catch (SqlException ex)
            {
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " 128.1.9.217 TE " + Terror + Environment.NewLine);
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " 128.1.9.217 HE " + Herror + Environment.NewLine);
                File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " 128.1.9.217 SQL " + ex.Message + Environment.NewLine);
                return;
            }
        }
    }
}