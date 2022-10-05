using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TnH
{
    public partial class ViewReadings : Form
    {
        BindingSource bs = new BindingSource();
        SqlConnection cnxn = new SqlConnection
                ("server = midprj01; user = views; password = views; " +
                 "database = tandh;");

        public ViewReadings()
        {
            InitializeComponent();
        }

        private void ViewReadings_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = (1000) * (1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter
                ("Select IP, Read_Location, Location, Last_Read_Time " +
                 " from lup_readings", cnxn);
                DataTable table = new DataTable();
                da.Fill(table);
                bs.DataSource = table;
                DGV.DataSource = bs;
                DGV.Show();
                timer1.Interval = (1000) * (60);
        }
    }
}