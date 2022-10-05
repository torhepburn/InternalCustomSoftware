using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Certs
{
    public partial class AdminDropDowns : Form
    {
        public AdminDropDowns()
        {
            InitializeComponent();
        }

        private void bFound_Click(object sender, EventArgs e)
        {
            g.adminTask = "FoundCondition";
            EditDropDown d = new EditDropDown();
            d.ShowDialog();
        }

        private void bProcedure_Click(object sender, EventArgs e)
        {
            g.adminTask = "CalProcedure";
            EditDropDown d = new EditDropDown();
            d.ShowDialog();
        }

        private void bResults_Click(object sender, EventArgs e)
        {
            g.adminTask = "Result";
            EditDropDown d = new EditDropDown();
            d.ShowDialog();
        }

        private void bTestType_Click(object sender, EventArgs e)
        {
            g.adminTask = "TestType";
            EditDropDown d = new EditDropDown();
            d.ShowDialog();
        }

        private void bRefStandards_Click(object sender, EventArgs e)
        {
            g.adminTask = "RefStandard";
            EditDropDown d = new EditDropDown();
            d.ShowDialog();
        }

        private void bLeft_Click(object sender, EventArgs e)
        {
            g.adminTask = "LeftCondition";
            EditDropDown d = new EditDropDown();
            d.ShowDialog();
        }
    }
}
