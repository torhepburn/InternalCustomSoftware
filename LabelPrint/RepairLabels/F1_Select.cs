using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RepairLabels
{
    public partial class F1_Select : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable table;

        public F1_Select()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection("server = PA-HOR-AS408; password = 2018#ameteK; " +
                                  "user = navdb_read; database = ZYGO-NAV-PROD;");

            this.Text = "Repair Labels - Printing on Zebra TLP2844";

            g.printer = "Zebra TLP2844";
            //g.printer = @"\\midprtsrv\zebrasnjv";

            try
            {
                cnxn.Open();
                da = new SqlDataAdapter(
                    "select No_, Description from ZYGO$Item " +
                    "order " +
                    "by No_", cnxn);
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

            DGV.Columns[0].Width = 90;
            DGV.Columns[1].Width = 250;
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                ("Select No_, description from ZYGO$Item " +
                 " where No_ like '%" + tbSearchPartNumber.Text + "%' " +
                 "or [Description] like '%" + tbSearchPartNumber.Text + "%' " +
                 " order by item_code", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
        }

        private void bItem_Click(object sender, EventArgs e)
        {
            g.item = tbSearchPartNumber.Text.ToString().Trim().ToUpper();
            tbSearchPartNumber.Text = "";
            SqlCommand cmd = new SqlCommand(
                "select No_ from ZYGO$Item " +
                "where No_ = '" + g.item + "'");
            cnxn = new SqlConnection(g.db);
            cmd.Connection = cnxn;
            cnxn.Open();
            object o = cmd.ExecuteScalar();

            if (o == null)
            {
                F3_Non_Standard_Parts f3 = new F3_Non_Standard_Parts();
                f3.ShowDialog();
            }
            else
            {
                cnxn = new SqlConnection(g.db);
                cnxn.Open();
                da = new SqlDataAdapter(
                    "Select No_, [Description] " +
                    "from ZYGO$Item " +
                    "where No_ = '" + g.item + "'", cnxn);
                DataTable table2 = new System.Data.DataTable();
                da.Fill(table2);
                g.item = table2.Rows[0].ItemArray[0].ToString().Trim();
                g.iDescription = table2.Rows[0].ItemArray[1].ToString().Trim();
                
                F2_Label_Details f2 = new F2_Label_Details();
                f2.ShowDialog();
            }

        }

        private void bFreeText_Click(object sender, EventArgs e)
        {
            g.item = tbSearchPartNumber.Text.ToString().Trim().ToUpper();
            tbSearchPartNumber.Text = "";
            F3_Non_Standard_Parts f3 = new F3_Non_Standard_Parts();
            f3.ShowDialog();
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
                g.item = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.iDescription = cell.EditedFormattedValue.ToString().Trim();
                //cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                //g.iRevision = cell.EditedFormattedValue.ToString().Trim();

                F2_Label_Details f2 = new F2_Label_Details();
                f2.ShowDialog();
            }
        }

        private void tbSearchPartNumber_Leave(object sender, EventArgs e)
        {
            tbSearchPartNumber.Text = tbSearchPartNumber.Text.Trim().ToUpper();
        }

        private void tbSearchPartNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                bItem.Focus();
            }
        }
    }

    public static class g
    {
        public static string user;
        public static string item;
        public static string iDescription;
        public static string iRevision;
        public static string iSerialNumber;
        public static string iQuantity;
        public static string iNumberofBoxes;
        public static string iLabelQuantity;
        public static string printer;
        public static string db = "server = PA-HOR-AS408; password = 2018#ameteK; " +
                                  "user = navdb_read; database = ZYGO-NAV-PROD;";
    }
}
