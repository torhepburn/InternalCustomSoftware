using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CapacityCalendar
{
    public partial class WorkCellJobs : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable dt;
        DataTable dt2;
        DateTime endofperiod;
        private string selectBase;
        
        public WorkCellJobs()
        {
            InitializeComponent();
        }

        private void WorkCellJobs_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            
            if (g.granularity == "DAYS")
            {
                selectBase = "runningdate = '" + g.loadDate + "' ";
            }
            else if (g.granularity == "WEEKS")
            {
                //need to calculate start and stop of week based on loaddate.
                g.loadDate = g.loadDate.AddDays(1);
                endofperiod = g.loadDate.AddDays(6);

                selectBase = "runningdate >= '" + g.loadDate + "' and " +
                             "runningdate <= '" + endofperiod + "' ";
            }
            else if (g.granularity == "MONTHS")
            {
                //need to calculate start and stop of month based on loaddate.
                
                g.loadDate = new DateTime
                    (g.loadDate.Year, g.loadDate.Month, 1);
                
                if (g.loadDate.Month == 12)
                {
                    endofperiod = new DateTime(g.loadDate.Year, g.loadDate.Month, 31);
                }
                else
                {
                    endofperiod = g.loadDate.AddMonths(1).AddDays(-1);
                }

                selectBase = "runningdate >= '" + g.loadDate + "' and " +
                             "runningdate <= '" + endofperiod + "' ";
            }
            else if (g.granularity == "QUARTERS")
            {
                endofperiod = g.loadDate.AddMonths(3).AddDays(-1);

                selectBase = "runningdate >= '" + g.loadDate + "' and " +
                             "runningdate <= '" + endofperiod + "' ";
            }

            da = new SqlDataAdapter(
             "select distinct " +
             "RunningDate, " +
             "r.DeptCode, " +
             "DeptDescription " +
             "from ScheduledRunningDates r " +
             "left join tblDept d on r.DeptCode = d.DeptCode " +
             "where " +
             selectBase +
             "and r.DeptCode = '" + g.workcell + "' ", cnxn);

            
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

            GridData();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 | e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.customer = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.project = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.element = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                g.item_code = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[13];
                g.jobID = cell.EditedFormattedValue.ToString().Trim();

                MaintainSchedulesLocalCC ms = new MaintainSchedulesLocalCC();
                ms.ShowDialog();
            }
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            bRefresh.BackColor = Color.Gray;
            bRefresh.Text = "Updating Data";
            this.Enabled = false;

            cnxn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "spCapacity";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 300;
            cmd.Connection = cnxn;
            
            cmd.ExecuteNonQuery();

            cnxn.Close();

            GridData();

            return;
        }

        private void GridData()
        {
            da = new SqlDataAdapter
                ("select " +
                 "j.Customer, " +
                 "j.Project, " +
                 "j.ElementName, " +
                 "j.PartDrawingNumber + PartDrawingRev Item_Code, " +
                 "p.ProdOrdNum SFO, " +
                 "w.OpNum, " +
                 "ss.opstart, " +
                 "r.RunTime, " +
                 "r.runningDate, " +
                 "r.DaysNeededToRun [Days to Run], " +
                 "r.CycleDays, " +
                 "ss.DueDate," +
                 "p.PartSN, " +
                 "j.JobID " +
                 "from ScheduledRunningDates r " +
                 "left join uScheduleStatus ss on r.SSID = ss.SSID " +
                 "left join tblPartSN p on ss.PartID = p.PartID " +
                 "left join tblJobInfo j on p.JobID = j.JobID " +
                 "left join tblWorkIns w on w.WorkID = ss.WorkID " +
                 "left join tblDept d on w.DeptID = d.DeptID " +
                 "where " +
                  selectBase +
                 "and r.DeptCode = '" + g.workcell + "' " +
                 "and jobcomplete = 0 " +
                 "and kanban = 0 " +
                 "union all " +
                 "select " +
                 "j.Customer, " +
                 "j.Project, " +
                 "j.ElementName, " +
                 "j.PartDrawingNumber + PartDrawingRev Item_Code, " +
                 "r.SFO, " +
                 "r.OpNum, " +
                 "DATEADD(dd, -(r.CycleDays - r.DaysNeededToRun), r.runningdate) opstart, " +
                 "r.RunTime, " +
                 "r.runningDate, " +
                 "r.DaysNeededToRun [Days to Run], " +
                 "r.CycleDays, " +
                 "DATEADD(dd, DaysNeededToRun, runningdate) DueDate, " +
                 "CAST(0 as varchar(10)), " +
                 "j.JobID " +
                 "from ScheduledRunningDates r " +
                 "left join AccessFrontEnds.dbo.MMX_PRODUCTION_ORDER_FILE f on r.SFO = f.ORDER_NO " +
                 "left join tblJobInfo j on f.ITEM_CODE = j.PartDrawingNumber + j.PartDrawingRev " +
                 "where " +
                  selectBase +
                 "and r.DeptCode = '" + g.workcell + "' " +
                 "and jobcomplete = 0 " +
                 "and kanban = 1 " +
                 "order by sfo, opnum ", cnxn);
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

            if (bRefresh.Enabled == false)
            {
                bRefresh.BackColor = Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(175)))), ((int)(((byte)(150)))));
                this.Enabled = true;
                bRefresh.Text = "REFRESH DATA";
            }

            
        }
    }
}
