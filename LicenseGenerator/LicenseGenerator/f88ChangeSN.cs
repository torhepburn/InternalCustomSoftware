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
using static System.Net.Mime.MediaTypeNames;

namespace LicenseGenerator
{
    public partial class f88ChangeSN : Form
    {
        SqlConnection cnxn;
        SqlDataReader dr;
        SqlCommand cmd;
        private string SerialNo;
        
        public f88ChangeSN()
        {
            InitializeComponent();
        }

        private void f88ChangeSN_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            cmd = new SqlCommand(
                "select " +
                "dongleid " +
                ",COALESCE(serialno, '') from LicenseData where " +
                "productline = 'MX' and " +
                "dongleid = '" + g.DongleID + "' " +
                "order by SerialNo", cnxn);

            DataTable dt = new DataTable();

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            LDongleID.Text = "DongleID: " + dt.Rows[0][0].ToString().Trim();
            LSerialNo.Text = "Current Serial Number: " + dt.Rows[0][1].ToString().Trim();
        }

        private void bChange_Click(object sender, EventArgs e)
        {
            if (tbSerialNo.Text.Length > 0)
            {
                SerialNo = tbSerialNo.Text.Trim();
            }
            else
            {
                MessageBox.Show("Must enter new serial number.");
                tbSerialNo.Focus();
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand(
                       " Update LicenseData " +
                       " set SerialNo = '" + SerialNo + "' " +
                       " where DongleID = '" + g.DongleID + "' ", cnxn);

                cnxn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }
            this.Close();

        }
    }
}
