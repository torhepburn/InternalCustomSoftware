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
    public partial class f17a_Select_Bench : Form
    {
        SqlDataAdapter da;
        BindingSource bs = new BindingSource();
        SqlConnection cnxn;

        DataTable table;

        public f17a_Select_Bench()
        {
            InitializeComponent();
            
        }

        private void f17a_Select_Bench_Load(object sender, EventArgs e)
        {
            if (g.item == "Equipment")
            {
                bBack.Visible = false;
            }
            gridload();
           
        }

        private void DGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 4)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGridView.Rows[e.RowIndex].Cells[0];
                g.location = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGridView.Rows[e.RowIndex].Cells[1];
                g.Ldescription = cell.EditedFormattedValue.ToString().Trim();

                if (g.item == "Location" & g.task == "Add" | g.task == "Edit")
                {
                    f17e_Add_Bench f17e = new f17e_Add_Bench();
                    f17e.Show();
                    this.Close();
                }
                if (g.task == "Delete")
                {
                    bDelete.Visible = true;
                    bDelete.Focus();
                }
                if (g.item == "Equipment" & g.task == "Add")
                {
                    cnxn = new SqlConnection(g.db);
                    SqlCommand cmd = new SqlCommand("Insert into ItemLocation " +
                        "(il_item, il_location) values ('" + g.iID + "','" +
                        g.location + "')");
                    cmd.Connection = cnxn;
                    cnxn.Open();
                    int rowsReturned = cmd.ExecuteNonQuery();
                    cnxn.Close();

                    cmd = new SqlCommand
                        (" select l_owner from location where " +
                         " l_id = '" + g.location + "'");
                    cmd.Connection = cnxn;
                    cnxn.Open();
                    object o = cmd.ExecuteScalar();
                    int owner = Convert.ToInt32(o.ToString().Trim());
                    cmd = new SqlCommand
                        (" Insert into ItemUser (i_item, i_user) values " +
                         "('" + g.iID + "'," + owner + ")");
                    cmd.Connection = cnxn;
                    rowsReturned = cmd.ExecuteNonQuery();
                    cnxn.Close();
                    this.Close();
                }
            }
        }
        private void bDelete_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            SqlCommand cmd = new SqlCommand
                        (" select il_location from ItemLocation where " +
                         " il_location like '" + g.location + "'");
            cmd.Connection = cnxn;
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();
            
            if (o != null)
            {
                MessageBox.Show("Can not delete a location which contains equipment.");
                return;
            }

            cmd = new SqlCommand("delete from location " +
                "where l_id = '" + g.location + "'");

            cmd.Connection = cnxn;
            cnxn.Open();
            int rowsReturned = cmd.ExecuteNonQuery();
            cnxn.Close();
            gridload();
        }

        private void f17a_Select_Bench_FormClosing(object sender, FormClosingEventArgs e)
        {
            if( g.item == "Equipment" & g.task == "Add")
            {
                SqlCommand cmd = new SqlCommand
                        (" select il_location from ItemLocation where " +
                         " il_item = '" + g.iID + "'");
                cmd.Connection = cnxn;
                cnxn.Open();
                object o = cmd.ExecuteScalar();
                cnxn.Close();
                if (o == null)
                {
                    MessageBox.Show("Must pick a location.");
                    e.Cancel = true;
                }
            }
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bNarrowSelection_Click(object sender, EventArgs e)
        {
            try
            {
                da = new SqlDataAdapter("Select l_id as Location, " +
                    "l_Description as Description, " +
                    "r_description as Room , " +
                    "name as Owner " +
                    " from location " +
                    "left join room on " + 
                    "r_roomnumber=left(l_id,(charindex('-',l_id) + " +
                    "(charindex('-',(substring(l_id,(charindex('-',l_id)+1),10)))-1))) " +
                    "left join " + g.dbDash + " e on " +
                    "l_owner=e.badgeid " +
                    "where l_id like '%" + g.facility + "%' " +
                    "and l_id like '%" + tbSearch.Text + "%' " + 
                    "order by l_id", cnxn);
                table = new DataTable();
                da.Fill(table);
                bs.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridload()
        {
            cnxn = new SqlConnection(g.db);

            DGridView.Show();
            DGridView.DataSource = bs;

            try
            {
                da = new SqlDataAdapter("Select l_id as Location, " +
                    "l_Description as Description, " +
                    "r_description as Room , " +
                    "e.name as Owner " +
                    " from location " +
                    "left join room on " +
                    "r_roomnumber=left(l_id,(charindex('-',l_id) + " +
                    "(charindex('-',(substring(l_id,(charindex('-',l_id)+1),10)))-1))) " +
                    "left join " + g.dbDash + " e on " +
                    "l_owner=e.badgeid " +
                    "where l_id like '%" + g.facility + "%' " + 
                    "and e.badgeid > 0 " +
                    "order by l_id", cnxn);
                table = new DataTable();
                da.Fill(table);
                bs.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}