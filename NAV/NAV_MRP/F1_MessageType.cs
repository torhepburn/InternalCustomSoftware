using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NAV_MRP
{
    public partial class F1_MessageType : Form
    {
        public F1_MessageType()
        {
            InitializeComponent();
        }

        private void F1_MessageType_Load(object sender, EventArgs e)
        {

        }

        private void BNotCancel_Click(object sender, EventArgs e)
        {
            g.messageCancel = false;
            g.messageChoice = " not ";
            Nexxt();
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            g.messageCancel = true;
            g.messageChoice = " ";
            Nexxt();
        }

        private void Nexxt()
        {
            AutoRun a = new AutoRun();
            a.ShowDialog();

            this.Close();
        }
    }
}
