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

namespace ProjectTotalDB
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bSubmit_Click(object sender, EventArgs e)
        {
            if (tbUserName.Text.ToUpper() == "PROJECTDB" &&
                tbPassword.Text == "Zygo8888")
            {
                Lerror.Visible = false;
                Response.Redirect("http://middbweb/projecttotal/projecttotal_dir/prjtot_main.aspx");
            }
            else
            {
                Lerror.Visible = true;
                tbUserName.Text = "";
                tbPassword.Text = "";
                tbUserName.Focus();
            }
 
        }
    }
}
