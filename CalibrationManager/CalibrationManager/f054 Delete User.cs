using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CalibrationManager
{
    public partial class f054_Delete_User : Form
    {
        SqlConnection cnxn;
        
        public f054_Delete_User()
        {
            InitializeComponent();

                       
            try
            {
                cnxn = new SqlConnection(g.db);
                SqlDataAdapter da = new SqlDataAdapter(
                    "Select name as 'USER' from AccessRights " +
                    "where facility = '" + g.facility + "' order by name", cnxn);
                DataTable table = new DataTable();
                da.Fill(table);
                DGV.Show();
                DGV.DataSource = table;
                DGV.Columns[0].Width = 200;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && (e.ColumnIndex == -1))
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                label1.Text = cell.EditedFormattedValue.ToString().Trim();

                bDelete.Visible = true;
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            SqlCommand cmd = new SqlCommand(
                "Delete from AccessRights where name = '" + label1.Text + "'", cnxn);
            cnxn.Open();
            cmd.ExecuteNonQuery();
            cnxn.Close();
            this.Close();

        }

        private void f054_Delete_User_Load(object sender, EventArgs e)
        {

        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
