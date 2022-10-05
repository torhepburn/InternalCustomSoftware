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
    public partial class F11_Op75 : Form
    {
        SqlConnection cnxn;
        private string op75PF;

        public F11_Op75()
        {
            InitializeComponent();
        }

        private void F11_Op75_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("select " +
                 " op75Wedge " +
                 ",op75WedgeInsp " +
                 ",convert(varchar,op75Wedgedate, 101) " +
                 "from CEA_RMAX_MIRROR_TAB_A where [part serial number] = " + g.serialNumber + " ", cnxn);

            DataTable table = new DataTable();

            da.Fill(table);

            tbWedge.Text = table.Rows[0][0].ToString();
            tbWedgeInsp.Text = table.Rows[0][1].ToString();

        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            if (tbWedge.BackColor.G == 200)
            {
                op75PF = "PASS";
            }
            else
            {
                op75PF = "FAIL";
                MessageBox.Show("This step does not PASS !");
            }

            try
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                    ("Update CEA_RMAX_MIRROR_TAB_A " +
                     "set op75Wedge = @Wedge " +
                     " ,op75wedgeinsp = @WedgeInsp " +
                     " ,op75wedgedate = @WedgeDate " +
                    " ,op75pf = '" + op75PF + "' " +
                     "where [part serial number] = " + g.serialNumber + " ", cnxn);

                
                if (tbWedge.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@Wedge", SqlDbType.NChar, 10).Value = tbWedge.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Wedge", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@WedgeInsp", SqlDbType.NChar, 10).Value = tbWedgeInsp.Text.Trim();
                cmd.Parameters.Add("@WedgeDate", SqlDbType.NChar, 10).Value = dtpWedgeDate.Text.Trim();

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

        private void tbWedge_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbWedge, 0.625M, 0.000M);
        }
    }
}
