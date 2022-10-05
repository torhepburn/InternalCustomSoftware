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
            //SqlConnection cnxn = new SqlConnection
            //    ("server=middb01; user=views; " +
            //     "password=views;database=dashboard;");
            //SqlDataAdapter da = new SqlDataAdapter
            //    ("Select mkreceipttransactionid, partnumber, " +
            //     "receiveddate from [tracking - all] " +
            //     "where receiveddate > '2012-05-31'", cnxn);
            //DataTable table = new DataTable();
            //da.Fill(table);
            //GridView1.DataSource = table;
            //GridView1.DataBind();

            if (!IsPostBack)
            {
                //int id = int.Parse(Request.QueryString[&#34;id&#34;]);
                //Display(id);
                GetData()
            }
        }

        //private void Display(int id)
        //{
        //    DataSet ds = GetData();
        //Byte[] bytes = (Byte[])ds.Tables[0].Rows[0][&#34;Data&#34;];
        //Response.Buffer = true;
        //    Response.Charset = &#34;&#34;;
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.ContentType = &#34;application/pdf&#34;;
        //Response.BinaryWrite(bytes);
        //    Response.Flush();
        //    Response.End();
        //}

        private DataSet GetData()
        {
            SqlConnection cnxn = new SqlConnection("server=midsql01; user = readWrite; password = 'Read+Write!'; database = calibration");

        
            SqlDataAdapter da = new SqlDataAdapter("select certpdf from calibrationdata where id = 117980", cnxn);

            DataTable table = new DataTable();
                    
                        da.Fill(table);

            string xx = "test";
            
        }
    }

}
