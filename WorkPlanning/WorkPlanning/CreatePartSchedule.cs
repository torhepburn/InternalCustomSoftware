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
    public partial class CreatePartSchedule : Form
    {
        SqlConnection cnxn;
        private string SOID;
        private string partID;
        private string opNum;
        SqlCommand cmd;
        private int rowSelected;

        public CreatePartSchedule()
        {
            InitializeComponent();
        }

        private void CreatePartSchedule_Load(object sender, EventArgs e)
        {

            LcustomerText.Text = g.customer;
            LprojectText.Text = g.project;
            LelementText.Text = g.element;
            LdrawingNoText.Text = g.drawingNo;
            Lpdd.Text = "";
            Lcrd.Text = "";
            Lopd.Text = "";
            Lod.Text = "";
            Ljswcd.Text = "";
            //LopNum.Text = "";


            // load DGV2 with data
            freshload();
        }

        private void freshload()
        {

            cnxn = new SqlConnection(g.db);

            cnxn.Open();

            SqlDataAdapter da = new SqlDataAdapter(
                    "select PartID, " +
                    "partsn 'Part ID', " +
                    "partreleasedate, " +
                    //"PLDlvry, " +
                    //"Curr_req_dt, " +
                    //"orig_prom_dt, " +
                    //"order_date, " +
                    "adjsbsqntWorkDays, " +
                    "prodordnum SFO, " +
                    "sbsqntworkcycDays " +
                    //"p.soid " +
                    "from tblPartSN p " +
                    //"left join tblSalesOrder s on p.soid = s.soid " +
                    "inner join tblJobInfo j " +
                    "on p.jobid = j.jobid " +
                    "where p.jobid = " + g.jobID + " and " +
                    "p.partpoclosed = 0 " +
                    "and j.jobcomplete = 0 order by partsn ", cnxn);
            cnxn.Close();

            DataTable dt2 = new DataTable();
            da.Fill(dt2);

            DGV2.DataSource = dt2;
            DGV2.Columns[0].Visible = false;
            DGV2.Columns[2].Visible = false;
            DGV2.Columns[4].Visible = false;
            DGV2.Columns[5].Visible = false;
            DGV2.Columns[6].Visible = false;
            DGV2.Columns[7].Visible = false;
            DGV2.Columns[9].Visible = false;
            DGV2.Columns[10].Visible = false;

            DGV2.Columns[1].Width = 50;
            DGV2.Columns[3].Width = 80;
            DGV2.Columns[8].Width = 50;

            DGV2.Width = 220;
            DGV2.Height = 100;
            DGV2.Show();

        }

        private void tbPartSubsequent_TextChanged(object sender, EventArgs e)
        {
            if (tbPartSubsequent.Text.Length > 0 & tbPartSubsequent.Text != "-")
            {
                double num;
                bool isNum = double.TryParse(tbPartSubsequent.Text, out num);
                if (isNum)
                {
                    CycleDayBlock();
                    freshload();
                    DGV2.CurrentCell = DGV2.Rows[rowSelected].Cells[1];
                }
                else
                {
                    MessageBox.Show("Invalid Number");
                    tbPartSubsequent.Text = "";
                }
            }
        }

        private void CycleDayBlock()
        {
            cnxn.Open();

            cmd = new SqlCommand
                ("select partid from uschedulestatus where partid = " + partID + " ", cnxn);
            object t = cmd.ExecuteScalar();

            cnxn.Close();

            if (t != null)
            {
                cnxn.Open();

                cmd = new SqlCommand
                            ("select sum(cycledays) from tblWorkIns where jobid = " + g.jobID + " ", cnxn);

                int cycledaysum = 0;
                object o = cmd.ExecuteScalar();

                if (o.ToString() != "")
                {
                    cycledaysum = Convert.ToInt32(o.ToString());
                }

                cmd = new SqlCommand
                    ("select sum(cmpadjdays) from uschedulestatus where partid = " + partID + " ", cnxn);

                int cmpadjdaysum = 0;
                object ob = cmd.ExecuteScalar();

                if (ob.ToString() != "")
                {
                    cmpadjdaysum = Convert.ToInt32(ob.ToString());
                }

                tbJobCycleDaySum.Text = (cycledaysum + Convert.ToInt32(Ljswcd.Text)).ToString();

                tbPartCycleDaySum.Text = (cycledaysum + Convert.ToInt32(Ljswcd.Text) + cmpadjdaysum +
                    Convert.ToInt32(tbPartSubsequent.Text)).ToString();

                //spOptiTRAK_ProjectedShipDate

                cmd = new SqlCommand();
                cmd.CommandText = "spOptiTRAK_ProjectedShipDate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnxn;
                cmd.Parameters.Add("@PartID", SqlDbType.Int).Value = partID;
                cmd.Parameters.Add("@jswd", SqlDbType.Int).Value = Convert.ToInt32(Ljswcd.Text.Trim());
                cmd.Parameters.Add("@pswd", SqlDbType.Int).Value = Convert.ToInt32(tbPartSubsequent.Text.Trim());
                cmd.Parameters.Add("@psd", SqlDbType.Date).Direction = ParameterDirection.Output;

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                //if projected shipping date is pushed out too far the calendar will need adjusting and will give an error.
                DateTime temp = Convert.ToDateTime(cmd.Parameters["@psd"].Value);

                LpShipDate.Text = temp.ToShortDateString();

                cnxn.Close();
            }
            else
            {
                return;
            }

        }

        private void newSchedule()
        {
            cmd = new SqlCommand(
                         "Delete from uScheduleStatus " +
                         "where partid = " + partID + " ;" +
                         "Insert into uScheduleStatus " +
                         "( PartID, WorkID ) " +
                         "Select partid, " +
                         "workid " +
                         "from tblPartSN p " +
                         "inner join tblWorkIns w " +
                         "on p.jobID = w.jobID " +
                         "where partid = " + partID + " ", cnxn);

            cnxn.Open();
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand();
            cmd.CommandText = "spOptiTRAK_NewSchedule";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnxn;
            cmd.Parameters.Add("@PartID", SqlDbType.Int).Value = partID;
            cmd.Parameters.Add("@previousDate", SqlDbType.Date).Value = dtpRelease.Value;
            cmd.Parameters.Add("@pdeliveryD", SqlDbType.Date).Value = Lpdd.Text;
            cmd.Parameters.Add("@aswd", SqlDbType.Int).Value = Ljswcd.Text;
            cmd.Parameters.Add("@swcd", SqlDbType.Int).Value = tbPartSubsequent.Text;
            cmd.Parameters.Add("@soid", SqlDbType.Int).Value = SOID;

            cmd.ExecuteNonQuery();

            cmd = new SqlCommand(
             "Update tblPartSN " +
             "Set PartReleaseDate = '" + dtpRelease.Value +
             "' where partid = " + partID + " ", cnxn);

            cmd.ExecuteNonQuery();

            cnxn.Close();


        }


        private void bEnterData_Click(object sender, EventArgs e)
        {
            if (partID == null)
            {
                MessageBox.Show("Must select a PartID from 2. Select Part ID");
                DGV2.Focus();
                return;
            }
            else
            {

                SqlCommand cmd = new SqlCommand
                        ("select ssid from uschedulestatus where partid = " + partID + " ", cnxn);
                cnxn.Open();
                Object o = cmd.ExecuteScalar();
                cnxn.Close();

                if (o == null)
                {
                    newSchedule();
                    //showSchedule();
                }
                else
                {
                    cmd = new SqlCommand
                        ("select ssid from uschedulestatus where partid = " + partID +
                        " and processstatusID > 0 ", cnxn);
                    cnxn.Open();
                    Object p = cmd.ExecuteScalar();
                    cnxn.Close();

                    if (p == null)
                    {
                        newSchedule();
                        //showSchedule();
                    }
                    else
                    {
                        MessageBox.Show("Operations have already been completed on this SFO. " +
                            "\n\n Adjust schedule using CMP days.");
                        return;
                    }

                }

                freshload();
                CycleDayBlock();
            }
        }

        private void DGV2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 7)
            {
                return;
            }
            else
            {
                rowSelected = e.RowIndex;

                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[0];
                partID = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[2];
                dtpRelease.Text = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[3];
                Lpdd.Text = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[4];
                Lcrd.Text = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[5];
                Lopd.Text = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[6];
                Lod.Text = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[9];
                Ljswcd.Text = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[7];
                string test = cell.EditedFormattedValue.ToString().Trim();
                tbPartSubsequent.Text = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[10];
                SOID = cell.EditedFormattedValue.ToString().Trim();

                cmd = new SqlCommand
                    ("select jobid from tblWorkIns where jobid = " + g.jobID + " ", cnxn);
                cnxn.Open();
                object oa = cmd.ExecuteScalar();

                if (oa == null)
                {
                    MessageBox.Show("No part routing exists for this job. \n\n" +
                        "Go to Maintain Part Routings");
                    this.Close();
                    return;
                }
                else
                {
                    cmd = new SqlCommand
                        ("select ssid from uschedulestatus where partid = " + partID + " ", cnxn);
                    Object o = cmd.ExecuteScalar();
                    cnxn.Close();

                    if (o == null)
                    {
                        MessageBox.Show("No schedule exists.");
                        //showSchedule();
                        return;
                    }
                    else
                    {
                        //showSchedule();

                        CycleDayBlock();

                        //tbCmpAdjDays.Visible = true;
                        //bAdjustDays.Visible = true;

                    }
                }
            }
        }
    }
}
