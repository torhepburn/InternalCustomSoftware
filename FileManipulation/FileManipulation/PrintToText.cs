using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Printing;

namespace FileManipulation
{
    public partial class PrintToText : Form
    {
        SqlConnection cnxn = new SqlConnection("server=midsql01; user= readWrite; password = Read+Write!; " +
            "database=AccessFrontends;");
        SqlDataAdapter da;
        DataTable table;
        private int pagesPrinted = 0;
        private int i;
         
        public PrintToText()
        {
            InitializeComponent();
        }

        private void PrintToText_Load(object sender, EventArgs e)
        {
            
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter
                ("select " +
                 "b.manufactured_item, " +
                 "b.position, " +
                 "b.item_code_component, " +
                 "i.[description], " +
                 "b.phantom," +
                 "b.net_quantity " +
                 "from mmx_production_bom b inner join mmx_item_data i on " +
                 "b.item_code_component = i.item_code where [manufactured_item] = '" + tbBOM.Text.Trim() + "' " +
                 "order by b.position", cnxn);

            table = new DataTable();

            da.Fill(table);
            
            i = table.Rows.Count;
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            (ppd as Form).WindowState = FormWindowState.Maximized;
            ppd.ShowDialog();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Font arial = new System.Drawing.Font("arial", 8, FontStyle.Regular);
            int lineDrop = 110;
            int count = 0;
            int linesPerPage = 40;
            int lineNo = this.pagesPrinted * linesPerPage;
            //ev.Graphics.DrawString(g.PMcategory, arial, Brushes.Black, 25, 40);
            ev.Graphics.DrawString("BOM for " + table.Rows[lineNo][0].ToString(), arial, Brushes.Black, 50, 40);
            ev.Graphics.DrawString(DateTime.Now.ToString(), arial, Brushes.Black, 650, 40);
            ev.Graphics.DrawString("Position", arial, Brushes.Black, 25, 80);
            ev.Graphics.DrawString("Item Code", arial, Brushes.Black, 100, 80);
            ev.Graphics.DrawString("Description", arial, Brushes.Black, 200, 80);
            ev.Graphics.DrawString("Phantom", arial, Brushes.Black, 500, 80);
            ev.Graphics.DrawString("Net Quantity", arial, Brushes.Black, 600, 80);
            //ev.Graphics.DrawString("Assigned to", arial, Brushes.Black, 650, 80);

            while (count < linesPerPage && lineNo < i)
            {
                ev.Graphics.DrawString(table.Rows[lineNo][1].ToString(), arial, Brushes.Black, 25, lineDrop);
                ev.Graphics.DrawString(table.Rows[lineNo][2].ToString(), arial, Brushes.Black, 100, lineDrop);
                ev.Graphics.DrawString(table.Rows[lineNo][3].ToString(), arial, Brushes.Black, 200, lineDrop);
                ev.Graphics.DrawString(table.Rows[lineNo][4].ToString(), arial, Brushes.Black, 500, lineDrop);
                ev.Graphics.DrawString(table.Rows[lineNo][5].ToString(), arial, Brushes.Black, 600, lineDrop);
                //trouble = table.Rows[lineNo][5].ToString();
                //trouble = trouble.Replace("\r\n", " ");
                //if (trouble.Length > 145)
                //{
                //    int SentEnd = trouble.IndexOf(" ", 135);
                //    ev.Graphics.DrawString(trouble.Substring(0, SentEnd), arial, Brushes.Black, 25, (lineDrop + 15));
                //    trouble = trouble.Substring((SentEnd + 1), (trouble.Length - (SentEnd + 1)));

                //    if (trouble.Length > 145)
                //    {
                //        SentEnd = trouble.IndexOf(" ", 135);
                //        ev.Graphics.DrawString(trouble.Substring(0, SentEnd), arial, Brushes.Black, 25, (lineDrop + 30));
                //        trouble = trouble.Substring((SentEnd + 1), (trouble.Length - (SentEnd + 1)));
                //        ev.Graphics.DrawString(trouble, arial, Brushes.Black, 25, (lineDrop + 45));
                //    }
                //    else
                //    {
                //        ev.Graphics.DrawString(trouble, arial, Brushes.Black, 25, (lineDrop + 30));
                //    }
                //}
                //else
                //{
                //    ev.Graphics.DrawString(trouble, arial, Brushes.Black, 25, (lineDrop + 15));
                //}

                lineDrop = lineDrop + 20;
                count++;
                lineNo++;
            }

            if (i > lineNo)
            {
                ev.HasMorePages = true;
                pagesPrinted++;
            }
            else
            {
                ev.HasMorePages = false;
                lineDrop = 160;
                count = 0;
                pagesPrinted = 0;
                lineNo = 0;
            }
        }

    }
}

