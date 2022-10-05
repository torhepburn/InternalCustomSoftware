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

namespace GeorgeReports
{
    public partial class _Default : System.Web.UI.Page
    {
        private int dow;
        DateTime weekStart;
        DateTime weekEnd;
        DataTable table;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            dow = ((int)Calendar1.SelectedDate.DayOfWeek);
            weekStart = Calendar1.SelectedDate.AddDays(-(dow));
            weekEnd = weekStart.AddDays(7);
            
            SqlConnection cnxn = new SqlConnection("server=midsrv04\\sqlexpress; user=views; " +
                "password=views; database=quotewerks;");
            SqlDataAdapter da = new SqlDataAdapter
                ("select " +
                 "count(i.manufacturerpartnumber) as [Times Quoted], " +
                 "i.manufacturerpartnumber, " +
                 "max(left(cast(i.[description] as nvarchar),50)) as [Description] " +
                 "from documentheaders h left join " +
                 "documentitems i on " +
                 "h.id = i.docid " +
                 "where (lastmodified > '" + weekStart + "' and " +
                 "lastmodified < '" + weekEnd + "') " +
                 "and (len(i.manufacturerpartnumber) !=0 " +
                 "and (ascii(manufacturerpartnumber)) > 47 " +
                 "and (ascii(manufacturerpartnumber)) < 58 " +
                 "or left(manufacturerpartnumber, 4) = 'Ser ') " +
                 "group by manufacturerpartnumber " +
                 "order by manufacturerpartnumber", cnxn);

            table = new DataTable();
            da.Fill(table);
            GridView.DataSource = table;
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment;filename=MyFiles.xls");
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htw = new HtmlTextWriter(sw);

            GridView.RenderControl(htw);

            Response.Write(sw.ToString());
            Response.End();
        }
    }
}
