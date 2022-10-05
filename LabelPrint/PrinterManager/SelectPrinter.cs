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

namespace PrinterManager
{
    public partial class SelectPrinter : Form
    {
        SqlConnection cnxn;
        DataTable table;
        SqlCommand cmd;
        private string SQL;

        public SelectPrinter()
        {
            InitializeComponent();
        }

        private void SelectPrinter_Load(object sender, EventArgs e)
        {
            SQL = g.queryBase +
                "WHERE Permission = 'PRINTER' " +
                "AND Application != 'PM' " +
                "ORDER BY Application, PCID ";

            GetData();
        }
        private void GetData()
        {
            cnxn = new SqlConnection(g.db);

            cmd = new SqlCommand(SQL, cnxn);
            
            try
            {
                cnxn.Open();
                SqlDataReader drMain = cmd.ExecuteReader();
                table = new DataTable();
                table.Load(drMain);
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
            DGV.Show();

            DGV.Columns[0].Width = 180;
            DGV.Columns[1].Width = 140;
            DGV.Columns[2].Width = 180;
            DGV.Columns[3].Width = 250;
            DGV.Columns[4].Width = 180;
            DGV.Columns[5].Visible = false;
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            SQL = g.queryBase +
                "WHERE Permission = 'PRINTER' " +
                "AND Application != 'PM' " +
                "AND PCID LIKE '%" + tbSearch.Text + "%' " +
                "OR UserName LIKE '%" + tbSearch.Text + "%' " +
                "OR Application LIKE '%" + tbSearch.Text + "%' " +
                "OR PermissionValue LIKE '%" + tbSearch.Text + "%' " +
                "OR Location LIKE '%" + tbSearch.Text + "%' " +
                "ORDER BY Application, PCID ";

            GetData();
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 | e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.computer = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.login = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.application = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                g.printer = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[4];
                g.location = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[5];
                g.ID = cell.EditedFormattedValue.ToString().Trim();
                DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)DGV.Rows[e.RowIndex].Cells[6];
                object o = cbc.EditedFormattedValue;
                if (o is false)
                {
                    g.ZPL = false;
                }
                else
                {
                    g.ZPL = true;
                }

                EditData ed = new EditData();
                ed.ShowDialog();

                GetData();
            }
        }
    }
}
