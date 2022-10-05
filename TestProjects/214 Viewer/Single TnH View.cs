using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _14_Viewer
{
    public partial class Bacon_Viewer : Form
    {
        BindingSource bs = new BindingSource();
        SqlDataAdapter da;

        public Bacon_Viewer()
        {
            InitializeComponent();
        }

        private void Bacon_Viewer_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(
                "server = midprj01; user = views; " +
                "password = views; database = TandH;");
            SqlDataAdapter da = new SqlDataAdapter
                ("select distinct ip, location from lup_readings order by ip", cnxn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox1.DataSource = dt;

            DataColumn dc = new DataColumn("combined");
            dc.Expression = string.Format("{0}+ ' '+ {1}", "ip", "Location");
            dt.Columns.Add(dc);
            comboBox1.DisplayMember = "combined";
            comboBox1.ValueMember = "IP";

            //dtpStart.Value = DateTime.Now.AddDays(-1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtpStart.Value = DateTime.Now.AddDays(-1);
            
            SqlConnection cnxn = new SqlConnection
                   ("server = midprj01; user = views; " +
                    "password = views; database = TandH;");
            
            if (comboBox1.SelectedValue.ToString() != "128.1.9.223" &
                comboBox1.SelectedValue.ToString() != "128.1.9.224")
            {
                da = new SqlDataAdapter
                    ("select dtetime as [Log], TempF, RH from " +
                     "tbl_readings_" +
                     comboBox1.SelectedValue.ToString().Replace(".", "_") +
                     " where dtetime >= '" + dtpStart.Value + "' " +
                     " and dtetime <= '" + dtpEnd.Value + "' " +
                     " order by dtetime desc", cnxn);
                
            }

            if (comboBox1.SelectedValue.ToString() == "128.1.9.223")
            {
                da = new SqlDataAdapter
                    ("select dtetime as [Log], Temp1F as VN008, " +
                     "Temp2F as VN007 from " +
                     "tbl_readings_" +
                     comboBox1.SelectedValue.ToString().Replace(".", "_") +
                     " where dtetime >= '" + dtpStart.Value + "' " +
                     " and dtetime <= '" + dtpEnd.Value + "' " +
                     " order by dtetime desc", cnxn);

            }

            if (comboBox1.SelectedValue.ToString() == "128.1.9.224")
            {
                da = new SqlDataAdapter
                    ("select dtetime as [Log], Temp1F as VN005, " +
                     "Temp2F as VN006 from " +
                     "tbl_readings_" +
                     comboBox1.SelectedValue.ToString().Replace(".", "_") +
                     " where dtetime >= '" + dtpStart.Value + "' " +
                     " and dtetime <= '" + dtpEnd.Value + "' " +
                     " order by dtetime desc", cnxn);

            }

            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            //bs.DataSource = table;
            //DGV.DataSource = bs;
            DGV.Show();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}