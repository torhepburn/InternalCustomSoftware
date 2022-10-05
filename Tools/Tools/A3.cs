using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tools
{
    public partial class A3 : Form
    {
        public A3()
        {
            InitializeComponent();
        }

        private void A3_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            // TODO: This line of code loads data into the 'opticsDataSet2.SetupSheet' table. You can move, or remove it, as needed.
            //this.setupSheetTableAdapter.Fill(this.opticsDataSet2.SetupSheet);

        }

        
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            setupSheetTableAdapter.Update(opticsDataSet2.SetupSheet);
        }
    
    }
}
