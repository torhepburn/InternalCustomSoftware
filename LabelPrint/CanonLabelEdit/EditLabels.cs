using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CanonLabelEdit
{
    public partial class EditLabels : Form
    {
        public EditLabels()
        {
            InitializeComponent();
        }

        private void zygoCanonMappingsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.zygoCanonMappingsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.accessFrontEndsDataSet);

        }

        private void EditLabels_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'accessFrontEndsDataSet.ZygoCanonMappings' table. You can move, or remove it, as needed.
            this.zygoCanonMappingsTableAdapter.Fill(this.accessFrontEndsDataSet.ZygoCanonMappings);

        }
    }
}
