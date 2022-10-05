using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace T_H_Single_Unit_Viewer
{
    public partial class TucsonTest : Form
    {
        BindingSource bs = new BindingSource();
        SqlConnection cnxn = new SqlConnection
                ("server = midsql01; user = views; password = views; " +
                 "database = tnh;");

        public TucsonTest()
        {
            InitializeComponent();
        }

        private void TucsonTest_Load(object sender, EventArgs e)
        {
        //    timer.Enabled = true;
        //    timer.Start();
        //    timer.Interval = (1000) * (1);
        //}

        //private void timer_Tick(object sender, EventArgs e)
        //{
            SqlDataAdapter da = new SqlDataAdapter
                ("Select log as [Date], tempf as Temperature, " +
                 " RH as Humidity " +
                 " from tnhdata " +
                 " where address = '128.7.0.73' " +
                 " and log > '2013-05-02' " +
                 " order by log desc", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            DGV.DataSource = bs;
            DGV.Show();
            timer.Interval = (1000) * (60);
        }
    }
}