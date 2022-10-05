using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JobInfo
{
    public partial class Task : Form
    {
        public Task()
        {
            InitializeComponent();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            g.task = "ADD";
            AddJob a = new AddJob();
            a.Show();
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            g.task = "EDIT";
            FindJob j = new FindJob();
            j.Show();
            
        }

        private void bCloseJobs_Click(object sender, EventArgs e)
        {
            CloseJobs c = new CloseJobs();
            c.ShowDialog();
            
        }

        //private void FindJob_FormClosed(object sender, FormClosedEventArgs e)
        //{

        //    string x = "new";

        //}
    }

    public static class g
    {
        public static string JobID;
        public static string task;
        //public static string ShortageGroup;
        //public static string ProductLine;
        //public static string task;
        //public static string origDelDate;
        //public static string PO;
        //public static string Supplier;
        //public static string PoQuantity;
        //public static string db = "server = CT-MID-SQL01; password = Read+Write!; " +
        public static string db = "server = midsql01; password = Read+Write!; " +
                    "user = readwrite; database = OptiTRAK;";
    }
}
