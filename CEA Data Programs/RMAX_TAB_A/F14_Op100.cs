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
    public partial class F14_Op100 : Form
    {
        SqlConnection cnxn;
        private string op100PF;

        public F14_Op100()
        {
            InitializeComponent();
        }

        private void F14_Op100_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter
                    ("select " +
                     " op100Thickness " +
                     ",op100ThicknessInsp " +
                     ",convert(varchar,op100ThicknessDate, 101) " +
                     ",op100SurfaceMap " +
                     ",op100SurfMapInsp " +
                     ",convert(varchar,op100SurfMapDate, 101) " +
                     "from CEA_RMAX_MIRROR_TAB_A where [part serial number] = " + g.serialNumber + " ", cnxn);

                DataTable table = new DataTable();

                da.Fill(table);

                tbThickness.Text = table.Rows[0][0].ToString();
                tbThickInsp.Text = table.Rows[0][1].ToString();

                if (table.Rows[0][2].ToString().Length > 0)
                {
                    dtpThickDate.Text = table.Rows[0][2].ToString();
                }

                if (table.Rows[0][3].Equals(true))
                {
                    cbSurfaceMap.Checked = true;
                }
                else
                {
                    cbSurfaceMap.Checked = false;
                }

                tbMapInsp.Text = table.Rows[0][4].ToString();

                if (table.Rows[0][5].ToString().Length > 0)
                {
                    dtpMapDate.Text = table.Rows[0][5].ToString();
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
            if (tbThickness.BackColor.G == 200 & 
                cbSurfaceMap.Checked == true)
            {
                op100PF = "PASS";
            }
            else
            {
                op100PF = "FAIL";
                MessageBox.Show("This step does not PASS !");
            }

            try
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                    ("Update CEA_RMAX_MIRROR_TAB_A set " +
                     " op100Thickness = @Thickness " +
                     ",op100ThicknessInsp = @ThickInsp " +
                     ",op100ThicknessDate = @ThickDate " +
                     ",op100SurfaceMap = @SurfaceMap " +
                     ",op100SurfMapInsp = @SurfMapInsp " +
                     ",op100SurfMapDate = @SurfMapDate " +
                     ",op100pf = '" + op100PF + "' " +
                     "where [part serial number] = " + g.serialNumber + " ", cnxn);

                if (tbThickness.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@Thickness", SqlDbType.NChar, 10).Value = tbThickness.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@thickness", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@ThickInsp", SqlDbType.NChar, 10).Value = tbThickInsp.Text.Trim();
                cmd.Parameters.Add("@thickDate", SqlDbType.NChar, 10).Value = dtpThickDate.Text.Trim();


                if (cbSurfaceMap.Checked == true)
                {
                    cmd.Parameters.Add("@SurfaceMap", SqlDbType.Bit).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("@SurfaceMap", SqlDbType.Bit).Value = 0;
                }

                cmd.Parameters.Add("@SurfMapInsp", SqlDbType.NChar, 10).Value = tbMapInsp.Text.Trim();
                cmd.Parameters.Add("@SurfMapDate", SqlDbType.NChar, 10).Value = dtpMapDate.Text.Trim();

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
            g.decimalChecker(tbThickness, 81.00M, 79.00M);
        }

        private void tbThickInsp_Leave(object sender, EventArgs e)
        {
            tbMapInsp.Text = tbThickInsp.Text;
        }

        private void dtpThickDate_Leave(object sender, EventArgs e)
        {
            dtpMapDate.Value = dtpThickDate.Value;
        }
    }
}
