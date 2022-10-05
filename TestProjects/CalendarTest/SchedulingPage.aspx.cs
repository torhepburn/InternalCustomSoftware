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

namespace CalendarTest
{
    public partial class SchedulingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NextButton_Command(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex += 1;
        }


        protected void BackButton_Command(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex -= 1;
        }
    }
}
