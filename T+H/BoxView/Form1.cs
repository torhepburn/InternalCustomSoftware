using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BoxView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime here = DateTime.Now;

            DateTime there = DateTime.UtcNow.AddHours(-7);

            string log = DateTime.UtcNow.AddHours(-7).ToString();

            DateTime Tucson = there.AddHours(-7);

            SqlConnection cnxn = new SqlConnection("server = midprj01; " +
                    "user = views; password = views; database = tandh;");
            SqlDataAdapter da = new SqlDataAdapter
               ("Select IP, Read_Location, Location, monitortype, e.model, CalibrationIDnumber,Last_Read_Time " +
                " from lup_readings r left join midsql01.calibration.dbo.equipment e on " + 
                "r.calibrationidnumber = e.id", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
        }
    }
}
