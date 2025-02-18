using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NAV_MRP
{
    public partial class F3_Sheets : Form
    {
        //private string directory = "\\\\MIDFILE01.ametek.com\\departments\\procurement\\purchasing\\mrp_requisitions\\MRP NAV";
        //private string ErrorLog = @"\\midfile01.ametek.com\departments\procurement\purchasing\mrp_requisitions\Archive\MRPerrorLog.txt";
        private string directory = @"C:\A";
        private string ErrorLog = @"C:\A\MRPerrorLog.txt";

        private string[] aItemNo = new string[20000];
        private string[] abuyerPlanner = new string[20000];
        private string[] aVendorNo = new string[20000];
        private string[] aVendorName = new string[20000];
        private string[] aVendorAddress = new string[20000];
        private string[] aVendorContact = new string[20000];
        private string[] aVendorPhone = new string[20000];
        private string[] aVendorEmail = new string[20000];
        private string[] aVendorFax = new string[20000];
        private string[] aVendorTitle = new string[20000];
        private string[] aVendorCommodityCode = new string[20000];
        private string[] aCopyExact = new string[20000];
        private string[] aInspection = new string[20000];
        private string[] aLocation = new string[20000];
        private string[] aDescription = new string[20000];
        private string[] aItemCommodityCode = new string[20000];
        private string[] aProductType = new string[20000];
        private string[] aSelectionCode = new string[20000];
        private string[] aItemGroup = new string[20000];
        private string[] aSignalCode = new string[20000];
        private string[] aLeadTime = new string[20000];
        private string[] aLotAccumulationPeriod = new string[20000];
        private string[] aSource = new string[20000];
        private string[] aCurrentRev = new string[20000];
        private string[] aECOstatus = new string[20000];
        private string[] aDateRevCreated = new string[20000];
        private string[] aOwner = new string[20000];
        private string[] aAnnualSpend = new string[20000];
        private string[] aNettableStock = new string[20000];
        private string[] aNonNetStock = new string[20000];
        private string[] aOnOrder = new string[20000];
        private string[] aBlockedStock = new string[20000];
        private string[] aSafetyStock = new string[20000];
        private string[] aSIM = new string[20000];
        private string[] aOrderMethod = new string[20000];
        private string[] aQtyMultiplier = new string[20000];
        private string[] aMinQty = new string[20000];
        private string[] aStdCost = new string[20000];
        private string[] aReorderPoint = new string[20000];
        private string[] aReorderQty = new string[20000];
        private string[] aPurchPrice = new string[20000];
        private string[] aLastPurchPrice = new string[20000];
        private string[] aVettedStatus = new string[20000];
        private string[] aAllocations = new string[20000];
        private string[] aMfrName = new string[20000];
        private string[] aMfrPartNumber = new string[20000];
        private string[] aQualification = new string[20000];
        private string[] aPreferred = new string[20000];
        private string[] aMfrDescription = new string[20000];
        private string[] shortage = new string[20000];
        private string[] shortageProductLine = new string[20000];
        private string[] aDampnerDaysLate = new string[20000];
        private string[] aSDSDocumentNo = new string[20000];
        private string[] aP6 = new string[20000];
        private string[] aF6 = new string[20000];
        private string[] aEAU = new string[20000];
        private string[] aHTS = new string[20000];
        private string[] aNetWeight = new string[20000];
        private string[] aNonDomesticVendor = new string[20000];
        private string[] aDampenerPeriod = new string[20000];
        private string[] aDampenerQuantity = new string[20000];
        private string[] aLTAReleaseBucket = new string[20000];
        private string[] aSupplierReplenishment = new string[20000];
        private string[] aFAIonOrder = new string[20000];
        private string[] aFAINettable = new string[20000];
        private string[] aFAINonNettable = new string[20000];

        private string[,] acOrderDate = new string[10000, 100];
        private string[,] acDeliveryDate = new string[10000, 100];
        private string[,] acOrderQuantity = new string[10000, 100];
        private string[,] acAmountStandard = new string[10000, 100];
        private string[,] acLocation = new string[10000, 100];
        private string[,] acAction = new string[10000, 100];
        private string[,] acBinCode = new string[20000, 100];
        private string[,] acOrigDueDate = new string[20000, 100];
        private string[,] acBestDate = new string[20000, 100];

        private string[,] afOrderDate = new string[20000, 100];
        private string[,] afDeliveryDate = new string[20000, 100];
        private string[,] afOrderQuantity = new string[20000, 100];
        private string[,] afAmountStandard = new string[20000, 100];
        private string[,] afLocation = new string[20000, 100];
        private string[,] afAction = new string[10000, 100];
        private string[,] afBinCode = new string[20000, 100];
        private string[,] afOrigDueDate = new string[20000, 100];
        private string[,] afBestDate = new string[20000, 100];

        private string[,] aRecriptDate = new string[20000, 5];
        private string[,] aReceiptOrder = new string[20000, 5];
        private string[,] aReceiptPosition = new string[20000, 5];
        private string[,] aReceiptVendor = new string[20000, 5];
        private string[,] aReceiptPrice = new string[20000, 5];
        private string[,] aReceiptDeliveredQuantity = new string[20000, 5];
        private string[,] aReceiptNetAmount = new string[20000, 5];
        private string[,] aItemText = new string[20000, 10];
        private string[,] aPO = new string[20000, 20];
        private string[,] aPOLine = new string[20000, 20];
        private string[,] aPOLineQty = new string[20000, 20];
        private string[,] aPOLineRequestedDate = new string[20000, 20];
        private string[,] aPOLinePromisedDate = new string[20000, 20];
        private string[,] aPOBest = new string[20000, 20];

        private int[] aMRPCurrentCount = new int[20000];
        private int[] aMRPCurrentPagePlus1 = new int[20000];
        private int[] aMRPFutureCount = new int[20000];
        private int[] aMRPFuturePage1 = new int[20000];
        private int[] aMRPFuturePage2 = new int[20000];
        private int[] aPOLineCount = new int[20000];
        private int[] aReceiptCount = new int[20000];
        private int[] aItemTextCount = new int[20000];
        private bool[] twoPagesRequired = new bool[20000];
        private bool[] pageOnePrinted = new bool[20000];
        private bool[] pageTwoPrinted = new bool[20000];
        private bool[] partOnePrinted = new bool[20000];
        private bool[] partTwoPrinted = new bool[20000];
        private bool[] threePagesRequired = new bool[20000];
        private bool[] pageThreePrinted = new bool[20000];
        private bool[] fourPagesRequired = new bool[20000];
        private bool[] fourThreePrinted = new bool[20000];
        private bool[] currentOverflowPrinted = new bool[20000];

        private int i = 0;
        private int extraPageCount = 0;
        private int statusCount = 1;
        private int pagesPrinted = 0;
        private bool statusPrinted = false;
        private bool wholeLinePrinted = false;
        private bool idGroup = true;
        private int lineNo = 0;
        DataTable table;
        private System.Windows.Forms.ToolStripButton ToolStripButton;
        PrintDialog pDlg;
        PrintPreviewDialog ppd;
        PrintDocument pd;

        private string NAVprefix = "ZYGO$";
        private string ItemNo = string.Empty;
        private string VendorNo = string.Empty;
        private string onOrder = string.Empty;
        private string FAIonOrder = string.Empty;
        private string nettableStock = string.Empty;
        private string nonnetStock = string.Empty;
        private string FAInettable = string.Empty;
        private string FAInonnettable = string.Empty;
        private string blockedStock = string.Empty;
        private string buyerPlanner = string.Empty;
        private string F6 = string.Empty;
        private string EAU = string.Empty;
        private string spend = string.Empty;
        private string Allocations = string.Empty;
        private string AllocationsF6 = string.Empty;
        private string Inspection = string.Empty;

        DataTable dt1;
        DataTable dtDash;
        DataTable dtMRPOrdersCurrent;
        DataTable dtMRPOrdersCurrentPlusPage;
        DataTable dtMRPOrdersFuture;
        DataTable dtReceipts;
        DataTable dtItem;
        
        DataTable dtItemText;
        DataTable dtPOLines;
        SqlDataReader dr;
        SqlDataReader drMain;


        public F3_Sheets()
        {
            InitializeComponent();
        }

        private void F3_Sheets_Load(object sender, EventArgs e)
        {

            /*  Use Replace //MessageBox.Show  MessageBox.Show to be able to see errors.
             *  MacroScheduler needs no interrupts in AutoRun
             */

            /*
             *  Conection used by loop within the reader
             */

            SqlConnection cnxn = new SqlConnection(g.server);

            /*
             *  Connection used to get the items in the loop for processing
             */

            SqlConnection cnxnR = new SqlConnection(g.server);

            /*
             *Connection used to get the Dashboard data
             */

            SqlConnection cnxnDash = new SqlConnection("server=MIDDB01.zygo.com; password=views; " +
                              "user=views; database=Dashboard;");

            /*
             *Connection used to get the old MK data
             */

            SqlConnection cnxnAFE = new SqlConnection("server=CT-MID-SQL11.ametek.com; password=views; " +
                                          "user=views; database=AccessFrontEnds;");



            /*
             *  Get the list of MRP purchased parts for which reports are needed 
             *  use all worksheets and exclude kanban parts - description starts with %
             *  [Ref_ Order Type] = 1 = Purchase
             *  Type = 2 = Item
             */

            if (g.messageChoice == " not ")
            {
                g.messageChoice = " MessageGroup = 'NotCancelOnly' ";
            }
            else
            {
                g.messageChoice = " MessageGroup = 'CancelOnly' ";
            }

            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM MRP_S1 " +
                "WHERE " +

                  g.messageChoice +

                  g.SQLselection +
                                    
                  "ORDER BY " +
                  "[Buyer Planner Code] " +
                  ",[Vendor No_] " +
                  ",Item"
                   , cnxnAFE);



            try
            {
                cnxnAFE.Open();
                drMain = cmd.ExecuteReader();
                dt1 = new DataTable();
                dt1.Load(drMain);
                int check = dt1.Rows.Count; /*  don't need this  */

                drMain = cmd.ExecuteReader();

                while (drMain.Read())
                {
                    aItemNo[i] = drMain.GetString(0);
                    abuyerPlanner[i] = drMain.GetString(1);
                    aLocation[i] = drMain.GetString(2);
                    aDescription[i] = drMain.GetString(4);
                    aCopyExact[i] = drMain.GetString(5);
                    aItemCommodityCode[i] = drMain.GetString(6);
                    aProductType[i] = drMain.GetString(7);
                    aSelectionCode[i] = drMain.GetString(8);
                    aItemGroup[i] = drMain.GetString(9);
                    aSignalCode[i] = drMain.GetString(10);

                    aLeadTime[i] = drMain.GetInt32(11).ToString() + " Days (" + drMain.GetInt32(12).ToString() + " Weeks)";
                    aLotAccumulationPeriod[i] = drMain.GetInt32(13).ToString() + " Days";

                    aCurrentRev[i] = drMain.GetString(14);  /* this from item but should be from doc control */

                    aSafetyStock[i] = drMain.GetInt32(16).ToString();
                    aOrderMethod[i] = drMain.GetString(17);
                    aQtyMultiplier[i] = drMain.GetInt32(18).ToString();
                    aMinQty[i] = drMain.GetInt32(19).ToString();
                    aStdCost[i] = drMain.GetString(20);
                    aPurchPrice[i] = drMain.GetString(21);
                    aLastPurchPrice[i] = drMain.GetString(22);
                    
                    aInspection[i] = drMain.GetString(23);

                    /*  standard cost for calculation    */

                    aReorderPoint[i] = drMain.GetInt32(25).ToString();
                    aReorderQty[i] = drMain.GetInt32(26).ToString();
                    aVettedStatus[i] = drMain.GetInt32(27).ToString();
                    aSIM[i] = drMain.GetString(28);
                    aDampnerDaysLate[i] = drMain.GetInt32(29).ToString();
                    aSDSDocumentNo[i] = drMain.GetString(30);
                    aP6[i] = drMain.GetInt32(31).ToString();
                    aF6[i] = drMain.GetInt32(32).ToString();
                    aEAU[i] = drMain.GetInt32(33).ToString();
                    aHTS[i] = drMain.GetString(34);
                    aNetWeight[i] = drMain.GetString(35);
                    aNonDomesticVendor[i] = drMain.GetString(36);

                    aDampenerPeriod[i] = drMain.GetString(37);
                    //aDampenerQuantity[i] = drMain.GetString(38);

                    aLTAReleaseBucket[i] = drMain.GetString(39);


                    //                 

                    //aVendorNo[i] = drMain.GetString(42);
                    //aVendorName[i] = drMain.GetString(44);
                    //aVendorAddress[i] = drMain.GetString(45 + ", " +
                    //drMain.GetString(7) + ", " +
                    //drMain.GetString(8) + " ";

                    //aVendorContact[i] = drMain.GetString(9);
                    //aVendorPhone[i] = drMain.GetString(10);
                    ////if (drMain[0][7].ToString().Length < 35)
                    ////{
                    //aVendorEmail[i] = drMain.GetString(11);
                    ////}
                    ///*else 
                    //{
                    //    aVendorEmail[i] = drMain[0][7].ToString().Substring(0, 35);
                    //}
                    //*/
                    //aVendorFax[i] = drMain.GetString(12);
                    //aVendorTitle[i] = drMain.GetString(13);
                    //aVendorCommodityCode[i] = drMain.GetString(14);


                    //decimal lt = drMain.GetInt32(22);

                    //    /*  Lead Time is always in work days - the symbol for work days is \u0003
                    //         if greater than one week then add extra week  replace \u00003 with ""*/





                    i++;
                }
            }
            catch (SqlException ex)
            {
                File.AppendAllText(ErrorLog, " 263 Initial Selection List  " + ex.ToString() + Environment.NewLine);
            }
            finally
            {
                cnxnAFE.Close();
            }


            
            
            //aAnnualSpend[i] = spend;
            //aNettableStock[i] = nettableStock;
            //aNonNetStock[i] = nonnetStock;
            //aOnOrder[i] = onOrder;
            //aBlockedStock[i] = blockedStock;
            //   aAllocations[i] = Allocations;
            
            //aFAIonOrder[i] = FAIonOrder;
            //aFAINettable[i] = FAInettable;
            //aFAINonNettable[i] = FAInonnettable;
            //try
            //{
            //    //object y = dtItem.Rows[0][7].GetType();
            //    //decimal lt = Convert.ToDecimal(dtItem.Rows[0][33].ToString());
            //    /*  Dampener Period Time is always in work days - the symbol for work days is \u0003
            //         if greater than one week then add extra week  replace \u00003 with ""*/

            //    //aLeadTime[i] = lt.ToString() + " Days (" + Convert.ToInt32(Math.Ceiling(lt / 5)).ToString() + " Weeks)";
            //    if (dtItem.Rows[0][33].ToString() == "Current Month")
            //    {
            //        aDampenerPeriod[i] = dtItem.Rows[0][33].ToString();
            //    }
            //    else
            //    {
            //        aDampenerPeriod[i] = dtItem.Rows[0][33].ToString() + " Days";
            //    }
            //}
            ////           
            //   


            /*
            *  Doc Control
            */

            cmd = new SqlCommand(
                "SELECT * FROM MRP_S2 " +
                "WHERE Item IN " +
                "(Select item from MRP_s1 WHERE " + g.messageChoice + " ", cnxnAFE);


            try
            {
                cnxnAFE.Open();
                dtDash = new DataTable();
                dr = cmd.ExecuteReader();
                dtDash.Load(dr);
            }
            catch (SqlException ex)
            {
                File.AppendAllText(ErrorLog, " 289 " + ex.ToString() + Environment.NewLine);
            }
            finally
            {
                cnxnAFE.Close();
            }




            /* MRP current  */

            cmd = new SqlCommand(
                "SELECT * FROM MRP_S3 " +
                "WHERE CF = 'Current' " +
                "ORDER BY [StartingDate] ", cnxnAFE);


            try
            {
                cnxnAFE.Open();
                dtMRPOrdersCurrent = new DataTable();
                dr = cmd.ExecuteReader();
                dtMRPOrdersCurrent.Load(dr);
            }
            catch (SqlException ex)
            {
                File.AppendAllText(ErrorLog, " 312 " + ex.ToString() + Environment.NewLine);
            }
            finally
            {
                cnxnAFE.Close();
            }

            aMRPCurrentCount[i] = dtMRPOrdersCurrent.Rows.Count;


            /*  MRP Future  */

            cmd = new SqlCommand(
            "SELECT * FROM MRP_S3 " +
            "WHERE CF = 'Future' " +
            "ORDER BY [StartingDate] ", cnxnAFE);


            try
            {
                cnxnAFE.Open();
                dtMRPOrdersFuture = new DataTable();
                dr = cmd.ExecuteReader();
                dtMRPOrdersFuture.Load(dr);

            }
            catch (SqlException ex)
            {
                File.AppendAllText(ErrorLog, " 1143 " + ItemNo + "   " + ex.ToString() + Environment.NewLine);
            }
            finally
            {
                cnxnAFE.Close();
            }

            aMRPFutureCount[i] = dtMRPOrdersFuture.Rows.Count;

            /*
             * 
             * PO Lines (next 20)
             * 
             */

            cmd = new SqlCommand(

                "SELECT * FROM MRP_Open_PO ORDER BY RRD ", cnxnAFE);

            try
            {
                cnxnAFE.Open();
                dtPOLines = new DataTable();
                dr = cmd.ExecuteReader();
                dtPOLines.Load(dr);

            }
            catch (SqlException ex)
            {
                File.AppendAllText(ErrorLog, " 1185 " + ItemNo + "   " + ex.ToString() + Environment.NewLine);
            }
            finally
            {
                cnxnAFE.Close();
            }

            aPOLineCount[i] = dtPOLines.Rows.Count;

            /*
                *  Last 5 receipts
                */

            cmd = new SqlCommand(

                "SELECT * from MRP_Item_Receipts ORDER BY RDate DESC "
                , cnxnAFE);

            dtReceipts = new DataTable();

            try
            {
                cnxnAFE.Open();
                dr = cmd.ExecuteReader();
                dtReceipts.Load(dr);

            }
            catch (SqlException ex)
            {
                File.AppendAllText(ErrorLog, " 1224 " + ItemNo + "   " + ex.ToString() + Environment.NewLine);
            }
            finally
            {
                cnxnAFE.Close();
            }

                             






            //aReceiptCount[i] = dtReceipts.Rows.Count;

            /*  Item Card Text */

            /*
             *  Get the item text from the text module line but
             *  if it contains the work embedded, go to the embedded text table
             *  and get the text
             *  
             * */

            //loopCmd = new SqlCommand
            //   ("SELECT " +
            //   "[Code 1] " +
            //   ",Text " +
            //   "FROM [" + NAVprefix + "Text Module Line] " +
            //   "WHERE [Code 1] = '" + ItemNo + "' "
            //   , cnxn);


            //try
            //{
            //    cnxn.Open();
            //    dtItemText = new DataTable();
            //    dr = loopCmd.ExecuteReader();
            //    dtItemText.Load(dr);

            //}
            //catch (SqlException ex)
            //{
            //    File.AppendAllText(ErrorLog, " 1312 " + ItemNo + "   " + ex.ToString() + Environment.NewLine);
            //}
            //finally
            //{
            //    cnxn.Close();
            //}

            //aItemTextCount[i] = dtItemText.Rows.Count;

            //if (dtItemText.Rows.Count > 0)
            //{
            //    if (dtItemText.Rows[0][1].ToString().Contains("mbed"))
            //    {
            //        loopCmd = new SqlCommand
            //           ("SELECT " +
            //           "COUNT(Text) " +
            //           "FROM NAV_EmbeddedText " +
            //           "WHERE [NAV_Key_1] = '" + ItemNo + "' " +
            //           "AND NAV_Table = 27 "
            //           , cnxnAFE);

            //        int rows = 9999;

            //        try
            //        {
            //            cnxnAFE.Open();
            //            rows = loopCmd.ExecuteNonQuery();
            //        }
            //        catch (SqlException ex)
            //        {
            //            File.AppendAllText(ErrorLog, " 1342 " + ItemNo + "   " + ex.ToString() + Environment.NewLine);
            //        }
            //        finally
            //        {
            //            cnxnAFE.Close();
            //        }

            //        if (rows > 0)
            //        {
            //            loopCmd = new SqlCommand
            //               ("SELECT " +
            //               "Text " +
            //               "FROM NAV_EmbeddedText " +
            //               "WHERE [NAV_Key_1] = '" + ItemNo + "' " +
            //               "AND NAV_Table = 27 "
            //               , cnxnAFE);

            //            try
            //            {
            //                cnxnAFE.Open();
            //                dtItemText.Columns[1].MaxLength = -1; /* -1 = no max length   */
            //                dtItemText.Rows[0][1] = (string)loopCmd.ExecuteScalar();
            //            }
            //            catch (SqlException ex)
            //            {
            //                File.AppendAllText(ErrorLog, " 1367 " + ItemNo + "   " + ex.ToString() + Environment.NewLine);
            //            }
            //            finally
            //            {
            //                cnxnAFE.Close();
            //            }
            //        }
            //    }
            //}


            /*  Shortage */

            //SqlCommand loopCmd = new SqlCommand
            //    ("SELECT " +
            //    " ID " +
            //    ",ProductLine " +
            //    "FROM Shortage_List " +
            //    "WHERE ItemCode = '" + ItemNo + "' " +
            //    "AND DateArchived is null "
            //    , cnxnAFE);

            //try
            //{
            //    cnxnAFE.Open();

            //    DataTable dtTemp = new DataTable();

            //    try
            //    {
            //        dr = loopCmd.ExecuteReader();
            //        dtTemp.Load(dr);
            //    }
            //    catch (SqlException ex)
            //    {
            //        File.AppendAllText(ErrorLog, " 1402 " + ItemNo + "   " + ex.ToString() + Environment.NewLine);
            //    }
            //    finally
            //    {
            //        cnxnAFE.Close();
            //    }

            //    if (dtTemp.Rows.Count > 0)
            //    {
            //        shortage[i] = dtTemp.Rows[0][0].ToString();
            //        shortageProductLine[i] = dtTemp.Rows[0][1].ToString();
            //    }
            //    else
            //    {
            //        shortage[i] = "";
            //        shortageProductLine[i] = "";
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    File.AppendAllText(ErrorLog, " 1422 " + ItemNo + "   " + ex.ToString() + Environment.NewLine);
            //}
            //finally
            //{
            //    cnxnAFE.Close();
            //}

            //        try
            //        {
            //            aItemNo[i] = ItemNo;
            //            abuyerPlanner[i] = buyerPlanner;
            //            if (dtVendor.Rows.Count > 0)
            //            {
            //                try
            //                {
            
            //                }
            //                catch (Exception ex)
            //                {
            //File.AppendAllText(ErrorLog, " 1459 " + ItemNo + "   " + ex.ToString() + Environment.NewLine);
            //                }
            //            }
            //            else
            //            {
            //                aVendorNo[i] = " ";
            //                aVendorName[i] = " ";
            //                aVendorAddress[i] = " ";
            //                aVendorContact[i] = " ";
            //                aVendorPhone[i] = " ";
            //                aVendorEmail[i] = " ";
            //                aVendorFax[i] = " ";
            //                aVendorTitle[i] = " ";
            //                aVendorCommodityCode[i] = " ";
            //            }

            //            if (dtItem.Rows.Count > 0)
            //            {
            //                try
            //                {
            

            string here;


            //try
            //{
            //    //object y = dtItem.Rows[0][7].GetType();
                
            //}
            //catch (Exception ex)
            //{
            //    File.AppendAllText(ErrorLog, " 1502      " + dtItem.Rows[0][7].ToString() + "     " + ex.ToString() + Environment.NewLine);
            //}



            ////         catch (Exception ex)
            //{
            //    File.AppendAllText(ErrorLog, " 1555     " + dtItem.Rows[0][7].ToString() + "     " + ex.ToString() + Environment.NewLine);
            //}

            //aDampenerQuantity[i] = dtItem.Rows[0][34].ToString();

            //aLTAReleaseBucket[i] = dtItem.Rows[0][35].ToString();
            //aSupplierReplenishment[i] = dtItem.Rows[0][36].ToString();

            ////                }
            ////                catch (Exception ex)
            ////                {
            //File.AppendAllText(ErrorLog, " 1567   " + ex.ToString() + Environment.NewLine);
            ////                }
            ////            }
            //            else
            //            {
            //                aCopyExact[i] = " ";
            //                aInspection[i] = " ";
                            aLocation[i] = " ";
            //                aDescription[i] = " ";
            //                aItemCommodityCode[i] = " ";
            //                aProductType[i] = " ";
            //                aSelectionCode[i] = "**None** ";
            //                aItemGroup[i] = "**None** ";
            //                aSignalCode[i] = "**None** ";
            //                aLeadTime[i] = " ";
            //                aLotAccumulationPeriod[i] = " ";
            //                aCurrentRev[i] = " ";

            //                aAnnualSpend[i] = "0.00";
            //                aNettableStock[i] = " ";
            //                aNonNetStock[i] = " ";
            //                aOnOrder[i] = " ";
            //                aBlockedStock[i] = " ";
            //                aSafetyStock[i] = " ";
            //                aSIM[i] = " ";
            //                aP6[i] = "0.00";
            //                aF6[i] = "0.00";
            //                aEAU[i] = "0.00";
            //                aOrderMethod[i] = " ";
            //                aQtyMultiplier[i] = " ";
            //                aMinQty[i] = " ";
            //                aStdCost[i] = " ";
            //                aPurchPrice[i] = " ";
            //                aLastPurchPrice[i] = " ";
            //                aAllocations[i] = " ";
            //                aHTS[i] = " ";
            //                aNetWeight[i] = " ";
            //                aLTAReleaseBucket[i] = " ";
            //                aSupplierReplenishment[i] = " ";
            //            }

            //            if (dtDocCtrl.Rows.Count > 0)
            //            {
            //                try
            //                {
            //aSource[i] = dtDocCtrl.Rows[0][2].ToString();
            //aECOstatus[i] = dtDocCtrl.Rows[0][3].ToString();
            //aDateRevCreated[i] = dtDocCtrl.Rows[0][1].ToString();
            //aOwner[i] = dtDocCtrl.Rows[0][4].ToString();
            //                }
            //                catch (Exception ex)
            //                {
            //File.AppendAllText(ErrorLog, " 1619    " + ex.ToString() + Environment.NewLine);
            //                }
            //            }
            //            else
            //            {
            //                aSource[i] = " ";
            //                aECOstatus[i] = " ";
            //                aDateRevCreated[i] = " ";
            //                aOwner[i] = " ";
            //            }

            //            if (dtPINS.Rows.Count > 0)
            //            {
            //                try
            //                {
            //aMfrName[i] = dtPINS.Rows[0][0].ToString();
            //aMfrPartNumber[i] = dtPINS.Rows[0][1].ToString();
            //aQualification[i] = " ";
            //aPreferred[i] = dtPINS.Rows[0][3].ToString();
            //aMfrDescription[i] = dtPINS.Rows[0][4].ToString();
            //                }
            //                catch (Exception ex)
            //                {
            //File.AppendAllText(ErrorLog, " 1641   " + ex.ToString() + Environment.NewLine);
            //                }
            //            }
            //            else
            //            {
            //                aMfrName[i] = " ";
            //                aMfrPartNumber[i] = " ";
            //                aQualification[i] = " ";
            //                aPreferred[i] = " ";
            //                aMfrDescription[i] = " ";
            //            }

            //            if (dtMRPOrdersCurrent.Rows.Count > 0)
            //            {
            //                for (int ii = 0; ii < dtMRPOrdersCurrent.Rows.Count; ii++)
            //                {
            //try
            //{
            //    acOrderDate[i, ii] = dtMRPOrdersCurrent.Rows[ii][0].ToString();
            //    acDeliveryDate[i, ii] = dtMRPOrdersCurrent.Rows[ii][1].ToString();
            //    acOrderQuantity[i, ii] = dtMRPOrdersCurrent.Rows[ii][2].ToString();
            //    acAmountStandard[i, ii] = dtMRPOrdersCurrent.Rows[ii][3].ToString();
            //    acLocation[i, ii] = dtMRPOrdersCurrent.Rows[ii][4].ToString();
            //    /* writing over item card location with mrp location     */
            //    aLocation[i] = dtMRPOrdersCurrent.Rows[ii][4].ToString();
            //    acBinCode[i, ii] = dtMRPOrdersCurrent.Rows[ii][5].ToString();
            //    acAction[i, ii] = dtMRPOrdersCurrent.Rows[ii][6].ToString();
            //    if (dtMRPOrdersCurrent.Rows[ii][7].ToString() == "01/01/53")
            //    {
            //        acOrigDueDate[i, ii] = "";
            //    }
            //    else
            //    {
            //        acOrigDueDate[i, ii] = dtMRPOrdersCurrent.Rows[ii][7].ToString();
            //    }
            //    acBestDate[i, ii] = dtMRPOrdersCurrent.Rows[ii][8].ToString();
            //}
            //catch (Exception ex)
            //{
            //    File.AppendAllText(ErrorLog, " 1681    " + ex.ToString() + Environment.NewLine);
            //}
            ////                }
            //            }

            //            if (dtMRPOrdersCurrent.Rows.Count == 0 & dtMRPOrdersFuture.Rows.Count > 0)
            //            {
            //                aLocation[i] = dtMRPOrdersFuture.Rows[0][4].ToString();
            //            }

            //            if (dtMRPOrdersFuture.Rows.Count > 0)
            //            {
            //                for (int ii = 0; ii < dtMRPOrdersFuture.Rows.Count; ii++)
            //                {
            //try
            //{
            //    afOrderDate[i, ii] = dtMRPOrdersFuture.Rows[ii][0].ToString();
            //    afDeliveryDate[i, ii] = dtMRPOrdersFuture.Rows[ii][1].ToString();
            //    afOrderQuantity[i, ii] = dtMRPOrdersFuture.Rows[ii][2].ToString();
            //    afAmountStandard[i, ii] = dtMRPOrdersFuture.Rows[ii][3].ToString();
            //    afLocation[i, ii] = dtMRPOrdersFuture.Rows[ii][4].ToString();
            //    afBinCode[i, ii] = dtMRPOrdersFuture.Rows[ii][5].ToString();
            //    afAction[i, ii] = dtMRPOrdersFuture.Rows[ii][6].ToString();
            //    if (dtMRPOrdersFuture.Rows[ii][7].ToString() == "01/01/53")
            //    {
            //        afOrigDueDate[i, ii] = "";
            //    }
            //    else
            //    {
            //        afOrigDueDate[i, ii] = dtMRPOrdersFuture.Rows[ii][7].ToString();
            //    }
            //    afBestDate[i, ii] = dtMRPOrdersFuture.Rows[ii][8].ToString();
            //}
            //catch (Exception ex)
            //{
            //    File.AppendAllText(ErrorLog, " 1716    " + ex.ToString() + Environment.NewLine);
            //}
            ////                }
            ////            }


            ////            if (dtPOLines.Rows.Count > 0)
            ////            {
            ////                for (int ii = 0; ii < dtPOLines.Rows.Count & ii < 20; ii++)
            ////                {
            //try
            //{
            //    aPO[i, ii] = dtPOLines.Rows[ii][0].ToString();
            //    aPOLine[i, ii] = dtPOLines.Rows[ii][1].ToString();
            //    aPOLineQty[i, ii] = dtPOLines.Rows[ii][2].ToString();
            //    aPOLineRequestedDate[i, ii] = dtPOLines.Rows[ii][3].ToString();
            //    aPOLinePromisedDate[i, ii] = dtPOLines.Rows[ii][4].ToString();
            //    aPOBest[i, ii] = dtPOLines.Rows[ii][5].ToString();
            //}
            //catch (Exception ex)
            //{
            //    File.AppendAllText(ErrorLog, " 1737    " + ex.ToString() + Environment.NewLine);
            //}
            ////                }
            //            }



            //            if (dtReceipts.Rows.Count > 0)
            //            {
            //                for (int ii = 0; ii < dtReceipts.Rows.Count & ii < 5; ii++)
            //                {
            //try
            //{
            //    aRecriptDate[i, ii] = dtReceipts.Rows[ii][0].ToString();
            //    aReceiptOrder[i, ii] = dtReceipts.Rows[ii][1].ToString();
            //    aReceiptPosition[i, ii] = dtReceipts.Rows[ii][2].ToString();
            //    aReceiptVendor[i, ii] = dtReceipts.Rows[ii][3].ToString();
            //    aReceiptPrice[i, ii] = dtReceipts.Rows[ii][4].ToString();
            //    aReceiptDeliveredQuantity[i, ii] = dtReceipts.Rows[ii][5].ToString();
            //    aReceiptNetAmount[i, ii] = dtReceipts.Rows[ii][6].ToString();
            //}
            //catch (Exception ex)
            //{
            //    File.AppendAllText(ErrorLog, " 1760    " + ex.ToString() + Environment.NewLine);
            //}
            ////                }
            ////            }


            //            if (dtItemText.Rows.Count > 0)
            //            {
            //                for (int ii = 0; ii < dtItemText.Rows.Count; ii++)
            //                {
            //try
            //{
            //    aItemText[i, ii] = dtItemText.Rows[ii][1].ToString();

            //}
            //catch (Exception ex)
            //{
            //    File.AppendAllText(ErrorLog, " 1777    " + ex.ToString() + " i " + i.ToString() + " ii " + ii.ToString() + "  " + Environment.NewLine);
            //}
            //                }
            //            }

            //            /*
            //            * 
            //            * Determine if it will fit on one page
            //            * 
            //            */
            //            int aa = aMRPCurrentCount[i];
            //            int ab = aPOLineCount[i];
            //            int ac = aMRPFutureCount[i];
            //            int ad = aReceiptCount[i];
            //            int ae = aItemTextCount[i];
            //            int part1Lines = 0;

            //            if (aa >= ab)
            //            {
            //                part1Lines = aa;
            //            }
            //            else
            //            {
            //                part1Lines = ab;
            //            }

            //            if (aa > 28)
            //            {
            //                aMRPCurrentPagePlus1[i] = aa - 28;
            //                twoPagesRequired[i] = true;
            //                extraPageCount++;
            //            }
            //            else
            //            {
            //                if (26 - (aMRPCurrentCount[i] + aMRPFutureCount[i] + aReceiptCount[i] + aItemTextCount[i]) <= 0)
            //                {
            twoPagesRequired[i] = true;
            extraPageCount++;

            if ((aMRPFutureCount[i] + aReceiptCount[i] + aItemTextCount[i]) > 40)
            {
                threePagesRequired[i] = true;
            }
            else
            {
                threePagesRequired[i] = false;
            }

            if ((aMRPFutureCount[i] + aReceiptCount[i] + aItemTextCount[i]) > 40)
            {
                fourPagesRequired[i] = true;
            }
            else
            {
                fourPagesRequired[i] = false;
            }
            //                }
            //                else
            //                {
            twoPagesRequired[i] = false;
            threePagesRequired[i] = false;
            fourPagesRequired[i] = false;
            //                }
            //            }
            //            i++;
            //        }
            //        catch (Exception ex)
            //        {
            //            File.AppendAllText(ErrorLog, " 1845    " + ex.ToString() + Environment.NewLine);
            //        }
            //    }
            
            ////catch (Exception ex)
            ////{
            ////    File.AppendAllText(ErrorLog, " 1854    " + ex.ToString() + Environment.NewLine);
            ////}

            ///*  colins and back slashes in the date time make the path unreadable    */
            //string today = DateTime.Now.ToString("MM-dd-yy hh.mm.ss");

            //string file = string.Empty;

            ////if (g.messageCancel)
            ////{
            ////    file = "MRP CANCEL " + g.rptName + g.ReportSelection + today + ".pdf";
            ////}
            ////else
            ////{
            ////    file = "MRP " + g.rptName + g.ReportSelection + today + ".pdf";
            ////}

            //PrintDocument pd = new PrintDocument();
            //pd.DefaultPageSettings.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            //pd.PrinterSettings.PrintToFile = true;
            //pd.PrinterSettings.PrintFileName = Path.Combine(directory, file);
            //StandardPrintController pc = new StandardPrintController();
            //pd.PrintController = pc;

            //pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            //try
            //{
            //    pd.Print();
            //}
            //catch (Exception ex)
            //{
            //    File.AppendAllText(ErrorLog, " 1882    " + ex.ToString() + Environment.NewLine);
            //}

            //this.Close();
        




        }





        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            /*
             * 
             *  PrintPage runs all the way to the bottom bracket "}"
             *  before evaluating if there is another page and
             *  then runs through again.
             * 
             */

            string date = DateTime.Now.ToString();

            DateTime MRPSunday = DateTime.Now;
            while (MRPSunday.DayOfWeek != DayOfWeek.Sunday)
                MRPSunday = MRPSunday.AddDays(-1);

            string reportSunday = MRPSunday.ToShortDateString();

            int linedrop = 100;

            //if (!partOnePrinted[lineNo])
            //{
            //    linedrop = 100;
            //}


            int linesPerpage = 30;  //40
            //int lineNo = this.pagesPrinted * linesPerpage;
            int pageNo = pagesPrinted + 1;
            //double NumPages = Math.Ceiling(((i - 1) / 24.0));
            double NumPages = Convert.ToDouble(i);
            NumPages = NumPages + Convert.ToDouble(extraPageCount);

            Pen pen = new Pen(Color.Red);
            Pen Gpen = new Pen(Color.Green);
            Pen Bpen = new Pen(Color.Turquoise);
            Pen Ypen = new Pen(Color.Orange);
            Ypen.Width = 25;
            Gpen.Width = 3;
            pen.Width = 1;
            Font A9R = new Font("arial", 9, FontStyle.Regular);
            Font title = new Font("arial", 16, FontStyle.Bold);
            Font heading = new Font("arial", 9, FontStyle.Bold);
            Font B12 = new Font("arial", 12, FontStyle.Bold);
            Font U9 = new Font("arial", 9, FontStyle.Underline);
            StringFormat alignR = new StringFormat();
            alignR.Alignment = StringAlignment.Far;
            int n = 0;

            //  the print location is X, Y

            if (shortage[lineNo] != "")
            {
                ev.Graphics.DrawLine(Ypen, 25, 10, 800, 10);
                ev.Graphics.DrawString("SHORTAGE ID = " + shortage[lineNo], A9R, Brushes.Black, 250, 10);
                ev.Graphics.DrawString("SHORTAGE Product Line = " + shortageProductLine[lineNo], A9R, Brushes.Black, 450, 10);
            }

            /*
             * if (partOnePrinted[lineNo] && (!partTwoPrinted[lineNo]) & !twoPagesRequired[lineNo])
             * if (pageOnePrinted[lineNo] && (!partTwoPrinted[lineNo]) & twoPagesRequired[lineNo])
             * */
            if (twoPagesRequired[lineNo])
            {
                ev.Graphics.DrawString("Two Pages Required for " + aItemNo[lineNo], A9R, Brushes.Black, 25, 50);
            }

            ev.Graphics.DrawString(g.rptName + " Data as of: " + date, A9R, Brushes.Black, 25, 25);
            ev.Graphics.DrawString(abuyerPlanner[lineNo], heading, Brushes.Black, 350, 25);
            ev.Graphics.DrawString("MRP Report: " + g.ReportSelection, A9R, Brushes.Black, 600, 25);
            //ev.Graphics.DrawString("MRP Date: " + reportSunday, A9R, Brushes.Black, 600, 25);
            ev.Graphics.DrawString("Page  " + pageNo + " of " + NumPages, A9R, Brushes.Black, 600, 50);

            if (aVettedStatus[lineNo] == "1")
            {
                ev.Graphics.DrawString("*************** ......NON-VETTED...... ***************", B12, Brushes.Purple, 225, 50);
            }
            ////File.AppendAllText(@"C:\A\PrintStartMRP .txt", DateTime.Now.ToShortTimeString() + Environment.NewLine);

            ev.Graphics.DrawLine(pen, 25, 70, 800, 70);


            if (!partOnePrinted[lineNo])
            {
                print_PartOne(ev, linedrop);
                partOnePrinted[lineNo] = true;
            }

            /*  part one printed - part two not printed - two pages not required    */

            //if (partOnePrinted[lineNo] && (!partTwoPrinted[lineNo]) & !twoPagesRequired[lineNo])
            //{
            //    print_PartTwo(ev, linedrop);
            //    partTwoPrinted[lineNo] = true;
            //}

            /*  for two page parts  */



            if (twoPagesRequired[lineNo])
            {
                if (pageOnePrinted[lineNo] && !partTwoPrinted[lineNo])
                {
                    if (aMRPCurrentPagePlus1[lineNo] < 1)
                    {
                        print_PartTwo(ev, linedrop);
                        partTwoPrinted[lineNo] = true;
                    }
                    else
                    {
                        printCurrentOverflow(ev);
                        //print_PartTwo(ev, linedrop);
                        partTwoPrinted[lineNo] = true;
                    }
                }

                if (partOnePrinted[lineNo] && !partTwoPrinted[lineNo])
                {
                    ev.HasMorePages = true;
                    pageOnePrinted[lineNo] = true;
                    pagesPrinted++;

                }

                if (partOnePrinted[lineNo] && partTwoPrinted[lineNo])
                {
                    lineNo++;

                    if (i > lineNo)
                    {
                        ev.HasMorePages = true;
                        pagesPrinted++;
                    }
                }
            }

            else
            {
                if ((i - 1) > lineNo)
                {
                    ev.HasMorePages = true;
                    pageOnePrinted[lineNo] = true;
                    pagesPrinted++;
                }
                else
                {
                    ev.HasMorePages = false;
                    linedrop = 160;
                    pagesPrinted = 0;
                    lineNo = 0;
                }

                lineNo++;
            }

        }


        private void print_PartOne(PrintPageEventArgs ev, int linedrop)
        {
            Pen pen = new Pen(Color.Red);
            Pen Gpen = new Pen(Color.Green);
            Pen Bpen = new Pen(Color.Turquoise);
            Pen Ypen = new Pen(Color.Orange);
            Ypen.Width = 25;
            Gpen.Width = 3;
            pen.Width = 1;
            Font A9R = new Font("arial", 9, FontStyle.Regular);
            Font title = new Font("arial", 16, FontStyle.Bold);
            Font heading = new Font("arial", 9, FontStyle.Bold);
            Font B12 = new Font("arial", 12, FontStyle.Bold);
            Font U9 = new Font("arial", 9, FontStyle.Underline);
            StringFormat alignR = new StringFormat();
            alignR.Alignment = StringAlignment.Far;

            try
            {

                /*  Vendor data     */


                ev.Graphics.DrawString(aVendorNo[lineNo], heading, Brushes.Black, 25, 80);
                ev.Graphics.DrawString(aVendorName[lineNo], heading, Brushes.Black, 75, 80);
                ev.Graphics.DrawString(aVendorAddress[lineNo], A9R, Brushes.Black, 400, 80);
                ev.Graphics.DrawString("Contact: " + aVendorContact[lineNo], A9R, Brushes.Black, 25, 100);
                ev.Graphics.DrawString("Phone: " + aVendorPhone[lineNo], A9R, Brushes.Black, 25, 120);
                ev.Graphics.DrawString("Fax: " + aVendorFax[lineNo], A9R, Brushes.Black, 25, 140);

                ev.Graphics.DrawString("Email: " + aVendorEmail[lineNo], A9R, Brushes.Black, 300, 140);
                //ev.Graphics.DrawString("Fax: " + aVendorFax[lineNo], A9R, Brushes.Black, 300, 140);

                ev.Graphics.DrawString("Vendor Title: " + aVendorTitle[lineNo], A9R, Brushes.Black, 300, 100);
                ev.Graphics.DrawString("Supplier Line of Business: " + aVendorCommodityCode[lineNo], A9R, Brushes.Black, 300, 120);

            }
            catch (Exception ex)
            {
                File.AppendAllText(ErrorLog, " 2089 Vendor Data " + ex.ToString() + Environment.NewLine);

            }

            ev.Graphics.DrawLine(pen, 25, 160, 800, 160);

            /*  Item Data   */

            try
            {
                ev.Graphics.DrawString("Copy Exact?", heading, Brushes.Black, 25, 165);
                ev.Graphics.DrawString(aCopyExact[lineNo], heading, Brushes.Red, 105, 165);

                ev.Graphics.DrawString("Inspection?  " + aInspection[lineNo], heading, Brushes.Black, 350, 165);


                if (aLocation[lineNo] == "MID")
                {
                    Bpen = new Pen(Color.Turquoise);
                }
                else if (aLocation[lineNo] == "MID SVC")
                {
                    Bpen = new Pen(Color.Blue);
                }
                else if (aLocation[lineNo] == "IRV")
                {
                    Bpen = new Pen(Color.Orange);
                }
                else if (aLocation[lineNo] == "IRV MRB")
                {
                    Bpen = new Pen(Color.Yellow);
                }
                else if (aLocation[lineNo] == "RIC")
                {
                    Bpen = new Pen(Color.Red);
                }
                else
                {
                    Bpen = new Pen(Color.Black);
                }

                Bpen.Width = 10;


                ev.Graphics.DrawLine(Bpen, 770, 165, 770, 220);
                ev.Graphics.DrawLine(Bpen, 570, 170, 770, 170);
                ev.Graphics.DrawLine(Bpen, 570, 215, 770, 215);
                ev.Graphics.DrawLine(Bpen, 570, 165, 570, 220);


                ev.Graphics.DrawString(aLocation[lineNo], title, Brushes.Black, 600, 180);

                ////File.AppendAllText(@"C:\A\PrintedMRP1 .txt", aItemNo[lineNo].ToString() + Environment.NewLine);

                ev.Graphics.DrawLine(Gpen, 25, 189, 25, 241);
                ev.Graphics.DrawLine(Gpen, 25, 190, 550, 190);
                ev.Graphics.DrawLine(Gpen, 25, 240, 550, 240);
                ev.Graphics.DrawLine(Gpen, 550, 189, 550, 241);


                ev.Graphics.DrawString(aItemNo[lineNo], B12, Brushes.Black, 30, 200);

                ev.Graphics.DrawString(aDescription[lineNo], heading, Brushes.Black, 250, 203);

                /*  Revision Data   */

                try
                {
                    ev.Graphics.DrawString("Current Rev: ", heading, Brushes.Black, 30, 220);
                    ev.Graphics.DrawString(aCurrentRev[lineNo], A9R, Brushes.Black, 110, 220);
                    ev.Graphics.DrawString("Rev Date: ", heading, Brushes.Black, 250, 220);
                    ev.Graphics.DrawString(aDateRevCreated[lineNo], A9R, Brushes.Black, 315, 220);
                }
                catch (Exception ex)
                {
                    File.AppendAllText(ErrorLog, " 2163 Revision Data " + ex.ToString() + Environment.NewLine);

                }

                ev.Graphics.DrawString("Commodity Code:", heading, Brushes.Black, 25, 245);
                ev.Graphics.DrawString(aItemCommodityCode[lineNo], A9R, Brushes.Black, 135, 245);
                ev.Graphics.DrawString("Product Type:", heading, Brushes.Black, 25, 260);
                ev.Graphics.DrawString(aProductType[lineNo], A9R, Brushes.Black, 135, 260);
                ev.Graphics.DrawString("Selection Code:", heading, Brushes.Black, 25, 275);
                ev.Graphics.DrawString(aSelectionCode[lineNo], A9R, Brushes.Black, 135, 275);

                ev.Graphics.DrawString("Item Group:", heading, Brushes.Black, 25, 290);
                ev.Graphics.DrawString(aItemGroup[lineNo], A9R, Brushes.Black, 135, 290);


                ev.Graphics.DrawString("Signal Code:", heading, Brushes.Black, 25, 305);

                if (aSignalCode[lineNo] == "** None **")
                {
                    ev.Graphics.DrawString(aSignalCode[lineNo], A9R, Brushes.Black, 135, 305);
                }
                else
                {
                    ev.Graphics.DrawString(aSignalCode[lineNo], A9R, Brushes.Red, 135, 305);
                }

                ev.Graphics.DrawString("Lead Time: ", heading, Brushes.Black, 25, 320);
                ev.Graphics.DrawString(aLeadTime[lineNo], A9R, Brushes.Black, 135, 320);

                if (aNonDomesticVendor[lineNo] == "TRUE" & aHTS[lineNo] == "")
                {
                    ev.Graphics.DrawString("HTS Code: ", heading, Brushes.Red, 260, 320);
                }
                else
                {
                    ev.Graphics.DrawString("HTS Code: ", heading, Brushes.Black, 260, 320);
                    ev.Graphics.DrawString(aHTS[lineNo], A9R, Brushes.Black, 340, 320);
                }

                ev.Graphics.DrawString("Lot Accumulation Period: ", heading, Brushes.Black, 25, 335);
                ev.Graphics.DrawString(aLotAccumulationPeriod[lineNo], A9R, Brushes.Black, 185, 335);

                ev.Graphics.DrawString("LTA Release Bucket: ", heading, Brushes.Black, 25, 350);
                ev.Graphics.DrawString(aLTAReleaseBucket[lineNo] + " days", A9R, Brushes.Black, 185, 350);

                ev.Graphics.DrawString("Supplier Replenishment: ", heading, Brushes.Black, 260, 350);
                ev.Graphics.DrawString(aSupplierReplenishment[lineNo] + " days", A9R, Brushes.Black, 420, 350);

                if (aNonDomesticVendor[lineNo] == "TRUE" & aNetWeight[lineNo] == "0.000000")
                {
                    ev.Graphics.DrawString("Net Wt (kg): ", heading, Brushes.Red, 260, 335);
                }
                else
                {
                    ev.Graphics.DrawString("Net Wt (kg): ", heading, Brushes.Black, 260, 335);
                    ev.Graphics.DrawString(aNetWeight[lineNo], A9R, Brushes.Black, 340, 335);
                }

                ev.Graphics.DrawString("Dampener Period: ", heading, Brushes.Black, 25, 365);
                /*  need to start the text in different spots due to length of string    */
                if (aDampenerPeriod[lineNo] == "Current Month")
                {
                    ev.Graphics.DrawString(aDampenerPeriod[lineNo], A9R, Brushes.Black, 140, 366);
                }
                else
                {
                    ev.Graphics.DrawString(aDampenerPeriod[lineNo], A9R, Brushes.Black, 185, 365);
                }

                ev.Graphics.DrawString("Dampener Quantity: ", heading, Brushes.Black, 260, 365);
                ev.Graphics.DrawString(aDampenerQuantity[lineNo], A9R, Brushes.Black, 400, 365);


                ev.Graphics.DrawString("Dampener Days Late: ", heading, Brushes.Black, 25, 380);
                ev.Graphics.DrawString(aDampnerDaysLate[lineNo], A9R, Brushes.Black, 185, 380);


                /* using rectangles to get data to line up correctly    */

                ev.Graphics.DrawString("P6: ", heading, Brushes.Black, 25, 395);
                var box = new Rectangle(40, 395, 35, 20);
                ev.Graphics.DrawString(aP6[lineNo], A9R, Brushes.Black, box, alignR);

                ev.Graphics.DrawString("F6: ", heading, Brushes.Black, 100, 395);
                box = new Rectangle(115, 395, 35, 20);
                ev.Graphics.DrawString(aF6[lineNo], A9R, Brushes.Black, box, alignR);

                ev.Graphics.DrawString("EAU: ", heading, Brushes.Black, 175, 395);
                box = new Rectangle(200, 395, 35, 20);
                ev.Graphics.DrawString(aEAU[lineNo], A9R, Brushes.Black, box, alignR);

                ev.Graphics.DrawString("Order Method: ", heading, Brushes.Black, 260, 395);
                ev.Graphics.DrawString(aOrderMethod[lineNo], A9R, Brushes.Black, 350, 395);

                //box = new Rectangle(400, 350, 100, 20);
                ev.Graphics.DrawString("SDS Doc No: ", heading, Brushes.Black, 260, 380);
                //box = new Rectangle(500, 350, 55, 20);
                ev.Graphics.DrawString(aSDSDocumentNo[lineNo], A9R, Brushes.Black, 340, 380);

                if (aFAIonOrder[lineNo] != "0.00" | aFAINettable[lineNo] != "0.00" | aFAINonNettable[lineNo] != "0.00")
                {
                    Bpen = new Pen(Color.Red);
                }
                else
                {
                    Bpen = new Pen(Color.Black);
                }

                Bpen.Width = 4;

                ev.Graphics.DrawLine(Bpen, 438, 378, 747, 378);
                ev.Graphics.DrawLine(Bpen, 438, 412, 747, 412);
                ev.Graphics.DrawLine(Bpen, 440, 378, 440, 412);
                ev.Graphics.DrawLine(Bpen, 745, 378, 745, 412);

                //box = new Rectangle(400, 350, 100, 20);
                ev.Graphics.DrawString("FAI On Order: ", heading, Brushes.Black, 450, 380);
                //box = new Rectangle(500, 350, 55, 20);
                ev.Graphics.DrawString(aFAIonOrder[lineNo], A9R, Brushes.Black, 540, 380);

                ev.Graphics.DrawString("FAI Nettable: ", heading, Brushes.Black, 590, 380);
                //box = new Rectangle(500, 350, 55, 20);
                ev.Graphics.DrawString(aFAINettable[lineNo], A9R, Brushes.Black, 710, 380);

                ev.Graphics.DrawString("FAI Non-Nettable: ", heading, Brushes.Black, 590, 395);
                //box = new Rectangle(500, 350, 55, 20);
                ev.Graphics.DrawString(aFAINonNettable[lineNo], A9R, Brushes.Black, 710, 395);

            }
            catch (Exception ex)
            {
                File.AppendAllText(ErrorLog, " 2294 Item Data   " + ex.ToString() + Environment.NewLine);

            }


            /*  stock data  */

            try
            {
                ev.Graphics.DrawString("Annual Spend Using F6 * 2: ", A9R, Brushes.Black, 570, 220);
                var box = new Rectangle(620, 220, 180, 20);
                ev.Graphics.DrawString(aAnnualSpend[lineNo], A9R, Brushes.Black, box, alignR);



                /*  left column */

                box = new Rectangle(400, 245, 100, 20);
                ev.Graphics.DrawString("Nettable Stk: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(500, 245, 55, 20);
                ev.Graphics.DrawString(aNettableStock[lineNo], A9R, Brushes.Black, box, alignR);

                box = new Rectangle(350, 260, 150, 20);
                ev.Graphics.DrawString("MRB Non-Net Stk: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(500, 260, 55, 20);

                ev.Graphics.DrawString(aNonNetStock[lineNo], A9R, Brushes.Black, box, alignR);
                box = new Rectangle(400, 275, 100, 20);
                ev.Graphics.DrawString("On Order: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(500, 275, 55, 20);
                ev.Graphics.DrawString(aOnOrder[lineNo], A9R, Brushes.Red, box, alignR);

                box = new Rectangle(400, 290, 100, 20);
                ev.Graphics.DrawString("Blocked Stock: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(500, 290, 55, 20);
                ev.Graphics.DrawString(aBlockedStock[lineNo], A9R, Brushes.Black, box, alignR);

                box = new Rectangle(400, 305, 100, 20);
                ev.Graphics.DrawString("Safety Stock: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(500, 305, 55, 20);
                ev.Graphics.DrawString(string.Format("{0:0.00}", Convert.ToDouble(aSafetyStock[lineNo])), A9R, Brushes.Red, box, alignR);

                box = new Rectangle(400, 320, 100, 20);
                ev.Graphics.DrawString("Allocations: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(500, 320, 55, 20);
                ev.Graphics.DrawString(aAllocations[lineNo], A9R, Brushes.Black, box, alignR);

                box = new Rectangle(400, 335, 100, 20);
                ev.Graphics.DrawString("SIM: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(500, 335, 55, 20);
                ev.Graphics.DrawString(aSIM[lineNo], A9R, Brushes.Black, box, alignR);

                //box = new Rectangle(400, 350, 100, 20);
                //ev.Graphics.DrawString("SDS Doc No: ", A9R, Brushes.Black, box, alignR);
                //box = new Rectangle(500, 350, 55, 20);
                //ev.Graphics.DrawString(aSDSDocumentNo[lineNo], A9R, Brushes.Black, box, alignR);

                /*  right column    */

                box = new Rectangle(580, 240, 100, 20);
                ev.Graphics.DrawString("Qty Multiplier: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(700, 240, 100, 20);
                ev.Graphics.DrawString(aQtyMultiplier[lineNo], A9R, Brushes.Black, box, alignR);

                box = new Rectangle(580, 260, 100, 20);
                ev.Graphics.DrawString("Min Qty: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(700, 260, 100, 20);
                ev.Graphics.DrawString(aMinQty[lineNo], A9R, Brushes.Black, box, alignR);

                box = new Rectangle(580, 280, 100, 20);
                ev.Graphics.DrawString("Reorder Point: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(700, 280, 100, 20);
                ev.Graphics.DrawString(aReorderPoint[lineNo], A9R, Brushes.Black, box, alignR);

                box = new Rectangle(560, 300, 120, 20);
                ev.Graphics.DrawString("Reorder Quantity: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(700, 300, 100, 20);
                ev.Graphics.DrawString(aReorderQty[lineNo], A9R, Brushes.Black, box, alignR);

                box = new Rectangle(530, 320, 150, 20);
                ev.Graphics.DrawString("Last Purch Price: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(700, 320, 100, 20);
                ev.Graphics.DrawString(aLastPurchPrice[lineNo], A9R, Brushes.Black, box, alignR);

                box = new Rectangle(580, 340, 100, 20);
                ev.Graphics.DrawString("Purch Price: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(700, 340, 100, 20);
                ev.Graphics.DrawString(aPurchPrice[lineNo], A9R, Brushes.Black, box, alignR);

                box = new Rectangle(580, 360, 100, 20);
                ev.Graphics.DrawString("Std Cost: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(700, 360, 100, 20);
                ev.Graphics.DrawString(aStdCost[lineNo], A9R, Brushes.Black, box, alignR);



            }
            catch (Exception ex)
            {
                File.AppendAllText(ErrorLog, " 2393 Stock Data  " + ex.ToString() + Environment.NewLine);

            }

            ev.Graphics.DrawLine(pen, 25, 410, 800, 410);

            try
            {

                /*  Manufacturer Data   */

                ev.Graphics.DrawString("Manuf Name", U9, Brushes.Black, 25, 415);
                ev.Graphics.DrawString("Manuf Part Number", U9, Brushes.Black, 275, 415);
                //ev.Graphics.DrawString("Qualification", U9, Brushes.Black, 425, 385);
                ev.Graphics.DrawString("Preferred?", U9, Brushes.Black, 525, 415);
                ev.Graphics.DrawString("Description", U9, Brushes.Black, 625, 415);

                ev.Graphics.DrawString(aMfrName[lineNo], A9R, Brushes.Black, 25, 425);
                ev.Graphics.DrawString(aMfrPartNumber[lineNo], A9R, Brushes.Black, 275, 425);
                //ev.Graphics.DrawString(aQualification[lineNo], A9R, Brushes.Black, 425, 399);
                ev.Graphics.DrawString(aPreferred[lineNo], A9R, Brushes.Black, 540, 426);
                ev.Graphics.DrawString(aMfrDescription[lineNo], A9R, Brushes.Black, 625, 425);
            }
            catch (Exception ex)
            {
                File.AppendAllText(ErrorLog, " 2418 Manufacturer Data  " + ex.ToString() + Environment.NewLine);

            }

            ev.Graphics.DrawLine(pen, 25, 440, 800, 440);
            ev.Graphics.DrawLine(pen, 490, 440, 490, 975);

            try
            {

                /*  MRP Recommended Orders   */

                ev.Graphics.DrawString("MRP RECOMMENDED ORDERS", U9, Brushes.Black, 25, 445);
                ev.Graphics.DrawString("Start", U9, Brushes.Black, 25, 465);
                ev.Graphics.DrawString("Orig", U9, Brushes.Black, 90, 465);
                ev.Graphics.DrawString("Rqstd", U9, Brushes.Black, 150, 465);
                ev.Graphics.DrawString("Order Qty", U9, Brushes.Black, 200, 465);
                ev.Graphics.DrawString("Ext Cost", U9, Brushes.Black, 270, 465);
                ev.Graphics.DrawString("Loc", U9, Brushes.Black, 335, 465);
                ev.Graphics.DrawString("Action", U9, Brushes.Black, 390, 465);
                ev.Graphics.DrawString("Best", U9, Brushes.Black, 450, 465);

                ev.Graphics.DrawString("Current Order (inside 2 weeks)", A9R, Brushes.Black, 25, 485);

                linedrop = 505;


                var box = new Rectangle(620, 220, 180, 20);

                if (aMRPCurrentCount[lineNo] > 0)
                {
                    int sectionLimit = Convert.ToInt32(aMRPCurrentCount[lineNo]);

                    if (aMRPCurrentPagePlus1[lineNo] > 0)
                    {
                        sectionLimit = 28;
                    }

                    for (int ii = 0; ii < sectionLimit; ii++)
                    {
                        ev.Graphics.DrawString(acOrderDate[lineNo, ii], A9R, Brushes.Black, 25, linedrop);
                        ev.Graphics.DrawString(acOrigDueDate[lineNo, ii], A9R, Brushes.Black, 90, linedrop);
                        ev.Graphics.DrawString(acDeliveryDate[lineNo, ii], A9R, Brushes.Black, 150, linedrop);
                        ev.Graphics.DrawString(acOrderQuantity[lineNo, ii], A9R, Brushes.Black, 220, linedrop);
                        //ev.Graphics.DrawString(acAmountStandard[lineNo, ii], A9R, Brushes.Black, 270, linedrop);
                        box = new Rectangle(250, linedrop, 70, 20);
                        ev.Graphics.DrawString(acAmountStandard[lineNo, ii], A9R, Brushes.Black, box, alignR);
                        ev.Graphics.DrawString(acLocation[lineNo, ii], A9R, Brushes.Black, 335, linedrop);
                        //ev.Graphics.DrawString(acBinCode[lineNo, ii], A9R, Brushes.Black, 550, linedrop);
                        ev.Graphics.DrawString(acAction[lineNo, ii], A9R, Brushes.Black, 390, linedrop);
                        ev.Graphics.DrawString(acBestDate[lineNo, ii], A9R, Brushes.Black, 450, linedrop);
                        linedrop = linedrop + 20;
                    }
                }

                /*
                * 
                * PO Lines
                * 
                * */

                ev.Graphics.DrawString("OPEN PURCHASE ORDERS", U9, Brushes.Black, 500, 445);
                ev.Graphics.DrawString("P.O", U9, Brushes.Black, 500, 465);
                ev.Graphics.DrawString("Line", U9, Brushes.Black, 580, 465);
                ev.Graphics.DrawString("Qty", U9, Brushes.Black, 630, 465);
                ev.Graphics.DrawString("Requested", U9, Brushes.Black, 680, 465);
                ev.Graphics.DrawString("Promised", U9, Brushes.Black, 750, 465);

                try
                {
                    for (int ii = 0; ii < 20; ii++)
                    {
                        ev.Graphics.DrawString(aPO[lineNo, ii], A9R, Brushes.Black, 500, 485 + (ii * 20));
                        ev.Graphics.DrawString(aPOBest[lineNo, ii], A9R, Brushes.Black, 560, 485 + (ii * 20));
                        ev.Graphics.DrawString(aPOLine[lineNo, ii], A9R, Brushes.Black, 580, 485 + (ii * 20));
                        ev.Graphics.DrawString(aPOLineQty[lineNo, ii], A9R, Brushes.Black, 630, 485 + (ii * 20));
                        ev.Graphics.DrawString(aPOLineRequestedDate[lineNo, ii], A9R, Brushes.Black, 680, 485 + (ii * 20));
                        ev.Graphics.DrawString(aPOLinePromisedDate[lineNo, ii], A9R, Brushes.Black, 750, 485 + (ii * 20));
                    }
                }
                catch (Exception ex)
                {
                    File.AppendAllText(ErrorLog, " 2501 PO Lines " + ex.ToString() + Environment.NewLine);

                }

                partOnePrinted[lineNo] = true;

                if (partOnePrinted[lineNo] && (!partTwoPrinted[lineNo]) & !twoPagesRequired[lineNo])
                {
                    print_PartTwo(ev, linedrop);
                    partTwoPrinted[lineNo] = true;
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(ErrorLog, " 2515 MRP Current Data   " + ex.ToString() + Environment.NewLine);

            }


        }

        private void print_PartTwo(PrintPageEventArgs ev, int linedrop)
{
    Pen pen = new Pen(Color.Red);
    Pen Gpen = new Pen(Color.Green);
    Pen Bpen = new Pen(Color.Turquoise);
    Pen Ypen = new Pen(Color.Orange);
    Ypen.Width = 25;
    Gpen.Width = 3;
    pen.Width = 1;
    Font A9R = new Font("arial", 9, FontStyle.Regular);
    Font title = new Font("arial", 16, FontStyle.Bold);
    Font heading = new Font("arial", 9, FontStyle.Bold);
    Font B12 = new Font("arial", 12, FontStyle.Bold);
    Font U9 = new Font("arial", 9, FontStyle.Underline);
    StringFormat alignR = new StringFormat();
    alignR.Alignment = StringAlignment.Far;


    ev.Graphics.DrawString("Future Order (outside 2 weeks)", A9R, Brushes.Black, 25, linedrop);

    linedrop = linedrop + 20;

    try
    {
        var box = new Rectangle(620, 220, 180, 20);

        if (Convert.ToInt32(aMRPFutureCount[lineNo]) > 0)
        {
            for (int ii = 0; ii < Convert.ToInt32(aMRPFutureCount[lineNo]); ii++)
            {
                ev.Graphics.DrawString(afOrderDate[lineNo, ii], A9R, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString(afOrigDueDate[lineNo, ii], A9R, Brushes.Black, 90, linedrop);
                ev.Graphics.DrawString(afDeliveryDate[lineNo, ii], A9R, Brushes.Black, 150, linedrop);
                ev.Graphics.DrawString(afOrderQuantity[lineNo, ii], A9R, Brushes.Black, 220, linedrop);
                box = new Rectangle(250, linedrop, 70, 20);
                ev.Graphics.DrawString(afAmountStandard[lineNo, ii], A9R, Brushes.Black, box, alignR);
                ev.Graphics.DrawString(afLocation[lineNo, ii], A9R, Brushes.Black, 335, linedrop);
                ev.Graphics.DrawString(afAction[lineNo, ii], A9R, Brushes.Black, 390, linedrop);
                ev.Graphics.DrawString(afBestDate[lineNo, ii], A9R, Brushes.Black, 450, linedrop);
                linedrop = linedrop + 20;
                //count++;
            }
        }
    }
    catch (Exception ex)
    {
        File.AppendAllText(ErrorLog, " 2567 MRP Future   " + ex.ToString() + Environment.NewLine);
    }

    int MRPc = aMRPCurrentCount[lineNo];
    int MRPf = aMRPFutureCount[lineNo];
    int POl = aPOLineCount[lineNo] + 1;


    if (POl > MRPc + MRPf)
    {
        linedrop = linedrop + ((POl - (MRPc + MRPf + 2)) * 20);

        if (MRPf > 0)
        {
            linedrop = linedrop + 20;
        }
    }

    if (POl == 2 & MRPc == 1)
    {
        linedrop = linedrop + 20;
    }

    ev.Graphics.DrawLine(pen, 25, linedrop, 800, linedrop);

    linedrop = linedrop + 5;


    /*  Last 5 Receipts   */

    ev.Graphics.DrawString("LAST 5 RECEIPTS", U9, Brushes.Black, 25, linedrop);
    linedrop = linedrop = linedrop + 20;
    ev.Graphics.DrawString("Rcpt Date", U9, Brushes.Black, 50, linedrop);
    ev.Graphics.DrawString("Order", U9, Brushes.Black, 150, linedrop);
    ev.Graphics.DrawString("Pos", U9, Brushes.Black, 225, linedrop);
    ev.Graphics.DrawString("Supplier", U9, Brushes.Black, 275, linedrop);
    ev.Graphics.DrawString("Price", U9, Brushes.Black, 550, linedrop);
    ev.Graphics.DrawString("Dlvrd Qty", U9, Brushes.Black, 625, linedrop);
    ev.Graphics.DrawString("Net Amount", U9, Brushes.Black, 725, linedrop);

    linedrop = linedrop + 20;
    //count++;

    try
    {
        if (Convert.ToInt32(aReceiptCount[lineNo]) > 0)
        {
            for (int ii = 0; ii < Convert.ToInt32(aReceiptCount[lineNo]); ii++)
            {
                ev.Graphics.DrawString(aRecriptDate[lineNo, ii], A9R, Brushes.Black, 50, linedrop);
                ev.Graphics.DrawString(aReceiptOrder[lineNo, ii], A9R, Brushes.Black, 150, linedrop);
                ev.Graphics.DrawString(aReceiptPosition[lineNo, ii], A9R, Brushes.Black, 225, linedrop);
                ev.Graphics.DrawString(aReceiptVendor[lineNo, ii], A9R, Brushes.Black, 275, linedrop);
                ev.Graphics.DrawString(aReceiptPrice[lineNo, ii], A9R, Brushes.Black, 550, linedrop);
                ev.Graphics.DrawString(aReceiptDeliveredQuantity[lineNo, ii], A9R, Brushes.Black, 625, linedrop);
                ev.Graphics.DrawString(aReceiptNetAmount[lineNo, ii], A9R, Brushes.Black, 725, linedrop);
                linedrop = linedrop + 20;
                //count = count + ii;
            }
        }
    }
    catch (Exception ex)
    {
        File.AppendAllText(ErrorLog, " 2630 Receipt Data   " + ex.ToString() + Environment.NewLine);
    }

    //linedrop = linedrop + 20;
    //count++;

    ev.Graphics.DrawLine(pen, 25, linedrop, 800, linedrop);

    linedrop = linedrop + 20;
    //count++;

    try
    {
        if (Convert.ToInt32(aItemTextCount[lineNo]) > 0)
        {
            for (int ii = 0; ii < Convert.ToInt32(aItemTextCount[lineNo]); ii++)
            {
                ev.Graphics.DrawString(aItemText[lineNo, ii], A9R, Brushes.Black, 50, linedrop + (ii * 20));

                //count = count + ii;
            }
        }
    }
    catch (Exception ex)
    {
        File.AppendAllText(ErrorLog, " 2655 Item Text   " + ex.ToString() + Environment.NewLine);
    }

    //ev.Graphics.DrawString("Date PO Placed:  _______________     PO Number _______________", A9R, Brushes.Black, 50, 1000);


}

        private void printCurrentOverflow(PrintPageEventArgs ev)
        {
            Pen pen = new Pen(Color.Red);
            Pen Gpen = new Pen(Color.Green);
            Pen Bpen = new Pen(Color.Turquoise);
            Pen Ypen = new Pen(Color.Orange);
            Ypen.Width = 25;
            Gpen.Width = 3;
            pen.Width = 1;
            Font A9R = new Font("arial", 9, FontStyle.Regular);
            Font title = new Font("arial", 16, FontStyle.Bold);
            Font heading = new Font("arial", 9, FontStyle.Bold);
            Font B12 = new Font("arial", 12, FontStyle.Bold);
            Font U9 = new Font("arial", 9, FontStyle.Underline);
            StringFormat alignR = new StringFormat();
            alignR.Alignment = StringAlignment.Far;
            int linedrop = 100;


            /*  MRP Recommended Orders   */

            ev.Graphics.DrawString("Start", U9, Brushes.Black, 25, linedrop);
            ev.Graphics.DrawString("Orig", U9, Brushes.Black, 90, linedrop);
            ev.Graphics.DrawString("Rqstd", U9, Brushes.Black, 150, linedrop);
            ev.Graphics.DrawString("Order Qty", U9, Brushes.Black, 200, linedrop);
            ev.Graphics.DrawString("Ext Cost", U9, Brushes.Black, 270, linedrop);
            ev.Graphics.DrawString("Loc", U9, Brushes.Black, 335, linedrop);
            ev.Graphics.DrawString("Action", U9, Brushes.Black, 390, linedrop);
            ev.Graphics.DrawString("Best", U9, Brushes.Black, 450, linedrop);

            linedrop = linedrop + 20;

            ev.Graphics.DrawString("Current Order (continued)", A9R, Brushes.Black, 25, linedrop);

            linedrop = linedrop + 20;


            var box = new Rectangle(620, 220, 180, 20);

            if (aMRPCurrentCount[lineNo] > 0)
            {
                //int sectionLimit = Convert.ToInt32(aMRPCurrentPagePlus1[lineNo]);

                for (int ii = 28; ii < aMRPCurrentCount[lineNo] + 1; ii++)
                {
                    ev.Graphics.DrawString(acOrderDate[lineNo, ii], A9R, Brushes.Black, 25, linedrop);
                    ev.Graphics.DrawString(acOrigDueDate[lineNo, ii], A9R, Brushes.Black, 90, linedrop);
                    ev.Graphics.DrawString(acDeliveryDate[lineNo, ii], A9R, Brushes.Black, 150, linedrop);
                    ev.Graphics.DrawString(acOrderQuantity[lineNo, ii], A9R, Brushes.Black, 220, linedrop);
                    //ev.Graphics.DrawString(acAmountStandard[lineNo, ii], A9R, Brushes.Black, 270, linedrop);
                    box = new Rectangle(250, linedrop, 70, 20);
                    ev.Graphics.DrawString(acAmountStandard[lineNo, ii], A9R, Brushes.Black, box, alignR);
                    ev.Graphics.DrawString(acLocation[lineNo, ii], A9R, Brushes.Black, 335, linedrop);
                    //ev.Graphics.DrawString(acBinCode[lineNo, ii], A9R, Brushes.Black, 550, linedrop);
                    ev.Graphics.DrawString(acAction[lineNo, ii], A9R, Brushes.Black, 390, linedrop);
                    ev.Graphics.DrawString(acBestDate[lineNo, ii], A9R, Brushes.Black, 450, linedrop);
                    linedrop = linedrop + 20;
                }


            }

            currentOverflowPrinted[lineNo] = true;

            print_PartTwo(ev, linedrop);
            partTwoPrinted[lineNo] = true;
        }


        private void BClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
