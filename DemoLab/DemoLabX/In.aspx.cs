using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DemoLabX
{
    public partial class Contact : Page
    {
        DataTable dt;
        static string SortExpression;
        static string SortDirection;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = SiteMaster.LocationX;

            ConnectionStringSettings css = ConfigurationManager.ConnectionStrings["DemoLabCnxn"];
            SqlConnection cnxn = new SqlConnection(css.ConnectionString);
            cnxn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnxn;
            cmd.CommandText = "StatusIn";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter location = new SqlParameter("@Location", SqlDbType.NChar, 20);
            location.Value = SiteMaster.LocationX;

            cmd.Parameters.Add(location);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cnxn.Close();
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            catch (SqlException ex)
            {

            }
        }

        //SQL tables linked in All.aspx sort automatically, the rest need to be treated below
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (e.SortExpression == SortExpression)
            {
                if (SortDirection == "ASC")
                {
                    SortDirection = "DESC";
                }
                else
                {
                    SortDirection = "ASC";
                }
            }
            else
            {
                if (SortDirection == "ASC")
                {
                    SortDirection = "DESC";
                }
                else
                {
                    SortDirection = "ASC";
                }
            }
            SortExpression = e.SortExpression.ToString();

            dt.DefaultView.Sort = SortExpression + " " + SortDirection;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}