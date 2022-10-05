using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            KBP k = new KBP();
            k.ShowDialog();
        }
    }

    public static class g
    {
        public static string SQLselection;
        public static string ReportSelection;
        public static string Main = "AND i.[Selection Code] <> 'MMX' " +
                             "AND i.[Vetted] <> '1' " +
                             "AND i.[Item Group Code] <> 'VMI'  " +
                             "AND CHARINDEX('X', r.No_, 1) <> 1 " +
                             "AND [Reference Component] <> 1 " +
                             "AND r.[Starting Date] <= (GETDATE() + 7) " +
                             "AND r.[Location Code]  NOT IN ('IRV', 'IRV MRB', 'RIC', 'RIC MRB') ";

        public static string Irvine = "AND i.[Selection Code] <> 'MMX' " +
                             "AND i.[Item Group Code] <> 'VMI'  " +
                             "AND [Reference Component] <> 1 " +
                             "AND r.[Starting Date] <= (GETDATE() + 28) " +
                             "AND r.[Location Code] IN ('IRV', 'IRV MRB') ";

        public static string MinMax = "AND ((i.[Selection Code] = 'MMX' " +
                             "AND [Reference Component] <> 1) " +
                             "OR ([Reference Component] = 1 AND ([Item Group Code] = 'CNT' OR [Selection Code] = 'SIC'))) " +
                             "AND i.[Vetted] <> '1' " +
                             "AND i.[Item Group Code] <> 'VMI' " +
                             "AND r.[Starting Date] <= (GETDATE() + 7) " +
                             "AND CHARINDEX('X', r.No_, 1) <> 1 ";

        public static string X = "AND (CHARINDEX('X', r.No_, 1) = 1 OR i.[Vetted] = '1') " +
                            "AND [Reference Component] <> 1 " +
                            "AND r.[Starting Date] <= (GETDATE() + 7) " +
                            "AND r.[Location Code] NOT IN ('IRV', 'IRV MRB') " +
                            "AND i.[Item Group Code] <> 'VMI'  ";

        public static string Richmond = "AND i.[Selection Code] <> 'MMX' " +
                             "AND i.[Vetted] <> '1' " +
                             "AND i.[Item Group Code] <> 'VMI'  " +
                             "AND CHARINDEX('X', r.No_, 1) <> 1 " +
                             "AND r.[Starting Date] <= (GETDATE() + 7) " +
                             "AND [Reference Component] <> 1 " +
                             "AND r.[Location Code] IN ('RIC', 'RIC MRB', 'RIC SVC') ";

        public static string sMRP = "SELECT " +
                        "CONVERT(varchar(10),[Starting Date], 1) " +
                        ",CONVERT(varchar(10),l.[Due Date], 1) " +
                        ",FORMAT([Remaining Quantity],'N0', 'en-us') " +
                        ",FORMAT([Cost Amount]," +
                        " 'C', 'en-us') " +
                        ",l.[Location Code] " +
                        ",l.[Bin Code] " +
                         ",CASE[Action Message] " +
                        "     WHEN 1 THEN 'New' " +
                        "     WHEN 2 THEN '+Qty' " +
                        "     WHEN 3 THEN 'Resched' " +
                        "     WHEN 4 THEN '+Qty+Date' " +
                        " END " +
                        ",CONVERT(varchar(10),l.[Original Due Date], 1) " +
                        ",CASE COALESCE(pl.[Best Delivery],0) " +
                        "   WHEN 0 THEN '' " +
                        "   WHEN 1 THEN 'YES' " +
                        "END " +
                        "from [ZYGO$Requisition Line] l " +
                        "LEFT JOIN [ZYGO$Purchase Line] pl  " +
                        "ON l.[Ref_ Order No_] = pl.[Document No_] " +
                        "AND l.[Ref_ Line No_] = pl.[Line No_] " +
                        "WHERE " +
                        "[Ref_ Order Type] = 1 " +
                        "AND l.Type = 2 " +                                   // type 2 = item
                        "AND [Worksheet Template Name] = 'PLANNING' " +
                        "AND [Journal Batch Name] = 'DEFAULT' " +
                        "AND  l.[No_] = '";

    }
}
