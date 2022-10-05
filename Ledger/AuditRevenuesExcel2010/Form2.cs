using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AuditRevenuesExcel2010
{
    public partial class Form2 : Form
    {
        DataTable dt;
        DataColumn dc;
        DataRow drow;
        SqlConnection cnxn;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Lwait.Visible = false;

            dt = new DataTable();
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "Period";

            dt.Columns.Add(dc);

            for (int i = 1; i < 10; i++)
            {
                drow = dt.NewRow();
                drow[0] = g.FYear + "0" + i.ToString();
                dt.Rows.Add(drow);
            }

            for (int i = 10; i < 13; i++)
            {
                drow = dt.NewRow();
                drow[0] = g.FYear + i.ToString();
                dt.Rows.Add(drow);
            }


            DGV.DataSource = dt;
            DGV.Show();

        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.Fperiod = cell.EditedFormattedValue.ToString().Trim();

                DGV.Hide();
                Lwait.Visible = true;

                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand("spDropAuditProgramAccountActivity", cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnxn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                cnxn.Close();

                cmd = new SqlCommand("sp_AuditProgramAccountActivity", cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnxn.Open();
                SqlParameter start = cmd.Parameters.Add
                    ("@start", SqlDbType.Int);

                start.Value = Convert.ToInt32(g.FYear + "00");
                SqlParameter period = cmd.Parameters.Add
                    ("@period", SqlDbType.Int);
                period.Value = Convert.ToInt32(g.Fperiod);
                cmd.CommandTimeout = 300;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                cnxn.Close();

                Form3 f3 = new Form3();
                f3.ShowDialog();
                this.Close();
            }
        }
    }
}
