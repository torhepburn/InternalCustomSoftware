using System.Drawing.Printing;
using System.IO;

namespace PrintTest
{
    public partial class PrintTest : Form
    {
        public PrintTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string file = "MRP Cancel .pdf";


            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            pd.PrinterSettings.PrintToFile = true;
            pd.PrinterSettings.PrintFileName = Path.Combine(directory, file);
            StandardPrintController pc = new StandardPrintController();
            pd.PrintController = pc;

            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ItemNo + " " + i.ToString() + "    " + ex.ToString());
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            /*
             * 
             *  PrintPage runs all the way to the bottom bracket "}"
             *  before evaluating if there is another page and
             *  then runs through again.
             * 
             */

            string date = DateTime.Now.ToString();

            DateTime MRPSunday = DateTime.Now;
            while (MRPSunday.DayOfWeek != DayOfWeek.Sunday)
                MRPSunday = MRPSunday.AddDays(-1);

            string reportSunday = MRPSunday.ToShortDateString();

            int linedrop = 100;

            //if (!partOnePrinted[lineNo])
            //{
            //    linedrop = 100;
            //}


            int linesPerpage = 30;  //40
            //int lineNo = this.pagesPrinted * linesPerpage;
            int pageNo = pagesPrinted + 1;
            //double NumPages = Math.Ceiling(((i - 1) / 24.0));
            double NumPages = Convert.ToDouble(i);
            NumPages = NumPages + Convert.ToDouble(extraPageCount);

            Pen pen = new Pen(Color.Red);
            Pen Gpen = new Pen(Color.Green);
            Pen Bpen = new Pen(Color.Turquoise);
            Pen Ypen = new Pen(Color.Orange);
            Ypen.Width = 25;
            Gpen.Width = 3;
            pen.Width = 1;
            Font A9R = new Font("arial", 9, FontStyle.Regular);
            Font title = new Font("arial", 16, FontStyle.Bold);
            Font heading = new Font("arial", 9, FontStyle.Bold);
            Font B12 = new Font("arial", 12, FontStyle.Bold);
            Font U9 = new Font("arial", 9, FontStyle.Underline);
            StringFormat alignR = new StringFormat();
            alignR.Alignment = StringAlignment.Far;
            int n = 0;

            //  the print location is X, Y

            if (shortage[lineNo] != "")
            {
                ev.Graphics.DrawLine(Ypen, 25, 10, 800, 10);
                ev.Graphics.DrawString("SHORTAGE ID = " + shortage[lineNo], A9R, Brushes.Black, 250, 10);
                ev.Graphics.DrawString("SHORTAGE Product Line = " + shortageProductLine[lineNo], A9R, Brushes.Black, 450, 10);
            }

            /*
             * if (partOnePrinted[lineNo] && (!partTwoPrinted[lineNo]) & !twoPagesRequired[lineNo])
             * if (pageOnePrinted[lineNo] && (!partTwoPrinted[lineNo]) & twoPagesRequired[lineNo])
             * */
            if (twoPagesRequired[lineNo])
            {
                ev.Graphics.DrawString("Two Pages Required for " + aItemNo[lineNo], A9R, Brushes.Black, 25, 50);
            }

            ev.Graphics.DrawString("Data as of: " + date, A9R, Brushes.Black, 25, 25);
            ev.Graphics.DrawString(abuyerPlanner[lineNo], heading, Brushes.Black, 350, 25);
            ev.Graphics.DrawString("MRP Date: " + reportSunday, A9R, Brushes.Black, 600, 25);
            ev.Graphics.DrawString("Page  " + pageNo + " of " + NumPages, A9R, Brushes.Black, 600, 50);

            if (aVettedStatus[lineNo] == "1")
            {
                ev.Graphics.DrawString("*************** ......NON-VETTED...... ***************", B12, Brushes.Purple, 225, 50);
            }
            ////File.AppendAllText(@"C:\A\PrintStartMRP .txt", DateTime.Now.ToShortTimeString() + Environment.NewLine);

            ev.Graphics.DrawLine(pen, 25, 70, 800, 70);


            if (!partOnePrinted[lineNo])
            {
                print_PartOne(ev, linedrop);
                partOnePrinted[lineNo] = true;
            }

            /*  part one printed - part two not printed - two pages not required    */

            //if (partOnePrinted[lineNo] && (!partTwoPrinted[lineNo]) & !twoPagesRequired[lineNo])
            //{
            //    print_PartTwo(ev, linedrop);
            //    partTwoPrinted[lineNo] = true;
            //}

            /*  for two page parts  */



            if (twoPagesRequired[lineNo])
            {
                if (pageOnePrinted[lineNo] && !partTwoPrinted[lineNo])
                {
                    if (aMRPCurrentPagePlus1[lineNo] < 1)
                    {
                        print_PartTwo(ev, linedrop);
                        partTwoPrinted[lineNo] = true;
                    }
                    else
                    {
                        printCurrentOverflow(ev);
                        //print_PartTwo(ev, linedrop);
                        partTwoPrinted[lineNo] = true;
                    }
                }

                if (partOnePrinted[lineNo] && !partTwoPrinted[lineNo])
                {
                    ev.HasMorePages = true;
                    pageOnePrinted[lineNo] = true;
                    pagesPrinted++;

                }

                if (partOnePrinted[lineNo] && partTwoPrinted[lineNo])
                {
                    lineNo++;

                    if (i > lineNo)
                    {
                        ev.HasMorePages = true;
                        pagesPrinted++;
                    }
                }
            }

            else
            {
                if ((i - 1) > lineNo)
                {
                    ev.HasMorePages = true;
                    pageOnePrinted[lineNo] = true;
                    pagesPrinted++;
                }
                else
                {
                    ev.HasMorePages = false;
                    linedrop = 160;
                    pagesPrinted = 0;
                    lineNo = 0;
                }

                lineNo++;
            }

        }

    }
}