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

namespace BlockedEmailAddresses
{
    public partial class BlockedAddresses : Form
    {
        public BlockedAddresses()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Blocked Email Addresses";

            SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL11; user = ReadWriteAttach; password = A!!ac8This; " +
                            "database = ZygoProductLicenses;");

            SqlCommand cmd = new SqlCommand(
                        "SELECT address FROM BlockedAddresses " +
                        "ORDER BY address", cnxn);

            cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dr);
            cnxn.Close();
            DGV.DataSource = dt;
         
            DGV.Columns[0].Width = 200;
            DGV.Show();
        }
    }
}
