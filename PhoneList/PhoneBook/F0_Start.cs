using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class F0_Start : Form
    {
        public F0_Start()
        {
            InitializeComponent();
        }

        private void bFind_Click(object sender, EventArgs e)
        {
            g.task = "VIEW";
            F1_Find f = new F1_Find();
            f.ShowDialog();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            g.task = "ADD";
            F1_Find f = new F1_Find();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*bEdit  */
            g.task = "EDIT";
            F1_Find f = new F1_Find();
            f.ShowDialog();
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
        public static string ADname;
        public static string first;
        public static string extension;
        public static string location;
        public static string task;
        public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                                  "user = readwrite; database = accessfrontends;";
    }
}
