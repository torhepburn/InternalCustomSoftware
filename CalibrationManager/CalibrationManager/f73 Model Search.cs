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
    public partial class f73_Model_Search : Form
    {
        BindingSource bs = new BindingSource();
        SqlDataAdapter da;
        DataTable table;

        public f73_Model_Search()
        {
            InitializeComponent();
            tbSearch.Focus();
        }

        private void bFind_Click(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(g.db);
            

            da = new SqlDataAdapter("select q.Model, q.ID, q.[Description], " +
                " q.manuf as Manufacturer,  q.Status, " +
                "l.il_location as Location from " +
                " equipment q inner join itemlocation l on " +
                "q.id = il_item " +
                " where model like '%" + tbSearch.Text.Trim() +
                "%' " +
                "and l.il_location like '%" + g.facility + 
                "%' order by model", cnxn);
            
            
            table = new DataTable();
            da.Fill(table);
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