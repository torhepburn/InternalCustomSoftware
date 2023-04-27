using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NAVRefresh_MRP
{
    public partial class RefMRP0 : Form
    {
        private bool run = false;

        public RefMRP0()
        {
            InitializeComponent();
        }

        private void RefMRP0_Load(object sender, EventArgs e)
        {
            if (run is false)
            {
                /* Main report     */

                g.SQLselection = g.Main;
                g.ReportSelection = "";

                REFMRP1 r = new REFMRP1();
                r.ShowDialog();


                /*  MinMAx    */

                g.SQLselection = g.MinMax;
                g.ReportSelection = "minmax ";
                REFMRP1 t = new REFMRP1();
                t.ShowDialog();


                ///*  X    */

                g.SQLselection = g.X;
                g.ReportSelection = "X Report ";
                REFMRP1 u = new REFMRP1();
                u.ShowDialog();

                /*  Irvine    */

                g.SQLselection = g.Irvine;
                g.ReportSelection = "Irvine ";
                REFMRP1 s = new REFMRP1();
                s.ShowDialog();
                //run = true;

                /*  Richmond    */

                g.SQLselection = g.Richmond;
                g.ReportSelection = "Richmond ";
                REFMRP1 v = new REFMRP1();
                v.ShowDialog();
                //run = true;

                ///*  MRP KBP    */
                RefKBP k = new RefKBP();
                k.ShowDialog();
                //run = true;

                this.Close();
            }
        }
    }
}
