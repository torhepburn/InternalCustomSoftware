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
    public partial class f65_View_Status_Codes : Form
    {
        public f65_View_Status_Codes()
        {
            InitializeComponent();
        }

        private void f65_View_Status_Codes_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter(
                "Select * from status " +
                " order by statuscode asc", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            BindingSource bs = new BindingSource();
            bs.DataSource = table;
            DGV.DataSource = bs;
            DGV.Show();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}