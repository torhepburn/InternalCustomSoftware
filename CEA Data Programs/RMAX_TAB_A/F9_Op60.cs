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
    public partial class F9_Op60 : Form
    {
        SqlConnection cnxn;
        private string op60PF;

        public F9_Op60()
        {
            InitializeComponent();
        }

        private void F9_Op60_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter
                    ("select " +
                     " op60InThickness " +
                     ",op60InThicknessInsp " +
                     ",convert(varchar,op60InThicknessDate, 101) " +
                     ",op60ThickAPolish " +
                     ",op60ThickAPolishInsp " +
                     ",convert(varchar,op60thickAPolishDate, 101) " +
                     ",op60ThickARemoval " +
                     ",op60Wedge " +
                     ",op60WedgeInsp " +
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

                tbAPolish.Text = table.Rows[0][3].ToString();
                tbAPolishInsp.Text = table.Rows[0][4].ToString();

                if (table.Rows[0][5].ToString().Length > 0)
                {
                    dtpADate.Text = table.Rows[0][5].ToString();
                }

                tbARemoval.Text = table.Rows[0][6].ToString();

                tbWedge.Text = table.Rows[0][7].ToString();
                tbWedgeInsp.Text = table.Rows[0][8].ToString();

                if (table.Rows[0][9].ToString().Length > 0)
                {
                    dtpWedgeDate.Text = table.Rows[0][9].ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                Close();
            }
            finally
            {

            }

        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            if (tbThickness.BackColor.G == 200 & tbAPolish.BackColor.G == 200 &
                tbWedge.BackColor.G == 200)
            {
                op60PF = "PASS";
            }
            else
            {
                op60PF = "FAIL";
                MessageBox.Show("This step does not PASS !");
            }

            try
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                    ("Update CEA_RMAX_MIRROR_TAB_A " +
                     "  set " +
                     "  op60InThickness = @Thickness " +
                     " ,op60InthicknessInsp = @ThickInsp " +
                     " ,op60InthicknessDate = @ThickDate " +
                     " ,op60ThickAPolish = @APolish " +
                     " ,op60ThickAPolishInsp = @APolishInsp " +
                     " ,op60thickAPolishDate = @ADate " +
                     " ,op60ThickARemoval = @ARemoval " +
                     " ,op60Wedge = @Wedge " +
                     " ,op60wedgeinsp = @WedgeInsp " +
                     " ,op60wedgedate = @WedgeDate " +
                    " ,op60pf = '" + op60PF + "' " +
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

                if (tbAPolish.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@APolish", SqlDbType.NChar, 10).Value = tbAPolish.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@APolish", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@APolishInsp", SqlDbType.NChar, 10).Value = tbAPolishInsp.Text.Trim();
                cmd.Parameters.Add("@ADate", SqlDbType.NChar, 10).Value = dtpADate.Text.Trim();
                cmd.Parameters.Add("@ARemoval", SqlDbType.NChar, 10).Value = tbARemoval.Text.Trim();

                
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
            g.decimalChecker(tbThickness, 81.00M, 80.50M);
        }

        private void tbAPolish_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbAPolish, 80.95M, 80.45M);
            tbARemoval.Text = (Convert.ToDecimal(tbThickness.Text) -
                Convert.ToDecimal(tbAPolish.Text)).ToString();
        }

        private void tbWedge_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbWedge, 0.625M, 0.000M);
        }

        private void tbThickInsp_Leave(object sender, EventArgs e)
        {
            tbAPolishInsp.Text = tbThickInsp.Text;
            tbWedgeInsp.Text = tbThickInsp.Text;
        }

        private void dtpThickDate_Leave(object sender, EventArgs e)
        {
            dtpADate.Value = dtpThickDate.Value;
            dtpWedgeDate.Value = dtpThickDate.Value;
        }
    }
}
