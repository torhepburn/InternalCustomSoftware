using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SqlConnection cnxn = new SqlConnection(
            //   "server = MIDSQL01; user = ReadWrite; " +
            //   "password = Read+Write!; database = Calibration;");
            SqlConnection cnxn = new SqlConnection(
                "server = MIDSQL01; user = ReadWrite; " +
            "password = Read+Write!; database = PriceLists;");
            //SqlConnection cnxn = new SqlConnection(
            //    "server = MIDSQL01; user = ReadWrite; " +
            //    "password = Read+Write!; database = Calibration;");
            //SqlCommand cmd = new SqlCommand("select * from equipment", cnxn);
            SqlCommand cmd = new SqlCommand("Select top 10 * from QWpricelist " +
            "where sales_price_list = 'dom'");
            cmd.Connection = cnxn;
            cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

        }
    }
}
