using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RMAX_TAB_A
{
    public partial class F0_Admin : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;

        public F0_Admin()
        {
            InitializeComponent();
        }

        private void bEnterProgram_Click(object sender, EventArgs e)
        {
            F1_SelectSerialNumber f1 = new F1_SelectSerialNumber();
            f1.Show();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            cmd = new SqlCommand
                ("Select [part serial number] from CEA_RMAX_MIRROR_TAB_A  " +
                 "where [part serial number] = @SN", cnxn);

            cmd.Parameters.Add("@SN", SqlDbType.NVarChar, 10).Value = tbSerialNumber.Text.Trim();

            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();
            if (o != null)
            {
                string test = o.ToString().Trim();
                if (test == tbSerialNumber.Text.Trim())
                {
                    DialogResult result;
                    result = MessageBox.Show(test + " has already been entered.");
                    cmd.Parameters.Clear();
                    tbSerialNumber.Text = "";
                    tbSerialNumber.Focus();
                    return;
                }
            }
            else
            {
                try
                {

                    cmd = new SqlCommand("Insert into CEA_RMAX_MIRROR_TAB_A " +
                              "([Part Serial Number]) " +
                              "values (@SN)", cnxn);
                    cmd.Parameters.Add("@SN", SqlDbType.NVarChar, 10).Value = tbSerialNumber.Text.Trim();
                    cnxn.Open();
                    int result = cmd.ExecuteNonQuery();
                    

                    if (result == 1)
                    {
                        MessageBox.Show("Serial Number Entered");
                        tbSerialNumber.Text = "";
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cnxn.Close();
                }


            }

            cmd.Parameters.Clear();
        }
    }
}
