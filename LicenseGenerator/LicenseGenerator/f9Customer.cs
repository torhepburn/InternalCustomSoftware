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

namespace LicenseGenerator
{
    public partial class f9Customer : Form
    {
        SqlDataReader dr;
        SqlConnection cnxn;
        DataTable table;
        SqlCommand cmd;
        private string SQL;

        public f9Customer()
        {
            InitializeComponent();
        }

        private void f9Customer_Load(object sender, EventArgs e)
        {
            if (g.task == "Block")
            {
                SQL =
                    "SELECT DISTINCT " +
                    " TRIM(CustomerNumber) [Customer Number] " +
                    ",TRIM(CustomerName) [Customer Name] " +
                    " FROM LicenseData " +
                    " WHERE CustomerNumber is not null " +
                    " AND Len(CustomerNumber) > 0 " +
                    " AND Blocked = 'No' " +
                    " ORDER BY [Customer Name]";

                label1.Text = "Click on line to select customer to block.";
            }
            else
            {
                SQL =
                    "SELECT DISTINCT " +
                    " TRIM(CustomerNumber) [Customer Number] " +
                    ",TRIM(CustomerName) [Customer Name] " +
                    " FROM LicenseData " +
                    " WHERE CustomerNumber is not null " +
                    " AND Len(CustomerNumber) > 0 " +
                    " AND Blocked = 'Yes' " +
                    " ORDER BY [Customer Name]";

                label1.Text = "Click on line to select customer to unblock.";
            }

            GetData();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            if (g.task == "Block")
            {
                SQL =
                "SELECT DISTINCT " +
                " TRIM(CustomerNumber) [Customer Number] " +
                ",TRIM(CustomerName) [Customer Name] " +
                " FROM LicenseData " +
                " WHERE (CustomerNumber is not null " +
                " AND Len(CustomerNumber) > 0) " +
                " AND Blocked = 'No' " +
                " AND CustomerNumber LIKE '%" + tbSearch.Text.Trim() + "%' " +
                " OR CustomerName LIKE '%" + tbSearch.Text.Trim() + "%' " +
                " ORDER BY [Customer Name]";
            }
            else
            {
                SQL =
                "SELECT DISTINCT " +
                " TRIM(CustomerNumber) [Customer Number] " +
                ",TRIM(CustomerName) [Customer Name] " +
                " FROM LicenseData " +
                " WHERE (CustomerNumber is not null " +
                " AND Len(CustomerNumber) > 0) " +
                " AND Blocked = 'Yes' " +
                " AND CustomerNumber LIKE '%" + tbSearch.Text.Trim() + "%' " +
                " OR CustomerName LIKE '%" + tbSearch.Text.Trim() + "%' " +
                " ORDER BY [Customer Name]";
            }
            GetData();
        }

        private void GetData()
        {
            cnxn = new SqlConnection(g.db);

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
            DGV.Columns[0].Width = 70;
            //DGV.Columns[0].HeaderCell.Value = "PART";
            DGV.Columns[1].Width = 300;
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
                string customerNumber = cell.EditedFormattedValue.ToString().Trim();

                if (g.task == "Block")
                {
                    SQL = "UPDATE LicenseData set Blocked = 'Yes' " +
                        "WHERE CustomerNumber = '" + cell.EditedFormattedValue.ToString().Trim() + "'";
                }
                else
                {
                    SQL = "UPDATE LicenseData set Blocked = 'No' " +
                        "WHERE CustomerNumber = '" + cell.EditedFormattedValue.ToString().Trim() + "'";
                }

                cmd = new SqlCommand(SQL, cnxn);

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
                }
            }

            this.Close();
        }
    }
}
