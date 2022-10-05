using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ChooseLocation
{
    public partial class ChooseLocation : Form
    {
        private string selection;
        
        public ChooseLocation()
        {
            InitializeComponent();
        }

        private void ChooseLocation_Load(object sender, EventArgs e)
        {
            rbM11.Checked = true;

            SqlConnection cnxn = new SqlConnection
                ("server=midsql01; user=readwrite; password=Read+Write!; database=tnh;");

            SqlCommand cmd = new SqlCommand("Select location from sensorlocation where " +
                "address = '10.213.83.7'", cnxn);
            cnxn.Open();

            try
            {
                object o = cmd.ExecuteScalar();
                label1.Text = "Current location: " + o.ToString().Trim();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            cnxn.Close();
            
            
        }

        private void bEnterSelection_Click(object sender, EventArgs e)
        {
            if (rbM11.Checked == true)
            { selection = "M1-1"; }

            if (rbM12.Checked == true)
            { selection = "M1-2"; }

            if (rbM13.Checked == true)
            { selection = "M1-3"; }

            if (rbM14.Checked == true)
            { selection = "M1-4"; }

            if (rbM21.Checked == true)
            { selection = "M2-1"; }

            if (rbM31.Checked == true)
            { selection = "M3-1"; }

            if (rbICQ1.Checked == true)
            { selection = "IQC-1"; }

            if (rbICQ2.Checked == true)
            { selection = "IQC-2"; }

            if (rbCL1.Checked == true)
            { selection = "CL-1"; }

            SqlConnection cnxn = new SqlConnection
                ("server=midsql01; user=readwrite; password=Read+Write!; database=tnh;");
            SqlCommand cmd = new SqlCommand("Update SensorLocation " +
                   "set Location = '" + selection + "' where " +
                   "address = '10.213.83.7' ");
                   
            cmd.Connection = cnxn;
            cnxn.Open();
            try
            {
                int rowsReturned = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            this.Close();
        }
    }
}
