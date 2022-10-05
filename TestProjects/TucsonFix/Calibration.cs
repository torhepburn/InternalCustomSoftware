using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TucsonFix
{
    public partial class Calibration : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable table;
        BindingSource bs = new BindingSource();
        
        public Calibration()
        {
            InitializeComponent();
        }

        private void Calibration_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            string select = "select ID, [desc] as Description, Location, Bench, Status " +
                "from views.meascal order by id asc";

            da = new SqlDataAdapter(select, cnxn);
            table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            DGV.DataSource = bs;
            DGV.Show();
            cnxn.Close();

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
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.iID = cell.EditedFormattedValue.ToString().Trim();
                
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.iDescription = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.location = cell.EditedFormattedValue.ToString().Trim();

                Change_Location cl = new Change_Location();
                cl.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            string select = "select ID, [desc] as Description, Location, Bench, Status " +
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
        public static string location;
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