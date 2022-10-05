using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MicroscopeDB
{
    public partial class SpreadsheetView : Form
    {
        public SpreadsheetView()
        {
            InitializeComponent();
        }

        private void SpreadsheetView_Load(object sender, EventArgs e)
        {
            LproductLine.Text = g.ProductLine;

            SqlConnection cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter(
                " SELECT * " +
                " FROM MicroscopeData WHERE " +
                " ProductLine = '" + g.ProductLine + "'", cnxn);

            DataTable table = new DataTable();

            da.Fill(table);

            DGV.DataSource = table;
            DGV.Show();
                
        }
    }
}
