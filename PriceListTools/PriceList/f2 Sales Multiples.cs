using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace PriceList
{
    public partial class PriceList : Form
    {
        private string select;
        private string tableName;
        private string company;
        private string cnxn = "provider=microsoft.jet.oledb.4.0;" +
            "server=mkpd;DSN=mkpd;uid=views; pwd=views; ";
        SqlConnection SqlCnxn;
        private string SqlDb = "server = midsql01; password = Read+Write!; user = readwrite; " +
                  "database = pricelists;";
            
        BindingSource bs = new BindingSource();    
        
        public PriceList()
        {
            InitializeComponent();
        }

        private void PriceList_Load(object sender, EventArgs e)
        {

            SqlCnxn = new SqlConnection(SqlDb);

            SqlDataAdapter Sda = new SqlDataAdapter
                ("select " +
                "count(item_code) as [Number of Sales Texts], " +
                "Item_Code " +
                 "from itemtext group by item_code having " +
                 "(count(item_code) >1) ", SqlCnxn);

            DataTable Stable = new DataTable();

            Sda.Fill(Stable);

            if (Stable.Rows.Count == 0)
            {
                this.Close();
            }

            //bs.DataSource = Stable;
            //DGV.DataSource = bs;

            DGV.DataSource = Stable;
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
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];

                string item = cell.EditedFormattedValue.ToString().Trim();
                
                //open a new window to select the correct sales text.
                //delete the unneeded sales text.  update the search
                //until there are no dups left

                f3_Sales_Text f3 = new f3_Sales_Text(item);
                f3.Show();
                this.Close();
             }
        }
    }
}