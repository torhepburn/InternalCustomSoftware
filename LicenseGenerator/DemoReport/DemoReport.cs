using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DemoReport
{
    public partial class DemoReport : Form
    {
        SqlDataAdapter da;

        public DemoReport()
        {
            InitializeComponent();
        }

        private void DemoReport_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            this.Text = "Demo Licenses";

            SqlConnection cnxn = new SqlConnection("server=midsql01; password = Read+Write!;" +
                " user = readwrite; database = ZygoProductLicenses");
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                "select " +
                "DongleID, " +
                "SalesOrder, " +
                "IIF(c.name is null, l.owner, c.name) as owner, " + 
                
                    "customer_po, " +
                    "text, " +
                "StartDate, " +
                "ExpirationDate, " +
                "Application, " +
                "LicenseNumber " +
                "from licensedata l " +
                    //"from DongleFullDetails d " +
                    "left join accessfrontends.dbo.mmx_sales_orders s " +
                    "on l.salesorder = s.order_no " +
                    "left join accessfrontends.dbo.mmx_customers c " +
                    "on s.customer = c.customer " +
                    "where " +
                    "productline = 'MX' and " +
                    "activedemo = 'A' " +
                    "and substring(salesorder, 1,1) = '9' " +
                "order by dongleid,startdate desc", cnxn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                cnxn.Close();
                DGV.DataSource = dt;
                DGV.Columns[0].Width = 120;
                DGV.Columns[1].Width = 140;
                DGV.Columns[2].Width = 90;
                DGV.Columns[3].Width = 90;
                DGV.Columns[4].Width = 120;
                DGV.Columns[5].Width = 120;
                DGV.Columns[6].Width = 150;
                DGV.Columns[7].Width = 200;
                DGV.Show();
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.ToString());
            }

            DGV.Columns[0].Visible = true;
            
            
        }

        private void SetColumns()
        {
            
            //DGV.Columns[8].Width = 120;

        }
    }
}
