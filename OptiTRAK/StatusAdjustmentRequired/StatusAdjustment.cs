using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace StatusAdjustmentRequired
{
    public partial class StatusAdjustmentRequired : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        
        public StatusAdjustmentRequired()
        {
            InitializeComponent();
        }

        private void StatusAdjustmentRequired_Load(object sender, EventArgs e)
        {
            this.Text = "StatusAdjustmentRequired v" + Application.ProductVersion;

            GetData();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 | e.ColumnIndex < 1)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[8];
                g.customer = cell.EditedFormattedValue.ToString().Trim();
                
                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[9];
                g.project = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[10];
                g.element = cell.EditedFormattedValue.ToString().Trim();
                
                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[12];
                g.item_code = cell.EditedFormattedValue.ToString().Trim();
                
                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[13];
                g.jobID = cell.EditedFormattedValue.ToString().Trim();

                MaintainSchedulesLocal ms = new MaintainSchedulesLocal();
                ms.ShowDialog();
            }
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            cnxn = new SqlConnection(g.db);

            da = new SqlDataAdapter
                ("with s1 as (" +
                 "select orderno, " +
                 "MAX(step) step, " +
                 "MAX(starttime) MostRecentStart " +
                 "from MIDDB01.Dashboard.dbo.view_timecard_production " +
                 "where orderno in (" +
                 "select prodordnum " +
                 "from uScheduleStatus ss " +
                 "left join tblPartSN p on ss.PartID = p.PartID " +
                 "left join tblJobInfo j on p.JobID = j.JobID " +
                 "left join tblWorkIns w on ss.WorkID = w.WorkID " +
                 "where PartPOClosed = 0 and JobComplete = 0 " +
                 "and holdstatid = 21 " +
                 "and CurrentRecord = -1  and (ProcessStatusID = 1 " +  //active step
                 "or ProcessStatusID = 3) " +  //waiting step
                 "and " +
                 "DueDate < DATEADD(d, -1, GETDATE())) " +
                 "group by orderno) " +
                 "select " +
                 "plannerinitials PLNR, " +
                 "ProdOrdNum SFO, " +
                 "OpNum Step, " +
                 "DueDate, " +
                 "CAST(delay as varchar) + '::' + CAST(extend as varchar) CmpAdjDays, " +
                 "PlnDueDate, " +
                 "OpStart, " +
                 "CAST(MostRecentStart as date) MostRecently, " +
                 "Customer, " +
                 "Project, " +      //9
                 "ElementName, " +
                 "PartSN, " +   //11
                 "partdrawingnumber + partdrawingrev item_code, " +
                 "j.jobid " + //13
                 "from uScheduleStatus ss " +
                 "left join tblPartSN p on ss.PartID = p.PartID " +
                 "left join tblJobInfo j on p.JobID = j.JobID " +
                 "left join tblWorkIns w on ss.WorkID = w.WorkID " +
                 "left join s1 on p.ProdOrdNum = s1.orderno and w.OpNum = s1.step " +
                 "left join tblPlanner l on j.PlannerID = l.PlannerID " +
                 "where PartPOClosed = 0 and JobComplete = 0 " +
                 "and holdstatid = 21 " +
                 "and CurrentRecord = -1  and (ProcessStatusID = 1 " +  //active step
                 "or ProcessStatusID = 3) " +  //waiting step
                 "and " +
                 "DueDate < DATEADD(d, -1, GETDATE()) " +
                 "order by duedate", cnxn);

            DataTable table = new DataTable();
            da.Fill(table);

            DGV.DataSource = table;
            DGV.Show();

            DGV.Columns[0].Width = 40;
            DGV.Columns[1].Width = 60;
            DGV.Columns[2].Width = 40;
            DGV.Columns[3].Width = 70;
            DGV.Columns[4].Width = 70;
            DGV.Columns[5].Width = 70;
            DGV.Columns[6].Width = 70;
            DGV.Columns[7].Width = 70;
            DGV.Columns[8].Width = 70;
            DGV.Columns[9].Width = 150;
            DGV.Columns[10].Width = 150;
            DGV.Columns[11].Width = 60;
            DGV.Columns[12].Width = 60;
            DGV.Columns[13].Visible = false;

            label1.Text = "Count = " + DGV.Rows.Count.ToString();
        }

        private void bProbableAdjustments_Click(object sender, EventArgs e)
        {
            PotentialAdjustments p = new PotentialAdjustments();
            p.ShowDialog();
        }
    }

    public static class g
    {
        public static string drawingNo;
        public static string jobID;
        public static string customer;
        public static string project;
        public static string element;
        public static string item_code;
        public static string opnum;
        public static string partsn;
        public static string holdStatusID;
        public static string partid;
        public static string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = OptiTRAK;";

    }
}
