using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace aaAdjustableShortageReview
{
    public partial class AdjustableReview : Form
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable table;
        DataTable selector;
        private int selectorNumber = -1;
        private string SQLselect;
        private bool changeFlag;
        private bool groupChangeFlag;
        private bool HotChangeFlag;
        private bool ActionChangeFlag;
        private bool ConfirmedChangeFlag;
        private bool RequiredChangeFlag;
        private bool WarDateChangeFlag;
        private bool OrigDueChangeFlag;
        private bool IQCCompleteChangeFlag;
        SqlConnection cnxn;
        SqlConnection NAVcnxn;
        SqlConnection cnxnDash;
        private string SqlSave;
        private int fontSize = 9;
        private string user;
        private string onOrder = string.Empty;
        private string nettableStock = string.Empty;
        private string nonnetStock = string.Empty;
        private string blockedStock = string.Empty;
        private string buyerPlanner = string.Empty;
        private string P6 = string.Empty;
        private string F6 = string.Empty;
        private string EAU = string.Empty;
        private string spend = string.Empty;
        private string Allocations = string.Empty;
        private string AllocationsF6 = string.Empty;
        private string Inspection = string.Empty;
        private string Shipper = string.Empty;


        public AdjustableReview()
        {
            InitializeComponent();
        }

        private void AdjustableReview_Load(object sender, EventArgs e)
        {
            /*
             *  the Assembly name on the properties page determines which 
             *  details will be used on the form
             * 
             */


            if (g.ProductLine == "PPS")
            {
                this.Text = "NAV PPS Shortages v" + Application.ProductVersion;
                this.BackColor = Color.FromArgb(40, 220, 120);
                Bnext.BackColor = Color.FromArgb(138, 188, 220);
                Bprevious.BackColor = Color.FromArgb(255, 120, 50);
                bArchive.BackColor = Color.FromArgb(180, 158, 192);
                bRefresh.BackColor = Color.FromArgb(150, 170, 192);
            }
            else if (g.ProductLine == "INST")
            {
                this.Text = "NAV INST Shortages v" + Application.ProductVersion;
                this.BackColor = Color.FromArgb(255, 240, 100);
                Bnext.BackColor = Color.FromArgb(128, 192, 128);
                Bprevious.BackColor = Color.FromArgb(255, 120, 50);
                bArchive.BackColor = Color.FromArgb(180, 158, 192);
                bRefresh.BackColor = Color.FromArgb(150, 170, 192);
            }
            else if (g.ProductLine == "OPT")
            {
                this.Text = "NAV OPTICS Shortages v" + Application.ProductVersion;
                this.BackColor = Color.FromArgb(100, 240, 255);
                Bnext.BackColor = Color.FromArgb(128, 192, 128);
                Bprevious.BackColor = Color.FromArgb(155, 250, 50);
                bArchive.BackColor = Color.FromArgb(180, 158, 192);
                bRefresh.BackColor = Color.FromArgb(150, 170, 192);
            }
            else if (g.ProductLine == "ZEOS")
            {
                this.Text = "NAV ZEOS Shortages v" + Application.ProductVersion;
                this.BackColor = Color.FromArgb(220, 100, 220);
                Bnext.BackColor = Color.FromArgb(228, 192, 128);
                Bprevious.BackColor = Color.FromArgb(255, 120, 50);
                bArchive.BackColor = Color.FromArgb(180, 180, 0);
                bRefresh.BackColor = Color.FromArgb(100, 200, 240);
            }
            else if (g.ProductLine == "WAR")
            {
                this.Text = "WARBOARD Shortages v" + Application.ProductVersion;
                this.BackColor = Color.FromArgb(220, 100, 100);
                Bnext.BackColor = Color.FromArgb(228, 192, 128);
                Bprevious.BackColor = Color.FromArgb(255, 120, 50);
                bArchive.BackColor = Color.FromArgb(180, 180, 0);
                bRefresh.BackColor = Color.FromArgb(100, 200, 240);
            }
            else if (g.ProductLine == "EPO")
            {
                this.Text = "NAV EPO Shortages v" + Application.ProductVersion;
                this.BackColor = Color.FromArgb(230, 102, 255);
                Bnext.BackColor = Color.FromArgb(128, 192, 128);
                Bprevious.BackColor = Color.FromArgb(155, 120, 50);
                bArchive.BackColor = Color.FromArgb(80, 180, 0);
                bRefresh.BackColor = Color.FromArgb(0, 200, 240);
            }

            dtpShipDate.Checked = false;
            //dtpShipDate.show

            if (g.task == "EDIT")
            {
                cnxn = new SqlConnection(g.db);

                SqlCommand cmd = new SqlCommand
                ("SELECT datearchived " +
                ",WhoArchived + ' on ' + CAST(DateArchived as nchar(19)) " +
                "FROM Shortage_List " +
                 "WHERE ID = " + g.ShortageID + " ", cnxn);
                cnxn.Open();
                cmd.CommandTimeout = 30;
                DataTable t = new DataTable();
                    
                SqlDataReader dr =  cmd.ExecuteReader();

                t.Load(dr);

                cnxn.Close();

                if (t.Rows[0][0].ToString().Length > 1)
                {
                    this.BackColor = Color.FromArgb(100, 100, 100);
                    LReason.Visible = false;
                    Lstatus.Text = "Status:  ALREADY ARCHIVED by " + t.Rows[0][1].ToString();
                    bArchive.Text = "Restore";
                    bArchive.BackColor = Color.Orange;
                }

                Bnext.Visible = false;
                Bprevious.Visible = false;
                LitemNumber.Visible = false;
                bRefresh.Visible = true;
                bRefresh.Text = "SAVE";
                bRefresh.BackColor = Color.FromArgb(180, 180, 128);

                GetData();
                RestoreAfterGroupChange();
            }
            else
            {
                bRefresh.Visible = false;
                firstLoad();
            }

            System.Security.Principal.WindowsIdentity userBase;
            userBase = System.Security.Principal.WindowsIdentity.GetCurrent();

            user = userBase.Name.ToUpper();

            if (userBase.Name.IndexOf("Z") == 0)
            {
                user = userBase.Name.Replace("ZYGOMIS\\", "");
            }
            else
            {
                user = userBase.Name.Replace("AMETEK-AD\\", "");
            }

            DGV_ShortageItem.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_Comments.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_History.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_ItemData.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_PLANNEDST.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_PROD.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_PURCH.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_RECEIPTS.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_TRACK_QC.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_TRACK_WH.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);

            DGV_ShortageItem.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGV_Comments.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGV_History.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGV_ItemData.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGV_PLANNEDST.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGV_PROD.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGV_PURCH.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGV_RECEIPTS.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGV_TRACK_QC.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGV_TRACK_WH.DefaultCellStyle.SelectionBackColor = Color.Yellow;

            DGV_ShortageItem.DefaultCellStyle.SelectionForeColor = Color.Black;
            DGV_Comments.DefaultCellStyle.SelectionForeColor = Color.Black;
            DGV_History.DefaultCellStyle.SelectionForeColor = Color.Black;
            DGV_ItemData.DefaultCellStyle.SelectionForeColor = Color.Black;
            DGV_PLANNEDST.DefaultCellStyle.SelectionForeColor = Color.Black;
            DGV_PROD.DefaultCellStyle.SelectionForeColor = Color.Black;
            DGV_PURCH.DefaultCellStyle.SelectionForeColor = Color.Black;
            DGV_RECEIPTS.DefaultCellStyle.SelectionForeColor = Color.Black;
            DGV_TRACK_QC.DefaultCellStyle.SelectionForeColor = Color.Black;
            DGV_TRACK_WH.DefaultCellStyle.SelectionForeColor = Color.Black;

            DGV_ShortageItem.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_Comments.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_History.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_ItemData.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_PLANNEDST.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_PROD.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_PURCH.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_RECEIPTS.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_TRACK_QC.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_TRACK_WH.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);

            DGV_ShortageItem.ColumnHeadersHeight = 34;
            DGV_ItemData.ColumnHeadersHeight = 34;
            DGV_PURCH.ColumnHeadersHeight = 34;
            DGV_PLANNEDST.ColumnHeadersHeight = 34;
            DGV_RECEIPTS.ColumnHeadersHeight = 34;
            DGV_PROD.ColumnHeadersHeight = 34;
            DGV_TRACK_QC.ColumnHeadersHeight = 34;
            DGV_TRACK_WH.ColumnHeadersHeight = 34;
        }

        private void firstLoad()
        {
            /*
             * 
             * this gets the list of ShortageIDs to be shown in the meeting in the order they need to be in.
             * 
             * SQL is the basic common selection
             * iqc allows for the two different tables needed to get the sort order correct 
             * order is similar to all but INST
             * 
             * */

            cnxn = new SqlConnection(g.db);

            string SQL = "SELECT " +
                          "l.ID " +
                          "FROM Shortage_List l " +
                          "INNER JOIN ShortageList_ActiveFlags f " +
                          "ON l.id = f.id " +
                          "WHERE ";

            string iqc = "COALESCE(itemstatus,'') != 'IQC' AND ";

            string order = "ORDER BY buyer, hot, sortgroup, lateflagsort, itemstatussort, productline, [group], itemcode, l.id";

            string SQL1 = string.Empty;

            
            if (g.ProductLine.ToUpper() == "INST")
            {
                SQL1 = SQL + iqc +
                    "productline = '" + g.ProductLine + "' AND ActionFlag = -1 and LateFlag != 'SOON DUE' " +
                    "ORDER BY buyer, instrumentoptic desc, hot, sortgroup, lateflagsort, itemstatussort, productline, [group], itemcode, l.id";
            }
            else if (g.ProductLine.ToUpper() == "OPT")
            {
                SQL1 = SQL + iqc +
                    "productline = '" + g.ProductLine + "' AND ActionFlag = -1 " + order;
            }
            else if (g.ProductLine.ToUpper() == "WAR")
            {
                SQL1 = SQL + iqc +
                    "productline = '" + g.ProductLine + "' AND ActionFlag = -1 " + order;
            }
            else
            {
                SQL1 = SQL + iqc +
                    "productline = '" + g.ProductLine + "' AND ActionFlag = -1 and LateFlag != 'SOON DUE' " + order;
            }

            
            try
            {
                cnxn.Open();
                cmd = new SqlCommand(SQL1, cnxn);
                //cmd.CommandTimeout = 30;
                SqlDataReader dr = cmd.ExecuteReader();
                selector = new DataTable();
                selector.Load(dr);
                /*  replace allows one query with two results  */
                SQL1 = SQL1.Replace("!= 'IQC'", "= 'IQC'");

                cmd = new SqlCommand(SQL1, cnxn);
                dr = cmd.ExecuteReader();
                DataTable selector1 = new DataTable();
                selector1.Load(dr);

                /* merge the second table after the first to get the IQC data last */
                selector.Merge(selector1);

                LitemNumber.Text = "1 of " + selector.Rows.Count.ToString();

                if (selector.Rows.Count > 0)
                {
                    //use Bnext to get data
                    Bnext.PerformClick();
                }
                else
                {
                    MessageBox.Show("No items in list");
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }
        }

        private void GetData()
        {
            cnxn = new SqlConnection(g.db);

            //SHORTAGE DATA

            cnxn.Open();

            SqlCommand cmd = new SqlCommand("SELECT DISTINCT " +
                " HOT " +
                ",FlagField " +
                ",CurrDueDate " + 
                ",PlannerRequiredDate " +
                ",f.lateflag " +
                ",ItemStatus" +
                ",ItemCode " +
                ",IQCCompleteDate " +
                ",Reason " +
                ",ShipmentTrackingNumber " +
                ",Shipper " +
                ",ProdOrder " +
                ",SalesOrder " +
                ",SOLineNo " +
                ",SODate " +
                ",ShipDate " +
                " FROM Shortage_List l " +
                "INNER JOIN Shortage_ActiveFlags f " +
                "ON l.id = f.id " +
                "WHERE l.ID = " + g.ShortageID + " "
                , cnxn);

            cmd.CommandTimeout = 30;
            SqlDataReader dr = cmd.ExecuteReader();

            DataTable tx = new DataTable();
            tx.Load(dr);

            dr = cmd.ExecuteReader();


            /*
             *  cnxn1.Open();
                dr1 = cmd.ExecuteReader();

                DataTable viewtable = new DataTable();
                viewtable.Load(dr1);

                dr1 = cmd.ExecuteReader();

             * */

            while (dr.Read())
            {
                if (dr.GetInt32(0) == -1)
                {
                    cbHot.Checked = true;
                }
                else
                {
                    cbHot.Checked = false;
                }

                if (dr.GetInt32(1) == -1)
                {
                    cbActionRqd.Checked = true;
                }
                else
                {
                    cbActionRqd.Checked = false;
                }

                if (!dr.IsDBNull(2))//current due date
                {
                    dtpCurrDueDate.Value = dr.GetDateTime(2);
                    SqlConnection cnxn3 = new SqlConnection(g.db);
                    SqlCommand cmd1 = new SqlCommand("UPDATE Shortage_List " +
                        "SET PreviousCurrDueDate = '" + dr.GetDateTime(2) + "' " +
                        "WHERE ID = " + g.ShortageID, cnxn3);
                    try
                    {
                        cnxn3.Open();
                        cmd1.CommandTimeout = 30;
                        cmd1.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn3.Close();
                    }
                }
                else
                {
                    dtpCurrDueDate.Text = "01-01-1900";
                }

                if (!dr.IsDBNull(3))//req date
                {
                    dtpRequiredDate.Value = dr.GetDateTime(3);
                }
                else
                {
                    dtpRequiredDate.Text = "01/01/1900";
                }

                if (!dr.IsDBNull(4))
                {
                    Lstatus.Text = "STATUS: " + dr.GetString(4).Trim();
                }
                else
                {
                    Lstatus.Text = "STATUS: ";
                }

                if (!dr.IsDBNull(5))    /*  Item Status */
                {
                    cbddItemStatus.Text = dr.GetString(5).Trim();

                    if (cbddItemStatus.Text == "IQC")
                    {
                        dtpIQCCompleteDate.Visible = true;
                        LIQCcompleteData.Visible = true;
                    }
                }
                else
                {
                    cbddItemStatus.Text = "";
                }

                if (!dr.IsDBNull(6))
                {
                    g.itemCode = dr.GetString(6).Trim();
                }
                else
                {
                    g.itemCode = "";
                }

                if (!dr.IsDBNull(7))//IQC date
                {
                    dtpIQCCompleteDate.Value = dr.GetDateTime(7);
                }
                else
                {
                    dtpIQCCompleteDate.Text = "01/01/1900";
                }

                if (!dr.IsDBNull(8))    /*  Reason */
                {
                    LReason.Text = "REASON:  " + dr.GetString(8).Trim().ToUpper();
                }
                else
                {
                    LReason.Text = "REASON:";
                    
                }

                cbddReason.Text = "";

                if (!dr.IsDBNull(9))    /*  Tracking Number */
                {
                    tbTrackingNumber.Text = dr.GetString(9).Trim();
                }
                else
                {
                    tbTrackingNumber.Text = "";
                }

                if (!dr.IsDBNull(10))    /*  Shipper  */
                {
                    Shipper = dr.GetString(10).Trim();
                }
                else
                {
                    Shipper = "";
                }

                if (!dr.IsDBNull(11))    /*  Production Order  */
                {
                    tbProdOrder.Text = dr.GetString(11).Trim();
                }
                else
                {
                    tbProdOrder.Text = string.Empty;
                }

                if (!dr.IsDBNull(12))    /*  Sales Order  */
                {
                    tbSalesOrder.Text = dr.GetString(12).Trim();
                }
                else
                {
                    tbSalesOrder.Text = string.Empty;
                }

                if (!dr.IsDBNull(13))    /*  SO Line No  */
                {
                    tbSOLineNo.Text = dr.GetString(13).Trim();
                }
                else
                {
                    tbSOLineNo.Text = string.Empty;
                }

                if (!dr.IsDBNull(14))    /*  Sales Order Date  */
                {
                    dtpSalesOrderDate.Text = dr.GetDateTime(14).ToShortDateString();
                }
                else
                {
                    dtpSalesOrderDate.Text = "01-01-2010";
                }

                if (!dr.IsDBNull(15))    /*  Ship Date  */
                {
                    dtpShipDate.Text = dr.GetDateTime(15).ToShortDateString();
                }
                else
                {
                    dtpShipDate.Text = "01-01-2010";
                }


            }
            cnxn.Close();

            //    COMMENTS

            try
            {
                string SQL = " SELECT " +
                    "  RTRIM(Comment) Comment " +
                    " ,RTRIM(EnteredBy) as [by] " +
                    " ,EnteredOn AS [Date of Change] " +
                    " FROM ShortageListComments " +
                    " WHERE ShortageID = " + g.ShortageID +
                    " ORDER BY CommentID  DESC";

                if (cnxn.State == ConnectionState.Closed)
                {
                    cnxn.Open();
                }

                cmd = new SqlCommand(SQL, cnxn);
                cmd.CommandTimeout = 30;

                dr = cmd.ExecuteReader();
                
                table = new DataTable();
                table.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            DGV_Comments.DataSource = table;
            DGV_Comments.Show();
            DGV_Comments.Columns[0].MinimumWidth = 400;
            DGV_Comments.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGV_Comments.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGV_Comments.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            


            //shortage item dgv

            try
            {
                string SQL =
                    "SELECT " +
                    " ID " +
                    ",[Group] " +
                    ",StkOut AS [Stk Out]" +
                    ",qtyNeeded AS [Qty Rqd]" +
                    ",CONVERT(varchar,DateAddedToList,1) AS [List Date]" +
                    ",DATEDIFF(D, DateAddedtoList, GETDATE()) AS [Days on List]" +
                    ",[Custom Item] " +
                    ",PO AS [PO/WO]" +
                    ",Qty [PO Qty] " +
                    ",WarBoardDate As [War Date]" +
                    ",whoAdded AS [By] " +
                    ",Project [Job No.]" +
                    ",projectdesc AS [Proj Description]" +
                    ",Supplier as Vendor" +
                    ",Buyer " +
                    ",CONVERT(varchar,[Orig_ Requested Receipt Date],1) [Orig_ Requested Receipt Date] " +
                    ",COALESCE(CONVERT(varchar,PlannedReceiptDate,1),'') PlannedReceiptDate" +
                    " from shortage_list where id = " + g.ShortageID;

                if (cnxn.State == ConnectionState.Closed)
                {
                    cnxn.Open();
                }

                cmd = new SqlCommand(SQL, cnxn);
                

                dr = cmd.ExecuteReader();
                cmd.CommandTimeout = 30;

                table = new DataTable();
                table.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            DGV_ShortageItem.DataSource = table;
            DGV_ShortageItem.Show();
            DGV_ShortageItem.Columns[0].MinimumWidth = 40;
            DGV_ShortageItem.Columns[0].FillWeight = 3;
            DGV_ShortageItem.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ShortageItem.Columns[1].MinimumWidth = 40;
            DGV_ShortageItem.Columns[1].FillWeight = 4;
            DGV_ShortageItem.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ShortageItem.Columns[2].MinimumWidth = 30;
            DGV_ShortageItem.Columns[2].FillWeight = 3;
            DGV_ShortageItem.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ShortageItem.Columns[3].MinimumWidth = 25;
            DGV_ShortageItem.Columns[3].FillWeight = 2;
            DGV_ShortageItem.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ShortageItem.Columns[4].MinimumWidth = 45;
            DGV_ShortageItem.Columns[4].FillWeight = 5;
            DGV_ShortageItem.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ShortageItem.Columns[5].MinimumWidth = 40;
            DGV_ShortageItem.Columns[5].FillWeight = 4;
            DGV_ShortageItem.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ShortageItem.Columns[6].MinimumWidth = 40;
            DGV_ShortageItem.Columns[6].FillWeight = 8;
            DGV_ShortageItem.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ShortageItem.Columns[7].MinimumWidth = 40;
            DGV_ShortageItem.Columns[7].FillWeight = 5;
            DGV_ShortageItem.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ShortageItem.Columns[8].MinimumWidth = 25;
            DGV_ShortageItem.Columns[8].FillWeight = 4;
            DGV_ShortageItem.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ShortageItem.Columns[9].MinimumWidth = 45;
            DGV_ShortageItem.Columns[9].FillWeight = 4;
            DGV_ShortageItem.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ShortageItem.Columns[10].MinimumWidth = 40;
            DGV_ShortageItem.Columns[10].FillWeight = 2;
            DGV_ShortageItem.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ShortageItem.Columns[11].MinimumWidth = 40;
            DGV_ShortageItem.Columns[11].FillWeight = 3;
            DGV_ShortageItem.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ShortageItem.Columns[12].MinimumWidth = 80;
            DGV_ShortageItem.Columns[12].FillWeight = 5;
            DGV_ShortageItem.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ShortageItem.Columns[13].MinimumWidth = 100;
            DGV_ShortageItem.Columns[13].FillWeight = 4;
            DGV_ShortageItem.Columns[14].MinimumWidth = 50;
            DGV_ShortageItem.Columns[14].FillWeight = 8;
            //DGV_ShortageItem.Columns[15].Visible = false;
            DGV_ShortageItem.Columns[15].MinimumWidth = 60;
            DGV_ShortageItem.Columns[15].FillWeight = 8;
            DGV_ShortageItem.Columns[16].Visible = false;
            //DGV_ShortageItem.Columns[16].MinimumWidth = 60;
            //DGV_ShortageItem.Columns[16].FillWeight = 4;
            //DGV_ShortageItem.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //DGV_ShortageItem.Columns[17].Visible = false;
            //DGV_ShortageItem.Columns[17].MinimumWidth = 60;
            //DGV_ShortageItem.Columns[17].FillWeight = 4;
            //DGV_ShortageItem.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //DGV_ShortageItem.Columns[18].MinimumWidth = 70;
            //DGV_ShortageItem.Columns[18].FillWeight = 5;

            /*
             * 
             * Highlight item if SER
             * need to check length to not get error if less than 3
             * 
             * */
            if (table.Rows[0][1].ToString().Length > 2 &&
                table.Rows[0][1].ToString().ToUpper().Substring(0, 3) == "SER")
            {
                if ((table.Rows[0][1].ToString().Length > 3 && table.Rows[0][1].ToString().ToUpper().Substring(3, 1) != "V") | table.Rows[0][1].ToString().Length == 3)
                {
                    DGV_ShortageItem.DefaultCellStyle.BackColor = Color.FromArgb(0, 200, 255);
                }
            }
            else
            {
                DGV_ShortageItem.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
            }

            string POitem = string.Empty;

            cnxn = new SqlConnection(g.db);

            cmd = new SqlCommand
            ("SELECT itemcode FROM Shortage_List " +
             "WHERE ID = " + g.ShortageID + " ", cnxn);
            cnxn.Open();
            cmd.CommandTimeout = 30;
            object o = cmd.ExecuteScalar();
            cnxn.Close();

            if (o.ToString().Length > 1)
            {
                POitem = o.ToString();
            }

            NAVcnxn = new SqlConnection(g.dbNAV);


            /*  Nettable stock  */

            SqlCommand loopCmd = new SqlCommand
                ("SELECT " +
                "COALESCE(FORMAT(SUM([Quantity]),'N0'), '0') " +
                "FROM [" + g.NAVprefix + "Item Ledger Entry] " +
                "WHERE [Non-Nettable] = 0 " +
                "and [Item No_] = '" + POitem + "' "
                , NAVcnxn);

            object nn = "";

            try
            {
                NAVcnxn.Open();
                loopCmd.CommandTimeout = 30;
                nn = loopCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                NAVcnxn.Close();
            }

            if (nn == null)
            {
                MessageBox.Show("This item does not exist.");
            }
            else
            {
                nettableStock = nn.ToString();
            }



            /*  Non-Nettable stock  */

            loopCmd = new SqlCommand
                ("SELECT " +
                "COALESCE(FORMAT(SUM([Quantity]),'N0'), '0') " +
                "FROM [" + g.NAVprefix + "Item Ledger Entry] " +
                "WHERE [Non-Nettable] = 1 " +
                "and [Item No_] = '" + POitem + "' "
                , NAVcnxn);

            nn= "";

            try
            {
                NAVcnxn.Open();
                loopCmd.CommandTimeout = 30;
                nn = loopCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                NAVcnxn.Close();
            }

            if (nn == null)
            {
                MessageBox.Show("This item does not exist.");
            }
            else
            {
                nonnetStock = nn.ToString();
            }

            /*  stock on order  */

            loopCmd = new SqlCommand
            ("SELECT " +
                "COALESCE(FORMAT(SUM(L.[Outstanding Quantity]),'N0'), '0') " +
                "FROM [" + g.NAVprefix + "Purchase Line] L " +
                "INNER JOIN [" + g.NAVprefix + "Item] I ON L.No_ = I.No_ " +
                "WHERE " + //([Replenishment System] = 0 and "
                "[Outstanding Quantity] > 0 AND L.No_ = '" + POitem + "' "
                , NAVcnxn);


            object p = "";

            try
            {
                NAVcnxn.Open();
                loopCmd.CommandTimeout = 30;
                p = loopCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                NAVcnxn.Close();
            }


            if (p == null)
            {
                MessageBox.Show("This item does not exist.");
            }
            else
            {
                onOrder = p.ToString();
            }


            /*  blocked stock   */


            loopCmd = new SqlCommand
                ("SELECT " +
                "COALESCE(FORMAT(SUM([Quantity]),'N0'), '0') " +
                "FROM [" + g.NAVprefix + "Warehouse Entry] " +
                "WHERE [Bin Code] like '%IQC%' " +
                "and [Item No_] = '" + POitem + "' "
                , NAVcnxn);

            object b = "";

            try
            {
                NAVcnxn.Open();
                loopCmd.CommandTimeout = 30;
                b = loopCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                NAVcnxn.Close();
            }

            if (b == null)
            {
                //MessageBox.Show("This item does not exist.");
            }
            else
            {
                blockedStock = b.ToString();
            }



            /*
             * 
             *  Allocated
             *  
             * */

            /*  Production Order Components  

                    Firm Planned and Released
                    Quantity goes back to required quantity on BOM
                    Remaining Quantity reflects what is needed for this order
            */

            loopCmd = new SqlCommand
               ("SELECT " +
                "COALESCE(SUM([Remaining Quantity]), 0) " +
                "FROM [" + g.NAVprefix + "Prod_ Order Component] " +
                "WHERE 1=1 " +
                "AND Status in (2, 3) " +
                "and [Item No_] = '" + POitem + "' "
               , NAVcnxn);

            object AS1 = 0;

            try
            {
                NAVcnxn.Open();
                loopCmd.CommandTimeout = 30;
                AS1 = loopCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                NAVcnxn.Close();
            }

            /*  Sales Orders */

            loopCmd = new SqlCommand
               ("SELECT " +
               "COALESCE(SUM([Quantity]), 0) " +
               "FROM [" + g.NAVprefix + "Sales Line] " +
               "WHERE 1=1 " + //[Posting Date] >= (GETDATE() + 183) " +
               "AND Type = 2 AND [Completely Shipped] = 0 " +
               "and [No_] = '" + POitem + "' "
               , NAVcnxn);

            object AS2 = 0;

            try
            {
                NAVcnxn.Open();
                loopCmd.CommandTimeout = 30;
                AS2 = loopCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                NAVcnxn.Close();
            }


            /*  Service Orders */

            loopCmd = new SqlCommand
               ("SELECT " +
               "COALESCE(SUM([Quantity]), 0) " +
               "FROM [" + g.NAVprefix + "Service Line] " +
               "WHERE 1=1 " + //[Posting Date] >= (GETDATE() + 183) " +
                              //"AND ([Entry Type] = 1 OR [Entry Type] = 5) " +
               "and [No_] = '" + POitem + "' "
               , NAVcnxn);

            object AS3 = 0;

            try
            {
                NAVcnxn.Open();
                loopCmd.CommandTimeout = 30;
                AS3 = loopCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                NAVcnxn.Close();
            }


            /*  Job - Inventory Requests */

            loopCmd = new SqlCommand
               ("SELECT " +
               "COALESCE(SUM([Quantity]), 0) " +
               "FROM [" + g.NAVprefix + "Job Journal Line] " +
               "WHERE 1=1 " + //[Posting Date] >= (GETDATE() + 183) " +
               "AND [Journal Template Name] = 'INVREQ' " +
               "and [No_] = '" + POitem + "' "
               , NAVcnxn);

            object AS4 = 0;

            try
            {
                NAVcnxn.Open();
                loopCmd.CommandTimeout = 30;
                AS4 = loopCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                NAVcnxn.Close();
            }



            Allocations = string.Format("{0:0}", (Convert.ToDouble(AS1) + Convert.ToDouble(AS2) + Convert.ToDouble(AS3) + Convert.ToDouble(AS4)));


            
            //    //ITEM DATA

            try
            {
                string SQL = 
                    "select distinct " +
                    "  No_ AS [ITEM NO] " +
                    " ,Description AS [DESCRIPTION] " +
                    " ,FORMAT([Safety Stock Quantity], 'N0') AS [SF STK] " +
                    " ,FORMAT([Reorder Point], 'N0') AS REORD " +
                     ",CASE  WHEN LEN([Lead Time Calculation]) = 0 THEN '0' " +
                        "      WHEN CHARINDEX(CHAR(3),[Lead Time Calculation]) > 0 " +
                        "           THEN REPLACE([Lead Time Calculation], CHAR(3), '') " +
                        "    WHEN CHARINDEX(CHAR(4),[Lead Time Calculation]) > 0 THEN " + // --week 
                        "       REPLACE([Lead Time Calculation], CHAR(4), '') * 5	" +       //--convert to days 
                        "    WHEN CHARINDEX(CHAR(5),[Lead Time Calculation]) > 0 THEN " + // --month 
                        "       REPLACE([Lead Time Calculation], CHAR(5), '') * 20	" +       //--convert to days 
                        "   WHEN CHARINDEX(CHAR(2),[Lead Time Calculation]) > 0 THEN " +      //-- days 
                        "       REPLACE([Lead Time Calculation], CHAR(2), '')		" +
                        "END [LT] " + 
                        ",[Supplier Replenishment] [RPL TM]" +
                    " ,FORMAT([Reorder Quantity], 'N0') AS [BIN SZ] " +
                    " ,FORMAT([Standard Cost], 'C') AS [STD COST]" +
                    ", CASE " +
                        "WHEN [MPS Item] = 0 THEN 'MRP' " +
                        "WHEN [MPS Item] = 1 THEN 'MPS' " +
                    " END AS [O SYS] " +
                    " ,[Signal Code] " +
                    " , P6 " +
                    " , F6 " +
                    " ,EAU " +
                    " FROM [" + g.NAVprefix + "Item] " +
                    " WHERE [No_] = '" + POitem + "'";


                if (NAVcnxn.State == ConnectionState.Closed)
                {
                    NAVcnxn.Open();
                }

                cmd = new SqlCommand(SQL, NAVcnxn);
                cmd.CommandTimeout = 30;

                dr = cmd.ExecuteReader();

                table = new DataTable();
                table.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                NAVcnxn.Close();
            }

            DataTable dtItem = new DataTable();
            dtItem.Columns.Add("Item Code", typeof(string));
            dtItem.Columns.Add("Description", typeof(string));
            dtItem.Columns.Add("STK OH", typeof(string));
            dtItem.Columns.Add("STK OO", typeof(string));
            dtItem.Columns.Add("ALO", typeof(string));
            dtItem.Columns.Add("BLK STK", typeof(string));
            dtItem.Columns.Add("NON NET", typeof(string));
            dtItem.Columns.Add("P6 ISS", typeof(string));
            dtItem.Columns.Add("F6", typeof(string));
            dtItem.Columns.Add("EAU", typeof(string));
            dtItem.Columns.Add("SFE STK", typeof(string));
            dtItem.Columns.Add("RE ORD", typeof(string));
            dtItem.Columns.Add("VEND LT", typeof(string));
            dtItem.Columns.Add("REPL TM", typeof(string));
            dtItem.Columns.Add("BIN SZ", typeof(string));
            dtItem.Columns.Add("O SYS", typeof(string));
            dtItem.Columns.Add("SIG CODE", typeof(string));
            dtItem.Columns.Add("STD COST", typeof(string));

            try
            {
                dtItem.Rows.Add(
                     table.Rows[0][0].ToString()
                    , table.Rows[0][1].ToString()
                    , nettableStock
                    , onOrder
                    , Allocations
                    , blockedStock
                    , nonnetStock
                    , table.Rows[0][10].ToString()
                    , table.Rows[0][11].ToString()
                    , table.Rows[0][12].ToString()
                    , table.Rows[0][2].ToString()
                    , table.Rows[0][3].ToString()
                    , table.Rows[0][4].ToString()
                    , table.Rows[0][5].ToString()
                    , table.Rows[0][6].ToString()
                    , table.Rows[0][8].ToString()
                    , table.Rows[0][9].ToString()
                    , table.Rows[0][7].ToString()
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show( POitem + "  is not a standard part.\n\n\n" + ex.ToString());
            }



            DGV_ItemData.DataSource = dtItem;
            DGV_ItemData.Show();
            DGV_ItemData.Columns[0].MinimumWidth = 110;
            DGV_ItemData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[1].MinimumWidth = 250;
            DGV_ItemData.Columns[2].MinimumWidth = 25;
            DGV_ItemData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[3].MinimumWidth = 25;
            DGV_ItemData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[4].MinimumWidth = 25;
            DGV_ItemData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[5].MinimumWidth = 25;
            DGV_ItemData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[6].MinimumWidth = 25;
            DGV_ItemData.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[7].MinimumWidth = 25;
            DGV_ItemData.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[8].MinimumWidth = 25;
            DGV_ItemData.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[9].MinimumWidth = 25;
            DGV_ItemData.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[10].MinimumWidth = 25;
            DGV_ItemData.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[11].MinimumWidth = 25;
            DGV_ItemData.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[12].MinimumWidth = 25;
            DGV_ItemData.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[13].MinimumWidth = 25;
            DGV_ItemData.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[14].MinimumWidth = 25;
            DGV_ItemData.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[15].MinimumWidth = 25;
            DGV_ItemData.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[16].MinimumWidth = 25;
            DGV_ItemData.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[17].MinimumWidth = 90;
            DGV_ItemData.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV_ItemData.Columns[0].FillWeight = 7;
            DGV_ItemData.Columns[1].FillWeight = 16;
            

            
            //    //PLANNED STOCK TRANSACTIONS
            try
            {
                string SQL =
                "with S1 as " +
                "( select " +
                " c.[Item No_] " +
                ", l.[Starting Date] [TRANS DT] " +
                ",c.[Remaining Quantity] [PLN QTY] " +
                ", 'DEMAND' as [TRANS TYPE] " +
                ", 'Production Order' as [Ord Type] " +
                ",l.[Prod_ Order No_] [ORDER #] " +
                ",c.[Line No_] POS " +
                ",l.[Item No_] AS [NxL Item Code] " +
                ",l.[Job No_] " +
                " FROM " +
                " [" + g.NAVprefix + "Prod_ Order Line] l " +
                " INNER JOIN [" + g.NAVprefix + "Prod_ Order Component] c ON l.[Prod_ Order No_] = c.[Prod_ Order No_] " +
                " WHERE " +
                " c.[Item No_] = '" + g.itemCode + "' " +
                " AND c.[Remaining Quantity] > 0 " +
                " AND c.Status in (2,3) " +
                " UNION " +
                " SELECT " +
                " No_ [Item No_] " +
                " , [Expected Receipt Date] " +
                " , [Outstanding Quantity] " +
                " , 'SUPPLY' " +
                " , 'Purchase Order' " +
                " , [Document No_]  " +
                " , [PO Line No_]  " +
                " , '' " +
                " ,[Job No_] " +
                " FROM [" + g.NAVprefix + "Purchase Line] WHERE No_ = '" + g.itemCode + "' " +
                " AND [Outstanding Quantity] > 0" +
                "UNION " +
                " SELECT " +
                "    No_ " +
                "    ,[Due Date] [TRANS DT] " +
                "	,[Quantity] " +
                "	,'DEMAND' as [TRANS TYPE] " +
                "	,'Job Inventory Request' as [Ord Type] " +
                "	,[Document No_] " +
                "	,[Line No_] " +
                "	,'' AS[NxL Item Code] " +
                "	,[Job No_] " +
                " FROM[ZYGO$Job Journal Line] " +
                " WHERE " +
                "    [Journal Template Name] = 'INVREQ' " +
                "    AND[No_] = '" + g.itemCode + "' " +
                "), " +
                " S2 as " +
                " ( " +
                " SELECT COALESCE(FORMAT(SUM([Quantity]),'N0', 'en-us'), '0') OH " +
                ",e.[Item No_] " +
                " FROM [" + g.NAVprefix + "Item Ledger Entry] e " +
                " WHERE [Item No_] IN (SELECT [NxL Item Code] FROM S1) " +
                " GROUP BY e.[Item No_] " +
                ") " +
                " SELECT " +
                " CONVERT (Varchar(8), [TRANS DT], 1) [TRANS DT] " +
                " , FORMAT([PLN QTY], 'N0') [PLN QTY] " +
                "  ,[TRANS TYPE] " +
                " ,[Job No_] [JOB NO] " +
                " ,CASE " +
                "	    WHEN [TRANS TYPE] = 'DEMAND' THEN FORMAT(([PLN QTY] * -1), 'n0') " +
                " 	    ELSE FORMAT([PLN QTY], 'n0') " +
                "  END AS [INV CHG] " +
                ",[Ord Type] [ORD TYPE] " +
                ",[ORDER #] " +
                ",POS " +
                ",[NxL Item Code] [NxL ITEM CODE] " +
                ", COALESCE(OH,  '0') OH " +
                " FROM S1 LEFT JOIN S2 on S1.[NxL Item Code] = S2.[Item No_] " +
                " ORDER BY S1.[TRANS DT] ";
                      
                if (NAVcnxn.State == ConnectionState.Closed)
                {
                    NAVcnxn.Open();
                }

                cmd = new SqlCommand(SQL, NAVcnxn);

                /*      wait time in seconds    */

                cmd.CommandTimeout = 30;
                dr = cmd.ExecuteReader();

                table = new DataTable();
                table.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                NAVcnxn.Close();
            }

            
            DGV_PLANNEDST.DataSource = table;
            DGV_PLANNEDST.Show();
            DGV_PLANNEDST.Columns[0].Width = 40;
            DGV_PLANNEDST.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PLANNEDST.Columns[1].Width = 30;
            DGV_PLANNEDST.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PLANNEDST.Columns[2].Width = 50;
            DGV_PLANNEDST.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PLANNEDST.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PLANNEDST.Columns[3].Width = 40;
            DGV_PLANNEDST.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PLANNEDST.Columns[4].Width = 30;
            DGV_PLANNEDST.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PLANNEDST.Columns[5].Width = 70;
            DGV_PLANNEDST.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PLANNEDST.Columns[6].Width = 40;
            DGV_PLANNEDST.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PLANNEDST.Columns[7].Width = 40;
            DGV_PLANNEDST.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PLANNEDST.Columns[8].Width = 60;
            DGV_PLANNEDST.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PLANNEDST.Columns[9].Width = 40;
            DGV_PLANNEDST.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            

            //    //HISTORY

            try
            {
                string SQL =
                    "select " +
                    "  LogDate AS [Date of Change] " +
                    " ,ConfDueDateValue AS Value " +
                    " FROM Shortage_ConfDueDate_Change_Log " +
                    " WHERE ShortageID = " + g.ShortageID +
                    " ORDER BY LogDate DESC";

                if (cnxn.State == ConnectionState.Closed)
                {
                    cnxn.Open();
                }

                cmd = new SqlCommand(SQL, cnxn);

                cmd.CommandTimeout = 30;
                dr = cmd.ExecuteReader();

                table = new DataTable();
                table.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            DGV_History.DataSource = table;
            DGV_History.Show();
            DGV_History.Columns[0].Width = 100;
            DGV_History.Columns[1].Width = 100;



            //    //OPEN PURCHASE ORDERS GRID 1

            
            try
            {
                string SQL =
                    "WITH s1 as " +
                    "( SELECT " +
                    "  [Document No_] ORDER_NO " +
                    " ,[PO Line No_] POSITION " +
                    " , CASE " +
                    "     WHEN [Orig_ Promised Receipt Date] = '1753-01-01 00:00:00.000' " +
                    "          THEN DATEDIFF(d, GETDATE(), [Promised Receipt Date]) " +
                    "     WHEN[Orig_ Promised Receipt Date] > '1753' " +
                    "          THEN DATEDIFF(d, GETDATE(), [Orig_ Promised Receipt Date]) " +
                    "   END AS POLineDaysTillDue " +
                    " FROM [" + g.NAVprefix + "Purchase Line] WHERE [Document Type] = 1 )" +
                    ", S2 as ( SELECT ORDER_NO, POSITION, POLineDaysTillDue " +
                    ", CASE WHEN POLineDaysTillDue <= 0 THEN null " +
                    "  WHEN POLineDaysTillDue > 0 THEN POLineDaysTillDue " +
                    "  END as POLineDaysEarly " +
                    " ,CASE WHEN POLineDaysTillDue <= 0 THEN(-1 * POLineDaysTillDue) " +
                    "  WHEN POLineDaysTillDue > 0 THEN null " +
                    "  END as POLineDaysLate FROM s1 ) " +
                    " select DISTINCT p.[Document No_][PO #] " +
                    ", p.[PO Line No_] LN " +
                    ", CONVERT (Varchar(8), p.[Requested Receipt Date], 1) [RQST RCPT DT] " + 
                    ", CONVERT (Varchar(8),p.[Promised Receipt Date], 1) [PROM RCPT DT] " +
                    ", CONVERT (Varchar(8),p.[Expected Receipt Date], 1) [EXPECT DT]" +
                    ", FORMAT(p.Quantity, '##0') [ORD QTY] " +
                    ", FORMAT(p.[Quantity Received], '##0') [DEL QTY] " +
                    ", FORMAT(p.[Outstanding Quantity], '##0') [BO QTY]" +
                    " , CONVERT (Varchar(8),p.[Order Date], 1) [ORD DT] " +
                    ", p.[Job No_] PROJ " +
                    ", j.[Description] [PROJ DESC] " +
                    ", p.[Prod_ Order No_] [PROD ORD], " +
                    "p.[Buy-from Vendor No_] SUPPLIER, " +
                    "s.[Name] as [Supplier Name]" +
                    ", CASE WHEN POLineDaysLate > 0 THEN 'LATE' WHEN POLineDaysLate <= 0 THEN '' END as [STA TUS] " +
                    ", CASE WHEN p.[Inspection Code] = 'I' THEN 'Y' WHEN p.[Inspection Code] <> 'I' THEN 'N' " +
                    " END [INS RQD] " +
                    ", p.[Inspection Code][Insp Code] " +
                    ", s.Contact SALES_REFERENCE " +
                    ", s.[Phone No_] TELEPHONE " +
                    ", s.[E-Mail] EMAIL " +
                    ", p.[Promised Receipt Date] " +
                    " FROM[" + g.NAVprefix + "Purchase Line] p " +
                    " LEFT JOIN S2 on S2.ORDER_NO = p.[Document No_] and  S2.POSITION = p.[PO Line No_]" +
                    " LEFT JOIN[" + g.NAVprefix + "Vendor] s ON p.[Buy-from Vendor No_] = s.No_ " +
                    " LEFT JOIN[" + g.NAVprefix + "Job] j ON p.[Job No_] = j.No_ " +
                    " WHERE [Document Type] = 1 AND [Quantity Received] <> Quantity AND p.[No_] = '" + POitem + "'" + 
                    " ORDER BY [Promised Receipt Date] ";

                if (NAVcnxn.State == ConnectionState.Closed)
                {
                    NAVcnxn.Open();
                }

                cmd = new SqlCommand(SQL, NAVcnxn);

                cmd.CommandTimeout = 30;
                dr = cmd.ExecuteReader();

                table = new DataTable();
                table.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            DGV_PURCH.DataSource = table;
            DGV_PURCH.Show();
            //DGV_PURCH.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGV_PURCH.Columns[0].MinimumWidth = 60;//0
            DGV_PURCH.Columns[1].MinimumWidth = 25;
            DGV_PURCH.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV_PURCH.Columns[2].MinimumWidth = 60;
            DGV_PURCH.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[3].MinimumWidth = 60;
            DGV_PURCH.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[4].MinimumWidth = 60;
            DGV_PURCH.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[5].Width = 30;//5
            DGV_PURCH.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[6].Width = 30;
            DGV_PURCH.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[7].Width = 30;
            DGV_PURCH.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[8].MinimumWidth = 60;
            DGV_PURCH.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[9].Width = 40; //project
            DGV_PURCH.Columns[10].Width = 60;//10
            DGV_PURCH.Columns[11].Width = 40;
            DGV_PURCH.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[12].Width = 40;
            DGV_PURCH.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGV_PURCH.Columns[14].Width = 40;
            DGV_PURCH.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[15].Width = 30;
            DGV_PURCH.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[16].Width = 40;
            DGV_PURCH.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[17].Width = 80;
            DGV_PURCH.Columns[18].MinimumWidth = 60;
            DGV_PURCH.Columns[19].Visible = false;
            DGV_PURCH.Columns[20].Visible = false;
            DGV_PURCH.Columns[15].Visible = false;  /* ins rqd field not needed  */


            //    //RECEIPTS awaiting QC

            try
            {
                            da = new SqlDataAdapter(
                                "SELECT " +
                                " Order_No PO " +
                                ",Position_Number POS " +
                                ", CONVERT (Varchar(8),[ReceivedDate], 1)[DT RCVD] " +
                                ", ReceivedQty[DEL QTY] " +
                                ", FORMAT(Quantity, 'N0')[Qty @QC] " +
                                ", MkReceiptTransactionID[TRKR ID] " +
                                ", ReceiptNumber RCPT " +
                                ", QualityInspectorAssigned INSPR " +
                                ", FORMAT(QualityPriority, 'N0') PRI " +
                                " FROM [Local_Dash_NAV_Receipts] r " +
                                " left join[Shortage NAV Warehouse Entry] S1 on " +
                                " s1.[Item No_] = r.PartNumber " +
                                " and s1.[Source No_] = r.Order_no " +
                                " and(s1.[Source Line No_] / 1000) = r.Position_Number " +
                                "WHERE " +
                                "(MKReceiptTransactionID in " +
                                "(select distinct MKReceiptTransactionID from Local_Dash_View_Tracking " +
                                "where MovedToDate > (GETDATE() - 365) " +
                                "AND MovedOutDate is null)) " +
                                "AND Quantity > 0 and [Bin Code] like '%IQC%' " +
                                "AND [PartNumber] = '" + POitem + "' ORDER BY ReceivedDate", cnxn);
                            table = new DataTable();
                            da.SelectCommand.CommandTimeout = 30;
                            da.Fill(table);
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            cnxn.Close();
                        }

                        DGV_RECEIPTS.DataSource = table;
                        DGV_RECEIPTS.Show();
                        DGV_RECEIPTS.Columns[0].Width = 60;
                        DGV_RECEIPTS.Columns[1].Width = 30;
                        DGV_RECEIPTS.Columns[2].Width = 50;
                        DGV_RECEIPTS.Columns[3].Width = 40;
                        DGV_RECEIPTS.Columns[4].Width = 40;
                        DGV_RECEIPTS.Columns[5].Width = 40;
                        DGV_RECEIPTS.Columns[6].Width = 40;
                        DGV_RECEIPTS.Columns[7].Width = 100;
                        //DGV_RECEIPTS.Columns[8].Width = 40;


                        //    //OPEN PRODUCTION ORDERS GRID 1

                                  

                        try
                        {
                            da = new SqlDataAdapter(
                                "select DISTINCT " +
                                "  p.[Prod_ Order No_] AS [PROD ORD]" +
                                ",CONVERT(varchar,[Starting Date],1) AS [START DT] " +
                                ",FORMAT([Remaining Quantity], '##0') [ORD QTY]" +
                                ",FORMAT([Finished Quantity],'##0') [POSTED QTY]" +
                                " ,CONVERT(varchar,[Due Date],1) AS [DUE DT] " +
                                ", CASE " +
                                "     WHEN[Due Date] <= GETDATE() THEN 'OVDUE' " +
                                "     WHEN[Due Date] <= (GETDATE() - 14) THEN 'LATE' " +
                                "END [STATUS] " +
                                ", p.[Job No_] AS [JOB NO] " +
                                ", l.[Purch_ Order No_] AS PO " +
                                ", l.[Expected Receipt Date] AS [PO DEL Dt] " +
                                " FROM [" + g.NAVprefix + "Prod_ Order Line] p " +
                                " LEFT JOIN[" + g.NAVprefix + "Purchase Line] l ON p.[Prod_ Order No_] = l.[Prod_ Order No_] " +
                                " WHERE p.[Item No_] = '" + POitem + "' AND Status = 3 ", NAVcnxn); 

                            table = new DataTable();
                            da.SelectCommand.CommandTimeout = 30;
                            da.Fill(table);
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            cnxn.Close();
                        }

                        DGV_PROD.DataSource = table;
                        DGV_PROD.Show();
                        DGV_PROD.Columns[0].Width = 60;
                        DGV_PROD.Columns[1].Width = 50;
                        DGV_PROD.Columns[2].Width = 50;
                        DGV_PROD.Columns[3].Width = 40;
                        DGV_PROD.Columns[4].Width = 40;
                        DGV_PROD.Columns[5].Width = 40;
                        DGV_PROD.Columns[6].Width = 60;
                        DGV_PROD.Columns[7].Width = 50;
                        DGV_PROD.Columns[8].Width = 50;

            

                        //    //TRACKER QC

                        try
                        {
                            da = new SqlDataAdapter(
                                "select DISTINCT " +
                                "  MovedOutDate AS [DATE MOVED OUT]" +
                                " ,SignatureName AS INSPECTOR" +
                                " ,MovedOutQty AS [QTY MVD]" +
                                " ,MkReceiptTransactionID AS [TRKR ID] " +
                                " ,ReceiptNumber AS RCPT" +
                                " ,Location AS LOCATION " +
                                " FROM Shortages_Tracking_MoveOut_QC where partNumber = '" + g.itemCode + "'  and LEN(operatorname) > 0 " 
                                   , cnxn);
                            table = new DataTable();
                            da.SelectCommand.CommandTimeout = 30;
                            da.Fill(table);
                            cnxn.Close();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            cnxn.Close();
                        }

                        DGV_TRACK_QC.DataSource = table;
                        DGV_TRACK_QC.Show();
                        DGV_TRACK_QC.Columns[0].Width = 80;
                        DGV_TRACK_QC.Columns[1].Width = 150;
                        DGV_TRACK_QC.Columns[2].Width = 40;
                        DGV_TRACK_QC.Columns[3].Width = 40;
                        DGV_TRACK_QC.Columns[4].Width = 40;
                        DGV_TRACK_QC.Columns[5].Width = 80;

            
                        //    //TRACKER MOVED TO WAREHOUSE

                        try
                        {
                            da = new SqlDataAdapter(
                                "select DISTINCT" +
                                "  MovedOutDate AS [DATE MOVED OUT]" +
                                " ,OperatorName as [MOVED BY]" +
                                " ,MovedOutQty AS [QTY MVD]" +
                                " ,MkReceiptTransactionID AS [TRKR ID]" +
                                " ,Location AS LOCATION" +
                                " ,SignatureName AS SIGNATURE " +
                                " FROM Shortages_Tracking_MoveOut_STK where partNumber = '" + g.itemCode + "'  and LEN(operatorname) > 0 " 
                                , cnxn);
                            table = new DataTable();
                            da.SelectCommand.CommandTimeout = 30;
                            da.Fill(table);
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            cnxn.Close();
                        }

                        DGV_TRACK_WH.DataSource = table;
                        DGV_TRACK_WH.Show();
                        DGV_TRACK_WH.Columns[0].Width = 60;
                        DGV_TRACK_WH.Columns[1].Width = 80;
                        DGV_TRACK_WH.Columns[2].Width = 30;
                        DGV_TRACK_WH.Columns[3].Width = 50;
                        DGV_TRACK_WH.Columns[4].Width = 90;
                        DGV_TRACK_WH.Columns[5].Width = 60;

            //if (Shipper == "F")
            //{
            //    Bups.Visible = false;
            //}
            //else if (Shipper == "U")
            //{
            //    BfedEx.Visible = false;
            //}
            //else
            //{
            //    BfedEx.Visible = false;
            //    Bups.Visible = false;
            //}

        }

        private void Bnext_Click(object sender, EventArgs e)
        {
            if (selectorNumber < (selector.Rows.Count - 1))
            {
                if (changeFlag == true | cbddComments.Text.Length > 0)
                {
                    saveData();
                }
                selectorNumber++;
                g.ShortageID = selector.Rows[selectorNumber][0].ToString().Trim();
                LitemNumber.Text = (selectorNumber + 1).ToString() + " of " + selector.Rows.Count.ToString();
            }

            //SQLselect = "FROM ShortageMeeting" + g.ProductLine + " " +
            //   "WHERE ID = " + g.ShortageID + " ";
            GetData();
            RestoreAfterGroupChange();
        }

        private void Bprevious_Click(object sender, EventArgs e)
        {
            if (selectorNumber != 0)
            {
                if (changeFlag == true | cbddComments.Text.Length > 0)
                {
                    saveData();
                }
                selectorNumber--;
                g.ShortageID = selector.Rows[selectorNumber][0].ToString().Trim();
                LitemNumber.Text = (selectorNumber + 1).ToString() + " of " + selector.Rows.Count.ToString();
                //SQLselect = "FROM ShortageMeeting" + g.ProductLine + " l " +
                //            "WHERE l.ID = " + g.ShortageID + " ";
                GetData();
                RestoreAfterGroupChange();
            }
        }


        private void bArchive_Click(object sender, EventArgs e)
        {
            if (bArchive.Text == "Restore")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand
                     ("Update Shortage_List set " +
                      " DateArchived = NULL " +
                      " ,WhoArchived = '' " +
                      " where id = " + g.ShortageID + " ");
                    cmd.Connection = cnxn;
                    if (cnxn.State == ConnectionState.Closed)
                    {
                        cnxn.Open();
                    }
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }

                bArchive.BackColor = Color.FromArgb(180, 180, 0);
                bArchive.Text = "Archive";

                this.Close();
            }
            else
            {

                SqlParameter pUser = new SqlParameter
                    ("@User", SqlDbType.NChar);
                pUser.Value = user;

                try
                {
                    SqlCommand cmd = new SqlCommand
                     ("Update Shortage_List set " +
                      " DateArchived = GETDATE() " +
                      " ,WhoArchived = " + pUser +
                      " where id = " + g.ShortageID + " ");
                    cmd.Connection = cnxn;
                    if (cnxn.State == ConnectionState.Closed)
                    {
                        cnxn.Open();
                    }
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.Add(pUser);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }

                bArchive.BackColor = Color.FromArgb(128, 128, 128);

                if (g.task == "REVIEW" && selectorNumber < (selector.Rows.Count - 1))
                {
                    if (changeFlag == true)
                    {
                        saveData();
                    }
                    selectorNumber++;
                    g.ShortageID = selector.Rows[selectorNumber][0].ToString().Trim();
                    LitemNumber.Text = (selectorNumber + 1).ToString() + " of " + selector.Rows.Count.ToString();
                    SQLselect = "FROM ShortageMeeting" + g.ProductLine + " " +
                                "WHERE ID = " + g.ShortageID + " ";
                    GetData();
                }
                else
                {
                    this.Close();
                }

            }

            
        }

        private void saveData()
        {
            if (g.task == "REVIEW")
            {
                g.ShortageID = selector.Rows[selectorNumber][0].ToString().Trim();
            }

            SqlParameter pGroup = new SqlParameter
                ("@group", SqlDbType.NChar);
            SqlParameter pCurrDueDate = new SqlParameter
                ("@CurrDueDate", SqlDbType.NChar);
            SqlParameter pOrigDueDate = new SqlParameter
                ("@OrigDueDate", SqlDbType.NChar);
            SqlParameter pRequiredDate = new SqlParameter
                ("@RequiredDate", SqlDbType.NChar);
            SqlParameter pComments = new SqlParameter
                ("@Comments", SqlDbType.NChar);
            SqlParameter pUser = new SqlParameter
                ("@User", SqlDbType.NChar);
            SqlParameter pHot = new SqlParameter
                ("@Hot", SqlDbType.Int);
            SqlParameter pAction = new SqlParameter
                ("@Action", SqlDbType.Int);
            SqlParameter pItemStatus = new SqlParameter
                ("@ItemStatus", SqlDbType.NChar);
            SqlParameter pSupplier = new SqlParameter
                ("@supplier", SqlDbType.NChar);
            SqlParameter pBuyer = new SqlParameter
                ("@buyer", SqlDbType.NChar);
            SqlParameter pPO = new SqlParameter
                ("@po", SqlDbType.NChar);
            SqlParameter pQuantity = new SqlParameter
                ("@quantity", SqlDbType.NChar);
            SqlParameter pIQCCompleteDate = new SqlParameter
                ("@IQCCompleteDate", SqlDbType.NChar);
            SqlParameter pWarDate = new SqlParameter
                ("@warDate", SqlDbType.NChar);
            SqlParameter pReason = new SqlParameter
                ("@Reason", SqlDbType.NChar);
            SqlParameter pTrackingNumber = new SqlParameter
                ("@TrackingNumber", SqlDbType.NChar);
            SqlParameter pProdOrder = new SqlParameter("@prodOrder", SqlDbType.VarChar);
            SqlParameter pSalesOrder = new SqlParameter("@salesOrder", SqlDbType.VarChar);
            SqlParameter pSOLineNo = new SqlParameter("@sOLineNo", SqlDbType.VarChar);
            SqlParameter pSalesODate = new SqlParameter("@salesODate", SqlDbType.Date);
            SqlParameter pShipDate = new SqlParameter("@shipDate", SqlDbType.Date);

            if (cbddComments.Text.Length > 0)
            {
                pUser.Value = user;
                pComments.Value = cbddComments.Text;

                try
                {
                    SqlCommand cmd = new SqlCommand
                        ("Insert into ShortageListComments (" +
                            " ShortageID " +
                            ",Comment " +
                            ",EnteredBy " +
                            ",EnteredOn " +
                            ") values (" +
                          g.ShortageID.ToString().Trim() + 
                          "," + pComments +
                          "," + pUser +
                          ",GETDATE() " +
                          ")", cnxn);

                    cmd.Parameters.Add(pComments);
                    cmd.Parameters.Add(pUser);

                    if (cnxn.State == ConnectionState.Closed)
                    {
                        cnxn.Open();
                    }

                    cmd.CommandTimeout = 30;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                    cbddComments.Text = "";
                }
            }


            if (changeFlag == true | cbddPO.Text.Length > 0 | cbddPlannerBuyer.Text.Length > 0
                | cbddSupplier.Text.Length > 0 | tbQuantity.Text.Length > 0 | tbTrackingNumber.Text.Length > 0)
            {

                SqlSave = " ";

                if (groupChangeFlag == true)
                {
                    pGroup.Value = cbddGroup.Text;
                    SqlSave = " [group] = " + pGroup;
                    cbddGroup.SelectedIndex = 0;

                    LeditGroup.Visible = false;
                    cbddGroup.Visible = false;
                    LconfirmedDueDate.Visible = true;
                    dtpCurrDueDate.Visible = true;
                    LrequiredDate.Visible = true;
                    dtpRequiredDate.Visible = true;
                }

                if (ConfirmedChangeFlag == true)
                {
                    pCurrDueDate.Value = dtpCurrDueDate.Text;
                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " ,CurrDueDate = " + pCurrDueDate;
                    }
                    else
                    {
                        SqlSave += " CurrDueDate = " + pCurrDueDate;
                    }
                }

                if (RequiredChangeFlag == true)
                {
                    pRequiredDate.Value = dtpRequiredDate.Text;
                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " ,[PlannerRequiredDate] = " + pRequiredDate;
                    }
                    else
                    {
                        SqlSave += " [PlannerRequiredDate] = " + pRequiredDate;
                    }
                }

                if (OrigDueChangeFlag == true)
                {
                    pOrigDueDate.Value = dtpOrigDue.Text;
                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " ,[Orig_ Requested Receipt Date] = " + pOrigDueDate;
                    }
                    else
                    {
                        SqlSave += " [Orig_ Requested Receipt Date] = " + pOrigDueDate;
                    }
                }

                if (IQCCompleteChangeFlag == true)
                {
                    pIQCCompleteDate.Value = dtpIQCCompleteDate.Text;
                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " ,[IQCCompleteDate] = " + pIQCCompleteDate;
                    }
                    else
                    {
                        SqlSave += " [IQCCompleteDate] = " + pIQCCompleteDate;
                    }
                }

                if (WarDateChangeFlag == true)
                {
                    pWarDate.Value = dtpWarDate.Text;
                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " ,[WarBoardDate] = " + pWarDate;
                    }
                    else
                    {
                        SqlSave += " [WarBoarddate] = " + pWarDate;
                    }
                }

                if (HotChangeFlag == true)
                {
                    if (cbHot.Checked == true)
                    {
                        pHot.Value = -1;
                    }
                    else
                    {
                        pHot.Value = 0;
                    }

                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " ,Hot = " + pHot;
                    }
                    else
                    {
                        SqlSave += " Hot = " + pHot;
                    }
                }

                if (ActionChangeFlag == true)
                {
                    if (cbActionRqd.Checked == true)
                    {
                        pAction.Value = -1;
                    }
                    else
                    {
                        pAction.Value = 0;
                    }

                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " ,FlagField = " + pAction;
                    }
                    else
                    {
                        SqlSave += " FlagField = " + pAction;
                    }
                }

                if (cbddSupplier.Text.Length > 0)
                {
                    pSupplier.Value = cbddSupplier.Text;
                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " , Supplier = " + pSupplier;
                    }
                    else
                    {
                        SqlSave += " Supplier = " + pSupplier;
                    }
                }

                if (cbddPlannerBuyer.Text.Length > 0)
                {
                    pBuyer.Value = cbddPlannerBuyer.Text;
                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " , Buyer = " + pBuyer;
                    }
                    else
                    {
                        SqlSave += " Buyer = " + pBuyer;
                    }
                }

                if (cbddPO.Text.Length > 0)
                {
                    pPO.Value = cbddPO.Text;
                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " , PO = " + pPO;
                    }
                    else
                    {
                        SqlSave += " PO = " + pPO;
                    }
                }

                if (tbQuantity.Text.Length > 0)
                {
                    pQuantity.Value = tbQuantity.Text;
                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " , POQty = " + pQuantity;
                    }
                    else
                    {
                        SqlSave += " POQty = " + pQuantity;
                    }
                }

                if (cbddItemStatus.Text.Length > 0)
                {
                    pItemStatus.Value = cbddItemStatus.Text;
                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " , ItemStatus = " + pItemStatus;
                    }
                    else
                    {
                        SqlSave += " ItemStatus = " + pItemStatus;
                    }
                }

                if (cbddItemStatus.Text.Length == 0 & changeFlag == true)
                {
                    
                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " , ItemStatus = NULL";
                    }
                    else
                    {
                        SqlSave += " ItemStatus = NULL";
                    }
                }

                if (cbddReason.Text.Length > 0)
                {
                    pReason.Value = cbddReason.Text;
                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " , Reason = " + pReason;
                    }
                    else
                    {
                        SqlSave += " Reason = " + pReason;
                    }
                }

                if (tbTrackingNumber.Text.Length > 0)
                {
                    pTrackingNumber.Value = tbTrackingNumber.Text.Trim();

                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " , ShipmentTrackingNumber = " + pTrackingNumber;
                    }
                    else
                    {
                        SqlSave += " ShipmentTrackingNumber = " + pTrackingNumber;
                    }
                }

                if (tbProdOrder.Text.Length > 0)
                {
                    pProdOrder.Value = tbProdOrder.Text.Trim();

                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " , ProdOrder = " + pProdOrder;
                    }
                    else
                    {
                        SqlSave += " ProdOrder = " + pProdOrder;
                    }
                }

                if (tbSalesOrder.Text.Length > 0)
                {
                    pSalesOrder.Value = tbSalesOrder.Text.Trim();

                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " , SalesOrder = " + pSalesOrder;
                    }
                    else
                    {
                        SqlSave += " SalesOrder = " + pSalesOrder;
                    }
                }

                if (tbSOLineNo.Text.Length > 0)
                {
                    pSOLineNo.Value = tbSOLineNo.Text.Trim();

                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " , SOLineNo = " + pSOLineNo;
                    }
                    else
                    {
                        SqlSave += " SOLineNo = " + pSOLineNo;
                    }
                }

                if (dtpSalesOrderDate.Checked)
                {
                    pSalesODate.Value = dtpSalesOrderDate.Value;

                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " , SODate = " + pSalesODate;
                    }
                    else
                    {
                        SqlSave += " SODate = " + pSalesODate;
                    }
                }

                if (dtpShipDate.Checked)
                {
                    pShipDate.Value = dtpShipDate.Value;

                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " , ShipDate = " + pShipDate;
                    }
                    else
                    {
                        SqlSave += " ShipDate = " + pShipDate;
                    }
                }

                try
                {
                    SqlCommand cmd = new SqlCommand
                        ("Update Shortage_List set " +
                         SqlSave +
                         " where id = " + g.ShortageID + " ");

                    if (groupChangeFlag == true) { cmd.Parameters.Add(pGroup); }
                    if (ConfirmedChangeFlag == true) { cmd.Parameters.Add(pCurrDueDate); }
                    if (RequiredChangeFlag == true) { cmd.Parameters.Add(pRequiredDate); }
                    if (IQCCompleteChangeFlag == true) { cmd.Parameters.Add(pIQCCompleteDate); }
                    if (WarDateChangeFlag == true) { cmd.Parameters.Add(pWarDate); }
                    if (HotChangeFlag == true) { cmd.Parameters.Add(pHot); }
                    if (ActionChangeFlag == true) { cmd.Parameters.Add(pAction); }
                    if (cbddPO.Text.Length > 0) { cmd.Parameters.Add(pPO); }
                    if (tbQuantity.Text.Length > 0) { cmd.Parameters.Add(pQuantity); }
                    if (cbddPlannerBuyer.Text.Length > 0) { cmd.Parameters.Add(pBuyer); }
                    if (cbddSupplier.Text.Length > 0) { cmd.Parameters.Add(pSupplier); }
                    if (OrigDueChangeFlag == true) { cmd.Parameters.Add(pOrigDueDate); }
                    if (cbddItemStatus.Text.Length > 0) { cmd.Parameters.Add(pItemStatus); }
                    if (cbddReason.Text.Length > 0) { cmd.Parameters.Add(pReason); }
                    if (tbTrackingNumber.Text.Length > 0) { cmd.Parameters.Add(pTrackingNumber); }
                    if (tbProdOrder.Text.Length > 0) { cmd.Parameters.Add(pProdOrder); }
                    if (tbSalesOrder.Text.Length > 0) { cmd.Parameters.Add(pSalesOrder); }
                    if (tbSOLineNo.Text.Length > 0) { cmd.Parameters.Add(pSOLineNo); }
                    if (dtpSalesOrderDate.Checked) { cmd.Parameters.Add(pSalesODate); }
                    if (dtpShipDate.Checked) { cmd.Parameters.Add(pShipDate); }

                    cmd.Connection = cnxn;
                    if (cnxn.State == ConnectionState.Closed)
                    {
                        cnxn.Open();
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }
                groupChangeFlag = false;
                ConfirmedChangeFlag = false;
                RequiredChangeFlag = false;
                WarDateChangeFlag = false;
                HotChangeFlag = false;
                ActionChangeFlag = false;
                changeFlag = false;
                OrigDueChangeFlag = false;
            }
        }



        private void cbHot_Click(object sender, EventArgs e)
        {
            HotChangeFlag = true;
            changeFlag = true;
        }

        private void cbActionRqd_Click(object sender, EventArgs e)
        {
            ActionChangeFlag = true;
            changeFlag = true;
        }

        private void cbddGroup_MouseClick(object sender, MouseEventArgs e)
        {
            changeFlag = true;
            groupChangeFlag = true;
        }

        private void dtpCurrDueDate_Enter(object sender, EventArgs e)
        {
            ConfirmedChangeFlag = true;
            changeFlag = true;
        }

        private void dtpRequiredDate_Enter(object sender, EventArgs e)
        {
            RequiredChangeFlag = true;
            changeFlag = true;
        }


        private void dtpOrigDue_Enter(object sender, EventArgs e)
        {
            OrigDueChangeFlag = true;
            changeFlag = true;
        }

        private void dtpWarDate_Enter(object sender, EventArgs e)
        {
            WarDateChangeFlag = true;
            changeFlag = true;
        }

        private void RestoreAfterGroupChange()
        {
            LeditGroup.Visible = false;
            cbddGroup.Visible = false;
            LconfirmedDueDate.Visible = true;
            dtpCurrDueDate.Visible = true;
            LrequiredDate.Visible = true;
            dtpRequiredDate.Visible = true;
        }

        private void bTrackingDetails_Click(object sender, EventArgs e)
        {
            TrackingReport r = new TrackingReport();
            r.ShowDialog();
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            if (g.task == "REVIEW")
            {
                /*  leaving this section in for now in case data from NAV becomes slow and we need warehousing   */

                int x = 1;

                try
                {
                    cnxn.Open();
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "spShortageMeeting" + g.ProductLine;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 30;
                    cmd.Connection = cnxn;

                    x = cmd.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }

                if (x > 1)
                {
                    selectorNumber--;
                    firstLoad();
                    bRefresh.BackColor = Color.Green;
                }
            }
            else
            {
                saveData();
                g.itemCode = string.Empty;
                g.ShortageID = string.Empty;
                
            this.Close();
            }

        }

        private void DGV_ShortageItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (g.task == "EDIT")
            {
                if (e.RowIndex == -1 | e.ColumnIndex == 0 | e.ColumnIndex == 2 | e.ColumnIndex == 3 | e.ColumnIndex == 4
                    | e.ColumnIndex == 5 | e.ColumnIndex == 6 | e.ColumnIndex == 10
                    | e.ColumnIndex == 11 | e.ColumnIndex == 12 | e.ColumnIndex == 17 | e.ColumnIndex == 18 | e.ColumnIndex == 15
                    )
                {
                    return;
                }
                else if (e.ColumnIndex == 1)
                {
                    /*
                    * 
                    * Group
                    * 
                    * */

                    da = new SqlDataAdapter
                    ("select distinct [group] from shortage_list " +
                    "WHERE [GROUP] IS NOT NULL order by [group]", cnxn);
                    DataTable dt1 = new DataTable();
                    da.SelectCommand.CommandTimeout = 30;
                    da.Fill(dt1);
                    DataRow newRow = dt1.NewRow();
                    dt1.Rows.InsertAt(newRow, 0);

                    cbddGroup.DataSource = dt1;
                    cbddGroup.DisplayMember = "Group";

                    LeditGroup.Visible = true;
                    cbddGroup.Visible = true;
                    LconfirmedDueDate.Visible = false;
                    dtpCurrDueDate.Visible = false;
                    LrequiredDate.Visible = false;
                    dtpRequiredDate.Visible = false;
                }

                else if (e.ColumnIndex == 7)
                {
                    /*
                    * 
                    * PO
                    * 
                    * */

                    da = new SqlDataAdapter(
                         "select order_no from mmx_purchase_order_lines " +
                         "where po_line_status = 1 and LEN(Financial_Reason) < 1 " +
                         "and item_code = '" + g.itemCode +
                         "' order by order_no ", cnxn);

                    DataTable dt2 = new DataTable();
                    dt2.Rows.Add();
                    dt2.AcceptChanges();
                    da.SelectCommand.CommandTimeout = 30;
                    da.Fill(dt2);

                    cbddPO.DataSource = dt2;
                    cbddPO.DisplayMember = "Order_No";

                    DGV_Comments.Visible = false;
                    Lpo.Visible = true;
                    cbddPO.Visible = true;
                }
                else if (e.ColumnIndex == 8)
                {
                    /*
                    * 
                    * Quantity
                    * 
                    * */

                    Lquantity.Visible = true;
                    tbQuantity.Visible = true;
                }
                else if (e.ColumnIndex == 9)
                {
                    /*
                    * 
                    * War Room Date
                    * 
                    * */
                    DGV_Comments.Visible = false;
                    LwarDate.Visible = true;
                    dtpWarDate.Visible = true;
                }
                else if (e.ColumnIndex == 13)
                {
                    /*
                    * 
                    * Supplier
                    * 
                    * */

                    da = new SqlDataAdapter(
                         "select NAME from accessfrontends.dbo.mmx_suppliers " +
                         "where title not like '%obs%' " +
                         "order by name ", cnxn);

                    DataTable dt3 = new DataTable();
                    dt3.Rows.Add();
                    dt3.AcceptChanges();
                    da.SelectCommand.CommandTimeout = 30;
                    da.Fill(dt3);

                    cbddSupplier.DataSource = dt3;
                    cbddSupplier.DisplayMember = "Name";

                    DGV_Comments.Visible = false;
                    cbddSupplier.Visible = true;
                    Lsuppliers.Visible = true;
                }
                else if (e.ColumnIndex == 14)
                {
                    /*
                    * 
                    * Planner Buyer
                    * 
                    * */
                    cnxnDash = new SqlConnection(g.dbDash);

                    da = new SqlDataAdapter(
                    "SELECT " +
                     "UPPER(SUBSTRING(name,(CHARINDEX(',',name))+ 2, LEN(name) -  (CHARINDEX(',',name))+ 2) + ' ' + LEFT(name,1)) " +
                     "Name " +
                     "from middb01.dashboard.dbo.view_employees where name != 'Bacon, Bill' and " +
                     "(mysupervisorname like 'piccolo%' or mysupervisorname like 'ogden%' " +
                     "or mysupervisorname like 'thompson%') or name = 'Tello, Christopher' " +
                     "order by name ", cnxnDash);


                    DataTable dt4 = new DataTable();
                    dt4.Rows.Add();
                    dt4.AcceptChanges();
                    da.SelectCommand.CommandTimeout = 30;
                    da.Fill(dt4);

                    cbddPlannerBuyer.DataSource = dt4;
                    cbddPlannerBuyer.DisplayMember = "Name";

                    DGV_Comments.Visible = false;
                    cbddPlannerBuyer.Visible = true;
                    Lbuyer.Visible = true;
                }
                else if (e.ColumnIndex == 18)
                {
                    /*
                     * 
                     * Orig Due Date
                     * 
                     * */
                    LorigDue.Visible = true;
                    dtpOrigDue.Visible = true;
                }

                if (e.ColumnIndex == 1 | e.ColumnIndex == 9
                    | e.ColumnIndex == 16 | e.ColumnIndex == 17)
                {
                    LconfirmedDueDate.Visible = false;
                    dtpCurrDueDate.Visible = false;
                    LrequiredDate.Visible = false;
                    dtpRequiredDate.Visible = false;

                }
            }
            else
            {
                if (e.RowIndex == -1 | e.ColumnIndex != 1)
                {
                    return;
                }
                else if (e.ColumnIndex == 1)
                {
                    da = new SqlDataAdapter
                    ("select distinct [group] from shortage_list " +
                    "WHERE [GROUP] IS NOT NULL order by [group]", cnxn);
                    DataTable dt1 = new DataTable();
                    //da.SelectCommand.CommandTimeout = 30;
                    da.Fill(dt1);
                    DataRow newRow = dt1.NewRow();
                    dt1.Rows.InsertAt(newRow, 0);

                    cbddGroup.DataSource = dt1;
                    cbddGroup.DisplayMember = "Group";

                    LeditGroup.Visible = true;
                    cbddGroup.Visible = true;
                    LconfirmedDueDate.Visible = false;
                    dtpCurrDueDate.Visible = false;
                    LrequiredDate.Visible = false;
                    dtpRequiredDate.Visible = false;
                }
            }
        }

        private void dtpIQCCompleteDate_Enter(object sender, EventArgs e)
        {
            IQCCompleteChangeFlag = true;
            changeFlag = true;
        }

        private void cbddItemStatus_Enter(object sender, EventArgs e)
        {
            changeFlag = true;
        }

        
        private void cbddReason_Enter(object sender, EventArgs e)
        {
            changeFlag = true;
        }

        private void Btrack_Click(object sender, EventArgs e)
        {
            /*  https://www.fedex.com/apps/fedextrack/?tracknumbers=771853356329&commit=Track%21    */
            string track = "https://www.fedex.com/apps/fedextrack/?tracknumbers=" +
                tbTrackingNumber.Text.Trim() + "&commit=Track%21";

            System.Diagnostics.Process.Start(track);
        }

        private void Bups_Click(object sender, EventArgs e)
        {
            // https://www.ups.com/track?loc=en_US&requester=ST/   "Shipped out via UPS 1Z06X4840390053163, Due 12/8"

            string track = "https://www.ups.com/track?loc=en_US&requester=ST/";
                

            System.Diagnostics.Process.Start(track);
        }

        private void tbProdOrder_Enter(object sender, EventArgs e)
        {
            changeFlag = true;
        }

        private void tbSalesOrder_Enter(object sender, EventArgs e)
        {
            changeFlag = true;
        }

        private void tbSOLineNo_Enter(object sender, EventArgs e)
        {
            changeFlag = true;
        }

        private void dtpShipDate_Enter(object sender, EventArgs e)
        {
            changeFlag = true;
        }

        private void dtpSalesOrderDate_Enter(object sender, EventArgs e)
        {
            changeFlag = true;
        }
    }

    public static class g
    {
        public static string itemCode;
        public static string ShortageID;
        public static string ShortageGroup;
        public static string ProductLine;
        public static string task;
        public static string origRqstRcptDate = string.Empty;
        public static string PlannedReceiptDate = string.Empty;
        public static string PO;
        public static string Supplier = string.Empty;
        public static string PoQuantity = string.Empty;
        public static string PurchaserCode = string.Empty;
        public static string dbDash = "server = MIDDB01.zygo.com; password = views; " +
            "user = views; database = Dashboard;";
        public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                            "user = readwrite; database = AccessFrontEnds;";
        public static string dbNAV = "server = pa-hor-as408; password = 2018#ameteK; " +
                            "user = navdb_read; database = ZYGO-NAV-PROD;";
        public static string NAVprefix = "ZYGO$";
    }
}
