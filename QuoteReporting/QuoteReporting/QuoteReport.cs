using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;


namespace QuoteReporting
{
    public partial class QuoteReport : Form
    {
        private int dow;
        DateTime weekStart;
        DateTime weekEnd;
        private string str1;
        private string str0;
        private string bottomLimit;
        private string SumAddress;

        public QuoteReport()
        {
            InitializeComponent();
        }

        private void QuoteReport_Load(object sender, EventArgs e)
        {
        

        }
               
        private void QuoteReport_Activated(object sender, EventArgs e)
        {
            weekStart = (DateTime.Now.AddDays(-8));
            weekEnd = DateTime.Now;

            SqlConnection cnxn = new SqlConnection("server=ct-mid-as37.zygo.com\\sqlexpress; user=sa; " +
                                                   "password=uaPQB983; database=quotewerks;");
            //SqlConnection cnxn = new SqlConnection("server=ct-mid-as37\\sqlexpress; user=ReadRead; " +
            //                                       "password=Read+Read; database=quotewerks;");


            //SqlDataAdapter da = new SqlDataAdapter
            //    ("select " +
            //     "count(i.manufacturerpartnumber) as [Times Quoted], " +
            //     "i.manufacturerpartnumber as [Part Number], " +
            //     "max(left(cast(i.[description] as nvarchar),50)) as [Description] " +
            //     "from documentheaders h left join " +
            //     "documentitems i on " +
            //     "h.id = i.docid " +
            //     "where (lastmodified > '" + weekStart + "' and " +
            //     "lastmodified < '" + weekEnd + "') " +
            //     "and (len(i.manufacturerpartnumber) !=0 " +
            //     "and (ascii(manufacturerpartnumber)) > 47 " +
            //     "and (ascii(manufacturerpartnumber)) < 58 " +
            //     "or left(manufacturerpartnumber, 4) = 'Ser ') " +
            //     "group by manufacturerpartnumber " +
            //     "order by manufacturerpartnumber", cnxn);

            //da.SelectCommand.CommandTimeout = 240; /*   4 minutes   default is 30 seconds  */

            SqlCommand cmd = new SqlCommand
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

            cmd.CommandTimeout = 240;

            cnxn.Open();

            SqlDataReader dar = cmd.ExecuteReader();

            System.Data.DataTable table = new System.Data.DataTable();
            //da.Fill(table);
            table.Load(dar);

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

            Microsoft.Office.Interop.Excel.Worksheet sheet3 =
            wb.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing)
                as Microsoft.Office.Interop.Excel.Worksheet;

            string str1 = weekStart.ToShortDateString();
            str0 = str1.Replace('/', '-');
            sheet3.Name = "PN Summary " + str0;
            sheet2.Name = "Sales Rep Summary " + str0;
            sheet1.Name = "Sales Rep Details " + str0;

            int c = 1;

            foreach (DataColumn dc in table.Columns)
            {
                sheet3.Cells.set_Item(1, c, dc.ToString());
                c++;
            }

            int r = 2;
            foreach (DataRow dr in table.Rows)
            {
                foreach (DataColumn dc in table.Columns)
                {
                    sheet3.Cells.set_Item(r, (dc.Ordinal + 1), dr[dc].ToString());
                }
                r++;
            }
            sheet3.Columns.AutoFit();

            //put formula in cell
            bottomLimit = "A" + (table.Rows.Count + 1);
            SumAddress = "A" + (table.Rows.Count + 3);
            Microsoft.Office.Interop.Excel.Range sum_range
                = sheet3.get_Range(SumAddress, SumAddress);
            sum_range.Formula = "=sum(A2:" + bottomLimit + ")";
            //write to cell from C#
            sheet3.Cells[(table.Rows.Count + 3), 2] = "Total Quotes";

            //da = new SqlDataAdapter
            //    ("select " +
            //     "salesrep, " +
            //     "count(manufacturerpartnumber) as [Times Quoted], " +
            //     "manufacturerpartnumber as PN, " +
            //     "max(left(cast(i.[description] as nvarchar), 50)) " +
            //     "as [Description] " +
            //     "from documentheaders h left join " +
            //     "documentitems i on " +
            //     "h.id = i.docid " +
            //     "where (lastmodified > '" + weekStart + "' and " +
            //     "lastmodified < '" + weekEnd + "') " +
            //     "and (len(i.manufacturerpartnumber) !=0 " +
            //     "and (ascii(manufacturerpartnumber)) > 47 " +
            //     "and (ascii(manufacturerpartnumber)) < 58 " +
            //     "or left(manufacturerpartnumber, 4) = 'Ser ') " +
            //     "group by salesrep, manufacturerpartnumber " +
            //     "order by salesrep, manufacturerpartnumber", cnxn);

            //da.SelectCommand.CommandTimeout = 240;

            System.Data.DataTable tableS = new System.Data.DataTable();
            //da.Fill(tableS);

            cmd = new SqlCommand
                ("select " +
                 "salesrep, " +
                 "count(manufacturerpartnumber) as [Times Quoted], " +
                 "manufacturerpartnumber as PN, " +
                 "max(left(cast(i.[description] as nvarchar), 50)) " +
                 "as [Description] " +
                 "from documentheaders h left join " +
                 "documentitems i on " +
                 "h.id = i.docid " +
                 "where (lastmodified > '" + weekStart + "' and " +
                 "lastmodified < '" + weekEnd + "') " +
                 "and (len(i.manufacturerpartnumber) !=0 " +
                 "and (ascii(manufacturerpartnumber)) > 47 " +
                 "and (ascii(manufacturerpartnumber)) < 58 " +
                 "or left(manufacturerpartnumber, 4) = 'Ser ') " +
                 "group by salesrep, manufacturerpartnumber " +
                 "order by salesrep, manufacturerpartnumber", cnxn);

            cmd.CommandTimeout = 240;

            dar = cmd.ExecuteReader();

            tableS.Load(dar);


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

            //da = new SqlDataAdapter
            //    ("select " +
            //     "SalesRep, " +
            //     "DocNo as [Quote #], " +
            //     "QtyTotal, " +
            //     "ExtendedPrice, " +
            //     "UnitPrice, " +
            //     "manufacturerpartnumber as PN, " +
            //     "i.[Description], " +
            //     "soldtocity as City, " +
            //     "soldtostate as State, " +
            //     "soldtocompany Company, " +
            //     "soldtocontact Contact " +
            //     ",LastModified " +
            //     ",Created " +
            //     "from documentheaders h left join " +
            //     "documentitems i on " +
            //     "h.id = i.docid " +
            //     "where (lastmodified > '" + weekStart + "' and " +
            //     "lastmodified < '" + weekEnd + "') " +
            //     "and (len(i.manufacturerpartnumber) !=0 " +
            //     "and (ascii(manufacturerpartnumber)) > 47 " +
            //     "and (ascii(manufacturerpartnumber)) < 58 " +
            //     "or left(manufacturerpartnumber, 4) = 'Ser ') " +
            //     "order by salesrep, manufacturerpartnumber", cnxn);

            System.Data.DataTable tableD = new System.Data.DataTable();

            //da.SelectCommand.CommandTimeout = 240;
            //da.Fill(tableD);

            cmd = new SqlCommand
                ("select " +
                 "SalesRep, " +
                 "DocNo as [Quote #], " +
                 "QtyTotal, " +
                 "ExtendedPrice, " +
                 "UnitPrice, " +
                 "manufacturerpartnumber as PN, " +
                 "i.[Description], " +
                 "soldtocity as City, " +
                 "soldtostate as State, " +
                 "soldtocompany Company, " +
                 "soldtocontact Contact " +
                 ",LastModified " +
                 ",Created " +
                 "from documentheaders h left join " +
                 "documentitems i on " +
                 "h.id = i.docid " +
                 "where (lastmodified > '" + weekStart + "' and " +
                 "lastmodified < '" + weekEnd + "') " +
                 "and (len(i.manufacturerpartnumber) !=0 " +
                 "and (ascii(manufacturerpartnumber)) > 47 " +
                 "and (ascii(manufacturerpartnumber)) < 58 " +
                 "or left(manufacturerpartnumber, 4) = 'Ser ') " +
                 "order by salesrep, manufacturerpartnumber", cnxn);

            cmd.CommandTimeout = 240;

            dar = cmd.ExecuteReader();

            tableD.Load(dar);

            c = 1;

            foreach (DataColumn dc in tableD.Columns)
            {
                sheet1.Cells.set_Item(1, c, dc.ToString());
                c++;
            }

            r = 2;
            foreach (DataRow dr in tableD.Rows)
            {
                foreach (DataColumn dc in tableD.Columns)
                {
                    sheet1.Cells.set_Item(r, (dc.Ordinal + 1), dr[dc].ToString());
                }
                r++;
            }
            sheet1.Columns.AutoFit();

            wb.Close(true, "Quotes Past Week Beginning " + str0, System.Type.Missing);

            //wb.Save();

            xl.Quit();

            this.Close();
        }
    }

}
