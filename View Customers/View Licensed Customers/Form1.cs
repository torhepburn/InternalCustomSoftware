using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace View_Licensed_Customers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
                ("server = midsql01; user = readWrite; password = Read+Write!; database = zygoproductlicenses;");
            SqlDataAdapter da = new SqlDataAdapter
                ("Select * from donglefulldetails where [customer number] is not null order by Owner", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            DGV.Show();
        }
    }
}
