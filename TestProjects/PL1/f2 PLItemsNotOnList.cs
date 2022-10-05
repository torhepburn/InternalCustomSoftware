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
    public partial class f2_PLItemsNotOnList : Form
    {
        BindingSource bs1 = new BindingSource();
        BindingSource bs2 = new BindingSource();
        SqlConnection cnxn;
        
        public f2_PLItemsNotOnList()
        {
            InitializeComponent();
        }

        private void f2_PLItemsNotOnList_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection
                ("server = midsql01; password = Read+Write!; user = readwrite; " +
                  "database = pricelists;");

            DGV1.Show();
            DGV1.DataSource = bs1;

            try
            {
                SqlDataAdapter da1 = new SqlDataAdapter
               ("select distinct " +
                "Item_Code as [Item Code] " +
                "from plistitemsls " +
                "where item_code not in " +
                "(Select item_code " +
                "from itemcodeclassnotes) " +
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

            DGV2.Show();
            DGV2.DataSource = bs2;

            try
            {
                SqlDataAdapter da2 = new SqlDataAdapter
               ("select  " +
                "ItemClassCode as [Item Class Code], " +
                "ItemClass as [Item Class] " +
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
            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV1.Rows[e.RowIndex].Cells[0];
                Litem.Text = cell.EditedFormattedValue.ToString().Trim();
            }
        }

        private void bEnter_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Insert into ItemCodeClassNotes " +
                    "(item_code, ItemClassCode, ItemNotes,tradeInValue) values ('" 
                    + Litem.Text.Trim() + "','" +
                    Lclass.Text.Trim() + "','" +
                    tbNotes.Text.Trim() + "','" +
                    tbTrade.Text.Trim() + "')", cnxn);
                cmd.Connection = cnxn;
                cnxn.Open();
                int rowsReturned = cmd.ExecuteNonQuery();
                cnxn.Close();
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DGV2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[0];
                Lclass.Text = cell.EditedFormattedValue.ToString().Trim();
            }
        }

        private void bNewClass_Click(object sender, EventArgs e)
        {
            f3_AssignClass f3 = new f3_AssignClass();
            f3.Show();

           
        }

        private void f2_PLItemsNotOnList_Activated(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da2 = new SqlDataAdapter
               ("select  " +
                "ItemClassCode as [Item Class Code], " +
                "ItemClass as [Item Class] " +
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
            DGV2.Refresh();
        }

    }
}