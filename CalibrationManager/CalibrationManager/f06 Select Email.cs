using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CalibrationManager
{
    public partial class f06_Select_Email : Form
    {
        public f06_Select_Email()
        {
            InitializeComponent();
        }

        private void bOverdue_Click(object sender, EventArgs e)
        {
            g.task = "overdue";
            email();
        }

        private void bThisMonth_Click(object sender, EventArgs e)
        {
            g.task = "thismonth";
            email();
        }

        private void bNextMonth_Click(object sender, EventArgs e)
        {
            g.task = "nextmonth";
            email();
        }

        private void email()
        {
            f06_Email fm = new f06_Email();
            fm.Show();
            Close();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}