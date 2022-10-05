using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WriteFile2C
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                File.AppendAllText(@"C:\Calibration\writetest.txt", "Does this work ?");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
