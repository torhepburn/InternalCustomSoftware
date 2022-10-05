using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MethodSheet1
{
    public partial class EditPartData : Form
    {
        public EditPartData()
        {
            InitializeComponent();
        }

        private void opticsMethodSheetDataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.opticsMethodSheetDataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.accessFrontEndsDataSet);
            //for this to work need to go edit dataset in designer
            //right click on the adapter section at the bottom
            //select configure, then advanced options
            //make sure 'refresh the data table' is selected
            //click on ok and finish.
            //table needs primary key too
        }

        private void EditPartData_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'accessFrontEndsDataSet.OpticsMethodSheetData' table. You can move, or remove it, as needed.
            this.opticsMethodSheetDataTableAdapter.Fill(this.accessFrontEndsDataSet.OpticsMethodSheetData);
            opticsMethodSheetDataDataGridView.Columns[0].Width = 75;
            opticsMethodSheetDataDataGridView.Columns[1].Width = 250;
            opticsMethodSheetDataDataGridView.Columns[2].Width = 120;
            opticsMethodSheetDataDataGridView.Columns[3].Width = 250;
            opticsMethodSheetDataDataGridView.Columns[4].Width = 50;
            opticsMethodSheetDataDataGridView.Columns[5].Width = 60;
            opticsMethodSheetDataDataGridView.Columns[6].Width = 50;
            opticsMethodSheetDataDataGridView.Columns[7].Width = 150;
            opticsMethodSheetDataDataGridView.Columns[10].Width = 600;
        }

        private void opticsMethodSheetDataBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.opticsMethodSheetDataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.accessFrontEndsDataSet);

        }
    }
}
