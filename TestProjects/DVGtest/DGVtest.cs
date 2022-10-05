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

namespace DVGtest
{
    public partial class DGVtest : Form
    {
        DataTable dt;

        public DGVtest()
        {
            InitializeComponent();
        }

        private void DGVtest_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(
                "Server = CT-MID-SQL01; password = $ecur1Ty; user = NdaAdmin; database = ZygoNonDisclosureAgreements;");

            SqlDataAdapter da = new SqlDataAdapter("select Company, CompanyContact, SubjectProtected, PeriodEnds, ProdLine " +
                "from NDA where status = 'Filed' and prodline = 'procurement' ", cnxn);

            try
            {
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DGV.DataSource = dt;

            DGV.Columns[0].Width = 200;
            DGV.Columns[2].Width = 300;
            DGV.Columns[3].Width = 80;
            DGV.Show();

        }
    }
}
