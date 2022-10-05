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
    public partial class F12_Op80 : Form
    {
        SqlConnection cnxn;
        private string op80PF;

        public F12_Op80()
        {
            InitializeComponent();
        }

        private void F12_Op80_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("select " +
                 " op80Power " +
                 ",op80PowerInsp " +
                 ",convert(varchar,op80PowerDate, 101) " +
                 ",op80Concave " +
                 ",op80ConcaveInsp " +
                 ",convert(varchar,op80Concavedate, 101) " +
                 ",op80EngineeringSignoff " +
                 ",op80EngineeringSignoffInsp " +
                 ",convert(varchar,op80EngineeringSignoffDate, 101) " +
                 ",op80Wedge " +
                 ",op80WedgeInsp " +
                 ",convert(varchar,op80Wedgedate, 101) " +
                 ",op80InCavityRDate " +
                 ",op80InCavityRTime " +
                 ",op80InCavityInsp " +
                 ",convert(varchar,op80InCavityDate, 101) " +
                 ",op80Flatness " +
                 ",op80FlatnessInsp " +
                 ",convert(varchar,op80FlatnessDate, 101) " +
                 ",op80FinalRDate " +
                 ",op80FinalRTime " +
                 ",op80FinalInsp " +
                 ",convert(varchar,op80FinalDate, 101) " +
                 ",op80Supervisor " +
                 ",convert(varchar,op80SupervisorDate, 101) " +
                 "from CEA_RMAX_MIRROR_TAB_A where [part serial number] = " + g.serialNumber + " ", cnxn);

            DataTable table = new DataTable();

            da.Fill(table);

            tbPower.Text = table.Rows[0][0].ToString();
            tbPowerInsp.Text = table.Rows[0][1].ToString();

            if (table.Rows[0][2].ToString().Length > 0)
            {
                dtpPowerDate.Text = table.Rows[0][2].ToString();
            }

            if (table.Rows[0][3].Equals(true))
            {
                cbConcave.Checked = true;
                tbEngSignoff.Text = table.Rows[0][6].ToString();
                tbEngSignoffInsp.Text = table.Rows[0][7].ToString();

                if (table.Rows[0][8].ToString().Length > 0)
                {
                    dtpEngSignoffDate.Text = table.Rows[0][8].ToString();
                }
            }
            else
            {
                cbConcave.Checked = true;
                cbConcave.Checked = false;
            }

            tbConcaveInsp.Text = table.Rows[0][4].ToString();

            if (table.Rows[0][5].ToString().Length > 0)
            {
                dtpConcaveDate.Text = table.Rows[0][5].ToString();
            }

            tbWedge.Text = table.Rows[0][9].ToString();
            tbWedgeInsp.Text = table.Rows[0][10].ToString();

            if (table.Rows[0][11].ToString().Length > 0)
            {
                dtpWedgeDate.Text = table.Rows[0][11].ToString();
            }

            if (table.Rows[0][12].ToString().Length > 0)
            {
                dtpRDate.Text = table.Rows[0][12].ToString();
            }

            if (table.Rows[0][13].ToString().Length > 0)
            {
                dtpRTime.Text = table.Rows[0][13].ToString();
            }

            tbInInsp.Text = table.Rows[0][14].ToString();

            if (table.Rows[0][15].ToString().Length > 0)
            {
                dtpInDate.Text = table.Rows[0][15].ToString();
            }

            tbFlatness.Text = table.Rows[0][16].ToString();
            tbFlatnessInsp.Text = table.Rows[0][17].ToString();

            if (table.Rows[0][18].ToString().Length > 0)
            {
                dtpFlatnessDate.Text = table.Rows[0][18].ToString();
            }

            if (table.Rows[0][19].ToString().Length > 0)
            {
                dtpFDate.Text = table.Rows[0][19].ToString();
            }

            if (table.Rows[0][20].ToString().Length > 0)
            {
                dtpFTime.Text = table.Rows[0][20].ToString();
            }

            tbFinalInsp.Text = table.Rows[0][21].ToString();

            if (table.Rows[0][22].ToString().Length > 0)
            {
                dtpFinalDate.Text = table.Rows[0][22].ToString();
            }

            tbSupervisor.Text = table.Rows[0][23].ToString();
            

            if (table.Rows[0][24].ToString().Length > 0)
            {
                dtpSupervisorDate.Text = table.Rows[0][24].ToString();
            }
        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            if (tbPower.BackColor.G == 200 &
                tbEngSignoff.BackColor.G == 200 &
                tbWedge.BackColor.G == 200 & 
                tbFlatness.BackColor.G == 200 &
                tbSupervisor.BackColor.G == 200 &
                dtpInDate.Text != "01/01/1900" &
                dtpFDate.Text != "01/01/1900")
            {
                op80PF = "PASS";
            }
            else
            {
                op80PF = "FAIL";
                MessageBox.Show("This step does not PASS !");
            }

            try
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                    ("Update CEA_RMAX_MIRROR_TAB_A set " +
                     "  op80Power = @power" +
                     " ,op80PowerInsp = @PowerInsp " +
                     " ,op80PowerDate = @PowerDate " +
                     " ,op80Concave = @Concave " +
                     " ,op80ConcaveInsp = @ConcaveInsp " +
                     " ,op80ConcaveDate = @ConcaveDate " +
                     " ,op80EngineeringSignoff = @EngSignoff " +
                     " ,op80EngineeringSignoffInsp = @EngSignoffInsp " +
                     " ,op80EngineeringSignoffDate = @EngSignoffDate " +
                     " ,op80Wedge = @Wedge " +
                     " ,op80wedgeinsp = @WedgeInsp " +
                     " ,op80wedgedate = @WedgeDate " +
                     " ,op80InCavityRDate = @InCavRDate " +
                     " ,op80InCavityRTime = @InCavRTime " +
                     " ,op80InCavityInsp = @InCavInsp " +
                     " ,op80InCavityDate = @InCavDate " +
                     " ,op80Flatness = @Flatness" +
                     " ,op80FlatnessInsp = @FlatnessInsp " +
                     " ,op80FlatnessDate = @FlatnessDate " +
                     " ,op80FinalRDate = @FinalRDate " +
                     " ,op80FinalRTime = @FinalRTime " +
                     " ,op80FinalInsp = @FinalInsp " +
                     " ,op80FinalDate = @FinalDate " +
                     " ,op80Supervisor = @Supervisor " +
                     " ,op80SupervisorDate = @SupervisorDate " +
                     " ,op80pf = '" + op80PF + "' " +
                     "  where [part serial number] = " + g.serialNumber + " ", cnxn);


                if (tbPower.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@power", SqlDbType.NChar, 10).Value = tbPower.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@power", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@PowerInsp", SqlDbType.NChar, 10).Value = tbPowerInsp.Text.Trim();
                cmd.Parameters.Add("@PowerDate", SqlDbType.NChar, 10).Value = dtpPowerDate.Text.Trim();

                if (cbConcave.Checked == true)
                {
                    cmd.Parameters.Add("@Concave", SqlDbType.Bit).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("@Concave", SqlDbType.Bit).Value = 0;
                }

                cmd.Parameters.Add("@ConcaveInsp", SqlDbType.NChar, 10).Value = tbConcaveInsp.Text.Trim();
                cmd.Parameters.Add("@ConcaveDate", SqlDbType.NChar, 10).Value = dtpConcaveDate.Text.Trim();


                if (cbConcave.Checked == true)
                {
                    cmd.Parameters.Add("@EngSignoff", SqlDbType.NChar, 10).Value = tbEngSignoff.Text.Trim();
                    cmd.Parameters.Add("@EngSignoffInsp", SqlDbType.NChar, 10).Value = tbEngSignoffInsp.Text.Trim();
                    cmd.Parameters.Add("@EngSignoffDate", SqlDbType.NChar, 10).Value = dtpEngSignoffDate.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@EngSignoff", SqlDbType.NChar, 10).Value = "";
                    cmd.Parameters.Add("@EngSignoffInsp", SqlDbType.NChar, 10).Value = "";
                    cmd.Parameters.Add("@EngSignoffDate", SqlDbType.NChar, 10).Value = "1900-01-01";
                }

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


                cmd.Parameters.Add("@InCavRDate", SqlDbType.NChar, 10).Value = dtpRDate.Text.Trim();
                cmd.Parameters.Add("@InCavRTime", SqlDbType.NChar, 10).Value = dtpRTime.Text.Trim();
                cmd.Parameters.Add("@InCavInsp", SqlDbType.NChar, 10).Value = tbInInsp.Text.Trim();
                cmd.Parameters.Add("@InCavDate", SqlDbType.NChar, 10).Value = dtpInDate.Text.Trim();

                if (tbFlatness.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@Flatness", SqlDbType.NChar, 10).Value = tbFlatness.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Flatness", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@FlatnessInsp", SqlDbType.NChar, 10).Value = tbFlatnessInsp.Text.Trim();
                cmd.Parameters.Add("@FlatnessDate", SqlDbType.NChar, 10).Value = dtpFlatnessDate.Text.Trim();


                cmd.Parameters.Add("@FinalRDate", SqlDbType.NChar, 10).Value = dtpFDate.Text.Trim();
                cmd.Parameters.Add("@FinalRTime", SqlDbType.NChar, 10).Value = dtpFTime.Text.Trim();
                cmd.Parameters.Add("@FinalInsp", SqlDbType.NChar, 10).Value = tbFinalInsp.Text.Trim();
                cmd.Parameters.Add("@FinalDate", SqlDbType.NChar, 10).Value = dtpFinalDate.Text.Trim();


                if (tbSupervisor.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@Supervisor", SqlDbType.NChar, 10).Value = tbSupervisor.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Supervisor", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@SupervisorDate", SqlDbType.NChar, 10).Value = dtpSupervisorDate.Text.Trim();

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

        private void tbPower_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbPower, 1000M, 0M);
        }

        private void cbConcave_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConcave.Checked == true)
            {
                tbEngSignoff.Text = "";
                tbEngSignoffInsp.Text = "";
                dtpEngSignoffDate.Text = "1900-01-01";
                tbEngSignoff.BackColor = Color.FromArgb(0, 200, 0);
            }
            else
            {
                if (tbEngSignoff.Text.Trim().Length > 1)
                {
                    tbEngSignoff.BackColor = Color.FromArgb(0, 200, 0);
                }
                else
                {
                    tbEngSignoff.BackColor = Color.FromArgb(200, 0, 0);
                }
            }
        }

        private void tbEngSignoff_TextChanged(object sender, EventArgs e)
        {
            if (cbConcave.Checked == false)
            {
                if (tbEngSignoff.Text.Trim().Length > 1)
                {
                    tbEngSignoff.BackColor = Color.FromArgb(0, 200, 0);
                }
                else
                {
                    tbEngSignoff.BackColor = Color.FromArgb(200, 0, 0);
                }
            }
            else
            {
                tbEngSignoff.BackColor = Color.FromArgb(0, 200, 0);
            }
        }  

        private void tbWedge_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbWedge, 1.250M, 0M);
        }

        private void dtpRDate_ValueChanged(object sender, EventArgs e)
        {
            tbInInsp.BackColor = Color.FromArgb(0, 200, 0);
        }

        private void tbFlatness_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbFlatness, 2, 0);
        }


        private void dtpFDate_ValueChanged(object sender, EventArgs e)
        {
            tbFinalInsp.BackColor = Color.FromArgb(0, 200, 0);
        }

        private void tbSupervisor_TextChanged(object sender, EventArgs e)
        {
            if (tbSupervisor.Text.Length > 1)
            {
                tbSupervisor.BackColor = Color.FromArgb(0, 200, 0);
            }
            else
            {
                tbSupervisor.BackColor = Color.FromArgb(200, 0, 0);
            }
        }

        private void tbPowerInsp_Leave(object sender, EventArgs e)
        {
            tbConcaveInsp.Text = tbPowerInsp.Text;
            tbWedgeInsp.Text = tbPowerInsp.Text;
            tbInInsp.Text = tbPowerInsp.Text;
            tbFlatnessInsp.Text = tbPowerInsp.Text;
            tbFinalInsp.Text = tbPowerInsp.Text;
            if (cbConcave.Checked == false)
            {
                tbEngSignoffInsp.Text = tbPowerInsp.Text;
            }
        }

        private void dtpPowerDate_Leave(object sender, EventArgs e)
        {
            dtpConcaveDate.Value = dtpPowerDate.Value;
            dtpWedgeDate.Value = dtpPowerDate.Value;
            dtpInDate.Value = dtpPowerDate.Value;
            dtpFlatnessDate.Value = dtpPowerDate.Value;
            dtpFinalDate.Value = dtpPowerDate.Value;
            if (cbConcave.Checked == false)
            {
                dtpEngSignoffDate.Value = dtpPowerDate.Value;
            }
        }

    }
}
