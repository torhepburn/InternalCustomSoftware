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
    public partial class F13_Op90 : Form
    {
        SqlConnection cnxn;
        private string op90PF;

        public F13_Op90()
        {
            InitializeComponent();
        }

        private void F13_Op90_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("select " +
                 " op90DataSaved " +
                 ",op90Insp " +
                 ",convert(varchar,op90Date, 101) " +
                 "from CEA_RMAX_MIRROR_TAB_A where [part serial number] = " + g.serialNumber + " ", cnxn);

            DataTable table = new DataTable();

            da.Fill(table);

            if (table.Rows[0][0].Equals(true))
            {
                cbDataSaved.Checked = true;
            }
            else
            {
                cbDataSaved.Checked = false;
            }

            tbInsp.Text = table.Rows[0][1].ToString();

            if (table.Rows[0][2].ToString().Length > 0)
            {
                dtpDate.Text = table.Rows[0][2].ToString();
            }
        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            if (cbDataSaved.Checked == true)
            {
                op90PF = "PASS";
            }
            else
            {
                op90PF = "FAIL";
                MessageBox.Show("This step does not PASS !");
            }

            try
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                    ("Update CEA_RMAX_MIRROR_TAB_A " +
                     "set " + 
                     "  op90DataSaved = @DataSaved " +
                     " ,op90insp = @Insp " +
                     " ,op90date = @Date " +
                     " ,op90pf = '" + op90PF + "' " +
                     "where [part serial number] = " + g.serialNumber + " ", cnxn);

                if (cbDataSaved.Checked == true)
                {
                    cmd.Parameters.Add("@DataSaved", SqlDbType.Bit).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("@DataSaved", SqlDbType.Bit).Value = 0;
                }

                cmd.Parameters.Add("@Insp", SqlDbType.NChar, 10).Value = tbInsp.Text.Trim();
                cmd.Parameters.Add("@Date", SqlDbType.NChar, 10).Value = dtpDate.Text.Trim();

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

    }
}


