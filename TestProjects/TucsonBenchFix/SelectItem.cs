using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TucsonBenchFix
{
    public partial class SelectItem : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable table;
        BindingSource bs = new BindingSource();
        
        
        public SelectItem()
        {
            InitializeComponent();
        }

        private void SelectItem_Load(object sender, EventArgs e)
        {
            this.Text = "Select Item";

            cnxn = new SqlConnection(g.db);

            string select = "select  Location, Bench,ID, [desc] as Description, Status " +
                "from views.meascal order by id asc";

            da = new SqlDataAdapter(select, cnxn);
            table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            DGV.DataSource = bs;
            DGV.Show();
            cnxn.Close();
        }

        private void DGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 3)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.iID = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                g.iDescription = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.bench = cell.EditedFormattedValue.ToString().Trim();

                Change_Bench cl = new Change_Bench();
                cl.Show();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            string select = "select Location, Bench,ID, [desc] as Description, Status " +
                "from views.meascal order by id asc";

            da = new SqlDataAdapter(select, cnxn);
            table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            DGV.DataSource = bs;
            DGV.Show();
            cnxn.Close();
        }

       
    }

    public static class g
    {
        public static string item;
        public static string task;
        public static string facility;
        public static int mkid;
        public static string bench;
        public static string Ldescription;
        public static string room;
        public static string Rdescription;
        public static string Rnotes;
        public static int rID;
        public static string eBadgeID;
        public static string iID;
        public static string iDescription;
        public static int cdID;                 //calibration data id
        public static string rpt_status;
        public static string rpt_CalSource;
        public static string rpt_earliestDueDate;
        public static string rpt_latestDueDate;
        public static string db = "server = midprj01; password = views; " +
                                  "user = views; database = calibrationTus;";
    }
}