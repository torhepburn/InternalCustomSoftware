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

namespace ToolRoom
{
    public partial class ThankYou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(
                "server=CT-MID-SQL11; user=readWrite; password=Read+Write!;" +
                "database=AccessFrontEnds;");
            SqlCommand cmd = new SqlCommand("Update Tool_Appendix " +
                "SET FlagAnother = 'NO' ", cnxn);
            try
            {
                cnxn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                cnxn.Close();
            }
        }

        protected void oneMore_Click(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(
                "server=CT-MID-SQL11; user=readWrite; password=Read+Write!;" +
                "database=AccessFrontEnds;");
            SqlCommand cmd = new SqlCommand("Update Tool_Appendix " +
                "SET FlagAnother = 'YES' ", cnxn);
            try
            {
                cnxn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                cnxn.Close();
            }

            Response.Redirect("~/ToolRoomDefault.aspx");
          
        }
    }
}
