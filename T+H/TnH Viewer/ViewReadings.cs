using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TnH
{
    public partial class ViewReadings : Form
    {
        BindingSource bs = new BindingSource();
        SqlConnection cnxn = new SqlConnection
                ("server = CT-MID-SQL11; user = views; password = views; " +
                 "database = tnh;");

        public ViewReadings()
        {
            InitializeComponent();
        }

        private void ViewReadings_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = (1000) * (1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter
                ("Select address, Read_Location, Location, monitortype as [Monitor Type],  " + 
                "CalibrationIDnumber as 'Label ID', Last_Read_Time " +
                " from unitSetup " +
                "WHERE read_location = 'Irvine' " +
                "and active = 1 " +
                "order by dbo.sc_sortableversionstring(address)", cnxn);
                DataTable table = new DataTable();
                da.Fill(table);
                bs.DataSource = table;
                DGV.DataSource = bs;
                foreach (DataGridViewRow gr in DGV.Rows)
                {
                    if (Convert.ToDateTime(gr.Cells[5].Value.ToString()) < DateTime.Now.AddMinutes(-186))
                    {
                        gr.DefaultCellStyle.BackColor = Color.LightSeaGreen;
                    }
                    else
                    {
                        gr.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    }
                }
                DGV.Show();
                timer1.Interval = (1000) * (60);
        }
    }
}