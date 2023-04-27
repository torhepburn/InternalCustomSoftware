using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace aLibComments
{
    public partial class dllForm : Form
    {
        public dllForm()
        {
            InitializeComponent();
        }

        private void dllForm_Load(object sender, EventArgs e)
        {
            tbComment.Text = g.ShortageLocator.ToString();
        }
    }
}
