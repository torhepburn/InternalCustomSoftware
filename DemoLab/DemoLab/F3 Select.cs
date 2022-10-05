using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DemoLab
{
    public partial class F3_Select : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        
        public F3_Select()
        {
            InitializeComponent();
        }

        private void F3_Select_Load(object sender, EventArgs e)
        {
            //this.Text = g.task + " " + g.item;

            cnxn = new SqlConnection(g.db);

            da = new SqlDataAdapter
                ("Select ID, [Description] from inventory" +
                 " order by id asc", cnxn);
            
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
        }
    }
}
