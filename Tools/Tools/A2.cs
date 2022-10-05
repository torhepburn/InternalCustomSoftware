using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tools
{
    public partial class A2 : Form
    {
        public A2()
        {
            InitializeComponent();
        }

        private void A2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'opticsDataSet1.PartSetUp' table. You can move, or remove it, as needed.
            this.partSetUpTableAdapter.Fill(this.opticsDataSet1.PartSetUp);

        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.partSetUpTableAdapter.Update(this.opticsDataSet1.PartSetUp);
        }

       
    }
}
