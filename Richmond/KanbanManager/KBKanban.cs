using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KanbanManager
{
    public partial class KBKanban : Form
    {
        public KBKanban()
        {
            InitializeComponent();
        }

        private void kanbanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.kanbanBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.accessFrontEndsDataSet1);

        }

        private void KBKanban_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'accessFrontEndsDataSet1.kanban' table. You can move, or remove it, as needed.
            this.kanbanTableAdapter.Fill(this.accessFrontEndsDataSet1.kanban);

        }
    }
}
