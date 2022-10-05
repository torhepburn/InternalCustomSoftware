using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AppendRoutingSteps
{
    public partial class EvaluateRouting : Form
    {
        SqlConnection cnxn;
        //SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public EvaluateRouting()
        {
            InitializeComponent();
        }

        private void EvaluateRouting_Load(object sender, EventArgs e)
        {
            try
            {
                cnxn = new SqlConnection(g.db);
                cnxn.Open();
            da = new SqlDataAdapter(
                
                "select distinct " +
                "j.JobID, " +
                "j.Customer, " +
                "j.Project, " +
                "j.ElementName, " +
                "j.PartDrawingnumber + j.PartDrawingRev Item_Code, " +
                "p.prodordnum SFO " +
                "from tblJobInfo j " +
                "inner join tblWorkIns w " +
                "on j.jobid = w.JobID " +
                "inner join tblPartSN p " +
                "on j.JobID = p.JobID " +
                "where j.JobComplete = 0 " +
                "and p.PartPOClosed = 0 " +
                "and j.KanBanJob = 0 " +
                "order by customer, project, elementname, prodordnum",cnxn);

                dt = new DataTable();
                da.Fill(dt);

                cnxn.Close();

                DGV.DataSource = dt;

                DGV.Columns[0].Visible = false;
                DGV.Columns[3].Width = 200;
                DGV.Columns[5].Width = 60;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                g.job = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.customer = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.project = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                g.element = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[5];
                g.SFO = cell.EditedFormattedValue.ToString().Trim();

              
                AppendRouting a = new AppendRouting();
                a.ShowDialog();

                            //if (g.StepFlag == true)
                            //{
                            //    MessageBox.Show("Routing Entered with Descriptions");
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Routing NOT Entered with Descriptions.  " +
                            //        "\n\n Editing Required");
                            //}
                            

                            //string z = g.text;


            //            }
            //            catch (SqlException ex)
            //            {
            //                MessageBox.Show(ex.ToString());
            //            }

            //        }
            //        else
            //        {
            //            MessageBox.Show("Routing already in table");
            //        }
                
            //    }
            //    cnxn.Close();

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
        public static string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = OptiTRAK;";

    }
}
