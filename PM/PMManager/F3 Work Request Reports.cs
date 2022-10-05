using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PMManager
{
    public partial class F3_Work_Request_Reports : Form
    {
        public F3_Work_Request_Reports()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            g.PMcategory = "Continuous Improvement";
            F31_Reports f31 = new F31_Reports();
            f31.Show();
        }

        private void bMachineDown_Click(object sender, EventArgs e)
        {
            g.PMcategory = "Machine Down - Production Stopped";
            F31_Reports f31 = new F31_Reports();
            f31.Show();
        }

        private void bRepair_Click(object sender, EventArgs e)
        {
            g.PMcategory = "Repair";
            F31_Reports f31 = new F31_Reports();
            f31.Show();
        }

        private void bSafety_Click(object sender, EventArgs e)
        {
            g.PMcategory = "Safety";
            F31_Reports f31 = new F31_Reports();
            f31.Show();
        }
    }

    public static class g
    {
        public static string PMcategory;
    }
}
