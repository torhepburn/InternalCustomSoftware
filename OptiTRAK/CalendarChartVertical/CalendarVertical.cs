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

namespace CalendarChartVertical
{
    public partial class CalendarVertical : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable dt;
        private string db = "server = midsql01; password = Read+Write!; " +
                            "user = readwrite; database = OptiTRAK;";
        private string rDate;
        private string WC;

        public CalendarVertical()
        {
            InitializeComponent();
        }

        private void CalendarVertical_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            da = new SqlDataAdapter
                ("with s1 as " +
                 "( " +
                 "select " +
                 "RunningDate, " +
                 "COUNT(DeptCode) multiplier, " +
                 "DeptCode, " +
                 "DeptDescription " +
                 "from ScheduledRunningDates rd " +
                 "left join uScheduleStatus ss on rd.ssid = ss.ssid " +
                 "left join tblWorkIns w on ss.WorkID = w.WorkID " +
                 "left join tblDept d on w.DeptID = d.DeptID " +
                 "left join tblPartSN p on ss.PartID = p.PartID " +
                 "left join tblJobInfo j on p.JobID = j.JobID " +
                 "where PartPOClosed = 0 " +
                 "and JobComplete = 0 " +
                 "group by RunningDate, deptcode, DeptDescription " +
                 "), " +
                 "R07 as " +
                 "( " +
                 "select " +
                 "runningdate, " +
                 "c.work_center, " +
                 "DeptDescription, " +
                 "IIF(Prorate is null, .1, prorate) * multiplier * 100 pc " +
                 "from s1 s left join WorkCenterCapacity c " +
                 "on s.DeptCode = c.WORK_CENTER " +
                 "where RunningDate >= DateAdd(day, -1, GETDATE()) " +
                 "and work_center = 'r07' " +
                 "), " +
                 "R08 as " +
                 "( " +
                 "select " +
                 "runningdate, " +
                 "c.work_center, " +
                 "DeptDescription, " +
                 "IIF(Prorate is null, .1, prorate) * multiplier * 100 pc " +
                 "from s1 s left join WorkCenterCapacity c " +
                 "on s.DeptCode = c.WORK_CENTER " +
                 "where RunningDate >= DateAdd(day, -1, GETDATE()) " +
                 "and work_center = 'r08' " +
                 "), " +
                 "R22 as " +
                 "( " +
                 "select " +
                 "runningdate, " +
                 "c.work_center, " +
                 "DeptDescription, " +
                 "IIF(Prorate is null, .1, prorate) * multiplier * 100 pc " +
                 "from s1 s left join WorkCenterCapacity c " +
                 "on s.DeptCode = c.WORK_CENTER " +
                 "where RunningDate >= DateAdd(day, -1, GETDATE()) " +
                 "and work_center = 'r22' " +
                 "), " +
                 "R42 as " +
                 "( " +
                 "select " +
                 "runningdate, " +
                 "c.work_center, " +
                 "DeptDescription, " +
                 "IIF(Prorate is null, .1, prorate) * multiplier * 100 pc " +
                 "from s1 s left join WorkCenterCapacity c " +
                 "on s.DeptCode = c.WORK_CENTER " +
                 "where RunningDate >= DateAdd(day, -1, GETDATE()) " +
                 "and work_center = 'r42' " +
                 ") " +
                 "select " +
                 "FORMAT(r07.RunningDate, 'D', 'en-us') RunningDate, " +
                 //"R07.work_center, " +
                 "ROUND(R07.pc, 1) R07pc, " +
                 //"R08.work_center, " +
                 "ROUND(R08.pc, 1) R08pc, " +
                 //"R22.work_center, " +
                 "ROUND(R22.pc, 1) R22pc, " +
                 //"R42.work_center, " +
                 "ROUND(R42.pc, 1) R42pc " +
                 "from r07 " +
                 "left join r08 on r07.RunningDate = r08.RunningDate " +
                 "left join r22 on r07.RunningDate = r22.RunningDate " +
                 "left join r42 on r07.RunningDate = r42.RunningDate " +
                 "order by r07.RunningDate ", cnxn);
            try
            {
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DGV.DataSource = dt;
            DGV.Show();
            //for (int i = 0; i < 5; i++)
            //{
            //    DGV.Columns[i].Width = 30;
            //}
            DGV.Columns[0].Width=160;
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 4)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                
                g.loadDate = Convert.ToDateTime(cell.EditedFormattedValue.ToString().Trim());

                if (e.ColumnIndex == 1) { g.workcell = "R07"; }
                if (e.ColumnIndex == 2) { g.workcell = "R08"; }
                if (e.ColumnIndex == 3) { g.workcell = "R22"; }
                if (e.ColumnIndex == 4) { g.workcell = "R42"; }

                CalendarWCJobs j = new CalendarWCJobs();
                j.Show();
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
