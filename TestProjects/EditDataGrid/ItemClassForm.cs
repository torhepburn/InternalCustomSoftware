using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EditDataGrid
{
    public partial class ItemClassForm : Form
    {
        public ItemClassForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'priceListsDataSet.ItemClasses' table. You can move, or remove it, as needed.
            this.itemClassesTableAdapter.Fill(this.priceListsDataSet.ItemClasses);
            // TODO: This line of code loads data into the 'priceListsDataSet.ItemClasses' table. You can move, or remove it, as needed.
            this.itemClassesTableAdapter.Fill(this.priceListsDataSet.ItemClasses);

        }

        private void itemClassesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.itemClassesBindingSource.EndEdit();
            this.itemClassesTableAdapter.Update(this.priceListsDataSet.ItemClasses);

        }
    }
}