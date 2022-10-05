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
    public partial class CalendarWCJobs : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable dt;
        DataTable dt2;
        SqlCommand cmd;

        public CalendarWCJobs()
        {
            InitializeComponent();
        }

        private void CalendarWCJobs_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            da = new SqlDataAdapter(
                 "select distinct " +
                 "RunningDate, " +
                 "DeptCode, " +
                 "DeptDescription " +
                 "from ScheduledRunningDates r " +
                 "left join uScheduleStatus ss on r.SSID = ss.SSID " +
                 "left join tblPartSN p on ss.PartID = p.PartID " +
                 "left join tblWorkIns w on w.WorkID = ss.WorkID " +
                 "left join tblDept d on w.DeptID = d.DeptID " +
                 "where " +
                 "runningdate = '" + g.loadDate + "' " +
                 "and DeptCode = '" + g.workcell + "' ", cnxn);

            try
            {
                dt2 = new DataTable();
                da.Fill(dt2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            LworkCell.Text = "Work Cell: " + dt2.Rows[0][1].ToString();
            LworkCellDescription.Text = "Work Cell Description: " + dt2.Rows[0][2].ToString();
            LrunningDate.Text = "Running Date: " + dt2.Rows[0][0].ToString();


            da = new SqlDataAdapter
                ("select " +
                 "j.Customer, " +
                 "j.Project, " +
                 "j.ElementName, " +
                 "j.PartDrawingNumber + PartDrawingRev Item_Code, " +
                 "p.ProdOrdNum SFO, " +
                 "w.OpNum, " +
                 "ss.opstart, " +
                 "w.RunTime, " +
                 "r.daysneededtorun DaysLeft, " + 
                 "w.CycleDays, " +
                 "ss.DueDate," +
                 "p.PartSN " +
                 "from ScheduledRunningDates r " +
                 "left join uScheduleStatus ss on r.SSID = ss.SSID " +
                 "left join tblPartSN p on ss.PartID = p.PartID " +
                 "left join tblJobInfo j on p.JobID = j.JobID " +
                 "left join tblWorkIns w on w.WorkID = ss.WorkID " +
                 "left join tblDept d on w.DeptID = d.DeptID " +
                 "where " +
                 "runningdate = '" + g.loadDate + "' " +
                 "and DeptCode = '" + g.workcell + "' " +
                 "order by prodordnum, opnum", cnxn);
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

            DGV.Columns[2].Width = 150;
            DGV.Columns[4].Width = 50;
            DGV.Columns[5].Width = 50;
            DGV.Columns[6].Width = 60;
            DGV.Columns[7].Width = 80;

        }
    }


}
