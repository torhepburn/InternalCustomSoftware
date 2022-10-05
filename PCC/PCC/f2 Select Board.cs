using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PCC
{
    public partial class f2_Select_Board : Form
    {
        public f2_Select_Board()
        {
            InitializeComponent();
        }

        private void f2_Select_Board_Load(object sender, EventArgs e)
        {
            this.Text = "PCC Graphing Program v" + Application.ProductVersion.Trim();
            rbMCert.Checked = true;
        }

        private void b4004_Click(object sender, EventArgs e)
        {
            if (rbMCert.Checked)
            {
                Graphs_11_28_12 ng = new Graphs_11_28_12
                    ("4004", "ZMI-4K-ITS", "MCert");
                ng.Show();
            }
            else
            {
                Graphs_11_28_12 ng = new Graphs_11_28_12
                    ("4004", "ZMI-4K-ITS", "Production");
                ng.Show();
            }
            
            Close();
        }

        private void b4104_Click(object sender, EventArgs e)
        {
            if (rbMCert.Checked)
            {
                Graphs_11_28_12 ng = new Graphs_11_28_12
                    ("4104", "ZMI-4K-ITS", "MCert");
                ng.Show();
            }
            else
            {
                Graphs_11_28_12 ng = new Graphs_11_28_12
                    ("4104", "ZMI-4K-ITS", "Production");
                ng.Show();
            }

            Close();
        }
    }
}