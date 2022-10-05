using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace MasterScheduleCalcium
{
    public partial class MasterScheduleCalcium : Form
    {
        SqlConnection cnxn;
        SqlConnection cnxn2;
        //private string db = "server = midsql01; password = Read+Write!; " +
        //                    "user = readwrite; database = OptiTRAK;";
        //SqlDataReader dr;
        //DataTable dt;
        //DataTable dt1;
        //DataTable Rdt1;
        //DataTable Rdt2;
        //DataTable Rdt3;
        //DataTable V3dt;
        DataRow newRow;
        //DataTable dtc1;


        public int snCount = 0;
        private string select1;
        private string select2;
        private string rowHeaders1;
        private string rowHeaders2;
        private string cte1;
        private string cte2;
        private string V3select1;
        private string V3select2;
        private string V3select3;
        private string V3rowHeaders1;
        private string V3rowHeaders2;
        private string V3cte1;
        private string V3cte2;

        private int rowColor;
        private Brush printColor;
        private bool rowsPageMore;
        private int pagesPrinted = 0;
        private int linedrop;
        private int headerDrop;
        private int columnHNo = 1;
        private int columnLNo = 0;
        private int RowIndex;
        private int ColumnIndex;
        //public int columnNo;



        public MasterScheduleCalcium()
        {
            InitializeComponent();
        }

        //vScrollBar1.Scroll += (sender, e) => { panel1.VerticalScroll.Value = vScrollBar1.Value; };

        private void MasterScheduleCalcium_Load(object sender, EventArgs e)
        {
            loadGrid(DGVp1, "349", LdgvP1Label);
            loadGrid(DGVp2, "70", LdgvP2Label);
            
        }

        /* 


         showSchedules();

     }
     */

        private void GridClick(object sender, DataGridViewCellEventArgs e)
        {
            g.partid = "";
            g.SFO = "";
            g.partsn = "";
            g.opnum = "";

            if (e.RowIndex < 4 | e.ColumnIndex < 1)
            {
                return;
            }
            else
            {
                RowIndex = e.RowIndex;
                ColumnIndex = e.ColumnIndex;

                DataGridView grd = sender as DataGridView;
                int hoMmanyRows = grd.Rows.Count;

                for (int i = 10; i < hoMmanyRows; i = i + 9)
                {
                    if (e.RowIndex == i)
                    {
                        if (tbExtend.Text.Length > 0)
                        {
                            tbExtend.Text = "";
                        }
                        Lsn.Text = "SFO " + g.SFO;
                        Lstep.Text = "Step " + g.opnum;
                        return;
                    }
                }

                for (int i = 11; i < hoMmanyRows; i = i + 9)
                {
                    if (e.RowIndex == i)
                    {
                        DataGridViewTextBoxCell cell =
                                    (DataGridViewTextBoxCell)grd.Rows[e.RowIndex].Cells[0];
                        char[] c = { 'A', 'd', 'j', 'u', 's', 't' };
                        g.partsn = cell.EditedFormattedValue.ToString().TrimEnd(c);

                        cell = (DataGridViewTextBoxCell)grd.Rows[e.RowIndex - 1].Cells[0];
                        char[] d = { 'A', 'c', 't', 'u', 'a', 'l' };
                        g.SFO = cell.EditedFormattedValue.ToString().TrimEnd(d);

                        cell =
                            (DataGridViewTextBoxCell)grd.Rows[0].Cells[e.ColumnIndex];
                        g.opnum = cell.EditedFormattedValue.ToString().Trim();

                        cell = (DataGridViewTextBoxCell)grd.Rows[e.RowIndex].Cells[e.ColumnIndex];

                        tbDelay.Text = cell.EditedFormattedValue.ToString().Trim().Substring(0,
                            cell.EditedFormattedValue.ToString().Trim().IndexOf(":"));

                        tbExtend.Text = cell.EditedFormattedValue.ToString().Trim().Substring(
                            cell.EditedFormattedValue.ToString().Trim().LastIndexOf(":") + 1,
                            (cell.EditedFormattedValue.ToString().Trim().Length -
                            cell.EditedFormattedValue.ToString().Trim().LastIndexOf(":") - 1)
                            );

                        tbDelay.Focus();
                    }
                }

                for (int i = 12; i < hoMmanyRows; i = i + 9)
                {
                    if (e.RowIndex == i)
                    {
                        if (tbExtend.Text.Length > 0)
                        {
                            tbExtend.Text = "";
                        }
                        Lsn.Text = "SFO " + g.SFO;
                        Lstep.Text = "Step " + g.opnum;
                        return;
                    }
                }
            }

            Lsn.Text = "SFO " + g.SFO;
            Lstep.Text = "Step " + g.opnum;
        }

            
        
        private void bAdjustDays_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            cnxn.Open();
            SqlCommand cmd = new SqlCommand("select processstatusid from uschedulestatus ss " +
                "inner join tblWorkIns w on ss.WorkID = w.WorkID " +
                "inner join tblpartsn p on ss.PartID = p.PartID " +
                "inner join tblJobInfo j on j.jobid = p.JobID " +
                "where p.prodordnum = '" + g.SFO + "' " +
                "and opnum = " + g.opnum + " ", cnxn);

            Object r = cmd.ExecuteScalar();
            cnxn.Close();

            if (r.ToString() == "2")
            {
                MessageBox.Show("Can not adjust schedule for steps which have been completed.");
                return;
            }

            cnxn.Open();
            cmd = new SqlCommand("select p.partid from uschedulestatus ss " +
                "inner join tblWorkIns w " +
                "on ss.WorkID = w.WorkID " +
                "inner join tblpartsn p " +
                "on ss.PartID = p.PartID " +
                "inner join tblJobInfo j " +
                "on j.jobid = p.JobID " +
                "where p.prodordnum = '" + g.SFO + "' " +
                "and opnum = " + g.opnum + " ", cnxn);

            Object p = cmd.ExecuteScalar();
            cnxn.Close();

            cmd = new SqlCommand(
                        "Update uScheduleStatus " +
                        "set Extend = " + tbExtend.Text.Trim() +
                         ", Delay = " + tbDelay.Text.Trim() + "from uScheduleStatus ss " +
                         "inner join tblWorkIns w " +
                         "on ss.WorkID = w.WorkID " +
                         "where partid = " + p + " " +
                         " and opnum = " + g.opnum + " ", cnxn);
            cnxn.Open();
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand();
            cmd.CommandText = "spAdjustBothSchedules";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnxn;
            cmd.Parameters.Add("@PartID", SqlDbType.Int).Value = p;
            cmd.Parameters.Add("@opNum", SqlDbType.Int).Value = g.opnum;

            cmd.ExecuteNonQuery();

            cnxn.Close();

            //    //showSchedules();
        }


        public static void loadGrid (DataGridView grd, string job, Label grdLabel)
        {
            DataTable dtJob = null;
            DataTable dt = null;
            DataTable dt1;
            DataRow newRow;
            SqlDataReader dr = null;
            SqlConnection cnxn2;

            SqlConnection cnxn = new SqlConnection(g.db);

            SqlDataAdapter da = new SqlDataAdapter(
               "select " +
               "customer, " +
               "project, " +
               "elementname, " +
               "partdrawingnumber + partdrawingrev " +
               "from tblJobInfo " +
               "where jobid = " + job + " "
               , cnxn);

            try
            {
                dtJob = new DataTable();
                da.Fill(dtJob);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            SqlCommand cmd = new SqlCommand
            ("select AdjsbsqntWorkDays + SbsqntWorkCycDays " +
             "from tblPartSN p inner join tblJobInfo j " +
             "on p.JobID = j.JobID where p.JobID = " + job + " ", cnxn);
        cnxn.Open();
        object s = cmd.ExecuteScalar();
        string subsequent = "Subsequent Cycle Days:  " + s.ToString();
        cnxn.Close();

            //cmd = new SqlCommand
            //    ("select stock_on_hand from AccessFrontEnds.dbo.mmx_item_data_by_warehouse where " +
            //     "warehouse = 48 and item_code = '" + dtJob.Rows[0][3].ToString() + "'");
            //cmd.Connection = cnxn;
            //cnxn.Open();
            //object o = cmd.ExecuteScalar();

            //    string inv = "";
            //if (o != null)
            //{
            //    inv = "W48 OH =  " + o.ToString().Trim();
            //}


            grdLabel.Text = "Customer: " + dtJob.Rows[0][0].ToString() + "  " +
                            "Project:  " + dtJob.Rows[0][1].ToString() + "  " +
                            "Element:  " + dtJob.Rows[0][2].ToString() + "  " +
                            "Part Number:  " + dtJob.Rows[0][3].ToString() + "  " +
                            subsequent + "  "; // + inv;


            int columnNo = 0;

            int snCount = 0;

            
            //  first get the shared part data
        

            da = new SqlDataAdapter(
               "select distinct " +
               "opnum, " +
               "DeptCode, " +
               "Description, " +
               "CycleDays " +
               "from uScheduleStatus ss " +
               "inner join tblPartSN p on ss.PartID = p.PartID " +
               "inner join tblWorkIns w on ss.WorkID = w.WorkID " +
               "inner join tblDept d on w.DeptID = d.DeptID " +
               "where p.jobid = " + job + " " +
               "order by opnum", cnxn);

            try
            {
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



            //  this table will be used to put the data in the correct arrangement

            dt1 = new DataTable();

            foreach (DataRow rr in dt.Rows)
            {
                columnNo++;
                dt1.Columns.Add((columnNo).ToString(), typeof(string));

                if (columnNo == 1)
                {
                    newRow = dt1.NewRow();
                    newRow[columnNo - 1] = rr.ItemArray[0].ToString();
                    dt1.Rows.Add(newRow);

                    newRow = dt1.NewRow();
                    newRow[columnNo - 1] = rr.ItemArray[1].ToString();
                    dt1.Rows.Add(newRow);

                    newRow = dt1.NewRow();
                    newRow[columnNo - 1] = rr.ItemArray[2].ToString();
                    dt1.Rows.Add(newRow);

                    newRow = dt1.NewRow();
                    newRow[columnNo - 1] = rr.ItemArray[3].ToString();
                    dt1.Rows.Add(newRow);
                }
                else
                {
                    dt1.Rows[0][columnNo - 1] = rr.ItemArray[0].ToString();
                    dt1.Rows[1][columnNo - 1] = rr.ItemArray[1].ToString();
                    dt1.Rows[2][columnNo - 1] = rr.ItemArray[2].ToString();
                    dt1.Rows[3][columnNo - 1] = rr.ItemArray[3].ToString();
                }
            }

                //  then get the list of parts for the job

                cmd = new SqlCommand(
                    "Select partsn from tblpartSN where jobid = " + job +
                    "and partpoclosed = 0 " +
                    "order by dbo.sc_sortableversionstring(partsn)", cnxn);

                cnxn.Open();

                try
                {
                    dr = cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("MaintainSchedules.cs line 213  " + ex.ToString());
                }

                // go through the list of parts and add the data to the first table

                while (dr.Read())
                {

                    cnxn2 = new SqlConnection(g.db);

                    // partsn could be either numeric or alphanumeric

                    SqlDataAdapter da1 = new SqlDataAdapter(
                            "select " +
                            "OpNum, " +
                            "ProdOrdNum, " +
                            "partsn, " +
                            "OpStart, " +
                            "CurrentRecord, " +
                            "IIF(ProcessStatusID = 2, 'Complete', IIF(ProcessStatusID = 1, 'Active', 'Waiting')) ProcessStatusID, " +
                            "CONVERT(nvarchar(10), DueDate, 101) DueDate, " +
                            "CAST(delay as varchar) + '::' + CAST(extend as varchar) CmpAdjDays, " +
                            "CONVERT(nvarchar(10), PlnDueDate, 101) PlnDueDate " +
                            "from uScheduleStatus ss " +
                            "inner join tblPartSN p on ss.PartID = p.PartID " +
                            "inner join tblWorkIns w on ss.WorkID = w.WorkID " +
                            "inner join tblDept d on w.DeptID = d.DeptID " +
                            "where partpoclosed = 0 " +
                            "and p.JobID = " + job + "  and partsn = '" + dr.GetString(0).Trim() +
                            "' order by opnum", cnxn2);

                    try
                    {
                        dt = new DataTable();
                        da1.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("MaintainSchedules.cs line 251  " + ex.ToString());
                    }

                    columnNo = 0;

                    foreach (DataRow rr in dt.Rows)
                    {
                        columnNo++;

                        if (columnNo == 1)
                        {
                            newRow = dt1.NewRow();
                            newRow[0] = rr.ItemArray[0].ToString();
                            dt1.Rows.Add(newRow);

                            newRow = dt1.NewRow();
                            newRow[0] = rr.ItemArray[1].ToString();
                            dt1.Rows.Add(newRow);

                            newRow = dt1.NewRow();
                            newRow[0] = rr.ItemArray[2].ToString();
                            dt1.Rows.Add(newRow);

                            newRow = dt1.NewRow();
                            newRow[0] = rr.ItemArray[3].ToString();
                            dt1.Rows.Add(newRow);

                            newRow = dt1.NewRow();
                            newRow[0] = rr.ItemArray[4].ToString();
                            dt1.Rows.Add(newRow);

                            newRow = dt1.NewRow();
                            newRow[0] = rr.ItemArray[5].ToString();
                            dt1.Rows.Add(newRow);

                            newRow = dt1.NewRow();
                            newRow[0] = rr.ItemArray[6].ToString();
                            dt1.Rows.Add(newRow);

                            newRow = dt1.NewRow();
                            newRow[0] = rr.ItemArray[7].ToString();
                            dt1.Rows.Add(newRow);

                            newRow = dt1.NewRow();
                            newRow[0] = rr.ItemArray[8].ToString();
                            dt1.Rows.Add(newRow);
                        }
                        else
                        {
                            dt1.Rows[4 + (9 * snCount)][columnNo - 1] = rr.ItemArray[0].ToString();
                            dt1.Rows[5 + (9 * snCount)][columnNo - 1] = rr.ItemArray[1].ToString();
                            dt1.Rows[6 + (9 * snCount)][columnNo - 1] = rr.ItemArray[2].ToString();
                            dt1.Rows[7 + (9 * snCount)][columnNo - 1] = rr.ItemArray[3].ToString();
                            dt1.Rows[8 + (9 * snCount)][columnNo - 1] = rr.ItemArray[4].ToString();
                            dt1.Rows[9 + (9 * snCount)][columnNo - 1] = rr.ItemArray[5].ToString();
                            dt1.Rows[10 + (9 * snCount)][columnNo - 1] = rr.ItemArray[6].ToString();
                            dt1.Rows[11 + (9 * snCount)][columnNo - 1] = rr.ItemArray[7].ToString();
                            dt1.Rows[12 + (9 * snCount)][columnNo - 1] = rr.ItemArray[8].ToString();
                        }
                    }
                    snCount++;

                }

                cnxn.Close();

                DataColumn col = dt1.Columns.Add((0).ToString(), typeof(string));
                col.SetOrdinal(0);

                dt1.Rows[0][0] = "      Step  ";
                dt1.Rows[1][0] = "      Department  ";
                dt1.Rows[2][0] = "      Description  ";
                dt1.Rows[3][0] = "      Cycle Days  ";

                /*  
                     get the SFO from column 1 put it in column 0
                */
                try
                {
                    for (int i = 5; i < (snCount * 9) + 5; i = i + 9)
                    {
                        dt1.Rows[i + 5][0] = dt1.Rows[i][1] + "     Actual";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Is routing loaded ? \r\r MaintainSchedules.cs line 337  \r\r" + ex.ToString());
                }
                /*  
                    get the PartSn from column 1 put it in column 0
                */
                for (int i = 6; i < (snCount * 9) + 6; i = i + 9)
                {
                    dt1.Rows[i + 5][0] = dt1.Rows[i][1] + "              Adjust";
                }

                for (int i = 7; i < (snCount * 9) + 7; i = i + 9)
                {
                    dt1.Rows[i + 5][0] = "              Planned";
                }


                grd.DataSource = dt1;

                //DGV must be generated prior to setting widths and other formatting

                grd.Rows[0].Frozen = true;
                grd.Rows[0].DefaultCellStyle.BackColor = Color.Plum;
                grd.Rows[1].Frozen = true;
                grd.Rows[1].DefaultCellStyle.BackColor = Color.Plum;
                grd.Rows[2].Frozen = true;
                grd.Rows[2].DefaultCellStyle.BackColor = Color.Plum;
                grd.Rows[3].Frozen = true;
                grd.Rows[3].DefaultCellStyle.BackColor = Color.Plum;
                grd.Columns[0].Frozen = true;

                grd.Rows[3].DividerHeight = 5;

                //divider width for every third row
                for (int i = 12; i < (snCount * 9) + 4; i = i + 9)
                {
                    grd.Rows[i].DividerHeight = 5;
                }


                for (int j = 0; j < 6; j++)
                {
                    for (int i = 4 + j; i < (snCount * 9) + 4; i = i + 9)
                    {
                        grd.Rows[i].Visible = false;
                    }
                }

                // set background color for adjust row
                for (int i = 11; i < (snCount * 9) + 4; i = i + 9)
                {
                    grd.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                }

                foreach (DataGridViewRow gr in grd.Rows)
                {
                    /*  want to make sure we don't add rows over the index number
                     *  should just check the rows which have the data - 8 + (i * 9)
                     *  and 9 + (i * 9) but will have to do that later
                     */
                  
                                  if (gr.Index < (grd.Rows.Count - 3))
                                  {
                                      foreach (DataGridViewCell sell in gr.Cells)
                                      {

                                          if (sell.Value.ToString().Trim() == "Complete")
                                          {
                                              grd.Rows[gr.Index + 1].Cells[sell.ColumnIndex].Style.BackColor = Color.Gray;
                                              grd.Rows[gr.Index + 2].Cells[sell.ColumnIndex].Style.BackColor = Color.Gray;
                                              grd.Rows[gr.Index + 3].Cells[sell.ColumnIndex].Style.BackColor = Color.Gray;
                                          }

                                          if (sell.Value.ToString().Trim() == "-1")
                                          {
                                              grd.Rows[gr.Index + 2].Cells[sell.ColumnIndex].Style.BackColor = Color.Pink;
                                              grd.Rows[gr.Index + 3].Cells[sell.ColumnIndex].Style.BackColor = Color.Pink;
                                              grd.Rows[gr.Index + 4].Cells[sell.ColumnIndex].Style.BackColor = Color.Pink;
                                          }

                                          if (sell.ColumnIndex == 0 & gr.Index > 4)
                                          {
                                              grd.Rows[gr.Index + 3].Cells[sell.ColumnIndex].Style.BackColor = Color.PaleGoldenrod;
                                          }

                                      }
                                  }

                              }

                              //  this keeps the cell in the same place when refreshing the data
                              //grd.CurrentCell = grd.Rows[RowIndex].Cells[ColumnIndex];
                              grd.Show();

        }



        public static class g
        {
            public static string drawingNo;
            public static string jobID;
            public static string job2ID;
            public static string customer;
            public static string project;
            public static string element;
            public static string item_code;
            public static string opnum;
            public static string partsn;
            public static string SFO;
            public static string holdStatusID;
            public static string partid;
            /*public static string db = "server = CT-mid-sql01; password = Read+Write!; " +
                                      "user = readwrite; database = OptiTRAK;";*/
            public static string db = "server = CT-MID-SQL01; password = Read+Write!; " +
                                      "user = readwrite; database = OptiTRAK;";
        }

        private void bKappa_Click(object sender, EventArgs e)
        {
            loadGrid(DGVp1, "349", LdgvP1Label);
            loadGrid(DGVp2, "70", LdgvP2Label);
            DGVp3.Visible = false;
            LdgvP3Label.Visible = false;
        }

        private void bSigma_Click(object sender, EventArgs e)
        {
            loadGrid(DGVp1, "144", LdgvP1Label);
            loadGrid(DGVp2, "142", LdgvP2Label);
            loadGrid(DGVp3, "143", LdgvP3Label);
        }

        private void bGammaO_Click(object sender, EventArgs e)
        {
            loadGrid(DGVp1, "530", LdgvP1Label);
            loadGrid(DGVp2, "532", LdgvP2Label);
            loadGrid(DGVp3, "531", LdgvP3Label);
        }

        private void BgammaP_Click(object sender, EventArgs e)
        {
            loadGrid(DGVp1, "521", LdgvP1Label);
            loadGrid(DGVp2, "529", LdgvP2Label);
            DGVp3.Visible = false;
            LdgvP3Label.Visible = false;
        }

        private void bWelle_Click(object sender, EventArgs e)
        {
            loadGrid(DGVp1, "217", LdgvP1Label);
            loadGrid(DGVp2, "296", LdgvP2Label);
            loadGrid(DGVp3, "297", LdgvP3Label);
        }

        private void DGVp1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GridClick(sender, e);
        }

        private void DGVp2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GridClick(sender, e);
        }

        private void DGVp3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GridClick(sender, e);
        }
    }
}
