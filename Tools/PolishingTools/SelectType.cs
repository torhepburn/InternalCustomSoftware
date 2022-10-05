using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PolishingTools
{
    public partial class SelectType : Form
    {
        public SelectType()
        {
            InitializeComponent();
        }

        private void bCarrier_Click(object sender, EventArgs e)
        {
            g.ToolType = "Carrier";
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void bFloaters_Click(object sender, EventArgs e)
        {
            g.ToolType = "Floater";
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void bTestPlates_Click(object sender, EventArgs e)
        {
            g.ToolType = "TestPlate";
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }
    }

    public static class g
    {
        public static string ToolType;
        
    }
}
