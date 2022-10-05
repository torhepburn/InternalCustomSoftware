using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UpdateTimeInQc
{
    public partial class UpdateTimeInQc : Form
    {
        public UpdateTimeInQc()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
               ("server = midsql01; user=readwrite; " +
                "password=Read+Write!; database = webtables;");
            
            cnxn.Open();
            SqlCommand cmd1 = new SqlCommand(
                   "rpt200", cnxn);
            cmd1.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd1.CommandTimeout = 300;
                cmd1.ExecuteNonQuery();
                cnxn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
