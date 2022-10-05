using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoLabX
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bDallas_Click(object sender, EventArgs e)
        {
            SiteMaster.LocationX = "Dallas";
            Response.Redirect("home.aspx");
        }

        protected void bMiddlefield_Click(object sender, EventArgs e)
        {
            SiteMaster.LocationX = "Middlefield";
            Response.Redirect("home.aspx");
        }

        protected void bSantaClara_Click(object sender, EventArgs e)
        {
            SiteMaster.LocationX = "Santa Clara";
            Response.Redirect("home.aspx");
        }

        protected void bTucson_Click(object sender, EventArgs e)
        {
            SiteMaster.LocationX = "Tucson";
            Response.Redirect("home.aspx");
        }

        protected void bCostaMesa_Click(object sender, EventArgs e)
        {
            SiteMaster.LocationX = "Costa Mesa";
            Response.Redirect("home.aspx");
        }
    }
}