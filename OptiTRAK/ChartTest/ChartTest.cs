using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartTest
{
    public partial class ChartTest : Form
    {
        SqlConnection cnxn;
        SqlDataReader dr;
        DataTable dt;
        SqlDataAdapter da;

        public ChartTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Titles.Add("R05 - maximum capacity 258 hours");
            chart1.Series[0].IsVisibleInLegend = false;
            chart1.Series[0].XValueType = ChartValueType.DateTime;
            StripLine sl = new StripLine();
            sl.Interval = 0;
            sl.StripWidth = 1;
            sl.BackColor = System.Drawing.Color.Red;
            sl.IntervalOffset = 40;
            chart1.ChartAreas[0].AxisY.StripLines.Add(sl);
            chart1.ChartAreas[0].AxisY.Title = "Hours";
            chart1.ChartAreas[0].AxisX.Title = "Dates";
            
            cnxn = new SqlConnection(g.db);

            SqlDataAdapter da = new SqlDataAdapter(
                 "select " +
                 "RunningDate, " +
                 "SUM(rd.RunTime)/60 RunTime " +
                 "from ScheduledRunningDates rd " +
                 "left join uScheduleStatus ss on rd.ssid = ss.ssid " +
                 "left join tblWorkIns w on ss.WorkID = w.WorkID " +
                 "left join tblDept d on w.DeptID = d.DeptID " +
                 "left join tblPartSN p on ss.PartID = p.PartID " +
                 "left join tblJobInfo j on p.JobID = j.JobID " +
                 "where PartPOClosed = 0 " +
                 "and JobComplete = 0 " +
                 "and deptcode = 'R05' " +
                 "and RunningDate > '02-02-2016' " +
                 "and RunningDate < '04-01-2016' " +
                 "group by runningdate " +
                 "order by runningdate"
                 , cnxn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            
            
            //SqlCommand cmd = new SqlCommand(
            //     "select " +
            //     "RunningDate, " +
            //     "SUM(rd.RunTime)/60 RunTime " +
            //     "from ScheduledRunningDates rd " +
            //     "left join uScheduleStatus ss on rd.ssid = ss.ssid " +
            //     "left join tblWorkIns w on ss.WorkID = w.WorkID " +
            //     "left join tblDept d on w.DeptID = d.DeptID " +
            //     "left join tblPartSN p on ss.PartID = p.PartID " +
            //     "left join tblJobInfo j on p.JobID = j.JobID " +
            //     "where PartPOClosed = 0 " +
            //     "and JobComplete = 0 " +
            //     "and deptcode = 'R05' " +
            //     "and RunningDate > '02-02-2016' " +
            //     "and RunningDate < '06-01-2016' " +
            //     "group by runningdate " +
            //     "order by runningdate"
            //     , cnxn);

            //cnxn.Open();

            //try
            //{
              
            //    dr = cmd.ExecuteReader();
            //    //chart1.DataBindTable(dr, "runningdate");
            //    //can use DataBindTable with data reader, not data table
            //    //need to specifiy which column will be the x axis
            //    chart1.Series[0].Points.DataBind(
            //    dr, "runningdate", "runtime", "Tooltip=Runningdate");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //cnxn.Close();
            //chart1.Series.Add("test");
            chart1.Series[0].XValueMember = "RunningDate";
            chart1.Series[0].YValueMembers = "RunTime";
            chart1.DataSource = dt;
            chart1.DataBind();


        }

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            HitTestResult result = chart1.HitTest(e.X, e.Y);
 
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                DataPoint point = chart1.Series[0].Points[result.PointIndex];
 
                label1.Text = "chart1.Series[0].Points[0].ToString() " + chart1.Series[0].Points[0].ToString();

                label2.Text = "dt.Rows[0][0].ToString() " + dt.Rows[0][0].ToString();
                
                
                //SqlCommand cmd = new SqlCommand("select CAST(" + label1.Text + " as datetime)", cnxn);

                //cnxn.Open();

                //DateTime x = DateTime.FromOADate(42447);
                //try
                //{
                //    object o = cmd.ExecuteScalar();
                //    label2.Text = o.ToString();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.ToString());
                //}
                //cnxn.Close();
                


            }
        }

        
    }

    public static class g
    {
        public static DateTime loadDate;
        public static string workcell;
        //public static string taskhistory;
        //public static string userType;
        public static string db = "server = midsql01; password = Read+Write!; " +
                            "user = readwrite; database = OptiTRAK;";

    }

}