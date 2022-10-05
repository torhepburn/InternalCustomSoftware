using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TrainingTool
{
    public partial class Training : Form
    {
        string SQL;

        public Training()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void bRemove_Click(object sender, EventArgs e)
        {
            SQL = "Delete ss from uschedulestatus ss " +
                "inner join tblPartSN p on ss.partID = p.partID " +
                "inner join tblJobInfo j on p.jobid = j.jobid " +
                "where j.JobID = 503;";

            SqlRun();

            Bschedule.BackColor = Color.Gray;
        }

        private void Brouting_Click(object sender, EventArgs e)
        {
            SQL = "Delete from tblWorkIns where JobID = 503; ";

            SqlRun();

            Brouting.BackColor = Color.Gray;
        }

        private void Bpart_Click(object sender, EventArgs e)
        {
            SQL = "Delete from tblPartSN where JobID = 503; ";

            SqlRun();

            Bpart.BackColor = Color.Gray;
        }

        private void SqlRun()
        {
            SqlConnection cnxn = new SqlConnection(
                "server = CT-MID-SQL01; password = Read+Write!; " +
                "user = readwrite; database = OptiTRAK;");

            try
            {
                cnxn.Open();

                SqlCommand cmd = new SqlCommand(SQL, cnxn);

                cmd.ExecuteNonQuery();
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
    }
}
