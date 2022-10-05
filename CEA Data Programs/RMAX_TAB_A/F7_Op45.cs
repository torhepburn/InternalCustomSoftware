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
    public partial class F7_Op45 : Form
    {
        SqlConnection cnxn;
        private string op45PF;

        public F7_Op45()
        {
            InitializeComponent();
        }

        private void F7_Op45_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                (" select " +
                 " op45Bevel " +
                 " ,op45BevelInsp " +
                 " ,convert(varchar,op45BevelDate, 101) " +
                 " from CEA_RMAX_MIRROR_TAB_A where [part serial number] = " + g.serialNumber + " ", cnxn);

            DataTable table = new DataTable();

            da.Fill(table);

            tbBevel.Text = table.Rows[0][0].ToString();
            tbBevelInsp.Text = table.Rows[0][1].ToString();

            if (table.Rows[0][2].ToString().Length > 0)
            {
                dtpBevelDate.Text = table.Rows[0][2].ToString();
            }
        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            if (tbBevel.BackColor.G == 200)
            {
                op45PF = "PASS";
            }
            else
            {
                op45PF = "FAIL";
                MessageBox.Show("This step does not PASS !");
            }

            try
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                    ("Update CEA_RMAX_MIRROR_TAB_A " +
                     " set op45Bevel = @Bevel " +
                     " ,op45Bevelinsp = @BevelInsp " +
                     " ,op45Beveldate = @BevelDate " +
                     " ,op45pf = '" + op45PF + "' " +
                     "where [part serial number] = " + g.serialNumber + " ", cnxn);

                if (tbBevel.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@Bevel", SqlDbType.NChar, 10).Value = tbBevel.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Bevel", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@BevelInsp", SqlDbType.NChar, 10).Value = tbBevelInsp.Text.Trim();
                cmd.Parameters.Add("@BevelDate", SqlDbType.NChar, 10).Value = dtpBevelDate.Text.Trim();

                cnxn.Open();
                int rowsReturned = cmd.ExecuteNonQuery();
                cnxn.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }

        private void tbBevel_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbBevel, 1.50M, 1.10M);
        }
    }
    
}
