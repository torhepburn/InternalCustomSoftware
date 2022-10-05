using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UpdateAnnualActivity
{
    public partial class UpdateAnnualActivity : Form
    {
        public UpdateAnnualActivity()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection("server = MIDSQL01; " +
                            "user id =  views; password = views; database = GeneralLedger;");

            SqlCommand cmd = new SqlCommand("Drop table AnnualAccountActivity", cnxn);
            cnxn.Open();
            int rows = cmd.ExecuteNonQuery();
            cnxn.Close();

            cmd = new SqlCommand("exec dbo.sp_AnnualAccountActivity", cnxn);
            cmd.CommandTimeout = 200;
            cnxn.Open();
            rows = cmd.ExecuteNonQuery();
            cnxn.Close();
        }
    }
}
