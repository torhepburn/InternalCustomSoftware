using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NexView
{
    public partial class Select_Serial_Number : Form
    {
        SqlConnection cnxn = new SqlConnection(g.db);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable table;

        public Select_Serial_Number()
        {
            InitializeComponent();
        }

        private void Select_Serial_Number_Load(object sender, EventArgs e)
        {
            try
            {
                cnxn.Open();
                da = new SqlDataAdapter(
                    "select sn [Serial Number] from NexView_Data " +
                    "order by sn", cnxn);
                table = new DataTable();
                da.Fill(table);
                cnxn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DGV.DataSource = table;
            DGV.Show();
            DGV.Columns[0].Width = 100;
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.serialNumber = cell.EditedFormattedValue.ToString().Trim();

                //checkFirstUse();

                //enterData();

                NexViewAccessories nv = new NexViewAccessories();
                nv.ShowDialog();
            }
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


    public static class g
    {
        public static string serialNumber;
        //public static string task;
        //public static string taskhistory;
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
        ////public static string db = "server = ct-mid-sqltest01; password = Read+Write!; " +
        //                          "user = readwrite; database = calibration;";
        //public static string db = "server = midsql01; password = Read+Write!; " +
        //                          "user = readwrite; database = calibration;";
        //public static string dbDash = "[middb01].dashboard.dbo.view_employees";
        public static string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readWrite; database = accessfrontends;";
    }

}
