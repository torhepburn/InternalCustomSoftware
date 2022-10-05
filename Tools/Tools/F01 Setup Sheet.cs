using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tools
{
    public partial class F01_Setup_Sheet : Form
    {
        public F01_Setup_Sheet()
        {
            InitializeComponent();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            F42_Edit_Setup_Sheet_Tools f42 = new F42_Edit_Setup_Sheet_Tools();
            f42.Show();
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            F44_Copy_Setup_Machine2Machine f44 = new F44_Copy_Setup_Machine2Machine();
            f44.Show();
        }

        private void bView_Click(object sender, EventArgs e)
        {
            g.task = "view";
            F45_Select_Sheet f45 = new F45_Select_Sheet();
            f45.Show();
        }
    }
}
