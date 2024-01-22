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


namespace LabelPrint
{
    public partial class F1_GPI : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable table;

        public F1_GPI()
        {
            InitializeComponent();
        }

        private void F1_GPI_Load(object sender, EventArgs e)
        {
            Lprinter.Text = "Printing on: " + gpi.printer;

            cnxn = new SqlConnection("server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
                            "user = navdb_read; database = ZYGO-NAV-PROD;");

            try
            {
                cnxn.Open();
                da = new SqlDataAdapter(
                    "SELECT No_, [Description] FROM ZYGO$Item " +
                    "ORDER BY No_"
                    , cnxn);
                table = new DataTable();
                da.Fill(table);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            DGV.DataSource = table;
            DGV.Show();
            DGV.Columns[0].Width = 90;
            DGV.Columns[1].Width = 250;
            
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                gpi.item = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                gpi.iDescription = cell.EditedFormattedValue.ToString().Trim();
                
                
                F2_GPI_Details f2 = new F2_GPI_Details();
                f2.Show();
                
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.dbNAV);
            da = new SqlDataAdapter
                ("SELECT No_, [Description] FROM ZYGO$Item " +
                 " where No_ LIKE '%" + tbSearchPartNumber.Text + "%' " +
                 "or [Description] like '%" + tbSearchPartNumber.Text + "%' " +
                 " order by No_", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
        }

        private void bItem_Click(object sender, EventArgs e)
        {
            g.item = tbSearchPartNumber.Text.ToString().Trim().ToUpper();
            tbSearchPartNumber.Text = "";
            SqlCommand cmd = new SqlCommand(
                "SELECT No_ FROM ZYGO$Item " +
                "where No_ = '" + g.item + "'");
            cnxn = new SqlConnection(g.dbNAV);
            cmd.Connection = cnxn;
            cnxn.Open();
            object o = cmd.ExecuteScalar();

            if (o == null)
            {
                MessageBox.Show("No part number found");
            }
            else
            {
                cnxn = new SqlConnection(g.dbNAV);
                cnxn.Open();
                da = new SqlDataAdapter(
                    "SELECT No_, [Description] FROM " + g.NAVprefix + "Item " +
                    "where No_ = '" + g.item + "'", cnxn);
                DataTable table2 = new System.Data.DataTable();
                da.Fill(table2);
                gpi.item = table2.Rows[0].ItemArray[0].ToString().Trim();
                gpi.iDescription = table2.Rows[0].ItemArray[1].ToString().Trim();
                

                
                    F2_GPI_Details f2 = new F2_GPI_Details();
                    f2.Show();
                
            }

        }
    }

    public static class gpi
    {
        public static string user;
        public static string item;
        public static string iDescription;
        public static string iRevision;
        public static string editRevision;
        public static string iSerialNumber;
        public static string iQuantity;
        public static string iNumberofBoxes;
        public static string iLabelQuantity;
        public static string printer = @"\\ct-mid-ps01\zebrasn19";
        public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";
        public static string dbNAV = "server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
                            "user = navdb_read; database = ZYGO-NAV-PROD;";
        
    }
}
