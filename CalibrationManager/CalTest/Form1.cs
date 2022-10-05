using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CalTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection("server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = calibration;");

            cnxn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnxn;
            //cmd.CommandText = "calibration_data_scan";
            cmd.CommandText = "calibration_data_TEST";
            cmd.CommandType = CommandType.StoredProcedure;

            //SqlParameter status = new SqlParameter("@Status", SqlDbType.NChar, 200);
            //status.Direction = ParameterDirection.Output;
            //status.Value = "Init";

            //cmd.Parameters.Add(status);

            //cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();

            //string feedback = "";
            //if (dr.Read())
            //{
            //    feedback = dr.GetString(0);
            //}
            //dr.Close();
            cnxn.Close();

        }

    }
}
