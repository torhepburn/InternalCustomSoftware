using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NAV_MRP_Cancel
{
    public partial class AutoRunMRPCancel : Form
    {
        private bool run = false;

        public AutoRunMRPCancel()
        {
            InitializeComponent();
        }

        private void AutoRunMRPCancel_Load(object sender, EventArgs e)
        {
            this.Text = "MRP Data Sheets Running";
        }

        private void AutoRunMRPCancel_Activated(object sender, EventArgs e)
        {
            if (run is false)
            {
                ///* Main report     */

                g.SQLselection = g.Main;
                g.ReportSelection = "";

                Form1 r = new Form1();
                r.ShowDialog();


                /*  MinMAx    */

                g.SQLselection = g.MinMax;
                g.ReportSelection = "minmax ";
                Form1 m = new Form1();
                m.ShowDialog();

                /*  X    */

                g.SQLselection = g.X;
                g.ReportSelection = "X Report ";
                Form1 u = new Form1();
                u.ShowDialog();

                /*  Irvine    */

                g.SQLselection = g.Irvine;
                g.ReportSelection = "Irvine ";
                Form1 s = new Form1();
                s.ShowDialog();
                //run = true;

                /*  Richmond    */

                g.SQLselection = g.Richmond;
                g.ReportSelection = "Richmond ";
                Form1 v = new Form1();
                v.ShowDialog();
                //run = true;

                /*  MRP KBP    */
                KBP_Cancel k = new KBP_Cancel();
                k.ShowDialog();
                run = true;

                this.Close();
            }
        }
    }
}
