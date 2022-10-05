using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PM_Test
{
    public partial class PM_TEST : Form
    {
        public PM_TEST()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://dashboard-ct.zygo.com/zto/app/maintenance/submitrequest.aspx");
        }
    }
}
