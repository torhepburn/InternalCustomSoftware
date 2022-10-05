using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace aaAdjustableShortageReview
{
    public partial class AoTest : Form
    {
        SqlConnection cnxn;
        SqlConnection NAVcnxn;
        SqlDataAdapter da;
        SqlDataReader dr;

        SqlParameter pComments;
        SqlParameter pProductLine;
            SqlParameter pGroup;
            SqlParameter pStockOut;
            SqlParameter pQuantityRequired;
            SqlParameter pCustomItem;
            SqlParameter pItemCode;
            SqlParameter pDescription;
            SqlParameter pProject;
            SqlParameter pProjectDescription;
            SqlParameter pPurchaseOrder;
            SqlParameter pRequiredDate;
            SqlParameter pPlannerBuyer;
            SqlParameter pWhoEntered;
            SqlParameter pShortageID;
            SqlParameter pOrigRqstRcptDate;
            SqlParameter pPlannedReceiptDate;
            SqlParameter pSupplier;
            SqlParameter pPOqty;
            SqlParameter pHot;
            SqlParameter pInstOptic;

        private string user;
        DataTable dt1;
        private int id;
        private bool multiplelineflag = false;
        private bool loaded = false;
        private bool noProductLine = true;
        private bool checkedLoopInProgress = false;
        private bool itemLoopInProgress = false;
        private bool itemCodeSelected = false;

        public AoTest()
        {
            InitializeComponent();
        }

        private void AoTest_Load(object sender, EventArgs e)
        {
            this.Text = "Add Shortage - Shortage Manager v" + Application.ProductVersion;

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
            cnxn = new SqlConnection(g.db);

            SqlCommand cmd = new SqlCommand(
                "select distinct [group] as prodGroup from shortage_list " +
                "WHERE DateAddedToList > (GetDate() - 365) " +
               " order by [group] ", cnxn);

            DataTable dt = new DataTable();

            try
            {
                cnxn.Open();
                cmd.CommandTimeout = 300;
                dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            cbddGroup.DataSource = dt;
            cbddGroup.DisplayMember = "prodGroup";

            NAVcnxn = new SqlConnection(g.dbNAV);

            da = new SqlDataAdapter(
                " select [No_] [Item Code], [Description] FROM [ZYGO$Item] " +
                " ORDER BY [No_]", NAVcnxn);

            try
            {
                dt1 = new DataTable();
                dt1.Rows.Add();
                dt1.AcceptChanges();
                da.SelectCommand.CommandTimeout = 300;
                da.Fill(dt1);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                NAVcnxn.Close();
            }

            cbddItemCode.DataSource = dt1;
            cbddItemCode.DisplayMember = "Item Code";


            /*
             * 
             * Planner Buyer
             * 
             * */

            da = new SqlDataAdapter(
                 "SELECT " +
                 "UPPER(SUBSTRING(name,(CHARINDEX(',',name))+ 2, LEN(name) -  (CHARINDEX(',',name))+ 2) + ' ' + LEFT(name,1)) " +
                 "Name " +
                 "from middb01.dashboard.dbo.view_employees where name != 'Bacon, Bill' and " +
                 "(mysupervisorname like 'piccolo%' or mysupervisorname like 'ogden%' " +
                 "or mysupervisorname like 'thompson%') or name = 'Tello, Christopher' " +
                 "order by name ", cnxn);

            DataTable dt2 = new DataTable();
            dt2.Rows.Add();
            dt2.AcceptChanges();
            da.SelectCommand.CommandTimeout = 300;
            da.Fill(dt2);

            cbddPlannerBuyer.DataSource = dt2;
            cbddPlannerBuyer.DisplayMember = "Name";

            cnxn.Close();

            loaded = true;
        }


        private void EnterItem()
        {
            pComments = new SqlParameter("@comments", SqlDbType.VarChar);
            if (cbddComments.Text.Length > 0)
            {
                pComments.Value = cbddComments.Text.Trim();
            }
            else
            {
                pComments.Value = "New Shortage - no comments entered.";
            }


            pProductLine = new SqlParameter("@productLine", SqlDbType.VarChar);
            pProductLine.Value = cbddProductLine.Text.Trim();
            
            pGroup = new SqlParameter("@pGroup", SqlDbType.VarChar);
            if (cbddGroup.Text.Length > 0)
            {
                pGroup.Value = cbddGroup.Text.Trim();
            }
            else
            {
                pGroup.Value = DBNull.Value;
            }

            pQuantityRequired = new SqlParameter("@quantityRequired", SqlDbType.VarChar);
            if (tbQuantityRequired.Text.Length > 0)
            {
                pQuantityRequired.Value = tbQuantityRequired.Text.Trim();
            }
            else
            {
                MessageBox.Show("Must enter a quantity required.");
                return;
            }

            pItemCode = new SqlParameter("@itemCode", SqlDbType.VarChar);
            if (cbCustomItem.Checked)
            {
                pItemCode.Value = g.itemCode;
            }


            if (cbddItemCode.Text.Length > 0 & cbCustomItem.Checked == false)
            {
                pItemCode.Value = cbddItemCode.Text.Trim();
            }
            else if (cbddItemCode.Text.Length == 0 & cbCustomItem.Checked == false)
            {
                pItemCode.Value = DBNull.Value;
                MessageBox.Show("Must select an item code or custom item code.");
                return;
            }



            pDescription = new SqlParameter("@pDescription", SqlDbType.VarChar);
            if (tbDescription.Text.Length > 0)
            {
                pDescription.Value = tbDescription.Text.Trim();
            }
            else
            {
                pDescription.Value = DBNull.Value;
            }

            pProject = new SqlParameter("@pProject", SqlDbType.VarChar);

            if (tbProject.Text.Length > 0)
            {
                pProject.Value = tbProject.Text.Trim();
            }
            else
            {
                pProject.Value = DBNull.Value;
            }

            pProjectDescription = new SqlParameter("@projectDescription", SqlDbType.VarChar);

            if (tbProjectDescription.Text.Length > 0)
            {
                pProjectDescription.Value = tbProjectDescription.Text.Trim();
            }
            else
            {
                pProjectDescription.Value = DBNull.Value;
            }

            pPurchaseOrder = new SqlParameter("@purchaseOrder", SqlDbType.VarChar);
            if (tbPO.Text.Length > 0)
            {
                pPurchaseOrder.Value = tbPO.Text.Trim();
            }
            else
            {
                pPurchaseOrder.Value = DBNull.Value;
            }

            pRequiredDate = new SqlParameter("@requiredDate", SqlDbType.Date);

            if (dtpRequiredDate.Text.Length > 0)
            {
                pRequiredDate.Value = dtpRequiredDate.Text.Trim();
            }
            else
            {
                pRequiredDate.Value = "01-01-1900";
            }

            pPlannerBuyer = new SqlParameter("@plannerBuyer", SqlDbType.VarChar);
            if (g.PurchaserCode != cbddPlannerBuyer.Text)
            {
                if (cbddPlannerBuyer.Text.Length > 0)
                {
                    pPlannerBuyer.Value = cbddPlannerBuyer.Text.Trim();
                }
                else
                {
                    pPlannerBuyer.Value = "CHRIS O";
                }
            }
            else
            {
                if (g.PurchaserCode.Length > 0)
                {
                    pPlannerBuyer.Value = g.PurchaserCode;
                }
                else
                {
                    pPlannerBuyer.Value = "CHRIS O";
                }
            }

            pWhoEntered = new SqlParameter("@whoEntered", SqlDbType.VarChar);
            pWhoEntered.Value = user;

            pStockOut = new SqlParameter("@stockOut", SqlDbType.VarChar);
            if (cbStockOut.Checked)
            {
                pStockOut.Value = 'Y';
            }
            else
            {
                pStockOut.Value = DBNull.Value;
            }

            pCustomItem = new SqlParameter("@customItem", SqlDbType.VarChar);
            if (cbCustomItem.Checked)
            {
                pCustomItem.Value = 'Y';
                pItemCode.Value = tbCustomItem.Text.Trim();
            }
            else
            {
                pCustomItem.Value = DBNull.Value;
            }

            pSupplier = new SqlParameter("@supplier", SqlDbType.VarChar);
            pSupplier.Value = g.Supplier;

            pPOqty = new SqlParameter("@POqty", SqlDbType.VarChar);
            pPOqty.Value = g.PoQuantity;

            pOrigRqstRcptDate = new SqlParameter("@origRqstRcptDate", SqlDbType.VarChar);
            if (g.origRqstRcptDate.Length > 0)
            {
                pOrigRqstRcptDate.Value = g.origRqstRcptDate;
            }
            else
            {
                pOrigRqstRcptDate.Value = "1900-01-01";
            }

            pPlannedReceiptDate = new SqlParameter("@plannedReceiptlDate", SqlDbType.VarChar);
            if (g.PlannedReceiptDate.Length > 0)
            {
                pPlannedReceiptDate.Value = g.PlannedReceiptDate;
            }
            else
            {
                pPlannedReceiptDate.Value = "1900-01-01";
            }

            pHot = new SqlParameter("@hot", SqlDbType.Int);
            if (cbHot.Checked)
            {
                pHot.Value = -1;
            }
            else
            {
                pHot.Value = 0; ;
            }

            pInstOptic = new SqlParameter("@instOptic", SqlDbType.Bit);
            if (pProductLine.Value.ToString() == "INST" & pGroup.Value.ToString().ToUpper() == "OPTICS")
            {
                pInstOptic.Value = 1;
            }
            else
            {
                pInstOptic.Value = 0; ;
            }


            /*
             * 
             *  use output parameter to get ShortageID for comment tracking
             * 
             * */

            pShortageID = new SqlParameter("@ID", SqlDbType.Int);
            pShortageID.Direction = ParameterDirection.Output;

            cnxn = new SqlConnection(g.db);

            SqlCommand cmd = new SqlCommand(
                "Insert into Shortage_List (" +
                " ProductLine " +
                ",[Group] " +
                ",StkOut " +
                ",QtyNeeded " +
                ",[Custom Item] " +
                ",ItemCode " +
                ",[Description] " +
                ",[Project] " +
                ",[ProjectDesc] " +
                ",PO " +
                ",[Orig_ Requested Receipt Date] " +
                ",PlannerRequiredDate " +
                ",PlannedReceiptDate " +
                ",CurrDueDate " +
                ",previousCurrDueDate " +
                ",Supplier " +
                ",Buyer " +
                ",POQty " +
                ",WhoAdded " +
                ",FlagField " +
                ",DateAddedToList " +
                ",Hot " +
                ",InstrumentOptic " +
                ") values (" +
                pProductLine + "," +
                pGroup + "," +
                pStockOut + "," +
                pQuantityRequired + "," +
                pCustomItem + "," +
                pItemCode + "," +
                pDescription + "," +
                pProject + "," +
                pProjectDescription + "," +
                pPurchaseOrder + "," +
                pOrigRqstRcptDate + "," +
                pRequiredDate + "," +
                pPlannedReceiptDate + "," +
                "'01-01-1900'," +
                "'01-01-1900'," +
                pSupplier + "," +
                pPlannerBuyer + "," +
                pPOqty + "," +
                pWhoEntered + "," +
                "-1, " +
                "GETDATE() " +
                "," + pHot +
                "," + pInstOptic +
                ") SET @ID = SCOPE_IDENTITY() ", cnxn);

            cmd.Parameters.Add(pProductLine);
            cmd.Parameters.Add(pGroup);
            cmd.Parameters.Add(pStockOut);
            cmd.Parameters.Add(pQuantityRequired);
            cmd.Parameters.Add(pCustomItem);
            cmd.Parameters.Add(pItemCode);
            cmd.Parameters.Add(pDescription);
            cmd.Parameters.Add(pProject);
            cmd.Parameters.Add(pProjectDescription);
            cmd.Parameters.Add(pPurchaseOrder);
            cmd.Parameters.Add(pRequiredDate);
            cmd.Parameters.Add(pPlannerBuyer);
            cmd.Parameters.Add(pWhoEntered);
            cmd.Parameters.Add(pShortageID);
            cmd.Parameters.Add(pOrigRqstRcptDate);
            cmd.Parameters.Add(pPlannedReceiptDate);
            cmd.Parameters.Add(pSupplier);
            cmd.Parameters.Add(pPOqty);
            cmd.Parameters.Add(pHot);
            cmd.Parameters.Add(pInstOptic);

            try
            {
                cnxn.Open();
                cmd.ExecuteNonQuery();

                id = (int)cmd.Parameters["@ID"].Value;

                if (id > 0 & pComments.Value.ToString().Length > 0)
                {
                    cmd.Parameters.Clear();

                    cmd = new SqlCommand(
                    "Insert into ShortageListComments (" +
                    " ShortageID " +
                    ",Comment " +
                    ",EnteredBy " +
                    ",EnteredOn " +
                    ") values (" +
                    id + "," +
                    pComments + "," +
                    pWhoEntered + "," +
                    "GETDATE() " +
                    ")", cnxn);

                    cmd.Parameters.Add(pComments);
                    cmd.Parameters.Add(pWhoEntered);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                    cbddComments.Text = "";
                    cbddProductLine.Text = "";
                    cbddGroup.Text = "";
                    tbQuantityRequired.Text = "";
                    tbDescription.Text = "";
                    loaded = false;
                    cbddItemCode.Text = "";
                    tbProject.Text = "";
                    tbProjectDescription.Text = "";
                    tbPO.Text = "";
                    cbddPlannerBuyer.Text = "";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
                cmd.Parameters.Clear();
                LshortageEntered.Text = "ShortageID " + id.ToString() + " entered in database.";
                LshortageEntered.Visible = true;
            }

            cbStockOut.Checked = false;
            cbCustomItem.Checked = false;

            this.Close();
        }


        private void cbddItemCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                if (itemLoopInProgress == false)
                {
                    productLineCheck();
                }

                if (noProductLine)
                {
                    itemLoopInProgress = true;
                    cbddItemCode.SelectedIndex = 0;
                    cbddProductLine.Focus();
                }
                else
                {

                    int n = cbddItemCode.SelectedIndex;
                    tbDescription.Text = dt1.Rows[n].ItemArray[1].ToString();
                    g.itemCode = dt1.Rows[n].ItemArray[0].ToString();

                    if (cbddProductLine.Text == "WAR")
                    {
                        if (n > 0)
                        {
                            PO p = new PO();
                            p.ShowDialog();
                        }
                    }
                    else
                    {
                        NAVcnxn = new SqlConnection(g.dbNAV);

                        SqlCommand cmd = new SqlCommand(
                            "SELECT TOP 1 " +
                            "l.[Document No_] [Order No] " +
                            ",l.[PO Line No_] [PO Line No] " +
                            ",l.[Job No_] [Job No] " +
                            ",CONVERT(varchar(10), l.[Orig_ Requested Receipt Date],101) [Orig_ Requested Receipt Date] " +
                            ",s.Name Vendor " +
                            ",FORMAT(l.Quantity, '##.##') as Quantity " +
                            ",CONVERT(varchar(10), l.[Planned Receipt Date],1) [Planned Receipt Date] " +
                            ",CASE " +
                            "   WHEN LEN(COALESCE(H.[Purchaser Code],'')) > 0 THEN H.[Purchaser Code] " +
                            "   WHEN LEN(COALESCE(H.[Purchaser Code],'')) = 0 THEN (" +
                            "SELECT CASE " +
                                " WHEN LEN([Buyer Planner Code]) > 0 THEN [Buyer Planner Code] " +
                                "   ELSE 'CHRIS O' " +
                                "END " +
                                "FROM ZYGO$Item " +
                            "       WHERE No_ = '" + g.itemCode + "') " +
                            "END [Purchaser Code]" +
                            "FROM [" + g.NAVprefix + "Purchase Line] l " +
                            "INNER JOIN [ZYGO$Purchase Header] H on H.No_ = l.[Document No_] " +
                            "inner join [" + g.NAVprefix + "Vendor] s on l.[Buy-from Vendor No_] = s.No_ " +
                            "WHERE  l.[Outstanding Quantity] > 0 and l.No_ = '" + g.itemCode + "' " +
                            "order by l.[Requested Receipt Date] ", NAVcnxn);

                        DataTable dt3 = new DataTable();

                        try
                        {
                            NAVcnxn.Open();
                            cmd.CommandTimeout = 300;
                            dr = cmd.ExecuteReader();
                            dt3.Load(dr);
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            NAVcnxn.Close();
                        }

                        if (dt3.Rows.Count > 0)
                        {
                            g.PO = dt3.Rows[0][0].ToString().Trim();

                            g.origRqstRcptDate = dt3.Rows[0][3].ToString().Trim();

                            g.Supplier = dt3.Rows[0][4].ToString().Trim();

                            g.PoQuantity = dt3.Rows[0][5].ToString().Trim();

                            g.PlannedReceiptDate = dt3.Rows[0][6].ToString().Trim();

                            g.PurchaserCode = dt3.Rows[0][7].ToString().Trim();

                            if (g.PurchaserCode.Length > 0)
                            {

                            }
                            else
                            {
                                g.PurchaserCode = null;
                            }
                        }
                        else
                        {
                            g.PO = string.Empty;

                            g.origRqstRcptDate = string.Empty;

                            g.Supplier = string.Empty;

                            g.PoQuantity = string.Empty;

                            g.PlannedReceiptDate = string.Empty;

                            g.PurchaserCode = null;

                            MessageBox.Show("There are no purchase orders open for this item.");
                        }
                    }
                    itemCodeSelected = true;
                    tbPO.Text = g.PO;
                    cbddItemCode.Text = g.itemCode;
                    cbddPlannerBuyer.Text = g.PurchaserCode;
                }
            }
        }

        private void productLineCheck()
        {
            if (loaded)
            {
                if (cbddProductLine.Text.Length < 1)
                {
                    MessageBox.Show("Must select a product line");
                    noProductLine = true;
                    cbddProductLine.Focus();
                }
                else
                {
                    noProductLine = false;
                    g.ProductLine = cbddProductLine.Text.Trim();
                }
            }
        }

        

        private void cbCustomItem_CheckedChanged(object sender, EventArgs e)
        {
            /* add flag for checkLoopInProgress     */
            if (checkedLoopInProgress == false)
            {
                productLineCheck();
                checkedLoopInProgress = true;
            }

            if (noProductLine)
            {
                checkedLoopInProgress = true;
                cbCustomItem.Checked = false;
                cbddProductLine.Focus();
            }
            else
            {
                if (cbCustomItem.Checked)
                {
                    tbCustomItem.Visible = true;
                    cbddItemCode.Text = string.Empty;
                    tbDescription.Text = string.Empty;
                    cbddItemCode.Visible = false;
                }
                else
                {
                    tbCustomItem.Visible = false;
                    cbddItemCode.Visible = true;
                }
            }
        }

        private void cbddProductLine_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbddProductLine.Text.Length > 0)
            {
                noProductLine = false;
            }
        }

        private void Badd_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            NAVcnxn = new SqlConnection(g.dbNAV);

            productLineCheck();

            
            /*  if all the lines of the PO are going to be entered    */

            if (cbPOEntire.Checked)
            {
                /* make sure that the PO is a valid number  */

                object o = null;

                try
                {
                    NAVcnxn.Open();
                    SqlCommand cmd1 = new SqlCommand("Select No_ FROM [ZYGO$Purchase Header] " +
                        "WHERE No_ = '" + tbPO.Text.Trim().ToUpper() + "'", NAVcnxn);
                    o = cmd1.ExecuteScalar();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    NAVcnxn.Close();
                }

                if (o is null)
                {
                    MessageBox.Show(tbPO.Text.Trim() + " is not a valid purchase order number");
                    tbPO.Text = string.Empty;
                    tbPO.Focus();
                    return;
                }
                else
                {
                    /*  set the global variable to the validated PO number    */

                    g.PO = tbPO.Text.Trim().ToUpper();
                }

                                
                if (cbddGroup.Text.Length > 0)
                {
                    g.ShortageGroup = cbddGroup.Text.Trim();
                }
                else
                {
                    g.ShortageGroup = g.ProductLine;
                }

                /*  get the lines and enter them in the shortage database    */

                SqlCommand cmd = new SqlCommand(
                    "SELECT " +
                    "  L.No_ " +
                    ", L.Description " +
                    ",CONVERT(varchar(10),L.[Orig_ Requested Receipt Date], 1) " + //put in RequiredDate field as this is automated
                    ",CONVERT(varchar(10), L.[Planned Receipt Date], 1) " +
                    ", H.[Buy-from Vendor Name] " +
                    ",CASE " +
                            "   WHEN LEN(COALESCE(H.[Purchaser Code],'')) > 0 THEN H.[Purchaser Code] " +
                            "   WHEN LEN(COALESCE(H.[Purchaser Code],'')) = 0 THEN (" +
                            "SELECT CASE " +
                                " WHEN LEN([Buyer Planner Code]) > 0 THEN [Buyer Planner Code] " +
                                "   ELSE 'CHRIS O' " +
                                "END " +
                                "FROM ZYGO$Item " +
                            "       WHERE No_ = '" + g.itemCode + "') " +
                            "END [Purchaser Code]" +
                    ", CAST(FORMAT(L.[Outstanding Quantity], '##.##') as varchar(5)) " +
                    "from [ZYGO$Purchase Line] L " +
                    "INNER JOIN [ZYGO$Purchase Header] H on L.[Document No_] = H.No_ " +
                    "where[Document No_] = '" + g.PO + "'", NAVcnxn);

                try
                {
                    NAVcnxn.Open();
                    SqlDataReader dr;

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        try
                        {
                            pComments = new SqlParameter("@comments", SqlDbType.VarChar);
                            if (cbddComments.Text.Length > 0)
                            {
                                pComments.Value = cbddComments.Text.Trim();
                            }
                            else
                            {
                                pComments.Value = "New Shortage - no comments entered.";
                            }

                            SqlParameter pCommentsWhoEntered = new SqlParameter("@commentsWhoEntered", SqlDbType.VarChar);
                            pCommentsWhoEntered.Value = user;


                            pProductLine = new SqlParameter("@productLine", SqlDbType.VarChar);
                            pProductLine.Value = g.ProductLine;

                            pGroup = new SqlParameter("@pGroup", SqlDbType.VarChar);
                            pGroup.Value = g.ShortageGroup;

                            pQuantityRequired = new SqlParameter("@quantityRequired", SqlDbType.VarChar);
                            pQuantityRequired.Value = dr.GetString(6);

                            pItemCode = new SqlParameter("@itemCode", SqlDbType.VarChar);
                            pItemCode.Value = dr.GetString(0);

                            pDescription = new SqlParameter("@pDescription", SqlDbType.VarChar);
                            pDescription.Value = dr.GetString(1);

                            pPurchaseOrder = new SqlParameter("@purchaseOrder", SqlDbType.VarChar);
                            pPurchaseOrder.Value = g.PO;

                            pOrigRqstRcptDate = new SqlParameter("@origRqstRcptDate", SqlDbType.Date);
                            pOrigRqstRcptDate.Value = dr.GetString(2);

                            pPlannedReceiptDate = new SqlParameter("@plannedReceiptlDate", SqlDbType.VarChar);
                            pPlannedReceiptDate.Value = dr.GetString(3);

                            pSupplier = new SqlParameter("@supplier", SqlDbType.VarChar);
                            pSupplier.Value = dr.GetString(4);

                            pPlannerBuyer = new SqlParameter("@plannerBuyer", SqlDbType.VarChar);
                            pPlannerBuyer.Value = dr.GetString(5);

                            pPOqty = new SqlParameter("@POqty", SqlDbType.VarChar);
                            pPOqty.Value = dr.GetString(6);

                            pWhoEntered = new SqlParameter("@whoEntered", SqlDbType.VarChar);
                            pWhoEntered.Value = user;

                            pShortageID = new SqlParameter("@ID", SqlDbType.Int);
                            pShortageID.Direction = ParameterDirection.Output;

                            pInstOptic = new SqlParameter("@instOptic", SqlDbType.Bit);
                            if (pProductLine.Value.ToString() == "INST" & pGroup.Value.ToString().ToUpper() == "OPTICS")
                            {
                                pInstOptic.Value = 1;
                            }
                            else
                            {
                                pInstOptic.Value = 0; ;
                            }


                            cnxn = new SqlConnection(g.db);

                            SqlCommand cmd1 = new SqlCommand(
                                "Insert into Shortage_List (" +
                                " ProductLine " +
                                ",[Group] " +
                                ",StkOut " +
                                ",QtyNeeded " +
                                ",[Custom Item] " +
                                ",ItemCode " +
                                ",[Description] " +
                                ",[Project] " +
                                ",[ProjectDesc] " +
                                ",PO " +
                                ",[Orig Date] " +
                                ",PlannerRequiredDate " +
                                ",PlannedReceiptDate " +
                                ",Supplier " +
                                ",Buyer " +
                                ",POQty " +
                                ",WhoAdded " +
                                ",FlagField " +
                                ",DateAddedToList " +
                                ",InstrumentOptic " +
                                ") values (" +
                                pProductLine + "," +
                                pGroup + "," +
                                "'', " +                    //stock out value
                                pQuantityRequired + "," +
                                "'', " +                    //custom item value
                                pItemCode + "," +
                                pDescription + "," +
                                "'', " +                    //project value
                                "'', " +                    //project desc value
                                pPurchaseOrder + "," +
                                pOrigRqstRcptDate + "," +
                                pOrigRqstRcptDate + "," +
                                pPlannedReceiptDate + "," +
                                pSupplier + "," +
                                pPlannerBuyer + "," +
                                pPOqty + "," +
                                pWhoEntered + "," +
                                "-1, " +
                                "GETDATE() ," +
                                pInstOptic +
                                ") SET @ID = SCOPE_IDENTITY() ", cnxn);

                            cmd1.Parameters.Add(pProductLine);
                            cmd1.Parameters.Add(pGroup);
                            cmd1.Parameters.Add(pQuantityRequired);
                            cmd1.Parameters.Add(pItemCode);
                            cmd1.Parameters.Add(pDescription);
                            cmd1.Parameters.Add(pPurchaseOrder);
                            cmd1.Parameters.Add(pOrigRqstRcptDate);
                            cmd1.Parameters.Add(pPlannerBuyer);
                            cmd1.Parameters.Add(pWhoEntered);
                            cmd1.Parameters.Add(pShortageID);
                            cmd1.Parameters.Add(pPlannedReceiptDate);
                            cmd1.Parameters.Add(pSupplier);
                            cmd1.Parameters.Add(pPOqty);
                            cmd1.Parameters.Add(pInstOptic);

                            try
                            {
                                cnxn.Open();
                                cmd1.ExecuteNonQuery();

                                id = (int)cmd1.Parameters["@ID"].Value;



                                if (id > 0 & pComments.Value.ToString().Length > 0)
                                {
                                    SqlCommand cmd2 = new SqlCommand(
                                    "Insert into ShortageListComments (" +
                                    " ShortageID " +
                                    ",Comment " +
                                    ",EnteredBy " +
                                    ",EnteredOn " +
                                    ") values (" +
                                    id + "," +
                                    pComments + "," +
                                    pCommentsWhoEntered + "," +
                                    "GETDATE() " +
                                    ")", cnxn);

                                    try
                                    {
                                        cmd2.Parameters.Add(pComments);
                                        cmd2.Parameters.Add(pCommentsWhoEntered);
                                        cmd2.ExecuteNonQuery();
                                    }
                                    catch (SqlException ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                    }
                                    finally
                                    {
                                        cmd2.Parameters.Clear();
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
                                cmd1.Parameters.Clear();
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
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    NAVcnxn.Close();
                }

                multiplelineflag = true;
                this.Close();
            }


            if (multiplelineflag == false)
            {
                if (tbQuantityRequired.Text.Length == 0)
                {
                    MessageBox.Show("Must enter a quantity required.");
                    tbQuantityRequired.Focus();
                    return;
                }

                if (cbCustomItem.Checked == false & !itemCodeSelected)
                {
                    MessageBox.Show("Must select an item code by clicking on the drop down arrow.");
                    cbddItemCode.Focus();
                    return;
                }


                if (cbddProductLine.Text != "WAR")
                {

                    if (cbCustomItem.Checked)
                    {
                        g.itemCode = tbCustomItem.Text;

                        PO p = new PO();
                        p.ShowDialog();

                        tbPO.Text = g.PO;
                    }

                    object x = null;
                    try
                    {
                        cnxn.Open();
                        SqlCommand cmd1 = new SqlCommand("Select ID from Shortage_List " +
                            "WHERE itemCode = '" + g.itemCode + "' and DateArchived is null ", cnxn);
                        x = cmd1.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn.Close();
                    }


                    if (x is null)
                    {
                        EnterItem();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show(g.itemCode + " is already in shortage list.  Do you wish to add it again ?", "Duplicate Item", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            EnterItem();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }

                loaded = false;
                noProductLine = true;
                checkedLoopInProgress = false;
                itemLoopInProgress = false;
            }
        }
    }
}
