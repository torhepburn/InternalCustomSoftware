using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormApps
{
    public partial class FileList : Form
    {
        public FileList()
        {
            InitializeComponent();
        }

        private void FileList_Load(object sender, EventArgs e)
        {


        }

        private void bInstrument_Click(object sender, EventArgs e)
        {
            g.ProductGroup = "INSTRUMENT";
            EditData ed = new EditData();
            //DataSelection d = new DataSelection();
            ed.ShowDialog();
        }
    }

    public static class g
    {
        public static string user;
        public static string NDA_ID;
        public static string task;
        public static string ProductGroup;
        public static string dbNAV = "server = PA-HOR-AS408; Database = ZYGO-NAV-PROD; " +
                            "user = navdb_read; password = 2018#ameteK;";
        public static string dbDash = "server = MIDDB01.zygo.com; Database = Dashboard; " +
                    "user = views; password = views;";
        
    }
}
