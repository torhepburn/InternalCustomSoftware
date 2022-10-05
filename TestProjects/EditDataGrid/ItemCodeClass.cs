using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EditDataGrid
{
    public partial class ItemCodeClass : Form
    {
        public ItemCodeClass()
        {
            InitializeComponent();
        }

        private void itemCodeClassNotesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.itemCodeClassNotesBindingSource.EndEdit();
            this.itemCodeClassNotesTableAdapter.Update(this.priceListsDataSet1.ItemCodeClassNotes);

        }

        private void ItemCodeClass_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'priceListsDataSet1.ItemCodeClassNotes' table. You can move, or remove it, as needed.
            this.itemCodeClassNotesTableAdapter.Fill(this.priceListsDataSet1.ItemCodeClassNotes);

        }
    }
}