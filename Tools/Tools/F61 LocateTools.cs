using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tools
{
    public partial class F61_LocateTools : Form
    {
        SqlConnection cnxn;
        
        public F61_LocateTools()
        {
            InitializeComponent();
        }

        private void F61_LocateTools_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("select lsn as SN, llocation as 'Current Location', " +
                 "t.location as 'Home Location' from tools t left join " +
                 "toollocation l on t.sn = l.lsn " +
                 "where lprogram = '" + g.program + 
                 "' and lfacility = '" + g.facility + "' " +
                 "and status is not null  and status != 'I' order by lsn", cnxn);
            DataTable dt = new DataTable();

            da.Fill(dt);

            DGV.DataSource = dt;
        }
    }
}
