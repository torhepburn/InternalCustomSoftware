using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;

namespace CalibrationView
{
    public partial class KPIt : System.Web.UI.Page
    {
        private string selectedMonth;
        private int monthNumber;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Bjanuary_Click(object sender, EventArgs e)
        {
            monthNumber = 1;
            DataSelect();
        }

        protected void Bfebruary_Click(object sender, EventArgs e)
        {
            monthNumber = 2;
            DataSelect();
        }

        protected void Bmarch_Click(object sender, EventArgs e)
        {
            monthNumber = 3;
            DataSelect();
        }

        protected void Bapril_Click(object sender, EventArgs e)
        {
            monthNumber = 4;
            DataSelect();
        }

        protected void Bmay_Click(object sender, EventArgs e)
        {
            monthNumber = 5;
            DataSelect();
        }

        protected void Bjune_Click(object sender, EventArgs e)
        {
            monthNumber = 6;
            DataSelect();
        }

        protected void Bjuly_Click(object sender, EventArgs e)
        {
            monthNumber = 7;
            DataSelect();
        }

        protected void Baugust_Click(object sender, EventArgs e)
        {
            monthNumber = 8;
            DataSelect();
        }

        protected void Bseptember_Click(object sender, EventArgs e)
        {
            monthNumber = 9;
            DataSelect();
        }

        protected void Boctober_Click(object sender, EventArgs e)
        {
            monthNumber = 10;
            DataSelect();
        }

        protected void Bnovember_Click(object sender, EventArgs e)
        {
            monthNumber = 11;
            DataSelect();
        }

        protected void Bdecember_Click(object sender, EventArgs e)
        {
            monthNumber = 12;
            DataSelect();
        }

        protected void DataSelect()
        {

            if (monthNumber >= DateTime.Now.Month)
            {
                selectedMonth = monthNumber.ToString() + "-01-" +
                    (DateTime.Now.Year - 1).ToString();
            }
            else
            {
                selectedMonth = monthNumber.ToString() + "-01-" +
                    DateTime.Now.Year.ToString();
            }

            SqlConnection cnxn = new SqlConnection
                ("server=middbsql; user=views; " +
                 "password=views; database=calibration;");
            SqlCommand cmd = new SqlCommand(
                "KPI", cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter month = cmd.Parameters.Add
                ("@Month", SqlDbType.DateTime);
            SqlParameter loc = cmd.Parameters.Add
                ("@loc", SqlDbType.VarChar, 20);
            loc.Value = "azt";

            month.Value = selectedMonth;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable table = new DataTable();
            da.Fill(table);

            GV.DataSource = table;
            GV.DataBind();

            cmd.Connection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            Chart1.DataBindTable(dr, "month");
            // databindtable creates a series you can't 
            // see in the designer

            foreach (Series series in Chart1.Series)
            {
                series.ChartType = SeriesChartType.Line;
                series.BorderWidth = 5;
            }

            Chart1.Legends.Add(new Legend("All Caps"));
            Chart1.Series[1].Legend = "All Caps";
            Chart1.Series[1].IsVisibleInLegend = true;
            Chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 30;

        }
    }
}