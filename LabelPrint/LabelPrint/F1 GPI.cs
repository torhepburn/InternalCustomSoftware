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
            this.Text = "GPI Labels.exe version " + Application.ProductVersion;
            Lprinter.Text = "Printing on: " + gpi.printer;

            //cnxnNAV = new SqlConnection("server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
            //                "user = navdb_read; database = ZYGO-NAV-PROD;");

            //try
            //{
            //    cnxn.Open();
            //    da = new SqlDataAdapter(
            //        "SELECT No_, [Description] FROM ZYGO$Item " +
            //        "ORDER BY No_"
            //        , cnxnNAV);
            //    table = new DataTable();
            //    da.Fill(table);
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    cnxnNAV.Close();
            //}

            //Lprinter.Text = "Printing on: " + gpi.printer;

            cnxn = new SqlConnection(gpi.db);

            try
            {
                cnxn.Open();
                da = new SqlDataAdapter(
                    "SELECT ItemNo, [Description], BinNumber, [Bin Code], FullQuantity FROM StockroomLowBinsAppendix " +
                    "WHERE LEN(Description) > 0 " +
                    "ORDER BY ItemNo"
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
            DGV.Columns[2].Width = 60;
            DGV.Columns[3].Visible = false;
            DGV.Columns[4].Visible = false;
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
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                gpi.iBinNumber = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                gpi.iBinCode = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[4];
                gpi.iQuantity = cell.EditedFormattedValue.ToString().Trim();


                F2_GPI_Details f2 = new F2_GPI_Details();
                f2.Show();
                
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                ("SELECT ItemNo, [Description] FROM StockroomLowBinsAppendix " +
                 " where ItemNo LIKE '%" + tbSearchPartNumber.Text + "%' " +
                 "or [Description] like '%" + tbSearchPartNumber.Text + "%' " +
                 " order by ItemNo ", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
        }

        private void bItem_Click(object sender, EventArgs e)
        {
            g.item = tbSearchPartNumber.Text.ToString().Trim().ToUpper();
            tbSearchPartNumber.Text = "";
            SqlCommand cmd = new SqlCommand(
                "SELECT ItemNo FROM StockroomLowBinsAppendix " +
                "where ItemNo = '" + g.item + "'");
            cnxn = new SqlConnection(g.db);
            cmd.Connection = cnxn;
            cnxn.Open();
            object o = cmd.ExecuteScalar();

            if (o == null)
            {
                MessageBox.Show("No part number found");
            }
            else
            {
                cnxn = new SqlConnection(g.db);
                cnxn.Open();
                da = new SqlDataAdapter(
                    "SELECT ItemNo, [Description], BinNumber, [Bin Code], FullQuantity FROM StockroomLowBinsAppendix " +
                    "where ItemNo = '" + g.item + "'", cnxn);
                DataTable table2 = new System.Data.DataTable();
                da.Fill(table2);
                gpi.item = table2.Rows[0].ItemArray[0].ToString().Trim();
                gpi.iDescription = table2.Rows[0].ItemArray[1].ToString().Trim();
                gpi.iBinNumber = table2.Rows[0].ItemArray[2].ToString().Trim();
                gpi.iBinCode = table2.Rows[0].ItemArray[3].ToString().Trim();
                gpi.iQuantity = table2.Rows[0].ItemArray[4].ToString().Trim();

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
        public static string iBinCode;
        public static string iQuantity;
        public static string iBinNumber;
        public static string iLabelQuantity;
        //public static string printer = "ZDesigner ZD421-203dpi ZPL (Copy 1)";
        public static string printer = @"\\ct-mid-ps01\zebrasn19";
        public static string db = "server = CT-MID-SQL11; password = views; " +
                                  "user = views; database = AccessFrontEnds;";
        public static string dbNAV = "server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
                            "user = navdb_read; database = ZYGO-NAV-PROD;";
        
    }
}
