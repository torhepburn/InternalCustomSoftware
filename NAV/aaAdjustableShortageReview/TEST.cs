using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace aaAdjustableShortageReview
{
    public partial class TEST : Form
    {
        SqlConnection cnxn;
        SqlDataReader dr;
        DataTable dt;
        SqlCommand cmd;
        public TEST()
        {
            InitializeComponent();
        }

        private void TEST_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection("server = CT-MID-SQL11; password = boardAdmin; " +
                            "user = ppsAdmin; database = ProductionControl;");

            cmd = new SqlCommand("select * from [apd_characterization]", cnxn);

            dt = new DataTable();

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            finally
            {
                cnxn.Close();

            }

            DGV.DataSource = dt;
            DGV.Show();

        }

    }
    
}
