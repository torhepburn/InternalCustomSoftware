using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _14_Viewer
{
    public partial class DataViewer214 : Form
    {
        BindingSource bs = new BindingSource();
        
        public DataViewer214()
        {
            InitializeComponent();
        }

        private void DataViewer214_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
               ("server = midprj01; user = views; " +
                "password = views; database = TandH;");
            SqlDataAdapter da = new SqlDataAdapter
                ("select dtetime as [Log], TempF, RH from " +
                 "tbl_readings_128_1_9_214 order by dtetime desc", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            DGV.DataSource = bs;
        }
    }
}