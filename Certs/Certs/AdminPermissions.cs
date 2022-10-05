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

namespace Certs
{
    public partial class AdminPermissions : Form
    {
        SqlDataReader dr;
        SqlConnection cnxn;
        DataTable table;
        SqlCommand cmd;

        public AdminPermissions()
        {
            InitializeComponent();
        }

        private void AdminPermissions_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            GetData();
        }

        private void GetData()
        {
            string SQL =
                "SELECT " +
                " cn [Name] " +
                ",TRIM(UserName) [Login Name] " +
                ",TRIM([Permission]) Permission " +
                ",TRIM(PermissionValue) [Permission Value]" +
                " FROM applicationSetup s " +
                " LEFT JOIN EmployeesAmetekAD a " +
                " ON s.username = a.loginname " +
                " WHERE Application = 'CertificationManager.exe' ";

            if (g.search.Length > 0)
            {
                SQL += g.search;
            }

            SQL += " ORDER BY [UserName] ";

            cmd = new SqlCommand(SQL, cnxn);
            table = new DataTable();

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();

                table.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            DGV.DataSource = table;
            DGV.Columns[0].Width = 150;
            DGV.Columns[1].Width = 100;
            DGV.Columns[2].Width = 100;
            DGV.Columns[3].Width = 100;
            //DGV.Columns[4].Width = 40;
            DGV.Show();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            g.search = " and ([username] like '%" + tbSearch.Text + "%' " +
               "OR [cn] like '%" + tbSearch.Text + "%' " +
               "OR [Permission] like '%" + tbSearch.Text + "%' " +
               "OR [sn] like '%" + tbSearch.Text + "%' )";

            GetData();
        }

        private void bGet_Click(object sender, EventArgs e)
        {

        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                    DataGridViewTextBoxCell cell =
                        (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                    g.employeeName = cell.EditedFormattedValue.ToString().Trim();

                    cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                    g.loginname = cell.EditedFormattedValue.ToString().Trim();

                    cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                    g.permission = cell.EditedFormattedValue.ToString().Trim();

                    cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                    g.permissionValue = cell.EditedFormattedValue.ToString().Trim();

                if (cbDelete.Checked)
                {
                    cmd = new SqlCommand(
                        "DELETE FROM ApplicationSetup " +
                        " WHERE username = '" + g.loginname + "' " +
                        " AND Application = 'CertificationManager.exe'", cnxn);

                    try
                    {
                        cnxn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn.Close();
                        GetData();
                    }
                }
                else
                {
                    AdminAddUser u = new AdminAddUser();
                    u.ShowDialog();
                }
            }

        }
    }
}
