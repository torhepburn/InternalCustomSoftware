using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelPrint
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
            g.iRevision = tbRevision.Text.Trim();
            F2_Label_Details f2 = new F2_Label_Details();
            f2.Show();
            //f2.ShowDialog();
            this.Close();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbDescription_Leave(object sender, EventArgs e)
        {
            tbDescription.Text = tbDescription.Text.Trim().ToUpper();
        }

        private void tbPartNumber_Leave(object sender, EventArgs e)
        {
            tbPartNumber.Text = tbPartNumber.Text.Trim().ToUpper();
        }
    }
}
