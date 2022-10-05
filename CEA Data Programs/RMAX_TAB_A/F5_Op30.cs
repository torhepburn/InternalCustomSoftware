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
    public partial class F5_Op30 : Form
    {
        SqlConnection cnxn;
        private string op30PF;

        public F5_Op30()
        {
            InitializeComponent();
        }

        private void F5_Op30_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter
                    ("select " +
                     " op30Chamfer " +
                     ",op30ChamferInsp " +
                     ",convert(varchar,op30Chamferdate, 101) " +
                     ",op30SurfaceRoughness " +
                     ",op30SurRufInsp " +
                     ",convert(varchar,op30SurRufDate, 101) " +
                     ",op30Length " +
                     ",op30LenInsp " +
                     ",convert(varchar,op30LenDate, 101) " +
                     ",op30Width " +
                     ",op30WidInsp " +
                     ",convert(varchar,op30WidDate, 101) " +
                     ",op30Serialized " +
                     ",op30SerInsp " +
                     ",convert(varchar,op30SerDate, 101) " +
                     "from CEA_RMAX_MIRROR_TAB_A where [part serial number] = " + g.serialNumber + " ", cnxn);

                DataTable table = new DataTable();

                da.Fill(table);

                tbChamfer.Text = table.Rows[0][0].ToString();
                tbChamferInsp.Text = table.Rows[0][1].ToString();

                if (table.Rows[0][2].ToString().Length > 0)
                {
                    dtpChamferDate.Text = table.Rows[0][2].ToString();
                }

                tbSurfaceRoughness.Text = table.Rows[0][3].ToString();
                tbSurfRufInsp.Text = table.Rows[0][4].ToString();

                if (table.Rows[0][5].ToString().Length > 0)
                {
                    dtpSurfRufDate.Text = table.Rows[0][5].ToString();
                }

                tbLength.Text = table.Rows[0][6].ToString();
                tbLenInsp.Text = table.Rows[0][7].ToString();

                if (table.Rows[0][8].ToString().Length > 0)
                {
                    dtpLenDate.Text = table.Rows[0][8].ToString();
                }

                tbWidth.Text = table.Rows[0][9].ToString();
                tbWidInsp.Text = table.Rows[0][10].ToString();

                if (table.Rows[0][11].ToString().Length > 0)
                {
                    dtpWidDate.Text = table.Rows[0][11].ToString();
                }

                if (table.Rows[0][12].Equals(true))
                {
                    cbSerialized.Checked = true;
                }
                else
                {
                    cbSerialized.Checked = false;
                }

                tbSerInsp.Text = table.Rows[0][13].ToString();

                if (table.Rows[0][14].ToString().Length > 0)
                {
                    dtpSerDate.Text = table.Rows[0][14].ToString();
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
            if (tbChamfer.BackColor.G == 200 & tbSurfaceRoughness.BackColor.G == 200 &
                tbLength.BackColor.G == 200 & tbWidth.BackColor .G == 200 &
                cbSerialized.Checked == true)
            {
                op30PF = "PASS";
            }
            else
            {
                op30PF = "FAIL";
                MessageBox.Show("This step does not PASS !");
            }

            try
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                    ("Update CEA_RMAX_MIRROR_TAB_A set " +
                     " op30Chamfer = @Chamfer " +
                     ",op30ChamferInsp = @ChamferInsp " +
                     ",op30Chamferdate = @ChamferDate " +
                     ",op30SurfaceRoughness = @SurfaceRoughness " +
                     ",op30SurRufInsp = @SurfRufInsp " +
                     ",op30SurRufDate = @SurfRufDate " +
                     ",op30Length = @Length " +
                     ",op30LenInsp = @LenInsp " +
                     ",op30LenDate = @LenDate " +
                     ",op30Width = @Width " +
                     ",op30WidInsp = @WidInsp " +
                     ",op30WidDate = @WidDate " +
                     ",op30Serialized = @Serialized " +
                     ",op30SerInsp = @SerInsp " +
                     ",op30SerDate = @SerDate " +
                     ",op30pf = '" + op30PF + "' " +
                     "where [part serial number] = " + g.serialNumber + " ", cnxn);

                if (tbChamfer.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@Chamfer", SqlDbType.NChar, 10).Value = tbChamfer.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Chamfer", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@ChamferInsp", SqlDbType.NChar, 10).Value = tbChamferInsp.Text.Trim();
                cmd.Parameters.Add("@ChamferDate", SqlDbType.NChar, 10).Value = dtpChamferDate.Text.Trim();


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

                if (tbLength.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@Length", SqlDbType.NChar, 10).Value = tbLength.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Length", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@LenInsp", SqlDbType.NChar, 10).Value = tbLenInsp.Text.Trim();
                cmd.Parameters.Add("@LenDate", SqlDbType.NChar, 10).Value = dtpLenDate.Text.Trim();

                if (tbWidth.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@Width", SqlDbType.NChar, 10).Value = tbWidth.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Width", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@WidInsp", SqlDbType.NChar, 10).Value = tbWidInsp.Text.Trim();
                cmd.Parameters.Add("@WidDate", SqlDbType.NChar, 10).Value = dtpWidDate.Text.Trim();

                if (cbSerialized.Checked == true)
                {
                    cmd.Parameters.Add("@Serialized", SqlDbType.Bit).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("@Serialized", SqlDbType.Bit).Value = 0;
                }

                cmd.Parameters.Add("@SerInsp", SqlDbType.NChar, 10).Value = tbWidInsp.Text.Trim();
                cmd.Parameters.Add("@SerDate", SqlDbType.NChar, 10).Value = dtpWidDate.Text.Trim();

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

        private void tbChamfer_TextChanged(object sender, EventArgs e)
        {
            //decimalChecker(box, max, min)
            g.decimalChecker(tbChamfer, 8M, 6M);
        }

        private void tbSurfaceRoughness_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbSurfaceRoughness, .5M, .1M);
        }

        private void tbLength_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbLength, 609.9M, 609.6M);
        }

        private void tbWidth_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbWidth, 429.9M, 429.6M);
        }

        private void tbChamferInsp_Leave(object sender, EventArgs e)
        {
            if (tbChamferInsp.Text.Length > 0)
            {
                tbSurfRufInsp.Text = tbChamferInsp.Text;
                tbLenInsp.Text = tbChamferInsp.Text;
                tbWidInsp.Text = tbChamferInsp.Text;
                tbSerInsp.Text = tbChamferInsp.Text;
            }
        }

        private void dtpChamferDate_Leave(object sender, EventArgs e)
        {
            dtpSurfRufDate.Value = dtpChamferDate.Value;
            dtpLenDate.Value = dtpChamferDate.Value;
            dtpWidDate.Value = dtpChamferDate.Value;
            dtpSerDate.Value = dtpChamferDate.Value;
        }
    }
}
