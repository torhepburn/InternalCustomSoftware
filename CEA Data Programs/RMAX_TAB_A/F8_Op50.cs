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
    public partial class F8_Op50 : Form
    {
        SqlConnection cnxn;
        private string op50PF;

        public F8_Op50()
        {
            InitializeComponent();
        }

        private void F8_Op50_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter
                    ("select " +
                     " op50InThickness " +
                     ",op50InThicknessInsp " +
                     ",convert(varchar,op50InThicknessDate, 101) " +
                     ",op50SurfaceRoughness " +
                     ",op50SurRufInsp " +
                     ",convert(varchar,op50SurRufDate, 101) " +
                     ",op50Thickness " +
                     ",op50ThickInsp " +
                     ",convert(varchar,op50thickDate, 101) " +
                     ",op50Wedge " +
                     ",op50WedgeInsp " +
                     ",convert(varchar,op50WedgeDate, 101) " +
                     "from CEA_RMAX_MIRROR_TAB_A where [part serial number] = " + g.serialNumber + " ", cnxn);

                DataTable table = new DataTable();

                da.Fill(table);

                tbInthickness.Text = table.Rows[0][0].ToString();
                tbInThickInsp.Text = table.Rows[0][1].ToString();

                if (table.Rows[0][2].ToString().Length > 0)
                {
                    dtpInThickDate.Text = table.Rows[0][2].ToString();
                }

                tbSurfaceRoughness.Text = table.Rows[0][3].ToString();
                tbSurfRufInsp.Text = table.Rows[0][4].ToString();

                if (table.Rows[0][5].ToString().Length > 0)
                {
                    dtpSurfRufDate.Text = table.Rows[0][5].ToString();
                }

                tbThickness.Text = table.Rows[0][6].ToString();
                tbThickInsp.Text = table.Rows[0][7].ToString();

                if (table.Rows[0][8].ToString().Length > 0)
                {
                    dtpThickDate.Text = table.Rows[0][8].ToString();
                }

                tbWedge.Text = table.Rows[0][9].ToString();
                tbWedgeInsp.Text = table.Rows[0][10].ToString();

                if (table.Rows[0][11].ToString().Length > 0)
                {
                    dtpWedgeDate.Text = table.Rows[0][11].ToString();
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
            if (tbInthickness.BackColor.G == 200 & tbSurfaceRoughness.BackColor.G == 200 &
                tbThickness.BackColor.G == 200 & tbWedge.BackColor.G == 200)
            {
                op50PF = "PASS";
            }
            else
            {
                op50PF = "FAIL";
                MessageBox.Show("This step does not PASS !");
            }

            try
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                    ("Update CEA_RMAX_MIRROR_TAB_A set " +
                     " op50Inthickness = @InThickness " +
                     ",op50InthicknessInsp = @InThickInsp " +
                     ",op50InthicknessDate = @InThickDate " +
                     ",op50SurfaceRoughness = @SurfaceRoughness " +
                     ",op50SurRufInsp = @SurfRufInsp " +
                     ",op50SurRufDate = @SurfRufDate " +
                     ",op50Thickness = @Thickness " +
                     ",op50ThickInsp = @ThickInsp " +
                     ",op50ThickDate = @ThickDate " +
                     ",op50Wedge = @Wedge " +
                     ",op50WedgeInsp = @WedgeInsp " +
                     ",op50WedgeDate = @WedgeDate " +
                     ",op50pf = '" + op50PF + "' " +
                     "where [part serial number] = " + g.serialNumber + " ", cnxn);

                if (tbInthickness.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@Inthickness", SqlDbType.NChar, 10).Value = tbInthickness.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Inthickness", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@InThickInsp", SqlDbType.NChar, 10).Value = tbInThickInsp.Text.Trim();
                cmd.Parameters.Add("@InthickDate", SqlDbType.NChar, 10).Value = dtpInThickDate.Text.Trim();


                if (tbSurfaceRoughness.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@SurfaceRoughness", SqlDbType.NChar, 10).Value = tbSurfaceRoughness.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@SurfaceRoughness", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@SurfRufInsp", SqlDbType.NChar, 10).Value = tbSurfRufInsp.Text.Trim();
                cmd.Parameters.Add("@SurfRufDate", SqlDbType.NChar, 10).Value = dtpSurfRufDate.Text.Trim();

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

        private void tbSurfaceRoughness_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbSurfaceRoughness, .5M, .1M);
        }

        private void tbInthickness_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbInthickness, 81.05M, 80.55M);
        }

        private void tbThickness_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbThickness, 81.00M, 80.50M);
        }

        private void tbWedge_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbWedge, 0.625M, 0.000M);
        }

        private void tbInThickInsp_Leave(object sender, EventArgs e)
        {
            tbSurfRufInsp.Text = tbInThickInsp.Text;
            tbThickInsp.Text = tbInThickInsp.Text;
            tbWedgeInsp.Text = tbInThickInsp.Text;
        }

        private void dtpInThickDate_Leave(object sender, EventArgs e)
        {
            dtpSurfRufDate.Value = dtpInThickDate.Value;
            dtpThickDate.Value = dtpInThickDate.Value;
            dtpWedgeDate.Value = dtpInThickDate.Value;
        }
    }
}
