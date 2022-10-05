using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ShortTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection("server = midsql01; user = ReadWrite; password = Read+Write!; database = Accessfrontends;");
            SqlDataAdapter da = new SqlDataAdapter
                ("Select * from [shortage list]", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            dgv.DataSource = table;
            dgv.Show();
        }
    }
}
