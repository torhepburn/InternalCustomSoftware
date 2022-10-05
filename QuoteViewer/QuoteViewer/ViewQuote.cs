using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuoteViewer
{
    public partial class ViewQuote : Form
    {
        private string quoteno;
        private int docid;

        public ViewQuote(string quote)
        {
            InitializeComponent();
            quoteno = quote;
        }

        private void ViewQuote_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
                ("server=midsrv04\\sqlexpress; user=views; " +
                 "password=views; database=quotewerks;");

            SqlCommand cmd = new SqlCommand
                ("select " +
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
                 "lastmodified, " +  //10
                 "docno, " +
                 "salesrep, " +
                 "terms, " +
                 "fob, " +
                 "grandtotal, " +
                 "id " +
                 "from documentheaders where docno = '" + quoteno + "'", cnxn);
            cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (!dr.IsDBNull(0)) { Lcompany.Text = dr.GetString(0).Trim(); }
                if (!dr.IsDBNull(1)) { label1.Text = dr.GetString(1).Trim(); }
                if (!dr.IsDBNull(2)) { label2.Text = dr.GetString(2).Trim(); }
                if (!dr.IsDBNull(3)) { label3.Text = dr.GetString(3).Trim(); }
                if (!dr.IsDBNull(4)) { label4.Text = dr.GetString(4).Trim(); }
                if (!dr.IsDBNull(5)) { label5.Text = dr.GetString(5).Trim(); }
                if (!dr.IsDBNull(6)) { label6.Text = dr.GetString(6).Trim(); }
                if (!dr.IsDBNull(7)) { label7.Text = dr.GetString(7).Trim(); }
                if (!dr.IsDBNull(8)) { label8.Text = dr.GetString(8).Trim(); }
                if (!dr.IsDBNull(9)) { label9.Text = dr.GetString(9).Trim(); }
                if (!dr.IsDBNull(10)) { label10.Text = dr.GetDateTime(10).ToShortDateString();}
                if (!dr.IsDBNull(11)) { label11.Text = dr.GetString(11).Trim(); }
                if (!dr.IsDBNull(12)) { label12.Text = dr.GetString(12).Trim(); }
                if (!dr.IsDBNull(13)) { label14.Text = dr.GetString(13).Trim(); }
                if (!dr.IsDBNull(14)) { label15.Text = dr.GetString(14).Trim(); }
                if (!dr.IsDBNull(15)) { label18.Text = dr.GetDouble(15).ToString().Trim(); }
                docid = dr.GetInt32(16);
            }
            cnxn.Close();

            SqlDataAdapter da = new SqlDataAdapter
                ("select " +
                 "qtybase, " +
                 "qtytotal, " +
                 "manufacturerpartnumber, " +
                 "description, " +
                 "unitprice, " +
                 "extendedprice " +
                 "from documentitems where docid = " + docid + "", cnxn);

            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;

            SqlDataAdapter da2 = new SqlDataAdapter
                ("select " +
                 "attachments, " +
                 "closingnotes, " +
                 "docname, " +
                 "docstatus, " +
                 "internalnotes, " +
                 "introductionnotes " +
                 "from documentheaders where docno = '" + quoteno + "'", cnxn);

            DataTable table2 = new DataTable();
            da2.Fill(table2);
            DGV2.DataSource = table2;


        }
    }
}
