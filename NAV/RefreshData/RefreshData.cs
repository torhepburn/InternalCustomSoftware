using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace RefreshData
{
    public partial class RefreshData : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;

        public RefreshData()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SqlConnection cnxn = new SqlConnection(
            //    "server=CT-MID-SQL01; user=ExecuteJob; password=$t@rtTh1s; " +
            //    "database = msdb;");
            //SqlCommand cmd = new SqlCommand();
            ////cmd.CommandType = CommandType.Text;
            //cmd.CommandType = CommandType.StoredProcedure;
            ////cmd.CommandText = "exec dbo.sp_start_job";
            //cmd.CommandText = "msdb.dbo.sp_start_job";//exec dbo.sp_start_job N'ShortageDataUpdate'
            ////'C5E27166 - D1C8 - 43F4 - A567 - 9D90E00BDB73'
            ////cmd.Parameters.AddWithValue("@job_name", "ShortageDataUpdate");

            //Guid jobID = new Guid("C5E27166 - D1C8 - 43F4 - A567 - 9D90E00BDB73");
            //cmd.Parameters.AddWithValue("@job_id", jobID);
            //cmd.Connection = cnxn;



            //try
            //{
            //    cnxn.Open();
            //    cmd.ExecuteNonQuery();
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    cnxn.Close();
            //}
            //string item = "1046-650-154";
            string item = "1046-650-154";
            //string item = "1012-900-029";
            string KB1contract = string.Empty;
            string KB1contractNote = string.Empty;
            int KB1quantity = 0;
            string KB1start = string.Empty;
            string KB1end = string.Empty;
            string KB2contract = string.Empty;
            string KB2contractNote = string.Empty;
            int KB2quantity = 0;
            string KB2start = string.Empty;
            string KB2end = string.Empty;
            string KB2processing = "NO";

            int KB1calculated = 0;
            int KB2calculated = 0;

            int MRProws = 0;
            string order = string.Empty;
            int rowNumber = 0;

            int MRPpoQuantity = 0;
            string MRPorderDate = string.Empty;
            string MRPdueDate = string.Empty;
            //int MRProwCount = 0;

            DateTime reorderdate;

            cnxn = new SqlConnection(
                "server=CT-MID-SQL11; user=readWrite; password=Read+Write!; " +
                "database = AccessFrontends;"
                );

            cmd = new SqlCommand("SELECT [KB1_Contract] " +
                ",KB1_Quantity " +
                ",KB1_Contract_Start_Date " +
                ",KB1_Contract_End_Date " +
                ",KB2_Contract " +
                ",KB2_Quantity " +
                ",KB2_Contract_Start_Date " +
                ",KB2_Contract_End_Date " +
                "FROM KBs1 WHERE ItemNo = '" + item + "'", cnxn);

            cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            cnxn.Close();

            KB1contract = table.Rows[0][0].ToString();
            string KB1quantityS1 = table.Rows[0][1].ToString();
            KB1start = table.Rows[0][2].ToString();
            KB1end = table.Rows[0][3].ToString();

            KB2contract = table.Rows[0][4].ToString();
            string KB2quantityS1 = table.Rows[0][5].ToString();
            KB2start = table.Rows[0][6].ToString();
            KB2end = table.Rows[0][7].ToString();

            KB1quantityS1 = KB1quantityS1.Replace(".", "");
            KB1quantityS1 = KB1quantityS1.Replace("0", "");

            KB2quantityS1 = KB2quantityS1.Replace(".", "");
            KB2quantityS1 = KB2quantityS1.Replace("0", "");


            if (KB1contract.Length == 0)
            {
                KB1contractNote = "No Contracts";
            }
            else
            {
                KB1calculated = Convert.ToInt32(KB1quantityS1);
                if (KB2quantityS1.Length > 0)
                {
                    KB2calculated = Convert.ToInt32(KB2quantityS1);
                }

                rowNumber = 1;
                order = "0";

                cmd = new SqlCommand("SELECT COUNT(No_) FROM KBs2 WHERE No_ = '" + item + "'", cnxn);

                cnxn.Open();
                dr = cmd.ExecuteReader();
                DataTable t1 = new DataTable();
                t1.Load(dr);
                cnxn.Close();

                string s1 = t1.Rows[0][0].ToString();
                MRProws = Convert.ToInt32(s1);

                if (MRProws == 0)
                {
                    KB1contractNote = "No MRP Activity";
                }
                else
                {

                    while (rowNumber < MRProws + 1)
                    {
                        cmd = new SqlCommand(
                               "SELECT " +
                               " Qty " +
                               ", DATEADD(dd, -42,[Due Date])[MRP Order Date] " +
                               ", [Due Date] " +
                               ", [Buyer Planner Code] " +
                               ", [Vendor No_] " +
                               " FROM KBs2 " +
                               " WHERE No_ = '" + item + "'" +
                               " AND RowNumber = " + rowNumber + "", cnxn);

                        cnxn.Open();
                        dr = cmd.ExecuteReader();
                        t1 = new DataTable();
                        t1.Load(dr);
                                                
                        dr = cmd.ExecuteReader();

                        while (dr.Read())   /* equivalent to the mrp cursor */
                        {
                            MRPpoQuantity = dr.GetInt32(0);

                            if (KB1calculated - MRPpoQuantity > 0)
                            {
                                KB1calculated = KB1calculated - MRPpoQuantity;

                                if (MRProws == rowNumber & KB1calculated > 0)
                                {
                                    KB1contractNote = "KB1 Contract will not run out";
                                }
                            }
                            else  /* if KB1calculated - MRPpoQuantity <= 0 */
                            {
                                if (KB1calculated - MRPpoQuantity <= 0 & order == "0")  /* stop processing once order put in  */
                                {
                                    if (KB1contractNote.Length == 0)
                                    {
                                        KB1contractNote = "SHOULD DEPLETE: " + dr.GetDateTime(2).ToShortDateString();
                                        KB1calculated = KB1calculated - MRPpoQuantity;
                                    }

                                    if (KB2contract.Length == 0)    /* no second contract process first contract  */
                                    {
                                        if (order == "0")
                                        {
                                            reorderdate = dr.GetDateTime(1);
                                            order = "1";

                                            //if (KB1end < reorderdate)
                                            //{
                                            //    KB2contractNote = "KB1 Needs End Date Reschedule Out";
                                            //}
                                        }
                                    }
                                    else //there is a second contract
                                    {
                                        if (KB2processing == "NO")
                                        {
                                            KB2calculated = KB2calculated + KB1calculated; //first time through only
                                            KB2processing = "YES";
                                        }
                                        else
                                        {
                                            if (KB2calculated - MRPpoQuantity <= 0)
                                            {
                                                KB2contractNote = "Should Deplete " + KB2contract;
                                            }
                                            else
                                            {
                                                KB2calculated = KB2calculated - MRPpoQuantity;

                                                if (MRProws == rowNumber & KB2calculated > 0)
                                                {
                                                    KB2contractNote = "KB2 Contract will not run out";
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                        cnxn.Close();
                        
                        rowNumber++;  /*  need to increment row number  after while loop   */

                        //MRPpoQuantity = Convert.ToInt32(t1.Rows[0][0].ToString());



                    }

                }



            }




        }
    }
}
