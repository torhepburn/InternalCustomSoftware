using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MidDBsql_Test
{
    public partial class Form1 : Form
    {
        BindingSource bs = new BindingSource();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
                ("server = middbsql; user = views; " +
                 "password = views; database = calibration;");
            SqlDataAdapter da = new SqlDataAdapter
                ("select * from equipment", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            dgv.DataSource = bs;
        }
    }
}