using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PriceList
{
    public partial class f3_Sales_Text : Form
    {
        private string itemCode;
        private string SqlDb = "server = midsql01; password = Read+Write!; user = readwrite; " +
                  "database = pricelists;";
        SqlDataAdapter da;
        SqlConnection cnxn;
        BindingSource bs = new BindingSource();
        
        public f3_Sales_Text(string item)
        {
            InitializeComponent();
            itemCode = item;
        }

        private void f3_Sales_Text_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(SqlDb);
        
            da = new SqlDataAdapter("select Item_Code, " +
                "Sales_Text, " +
                "Zygo_Company_Number " +
                "from ItemText " +
                "where item_code = '" + itemCode +
                "'", cnxn);


            DataTable table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            DGV.DataSource = bs;
            DGV.Show();

        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 1)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                string item = cell.EditedFormattedValue.ToString().Trim();
                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                string company = cell.EditedFormattedValue.ToString().Trim();
                //open a new window to select the correct sales text.
                //delete the unneeded sales text.  update the search
                //until there are no dups left

                //cnxn = new SqlConnection(SqlDb);

                SqlCommand cmd = new SqlCommand("Delete from ItemText where " +
                    "item_code = '" + item + "' and " +
                    "zygo_company_number = " + company + " ", cnxn);
                
                cnxn.Open();
                int rowsReturned = cmd.ExecuteNonQuery();
                cnxn.Close();
                

                PriceList PL = new PriceList();
                PL.Show();
                this.Close();
            }
        }
    }
}