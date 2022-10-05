using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FixStepsInMknotOT
{
    public partial class InMKnotOT : Form
    {
        SqlConnection cnxn;
        DataTable dt;
        SqlDataAdapter da;
        public InMKnotOT()
        {
            InitializeComponent();
        }

        private void InMKnotOT_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            cnxn.Open();
            da = new SqlDataAdapter(
                "select distinct " +
                "operation Step, " +
                "Customer, " +
                "Project, " +
                "ElementName, " +
                "ITEM_CODE [Item Code], " +
                "j.JobID " +
                "from StepsinMKnotinOT s " +
                "left join tblJobInfo j on s.JobID = j.JobID " +
                "order by Customer, Project, elementName, operation", cnxn);
            
            dt = new DataTable();
            da.Fill(dt);

            cnxn.Close();

            DGV.DataSource = dt;

            DGV.Columns[0].Width = 40;
            DGV.Columns[1].Width = 90;
            DGV.Columns[2].Width = 120;
            DGV.Columns[3].Width = 250;
            DGV.Columns[4].Width = 120;
            DGV.Columns[5].Visible = false;
            
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

                //cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[6];
                //g.travelerRev = cell.EditedFormattedValue.ToString().Trim();

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
                        //StatusData d = new StatusData();
                        //d.ShowDialog();
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
