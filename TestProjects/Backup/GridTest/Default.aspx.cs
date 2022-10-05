using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace GridTest
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
                ("server=middbsql\\sql2000; user=views; " +
                 "password=views;database=dashboard;");
            SqlDataAdapter da = new SqlDataAdapter
                ("Select mkreceipttransactionid, partnumber, " +
                 "receiveddate from [tracking - all] " +
                 "where receiveddate > '2012-05-31'", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            GridView1.DataSource = table;
            GridView1.DataBind();
        }
    }
}
