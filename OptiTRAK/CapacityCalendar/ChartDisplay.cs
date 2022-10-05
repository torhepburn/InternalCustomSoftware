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
using System.Globalization;

namespace CapacityCalendar
{
    public partial class ChartDisplay : Form
    {
        SqlConnection cnxn;
        SqlDataReader dr;
        SqlCommand cmd;
        
        public ChartDisplay()
        {
            InitializeComponent();
            //CultureInfo _culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            //CultureInfo _uiculture = (CultureInfo)CultureInfo.CurrentUICulture.Clone();
            //_culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
            //_uiculture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
            //System.Threading.Thread.CurrentThread.CurrentCulture = _culture;
            //System.Threading.Thread.CurrentThread.CurrentUICulture = _uiculture;
        }

        private void ChartDisplay_Load(object sender, EventArgs e)
        {
            LHeading.Text = g.workcell + "  " + "Data grouped by " + g.granularity;
            chart1.Titles.Add(g.workcell);
            chart1.Series[0].IsVisibleInLegend = false;
            chart1.Series[0].XValueType = ChartValueType.DateTime;
            
            /* StripLine only shows behind colummns
             * Annotation shows in front of columns
             */

            //StripLine sl = new StripLine();
            //sl.Interval = 0;
            //sl.StripWidth = .1;
            //sl.BackColor = System.Drawing.Color.Green;
            ////sl.IntervalOffset = 10;
            //chart1.ChartAreas[0].AxisY.StripLines.Add(sl);
            chart1.ChartAreas[0].AxisY.Title = "Hours";
            chart1.ChartAreas[0].AxisX.Title = "Dates";
            chart1.ChartAreas[0].AxisX.IntervalOffset = 1;
            //chart1.ChartAreas[0].AxisY.IntervalOffset = 1;
            chart1.ChartAreas[0].AxisX.Interval = 1;

            TextAnnotation Limit = new TextAnnotation();
            Limit.Text = "Red Line = Capacity Limit";
            Limit.X = 5;
            Limit.Y = 5;
            //Limit.BringToFront();
            Limit.ForeColor = Color.Red;
            chart1.Annotations.Add(Limit);

            HorizontalLineAnnotation hL = new HorizontalLineAnnotation();
            hL.AxisX = chart1.ChartAreas[0].AxisX;
            hL.AxisY = chart1.ChartAreas[0].AxisY;
            hL.ClipToChartArea = chart1.ChartAreas[0].Name;
            hL.LineColor = Color.Red;
            hL.LineWidth = 3;
            hL.IsInfinitive = true;
            hL.IsSizeAlwaysRelative = false;
            chart1.Annotations.Add(hL);
            cnxn = new SqlConnection(g.db);

            cmd = new SqlCommand(
                "select capacity from tblDept where deptcode = '" + g.workcell +
                "' ", cnxn);
            try
            {
                cnxn.Open();
                object o = cmd.ExecuteScalar();
                cnxn.Close();
                if (o != null)
                {
                    hL.AnchorY = Convert.ToDouble(o);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }



            if (g.granularity != "QUARTERS")
            {
                cmd = new SqlCommand(
                     "select " +
                     "RunningDate, " +
                     "SUM(rd.RunTime) RunTime " +
                     "from ScheduledRunningDates rd " +
                     "where deptcode = '" + g.workcell + "' " +
                     "and RunningDate >= '" + g.startDate + "' " +
                     "and RunningDate <= '" + g.endDate + "' " +
                     "group by runningdate " +
                     "order by runningdate", cnxn);

                cnxn.Open();

                try
                {
                    dr = cmd.ExecuteReader();
                    //can use DataBindTable with data reader, not data table
                    //need to specifiy which column will be the x axis
                    chart1.Series[0].Points.DataBind(
                    dr, "runningdate", "runtime", "Tooltip=Runningdate");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }
            }
            
            if (g.granularity == "WEEKS")
            {
                hL.AnchorY = (hL.AnchorY * 5);
                chart1.DataManipulator.Group("SUM", 1, IntervalType.Weeks, chart1.Series[0]);
                chart1.DataManipulator.InsertEmptyPoints(1, IntervalType.Weeks, chart1.Series[0]);
                chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Weeks;
                
            }
            else if (g.granularity == "MONTHS")
            {
                cmd = new SqlCommand(
                     "select " +
                     "CONVERT(varchar(3), DATENAME(month, RunningDate)) RunningDate, " +
                     "SUM(rd.RunTime) RunTime " +
                     "from ScheduledRunningDates rd " +
                     "where deptcode = '" + g.workcell + "' " +
                     "and RunningDate > '" + g.startDate + "' " +
                     "and RunningDate < '" + g.endDate + "' " +
                     "group by DATEPART(month, RunningDate), DATENAME(month, RunningDate) " +
                     "order by DATEPART(month, runningdate)", cnxn);
                try
                {
                    cnxn.Open();
                    dr = cmd.ExecuteReader();
                    //can use DataBindTable with data reader, not data table
                    //need to specifiy which column will be the x axis
                    chart1.Series[0].Points.DataBind(
                    dr, "runningdate", "runtime", "Tooltip=Runningdate");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }

                hL.AnchorY = (hL.AnchorY * 30);
            }
            else if (g.granularity == "QUARTERS")
            {
                cmd = new SqlCommand(
                     "select " +
                     "CONVERT(varchar(1), DATEPART(quarter, RunningDate)) RunningDate, " +
                     "SUM(rd.RunTime) RunTime " +
                     "from ScheduledRunningDates rd " +
                     "left join uScheduleStatus ss on rd.ssid = ss.ssid " +
                     "left join tblWorkIns w on ss.WorkID = w.WorkID " +
                     "left join tblDept d on w.DeptID = d.DeptID " +
                     "left join tblPartSN p on ss.PartID = p.PartID " +
                     "left join tblJobInfo j on p.JobID = j.JobID " +
                     "where rd.deptcode = '" + g.workcell + "' " +
                     "and RunningDate > '" + g.startDate + "' " +
                     "and RunningDate < '" + g.endDate + "' " +
                     "group by DATEPART(quarter, RunningDate)  " +
                     "order by DATEPART(quarter, runningdate)", cnxn);

                cnxn.Open();

                try
                {
                    dr = cmd.ExecuteReader();
                    //can use DataBindTable with data reader, not data table
                    //need to specifiy which column will be the x axis
                    chart1.Series[0].Points.DataBind(
                    dr, "runningdate", "runtime", "Tooltip=Runningdate");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }
                
                hL.AnchorY = (hL.AnchorY * 121);
            }
            

        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = chart1.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                DataPoint point = chart1.Series[0].Points[result.PointIndex];

                if (g.granularity == "MONTHS")
                {
                    g.loadDate = g.startDate.AddMonths(result.PointIndex);
                }
                else if (g.granularity == "QUARTERS")
                {
                    g.loadDate = g.startDate.AddMonths(result.PointIndex * 3);
                }
                else
                {
                    g.loadDate = DateTime.FromOADate(point.XValue);
                }

                WorkCellJobs w = new WorkCellJobs();
                w.ShowDialog();
            }
        }
    }
}
