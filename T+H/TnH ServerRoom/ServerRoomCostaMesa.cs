using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TnH_ServerRoom
{
    public partial class ServerRoomCostaMesa : Form
    {
        SqlConnection cnxn = new SqlConnection
           ("server = midsql01; user = views; password = views;" +
            "database = tnh;");

        public ServerRoomCostaMesa()
        {
            InitializeComponent();
        }

        private void ServerRoomCostaMesa_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = (1000) * (1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter
              ("select top 1 " +
               "tempf, " +
               "rh, " +
               "[log] from tnhdata " +
               "where address = '10.213.97.1' " +
               "order by [log] desc", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            Ltemp.Text = table.Rows[0].ItemArray[0].ToString();
            Lhum.Text = table.Rows[0].ItemArray[1].ToString();
            Ltime.Text = table.Rows[0].ItemArray[2].ToString();
            timer1.Interval = (1000) * (60) * (1);
        }

    }

}
