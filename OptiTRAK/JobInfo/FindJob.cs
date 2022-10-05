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
    public partial class FindJob : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        string SQL1 = "Select JobID, Customer, Project, ElementName Part, " +
                 "PartDrawingNumber, PartDrawingRev, PartDrawingRevDate, " +
                 "Jobcomplete, JobSelect, EmployeeID " +
                 "TravelerRev, TravelerRevDate, SbsqntWorkCycDays, " +
                 "PlannerID, KanbanJob, JobFolder " +
                 "from tbljobinfo where jobcomplete = 0 ";
        string SQL2 = "order by customer, project, elementname ";
        
        public FindJob()
        {
            InitializeComponent();
        }

        private void FindJob_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            try
            {
                da = new SqlDataAdapter
                (SQL1 + SQL2, cnxn);
                DataTable table = new DataTable();
                da.Fill(table);
                DGV.DataSource = table;

                DGV.Columns[0].Visible = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnxn.Close();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                (SQL1 +
                 " where (customer like '%" + tbSearchEquipment.Text + "%' " +
                 "or project like '%" + tbSearchEquipment.Text + "%' " +
                 "or elementname like '%" + tbSearchEquipment.Text + "%') " +
                 SQL2, cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            tbSearchEquipment.Text = "";
        }

        private void bItem_Click(object sender, EventArgs e)
        {

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
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.JobID = cell.EditedFormattedValue.ToString().Trim();

                AddJob j = new AddJob();
                j.ShowDialog();

                this.Close();
            }
        }
    }
}
