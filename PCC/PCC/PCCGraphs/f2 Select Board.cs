using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PCCGraphs
{
    public partial class f2_Select_Board : Form
    {
        public f2_Select_Board()
        {
            InitializeComponent();
        }

        private void f2_Select_Board_Load(object sender, EventArgs e)
        {
            //this.Text = "PCC Graphing Program v" + Application.ProductVersion.Trim();
            //rbMCert.Checked = true;
        }

        private void b4004_Click(object sender, EventArgs e)
        {
            if (rbMCert.Checked)
            {
                f1PCCGraphs ng = new f1PCCGraphs
                    ("4004","MCert");
                ng.Show();
            }
            else
            {
                f1PCCGraphs ng = new f1PCCGraphs
                    ("4004", "Production");
                ng.Show();
            }

            Close();
        }

        private void b4104_Click(object sender, EventArgs e)
        {
            if (rbMCert.Checked)
            {
                f1PCCGraphs ng = new f1PCCGraphs
                    ("4104", "MCert");
                ng.Show();
            }
            else
            {
                f1PCCGraphs ng = new f1PCCGraphs
                    ("4104", "Production");
                ng.Show();
            }

            Close();
        }
    }
}