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
using System.IO;
using MetroproXLicenseDLL;

namespace Test_LicenseIssue
{
    public partial class TEST2 : Form
    {
        private string dongleID;
        private string application;
        private string customer;
        private string email;
        private string ZygoLicense;
        private string firstName;

        SqlConnection cnxn;
        MetroproXLicense MX = new MetroproXLicense();

        public TEST2()
        {
            InitializeComponent();
        }

        private void TEST2_Load(object sender, EventArgs e)
        {
            //SqlConnection cnxn;

            //    DataTable table = new DataTable();

            //    cnxn = new SqlConnection("server = CT-MID-SQL11.ametek.com; user = ReadWriteAttach; password = A!!ac8This; " +
            //                    "database = ZygoProductLicenses;");

            //    SqlCommand cmd = new SqlCommand("Select Top (1) owner from DongleFullDetails WHERE [Dongle ID] = '1212121215' " +
            //        "ORDER BY [Start Date] desc", cnxn);

            //    cnxn.Open();
            //    try
            //    {
            //        SqlDataReader dr = cmd.ExecuteReader();

            //        table.Load(dr);
            //    }
            //    catch (SqlException ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //    finally
            //    {
            //        cnxn.Close();
            //    }

            //    DGV.DataSource = table;
            //    DGV.Show();

            string timestamp = string.Empty;

            try
            {
                StreamReader st = new StreamReader("\\\\CT-MID-SQL11\\a\\data1.txt");

                while (st.Peek() >= 0)
                {
                    string x = st.ReadLine();

                    string[] insert = x.Split('|');

                    timestamp = insert[0].ToString().Trim();
                    timestamp = timestamp.Replace("T", " ");
                    timestamp = timestamp.Replace("Z", ".000");

                    dongleID = insert[1].ToString().Trim();
                    application = insert[2].ToString().Trim();
                    customer = insert[3].ToString().Trim();

                    try
                    {
                        ZygoLicense = MX.GenerateMetroproLicenseKey(
                        dongleID,
                        application,
                        DateTime.Now.ToShortDateString(),
                        DateTime.Now.AddYears(1).ToShortDateString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("DLL error  " + ex.ToString());
                    }



                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            try
            {
                File.AppendAllText(@"\\CT-MID-SQL11.ametek.com\a\test.txt", "This is a test today " + timestamp +
                    "  " + dongleID + "  " +
                    application +  "." + Environment.NewLine);

                //@"\\CT-MID-SQL01.zygo.com\A\license.pdf";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
    }
}
