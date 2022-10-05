using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebTest
{
    public partial class QAtest : System.Web.UI.Page
    {
        SqlConnection cnxn1;
        SqlDataAdapter da1;
        SqlConnection cnxn2;
        SqlDataAdapter da2;
        DateTime standard;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            cnxn1 = new SqlConnection
    ("server=midsql01; user=views; password=views; " +
     "database=webtables;");
            da1 = new SqlDataAdapter
            ("select " +
             "mk.receipt_number, " +
             "r.receiveddate, " +
             "a.maintainoperator, " +
             "r.partnumber, " +
             "mk.receipt_item_description, " +
             "datediff(dd,r.receiveddate, a.transactiondate)- " +
             "(datediff(ww,r.receiveddate, a.transactiondate)*2) as DaysInQC " +
             "from backlogUniqueReceipt600 r " +
             "left join backlogmk600 mk on " +
             "r.receiptnumber_int = mk.receipt_number and r.partnumber = mk.item_code " +
             "left join [middb01].dashboard.dbo.view_maintain_approval a " +
             "on r.mklink = a.mkreceipttransactionid " +
             "where maintainoperator is not null " +
             "and datediff(dd,r.receiveddate, a.transactiondate)- " +
             "(datediff(ww,r.receiveddate, a.transactiondate)*2) > 30 and " +
             "a.transactiondate > '" + DateTime.Now.AddMonths(-6).ToShortDateString() + "' " +
             "order by mkreceipttransactionid", cnxn1);
            DataTable table1 = new DataTable();
            da1.Fill(table1);
            GridView1.DataSource = table1;
            GridView1.DataBind();

            cnxn2 = new SqlConnection
                ("server=middb01; user=views; password=views; " +
                 "database=dashboard;");
            da2 = new SqlDataAdapter
            ("select " +
             "year(a.transactiondate) as [Year], " +
             "month(a.transactiondate) as Month, " +
             "avg(daysfromreceipttoapproval) as [Average Days] " +
             "from " +
             "(select " +
             "t.mkreceipttransactionid, " +
             "t.receiveddate, " +
             "m.transactiondate, " +
             "case " +
             "when " +
             "(datediff(dd,t.receiveddate, m.transactiondate)) - " +
             "(datediff(ww,t.receiveddate, m.transactiondate)*2) " +
             "= 0 " +
             "then .5 " +
             "else " +
             "(datediff(dd,t.receiveddate, m.transactiondate)) - " +
             "(datediff(ww,t.receiveddate, m.transactiondate)*2) " +
             "end as DaysFromReceiptToApproval " +
             "from " +
             "[tracking - all] t " +
             "inner join " +
             "view_maintain_approval m " +
             "on t.mkreceipttransactionid = m.mkreceipttransactionid " +
             "where " +
             "t.companyid = 600 " +
             "and " +
             "t.inspectionrequired = 1 " +
             "and " +
             "t.receiveddate > '" + DateTime.Now.AddYears(-2).ToShortDateString() + "' " +
             "and t.location like 'receiving dock %tucson%') a " +
             "group by month(a.transactiondate), year(a.transactiondate) " +
             "order by year(a.transactiondate), month(a.transactiondate) "
             , cnxn2);
            DataTable table2 = new DataTable();
            da2.Fill(table2);
            GridView2.DataSource = table2;
            GridView2.DataBind();

        }
    }
}