using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDA
{
    public partial class ProcurementChoices : Form
    {
        public ProcurementChoices()
        {
            InitializeComponent();
        }

        private void BAdd_Click(object sender, EventArgs e)
        {
            g.Task = "ADD";
            DataEntryForm d = new DataEntryForm();
            d.ShowDialog();
        }

        private void BEdit_Click(object sender, EventArgs e)
        {
            g.Task = "ProcurementEDIT";
            SelectNDA n = new SelectNDA();
            n.ShowDialog();
        }
    }
}
