using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CalibrationManager
{
    public partial class f06_Email_Type : Form
    {
        public f06_Email_Type()
        {
            InitializeComponent();
        }

        private void bAll_Click(object sender, EventArgs e)
        {
            g.item = "EmailAll";
            f06_Select_Email se = new f06_Select_Email();
            se.Show();
        }

        private void bSingle_Click(object sender, EventArgs e)
        {
            g.item = "EmailOne";
            f21_Select_Employees f21 = new f21_Select_Employees();
            f21.Show();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}