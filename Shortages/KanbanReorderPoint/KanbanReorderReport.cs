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
using System.IO;
using System.Drawing.Printing;

namespace KanbanReorderPoint
{
    public partial class KanbanReorderReport : Form
    {
        private int KBcalculated;
        private int POquantity;
        private string KBreorder;
        private int leadTime;
        private bool ordered = false;

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
        private string[] aP6 = new string[20000];
        private string[] aF6 = new string[20000];
        private string[] aEAU = new string[20000];
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
        private string[] KBpoOrder = new string[20000];
        private string[] KBpoStart = new string[20000];
        private string[] KBpoEnd = new string[20000];

        private string[,] acOrderDate = new string[10000, 50];
        private string[,] acDeliveryDate = new string[10000, 50];
        private string[,] acOrderQuantity = new string[10000, 50];
        private string[,] acAmountStandard = new string[10000, 50];
        private string[,] acLocation = new string[10000, 50];
        private string[,] acAction = new string[10000, 50];
        private string[,] acBinCode = new string[20000, 50];
        private string[,] afOrderDate = new string[20000, 50];
        private string[,] afDeliveryDate = new string[20000, 50];
        private string[,] afOrderQuantity = new string[20000, 50];
        private string[,] afAmountStandard = new string[20000, 50];
        private string[,] afLocation = new string[20000, 50];
        private string[,] afAction = new string[10000, 50];
        private string[,] afBinCode = new string[20000, 50];
        private string[,] aRecriptDate = new string[20000, 5];
        private string[,] aReceiptOrder = new string[20000, 5];
        private string[,] aReceiptPosition = new string[20000, 5];
        private string[,] aReceiptVendor = new string[20000, 5];
        private string[,] aReceiptPrice = new string[20000, 5];
        private string[,] aReceiptDeliveredQuantity = new string[20000, 5];
        private string[,] aReceiptNetAmount = new string[20000, 5];
        private string[,] aItemText = new string[20000, 10];
        private string[,] aPO = new string[20000, 5];
        private string[,] aPOLine = new string[20000, 5];
        private string[,] aPOLineQty = new string[20000, 5];
        private string[,] aPOLineRequestedDate = new string[20000, 5];
        private string[,] aPOLinePromisedDate = new string[20000, 5];

        private int[] aMRPCurrentCount = new int[20000];
        private int[] aMRPFutureCount = new int[20000];
        private int[] aReceiptCount = new int[20000];
        private int[] aItemTextCount = new int[20000];
        private int[] KBpoOpen = new int[20000];
        private bool[] twoPagesRequired = new bool[20000];
        private bool[] pageOnePrinted = new bool[20000];
        private bool[] pageTwoPrinted = new bool[20000];
        private bool[] partOnePrinted = new bool[20000];
        private bool[] partTwoPrinted = new bool[20000];

        private int i = 0;
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
        private string KBstart = string.Empty;
        private string KBend = string.Empty;
        private string KBorder = string.Empty;

        SqlConnection cnxn1;
        SqlConnection cnxn2;
        SqlConnection cnxn;
        SqlConnection cnxnDash;
        SqlConnection cnxnAFE;
        SqlDataReader dr;

        DataTable dtVendor;
        DataTable dtMRPOrdersCurrent;
        DataTable dtMRPOrdersFuture;
        DataTable dtReceipts;
        DataTable dtItem;
        DataTable dtPINS;
        DataTable dtDocCtrl;
        DataTable dtItemText;
        DataTable dtPOLines;



        public KanbanReorderReport()
        {
            InitializeComponent();
        }

        private void KanbanReorderReport_Load(object sender, EventArgs e)
        {

            /*
             *  Connection used to get the items in the loop for processing
             */

            cnxn1 = new SqlConnection("server=pa-hor-as408.ametek.com; password=2018#ameteK; " +
                                        "user=navdb_read; database=ZYGO-NAV-PROD;");

            cnxn2 = new SqlConnection("server=pa-hor-as408.ametek.com; password=2018#ameteK; " +
                                        "user=navdb_read; database=ZYGO-NAV-PROD;");

            /*
             *  Conection used by loop within the reader
             */

            cnxn = new SqlConnection("server=pa-hor-as408.ametek.com; password=2018#ameteK; " +
                                        "user=navdb_read; database=ZYGO-NAV-PROD;");

            /*
             *Connection used to get the Dashboard data
             */

            cnxnDash = new SqlConnection("server=MIDDB01; password=views; " +
              "user=views; database=Dashboard;");

            /*
             *Connection used to get the old MK data
             */

            cnxnAFE = new SqlConnection("server=CT-MID-SQL01; password=views; " +
                          "user=views; database=AccessFrontEnds;");



            SqlCommand cmd = new SqlCommand(
                "WITH s1 AS " +
                "( " +
                "SELECT " +
                "No_ " +
                ", COALESCE(CONVERT(int, CASE " +
                "     WHEN CHARINDEX(CHAR(3), [Lead Time Calculation]) > 0 THEN REPLACE([Lead Time Calculation], CHAR(3), '') " +
                "     END), 0) LeadTime " +
                "FROM ZYGO$Item " +
                "WHERE " +
                "[Selection Code] = 'KBP' " +
                ")" +
                "SELECT " +
                "i.No_" +
                ",LeadTime " +
                "FROM ZYGO$Item i " +
                "LEFT JOIN s1 ON i.No_ = s1.No_ " +
                "WHERE " +
                "[Selection Code] = 'KBP' " +
                "AND CHARINDEX('X', i.No_, 1) = 0" +
                "AND s1.LeadTime < 130 " +
                "AND i.No_ NOT LIKE '%FAI' " +
                //"AND i.No_ = '1120-300-153' " +
                "ORDER BY i.No_"
                , cnxn1);

            SqlDataReader dr1;

            try
            {
                cnxn1.Open();
                dr1 = cmd.ExecuteReader();

                DataTable viewtable = new DataTable();
                viewtable.Load(dr1);

                dr1 = cmd.ExecuteReader();

                while (dr1.Read())
                {
                    ItemNo = dr1.GetString(0);
                    //itemNumber = "1046-480-055";
                    /*  leadtime from NAV is in work days    */
                    leadTime = dr1.GetInt32(1);
                    //leadTime = 30;
                    /*  convert leadtime to days - add back weekends for full weeks -    
                        then add two weeks lead time
                     */
                    leadTime = leadTime + ((leadTime / 5) * 2) + 14;

                    /*      
                     *   Find remaining quantity on blanket order
                     *  Document Type = 4 = Blanket Order
                     */
                    cmd = new SqlCommand("SELECT TOP 1 " +
                        "CONVERT(int, COALESCE(SUM([Outstanding Quantity]),0)) " +
                        ",FORMAT(MIN([Contract Start Date]),'MM-dd-yy') " +
                        ",FORMAT(MAX([Contract End Date]),'MM-dd-yy') " +
                        ",MAX(h.No_) " +
                        "FROM [ZYGO$Purchase Line] l " +
                        "INNER JOIN [ZYGO$Purchase Header] h ON l.[Document No_] = h.No_ " +
                        "WHERE l.No_ = '" + ItemNo + "' AND h.[Document Type] = 4 " +
                        "ORDER BY MAX([Contract End Date]) DESC ", cnxn2);

                    try
                    {
                        cnxn2.Open();

                        SqlDataReader dr2;
                        dr2 = cmd.ExecuteReader();

                        while (dr2.Read())
                        {
                            KBpoOpen[i] = dr2.GetInt32(0);
                            if (!dr2.IsDBNull(1)) { KBpoStart[i] = dr2.GetString(1); } else { KBpoStart[i] = "01-01-2010"; }
                            if (!dr2.IsDBNull(2)) { KBpoEnd[i] = dr2.GetString(2); } else { KBpoEnd[i] = "01-01-2010"; }
                            if (!dr2.IsDBNull(3)) { KBpoOrder[i] = dr2.GetString(3); } else { KBpoOrder[i] = "No KB-Order"; }
                            
                            KBcalculated = KBpoOpen[i];
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn2.Close();
                    }

                    /*
                     *  Going to requisition line to get MRP proposed purchases
                     *  
                     * */

                    cmd = new SqlCommand("SELECT " +
                        "CONVERT(int, Quantity)" +
                        ", DATEADD(dd, -" + leadTime + ",[Due Date])" +
                        ", [Due Date] " +
                        ", [Buyer Planner Code]" +
                        ", [Vendor No_] " +
                        "FROM [ZYGO$Requisition Line] " +
                        "WHERE No_ = '" + ItemNo + "' AND [Due Date] < (GETDATE()+1500) " +
                        "AND [Action Message] not in (3,5) " +
                        "ORDER BY " +
                        " [Buyer Planner Code] " +
                        ",[Vendor No_] " +
                        ", No_", cnxn2);

                    try
                    {
                        cnxn2.Open();
                        dr = cmd.ExecuteReader();

                        DataTable dtt = new DataTable();
                        dtt.Load(dr);

                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            POquantity = dr.GetInt32(0);


                            if (KBcalculated - POquantity > 0)
                            {
                                KBcalculated = KBcalculated - POquantity;
                            }
                            else
                            {
                                if (ordered)
                                {
                                    /*  skip if already printed   */
                                }
                                else
                                {
                                    /*  Here is where the item needs to have a new order put in   */

                                    itemData();

                                    ordered = true;
                                }
                            }
                        }

                        /*
                         *  dr reads the orders for the item.  When it is done the next item  from the outer loop
                         *  is called.
                         * */

                        ordered = false;


                        //KBreorder = dr.GetDateTime(1).ToShortDateString();
                        //string RunoutDate = dr.GetDateTime(2).ToShortDateString();
                        //File.AppendAllText(@"C:\A\KanbanTest.csv", ItemNo + "," + RunoutDate + "," + leadTime.ToString() + "," + KBopen.ToString() + "," + KBreorder + Environment.NewLine);
                        //printed = true;

                        //printed = false;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn2.Close();
                    }

                    

                }

                /*  colins and back slashes in the date time make the path unreadable    */
                string today = DateTime.Now.ToString("MM-dd-yy hh.mm.ss");
                string file = "Kanban Reorder Report  " + today + ".pdf";
                //string directory = "\\\\MIDFILE01\\departments\\procurement\\purchasing\\mrp_requisitions\\MRP NAV";
                string directory = "C:\\A";
                // }

                PrintDocument pd = new PrintDocument();
                pd.DefaultPageSettings.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                pd.PrinterSettings.PrintToFile = true;
                pd.PrinterSettings.PrintFileName = Path.Combine(directory, file);
                StandardPrintController pc = new StandardPrintController();
                pd.PrintController = pc;

                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                try
                {
                    pd.Print();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ItemNo + " " + i.ToString() + "    " + ex.ToString());
                }


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn1.Close();
            }



        }

        private void itemData()
        {
            buyerPlanner = dr.GetString(3);

            SqlDataAdapter da;

            /*
             *  Vendor data
             */

            SqlCommand loopCmd = new SqlCommand
            ("SELECT [Vendor No_] FROM [" + NAVprefix + "Item] " +
             "WHERE No_ = '" + ItemNo + "'", cnxn);
            cnxn.Open();
            object o = loopCmd.ExecuteScalar();
            cnxn.Close();

            if (o == null)
            {
                ////MessageBox.Show("This item does not exist.");
            }
            else
            {
                VendorNo = o.ToString();
            }

            loopCmd = new SqlCommand(
            "SELECT " +
            "No_ " +
            ", Name " +
            ", City " +
            ", County " +
            ",[Country_Region Code] " +
            ", Contact " +
            ",[Phone No_] " +
            ",[E-Mail] " +
            ",[Fax No_] " +
            ",[Vendor Title] + '  ' + t.Description " +
            ",[Line of Business of a Supplier] + '  ' + b.Description " +
            "FROM [" + NAVprefix + "Vendor] v " +
            "LEFT JOIN [" + NAVprefix + "Vendor Title] t  ON v.[Vendor Title] = t.Code " +
            "LEFT JOIN [" + NAVprefix + "Line of Business] b  ON v.[Line of Business of a Supplier] = b.Code " +
            "WHERE No_ = '" + VendorNo + "'", cnxn);

            da = new SqlDataAdapter();
            dtVendor = new DataTable();
            da.SelectCommand = loopCmd;
            da.Fill(dtVendor);



            /*
            *  Item Data 
            */

            loopCmd = new SqlCommand(

                "SELECT " +
                " i.Description " +
                ",CASE [Copy Exact] " +
                "    WHEN 0 THEN 'No' " +
                "    WHEN 1 THEN 'Yes' " +
                "END " +
                ", Commodity + '  ' + c.Description  " +
                ",CASE " +
                "   WHEN LEN([Product Types]) > 0 THEN [Product Types]  + '  ' + p.Description  " +
                "   WHEN LEN([Product Types]) = 0 THEN '** None **' " +
                " END " +
                ",CASE " +
                "   WHEN LEN([Selection Code]) > 0 THEN [Selection Code]  + '  ' + s.Description  " +
                "   WHEN LEN([Selection Code]) = 0 THEN '** None **' " +        /*4*/
                "END " +
                ",CASE " +
                "   WHEN LEN([Item Group Code]) > 0 THEN [Item Group Code]  + '  ' + ig.Description  " +
                "   WHEN LEN([Item Group Code]) = 0 THEN '** None **' " +
                "END " +
                ",CASE " +
                "   WHEN LEN([Signal Code]) > 0 THEN [Signal Code]  + '  ' + g.Description  " +
                "   WHEN LEN([Signal Code]) = 0 THEN '** None **' " +
                "END " +
                ",CASE  WHEN LEN(i.[Lead Time Calculation]) = 0 THEN '0' " +
                "      WHEN CHARINDEX(CHAR(3),i.[Lead Time Calculation]) > 0 " +
                "           THEN REPLACE(i.[Lead Time Calculation], CHAR(3), '') " +
                "    WHEN CHARINDEX(CHAR(4),i.[Lead Time Calculation]) > 0 THEN " + // --week 
                "       REPLACE(i.[Lead Time Calculation], CHAR(4), '') * 5	" +       //--convert to days 
                "    WHEN CHARINDEX(CHAR(5),i.[Lead Time Calculation]) > 0 THEN " + // --month 
                "       REPLACE(i.[Lead Time Calculation], CHAR(5), '') * 20	" +       //--convert to days 
                "   WHEN CHARINDEX(CHAR(2),i.[Lead Time Calculation]) > 0 THEN " +      //-- days 
                "       REPLACE(i.[Lead Time Calculation], CHAR(2), '')		" +
                "END [Lead Time Calculation] " + /*7*/
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
                " END [Lot Accumulation Period]" +
                ",i.[Revision Level] " +
                ",i.[Vendor Item No_] " +
                ",COALESCE([Safety Stock Quantity], 0.00) " +    /*11*/
                ", CASE[Reordering Policy] " +
                "    WHEN 1 THEN 'Fixed Order Quantity' " +
                "    WHEN 2 THEN 'Maximum Quantity' " +
                "    WHEN 3 THEN 'Order' " +
                "    WHEN 4 THEN 'Lot for Lot' " +
                "END [Order Method] " +
                ",FORMAT([Order Multiple],'N', 'en-us') " +             /* problems with arithmatic overflow when using coalesce  */
                ",FORMAT([Minimum Order Quantity],'N', 'en-us') " +
                ",FORMAT([Standard Cost], 'C', 'en-us') " +
                ",FORMAT([Proposed Purchase Cost],'C', 'en-us') " +  /*16*/
                ",FORMAT([Last Direct Cost],'C', 'en-us') " +
                ",CASE [Stock Location] " +
                "     WHEN 'MID' THEN 'Middlefield' " +
                "     WHEN 'MID SVC' THEN 'Middlefield Service'" +
                "     WHEN 'RIC' THEN 'Richmond' " +
                "     WHEN 'IRV' THEN 'Irvine' " +
                "     WHEN 'IRV MRB' THEN 'Irvine MRB'" +
                " END " +
                ",CASE [Inspection Code] " +
                "     WHEN 'D' THEN 'No Inspection' " +
                "     WHEN 'I' THEN 'Inspection Required' " +
                " END " +
                ",[Standard Cost]" +    /* 20  pulling standard cost without dollar sign to use in calculation     */
                ",FORMAT([Reorder Point],'N', 'en-us')" +
                ",FORMAT([Reorder Quantity],'N', 'en-us') " +
                ",[Vetted] " +  /*  23    */
                ",CASE SIM " +
                "   WHEN 1 THEN 'A1' " +
                "   WHEN 2 THEN 'A2' " +
                "   WHEN 3 THEN 'A3' " +
                "   WHEN 4 THEN 'B1' " +
                "   WHEN 5 THEN 'B2' " +
                "   WHEN 6 THEN 'B3' " +
                "   WHEN 7 THEN 'C1' " +
                "   WHEN 8 THEN 'C2' " +
                "   WHEN 9 THEN 'C3' " +
                "END SIM " +
                "FROM [" + NAVprefix + "Item] i " +
                "LEFT JOIN [" + NAVprefix + "Commodity] c ON i.[Commodity] = c.Code " +
                "LEFT JOIN [" + NAVprefix + "Product Types] p ON i.[Product Types] = p.Code " +
                "LEFT JOIN [" + NAVprefix + "Selection Codes] s ON i.[Selection Code] = s.Code " +
                "LEFT JOIN [" + NAVprefix + "Signal Code] g ON i.[Signal Code] = g.Code " +
                "LEFT JOIN [" + NAVprefix + "Item Group] ig ON i.[Item Group Code] = ig.Code " +
                "LEFT JOIN [" + NAVprefix + "Item Vendor] v ON i.[No_] = v.[Item No_] AND i.[Vendor No_] = v.[Vendor No_] " +
                "WHERE No_ = '" + ItemNo + "'", cnxn);

            da = new SqlDataAdapter();
            dtItem = new DataTable();
            da.SelectCommand = loopCmd;

            try
            {
                da.Fill(dtItem);
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ItemNo + "\n\n" + ex.ToString());
            }

            /*
             *  Item Stock Data 
             * 
             */

            /*  Nettable stock  */

            loopCmd = new SqlCommand
                ("SELECT " +
                "COALESCE(FORMAT(SUM([Quantity]),'N', 'en-us'), '0.00') " +
                "FROM [" + NAVprefix + "Item Ledger Entry] " +
                "WHERE [Non-Nettable] = 0 " +
                "and [Item No_] = '" + ItemNo + "' "
                , cnxn);

            object n = "";

            try
            {
                cnxn.Open();
                n = loopCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            if (n == null)
            {
                ////MessageBox.Show("This item does not exist.");
            }
            else
            {
                nettableStock = n.ToString();
            }


            /*  Non-Nettable stock  */

            loopCmd = new SqlCommand
                ("SELECT " +
                "COALESCE(FORMAT(SUM([Quantity]),'N', 'en-us'), '0.00') " +
                "FROM [" + NAVprefix + "Item Ledger Entry] " +
                "WHERE [Non-Nettable] = 1 " +
                "and [Item No_] = '" + ItemNo + "' "
                , cnxn);

            object nn = "";

            try
            {
                cnxn.Open();
                nn = loopCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            if (nn == null)
            {
                ////MessageBox.Show("This item does not exist.");
            }
            else
            {
                nonnetStock = nn.ToString();
            }

            /*  stock on order  */

            loopCmd = new SqlCommand
            ("SELECT " +
                "COALESCE(FORMAT(SUM(L.[Outstanding Quantity]),'N', 'en-us'), '0.00') " +
                "FROM [" + NAVprefix + "Purchase Line] L " +
                "INNER JOIN [" + NAVprefix + "Item] I ON L.No_ = I.No_ " +
                "WHERE ([Replenishment System] = 0 and [Document Type] = 1 " +
                "and [Outstanding Quantity] > 0) AND L.No_ = '" + ItemNo + "' "
                , cnxn);


            object p = "";

            try
            {
                cnxn.Open();
                p = loopCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }


            if (p == null)
            {
                ////MessageBox.Show("This item does not exist.");
            }
            else
            {
                onOrder = p.ToString();
            }


            /*  blocked stock   */


            loopCmd = new SqlCommand
                ("SELECT " +
                "COALESCE(FORMAT(SUM([Quantity]),'N', 'en-us'), '0.00') " +
                "FROM [" + NAVprefix + "Warehouse Entry] " +
                "WHERE [Bin Code] like '%IQC%' " +
                "and [Item No_] = '" + ItemNo + "' "
                , cnxn);

            object b = "";

            try
            {
                cnxn.Open();
                b = loopCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            if (b == null)
            {
                ////MessageBox.Show("This item does not exist.");
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

                    Status Firm Planned = 2, and Released = 3
                    Quantity goes back to required quantity on BOM
                    Remaining Quantity reflects what is needed for this order
                    Variable naming convention A stands for Allocated, S... stands for Step
            */

            loopCmd = new SqlCommand
               ("SELECT " +
                "COALESCE(SUM([Remaining Quantity]), 0) " +
                "FROM [" + NAVprefix + "Prod_ Order Component] " +
                "WHERE 1=1 " +
                "AND Status in (2, 3) " +
                "and [Item No_] = '" + ItemNo + "' "
               , cnxn);

            object AS1 = 0;

            try
            {
                cnxn.Open();
                AS1 = loopCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            /*  Sales Orders */

            loopCmd = new SqlCommand
               ("SELECT " +
               "COALESCE(SUM([Quantity]), 0) " +
               "FROM [" + NAVprefix + "Sales Line] " +
               "WHERE 1=1 " + //[Posting Date] >= (GETDATE() + 183) " +
               "AND Type = 2 AND [Completely Shipped] = 0 " +
               "and [No_] = '" + ItemNo + "' "
               , cnxn);

            object AS2 = 0;

            try
            {
                cnxn.Open();
                AS2 = loopCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }


            /*  Service Orders */

            loopCmd = new SqlCommand
               ("SELECT " +
               "COALESCE(SUM([Quantity]), 0) " +
               "FROM [" + NAVprefix + "Service Line] " +
               "WHERE 1=1 " + //[Posting Date] >= (GETDATE() + 183) " +
                              //"AND ([Entry Type] = 1 OR [Entry Type] = 5) " +
               "and [No_] = '" + ItemNo + "' "
               , cnxn);

            object AS3 = 0;

            try
            {
                cnxn.Open();
                AS3 = loopCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }


            /*  Job - Inventory Requests */

            loopCmd = new SqlCommand
               ("SELECT " +
               "COALESCE(SUM([Quantity]), 0) " +
               "FROM [" + NAVprefix + "Job Journal Line] " +
               "WHERE 1=1 " + //[Posting Date] >= (GETDATE() + 183) " +
               "AND [Journal Template Name] = 'INVREQ' " +
               "and [No_] = '" + ItemNo + "' "
               , cnxn);

            object AS4 = 0;

            try
            {
                cnxn.Open();
                AS4 = loopCmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }


            Allocations = string.Format("{0:0.00}", (Convert.ToDouble(AS1) + Convert.ToDouble(AS2) + Convert.ToDouble(AS3) + Convert.ToDouble(AS4)));


            loopCmd = new SqlCommand(

             "SELECT " +
             "DFT_P6 " +
             ",DFT_F6 " +
             ",DFT_EAU " +
             "FROM NAV_EAU " +
             "WHERE PartNumber = '" + ItemNo + "'", cnxnDash);

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
                //MessageBox.Show(ex.ToString());
            }


            // Annual Spend = F6 * Standard Cost * 2


            if (F6 != "0")
            {
                int F6x = Convert.ToInt32(F6);
                Double Step1 = (Convert.ToDouble(dtItem.Rows[0][20].ToString()) * F6x * 2);

                spend = string.Format("{0:$0.00}", Step1);
            }
            else
            {
                spend = "$0.00";
            }

            /*
            *  Doc Control
            */

            loopCmd = new SqlCommand(

              "SELECT " +
              "LatestRev " +
              ",CONVERT(varchar(10),[DateCreated], 101) " +
              ",Source " +
              ",ECOStatus " +
              ",ResponsibleUser " +
              "FROM All_PartNumbers " +
              "WHERE PartNumber = '" + ItemNo + "'", cnxnDash);

            da = new SqlDataAdapter();
            dtDocCtrl = new DataTable();
            da.SelectCommand = loopCmd;

            try
            {
                da.Fill(dtDocCtrl);
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.ToString());
            }


            /*
             *  PINS
             */

            loopCmd = new SqlCommand(

              "SELECT " +
              "ManufName " +
              ",ManufPartNumber " +
              ",Qualification " +
              ",CASE Preferred " +
              "     WHEN 0 THEN 'No' " +
              "     WHEN 1 THEN 'Yes' " +
              "END " +
              ",ManufPartDescription " +
              "FROM VIEW_PINS " +
              "WHERE PinsNumber = '" + ItemNo + "'", cnxnDash);

            da = new SqlDataAdapter();
            dtPINS = new DataTable();
            da.SelectCommand = loopCmd;

            try
            {
                da.Fill(dtPINS);
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.ToString() + "   " + ItemNo);
            }

            /*
             * 
             * PO Lines (next 5)
             * 
             */

            loopCmd = new SqlCommand(

              "SELECT TOP 5 " +
              " [Document No_] a " +
              ",[PO Line No_] b " +
              ",FORMAT([Outstanding Quantity],'N', 'en-us') c " +
              ",CONVERT(varchar(10),[Requested Receipt Date], 1) d " +
              ",CONVERT(varchar(10),[Promised Receipt Date], 1) d " +
              "FROM [" + NAVprefix + "Purchase Line] r " +
              "WHERE [Outstanding Quantity] > 0 AND " +
              "[Document Type] = 1 AND r.No_ = '" + ItemNo + "' " +
              "ORDER BY [Requested Receipt Date]", cnxn);

            da = new SqlDataAdapter();
            dtPOLines = new DataTable();


            da.SelectCommand = loopCmd;

            try
            {
                da.Fill(dtPOLines);
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.ToString());
            }



            /*
             *  Last 5 receipts
             */

            loopCmd = new SqlCommand(

              "SELECT TOP 5 " +
              "CONVERT(varchar(10),[Posting Date], 101) a " +
              ",[Order No_] b " +
              ",[PO Line No_] c " +
              ", v.[Name] d " +
              ",FORMAT([Unit Cost], 'C', 'en-us') e " +
              ",FORMAT(Quantity,'N', 'en-us') f " +
              ",FORMAT([Item Charge Base Amount], 'C', 'en-us') g " +
              "FROM [" + NAVprefix + "Purch_ Rcpt_ Line] r " +
              "LEFT JOIN [" + NAVprefix + "Vendor] v on r.[Buy-from Vendor No_] = v.[No_] " +
              "WHERE [Item Rcpt_ Entry No_] > 0 AND r.No_ = '" + ItemNo + "' " +
              "ORDER BY [Posting Date] DESC", cnxn);

            da = new SqlDataAdapter();
            DataTable dtReceipts = new DataTable();


            da.SelectCommand = loopCmd;

            try
            {
                da.Fill(dtReceipts);
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.ToString());
            }

            /*  See how many receipts NAV has and if need be go to MK to get total of five.    */

            if (dtReceipts.Rows.Count < 5)
            {
                string request = (5 - dtReceipts.Rows.Count).ToString();

                loopCmd = new SqlCommand(

             "SELECT TOP " + request + " " +
             "CONVERT(varchar(10),Receipt_Date, 101) a " +
             ",CONVERT(varchar(20),Order_No) b " +
             ",[Position] c " +
             ", s.[Name] d " +
             ",FORMAT([Price], 'C', 'en-us') e " +
             ",FORMAT(Delivered_Quantity,'N', 'en-us') f " +
             ",FORMAT([Net_Goods_Amount], 'C', 'en-us') g " +
             "FROM MMX_RECEIPTS r " +
             "LEFT JOIN MMX_Suppliers s on r.[Supplier] = s.[Supplier] " +
             "WHERE [Delivered_Quantity] > 0 AND r.Item_Code = '" + ItemNo + "' " +
             "ORDER BY Receipt_Date DESC", cnxnAFE);

                da = new SqlDataAdapter();
                DataTable worktable = new DataTable();
                da.SelectCommand = loopCmd;

                try
                {
                    da.Fill(worktable);
                }
                catch (SqlException ex)
                {
                    //MessageBox.Show(ex.ToString());
                }

                try
                {
                    dtReceipts.Merge(worktable, false, MissingSchemaAction.Add);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                }


            }

            aReceiptCount[i] = dtReceipts.Rows.Count;

            /*  Item Card Text */

            /*
             *  Get the item text from the text module line but
             *  if it contains the work embedded, go to the embedded text table
             *  and get the text
             *  
             * */

            loopCmd = new SqlCommand
               ("SELECT " +
               "[Code 1] " +
               ",Text " +
               "FROM [" + NAVprefix + "Text Module Line] " +
               "WHERE [Code 1] = '" + ItemNo + "' "
               , cnxn);


            da = new SqlDataAdapter();
            dtItemText = new DataTable();
            da.SelectCommand = loopCmd;

            try
            {
                da.Fill(dtItemText);
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            aItemTextCount[i] = dtItemText.Rows.Count;

            if (dtItemText.Rows.Count > 0)
            {
                if (dtItemText.Rows[0][1].ToString().Contains("mbed"))
                {
                    loopCmd = new SqlCommand
                       ("SELECT " +
                       "Text " +
                       "FROM NAV_EmbeddedText " +
                       "WHERE [NAV_Key_1] = '" + ItemNo + "' " +
                       "AND NAV_Table = 27 "
                       , cnxnAFE);


                    //da = new SqlDataAdapter();
                    //dtItemText = new DataTable();
                    //da.SelectCommand = loopCmd;

                    try
                    {
                        cnxnAFE.Open();
                        dtItemText.Rows[0][1] = (string)loopCmd.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        //MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxnAFE.Close();
                    }

                }
            }

            try
            {
                aItemNo[i] = ItemNo;
                abuyerPlanner[i] = buyerPlanner;
                if (dtVendor.Rows.Count > 0)
                {
                    try
                    {
                        aVendorNo[i] = dtVendor.Rows[0][0].ToString();
                        aVendorName[i] = dtVendor.Rows[0][1].ToString();
                        aVendorAddress[i] = dtVendor.Rows[0][2].ToString() + ", " +
                        dtVendor.Rows[0][3].ToString() + ", " +
                        dtVendor.Rows[0][4].ToString() + ", ";
                        aVendorContact[i] = dtVendor.Rows[0][5].ToString();
                        aVendorPhone[i] = dtVendor.Rows[0][6].ToString();
                        aVendorEmail[i] = dtVendor.Rows[0][7].ToString();
                        aVendorFax[i] = dtVendor.Rows[0][8].ToString();
                        aVendorTitle[i] = dtVendor.Rows[0][9].ToString();
                        aVendorCommodityCode[i] = dtVendor.Rows[0][10].ToString();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    aVendorNo[i] = " ";
                    aVendorName[i] = " ";
                    aVendorAddress[i] = " ";
                    aVendorContact[i] = " ";
                    aVendorPhone[i] = " ";
                    aVendorEmail[i] = " ";
                    aVendorFax[i] = " ";
                    aVendorTitle[i] = " ";
                    aVendorCommodityCode[i] = " ";
                }

                if (dtItem.Rows.Count > 0)
                {
                    try
                    {
                        aCopyExact[i] = dtItem.Rows[0][1].ToString();
                        aInspection[i] = dtItem.Rows[0][19].ToString();
                        aLocation[i] = dtItem.Rows[0][18].ToString();
                        aDescription[i] = dtItem.Rows[0][0].ToString();
                        aItemCommodityCode[i] = dtItem.Rows[0][2].ToString();
                        aProductType[i] = dtItem.Rows[0][3].ToString();
                        aSelectionCode[i] = dtItem.Rows[0][4].ToString();
                        aItemGroup[i] = dtItem.Rows[0][5].ToString();
                        aSignalCode[i] = dtItem.Rows[0][6].ToString();

                        try
                        {
                            //object y = dtItem.Rows[0][7].GetType();
                            decimal lt = Convert.ToDecimal(dtItem.Rows[0][7].ToString());
                            /*  Lead Time is always in work days - the symbol for work days is \u0003
                                 if greater than one week then add extra week  replace \u00003 with ""*/

                            aLeadTime[i] = lt.ToString() + " Days (" + Convert.ToInt32(Math.Ceiling(lt / 5)).ToString() + " Weeks)";

                            aLotAccumulationPeriod[i] = dtItem.Rows[0][8].ToString() + " Days";
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(aItemNo[i] + "     " + dtItem.Rows[0][7].ToString() + "     " + ex.ToString());
                        }



                        aCurrentRev[i] = dtItem.Rows[0][9].ToString();
                        aAnnualSpend[i] = spend;
                        aNettableStock[i] = nettableStock;
                        aNonNetStock[i] = nonnetStock;
                        aOnOrder[i] = onOrder;
                        aBlockedStock[i] = blockedStock;
                        aSafetyStock[i] = dtItem.Rows[0][11].ToString();
                        aP6[i] = P6;
                        aF6[i] = F6;
                        aEAU[i] = EAU;
                        aOrderMethod[i] = dtItem.Rows[0][12].ToString();
                        aQtyMultiplier[i] = dtItem.Rows[0][13].ToString();
                        aMinQty[i] = dtItem.Rows[0][14].ToString();
                        aStdCost[i] = dtItem.Rows[0][15].ToString();
                        aPurchPrice[i] = dtItem.Rows[0][16].ToString();
                        aLastPurchPrice[i] = dtItem.Rows[0][17].ToString();
                        aAllocations[i] = Allocations;
                        aReorderPoint[i] = dtItem.Rows[0][21].ToString();
                        aReorderQty[i] = dtItem.Rows[0][22].ToString();
                        aVettedStatus[i] = dtItem.Rows[0][23].ToString();
                        aSIM[i] = dtItem.Rows[0][24].ToString();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    aCopyExact[i] = " ";
                    aInspection[i] = " ";
                    aLocation[i] = " ";
                    aDescription[i] = " ";
                    aItemCommodityCode[i] = " ";
                    aProductType[i] = " ";
                    aSelectionCode[i] = "**None** ";
                    aItemGroup[i] = "**None** ";
                    aSignalCode[i] = "**None** ";
                    aLeadTime[i] = " ";
                    aLotAccumulationPeriod[i] = " ";
                    aCurrentRev[i] = " ";

                    aAnnualSpend[i] = "0.00";
                    aNettableStock[i] = " ";
                    aNonNetStock[i] = " ";
                    aOnOrder[i] = " ";
                    aBlockedStock[i] = " ";
                    aSafetyStock[i] = " ";
                    aSIM[i] = " ";
                    aP6[i] = "0.00";
                    aF6[i] = "0.00";
                    aEAU[i] = "0.00";
                    aOrderMethod[i] = " ";
                    aQtyMultiplier[i] = " ";
                    aMinQty[i] = " ";
                    aStdCost[i] = " ";
                    aPurchPrice[i] = " ";
                    aLastPurchPrice[i] = " ";
                    aAllocations[i] = " ";
                }

                if (dtDocCtrl.Rows.Count > 0)
                {
                    try
                    {
                        aSource[i] = dtDocCtrl.Rows[0][2].ToString();
                        aECOstatus[i] = dtDocCtrl.Rows[0][3].ToString();
                        aDateRevCreated[i] = dtDocCtrl.Rows[0][1].ToString();
                        aOwner[i] = dtDocCtrl.Rows[0][4].ToString();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    aSource[i] = " ";
                    aECOstatus[i] = " ";
                    aDateRevCreated[i] = " ";
                    aOwner[i] = " ";
                }

                if (dtPINS.Rows.Count > 0)
                {
                    try
                    {
                        aMfrName[i] = dtPINS.Rows[0][0].ToString();
                        aMfrPartNumber[i] = dtPINS.Rows[0][1].ToString();
                        aQualification[i] = dtPINS.Rows[0][2].ToString();
                        aPreferred[i] = dtPINS.Rows[0][3].ToString();
                        aMfrDescription[i] = dtPINS.Rows[0][4].ToString();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    aMfrName[i] = " ";
                    aMfrPartNumber[i] = " ";
                    aQualification[i] = " ";
                    aPreferred[i] = " ";
                    aMfrDescription[i] = " ";
                }



                if (dtPOLines.Rows.Count > 0)
                {
                    for (int ii = 0; ii < dtPOLines.Rows.Count & ii < 5; ii++)
                    {
                        try
                        {
                            aPO[i, ii] = dtPOLines.Rows[ii][0].ToString();
                            aPOLine[i, ii] = dtPOLines.Rows[ii][1].ToString();
                            aPOLineQty[i, ii] = dtPOLines.Rows[ii][2].ToString();
                            aPOLineRequestedDate[i, ii] = dtPOLines.Rows[ii][3].ToString();
                            aPOLinePromisedDate[i, ii] = dtPOLines.Rows[ii][4].ToString();
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.ToString());
                        }
                    }
                }



                if (dtReceipts.Rows.Count > 0)
                {
                    for (int ii = 0; ii < dtReceipts.Rows.Count & ii < 5; ii++)
                    {
                        try
                        {
                            aRecriptDate[i, ii] = dtReceipts.Rows[ii][0].ToString();
                            aReceiptOrder[i, ii] = dtReceipts.Rows[ii][1].ToString();
                            aReceiptPosition[i, ii] = dtReceipts.Rows[ii][2].ToString();
                            aReceiptVendor[i, ii] = dtReceipts.Rows[ii][3].ToString();
                            aReceiptPrice[i, ii] = dtReceipts.Rows[ii][4].ToString();
                            aReceiptDeliveredQuantity[i, ii] = dtReceipts.Rows[ii][5].ToString();
                            aReceiptNetAmount[i, ii] = dtReceipts.Rows[ii][6].ToString();
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.ToString());
                        }
                    }
                }


                if (dtItemText.Rows.Count > 0)
                {
                    for (int ii = 0; ii < dtItemText.Rows.Count; ii++)
                    {
                        try
                        {
                            aItemText[i, ii] = dtItemText.Rows[ii][1].ToString();

                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.ToString());
                        }
                    }
                }

                /*
             * 
             * Determine if it will fit on one page
             * 
             */

                //if (28 - (aMRPCurrentCount[i] + aMRPFutureCount[i] + aReceiptCount[i] + aItemTextCount[i]) <= 0)
                //{
                //    twoPagesRequired[i] = true;
                //}
                //else
                //{
                //    twoPagesRequired[i] = false;
                //}


                //File.AppendAllText(@"C:\A\mrpTest " + DateTime.Now.ToLongDateString() + ".txt", i.ToString() + "  " + aItemNo[i] + Environment.NewLine);

                i++;



            }
            catch (Exception ex)
            {
                //MessageBox.Show(ItemNo + " " + i.ToString() + "    " + ex.ToString());
            }
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
            int count = 0;
            int linesPerpage = 30;  //40
            //int lineNo = this.pagesPrinted * linesPerpage;
            int pageNo = pagesPrinted + 1;
            //double NumPages = Math.Ceiling(((i - 1) / 24.0));
            double NumPages = Convert.ToDouble(i);
            //string penflag = "BK";
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

            ev.Graphics.DrawLine(Gpen, 25, 5, 800, 5);
            ev.Graphics.DrawString("KANBAN CONTRACT REORDER NEEDED ", A9R, Brushes.Black, 250, 10);
            ev.Graphics.DrawLine(Gpen, 25, 25, 800, 25);

            ev.Graphics.DrawString("Data as of: " + date, A9R, Brushes.Black, 25, 30);
            ev.Graphics.DrawString(abuyerPlanner[lineNo], heading, Brushes.Black, 350, 30);
            ev.Graphics.DrawString("MRP Date: " + reportSunday, A9R, Brushes.Black, 600, 30);
            ev.Graphics.DrawString("Page  " + pageNo + " of " + NumPages, A9R, Brushes.Black, 600, 50);

            if (aVettedStatus[lineNo] == "1")
            {
                ev.Graphics.DrawString("*************** ......NON-VETTED...... ***************", B12, Brushes.Purple, 225, 50);
            }
            
            ev.Graphics.DrawLine(pen, 25, 70, 800, 70);

            //if (!partOnePrinted[lineNo])
            //{
                try
                {

                    /*  Vendor data     */


                    ev.Graphics.DrawString(aVendorNo[lineNo], heading, Brushes.Black, 25, 80);
                    ev.Graphics.DrawString(aVendorName[lineNo], heading, Brushes.Black, 75, 80);
                    ev.Graphics.DrawString(aVendorAddress[lineNo], A9R, Brushes.Black, 400, 80);
                    ev.Graphics.DrawString("Contact: " + aVendorContact[lineNo], A9R, Brushes.Black, 25, 100);
                    ev.Graphics.DrawString("Phone: " + aVendorPhone[lineNo], A9R, Brushes.Black, 25, 120);
                    ev.Graphics.DrawString("Email: " + aVendorEmail[lineNo], A9R, Brushes.Black, 25, 140);
                    ev.Graphics.DrawString("Fax: " + aVendorFax[lineNo], A9R, Brushes.Black, 300, 140);

                    ev.Graphics.DrawString("Vendor Title: " + aVendorTitle[lineNo], A9R, Brushes.Black, 300, 100);
                    ev.Graphics.DrawString("Supplier Line of Business: " + aVendorCommodityCode[lineNo], A9R, Brushes.Black, 300, 120);

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString() + "  Vendor Data");
                }

                ev.Graphics.DrawLine(pen, 25, 160, 800, 160);

                /*  Item Data   */

                try
                {
                    ev.Graphics.DrawString("Copy Exact?", heading, Brushes.Black, 25, 165);
                    ev.Graphics.DrawString(aCopyExact[lineNo], heading, Brushes.Red, 105, 165);

                    ev.Graphics.DrawString("Inspection?  " + aInspection[lineNo], heading, Brushes.Black, 350, 165);


                    if (aLocation[lineNo] == "Middlefield")
                    {
                        Bpen = new Pen(Color.Turquoise);
                    }
                    else if (aLocation[lineNo] == "Middlefield Service")
                    {
                        Bpen = new Pen(Color.Blue);
                    }
                    else if (aLocation[lineNo] == "Irvine")
                    {
                        Bpen = new Pen(Color.Orange);
                    }
                    else if (aLocation[lineNo] == "Irvine MRB")
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

                    if (aLocation[lineNo] == "Middlefield Service")
                    {
                        ev.Graphics.DrawLine(Bpen, 870, 165, 870, 220);
                        ev.Graphics.DrawLine(Bpen, 570, 170, 870, 170);
                        ev.Graphics.DrawLine(Bpen, 570, 215, 870, 215);
                        ev.Graphics.DrawLine(Bpen, 570, 165, 570, 220);
                    }
                    else
                    {
                        ev.Graphics.DrawLine(Bpen, 770, 165, 770, 220);
                        ev.Graphics.DrawLine(Bpen, 570, 170, 770, 170);
                        ev.Graphics.DrawLine(Bpen, 570, 215, 770, 215);
                        ev.Graphics.DrawLine(Bpen, 570, 165, 570, 220);
                    }

                    ev.Graphics.DrawString(aLocation[lineNo], title, Brushes.Black, 600, 180);

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
                        //MessageBox.Show(ex.ToString() + "  Revision Data");
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
                    ev.Graphics.DrawString("Lot Accumulation Period: ", heading, Brushes.Black, 25, 335);
                    ev.Graphics.DrawString(aLotAccumulationPeriod[lineNo], A9R, Brushes.Black, 185, 335);

                    ev.Graphics.DrawString("DFT_P6: ", heading, Brushes.Black, 25, 355);
                    var box = new Rectangle(75, 355, 50, 20);
                    ev.Graphics.DrawString(aP6[lineNo], A9R, Brushes.Black, box, alignR);

                    ev.Graphics.DrawString("DFT_F6: ", heading, Brushes.Black, 135, 355);
                    box = new Rectangle(185, 355, 50, 20);
                    ev.Graphics.DrawString(aF6[lineNo], A9R, Brushes.Black, box, alignR);

                    ev.Graphics.DrawString("DFT_EAU: ", heading, Brushes.Black, 245, 355);
                    box = new Rectangle(305, 355, 50, 20);
                    ev.Graphics.DrawString(aEAU[lineNo], A9R, Brushes.Black, box, alignR);

                    ev.Graphics.DrawString("Order Method: ", heading, Brushes.Black, 365, 355);
                    ev.Graphics.DrawString(aOrderMethod[lineNo], A9R, Brushes.Black, 455, 355);


                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString() + "  Item Data");
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

                    box = new Rectangle(400, 260, 100, 20);
                    ev.Graphics.DrawString("Non-Net Stk: ", A9R, Brushes.Black, box, alignR);
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
                    //MessageBox.Show(ex.ToString() + "  Stock Data");
                }

                ev.Graphics.DrawLine(pen, 25, 380, 800, 380);

                try
                {

                    /*  Manufacturer Data   */

                    ev.Graphics.DrawString("Manuf Name", U9, Brushes.Black, 25, 385);
                    ev.Graphics.DrawString("Manuf Part Number", U9, Brushes.Black, 275, 385);
                    ev.Graphics.DrawString("Qualification", U9, Brushes.Black, 425, 385);
                    ev.Graphics.DrawString("Preferred?", U9, Brushes.Black, 525, 385);
                    ev.Graphics.DrawString("Description", U9, Brushes.Black, 625, 385);

                    ev.Graphics.DrawString(aMfrName[lineNo], A9R, Brushes.Black, 25, 405);
                    ev.Graphics.DrawString(aMfrPartNumber[lineNo], A9R, Brushes.Black, 275, 405);
                    ev.Graphics.DrawString(aQualification[lineNo], A9R, Brushes.Black, 425, 399);
                    ev.Graphics.DrawString(aPreferred[lineNo], A9R, Brushes.Black, 540, 411);
                    ev.Graphics.DrawString(aMfrDescription[lineNo], A9R, Brushes.Black, 625, 405);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString() + "  Manufacturer Data");
                }

                ev.Graphics.DrawLine(pen, 25, 425, 800, 425);
                //ev.Graphics.DrawLine(pen, 25, 340, 380, 340);
                ev.Graphics.DrawLine(pen, 480, 425, 480, 590);

                try
                {

                    /*  Kanban Order   */

                    ev.Graphics.DrawString("KANBAN ORDER:", U9, Brushes.Black, 25, 430);
                    ev.Graphics.DrawString(KBpoOrder[lineNo] , A9R, Brushes.Black, 150, 430);
                    ev.Graphics.DrawString("Contract Start Date:", heading, Brushes.Black, 150, 450);
                    ev.Graphics.DrawString(KBpoStart[lineNo], A9R, Brushes.Black, 280, 450);
                    ev.Graphics.DrawString("Contract End Date:", heading, Brushes.Black, 150, 470);
                    ev.Graphics.DrawString(KBpoEnd[lineNo], A9R, Brushes.Black, 280, 470);
                    ev.Graphics.DrawString("Remaining Balance:", heading, Brushes.Black, 150, 490);
                    ev.Graphics.DrawString(KBpoOpen[lineNo].ToString(), A9R, Brushes.Black, 280, 490);


                    linedrop = 490;
                    count = 28;

                }
                catch (Exception ex)
                {
            //        //MessageBox.Show(ex.ToString() + "  MRP Current Data");
                }
            //}

            /*  page one printed - page two not printed - two pages not required    */

            //if (partOnePrinted[lineNo] && (!partTwoPrinted[lineNo]) & !twoPagesRequired[lineNo])
            //{
                //linedrop = linedrop + 20;

                //ev.Graphics.DrawString("Future Order (outside 2 weeks)", A9R, Brushes.Black, 25, linedrop);

                linedrop = linedrop + 20;
                count++;


                /*
                 * 
                 * PO Lines
                 * 
                 * */

                ev.Graphics.DrawString("OPEN PURCHASE ORDERS", U9, Brushes.Black, 500, 430);
                ev.Graphics.DrawString("P.O", U9, Brushes.Black, 500, 450);
                ev.Graphics.DrawString("Line", U9, Brushes.Black, 580, 450);
                ev.Graphics.DrawString("Qty", U9, Brushes.Black, 630, 450);
                ev.Graphics.DrawString("Requested", U9, Brushes.Black, 680, 450);
                ev.Graphics.DrawString("Promised", U9, Brushes.Black, 750, 450);

                try
                {
                    for (int ii = 0; ii < 5; ii++)
                    {
                        ev.Graphics.DrawString(aPO[lineNo, ii], A9R, Brushes.Black, 500, 470 + (ii * 20));
                        ev.Graphics.DrawString(aPOLine[lineNo, ii], A9R, Brushes.Black, 580, 470 + (ii * 20));
                        ev.Graphics.DrawString(aPOLineQty[lineNo, ii], A9R, Brushes.Black, 630, 470 + (ii * 20));
                        ev.Graphics.DrawString(aPOLineRequestedDate[lineNo, ii], A9R, Brushes.Black, 680, 470 + (ii * 20));
                        ev.Graphics.DrawString(aPOLinePromisedDate[lineNo, ii], A9R, Brushes.Black, 750, 470 + (ii * 20));
                    }
                    //}
                }
                catch (Exception ex)
                {
                    //File.AppendAllText(@"C:\A\MRPerrors.txt", ItemNo[lineNo].ToString() + "  " + ex.ToString());
                    //MessageBox.Show(ex.ToString());
                }




                linedrop = linedrop + 20;
                count++;

                ev.Graphics.DrawLine(pen, 25, linedrop, 800, linedrop);

                linedrop = linedrop + 20;
                count++;

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
                count++;

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
                            count = count + ii;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString() + "  Receipt Data");
                }

                linedrop = linedrop + 20;
                count++;

                ev.Graphics.DrawLine(pen, 25, linedrop, 800, linedrop);

                linedrop = linedrop + 20;
                count++;

                try
                {
                    if (Convert.ToInt32(aItemTextCount[lineNo]) > 0)
                    {
                        for (int ii = 0; ii < Convert.ToInt32(aItemTextCount[lineNo]); ii++)
                        {
                            ev.Graphics.DrawString(aItemText[lineNo, ii], A9R, Brushes.Black, 50, linedrop + (ii * 20));

                            count = count + ii;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString() + "  Item Text");
                }

                ev.Graphics.DrawString("Date PO Placed:  _______________     PO Number _______________", A9R, Brushes.Black, 50, 1000);

                count = 30;
  
                

            //if (twoPagesRequired[lineNo])
            //{
            //    if (partOnePrinted[lineNo] && !partTwoPrinted[lineNo])
            //    {
            //        ev.HasMorePages = true;
            //        pageOnePrinted[lineNo] = true;
            //        pagesPrinted++;
            //    }

            //    if (partOnePrinted[lineNo] && partTwoPrinted[lineNo])
            //    {
                    lineNo++;

            //        if (i > lineNo)
            //        {
            //            ev.HasMorePages = true;
            //            pageOnePrinted[lineNo] = true;
            //            pagesPrinted++;
            //        }
            //    }
            //}
            //else
            //{
                if (i > lineNo)
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
                }

               
            //}

        }

    }
}
