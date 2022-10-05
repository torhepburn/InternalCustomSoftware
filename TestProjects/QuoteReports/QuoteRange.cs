using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;

namespace QuoteReports
{
    public partial class QuoteRange : Form
    {
        DateTime start;
        DateTime end;
        private string bottomLimit;
        private string SumAddress;
        
        public QuoteRange()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            start = monthCalendar1.SelectionStart;
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            end = monthCalendar2.SelectionStart;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (start.Year.ToString() == "1")
            {
                MessageBox.Show("Must Select a Start Date");
                return;
            }
            if (end.Year.ToString() == "1")
            {
                MessageBox.Show("Must Select an End Date");
                return;
            }

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
                 "where (lastmodified >= '" + start + "' and " +
                 "lastmodified <= '" + end + "') " +
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
            // this adds one sheet only
            Microsoft.Office.Interop.Excel.Workbook wb =
                xl.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

            //this adds three sheets
            //Microsoft.Office.Interop.Excel.Workbook wb =
            //    xl.Workbooks.Add(Type.Missing);

            Microsoft.Office.Interop.Excel.Worksheet sheet1 =
                (Microsoft.Office.Interop.Excel.Worksheet)wb.Sheets[1];

            Microsoft.Office.Interop.Excel.Worksheet sheet2 =
            wb.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing)
                as Microsoft.Office.Interop.Excel.Worksheet;

            string str1 = start.ToShortDateString();
            string str0 = str1.Replace('/', '-');
            str1 = str0 + " to ";
            str0 = end.ToShortDateString();
            string str2 = str0.Replace('/', '-');
            str1 = str1 + str2;
            sheet1.Name = "PN Summary ";
            sheet2.Name = "Sales Rep Summary ";

            int c = 1;

            foreach (DataColumn dc in table.Columns)
            {
                sheet1.Cells.set_Item(1, c, dc.ToString());
                c++;
            }

            int r = 2;
            foreach (DataRow dr in table.Rows)
            {
                foreach (DataColumn dc in table.Columns)
                {
                    sheet1.Cells.set_Item(r, (dc.Ordinal + 1), dr[dc].ToString());
                }
                r++;
            }
            sheet1.Columns.AutoFit();

            //put formula in cell
            bottomLimit = "A" + (table.Rows.Count + 1);
            SumAddress = "A" + (table.Rows.Count + 3);
            Microsoft.Office.Interop.Excel.Range sum_range
                = sheet1.get_Range(SumAddress, SumAddress);
            sum_range.Formula = "=sum(A2:" + bottomLimit + ")";
            //write to cell from C#
            sheet1.Cells[(table.Rows.Count + 3), 2] = "Total Times Part Numbers Quoted";

            da = new SqlDataAdapter
                ("select " +
                 "salesrep, " +
                 "count(manufacturerpartnumber) as [Times Quoted], " +
                 "manufacturerpartnumber as PN, " +
                 "max(left(cast(i.[description] as nvarchar), 50)) " +
                 "as [Description] " +
                 "from documentheaders h left join " +
                 "documentitems i on " +
                 "h.id = i.docid " +
                 "where (lastmodified >= '" + start + "' and " +
                 "lastmodified <= '" + end + "') " +
                 "and (len(i.manufacturerpartnumber) !=0 " +
                 "and (ascii(manufacturerpartnumber)) > 47 " +
                 "and (ascii(manufacturerpartnumber)) < 58 " +
                 "or left(manufacturerpartnumber, 4) = 'Ser ') " +
                 "group by salesrep, manufacturerpartnumber " +
                 "order by salesrep, manufacturerpartnumber", cnxn);

            System.Data.DataTable tableS = new System.Data.DataTable();
            da.Fill(tableS);

            c = 1;

            foreach (DataColumn dc in tableS.Columns)
            {
                sheet2.Cells.set_Item(1, c, dc.ToString());
                c++;
            }

            r = 2;
            foreach (DataRow dr in tableS.Rows)
            {
                foreach (DataColumn dc in tableS.Columns)
                {
                    sheet2.Cells.set_Item(r, (dc.Ordinal + 1), dr[dc].ToString());
                }
                r++;
            }
            sheet2.Columns.AutoFit();

            wb.Close(true, "Quote Report " + str1, System.Type.Missing);


            xl.Quit();
 
        }
    }
}