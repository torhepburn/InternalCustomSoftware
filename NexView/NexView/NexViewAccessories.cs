using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NexView
{
    public partial class NexViewAccessories : Form
    {
        SqlConnection cnxn = new SqlConnection(g.db);
        SqlDataAdapter da;
        DataTable table;

        public NexViewAccessories()
        {
            InitializeComponent();
        }

        private void NexViewAccessories_Load(object sender, EventArgs e)
        {
            lblSerialNumber.Text = "Serial Number:  " + g.serialNumber;

            try
            {
                cnxn.Open();
                da = new SqlDataAdapter(
                    "select accobjectives from NexView_Data " +
                    " where sn = '" + g.serialNumber + "' " +
                    "order by sn", cnxn);
                table = new DataTable();
                da.Fill(table);
                cnxn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            /*
            DGV1.DataSource = table;
            DGV1.Show();
            DGV1.Columns[0].Width = 100;
            */

            string StartText = table.Rows[0][0].ToString().Trim();


            string stophere = "this";
        }
    }
}
