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
    public partial class F42_Edit_Setup_Sheet_Tools : Form
    {
        public F42_Edit_Setup_Sheet_Tools()
        {
            InitializeComponent();
        }

        private void F42_Edit_Setup_Sheet_Tools_Load(object sender, EventArgs e)
        {

        }

        private void bSave_Click(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(g.db);
            SqlCommand cmd = new SqlCommand
                ("insert into partsetup ( " +
                 "machine, " +
                 "position, " +
                 "tool_sn, " +
                 "min_usable_length, " +
                 "min_diamond_length, " +
                 "holder_n_nut_size, " +
                 "part_name) values ('" +
                 tbMachine.Text.ToUpper().Trim() + "'," +
                 tbPosition.Text.Trim() + ",'" +
                 tbSN.Text.Trim() + "','" +
                 tbMinUsable.Text.Trim() + "','" +
                 tbMinDiamond.Text.Trim() + "','" +
                 tbHolder.Text.Trim() + "','" +
                 tbName.Text.ToUpper().Trim() + "')", cnxn);
            cnxn.Open();
            cmd.ExecuteNonQuery();

            tbPosition.Text = "";
            tbSN.Text = "";
            tbMinUsable.Text = "";
            tbMinDiamond.Text = "";
            tbHolder.Text = "";
            tbPosition.Focus();
        }
    }
}
