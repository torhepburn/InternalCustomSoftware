using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tools
{
    public partial class F0_Choose_Type : Form
    {
        public F0_Choose_Type()
        {
            InitializeComponent();
        }

        private void bCNC_Click(object sender, EventArgs e)
        {
            g.program = "CNC";
            this.BackColor = Color.FromArgb(205, 205, 100);
            F1_Start f1 = new F1_Start();
            f1.Show();
        }

        private void bLFO_Click(object sender, EventArgs e)
        {
            g.program = "LFO";
            this.BackColor = Color.FromArgb(240, 100, 100);
            F1_Start f1 = new F1_Start();
            f1.Show();
        }

        private void Bfixtures_Click(object sender, EventArgs e)
        {
            g.program = "FX";
            this.BackColor = Color.Green;
            F1_Start f1 = new F1_Start();
            f1.Show();
        }

        private void Bvacuumchucks_Click(object sender, EventArgs e)
        {
            g.program = "VC";
            this.BackColor = Color.Blue;
            F1_Start f1 = new F1_Start();
            f1.Show();
        }

        private void F0_Choose_Type_Load(object sender, EventArgs e)
        {
            this.Text = "Tooling Program version " + Application.ProductVersion;
        }
    }
}
