using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PL1
{
    public partial class Form1 : Form
    {
        BindingSource bs1 = new BindingSource();
        BindingSource bs2 = new BindingSource();
        SqlConnection cnxn;
        SqlDataAdapter da1;
        SqlDataAdapter da2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection
                ("server = middbsql; password = views; user = views; " +
                  "database = pricelists;");
            DGV1.Show();
            DGV1.DataSource = bs1;

            try
            {
                da1 = new SqlDataAdapter
               ("select " +
                "Item_Code as [Item Code], " +
                "ItemClassCode, " +
                "ItemNotes, " +
                "TradeInValue " +
                "from itemcodeclassnotes " +
                "order by item_code ", cnxn);
                DataTable table1 = new DataTable();
                da1.Fill(table1);
                bs1.DataSource = table1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            DGV1.DataSource = bs1;

            try
            {
                da2 = new SqlDataAdapter
               ("select " +
                "ItemClassCode, " +
                "ItemClass " +
                "from itemclasses " +
                "order by itemclasscode ", cnxn);
                DataTable table2 = new DataTable();
                da2.Fill(table2);
                bs2.DataSource = table2;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            DGV2.DataSource = bs2;

            
        }

        private void DGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 3)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                   (DataGridViewTextBoxCell)DGV1.Rows[e.RowIndex].Cells[0];
                LItem.Text = cell.EditedFormattedValue.ToString().Trim();
                 
            }
    
        }

        private void DGV2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 3)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[0];
                LLocation.Text = cell.EditedFormattedValue.ToString().Trim();
                 
            }
        }

        private void bsearchItem_Click(object sender, EventArgs e)
        {
            try
            {
                da1 = new SqlDataAdapter(
                    "select " +
                    "Item_Code as [Item Code], " +
                    "ItemClassCode, " +
                    "ItemNotes, " +
                    "TradeInValue " +
                    "from itemcodeclassnotes " +
                    "where item_code like '%" +
                    tbSearchItem.Text.Trim() + 
                    "%' order by item_code ", cnxn);
                    
                DataTable table1 = new DataTable();
                da1.Fill(table1);
                bs1.DataSource = table1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnxn.Close();
            DGV1.Refresh();
        }

        private void bSearchClassCode_Click(object sender, EventArgs e)
        {
            try
            {
                da2 = new SqlDataAdapter(
                    "select " +
                    "ItemClassCode, " +
                    "ItemClass " +
                    "from itemclasses " +
                    "where itemclasscode like '%" +
                    tbSearchLocation.Text.Trim() +
                    "%' order by itemclasscode "
                    , cnxn);
                DataTable table2 = new DataTable();
                da2.Fill(table2);
                bs2.DataSource = table2;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnxn.Close();
            DGV2.Refresh();
        }

        private void bSearchDescription_Click(object sender, EventArgs e)
        {
            try
            {
                da2 = new SqlDataAdapter(
                    "select " +
                    "ItemClassCode, " +
                    "ItemClass " +
                    "from itemclasses " +
                    "where itemclass like '%" +
                    tbSearchLocation.Text.Trim() +
                    "%' order by itemclasscode "
                    , cnxn);
                   
                DataTable table2 = new DataTable();
                da2.Fill(table2);
                bs2.DataSource = table2;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnxn.Close();
            DGV2.Refresh();
        }

        private void bAssign_Click(object sender, EventArgs e)
        {
            if (LItem.Text.Length == 0)
            {
                MessageBox.Show("An Item must be selected.");
            }
            
            if (LLocation.Text.Length == 0)
            {
                MessageBox.Show("A Class must be selected.");
            }

            if (LItem.Text.Length != 0 & LLocation.Text.Length != 0)
            {

                cnxn = new SqlConnection
                ("server = middbsql; password = views; user = views; " +
                  "database = pricelists;");

                SqlCommand cmd = new SqlCommand
                    ("update itemcodeclassnotes set itemclasscode = '" + LLocation.Text.Trim() +
                    "' where item_code = '" + LItem.Text + "'", cnxn);

                cnxn.Open();
                int rowsReturned = cmd.ExecuteNonQuery();
                cnxn.Close();
                try
                {
                    da1 = new SqlDataAdapter
                        ("select " +
                        "Item_Code as [Item Code], " +
                        "ItemClassCode, " +
                        "ItemNotes, " +
                        "TradeInValue " +
                        "from itemcodeclassnotes " +
                        "order by item_code ", cnxn);
                    DataTable table1 = new DataTable();
                    da1.Fill(table1);
                    bs1.DataSource = table1;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                cnxn.Close();
                DGV1.Refresh();
                LLocation.Text = "";
                LItem.Text = "";
                tbSearchItem.Text = "";
                tbSearchLocation.Text = "";
            }
        }
    }
}