using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CalibrationManager
{
    public partial class f16D_Delete_Rooms : Form
    {
        private string location;
        SqlDataAdapter da;
        BindingSource bs = new BindingSource();
        SqlConnection cxn;
        private string RoomNumber;


        public f16D_Delete_Rooms(string locate)
        {
            InitializeComponent();
            location = locate;
        }

        private void f16D_Delete_Rooms_Load(object sender, EventArgs e)
        {
            bDelete.Enabled = false;

            cxn = new SqlConnection
                   ("server = midprj01; user = views; password = views;" +
                   " database = calibration");
            DGV2.Show();
            DGV2.DataSource = bs;

            GetData("Select r_RoomNumber as [Room Number], R_Description as " +
                    "Description, R_Notes as Notes, R_ID as ID from room " +
                    " where r_RoomNumber like '" + location + "%'");
        }
        
        private void DGV2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 1)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[0];
                RoomNumber = cell.EditedFormattedValue.ToString().Trim();
                bDelete.Focus();
                bDelete.Enabled = true;
             
            }
        }

        private void GetData(string select)
        {
            try
            {
                da = new SqlDataAdapter(select, cxn);
                DataTable table = new DataTable();
                da.Fill(table);
                bs.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand
                ("select b_name from lup_bench " +
                 "where b_name like '%" + RoomNumber + "%'");
            cxn.Open();
            cmd.Connection = cxn;
            object o = cmd.ExecuteScalar();
            cxn.Close();
            if (o != null)
            {
                MessageBox.Show("Can not delete rooms " +
                    "which contain benches.");
            }
            else
            {

                cmd = new SqlCommand
                    ("Delete from lup_rooms where r_roomnumber = '" + RoomNumber + "'");
                cmd.Connection = cxn;
                cxn.Open();
                int rowsReturned = cmd.ExecuteNonQuery();
                cxn.Close();
                bDelete.Enabled = false;
                this.Close();
            }
        }

        
    }
}