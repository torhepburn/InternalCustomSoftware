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
    public partial class F3_MSI_Phase_I : Form
    {
        SqlConnection cnxn;
        private string p1PF;
        
        public F3_MSI_Phase_I()
        {
            InitializeComponent();
        }

        private void F3_MSI_Phase_I_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("select " +
                 "p1Length , " +
                 "p1leninsp, " +
                 "convert(varchar,p1lendate, 101), " +
                 "p1surfaceroughness, " +
                 "p1surrufinsp, " +
                 "convert(varchar, p1surrufdate, 101) " +
                 "from nif_amp_data where [part serial number] = " + g.serialNumber + " ", cnxn);

            DataTable table = new DataTable();

            da.Fill(table);

            tbLength.Text = table.Rows[0].ItemArray[0].ToString();
            tbLenInsp.Text = table.Rows[0].ItemArray[1].ToString();

            if (table.Rows[0].ItemArray[2].ToString().Length > 0)
            {
                dtpLenDate.Text = table.Rows[0].ItemArray[2].ToString();
            }
            
            tbSurRuf.Text = table.Rows[0].ItemArray[3].ToString();
            tbSurRufInsp.Text = table.Rows[0].ItemArray[4].ToString();

            if (table.Rows[0].ItemArray[5].ToString().Length > 0)
            {
                dtpSurRufDate.Text = table.Rows[0].ItemArray[5].ToString();
            }

        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            if (tbLength.BackColor.G == 200 & tbSurRuf.BackColor.G == 200)
            {
                p1PF = "PASS";
            }
            else
            {
                p1PF = "FAIL";
                MessageBox.Show("This step does not PASS !");
            }
            
            try
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                    ("Update NIF_AMP_Data " +
                     "set p1Length = @Length, " +
                     "p1leninsp = @LenInsp, " +
                     "p1lendate = @LenDate, " +
                     "p1surfaceroughness = @Surruf, " +
                     "p1surrufinsp = @SurRufInsp, " +
                     "p1surrufdate = @SurRufDate, " +
                     "p1pf = '" + p1PF  + "' " +
                     "where [part serial number] = " + g.serialNumber + " ", cnxn);

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

                if (tbSurRuf.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@Surruf", SqlDbType.NChar, 10).Value = tbSurRuf.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Surruf", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@SurrufInsp", SqlDbType.NChar, 10).Value = tbSurRufInsp.Text.Trim();
                cmd.Parameters.Add("@SurrufDate", SqlDbType.NChar, 10).Value = dtpSurRufDate.Text.Trim();

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

        
        private void tbLength_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbLength, 785.35M, 784.95M);
        }

        private void tbSurRuf_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbSurRuf, .5M, 0);
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

        private void tbLenInsp_Leave(object sender, EventArgs e)
        {
            if (tbLenInsp.Text.Length > 0)
            {
                tbSurRufInsp.Text = tbLenInsp.Text;
            }
        }

        private void dtpLenDate_Leave(object sender, EventArgs e)
        {
            dtpSurRufDate.Value = dtpLenDate.Value;
        }

    }

}
