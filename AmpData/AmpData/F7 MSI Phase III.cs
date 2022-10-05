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
    public partial class F7_MSI_Phase_III : Form
    {
        SqlConnection cnxn;
        
        public F7_MSI_Phase_III()
        {
            InitializeComponent();
        }

        private void F7_MSI_Phase_III_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("select " +
                 "p3Length , " +
                 "p3leninsp, " +
                 "convert(varchar,p3lendate, 101), " +
                 "p3width , " +
                 "p3widinsp, " +
                 "convert(varchar,p3widdate, 101) " +
                 "from nif_amp_data where [part serial number] = " + g.serialNumber + " ", cnxn);

            DataTable table = new DataTable();

            da.Fill(table);

            tbLength.Text = table.Rows[0].ItemArray[0].ToString();
            tbLenInsp.Text = table.Rows[0].ItemArray[1].ToString();
            if (table.Rows[0].ItemArray[2].ToString().Length > 0)
            {
                dtpLenDate.Text = table.Rows[0].ItemArray[2].ToString();
            }

            tbWidth.Text = table.Rows[0].ItemArray[3].ToString();
            tbWidInsp.Text = table.Rows[0].ItemArray[4].ToString();
            if (table.Rows[0].ItemArray[5].ToString().Length > 0)
            {
                dtpWidDate.Text = table.Rows[0].ItemArray[5].ToString();
            }
        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            try
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                    ("Update NIF_AMP_Data set " +
                     "p3Length = @Length, " +
                     "p3leninsp = @LenInsp, " +
                     "p3lendate = @LenDate, " +
                     "p3width = @Width, " +
                     "p3widinsp = @WidInsp, " +
                     "p3widdate = @WidDate " +
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
            decimalChecker(tbLength, 808.2M, 807.8M);
        }

        private void tbWidth_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbWidth, 457.7M, 457.3M);
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
                tbWidInsp.Text = tbLenInsp.Text;
            }
        }

        private void dtpLenDate_Leave(object sender, EventArgs e)
        {
            dtpWidDate.Value = dtpLenDate.Value;
        }
    }
}
