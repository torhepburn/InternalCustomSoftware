using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PCC_Failure_Log
{
    public partial class Select_Purpose : Form
    {
        public Select_Purpose()
        {
            InitializeComponent();
        }

        private void bMCertTest_Click(object sender, EventArgs e)
        {
            pV.purpose = "MCert";
            pV.task = pV.purpose;
            Select_Company co = new Select_Company();
            co.Show();
        }

        private void bProduction_Click(object sender, EventArgs e)
        {
            pV.purpose = "Production";
            pV.task = pV.purpose;
            Select_Company co = new Select_Company();
            co.Show();
        }

       
    }

    public static class pV
    {
        public static string task;
        public static string select;
        public static string purpose;
        public static string location;
    }
}