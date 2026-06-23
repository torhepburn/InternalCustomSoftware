using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace NAVISIONpermission
{
    public partial class F1_Start : Form
    {
        public string selectedRole = "";
        public string selectedUserName = "";
        public string selectedADGroup = "";
        public string selectedObjectName = "";
        //public string selectedCostCenter = "";
        public string selection = "";


        SqlDataReader dr;
        SqlConnection cnxn;
        DataTable table;
        DataTable dtRole;
        DataTable dtUserNAme;
        DataTable dtADGroup;
        DataTable dtObjectName;
        SqlCommand cmd;


        public F1_Start()
        {
            InitializeComponent();
        }

        private void F1_Start_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            cnxn = new SqlConnection(g.db);

            // Location Region

            cmd = new SqlCommand("SELECT '' [RoleID] UNION ALL " +
                                 "select DISTINCT [Role ID] RoleID from [NAV AD Group to Permission] " +
                                 "order by [Role ID]", cnxn);

            dtRole = new DataTable();

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();

                dtRole.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            cbddRole.DataSource = dtRole;
            cbddRole.DisplayMember = "RoleID";
            cbddRole.ValueMember = "RoleID";

        }
        private void GetData()
        {

        }

        private void bSearch_Click(object sender, EventArgs e)
        {

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
        public static string paymentTermsPlan;
        //public string? annualspendActual ;
        //public string? annualspendProjected ;
        public static string locationRegion;
        public static string commodity1;
        public static string commodity2;
        public static string buyer;

        public static string parentCompanyLocation;
        public static string parentCompanyName;
        public static string headquartersLocation;
        public static string factoryLocations;
        public static string technology;
        public static string costSavingsPlan;
        public static string costSavingsStatus;
        public static string strategy;
        public static string issues;
        public static string leadTimePlan;
        public static string leadTimeRange;
        public static string businessAlignment;
        public static string notes;
        //public static string permission ;
        public static string permissionvalue;
        public static DateOnly ndaExpirationDate;
        public static DateOnly ISO9001ExpirationDate;
        public static DateOnly ISO13485ExpirationDate;
        public static DateOnly AS9100ExpirationDate;
        public static DateOnly ZM0027ExpirationDate;
        public static string alternateSuppliers;
        public static string numberCriticalParts;
        public static string contractsType;
        public static string percentOfCoverage;
        public static string typeStatus;
        public static string lineofBusiness;


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
