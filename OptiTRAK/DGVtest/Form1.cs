using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DGVtest
{
    public partial class Form1 : Form
    {
        SqlConnection cnxn;
        SqlConnection cnxn2;
        private string db = "server = midsql01; password = Read+Write!; " +
                            "user = readwrite; database = OptiTRAK;";
        DataTable dt;
        private string V3select1 = "";
        private string V3select2 = "";
        private string V3select3;
        private int snCount = 0;
        private string V3rowHeaders1;
        private string V3rowHeaders2;
        private string V3cte1;
        private string V3cte2;
        private int columnNo;
        DataRow newRow;
        DataTable dt1;
        DataTable dt2;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            cnxn2 = new SqlConnection(db);
            //DGV.ColumnCount = 4;
            //DGV.Columns[1].DividerWidth = 15;


            /*
            SqlCommand cmd = new SqlCommand(
                "Select partsn from tblpartSN where jobid = 432 " +
                " and partpoclosed = 0  order by dbo.sc_sortableversionstring(partsn)", cnxn);
            cnxn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                try
                {
                    snCount = snCount + 1;

                    if(V3select1 == "")
                    {
                        V3select1 = "with pn" + snCount.ToString() + " as (" +
                        "select  Title" + snCount.ToString() + ", " +
                        "Value"  + snCount.ToString() + " from ( select " +
                        "CAST(prodordnum as nvarchar(255)) SFO, " +
                        "CAST(CAST(PLDlvry as date) as nvarchar(255)) [Planned Delivery Date], " +
                        "CAST(CAST(Curr_req_dt as date) as nvarchar(255)) [Customer Request Date], " +
                        "CAST(CAST(orig_prom_dt as date) as nvarchar(255)) [Original Promise Date], " +
                        "CAST(CAST(ProjectedShipDate as date) as nvarchar(255)) [Projected Ship Date], " +
                        "CAST(CAST(partreleasedate as date) as nvarchar(255)) [Part Release Date], " +
                        "CAST(partsn as nvarchar(255)) [Part ID] , " +
                        "CAST(PartID as nvarchar(255)) PartID " +
                        "from tblPartSN p " +
                        "left join tblSalesOrder s on p.soid = s.soid " +
                        "inner join tblJobInfo j on p.jobid = j.jobid " +
                        "where partpoclosed = 0 " +
                        "and  j.JobComplete = 0 " +
                        "and p.JobID = 432 and p.PartSN = " + dr.GetString(0).Trim() + " )a " + 
                        "unpivot " +
                        "(Value"   + snCount.ToString() + " for Title" + snCount.ToString() + " in " +
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
                        "Value"  + snCount.ToString() + " from ( select " +
                        "CAST(prodordnum as nvarchar(255)) SFO, " +
                        "CAST(CAST(PLDlvry as date) as nvarchar(255)) [Planned Delivery Date], " +
                        "CAST(CAST(Curr_req_dt as date) as nvarchar(255)) [Customer Request Date], " +
                        "CAST(CAST(orig_prom_dt as date) as nvarchar(255)) [Original Promise Date], " +
                        "CAST(CAST(ProjectedShipDate as date) as nvarchar(255)) [Projected Ship Date], " +
                        "CAST(CAST(partreleasedate as date) as nvarchar(255)) [Part Release Date], " +
                        "CAST(partsn as nvarchar(255)) [Part ID] , " +
                        "CAST(PartID as nvarchar(255)) PartID " +
                        "from tblPartSN p " +
                        "left join tblSalesOrder s on p.soid = s.soid " +
                        "inner join tblJobInfo j on p.jobid = j.jobid " +
                        "where partpoclosed = 0 " +
                        "and  j.JobComplete = 0 " +
                        "and p.JobID = 432 and p.PartSN = " + dr.GetString(0).Trim() + " )a " + 
                        "unpivot " +
                        "(Value"   + snCount.ToString() + " for Title" + snCount.ToString() + " in " +
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

                    //select1 = "pn" + dr.GetString(0).Trim() + " as (" +
                    //    "select  Title" + dr.GetString(0).Trim() + "," +
                    //    "Value"  + dr.GetString(0).Trim() + " from ( select " +
                    //    "CAST(prodordnum as nvarchar(255)) SFO, " +
                    //    "CAST(CAST(PLDlvry as date) as nvarchar(255)) [Planned Delivery Date], " +
                    //    "CAST(CAST(Curr_req_dt as date) as nvarchar(255)) [Customer Request Date], " +
                    //    "CAST(CAST(orig_prom_dt as date) as nvarchar(255)) [Original Promise Date], " +
                    //    "CAST(CAST(ProjectedShipDate as date) as nvarchar(255)) [Projected Ship Date], " +
                    //    "CAST(CAST(partreleasedate as date) as nvarchar(255)) [Part Release Date], " +
                    //    "CAST(partsn as nvarchar(255)) [Part ID] , " +
                    //    "CAST(PartID as nvarchar(255)) PartID " +
                    //    "from tblPartSN p " +
                    //    "left join tblSalesOrder s on p.soid = s.soid " +
                    //    "inner join tblJobInfo j on p.jobid = j.jobid " +
                    //    "where partpoclosed = 0 " +
                    //    "and  j.JobComplete = 0 " +
                    //    "and p.JobID = 432 and p.PartSN = " + dr.GetString(0).Trim() + " )a " + 
                    //    "unpivot " +
                    //    "(Value"   + dr.GetString(0).Trim() + " for Title" + dr.GetString(0).Trim() + " in " +
                    //    "( " +
                    //    "SFO, " +
                    //    "[Planned Delivery Date], " +
                    //    "[Customer Request Date], " +
                    //    "[Original Promise Date], " +
                    //    "[Projected Ship Date], " +
                    //    "[Part Release Date], " +
                    //    "[Part ID] , " +
                    //    "PartID " +
                    //    "))b )";

                    //select1 = 
                    //    "select  Title" + dr.GetString(0).Trim() + ", " +
                    //    "Value" + dr.GetString(0).Trim() + " from ( select " +
                    //    "CAST(prodordnum as nvarchar(255)) SFO, " +
                    //    "CAST(CAST(PLDlvry as date) as nvarchar(255)) [Planned Delivery Date], " +
                    //    "CAST(CAST(Curr_req_dt as date) as nvarchar(255)) [Customer Request Date], " +
                    //    "CAST(CAST(orig_prom_dt as date) as nvarchar(255)) [Original Promise Date], " +
                    //    "CAST(CAST(ProjectedShipDate as date) as nvarchar(255)) [Projected Ship Date], " +
                    //    "CAST(CAST(partreleasedate as date) as nvarchar(255)) [Part Release Date], " +
                    //    "CAST(partsn as nvarchar(255)) [Part ID] , " +
                    //    "CAST(PartID as nvarchar(255)) PartID " +
                    //    "from tblPartSN p " +
                    //    "left join tblSalesOrder s on p.soid = s.soid " +
                    //    "inner join tblJobInfo j on p.jobid = j.jobid " +
                    //    "where " +
                    //    "p.JobID = 432 and p.PartSN = " + dr.GetString(0).Trim() + " " +
                    //    "and  j.JobComplete = 0 and partpoclosed = 0 " +
                    //    " )a " +
                    //    "unpivot " +
                    //    "(Value" + dr.GetString(0).Trim() + " for Title" + dr.GetString(0).Trim() + " in " +
                    //    "( " +
                    //    "SFO, " +
                    //    "[Planned Delivery Date], " +
                    //    "[Customer Request Date], " +
                    //    "[Original Promise Date], " +
                    //    "[Projected Ship Date], " +
                    //    "[Part Release Date], " +
                    //    "[Part ID] , " +
                    //    "PartID " +
                    //    "))b ";


                    
                    if (V3select2 != "")
                    {
                        V3select3 = V3select3 + "," + Environment.NewLine + V3select2;
                    }

                    //rowHeaders1 =
                    //            "[Title" + dr.GetString(0).Trim() + "]," +
                    //            "[Value" + dr.GetString(0).Trim() + "]," +
                    //            "[A" + dr.GetString(0).Trim() + "]," +
                    //            "[B" + dr.GetString(0).Trim() + "]," +
                    //            "[C" + dr.GetString(0).Trim() + "]," +
                    //            "[D" + dr.GetString(0).Trim() + "]," +
                    //            "[E" + dr.GetString(0).Trim() + "],";
                    V3rowHeaders1 =
                                "[Title" + snCount.ToString() + "]," +
                                "[Value" + snCount.ToString() + "]," +
                                "0 [A" + snCount.ToString() + "]," +
                                "0 [B" + snCount.ToString() + "]," +
                                "0 [C" + snCount.ToString() + "]," +
                                "0 [D" + snCount.ToString() + "]," +
                                "0 [E" + snCount.ToString() + "],";

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
                    MessageBox.Show(ex.ToString());
                }

                 //DataTable dt2 = new DataTable();
                //da.Fill(dt2);


            }

            //select3 = select3.Substring(1);
            V3rowHeaders2 = V3rowHeaders2.TrimEnd(',');

            cnxn = new SqlConnection(db);

            //don't need open connection if using Fill
            //cnxn.Open();

            //string ss = select1 + select3 + " select " + rowHeaders2 + " from pn1 " + cte2;

            SqlCommand next = new SqlCommand(
                V3select1 + V3select3 + " select " + V3rowHeaders2 + " from pn1 " + V3cte2, cnxn);
                //select1 + select3
                //"(" +
                //"select distinct " +
                //"d.DeptCode, " +
                //"w.OpNum, " +
                //"Description, " +
                //"CycleDays Cycle " +
                //"from uScheduleStatus ss " +
                //"inner join tblPartSN p on ss.PartID = p.PartID " +
                //"inner join tblWorkIns w on ss.WorkID = w.WorkID " +
                //"inner join tblDept d on w.DeptID = d.DeptID " +
                //"where partpoclosed = 0 " +
                //"and  " +
                //"p.JobID =  432 )" +
                //select2 + " " +
                //"select fr.opnum, deptcode, description, cycle, " + rowHeaders2 + " from  fr " + cte2 +
                //" order by opnum", cnxn);
               //, cnxn);
            

            SqlDataAdapter da = new SqlDataAdapter(next);

            //            cnxn.Close();
            */
          SqlDataAdapter da = new SqlDataAdapter(
                "select distinct " +
                "opnum, " +
                "DeptCode, " +
                "Description " +
                "from uScheduleStatus ss " +
                "inner join tblPartSN p on ss.PartID = p.PartID " +
                "inner join tblWorkIns w on ss.WorkID = w.WorkID " +
                "inner join tblDept d on w.DeptID = d.DeptID " +
                "where partpoclosed = 0 " +
                "and  " +
                "p.JobID = 245 order by opnum", cnxn);

            try
            {
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            int numberColumns = dt.Rows.Count;
            int numberRows = dt.Columns.Count;

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
                }
                else
                {
                    dt1.Rows[0][columnNo - 1] = rr.ItemArray[0].ToString();
                    dt1.Rows[1][columnNo - 1] = rr.ItemArray[1].ToString();
                    dt1.Rows[2][columnNo - 1] = rr.ItemArray[2].ToString();
                }
            }

/*
            //SqlCommand cmd = new SqlCommand("select COUNT(partsn) " +
            //    "from tblPartSN p " +
            //    "inner join tblJobInfo j on p.JobID = j.JobID " +
            //    "where partpoclosed = 0 and jobcomplete = 0 " +
            //    "and p.JobID = 245", cnxn);

  /*          //cnxn.Open();

            try
            {
                object o = cmd.ExecuteScalar();
                snCount = Convert.ToInt32(o);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

*/
            
             SqlCommand cmd = new SqlCommand(
                "Select partsn from tblpartSN where jobid = 245 " +
                " and partpoclosed = 0 order by dbo.sc_sortableversionstring(partsn)", cnxn);
            
            cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //cnxn.Close();

            //dt1 = new DataTable();

            while (dr.Read())
            {
                
                SqlDataAdapter da1 = new SqlDataAdapter(
                        "select " +
                        "ProdOrdNum, " +
                        "partsn, " +
                        "CurrentRecord, " +
                        "IIF(ProcessStatusID = 2, 'Complete', IIF(ProcessStatusID = 1, 'Active', 'Waiting')) ProcessStatusID, " +
                        "OpStart, " +
                        "OpNum, " +
                        "DueDate, " +
                        "CmpAdjDays, " +
                        "PlnDueDate " +
                        "from uScheduleStatus ss " +
                        "inner join tblPartSN p on ss.PartID = p.PartID " +
                        "inner join tblWorkIns w on ss.WorkID = w.WorkID " +
                        "inner join tblDept d on w.DeptID = d.DeptID " +
                        "where partpoclosed = 0 " +
                        //"and p.JobID = 245  and partsn = 1 " +
                        "and p.JobID = 245  and partsn = " + dr.GetString(0).Trim() +
                        "order by opnum", cnxn2);

                try
                {
                    dt = new DataTable();
                    da1.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                columnNo = 0;

                foreach (DataRow rr in dt.Rows)
                {
                    columnNo++;

                    //if (dt1.Columns.Count != dt.Rows.Count)
                    //{
                    //    dt1.Columns.Add((columnNo).ToString(), typeof(string));
                    //}

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
                        dt1.Rows[3 + (9 * snCount)][columnNo - 1] = rr.ItemArray[0].ToString();
                        dt1.Rows[4 + (9 * snCount)][columnNo - 1] = rr.ItemArray[1].ToString();
                        dt1.Rows[5 + (9 * snCount)][columnNo - 1] = rr.ItemArray[2].ToString();
                        dt1.Rows[6 + (9 * snCount)][columnNo - 1] = rr.ItemArray[3].ToString();
                        dt1.Rows[7 + (9 * snCount)][columnNo - 1] = rr.ItemArray[4].ToString();
                        dt1.Rows[8 + (9 * snCount)][columnNo - 1] = rr.ItemArray[5].ToString();
                        dt1.Rows[9 + (9 * snCount)][columnNo - 1] = rr.ItemArray[6].ToString();
                        dt1.Rows[10 + (9 * snCount)][columnNo - 1] = rr.ItemArray[7].ToString();
                        dt1.Rows[11 + (9 * snCount)][columnNo - 1] = rr.ItemArray[8].ToString();
                    }
                }

                snCount++;
            }
            
            //foreach (DataRow rr in dt.Rows)
            //{
            //    columnNo++;
            //    dt1.Rows[0].SetField(columnNo, rr.ItemArray[0].ToString());
            //    //dt1.Rows[0].SetField(columnNo, "text");
            //    //dt1.Rows[1].SetField(columnNo, rr.ItemArray[1].ToString());
            //    //dt1.Rows[2].SetField(columnNo, rr.ItemArray[2].ToString());
            //}

            //dt.Rows[1].SetField(0, (dt.Rows[0][0].ToString()));
            //dt.Rows[2].SetField(2, (dt.Rows[0][1].ToString()));
          


            
            //foreach (DataGridViewRow gr in DGV.Rows)
            //{
            //    foreach (DataGridViewCell sell in gr.Cells)
            //    {

            //        if (sell.Value.ToString().Trim() == "Complete")
            //        {
            //            DGV.Rows[gr.Index].Cells[sell.ColumnIndex + 2].Style.BackColor = Color.Gray;
            //            DGV.Rows[gr.Index].Cells[sell.ColumnIndex + 3].Style.BackColor = Color.Gray;
            //            DGV.Rows[gr.Index].Cells[sell.ColumnIndex + 4].Style.BackColor = Color.Gray;
            //            DGV.Rows[gr.Index].Cells[sell.ColumnIndex + 5].Style.BackColor = Color.Gray;
            //        }

            //        if (sell.Value.ToString().Trim() == "Current")
            //        {
            //            DGV.Rows[gr.Index].Cells[sell.ColumnIndex + 3].Style.BackColor = Color.Pink;
            //            DGV.Rows[gr.Index].Cells[sell.ColumnIndex + 4].Style.BackColor = Color.Pink;
            //            DGV.Rows[gr.Index].Cells[sell.ColumnIndex + 5].Style.BackColor = Color.Pink;
            //            DGV.Rows[gr.Index].Cells[sell.ColumnIndex + 6].Style.BackColor = Color.Pink;
            //        }
            //    }
            //}
            
            DGV.DataSource = dt1;
            DGV3.DataSource = dt1;




            //DGV.Columns[0].Frozen = true;
            //DGV must be generated prior to setting widths

            //divider width for every fourth column
            //for (int i = 10; i < (snCount * 7) + 5; i = i + 7)
            //{
            //    DGV.Columns[i].DividerWidth = 10;
            //}

            //for (int i = 4; i < (snCount * 7) + 4; i++)
            //{
            //    DGV.Columns[i].Width = 60;
            //}

            //DGV.Columns[0].Visible = false;
            //DGV.Columns[1].Visible = false;
            //DGV.Columns[2].Visible = false;
            //DGV.Columns[3].Visible = false;

            //for (int i = 4; i < (snCount * 7) + 4; i = i + 7)
            //{
            //    DGV.Columns[i].Visible = false;
            //}

            //for (int i = 5; i < (snCount * 7) + 4; i = i + 7)
            //{
            //    DGV.Columns[i].Visible = false;
            //}

            //for (int i = 6; i < (snCount * 7) + 4; i = i + 7)
            //{
            //    DGV.Columns[i].Visible = false;
            //}

            //foreach (DataGridViewRow gr in DGV.Rows)
            //{
            //    foreach (DataGridViewCell sell in gr.Cells)
            //    {

            //        if (sell.Value.ToString().Trim() == "Complete")
            //        {
            //            DGV.Rows[gr.Index].Cells[sell.ColumnIndex + 2].Style.BackColor = Color.Gray;
            //            DGV.Rows[gr.Index].Cells[sell.ColumnIndex + 3].Style.BackColor = Color.Gray;
            //            DGV.Rows[gr.Index].Cells[sell.ColumnIndex + 4].Style.BackColor = Color.Gray;
            //            DGV.Rows[gr.Index].Cells[sell.ColumnIndex + 5].Style.BackColor = Color.Gray;
            //        }

            //        if (sell.Value.ToString().Trim() == "Current")
            //        {
            //            DGV.Rows[gr.Index].Cells[sell.ColumnIndex + 3].Style.BackColor = Color.Pink;
            //            DGV.Rows[gr.Index].Cells[sell.ColumnIndex + 4].Style.BackColor = Color.Pink;
            //            DGV.Rows[gr.Index].Cells[sell.ColumnIndex + 5].Style.BackColor = Color.Pink;
            //            DGV.Rows[gr.Index].Cells[sell.ColumnIndex + 6].Style.BackColor = Color.Pink;
            //        }
            //    }
            //}

            DGV.Show();

            V3select1 = "";
            V3select2 = "";
            V3select3 = "";
            V3rowHeaders1 = "";
            V3rowHeaders2 = "";
            V3cte1 = "";
            V3cte2 = "";
            
        }

        //private void DGV_Scroll(object sender, ScrollEventArgs e)
        //{
        //    DGV3.FirstDisplayedScrollingColumnIndex = DGV.FirstDisplayedScrollingColumnIndex; 
        //}
    }
}
