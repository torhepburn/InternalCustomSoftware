using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

namespace Chartist
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
               ("server=middbsql; user=views; " +
                "password=views; database=calibration;");

            //SqlCommand cmd = new SqlCommand
            //    ("Select [count], [time period] from " +
            //     " kpitable where [action reported] like '%not completed%' " + 
            //     " and [time period] < '2012-09-01' " +
            //     " and [time period] > '2011-08-01'", cnxn);
            SqlCommand cmd = new SqlCommand(
                "KPI.old", cnxn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter month = cmd.Parameters.Add
                ("@Month", SqlDbType.DateTime);
            SqlParameter loc = cmd.Parameters.Add
                ("@loc", SqlDbType.VarChar, 20);
            loc.Value = "zams";

            month.Value = "09-01-2012";

            cmd.Connection.Open();

            SqlDataReader dr = cmd.ExecuteReader();


            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = cmd;

            //DataTable table = new DataTable();
            //da.Fill(table);
            
            Chart2.DataBindTable(dr, "time period");
            // databinetable does not touch the existing series.
            
            foreach (Series series in Chart2.Series)
            {
                series.ChartType = SeriesChartType.Line;
                series.BorderWidth = 5;
            }

            Chart2.Legends.Add(new Legend("All Caps"));
            //Chart2.Legends["Not Completed"].DockedToChartArea = "ChartArea1";
            Chart2.Series[1].Legend = "All Caps";
            Chart2.Series[1].IsVisibleInLegend = true;
            //Chart2.ChartAreas[0].AxisX.MajorTickMark.Interval = 12;
            //Chart2.ChartAreas[0].AxisX.MajorGrid.Interval = 100;
            //Chart2.Series[1].IsVisibleInLegend = true;
          
        }
    }
}
