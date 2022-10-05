using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace WorkPlanning
{
    public partial class MaintainSchedules : Form
    {
        SqlConnection cnxn;
        SqlConnection cnxn2;
        private string db = "server = midsql01; password = Read+Write!; " +
                            "user = readwrite; database = Planning;";
        SqlDataReader dr;
        DataTable dt;
        DataTable dt1;
        DataTable Rdt1;
        DataTable Rdt2;
        DataTable Rdt3;
        DataTable V3dt;
        DataRow newRow;
        
        
        private int snCount;
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
        private int columnNo;
        
        public MaintainSchedules()
        {
            InitializeComponent();
        }

        private void MaintainSchedules_Load(object sender, EventArgs e)
        {
            //Lcustomer.Text = "Customer: " + g.customer;
            //Lproject.Text = "Project:  " + g.project;
            //Lelement.Text = "Element:  " + g.element;
            //LitemCode.Text = "Part Number:  " + g.item_code;

            SqlConnection cnxn = new SqlConnection(db);
            
            //SqlCommand cmd = new SqlCommand
            //    ("select AdjsbsqntWorkDays + SbsqntWorkCycDays " +
            //     "from tblPartSN p inner join tblJobInfo j " + 
            //     "on p.JobID = j.JobID where p.JobID = " + g.jobID + " ", cnxn);
            //cnxn.Open();
            //object j = cmd.ExecuteScalar();
            //Lsubsequent.Text = "Subsequent Cycle Days:  " + j.ToString();
            //cnxn.Close();
            
            //cmd = new SqlCommand
            //    ("select stock_on_hand from AccessFrontEnds.dbo.mmx_item_data_by_warehouse where " +
            //     "warehouse = 48 and item_code = '" + g.item_code + "'");
            //cmd.Connection = cnxn;
            //cnxn.Open();
            //object o = cmd.ExecuteScalar();
            //if (o != null)
            //{
            //    Lfg48.Text = "Warehouse 48 Finished Goods Stock on Hand =  " + o.ToString().Trim();
            //}
           
            showSchedules();
        }

        private void showSchedules()
        {
            columnNo = 0;

            snCount = 0;

            //  set up the connection

            cnxn = new SqlConnection(g.db);

            //  get the details for the top grid
            
            SqlDataAdapter da = new SqlDataAdapter(
                "select " +
                "CAST(prodordnum as nvarchar(255)) SFO, " +
                "CONVERT(nvarchar(255), CAST(PLDlvry as date), 101) [Planned Delivery Date], " +
                "CONVERT(nvarchar(255), CAST(Curr_req_dt as date), 101) [Customer Request Date], " +
                "CONVERT(nvarchar(255), CAST(orig_prom_dt as date), 101) [Original Promise Date], " +
                "CONVERT(nvarchar(255), CAST(ProjectedShipDate as date), 101) [Projected Ship Date], " +
                "CONVERT(nvarchar(255), CAST(partreleasedate as date), 101) [Part Release Date], " +
                "CAST(partsn as nvarchar(255)) [Part ID], " +
                "CAST(pstatusdesc as nvarchar(255)) [Hold Status] " +
                "from tblPartSN p " +
                "left join tblSalesOrder s on p.soid = s.soid " +
                "inner join tblJobInfo j on p.jobid = j.jobid " +
                "left join tblProcessStatus ps on ps.processstatusid = p.holdstatid " +
                "where partpoclosed = 0 " +
                "and  j.JobComplete = 0 " +
                "and p.JobID = " + g.jobID + 
                "order by partsn ", cnxn);

            try
            {
                V3dt = new DataTable();
                da.Fill(V3dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("MaintianSchedules.cs line 130  " + ex.ToString());
            }

            DGV2.DataSource = V3dt;

            // set background color if the part is on hold
            for (int i = 0; i < DGV2.RowCount; i++)
            {
                if (V3dt.Rows[i][7].ToString().IndexOf("No Hold") == -1)
                {
                    DGV2.Rows[i].DefaultCellStyle.BackColor = Color.DarkCyan;
                }
            }

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
               "where p.jobid = " + g.jobID + " " +
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

            SqlCommand cmd = new SqlCommand(
                "Select partsn from tblpartSN where jobid = " + g.jobID +
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
                        "and p.JobID = " + g.jobID + "  and partsn = '" + dr.GetString(0).Trim() +
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


            DGV.DataSource = dt1;

            //DGV must be generated prior to setting widths and other formatting

            DGV.Rows[0].Frozen = true;
            DGV.Rows[0].DefaultCellStyle.BackColor = Color.Plum;
            DGV.Rows[1].Frozen = true;
            DGV.Rows[1].DefaultCellStyle.BackColor = Color.Plum;
            DGV.Rows[2].Frozen = true;
            DGV.Rows[2].DefaultCellStyle.BackColor = Color.Plum;
            DGV.Rows[3].Frozen = true;
            DGV.Rows[3].DefaultCellStyle.BackColor = Color.Plum;
            DGV.Columns[0].Frozen = true;

            DGV.Rows[3].DividerHeight = 5;

            //divider width for every third row
            for (int i = 12; i < (snCount * 9) + 4; i = i + 9)
            {
                DGV.Rows[i].DividerHeight = 5;
            }


            for (int j = 0; j < 6; j++)
            {
                for (int i = 4 + j; i < (snCount * 9) + 4; i = i + 9)
                {
                    DGV.Rows[i].Visible = false;
                }
            }

            // set background color for adjust row
            for (int i = 11; i < (snCount * 9) + 4; i = i + 9)
            {
                DGV.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
            }

            foreach (DataGridViewRow gr in DGV.Rows)
            {
                /*  want to make sure we don't add rows over the index number
                 *  should just check the rows which have the data - 8 + (i * 9)
                 *  and 9 + (i * 9) but will have to do that later
                 */

                if (gr.Index < (DGV.Rows.Count - 3))
                {
                    foreach (DataGridViewCell sell in gr.Cells)
                    {

                        if (sell.Value.ToString().Trim() == "Complete")
                        {
                            DGV.Rows[gr.Index + 1].Cells[sell.ColumnIndex].Style.BackColor = Color.Gray;
                            DGV.Rows[gr.Index + 2].Cells[sell.ColumnIndex].Style.BackColor = Color.Gray;
                            DGV.Rows[gr.Index + 3].Cells[sell.ColumnIndex].Style.BackColor = Color.Gray;
                        }

                        if (sell.Value.ToString().Trim() == "-1")
                        {
                            DGV.Rows[gr.Index + 2].Cells[sell.ColumnIndex].Style.BackColor = Color.Pink;
                            DGV.Rows[gr.Index + 3].Cells[sell.ColumnIndex].Style.BackColor = Color.Pink;
                            DGV.Rows[gr.Index + 4].Cells[sell.ColumnIndex].Style.BackColor = Color.Pink;
                        }

                        if (sell.ColumnIndex == 0 & gr.Index > 4)
                        {
                            DGV.Rows[gr.Index + 3].Cells[sell.ColumnIndex].Style.BackColor = Color.PaleGoldenrod;
                        }

                    }
                }

            }

            //  this keeps the cell in the same place when refreshing the data
            DGV.CurrentCell = DGV.Rows[RowIndex].Cells[ColumnIndex];
            DGV.Show();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 4 | e.ColumnIndex < 1)
            {
                return;
            }
            else
            {
                RowIndex = e.RowIndex;
                ColumnIndex = e.ColumnIndex;
                
                for (int i = 10; i < (snCount * 9) + 4; i = i + 9)
                {
                    if (e.RowIndex == i)
                    {
                        if (tbExtend.Text.Length > 0 )
                        { 
                            tbExtend.Text = ""; 
                        }
                        return;
                    }
                }

                for (int i = 11; i < (snCount * 9) + 4; i = i + 9)
                {
                    if (e.RowIndex == i)
                    {
                        DataGridViewTextBoxCell cell =
                            (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                        char[] c = {'A', 'd', 'j', 'u', 's', 't'};
                        g.partsn = cell.EditedFormattedValue.ToString().TrimEnd(c);

                        cell =
                            (DataGridViewTextBoxCell)DGV.Rows[0].Cells[e.ColumnIndex];
                        g.opnum = cell.EditedFormattedValue.ToString().Trim();

                        cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        
                        tbDelay.Text = cell.EditedFormattedValue.ToString().Trim().Substring(0,
                            cell.EditedFormattedValue.ToString().Trim().IndexOf(":"));

                        tbExtend.Text = cell.EditedFormattedValue.ToString().Trim().Substring(
                            cell.EditedFormattedValue.ToString().Trim().LastIndexOf(":") + 1,
                            (cell.EditedFormattedValue.ToString().Trim().Length -
                            cell.EditedFormattedValue.ToString().Trim().LastIndexOf(":")-1)
                            );


                        Lsn.Text = "SN " + g.partsn;
                        Lstep.Text = "Step " + g.opnum;


                        tbDelay.Focus();
                    }
                }

                for (int i = 12; i < (snCount * 9) + 4; i = i + 9)
                {
                    if (e.RowIndex == i)
                    {
                        if (tbExtend.Text.Length > 0)
                        {
                            tbExtend.Text = "";
                        }
                        return;
                    }
                }
            }
        }

        private void bAdjustDays_Click(object sender, EventArgs e)
        {
            cnxn.Open();
            SqlCommand cmd = new SqlCommand("select processstatusid from uschedulestatus ss " +
                "inner join tblWorkIns w " +
                "on ss.WorkID = w.WorkID " +
                "inner join tblpartsn p " +
                "on ss.PartID = p.PartID " +
                "inner join tblJobInfo j " +
                "on j.jobid = p.JobID " +
                "where partsn = '" + g.partsn + "' " +
                "and opnum = " + g.opnum + " " +
                "and p.jobid = " + g.jobID + " ", cnxn);

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
                "where p.partsn = '" + g.partsn + "' " +
                "and opnum = " + g.opnum + " " +
                "and p.jobid = " + g.jobID + " ", cnxn);

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

            showSchedules();
        }


        private void bPrint_Click(object sender, EventArgs e)
        {
            select1 = "";
            select2 = "";
            rowHeaders1 = "";
            rowHeaders2 = "";
            cte1 = "";
            cte2 = "";
            V3select1 = "";
            V3select2 = "";
            V3select3 = "";
            V3rowHeaders1 = "";
            V3rowHeaders2 = "";
            V3cte1 = "";
            V3cte2 = "";
            
            snCount = 0;

            cnxn = new SqlConnection(g.db);

            SqlDataAdapter Rda2 = new SqlDataAdapter(
                "select distinct " +
                "w.OpNum Step, " +
                "d.DeptCode Dept, " +
                "substring(Description, 0, 40) Description, " +
                "CycleDays Cycle " +
                "from uScheduleStatus ss " +
                "inner join tblPartSN p on ss.PartID = p.PartID " +
                "inner join tblWorkIns w on ss.WorkID = w.WorkID " +
                "inner join tblDept d on w.DeptID = d.DeptID " +
                "where partpoclosed = 0 " +
                "and  " +
                "p.JobID = " + g.jobID + "", cnxn);

            Rdt2 = new DataTable();

            try
            {
                Rda2.Fill(Rdt2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("MaintainSchedules.cs line 598  " + ex.ToString());
            }

            SqlCommand cmd = new SqlCommand(
                "Select partsn from tblpartSN p inner join tbljobinfo j " +
                "on p.jobid = j.jobid where p.jobid = " + g.jobID +
                "and partpoclosed = 0 and jobcomplete  = 0 " +
                "order by dbo.sc_sortableversionstring(partsn)", cnxn);
            cnxn.Open();
            try
            {
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MaintainSchedules.cs line 613  " + ex.ToString());
            }

            while (dr.Read())
            {
                try
                {
                    select1 = "pn" + dr.GetString(0).Trim() + " as (" +
                        "select " +
                        "IIF(currentrecord = -1, 'Current', '') OnStep" + dr.GetString(0).Trim() + "," +
                        "IIF(processstatusid = 2, 'Complete', IIF(processstatusid = 1, 'Active', 'Waiting')) Status" + dr.GetString(0).Trim() + "," +
                        "opstart opstart" + dr.GetString(0).Trim() + "," +
                        "w.OpNum, " +
                        "CAST(DATEPART(mm,DueDate) as nvarchar(2)) + '/' " +
                        "+ CAST( DATEPART(dd, DueDate) as nvarchar(2)) '" + dr.GetString(0).Trim() + "A', " +
                        "CAST(delay as varchar) + '::' + CAST(extend as varchar) '" + dr.GetString(0).Trim() + "Adj', " +
                        "CAST(DATEPART(mm,PlnDueDate) as nvarchar(2)) + '/' " +
                        "+ CAST( DATEPART(dd, PlnDueDate) as nvarchar(2)) '" + dr.GetString(0).Trim() + "PL' " +
                        "from uScheduleStatus ss " +
                        "inner join tblPartSN p on ss.PartID = p.PartID " +
                        "inner join tblWorkIns w on ss.WorkID = w.WorkID " +
                        "inner join tblDept d on w.DeptID = d.DeptID " +
                        "where partpoclosed = 0 " +
                        "and  " +
                        "p.JobID = " + g.jobID + " and p.PartSN = " + dr.GetString(0).Trim() + " )";


                    snCount = snCount + 1;

                    select2 = select2 + "," + Environment.NewLine + select1;

                    rowHeaders1 =
                                "[OnStep" + dr.GetString(0).Trim() + "]," +
                                "[Status" + dr.GetString(0).Trim() + "]," +
                                "[opstart" + dr.GetString(0).Trim() + "]," +
                                "[" + dr.GetString(0).Trim() + "A]," +
                                    "[" + dr.GetString(0).Trim() + "Adj]," +
                                "[" + dr.GetString(0).Trim() + "PL],";


                    rowHeaders2 = rowHeaders2 + Environment.NewLine + rowHeaders1;

                    cte1 = "left join pn" + dr.GetString(0).Trim() + " on fr.opnum = pn" +
                            dr.GetString(0).Trim() + ".opnum";
                    cte2 = cte2 + Environment.NewLine + cte1;

                    if (V3select1 == "" | V3select1 == null)
                    {
                        V3select1 = "with pn" + snCount.ToString() + " as (" +
                        "select  Title" + snCount.ToString() + ", " +
                        "Value" + snCount.ToString() + " from ( select " +
                        "CAST(prodordnum as nvarchar(255)) SFO, " +
                        "CONVERT(nvarchar(255), CAST(PLDlvry as date), 101) [Planned Delivery Date], " +
                        "CONVERT(nvarchar(255), CAST(Curr_req_dt as date), 101) [Customer Request Date], " +
                        "CONVERT(nvarchar(255), CAST(orig_prom_dt as date), 101) [Original Promise Date], " +
                        "CONVERT(nvarchar(255), CAST(ProjectedShipDate as date), 101) [Projected Ship Date], " +
                        "CONVERT(nvarchar(255), CAST(partreleasedate as date), 101) [Part Release Date], " +
                        "CAST(partsn as nvarchar(255)) [Part ID] , " +
                        "CAST(PartID as nvarchar(255)) PartID " +
                        "from tblPartSN p " +
                        "left join tblSalesOrder s on p.soid = s.soid " +
                        "inner join tblJobInfo j on p.jobid = j.jobid " +
                        "where partpoclosed = 0 " +
                        "and  j.JobComplete = 0 " +
                        "and p.JobID = " + g.jobID + " and p.PartSN = " + dr.GetString(0).Trim() + " )a " +
                        "unpivot " +
                        "(Value" + snCount.ToString() + " for Title" + snCount.ToString() + " in " +
                        "( " +
                        "SFO, " +
                        "[Planned Delivery Date], " +
                        "[Customer Request Date], " +
                        "[Original Promise Date], " +
                        "[Projected Ship Date], " +
                        "[Part Release Date], " +
                        "[Part ID] , " +
                        "PartID " +
                        "))b )";
                    }
                    else
                    {
                        V3select2 = "pn" + snCount.ToString() + " as (" +
                        "select  Title" + snCount.ToString() + ", " +
                        "Value" + snCount.ToString() + " from ( select " +
                        "CAST(prodordnum as nvarchar(255)) SFO, " +
                        "CONVERT(nvarchar(255), CAST(PLDlvry as date), 101) [Planned Delivery Date], " +
                        "CONVERT(nvarchar(255), CAST(Curr_req_dt as date), 101) [Customer Request Date], " +
                        "CONVERT(nvarchar(255), CAST(orig_prom_dt as date), 101) [Original Promise Date], " +
                        "CONVERT(nvarchar(255), CAST(ProjectedShipDate as date), 101) [Projected Ship Date], " +
                        "CONVERT(nvarchar(255), CAST(partreleasedate as date), 101) [Part Release Date], " +
                        "CAST(partsn as nvarchar(255)) [Part ID] , " +
                        "CAST(PartID as nvarchar(255)) PartID " +
                        "from tblPartSN p " +
                        "left join tblSalesOrder s on p.soid = s.soid " +
                        "inner join tblJobInfo j on p.jobid = j.jobid " +
                        "where partpoclosed = 0 " +
                        "and  j.JobComplete = 0 " +
                        "and p.JobID = " + g.jobID + " and p.PartSN = " + dr.GetString(0).Trim() + " )a " +
                        "unpivot " +
                        "(Value" + snCount.ToString() + " for Title" + snCount.ToString() + " in " +
                        "( " +
                        "SFO, " +
                        "[Planned Delivery Date], " +
                        "[Customer Request Date], " +
                        "[Original Promise Date], " +
                        "[Projected Ship Date], " +
                        "[Part Release Date], " +
                        "[Part ID] , " +
                        "PartID " +
                        "))b )";
                    }

                    if (V3select2 != "")
                    {
                        V3select3 = V3select3 + "," + Environment.NewLine + V3select2;
                    }

                    V3rowHeaders1 =
                                "[Title" + snCount.ToString() + "]," +
                                "[Value" + snCount.ToString() + "],";

                    V3rowHeaders2 = V3rowHeaders2 + Environment.NewLine + V3rowHeaders1;

                    if (snCount > 1)
                    {
                        V3cte1 = "left join pn" + snCount.ToString() +
                            " on pn1.Title1 = pn" + snCount.ToString() +
                            ".Title" + snCount.ToString() + " ";
                        V3cte2 = V3cte2 + Environment.NewLine + V3cte1;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("MaintainSchedules.cs line 746  " + ex.ToString());
                }
            }

            rowHeaders2 = rowHeaders2.TrimEnd(',');

            cnxn = new SqlConnection(g.db);

            //select the fixed left most columns and then build the conditional others

            SqlCommand next = new SqlCommand(
                "with fr as " +
                "(" +
                "select distinct " +
                "d.DeptCode, " +
                "w.OpNum, " +
                "Description, " +
                "CycleDays Cycle " +
                "from uScheduleStatus ss " +
                "inner join tblPartSN p on ss.PartID = p.PartID " +
                "inner join tblWorkIns w on ss.WorkID = w.WorkID " +
                "inner join tblDept d on w.DeptID = d.DeptID " +
                "where partpoclosed = 0 " +
                "and  " +
                "p.JobID = " + g.jobID + ")" +
                select2 + " " +
                "select fr.opnum, deptcode, description, cycle, " + rowHeaders2 + " from  fr " + cte2 +
                " order by opnum", cnxn);

            SqlDataAdapter da = new SqlDataAdapter(next);

            try
            {
                Rdt3 = new DataTable();
                da.Fill(Rdt3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("MaintainSchedules.cs line 788  " + ex.ToString());
            }

            V3rowHeaders2 = V3rowHeaders2.TrimEnd(',');
            cnxn = new SqlConnection(g.db);
            SqlCommand V3next = new SqlCommand(
                V3select1 + V3select3 + " select " + V3rowHeaders2 + " from pn1 " + V3cte2, cnxn);
            SqlDataAdapter V3da = new SqlDataAdapter(V3next);
            try
            {
                Rdt1 = new DataTable();
                V3da.Fill(Rdt1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("MaintainSchedules.cs line 799  " + ex.ToString());
            }

            
            rowsPageMore = false;
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = true;
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            (ppd as Form).WindowState = FormWindowState.Maximized;
            ppd.ShowDialog();
            Close();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            string date = DateTime.Now.ToString();
            if (rowsPageMore == true)
            { linedrop = 80; }
            else
            { linedrop = 240; }
            
            int count = 0;
            int linesPerpage = 40;
            int lineNo = this.pagesPrinted * linesPerpage;
            int pageNo = pagesPrinted + 1;
            //  double NumPages = Math.Ceiling(((i - 1) / 36.0));
            //string penflag = "BK";
            Pen pen = new Pen(Color.Red);
            Pen Gpen = new Pen(Color.Green);
            Gpen.Width = 2;
            pen.Width = 2;
            int columnSeparate = 135;
            Font arial = new Font("arial", 9, FontStyle.Regular);
            Font title = new Font("arial", 24, FontStyle.Bold);
            Font heading = new Font("arial", 9, FontStyle.Bold);
            Font leaders = new Font("arial", 14, FontStyle.Bold);

            
            if (rowsPageMore == false)
            {
                ev.Graphics.DrawString("SCHEDULE", title, Brushes.Black, 30, 100);
                ev.Graphics.DrawString("REPORT", title, Brushes.Black, 30, 140);
                ev.Graphics.DrawString("Printed: " + date, heading, Brushes.Black, 800, 15);

                ev.Graphics.DrawRectangle(pen, 25, 80, 200, 135);
                //ev.Graphics.DrawString("Page  " + pageNo + " of " + NumPages, heading, Brushes.Black, 800, 50);
                pen.Width = 1;

                
                //ev.Graphics.DrawString("Customer:  " + g.customer, heading, Brushes.Black, 25, 80);
                //ev.Graphics.DrawString("Project:  " + g.project, heading, Brushes.Black, 25, 100);
                //ev.Graphics.DrawString("Element:  " + g.element, heading, Brushes.Black, 25, 120);
                //ev.Graphics.DrawString("Part Number:  " + g.item_code, heading, Brushes.Black, 25, 140);
                //ev.Graphics.DrawString(Lsubsequent.Text, heading, Brushes.Black, 25, 160);

                ev.Graphics.DrawString("Customer:  " + g.customer, leaders, Brushes.Black, 20, 20);
                ev.Graphics.DrawString("Project:  " + g.project, leaders, Brushes.Black, 20, 50);
                ev.Graphics.DrawString("Element:  " + g.element, leaders, Brushes.Black, 350, 20);
                ev.Graphics.DrawString("Part Number:  " + g.item_code, leaders, Brushes.Black, 350, 50);
                ev.Graphics.DrawString(Lsubsequent.Text, leaders, Brushes.Black, 750, 50);

                ev.Graphics.DrawString("SFO:", heading, Brushes.Black, 230, 80);
                ev.Graphics.DrawString("Planned Delivery Date:", heading, Brushes.Black, 230, 100);
                ev.Graphics.DrawString("Customer Request Date:", heading, Brushes.Black, 230, 120);
                ev.Graphics.DrawString("Original Promise Date:", heading, Brushes.Black, 230, 140);
                ev.Graphics.DrawString("Projected ship Date:", heading, Brushes.Black, 230, 160);
                ev.Graphics.DrawString("Part Release Date:", heading, Brushes.Black, 230, 180);
                ev.Graphics.DrawString("Part ID:", heading, Brushes.Black, 230, 200);

                ev.Graphics.DrawString("St", heading, Brushes.Black, 35, 220);
                ev.Graphics.DrawString("Dept", heading, Brushes.Black, 65, 220);
                ev.Graphics.DrawString("Operation", heading, Brushes.Black, 100, 220);
                ev.Graphics.DrawString("Cycle", heading, Brushes.Black, 352, 220);

                ev.Graphics.DrawLine(Gpen, 25, 75, 1050, 75);
            }
            
            int cdt3 = Rdt1.Columns.Count;
            //data above the columns with the dates per sn
            //using count for columns here - one per every pair of columns
            //columnHNo gets the data from every other column and continues
            // to following pages
            //'i' keeps track of the columns printed per page
            count = 1;

            for (int i = 1; ((columnHNo <= (cdt3)) && (i < 10)); i = i + 2)
            {
                ev.Graphics.DrawLine(pen, (255 + (count * columnSeparate)), 80, (255 + (count * columnSeparate)), (240 + (dt.Rows.Count * 15)));
                
                ev.Graphics.DrawString((Rdt1.Rows[0][columnHNo]).ToString(), arial, Brushes.Black, (270 + (count * columnSeparate)), 80);
                ev.Graphics.DrawString((Rdt1.Rows[1][columnHNo]).ToString(), arial, Brushes.Black, (270 + (count * columnSeparate)), 100);
                ev.Graphics.DrawString((Rdt1.Rows[2][columnHNo]).ToString(), arial, Brushes.Black, (270 + (count * columnSeparate)), 120);
                ev.Graphics.DrawString((Rdt1.Rows[3][columnHNo]).ToString(), arial, Brushes.Black, (270 + (count * columnSeparate)), 140);
                ev.Graphics.DrawString((Rdt1.Rows[4][columnHNo]).ToString(), arial, Brushes.Black, (270 + (count * columnSeparate)), 160);
                ev.Graphics.DrawString((Rdt1.Rows[5][columnHNo]).ToString(), arial, Brushes.Black, (270 + (count * columnSeparate)), 180);
                ev.Graphics.DrawString((Rdt1.Rows[6][columnHNo]).ToString(), arial, Brushes.Black, (270 + (count * columnSeparate)), 200);

                ev.Graphics.DrawString("Act", heading, Brushes.Black, (270 + (count * columnSeparate)), 220);
                ev.Graphics.DrawString("Adj", heading, Brushes.Black, (310 + (count * columnSeparate)), 220);
                ev.Graphics.DrawString("Pl", heading, Brushes.Black, (350 + (count * columnSeparate)), 220);
                count++;
                columnHNo = columnHNo + 2;
            }
            

            int rRdt2 = Rdt2.Rows.Count;
            int cRdt = Rdt3.Columns.Count;

           

            //using count for rows here
            //dt and dt2 rows are coordinated
            if (rowsPageMore == true)
            {
                lineNo = linesPerpage -1;
                headerDrop = 60;
            }
            else
            {
                lineNo = 0;
                headerDrop = 220;
            }

            count = 1;

            
            if (rowsPageMore == true)
            {
                pageNo = pageNo - 1;
            
            }

            //five columns per page; need zero on the first page
            columnLNo = (pageNo - 1) * (5);


            while (lineNo < rRdt2 && count < linesPerpage)
            {
                //step values/descriptions
                ev.Graphics.DrawString((Rdt2.Rows[lineNo][0]).ToString(), arial, Brushes.Black, 35, linedrop);
                ev.Graphics.DrawString((Rdt2.Rows[lineNo][1]).ToString(), arial, Brushes.Black, 65, linedrop);
                ev.Graphics.DrawString((Rdt2.Rows[lineNo][2]).ToString(), arial, Brushes.Black, 100, linedrop);
                ev.Graphics.DrawString((Rdt2.Rows[lineNo][3]).ToString(), arial, Brushes.Black, 365, linedrop);

                
                for (int i = 0; (((columnLNo + i) * 6) + 5 <= cRdt) && (i < 5); i++)
                {
                    if ((Rdt3.Rows[lineNo][5 + ((columnLNo + i) * 6)]).ToString().ToUpper() == "COMPLETE")
                    {
                        printColor = Brushes.Green;
                    }
                    else if ((Rdt3.Rows[lineNo][5 + ((columnLNo + i) * 6)]).ToString().ToUpper() == "ACTIVE")
                    {
                        printColor = Brushes.Red;
                    }
                    else
                    {
                        printColor = Brushes.Blue;
                    }
                    
                    //schedule actual - adjustment - planned
                    ev.Graphics.DrawString((Rdt3.Rows[lineNo][7 + ((columnLNo + i) * 6)]).ToString(), arial, printColor, (410 + (i * columnSeparate)), linedrop);
                    ev.Graphics.DrawString((Rdt3.Rows[lineNo][8 + ((columnLNo + i) * 6)]).ToString(), arial, printColor, (445 + (i * columnSeparate)), linedrop);
                    ev.Graphics.DrawString((Rdt3.Rows[lineNo][9 + ((columnLNo + i) * 6)]).ToString(), arial, printColor, (480 + (i * columnSeparate)), linedrop);

                    if (lineNo % 3 == 0)
                    {
                        ev.Graphics.DrawLine(pen, 25, linedrop, (480 + (i * columnSeparate)) + 30, linedrop);
                    }

                    //ev.Graphics.DrawLine(pen, (255 + (count * columnSeparate)), 80, (255 + (count * columnSeparate)), linedrop);
                }
                count++;
                lineNo++;
                linedrop = linedrop + 15;
            }



            if (rRdt2 > linesPerpage)
            {
                rowsPageMore = true;
            }

            if (pageNo == 2)
            {
                rowsPageMore = false;
            }

            
            if (rowsPageMore == true | columnHNo < Rdt1.Columns.Count)
            {
                ev.HasMorePages = true;
                pagesPrinted++;
            }
            else
            {
                ev.HasMorePages = false;
                linedrop = 160;
                count = 0;
                pagesPrinted = 0;
                lineNo = 0;
                columnHNo = 1;
                columnLNo = 0;
            }
        }

        private void bBlockAdjust_Click(object sender, EventArgs e)
        {

            if (g.opnum == null)
            {
                MessageBox.Show("Must select an operation step.");
                return;
            }    

            
            //BlockAdjust b = new BlockAdjust();
            //b.ShowDialog();

            showSchedules();
        }

        private void bFixCompletedNError_Click(object sender, EventArgs e)
        {
            cnxn.Open();
            SqlCommand cmd = new SqlCommand("select processstatusid from uschedulestatus ss " +
                "inner join tblWorkIns w " +
                "on ss.WorkID = w.WorkID " +
                "inner join tblpartsn p " +
                "on ss.PartID = p.PartID " +
                "inner join tblJobInfo j " +
                "on j.jobid = p.JobID " +
                "where partsn = '" + g.partsn + "' " +
                "and opnum = " + g.opnum + " " +
                "and p.jobid = " + g.jobID + " ", cnxn);

            Object r = cmd.ExecuteScalar();
            cnxn.Close();

            if (r.ToString() == "2")
            {
                cnxn.Open();
                cmd = new SqlCommand("select p.partid from uschedulestatus ss " +
                    "inner join tblWorkIns w " +
                    "on ss.WorkID = w.WorkID " +
                    "inner join tblpartsn p " +
                    "on ss.PartID = p.PartID " +
                    "inner join tblJobInfo j " +
                    "on j.jobid = p.JobID " +
                    "where p.partsn = '" + g.partsn + "' " +
                    "and opnum = " + g.opnum + " " +
                    "and p.jobid = " + g.jobID + " ", cnxn);

                Object p = cmd.ExecuteScalar();
                cnxn.Close();

                cmd = new SqlCommand(
                        "Update uScheduleStatus " +
                        "set ProcessStatusID = 0 " +
                         " from uScheduleStatus ss " +
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
            }

            showSchedules();
        }

        private void bStatus_Click(object sender, EventArgs e)
        {
            cnxn.Open();
            SqlCommand cmd = new SqlCommand("select p.partid from uschedulestatus ss " +
                "inner join tblWorkIns w " +
                "on ss.WorkID = w.WorkID " +
                "inner join tblpartsn p " +
                "on ss.PartID = p.PartID " +
                "inner join tblJobInfo j " +
                "on j.jobid = p.JobID " +
                "where p.partsn = '" + g.partsn + "' " +
                "and opnum = " + g.opnum + " " +
                "and p.jobid = " + g.jobID + " ", cnxn);

            try
            {
                Object p = cmd.ExecuteScalar();

                if (p != null)
                {
                    g.partid = p.ToString();
                }
                else
                {
                    MessageBox.Show("Must click on an adjustment row");
                    return;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Must click on an adjustment row. \r\r" + ex.ToString());
                return;
            }
            finally
            {
                cnxn.Close();
            }

            //HoldStatusSelector h = new HoldStatusSelector();
            //h.ShowDialog();

            showSchedules();
        }
    }
}
