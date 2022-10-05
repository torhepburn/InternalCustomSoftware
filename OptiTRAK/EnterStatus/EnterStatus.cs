using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EnterStatus
{
    public partial class EnterStatus : Form
    {
        SqlConnection cnxn;
        DataTable dt;
        SqlDataAdapter da;
                
        public EnterStatus()
        {
            InitializeComponent();
        }

        private void EnterStatus_Load(object sender, EventArgs e)
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
                g.customer = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.project = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                g.element = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[6];
                g.travelerRev = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.jobID = cell.EditedFormattedValue.ToString().Trim();

                SqlCommand cmd = new SqlCommand(
                    "Select workid from tblworkins where jobid = " + g.jobID + "", cnxn);
                cnxn.Open();
                object o = cmd.ExecuteScalar();
                cnxn.Close();
                if (o == null)
                {
                    MessageBox.Show("  No routing exists for this job. \n\n  " +
                        "Go to Maintain Part Routings and enter operations.");
                    this.Close();
                }
                else
                {
                    cmd = new SqlCommand(
                        "Select workid from uschedulestatus where workid = " + o.ToString() + "", cnxn);
                    cnxn.Open();

                    object p = cmd.ExecuteScalar();
                    cnxn.Close();

                    if (p == null)
                    {
                        StatusData d = new StatusData();
                        d.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Part already released.");
                        this.Close();
                        return;
                    }
                    
                }
            }
             
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                ("select JobID, Customer, Project, ElementName, PartDrawingNumber, " +
                "PartDrawingRev, TravelerRev from tblJobInfo where " +
                "customer like '%" + tbSearch.Text.Trim() + "%' and " +
                "JobComplete = 'False' " +
                "order by customer, project, elementname", cnxn);
            dt = new DataTable();
            da.Fill(dt);
            DGV.DataSource = dt;
            DGV.Show();
        }
    }

    public static class g
    {
        public static string jobID;
        public static string partID;
        public static string customer;
        public static string project;
        public static string element;
        public static string travelerRev;
        public static string PStatus;
        public static string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = OptiTRAK;";

    }
}
