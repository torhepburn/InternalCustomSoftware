using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PCC
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Graphs_11_28_12 ng = new Graphs_11_28_12
            //   ("4004", "ZMI-4K-ITS", "MCert");
            //ng.Show();
            //Graphs_11_28_12 ag = new Graphs_11_28_12
            //    ("4004", "ZMI-4K-ITS", "Production");
            //ag.Show();
            //ng.Close();
            Graphs_11_28_12 Bg = new Graphs_11_28_12
                ("4104", "ZMI-4K-ITS", "MCert");
            Bg.Show();
            //ag.Close();
            //Graphs_11_28_12 Cg = new Graphs_11_28_12
            //    ("4104", "ZMI-4K-ITS", "Production");
            //Cg.Show();
            //Bg.Close();
            //Graphs_11_28_12 Dg = new Graphs_11_28_12
            //    ("4104", "ZMI-TEST-1", "MCert");
            //Dg.Show();
            //Cg.Close();
            //Graphs_11_28_12 Eg = new Graphs_11_28_12
            //    ("4104", "ZMI-TEST-1", "Production");
            //Eg.Show();
            //Dg.Close();
            Close();
        }
    }
}