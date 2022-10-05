using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhoneList
{
    public partial class F0_Start : Form
    {
        public F0_Start()
        {
            InitializeComponent();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            g.task = "add";
            F1FindEmployee f1 = new F1FindEmployee();
            f1.ShowDialog();
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            g.task = "edit";
            F1FindEmployee f1 = new F1FindEmployee();
            f1.ShowDialog();
        }

        private void bFind_Click(object sender, EventArgs e)
        {
            g.task = "find";
            F1FindEmployee f1 = new F1FindEmployee();
            f1.ShowDialog();
        }

        private void F0_Start_Load(object sender, EventArgs e)
        {
            this.Text = "Edit Phone List " + Application.ProductVersion;
        }

        private void bReport_Click(object sender, EventArgs e)
        {

        }
    }

    public static class g
    {
        public static string UID;
        public static string Dept;
        public static string HireDate;
        public static string name;
        public static string last;
        public static string first;
        public static string extension;
        public static string loc;
        public static string task;
        public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                                  "user = readwrite; database = accessfrontends;";
    }

}
