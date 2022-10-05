using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace FileManipulation
{
    public partial class PMdatabase : Form
    {
        public PMdatabase()
        {
            InitializeComponent();
        }

        private void PMdatabase_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("c:\\a\\pmtasks.csv");

            while (sr.Peek() >= 0)
            {
                string x = sr.ReadLine();

                string[] insert = x.Split(',');

            
                SqlConnection cxn = new SqlConnection("server = midprj01; " +
                    "user id = views; password = views; database = logsheetsdb;");

                //SqlCommand cmd = new SqlCommand("Insert into pmequip (" +
                //    "serial, " +    
                //    "startdate, " +
                //    "status, " +
                //    "description, " +        
                //    "owner, " +      
                //    "location, " +
                //    "comment, " +
                //    "lotoverified, " +
                //    "cost_center, " +
                //    "serial_nospaces)" +
                //    "values " +
                //    "('" + insert[0].ToString().Trim() +        
                //    "','" + insert[1].ToString().Trim() +        
                //    "','" + insert[2].ToString().Trim() +
                //    "','" + insert[3].ToString().Trim() +
                //    "','" + insert[4].ToString().Trim() +   
                //    "','" + insert[5].ToString().Trim() +      
                //    "','" + insert[6].ToString().Trim() +
                //    "','" + insert[7].ToString().Trim() +        
                //    "','" + insert[8].ToString().Trim() +
                //    "','" + insert[9].ToString().Trim() +        
                //    "' )");

                SqlCommand cmd = new SqlCommand("Insert into pmtasks (" +
                    "serial, " +
                    "item, " +
                    "freq, " +
                    "[group], " +
                    "material, " +
                    "pmtask, " +
                    "lastpm) " +
                    "values " +
                    "('" + insert[0].ToString().Trim() +
                    "'," + insert[1].ToString().Trim() +
                    "," + insert[2].ToString().Trim() +
                    ",'" + insert[3].ToString().Trim() +
                    "','" + insert[4].ToString().Trim() +
                    "','" + insert[5].ToString().Trim() +
                    "','" + insert[6].ToString().Trim() +
                    "' )");


                cmd.Connection = cxn;
                cxn.Open();
                int rowsReturned = cmd.ExecuteNonQuery();
                cxn.Close();
            }
 
        }
    }
}