using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuoteViewer
{
    public partial class QuoteViewer : Form
    {
        public QuoteViewer()
        {
            InitializeComponent();
        }

        private void bGetQuoteDetails_Click(object sender, EventArgs e)
        {
            ViewQuote q = new ViewQuote(tbQuoteNumber.Text);
            q.Show();
        }
    }
}
