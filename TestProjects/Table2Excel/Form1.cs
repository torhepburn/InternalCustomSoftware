using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Table2Excel
{
    public partial class Form1 : Form
    {
        DataTable table;
         
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
                ("server=midprj01; user=views; password=views;" +
                 "database=tandh;");
            SqlDataAdapter da = new SqlDataAdapter
                ("select * from tbl_readings_128_1_9_231", cnxn);
            table = new DataTable();
            da.Fill(table);

            //XmlDataDocument xmlDataDoc = new XmlDataDocument(table);
            //XslCompiledTransform xt = new XslCompiledTransform();
            //StreamReader sr = new StreamReader("c:\\i386\\Excel.xsl");
            //XmlTextReader xrdr = new XmlTextReader(sr);
            //xt.Load(xrdr, null, null);
            //StringWriter sw = new StringWriter();
            ////xt.Transform(xrdr, null, null);
            //StreamWriter myWriter = new StreamWriter("c:\\a\\report.xls");
            //myWriter.Write(sw.ToString());
            //myWriter.Close();

            if (table.Rows.Count > 0)
            {
                string filename = "hope.xls";
                System.IO.StringWriter sw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htw = new HtmlTextWriter(sw);
                GridView gv = new GridView();
                gv.DataSource = table;
                gv.RenderControl(htw);

                File.AppendAllText("c:\\a\\xl.xls", sw.ToString());
                //Response.Clear();
                //Response.Buffer = true;
                //Response.ContentType = "application/vnd.ms-excel";
                //Response.AddHeader("content-disposition", "attachment;filename=MyFiles.xls");
                //Response.Charset = "";
                //this.EnableViewState = false;
                //Response.Write(sw.ToString());
                //Response.End();
            }
            //Response.Clear();
            //Response.Buffer = true;
            //Response.ContentType = "application/vnd.ms-excel";
            //Response.AddHeader("content-disposition", "attachment;filename=MyFiles.xls");
            //Response.Charset = "";
            //this.EnableViewState = false;

            //System.IO.StringWriter sw = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter htw = new HtmlTextWriter(sw);

            //GridView.RenderControl(htw);

            //Response.Write(sw.ToString());
            //Response.End();
            
            
        }
    }
}