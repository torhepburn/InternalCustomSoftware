using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace AuditReportAccountDetails
{
    public partial class Results : Form
    {
        DataSet ds;

        public Results()
        {
            InitializeComponent();
        }

        private void Results_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(g.db);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select " +
                    "* from [dbo].[GL_Adjusted_Posted_Ledger_Transactions] " +
                    "where PERIOD_NUMBER > 201512 and PERIOD_NUMBER< 201701 " +
                    "and LEDGER_ACCOUNT in (" + g.accountSelect + ") and " +
                    "cost_center in (" + g.costcenterSelect + ") " +
                    "order by LEDGER_ACCOUNT ", cnxn);
                ds = new DataSet();
                //DataTable table = new DataTable();
                da.Fill(ds);
                DGV.DataSource = ds.Tables[0];
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Bexcel_Click(object sender, EventArgs e)
        {
            SqlConnection cnxn;

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

        }
    }
}
