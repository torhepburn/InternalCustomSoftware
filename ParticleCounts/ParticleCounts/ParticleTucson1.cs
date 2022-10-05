using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WSMBT;
using System.Data.SqlClient;
using System.Timers;


namespace ParticleCounts
{
    public partial class ParticleTucson1 : Form
    {
        //private string timemark = DateTime.Now.ToShortTimeString();
        private string log;
        private string Zpoint3;
        private string Zpoint5;
        private string N1point0;
        private string N3point0;
        private string N5point0;
        private string N10point0;
        private string SampleTime;
        private string Volume;
        private string sensorLocation;
        private string ReadingNumberFromCounter;
        private System.Timers.Timer timer;
        
        public ParticleTucson1()
        {
            InitializeComponent();
        }

        private void ParticleTucson1_Load(object sender, EventArgs e)
        {
            this.Text = "10.213.97.4 AeroTEK Selection";
            timer = new System.Timers.Timer((1000) * (60) * (.5));
            timer.Enabled = true;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Interval = (1000) * (60) * (21);
            //timer.Interval = (1000) * (60) * (2);
        }

        private void timer_Elapsed(object source, ElapsedEventArgs e)
        {
            WSMBT.Result Result;
            WSMBT.WSMBTControl wsmbtControl1 = new WSMBTControl();
            wsmbtControl1.Mode = WSMBT.Mode.TCP_IP;
            wsmbtControl1.ResponseTimeout = 3000;
            //Result = wsmbtControl1.Connect("10.213.83.7", 502);
            Result = wsmbtControl1.Connect("10.213.97.4", 502);
            //timemark = timemark.Replace(":", "-");
            if (Result != WSMBT.Result.SUCCESS)
            {
                //MessageBox.Show(wsmbtControl1.GetLastErrorString());
                File.AppendAllText(@"C:\a\tsi.txt", DateTime.Now.ToString() + ' ' + 
                    wsmbtControl1.GetLastErrorString() + Environment.NewLine);
                return;
            }

            for (ushort ii = 2001; ii < 2073; ii++)
            {
                Int16[] Registers = new Int16[2];
                //WSMBT.Result Result;
                Result = wsmbtControl1.ReadHoldingRegisters(1, ii, 1, Registers);
                //Result = wsmbtControl1.ReadInputRegisters(1, ii, 1, Registers);
                if (Result == WSMBT.Result.SUCCESS)
                {
                    string DataString = "";
                    string str = "";


                    for (int i = 0; i < 1; i++)
                    {
                        str = string.Format("{0:D}", Registers[i]);
                        DataString = ii + "  " + str + Environment.NewLine;
                    }
                    if (ii == 2001)
                    {
                        ReadingNumberFromCounter = str;
                    }
                    if (ii == 2006)
                    {
                        //year
                        log = str;
                    }
                    if (ii == 2007)
                    {
                        //month
                        if (str.Length == 1)
                        {
                            str = "0" + str;
                        }
                        log = log + "-" + str;
                    }
                    if (ii == 2008)
                    {
                        //day
                        if (str.Length == 1)
                        {
                            str = "0" + str;
                        }
                        log = log + "-" + str;
                    }
                    if (ii == 2009)
                    {
                        //hours
                        if (str.Length == 1)
                        {
                            str = "0" + str;
                        }
                        log = log + " " + str;
                    }
                    if (ii == 2010)
                    {
                        //minutes
                        if (str.Length == 1)
                        {
                            str = "0" + str;
                        }
                        log = log + ":" + str;
                    }
                    if (ii == 2011)
                    {
                        //seconds
                        if (str.Length == 1)
                        {
                            str = "0" + str;
                        }
                        log = log + ":" + str;
                    }
                    if (ii == 2021)
                    {
                        SampleTime = str;
                    }
                    if (ii == 2026)
                    {
                        Zpoint3 = str;
                    }
                    if (ii == 2028)
                    {
                        //float b = Convert.ToSingle(str);
                        //float c = b * 35.3146667F;
                        //int rounded = (int)Math.Round(c);
                        //Zpoint5 = rounded.ToString();
                        Zpoint5 = str;
                    }
                    if (ii == 2030)
                    {
                        N1point0 = str;
                    }
                    if (ii == 2032)
                    {
                        N3point0 = str;
                    }
                    if (ii == 2034)
                    {
                        N5point0 = str;
                    }
                    if (ii == 2036)
                    {
                        N10point0 = str;
                    }


                    //File.AppendAllText(@"C:\a\tsi" + timemark + ".txt", DataString);
                }
                //else
                //{
                //    string str = "no reading";
                //    string DataString = ii + "  " + str + Environment.NewLine;
                //    File.AppendAllText(@"C:\a\tsi" + timemark + ".txt", DataString);
                //    //MessageBox.Show(wsmbtControl1.GetLastErrorString());
                //}
            }

            SqlConnection cnxn = new SqlConnection
                ("server=midsql01; user=readwrite; password=Read+Write!; database=tnh;");

            SqlCommand cmd = new SqlCommand("Select location from sensorlocation where " +
                "address = '10.213.97.4'", cnxn);
            cnxn.Open();

            object o = cmd.ExecuteScalar();

            cnxn.Close();

            sensorLocation = o.ToString().Trim();
            
            
            cmd = new SqlCommand("Insert into ParticleCountData (" +
                   "Location, " +               //1
                   "LogDate, " +
                   "[0.3], " +
                   "[0.5], " +
                   "[1.0], " +              //5
                   "[3.0], " +
                   "[5.0], " +
                   "[10.0], " +
                   "Volume," +
                   "SampleTime," +
                   "ReadingNumberFromCounter" +
                   ") values (" +
                   "'" + sensorLocation +         //1
                   "','" + log +
                   "'," + Zpoint3 +
                   "," + Zpoint5 +
                   "," + N1point0 +                        //5
                   "," + N3point0 +
                   "," + N5point0 +
                   "," + N10point0 +
                   ", 0 " +
                   "," + SampleTime +
                   "," + ReadingNumberFromCounter +
                   ") ");

            cmd.Connection = cnxn;
            cnxn.Open();
            try
            {
                int rowsReturned = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
    }

}
