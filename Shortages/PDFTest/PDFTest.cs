using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace PDFTest
{
    public partial class Form1 : Form
    {
        private int lineno = 0;
        private int limit = 30;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                pd.Print();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            string date = DateTime.Now.ToString();
            Font A9R = new Font("arial", 9, FontStyle.Regular);
            int linedrop = 100;
            int count = 0;


            while (count < 10 && lineno < limit)
            {
                ev.Graphics.DrawString("Data as of: " + date, A9R, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString(count.ToString(), A9R, Brushes.Black,250, linedrop);
                count++;
                lineno++;
                linedrop = linedrop + 100;
            }

            if (limit > lineno)
            {
                ev.HasMorePages = true;
                /*
                 *  HasMorePages = true sends control back to pd_PrintPage
                 *  count goes back to zero
                 */

            }
            else
            {
                ev.HasMorePages = false;
            }


        }
    }
}
