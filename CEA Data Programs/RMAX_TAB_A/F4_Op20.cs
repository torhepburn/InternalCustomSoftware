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
    public partial class F4_Op20 : Form
    {
        SqlConnection cnxn;
        private string op20PF;

        public F4_Op20()
        {
            InitializeComponent();
        }

        private void F4_Op20_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("select " +
                 " op20Wedge " +
                 ",op20WedgeInsp " +
                 ",convert(varchar,op20Wedgedate, 101) " +
                 ",op20Thickness " +
                 ",op20ThickInsp " +
                 ",convert(varchar,op20thickDate, 101) " +
                 "from CEA_RMAX_MIRROR_TAB_A where [part serial number] = " + g.serialNumber + " ", cnxn);

            DataTable table = new DataTable();

            da.Fill(table);

            tbWedge.Text = table.Rows[0][0].ToString();
            tbWedgeInsp.Text = table.Rows[0][1].ToString();

            if (table.Rows[0][2].ToString().Length > 0)
            {
                dtpWedgeDate.Text = table.Rows[0][2].ToString();
            }

            tbThickness.Text = table.Rows[0][3].ToString();
            tbThickInsp.Text = table.Rows[0][4].ToString();

            if (table.Rows[0][5].ToString().Length > 0)
            {
                dtpThickDate.Text = table.Rows[0][5].ToString();
            }
        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            if (tbWedge.BackColor.G == 200 & tbThickness.BackColor.G == 200)
            {
                op20PF = "PASS";
            }
            else
            {
                op20PF = "FAIL";
                MessageBox.Show("This step does not PASS !");
            }

            try
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                    ("Update CEA_RMAX_MIRROR_TAB_A " +
                     "set op20Wedge = @Wedge " +
                     " ,op20wedgeinsp = @WedgeInsp " +
                     " ,op20wedgedate = @WedgeDate " +
                     " ,op20Thickness = @Thickness " +
                     " ,op20thickInsp = @ThickInsp " +
                     " ,op20thickDate = @ThickDate " +
                    " ,op20pf = '" + op20PF + "' " +
                     "where [part serial number] = " + g.serialNumber + " ", cnxn);

                if (tbThickness.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@Thickness", SqlDbType.NChar, 10).Value = tbThickness.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Thickness", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@ThickInsp", SqlDbType.NChar, 10).Value = tbThickInsp.Text.Trim();
                cmd.Parameters.Add("@ThickDate", SqlDbType.NChar, 10).Value = dtpThickDate.Text.Trim();


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

        private void tbThickness_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbThickness, 81.65M, 81.15M);
        }

        private void tbWedge_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbWedge, 0.625M, 0.000M);
        }

        private void tbThickInsp_Leave(object sender, EventArgs e)
        {
            tbWedgeInsp.Text = tbThickInsp.Text;
        }

        private void dtpThickDate_Leave(object sender, EventArgs e)
        {
            dtpWedgeDate.Value = dtpThickDate.Value;
        }
    }
}
