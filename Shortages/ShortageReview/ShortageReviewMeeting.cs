using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ShortageReview
{
    public partial class ShortageReviewMeeting : Form
    {
        //private string db = "server = CT-MID-SQL01; password = Read+Write!; " +
          //                  "user = readwrite; database = AccessFrontEnds;";
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
        private bool CommentsChangeFlag;
        SqlConnection cnxn;
        private string SqlSave;
        private int fontSize = 7;
        private string product;

        public ShortageReviewMeeting()
        {
            InitializeComponent();
        }

        private void ShortageReviewMeeting_Load(object sender, EventArgs e)
        {
            /*
             *  the Assembly name on the properties page determines which 
             *  details will be used on the form
             * 
             */


            if (System.Reflection.Assembly.GetExecutingAssembly().GetName().Name == "PPSreview")
            {
                this.Text = "PPS Shortages v" + Application.ProductVersion;
                this.BackColor = Color.FromArgb(140, 200, 120);
                Bnext.BackColor = Color.FromArgb(138, 188, 220);
                Bprevious.BackColor = Color.FromArgb(255, 120, 50);
                bArchive.BackColor = Color.FromArgb(180, 158, 192);
                bRefresh.BackColor = Color.FromArgb( 150, 170, 192);
                product = "PPS";
            }
            else
            {
                this.Text = "INST Shortages v" + Application.ProductVersion;
                this.BackColor = Color.FromArgb(255, 192, 128);
                Bnext.BackColor = Color.FromArgb(128, 192, 128);
                Bprevious.BackColor = Color.FromArgb(255, 120, 50);
                bArchive.BackColor = Color.FromArgb(180, 158, 192);
                bRefresh.BackColor = Color.FromArgb(150, 170, 192);
                product = "INST";
            }

            firstLoad();

            tbComments.Font = new Font("Tahoma", 8);
            tbCurrDueDate.Font = new Font("Tahoma", 8);
            tbReqDate.Font = new Font("Tahoma", 8);

            DGV_ShortageItem.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_History.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_ItemData.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_PLANNEDST.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_PROD.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_PURCH.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_RECEIPTS.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_TRACK_QC.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_TRACK_WH.RowsDefaultCellStyle.Font = new Font("Tahoma", fontSize);

            DGV_ShortageItem.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGV_History.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGV_ItemData.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGV_PLANNEDST.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGV_PROD.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGV_PURCH.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGV_RECEIPTS.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGV_TRACK_QC.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            DGV_TRACK_WH.DefaultCellStyle.SelectionBackColor = Color.Yellow;

            DGV_ShortageItem.DefaultCellStyle.SelectionForeColor = Color.Black;
            DGV_History.DefaultCellStyle.SelectionForeColor = Color.Black;
            DGV_ItemData.DefaultCellStyle.SelectionForeColor = Color.Black;
            DGV_PLANNEDST.DefaultCellStyle.SelectionForeColor = Color.Black;
            DGV_PROD.DefaultCellStyle.SelectionForeColor = Color.Black;
            DGV_PURCH.DefaultCellStyle.SelectionForeColor = Color.Black;
            DGV_RECEIPTS.DefaultCellStyle.SelectionForeColor = Color.Black;
            DGV_TRACK_QC.DefaultCellStyle.SelectionForeColor = Color.Black;
            DGV_TRACK_WH.DefaultCellStyle.SelectionForeColor = Color.Black;

            fontSize = 6;

            DGV_ShortageItem.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_History.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_ItemData.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_PLANNEDST.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_PROD.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_PURCH.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_RECEIPTS.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_TRACK_QC.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);
            DGV_TRACK_WH.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", fontSize);

        }

        private void firstLoad()
        {
            cnxn = new SqlConnection(g.db);

            try
            {
                da = new SqlDataAdapter(
                    "select " +
                    "l.ID " +
                    "from Shortage_List l " +
                    "inner join Shortage_ActiveFlags f " +
                    "on l.id = f.id " +
                    "WHERE productline = '" + product + "' AND ActionFlag = -1 " +
                    "ORDER BY  hot, sortgroup, lateflagsort, productline, [group], itemcode, l.id", cnxn);
                selector = new DataTable();
                da.Fill(selector);

                LitemNumber.Text = "Item number 1 of " + selector.Rows.Count.ToString();

                Bnext.PerformClick();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            da = new SqlDataAdapter
                ("select distinct [group] from shortage_list " +
                "WHERE [GROUP] IS NOT NULL order by [group]", cnxn);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            DataRow newRow = dt1.NewRow();
            dt1.Rows.InsertAt(newRow, 0);

            cbddGroup.DataSource = dt1;
            cbddGroup.DisplayMember = "Group";

        }

        private void GetData()
        {
            SqlConnection cnxn = new SqlConnection(g.db);

            //SHORTAGE DATA

            cnxn.Open();

            SqlCommand cmd = new SqlCommand("SELECT DISTINCT " +
                " HOT " +
                ",FlagField " +
                ",CurrDueDate " +
                ",[Req Date] " +
                ",Comments " +
                ",f.lateflag " +
                ", [group] " +
                " FROM Shortage_List l " +
                "INNER JOIN Shortage_ActiveFlags f " +
                "ON l.id = f.id " +
                "WHERE l.ID = " + selector.Rows[selectorNumber][0].ToString().Trim() + " "
                , cnxn);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr.GetInt32(0) == -1)
                {
                    cbHot.Checked = true; ;
                }
                else
                {
                    cbHot.Checked = false; ;
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
                    tbCurrDueDate.Text = dr.GetDateTime(2).ToShortDateString().Trim();
                }
                else
                {
                    tbCurrDueDate.Text = "";
                }

                if (!dr.IsDBNull(3))//req date
                {
                    tbReqDate.Text = dr.GetDateTime(3).ToShortDateString().Trim();
                }
                else
                {
                    tbReqDate.Text = "";
                }

                if (!dr.IsDBNull(4))
                {
                    tbComments.Text = dr.GetString(4).Trim();
                }

                if (!dr.IsDBNull(5))
                {
                    Lstatus.Text = "STATUS: " + dr.GetString(5).Trim();
                }
                else
                {
                    Lstatus.Text = "STATUS: ";
                }

                if (!dr.IsDBNull(6))
                {
                    Lgroup.Text = dr.GetString(6).Trim();
                }
                else
                {
                    Lgroup.Text = "";
                }
            }
            cnxn.Close();


            try
            {
                da = new SqlDataAdapter(
                    "SELECT DISTINCT " +
                    " ID " +
                    ",[Group] " +
                    ",StkOut AS [Stk Out]" +
                    ",qtyNeeded AS [Qty Rqd]" +
                    ",CONVERT(varchar,DateAddedToList,1) AS [List Date]" +
                    ",ShortageAge AS [Days on List]" +
                    ",Itemcode AS [Item Code]" +
                    ",Description " +
                    ",[Custom Item] " +
                    ",PO AS [PO/WO]" +
                    ",Qty " +               //10
                    ",received AS Rcvd " +
                    ",dateChanged As [Remind Date]" +
                    ",whoAdded AS [By] " +
                    ",sl_project AS Project" +
                    ",projectdesc AS [Proj Description]" +
                    ",Supplier_Name as Supplier" +
                    ",Buyer " +
                    ",CONVERT(varchar,[Orig Date],1) [Orig Due] " +
                      SQLselect, cnxn);
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
            DGV_ShortageItem.Columns[0].Width = 40;
            DGV_ShortageItem.Columns[1].Width = 40;
            DGV_ShortageItem.Columns[2].Width = 30;
            DGV_ShortageItem.Columns[3].Width = 25;
            DGV_ShortageItem.Columns[4].Width = 45;
            DGV_ShortageItem.Columns[5].Width = 40;
            DGV_ShortageItem.Columns[6].Width = 65;
            DGV_ShortageItem.Columns[7].Width = 100;
            DGV_ShortageItem.Columns[8].Width = 40;
            DGV_ShortageItem.Columns[9].Width = 40;
            DGV_ShortageItem.Columns[10].Width = 25;
            DGV_ShortageItem.Columns[11].Width = 30;
            DGV_ShortageItem.Columns[12].Width = 45;
            DGV_ShortageItem.Columns[13].Width = 40;
            DGV_ShortageItem.Columns[14].Width = 40;
            DGV_ShortageItem.Columns[15].Width = 100;
            DGV_ShortageItem.Columns[16].Width = 100;
            DGV_ShortageItem.Columns[17].Width = 50;
            DGV_ShortageItem.Columns[18].Width = 45;


            //ITEM DATA

            try
            {
                da = new SqlDataAdapter(
                    "select distinct " +
                    "  ITEMCODE AS [ITEM CODE] " +
                    " ,iDESCRIPTION AS [DESCRIPTION] " +
                    " ,STOCK_ON_HAND AS [STK OH] " +
                    " ,STOCK_ON_ORDER AS [STK OO] " +
                    " ,ALLOCATED_STOCK AS ALLOC " +
                    " ,BLOCKED_STOCK AS [BLK STK] " +
                    " ,NON_NETTABLE_STOCK AS NONNET " +
                    " ,DFT_P6_Issues AS [DFT P6 ISS] " +
                    " ,DFT_F6 AS [DFT P6] " +
                    " ,DFT_EAU AS [DFT EAU] " +
                    " ,SAFETY_STOCK AS [SF STK] " +
                    " ,RE_ORDER_POINT AS REORD " +
                    " ,VendorLeadTime AS [VEND LT] " +
                    " ,SUPPLIER_REPLEN_DAYS AS [REPL TM] " +
                    " ,CurrentBinSize AS [BIN SZ] " +
                    " ,Order_System_Desc AS [O SYS] " +
                    " ,SIGNAL_CODE AS [SIG CODE] " +
                    " ,STANDARD_COST_PRICE AS [STD CST] " +
                       SQLselect, cnxn);

                string test = selector.Rows[selectorNumber][0].ToString().Trim();
                table = new DataTable();
                da.Fill(table);
                if (table.Rows.Count > 0)
                {
                    g.itemCode = table.Rows[0][0].ToString();
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

            DGV_ItemData.DataSource = table;
            DGV_ItemData.Show();
            DGV_ItemData.Columns[0].Width = 70;
            DGV_ItemData.Columns[1].Width = 160;
            DGV_ItemData.Columns[2].Width = 40;
            DGV_ItemData.Columns[3].Width = 40;
            DGV_ItemData.Columns[4].Width = 40;
            DGV_ItemData.Columns[5].Width = 40;
            DGV_ItemData.Columns[6].Width = 40;
            DGV_ItemData.Columns[7].Width = 40;
            DGV_ItemData.Columns[8].Width = 40;
            DGV_ItemData.Columns[9].Width = 40;
            DGV_ItemData.Columns[10].Width = 40;
            DGV_ItemData.Columns[11].Width = 40;
            DGV_ItemData.Columns[12].Width = 40;
            DGV_ItemData.Columns[13].Width = 40;
            DGV_ItemData.Columns[14].Width = 40;
            DGV_ItemData.Columns[15].Width = 40;
            DGV_ItemData.Columns[16].Width = 40;
            DGV_ItemData.Columns[17].Width = 40;


            //PLANNED STOCK TRANSACTIONS
            try
            {
                da = new SqlDataAdapter(
                    "select distinct " +
                    "  CONVERT(varchar, TRANSACTION_DATE, 1) AS [TRANS DT] " +
                    " ,PLANNED_QUANTITY AS [PLN QTY] " +
                    " ,TRANSTYPEDESC AS [TRANS TYPE] " +
                    " ,PROJECT AS [PROJ] " +
                    " ,INVCHG AS [INV CHG] " +
                    " ,MRP_ORDER_DESC AS [ORD TYPE] " +
                    " ,ORDER_ID AS [ORDER #] " +
                    " ,POSITION_NO AS [POS] " +
                    " ,SERIAL_NO AS [SN] " +
                    " ,TOP_LEVEL_ORDER_NUMBER AS [NxL ORD] " +
                    " ,TOP_LEVEL_ITEM_CODE AS [NxL ITEM CODE] " +
                    " ,TOP_LEVEL_STK_OH AS [NxL OH] " +
                    " ,TRANSACTION_DATE " +
                       SQLselect +
                    "  ORDER BY transaction_date, [ORDER #], [POS] "
                      ,cnxn);

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
            DGV_PLANNEDST.Columns[0].Width = 50;
            DGV_PLANNEDST.Columns[1].Width = 30;
            DGV_PLANNEDST.Columns[2].Width = 60;
            DGV_PLANNEDST.Columns[3].Width = 40;
            DGV_PLANNEDST.Columns[4].Width = 30;
            DGV_PLANNEDST.Columns[5].Width = 70;
            DGV_PLANNEDST.Columns[6].Width = 40;
            DGV_PLANNEDST.Columns[7].Width = 40;
            DGV_PLANNEDST.Columns[8].Width = 40;
            DGV_PLANNEDST.Columns[9].Width = 40;
            DGV_PLANNEDST.Columns[10].Width = 100;
            DGV_PLANNEDST.Columns[11].Width = 40;
            DGV_PLANNEDST.Columns[12].Visible = false;


            //HISTORY

            try
            {
                da = new SqlDataAdapter(
                    "select " +
                    "  LogDate AS [Date of Change] " +
                    " ,ConfDueDateValue AS Value " +
                    " FROM Shortage_ConfDueDate_Change_Log " +
                    " WHERE ShortageID = " + selector.Rows[selectorNumber][0].ToString().Trim() +
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



            //OPEN PURCHASE ORDERS GRID 1
            try
            {
                da = new SqlDataAdapter(
                    "select distinct " +
                    "  PO_ORDER_NO AS [PO #] " +
                    " ,PO_POSITION AS [POS] " +
                    " ,CONVERT(varchar,DELIVERY_DATE,1) AS [DELIVERY DT] " +
                    " ,CONVERT(varchar,DELIVERY_DATE_CONFIRMED,1) AS [CNF DEL DT] " +
                    " ,CONVERT(varchar,CHANGED_DELIVERY_DATE,1) AS [CHG DEL DT] " +
                    " ,PO_QUANTITY AS [ORD QTY] " +
                    " ,TOTAL_DELIVERED_QUANTITY AS [DEL QTY] " +
                    " ,TOTAL_BACKORDERED_QUANTITY AS [BO QTY] " +
                    " ,CONVERT(varchar,PO_ORDER_DATE,1) AS [ORD DT] " +
                    " ,PO_PROJECT AS [PROJ] " +
                    " ,PROJDESC AS [PROJ DESC] " +
                    " ,PRODUCTION_ORDER AS [PROD ORD] " +
                    " ,SUPPLIER AS [SUPPLIER] " +
                    " ,SUPPLIER_NAME AS [Supplier Name] " +
                    "  ,POLineLateFlag AS [STATUS]" +
                    " ,InspRqd AS [Insp Rqd]" +
                    " ,INSPECTION_CODE AS [Insp Code]" +
                    " ,SALES_REFERENCE " +
                    " ,TELEPHONE " +
                    " ,EMAIL " +
                    " ,delivery_date " +
                       SQLselect + " and len(PO_order_no) > 0 " +
                    "  ORDER BY DELIVERY_DATE "   
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

            DGV_PURCH.DataSource = table;
            DGV_PURCH.Show();
            DGV_PURCH.Columns[0].Width = 40;//0
            DGV_PURCH.Columns[1].Width = 25;
            DGV_PURCH.Columns[2].Width = 50;
            DGV_PURCH.Columns[3].Width = 50;
            DGV_PURCH.Columns[4].Width = 50;
            DGV_PURCH.Columns[5].Width = 30;//5
            DGV_PURCH.Columns[6].Width = 30;
            DGV_PURCH.Columns[7].Width = 30;
            DGV_PURCH.Columns[8].Width = 50;
            DGV_PURCH.Columns[9].Width = 40; //project
            DGV_PURCH.Columns[10].Width = 60;//10
            DGV_PURCH.Columns[11].Width = 40;
            DGV_PURCH.Columns[12].Width = 40;
            DGV_PURCH.Columns[13].Width = 80;
            DGV_PURCH.Columns[14].Width = 40;
            DGV_PURCH.Columns[15].Width = 25;
            DGV_PURCH.Columns[16].Width = 40;
            DGV_PURCH.Columns[17].Width = 80;
            DGV_PURCH.Columns[18].Width = 60;
            DGV_PURCH.Columns[19].Width = 80;
            DGV_PURCH.Columns[20].Visible = false;



            //RECEIPTS

            try
            {
                da = new SqlDataAdapter(
                    "select DISTINCT " +
                    "  RPO_ORDER_NO AS PO" +
                    " ,RPO_POSITION AS POS" +
                    " ,SERIAL_NUMBER AS SN" +
                    " ,CONVERT(varchar, RECEIPT_DATE,1) AS [DT RCVD]" +
                    " ,DELIVERED_QUANTITY AS [DEL QTY]" +
                    " ,QtyInQc AS [Qty @QC]" +
                    " ,MkReceiptTransactionID [TRKR ID]" +
                    " ,RECEIPT_NUMBER AS RCPT" +
                    " ,QualityInspectorAssigned AS INSPR" +
                    " ,QualityPriority AS PRI " +
                       SQLselect + " and LEN(rpo_order_no) > 0 ", cnxn);
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
            DGV_RECEIPTS.Columns[0].Width = 40;
            DGV_RECEIPTS.Columns[1].Width = 30;
            DGV_RECEIPTS.Columns[2].Width = 40;
            DGV_RECEIPTS.Columns[3].Width = 50;
            DGV_RECEIPTS.Columns[4].Width = 40;
            DGV_RECEIPTS.Columns[5].Width = 40;
            DGV_RECEIPTS.Columns[6].Width = 40;
            DGV_RECEIPTS.Columns[7].Width = 40;
            DGV_RECEIPTS.Columns[8].Width = 80;
            DGV_RECEIPTS.Columns[9].Width = 40;


            //OPEN PRODUCTION ORDERS GRID 1

            try
            {
                da = new SqlDataAdapter(
                    "select DISTINCT " +
                    "  ORDER_NO AS [PROD ORD]" +
                    " ,CONVERT(varchar,START_DATE, 1) AS [START DT]" +
                    " ,CONVERT(varchar,PLANNED_DELIVERY_DATE, 1) AS [PLN DEL DT]" +
                    " ,PRODORDLATEFLAG AS STATUS" +
                    " ,ORDER_QUANTITY AS [ORD QTY]" +
                    " ,QUANTITY_POSTED AS [POSTED QTY]" +
                    " ,PROJECT " +
                    " ,Purchase_Order_No AS [PO]" +
                    " ,Purchase_Order_Del_Date AS [PO DEL DT] " +
                       SQLselect + "and transtypedesc = 'Supply' " +
                       "and MRP_Order_desc = 'Production Order' ", cnxn);

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



            //TRACKER QC

            try
            {
                da = new SqlDataAdapter(
                    "select DISTINCT " +
                    "  QcMovedOutDate AS [DATE MOVED OUT]" +
                    " ,QcOperatorName AS INSPECTOR" +
                    " ,QcMovedOutQty AS [QTY MVD]" +
                    " ,QC_MkReceiptTransactionID AS [TRKR ID] " +
                    " ,QcReceiptNumber AS RCPT" +
                    " ,QcLocation AS LOCATION " +
                       SQLselect //+ " and LEN(qcoperatorname) > 0 " +
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


            //TRACKER MOVED TO WAREHOUSE

            try
            {
                da = new SqlDataAdapter(
                    "select DISTINCT" +
                    "  StkMovedOutDate AS [DATE MOVED OUT]" +
                    " ,StkOperatorName as [MOVED BY]" +
                    " ,StkMovedOutQty AS [QTY MVD]" +
                    " ,StkMkReceiptTransactionID AS [TRKR ID]" +
                    " ,StkLocation AS LOCATION" +
                    " ,StkSignatureName AS SIGNATURE " +
                       SQLselect + " and LEN(stkoperatorname) > 0 ", cnxn);
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
            SqlParameter pGroup = new SqlParameter
                ("@group", SqlDbType.NChar);
            SqlParameter pCurrDueDate = new SqlParameter
                ("@CurrDueDate", SqlDbType.NChar);
            SqlParameter pRequiredDate = new SqlParameter
                ("@RequiredDate", SqlDbType.NChar);
            SqlParameter pComments = new SqlParameter
                ("@Comments", SqlDbType.NChar);
            SqlParameter pHot = new SqlParameter
                ("@Hot", SqlDbType.Int);
            SqlParameter pAction = new SqlParameter
                ("@Action", SqlDbType.Int);

            SqlSave = " ";

            if (groupChangeFlag == true)
            {
                pGroup.Value = cbddGroup.Text;
                SqlSave = " [group] = " + pGroup;
                cbddGroup.SelectedIndex = 0;
            }

            if (ConfirmedChangeFlag == true)
            {
                pCurrDueDate.Value = tbCurrDueDate.Text;
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
                pRequiredDate.Value = tbReqDate.Text;
                if (SqlSave.Length > 1)
                {
                    SqlSave += " ,[Req Date] = " + pRequiredDate;
                }
                else
                {
                    SqlSave += " [Req Date] = " + pRequiredDate;
                }
            }

            if (CommentsChangeFlag == true)
            {
                pComments.Value = tbComments.Text;
                if (SqlSave.Length > 1)
                {
                    SqlSave += " ,Comments = " + pComments;
                }
                else
                {
                    SqlSave += " Comments = " + pComments;
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

            try
            {
                SqlCommand cmd = new SqlCommand
                    ("Update Shortage_List set " +
                     SqlSave +
                     " where id = " + selector.Rows[selectorNumber][0].ToString().Trim() + " ");
                if (groupChangeFlag == true) { cmd.Parameters.Add(pGroup); }
                if (ConfirmedChangeFlag == true) { cmd.Parameters.Add(pCurrDueDate); }
                if (RequiredChangeFlag == true) { cmd.Parameters.Add(pRequiredDate); }
                if (CommentsChangeFlag == true) { cmd.Parameters.Add(pComments); }
                if (HotChangeFlag == true) { cmd.Parameters.Add(pHot); }
                if (ActionChangeFlag == true) { cmd.Parameters.Add(pAction); }
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
            CommentsChangeFlag = false;
            HotChangeFlag = false;
            ActionChangeFlag = false;
            changeFlag = false;

        }


        private void Bnext_Click(object sender, EventArgs e)
        {
            if (selectorNumber < (selector.Rows.Count - 1))
            {
                if (changeFlag == true)
                {
                    saveData();
                }
                selectorNumber++;
                LitemNumber.Text = "Item number " + (selectorNumber + 1).ToString() + " of " + selector.Rows.Count.ToString();
                /*SQLselect = "FROM ShortageAr" + product + "_DW " +
                            "WHERE ID = " +
                             selector.Rows[selectorNumber][0].ToString().Trim() + " ";
                             */
                SQLselect = "FROM ShortageMeeting" + product + " " +
               "WHERE ID = " +
                selector.Rows[selectorNumber][0].ToString().Trim() + " ";
                GetData();
            }
        }

        private void Bprevious_Click(object sender, EventArgs e)
        {
            if (selectorNumber != 0)
            {
                if (changeFlag == true)
                {
                    saveData();
                }
                selectorNumber--;
                LitemNumber.Text = "Item number " + (selectorNumber + 1).ToString() + " of " + selector.Rows.Count.ToString();
                /*
                SQLselect = "FROM ShortageAr" + product + "_DW l " +
                            "WHERE l.ID = " +
                             selector.Rows[selectorNumber][0].ToString().Trim() + " ";
                             */
                SQLselect = "FROM ShortageMeeting" + product + " l " +
                            "WHERE l.ID = " +
                             selector.Rows[selectorNumber][0].ToString().Trim() + " ";
                GetData();
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

        private void tbCurrDueDate_Enter(object sender, EventArgs e)
        {
            ConfirmedChangeFlag = true;
            changeFlag = true;
        }

        private void tbReqDate_Enter(object sender, EventArgs e)
        {
            RequiredChangeFlag = true;
            changeFlag = true;
        }

        private void tbComments_Enter(object sender, EventArgs e)
        {
            CommentsChangeFlag = true;
            changeFlag = true;
        }

        private void bArchive_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand
                 ("Update Shortage_List set " +
                  " DateArchived = GETDATE() " +
                  " where id = " + selector.Rows[selectorNumber][0].ToString().Trim() + " ");
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

            bArchive.BackColor = Color.FromArgb(128, 128, 128);

            if (selectorNumber < (selector.Rows.Count - 1))
            {
                if (changeFlag == true)
                {
                    saveData();
                }
                selectorNumber++;
                LitemNumber.Text = "Item number " + (selectorNumber + 1).ToString() + " of " + selector.Rows.Count.ToString();
                /*
                SQLselect = "FROM ShortageAr" + product + "_DW " +
                            "WHERE ID = " +
                             selector.Rows[selectorNumber][0].ToString().Trim() + " ";
                */
                SQLselect = "FROM ShortageMeeting" + product + " " +
                            "WHERE ID = " +
                             selector.Rows[selectorNumber][0].ToString().Trim() + " ";
                GetData();
            }
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            int x = 1;

            try
            {
                cnxn.Open();
                SqlCommand cmd = new SqlCommand();
                if (System.Reflection.Assembly.GetExecutingAssembly().GetName().Name == "PPSreview")
                {
                    cmd.CommandText = "spShortageMeetingPPS";
                }
                else
                {
                    cmd.CommandText = "spShortageMeetingINST";
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
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
                firstLoad();
                bRefresh.BackColor = Color.Green;
            }
        }

 
        private void bTrackingDetails_Click(object sender, EventArgs e)
        {
            ReportForm r = new ReportForm();
            r.ShowDialog();
        }
    }

    public static class g
    {
        //public static string tbSearchCustomer;
        //public static string tbSearchProject;
        //public static string tbSearchElement;
        //public static string tbSearchPlanner;
        public static string itemCode;
        //public static string project;
        //public static string element;
        //public static string db = "server = CT-MID-SQL01; password = Read+Write!; " +
        public static string db = "server = MIDSQL01; password = Read+Write!; " +
                            "user = readwrite; database = AccessFrontEnds;";
        //public static string basicselect = "select " +
        //        "PlannerInitials as Planner, " +
        //        "from PlannerCurrentStatus ";
        //public static string basicsort = "order by planner, customer, " +
        //    "project, elementname, dbo.sc_sortableversionstring(partsn)";

        //public static string basicsort = "order by planner, deptcode, " +
        //    "project, elementname, dbo.sc_sortableversionstring(partsn)";


    }

}
