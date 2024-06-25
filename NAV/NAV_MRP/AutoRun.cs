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
    public partial class AutoRun : Form
    {
        private bool run = false;
        public AutoRun()
        {
            InitializeComponent();
        }

        private void AutoRun_Load(object sender, EventArgs e)
        {
            this.Text = "MRP Data Sheets Running";
        }

        private void AutoRun_Activated(object sender, EventArgs e)
        {
            if (run is false)
            {
                /*      Main report     */

                g.SQLselection = g.Main + g.dateAndAction;
                g.ReportSelection = " Purchase News ";
                MRP_PrintedReport r = new MRP_PrintedReport();
                r.ShowDialog();

                g.SQLselection = g.Main + g.Reschedule + g.Main + g.dateAndAction + " )";
                g.ReportSelection = " Reschedules ";
                MRP_PrintedReport rr = new MRP_PrintedReport();
                rr.ShowDialog();


                /*  MinMAx    */

                g.SQLselection = g.MinMax + g.dateAndAction;
                g.ReportSelection = "MinMax Purchase News ";
                MRP_PrintedReport t = new MRP_PrintedReport();
                t.ShowDialog();

                g.SQLselection = g.MinMax + g.Reschedule + g.MinMax + g.dateAndAction + ")";
                g.ReportSelection = "MinMax Reschedules ";
                MRP_PrintedReport tt = new MRP_PrintedReport();
                tt.ShowDialog();

                /*  X    */

                g.SQLselection = g.X + g.dateAndAction;
                g.ReportSelection = "X Purchase News ";
                MRP_PrintedReport u = new MRP_PrintedReport();
                u.ShowDialog();

                g.SQLselection = g.X + g.Reschedule + g.X + g.dateAndAction + " )";
                g.ReportSelection = "X Reschedules ";
                MRP_PrintedReport uu = new MRP_PrintedReport();
                uu.ShowDialog();

                /*  Irvine    */

                g.SQLselection = g.Irvine + g.dateAndAction;
                g.ReportSelection = "Irvine Purchase News ";
                MRP_PrintedReport s = new MRP_PrintedReport();
                s.ShowDialog();

                g.SQLselection = g.Irvine + g.Reschedule + g.Irvine + g.dateAndAction + " )";
                g.ReportSelection = "Irvine Reschedules ";
                MRP_PrintedReport ss = new MRP_PrintedReport();
                ss.ShowDialog();

                ///*  Richmond    */

                g.SQLselection = g.Richmond + g.dateAndAction;
                g.ReportSelection = "Richmond Purchase News ";
                MRP_PrintedReport v = new MRP_PrintedReport();
                v.ShowDialog();


                g.SQLselection = g.Richmond + g.Reschedule + g.Richmond + g.dateAndAction + " )";
                g.ReportSelection = "Richmond Reschedules ";
                MRP_PrintedReport vv = new MRP_PrintedReport();
                vv.ShowDialog();

                /*  MRP KBP    */
                g.ReportSelection = "KBP Purchase News ";
                g.SQLselection = g.KBP + g.dateAndAction;
                MRP_PrintedReport k = new MRP_PrintedReport();
                k.ShowDialog();


                g.ReportSelection = "KBP Reschedules ";
                g.SQLselection = g.KBP + g.Reschedule + g.KBP + g.dateAndAction + " )";
                MRP_PrintedReport kk = new MRP_PrintedReport();
                kk.ShowDialog();


                /*  LTA    */
                g.ReportSelection = "LTA ";
                g.SQLselection = g.LTA;
                LTA l = new LTA();
                l.ShowDialog();

                //run = true;

                this.Close();
            }
        }
    }
}
