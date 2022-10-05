using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ActiveDetailsForm
{
    public partial class ActiveDetailsForm : Form
    {
        private string db = "server = midsql01; password = Read+Write!; " +
                            "user = readwrite; database = AccessFrontEnds;";

        SqlDataAdapter da;
        DataTable table;
        DataTable selector;
        private int selectorNumber = 0;
        private string SQLselect;


        public ActiveDetailsForm()
        {
            InitializeComponent();
        }

        private void ActiveDetailsForm_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection("server = midsql01; password = Read+Write!; " +
                "user = readwrite; database = AccessFrontEnds;");

            try
            {
                da = new SqlDataAdapter(
                    "select " +
                    "l.ID " +
                    "from [Shortage List] l " +
                    "inner join ShortageList_ActiveFlags f " +
                    "on l.id = f.id " +
                    "WHERE productline = 'INST' " +
                    "ORDER BY  hot, sortgroup,lateflagsort, productline, [group], itemcode, l.id", cnxn);
                selector = new DataTable();
                da.Fill(selector);
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
                ("select distinct [group] from [shortage list] " +
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
            SqlConnection cnxn = new SqlConnection("server = midsql01; password = Read+Write!; " +
                "user = readwrite; database = AccessFrontEnds;");

            //SHORTAGE DATA

            cnxn.Open();
            SqlCommand cmd = new SqlCommand("SELECT " +
                " ID " +
                ",ProductLine " +
                ",stkOut " +
                ",qtyNeeded " +
                ",DateAddedToList " +
                ",ShortageAge " +
                ",Itemcode " +
                ",Description " +
                ",[custom item] " +
                ",PO " +
                ",qty " +               //10
                ",received " +
                ",dateChanged " +
                ",whoAdded " +
                ",sl_project " +
                ",projectdesc " +
                ",supplier " +
                ",buyer " +
                ",lateFlag " +
                ",[orig date] " +
                ",[Group] " +       //20
                //",Hot " +
                 SQLselect, cnxn);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (!dr.IsDBNull(0)) { LID.Text = dr.GetInt32(0).ToString().Trim(); }
                if (!dr.IsDBNull(1)) { LPLine.Text = dr.GetString(1).Trim(); }
                if (!dr.IsDBNull(2))
                {
                    LstkOut.Text = dr.GetString(2).Trim();
                }
                else
                {
                    LstkOut.Text = "   ";
                }
                if (!dr.IsDBNull(3))
                {
                    LqtyRqd.Text = dr.GetString(3).Trim();
                }
                else
                {
                    LqtyRqd.Text = "   ";
                }
                if (!dr.IsDBNull(4)) { LdateAdded.Text = dr.GetDateTime(4).ToShortDateString().Trim(); }
                if (!dr.IsDBNull(5)) { LdaysOnList.Text = dr.GetInt32(5).ToString().Trim(); }
                if (!dr.IsDBNull(6)) { LitemCode.Text = dr.GetString(6).Trim(); }
                if (!dr.IsDBNull(7)) { Ldescription.Text = dr.GetString(7).Trim(); }
                if (!dr.IsDBNull(8))
                {
                    LCustomItem.Text = dr.GetString(8).Trim();
                }
                else
                {
                    LCustomItem.Text = "   ";
                }
                if (!dr.IsDBNull(9)) { LPOWO.Text = dr.GetString(9).Trim(); }
                if (!dr.IsDBNull(10)) { Lqty.Text = dr.GetString(10).ToString().Trim(); }
                if (!dr.IsDBNull(11))
                {
                    Lrcvd.Text = dr.GetString(11).ToString().Trim();
                }
                else
                {
                    Lrcvd.Text = "   ";
                }
                if (!dr.IsDBNull(12))
                {
                    LremindDateChanged.Text = dr.GetString(12).ToString().Trim();
                }
                else
                {
                    LremindDateChanged.Text = "                ";
                }
                if (!dr.IsDBNull(13)) { LwhoAdded.Text = dr.GetString(13).ToString().Trim(); }
                if (!dr.IsDBNull(14)) { Lproject.Text = dr.GetString(14).ToString().Trim(); }
                if (!dr.IsDBNull(15)) { LprojDesc.Text = dr.GetString(15).ToString().Trim(); }

                if (!dr.IsDBNull(20))
                {
                    Lgroup.Text = dr.GetString(20).Trim();
                    cbddGroup.Visible = false;
                }


            }
            cnxn.Close();



            //ITEM DATA

            try
            {
                da = new SqlDataAdapter(
                    "select distinct " +
                    "  ITEMCODE AS [ITEM CODE] " +
                    " ,iDESCRIPTION " +
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
            DGV_ItemData.Columns[0].Width = 60;
            DGV_ItemData.Columns[1].Width = 150;
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
                    "  TRANSACTION_DATE AS [TRANS DT] " +
                    " ,PLANNED_QUANTITY AS [PLN QTY] " +
                    " ,TRANSTYPEDESC AS [TRANS TYPE] " +
                    " ,PROJECT AS [PROJ] " +
                    " ,INVCHG AS [INV CHG] " +
                    " ,MRP_ORDER_DESC AS [ORD TYPE] " +
                    " ,ORDER_ID AS [ORDER #] " +
                    " ,POSITION_NO AS [POS] " +
                    " ,SERIAL_NO AS [SN] " +
                    " ,TOP_LEVEL_ORDER_NUMBER AS [TL ORD #] " +
                    " ,TOP_LEVEL_ITEM_CODE AS [TL ITEM CODE] " +
                    " ,TOP_LEVEL_STK_OH AS [TL OH] " +
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


            //OPEN PURCHASE ORDERS GRID 1
            try
            {
                da = new SqlDataAdapter(
                    "select distinct " +
                    "  PO_ORDER_NO AS [PO #] " +
                    " ,PO_POSITION AS [POS] " +
                    " ,DELIVERY_DATE AS [DELIVERY DT] " +
                    " ,DELIVERY_DATE_CONFIRMED AS [CNF DEL DT] " +
                    " ,CHANGED_DELIVERY_DATE AS [CHG DEL DT] " +
                    " ,PO_QUANTITY AS [ORD QTY] " +
                    " ,TOTAL_DELIVERED_QUANTITY AS [DEL QTY] " +
                    " ,TOTAL_BACKORDERED_QUANTITY AS [BO QTY] " +
                    " ,PO_ORDER_DATE AS [ORD DT] " +
                    " ,PROJECT AS [PROJ] " +
                    " ,PROJDESC AS [PROJ DESC] " +
                    " ,PRODUCTION_ORDER AS [PROD ORD] " +
                    " ,SUPPLIER AS [SUPPLIER] " +
                    " ,SUPPLIER_NAME AS [SUPPLIER] " +
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

            DGV_PURCH.DataSource = table;
            DGV_PURCH.Show();
            DGV_PURCH.Columns[0].Width = 60;
            DGV_PURCH.Columns[1].Width = 40;
            DGV_PURCH.Columns[2].Width = 60;
            DGV_PURCH.Columns[3].Width = 60;
            DGV_PURCH.Columns[4].Width = 60;
            DGV_PURCH.Columns[5].Width = 50;
            DGV_PURCH.Columns[6].Width = 40;
            DGV_PURCH.Columns[7].Width = 40;
            DGV_PURCH.Columns[8].Width = 40;
            DGV_PURCH.Columns[9].Width = 40;
            DGV_PURCH.Columns[10].Width = 60;
            DGV_PURCH.Columns[11].Width = 60;
            DGV_PURCH.Columns[12].Width = 40;
            DGV_PURCH.Columns[13].Width = 100;


            //OPEN PURCHASE ORDERS GRID 2
            try
            {
                da = new SqlDataAdapter(
                    "select " +
                    "  POLineLateFlag " +
                    " ,InspRqd " +
                    " ,INSPECTION_CODE " +
                    " ,PRODUCTION_ORDER " +
                    " ,SALES_REFERENCE " +
                    " ,TELEPHONE " +
                    " ,EMAIL " +
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

            DGV_PURCH2.DataSource = table;
            DGV_PURCH2.Show();
            DGV_PURCH2.Columns[0].Width = 60;
            DGV_PURCH2.Columns[1].Width = 40;
            DGV_PURCH2.Columns[2].Width = 60;
            DGV_PURCH2.Columns[3].Width = 60;
            DGV_PURCH2.Columns[4].Width = 60;
            DGV_PURCH2.Columns[5].Width = 50;
            DGV_PURCH2.Columns[6].Width = 40;


            //RECEIPTS

            try
            {
                da = new SqlDataAdapter(
                    "select " +
                    "  RPO_ORDER_NO " +
                    " ,RPO_POSITION " +
                    " ,SERIAL_NUMBER " +
                    " ,RECEIPT_DATE " +
                    " ,DELIVERED_QUANTITY " +
                    " ,QtyInQc " +
                    " ,MkReceiptTransactionID " +
                    " ,RECEIPT_NUMBER " +
                    " ,QualityInspectorAssigned " +
                    " ,QualityPriority " +
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

            DGV_RECEIPTS.DataSource = table;
            DGV_RECEIPTS.Show();
            DGV_RECEIPTS.Columns[0].Width = 80;
            DGV_RECEIPTS.Columns[1].Width = 150;
            DGV_RECEIPTS.Columns[2].Width = 40;
            DGV_RECEIPTS.Columns[3].Width = 40;
            DGV_RECEIPTS.Columns[4].Width = 40;
            DGV_RECEIPTS.Columns[5].Width = 40;
            DGV_RECEIPTS.Columns[6].Width = 40;
            DGV_RECEIPTS.Columns[7].Width = 40;
            DGV_RECEIPTS.Columns[8].Width = 40;
            DGV_RECEIPTS.Columns[9].Width = 40;


            //OPEN PRODUCTION ORDERS GRID 1

            try
            {
                da = new SqlDataAdapter(
                    "select " +
                    "  ORDER_NO " +
                    " ,START_DATE " +
                    " ,PLANNED_DELIVERY_DATE " +
                    " ,PRODORDLATEFLAG " +
                    " ,ORDER_QUANTITY " +
                    " ,QUANTITY_POSTED " +
                    " ,PROJECT " +
                    " ,Purchase_Order_No " +
                    " ,Purchase_Order_Del_Date " +
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

            DGV_PROD.DataSource = table;
            DGV_PROD.Show();
            DGV_PROD.Columns[0].Width = 80;
            DGV_PROD.Columns[1].Width = 150;
            DGV_PROD.Columns[2].Width = 40;
            DGV_PROD.Columns[3].Width = 40;
            DGV_PROD.Columns[4].Width = 40;
            DGV_PROD.Columns[5].Width = 40;
            DGV_PROD.Columns[6].Width = 40;
            DGV_PROD.Columns[7].Width = 40;
            DGV_PROD.Columns[8].Width = 40;



            //TRACKER QC

            try
            {
                da = new SqlDataAdapter(
                    "select " +
                    "  QcMovedOutDate " +
                    " ,QcOperatorName " +
                    " ,QcMovedOutQty " +
                    " ,QC_MkReceiptTransactionID " +
                    " ,QcReceiptNumber" +
                    " ,QcLocation " +
                       SQLselect, cnxn);
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
            DGV_TRACK_QC.Columns[5].Width = 40;


            //TRACKER MOVED TO WAREHOUSE

            try
            {
                da = new SqlDataAdapter(
                    "select " +
                    "  StkMovedOutDate " +
                    " ,StkOperatorName " +
                    " ,StkMovedOutQty " +
                    " ,StkMkReceiptTransactionID " +
                    " ,StkLocation " +
                    " ,StkSignatureName " +
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

            DGV_TRACK_WH.DataSource = table;
            DGV_TRACK_WH.Show();
            DGV_TRACK_WH.Columns[0].Width = 80;
            DGV_TRACK_WH.Columns[1].Width = 150;
            DGV_TRACK_WH.Columns[2].Width = 40;
            DGV_TRACK_WH.Columns[4].Width = 40;
            DGV_TRACK_WH.Columns[5].Width = 40;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SQLselect = "FROM ShortagesDetailsInst_DW " +
                        "WHERE ID = " +
                         selector.Rows[selectorNumber][0].ToString().Trim() + " ";
            GetData();
            selectorNumber++;
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void Lbuyer_Click(object sender, EventArgs e)
        {

        }

        private void Lqty_Click(object sender, EventArgs e)
        {

        }

        private void LPOWO_Click(object sender, EventArgs e)
        {

        }

        private void LCustomItem_Click(object sender, EventArgs e)
        {

        }

        private void Ldescription_Click(object sender, EventArgs e)
        {

        }

        private void LitemCode_Click(object sender, EventArgs e)
        {

        }

        private void LdateAdded_Click(object sender, EventArgs e)
        {

        }

        private void LqtyRqd_Click(object sender, EventArgs e)
        {

        }

        private void LstkOut_Click(object sender, EventArgs e)
        {

        }

        private void LPLine_Click(object sender, EventArgs e)
        {

        }

        private void LID_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectorNumber--;
            SQLselect = "FROM ShortagesDetailsInst_DW " +
                        "WHERE ID = " +
                         selector.Rows[selectorNumber][0].ToString().Trim() + " ";
            GetData();
            
        }
    }
}
