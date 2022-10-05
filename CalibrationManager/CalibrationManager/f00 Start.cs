using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CalibrationManager
{
    public partial class f00_Start : Form
    {
        public f00_Start()
        {
            InitializeComponent();
        }

        private void f00_Start_Load(object sender, EventArgs e)
        {
            string applicationVersion = Application.ProductVersion.Trim();
            this.Text = "f00 Start v" + applicationVersion;

            SqlConnection cnxn = new SqlConnection(g.db);
            SqlCommand cmd = new SqlCommand
                ("select version from versionhistory order by date desc");
            cmd.Connection = cnxn;
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            string V = o.ToString().Trim();

            if (V != applicationVersion)
            {
                MessageBox.Show("The program version is not up to date.");
            }

            if (g.userType.ToUpper() == "LIMITED")
            {
                bEmail.Visible = false;
                bData.Visible = false;
            }

            if (g.userType.ToUpper() == "VIEW")
            {
                bEmail.Visible = false;
                bData.Visible = false;
                bSetup.Visible = false;
            }

            if (g.userType.ToUpper() == "VIEW+DATA")
            {
                bEmail.Visible = false;
                bSetup.Visible = false;
            }

            if (g.userType.ToUpper() == "SYSTEM" | g.userType.ToUpper() == "SYSTEMAC")
            {
                bBack.Text = "BACK";
            }
        }

        private void bSetup_Click(object sender, EventArgs e)
        {
            f0_Entry_Point ep = new f0_Entry_Point();
            ep.Show();
        }

        private void bData_Click(object sender, EventArgs e)
        {
            g.item = "Data";
            g.task = "Add";
            g.taskhistory = "Add";
            f51_Equipment f1 = new f51_Equipment();
            f1.Show();
        }

        private void bReport_Click(object sender, EventArgs e)
        {
            g.item = "Data";
            g.task = "View";
            g.taskhistory = "View";
            f51_Equipment f5 = new f51_Equipment();
            f5.Show();
        }

        private void bViewsReports_Click(object sender, EventArgs e)
        {
            g.item = "Reports";
            f50_View_Selection v = new f50_View_Selection();
            v.Show();
        }

        private void bEmail_Click(object sender, EventArgs e)
        {
            f06_Email_Type et = new f06_Email_Type();
            et.Show();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public static class g
    {
        public static string item;
        public static string task;
        public static string taskhistory;
        public static string userType;

        public static string facility;
        public static string emailFrom;
        //public static DataTable table;
        public static string location;
        public static string Ldescription;
        public static string room;
        public static string Rdescription;
        public static string Rnotes;
        public static int rID;
        public static string eBadgeID;
        public static string iID;
        public static string iDescription;
        public static int internalCalContact;
        public static int cdID;                 //calibration data id
        public static string rpt_status;
        public static string rpt_CalSource;
        public static string rpt_earliestDueDate;
        public static string rpt_latestDueDate;
        public static string rpt_room;
        public static string rpt_type;
        public static string pdf;
        //public static string db = "server = ct-mid-sqltest01; password = Read+Write!; " +
        //                          "user = readwrite; database = calibration;";
        /*      settings as last run
        public static string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = calibration;";
        public static string dbDash = "[middb01].dashboard.dbo.view_employees";
        public static string dbDashserver = "server = middb01; password = views; " +
                                  "user = views; database = dashboard;";
        */
        public static string db = "server = CT-MID-SQL11; password = views; " +
                                  "user = views; database = calibration;";
        public static string dbDash = "[middb01].dashboard.dbo.view_employees";
        public static string dbDashserver = "server = middb01.zygo.com; password = views; " +
                                  "user = views; database = dashboard;";
    }
}