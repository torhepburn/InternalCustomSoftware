using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CapacityChart
{
    public partial class CapacityChart1 : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable dt;
        SqlDataReader dr; 

        public CapacityChart1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            //this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            //this.chart1.Titles.Add("pets");
            //this.chart1.Legends.Add("Legend of the Fall");

            cnxn = new SqlConnection(g.db);

            da = new SqlDataAdapter(
            //SqlCommand cmd = new SqlCommand
                //("declare @cols varchar(max) " +
                // "declare @query varchar(max) " +
                // "with s1 as " +
                // "( " +
                // "select distinct CONVERT(varchar(10), runningdate, 1) RD " +
                // "from ScheduledRunningDates where " +
                // "runningdate > '02-02-2016' and RunningDate < '04-01-2016' " +
                // ") " +
                // "Select @cols = COALESCE( + @cols + '], [', '[') + RD from s1 " +
                // "order by RD " +
                // "set @query = N' " +
                // "select '''' [Capacity (m/day)], * from " +
                // "( " +
                 "select " +
                 //"DeptCode, " +
                 "RunningDate, " +
                 "rd.RunTime " +
                 "from ScheduledRunningDates rd " +
                 "left join uScheduleStatus ss on rd.ssid = ss.ssid " +
                 "left join tblWorkIns w on ss.WorkID = w.WorkID " +
                 "left join tblDept d on w.DeptID = d.DeptID " +
                 "left join tblPartSN p on ss.PartID = p.PartID " +
                 "left join tblJobInfo j on p.JobID = j.JobID " +
                 "where PartPOClosed = 0 " +
                 "and JobComplete = 0 " +
                 "and RunningDate > '02-02-2016' " +
                 "order by runningdate"
                 //@"and deptcode = ''R05'' " +
                 //") as s " +
                 //"PIVOT " +
                 //"( " +
                 //"SUM(RunTime) " +
                 //"for RunningDate in (' + @cols + ']) " +
                 //") as PVT order by DeptCode' " +
                 //"execute(@query)"
                 , cnxn);

            cnxn.Open();

            try
            {
                //dr = cmd.ExecuteReader();

                //chart1.DataBindTable(dr, "02-03-2016");
                dt = new DataTable();
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cnxn.Close();
            chart1.DataBindTable(dt, "runningdate");

            
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
