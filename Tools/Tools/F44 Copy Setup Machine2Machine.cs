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
    public partial class F44_Copy_Setup_Machine2Machine : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        
        public F44_Copy_Setup_Machine2Machine()
        {
            InitializeComponent();
        }

        private void F44_Copy_Setup_Machine2Machine_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                ("select distinct machine + part_name as two from partsetup order by two", cnxn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cbddSetupSheet.DataSource = dt;
            cbddSetupSheet.DisplayMember = "two";

            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                ("select location from locations where location like 'nc%' and len(location) < 7 " +
                "order by location", cnxn);
            dt = new DataTable();
            da.Fill(dt);

            cbddMachine.DataSource = dt;
            cbddMachine.DisplayMember = "location";
        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            cnxn.Open();
            SqlCommand cmd = new SqlCommand(
                "insert into partsetup (" +
                "machine, " +
                "position, " +
                "tool_sn, " +
                "min_usable_length, " +
                "min_diamond_length, " +
                "holder_n_nut_size, " +
                "part_name) " +
                "select " +
                "'" + cbddMachine.Text + "', " +
                "position, " +
                "tool_sn, " +
                "min_usable_length, " +
                "min_diamond_length, " +
                "holder_n_nut_size, " +
                "part_name " +
                "from partsetup where machine + part_name = '" + cbddSetupSheet.Text + "'",
                 cnxn);
            cmd.ExecuteNonQuery();
            cnxn.Close();
            this.Close();
        }
    }
}