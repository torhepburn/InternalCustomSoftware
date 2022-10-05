using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DGVtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void zygoCannonMappingsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.zygoCannonMappingsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.accessFrontEndsDataSet);
            //this didn't work at first.  Need to have a primary key set in the table.
            //edit the table adapter in the data set designer by right clicking on it
            //then right click on the mappings table adapter and go to configure
            //go to advanced options and make sure that Refresh the Data Table is checked
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'accessFrontEndsDataSet.ZygoCannonMappings' table. You can move, or remove it, as needed.
            this.zygoCannonMappingsTableAdapter.Fill(this.accessFrontEndsDataSet.ZygoCannonMappings);

        }
    }
}
