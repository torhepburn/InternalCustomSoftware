using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RoutingView
{
    public partial class RoutingView : Form
    {
        SqlConnection cnxn = new SqlConnection("server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;");
        SqlDataAdapter da;
        DataTable table;
        
        public RoutingView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                cnxn.Open();
                da = new SqlDataAdapter(
                    "select * from mmx_routing r left join mmx_text t " +
                    "on CAST(CAST(r.TEXT as varchar(20)) as int) = CAST(t.textkey as int) order " +
                    "by manufactured_item, operation_route", cnxn);
                table = new DataTable();
                da.Fill(table);
                cnxn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DGV.DataSource = table;
            DGV.Show();
        }
    }
}
