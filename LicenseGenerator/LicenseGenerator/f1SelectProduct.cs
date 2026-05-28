using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            System.Security.Principal.WindowsIdentity userBase;
            userBase = System.Security.Principal.WindowsIdentity.GetCurrent();

            string user = userBase.Name.ToUpper(); ;

            if (userBase.Name.IndexOf("Z") == 0)
            {
                user = userBase.Name.Replace("ZYGOMIS\\", "");
            }
            else
            {
                user = userBase.Name.Replace("AMETEK-AD\\", "");
            }



            SqlConnection cnxn = new SqlConnection(g.dbAFE);

            try
            {
                SqlCommand cmd = new SqlCommand(
                 " Select permission, permissionvalue from applicationsetup " +
                 " where application = 'LicenseManager.exe' and " +
                 " userName = '" + user + "' " +
                 " order by permission desc ", cnxn);
                DataTable table = new DataTable();

                cnxn.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();
                table.Load(dr);


                if (table.Rows.Count > 0)
                {
                    if (table.Rows[0][0].ToString().Trim().ToUpper() == "BLOCK" & table.Rows[0][1].ToString().Trim().ToUpper() == "TRUE")
                    { 
                        Bblock.Visible = true;
                        Bunblock.Visible= true;
                    }

                    
                }
                //else
                //{
                //    //MessageBox.Show("This user " + user + " does not have block permission to use this program: LicenseManager.exe.");
                //    //this.Close();
                //}
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }

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

        private void Bblock_Click(object sender, EventArgs e)
        {
            g.task = "Block";
            f9Customer c = new f9Customer();
            c.ShowDialog();
        }

        private void Bunblock_Click(object sender, EventArgs e)
        {
            g.task = "UnBlock";
            f9Customer c = new f9Customer();
            c.ShowDialog();
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
        public static string role;
        public static string user;
        public static string windowsUser;
        public static string db = "server=CT-MID-SQL11; password = Read+Write!;" +
                                  " user = readwrite; database = ZygoProductLicenses";
        public static string dbNAV = "server = pa-hor-as408; password = 2018#ameteK; " +
                                     "user = navdb_read; database = ZYGO-NAV-PROD;";
        public static string dbAFE = "server=CT-MID-SQL11; password = Read+Write!;" +
                                  " user = readwrite; database = AccessFrontEnds";


    }
}