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
    public partial class f5Assembly : Form
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


        public f5Assembly()
        {
            InitializeComponent();
        }

        private void f5Assembly_Load(object sender, EventArgs e)
        {
            if (g.role == "TAIWAN")
            {
                this.Text = "License Generator v" + Application.ProductVersion;
            }

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

            if (g.role != "TAIWAN")
            {
                string[] duration =
                {
                "14 Days"
                ,"30 Days"
                ,"60 Days"
                ,"90 Days"
                ,"120 Days"
                ,"6 Months"
                ,"9 Months"
                ,"1 Year"
                ,"3 Years"
                ,"5 Years"
                ,"10 Years"
                ,"15 Years"
                ,"20 Years"
                ,"21 Years"
            };
                cbDuration.Items.AddRange(duration);
                LDuration.Visible = false;
            }
            else
            {
                cbDuration.Visible = false;
                LDuration.Visible = true;
            }
        }

        private void bLicense_Click(object sender, EventArgs e)
        {
            if (g.role != "TAIWAN")
            {
                if (cbDuration.Text == "14 Days")
                {
                    endDate = dtpStart.Value.Date.AddDays(14);
                }
                if (cbDuration.Text == "30 Days")
                {
                    endDate = dtpStart.Value.Date.AddMonths(1);
                }
                if (cbDuration.Text == "60 Days")
                {
                    endDate = dtpStart.Value.Date.AddMonths(2);
                }
                if (cbDuration.Text == "90 Days")
                {
                    endDate = dtpStart.Value.Date.AddMonths(3);
                }
                if (cbDuration.Text == "120 Days")
                {
                    endDate = dtpStart.Value.Date.AddMonths(4);
                }
                if (cbDuration.Text == "6 Months")
                {
                    endDate = dtpStart.Value.Date.AddMonths(6);
                }
                if (cbDuration.Text == "9 Months")
                {
                    endDate = dtpStart.Value.Date.AddMonths(9);
                }
                if (cbDuration.Text == "1 Year")
                {
                    endDate = dtpStart.Value.Date.AddYears(1);
                }
                if (cbDuration.Text == "3 Years")
                {
                    endDate = dtpStart.Value.Date.AddYears(3);
                }
                if (cbDuration.Text == "5 Years")
                {
                    endDate = dtpStart.Value.Date.AddYears(5);
                }
                if (cbDuration.Text == "10 Years")
                {
                    endDate = dtpStart.Value.Date.AddYears(10);
                }
                if (cbDuration.Text == "15 Years")
                {
                    endDate = dtpStart.Value.Date.AddYears(15);
                }
                if (cbDuration.Text == "20 Years")
                {
                    endDate = dtpStart.Value.Date.AddYears(20);
                }
                if (cbDuration.Text == "21 Years")
                {
                    endDate = dtpStart.Value.Date.AddYears(21);
                }
            }
            else
            {
                endDate = dtpStart.Value.Date.AddMonths(4);
                cbDuration.Text = "120 Days";
            }
            
            if (cbDuration.Text.Length > 0 && tbSerialNumber.Text.Length > 0)
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

        private void bAnother_Click(object sender, EventArgs e)
        {
            cbDuration.Text = "";
            endDate = DateTime.Today;
            label6.Text = "";
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            g.DongleID = tbDongle.Text.Trim();

            f63_PrintPDFsnOnly f63 = new f63_PrintPDFsnOnly();
            f63.Show();
        }

        private void bRePrint_Click(object sender, EventArgs e)
        {
            if (tbDongle.Text.Length < 1)
            {
                MessageBox.Show("DongleID entry needed.");
                tbDongle.Focus();
                return;
            }
            else
            {
                g.DongleID = tbDongle.Text.Trim();
            }

            f63_PrintPDFsnOnly f63 = new f63_PrintPDFsnOnly();
            f63.Show();
        }

        private void bChangeSN_Click(object sender, EventArgs e)
        {
            if (tbDongle.Text.Length < 1)
            {
                MessageBox.Show("DongleID entry needed.");
                tbDongle.Focus();
                return;
            }
            else
            {
                g.DongleID = tbDongle.Text.Trim();

                f88ChangeSN f88 = new f88ChangeSN();
                f88.Show();
            }
            this.Close();

        }
    }
}
