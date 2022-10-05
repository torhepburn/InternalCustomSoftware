using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QuoteViewer
{
    public partial class ViewAllQuotes : Form
    {
        public ViewAllQuotes()
        {
            InitializeComponent();
        }

        private void ViewAllQuotes_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
                ("server=midsrv04\\sqlexpress; user=views; " +
                 "password=views; database=quotewerks;");

            SqlDataAdapter da = new SqlDataAdapter(
                 "select " +
                 "docno as 'Quote Number', " +
                 "lastmodified as 'Last Modified Date', " +
                 "soldtocompany, " +
                 "soldtocontact, " +
                 "soldtoaddress1, " +
                 "soldtoaddress2, " +
                 "soldtoaddress3, " +
                 "soldtocity, " +
                 "soldtostate, " +
                 "soldtopostalcode, " +
                 "soldtophone, " +
                 "soldtoemail, " +
                 "salesrep, " +
                 "terms, " +
                 "fob, " +
                 "grandtotal, " +
                 "id " +
                 "from documentheaders " +
                 "order by lastmodified desc", cnxn);

            DataTable table = new System.Data.DataTable();
            da.Fill(table);

            DGV.DataSource = table;
            DGV.Show();
            
            
        }
    }
}
