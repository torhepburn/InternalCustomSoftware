using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PlannerCurrentStatus
{
    public partial class ExplanatoryText : Form
    {
        public ExplanatoryText()
        {
            InitializeComponent();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
