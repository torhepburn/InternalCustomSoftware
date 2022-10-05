using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CalibrationManager
{
    public partial class f74_Version_History : Form
    {
        SqlDataAdapter da;
        BindingSource bs = new BindingSource();
        SqlConnection cnxn;
        
        public f74_Version_History()
        {
            InitializeComponent();
        }

        private void f74_Version_History_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            da = new SqlDataAdapter
                (" Select * from versionhistory" +
                 " order by Date desc", cnxn);
            
            DataTable table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            DGV.DataSource = bs;
        }
    }
}