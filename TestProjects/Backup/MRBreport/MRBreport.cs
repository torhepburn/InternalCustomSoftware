using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;


namespace MRBreport
{
    public partial class MRBreport : Form
    {
        private int dow;
        DateTime weekStart;
        DateTime weekEnd;
        //DataTable table;
        //BindingSource bs = new BindingSource();
        private string str1;
        private string str0;
        private string bottomLimit;
        private string SumAddress;
        
        public MRBreport()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            dow = ((int)monthCalendar1.SelectionStart.DayOfWeek);
            weekStart = monthCalendar1.SelectionStart.AddDays(-(dow));
            weekEnd = weekStart.AddDays(7);

            SqlConnection cnxn = new SqlConnection("server=midsrv04\\sqlexpress; user=views; " +
                "password=views; database=quotewerks;");
            SqlDataAdapter da = new SqlDataAdapter
                ("select " +
                 "count(i.manufacturerpartnumber) as [Times Quoted], " +
                 "i.manufacturerpartnumber as [Part Number], " +
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

            System.Data.DataTable table = new System.Data.DataTable();
            da.Fill(table);

            Microsoft.Office.Interop.Excel.Application xl =
                new Microsoft.Office.Interop.Excel.Application();
            xl.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb =
                xl.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet sheet =
                (Microsoft.Office.Interop.Excel.Worksheet)wb.Sheets[1];

            string str1 = weekStart.ToShortDateString();
            str0 = str1.Replace('/', '-');
            sheet.Name = "Week Beginning " + str0;

            int c = 1;

            foreach (DataColumn dc in table.Columns)
            {
                sheet.Cells.set_Item(1, c, dc.ToString());
                c++;
            }

            int r = 2;
            foreach (DataRow dr in table.Rows)
            {
                foreach (DataColumn dc in table.Columns)
                {
                    sheet.Cells.set_Item(r, (dc.Ordinal + 1), dr[dc].ToString());
                }
                r++;
            }
            sheet.Columns.AutoFit();

            //put formula in cell
            bottomLimit = "A" + (table.Rows.Count + 1);
            SumAddress = "A" + (table.Rows.Count + 3);
            Microsoft.Office.Interop.Excel.Range sum_range
                = sheet.get_Range(SumAddress, SumAddress);
            sum_range.Formula = "=sum(A2:" + bottomLimit + ")";
            //write to cell from C#
            sheet.Cells[(table.Rows.Count + 3), 2] = "Total Quotes";

            wb.Close(true, "Week Beginning " + str0, System.Type.Missing);
            xl.Quit();
        }
    }
}