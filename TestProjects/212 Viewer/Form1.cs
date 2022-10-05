using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _12_Viewer
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
                ("server = midprj01; user = views; " +
                 "password = views; database = TandH;");
            SqlDataAdapter da  = new SqlDataAdapter
                ("select top 25 dtetime, tempf from " +
                 "tbl_readings_128_1_9_212", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            DGV.DataSource = bs;
 
        }
    }
}