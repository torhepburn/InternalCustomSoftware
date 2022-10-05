using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EditNotes
{
    public partial class Form1 : Form
    {
        SqlConnection cnxn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter
               ("select  " +
                "RTRIM(item_code) [Item Code], " +
                "RTRIM(ItemClassCode) as [Item Class Code], " +
                "RTRIM(itemNotes) as [Item Notes] " +
                "from itemcodeclassnotes " +
                "order by item_code ", cnxn);
                DataTable table = new DataTable();
                da.Fill(table);
                DGV.DataSource = table;

                DGV.Columns[0].Width = 100;
                DGV.Columns[1].Width = 60;
                DGV.Columns[2].Width = 200;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

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
                g.itemCode = cell.EditedFormattedValue.ToString().Trim();
                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.itemClass = cell.EditedFormattedValue.ToString().Trim();
                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.itemNotes = cell.EditedFormattedValue.ToString().Trim();

                f2EditItem f2 = new f2EditItem();
                f2.ShowDialog();
            }
        }

       
        private void bItem_Click(object sender, EventArgs e)
        {
            g.itemCode = tbSearchEquipment.Text.ToString().Trim().ToUpper();
            tbSearchEquipment.Text = "";

            try
            {
                SqlDataAdapter da1 = new SqlDataAdapter
                    ("select  " +
                    "RTRIM(ItemClassCode), " +
                    "RTRIM(itemNotes) " +
                    "from itemcodeclassnotes " +
                    "where item_code = '" + g.itemCode + "'", cnxn);
                DataTable table = new DataTable();
                da1.Fill(table);

                g.itemClass = table.Rows[0][0].ToString().Trim();
                g.itemNotes = table.Rows[0][1].ToString().Trim();

                f2EditItem f2 = new f2EditItem();
                f2.ShowDialog();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter
               ("select  " +
                "RTRIM(item_code) [Item Code], " +
                "RTRIM(ItemClassCode) as [Item Class Code], " +
                "RTRIM(itemNotes) as [Item Notes] " +
                "from itemcodeclassnotes " +
                "where item_code like '%" + tbSearchEquipment.Text.Trim() + "%' " +
                "order by item_code ", cnxn);
                DataTable table = new DataTable();
                da.Fill(table);
                DGV.DataSource = table;

                DGV.Columns[0].Width = 100;
                DGV.Columns[1].Width = 60;
                DGV.Columns[2].Width = 200;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
    }

    public static class g
    {
        public static string itemCode;
        public static string itemClass;
        public static string itemNotes;
        public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                                  "user = readwrite; database = PriceLists;";
    }
}
