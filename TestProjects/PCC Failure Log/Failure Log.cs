using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PCC_Failure_Log
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
                ("server = midsql01; user = views; " +
                 "password = views; database = productioncontrol;");
            SqlDataAdapter da = new SqlDataAdapter
                ("select * from [failure log] " + 
                 "where " + pV.select +
                 " order by [xml file], [board test],[minitab test]", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            dgv.DataSource = bs;
            dgv.Columns[0].Visible = false;
        }
    }
}