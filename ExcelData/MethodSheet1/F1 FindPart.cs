using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MethodSheet1
{
    public partial class F1_FindPart : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;

        public F1_FindPart()
        {
            InitializeComponent();
        }

        private void F1_FindPart_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
                
            try
            {
                da = new SqlDataAdapter
                ("Select partnumber 'Part Number' from OpticsMethodSheetData " +
                 " order by partnumber", cnxn);

                DataTable table = new DataTable();
                da.Fill(table);
                DGV.DataSource = table;

                DGV.Columns[0].Width = 400;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                g.partnumber = cell.EditedFormattedValue.ToString().Trim();

                F2_EnterReleaseData f2 = new F2_EnterReleaseData();
                f2.ShowDialog();
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            try
            {
                da = new SqlDataAdapter
                    ("Select partnumber 'Part Number' from OpticsMethodSheetData " +
                     "where partnumber like '%" + tbSearchEquipment.Text + "%' " +
                     " order by partnumber", cnxn);


                DataTable table = new DataTable();
                da.Fill(table);

                DGV.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            EditPartData f4 = new EditPartData();
            f4.ShowDialog();
        }

        
    }

    public static class g
    {
        public static string partnumber;
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
        public static string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";
        
    }
}
