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
    public partial class F6_Op40 : Form
    {
        SqlConnection cnxn;
        private string op40PF;

        public F6_Op40()
        {
            InitializeComponent();
        }

        private void F6_Op40_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter
                    ("select " +
                     " op40IncomingThickness " +
                     ",op40InThickInsp " +
                     ",convert(varchar,op40InThickDate, 101) " +
                     ",op40ThickS2Grind " +
                     ",op40ThickS2Insp " +
                     ",convert(varchar,op40thickS2Date, 101) " +
                     ",op40S2Removal " +
                     ",op40ThickS1Grind " +
                     ",op40ThickS1Insp " +
                     ",convert(varchar,op40thickS1Date, 101) " +
                     ",op40S1Removal " +
                     ",op40Wedge " +
                     ",op40WedgeInsp " +
                     ",convert(varchar,op40Wedgedate, 101) " +
                     "from CEA_RMAX_MIRROR_TAB_A where [part serial number] = " + g.serialNumber + " ", cnxn);

                DataTable table = new DataTable();

                da.Fill(table);

                tbThickness.Text = table.Rows[0][0].ToString();
                tbThickInsp.Text = table.Rows[0][1].ToString();

                if (table.Rows[0][2].ToString().Length > 0)
                {
                    dtpThickDate.Text = table.Rows[0][2].ToString();
                }

                tbS2Grind.Text = table.Rows[0][3].ToString();
                tbS2GrindInsp.Text = table.Rows[0][4].ToString();

                if (table.Rows[0][5].ToString().Length > 0)
                {
                    dtpS2Date.Text = table.Rows[0][5].ToString();
                }

                tbS2Removal.Text = table.Rows[0][6].ToString();

                tbS1Grind.Text = table.Rows[0][7].ToString();
                tbS1GrindInsp.Text = table.Rows[0][8].ToString();

                if (table.Rows[0][9].ToString().Length > 0)
                {
                    dtpS1Date.Text = table.Rows[0][9].ToString();
                }

                tbS1Removal.Text = table.Rows[0][10].ToString();

                tbWedge.Text = table.Rows[0][11].ToString();
                tbWedgeInsp.Text = table.Rows[0][12].ToString();

                if (table.Rows[0][13].ToString().Length > 0)
                {
                    dtpWedgeDate.Text = table.Rows[0][13].ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }
        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            if (tbThickness.BackColor.G == 200 & tbS2Grind.BackColor.G == 200 &
                tbS1Grind.BackColor.G == 200 & tbWedge.BackColor.G == 200 )
            {
                op40PF = "PASS";
            }
            else
            {
                op40PF = "FAIL";
                MessageBox.Show("This step does not PASS !");
            }

            try
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                    ("Update CEA_RMAX_MIRROR_TAB_A " +
                     "  set " +
                     "  op40IncomingThickness = @Thickness " +
                     " ,op40InthickInsp = @ThickInsp " +
                     " ,op40InthickDate = @ThickDate " +
                     " ,op40ThickS2Grind = @S2Grind " +
                     " ,op40ThickS2Insp = @S2Insp " +
                     " ,op40thickS2Date = @S2Date " +
                     " ,op40S2Removal = @S2Removal " +
                     " ,op40ThickS1Grind = @S1Grind " +
                     " ,op40ThickS1Insp = @S1Grind " +
                     " ,op40thickS1Date = @S1Date " +
                     " ,op40S1Removal = @S1Removal " +
                     " ,op40Wedge = @Wedge " +
                     " ,op40wedgeinsp = @WedgeInsp " +
                     " ,op40wedgedate = @WedgeDate " +
                    " ,op40pf = '" + op40PF + "' " +
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

                if (tbS2Grind.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@S2Grind", SqlDbType.NChar, 10).Value = tbS2Grind.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@S2Grind", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@S2Insp", SqlDbType.NChar, 10).Value = tbS2GrindInsp.Text.Trim();
                cmd.Parameters.Add("@S2Date", SqlDbType.NChar, 10).Value = dtpS2Date.Text.Trim();
                cmd.Parameters.Add("@S2Removal", SqlDbType.NChar, 10).Value = tbS2Removal.Text.Trim();

                if (tbS1Grind.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@S1Grind", SqlDbType.NChar, 10).Value = tbS1Grind.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@S1Grind", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@S1Insp", SqlDbType.NChar, 10).Value = tbS1GrindInsp.Text.Trim();
                cmd.Parameters.Add("@S1Date", SqlDbType.NChar, 10).Value = dtpS1Date.Text.Trim();
                cmd.Parameters.Add("@S1Removal", SqlDbType.NChar, 10).Value = tbS1Removal.Text.Trim();

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
            g.decimalChecker(tbThickness, 81.65M, 80.15M);
        }

        private void tbS2Grind_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbS2Grind, 81.40M, 81.35M);
            tbS2Removal.Text = (Convert.ToDecimal(tbThickness.Text) - 
                Convert.ToDecimal(tbS2Grind.Text)).ToString();
        }

        private void tbS1Grind_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbS1Grind, 81.05M, 80.65M);
            tbS1Removal.Text = (Convert.ToDecimal(tbS2Grind.Text) -
                Convert.ToDecimal(tbS1Grind.Text)).ToString();
        }

        private void tbWedge_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbWedge, 0.625M, 0.000M);
        }

        private void tbThickInsp_Leave(object sender, EventArgs e)
        {
            tbS2GrindInsp.Text = tbThickInsp.Text;
            tbS1GrindInsp.Text = tbThickInsp.Text;
            tbWedgeInsp.Text = tbThickInsp.Text;
        }

        private void dtpThickDate_Leave(object sender, EventArgs e)
        {
            dtpS2Date.Value = dtpThickDate.Value;
            dtpS1Date.Value = dtpThickDate.Value;
            dtpWedgeDate.Value = dtpThickDate.Value;
        }
    }
}
