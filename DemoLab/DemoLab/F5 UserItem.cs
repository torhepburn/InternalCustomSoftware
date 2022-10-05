using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DemoLab
{
    public partial class F5_UserItem : Form
    {
        SqlDataAdapter da;
        BindingSource bs = new BindingSource();
        SqlConnection cnxn1;

        SqlDataAdapter da2;
        BindingSource bs2 = new BindingSource();
        SqlConnection cnxn2;

        SqlConnection cnxn;
        SqlCommand cmd;

        DataTable dt3;
        
        public F5_UserItem()
        {
            InitializeComponent();
        }

        private void F5_UserItem_Load(object sender, EventArgs e)
        {
            cnxn1 = new SqlConnection("server = middb01; password = views; " +
                                  "user = views; database = dashboard;");
            DGV1.Show();
            DGV1.DataSource = bs;

            employeeList("Select Name, BadgeID, Email " +
                    " from dbo.view_employees where " +
                    " badgeid > 0 order by name");

            leftGrid();
        }

        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 3)
            {
                return;
            }
            else
            {
                //if (g.item == "Location")
                //{
                //    DataGridViewTextBoxCell cell =
                //        (DataGridViewTextBoxCell)DGV1.Rows[e.RowIndex].Cells[0];
                //    lLocation.Text = cell.EditedFormattedValue.ToString().Trim();
                //    g.location = lLocation.Text;
                //}
                //if (g.item == "Equipment")
                //{
                //    DataGridViewTextBoxCell cell =
                //        (DataGridViewTextBoxCell)DGV1.Rows[e.RowIndex].Cells[0];
                //    lLocation.Text = cell.EditedFormattedValue.ToString().Trim();
                //    g.iID = lLocation.Text;
                //}
            }
        }

        private void DGV2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 3)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[0];
                lEmployee.Text = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[1];

                //g.eBadgeID = cell.EditedFormattedValue.ToString().Trim();
            }
        }

        private void bAssign_Click(object sender, EventArgs e)
        {
            //cnxn = new SqlConnection(g.db);

            //if (g.item == "Location")
            //{
            //    // change owner of location

            //    cmd = new SqlCommand("Update location " +
            //        " set l_Owner = '" + g.eBadgeID + "'" +
            //        " where l_id = '" + g.location + "'");
            //}
            //if (g.item == "Equipment")
            //{
            //    // change user of equipment
            //    // sql trigger in scandata updates the itemuser table

            //    cmd = new SqlCommand(
            //        " Insert into scandata (item, " +
            //        " employee, location, date) values (" +
            //        " '" + g.iID + "'," +
            //        " '" + g.eBadgeID + "'," +
            //        " 'No Change', " +
            //        " '" + DateTime.Now + "') ");
            //}

            cmd.Connection = cnxn;
            cnxn.Open();
            int rowsReturned = cmd.ExecuteNonQuery();
            cnxn.Close();

            leftGrid();

            lLocation.Text = "";
            lEmployee.Text = "";
        }

        private void bsearchItem_Click(object sender, EventArgs e)
        {
            //if (g.item == "Equipment")
            //{
            //    equipmentList("Select u.i_item as Item,  " +
            //            " e.Description, " +
            //            " u.i_user from itemuser u inner join " +
            //            " itemlocation l on u.i_item = l.il_item " +
            //            " inner join equipment e on e.id = u.i_item " +
            //            " where l.il_location like '%" + g.facility + "%'" +
            //            " and u.i_item like '%" + tbSearchItem.Text + "%' " +
            //            " order by Item", "select badgeid, Name from dbo.view_employees " +
            //            " where badgeid > 0 ");

            //    tbSearchItem.Text = "";
            //}

            //if (g.item == "Location")
            //{
            //    locationList("Select l_id as Location, l_Description as " +
            //            "Description, l_Owner from location " +
            //            "where l_id like '%" + tbSearchItem.Text + "%'",
            //            "select badgeid, Name from dbo.view_employees " +
            //            "where badgeid > 0");

            //    tbSearchItem.Text = "";
            //}
        }

        private void bsearchUserOwner_Click(object sender, EventArgs e)
        {
            //if (g.item == "Equipment")
            //{
            //    equipmentList("Select u.i_item as Item,  " +
            //            " e.Description, " +
            //            " u.i_user from itemuser u inner join " +
            //            " itemlocation l on u.i_item = l.il_item " +
            //            " inner join equipment e on e.id = u.i_item " +
            //            " where l.il_location like '%" + g.facility + "%'" +
            //            " order by Item", "select badgeid, Name from dbo.view_employees " +
            //            " where badgeid > 0 " +
            //            " and Name like '%" + tbSearchItem.Text + "%'");
            //}

            //if (g.item == "Location")
            //{
            //    bsearchUserOwner.Text = "Search Owner";
            //    bsearchItem.Text = "Search Location";

            //    locationList("Select l_id as Location, l_Description as " +
            //            " Description, l_Owner from location " +
            //            " where l_id like '%" + g.facility + "%'",
            //            " select badgeid, Name from dbo.view_employees " +
            //            " where badgeid > 0 " +
            //            " and Name like '%" + tbSearchItem.Text + "%'");
            //}
            //tbSearchItem.Text = "";
        }

        private void bSearchEmployee_Click(object sender, EventArgs e)
        {
            employeeList("Select Name, BadgeID, Email " +
                    " from dbo.view_employees where " +
                    " badgeid > 0 and name like '%" + tbSearchEmployee.Text + "%'");

            tbSearchEmployee.Text = "";
        }

        private void employeeList(string select)
        {
            cnxn2 = new SqlConnection
                  (g.dbDashserver);
            DGV2.Show();
            DGV2.DataSource = bs2;

            try
            {
                da2 = new SqlDataAdapter(select, cnxn2);
                DataTable table3 = new DataTable();
                da2.Fill(table3);
                bs2.DataSource = table3;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            DGV2.Columns[1].Visible = false;
            DGV2.Columns[2].Visible = false;
        }

        private void equipmentList(string selectItem, string selectOwner)
        {
            //try
            //{
            //    DataSet ds = new DataSet();

            //    da = new SqlDataAdapter(selectItem, cnxn1);

            //    da.Fill(ds, "table1");
            //    DataTable dt1 = ds.Tables["table1"];

            //    string db2 = g.dbDashserver;
            //    da = new SqlDataAdapter(selectOwner, db2);

            //    da.Fill(ds, "table2");
            //    DataTable dt2 = ds.Tables["table2"];

            //    dt3 = new DataTable();

            //    dt3.Columns.Add("Item", typeof(string));
            //    dt3.Columns.Add("User", typeof(string));
            //    dt3.Columns.Add("Description", typeof(string));


            //    foreach (DataRow locationRow in dt1.Rows)
            //    {
            //        foreach (DataRow personRow in dt2.Rows)
            //        {
            //            object i = personRow.ItemArray[0];
            //            object j = locationRow.ItemArray[2];
            //            DataRow rr = dt3.NewRow();
            //            if (i.ToString() == j.ToString())
            //            {
            //                rr["Item"] = locationRow["Item"];
            //                rr["Description"] = locationRow["Description"];
            //                rr["User"] = personRow["Name"];
            //                dt3.Rows.Add(rr);
            //            }
            //        }
            //    }


            //    bs.DataSource = dt3;
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }


        private void locationList(string selectLocation, string selectOwner)
        {
            //try
            //{
            //    DataSet ds = new DataSet();

            //    da = new SqlDataAdapter(selectLocation, cnxn1);

            //    da.Fill(ds, "table1");
            //    DataTable dt1 = ds.Tables["table1"];

            //    string db2 = g.dbDashserver;
            //    da = new SqlDataAdapter(selectOwner, db2);

            //    da.Fill(ds, "table2");
            //    DataTable dt2 = ds.Tables["table2"];

            //    dt3 = new DataTable();

            //    dt3.Columns.Add("Location", typeof(string));
            //    dt3.Columns.Add("Owner", typeof(string));
            //    dt3.Columns.Add("Description", typeof(string));

            //    foreach (DataRow locationRow in dt1.Rows)
            //    {
            //        foreach (DataRow personRow in dt2.Rows)
            //        {
            //            object i = personRow.ItemArray[0];
            //            object j = locationRow.ItemArray[2];
            //            DataRow rr = dt3.NewRow();
            //            if (i.ToString() == j.ToString())
            //            {
            //                rr["Location"] = locationRow["Location"];
            //                rr["Description"] = locationRow["Description"];
            //                rr["Owner"] = personRow["Name"];
            //                dt3.Rows.Add(rr);
            //            }
            //        }
            //    }

            //    bs.DataSource = dt3;
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void leftGrid()
        {
        //    if (g.item == "Equipment")
        //    {
        //        bsearchUserOwner.Text = "Search User";

        //        equipmentList("Select u.i_item as Item,  " +
        //            " e.Description, " +
        //            " u.i_user from itemuser u inner join " +
        //            " itemlocation l on u.i_item = l.il_item " +
        //            " inner join equipment e on e.id = u.i_item " +
        //            " where l.il_location like '%" + g.facility + "%'" +
        //            " order by Item", "select badgeid, Name from " +
        //            " dbo.view_employees where " +
        //            " badgeid > 0");
        //    }

        //    if (g.item == "Location")
        //    {
        //        bsearchUserOwner.Text = "Search Owner";
        //        bsearchItem.Text = "Search Location";

        //        locationList("Select l_id as Location, l_Description as " +
        //                "Description, l_Owner from location " +
        //                "where l_id like '%" + g.facility + "%'",
        //                "select badgeid, Name from dbo.view_employees " +
        //                "where badgeid > 0");
        //    }
        //}

        //private void bBack_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

    }

}

