using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JobInfo
{
    public partial class AddJob : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        private string SQL1;
        DataTable tbl1;
        DataTable tbl2;
        public AddJob()
        {
            InitializeComponent();
        }

        private void AddJob_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            string select = " select EmployeeID, FirstName + ' ' + LastName Name from tblEmployee " +
                     " where notActive = 0 order by LastName";

            da = new SqlDataAdapter(select, cnxn);
            tbl1 = new DataTable();
            tbl1.Rows.Add();
            tbl1.AcceptChanges();
            da.Fill(tbl1);

            cbddProjectManager.DataSource = tbl1;
            cbddProjectManager.DisplayMember = "Name";

            select = "select PlannerID, PlannerFirstName + ' ' + PlannerLastName Name from tblPlanner " +
                " where Active = 1 ";

            da = new SqlDataAdapter(select, cnxn);
            tbl2 = new DataTable();
            tbl2.Rows.Add();
            tbl2.AcceptChanges();
            da.Fill(tbl2);

            cbddPlanner.DataSource = tbl2;
            cbddPlanner.DisplayMember = "Name";

            if (g.task == "EDIT")
            {
                this.BackColor = Color.FromArgb(100, 150, 250);
                this.Text = "Enter data to update job info.";

                SQL1 =
                    " Select " +
                    " Customer " +
                    ",Project " +
                    ",ElementName " +
                    ",JobFolder " +
                    ",PartDrawingNumber " +
                    ",PartDrawingRev " +
                    ",PartDrawingRevDate " +
                    ",TravelerRev " +
                    ",TravelerRevDate " +
                    ",SbsqntWorkCycDays " +
                    ",JobComplete " +
                    ",KanbanJob " +
                    " from tblJobInfo where JobID = " + g.JobID;

                try
                {
                    da = new SqlDataAdapter
                    (" Select " +
                        " Customer " +
                        ",Project " +
                        ",ElementName " +
                        ",JobFolder " +
                        ",PartDrawingNumber " +
                        ",PartDrawingRev " +
                        ",PartDrawingRevDate " +
                        ",TravelerRev " +
                        ",TravelerRevDate " +
                        ",SbsqntWorkCycDays " +
                        ",JobComplete " +
                        ",KanbanJob " +
                        ",FirstName + ' ' + LastName projectManager " +
                        ", PlannerFirstName + ' ' + PlannerLastName Planner " +
                        " from tblJobInfo j " +
                        " left join tblemployee e on j.EmployeeID = e.EmployeeID " +
                        " left join tblPlanner p on j.PlannerID = p.PlannerID" +
                        " where JobID = " + g.JobID, cnxn);

                    DataTable table = new DataTable();
                    da.Fill(table);

                    tbCustomer.Text = table.Rows[0][0].ToString();
                    tbProject.Text = table.Rows[0][1].ToString();
                    tbElementPartName.Text = table.Rows[0][2].ToString();
                    tbJobFolder.Text = table.Rows[0][3].ToString();
                    tbPartDrawingNumber.Text = table.Rows[0][4].ToString();
                    tbPartDrawingRev.Text = table.Rows[0][5].ToString();
                    dtpPartDrawingRevDate.Text = table.Rows[0][6].ToString();
                    tbTravellerRev.Text = table.Rows[0][7].ToString();
                    dtpTravellerRevDate.Text = table.Rows[0][8].ToString();
                    tbSubsequentWorkCycleDays.Text = table.Rows[0][9].ToString();
                    if (table.Rows[0][10].ToString() == "-1")
                    {
                        cbJobComplete.Checked = true;
                    }
                    else
                    {
                        cbJobComplete.Checked = false;
                    }
                    if (table.Rows[0][11].ToString() == "-1")
                    {
                        cbKanbanJob.Checked = true;
                    }
                    else
                    {
                        cbKanbanJob.Checked = false;
                    }

                    cbddProjectManager.Text = table.Rows[0][12].ToString();
                    cbddPlanner.Text = table.Rows[0][13].ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                finally
                {
                    cnxn.Close();
                }
            }
            else     //task == "ADD"
            {
                this.BackColor = Color.FromArgb(100, 150, 100);
                this.Text = "Enter data to add new job.";

            }

            
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            string jobcomplete;
            string kanbanjob;

            SqlParameter pCustomer = new SqlParameter("@pCustomer", SqlDbType.VarChar);
            if (tbCustomer.Text.Length > 0)
            {
                pCustomer.Value = tbCustomer.Text.Trim();
            }
            else
            {
                pCustomer.Value = DBNull.Value;
            }

            SqlParameter pProject = new SqlParameter("@pProject", SqlDbType.VarChar);
            if (tbProject.Text.Length > 0)
            {
                pProject.Value = tbProject.Text.Trim();
            }
            else
            {
                pProject.Value = DBNull.Value;
            }

            SqlParameter pElementPartName = new SqlParameter("@pElementPartName", SqlDbType.VarChar);
            if (tbElementPartName.Text.Length > 0)
            {
                pElementPartName.Value = tbElementPartName.Text.Trim();
            }
            else
            {
                pElementPartName.Value = DBNull.Value;
            }

            SqlParameter pJobFolder = new SqlParameter("@pJobFolder", SqlDbType.VarChar);
            if (tbJobFolder.Text.Length > 0)
            {
                pJobFolder.Value = tbJobFolder.Text.Trim();
            }
            else
            {
                pJobFolder.Value = DBNull.Value;
            }

            SqlParameter pProjectManager = new SqlParameter("@pProjectManager", SqlDbType.Int);
            if (cbddProjectManager.Text.Length > 0)
            {
                int n = cbddProjectManager.SelectedIndex;
                pProjectManager.Value = tbl1.Rows[n][0];
            }
            else
            {
                pProjectManager.Value = DBNull.Value;
            }

            SqlParameter pPlanner = new SqlParameter("@pPlanner", SqlDbType.Int);
            if (cbddPlanner.Text.Length > 0)
            {
                int n = cbddPlanner.SelectedIndex;
                pPlanner.Value = tbl2.Rows[n][0];
            }
            else
            {
                pPlanner.Value = DBNull.Value;
            }

            SqlParameter pPartDrawingNumber = new SqlParameter("@pPartDrawingNumber", SqlDbType.VarChar);
            if (tbPartDrawingNumber.Text.Length > 0)
            {
                pPartDrawingNumber.Value = tbPartDrawingNumber.Text.Trim();
            }
            else
            {
                pPartDrawingNumber.Value = DBNull.Value;
            }

            SqlParameter pPartDrawingRev = new SqlParameter("@pPartDrawingRev", SqlDbType.VarChar);
            if (tbPartDrawingRev.Text.Length > 0)
            {
                pPartDrawingRev.Value = tbPartDrawingRev.Text.Trim();
            }
            else
            {
                pPartDrawingRev.Value = DBNull.Value;
            }

            SqlParameter pPartDrawingRevDate = new SqlParameter("@pPartDrawingRevDate", SqlDbType.Date);
            if (dtpPartDrawingRevDate.Text.Length > 0)
            {
                pPartDrawingRevDate.Value = dtpPartDrawingRevDate.Text.Trim();
            }
            else
            {
                pPartDrawingRevDate.Value = DBNull.Value;
            }

            SqlParameter pTravellerRev = new SqlParameter("@pTravellerRev", SqlDbType.VarChar);
            if (tbTravellerRev.Text.Length > 0)
            {
                pTravellerRev.Value = tbTravellerRev.Text.Trim();
            }
            else
            {
                pTravellerRev.Value = DBNull.Value;
            }

            SqlParameter pTravellerRevDate = new SqlParameter("@pTravellerRevDate", SqlDbType.Date);
            if (dtpTravellerRevDate.Text.Length > 0)
            {
                pTravellerRevDate.Value = dtpTravellerRevDate.Text.Trim();
            }
            else
            {
                pTravellerRevDate.Value = DBNull.Value;
            }

            SqlParameter pSubsequentWorkCycleDays = new SqlParameter("@pSubsequentWorkCycleDays", SqlDbType.VarChar);
            if (tbSubsequentWorkCycleDays.Text.Length > 0)
            {
                pSubsequentWorkCycleDays.Value = tbSubsequentWorkCycleDays.Text.Trim();
            }
            else
            {
                pSubsequentWorkCycleDays.Value = DBNull.Value;
            }

            if (cbJobComplete.Checked)
            {
                jobcomplete = "-1";
            }
            else
            {
                jobcomplete = "0";
            }

            if (cbKanbanJob.Checked)
            {
                kanbanjob = "-1";
            }
            else
            {
                kanbanjob = "0";
            }

            if (g.task == "ADD")
            {
                SQL1 = "INSERT INTO tblJobInfo (" +
                    "  Customer " +
                    " ,Project " +
                    " ,ElementName " +
                    " ,PartDrawingNumber " +
                    " ,PartDrawingRev " +
                    " ,PartDrawingRevDate " +
                    " ,JobComplete " +
                    " ,JobSelect " +
                    " ,EmployeeID " +
                    " ,TravelerRev " +
                    " ,TravelerRevDate " +
                    " ,SbsqntWorkCycDays " +
                    " ,PlannerID " +
                    " ,KanBanJob " +
                    " ,JobFolder " +
                    ") VALUES (" +
                    pCustomer + "," +
                    pProject + "," +
                    pElementPartName + "," +
                    pPartDrawingNumber + "," +
                    pPartDrawingRev + "," +
                    pPartDrawingRevDate + ",'" +
                    jobcomplete + "'," +
                    "0 ," +
                    pProjectManager + "," +
                    pTravellerRev + "," +
                    pTravellerRevDate + "," +
                    pSubsequentWorkCycleDays + "," +
                    pPlanner + "," +
                    kanbanjob + "," +
                    pJobFolder + ")";
            }
            else
            {
                SQL1 = "UPDATE tblJobInfo " +
                    " SET " +
                    "  Customer = " + pCustomer +
                    " ,Project  = " + pProject +
                    " ,ElementName = " + pElementPartName +
                    " ,PartDrawingNumber = " + pPartDrawingNumber +
                    " ,PartDrawingRev = " + pPartDrawingRev +
                    " ,PartDrawingRevDate = " + pPartDrawingRevDate +
                    " ,JobComplete = " + jobcomplete +
                    " ,JobSelect = 0 " +
                    " ,EmployeeID = " + pProjectManager +
                    " ,TravelerRev = " + pTravellerRev +
                    " ,TravelerRevDate = " + pTravellerRevDate +
                    " ,SbsqntWorkCycDays = " + pSubsequentWorkCycleDays +
                    " ,PlannerID = " + pPlanner +
                    " ,KanBanJob = " + kanbanjob +
                    " ,JobFolder = " + pJobFolder +
                    " WHERE JobID = " + g.JobID;
            }

            SqlCommand cmd = new SqlCommand(SQL1, cnxn);
            cnxn.Open();

            cmd.Parameters.Add(pCustomer);
            cmd.Parameters.Add(pProject);
            cmd.Parameters.Add(pElementPartName);
            cmd.Parameters.Add(pPartDrawingNumber);
            cmd.Parameters.Add(pPartDrawingRev);
            cmd.Parameters.Add(pPartDrawingRevDate);
            cmd.Parameters.Add(pProjectManager);
            cmd.Parameters.Add(pPlanner);
            cmd.Parameters.Add(pTravellerRev);
            cmd.Parameters.Add(pTravellerRevDate);
            cmd.Parameters.Add(pSubsequentWorkCycleDays);
            cmd.Parameters.Add(pJobFolder);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
                cmd.Parameters.Clear();
            }
            this.Close();
        }
    }
}
