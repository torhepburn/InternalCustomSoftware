using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MRP2026
{
    public partial class F1_MessageType : Form
    {
        public F1_MessageType()
        {
            InitializeComponent();
        }

        private void BNotCancel_Click(object sender, EventArgs e)
        {
            g.messageCancel = false;
            g.messageChoice = " not ";
            Nexxt();
        }

        private void Nexxt()
        {
            F2_ReportSelection a = new F2_ReportSelection();
            //F2N a = new F2N();
            a.ShowDialog();

            this.Close();
        }
    }

    
    

}
