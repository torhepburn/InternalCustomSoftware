using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PMclose
{
    public partial class PMSelect : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        
        public PMSelect()
        {
            InitializeComponent();
        }

        private void PMSelect_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
                
            da = new SqlDataAdapter(
                "Select  " +
                "H.serial, " +
                "trouble_work_reference_number, " +
                "trouble_assignedto, " +
                "owner from [repair history] H " +
                "inner join pmequip E on " +
                "H.serial = E.serial " +
                "where repair_date is null " + 
                "order by h.serial", cnxn);

            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter(
                 "Select  " +
                 "H.serial, " +
                 "trouble_work_reference_number, " +
                 "trouble_assignedto, " +
                 "owner from [repair history] H " +
                 "inner join pmequip E on " +
                 "H.serial = E.serial " +
                 "where h.serial like '%" + tbSearchEquipment.Text + "%' " +
                 " and repair_date is null " +
                 " order by h.serial", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
        }

        private void bItem_Click(object sender, EventArgs e)
        {

        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public static class g
        {
            public static string item;
            //public static string task;
            //public static string taskhistory;
            //public static string userType;

            //public static string facility;
            //public static string emailFrom;

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
            public static string db = "server = midprj01; password = views; " +
                                      "user = views; database = logsheetsdb;";
            
        }
    }
}
