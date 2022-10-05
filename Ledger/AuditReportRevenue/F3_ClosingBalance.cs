using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace AuditReportRevenue
{
    public partial class F3_ClosingBalance : Form
    {
        SqlConnection cnxn;

        public F3_ClosingBalance()
        {
            InitializeComponent();
        }

        private void F3_ClosingBalance_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            SqlCommand cmd = new SqlCommand(
                "select sum(sales) from auditRevenueS1", cnxn);
            cnxn.Open();

            object o = cmd.ExecuteScalar();

            Lbalance.Text = "Closing Balance = " + o.ToString(); 

        }

        private void Bexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Bexport_Click(object sender, EventArgs e)
        {
            SqlConnection cnxn;

            Excel.Application xlAp;
            Excel.Workbook xlWb;
            Excel.Worksheet xlWs;
            
            xlAp = new Excel.Application();
            xlWb = xlAp.Workbooks.Add(Missing.Value);
            Excel.Worksheet Sheet2;
            Sheet2 = (Excel.Worksheet)xlWb.Worksheets.Add();
            xlWs = (Excel.Worksheet)xlWb.Worksheets.get_Item(2);
            xlWs.Name = "RevenueDetails";

/*            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter(
                "select " +
                "ORDER_NUMBER, " +
                "POSITION, " +
                "QUANTITY, " +
                "ITEM_CODE, " +
                "ITEM_DESCRIPTION, " +
                "SALES, " +
                "LEDGER, " +
                "DESCRIPTION, " +
                "PROJECTSTR, " +
                "INVOICE, " +
                "INVOICE_DATE, " +
                "NAME, " +
                "PERIOD, " +
                "SOURCE, " +
                "AREA, " +
                "TRANSACTIONDATE, " +
                "CUSTNO, " +
                "CUSTOMER, " +
                "COUNTRY, " +
                "STATE " +
                "from AuditRevenueS1", cnxn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            for (int i = 1; i <= ds.Tables[0].Columns.Count; i++)
            {
                xlWs.Cells[1, i] = ds.Tables[0].Columns[i - 1].ColumnName;
            }

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    xlWs.Cells[i + 2, j + 1] = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                }
            }
            xlWs.Columns.AutoFit();

            xlWs = (Excel.Worksheet)xlWb.Worksheets.get_Item(1);
            xlWs.Name = "LedgerTotals";

            System.Threading.Thread.Sleep(30000); //milliseconds - 30 seconds

            da = new SqlDataAdapter(
                "select " +
                "LEDGER, " +
                "[DESCRIPTION], " +
                "cast(((sum(sales))* -1) as decimal (20,2)) as [CLOSING BALANCE] from  " +
                "AuditRevenueS1 " +
                "group by  " +
                "ledger, DESCRIPTION " +
                "having sum(sales) != 0 " +
                "order by ledger ", cnxn);

            da.SelectCommand.CommandTimeout = 0;
            ds = new DataSet();
            da.Fill(ds);

            for (int i = 1; i <= ds.Tables[0].Columns.Count; i++)
            {
                xlWs.Cells[1, i] = ds.Tables[0].Columns[i - 1].ColumnName;
            }

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    xlWs.Cells[i + 2, j + 1] = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                }
            }
            xlWs.Columns.AutoFit();
            

            xlWb.SaveAs(@"C:\A\GLAudit" + g.Fperiod.ToString() + ".xls",
                             Excel.XlFileFormat.xlWorkbookNormal,
                             Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                             Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value,
                             Missing.Value, Missing.Value, Missing.Value);*/

            xlWb.Close();

            Application.Exit();            
        }
    }
}
