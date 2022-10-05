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

namespace DropDownTest
{
    public partial class _Default : System.Web.UI.Page
    {
        private bool clickOn;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = DropDownList1.Text;
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                DropDownList1.Visible = true;
                TextBox1.Text = DropDownList1.Text;
                CheckBox1.Text = "Filtering";
            }
            else
            {
                DropDownList1.Visible = false;
                CheckBox1.Text = "Check to Filter";
            }
        }
    }
}
