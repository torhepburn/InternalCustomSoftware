using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Data.SqlClient;

namespace T_H_ThermoWorks
{
    public partial class TnHThermoWorks : Form
    {
        Process p = new Process();
        int H;

        public TnHThermoWorks()
        {
            InitializeComponent();
        }

        private void TnHThermoWorks_Load(object sender, EventArgs e)
        {
                timer1.Interval = (1000) * (1);
                timer1.Enabled = true;
                timer1.Start();
                this.Text = "219";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "ftp";
            //p.StartInfo.Arguments = @"-d -s:c:\tnh\128_7_0_23_ftp_script.txt";
            p.StartInfo.Arguments = @"-d -s:c:\tnh\128_1_9_219_ftp_script.txt";
            //p.StartInfo.Arguments = @"-d -s:c:\tnh\128_1_9_220_ftp_script.txt";
            //p.StartInfo.Arguments = @"-d -s:c:\tnh\128_1_9_221_ftp_script.txt";
            //p.StartInfo.Arguments = @"-d -s:c:\tnh\128_1_9_222_ftp_script.txt";
            p.Start();
            p.WaitForExit((1000)*(1));
            if (p.HasExited == true)
            {
                string log = p.ExitTime.ToString();
                string error = p.StandardError.ReadToEnd();
                string output = p.StandardOutput.ReadToEnd();

                //string data = File.ReadAllText(@"c:\TnH\128-7-0-23.txt");
                string data = File.ReadAllText(@"c:\TnH\128-1-9-219.txt");
                //string data = File.ReadAllText(@"c:\TnH\128-1-9-220.txt");
                //string data = File.ReadAllText(@"c:\TnH\128-1-9-221.txt");
                //string data = File.ReadAllText(@"c:\TnH\128-1-9-222.txt");
                
                if (error != "")
                {
                    File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " E 128.1.9.219 " + error);
                }

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
                    //SqlCommand cmd = new SqlCommand("Insert into tbl_readings_128_7_0_23 " +
                    SqlCommand cmd = new SqlCommand("Insert into tbl_readings_128_1_9_219 " +
                    //SqlCommand cmd = new SqlCommand("Insert into tbl_readings_128_1_9_220 " +
                    //SqlCommand cmd = new SqlCommand("Insert into tbl_readings_128_1_9_221 " +
                    //SqlCommand cmd = new SqlCommand("Insert into tbl_readings_128_1_9_222 " +
                        " (dtetime, tempf, rh, error) values ('" +
                    log + "'," +
                    tmprtr + ",'" +
                    humidity + "', 0)", cnxn);
                    cnxn.Open();
                    cmd.ExecuteNonQuery();
                    cnxn.Close();
                }
                catch (SqlException ex)
                {
                    File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " SQL 128.1.9.219 " +
                                        ex.Message + Environment.NewLine);
                    return;
                }
                timer1.Interval = ((1000) * (5) * (60));
            }
        }
    }
}