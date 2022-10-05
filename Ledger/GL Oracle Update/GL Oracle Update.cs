using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GL_Oracle_Update
{
    public partial class Form1 : Form
    {
        private int a = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnxn = new SqlConnection("server = MIDSQL01; " +
                            "user id =  SpecialUser; password = 2Secure!; database = msdb;");
                SqlCommand cmd = new SqlCommand("exec dbo.sp_start_job N'mk40 projects'", cnxn);
                cnxn.Open();
                int rows = cmd.ExecuteNonQuery();
                cnxn.Close();
                cmd = new SqlCommand("exec dbo.sp_start_job N'mk32 prices pricelist item sls'", cnxn);
                cnxn.Open();
                rows = cmd.ExecuteNonQuery();
                cnxn.Close();
                cmd = new SqlCommand("exec dbo.sp_start_job N'mk89 posted ledger transactions for gl'", cnxn);
                cnxn.Open();
                rows = cmd.ExecuteNonQuery();
                cnxn.Close();

                bool go = true;

                while (go == true)
                {
                    SqlConnection cnxn2 = new SqlConnection("server = MIDSQL01; " +
                            "user id =  SpecialUser; password = 2Secure!; database = msdb;");
                    SqlCommand cmd2 = new SqlCommand(
                        "select 1 from sysjobs j " +
                        "left join sysjobactivity a on a.job_id = j.job_id " +
                        "where j.name = N'Mk89 Posted Ledger Transactions for GL' " +
                        "and a.run_requested_date is not null " +
                        "and a.stop_execution_date is null ", cnxn2);
                    cnxn2.Open();
                    object o = cmd2.ExecuteScalar();
                    cnxn2.Close();
                    if (o != null)
                    {
                        label1.Visible = true;
                        label2.Visible = true;
                        label3.Visible = true;
                        label2.Text = "Time Running " + a.ToString() + " seconds";
                        label1.Invalidate();
                        label2.Invalidate();
                        Application.DoEvents();
                    }
                    else
                    {
                        go = false;
                    }
                    //check every ten seconds
                    System.Threading.Thread.Sleep(10000);
                    a = a + 10;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                a = 0;
                SqlConnection cnxn = new SqlConnection("server = MIDSQL01; " +
                            "user id =  views; password = views; database = GeneralLedger;");

                SqlCommand cmd = new SqlCommand("Drop table AnnualAccountActivity", cnxn);
                cnxn.Open();
                int rows = cmd.ExecuteNonQuery();
                cnxn.Close();
                rows = 0;

                label2.Text = "Now wait four minutes from :" + DateTime.Now.ToShortTimeString();
                label2.Invalidate();
                label3.Visible = false;
                Application.DoEvents();

                cmd = new SqlCommand("exec dbo.sp_AnnualAccountActivity", cnxn);
                cmd.CommandTimeout = 200;
                cnxn.Open();
                rows = cmd.ExecuteNonQuery();
                cnxn.Close();

                System.Threading.Thread.Sleep(15000);

                cmd = new SqlCommand("drop table tabProjectItemTransferSum2", cnxn);
                //cmd.CommandTimeout = 200;
                cnxn.Open();
                rows = cmd.ExecuteNonQuery();
                cnxn.Close();

                cmd = new SqlCommand("exec dbo.sp_PITS2", cnxn);
                cmd.CommandTimeout = 200;
                cnxn.Open();
                rows = cmd.ExecuteNonQuery();
                cnxn.Close();


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}
