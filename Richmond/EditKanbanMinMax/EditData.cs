using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditKanbanMinMax
{
    public partial class EditData : Form
    {
        public EditData()
        {
            InitializeComponent();
        }

        private void EditData_Load(object sender, EventArgs e)
        {
            this.kanbanTableAdapter1.Fill(this.accessFrontEndsDataSet.kanban);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.kanbanBindingSource1.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.accessFrontEndsDataSet);
        }
    }
}
