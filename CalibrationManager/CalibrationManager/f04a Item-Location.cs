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
    public partial class f04a_Item_Location : Form
    {
        SqlDataAdapter da;
        BindingSource bs = new BindingSource();
        SqlConnection cnxn1;
        
        SqlDataAdapter da2;
        BindingSource bs2 = new BindingSource();
        
        public f04a_Item_Location()
        {
            InitializeComponent();
        }

        private void f04a_Item_Location_Load(object sender, EventArgs e)
        {
            cnxn1 = new SqlConnection(g.db);
            DGV1.Show();
            DGV1.DataSource = bs;

            // routine to update DGGV1
            viewUpToDate();

            DGV2.Show();
            DGV2.DataSource = bs2;

            try
            {
                da2 = new SqlDataAdapter("select l_id as Location, " +
                    "l_description as Description from " +
                    "location where l_id like '" + g.facility +
                    "%' order by l_id", cnxn1);
                DataTable table2 = new DataTable();
                da2.Fill(table2);
                bs2.DataSource = table2;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnxn1.Close();
        }

        private void DGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 3)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                   (DataGridViewTextBoxCell)DGV1.Rows[e.RowIndex].Cells[0];
                g.iID = cell.EditedFormattedValue.ToString().Trim();
                LItem.Text = g.iID;
            }
        }

        private void DGV2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 3)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[0];
                g.location = cell.EditedFormattedValue.ToString().Trim();
                LLocation.Text = g.location;
                

            }
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bAssign_Click(object sender, EventArgs e)
        {
            if (LItem.Text.Length == 0)
            {
                MessageBox.Show("An Item must be selected.");
            }
            
            if (LLocation.Text.Length == 0)
            {
                MessageBox.Show("A Location must be selected.");
            }
            
            if (LItem.Text.Length != 0 & LLocation.Text.Length != 0)
            {

                cnxn1 = new SqlConnection(g.db);

                SqlCommand cmd = new SqlCommand
                    (" select l_owner from location where " +
                     " l_id = '" + g.location + "'", cnxn1);
                cnxn1.Open();
                object o = cmd.ExecuteScalar();
                int owner = Convert.ToInt32(o.ToString().Trim());
                
                // owner of location causes user to change 
                // based on sql trigger in scandata
                cmd = new SqlCommand(
                    " Insert into scandata (item, " +
                    " employee, location, date) values (" +
                    " '" + g.iID + "'," +
                    " '" + owner + "'," +
                    " 'No Change', " +
                    " '" + DateTime.Now + "')", cnxn1);

                int rowsReturned = cmd.ExecuteNonQuery();
                cnxn1.Close();

                // need two separate inserts into scandata to
                // get both user and location changed
                
                cmd = new SqlCommand(
                    " Insert into scandata (item, " +
                    " employee, location, date) values (" +
                    " '" + g.iID + "'," +
                    " '" + owner + "'," +
                    " '" + g.location + "', " +
                    " '" + DateTime.Now + "')", cnxn1);

                cnxn1.Open();
                rowsReturned = cmd.ExecuteNonQuery();
                cnxn1.Close();

                viewUpToDate();
                
                DGV1.Refresh();
                LLocation.Text = "";
                LItem.Text = "";

                
            }
        }

        private void bsearchItem_Click(object sender, EventArgs e)
        {
            try
            {
                da = new SqlDataAdapter("select il_item as Item, " +
                    " il_location as Location from " +
                    "itemlocation where il_location like '" + g.facility +
                    "%' and il_item like '%" +  tbSearchItem.Text.Trim() + 
                    "%' order by il_item", cnxn1);
                DataTable table = new DataTable();
                da.Fill(table);
                bs.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnxn1.Close();
            DGV1.Refresh();
            tbSearchItem.Text = "";
        }

        private void bSearchLocation_Click(object sender, EventArgs e)
        {
            try
            {
                da2 = new SqlDataAdapter("select l_id as Location, " +
                    "l_description as Description from " +
                    "location where l_id like '" + g.facility +
                    "%'and l_id like '%" + tbSearchLocation.Text.Trim() +
                    "%' order by l_id", cnxn1);
                DataTable table2 = new DataTable();
                da2.Fill(table2);
                bs2.DataSource = table2;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnxn1.Close();
            DGV2.Refresh();
            tbSearchLocation.Text = "";
        }

        private void bSearchDescription_Click(object sender, EventArgs e)
        {
            try
            {
                da2 = new SqlDataAdapter("select l_id as Location, " +
                    "l_description as Description from " +
                    "location where l_id like '" + g.facility +
                    "%'and l_description like '%" + tbSearchLocation.Text.Trim() +
                    "%' order by l_id", cnxn1);
                DataTable table2 = new DataTable();
                da2.Fill(table2);
                bs2.DataSource = table2;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnxn1.Close();
            DGV2.Refresh();
            tbSearchLocation.Text = "";
        }

        private void viewUpToDate()
        {
            try
            {
                da = new SqlDataAdapter("select il_item as Item, " +
                    " il_location as Location from " +
                    "itemlocation where il_location like '" + g.facility +
                    "%' order by il_item", cnxn1);
                DataTable table = new DataTable();
                da.Fill(table);
                bs.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnxn1.Close();
        }
    }
}