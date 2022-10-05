using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StatusAdjustmentRequired
{
    public partial class BlockAdjustLocal : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable dt;
        SqlCommand cmd;
        private string CurrentDueDate;
        private string Slist;

        public BlockAdjustLocal()
        {
            InitializeComponent();
        }

        private void BlockAdjustLocal_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            da = new SqlDataAdapter(
                "select distinct DueDate from uScheduleStatus ss " +
                "left join tblPartSN p on ss.PartID = p.PartID " +
                "left join tblWorkIns w on ss.WorkID = w.WorkID " +
                "left join tblJobInfo j on p.JobID = j.JobID " +
                "where w.JobID = " + g.jobID + " and opnum = " + g.opnum +
                "and PartPOClosed = 0 " +
                "and JobComplete = 0 " +
                "and ProcessStatusID != 2 order by duedate", cnxn);

            try
            {
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DGV.DataSource = dt;

            DGV.Show();

        }

        private void bAdjustDays_Click(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(tbCmpAdjDays.Text, out result))
            {
                //get the ssid of the rows to be updated and put in string
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Slist = Slist + "," + dt.Rows[i][0].ToString();
                    Slist = Slist.TrimStart(',');

                    cmd = new SqlCommand(
                        "Update uschedulestatus set Delay = " +
                        tbCmpAdjDays.Text.Trim() +
                        "where ssid in (" + Slist + ")", cnxn);
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
            else
            {
                MessageBox.Show("Not a valid number.");
                return;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int PartID;
                Int32.TryParse(dt.Rows[i][1].ToString(), out PartID);
                cmd = new SqlCommand();
                cmd.CommandText = "spAdjustBothSchedules";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnxn;
                cmd.Parameters.Add("@PartID", SqlDbType.Int).Value = PartID;
                cmd.Parameters.Add("@opNum", SqlDbType.Int).Value = g.opnum;

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
            this.Close();
        }


        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                            (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                CurrentDueDate = cell.EditedFormattedValue.ToString().Trim();

                da = new SqlDataAdapter(
                "select ssid, ss.partid, ProdOrdNum, OpNum, Delay " +
                "from uScheduleStatus ss " +
                "left join tblPartSN p on ss.PartID = p.PartID " +
                "left join tblWorkIns w on ss.WorkID = w.WorkID " +
                "left join tblJobInfo j on p.JobID = j.JobID " +
                "where w.JobID = " + g.jobID + " and opnum = " + g.opnum + " " +
                "and duedate = '" + CurrentDueDate + "' " +
                "and PartPOClosed = 0 " +
                "and JobComplete = 0 " +
                "and ProcessStatusID != 2 order by prodordnum", cnxn);

                try
                {
                    dt = new DataTable();
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                DGV2.DataSource = dt;

                DGV2.Columns[0].Visible = false;
                DGV2.Columns[1].Visible = false;
                DGV2.Columns[3].Width = 50;


                DGV2.Show();
            }
        }

    }
}
