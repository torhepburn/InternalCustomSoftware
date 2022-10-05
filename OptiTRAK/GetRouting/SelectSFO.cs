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
    public partial class SelectSFO : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        DataTable dt1;
        
        public SelectSFO()
        {
            InitializeComponent();
        }

        private void SelectSFO_Load(object sender, EventArgs e)
        {
            this.Text = "Get Routing v" + Application.ProductVersion;

            
            cnxn = new SqlConnection(g.db);

            cnxn.Open();
            da = new SqlDataAdapter(
                //"select distinct o.order_no from AccessFrontEnds.dbo.MMX_PRODUCTION_PLANNING_BY_ORDER o " +
                //"inner join AccessFrontEnds.dbo.MMX_PRODUCTION_ORDER_FILE p " +
                //"on o.ORDER_NO = p.ORDER_NO " +
                //"where (o.ORDER_NO > 360000 and o.ORDER_NO < 390000 " +
                //"and ORDER_STATUS < 7) " +
                //"and o.ORDER_NO in (select prodordnum from tblPartSN where PartPOClosed = 0) " +
                //"order by o.order_no", cnxn);

                "select distinct " +
                "j.Customer, " +
                "j.Project, " +
                "j.ElementName, " +
                "j.PartDrawingnumber + j.PartDrawingRev Item_Code " +
                "from  tblJobInfo j " +
                "inner join tblWorkIns w " +
                "on j.jobid = w.JobID " +
                "inner join tblPartSN p " +
                "on j.JobID = p.JobID " +
                "where j.JobComplete = 0 " +
                "and p.PartPOClosed = 0 " +
                "and j.KanBanJob = 0", cnxn);

            dt = new DataTable();
            da.Fill(dt);

            cnxn.Close();

            DGV.DataSource = dt;

            DGV.Columns[0].Width = 90;
            
            DGV.Show();

        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                ("select distinct o.order_no from AccessFrontEnds.dbo.MMX_PRODUCTION_PLANNING_BY_ORDER o " +
                "inner join AccessFrontEnds.dbo.MMX_PRODUCTION_ORDER_FILE p " +
                "on o.ORDER_NO = p.ORDER_NO " +
                "where o.ORDER_NO > 360000 and o.ORDER_NO < 390000 " +
                "and ORDER_STATUS < 7  and p.order_no like '%" + tbSearch.Text.Trim() + "%' " +
                "and o.ORDER_NO in (select prodordnum from tblPartSN where PartPOClosed = 0) " +
                "order by o.order_no", cnxn);
            dt = new DataTable();
            da.Fill(dt);
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
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.SFO = cell.EditedFormattedValue.ToString().Trim();

                cnxn.Open();
                SqlCommand cmd = new SqlCommand(
                    "select jobid from tblpartsn where prodordnum = " + g.SFO + " and partpoclosed = 0 ", cnxn);
                g.job = cmd.ExecuteScalar();
                cnxn.Close();

                if (g.job == null)
                {
                    MessageBox.Show("Part Not Entered in OptiTRAK");
                }
                else
                {
                    cmd = new SqlCommand(
                        "select jobid from tblWorkIns where jobid = " + g.job.ToString() + " ", cnxn);
                    //cmd = new SqlCommand(
                    //    "select jobid from WItemp where jobid = " + g.job.ToString() + " ", cnxn);
                    
                    cnxn.Open();
                    object alreadyIn = cmd.ExecuteScalar();
                    cnxn.Close();
                    if (alreadyIn == null)
                    {
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
                                "update tblWorkIns set jobid = " + g.job.ToString() + " where jobid = 999999", cnxn);
                                //"update WItemp set jobid = " + g.job.ToString() + " where jobid = 999999", cnxn);
                            cmd.ExecuteNonQuery();
                            cnxn.Close();

                            da = new SqlDataAdapter
                                ("select customer, project, elementname from tblJobInfo " +
                                "where jobID = " + g.job.ToString() + " ", cnxn);
                            dt1 = new DataTable();
                            da.Fill(dt1);

                            g.customer = dt1.Rows[0].ItemArray[0].ToString();
                            g.project = dt1.Rows[0].ItemArray[1].ToString();
                            g.element = dt1.Rows[0].ItemArray[2].ToString();

                            Ljob.Text = "Job:  " + g.customer;
                            Lproject.Text = "Project:  " + g.project;
                            Lelement.Text = "Element:  " + g.element;

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

                    }
                    else
                    {
                        MessageBox.Show("Routing already in table");
                    }
                
                }
                cnxn.Close();

            }
        }
    }   

    //public static class g
    //{
    //    public static string SFO;
    //    public static string customer;
    //    public static string project;
    //    public static string element;
    //    public static string drawingNo;
    //    public static string text;
    //    public static object job;
    //    public static bool StepFlag;
    //    public static string db = "server = midsql01; password = Read+Write!; " +
    //                              "user = readwrite; database = OptiTRAK;";

    //}
}
