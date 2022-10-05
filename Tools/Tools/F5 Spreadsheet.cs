using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Tools
{
    public partial class Atest : Form
    {
        public Atest()
        {
            InitializeComponent();

        }

        private void Atest_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'opticsDataSet.Tools' table. You can move, or remove it, as needed.
            this.toolsTableAdapter.Fill(this.opticsDataSet.Tools);

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            toolsTableAdapter.Update(opticsDataSet.Tools);
        }
    

       
    }
}
