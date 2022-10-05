using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Backlog
{
    public partial class Backlog : Form
    {
        public Backlog()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
               ("server = midsql01; user=readwrite; " +
                "password=Read+Write!; database = webtables;");
            //SqlDataAdapter Qda = new SqlDataAdapter
            //    ("Select " +
            //     "ta.mkreceipttransactionid, " +
            //     "ta.partnumber, " +
            //     "ta.order_no as OrdNum, " +
            //     "ma.OriginalQty as RcvdQty, " +
            //     "ma.MaintainOperator as Inspector, " +
            //     "ma.transactionDate as DateApprvd, " +
            //     "mk.business_line_description, " +
            //     "mk.receipt_item_description " +
            //     //", ta.receiptNumber_int " +
            //     "from [middb01].dashboard.dbo.[tracking - all] ta " +
            //     "inner join [middb01].dashboard.dbo.view_maintain_approval ma " +
            //     "on ta.mkreceipttransactionid = " +
            //     "ma.mkreceipttransactionid " +
            //     "left join backlogmk200 mk " +
            //     "on ta.receiptnumber_int = mk.receipt_number " +
            //     "where " +
            //     "ta.companyID = 200 " +
            //     "and ma.transactiondate >= '2010-01-01' " +
            //     "group by " +
            //     "ta.mkreceipttransactionid, " +
            //     "ta.partnumber, " +
            //     "ta.order_no, " +
            //     "ma.OriginalQty, " +
            //     "ma.MaintainOperator, " +
            //     "ma.transactionDate, " +
            //     "ta.receiptNumber_int, " +
            //     "mk.business_line_description, " +
            //     "mk.receipt_item_description " +
            //     "order by ta.mkreceipttransactionid",
            //     cnxn);

            //try
            //{
            //    DataTable dshTable = new DataTable();
            //    Qda.Fill(dshTable);
            //    cnxn.Close();
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            cnxn.Open();
            SqlCommand cmd1 = new SqlCommand(
                   "rpt200", cnxn);
            cmd1.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd1.CommandTimeout = 300;
                cmd1.ExecuteNonQuery();
                cnxn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}