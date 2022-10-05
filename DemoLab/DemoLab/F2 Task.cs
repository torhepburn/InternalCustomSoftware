using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoLab
{
    public partial class F2_Task : Form
    {
        public F2_Task()
        {
            InitializeComponent();
        }

        private void F2_Task_Load(object sender, EventArgs e)
        {

        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            F4_Edit f4 = new F4_Edit();
            f4.Show();
        }
    }
}
