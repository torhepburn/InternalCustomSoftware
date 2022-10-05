using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LLNL_Amp_Write2File
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
