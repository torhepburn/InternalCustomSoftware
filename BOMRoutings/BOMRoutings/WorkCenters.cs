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

namespace BOMRoutings
{
    public partial class WorkCenters : Form
    {
        SqlConnection cnxn = new SqlConnection(g.db);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable table;

        public WorkCenters()
        {
            InitializeComponent();
        }

        private void WorkCenters_Load(object sender, EventArgs e)
        {
            try
            {
                cnxn.Open();
                da = new SqlDataAdapter(
                    "SELECT " +
                    " [No_] [Work Center]" +
                    ",[Name] [Description] " +
                    " FROM [" + g.NAVprefix + "Work Center] " +
                    " ORDER BY [No_]", cnxn);
                table = new DataTable();
                da.Fill(table);
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("WorkCenters Page " + ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            DGV.DataSource = table;
            DGV.Show();
            DGV.Columns[0].Width = 50;
            DGV.Columns[1].Width = 275;

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
                g.workCenter = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.workCenterDescription = cell.EditedFormattedValue.ToString().Trim();

                this.Close();
            }
        }
    }
}
