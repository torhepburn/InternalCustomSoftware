using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Printing;


namespace KanbanReorderPoint
{
    public partial class KanbanSummarySpreadsheet : Form
    {
        private int KBcalculated;
        private int POquantity;
        private int leadTime;
        private bool ordered = false;
        private DateTime runOutDate;
        private DateTime ReOrderDate;

        private int[] KBpoOpen = new int[20000];

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
        private string standardCost = string.Empty;
        private string spend = string.Empty;
        private string Allocations = string.Empty;
        private string AllocationsF6 = string.Empty;
        private string Inspection = string.Empty;
        private string KBstart = string.Empty;
        private string KBend = string.Empty;
        private string KBorder = string.Empty;
        private string KBopen = string.Empty;
        private string KBfile = string.Empty;

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

        public KanbanSummarySpreadsheet()
        {
            InitializeComponent();
        }

        private void KanbanSummarySpreadsheet_Load(object sender, EventArgs e)
        {
            KBfile = @"\\MIDFILE01\Departments\Procurement\Kanban Review\Kanban Summary Spreadsheet " + DateTime.Now.ToString("MM-dd-yy") + ".csv";

            //KBfile = @"C:\A\Kanban Summary Spreadsheet " + DateTime.Now.ToString("MM-dd-yy") + ".csv";
            /*
             *  Connection used to get the items in the loop for processing
             */

            string dbNAV = "server=pa-hor-as408.ametek.com; password=2018#ameteK; " +
                                        "user=navdb_read; database=ZYGO-NAV-PROD;";

            cnxn1 = new SqlConnection(dbNAV);

            cnxn2 = new SqlConnection(dbNAV);

            /*
             *  Conection used by loop within the reader
             */

            cnxn = new SqlConnection(dbNAV);

            /*
             *Connection used to get the Dashboard data
             */

            cnxnDash = new SqlConnection("server=MIDDB01.zygo.com; password=views; " +
              "user=views; database=Dashboard;");

            
            File.WriteAllText(KBfile,
            "Date " +
            ",Buyer " +
            ",Item No " +
            ",Description " +
            ",Copy Exact " +
            ",Rev " +
            ",Vendor No " +
            ",Vendor Name" +
            ",Lead Time " +
            ",Standard Cost " +
            ",Proposed Cost " +
            ",Reorder Qty " +
            ",Net " +
            ",Non-Net " +
            ",Blkd Stk " +
            ",Alloc " +
            ",P6 " +
            ",F6 " +
            ",EAU " +
            ",EAU Spend" +
            ",Annual Spend " +
            ",KB Order " +
            ",Contract Start " +
            ",Contract End " +
            ",KB Bal " +
            ",On Ord " +
            ",Re-Order Date " +

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
                /* next line for test purposes - remember to comment out */
                //"AND i.No_ = '1115-802-935'  " +
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
                        ",MIN(h.No_) " +
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
                        ", DATEADD(dd, -" + leadTime + ",[Due Date]) [MRP Order Date] " +
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
                                runOutDate = dr.GetDateTime(1);
                                ReOrderDate = dr.GetDateTime(1).AddDays(-14);

                                if (ordered)
                                {
                                    /*  skip if already printed   */
                                }
                                else
                                {
                                    /*  Here is where the item needs to have a new order put in  
                                     *  
                                     *  Need to figure out which orders run out in the next 12 weeks
                                     *  
                                     *  What shows up on report.  84 days = 12 weeks. 
                                     *                                       
                                     */

                                    if (runOutDate < DateTime.Now.AddDays(84))
                                    {
                                        itemData();

                                        ordered = true;
                                    }
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

            File.AppendAllText(KBfile, DateTime.Now.ToShortDateString());
            File.AppendAllText(KBfile, "," + buyerPlanner);
            File.AppendAllText(KBfile, "," + ItemNo);

            /*
            *  Item Data 
            */

            SqlCommand loopCmd = new SqlCommand(

                "SELECT " +
                "REPLACE(i.Description,',',' ') " +
                ",CASE [Copy Exact] " +
                "    WHEN 0 THEN 'No' " +
                "    WHEN 1 THEN 'Yes' " +
                "END " +
                ",i.[Revision Level] " +
                "FROM [" + NAVprefix + "Item] i " +
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
                    File.AppendAllText(KBfile, "," +
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
                cnxn.Close();
            }


            /*
             *  Vendor data
             */

            loopCmd = new SqlCommand
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
            "FROM [" + NAVprefix + "Vendor] v " +
            "WHERE No_ = '" + VendorNo + "'", cnxn);

            try
            {
                cnxn.Open();
                drItem = loopCmd.ExecuteReader();

                while (drItem.Read())
                {
                    File.AppendAllText(KBfile, "," +
                    drItem[0].ToString() + "," +
                    drItem[1].ToString());
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
            *  Item Data 
            */

            loopCmd = new SqlCommand(

                "SELECT " +
                "CASE  WHEN LEN(i.[Lead Time Calculation]) = 0 THEN '0' " +
                "      WHEN CHARINDEX(CHAR(3),i.[Lead Time Calculation]) > 0 " +
                "           THEN REPLACE(i.[Lead Time Calculation], CHAR(3), '') " +
                "    WHEN CHARINDEX(CHAR(4),i.[Lead Time Calculation]) > 0 THEN " + // --week 
                "       REPLACE(i.[Lead Time Calculation], CHAR(4), '') * 5	" +       //--convert to days 
                "    WHEN CHARINDEX(CHAR(5),i.[Lead Time Calculation]) > 0 THEN " + // --month 
                "       REPLACE(i.[Lead Time Calculation], CHAR(5), '') * 20	" +       //--convert to days 
                "   WHEN CHARINDEX(CHAR(2),i.[Lead Time Calculation]) > 0 THEN " +      //-- days 
                "       REPLACE(i.[Lead Time Calculation], CHAR(2), '')		" +
                "END [Lead Time Calculation] " + /*7*/
                ",REPLACE(FORMAT([Standard Cost], 'N', 'en-us'), ',', '') [Standard Cost] " +
                ",REPLACE(FORMAT([Proposed Purchase Cost],'N', 'en-us'), ',', '')" +  /*16*/
                ",FORMAT([Reorder Quantity],'N', 'en-us') " +
                "FROM [" + NAVprefix + "Item] i " +
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
                    File.AppendAllText(KBfile, "," +
                    drItem[0].ToString() + "," +
                    drItem[1].ToString() + "," +
                    drItem[2].ToString() + "," +
                    drItem[3].ToString());

                    standardCost = drItem[1].ToString();
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

            File.AppendAllText(KBfile, "," + nettableStock);


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

            File.AppendAllText(KBfile, "," + nonnetStock);

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

            File.AppendAllText(KBfile, "," + blockedStock);

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

            File.AppendAllText(KBfile, "," + Allocations);

            loopCmd = new SqlCommand(

             "SELECT " +
             "P6 " +
             ",F6 " +
             ",EAU " +
             "FROM ZYGO$Item " +
             "WHERE No_ = '" + ItemNo + "'", cnxn);

            DataTable dtDash = new DataTable();

            try
            {
                cnxn.Open();
                drItem = loopCmd.ExecuteReader();
                dtDash.Load(drItem);
                drItem = loopCmd.ExecuteReader();

                while (drItem.Read())
                {
                    File.AppendAllText(KBfile, "," +
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
                cnxn.Close();
            }

            P6 = dtDash.Rows[0][0].ToString();
            F6 = dtDash.Rows[0][1].ToString();
            EAU = dtDash.Rows[0][2].ToString();

            // EAU Spend = EAU * Standard Cost

            string EAUSpend = string.Empty;

            if (EAU != "0")
            {
                
                Double Step1 = (Convert.ToDouble(standardCost) * Convert.ToDouble(EAU));

                EAUSpend = string.Format("{0:$0.00}", Step1);
            }
            else
            {
                EAUSpend = "$0.00";
            }

            File.AppendAllText(KBfile, "," + EAUSpend);

            // Annual Spend = F6 * Standard Cost * 2

            if (F6 != "0")
            {
                int F6x = Convert.ToInt32(F6);
                Double Step1 = (Convert.ToDouble(standardCost) * F6x * 2);

                spend = string.Format("{0:$0.00}", Step1);
            }
            else
            {
                spend = "$0.00";
            }

            File.AppendAllText(KBfile, "," + spend);

            /*
             * 
             * Kanban contract data
             * 
             * */

            File.AppendAllText(KBfile, "," +
                    KBorder + "," +
                    KBstart + "," +
                    KBend + "," +
                    KBopen + "," +
                    onOrder);

            KBorder = "printed";
            KBstart = "printed";
            KBend = "printed";
            KBopen = "printed";

            File.AppendAllText(KBfile, "," + ReOrderDate.ToShortDateString());

            File.AppendAllText(KBfile, Environment.NewLine);
        }
    }
}
