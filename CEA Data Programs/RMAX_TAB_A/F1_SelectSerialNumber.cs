using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace RMAX_TAB_A
{
    public partial class F1_SelectSerialNumber : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        public F1_SelectSerialNumber()
        {
            InitializeComponent();
        }

        private void F1_SelectSerialNumber_Load(object sender, EventArgs e)
        {
            this.Text = "Select Serial Number  v" + Application.ProductVersion;
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter("Select [part serial number] from CEA_RMAX_MIRROR_TAB_A " +
                 "order by [part serial number]", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            DGV.Columns[0].Width = 160;
            DGV.Show();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 1)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];

                g.serialNumber = cell.EditedFormattedValue.ToString().Trim();
                F2_Select_Operation f2 = new F2_Select_Operation();
                f2.ShowDialog();
                this.Close();
            }
        }

        private void bGetItem_Click(object sender, EventArgs e)
        {
            g.serialNumber = tbSearch.Text.ToString().Trim();
            tbSearch.Text = "";
            F2_Select_Operation f2 = new F2_Select_Operation();
            f2.ShowDialog();
        }
    }

    public static class g
    {
        public static string serialNumber;
        //public static string task;
        public static string userType;
        //public static string rpt_type;
        //public static string pdf;
        public static string db = "server = midsql01; password = Read+Write!; " +
                                "user = readwrite; database = accessfrontends;";

        public static void decimalChecker(TextBox box, decimal max, decimal min)
        {
            string a = box.Text.Trim();
            if (a != "")
            {
                bool isNum;
                decimal result;
                isNum = Decimal.TryParse(box.Text, out result);
                if (isNum == false)
                {
                    MessageBox.Show("Invalid Number \r\n  \r\nMust enter 0 first for a decimal");
                    box.Text = "";
                    box.Focus();
                    return;
                }

                if (max >= Convert.ToDecimal(box.Text) & min <= Convert.ToDecimal(box.Text))
                {
                    box.BackColor = Color.FromArgb(0, 200, 0);
                }
                else
                {
                    box.BackColor = Color.FromArgb(200, 0, 0);
                }
            }
        }


    }

}
