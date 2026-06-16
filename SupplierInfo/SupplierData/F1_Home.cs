using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace SupplierData
{
    public partial class F1_Home : Form
    {
        public string selectedRegion = "";
        public string selectedCommodity = "";
        public string selectedPurchaser = "";
        public string selectedVendorTitle = "";
        //public string selectedCostCenter = "";
        public string selection = "";


        SqlDataReader dr;
        SqlConnection cnxn;
        DataTable table;
        DataTable dtLocationRegion;
        DataTable dtCommodity;
        DataTable dtBuyer;
        DataTable dtTitle;
        SqlCommand cmd;


        public F1_Home()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            cnxn = new SqlConnection(g.dbNAV);

            // Location Region

            cmd = new SqlCommand("SELECT '' Region UNION ALL " +
                                 "select Code + ' : ' + Name Region from [ZYGO$Country_Region] " +
                                 "order by Region", cnxn);

            dtLocationRegion = new DataTable();

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();

                dtLocationRegion.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            cbRegion.DataSource = dtLocationRegion;
            cbRegion.DisplayMember = "Region";
            cbRegion.ValueMember = "Region";

            //buyer

            dtBuyer = new System.Data.DataTable();

            cnxn = new SqlConnection(g.db);

            cmd = new SqlCommand("SELECT ' ' Buyer UNION ALL " +
                "SELECT Code [Buyer] from [BuyerPlannerData] " +
                "ORDER BY Buyer", cnxn);

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();
                dtBuyer.Load(dr);
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            finally
            {
                cnxn.Close();
            }
           
            cbPurchaser.DataSource = dtBuyer;
            cbPurchaser.DisplayMember = "Buyer";
            cbPurchaser.ValueMember = "Buyer";


            //  Commodity

            cnxn = new SqlConnection(g.db);

            cmd = new SqlCommand
                ("SELECT ' ' Commodity UNION ALL " +
                "select distinct [Commodity 1] Commodity FROM SupplierData_s1 " +
                 "WHERE LEN([Commodity 1]) > 0 " +
                 "order by [Commodity] ", cnxn);

            dtCommodity = new DataTable();

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();

                dtCommodity.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            cbCommodity.DataSource = dtCommodity;
            cbCommodity.DisplayMember = "Commodity";
            cbCommodity.ValueMember = "Commodity";
            
            //  vendor title

            cmd = new SqlCommand("SELECT DISTINCT [Vendor Title] Title from SupplierData " +
                                 " UNION ALL SELECT TOP 1 '' FROM SupplierData " +
                                 " ORDER BY [Vendor Title]", cnxn);

            dtTitle = new DataTable();

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();

                dtTitle.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            cbTitle.DataSource = dtTitle;

            cbTitle.DisplayMember = "Title";
            cbTitle.ValueMember = "Title";

            GetData();
        }

        private void GetData()
        {
            string SQL =
                "SELECT " +
                "TRIM([Name]) Supplier " +
                ",TRIM([SupplierNo]) [Supplier No] " +
                ",TRIM([Overall Supplier Rating]) [Overall Supplier Rating] " +
                ",TRIM([Quality Rating]) [Quality Rating] " +
                ",TRIM([OTD Rating]) [OTD Rating] " +
                ",TRIM([Payment Terms]) [Payment Terms] " +
                ",[Annual Spend Actual] [Annual Spend Actual] " +
                ",[Annual Spend Projected] [Annual Spend Projected] " +
                ",TRIM([Location/Region]) [Location/Region] " +
                ",TRIM([Commodity 1]) [Commodity] " +
                ",TRIM([Vendor Title]) [Vendor Title] " +
                ",TRIM([Purchaser Code]) [Purchaser Code] " +
                //",[DateEntered] [DateEntered] " +
                " FROM SupplierData_s1";

            //selectFilter();

            if (selection.Length > 0)
            {
                SQL += selection + " ORDER BY Supplier";
            }
            else
            {
                SQL += " ORDER BY [Name]";
            }

            cmd = new SqlCommand(SQL, cnxn);
            table = new DataTable();

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();

                table.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            DGV.DataSource = table;
            DGV.Columns[0].Width = 250;
            DGV.Columns[1].Width = 60;
            DGV.Columns[2].Width = 60;
            DGV.Columns[3].Width = 60;
            DGV.Columns[4].Width = 60;
            DGV.Columns[5].Width = 60;
            DGV.Columns[6].Width = 80;
            DGV.Columns[7].Width = 80;
            DGV.Columns[8].Width = 150;
            DGV.Columns[9].Width = 350;
            DGV.Columns[10].Width = 250;
            DGV.Columns[11].Width = 200;
            
            DGV.Show();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            selection = " WHERE [Name] LIKE '%" + tbSearch.Text.Trim() + "%'";

            GetData();
        }

        private void bItem_Click(object sender, EventArgs e)
        {
            selection = " WHERE [SupplierNo] = '" + tbSearch.Text.Trim() + "'";

            GetData();

            /*
             * g.item = tbSearchPartNumber.Text.ToString().Trim().ToUpper();
            tbSearchPartNumber.Text = "";
            SqlCommand cmd = new SqlCommand(
                "SELECT No_ FROM " + g.NAVprefix + "Item " +
                "where No_ = '" + g.item + "'" );
            cnxn = new SqlConnection(g.dbNAV);
            cmd.Connection = cnxn;
            cnxn.Open();
            object o = cmd.ExecuteScalar();
             * */

        }

        private void selectFilter()
        {            
            if (selectedRegion.Length > 0)
            {
                selection += " and [Location/Region] = '" + selectedRegion + "' ";
            }

            if (selectedCommodity.Length > 0)
            {
                selection += " and [Commodity 1] = '" + selectedCommodity + "' ";
            }

            if (selectedPurchaser.Length > 0)
            {
                selection += " and [Purchaser Code] = '" + selectedPurchaser + "' ";
            }

            if (selectedVendorTitle.Length > 0)
            {
                selection += " and [Vendor Title] = '" + selectedVendorTitle + "' ";
            }
        }



        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 | e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.supplierNo = cell.EditedFormattedValue.ToString().Trim();

                EditData ED = new EditData();
                ED.ShowDialog();

            }
        }

        private void CbRegion_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            selectedRegion = cbRegion.SelectedValue.ToString().Trim();
        }

        private void cbCommodity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedCommodity = cbCommodity.SelectedValue.ToString().Trim();
        }

        private void cbTitle_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedVendorTitle = cbTitle.SelectedValue.ToString().Trim();
        }

        private void cbPurchaser_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            selectedPurchaser = cbPurchaser.SelectedValue.ToString().Trim();
        }

        private void bFilters_Click(object sender, EventArgs e)
        {
            selection = " WHERE 1=1 ";
            selectFilter();
            GetData();
        }
    }

    public static class g
    {
        public static int ID;
        public static string description;
        public static string task;
        public static string dbTable = "CERT_Data";
        public static string ISO = string.Empty;
        public static string search = string.Empty;
        public static string form = string.Empty;
        public static string dbImage = "CERT_Image";
        public static string subtask;
        public static string newCertNumber;
        public static string adminTask;
        public static string permission;
        public static string permissionValue;
        public static string loginname;
        public static string employeeName;
        public static string supplierNo;
        public static string vendorTitle;
        public static string supplierName;
        public static string supplierRating;
        public static string qualityRating;
        public static string otdRating;
        public static string paymentTerms;
        public static string paymentTermsPlan ;
        //public string? annualspendActual ;
        //public string? annualspendProjected ;
        public static string locationRegion;
        public static string commodity1;
        public static string commodity2;
        public static string buyer;

        public static string parentCompanyLocation ;
        public static string parentCompanyName ;
        public static string headquartersLocation ;
        public static string factoryLocations ;
        public static string technology ;
        public static string costSavingsPlan ;
        public static string costSavingsStatus ;
        public static string strategy ;
        public static string issues ;
        public static string leadTimePlan ;
        public static string leadTimeRange ;
        public static string businessAlignment ;
        public static string notes ;
        //public static string permission ;
        public static string permissionvalue ;
        public static DateOnly ndaExpirationDate ;
        public static DateOnly ISO9001ExpirationDate ;
        public static DateOnly ISO13485ExpirationDate ;
        public static DateOnly AS9100ExpirationDate ;
        public static DateOnly ZM0027ExpirationDate ;
        public static string alternateSuppliers ;
        public static string numberCriticalParts ;
        public static string contractsType ;
        public static string percentOfCoverage ;
        public static string typeStatus ;
        public static string lineofBusiness ;


        //public static string rpt_CalSource;
        //public static string rpt_earliestDueDate;
        //public static string rpt_latestDueDate;
        //public static string rpt_room;
        public static string rpt_type = string.Empty;
        //public static string pdf;
        public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds; encrypt=false;";
        public static string dbNAV = "server = pa-hor-as408.ametek.com; user = navdb_read; password = 2018#ameteK; database = ZYGO-NAV-PROD";
        //public static string dbDashserver = "server = middb01; password = views; " +
        //                          "user = views; database = dashboard;";
    }
}
