using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace NAV_MRP
{
    public partial class F2_ReportSelection : Form
    {
        private bool run = false;
        public F2_ReportSelection()
        {
            InitializeComponent();
        }

        private void AutoRun_Load(object sender, EventArgs e)
        {
            this.Text = "MRP Data Sheets Running";
        }

        private async void AutoRun_Activated(object sender, EventArgs e)
        {

            
        }

        
        private void MainRescheduledSheets()
        {
            g.SQLselection = g.gMain;
            g.ReportSelection = " Reschedules ";
            g.ReportFilter = "MRP_s1o";
            F3_Sheets rr = new F3_Sheets();
            rr.ShowDialog();

            //await Task.Delay(1000);
        }

        private void KBP()
        {
            ///*  MRP KBP    */
            g.ReportSelection = "KBP Purchase News ";
            g.SQLselection = g.gKBP;
            g.ReportFilter = "MRP_s1p";
            F3_Sheets k = new F3_Sheets();
            k.ShowDialog();


            g.ReportSelection = "KBP Reschedules ";
            g.SQLselection = g.gKBP;
            g.ReportFilter = "MRP_s1o";
            F3_Sheets kk = new F3_Sheets();
            kk.ShowDialog();
        }

        private async Task reports()
        {
            /*      Main report     */

            g.SQLselection = g.gMain;
            g.ReportSelection = " Purchase News ";
            g.ReportFilter = "MRP_s1p";
            F3_Sheets r = new F3_Sheets();
            r.ShowDialog();


            /*  MinMAx    */

            g.SQLselection = g.gMinMax;
            g.ReportSelection = "MinMax Purchase News ";
            g.ReportFilter = "MRP_s1p";
            F3_Sheets t = new F3_Sheets();
            t.ShowDialog();

            g.SQLselection = g.gMinMax;
            g.ReportSelection = "MinMax Reschedules ";
            g.ReportFilter = "MRP_s1o";
            F3_Sheets tt = new F3_Sheets();
            tt.ShowDialog();


            ///*  X    */

            g.SQLselection = g.gX;
            g.ReportSelection = "X Purchase News ";
            F3_Sheets u = new F3_Sheets();
            u.ShowDialog();

            g.SQLselection = g.gX;
            g.ReportSelection = "X Reschedules ";
            g.ReportFilter = "MRP_s1o";
            F3_Sheets uu = new F3_Sheets();
            uu.ShowDialog();


            ///*  Richmond    */

            g.SQLselection = g.gRichmond;
            g.ReportSelection = "Richmond Purchase News ";
            g.ReportFilter = "MRP_s1p";
            F3_Sheets v = new F3_Sheets();
            v.ShowDialog();

            g.SQLselection = g.gRichmond;
            g.ReportSelection = "Richmond Reschedules ";
            g.ReportFilter = "MRP_s1o";
            F3_Sheets vv = new F3_Sheets();
            vv.ShowDialog();

            g.SQLselection = g.gXRichmond;
            g.ReportSelection = "Richmond X Purchase News ";
            g.ReportFilter = "MRP_s1p";
            F3_Sheets vx = new F3_Sheets();
            vx.ShowDialog();

            g.SQLselection = g.gXRichmond;
            g.ReportSelection = "Richmond X Reschedules ";
            g.ReportFilter = "MRP_s1o";
            F3_Sheets vvx = new F3_Sheets();
            vvx.ShowDialog();


            ///*  LTA    */

            g.ReportSelection = "LTA ";
            g.SQLselection = g.LTA;
            g.ReportFilter = "MRP_s1p";
            LTA l = new LTA();
            l.ShowDialog();

            await Task.Delay(1000);
        }

    }


}
