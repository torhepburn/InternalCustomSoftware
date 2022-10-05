using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AuditReportRevenue
{
    public partial class F1_GetData : Form
    {
        
        DataTable dt;
        DataColumn dc;
        DataRow drow;

        public F1_GetData()
        {
            InitializeComponent();
        }

        private void F1_GetData_Load(object sender, EventArgs e)
        {
            int y = DateTime.Now.Year;

            dt = new DataTable();
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Int32");
            dc.ColumnName = "FiscalYear";

            dt.Columns.Add(dc);

            for (int i = -5; i < 2; i++)
            {
                drow = dt.NewRow();
                drow[0] = y + i;
                dt.Rows.Add(drow);
            }

            DGV.DataSource = dt;
            DGV.Show();
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.FYear = cell.EditedFormattedValue.ToString().Trim();

                F2_Period f2 = new F2_Period();
                f2.ShowDialog();
            }
        }
    }

    public static class g
    {
        public static string FYear;
        public static string Fperiod;
        public static string taskgroup;

        public static string amps;
        public static string model;
        public static bool freeText;
        public static string printer;
        public static string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = GeneralLedger;";
    }
}
