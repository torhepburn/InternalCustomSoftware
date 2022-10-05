using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tools
{
    public partial class F6_ToolLocation : Form
    {
        SqlDataAdapter da;
        BindingSource bs = new BindingSource();
        SqlConnection cnxn1;

        SqlDataAdapter da2;
        BindingSource bs2 = new BindingSource();
        
        public F6_ToolLocation()
        {
            InitializeComponent();
        }

        private void F6_ToolLocationorm2_Load(object sender, EventArgs e)
        {
            cnxn1 = new SqlConnection(g.db);
            DGV1.Show();
            DGV1.DataSource = bs;

            ToolTip TTbAssign = new ToolTip();
            TTbAssign.SetToolTip(bAssign, "Select a tool by clicking on it in the left hand window - " +
                "it should show up in maroon to the left of this button, then select a location " +
                "by clicking on it in the right hand window and it should show up in maroon just to " +
                "the left of this button.  Assign the location by clicking on this button.");

            // routine to update DGV1
            viewUpToDate();

            DGV2.Show();
            DGV2.DataSource = bs2;

            try
            {
                da2 = new SqlDataAdapter("select Location " +
                    "from locations where program = '" + g.program +
                    "' and facility = '" + g.facility +
                    "' order by location", cnxn1);
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
                MessageBox.Show("A Tool must be selected.");
            }

            if (LLocation.Text.Length == 0)
            {
                MessageBox.Show("A Location must be selected.");
            }

            if (LItem.Text.Length != 0 & LLocation.Text.Length != 0)
            {

                cnxn1 = new SqlConnection(g.db);

                da = new SqlDataAdapter
                    ("Select * from locations where " +
                     "location like '%" + LLocation.Text.Trim() + "%'", cnxn1);
                DataTable table3 = new DataTable();
                da.Fill(table3);

                string o = table3.Rows[0][2].ToString().Trim();
                object p = table3.Rows[0][3].ToString().Trim();
                //object o = cmd.ExecuteScalar();
                //int owner = Convert.ToInt32(o.ToString().Trim());

                //// owner of location causes user to change 
                //// based on sql trigger in scandata
                SqlCommand cmd = new SqlCommand(
                    " Update toollocation  " +
                    " set llocation = '" + LLocation.Text.Trim() + "', " +
                    " lprogram = '" + table3.Rows[0][2].ToString().Trim() + "', " +
                    " lfacility = '" + table3.Rows[0][3].ToString().Trim() + "' " +
                    " where lsn = '" + LItem.Text.Trim() + "'", cnxn1);
                cnxn1.Open();   
                int rowsReturned = cmd.ExecuteNonQuery();
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
                da = new SqlDataAdapter("select lsn as Tool, " +
                    " LLocation as Location from toollocation" +
                    " where LFacility = '" + g.facility +
                    "' and LProgram = '" + g.program +
                    "' and lsn like '%" + tbSearchItem.Text.Trim() +
                    "%' order by lsn", cnxn1);
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
        }

        private void bSearchLocation_Click(object sender, EventArgs e)
        {
            try
            {
                da2 = new SqlDataAdapter("select Location " +
                    " from locations " +
                    "where location like '%" + tbSearchLocation.Text.Trim() +
                    "%' and Facility = '" + g.facility + 
                    "' and Program = '" + g.program + 
                    "' order by location", cnxn1);
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
        }

        private void viewUpToDate()
        {
            try
            {
                da = new SqlDataAdapter("select lsn as Tool, " +
                    " LLocation as Location from toollocation" +
                    " where LFacility = '" + g.facility + 
                    "' and LProgram = '" + g.program + 
                    "' order by lsn", cnxn1);
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

        private void bAddLocation_Click(object sender, EventArgs e)
        {
            F62_AddLocation f62 = new F62_AddLocation();
            f62.Show();
        }

        private void bSetupSheet_Click(object sender, EventArgs e)
        {
            F63_ChooseSetupSheet f63 = new F63_ChooseSetupSheet();
            f63.Show();
        }

        private void F6_ToolLocation_Activated(object sender, EventArgs e)
        {
            viewUpToDate();
        }

        private void bSearchDescription_Click(object sender, EventArgs e)
        {
            // not used

            //try
            //{
            //    da2 = new SqlDataAdapter("select l_id as Location, " +
            //        "l_description as Description from " +
            //        "location where l_id like '" + g.facility +
            //        "%'and l_description like '%" + tbSearchLocation.Text.Trim() +
            //        "%' order by l_id", cnxn1);
            //    DataTable table2 = new DataTable();
            //    da2.Fill(table2);
            //    bs2.DataSource = table2;
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //cnxn1.Close();
            //DGV2.Refresh();

        }

    }
}