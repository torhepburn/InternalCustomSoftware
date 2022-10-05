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
    public partial class UnitViewer : Form
    {
        BindingSource bs = new BindingSource();
        SqlConnection cnxn = new SqlConnection
                ("server = midprj01; user = views; password = views; " +
                 "database = tandh;");
        
        public UnitViewer()
        {
            InitializeComponent();
        }

        private void UnitViewer_Load(object sender, EventArgs e)
        {
            timer.Enabled = true;
            timer.Start();
            timer.Interval = (1000) * (1);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter
                ("Select top 2000 dtetime as [Date], tempf as Temperature, " +
                 " RH as Humidity " +
                 " from tbl_readings_172_16_1_12 " + 
                 " order by dtetime desc", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            DGV.DataSource = bs;
            DGV.Show();
            timer.Interval = (1000) * (60);
        }
    }
}