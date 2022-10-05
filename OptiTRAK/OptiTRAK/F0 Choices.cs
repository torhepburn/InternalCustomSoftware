using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OptiTRAK
{
    public partial class F0_Choices : Form
    {
        public F0_Choices()
        {
            InitializeComponent();
        }

        private void F0_Choices_Load(object sender, EventArgs e)
        {

        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            f1_AddOrder f1 = new f1_AddOrder();
            f1.ShowDialog();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            g.task = "Delete";
            F2_Select_Sales_Order f2 = new F2_Select_Sales_Order();
            f2.ShowDialog();
        }
    }

    public static class g
    {
        public static string orderNo;
        public static string task;
        public static string position;
        //public static string userType;

        //public static string facility;
        //public static string emailFrom;
        ////public static DataTable table;
        //public static string location;
        //public static string Ldescription;
        //public static string room;
        //public static string Rdescription;
        //public static string Rnotes;
        //public static int rID;
        //public static string eBadgeID;
        //public static string iID;
        //public static string iDescription;
        //public static int internalCalContact;
        //public static int cdID;                 //calibration data id
        //public static string rpt_status;
        //public static string rpt_CalSource;
        //public static string rpt_earliestDueDate;
        //public static string rpt_latestDueDate;
        //public static string rpt_room;
        //public static string rpt_type;
        //public static string pdf;
        public static string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = optitrak;";
        //public static string dbDash = "[middb01].dashboard.dbo.view_employees";
        //public static string dbDashserver = "server = middb01; password = views; " +
        //                          "user = views; database = dashboard;";
    }
}
