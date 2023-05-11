using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LicenseGenerator
{
    public partial class f1SelectProduct : Form
    {
        public f1SelectProduct()
        {
            InitializeComponent();
        }

        private void f1SelectProduct_Load(object sender, EventArgs e)
        {
            this.Text = "License Generator v" + Application.ProductVersion;
        }

        private void bMPX_Click(object sender, EventArgs e)
        {
            g.productLine = "MX";
            g.activeDemo = "A";
            g.user = "";
            f4Task f4 = new f4Task();
            f4.Show();
        }

        private void bZeMaps_Click(object sender, EventArgs e)
        {
            g.productLine = "ZMP";
            g.activeDemo = "A";
            g.user = "";
            f4Task f4 = new f4Task();
            f4.Show();
        }

        private void bMetroPro_Click(object sender, EventArgs e)
        {
            g.productLine = "MTP";
            g.activeDemo = "A";
            g.user = "";
            f4Task f4 = new f4Task();
            f4.Show();
        }

        private void bAssembly_Click(object sender, EventArgs e)
        {
            g.productLine = "MX";
            g.activeDemo = "A";
            g.user = "Assembly";
            f5Assembly f5 = new f5Assembly();
            f5.Show();
        }
    }

    public static class g
    {
        public static string application;
        public static string activeDemo;
        public static string DongleID;
        public static string license;
        public static string productLine;
        public static string salesorder;
        public static string task;
        public static string uid;
        public static string MkNAV;
        public static string customerName;
        public static string owner;
        public static string user;
        public static string db = "server=CT-MID-SQL11; password = Read+Write!;" +
                                  " user = readwrite; database = ZygoProductLicenses";
        public static string dbNAV = "server = pa-hor-as408; password = 2018#ameteK; " +
                                     "user = navdb_read; database = ZYGO-NAV-PROD;";

        
       
    }
}