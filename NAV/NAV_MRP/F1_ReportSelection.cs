using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NAV_MRP
{
    public partial class F1_ReportSelection : Form
    {
        public F1_ReportSelection()
        {
            InitializeComponent();
        }

        private void F1_ReportSelection_Load(object sender, EventArgs e)
        {
            this.Text = "MRP Reports v" + Application.ProductVersion;
        }

        private void BMainReport_Click(object sender, EventArgs e)
        {
            BMainReport.BackColor = Color.FromArgb(0, 100, 0);
            BMainReport.Refresh();
            g.SQLselection = g.Main ;
            g.ReportSelection = "";

            MRP_PrintedReport r = new MRP_PrintedReport();
            r.ShowDialog();
            this.Close();
        }

        private void BIrvine_Click(object sender, EventArgs e)
        {
            BIrvine.BackColor = Color.FromArgb(200, 50, 200);
            BIrvine.Refresh();
            g.SQLselection = g.Irvine;
            g.ReportSelection = "Irvine ";
            MRP_PrintedReport r = new MRP_PrintedReport();
            r.ShowDialog();
            //this.Close();
        }

        private void BMinMax_Click(object sender, EventArgs e)
        {
            BMinMax.BackColor = Color.FromArgb(157, 75, 0);
            BMinMax.Refresh();
            g.SQLselection = g.MinMax;
            g.ReportSelection = "MinMax ";
            MRP_PrintedReport r = new MRP_PrintedReport();
            r.ShowDialog();
        }

        private void Bx_Click(object sender, EventArgs e)
        {
            Bx.BackColor = Color.FromArgb(0, 50, 200);
            Bx.Refresh();
            g.SQLselection = g.X;
            g.ReportSelection = "X Report ";
            MRP_PrintedReport r = new MRP_PrintedReport();
            r.ShowDialog();
        }

        private void bRichmond_Click(object sender, EventArgs e)
        {
            Brichmond.BackColor = Color.FromArgb(100, 50, 100);
            Brichmond.Refresh();
            g.SQLselection = g.Richmond;
            g.ReportSelection = "Richmond ";
            MRP_PrintedReport r = new MRP_PrintedReport();
            r.ShowDialog();
        }

        private void bKBP_Click(object sender, EventArgs e)
        {
            /*  MRP KBP    */
            bKBP.BackColor = Color.FromArgb(100, 50, 100);
            bKBP.Refresh();
            g.SQLselection = g.KBP;
            g.ReportSelection = "KBP";
            MRP_PrintedReport r = new MRP_PrintedReport();
            r.ShowDialog();
        }
    }

    
}
