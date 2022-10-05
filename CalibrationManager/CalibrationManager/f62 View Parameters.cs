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
    public partial class f62_View_Parameters : Form
    {
        public f62_View_Parameters()
        {
            InitializeComponent();
        }

        private void f62_View_Parameters_Load(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            SqlConnection cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("Select par1,par1nom, par1um, par1criteria, " +
                 " par2,par2nom, par2um, par2criteria, " +
                 " par3,par3nom, par3um, par3criteria, " +
                 " par4,par4nom, par4um, par4criteria, " +
                 " par5,par5nom, par5um, par5criteria, " +
                 " par6,par6nom, par6um, par6criteria " +
                 " from equipment e" +
                 " where e.id = '" + g.iID + "'", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            DGV.DataSource = bs;
        }
    }
}