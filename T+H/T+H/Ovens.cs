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
using System.Net.NetworkInformation;

namespace T_H_Ovens
{
    public partial class Ovens : Form
    {
        Process p = new Process();
        private string site = "10.213.71.76";
        private string SQLtable = "128_1_9_224";
        
        public Ovens()
        {
            InitializeComponent();
        }

        private void Ovens_Load(object sender, EventArgs e)
        {
            bool go = true;

            while (go == true)
            {
                GetData();
                System.Threading.Thread.Sleep(30000);
            }
        }

        private void GetData()
        {
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "ftp";
            
            p.StartInfo.Arguments = @"-d -s:c:\tnh\" + site + "_ftp_script.txt";
            p.Start();
            System.Threading.Thread.Sleep(1000);
            if (p.HasExited == true)
            {
                string log = p.ExitTime.ToString();
                string error = p.StandardError.ReadToEnd();
                p.WaitForExit();
                string output = p.StandardOutput.ReadToEnd();

                string data = File.ReadAllText(@"c:\TnH\" + site + ".txt");
                
                if (error != "")
                {
                    File.AppendAllText(@"C:\tnh\tnh_log.txt", log +
                        " E " + site + " " + error + Environment.NewLine);
                    
                }


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
                        SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL01.zygo.com; " +
                            "user = views; password = views; database = tandh;");
                        SqlCommand cmd = new SqlCommand("Insert into tbl_readings_" + SQLtable  +
                            " (dtetime, temp1f, temp2f, error) values ('" +
                        log + "'," +
                        tmprtr1 + "," +
                        tmprtr2 + ", 0)", cnxn);
                        cnxn.Open();
                        cmd.ExecuteNonQuery();
                        cnxn.Close();
                    }
                    catch (SqlException ex)
                    {
                        File.AppendAllText(@"C:\tnh\tnh_log.txt", log + " SQL " + site +
                                            ex.Message + Environment.NewLine);
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
    }
}