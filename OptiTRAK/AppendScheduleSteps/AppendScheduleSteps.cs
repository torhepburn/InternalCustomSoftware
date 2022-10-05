using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AppendScheduleSteps
{
    public partial class AppendScheduleSteps : Form
    {
        public AppendScheduleSteps()
        {
            InitializeComponent();
        }

        private void AppendScheduleSteps_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnxn = new SqlConnection("server = midsql01; password = Read+Write!; " +
                                      "user = readwrite; database = OptiTRAK;");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "spAppendStepsToScheduleStatus";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnxn;
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
