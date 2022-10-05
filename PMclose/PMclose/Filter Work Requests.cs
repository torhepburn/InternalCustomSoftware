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
    public partial class Filter_Work_Requests : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        private string sSerial;
        private string sWorkRQ;
        private string sAssigned;
        private string sOwner;

        public Filter_Work_Requests()
        {
            InitializeComponent();
        }

        private void Filter_Work_Requests_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("select '' serial  union select distinct H.SERIAL " +
                "from [repair history] H " +
                "inner join pmequip E on " +
                "H.serial = E.serial " +
                "where repair_date is null " + 
                "order by h.serial", cnxn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            cbSerial.DataSource = dt;
            cbSerial.DisplayMember = "Serial";

            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                ("select '' trouble_work_reference_number " +
                 "union select distinct " +
                 "trouble_work_reference_number " +
                "from [repair history] H " +
                "inner join pmequip E on " +
                "H.serial = E.serial " +
                "where repair_date is null " +
                "order by trouble_work_reference_number", cnxn);

            DataTable dt1 = new DataTable();
            da.Fill(dt1);

            cbWorkRQ.DataSource = dt1;
            cbWorkRQ.DisplayMember = "trouble_work_reference_number";

            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                ("select '' trouble_assignedto union " +
                "select distinct trouble_assignedto " +
                "from [repair history] H " +
                "inner join pmequip E on " +
                "H.serial = E.serial " +
                "where repair_date is null " +
                "order by trouble_assignedto", cnxn);

            DataTable dt2 = new DataTable();
            da.Fill(dt2);

            cbAssigned2.DataSource = dt2;
            cbAssigned2.DisplayMember = "trouble_assignedto";


            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                ("select '' owner union select distinct owner " +
                 "from [repair history] H " +
                 "inner join pmequip E on " +
                 "H.serial = E.serial " +
                 "where repair_date is null " +
                 "order by owner", cnxn);
            
            DataTable dt3 = new DataTable();
            da.Fill(dt3);

            cbOwner.DataSource = dt3;
            cbOwner.DisplayMember = "Owner";

        }

        private void bFind_Click(object sender, EventArgs e)
        {
            if (cbSerial.Text.Length < 1)
            {
                sSerial = "";
            }
            else
            {
                sSerial = " h.serial = '" + 
                    cbSerial.Text + "' and ";
            }

            if (cbWorkRQ.Text.Length < 1)
            {
                sWorkRQ = "";
            }
            else
            {
                sWorkRQ = " trouble_work_reference_number = " +
                    cbWorkRQ.Text + " and ";
            }

            if (cbAssigned2.Text.Length < 1)
            {
                sAssigned = "";
            }
            else
            {
                sAssigned = " trouble_assignedto = '" +
                    cbAssigned2.Text + "' and ";
            }


            if (cbOwner.Text.Length < 1)
            {
                sOwner = "";
            }
            else
            {
                sOwner = " owner = '" + 
                    cbOwner.Text + "' and ";
            }

                
             cnxn = new SqlConnection(g.db);
             da = new SqlDataAdapter(
                  "Select  " +
                  "H.serial, " +
                  "trouble_work_reference_number, " +
                  "trouble_assignedto, " +
                  "owner, " +
                  "trouble from [repair history] H " +
                  "inner join pmequip E on " +
                  "H.serial = E.serial " +
                  "where " + sSerial +
                   sWorkRQ + 
                   sAssigned +
                   sOwner +
                  " repair_date is null " +
                  " order by h.serial", cnxn);
 

             DataTable dt4 = new DataTable();

             da.Fill(dt4);

             DGV.DataSource = dt4;

        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Close();
        }

 
        public static class g
        {
            public static string WorkRefNo;
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

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.WorkRefNo = cell.EditedFormattedValue.ToString().Trim();
                //cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                //g.iDescription = cell.EditedFormattedValue.ToString().Trim();

                PMClose pm = new PMClose();
                pm.Show();

            }
        }
    }
}