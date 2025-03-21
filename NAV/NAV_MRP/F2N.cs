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
    public partial class F2N: Form
    {
        public F2N()
        {
            InitializeComponent();
        }

        private async void F2N_Load(object sender, EventArgs e)
        {
            await Task.Run(() => { _ = MainRescheduledSheets(); });
            await Task.Run(() => { _ = KBP(); });
            await Task.Run(() => { _ = reports(); });

            this.Close();
        }

        private async Task MainRescheduledSheets()
        {
            g.SQLselection = g.gMain;
            g.ReportSelection = " Reschedules ";
            g.ReportFilter = "MRP_s1o";
            F3_Sheets rr = new F3_Sheets();
            rr.ShowDialog();
        }

        private async Task KBP()
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
