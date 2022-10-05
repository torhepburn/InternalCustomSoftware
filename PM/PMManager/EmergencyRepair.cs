using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PMManager
{
    public partial class EmergencyRepair : Form
    {
        public EmergencyRepair()
        {
            InitializeComponent();
        }

        private void EmergencyRepair_Load(object sender, EventArgs e)
        {
            //SqlConnection cnxn = new SqlConnection
            //       ("server=midprj01; user=views; password=views;" +
            //        "database=logsheetsdb");

            //SqlParameter Trouble = new SqlParameter("@Trouble", SqlDbType.VarChar, 4000);
            ////Trouble.Value = tbTrouble.Text.Trim();
            //SqlParameter Phone = new SqlParameter("@Phone", SqlDbType.VarChar, 50);
            ////Phone.Value = tbPhone.Text.Trim();
            //SqlParameter CostCenter = new SqlParameter("@CostCenter", SqlDbType.VarChar, 4);
            ////CostCenter.Value = tbCostCenter.Text.Trim();
            //SqlParameter Project = new SqlParameter("@Project", SqlDbType.VarChar, 6);
            ////Project.Value = tbProject.Text.Trim();
            //SqlParameter ContactEmail = new SqlParameter("@ContactEmail", SqlDbType.VarChar, 50);
            ////ContactEmail.Value = tbContactEmail.Text.Trim();


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
                   ("server=MIDSQL01; user=readWrite; password=Read+Write!;" +
                    "database=PM_2015_A");

            //create unique identifier in format xxxxxxxx-xxxx-xxxx

            Random r = new Random();
            string r1 = r.Next(0, 10000).ToString();
            while (r1.Length < 4)
            { r1 = "0" + r1; }
            string r2 = r.Next(0, 10000).ToString();
            while (r2.Length < 4)
            { r2 = "0" + r2; }
            string y = DateTime.Now.Year.ToString();
            string m = DateTime.Now.Month.ToString();
            while (m.Length < 2)
            { m = "0" + m; }
            string d = DateTime.Now.Day.ToString();
            while (d.Length < 2)
            { d = "0" + d; }
            string uid = y + m + d + "-" + r1 + "-" + r2;

            SqlCommand cmd = new SqlCommand("Insert into [repair history from web] (" +
                    "[trouble serial]," +               //1
                    "Serial_Web_Entered," +
                    "[trouble repair category]," +
                    "[trouble cost center]," +
                    //"[trouble project]," +              //5
                    //"[trouble phone]," +
                    "[trouble rptd by]," +
                    "[trouble email]," +
                    "[trouble rptd date]," +
                    "trouble," +                        //10
                    "[trouble severity]," +
                    "[trouble unique_reference_number]," +
                    "trouble_email_owner" +
                    //"trouble_supervisor_submitter," +
                    //"trouble_supervisor_submitter_email" +     //15
                    ") values (" +
                    "'" + tbEquipID.Text.ToString().Trim() +        //1
                    "','" + tbEquipID.Text.ToString().Trim() +
                    "','" + tbCategory.Text.Trim() +
                    "'," + tbCostCenter.Text.Trim() +
                    //"," + Project +                        //5
                    //"," + Phone +
                    ",'" + tbName.Text.Trim() +
                    "'," + tbContactEmail.Text.Trim() +
                    ",'" + tbDateTime.Text.Trim() +
                    "'," + tbTrouble.Text.Trim() +                                //10
                    ",'Routine" + 
                    "','" + uid +
                    "','" + tbOwnerEmail.Text.Trim() +
                    //"','" + supervisor +
                    //"','" + superemail 
                    "') ");                    //15
            //cmd.Parameters.Add(Trouble);
            //cmd.Parameters.Add(Phone);
            //cmd.Parameters.Add(CostCenter);
            //cmd.Parameters.Add(Project);
            //cmd.Parameters.Add(ContactEmail);

            cmd.Connection = cnxn;
            cnxn.Open();
            try
            {
                int rowsReturned = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                //Lerror.Visible = true;
                //Lerror.Text = ex.ToString();
                return;
            }
            cnxn.Close();

        }
    }
}
