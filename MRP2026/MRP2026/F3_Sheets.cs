using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


namespace MRP2026
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
        private string[] aVendorNo2 = new string[20000];
        private string[] aVendorName2 = new string[20000];
        private string[] aVendorAddress2 = new string[20000];
        private string[] aVendorContact2 = new string[20000];
        private string[] aVendorPhone2 = new string[20000];
        private string[] aVendorEmail2 = new string[20000];
        private string[] aVendorFax2 = new string[20000];
        private string[] aVendorTitle2 = new string[20000];
        private string[] aVendorCommodityCode2 = new string[20000];
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
        private string[] aEffectiveDate = new string[20000];
        private string[] aECOnumber = new string[20000];
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

        private string[,] aMfrName = new string[20000, 10];
        private string[,] aMfrPartNumber = new string[20000, 10];
        private string[,] aPreferred = new string[20000, 10];
        private string[,] aMfrDescription = new string[20000, 10];

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
        private string[] aAging = new string[20000];
        private int[] aS1_ID = new int[20000];

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
        private string[,] aItemText = new string[20000, 15];
        private string[,] aPO = new string[20000, 20];
        private string[,] aPOLine = new string[20000, 20];
        private string[,] aPOLineQty = new string[20000, 20];
        private string[,] aPOLineRequestedDate = new string[20000, 20];
        private string[,] aPOLinePromisedDate = new string[20000, 20];
        private string[,] aPOBest = new string[20000, 20];
        private string[,] aPOVendor = new string[20000, 20];

        private int[] aVendorCount = new int[20000];
        private int[] aMRPCurrentCount = new int[20000];
        private int[] aMfrCount = new int[20000];
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

        DataTable dt1;
        DataTable dtDash;
        DataTable dtMRPOrdersCurrent;
        DataTable dtMRPOrdersCurrentPlusPage;
        DataTable dtMRPOrdersFuture;
        DataTable dtReceipts;

        DataTable dtItemText;
        DataTable dtPOLines;
        SqlDataReader dr;
        SqlDataReader drMain;
        SqlCommand cmd;


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
             *Connection used to get the old MK data
             */

            SqlConnection cnxnAFE = new SqlConnection("server=CT-MID-SQL11.ametek.com; password=views; " +
                                          "user=views; database=AccessFrontEnds; encrypt=false;");

            /*
             *  Get the list of MRP purchased parts for which reports are needed 
             *  use all worksheets and exclude kanban parts - description starts with %
             *  [Ref_ Order Type] = 1 = Purchase
             *  Type = 2 = Item
             */

            if (g.messageChoice == " not " | (g.messageChoice == " AND MessageGroup = 'NotCancelOnly' "))
            {
                g.messageChoice = " AND MessageGroup = 'NotCancelOnly' ";

                cmd = new SqlCommand(
                "SELECT * FROM MRP_S1 " +
                "INNER JOIN " + g.ReportFilter + " c ON MRP_s1.Item = c.No_ " +
                "WHERE 1=1  " +
                " AND Item = '1450-300-011' " +

                g.messageChoice +

                g.SQLselection +

                  "ORDER BY " +
                  "[Buyer Planner Code] " +
                  ",[Vendor No_] " +
                  ",Item"
                   , cnxnAFE);
            }
            else
            {
                g.messageChoice = " AND MessageGroup = 'CancelOnly' ";

                cmd = new SqlCommand(
                "SELECT * FROM MRP_S1 " +
                "WHERE 1=1 " +

                g.messageChoice +

                  "ORDER BY " +
                  "[Buyer Planner Code] " +
                  ",[Vendor No_] " +
                  ",Item"
                   , cnxnAFE);
            }



            try
            {
                cnxnAFE.Open();
                drMain = cmd.ExecuteReader();
                dt1 = new DataTable();
                dt1.Load(drMain);
            }
            catch (SqlException ex)
            {
                File.AppendAllText(ErrorLog, " 351 Initial Selection List  " + ex.ToString() + Environment.NewLine);
            }
            finally
            {
                cnxnAFE.Close();
            }

            if (dt1.Rows.Count < 1)
            {
                string xtoday = DateTime.Now.ToString("MM-dd-yy hh.mm.ss");

                string xfile = string.Empty;

                xfile = "No Data MRP " + g.rptName + g.ReportSelection + xtoday + ".txt";

                File.WriteAllText(directory + @"\" + xfile, "");
                //MessageBox.Show("No Data");

            }
            else
            {
                try
                {
                    cnxnAFE.Open();

                    drMain = cmd.ExecuteReader();

                    while (drMain.Read())
                    {
                        aS1_ID[i] = drMain.GetInt32(0);
                        aItemNo[i] = drMain.GetString(1);
                        abuyerPlanner[i] = drMain.GetString(2);
                        aLocation[i] = drMain.GetString(3);
                        aDescription[i] = drMain.GetString(5);
                        aCopyExact[i] = drMain.GetString(6);
                        aItemCommodityCode[i] = drMain.GetString(7);
                        aProductType[i] = drMain.GetString(8);
                        aSelectionCode[i] = drMain.GetString(9);
                        aItemGroup[i] = drMain.GetString(10);
                        aSignalCode[i] = drMain.GetString(11);

                        aLeadTime[i] = drMain.GetInt32(12).ToString() + " Days (" + drMain.GetInt32(13).ToString() + " Weeks)";
                        aLotAccumulationPeriod[i] = drMain.GetInt32(14).ToString() + " Days";

                        aCurrentRev[i] = drMain.GetString(15);  /* this from item but should be from doc control */

                        aSafetyStock[i] = drMain.GetInt32(17).ToString();
                        aOrderMethod[i] = drMain.GetString(18);
                        aQtyMultiplier[i] = drMain.GetInt32(19).ToString();
                        aMinQty[i] = drMain.GetInt32(20).ToString();
                        aStdCost[i] = drMain.GetString(21);
                        aPurchPrice[i] = drMain.GetString(22);
                        aLastPurchPrice[i] = drMain.GetString(23);

                        aInspection[i] = drMain.GetString(24);

                        aReorderPoint[i] = drMain.GetInt32(26).ToString();
                        aReorderQty[i] = drMain.GetInt32(27).ToString();
                        aVettedStatus[i] = drMain.GetInt32(28).ToString();
                        aSIM[i] = drMain.GetString(29);
                        aDampnerDaysLate[i] = drMain.GetInt32(30).ToString();
                        aSDSDocumentNo[i] = drMain.GetString(31);
                        aP6[i] = drMain.GetInt32(32).ToString();
                        aF6[i] = drMain.GetInt32(33).ToString();
                        aEAU[i] = drMain.GetInt32(34).ToString();
                        aHTS[i] = drMain.GetString(35);
                        aNetWeight[i] = drMain.GetString(36);
                        aNonDomesticVendor[i] = drMain.GetString(37);

                        aDampenerPeriod[i] = drMain.GetString(38);
                        aDampenerQuantity[i] = drMain.GetInt32(39).ToString();

                        aLTAReleaseBucket[i] = drMain.GetInt32(40).ToString();
                        aSupplierReplenishment[i] = drMain.GetInt32(41).ToString();

                        aAnnualSpend[i] = drMain.GetString(25);
                        aNettableStock[i] = drMain.GetInt32(45).ToString();
                        aNonNetStock[i] = drMain.GetInt32(46).ToString();
                        aOnOrder[i] = drMain.GetInt32(44).ToString();
                        aBlockedStock[i] = drMain.GetInt32(51).ToString();

                        aFAIonOrder[i] = drMain.GetInt32(47).ToString();
                        aFAINettable[i] = drMain.GetInt32(48).ToString();
                        aFAINonNettable[i] = drMain.GetInt32(49).ToString();

                        aAllocations[i] = drMain.GetInt32(50).ToString();
                        aBlockedStock[i] = drMain.GetInt32(51).ToString();



                        shortage[i] = drMain.GetString(52).Trim();
                        shortageProductLine[i] = drMain.GetString(53).Trim();

                        aVendorNo[i] = drMain.GetString(54);
                        aVendorName[i] = drMain.GetString(55);
                        aVendorAddress[i] = drMain.GetString(56);
                        aVendorContact[i] = drMain.GetString(57);
                        aVendorPhone[i] = drMain.GetString(58);
                        aVendorEmail[i] = drMain.GetString(59);
                        aVendorFax[i] = drMain.GetString(60);
                        aVendorTitle[i] = drMain.GetString(61);
                        aVendorCommodityCode[i] = drMain.GetString(62);

                        aVendorNo2[i] = drMain.GetString(63).Trim();
                        if (aVendorNo2[i].Length > 0)
                        {
                            aVendorCount[i] = 2;
                        }
                        else
                        {
                            aVendorCount[i] = 1;
                        }
                        aVendorName2[i] = drMain.GetString(64);
                        aVendorAddress2[i] = drMain.GetString(65);
                        aVendorContact2[i] = drMain.GetString(66);
                        aVendorPhone2[i] = drMain.GetString(67);
                        aVendorEmail2[i] = drMain.GetString(68);
                        aVendorFax2[i] = drMain.GetString(69);
                        aVendorTitle2[i] = drMain.GetString(70);
                        aVendorCommodityCode2[i] = drMain.GetString(71);

                        aECOnumber[i] = drMain.GetString(72);
                        aEffectiveDate[i] = drMain.GetString(73);
                        aECOstatus[i] = drMain.GetString(74).Trim();

                        aAging[i] = drMain.GetString(75).Trim();

                        i++;
                    }
                }
                catch (SqlException ex)
                {
                    File.AppendAllText(ErrorLog, " 351 Initial Selection List  " + ex.ToString() + Environment.NewLine);
                }
                finally
                {
                    cnxnAFE.Close();
                }


                for (int x = 0; x < i; x++)
                {
                    /*
                    *  Manufacturer Data
                    */

                    cmd = new SqlCommand(
                        "SELECT * FROM MRP_S2 " +
                        "WHERE s1_id = " + aS1_ID[x] +
                        "AND Item IN " +
                        "(Select item from MRP_s1 " +
                        "INNER JOIN " + g.ReportFilter + " c ON MRP_s1.Item = c.No_ " +

                        g.messageChoice + g.SQLselection +

                        " )", cnxnAFE);


                    try
                    {
                        cnxnAFE.Open();
                        dtDash = new DataTable();
                        dr = cmd.ExecuteReader();
                        dtDash.Load(dr);
                    }
                    catch (SqlException ex)
                    {
                        File.AppendAllText(ErrorLog, " 378 " + ex.ToString() + Environment.NewLine);
                    }
                    finally
                    {
                        cnxnAFE.Close();
                    }

                    aMfrCount[x] = dtDash.Rows.Count;

                    if (dtDash.Rows.Count > 0)
                    {
                        for (int ii = 0; ii < dtDash.Rows.Count; ii++)
                        {
                            try
                            {
                                aMfrName[x, ii] = dtDash.Rows[ii][1].ToString();
                                aMfrPartNumber[x, ii] = dtDash.Rows[ii][2].ToString();
                                aPreferred[x, ii] = dtDash.Rows[ii][3].ToString();
                                aMfrDescription[x, ii] = dtDash.Rows[ii][4].ToString();
                            }
                            catch (Exception ex)
                            {
                                File.AppendAllText(ErrorLog, " 312 " + ex.ToString() + Environment.NewLine);
                            }
                        }
                    }
                    else
                    {
                        aMfrName[x, 0] = "";
                        aMfrPartNumber[x, 0] = "";
                        aPreferred[x, 0] = "";
                        aMfrDescription[x, 0] = "";
                    }

                    /* MRP current  */

                    cmd = new SqlCommand(
                        "SELECT * FROM MRP_S4 " +
                        "WHERE CF = 'Current' " +
                        "AND s1_id = " + aS1_ID[x] +
                        " ORDER BY CONVERT(date, startingdate) ", cnxnAFE);


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

                    aMRPCurrentCount[x] = dtMRPOrdersCurrent.Rows.Count;

                    if (dtMRPOrdersCurrent.Rows.Count > 0)
                    {
                        for (int ii = 0; ii < dtMRPOrdersCurrent.Rows.Count; ii++)
                        {
                            try
                            {
                                acOrderDate[x, ii] = dtMRPOrdersCurrent.Rows[ii][2].ToString();
                                acDeliveryDate[x, ii] = dtMRPOrdersCurrent.Rows[ii][3].ToString();
                                acOrderQuantity[x, ii] = dtMRPOrdersCurrent.Rows[ii][4].ToString();
                                acAmountStandard[x, ii] = dtMRPOrdersCurrent.Rows[ii][5].ToString();
                                acLocation[x, ii] = dtMRPOrdersCurrent.Rows[ii][6].ToString();
                                acBinCode[x, ii] = dtMRPOrdersCurrent.Rows[ii][7].ToString();
                                acAction[x, ii] = dtMRPOrdersCurrent.Rows[ii][8].ToString();
                                if (dtMRPOrdersCurrent.Rows[ii][9].ToString() == "01/01/53")
                                {
                                    acOrigDueDate[x, ii] = "";
                                }
                                else
                                {
                                    acOrigDueDate[x, ii] = dtMRPOrdersCurrent.Rows[ii][9].ToString();
                                }
                                acBestDate[x, ii] = dtMRPOrdersCurrent.Rows[ii][10].ToString();
                            }
                            catch (Exception ex)
                            {
                                File.AppendAllText(ErrorLog, " 1681    " + ex.ToString() + Environment.NewLine);
                            }
                        }
                    }


                    /*  MRP Future  */

                    cmd = new SqlCommand(
                    "SELECT * FROM MRP_s4 " +
                    "WHERE CF = 'Future' " +
                    "AND s1_id = " + aS1_ID[x] +
                    " ORDER BY CONVERT(date, startingdate) ", cnxnAFE);


                    try
                    {
                        cnxnAFE.Open();
                        dtMRPOrdersFuture = new DataTable();
                        dr = cmd.ExecuteReader();
                        dtMRPOrdersFuture.Load(dr);

                    }
                    catch (SqlException ex)
                    {
                        File.AppendAllText(ErrorLog, " 465  MRP Future " + ex.ToString() + Environment.NewLine);
                    }
                    finally
                    {
                        cnxnAFE.Close();
                    }

                    aMRPFutureCount[x] = dtMRPOrdersFuture.Rows.Count;

                    if (dtMRPOrdersFuture.Rows.Count > 0)
                    {
                        for (int ii = 0; ii < dtMRPOrdersFuture.Rows.Count; ii++)
                        {
                            try
                            {
                                afOrderDate[x, ii] = dtMRPOrdersFuture.Rows[ii][2].ToString();
                                afDeliveryDate[x, ii] = dtMRPOrdersFuture.Rows[ii][3].ToString();
                                afOrderQuantity[x, ii] = dtMRPOrdersFuture.Rows[ii][4].ToString();
                                afAmountStandard[x, ii] = dtMRPOrdersFuture.Rows[ii][5].ToString();
                                afLocation[x, ii] = dtMRPOrdersFuture.Rows[ii][6].ToString();
                                afBinCode[x, ii] = dtMRPOrdersFuture.Rows[ii][7].ToString();
                                afAction[x, ii] = dtMRPOrdersFuture.Rows[ii][8].ToString();
                                if (dtMRPOrdersFuture.Rows[ii][9].ToString() == "01/01/53")
                                {
                                    afOrigDueDate[x, ii] = "";
                                }
                                else
                                {
                                    afOrigDueDate[x, ii] = dtMRPOrdersFuture.Rows[ii][9].ToString();
                                }
                                afBestDate[x, ii] = dtMRPOrdersFuture.Rows[ii][10].ToString();
                            }
                            catch (Exception ex)
                            {
                                File.AppendAllText(ErrorLog, " 499 Future lines  " + ex.ToString() + Environment.NewLine);
                            }
                        }
                    }


                    /*
                     * 
                     * PO Lines (next 20)
                     * 
                     */

                    cmd = new SqlCommand(

                        "SELECT * FROM MRP_Open_PO " +
                        "WHERE s1_id = " + aS1_ID[x] +
                        " ORDER BY CONVERT(date,RRD) ", cnxnAFE);

                    try
                    {
                        cnxnAFE.Open();
                        dtPOLines = new DataTable();
                        dr = cmd.ExecuteReader();
                        dtPOLines.Load(dr);

                    }
                    catch (SqlException ex)
                    {
                        File.AppendAllText(ErrorLog, " 527 PO Lines   " + ex.ToString() + Environment.NewLine);
                    }
                    finally
                    {
                        cnxnAFE.Close();
                    }

                    aPOLineCount[x] = dtPOLines.Rows.Count;

                    if (dtPOLines.Rows.Count > 0)
                    {
                        for (int ii = 0; ii < dtPOLines.Rows.Count & ii < 20; ii++)
                        {
                            try
                            {
                                aPO[x, ii] = dtPOLines.Rows[ii][1].ToString();
                                aPOLine[x, ii] = dtPOLines.Rows[ii][2].ToString();
                                aPOLineQty[x, ii] = dtPOLines.Rows[ii][3].ToString();
                                aPOLineRequestedDate[x, ii] = dtPOLines.Rows[ii][4].ToString();
                                aPOLinePromisedDate[x, ii] = dtPOLines.Rows[ii][5].ToString();
                                aPOBest[x, ii] = dtPOLines.Rows[ii][6].ToString();
                                aPOVendor[x, ii] = dtPOLines.Rows[ii][7].ToString();
                            }

                            catch (Exception ex)
                            {
                                File.AppendAllText(ErrorLog, " 553 PO Lines    " + ex.ToString() + Environment.NewLine);
                            }
                        }
                    }

                    /*
                    *  Last 5 receipts
                    */

                    cmd = new SqlCommand(

                        "SELECT * from MRP_Item_Receipts " +
                        "WHERE s1_id =" + aS1_ID[x] +
                        " ORDER BY CONVERT(date,RDate) DESC "
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
                        File.AppendAllText(ErrorLog, " 1224   " + ex.ToString() + Environment.NewLine);
                    }
                    finally
                    {
                        cnxnAFE.Close();
                    }


                    if (dtReceipts.Rows.Count < 5)
                    {

                        aReceiptCount[x] = dtReceipts.Rows.Count;
                    }
                    else
                    {
                        aReceiptCount[x] = 5;
                    }

                    if (dtReceipts.Rows.Count > 0)
                    {
                        for (int ii = 0; ii < dtReceipts.Rows.Count & ii < 5; ii++)
                        {
                            try
                            {
                                aRecriptDate[x, ii] = dtReceipts.Rows[ii][1].ToString();
                                aReceiptOrder[x, ii] = dtReceipts.Rows[ii][2].ToString();
                                aReceiptPosition[x, ii] = dtReceipts.Rows[ii][3].ToString();
                                aReceiptVendor[x, ii] = dtReceipts.Rows[ii][4].ToString();
                                aReceiptPrice[x, ii] = dtReceipts.Rows[ii][5].ToString();
                                aReceiptDeliveredQuantity[x, ii] = dtReceipts.Rows[ii][6].ToString();
                                aReceiptNetAmount[x, ii] = dtReceipts.Rows[ii][7].ToString();
                            }
                            catch (Exception ex)
                            {
                                File.AppendAllText(ErrorLog, " 1760    " + ex.ToString() + Environment.NewLine);
                            }
                        }
                    }

                    /*   the items with multiple lines of data    */

                    cmd = new SqlCommand(

                        "SELECT * from MRP_TEXT " +
                        "WHERE s1_id =" + aS1_ID[x]
                        //" ORDER BY CONVERT(date,RDate) DESC "
                        , cnxnAFE);

                    dtItemText = new DataTable();

                    try
                    {
                        cnxnAFE.Open();
                        dr = cmd.ExecuteReader();
                        dtItemText.Load(dr);
                    }
                    catch (SqlException ex)
                    {
                        File.AppendAllText(ErrorLog, " 1224   " + ex.ToString() + Environment.NewLine);
                    }
                    finally
                    {
                        cnxnAFE.Close();
                    }


                    if (dtItemText.Rows.Count < 1)
                    {
                        aItemTextCount[x] = 0;
                    }
                    else
                    {
                        aItemTextCount[x] = dtItemText.Rows.Count;

                        try
                        {
                            cnxnAFE.Open();
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                for (int ii = 0; ii < dtItemText.Rows.Count; ii++)
                                {
                                    aItemText[x, ii] = dtItemText.Rows[ii][0].ToString();

                                }
                            }
                        }
                        catch (SqlException ex)
                        {
                            File.AppendAllText(ErrorLog, " 1224   " + ex.ToString() + Environment.NewLine);
                        }
                        finally
                        {
                            cnxnAFE.Close();
                        }
                    }
                }


                /*
               * 
               * Determine if it will fit on one page
               * 
               */

                for (int xx = 0; xx < i; xx++)
                {
                    int aa = aMRPCurrentCount[xx];
                    int ab = aPOLineCount[xx];
                    int ac = aMRPFutureCount[xx];
                    int ad = aReceiptCount[xx];
                    int ae = aItemTextCount[xx];
                    int am = aMfrCount[xx];
                    int av = aVendorCount[xx];
                    int part1Lines = 0;

                    if (aa >= ab)
                    {
                        part1Lines = aa;
                    }
                    else
                    {
                        part1Lines = ab;
                    }

                    if ((aa + (av * 4) + am) > 26)
                    {
                        aMRPCurrentPagePlus1[xx] = (aa + (av * 4) + am) - 26;
                        twoPagesRequired[xx] = true;
                        extraPageCount++;
                    }
                    else
                    {
                        if (30 - (aMRPCurrentCount[xx] + aMRPFutureCount[xx] + aReceiptCount[xx] + aItemTextCount[xx] + aMfrCount[xx] + (aVendorCount[xx] * 4)) <= 0)
                        {
                            twoPagesRequired[xx] = true;
                            extraPageCount++;

                            if ((aMRPFutureCount[xx] + aReceiptCount[xx] + aItemTextCount[xx] + aMfrCount[xx] + (aVendorCount[xx] * 4)) > 30)
                            {
                                threePagesRequired[xx] = true;
                            }
                            else
                            {
                                threePagesRequired[xx] = false;
                            }

                            if ((aMRPFutureCount[xx] + aReceiptCount[xx] + aItemTextCount[xx]) > 35)
                            {
                                fourPagesRequired[xx] = true;
                            }
                            else
                            {
                                fourPagesRequired[xx] = false;
                            }
                            //                }
                            //                else
                            //                {
                            //twoPagesRequired[xx] = false;
                            //threePagesRequired[xx] = false;
                            //fourPagesRequired[xx] = false;
                        }
                    }
                }



                ///*  colons and back slashes in the date time make the path unreadable    */
                string today = DateTime.Now.ToString("MM-dd-yy hh.mm.ss");

                string file = string.Empty;

                if (g.messageCancel)
                {
                    file = "MRP CANCEL " + g.rptName + g.ReportSelection + today + ".pdf";
                }
                else
                {
                    file = "MRP " + g.rptName + g.ReportSelection + today + ".pdf";
                }



                PrintDocument Pd = new PrintDocument();
                Pd.DefaultPageSettings.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                Pd.PrinterSettings.PrintToFile = true;
                Pd.PrinterSettings.PrintFileName = Path.Combine(directory, file);
                StandardPrintController Pc = new StandardPrintController();
                Pd.PrintController = Pc;

                Pd.PrintPage += new PrintPageEventHandler(Pd_PrintPage);



                try
                {
                    //await 
                    Pd.Print();
                }
                catch (Exception ex)
                {
                    File.AppendAllText(ErrorLog, " 1882    " + ex.ToString() + Environment.NewLine);
                }


            }
            this.Close();
        }


        private async void Pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            /*
             * 
             *  PrintPage runs all the way to the bottom bracket "}"
             *  before evaluating if there is another page and
             *  then runs through again.
             *  
             *  PrintPage is only called once for each report so the length of
             *  each page will correspond to the x collection for the part
             * 
             */



            string date = DateTime.Now.ToString();

            DateTime MRPSunday = DateTime.Now;
            while (MRPSunday.DayOfWeek != DayOfWeek.Sunday)
                MRPSunday = MRPSunday.AddDays(-1);

            string reportSunday = MRPSunday.ToShortDateString();

            int linedrop = 100;
            int POlinedrop = 100;

            int linesPerpage = 30;  //40

            int pageNo = pagesPrinted + 1;

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

            if (shortage[lineNo].Length > 0)
            {
                ev.Graphics.DrawLine(Ypen, 25, 10, 800, 10);
                ev.Graphics.DrawString("SHORTAGE ID = " + shortage[lineNo], A9R, Brushes.Black, 250, 10);
                ev.Graphics.DrawString("SHORTAGE Product Line = " + shortageProductLine[lineNo], A9R, Brushes.Black, 450, 10);
            }

            if (twoPagesRequired[lineNo])
            {
                ev.Graphics.DrawString("Two Pages Required for " + aItemNo[lineNo], A9R, Brushes.Black, 25, 50);
            }

            ev.Graphics.DrawString(g.rptName + " Data as of: " + date, A9R, Brushes.Black, 25, 25);
            ev.Graphics.DrawString(abuyerPlanner[lineNo], heading, Brushes.Black, 350, 25);
            ev.Graphics.DrawString("MRP Report: " + g.ReportSelection, A9R, Brushes.Black, 600, 25);

            if (aAging[lineNo].Length > 0)
            {
                ev.Graphics.DrawString("Aging: " + aAging[lineNo], heading, Brushes.Black, 330, 50);
            }

            //ev.Graphics.DrawString("MRP Date: " + reportSunday, A9R, Brushes.Black, 600, 25);
            ev.Graphics.DrawString("Page  " + pageNo + " of " + NumPages, A9R, Brushes.Black, 600, 50);

            if (aVettedStatus[lineNo] == "1")
            {
                ev.Graphics.DrawString("*************** ......NON-VETTED...... ***************", B12, Brushes.Purple, 225, 50);
            }

            ev.Graphics.DrawLine(pen, 25, 70, 800, 70);

            if (!partOnePrinted[lineNo])
            {
                print_PartOne(ev, linedrop, POlinedrop);
                partOnePrinted[lineNo] = true;
            }

            /*  part one printed - part two not printed - two pages not required    */

            //if (partOnePrinted[lineNo] && (!partTwoPrinted[lineNo]) & !twoPagesRequired[lineNo])
            //{
            //    print_PartTwo(ev, linedrop);
            //    partTwoPrinted[lineNo] = true;
            //}


            //if (partOnePrinted[lineNo] && (partTwoPrinted[lineNo]))
            //{
            //        if (lineNo < 3)
            //        {
            //            ev.HasMorePages = true;
            //            pagesPrinted++;
            //        }
            //        else
            //        {
            //            ev.HasMorePages = false;
            //        }

            //        lineNo++;
            //    }


            //--print_PartOne(ev, linedrop);

            //if ((i - 1) > lineNo)
            //{
            //    ev.HasMorePages = true;
            //    pageOnePrinted[lineNo] = true;
            //    pagesPrinted++;
            //    lineNo++;
            //}
            //else
            //{
            //    ev.HasMorePages = false;
            //    linedrop = 160;
            //    pagesPrinted = 0;
            //    lineNo = 0;
            //}

            //lineNo++;


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



            await Task.Delay(1000);
        }



        private async void print_PartOne(PrintPageEventArgs ev, int linedrop, int POlinedrop)
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
                ev.Graphics.DrawString("Vendor Title: " + aVendorTitle[lineNo], A9R, Brushes.Black, 300, 100);
                ev.Graphics.DrawString("Phone: " + aVendorPhone[lineNo], A9R, Brushes.Black, 25, 120);
                ev.Graphics.DrawString("Supplier Line of Business: " + aVendorCommodityCode[lineNo], A9R, Brushes.Black, 300, 120);
                ev.Graphics.DrawString("Fax: " + aVendorFax[lineNo], A9R, Brushes.Black, 25, 140);
                ev.Graphics.DrawString("Email: " + aVendorEmail[lineNo], A9R, Brushes.Black, 300, 140);
            }
            catch (Exception ex)
            {
                File.AppendAllText(ErrorLog, " 2089 Vendor Data " + ex.ToString() + Environment.NewLine);

            }

            linedrop = 140;

            if (aVendorCount[lineNo] > 1)
            {
                linedrop = 160;

                ev.Graphics.DrawString(aVendorNo2[lineNo], heading, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString(aVendorName2[lineNo], heading, Brushes.Black, 75, linedrop);
                ev.Graphics.DrawString(aVendorAddress2[lineNo], A9R, Brushes.Black, 400, linedrop);
                linedrop = linedrop + 20;
                ev.Graphics.DrawString("Contact: " + aVendorContact2[lineNo], A9R, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString("Vendor Title: " + aVendorTitle2[lineNo], A9R, Brushes.Black, 300, linedrop);
                linedrop = linedrop + 20;
                ev.Graphics.DrawString("Phone: " + aVendorPhone2[lineNo], A9R, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString("Supplier Line of Business: " + aVendorCommodityCode2[lineNo], A9R, Brushes.Black, 300, linedrop);
                linedrop = linedrop + 20;
                ev.Graphics.DrawString("Fax: " + aVendorFax2[lineNo], A9R, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString("Email: " + aVendorEmail2[lineNo], A9R, Brushes.Black, 300, linedrop);
            }

            linedrop = linedrop + 20;

            ev.Graphics.DrawLine(pen, 25, linedrop, 800, linedrop);

            linedrop = linedrop + 5;

            /*  Item Data   */

            try
            {
                ev.Graphics.DrawString("Copy Exact?", heading, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString(aCopyExact[lineNo], heading, Brushes.Red, 105, linedrop);

                ev.Graphics.DrawString("Inspection?  " + aInspection[lineNo], heading, Brushes.Black, 350, linedrop);


                if (aLocation[lineNo] == "Middlefield")
                {
                    Bpen = new Pen(Color.Turquoise);
                }
                else if (aLocation[lineNo] == "Middlefield Service")
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
                else if (aLocation[lineNo] == "Richmond")
                {
                    Bpen = new Pen(Color.Red);
                }
                else
                {
                    Bpen = new Pen(Color.Black);
                }

                Bpen.Width = 10;


                ev.Graphics.DrawLine(Bpen, 770, linedrop, 770, linedrop + 55);
                ev.Graphics.DrawLine(Bpen, 570, linedrop + 5, 770, linedrop + 5);
                ev.Graphics.DrawLine(Bpen, 570, linedrop + 50, 770, linedrop + 50);
                ev.Graphics.DrawLine(Bpen, 570, linedrop, 570, linedrop + 55);

                linedrop = linedrop + 15;

                ev.Graphics.DrawString(aLocation[lineNo], title, Brushes.Black, 600, linedrop);

                ////File.AppendAllText(@"C:\A\PrintedMRP1 .txt", aItemNo[lineNo].ToString() + Environment.NewLine);

                ev.Graphics.DrawLine(Gpen, 25, linedrop + 9, 25, linedrop + 61);
                ev.Graphics.DrawLine(Gpen, 25, linedrop + 10, 550, linedrop + 10);
                ev.Graphics.DrawLine(Gpen, 25, linedrop + 60, 550, linedrop + 60);
                ev.Graphics.DrawLine(Gpen, 550, linedrop + 9, 550, linedrop + 61);

                linedrop = linedrop + 20;

                ev.Graphics.DrawString(aItemNo[lineNo], B12, Brushes.Black, 30, linedrop);

                ev.Graphics.DrawString(aDescription[lineNo], heading, Brushes.Black, 250, linedrop + 3);

                /*  Revision Data   */

                linedrop = linedrop + 20;

                try
                {
                    ev.Graphics.DrawString("Current Rev: ", heading, Brushes.Black, 30, linedrop);
                    ev.Graphics.DrawString(aCurrentRev[lineNo], A9R, Brushes.Black, 110, linedrop);
                    ev.Graphics.DrawString("ECO: ", heading, Brushes.Black, 140, linedrop);
                    ev.Graphics.DrawString(aECOnumber[lineNo], A9R, Brushes.Black, 180, linedrop);
                    ev.Graphics.DrawString("Eff Date: ", heading, Brushes.Black, 270, linedrop);
                    ev.Graphics.DrawString(aEffectiveDate[lineNo], A9R, Brushes.Black, 330, linedrop);
                    ev.Graphics.DrawString("ECO Status: ", heading, Brushes.Black, 400, linedrop);
                    if (aECOstatus[lineNo] != "Released")
                    {
                        ev.Graphics.DrawString(aECOstatus[lineNo], A9R, Brushes.Red, 480, linedrop);
                    }
                    else
                    {
                        ev.Graphics.DrawString(aECOstatus[lineNo], A9R, Brushes.Black, 480, linedrop);
                    }
                }
                catch (Exception ex)
                {
                    File.AppendAllText(ErrorLog, " 2163 Revision Data " + ex.ToString() + Environment.NewLine);

                }

                ev.Graphics.DrawString("Annual Spend Using F6 * 2: ", A9R, Brushes.Black, 560, linedrop);
                var box = new Rectangle(620, linedrop, 180, 20);
                ev.Graphics.DrawString(aAnnualSpend[lineNo], A9R, Brushes.Black, box, alignR);

                linedrop = linedrop + 25;

                ev.Graphics.DrawString("Commodity Code:", heading, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString(aItemCommodityCode[lineNo], A9R, Brushes.Black, 135, linedrop);

                box = new Rectangle(420, linedrop, 100, 20);
                ev.Graphics.DrawString("Nettable Stk: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(500, linedrop, 55, 20);
                ev.Graphics.DrawString(aNettableStock[lineNo], A9R, Brushes.Black, box, alignR);

                box = new Rectangle(580, linedrop, 100, 20);
                ev.Graphics.DrawString("Qty Multiplier: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(700, linedrop, 100, 20);
                ev.Graphics.DrawString(aQtyMultiplier[lineNo], A9R, Brushes.Black, box, alignR);

                /******************************************************************************/

                linedrop = linedrop + 15;

                ev.Graphics.DrawString("Product Type:", heading, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString(aProductType[lineNo], A9R, Brushes.Black, 135, linedrop);

                box = new Rectangle(370, linedrop, 150, 20);
                ev.Graphics.DrawString("MRB Non-Net Stk: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(500, linedrop, 55, 20);
                ev.Graphics.DrawString(aNonNetStock[lineNo], A9R, Brushes.Black, box, alignR);

                box = new Rectangle(580, linedrop, 100, 20);
                ev.Graphics.DrawString("Min Qty: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(700, linedrop, 100, 20);
                ev.Graphics.DrawString(aMinQty[lineNo], A9R, Brushes.Black, box, alignR);

                /******************************************************************************/

                linedrop = linedrop + 15;

                ev.Graphics.DrawString("Selection Code:", heading, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString(aSelectionCode[lineNo], A9R, Brushes.Black, 135, linedrop);

                box = new Rectangle(420, linedrop, 100, 20);
                ev.Graphics.DrawString("On Order: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(500, linedrop, 55, 20);
                ev.Graphics.DrawString(aOnOrder[lineNo], A9R, Brushes.Red, box, alignR);

                box = new Rectangle(580, linedrop, 100, 20);
                ev.Graphics.DrawString("Reorder Point: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(700, linedrop, 100, 20);
                ev.Graphics.DrawString(aReorderPoint[lineNo], A9R, Brushes.Black, box, alignR);

                /******************************************************************************/

                linedrop = linedrop + 15;

                ev.Graphics.DrawString("Item Group:", heading, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString(aItemGroup[lineNo], A9R, Brushes.Black, 135, linedrop);

                box = new Rectangle(420, linedrop, 100, 20);
                ev.Graphics.DrawString("Blocked Stock: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(500, linedrop, 55, 20);
                ev.Graphics.DrawString(aBlockedStock[lineNo], A9R, Brushes.Black, box, alignR);

                box = new Rectangle(560, linedrop, 120, 20);
                ev.Graphics.DrawString("Reorder Quantity: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(700, linedrop, 100, 20);
                ev.Graphics.DrawString(aReorderQty[lineNo], A9R, Brushes.Black, box, alignR);

                /******************************************************************************/

                linedrop = linedrop + 15;

                ev.Graphics.DrawString("Signal Code:", heading, Brushes.Black, 25, linedrop);

                if (aSignalCode[lineNo] == "** None **")
                {
                    ev.Graphics.DrawString(aSignalCode[lineNo], A9R, Brushes.Black, 135, linedrop);
                }
                else
                {
                    ev.Graphics.DrawString(aSignalCode[lineNo], A9R, Brushes.Red, 135, linedrop);
                }

                box = new Rectangle(420, linedrop, 100, 20);
                ev.Graphics.DrawString("Safety Stock: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(500, linedrop, 55, 20);
                ev.Graphics.DrawString(aSafetyStock[lineNo], A9R, Brushes.Red, box, alignR);

                box = new Rectangle(530, linedrop, 150, 20);
                ev.Graphics.DrawString("Last Purch Price: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(700, linedrop, 100, 20);
                ev.Graphics.DrawString(aLastPurchPrice[lineNo], A9R, Brushes.Black, box, alignR);

                /******************************************************************************/

                linedrop = linedrop + 15;

                ev.Graphics.DrawString("Lead Time: ", heading, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString(aLeadTime[lineNo], A9R, Brushes.Black, 135, linedrop);

                if (aNonDomesticVendor[lineNo] == "TRUE" & aHTS[lineNo] == "")
                {
                    ev.Graphics.DrawString("HTS Code: ", heading, Brushes.Red, 260, linedrop);
                }
                else
                {
                    ev.Graphics.DrawString("HTS Code: ", heading, Brushes.Black, 260, linedrop);
                    ev.Graphics.DrawString(aHTS[lineNo], A9R, Brushes.Black, 340, linedrop);
                }

                box = new Rectangle(420, linedrop, 100, 20);
                ev.Graphics.DrawString("Allocations: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(500, linedrop, 55, 20);
                ev.Graphics.DrawString(aAllocations[lineNo], A9R, Brushes.Black, box, alignR);

                box = new Rectangle(580, linedrop, 100, 20);
                ev.Graphics.DrawString("Purch Price: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(700, linedrop, 100, 20);
                ev.Graphics.DrawString(aPurchPrice[lineNo], A9R, Brushes.Black, box, alignR);

                /******************************************************************************/

                linedrop = linedrop + 15;

                ev.Graphics.DrawString("Lot Accumulation Period: ", heading, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString(aLotAccumulationPeriod[lineNo], A9R, Brushes.Black, 185, linedrop);

                if (aNonDomesticVendor[lineNo] == "TRUE" & aNetWeight[lineNo] == "0.000000")
                {
                    ev.Graphics.DrawString("Net Wt (kg): ", heading, Brushes.Red, 260, linedrop);
                }
                else
                {
                    ev.Graphics.DrawString("Net Wt (kg): ", heading, Brushes.Black, 260, linedrop);
                    ev.Graphics.DrawString(aNetWeight[lineNo], A9R, Brushes.Black, 340, linedrop);
                }

                box = new Rectangle(420, linedrop, 100, 20);
                ev.Graphics.DrawString("SIM: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(500, linedrop, 55, 20);
                ev.Graphics.DrawString(aSIM[lineNo], A9R, Brushes.Black, box, alignR);

                box = new Rectangle(580, linedrop, 100, 20);
                ev.Graphics.DrawString("Std Cost: ", A9R, Brushes.Black, box, alignR);
                box = new Rectangle(700, linedrop, 100, 20);
                ev.Graphics.DrawString(aStdCost[lineNo], A9R, Brushes.Black, box, alignR);


                /******************************************************************************/

                linedrop = linedrop + 15;

                ev.Graphics.DrawString("LTA Release Bucket: ", heading, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString(aLTAReleaseBucket[lineNo] + " days", A9R, Brushes.Black, 185, linedrop);

                ev.Graphics.DrawString("Supplier Replenishment: ", heading, Brushes.Black, 260, linedrop);
                ev.Graphics.DrawString(aSupplierReplenishment[lineNo] + " days", A9R, Brushes.Black, 420, linedrop);

                /******************************************************************************/

                linedrop = linedrop + 15;

                ev.Graphics.DrawString("Dampener Period: ", heading, Brushes.Black, 25, linedrop);
                /*  need to start the text in different spots due to length of string    */
                if (aDampenerPeriod[lineNo] == "Current Month")
                {
                    ev.Graphics.DrawString(aDampenerPeriod[lineNo], A9R, Brushes.Black, 140, linedrop + 1);
                }
                else
                {
                    ev.Graphics.DrawString(aDampenerPeriod[lineNo], A9R, Brushes.Black, 185, linedrop);
                }

                ev.Graphics.DrawString("Dampener Quantity: ", heading, Brushes.Black, 260, linedrop);
                ev.Graphics.DrawString(aDampenerQuantity[lineNo], A9R, Brushes.Black, 400, linedrop);

                /******************************************************************************/

                linedrop = linedrop + 15;

                ev.Graphics.DrawString("Dampener Days Late: ", heading, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString(aDampnerDaysLate[lineNo], A9R, Brushes.Black, 185, linedrop);

                ev.Graphics.DrawString("SDS Doc No: ", heading, Brushes.Black, 260, linedrop);
                ev.Graphics.DrawString(aSDSDocumentNo[lineNo], A9R, Brushes.Black, 340, linedrop);

                if (aFAIonOrder[lineNo] != "0" | aFAINettable[lineNo] != "0" | aFAINonNettable[lineNo] != "0")
                {
                    Bpen = new Pen(Color.Red);
                }
                else
                {
                    Bpen = new Pen(Color.Black);
                }

                ev.Graphics.DrawString("FAI On Order: ", heading, Brushes.Black, 505, linedrop);

                ev.Graphics.DrawString(aFAIonOrder[lineNo], A9R, Brushes.Black, 595, linedrop);

                ev.Graphics.DrawString("FAI Nettable: ", heading, Brushes.Black, 645, linedrop);

                ev.Graphics.DrawString(aFAINettable[lineNo], A9R, Brushes.Black, 765, linedrop);

                Bpen = new Pen(Color.Black);

                /******************************************************************************/

                linedrop = linedrop + 15;

                /* using rectangles to get data to line up correctly    */

                ev.Graphics.DrawString("P6: ", heading, Brushes.Black, 25, linedrop);
                box = new Rectangle(40, linedrop, 35, 20);
                ev.Graphics.DrawString(aP6[lineNo], A9R, Brushes.Black, box, alignR);

                ev.Graphics.DrawString("F6: ", heading, Brushes.Black, 100, linedrop);
                box = new Rectangle(115, linedrop, 35, 20);
                ev.Graphics.DrawString(aF6[lineNo], A9R, Brushes.Black, box, alignR);

                ev.Graphics.DrawString("EAU: ", heading, Brushes.Black, 175, linedrop);
                box = new Rectangle(200, linedrop, 35, 20);
                ev.Graphics.DrawString(aEAU[lineNo], A9R, Brushes.Black, box, alignR);

                ev.Graphics.DrawString("Order Method: ", heading, Brushes.Black, 260, linedrop);
                ev.Graphics.DrawString(aOrderMethod[lineNo], A9R, Brushes.Black, 350, linedrop);

                if (aFAIonOrder[lineNo] != "0.00" | aFAINettable[lineNo] != "0.00" | aFAINonNettable[lineNo] != "0.00")
                {
                    Bpen = new Pen(Color.Red);
                }
                else
                {
                    Bpen = new Pen(Color.Black);
                }

                ev.Graphics.DrawString("FAI Non-Nettable: ", heading, Brushes.Black, 645, linedrop);

                ev.Graphics.DrawString(aFAINonNettable[lineNo], A9R, Brushes.Black, 765, linedrop);

                Bpen = new Pen(Color.Black);

                /******************************************************************************/



                if (aFAIonOrder[lineNo] != "0.00" | aFAINettable[lineNo] != "0.00" | aFAINonNettable[lineNo] != "0.00")
                {
                    Bpen = new Pen(Color.Red);
                }
                else
                {
                    Bpen = new Pen(Color.Black);
                }

                Bpen.Width = 4;

                ev.Graphics.DrawLine(Bpen, 493, linedrop - 17, 802, linedrop - 17);
                ev.Graphics.DrawLine(Bpen, 493, linedrop + 17, 802, linedrop + 17);
                ev.Graphics.DrawLine(Bpen, 495, linedrop - 17, 495, linedrop + 17);
                ev.Graphics.DrawLine(Bpen, 800, linedrop - 17, 800, linedrop + 017);


                Bpen = new Pen(Color.Black);


            }
            catch (Exception ex)
            {
                File.AppendAllText(ErrorLog, " 2294 Item Data   " + ex.ToString() + Environment.NewLine);

            }

            linedrop = linedrop + 15;

            ev.Graphics.DrawLine(pen, 25, linedrop, 800, linedrop);

            linedrop = linedrop + 5;

            try
            {

                /*  Manufacturer Data   */

                ev.Graphics.DrawString("Manuf Name", U9, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString("Manuf Part Number", U9, Brushes.Black, 275, linedrop);
                ev.Graphics.DrawString("Preferred?", U9, Brushes.Black, 525, linedrop);
                ev.Graphics.DrawString("Description", U9, Brushes.Black, 625, linedrop);

                linedrop = linedrop + 15;

                for (int ii = 0; ii < aMfrCount[lineNo]; ii++)
                {
                    ev.Graphics.DrawString(aMfrName[lineNo, ii], A9R, Brushes.Black, 25, linedrop);
                    ev.Graphics.DrawString(aMfrPartNumber[lineNo, ii], A9R, Brushes.Black, 275, linedrop);
                    ev.Graphics.DrawString(aPreferred[lineNo, ii], A9R, Brushes.Black, 540, linedrop + 1);
                    ev.Graphics.DrawString(aMfrDescription[lineNo, ii], A9R, Brushes.Black, 625, linedrop);
                    linedrop = linedrop + 15;
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(ErrorLog, " 2418 Manufacturer Data  " + ex.ToString() + Environment.NewLine);

            }

            linedrop = linedrop + 15;

            ev.Graphics.DrawLine(pen, 25, linedrop, 800, linedrop);
            ev.Graphics.DrawLine(pen, 490, linedrop, 490, 975);

            linedrop = linedrop + 5;

            try
            {

                /*  MRP Recommended Orders   */

                ev.Graphics.DrawString("MRP RECOMMENDED ORDERS", U9, Brushes.Black, 25, linedrop);

                linedrop = linedrop + 20;

                ev.Graphics.DrawString("Start", U9, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString("Orig", U9, Brushes.Black, 90, linedrop);
                ev.Graphics.DrawString("Rqstd", U9, Brushes.Black, 150, linedrop);
                ev.Graphics.DrawString("Order Qty", U9, Brushes.Black, 200, linedrop);
                ev.Graphics.DrawString("Ext Cost", U9, Brushes.Black, 270, linedrop);
                ev.Graphics.DrawString("Loc", U9, Brushes.Black, 335, linedrop);
                ev.Graphics.DrawString("Action", U9, Brushes.Black, 390, linedrop);
                ev.Graphics.DrawString("Best", U9, Brushes.Black, 450, linedrop);

                ev.Graphics.DrawString("OPEN PURCHASE ORDERS", U9, Brushes.Black, 500, linedrop - 20);
                ev.Graphics.DrawString("P.O", U9, Brushes.Black, 500, linedrop);
                ev.Graphics.DrawString("Line", U9, Brushes.Black, 560, linedrop);
                ev.Graphics.DrawString("Qty", U9, Brushes.Black, 600, linedrop);
                ev.Graphics.DrawString("Requested", U9, Brushes.Black, 640, linedrop);
                ev.Graphics.DrawString("Promised", U9, Brushes.Black, 710, linedrop);
                ev.Graphics.DrawString("Vendor", U9, Brushes.Black, 770, linedrop);

                linedrop = linedrop + 20;
                POlinedrop = linedrop;

                ev.Graphics.DrawString("Current Order (inside 2 weeks)", A9R, Brushes.Black, 25, linedrop);

                linedrop = linedrop + 20;


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
                        box = new Rectangle(250, linedrop, 70, 20);
                        ev.Graphics.DrawString(acAmountStandard[lineNo, ii], A9R, Brushes.Black, box, alignR);
                        ev.Graphics.DrawString(acLocation[lineNo, ii], A9R, Brushes.Black, 335, linedrop);
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


                try
                {
                    for (int ii = 0; ii < 20; ii++)
                    {
                        ev.Graphics.DrawString(aPO[lineNo, ii], A9R, Brushes.Black, 500, POlinedrop + (ii * 20));
                        ev.Graphics.DrawString(aPOLine[lineNo, ii], A9R, Brushes.Black, 560, POlinedrop + (ii * 20));
                        ev.Graphics.DrawString(aPOLineQty[lineNo, ii], A9R, Brushes.Black, 600, POlinedrop + (ii * 20));
                        ev.Graphics.DrawString(aPOLineRequestedDate[lineNo, ii], A9R, Brushes.Black, 640, POlinedrop + (ii * 20));
                        ev.Graphics.DrawString(aPOLinePromisedDate[lineNo, ii], A9R, Brushes.Black, 710, POlinedrop + (ii * 20));
                        ev.Graphics.DrawString(aPOVendor[lineNo, ii], A9R, Brushes.Black, 770, POlinedrop + (ii * 20));
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

            await Task.Delay(1000);
        }
        private async void print_PartTwo(PrintPageEventArgs ev, int linedrop)
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

            await Task.Delay(1000);
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
            /*
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

                        //if (aMRPCurrentCount[lineNo] > 0)
                        //{
                        //    //int sectionLimit = Convert.ToInt32(aMRPCurrentPagePlus1[lineNo]);

                        //    for (int ii = 28; ii < aMRPCurrentCount[lineNo] + 1; ii++)
                        //    {
                        //        ev.Graphics.DrawString(acOrderDate[lineNo, ii], A9R, Brushes.Black, 25, linedrop);
                        //        ev.Graphics.DrawString(acOrigDueDate[lineNo, ii], A9R, Brushes.Black, 90, linedrop);
                        //        ev.Graphics.DrawString(acDeliveryDate[lineNo, ii], A9R, Brushes.Black, 150, linedrop);
                        //        ev.Graphics.DrawString(acOrderQuantity[lineNo, ii], A9R, Brushes.Black, 220, linedrop);
                        //        //ev.Graphics.DrawString(acAmountStandard[lineNo, ii], A9R, Brushes.Black, 270, linedrop);
                        //        box = new Rectangle(250, linedrop, 70, 20);
                        //        ev.Graphics.DrawString(acAmountStandard[lineNo, ii], A9R, Brushes.Black, box, alignR);
                        //        ev.Graphics.DrawString(acLocation[lineNo, ii], A9R, Brushes.Black, 335, linedrop);
                        //        //ev.Graphics.DrawString(acBinCode[lineNo, ii], A9R, Brushes.Black, 550, linedrop);
                        //        ev.Graphics.DrawString(acAction[lineNo, ii], A9R, Brushes.Black, 390, linedrop);
                        //        ev.Graphics.DrawString(acBestDate[lineNo, ii], A9R, Brushes.Black, 450, linedrop);
                        //        linedrop = linedrop + 20;
                        //    }


                        //}

                        //currentOverflowPrinted[lineNo] = true;

                        //print_PartTwo(ev, linedrop);
                        partTwoPrinted[lineNo] = true;
                    }


                    private void BClose_Click(object sender, EventArgs e)
                    {
                        this.Close();
                    }
            */
        }
    }
}
