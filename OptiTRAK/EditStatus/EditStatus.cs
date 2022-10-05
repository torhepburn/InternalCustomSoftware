using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EditStatus
{
    public partial class EditStatus : Form
    {
        SqlConnection cnxn;
        private string workID;
        private string partID;
        private string opNum;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        private string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = OptiTRAK;";
        private string basicselect = "select j.JobID, PartID, Customer, Project, ElementName as Element, " +
                                     "TravelerRev, PartSN as 'Part ID', ProdOrdNum as SFO from tblJobInfo j " +
                                     "inner join tblPartSN p on j.jobid = p.jobid " +
                                     "where JobComplete = 0  and p.partpoclosed = 0 ";
        
        public EditStatus()
        {
            InitializeComponent();
        }

        private void EditStatus_Load(object sender, EventArgs e)
        {
            Lholdstatus.Visible = false;
            bSave.Visible = false;
            cbHoldStatus.Visible = false;
           
            cnxn = new SqlConnection(db);

            cnxn.Open();
            da = new SqlDataAdapter(basicselect +
                "order by customer, project, elementname", cnxn);

            displaydata1();

            DGV2.Visible = false;
            tbCustomer.Visible = false;
            tbElement.Visible = false;
            tbPartID.Visible = false;
            tbProject.Visible = false;
            tbSFO.Visible = false;
            tbTravelerRev.Visible = false;
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            Lholdstatus.Visible = false;
            bSave.Visible = false;
            cbHoldStatus.Visible = false;
            DGV2.Visible = false;
            tbCustomer.Visible = false;
            tbElement.Visible = false;
            tbPartID.Visible = false;
            tbProject.Visible = false;
            tbSFO.Visible = false;
            tbTravelerRev.Visible = false;
           
            cnxn = new SqlConnection(db);
            da = new SqlDataAdapter
                (basicselect +
                "and customer like '%" + tbSearch.Text.Trim() + "%'  " +
                "order by customer, project, elementname", cnxn);
            
            displaydata1();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                DGV.Height = 100;
                DGV2.Visible = true;
                tbCustomer.Visible = true;
                tbElement.Visible = true;
                tbPartID.Visible = true;
                tbProject.Visible = true;
                tbSFO.Visible = true;
                tbTravelerRev.Visible = true;
                cbHoldStatus.Visible = true;

                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                tbCustomer.Text = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                tbProject.Text = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[4];
                tbElement.Text = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[7];
                tbTravelerRev.Text = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[6];
                tbPartID.Text = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[5];
                tbSFO.Text = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                partID = cell.EditedFormattedValue.ToString().Trim();

                da = new SqlDataAdapter
                ("select OpNum as 'Op Num', Description, OpStart, OpStop, PStatusDesc as 'Process Status', " +
                "Comment, IIF(CurrentRecord = -1, 'True', 'False') as 'Current', ss.workid from uScheduleStatus ss " +
                "inner join tblWorkIns w on ss.workid = w.workid " +
                "inner join tblProcessStatus s on ss.processstatusid = s.processstatusid " + 
                "where partid ='" + partID + "' " +
                "order by opnum", cnxn);

                DataTable dt2 = new DataTable();
                da.Fill(dt2);
                DGV2.DataSource = dt2;

                foreach (DataGridViewRow gr in DGV2.Rows)
                {
                    if ((Convert.ToBoolean(gr.Cells[6].Value) == true) | (Convert.ToString(gr.Cells[4].Value) == "Active"))
                    {
                        gr.DefaultCellStyle.BackColor = Color.Pink;

                    }

                    if (Convert.ToString(gr.Cells[4].Value) == "Complete")
                    {
                        gr.DefaultCellStyle.BackColor = Color.Gray;

                    }
                }

                DGV2.Columns[0].Width = 40;
                DGV2.Columns[1].Width = 240;
                DGV2.Columns[2].Width = 100;
                DGV2.Columns[3].Width = 100;
                DGV2.Columns[4].Width = 90;
                DGV2.Columns[5].Width = 190;
                DGV2.Columns[6].Width = 80;
                DGV2.Columns[7].Visible = false;

                DGV2.Show();

                Lholdstatus.Visible = true;
                bSave.Visible = true;

                da = new SqlDataAdapter(
                    "select processstatusid, PstatusDesc as Status " +
                    "from tblProcessStatus where processstatusid > 3", cnxn);
                DataTable dt3 = new DataTable();
                da.Fill(dt3);
                cbHoldStatus.DisplayMember = "Status";
                cbHoldStatus.ValueMember = "processstatusid";
                cbHoldStatus.DataSource = dt3;

            }
        }

        private void DGV2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex == -1 && e.ColumnIndex < 8)
            //{
            //    return;
            //}
            //else
            //{
            //    DataGridViewTextBoxCell cell =
            //        (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[5];
            //    //tbComment.Text = cell.EditedFormattedValue.ToString();

            //    cell =
            //        (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[0];
            //    opNum = cell.EditedFormattedValue.ToString().Trim();
            //    Lholdstatus.Text = "Enter Comment for Operation Number: " + opNum + " ";

            //    cell =
            //        (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[7];
            //    workID = cell.EditedFormattedValue.ToString().Trim();

            //    //tbCmpAdjDays.Focus();
            //}
        }

       
        private void displaydata1()
        {
            dt = new DataTable();
            da.Fill(dt);

            cnxn.Close();

            DGV.DataSource = dt;

            DGV.Columns[0].Visible = false;
            DGV.Columns[1].Visible = false;
            DGV.Columns[2].Width = 120;
            DGV.Columns[3].Width = 200;
            DGV.Columns[4].Width = 240;
            DGV.Columns[5].Width = 90;
            DGV.Columns[6].Width = 80;
            DGV.Columns[7].Width = 90;
            //DGV.Columns[8].Width = 90;

            DGV.Height = 450;

            DGV.Show();
            

        }

        private void bSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(
                "update tblpartsn set holdstatid = " +
                Convert.ToInt32(cbHoldStatus.SelectedValue) +
                "where partid = " + partID + "", cnxn);
            cnxn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            cnxn.Close();
        }
    }
}
