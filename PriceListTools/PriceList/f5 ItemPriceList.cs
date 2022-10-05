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
    public partial class f5_ItemPriceList : Form
    {
        BindingSource bs = new BindingSource();
        
        public f5_ItemPriceList()
        {
            InitializeComponent();
        }

        private void f5_ItemPriceList_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
                ("server = midsql01; password = Read+Write!; user = readwrite; " +
                  "database = pricelists;");
            SqlDataAdapter da = new SqlDataAdapter
                ("select " +
                 "Item_Code as [Item Code], " +
                 "ItemClassCode, " +
                 "ItemNotes, " +
                 "TradeInValue " +
                 "from itemcodeclassnotes " +
                 "order by item_code ", cnxn);

            DataTable table = new DataTable();

            da.Fill(table);

            bs.DataSource = table;
            DGV.DataSource = bs;

            DGV.Show();

        }
    }
}