using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhoneList
{
    public partial class F1FindEmployee : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        SqlCommand cmd;
        DataTable table;
        private string Ename;
        
        public F1FindEmployee()
        {
            InitializeComponent();
        }

        private void F1FindEmployee_Load(object sender, EventArgs e)
        {
            refresh();
         }

        private void bSearch_Click(object sender, EventArgs e)
        {
            if (g.task == "add")
            {
                getData("Select Name " +
                    " from middb01.dashboard.dbo.view_employees  " +
                    " where mk_costCenter is not null " +
                    " and name like '%" + tbSearch.Text + "%' " +
                    " order by name");
            }
            else
            {
                getData("Select last,  first, " +
                    " extension, dept, loc, uid from empTQPROSDB2  " +
                    " where termdate is null " +
                    " and (last like '%" + tbSearch.Text + "%' " +
                    " or first like '%" + tbSearch.Text + "%' )" +
                    " order by last");
            }
        }

        private void getData(string select)
        {
            cnxn = new SqlConnection
                (g.db);
            DGV.Show();
            DGV.DataSource = table;

            try
            {
                da = new SqlDataAdapter(select, cnxn);
                table = new DataTable();
                da.Fill(table);
                DGV.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (g.task == "add")
            {
                DGV.Columns[1].Visible = false;
                DGV.Columns[2].Visible = false;
                DGV.Columns[3].Visible = false;
            }
            else
            {
                DGV.Columns[2].Visible = false;
                DGV.Columns[3].Visible = false;
                DGV.Columns[4].Visible = false;
                DGV.Columns[5].Visible = false;
            }
            tbSearch.Focus();
        }

        private void refresh()
        {
            if (g.task == "add")
            {
                getData("Select Name " +
                    " from middb01.dashboard.dbo.view_employees  " +
                    " where mk_costCenter is not null order by name");
            }
            else
            {
                this.Width = 650;
                getData("Select last,  first, " +
                    " extension, dept, loc, uid from empTQPROSDB2  " +
                    " where termdate is null " +
                    " order by last");
            }
            tbSearch.Focus();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 1)
            {
                return;
            }
            else
            {
                if (g.task == "add")
                {
                    DataGridViewTextBoxCell cell =
                        (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                    g.name = cell.EditedFormattedValue.ToString().Trim();
                    
                }
                else
                {
                    DataGridViewTextBoxCell cell =
                        (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                    g.last = cell.EditedFormattedValue.ToString().Trim();
                    cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                    g.first = cell.EditedFormattedValue.ToString().Trim();
                    cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                    g.extension = cell.EditedFormattedValue.ToString().Trim();
                    cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                    g.Dept = cell.EditedFormattedValue.ToString().Trim();
                    cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[4];
                    g.loc = cell.EditedFormattedValue.ToString().Trim();
                    cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[5];
                    g.UID = cell.EditedFormattedValue.ToString().Trim();
                }

                F2EditEmployee f2 = new F2EditEmployee();
                f2.ShowDialog();
            }
        }
    }
}