using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RepairLabels
{
    public partial class F3_Non_Standard_Parts : Form
    {
        public F3_Non_Standard_Parts()
        {
            InitializeComponent();
        }

        private void F3_Non_Standard_Parts_Load(object sender, EventArgs e)
        {
            tbPartNumber.Text = g.item;
        }

        private void bEnter_Click(object sender, EventArgs e)
        {
            g.item = tbPartNumber.Text.Trim();
            g.iDescription = tbDescription.Text.Trim();
            F2_Label_Details f2 = new F2_Label_Details();
            f2.ShowDialog();
            this.Close();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbPartNumber_Leave(object sender, EventArgs e)
        {
            tbPartNumber.Text = tbPartNumber.Text.Trim().ToUpper();
        }

        private void tbDescription_Leave(object sender, EventArgs e)
        {
            tbDescription.Text = tbDescription.Text.Trim().ToUpper();
        }
    }
}
