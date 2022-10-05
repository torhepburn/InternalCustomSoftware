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

namespace RPM
{
    public partial class _Default : System.Web.UI.Page
    {
        static string buttonSender;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //may have to use regular select due to permissions.
             
            //SqlConnection cnxn = new SqlConnection
            //    ("server=midprj01; user=views; " +
            //     "password=views; database=logsheetsdb;");
            //SqlCommand cmd = new SqlCommand(
            //    "ddlCostCenter", cnxn);
            //cmd.CommandType = CommandType.StoredProcedure;
            
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = cmd;

            //DataTable table = new DataTable();
            //da.Fill(table);

            //ddLcostcenter.DataSource = table;

            //DataColumn dc = new DataColumn("Combined");
            //dc.Expression = string.Format("{0}+' '+{1}", "Cost Center", "Description");
            //table.Columns.Add(dc);
           
            //GV.DataBind();
     
        }

        protected void Bcalendar_Click(object sender, EventArgs e)
        {
            buttonSender = "Start Date";
            Calendar.Visible = true;
        }

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            if (buttonSender == "Start Date")
            {
                tbStartDate.Text = Calendar.SelectedDate.ToShortDateString();
                Calendar.Visible = false;
            }

            if (buttonSender == "Verified")
            {
                tbLotoVerified.Text = Calendar.SelectedDate.ToShortDateString();
                Calendar.Visible = false;
            }
        }

        protected void BlotoNo_Click(object sender, EventArgs e)
        {
            tbLotoVerified.Text = "No";
        }

        protected void BlotoNA_Click(object sender, EventArgs e)
        {
            tbLotoVerified.Text = "N/A";
        }

        protected void BlotoDate_Click(object sender, EventArgs e)
        {
            buttonSender = "Verified";
            Calendar.Visible = true;
        }
    }
}
