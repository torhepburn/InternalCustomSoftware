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
using System.Drawing;
using System.IO;

namespace Certs
{
    public partial class F0281_03_Page_2 : Form
    {
        public F0281_03_Page_2()
        {
            InitializeComponent();
        }

        private void F0281_03_Page_2_Load(object sender, EventArgs e)
        {
            PrintDocument pd2 = new PrintDocument();
            //pd2.DefaultPageSettings.Landscape = true;
            pd2.PrintPage += new PrintPageEventHandler(pd2_PrintPage);

            PrintPreviewDialog ppd2 = new PrintPreviewDialog();
            ppd2.Document = pd2;
            (ppd2 as Form).WindowState = FormWindowState.Maximized;
            ppd2.ShowDialog();

        }

        private void pd2_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Image i2 = Image.FromFile("C:\\A\\png_test.png");

            i2.RotateFlip(RotateFlipType.Rotate90FlipNone);

            Rectangle m = ev.MarginBounds;

            if ((double)i2.Width / (double)i2.Height > (double)m.Width / (double)m.Height) // image is wider
            {
                m.Height = (int)((double)i2.Height / (double)i2.Width * (double)m.Width);
            }
            else
            {
                m.Width = (int)((double)i2.Width / (double)i2.Height * (double)m.Height);
            }
            //args.Graphics.DrawImage(i, m);
            ev.Graphics.DrawImage(i2, m);
            //ev.Graphics.DrawImage(i2, ev.PageBounds);
            Font arial = new Font("arial", 10, FontStyle.Regular);
            ev.Graphics.DrawString("Certification Number " + g.certificationNumber, arial, Brushes.Black, 50, 1050);
            ev.Graphics.DrawString("Page 2 of 2", arial, Brushes.Black, 650,1050);
        }
    }
}
