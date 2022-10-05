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
    public partial class F6_Clad_Phase_II : Form
    {
        SqlConnection cnxn;
        private decimal decimalResult;
        private int intResult;
        SqlCommand cmd;
        private double indexValue;
        
        public F6_Clad_Phase_II()
        {
            InitializeComponent();
        }

 
        private void F6_Clad_Phase_II_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("select " +
                 "convert(varchar, clp2claddate, 101) , " +
                 "clp2slabmfg, " +
                 "clp2reqepoxy, " +
                 "clp2cementbatchA, " +
                 "convert(varchar, clp2expirationA, 101) , " +
                 "clp2cementbatchB, " +
                 "convert(varchar, clp2expirationB, 101) , " +
                 "clp2diskstorage, " +
                 "clp2phacid, " +
                 "clp2phsilane, " +
                 "clp2cladroompartcount, " +
                 "clp2cladroomRH, " +
                 "clp2temp15CR, " +
                 "clp2temp30CR, " +
                 "clp2temp60CR, " +
                 "clp2temp15Refr, " +
                 "clp2temp30Refr, " +
                 "clp2temp60Refr, " +
                 "clp2temp15Index, " +
                 "clp2temp30Index, " +
                 "clp2temp60Index, " +
                 "clp2precurehardness, " +
                 "clp2postcurehardness " +
                 "from nif_amp_data where [part serial number] = " + g.serialNumber + " ", cnxn);

            DataTable table = new DataTable();

            da.Fill(table);

            if (table.Rows[0].ItemArray[0].ToString().Length > 0)
            {
                dtpCladDate.Text = table.Rows[0].ItemArray[0].ToString();
            }

            cbSlab.Text = table.Rows[0].ItemArray[1].ToString();
            cbEpoxy.Text = table.Rows[0].ItemArray[2].ToString();
            
            if (table.Rows[0].ItemArray[3].ToString().Trim() == "0")
            {
                tbCementA.Text = "";
            }
            else
            {
                tbCementA.Text = table.Rows[0].ItemArray[3].ToString();
            }

            if (table.Rows[0].ItemArray[4].ToString().Length > 0)
            {
                dtpExpirationA.Text = table.Rows[0].ItemArray[4].ToString();
            }
           
            if (table.Rows[0].ItemArray[5].ToString().Trim() == "0")
            {
                tbCementB.Text = "";
            }
            else
            {
                tbCementB.Text = table.Rows[0].ItemArray[5].ToString();
            }

            if (table.Rows[0].ItemArray[6].ToString().Length > 0)
            {
                dtpExpirationB.Text = table.Rows[0].ItemArray[6].ToString();
            }

            
            if (table.Rows[0].ItemArray[7].ToString().Trim() == "0")
            {
                tbDiskStorage.Text = "";
            }
            else
            {
                tbDiskStorage.Text = table.Rows[0].ItemArray[7].ToString();
            }
            
            if(table.Rows[0].ItemArray[8].ToString().Trim() == "0")
            {
                tbAcidEtch.Text = "";
            }
            else
            {
                tbAcidEtch.Text = table.Rows[0].ItemArray[8].ToString();
            }

            if (table.Rows[0].ItemArray[9].ToString().Trim() == "0")
            {
                tbSilane.Text = "";
            }
            else
            {
                tbSilane.Text = table.Rows[0].ItemArray[9].ToString();
            }

            tbParticleCount.Text = table.Rows[0].ItemArray[10].ToString();
            
            if (table.Rows[0].ItemArray[11].ToString().Trim() == "0")
            {
                tbHumidity.Text = "";
            }
            else
            {
                tbHumidity.Text = table.Rows[0].ItemArray[11].ToString();
            }

            if (table.Rows[0].ItemArray[12].ToString().Trim() == "0.0")
            {
                tbCRtemp15.Text = "";
            }
            else
            {
                tbCRtemp15.Text = table.Rows[0].ItemArray[12].ToString();
            }

            if (table.Rows[0].ItemArray[13].ToString().Trim() == "0.0")
            {
                tbCRtemp60.Text = "";
            }
            else
            {
                tbCRtemp60.Text = table.Rows[0].ItemArray[13].ToString();
            }

            if (table.Rows[0].ItemArray[14].ToString().Trim() == "0.0")
            {
                tbCRtemp90.Text = "";
            }
            else
            {
                tbCRtemp90.Text = table.Rows[0].ItemArray[14].ToString();
            }

            if (table.Rows[0].ItemArray[15].ToString().Trim() == "0.0")
            {
                tbRef15.Text = "";
            }
            else
            {
                tbRef15.Text = table.Rows[0].ItemArray[15].ToString();
            }

            if (table.Rows[0].ItemArray[16].ToString().Trim() == "0.0")
            {
                tbRef60.Text = "";
            }
            else
            {
                tbRef60.Text = table.Rows[0].ItemArray[16].ToString();
            }

            if (table.Rows[0].ItemArray[17].ToString().Trim() == "0.0")
            {
                tbRef90.Text = "";
            }
            else
            {
                tbRef90.Text = table.Rows[0].ItemArray[17].ToString();
            }

            if (table.Rows[0].ItemArray[18].ToString().Trim() == "0.0000")
            {
                tbIndex15.Text = "";
            }
            else
            {
                tbIndex15.Text = table.Rows[0].ItemArray[18].ToString();
            }

            if (table.Rows[0].ItemArray[19].ToString().Trim() == "0.0000")
            {
                tbIndex60.Text = "";
            }
            else
            {
                tbIndex60.Text = table.Rows[0].ItemArray[19].ToString();
            }

            if (table.Rows[0].ItemArray[20].ToString().Trim() == "0.0000")
            {
                tbIndex90.Text = "";
            }
            else
            {
                tbIndex90.Text = table.Rows[0].ItemArray[20].ToString();
            }

            if (table.Rows[0].ItemArray[21].ToString().Trim() == "0")
            {
                tbPrecure.Text = "";
            }
            else
            {
                tbPrecure.Text = table.Rows[0].ItemArray[21].ToString();
            }

            if (table.Rows[0].ItemArray[22].ToString().Trim() == "0")
            {
                tbPostcure.Text = "";
            }
            else
            {
                tbPostcure.Text = table.Rows[0].ItemArray[22].ToString();
            }
            
        }

        private void tbAcidEtch_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbAcidEtch, 3.1M, 2.5M);
        }

        private void tbSilane_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbSilane, 4.5M, 3.5M);
        }

        private void tbParticleCount_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbParticleCount, 100, 0);
        }

        private void tbHumidity_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbHumidity, 45, 0);
        }

 
        private void tbCRtemp15_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbCRtemp15, 76, 68);
        }

        private void tbCRtemp30_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbCRtemp60, 76, 68);
        }

        private void tbCRtemp60_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbCRtemp90, 76, 68);
        }

        private void tbRef15_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbRef15, 76, 68);
        }

        private void tbRef30_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbRef60, 76, 68);
        }

        private void tbRef60_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbRef90, 76, 68);
        }

        private void tbIndex15_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbIndex15, 2, 0);
        }

        private void tbIndex30_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbIndex60, 2, 0);
        }

        private void tbIndex60_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbIndex90, 2, 0);
        }

        private void tbPrecure_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbPrecure, 100, 35);
        }

        private void tbPostcure_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbPostcure, 73, 63);
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
                    MessageBox.Show("Invalid Number");
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

        private void entryChecker(TextBox box, string parameter)
        {

            if (box.Text.Trim().Length > 0)
            {
                cmd.Parameters.Add(parameter, SqlDbType.NChar, 10).Value = box.Text.Trim();
            }
            else
            {
                cmd.Parameters.Add(parameter, SqlDbType.NChar, 10).Value = "0";
            }
        }

        private void dateCheck(TextBox box, string parameter)
        {
            if (box.Text.Trim().Length > 0)
            {
                cmd.Parameters.Add(parameter, SqlDbType.NChar, 10).Value = box.Text.Trim();
            }
            else
            {
                cmd.Parameters.Add(parameter, SqlDbType.Date).Value = "01/01/1900";
            }
        }

        private void indexMin(double time, double refractTemp)
        {
            if (cbEpoxy.Text.Trim() == "1")
            {
                indexValue = ((1.49422 + 0.00002198 * time - 0.00000001304 * time * time)
                    - 0.0003 * ((refractTemp - 32) * 5 / 9 - 20) - 0.002);
            }

            if (cbEpoxy.Text.Trim() == "2.5")
            {
                indexValue = ((1.4807 + 0.000016772 * time - 0.00000002956 * time * time)
                    - 0.0003 * ((refractTemp - 32) * 5 / 9 - 20) - 0.002);
            }
        }

        private void indexMax(double time, double refractTemp)
        {
            if (cbEpoxy.Text.Trim() == "1")
            {
                indexValue = ((1.49422 + 0.00002198 * time - 0.00000001304 * time * time)
                    - 0.0003 * ((refractTemp - 32) * 5 / 9 - 20) + 0.002);
            }

            if (cbEpoxy.Text.Trim() == "2.5")
            {
                indexValue = ((1.4807 + 0.000016772 * time - 0.00000002956 * time * time)
                    - 0.0003 * ((refractTemp - 32) * 5 / 9 - 20) + 0.002);
            }


        }
        private void bEnterData_Click(object sender, EventArgs e)
        {
            try
            {
                cnxn = new SqlConnection(g.db);
                cmd = new SqlCommand
                    ("Update NIF_AMP_Data " +
                     "set " +
                     "clp2claddate = @claddate, " +
                     "clp2slabmfg = @slabmfg, " +
                     "clp2reqepoxy = @epoxy, " +
                     "clp2cementbatchA = @cementA, " +
                     "clp2expirationA = @expirationA, " +
                     "clp2cementbatchB = @cementB, " +
                     "clp2expirationB =  @expirationB, " +
                     "clp2diskstorage = @disk, " +
                     "clp2phacid = @acid, " +
                     "clp2phsilane = @silane, " +
                     "clp2cladroompartcount = @part, " +
                     "clp2cladroomRH = @rh, " +
                     "clp2temp15CR = @15cr, " +
                     "clp2temp30CR = @30cr, " +
                     "clp2temp60CR = @60cr, " +
                     "clp2temp15Refr = @15refr, " +
                     "clp2temp30Refr = @30refr, " +
                     "clp2temp60Refr = @60refr, " +
                     "clp2temp15Index = @15index, " +
                     "clp2temp30Index = @30index, " +
                     "clp2temp60Index = @60index, " +
                     "clp2precurehardness = @pre, " +
                     "clp2postcurehardness = @post " +
                     "where [part serial number] = " + g.serialNumber + " ", cnxn);


                cmd.Parameters.Add("@slabmfg", SqlDbType.NChar, 10).Value = cbSlab.Text.Trim();
                cmd.Parameters.Add("@epoxy", SqlDbType.NChar, 10).Value = cbEpoxy.Text.Trim();
                entryChecker(tbCementA, "@cementA");
                entryChecker(tbCementB, "@cementB");
                entryChecker(tbDiskStorage, "@disk");
                entryChecker(tbAcidEtch, "@acid");
                entryChecker(tbSilane, "@silane");
                entryChecker(tbParticleCount, "@part");
                entryChecker(tbHumidity, "@rh");
                entryChecker(tbCRtemp15, "@15cr");
                entryChecker(tbCRtemp60, "@30cr");
                entryChecker(tbCRtemp90, "@60cr");
                entryChecker(tbRef15, "@15refr");
                entryChecker(tbRef60, "@30refr");
                entryChecker(tbRef90, "@60refr");
                entryChecker(tbIndex15, "@15index");
                entryChecker(tbIndex60, "@30index");
                entryChecker(tbIndex90, "@60index");
                entryChecker(tbPrecure, "@pre");
                entryChecker(tbPostcure, "@post");

                cmd.Parameters.Add("@CladDate", SqlDbType.Date).Value = dtpCladDate.Value;
                cmd.Parameters.Add("@ExpirationA", SqlDbType.Date).Value = dtpExpirationA.Value;
                cmd.Parameters.Add("@ExpirationB", SqlDbType.Date).Value = dtpExpirationB.Value;

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

        private void bCalculate_Click(object sender, EventArgs e)
        {
            if (tbRef15.Text.Length > 0 & cbEpoxy.Text.Length > 0)
            {
                indexMin(15, Convert.ToDouble(tbRef15.Text.ToString().Trim()));
                LImin15.Text = indexValue.ToString().Substring(0, 7);
                indexMax(15, Convert.ToDouble(tbRef15.Text.ToString().Trim()));
                LImax15.Text = indexValue.ToString().Substring(0, 7);
                if (tbIndex15.Text.Length > 0)
                {
                    if (Convert.ToDouble(LImin15.Text) <= Convert.ToDouble(
                        tbIndex15.Text.ToString().Trim()) & 
                        (Convert.ToDouble(tbIndex15.Text.ToString().Trim()) <=
                        Convert.ToDouble(LImax15.Text)))
                    {
                        L15pf.Text = "PASS";
                    }
                    else
                    {
                        L15pf.Text = "FAIL";
                    }
                }
            }

            if (tbRef60.Text.Length > 0 & cbEpoxy.Text.Length > 0)
            {
                indexMin(60, Convert.ToDouble(tbRef60.Text.ToString().Trim()));
                LImin60.Text = indexValue.ToString().Substring(0, 7);
                indexMax(60, Convert.ToDouble(tbRef60.Text.ToString().Trim()));
                LImax60.Text = indexValue.ToString().Substring(0, 7);
                if (tbIndex60.Text.Length > 0)
                {
                    if (Convert.ToDouble(LImin60.Text) <= Convert.ToDouble(
                        tbIndex60.Text.ToString().Trim()) &
                        (Convert.ToDouble(tbIndex60.Text.ToString().Trim()) <=
                        Convert.ToDouble(LImax60.Text)))
                    {
                        L60pf.Text = "PASS";
                    }
                    else
                    {
                        L60pf.Text = "FAIL";
                    }
                }
            }
            if (tbRef90.Text.Length > 0 & cbEpoxy.Text.Length > 0)
            {
                indexMin(90, Convert.ToDouble(tbRef90.Text.ToString().Trim()));
                LImin90.Text = indexValue.ToString().Substring(0, 7);
                indexMax(90, Convert.ToDouble(tbRef90.Text.ToString().Trim()));
                LImax90.Text = indexValue.ToString().Substring(0, 7);
                if (tbIndex90.Text.Length > 0)
                {
                    if (Convert.ToDouble(LImin90.Text) <= Convert.ToDouble(
                        tbIndex90.Text.ToString().Trim()) &
                        (Convert.ToDouble(tbIndex90.Text.ToString().Trim()) <=
                        Convert.ToDouble(LImax90.Text)))
                    {
                        L90pf.Text = "PASS";
                    }
                    else
                    {
                        L90pf.Text = "FAIL";
                    }
                }
            }

            
        }

        private void bDurometer_Click(object sender, EventArgs e)
        {
            if (tbPrecure.Text.ToString().Trim().Length > 0)
            {
                if (35 <= Convert.ToInt32(
                       tbPrecure.Text.ToString().Trim()) &
                       (Convert.ToInt32(tbPrecure.Text.ToString().Trim()) <= 100))
                {
                    LprecurePF.Text = "PASS";
                }
                else
                {
                    LprecurePF.Text = "FAIL";
                }
            }

            if (tbPostcure.Text.ToString().Trim().Length > 0)
            {
                if (63 <= Convert.ToInt32(
                       tbPostcure.Text.ToString().Trim()) &
                       (Convert.ToInt32(tbPostcure.Text.ToString().Trim()) <= 73))
                {
                    LpostcurePF.Text = "PASS";
                }
                else
                {
                    LpostcurePF.Text = "FAIL";
                }
            }
        }

        private void tbCladDate_TextChanged(object sender, EventArgs e)
        {
            if (dtpCladDate.Text.Trim() == "01/01/1900")
            {
                dtpCladDate.BackColor = Color.FromArgb(200, 0, 0);
            }
            else
            {
                dtpCladDate.BackColor = Color.FromArgb(0, 200, 0);
            }
        }

        private void tbExpirationA_TextChanged(object sender, EventArgs e)
        {
            if (dtpExpirationA.Text.Trim() == "01/01/1900")
            {
                dtpExpirationA.BackColor = Color.FromArgb(200, 0, 0);
            }
            else
            {
                dtpExpirationA.BackColor = Color.FromArgb(0, 200, 0);
            }
        }

        private void tbExpirationB_TextChanged(object sender, EventArgs e)
        {
            if (dtpExpirationB.Text.Trim() == "01/01/1900")
            {
                dtpExpirationB.BackColor = Color.FromArgb(200, 0, 0);
            }
            else
            {
                dtpExpirationB.BackColor = Color.FromArgb(0, 200, 0);
            }
        }

        


    }
}
