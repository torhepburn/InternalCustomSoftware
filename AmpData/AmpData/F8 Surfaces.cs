using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AmpData
{
    public partial class F8_Surfaces : Form
    {
        SqlConnection cnxn;
        
        public F8_Surfaces()
        {
            InitializeComponent();
        }

        private void F8_Surfaces_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("select " +
                 "FilteredPV , " +
                 "FPVinsp, " +
                 "convert(varchar,fpvdate, 101), " +
                 "rmspgrad , " +
                 "rmspginsp, " +
                 "convert(varchar,rmspgdate, 101), " +
                 "rmspband , " +
                 "rmspbandinsp, " +
                 "convert(varchar,rmspbanddate, 101), " +
                 "rmspbandworst , " +
                 "rmspbandworstinsp, " +
                 "convert(varchar,rmspbandworstdate, 101), " +
                 "Ratio, " +
                 "ratioinsp, " +
                 "convert(varchar, ratiodate, 101) " +
                 "from nif_amp_data where [part serial number] = " + g.serialNumber + " ", cnxn);

            DataTable table = new DataTable();

            da.Fill(table);

            tbFPV.Text = table.Rows[0].ItemArray[0].ToString();
            tbFPBinsp.Text = table.Rows[0].ItemArray[1].ToString();
            if (table.Rows[0].ItemArray[2].ToString().Length > 0)
            {
                dtpFPVdate.Text = table.Rows[0].ItemArray[2].ToString();
            }
            
            tbRMSpg.Text = table.Rows[0].ItemArray[3].ToString();
            tbRMSpgInsp.Text = table.Rows[0].ItemArray[4].ToString();
            if (table.Rows[0].ItemArray[5].ToString().Length > 0)
            {
                dtpRMSpgDate.Text = table.Rows[0].ItemArray[5].ToString();
            }
            
            tbRMSpBand.Text = table.Rows[0].ItemArray[6].ToString();
            tbRMSpbInsp.Text = table.Rows[0].ItemArray[7].ToString();
            if (table.Rows[0].ItemArray[8].ToString().Length > 0)
            {
                dtpRMSpbDate.Text = table.Rows[0].ItemArray[8].ToString();
            }
            
            tbRMSworst.Text = table.Rows[0].ItemArray[9].ToString();
            tbRMSworstInsp.Text = table.Rows[0].ItemArray[10].ToString();
            if (table.Rows[0].ItemArray[11].ToString().Length > 0)
            {
                dtpRMSworstDate.Text = table.Rows[0].ItemArray[11].ToString();
            }

            if (table.Rows[0].ItemArray[12].ToString().Length > 0)
            { 
                Decimal RatioS = Convert.ToDecimal(table.Rows[0].ItemArray[12].ToString());
                RatioS = RatioS * 100;
                tbRatio.Text = RatioS.ToString();
            }   
            
            tbRatioInsp.Text = table.Rows[0].ItemArray[13].ToString();
            if (table.Rows[0].ItemArray[14].ToString().Length > 0)
            {
                dtpRatioDate.Text = table.Rows[0].ItemArray[14].ToString();
            }
        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            try
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                    ("Update NIF_AMP_Data set " +
                     "FilteredPV = @PV, " +
                     "FPVinsp = @PVinsp, " +
                     "fpvdate = @PVdate, " +
                     "rmspgrad = @PG, " +
                     "rmspginsp = @PGinsp, " +
                     "rmspgdate = @PGdate, " +
                     "rmspband = @Band, " +
                     "rmspbandinsp = @Bandinsp, " +
                     "rmspbanddate = @Banddate, " +
                     "rmspbandworst = @Worst, " +
                     "rmspbandworstinsp = @Worstinsp, " +
                     "rmspbandworstdate = @Worstdate, " +
                     "Ratio = @Ratio, " +
                     "ratioinsp = @Ratioinsp, " +
                     "ratiodate = @Ratiodate " +
                     "where [part serial number] = " + g.serialNumber + " ", cnxn);
                  
                if (tbFPV.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@PV", SqlDbType.NChar, 10).Value = tbFPV.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@PV", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@PVinsp", SqlDbType.NChar, 10).Value = tbFPBinsp.Text.Trim();
                cmd.Parameters.Add("@PVdate", SqlDbType.NChar, 10).Value = dtpFPVdate.Text.Trim();

                if (tbRMSpg.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@PG", SqlDbType.NChar, 10).Value = tbRMSpg.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@PG", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@PGinsp", SqlDbType.NChar, 10).Value = tbRMSpgInsp.Text.Trim();
                cmd.Parameters.Add("@PGdate", SqlDbType.NChar, 10).Value = dtpRMSpgDate.Text.Trim();

                if (tbRMSpBand.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@Band", SqlDbType.NChar, 10).Value = tbRMSpBand.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Band", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@Bandinsp", SqlDbType.NChar, 10).Value = tbRMSpbInsp.Text.Trim();
                cmd.Parameters.Add("@Banddate", SqlDbType.NChar, 10).Value = dtpRMSpbDate.Text.Trim();

                if (tbRMSworst.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@Worst", SqlDbType.NChar, 10).Value = tbRMSworst.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Worst", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@Worstinsp", SqlDbType.NChar, 10).Value = tbRMSworstInsp.Text.Trim();
                cmd.Parameters.Add("@Worstdate", SqlDbType.NChar, 10).Value = dtpRMSworstDate.Text.Trim();

                if (tbRatio.Text.Trim().Length > 0)
                {
                    decimal ratio = Convert.ToDecimal(tbRatio.Text.ToString().Trim());
                    ratio = ratio / 100;
                    cmd.Parameters.Add("@Ratio", SqlDbType.NChar, 10).Value = ratio;
                }
                else
                {
                    cmd.Parameters.Add("@Ratio", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@Ratioinsp", SqlDbType.NChar, 10).Value = tbRatioInsp.Text.Trim();
                cmd.Parameters.Add("@Ratiodate", SqlDbType.NChar, 10).Value = dtpRatioDate.Text.Trim();

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

        
        private void tbFPV_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbFPV, 0.3333M, 0.0003M);
        }

        private void tbRMSpg_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbRMSpg, 0.01111M, 0.00011M);
        }

        private void tbRMSpBand_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbRMSpBand, 1.8M, 0M);
        }

        private void tbRMSworst_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbRMSworst, 3.6M, 0M);
        }

        private void tbRatio_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbRatio, 100M, 0M);
        }



        private void decimalChecker(TextBox box, decimal max, decimal min)
        {
            string a = box.Text.Trim();
            if (a != "")
            {
                bool isNum;
                decimal result;
                isNum = Decimal.TryParse(box.Text, out result);
                if (isNum == false)
                {
                    MessageBox.Show("Invalid Number \r\n  \r\nMust enter 0 first for a decimal");
                    box.Text = "";
                    box.Focus();
                    return;
                }

                if (max >= Convert.ToDecimal(box.Text) & min <= Convert.ToDecimal(box.Text))
                {
                    box.BackColor = Color.FromArgb(0, 200, 0);
                }
                else
                {
                    box.BackColor = Color.FromArgb(200, 0, 0);
                }
            }
        }

        private void tbFPBinsp_Leave(object sender, EventArgs e)
        {
            if (tbFPBinsp.Text.Length > 0)
            {
                tbRMSpgInsp.Text = tbFPBinsp.Text;
                tbRMSpbInsp.Text = tbFPBinsp.Text;
                tbRMSworstInsp.Text = tbFPBinsp.Text;
                tbRatioInsp.Text = tbFPBinsp.Text;
            }
        }

        private void dtpFPVdate_Leave(object sender, EventArgs e)
        {
            dtpRMSpgDate.Value = dtpFPVdate.Value;
            dtpRMSpbDate.Value = dtpFPVdate.Value;
            dtpRMSworstDate.Value = dtpFPVdate.Value;
            dtpRatioDate.Value = dtpFPVdate.Value;
        }
    }
}
