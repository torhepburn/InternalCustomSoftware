using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace LicenseServerTest
{
    public partial class GetData : Form
    {
        SqlConnection cnxn;
        public GetData()
        {
            InitializeComponent();
        }

        private void GetData_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();

            cnxn = new SqlConnection("server = CT-MID-SQL11.ametek.com; user = ReadWriteAttach; password = A!!ac8This; " +
                            "database = ZygoProductLicenses;");

            SqlCommand cmd = new SqlCommand("Select Top (1) owner from DongleFullDetails WHERE [Dongle ID] = '1212121215' " +
                "ORDER BY [Start Date] desc", cnxn);

            cnxn.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                table.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            DGV.DataSource = table;
            DGV.Show();

            File.AppendAllText(@"C:\a\test.txt", "This is a test." + Environment.NewLine);
        }


    }
}
