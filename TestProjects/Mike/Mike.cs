using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Mike
{
    public partial class Mike : Form
    {
        private string midws0102 = @"\\midws0102\data";
        private string coating = @"\\zygocorp\departments\optics\opt_eng\optical coating dept\zygo coating";
        private string here = @"c:\a";
        private string there = @"\\zygocorp\departments\quality\calibration";
        private string fileName;

        public Mike()
        {
            InitializeComponent();
        }

        private void Mike_Load(object sender, EventArgs e)
        {
            string[] result = Directory.GetFiles(midws0102);
            int qtyFiles = result.Length;

            for (int i = 0; i < qtyFiles; i++)
            {
                LBx.Items.Add(result[i]);
            }

        }

        private void LBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            fileName = sender.ToString();
            string waaa = "this";
        }
    }
}
