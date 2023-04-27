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

namespace aaShortageManagerLargeFonts
{
    public partial class F1_Select : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        private string UserName;
        private int LogID;

        public F1_Select()
        {
            InitializeComponent();
        }

        private void F1_Select_Load(object sender, EventArgs e)
        {
            this.Text = "Select Task - Shortage Manager v" + Application.ProductVersion;

            cnxn = new SqlConnection(g.db);
            cnxn.Open();

            System.Security.Principal.WindowsIdentity userBase;
            userBase = System.Security.Principal.WindowsIdentity.GetCurrent();

            UserName = userBase.Name.Replace("ZYGOMIS\\", "");
            string computername = Environment.MachineName;

            SqlParameter pUserName = new SqlParameter("@pUserName", SqlDbType.VarChar);
            pUserName.Value = UserName;

            SqlParameter pLogID = new SqlParameter("@LogID", SqlDbType.Int);
            pLogID.Direction = ParameterDirection.Output;

            SqlCommand cmd = new SqlCommand(
                "Insert into ApplicationUseLog (" +
                " PCID " +
                ",UserName " +
                ",Application " +
                ",LogON " +
                ",Location " +
                ")values('" +
                computername + "', " +
                pUserName + ", " +
                "'ShortageManager','" +
                DateTime.Now + "'," +
                "'ZAMS') SET @LogID = SCOPE_IDENTITY() ", cnxn);

            cmd.Parameters.Add(pUserName);
            cmd.Parameters.Add(pLogID);

            try
            {
                cmd.ExecuteNonQuery();
                LogID = (int)cmd.Parameters["@LogID"].Value;
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
            (" Select ItemCode [Item Code], ProductLine Line, [Req date],  ID " +
             " FROM shortage_list " +
             " WHERE DateArchived IS NULL " +
             " ORDER BY ItemCode, ID ", cnxn);

            DataTable table = new DataTable();
            da.Fill(table);

            DGV.DataSource = table;

            DGV.Columns[0].Width = 120;
            DGV.Columns[1].Width = 50;
            DGV.Columns[2].Width = 90;
            DGV.Columns[3].Width = 50;

            DGV.Show();

            //this works better than focus()
            tbSearch.Select();
        }

        private void bINST_Click(object sender, EventArgs e)
        {
            g.task = "REVIEW";
            g.ProductLine = "INST";
            F2_Meeting r = new F2_Meeting();
            r.Show();
        }

        private void bPPS_Click(object sender, EventArgs e)
        {

        }

        private void bOPTICS_Click(object sender, EventArgs e)
        {

        }

        private void bZEOS_Click(object sender, EventArgs e)
        {

        }

        private void bWarRoom_Click(object sender, EventArgs e)
        {

        }
    }

    public static class g
    {
        public static string itemCode;
        public static string ShortageID;
        public static string ShortageGroup;
        public static string ProductLine;
        public static string task;
        public static string origDelDate = string.Empty;
        public static string ExpectedReceiptDate = string.Empty;
        public static string PO;
        public static string Supplier = string.Empty;
        public static string PoQuantity = string.Empty;
        public static string PurchaserCode = string.Empty;
        public static string dbDash = "server = MIDDB01; password = views; " +
            "user = views; database = Dashboard;";
        public static string db = "server = CT-MID-SQL01; password = Read+Write!; " +
                            "user = readwrite; database = AccessFrontEnds;";
        //public static string dbNAV = "server = MIDNAV01; password = views; " +
        //                    "user = views; database = ZYGO-NAV-TEST;";
        public static string dbNAV = "server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
                            "user = navdb_read; database = ZYGO-NAV-PROD;";
        /*public static string dbNAV = "server = pa-hor-as408.ametek.com; password = views; " +
                            "user = views; database = ZYGO-NAV-TEST;";*/
        public static string NAVprefix = "ZYGO$";
        //public static string NAVprefix = "ZYGO$";
    }
}
