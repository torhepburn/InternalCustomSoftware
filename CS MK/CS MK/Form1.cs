using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CS_MK
{
    public partial class Form1 : Form
    {
        private string test;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OleDbConnection cxn = new OleDbConnection();

            //cxn.ConnectionString = "provider=microsoft.jet.oledb.4.0;" +
            //                       "Data Source=c:\\a\\test_mk.mdb;mode=readwrite; " +
            //                       "persist security info= false";

            cxn.ConnectionString = "provider=microsoft.jet.oledb.4.0;" +
                                   "DSN=mkpd; " +
                                   "persist security info=false";

            BindingSource bs = new BindingSource();
            OleDbDataAdapter da = new OleDbDataAdapter
                ("Select " +
                 "Item_code," +
                 "Item_desc," +
                 "Bom_level," +
                 "Net_qty," +
                 "Stock_on_hand," +
                 "Stock_on_order " +
                 "from bom_bom_ind_bill where begin_item_code = '4022.631.88374'" +
                 "order by item_code asc", cxn);
            DataTable table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;

            dgv.DataSource = bs;
            dgv.Show();

        }
    }
}