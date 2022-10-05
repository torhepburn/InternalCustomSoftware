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

namespace AJAXEnabledWebApplication1
{
    public partial class D : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Bscheduling_Click(object sender, EventArgs e)
        {

        }


        protected void Bsystems_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource1";
        }

        protected void Bobjectives_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource2";
        }

        protected void Bflats_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource3";
        }

        protected void Baccessories_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = "SqlDataSource4";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
        }

    }
}
