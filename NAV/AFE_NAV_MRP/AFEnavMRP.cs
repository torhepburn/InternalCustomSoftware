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
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;


namespace AFE_NAV_MRP
{
    public partial class AFEnavMRP : Form
    {
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
        private string[] aP6 = new string[20000];
        private string[] aF6 = new string[20000];
        private string[] aEAU = new string[20000];
        private string[] aOrderMethod = new string[20000];
        private string[] aQtyMultiplier = new string[20000];
        private string[] aMinQty = new string[20000];
        private string[] aStdCost = new string[20000];
        private string[] aPurchPrice = new string[20000];
        private string[] aLastPurchPrice = new string[20000];
        private string[] aAllocations = new string[20000];
        private string[] aMfrName = new string[20000];
        private string[] aMfrPartNumber = new string[20000];
        private string[] aQualification = new string[20000];
        private string[] aPreferred = new string[20000];
        private string[] aMfrDescription = new string[20000];
        private string[,] acOrderDate = new string[10000, 50];
        private string[,] acDeliveryDate = new string[10000, 50];
        private string[,] acOrderQuantity = new string[10000, 50];
        private string[,] acAmountStandard = new string[10000, 50];
        private string[,] acLocation = new string[10000, 50];
        private string[,] acBinCode = new string[20000, 50];
        private string[,] afOrderDate = new string[20000, 50];
        private string[,] afDeliveryDate = new string[20000, 50];
        private string[,] afOrderQuantity = new string[20000, 50];
        private string[,] afAmountStandard = new string[20000, 50];
        private string[,] afLocation = new string[20000, 50];
        private string[,] afBinCode = new string[20000, 50];
        private string[,] aRecriptDate = new string[20000, 5];
        private string[,] aReceiptOrder = new string[20000, 5];
        private string[,] aReceiptPosition = new string[20000, 5];
        private string[,] aReceiptVendor = new string[20000, 5];
        private string[,] aReceiptPrice = new string[20000, 5];
        private string[,] aReceiptDeliveredQuantity = new string[20000, 5];
        private string[,] aReceiptNetAmount = new string[20000, 5];
        private int[] aMRPCurrentCount = new int[20000];
        private int[] aMRPFutureCount = new int[20000];
        private int[] aReceiptCount = new int[20000];
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

        //private string NAVprefix = "ZYGO_MRP1$";
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

        DataTable dtVendor;
        DataTable dtMRPOrdersCurrent;
        DataTable dtMRPOrdersFuture;
        DataTable dtReceipts;
        DataTable dtItem;
        DataTable dtPINS;
        DataTable dtDocCtrl;
        SqlDataAdapter da;

        public AFEnavMRP()
        {
            InitializeComponent();
        }

        private void AFEnavMRP_Load(object sender, EventArgs e)
        {
            /*
             *Connection used to get the Dashboard data
             */

            SqlConnection cnxnDash = new SqlConnection("server=MIDDB01; password=views; " +
                          "user=views; database=Dashboard;");

            /*
             *Connection used to get the old MK data
             */

            SqlConnection cnxnAFE = new SqlConnection("server=CT-MID-SQL01; password=views; " +
                          "user=views; database=AccessFrontEnds;");

            SqlCommand cmd = new SqlCommand(
                
                        "SELECT " +
                        "[DATADATE] " +
                        ",[BUYER PLANNER CODE] " +
                        ",[NO_] " +
                        ",[DESCRIPTION] " +
                        ",[VENDOR NO] " +
                        ",[NAME] " +
                        ",[CITY] " +
                        ",[COUNTY] " +
                        ",[COUNTRY] " +
                        ",[CONTACT] " +
                        ",[PHONE NO_] " +
                        ",[E-MAIL] " +
                        ",[FAX NO_] " +
                        ",[VENDOR STATUS] " +
                        ",[LINE OF BUSINESS] " +
                        ",[COPY EXACT] " +
                        ",[INSPECTION CODE] " +
                        ",[COMMODITY CODE] " +
                        ",[PRODUCT TYPE] " +
                        ",[SELECTION CODE] " +
                        ",[ITEM GROUP] " +
                        ",[SIGNAL CODE] " +
                        ",[LEAD TIME CALCULATION] " +
                        ",[LOT ACCUMULATION PERIOD] " +
                        ",[REVISION LEVEL] " +
                        ",[VENDOR ITEM NO_] " +
                        ",[SAFETY STOCK QUANTITY] " +
                        ",[ORDER METHOD] " +
                        ",[ORDER MULTIPLE] " +
                        ",[MIN ORDER QTY] " +
                        ",[STANDARD COST] " +
                        ",[PURCH PRICE] " +
                        ",[LAST PURCH PRICE] " +
                        ",[LOC] " +
                        
                        ",[NET] " +
                        ",[NNET] " +
                        ",[SOO] " +
                        ",[BLK] " +
                        ",[P6NAV] " +
                        ",[ALLOC] " +
                        " FROM NAV_MRP1", cnxnAFE);

            da = new SqlDataAdapter();
            dtItem = new DataTable();
            da.SelectCommand = cmd;

            try
            {
                da.Fill(dtItem);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
