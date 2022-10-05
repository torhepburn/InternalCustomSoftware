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
using System.Drawing;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data.SqlClient;


namespace MRBweb
{
    public partial class _Default : System.Web.UI.Page
    {
        private OracleConnection conn = new OracleConnection();
        private OracleCommand cmd;
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        //private DataSet ds;
        DataTable table;
        private string item;
        SqlConnection cnxn;
        SqlCommand SqlCmd;
        DataTable FastTable;
        private string FastID;
        private string FastResponsibleUser;
        DataTable EndTable;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                object t = (e.Row.DataItem as DataRowView).Row.ItemArray[0];
                DataRowView drv = (DataRowView)e.Row.DataItem;
                string test = drv.Row.ItemArray[0].ToString();
                string state = drv["Name"].ToString();

                if (drv.Row.ItemArray[0].ToString() == "Heizman, Robert")
                {
                    e.Row.BackColor = System.Drawing.Color.DarkCyan;
                }
                else if (drv.Row.ItemArray[0].ToString() == "Kindelan, Davey")
                {
                    e.Row.BackColor = System.Drawing.Color.SteelBlue;
                }
                else if (drv.Row.ItemArray[0].ToString() == "Lamarr, Amanda")
                {
                    e.Row.BackColor = System.Drawing.Color.LightGreen;
                }
                else if (drv.Row.ItemArray[0].ToString() == "Lawrence, Mark")
                {
                    e.Row.BackColor = System.Drawing.Color.MediumPurple;
                }
                else if (drv.Row.ItemArray[0].ToString() == "Morenz, Mark")
                {
                    e.Row.BackColor = System.Drawing.Color.Goldenrod;
                }
                else if (drv.Row.ItemArray[0].ToString() == "Santos, Rick")
                {
                    e.Row.BackColor = System.Drawing.Color.MediumTurquoise;
                }
                if (drv.Row.ItemArray[0].ToString() == "Vitali, Margaret")
                {
                    e.Row.BackColor = System.Drawing.Color.DarkKhaki;
                }
            }
        }
    }
}
