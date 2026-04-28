using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroproXLicenseDLL;

namespace LicenseGenerator
{
    public partial class f1_TAssembly : Form
    {
        private string ZygoLicense;
        //private string owner;
        //private string SalesOrder;
        private string appSort1;
        private string appSort2;
        private DateTime endDate;
        private bool MtpLimit = false;
        SqlConnection cnxn;
        SqlCommand cmd;
        SqlDataReader dr;
        MetroproXLicense MX = new MetroproXLicense();

        public f1_TAssembly()
        {
            InitializeComponent();
        }

        private void f1_TAssembly_Load(object sender, EventArgs e)
        {
            this.Location = new Point(300, 200);

            appSort1 = "and application like 'Metro%' ";
            appSort2 = "and application not like 'Metro%' ";

            cnxn = new SqlConnection(g.db);

            SqlCommand cmd = new SqlCommand(
                "select application, application flist from applications where productline = '" + g.productLine + "' " +
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
                 "select LTRIM(assemblylist), application flist from applications where assemblylist is not null " +
                 "order by assemblylist", cnxn);

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
            cbApplication.ValueMember = "flist";

        }

        private void bLicense_Click(object sender, EventArgs e)
        {
            g.productLine = "MX";
            endDate = dtpStart.Value.Date.AddMonths(4);

            if (tbSerialNumber.Text.Length > 0)
            {
                ZygoLicense = MX.GenerateMetroproLicenseKey(
                tbDongle.Text.Trim(),
                cbApplication.SelectedValue.ToString().Trim(),
                dtpStart.Value.ToString(),
                endDate.ToString());


                
                cmd = new SqlCommand(
                    "Insert into licensedata (" +
                    "productline, " +
                    "licensenumber, " +
                    "dongleid, " +
                    "application, " +
                    "startdate, " +
                    "expirationdate, " +
                    "SerialNo, " +
                    "activedemo) " +
                    "values ('" +
                    g.productLine + "','" +
                    ZygoLicense + "','" +
                    tbDongle.Text.Trim() + "','" +
                    cbApplication.SelectedValue.ToString().Trim() + "','" +
                    dtpStart.Value + "','" +
                    endDate + "','" +
                    tbSerialNumber.Text.Trim() + "','" +
                    g.activeDemo + "')", cnxn);

                cnxn.Open();

                try
                {
                    int returnd = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }
            }
            else
            {
                MessageBox.Show("Duration and Serial Number boxes require entries.");
                cbDuration.Focus();
            }
            label6.Text = ZygoLicense;
            g.license = ZygoLicense;


        }

        private void bChangeSN_Click(object sender, EventArgs e)
        {

        }

        private void bAnother_Click(object sender, EventArgs e)
        {

        }

        private void bPrint_Click(object sender, EventArgs e)
        {

        }

        private void bRePrint_Click(object sender, EventArgs e)
        {

        }

        
    }
}
