using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WorkPlanning
{
    public partial class FirstPage : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable dt;
        SqlCommand cmd;
        private string formFunction;
        private string searchFunction;

        public FirstPage()
        {
            InitializeComponent();
        }

        private void f1_SelectJob_Load(object sender, EventArgs e)
        {
            this.Text = "MaintainSchedules v" + Application.ProductVersion;
            LformFunction.Text = "Maintain Schedules";
            loadJobs();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            searchFunction = "customer like '%" + tbSearch.Text.Trim() + "%' and ";
            tbSearch.Text = "";
            
            if (formFunction == "Maintain")
            {
                loadJobs();   
            }
            else
            {
                loadCustomers();
            }
            
            //cnxn = new SqlConnection(g.db);
            //da = new SqlDataAdapter
            //    ("select distinct j.JobID, Customer, Project, ElementName, PartDrawingNumber, " +
            //    "PartDrawingRev, TravelerRev from tblJobInfo j " +
            //    "inner join tblPartSN p on j.JobID = p.JobID " +
            //    "where " +
            //    "customer like '%" + tbSearch.Text.Trim() + "%' and " +
            //    "(JobComplete = 0  and EXISTS " +
            //    "(select jobid from tblworkins where jobid = j.jobid) ) " +
            //    "and EXISTS (select partid from uScheduleStatus where partid = p.partid) " +
            //    "and partpoclosed = 0 " +
            //    "order by customer, project, elementname", cnxn);
            //dt = new DataTable();
            //da.Fill(dt);
            //DGV.DataSource = dt;
            //DGV.Show();
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

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[5];
                string b = cell.EditedFormattedValue.ToString().Trim();

                g.item_code = g.drawingNo + b;

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.jobID = cell.EditedFormattedValue.ToString().Trim();

                
                if (formFunction == "Maintain")
                {
                    cmd = new SqlCommand(
                    "select jobid from tblPartSN where jobid = " + g.jobID + " and partpoclosed = 0 ", cnxn);
                    cnxn.Open();
                    object o = cmd.ExecuteScalar();
                    cnxn.Close();
                    if (o == null)
                    {
                        MessageBox.Show(" No Shop Floor Orders are open for this job. ");
                        return;
                    }
                    
                    cmd = new SqlCommand(
                        "Select workid from tblworkins where jobid = " + g.jobID + "", cnxn);
                    cnxn.Open();
                    o = cmd.ExecuteScalar();
                    cnxn.Close();
                    if (o == null)
                    {
                        MessageBox.Show("  No routing exists for this job. \n\n  " +
                        "Go to Maintain Part Routings and enter operations.");
                    }
                    else
                    {
                        MaintainSchedules m = new MaintainSchedules();
                        m.ShowDialog();
                    }
                }

                if (formFunction == "Create")
                {
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
                        CreatePartSchedule c1 = new CreatePartSchedule();
                        c1.Show();
                    }
                
                }

            }
        }

        private void bMaintainSchedule_Click(object sender, EventArgs e)
        {
            this.Text = "Maintain Schedules";
            LformFunction.Text = "Maintain Schedules";
            loadJobs();
        }

        private void bCreateSchedule_Click(object sender, EventArgs e)
        {
            LformFunction.Text = "Create Schedules";
            this.Text = "Create Schedules";
            loadCustomers();
        }

        private void loadJobs()
        {
            formFunction = "Maintain";
            tbSearch.Text = "";

            cnxn = new SqlConnection(g.db);

            da = new SqlDataAdapter(
                "select distinct j.JobID, Customer, Project, ElementName, PartDrawingNumber, " +
                "PartDrawingRev, TravelerRev from tblJobInfo j " +
                "inner join tblPartSN p on j.JobID = p.JobID " +
                "where " + searchFunction + 
                "(JobComplete = 0  and EXISTS " +
                "(select jobid from tblworkins where jobid = j.jobid) ) " +
                "and EXISTS (select partid from uScheduleStatus where partid = p.partid) " +
                "and partpoclosed = 0 " +
                "order by customer desc, project, elementname", cnxn);
            try
            {
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("F1 line 189 " + ex.ToString());
            }
            finally
            {
                searchFunction = "";
            }

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

        private void loadCustomers()
        {
            formFunction = "Create";
            tbSearch.Text = "";

            cnxn = new SqlConnection(g.db);

            cnxn.Open();
            da = new SqlDataAdapter(
                "select JobID, Customer, Project, ElementName, PartDrawingNumber, " +
                "PartDrawingRev, TravelerRev from tblJobInfo where " +
                searchFunction + 
                "JobComplete = 0 " +
                "order by customer desc, project, elementname", cnxn);

            dt = new DataTable();
            da.Fill(dt);

            cnxn.Close();

            searchFunction = "";

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
                                  "user = readwrite; database = Planning;";

    }
}
