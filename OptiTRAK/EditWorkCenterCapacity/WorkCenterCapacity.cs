using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EditWorkCenterCapacity
{
    public partial class WorkCenterCapacity : Form
    {
        public WorkCenterCapacity()
        {
            InitializeComponent();
        }

        private void tblDeptBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tblDeptBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.optiTrakDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'optiTrakDataSet.tblDept' table. You can move, or remove it, as needed.
            this.tblDeptTableAdapter.Fill(this.optiTrakDataSet.tblDept);

            tblDeptDataGridView.Columns[0].Width = 60;
            tblDeptDataGridView.Columns[1].Width = 150;

        }
    }
}
