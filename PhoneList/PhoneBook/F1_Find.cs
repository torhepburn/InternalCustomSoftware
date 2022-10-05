using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhoneBook
{
    public partial class F1_Find : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        public F1_Find()
        {
            InitializeComponent();
        }

        private void F1_Find_Load(object sender, EventArgs e)
        {
            GetData("SELECT * FROM v_Phonebook");

        }

        private void GetData(string select)
        {
            cnxn = new SqlConnection(g.db);

            cmd = new SqlCommand(select, cnxn);

            SqlDataReader dr;

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();

                dt.Load(dr);

                DGV.DataSource = dt;
                DGV.Show();

                DGV.Columns[0].Width = 200;
                DGV.Columns[2].Width = 200;
                DGV.Columns[4].Visible = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            GetData(
                    " Select * from v_Phonebook " +
                    " where " +
                    " name like '%" + tbSearch.Text + "%' " +
                    " or Name_in_AD like '%" + tbSearch.Text + "%' " +
                    " order by name");
                
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 1)
            {
                return;
            }
            else
            {
                if (g.task == "ADD")
                {
                    DataGridViewTextBoxCell cell =
                        (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                    g.name = cell.EditedFormattedValue.ToString().Trim();

                    if (g.name.Length > 0)
                    {
                        MessageBox.Show("Can not add person who is already in database");
                        return;
                    }
                    else
                    {
                        cell =
                            (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                        g.name = cell.EditedFormattedValue.ToString().Trim();
                    }

                }
                else
                {
                    DataGridViewTextBoxCell cell =
                        (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                    g.name = cell.EditedFormattedValue.ToString().Trim();
                    cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                    g.extension = cell.EditedFormattedValue.ToString().Trim();
                    cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                    g.ADname = cell.EditedFormattedValue.ToString().Trim();
                    cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                    g.location = cell.EditedFormattedValue.ToString().Trim();
                    cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[4];
                    g.UID = cell.EditedFormattedValue.ToString().Trim();
                }

                F2_AddEdit f2 = new F2_AddEdit();
                f2.ShowDialog();
            }
        }
    }
}
