using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LLNL4XP
{
    public partial class F2_Errors : Form
    {
        public F2_Errors()
        {
            InitializeComponent();
        }

        private void F2_Errors_Load(object sender, EventArgs e)
        {
            tb1.Text = g.Errors.ToString();
        }
    }
}
