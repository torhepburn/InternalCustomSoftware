using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace PCC_data
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("c:\\a\\4104SQL.csv");

            while (sr.Peek() >= 0)
            {
                string x = sr.ReadLine();

                string[] insert = x.Split(',');

                DateTime dt = Convert.ToDateTime(insert[2]);
                
                SqlConnection cxn = new SqlConnection("server = midprj01; " +
                    "user id = views; password = views; database = productioncontrol;");

                SqlCommand cmd = new SqlCommand("Insert into dbo.[test data] " +

                    "(sn, " +
                    "[its build number], " +
                    "[test date], " +
                    "[MeasPower_10_Ax1], " +
                    "[MeasPower_1_Ax1], " +
                    "[MeasPower_07_Ax1]) " +
                    "values " +
                    "('" + insert[0].ToString().Trim() +
                    "','" + insert[1].ToString().Trim() +
                    "','" + dt +
                    "','" + insert[3].Trim() +
                    "','" + insert[4].Trim() +
                    "','" + insert[5].Trim() +
                    "')");


                cmd.Connection = cxn;
                cxn.Open();
                int rowsReturned = cmd.ExecuteNonQuery();
                cxn.Close();
            }
        }
    }
}