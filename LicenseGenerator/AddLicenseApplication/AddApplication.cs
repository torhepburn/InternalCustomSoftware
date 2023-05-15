using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AddLicenseApplication
{
    public partial class F1AddApplication : Form
    {
        private string productline;

        public F1AddApplication()
        {
            InitializeComponent();
        }

        private void F1AddApplication_Load(object sender, EventArgs e)
        {
            
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            
                productline = "MX";
            
            SqlConnection cnxn = new SqlConnection(
                "server=CT-MID-SQL11; password = Read+Write!;" +
                " user = readwrite; database = ZygoProductLicenses;");

            SqlCommand cmd = new SqlCommand("insert into applications " +
                "(ProductLine, Application, ActiveDemo,AssemblyList ) values " +
                "('MX','" + tbApplication.Text.Trim() + 
                "','A', '" + tbAssembly.Text.Trim() + "') " , cnxn);
            cnxn.Open();
            int success = cmd.ExecuteNonQuery();
            cnxn.Close();
            tbApplication.Text = "";
            tbAssembly.Text = "";
        }

    }
}
