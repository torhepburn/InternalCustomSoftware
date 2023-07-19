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
                ///* Main report     */

                g.SQLselection = g.Main;
                g.ReportSelection = "";

                MRP_PrintedReport r = new MRP_PrintedReport();
                r.ShowDialog();


                /*  MinMAx    */

                //g.SQLselection = g.MinMax;
                //g.ReportSelection = "minmax ";
                //MRP_PrintedReport t = new MRP_PrintedReport();
                //t.ShowDialog();

                /////*  X    */

                //g.SQLselection = g.X;
                //g.ReportSelection = "X Report ";
                //MRP_PrintedReport u = new MRP_PrintedReport();
                //u.ShowDialog();

                ///*  Irvine    */

                //g.SQLselection = g.Irvine;
                //g.ReportSelection = "Irvine ";
                //MRP_PrintedReport s = new MRP_PrintedReport();
                //s.ShowDialog();
                ////run = true;

                ///*  Richmond    */

                //g.SQLselection = g.Richmond;
                //g.ReportSelection = "Richmond ";
                //MRP_PrintedReport v = new MRP_PrintedReport();
                //v.ShowDialog();
                ////run = true;

                ///*  MRP KBP    */
                //KBP k = new KBP();
                //k.ShowDialog();
                ////run = true;

                this.Close();
            }
        }
    }
}
