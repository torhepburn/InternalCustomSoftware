using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GetRouting
{
    public partial class SelectMissingRouting : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        
                        
        public SelectMissingRouting()
        {
            InitializeComponent();
        }

        private void SelectMissingRouting_Load(object sender, EventArgs e)
        {
            this.Text = "Get Routing v" + Application.ProductVersion;


            cnxn = new SqlConnection(g.db);

            da = new SqlDataAdapter(
                    "select " +
                    "Customer, " +
                    "Project, " +
                    "ElementName, " +
                    "ProdOrdNum SFO, " +
                    "p.JobID " +
                    "from tblPartSN p " +
                    "left join tblJobInfo j " +
                    "on p.JobID = j.JobID " +
                    "where " +
                    "(PartPOClosed = 0) and " +
                    "NOT EXISTS (select jobid from tblWorkIns " +
                    "where JobID = p.JobID)", cnxn);

                
            dt = new DataTable();
            da.Fill(dt);

            DGV.DataSource = dt;

            DGV.Columns[0].Width = 90;
            DGV.Columns[1].Width = 90;
            DGV.Columns[2].Width = 290;
            DGV.Columns[3].Width = 90;
            DGV.Columns[4].Visible = false;

            DGV.Show();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 | e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                DGV.BackgroundColor = Color.Yellow;

                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.customer = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.project = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.element = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                g.SFO = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[4];
                g.job = cell.EditedFormattedValue.ToString().Trim();

                cmd = new SqlCommand(
                        "insert into tblWorkIns (jobid,deptid, opnum, description, CycleDays) " +
                    //"insert into WItemp (jobid,deptid, opnum, description, CycleDays) " +
                        "select 999999, deptid, operation, t.description, 0 from " +
                        "AccessFrontEnds.dbo.MMX_PRODUCTION_PLANNING_BY_ORDER o " +
                        "left join tblDept d " +
                        "on o.Work_Center = d.deptcode " +
                        "left join accessfrontends.dbo.mmx_tasks t " +
                        "on o.task = t.TASK " +
                        "where ORDER_NO =  " + g.SFO + " " +
                        "order by operation", cnxn);

                try
                {
                    cnxn.Open();
                    cmd.ExecuteNonQuery();


                    cmd = new SqlCommand(
                        "update tblWorkIns set jobid = " + g.job + " where jobid = 999999", cnxn);
                    //"update WItemp set jobid = " + g.job.ToString() + " where jobid = 999999", cnxn);
                    cmd.ExecuteNonQuery();
                    cnxn.Close();

                    EditRouting r = new EditRouting();
                    r.ShowDialog();

                    if (g.StepFlag == true)
                    {
                        MessageBox.Show("Routing Entered with Descriptions");
                    }
                    else
                    {
                        MessageBox.Show("Routing NOT Entered with Descriptions.  " +
                            "\n\n Editing Required");
                    }


                    string z = g.text;


                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    this.Close();
                }
            }

        }

    }

    public static class g
    {
        public static string SFO;
        public static string customer;
        public static string project;
        public static string element;
        public static string drawingNo;
        public static string text;
        public static object job;
        public static bool StepFlag;
        public static string db = "server = CT-MID-SQL01; password = Read+Write!; " +
                                  "user = readwrite; database = OptiTRAK;";

    }
}
