using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NAV_MRP_ProposedChanges
{
    public partial class AutoRunProposed : Form
    {
        private bool run = false;

        public AutoRunProposed()
        {
            InitializeComponent();
        }

        private void AutoRunProposed_Load(object sender, EventArgs e)
        {
            this.Text = "MRP Data Sheets Running";
            
        }

        private void AutoRunProposed_Activated(object sender, EventArgs e)
        {
            if (run is false)
            {
                /* Main report     */

                g.SQLselection = g.Main;
                g.ReportSelection = "";

                ProposedChanges r = new ProposedChanges();
                r.ShowDialog();


                /*  MinMAx    */

                g.SQLselection = g.MinMax;
                g.ReportSelection = "minmax ";
                ProposedChanges t = new ProposedChanges();
                t.ShowDialog();


                ///*  X    */

                g.SQLselection = g.X;
                g.ReportSelection = "X Report ";
                ProposedChanges u = new ProposedChanges();
                u.ShowDialog();

                /*  Irvine    */

                g.SQLselection = g.Irvine;
                g.ReportSelection = "Irvine ";
                ProposedChanges s = new ProposedChanges();
                s.ShowDialog();
                //run = true;

                /*  Richmond    */

                g.SQLselection = g.Richmond;
                g.ReportSelection = "Richmond ";
                ProposedChanges v = new ProposedChanges();
                v.ShowDialog();
                //run = true;

                ///*  MRP KBP    */
                KBP_Proposed k = new KBP_Proposed();
                k.ShowDialog();
                ////run = true;

                this.Close();
            }
        }
    }
}
