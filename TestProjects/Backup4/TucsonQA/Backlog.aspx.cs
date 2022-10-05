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

public partial class Backlog : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection cnxn = new SqlConnection
         ("server=middbsql; user=views; password=views; " +
          "database=webtables;");
        SqlDataAdapter da = new SqlDataAdapter
            ("select " + 
             "r.mklink, " +
             "r.order_no, " +
             "r.receiveddate, " +
             "a.maintainoperator, " +
             "r.partnumber, " +
             "mk.receipt_item_description, " +
             "datediff(dd,r.receiveddate, a.transactiondate)- " +
             "(datediff(ww,r.receiveddate, a.transactiondate)*2) as DaysInQC " +
             "from backlogUniqueReceipt600 r " +
             "left join backlogmk mk on " +
             "r.receiptnumber_int = mk.receipt_number and r.partnumber = mk.item_code " +
             "left join [middbsql\\sql2000].dashboard.dbo.view_maintain_approval a " +
             "on r.mklink = a.mkreceipttransactionid " +
             "where maintainoperator is not null " +
             "and datediff(dd,r.receiveddate, a.transactiondate)- " +
             "(datediff(ww,r.receiveddate, a.transactiondate)*2) > 30 " +
             "order by mkreceipttransactionid", cnxn);
        DataTable table = new DataTable();
        da.Fill(table);
        //GridView1.DataSource = table;
        //GridView1.DataBind();
    }

   
   
}
