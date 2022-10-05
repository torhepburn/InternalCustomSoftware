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

namespace BOMRoutings
{
    public partial class FindRouting : Form
    {
        SqlConnection cnxn = new SqlConnection(g.db);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable table;
        private string SQL1 = string.Empty;


        public FindRouting()
        {
            InitializeComponent();
        }

        private void FindRouting_Load(object sender, EventArgs e)
        {
            this.Text = "BOM Routing Restructure Tool Program v" + Application.ProductVersion.Trim();

            SQL1 = "select [No_] + '      ' +  [Description] [Routing], [No_] " +
                                "from [" + g.NAVprefix + "Routing Header] ";

            gridData();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                (SQL1 + 
                 " WHERE No_ like '%" + tbSearchPartNumber.Text + "%' " +
                 " OR [Description] like '%" + tbSearchPartNumber.Text + "%' " +
                 " ORDER BY No_", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            DGV.Columns[1].Visible = false;
        }

        private void bItem_Click(object sender, EventArgs e)
        {
            g.routingNumber = tbSearchPartNumber.Text.ToString().Trim().ToUpper();
            tbSearchPartNumber.Text = "";
            SqlCommand cmd = new SqlCommand(
                 SQL1 + " WHERE No_ = '" + g.routingNumber + "' ", cnxn);
            cnxn = new SqlConnection(g.db);
            cmd.Connection = cnxn;
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();

            if (o == null)
            {
                MessageBox.Show("Not a valid routing number.");
                return;
            }
            else
            {
                Routing r = new Routing();
                r.ShowDialog();
            }
        }

        private void gridData()
        {
            try
            {
                cnxn.Open();
                da = new SqlDataAdapter(SQL1 +
                    "order by No_", cnxn);
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
            DGV.Columns[1].Visible = false;
            DGV.Columns[0].Width = 370;

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
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.routingNumber = cell.EditedFormattedValue.ToString().Trim();

                BOM b = new BOM();
                b.Show();

                Routing r = new Routing();
                r.ShowDialog();
            }
        }
    }

    public static class g
    {
        public static string routingNumber;
        public static string workCenter;
        public static int rRowIndex;
        public static string workCenterDescription;
        public static decimal currentTime;
        public static decimal newTime;
        public static decimal totalSetupTime;
        public static decimal totalRunTime;
        public static bool modifyOperation = false;
        //public static string iNumberofBoxes;
        public static string NAVprefix = "ZYGO_TEST3$";
        public static string db = "server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
                                  "user = navdb_read; database = ZYGO-NAV-TEST;";
    }
}
