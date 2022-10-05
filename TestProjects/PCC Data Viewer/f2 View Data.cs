using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PCC_Data_Viewer
{
    public partial class f2_View_Data : Form
    {
        BindingSource bs = new BindingSource();
        
        public f2_View_Data()
        {
            InitializeComponent();
        }

        private void f2_View_Data_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
                ("server = midsql01; user = views; " +
                 "password = views; database = productioncontrol;");
            SqlDataAdapter da = new SqlDataAdapter
                ("select * from [test data] where " +
                 v.select , cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            dgv.DataSource = bs;
 
        }
    }
}