using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace GridButtonTest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataTable dt;
        SqlConnection cnxn;


        protected void Page_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection
                ("server=MIDSQL01; user=readWrite; password=Read+Write!;" +
                 "database=AccessFrontEnds");

            SqlDataAdapter da = new SqlDataAdapter
                ("select top 10 " +
                 "customer CustomerID, " +
                 "name CompanyName, " +
                 "City from mmx_customers " +
                 "order by name", cnxn);
            dt = new DataTable();
            da.Fill(dt);

            //CustomersGridView.DataSource = dt;
            //CustomersGridView.DataBind();
        }

        //protected void CustomersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //        //If multiple ButtonField columns are used, use the
        //        // CommandName property to determine which button was clicked.
        //        if (e.CommandName == "Add")
        //        {
        //            // Convert the row index stored in the CommandArgument
        //            // property to an Integer.
        //            int index = Convert.ToInt32(e.CommandArgument);

        //            // Retrieve the row that contains the button clicked
        //            // by the user from the Rows collection. Use the
        //            // CommandSource property to access the GridView control.
        //            GridView customersGridView = (GridView)e.CommandSource;
        //            GridViewRow row = customersGridView.Rows[index];

        //            // Create a new ListItem object for the customer in the row.
        //            ListItem item = new ListItem();
        //            item.Text = Server.HtmlDecode(row.Cells[1].Text) + " " + Server.HtmlDecode(row.Cells[2].Text);

        //            // If the author is not already in the ListBox, add the ListItem
        //            // object to the Items collection of a ListBox control.
        //            if (!CustomersListBox.Items.Contains(item))
        //            {
        //                CustomersListBox.Items.Add(item);
        //            }
        //        }
        //}

        //protected void CustomersGridView_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //        //The GridViewCommandEventArgs class does not contain a
        //        // property that indicates which row's command button was
        //        // clicked. To identify which row was clicked, use the button's
        //        // CommandArgument property by setting it to the row's index.
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            // Retrieve the LinkButton control from the first column.
        //            LinkButton addButton = (LinkButton)e.Row.Cells[0].Controls[0];

        //            // Set the LinkButton's CommandArgument property with the
        //            // row's index.
        //            addButton.CommandArgument = e.Row.RowIndex.ToString();
        //        }
        //}
    }
}