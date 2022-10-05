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
    public partial class F62_AddLocation : Form
    {
        public F62_AddLocation()
        {
            InitializeComponent();
        }

        private void bAddLocation_Click(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(g.db);
            SqlCommand cmd = new SqlCommand
                ("insert into locations (location, program, facility) " +
                "values ('" + tbLocation.Text.Trim() + "','" +
                g.program + "','" + g.facility + "')", cnxn);
            cnxn.Open();
            cmd.ExecuteNonQuery();
            cnxn.Close();
            this.Close();
        }
    }
}
