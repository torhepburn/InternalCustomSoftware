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

namespace AuditReportAccountDetails
{
    public partial class AuditDetails : Form
    {
        SqlConnection cnxn;
        DataSet ds;
        SqlDataAdapter da2;
        private string startLimit;
        private string endLimit;

        public AuditDetails()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startLimit = DateTime.Now.ToString("yyyy") + "12";
            endLimit = DateTime.Now.AddYears(2).ToString("yyyy") + "01";

            cnxn = new SqlConnection(g.db);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select " +
                    "distinct ledger_account from " +
                    "[dbo].[GL_Adjusted_Posted_Ledger_Transactions] " +
                    "order by LEDGER_ACCOUNT ", cnxn);
                DataTable table = new DataTable();
                da.Fill(table);
                DGV1.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                da2 = new SqlDataAdapter("select " +
                    "cost_center, cost_center_description from mmx_cost_centers " +
                    "where cost_center_description not like 'no longer%' " +
                    "order by cost_center",  cnxn);
                DataTable table2 = new DataTable();
                da2.Fill(table2);
                DGV2.DataSource = table2;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnxn.Close();
        }

        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 3)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                   (DataGridViewTextBoxCell)DGV1.Rows[e.RowIndex].Cells[0];
                tbAccountCode.Text += cell.EditedFormattedValue.ToString().Trim() + ", ";
            }
        }

        private void DGV2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 3)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[0];
                tbCostCenters.Text += cell.EditedFormattedValue.ToString().Trim() + ", ";
            }
        }

        private void bGetData_Click(object sender, EventArgs e)
        {
            g.accountSelect = tbAccountCode.Text.TrimEnd(',', ' ');
            g.costcenterSelect = tbCostCenters.Text.TrimEnd(',', ' ');

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select " +
                    "LEDGER_ACCOUNT, " +
                    "COST_CENTER, " +
                    "LINE_REFERENCE, " +
                    "BATCH_NUMBER, " +
                    "JOURNAL_NUMBER, " +
                    "IIF(DEBIT_CREDIT_INDICATOR = 1, AMOUNT, (AMOUNT * -1)) AMOUNT, " +
                    "PERIOD_NUMBER, " +
                    "BOOKING_POSTING_DATE " +
                    "from GL_Adjusted_Posted_Ledger_Transactions " +
                    "where PERIOD_NUMBER > " + startLimit + " and PERIOD_NUMBER < " + endLimit + " " +
                    "and LEDGER_ACCOUNT in (" + g.accountSelect + ") and " +
                    "cost_center in (" + g.costcenterSelect + ") " +
                    "order by LEDGER_ACCOUNT, COST_CENTER ", cnxn);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            Excel.Application xlAp;
            Excel.Workbook xlWb;
            Excel.Worksheet xlWs;

            xlAp = new Excel.Application();
            xlWb = xlAp.Workbooks.Add(Missing.Value);
            xlWs = (Excel.Worksheet)xlWb.Worksheets.get_Item(1);
            xlWs.Name = "AccountDetails";

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


            System.Threading.Thread.Sleep(30000); //milliseconds - 30 seconds

            xlWb.SaveAs(@"C:\A\GLAudit.xls",
                             Excel.XlFileFormat.xlWorkbookNormal,
                             Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                             Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value,
                             Missing.Value, Missing.Value, Missing.Value);

            xlWb.Close();

            Application.Exit();            

            //Results r = new Results();
            //r.ShowDialog();
        }

        private void bCurrentFY_Click(object sender, EventArgs e)
        {
            startLimit = DateTime.Now.ToString("yyyy") + "12";
            endLimit = DateTime.Now.AddYears(2).ToString("yyyy") + "01";
        }

        private void bLastFY_Click(object sender, EventArgs e)
        {
            startLimit = DateTime.Now.AddYears(-1).ToString("yyyy") + "12";
            endLimit = DateTime.Now.AddYears(1).ToString("yyyy") + "01";

        }
    }

    public static class g
    {
        public static string FYear;
        public static string Fperiod;
        public static string taskgroup;

        public static string accountSelect;
        public static string costcenterSelect;
        public static bool freeText;
        public static string printer;
        public static string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = GeneralLedger;";
    }
}

