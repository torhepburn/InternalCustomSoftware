using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WorkCenterCapacityperDate
{
    public partial class DisplayData : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable dt;
        SqlCommand cmd;
    
        public DisplayData()
        {
            InitializeComponent();
        }

        private void DisplayData_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                ("with s1 as " +
                 "( " + 
                 "select " +
                 "RunningDate, " +
                 "DeptCode WorkCenter, " +
                 "count(deptcode) multiplier, " +
                 "d.DeptDescription " +
                 "from ScheduledRunningDates rd " +
                 "left join uScheduleStatus ss on rd.ssid = ss.ssid " +
                 "left join tblPartSN p on ss.PartID = p.PartID " +
                 "left join tblJobInfo j on p.JobID = j.JobID " +
                 "left join tblWorkIns w on w.WorkID = ss.WorkID " +
                 "left join tblDept d on w.DeptID = d.DeptID " +
                 "where RunningDate = ' " + g.loadDate + "' " +
                 "and PartPOClosed = 0 " +
                 "and JobComplete = 0 " +
                 "group by RunningDate, DeptCode, D.DeptDescription " +
                 ") " +
                 "select " +
                 "RunningDate, " +
                 "WorkCenter, " +
                 "DeptDescription, " +
                 "IIF(Prorate is null, .1, prorate) * (multiplier * 100) PerCentUsed " +
                 "from s1 s left join WorkCenterCapacity c " +
                 "on s.WorkCenter = c.WORK_CENTER " +
                 "order by percentused desc", cnxn);
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
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.workcell = cell.EditedFormattedValue.ToString().Trim();
                WorkCellJobs j = new WorkCellJobs();
                j.ShowDialog();
            }
                //cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                //g.project = cell.EditedFormattedValue.ToString().Trim();

                //cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                //g.element = cell.EditedFormattedValue.ToString().Trim();

                
                //cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[4];
                //string a = cell.EditedFormattedValue.ToString().Trim();

                //cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[5];
                //string b = cell.EditedFormattedValue.ToString().Trim();

                //g.item_code = a + b;

                //cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                //g.jobID = cell.EditedFormattedValue.ToString().Trim();

                //cmd = new SqlCommand(
                //    "select jobid from tblPartSN where jobid = " + g.jobID + " and partpoclosed = 0 ", cnxn);
                //cnxn.Open();
                //object o = cmd.ExecuteScalar();
                //cnxn.Close();
                //if (o == null)
                //{
                //    MessageBox.Show(" No Shop Floor Orders are open for this job. ");
                //    return;
                //}
                
                //cmd = new SqlCommand(
                //    "Select workid from tblworkins where jobid = " + g.jobID + "", cnxn);
                //cnxn.Open();
                //o = cmd.ExecuteScalar();
                //cnxn.Close();
                //if (o == null)
                //{
                //    MessageBox.Show("  No routing exists for this job. \n\n  " +
                //        "Go to Maintain Part Routings and enter operations.");
                //    //this.Close();
                //}
                //else
                //{
                //    MaintainSchedules m = new MaintainSchedules();
                //    m.ShowDialog();
                //}

        }
    }
}
