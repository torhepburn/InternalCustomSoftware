using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Calibration_KPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
                ("server=middbsql; user=views; " +
                 "password=views; database=calibration;");
            SqlCommand cmd = new SqlCommand(
                "CalibrationMetricMonthlyReport", cnxn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter loc = cmd.Parameters.Add
                ("@loc", SqlDbType.VarChar,20);
            SqlParameter month = cmd.Parameters.Add
                ("@Month", SqlDbType.DateTime);
            loc.Value = "zams%";
            month.Value = "2012-04-01";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable table = new DataTable();
            da.Fill(table);

            
        }
    }
}