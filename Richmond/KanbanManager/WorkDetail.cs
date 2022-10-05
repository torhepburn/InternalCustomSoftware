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
    public partial class WorkDetail : Form
    {
        public WorkDetail()
        {
            InitializeComponent();
        }

        private void WorkDetail_Load(object sender, EventArgs e)
        {
            this.kbWorkDetailTableAdapter1.Fill(this.accessFrontEndsDataSet.KBWorkDetail);
        }
    }
}
