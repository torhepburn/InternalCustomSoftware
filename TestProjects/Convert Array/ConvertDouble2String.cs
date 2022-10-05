using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Convert_Array
{
    public partial class ConvertDouble2String : Form
    {
        public ConvertDouble2String()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double[] apf = {100.0,29.0,54.0};
            string[] bpf = Array.ConvertAll(apf, new Converter<double, string>(d2s));

        }

        private string d2s(double x)
        {
            return x.ToString();
        }
    }
}