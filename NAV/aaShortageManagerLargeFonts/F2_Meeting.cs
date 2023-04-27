using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace aaShortageManagerLargeFonts
{
    public partial class F2_Meeting : Form
    {
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
        private string SqlSave;
        private int fontSize = 8;
        private string UserName;
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


        public F2_Meeting()
        {
            InitializeComponent();
        }

        private void F2_Meeting_Load(object sender, EventArgs e)
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

            if (g.task == "EDIT")
            {
                cnxn = new SqlConnection(g.db);

                SqlCommand cmd = new SqlCommand
                ("SELECT datearchived FROM Shortage_List " +
                 "WHERE ID = " + g.ShortageID + " ", cnxn);
                cnxn.Open();
                object o = cmd.ExecuteScalar();
                cnxn.Close();

                if (o.ToString().Length > 1)
                {
                    this.BackColor = Color.FromArgb(100, 100, 100);
                    Lstatus.Text = "Status:  ALREADY ARCHIVED";
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

            System.Security.Principal.WindowsIdentity user;
            user = System.Security.Principal.WindowsIdentity.GetCurrent();

            UserName = user.Name.Substring(8, user.Name.Length - 8);

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

            //    fontSize = 6;

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

            DGV_PURCH.ColumnHeadersHeight = 32;
            DGV_PLANNEDST.ColumnHeadersHeight = 32;
            DGV_RECEIPTS.ColumnHeadersHeight = 32;
            DGV_PROD.ColumnHeadersHeight = 32;
        }

        private void firstLoad()
        {
            /*
             * 
             * this gets the list of ShortageIDs to be shown in the meeting in the order they need to be in.
             * 
             * */

            cnxn = new SqlConnection(g.db);

            string SQL = string.Empty;

            if (g.ProductLine.ToUpper() == "INST")
            {
                SQL = "select " +
                    "l.ID " +
                    "from Shortage_List l " +
                    "inner join ShortageList_ActiveFlags f " +
                    "on l.id = f.id " +
                    "WHERE productline = '" + g.ProductLine + "' AND ActionFlag = -1 and LateFlag != 'SOON DUE' " +
                    "ORDER BY instrumentoptic desc, hot, sortgroup, lateflagsort, itemstatussort, productline, [group], itemcode, l.id";
            }
            else if (g.ProductLine.ToUpper() == "OPT")
            {
                SQL = "select " +
                    "l.ID " +
                    "from Shortage_List l " +
                    "inner join ShortageList_ActiveFlags f " +
                    "on l.id = f.id " +
                    "WHERE productline = '" + g.ProductLine + "' AND ActionFlag = -1 " +
                    "ORDER BY hot, sortgroup, lateflagsort, itemstatussort, productline, [group], itemcode, l.id";
            }
            else if (g.ProductLine.ToUpper() == "WAR")
            {
                SQL = "select " +
                    "l.ID " +
                    "from Shortage_List l " +
                    "inner join ShortageList_ActiveFlags f " +
                    "on l.id = f.id " +
                    "WHERE productline = '" + g.ProductLine + "' AND ActionFlag = -1 " +
                    "ORDER BY hot, sortgroup, lateflagsort, itemstatussort, productline, [group], itemcode, l.id";
            }
            else
            {
                SQL = "select " +
                    "l.ID " +
                    "from Shortage_List l " +
                    "inner join ShortageList_ActiveFlags f " +
                    "on l.id = f.id " +
                    "WHERE productline = '" + g.ProductLine + "' AND ActionFlag = -1 and LateFlag != 'SOON DUE' " +
                    "ORDER BY hot, sortgroup, lateflagsort, itemstatussort, productline, [group], itemcode, l.id";
            }

            try
            {
                da = new SqlDataAdapter(SQL, cnxn);
                selector = new DataTable();
                da.Fill(selector);

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
                ",CurrDueDate " +  //goes into the Confirmed Due Date field
                ",[Req Date] " +
                ",f.lateflag " +
                ",ItemStatus" +
                ",ItemCode " +
                ",IQCCompleteDate " +
                " FROM Shortage_List l " +
                "INNER JOIN Shortage_ActiveFlags f " +
                "ON l.id = f.id " +
                "WHERE l.ID = " + g.ShortageID + " "
                , cnxn);


            SqlDataReader dr = cmd.ExecuteReader();

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


            }
            cnxn.Close();

            //    COMMENTS

            try
            {
                da = new SqlDataAdapter(
                    " SELECT " +
                    "  RTRIM(Comment) Comment " +
                    " ,EnteredBy as [by] " +
                    " ,EnteredOn AS [Date of Change] " +
                    " FROM ShortageListComments " +
                    " WHERE ShortageID = " + g.ShortageID +
                    " ORDER BY CommentID  DESC", cnxn);
                table = new DataTable();
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

            DGV_Comments.DataSource = table;
            DGV_Comments.Show();
            DGV_Comments.Columns[0].Width = 230;
            DGV_Comments.Columns[1].Width = 50;
            DGV_Comments.Columns[2].Width = 80;


            //shortage item dgv

            try
            {
                da = new SqlDataAdapter(
                    "SELECT " +
                    " ID " +
                    ",[Group] " +
                    ",StkOut AS [Stk Out]" +
                    ",qtyNeeded AS [Qty Rqd]" +
                    ",CONVERT(varchar,DateAddedToList,1) AS [List Date]" +
                    ",DATEDIFF(D, DateAddedtoList, GETDATE()) AS [Days on List]" +
                    ",[Custom Item] " +
                    ",PO AS [PO/WO]" +
                    ",Qty " +
                    ",WarBoardDate As [War Date]" +
                    ",whoAdded AS [By] " +
                    ",Project [Job No.]" +
                    ",projectdesc AS [Proj Description]" +
                    ",Supplier as Vendor" +
                    ",Buyer " +
                    ",CONVERT(varchar,[Orig Date],1) [Orig Promised Receipt Date] " +
                    ",CONVERT(varchar,[Expected Receipt Date],1) [Expected Receipt Date] " +
                    " from shortage_list where id = " + g.ShortageID + " ", cnxn);
                table = new DataTable();
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
            DGV_ShortageItem.Columns[15].MinimumWidth = 60;
            DGV_ShortageItem.Columns[15].FillWeight = 8;
            DGV_ShortageItem.Columns[16].Visible = false;
            DGV_ShortageItem.Columns[16].MinimumWidth = 60;
            DGV_ShortageItem.Columns[16].FillWeight = 4;
            DGV_ShortageItem.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

            nn = "";

            try
            {
                NAVcnxn.Open();
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
                "COALESCE(FORMAT(SUM(L.[Quantity]),'N0'), '0') " +
                "FROM [" + g.NAVprefix + "Purchase Line] L " +
                "INNER JOIN [" + g.NAVprefix + "Item] I ON L.No_ = I.No_ " +
                "WHERE ([Replenishment System] = 0 " +
                "and [Outstanding Quantity] > 0) AND L.No_ = '" + POitem + "' "
                , NAVcnxn);


            object p = "";

            try
            {
                NAVcnxn.Open();
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




            // /*
            //  * 
            //  *  DFT-P6
            //  * 
            //  * */

            // /*  MK  */

            // loopCmd = new SqlCommand
            //    ("SELECT " +
            //    "COALESCE(SUM([Quantity]), 0) " +
            //    "FROM MMX_STOCK_TRANSACTIONS_ITEM_700 " +
            //    "WHERE (Transaction_date >= (GETDATE() - 183)) " +
            //    "AND Item_Code = '" + POitem + "' " +
            //    "AND ((Transaction_Type = 2 AND Order_Type <> 16) " +    /* 2 = stock transfer, 16 = warehouse */
            //    "OR " +
            //    "(Transaction_Type = 6 AND Order_Type <> 20) " +         /* 6 = sales delivery, 20 = rework production   */
            //    "OR " +
            //    "Transaction_Type = 7) "                              /* 7 = production issue  */
            //    , cnxn);

            // object p6S1 = 0;

            // try
            // {
            //     cnxn.Open();
            //     p6S1 = loopCmd.ExecuteScalar();
            // }
            // catch (SqlException ex)
            // {
            //     MessageBox.Show(ex.ToString());
            // }
            // finally
            // {
            //     cnxn.Close();
            // }

            // /*  NAV */

            // loopCmd = new SqlCommand
            //    ("SELECT " +
            //    "COALESCE(SUM([Quantity]), 0) " +
            //    "FROM [" + g.NAVprefix + "Item Ledger Entry] " +
            //    "WHERE [Posting Date] >= (GETDATE() - 183) " +
            //    "AND ([Entry Type] = 1 OR [Entry Type] = 5) " +
            //    "and [Item No_] = '" + POitem + "' "
            //    , NAVcnxn);

            // object p6S2 = 0;

            // try
            // {
            //     NAVcnxn.Open();
            //     p6S2 = loopCmd.ExecuteScalar();
            // }
            // catch (SqlException ex)
            // {
            //     MessageBox.Show(ex.ToString());
            // }
            // finally
            // {
            //     NAVcnxn.Close();
            // }

            // Double P6x = Convert.ToDouble(p6S1) + Convert.ToDouble(p6S2);

            // P6 = string.Format("{0:0}", P6x);


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


            // /*
            //  * 
            //  *  DFT-F6
            //  * 
            //  * */


            // /*
            //* 
            //*  Allocated - time restricted for F6
            //*  
            //* */

            // /*  Production Order Components  

            //         Firm Planned and Released
            //         Quantity goes back to required quantity on BOM
            //         Remaining Quantity reflects what is needed for this order
            // */

            // loopCmd = new SqlCommand
            //    ("SELECT " +
            //     "COALESCE(SUM([Remaining Quantity]), 0) " +
            //     "FROM [" + g.NAVprefix + "Prod_ Order Component] " +
            //     "WHERE 1=1 " +
            //     "AND [Due Date] <= (GETDATE() + 183) " +
            //     "AND Status in (2, 3) " +
            //     "and [Item No_] = '" + POitem + "' "
            //    , NAVcnxn);

            // object AFS1 = 0;

            // try
            // {
            //     NAVcnxn.Open();
            //     AFS1 = loopCmd.ExecuteScalar();
            // }
            // catch (SqlException ex)
            // {
            //     MessageBox.Show(ex.ToString());
            // }
            // finally
            // {
            //     NAVcnxn.Close();
            // }

            // /*  Sales Orders */

            // loopCmd = new SqlCommand
            //    ("SELECT " +
            //    "COALESCE(SUM([Quantity]), 0) " +
            //    "FROM [" + g.NAVprefix + "Sales Line] " +
            //    "WHERE " +
            //    "[Orig_ Requested Delivery Date] <= (GETDATE() + 183) " +
            //    "AND Type = 2 AND [Completely Shipped] = 0 " +
            //    "and [No_] = '" + POitem + "' "
            //    , NAVcnxn);

            // object AFS2 = 0;

            // try
            // {
            //     NAVcnxn.Open();
            //     AFS2 = loopCmd.ExecuteScalar();
            // }
            // catch (SqlException ex)
            // {
            //     MessageBox.Show(ex.ToString());
            // }
            // finally
            // {
            //     NAVcnxn.Close();
            // }


            // /*  Service Orders */

            // loopCmd = new SqlCommand
            //    ("SELECT " +
            //    "COALESCE(SUM([Quantity]), 0) " +
            //    "FROM [" + g.NAVprefix + "Service Line] " +
            //    "WHERE 1=1 " + //[Posting Date] >= (GETDATE() + 183) " +
            //                   //"AND ([Entry Type] = 1 OR [Entry Type] = 5) " +
            //    "and [No_] = '" + POitem + "' "
            //    , NAVcnxn);

            // object AFS3 = 0;

            // try
            // {
            //     NAVcnxn.Open();
            //     AFS3 = loopCmd.ExecuteScalar();
            // }
            // catch (SqlException ex)
            // {
            //     MessageBox.Show(ex.ToString());
            // }
            // finally
            // {
            //     NAVcnxn.Close();
            // }


            // /*  Job - Inventory Requests */

            // loopCmd = new SqlCommand
            //    ("SELECT " +
            //    "COALESCE(SUM([Quantity]), 0) " +
            //    "FROM [" + g.NAVprefix + "Job Journal Line] " +
            //    "WHERE " +
            //    "[Due Date] <= (GETDATE() + 183) " +
            //    "AND [Journal Template Name] = 'INVREQ' " +
            //    "and [No_] = '" + POitem + "' "
            //    , NAVcnxn);

            // object AFS4 = 0;

            // try
            // {
            //     NAVcnxn.Open();
            //     AFS4 = loopCmd.ExecuteScalar();
            // }
            // catch (SqlException ex)
            // {
            //     MessageBox.Show(ex.ToString());
            // }
            // finally
            // {
            //     NAVcnxn.Close();
            // }

            // //AllocationsF6 = string.Format("{0:0.00}", (Convert.ToDouble(AFS1) + Convert.ToDouble(AFS2) + Convert.ToDouble(AFS3) + Convert.ToDouble(AFS4)));

            // /*  MRP New    */

            // loopCmd = new SqlCommand(
            //     "SELECT " +
            //     "COALESCE(SUM(Quantity),0) " +
            //     "FROM [" + g.NAVprefix + "Requisition Line] " + 
            //     "WHERE " +
            //     "[Worksheet Template Name] = 'PLANNING' " +
            //     "AND Type = 2 " +
            //     "AND [Due Date] < GETDATE() + 183 " +
            //     "AND [Action Message] = 1 " +
            //     "AND [No_] = '" + POitem + "' " +
            //     "GROUP BY No_ ", NAVcnxn);

            // object AFMRP1 = 0;

            // try
            // {
            //     NAVcnxn.Open();
            //     AFMRP1 = loopCmd.ExecuteScalar();
            // }
            // catch (SqlException ex)
            // {
            //     MessageBox.Show(ex.ToString());
            // }
            // finally
            // {
            //     NAVcnxn.Close();
            // }

            // /*  MRP Chg Qty    */

            // loopCmd = new SqlCommand(
            //     "SELECT " +
            //     "COALESCE(SUM(Quantity - [Original Quantity]), 0) " +
            //     "FROM [" + g.NAVprefix + "Requisition Line] " +
            //     "WHERE " +
            //     "[Worksheet Template Name] = 'PLANNING' " +
            //     "AND Type = 2 " +
            //     "AND [Due Date] < GETDATE() + 183 " +
            //     "AND [Action Message] = 2 " +
            //     "AND [No_] = '" + POitem + "' " +
            //     "GROUP BY No_ ", NAVcnxn);

            // object AFMRP2 = 0;

            // try
            // {
            //     NAVcnxn.Open();
            //     AFMRP2 = loopCmd.ExecuteScalar();
            // }
            // catch (SqlException ex)
            // {
            //     MessageBox.Show(ex.ToString());
            // }
            // finally
            // {
            //     NAVcnxn.Close();
            // }


            // /*  MRP Chg Date    */

            // loopCmd = new SqlCommand(
            //     "WITH S1 as (" +
            //     "SELECT " +
            //     "CASE " +
            //     "  WHEN ([Original Due Date] <= (GETDATE() + 183)) AND ([Due Date] <= (GETDATE() + 183)) THEN 0 " +
            //     "  WHEN([Original Due Date] <= GETDATE() + 183) AND([Due Date] >= GETDATE() + 183) THEN (Quantity * -1) " +
            //     "  WHEN([Original Due Date] >= GETDATE() + 183) AND([Due Date] <= GETDATE() + 183) THEN (Quantity) " +
            //     "END a " +
            //     "FROM [" + g.NAVprefix + "Requisition Line] " +
            //     "WHERE " +
            //     "[Worksheet Template Name] = 'PLANNING' " +
            //     "AND Type = 2 " +
            //     "AND [Due Date] < (GETDATE() + 183) " +
            //     "AND [Action Message] = 3 " +
            //     "AND [No_] = '" + POitem + "' )" +
            //     "SELECT COALESCE(SUM(a), 0) FROM S1 ", NAVcnxn);

            // object AFMRP3 = 0;

            // try
            // {
            //     NAVcnxn.Open();
            //     AFMRP3 = loopCmd.ExecuteScalar();
            // }
            // catch (SqlException ex)
            // {
            //     MessageBox.Show(ex.ToString());
            // }
            // finally
            // {
            //     NAVcnxn.Close();
            // }


            // /*  MRP Chg Date and Quantity    */

            // loopCmd = new SqlCommand(
            //    "WITH S1 as (" +
            //     "SELECT " +
            //     "CASE " +
            //     "  WHEN ([Original Due Date] <= (GETDATE() + 183)) AND ([Due Date] <= (GETDATE() + 183)) THEN (Quantity - [Original Quantity]) " +
            //     "  WHEN([Original Due Date] <= GETDATE() + 183) AND([Due Date] >= GETDATE() + 183) THEN ((Quantity - [Original Quantity]) * -1) " +
            //     "  WHEN([Original Due Date] >= GETDATE() + 183) AND([Due Date] <= GETDATE() + 183) THEN ((Quantity - [Original Quantity])) " +
            //     "END a " +
            //     "FROM [" + g.NAVprefix + "Requisition Line] " +
            //     "WHERE " +
            //     "[Worksheet Template Name] = 'PLANNING' " +
            //     "AND Type = 2 " +
            //     "AND [Due Date] < (GETDATE() + 183) " +
            //     "AND [Action Message] = 3 " +
            //     "AND [No_] = '" + POitem + "' )" +
            //     "SELECT COALESCE(SUM(a), 0) FROM S1 ", NAVcnxn);

            // object AFMRP4 = 0;

            // try
            // {
            //     NAVcnxn.Open();
            //     AFMRP4 = loopCmd.ExecuteScalar();
            // }
            // catch (SqlException ex)
            // {
            //     MessageBox.Show(ex.ToString());
            // }
            // finally
            // {
            //     NAVcnxn.Close();
            // }


            // /*  MRP Cancel    */

            // loopCmd = new SqlCommand(
            //     "SELECT " +
            //     "COALESCE(SUM(Quantity),0) " +
            //     "FROM [" + g.NAVprefix + "Requisition Line] " +
            //     "WHERE " +
            //     "[Worksheet Template Name] = 'PLANNING' " +
            //     "AND Type = 2 " +
            //     "AND [Due Date] < GETDATE() + 183 " +
            //     "AND [Action Message] = 5 " +
            //     "AND [No_] = '" + POitem + "' " +
            //     "GROUP BY No_ ", NAVcnxn);

            // object AFMRP5 = 0;

            // try
            // {
            //     NAVcnxn.Open();
            //     AFMRP5 = loopCmd.ExecuteScalar();
            // }
            // catch (SqlException ex)
            // {
            //     MessageBox.Show(ex.ToString());
            // }
            // finally
            // {
            //     NAVcnxn.Close();
            // }


            // Double F6S1 = Convert.ToDouble(AFS1) + Convert.ToDouble(AFS2) + Convert.ToDouble(AFS3) + Convert.ToDouble(AFS4) +
            //     Convert.ToDouble(AFMRP1) + Convert.ToDouble(AFMRP2) + Convert.ToDouble(AFMRP3) + Convert.ToDouble(AFMRP4) - Convert.ToDouble(AFMRP5);


            // Annual Spend = F6 * Standard Cost * 2

            ///*  Standard Costl    */

            //loopCmd = new SqlCommand(
            //    "SELECT " +
            //    "[Standard Cost] " +
            //    "FROM [" + g.NAVprefix + "Item] " +
            //    "WHERE " +
            //    " [No_] = '" + POitem + "' "
            //    , NAVcnxn);

            //object AS = 0;

            //try
            //{
            //    NAVcnxn.Open();
            //    AS = loopCmd.ExecuteScalar();

            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    NAVcnxn.Close();
            //}

            //Double Step0 = (Convert.ToDouble(AS));
            //Double Step1 = (Convert.ToDouble(Step0 * F6S1 * 2));

            //spend = string.Format("{0:$0.00}", Step1);

            //F6 = string.Format("{0:0}", F6S1);

            //Double EAUcalac = 0;

            //if (P6x > 0)
            //{
            //    EAUcalac = P6x + F6S1;
            //}
            //else
            //{
            //    EAUcalac = 2 * F6S1;
            //}

            //EAU = string.Format("{0:0}", EAUcalac);


            /*  getting data from Dashboard     */

            SqlConnection cnxnDash = new SqlConnection(g.dbDash);

            loopCmd = new SqlCommand(

                     "SELECT " +
                     "DFT_P6 " +
                     ",DFT_F6 " +
                     ",DFT_EAU " +
                     "FROM NAV_EAU " +
                     "WHERE PartNumber = '" + POitem + "'", cnxnDash);

            DataTable dtDash = new DataTable();
            da = new SqlDataAdapter();
            da.SelectCommand = loopCmd;

            try
            {
                da.Fill(dtDash);

                P6 = dtDash.Rows[0][0].ToString();
                F6 = dtDash.Rows[0][1].ToString();
                EAU = dtDash.Rows[0][2].ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }





            //    //ITEM DATA

            try
            {
                da = new SqlDataAdapter(
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
                        ",CASE " +
                        "   WHEN CHARINDEX(CHAR(3),[Lot Accumulation Period]) > 0 THEN " +  // --work days 
                        "        REPLACE([Lot Accumulation Period], CHAR(3), '') " +
                        "    WHEN CHARINDEX(CHAR(4),[Lot Accumulation Period]) > 0 THEN " + // --week 
                        "       REPLACE([Lot Accumulation Period], CHAR(4), '') * 5	" +       //--convert to days 
                        "    WHEN CHARINDEX(CHAR(5),[Lot Accumulation Period]) > 0 THEN " + // --month 
                        "       REPLACE([Lot Accumulation Period], CHAR(5), '') * 20	" +       //--convert to days 
                        "   WHEN CHARINDEX(CHAR(2),[Lot Accumulation Period]) > 0 THEN " +      //-- days 
                        "       REPLACE([Lot Accumulation Period], CHAR(2), '')		" +
                        "   WHEN LEN([Lot Accumulation Period]) = 0 THEN '0' " +
                        " END [RPL TM]" +
                    " ,FORMAT([Maximum Order Quantity], 'N0') AS [BIN SZ] " +
                    " ,FORMAT([Standard Cost], 'C') AS [STD COST]" +
                    ", CASE " +
                        "WHEN [MPS Item] = 0 THEN 'MRP' " +
                        "WHEN [MPS Item] = 1 THEN 'MPS' " +
                    " END AS [O SYS] " +
                    " ,[Signal Code] " +
                    " FROM [" + g.NAVprefix + "Item] " +
                    " WHERE [No_] = '" + POitem + "' "
                    , NAVcnxn);

                table = new DataTable();
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
                    , P6
                    , F6
                    , EAU
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
                MessageBox.Show(POitem + "  is not a standard part.\n\n\n" + ex.ToString());
            }



            DGV_ItemData.DataSource = dtItem;
            DGV_ItemData.Show();
            DGV_ItemData.Columns[0].MinimumWidth = 110;
            DGV_ItemData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[1].MinimumWidth = 160;
            DGV_ItemData.Columns[2].MinimumWidth = 30;
            DGV_ItemData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[3].MinimumWidth = 30;
            DGV_ItemData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[4].MinimumWidth = 30;
            DGV_ItemData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[5].MinimumWidth = 30;
            DGV_ItemData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[6].MinimumWidth = 30;
            DGV_ItemData.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[7].MinimumWidth = 30;
            DGV_ItemData.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[8].MinimumWidth = 30;
            DGV_ItemData.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[9].MinimumWidth = 30;
            DGV_ItemData.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[10].MinimumWidth = 30;
            DGV_ItemData.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[11].MinimumWidth = 30;
            DGV_ItemData.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[12].MinimumWidth = 40;
            DGV_ItemData.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[13].MinimumWidth = 40;
            DGV_ItemData.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[14].MinimumWidth = 40;
            DGV_ItemData.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[15].MinimumWidth = 40;
            DGV_ItemData.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[16].MinimumWidth = 40;
            DGV_ItemData.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_ItemData.Columns[17].MinimumWidth = 70;
            DGV_ItemData.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV_ItemData.Columns[0].FillWeight = 7;
            DGV_ItemData.Columns[1].FillWeight = 16;
            /* DGV_ItemData.Columns[2].FillWeight = 4;
             DGV_ItemData.Columns[3].FillWeight = 4;
             DGV_ItemData.Columns[4].FillWeight = 4;
             DGV_ItemData.Columns[5].FillWeight = 4;
             DGV_ItemData.Columns[6].FillWeight = 4;
             DGV_ItemData.Columns[7].FillWeight = 4;
             DGV_ItemData.Columns[8].FillWeight = 4;
             DGV_ItemData.Columns[9].FillWeight = 4;
             DGV_ItemData.Columns[10].FillWeight = 4;
             DGV_ItemData.Columns[11].FillWeight = 4;
             DGV_ItemData.Columns[12].FillWeight = 4;
             DGV_ItemData.Columns[13].FillWeight = 4;
             DGV_ItemData.Columns[14].FillWeight = 4;
             DGV_ItemData.Columns[15].FillWeight = 4;
             DGV_ItemData.Columns[16].FillWeight = 4;
             DGV_ItemData.Columns[17].FillWeight = 4;
             */


            //    //PLANNED STOCK TRANSACTIONS
            try
            {
                da = new SqlDataAdapter(
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
                " AND [Outstanding Quantity] > 0), " +
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
                " ORDER BY S1.[TRANS DT] "
                      , NAVcnxn);

                table = new DataTable();
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
            /* DGV_PLANNEDST.Columns[10].Width = 100;
             DGV_PLANNEDST.Columns[11].Width = 40;
             DGV_PLANNEDST.Columns[12].Visible = false;
             DGV_PLANNEDST.Columns[11].Width = 40;
             */

            //    //HISTORY

            try
            {
                da = new SqlDataAdapter(
                    "select " +
                    "  LogDate AS [Date of Change] " +
                    " ,ConfDueDateValue AS Value " +
                    " FROM Shortage_ConfDueDate_Change_Log " +
                    " WHERE ShortageID = " + g.ShortageID +
                    " ORDER BY LogDate DESC", cnxn);
                table = new DataTable();
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

            DGV_History.DataSource = table;
            DGV_History.Show();
            DGV_History.Columns[0].Width = 100;
            DGV_History.Columns[1].Width = 100;



            //    //OPEN PURCHASE ORDERS GRID 1


            try
            {
                da = new SqlDataAdapter(
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
                    " ORDER BY [Promised Receipt Date] ", NAVcnxn);
                table = new DataTable();
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

            DGV_PURCH.DataSource = table;
            DGV_PURCH.Show();
            DGV_PURCH.Columns[0].Width = 50;//0
            DGV_PURCH.Columns[1].Width = 25;
            DGV_PURCH.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV_PURCH.Columns[2].Width = 50;
            DGV_PURCH.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[3].Width = 50;
            DGV_PURCH.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[4].Width = 50;
            DGV_PURCH.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[5].Width = 30;//5
            DGV_PURCH.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[6].Width = 30;
            DGV_PURCH.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[7].Width = 30;
            DGV_PURCH.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[8].Width = 50;
            DGV_PURCH.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[9].Width = 40; //project
            DGV_PURCH.Columns[10].Width = 60;//10
            DGV_PURCH.Columns[11].Width = 40;
            DGV_PURCH.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[12].Width = 40;
            DGV_PURCH.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[13].Width = 80;
            DGV_PURCH.Columns[14].Width = 40;
            DGV_PURCH.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[15].Width = 30;
            DGV_PURCH.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[16].Width = 40;
            DGV_PURCH.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_PURCH.Columns[17].Width = 80;
            DGV_PURCH.Columns[18].Width = 60;
            DGV_PURCH.Columns[19].Visible = false;
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



            if (changeFlag == true | cbddPO.Text.Length > 0 | cbddPlannerBuyer.Text.Length > 0
                | cbddSupplier.Text.Length > 0 | tbQuantity.Text.Length > 0)
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
                        SqlSave += " ,[Req Date] = " + pRequiredDate;
                    }
                    else
                    {
                        SqlSave += " [Req Date] = " + pRequiredDate;
                    }
                }

                if (OrigDueChangeFlag == true)
                {
                    pOrigDueDate.Value = dtpOrigDue.Text;
                    if (SqlSave.Length > 1)
                    {
                        SqlSave += " ,[Orig Date] = " + pOrigDueDate;
                    }
                    else
                    {
                        SqlSave += " [Orig Date] = " + pOrigDueDate;
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
                        SqlSave += " , Qty = " + pQuantity;
                    }
                    else
                    {
                        SqlSave += " Qty = " + pQuantity;
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

            if (cbddComments.Text.Length > 0)
            {
                pUser.Value = UserName;
                pComments.Value = cbddComments.Text;

                try
                {
                    SqlCommand cmd = new SqlCommand
                        ("INSERT INTO ShortageListComments " +
                         " (ShortageID, Comment, EnteredBy) values (" +
                          g.ShortageID.ToString().Trim() + "," +
                          pComments + "," +
                          pUser + ")", cnxn);

                    cmd.Parameters.Add(pComments);
                    cmd.Parameters.Add(pUser);

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
                    cbddComments.Text = "";
                    changeFlag = false;
                }
            }
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

            SQLselect = "FROM ShortageMeeting" + g.ProductLine + " " +
               "WHERE ID = " + g.ShortageID + " ";
            GetData();
            RestoreAfterGroupChange();
        }
    }
}
