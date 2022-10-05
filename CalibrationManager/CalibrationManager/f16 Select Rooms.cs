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
    public partial class f16_Select_Rooms : Form
    {
        SqlDataAdapter da;
        BindingSource bs = new BindingSource();
        SqlConnection cnxn;
                 
        public f16_Select_Rooms()
        {
            InitializeComponent();
        }

        private void f16M_View_Rooms_Middlefield_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
                    
            dataGridView1.Show();
            dataGridView1.DataSource = bs;

            try
            {
                int facilityLength = g.facility.Length + 1;
                string select = "Select substring(r_RoomNumber, " + (facilityLength + 1) + 
                    ", (len(r_RoomNumber)) - " + facilityLength + ") as [Room Number], " +
                    "R_Description as Description, R_Notes as Notes, " +
                    "R_ID as ID from room " +
                    " where r_RoomNumber like '" + g.facility + "%' " +
                    " order by r_RoomNumber";
                da = new SqlDataAdapter(select, cnxn);
                DataTable table = new DataTable();
                da.Fill(table);
                bs.DataSource = table;
                dataGridView1.Columns[3].Visible = false;

                SqlCommand cmd = new SqlCommand(select);
                cnxn = new SqlConnection(g.db);
                cmd.Connection = cnxn;
                cnxn.Open();
                object o = cmd.ExecuteScalar();
                if (o == null)
                {
                    MessageBox.Show("Room data must be entered before location data.");
                    Close();
                }
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (g.task == "Edit")
            {
                if (e.RowIndex == -1 && e.ColumnIndex <4)
                {
                    return;
                }
                else
                {
                    DataGridViewTextBoxCell cell =
                        (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[0];
                    g.room = cell.EditedFormattedValue.ToString().Trim();
                    cell = (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[1];
                    g.Rdescription = cell.EditedFormattedValue.ToString().Trim();
                    cell = (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[2];
                    g.Rnotes = cell.EditedFormattedValue.ToString().Trim();
                    cell = (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[3];
                    g.rID = Convert.ToInt32(cell.EditedFormattedValue.ToString().Trim());
                    f40_Room f40 = new f40_Room();
                    f40.Show();
                    this.Close();
                }
            }
            if (g.task == "Delete")
            {
                if (e.RowIndex == -1 && e.ColumnIndex < 4)
                {
                    return;
                }
                else
                {
                    DataGridViewTextBoxCell cell =
                        (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[3];
                    g.rID = Convert.ToInt32(cell.EditedFormattedValue.ToString().Trim());

                    bDelete.Visible = true;
                 }
            }
            if (g.task == "Add" & g.item == "Location")
            {
                if (e.RowIndex == -1 && e.ColumnIndex == 1)
                {
                    return;
                }
                else
                {
                    DataGridViewTextBoxCell cell =
                        (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[0];

                    g.room = cell.EditedFormattedValue.ToString().Trim();
                    g.room = g.facility + "-" + g.room;

                    f17e_Add_Bench A = new f17e_Add_Bench();
                    A.Show();
                    this.Close();
                }
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand 
                ("Delete from room where r_id = '" + g.rID + "'");
            cnxn = new SqlConnection(g.db);
            cnxn.Open();
            cmd.Connection = cnxn;
            int rowsReturned = cmd.ExecuteNonQuery();
            cnxn.Close();
            this.Close();
        }
    }
}