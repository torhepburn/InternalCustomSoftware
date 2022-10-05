using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CreatePartSchedule
{
    public partial class F1_Select_Customer : Form
    {
        SqlConnection cnxn;
        DataTable dt;
        SqlDataAdapter da;
        
        public F1_Select_Customer()
        {
            InitializeComponent();
        }

        private void F1_Select_Customer_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            cnxn.Open();
            da = new SqlDataAdapter(
                "select JobID, Customer, Project, ElementName, PartDrawingNumber, " +
                "PartDrawingRev, TravelerRev from tblJobInfo where " +
                "JobComplete = 0 " +
                "order by customer, project, elementname", cnxn);

            dt = new DataTable();
            da.Fill(dt);

            cnxn.Close();

            DGV.DataSource = dt;

            DGV.Columns[0].Visible = false;
            DGV.Columns[1].Width = 90;
            DGV.Columns[2].Width = 120;
            DGV.Columns[3].Width = 250;
            DGV.Columns[4].Width = 150;
            DGV.Columns[5].Width = 120;
            DGV.Columns[6].Width = 90;
            
            DGV.Show();

        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                ("select JobID, Customer, Project, ElementName, PartDrawingNumber, " +
                "PartDrawingRev, TravelerRev from tblJobInfo where " +
                "customer like '%" + tbSearch.Text.Trim() + "%' and " +
                "JobComplete = 0 " +
                "order by customer, project, elementname", cnxn);
            dt = new DataTable();
            da.Fill(dt);
            DGV.DataSource = dt;
            DGV.Show();
        }

 
        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 | e.ColumnIndex < 1)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.customer = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.project = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                g.element = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[4];
                g.drawingNo = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.jobID = cell.EditedFormattedValue.ToString().Trim();

                SqlCommand cmd = new SqlCommand(
                    "Select workid from tblworkins where jobid = " + g.jobID + "", cnxn);
                cnxn.Open();
                object o = cmd.ExecuteScalar();
                cnxn.Close();
                if ( o == null)
                {
                    MessageBox.Show("  No routing exists for this job. \n\n  " +
                        "Go to Maintain Part Routings and enter operations.");
                    this.Close();
                }
                else
                {
                    CreatePartSchedule c1 = new CreatePartSchedule();
                    c1.Show();
                }
                
            }
        }
    }

    public static class g
    {
        public static string jobID;
        public static string customer;
        public static string project;
        public static string element;
        public static string drawingNo;
        public static string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = OptiTRAK;";

    }
}
