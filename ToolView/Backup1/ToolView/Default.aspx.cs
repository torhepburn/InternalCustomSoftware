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

namespace ToolView
{
    public partial class _Default : System.Web.UI.Page
    {
        private string statusFilter;
        private string locationFilter;
        private string roomFilter;
        private string typeFilter;
        private string manufacturerFilter;
        private string userFilter;
        private string ownerFilter;
        private string ownersupFilter;
        private string calsourceFilter;
        private string modelFilter;
        private string where;
        private string calendarFilter;
        private string idFilter;
        private string descriptionFilter;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
