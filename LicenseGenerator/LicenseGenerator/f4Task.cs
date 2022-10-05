using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LicenseGenerator
{
    public partial class f4Task : Form
    {
        private string appSort1;
        private string appSort2;
        SqlDataReader dr;

        public f4Task()
        {
            InitializeComponent();
        }

        private void f4Task_Load(object sender, EventArgs e)
        {
          if (g.productLine == "MTP" || g.productLine == "MX")
          {
              appSort1 = "and application like 'Metro%' ";
              appSort2 = "and application not like 'Metro%' ";
          }
          if (g.productLine == "ZMP")
          {
              appSort1 = "and application like 'ZeMaps%' ";
              appSort2 = "and application not like 'ZeMaps%' ";
          }

          SqlConnection cnxn = new SqlConnection(g.db);
          
          SqlCommand cmd = new SqlCommand(
              "select application from applications where productline = '" + g.productLine + "' " +
              "and activedemo = '" + g.activeDemo + "' " + appSort1 +
              "order by dbo.sc_sortableversionstring(application) desc ", cnxn);

          DataTable dt = new DataTable();
            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            cmd = new SqlCommand(
               "select application from applications where productline = '" + g.productLine + "' " +
              "and activedemo = '" + g.activeDemo + "' " + appSort2 +
              "order by application ", cnxn);

            DataTable dt2 = new DataTable();
            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();
                dt2.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

          foreach (DataRow row in dt2.Rows)
          {
              dt.Rows.Add(row.ItemArray);
          }
          cbApplication.DataSource = dt;
          cbApplication.DisplayMember = "Application";
        }
        private void bLicense_Click(object sender, EventArgs e)
        {
            f5GenerateLicense generateLicense = new f5GenerateLicense();
            generateLicense.Show();
        }

        private void bDetails_Click(object sender, EventArgs e)
        {
            g.task = "Dongle Details";
            f7ViewDetails f7 = new f7ViewDetails();
            f7.Show();
        }

        private void bCustomer_Click(object sender, EventArgs e)
        {
            g.task = "Customer Details";
            f71DetailReport f71 = new f71DetailReport();
            f71.Show();
        }

        private void bSalesOrder_Click(object sender, EventArgs e)
        {
            g.task = "Sales Order Details";
            f7ViewDetails f7 = new f7ViewDetails();
            f7.Show();
        }

        private void bChange_Click(object sender, EventArgs e)
        {
            g.task = "Change SO";
            f7ViewDetails f7 = new f7ViewDetails();
            f7.Show();
        }

        private void bExpirationAll_Click(object sender, EventArgs e)
        {
            g.task = "Show All";
            f7ViewDetails f7 = new f7ViewDetails();
            f7.Show();
        }

        private void bExpirationLT5Y_Click(object sender, EventArgs e)
        {
            g.task = "Less Than Five";
            f7ViewDetails f7 = new f7ViewDetails();
            f7.Show();
        }

        private void bDongleByApp_Click(object sender, EventArgs e)
        {
            g.task = "Dongle by App";
            g.application = cbApplication.Text.Trim();
            f71DetailReport f71 = new f71DetailReport();
            f71.Show();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            g.task = "Delete";
            f7ViewDetails f7 = new f7ViewDetails();
            f7.Show();
        }

        
    }
}
