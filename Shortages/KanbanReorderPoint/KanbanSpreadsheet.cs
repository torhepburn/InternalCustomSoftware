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
    public partial class KanbanSpreadsheet : Form
    {
        private int KBcalculated;
        private int POquantity;
        //private string KBreorder;
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
        private string KBopen = string.Empty;

        SqlConnection cnxn1;
        SqlConnection cnxn2;
        SqlConnection cnxn;
        SqlConnection cnxnDash;
        SqlConnection cnxnAFE;
        SqlDataReader dr;
        SqlDataReader drItem;

        DataTable dtVendor;
        DataTable dtMRPOrdersCurrent;
        DataTable dtMRPOrdersFuture;
        DataTable dtReceipts;
        DataTable dtItem;
        DataTable dtPINS;
        DataTable dtDocCtrl;
        DataTable dtItemText;
        DataTable dtPOLines;



        public KanbanSpreadsheet()
        {
            InitializeComponent();
        }

        private void KanbanSpreadsheet_Load(object sender, EventArgs e)
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

            File.WriteAllText(@"C:\A\KBSpread.csv", 
            "Date " +
            ",Buyer " +
            ",Item No " +
            ",Vendor No "+
            ",Vendor Name" +
            ",City " +
            ",County " +
            ",Country_Region Code " +
            ",Contact " +
            ",Phone No_ " +
            ",E-Mail " +
            ",Fax No_ " +
            ",Vendor Title " +
            ",Line of Business of a Supplier " +
            ",Item Description " +
            ",Copy Exact " +
            ",Commodity Description  " +
            ",Product Types " +
            ",Selection Code  " +
            ",Item Group Code " +
            ",Signal Code " +
            ",Lead Time Calculation (days) " +
            ",Lot Accumulation Period (days) " +
            ",Revision Level " +
            ",Vendor Item No " +
            ",Safety Stock Quantity" + 
            ",Order Method " +
            ",Order Multiple " +             /* problems with arithmatic overflow when using coalesce  */
            ",Minimum Order Quantity " +
            ",Standard Cost " +
            ",Proposed Purchase Cost " +  /*16*/
            ",Last Direct Cost " +
            ",Stock Location " +
            ",Inspection Code" +
            ",Reorder Point" +
            ",Reorder Quantity " +
            ",Vetted " +  /*  23    */
            ", SIM " +
            ", Nettable " +
            ", Non-Nettable " +
            ", On Order " +
            ", Blocked Stock " +
            ",Allocations " +
            ",DFT_P6 " +
            ",DFT_F6 " +
            ",DFT_EAU " +
            ", Annul Spend " +
            ",LatestRev " +
            ",DateCreated " +
            ",Source " +
            ",ECOStatus " +
            ",ResponsibleUser " +
            ",Mfr 1" +
            ",Mfr 1 PN " +
            ",Mfr 1 PN Description " +
            ",Mrf 1 Qualification " +
            ",Mfr 1 Preferred " +
            ",Mfr 2" +
            ",Mfr 2 PN " +
            ",Mfr 2 PN Description " +
            ",Mrf 2 Qualification " +
            ",Mfr 2 Preferred " +
            ",Mfr 3" +
            ",Mfr 3 PN " +
            ",Mfr 3 PN Description " +
            ",Mrf 3 Qualification " +
            ",Mfr 3 Preferred " +
            ",Mfr 4" +
            ",Mfr 4 PN " +
            ",Mfr 4 PN Description " +
            ",Mrf 4 Qualification " +
            ",Mfr 4 Preferred " +
            ",Mfr 5" +
            ",Mfr 5 PN " +
            ",Mfr 5 PN Description " +
            ",Mrf 5 Qualification " +
            ",Mfr 5 Preferred " +
            ",Mfr 6" +
            ",Mfr 6 PN " +
            ",Mfr 6 PN Description " +
            ",Mrf 6 Qualification " +
            ",Mfr 6 Preferred " +
            ",Mfr 7" +
            ",Mfr 7 PN " +
            ",Mfr 7 PN Description " +
            ",Mrf 7 Qualification " +
            ",Mfr 7 Preferred " +
            ",Kanban Order " +
            ",Contract Start Date " +
            ",Contract End Date " +
            ",Remaining Balance " +
            ",PO 1 PO " +
            ",PO 1 PO Line " +
            ",PO 1 PO Qty " +
            ",PO 1 Requested " +
            ",PO 1 Promised " +
            ",PO 2 PO " +
            ",PO 2 PO Line " +
            ",PO 2 PO Qty " +
            ",PO 2 Requested " +
            ",PO 2 Promised " +
            ",PO 3 PO " +       
            ",PO 3 PO Line " +
            ",PO 3 PO Qty " +
            ",PO 3 Requested " +
            ",PO 3 Promised " +
            ",PO 4 PO " +
            ",PO 4 PO Line " +
            ",PO 4 PO Qty " +
            ",PO 4 Requested " +
            ",PO 4 Promised " +
            ",PO 5 PO " +
            ",PO 5 PO Line " +
            ",PO 5 PO Qty " +
            ",PO 5 Requested " +
            ",PO 5 Promised " +
            ",Receipt 1 Date " +
            ",Receipt 1 PO " +
            ",Receipt 1 PO Line " +
            ",Receipt 1 Vendor " +
            ",Receipt 1 Price " +
            ",Receipt 1 Qty " +
            ",Receipt 1 Total " +
            ",Receipt 2 Date " +
            ",Receipt 2 PO " +
            ",Receipt 2 PO Line " +
            ",Receipt 2 Vendor " +
            ",Receipt 2 Price " +
            ",Receipt 2 Qty " +
            ",Receipt 2 Total " +
            ",Receipt 3 Date " +
            ",Receipt 3 PO " +
            ",Receipt 3 PO Line " +
            ",Receipt 3 Vendor " +
            ",Receipt 3 Price " +
            ",Receipt 3 Qty " +
            ",Receipt 3 Total " +
            ",Receipt 4 Date " +
            ",Receipt 4 PO " +
            ",Receipt 4 PO Line " +
            ",Receipt 4 Vendor " +
            ",Receipt 4 Price " +
            ",Receipt 4 Qty " +
            ",Receipt 4 Total " +
            ",Receipt 5 Date " +
            ",Receipt 5 PO " +
            ",Receipt 5 PO Line " +
            ",Receipt 5 Vendor " +
            ",Receipt 5 Price " +
            ",Receipt 5 Qty " +
            ",Receipt 5 Total " +
            ",Item Text " +

                Environment.NewLine);

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
                            if (!dr2.IsDBNull(1)) { KBstart = dr2.GetString(1); } else { KBstart = "01-01-2010"; }
                            if (!dr2.IsDBNull(2)) { KBend = dr2.GetString(2); } else { KBend = "01-01-2010"; }
                            if (!dr2.IsDBNull(3)) { KBorder = dr2.GetString(3); } else { KBorder = "No KB-Order"; }

                            KBcalculated = KBpoOpen[i];
                            KBopen = KBpoOpen[i].ToString();
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

  
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn1.Close();
            }

            this.Close();
        }

        private void itemData()
        {
            buyerPlanner = dr.GetString(3);

            File.AppendAllText(@"C:\A\KBSpread.csv", DateTime.Now.ToShortDateString());
            File.AppendAllText(@"C:\A\KBSpread.csv", "," + buyerPlanner);
            File.AppendAllText(@"C:\A\KBSpread.csv", "," + ItemNo);
            
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
            ", REPLACE(Name, ',', ' ') " +
            ", REPLACE(City, ',', ' ') " +
            ", REPLACE(County, ',', ' ') " +
            ",[Country_Region Code] " +
            ", Contact " +
            ",[Phone No_] " +
            ",[E-Mail] " +
            ",[Fax No_] " +
            ",[Vendor Title] + '  ' + t.Description " +
            ",[Line of Business of a Supplier] + '  ' + REPLACE(b.Description, ',', ' ') " +
            "FROM [" + NAVprefix + "Vendor] v " +
            "LEFT JOIN [" + NAVprefix + "Vendor Title] t  ON v.[Vendor Title] = t.Code " +
            "LEFT JOIN [" + NAVprefix + "Line of Business] b  ON v.[Line of Business of a Supplier] = b.Code " +
            "WHERE No_ = '" + VendorNo + "'", cnxn);

            dtVendor = new DataTable();

            try
            {
                cnxn.Open();
                drItem = loopCmd.ExecuteReader();

                while (drItem.Read())
                {
                    File.AppendAllText(@"C:\A\KBSpread.csv", "," +
                    drItem[0].ToString() + "," +
                    drItem[1].ToString() + "," +
                    drItem[2].ToString() + "," +
                    drItem[3].ToString() + "," +
                    drItem[4].ToString() + "," +
                    drItem[5].ToString() + "," +
                    drItem[6].ToString() + "," +
                    drItem[7].ToString() + "," +
                    drItem[8].ToString() + "," +
                    drItem[9].ToString() + "," +
                    drItem[10].ToString());
                }

                dtVendor.Load(drItem);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            

            /*
            *  Item Data 
            */

            loopCmd = new SqlCommand(

                "SELECT " +
                "REPLACE(i.Description,',',' ') " +
                ",CASE [Copy Exact] " +
                "    WHEN 0 THEN 'No' " +
                "    WHEN 1 THEN 'Yes' " +
                "END " +
                ", Commodity + '  ' + REPLACe(c.Description,',',' ')  " +
                ",CASE " +
                "   WHEN LEN([Product Types]) > 0 THEN [Product Types]  + '  ' + REPLACE(p.Description,',',' ')  " +
                "   WHEN LEN([Product Types]) = 0 THEN '** None **' " +
                " END " +
                ",CASE " +
                "   WHEN LEN([Selection Code]) > 0 THEN [Selection Code]  + '  ' + REPLACe(s.Description,',',' ')   " +
                "   WHEN LEN([Selection Code]) = 0 THEN '** None **' " +        /*4*/
                "END " +
                ",CASE " +
                "   WHEN LEN([Item Group Code]) > 0 THEN [Item Group Code]  + '  ' + REPLACE(ig.Description,',',' ')  " +
                "   WHEN LEN([Item Group Code]) = 0 THEN '** None **' " +
                "END " +
                ",CASE " +
                "   WHEN LEN([Signal Code]) > 0 THEN [Signal Code]  + '  ' + REPLACE(g.Description,',',' ') " +
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
                ",REPLACE(FORMAT([Standard Cost], 'N', 'en-us'), ',', '') [Standard Cost] " +
                ",REPLACE(FORMAT([Proposed Purchase Cost],'N', 'en-us'), ',', '')" +  /*16*/
                ",REPLACE(FORMAT([Last Direct Cost],'N', 'en-us'), ',', '') " +
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

            dtItem = new DataTable();

            try
            {
                cnxn.Open();
                drItem = loopCmd.ExecuteReader();
                dtItem.Load(drItem);
                drItem = loopCmd.ExecuteReader();

                while (drItem.Read())
                {
                    File.AppendAllText(@"C:\A\KBSpread.csv", "," +
                    drItem[0].ToString() + "," +
                    drItem[1].ToString() + "," +
                    drItem[2].ToString() + "," +
                    drItem[3].ToString() + "," +
                    drItem[4].ToString() + "," +
                    drItem[5].ToString() + "," +
                    drItem[6].ToString() + "," +
                    drItem[7].ToString() + "," +
                    drItem[8].ToString() + "," +
                    drItem[9].ToString() + "," +
                    drItem[10].ToString() + "," +
                    drItem[11].ToString() + "," +
                    drItem[12].ToString() + "," +
                    drItem[13].ToString() + "," +
                    drItem[14].ToString() + "," +
                    drItem[15].ToString() + "," +
                    drItem[16].ToString() + "," +
                    drItem[17].ToString() + "," +
                    drItem[18].ToString() + "," +
                    drItem[19].ToString() + "," +
                    drItem[20].ToString() + "," +
                    drItem[21].ToString() + "," +
                    drItem[22].ToString() + "," +
                    drItem[23].ToString());
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

            File.AppendAllText(@"C:\A\KBSpread.csv", "," + nettableStock);


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
                nonnetStock = "0";
            }
            else
            {
                nonnetStock = nn.ToString();
            }

            File.AppendAllText(@"C:\A\KBSpread.csv", "," + nonnetStock);

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
                onOrder = "0";
            }
            else
            {
                onOrder = p.ToString();
            }

            File.AppendAllText(@"C:\A\KBSpread.csv", "," + onOrder);

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
                blockedStock = "0";
            }
            else
            {
                blockedStock = b.ToString();
            }

            File.AppendAllText(@"C:\A\KBSpread.csv", "," + blockedStock);

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

            File.AppendAllText(@"C:\A\KBSpread.csv", "," + Allocations);

            loopCmd = new SqlCommand(

             "SELECT " +
             "DFT_P6 " +
             ",DFT_F6 " +
             ",DFT_EAU " +
             "FROM NAV_EAU " +
             "WHERE PartNumber = '" + ItemNo + "'", cnxnDash);

            DataTable dtDash = new DataTable();
            
            try
            {
                cnxnDash.Open();
                drItem = loopCmd.ExecuteReader();
                dtDash.Load(drItem);
                drItem = loopCmd.ExecuteReader();

                while (drItem.Read())
                {
                    File.AppendAllText(@"C:\A\KBSpread.csv", "," +
                    drItem[0].ToString() + "," +
                    drItem[1].ToString() + "," +
                    drItem[2].ToString());
                }


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxnDash.Close();
            }

            P6 = dtDash.Rows[0][0].ToString();
            F6 = dtDash.Rows[0][1].ToString();
            EAU = dtDash.Rows[0][2].ToString();

            // Annual Spend = F6 * Standard Cost * 2
            
            if (F6 != "0")
            {
                int F6x = Convert.ToInt32(F6);
                Double Step1 = (Convert.ToDouble(dtItem.Rows[0][15].ToString()) * F6x * 2);

                spend = string.Format("{0:$0.00}", Step1);
            }
            else
            {
                spend = "$0.00";
            }

            File.AppendAllText(@"C:\A\KBSpread.csv", "," + spend);

            /*
            *  Doc Control
            */

            loopCmd = new SqlCommand(

              "SELECT " +
              "LatestRev " +
              ",CONVERT(varchar(10),[DateCreated], 101) " +
              ",Source " +
              ",ECOStatus " +
              ",REPLACE(ResponsibleUser,',',' ') " +
              "FROM All_PartNumbers " +
              "WHERE PartNumber = '" + ItemNo + "'", cnxnDash);

            dtDocCtrl = new DataTable();

            try
            {
                cnxnDash.Open();
                drItem = loopCmd.ExecuteReader();
                dtDocCtrl.Load(drItem);
                drItem = loopCmd.ExecuteReader();

                while (drItem.Read())
                {
                    File.AppendAllText(@"C:\A\KBSpread.csv", "," +
                    drItem[0].ToString() + "," +
                    drItem[1].ToString() + "," +
                    drItem[2].ToString() + "," +
                    drItem[3].ToString() + "," +
                    drItem[4].ToString());
                }

                if (dtDocCtrl.Rows.Count < 1)
                {
                    File.AppendAllText(@"C:\A\KBSpread.csv", ",,,,,");
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxnDash.Close();
            }

            /*
             *  PINS
             */

            loopCmd = new SqlCommand(

              "SELECT " +
              "REPLACE(ManufName,',',' ') " +
              ",REPLACE(ManufPartNumber,',',' ') " +
              ",REPLACE(ManufPartDescription,',',' ') " +
              ",REPLACE(Qualification,',',' ') " +
              ",CASE Preferred " +
              "     WHEN 0 THEN 'No' " +
              "     WHEN 1 THEN 'Yes' " +
              "END " +
              "FROM VIEW_PINS " +
              "WHERE PinsNumber = '" + ItemNo + "'", cnxnDash);

            dtPINS = new DataTable();

            try
            {
                cnxnDash.Open();
                drItem = loopCmd.ExecuteReader();
                dtPINS.Load(drItem);
                drItem = loopCmd.ExecuteReader();

                while (drItem.Read())
                {
                    File.AppendAllText(@"C:\A\KBSpread.csv", "," +
                    drItem[0].ToString() + "," +
                    drItem[1].ToString() + "," +
                    drItem[2].ToString() + "," +
                    drItem[3].ToString() + "," +
                    drItem[4].ToString());
                }

                for (int ii = dtPINS.Rows.Count; ii < 7; ii++)
                {
                    try
                    {
                        File.AppendAllText(@"C:\A\KBSpread.csv", ",,,,,");
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxnDash.Close();
            }

            /*
             * 
             * Kanban contract data
             * 
             * */

            File.AppendAllText(@"C:\A\KBSpread.csv", "," +
                    KBorder + "," +
                    KBstart + "," +
                    KBend + "," +
                    KBopen);

            KBorder = "printed";
            KBstart = "printed";
            KBend = "printed";
            KBopen = "printed";

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

            dtPOLines = new DataTable();

            try
            {
                cnxn.Open();
                drItem = loopCmd.ExecuteReader();
                dtPOLines.Load(drItem);
                drItem = loopCmd.ExecuteReader();

                while (drItem.Read())
                {
                    File.AppendAllText(@"C:\A\KBSpread.csv", "," +
                    drItem[0].ToString() + "," +
                    drItem[1].ToString() + "," +
                    drItem[2].ToString() + "," +
                    drItem[3].ToString() + "," +
                    drItem[4].ToString());
                }

                for (int ii = dtPOLines.Rows.Count; ii < 5; ii++)
                {
                    try
                    {
                        File.AppendAllText(@"C:\A\KBSpread.csv", ",,,,,");
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString());
                    }
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

            //File.AppendAllText(@"C:\A\KBSpread.csv", " Receipts");

            /*
             *  Last 5 receipts
             */

            loopCmd = new SqlCommand(

              "SELECT TOP 5 " +
              "CONVERT(varchar(10),[Posting Date], 101) a " +
              ",[Order No_] PO " +
              ",[PO Line No_] POLine " +
              ", REPLACE(v.[Name], ',','') Vendor" +
              ",REPLACE(FORMAT([Unit Cost], 'C', 'en-us'),',','') e " +
              ",REPLACE(FORMAT(Quantity,'N', 'en-us'),',','') f " +
              ",REPLACE(FORMAT([Item Charge Base Amount], 'C', 'en-us'),',','') g " +
              "FROM [" + NAVprefix + "Purch_ Rcpt_ Line] r " +
              "LEFT JOIN [" + NAVprefix + "Vendor] v on r.[Buy-from Vendor No_] = v.[No_] " +
              "WHERE [Item Rcpt_ Entry No_] > 0 AND r.No_ = '" + ItemNo + "' " +
              "ORDER BY [Posting Date] DESC", cnxn);

            DataTable dtReceipts = new DataTable();

            try
            {
                cnxn.Open();
                drItem = loopCmd.ExecuteReader();
                dtReceipts.Load(drItem);
                drItem = loopCmd.ExecuteReader();

                while (drItem.Read())
                {
                    File.AppendAllText(@"C:\A\KBSpread.csv", "," +
                    drItem[0].ToString() + "," +
                    drItem[1].ToString() + "," +
                    drItem[2].ToString() + "," +
                    drItem[3].ToString() + "," +
                    drItem[4].ToString() + "," +
                    drItem[5].ToString() + "," +
                    drItem[6].ToString());
                }

                for (int ii = dtReceipts.Rows.Count; ii < 5; ii++)
                {
                    try
                    {
                        File.AppendAllText(@"C:\A\KBSpread.csv", ",,,,,,,");
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString());
                    }
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
               "Text " +
               "FROM [" + NAVprefix + "Text Module Line] " +
               "WHERE [Code 1] = '" + ItemNo + "' "
               , cnxn);

            dtItemText = new DataTable();

            try
            {
                cnxn.Open();
                drItem = loopCmd.ExecuteReader();
                dtItemText.Load(drItem);
                drItem = loopCmd.ExecuteReader();

                while (drItem.Read())
                {
                    if (!drItem[0].ToString().Contains("mbed"))
                    {
                        File.AppendAllText(@"C:\A\KBSpread.csv", "," +
                        drItem[0].ToString());
                    }
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
            aItemTextCount[i] = dtItemText.Rows.Count;

            DataTable dt10 = new DataTable();

            if (dtItemText.Rows.Count > 0)
            {
                if (dtItemText.Rows[0][0].ToString().Contains("mbed"))
                {
                    /* replace commas and line feeds in text  */

                    loopCmd = new SqlCommand
                       ("SELECT " +
                       "REPLACE(REPLACE(Text, CHAR(10),' '),',',' ') " +
                       "FROM NAV_EmbeddedText " +
                       "WHERE [NAV_Key_1] = '" + ItemNo + "' " +
                       "AND NAV_Table = 27 "
                       , cnxnAFE);

                    try
                    {
                        cnxnAFE.Open();
                        drItem = loopCmd.ExecuteReader();
                        dt10.Load(drItem);
                        drItem = loopCmd.ExecuteReader();

                        while (drItem.Read())
                        {
                            
                            File.AppendAllText(@"C:\A\KBSpread.csv", "," +
                                drItem[0].ToString());
                            
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxnAFE.Close();
                    }

                }

            }

            File.AppendAllText(@"C:\A\KBSpread.csv", Environment.NewLine);

        }
    }
}
