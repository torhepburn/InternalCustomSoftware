using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Printing;

namespace StapleTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //PrintDocument pd = new PrintDocument();
            //pd.DefaultPageSettings.Landscape = true;
            //pd.PrinterSettings.Collate = true;

            PrintQueue printQueue = null;
            LocalPrintServer lps = new LocalPrintServer();

            PrintQueueCollection localPrinterCollection =
                lps.GetPrintQueues();

            System.Collections.IEnumerator localPrinterEnumerator =
                localPrinterCollection.GetEnumerator();

            if (localPrinterEnumerator.MoveNext())
            {
                printQueue = (PrintQueue)localPrinterEnumerator.Current;
            }


            

            //PrintQueue que = LocalPrintServer.GetDefaultPrintQueue();
            
        }

        private PrintTicket GetPrintTicketFromPrinter()
        {

        }
    }
}
