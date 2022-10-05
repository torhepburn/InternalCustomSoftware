using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TucsonBenchFix
{
    public partial class Change_Bench : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable table;
        BindingSource bs = new BindingSource();
        SqlCommand cmd;
        
        public Change_Bench()
        {
            InitializeComponent();
        }

        private void Change_Bench_Load(object sender, EventArgs e)
        {
            label1.Text = g.iID;
            label4.Text = g.iDescription;
            label2.Text = "Current Bench: " + g.bench;

            cnxn = new SqlConnection(g.db);

            string select = "select b_name, b_description " +
                "from views.lup_bench order by b_name asc";

            da = new SqlDataAdapter(select, cnxn);
            table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            DGV.DataSource = bs;
            DGV.Show();
        }

        private void DGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
            g.bench = cell.EditedFormattedValue.ToString().Trim();

            SqlConnection cnxn2 = new SqlConnection(g.db);

            cmd = new SqlCommand("Update views.meascal " +
                " set bench = '" + g.bench + "'" +
                " where id = '" + g.iID + "'");

            cmd.Connection = cnxn2;
            cnxn2.Open();
            int rowsReturned = cmd.ExecuteNonQuery();
            cnxn2.Close();

            this.Close();
        }
    }
}