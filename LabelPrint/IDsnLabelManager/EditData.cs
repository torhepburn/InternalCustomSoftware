using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IDsnLabelManager
{
    public partial class EditData : Form
    {
        public EditData()
        {
            InitializeComponent();
        }

        private void iDsnLabelsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.iDsnLabelsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.accessFrontEndsDataSet);

        }

        private void EditData_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'accessFrontEndsDataSet.IDsnLabels' table. You can move, or remove it, as needed.
            this.iDsnLabelsTableAdapter.Fill(this.accessFrontEndsDataSet.IDsnLabels);


        }
    }
}
