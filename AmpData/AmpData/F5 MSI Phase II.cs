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
    public partial class F5_MSI_Phase_II : Form
    {
        SqlConnection cnxn;
        
        public F5_MSI_Phase_II()
        {
            InitializeComponent();
        }

        private void F5_MSI_Phase_II_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("select " +
                 "p2Width , " +
                 "p2widinsp, " +
                 "p2widdate, " +
                 "p2surfaceroughness, " +
                 "p2surrufinsp, " +
                 "p2surrufdate " +
                 "from nif_amp_data where [part serial number] = " + g.serialNumber + " ", cnxn);

            DataTable table = new DataTable();

            da.Fill(table);

            tbWidth.Text = table.Rows[0].ItemArray[0].ToString();
            tbWidInsp.Text = table.Rows[0].ItemArray[1].ToString();
            if (table.Rows[0].ItemArray[2].ToString().Length > 0)
            {
                dtpWidDate.Text = table.Rows[0].ItemArray[2].ToString();
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
            try
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                    ("Update NIF_AMP_Data " +
                     "set p2width = @Width, " +
                     "p2widinsp = @WidInsp, " +
                     "p2widdate = @WidDate, " +
                     "p2surfaceroughness = @Surruf, " +
                     "p2surrufinsp = @SurRufInsp, " +
                     "p2surrufdate = @SurRufDate " +
                     "where [part serial number] = " + g.serialNumber + " ", cnxn);

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

        
        private void tbWidth_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbWidth, 434.85M, 434.45M);
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

        private void tbWidInsp_Leave(object sender, EventArgs e)
        {
            if (tbWidInsp.Text.Length > 0)
            {
                tbSurRufInsp.Text = tbWidInsp.Text;
            }
        }

        private void dtpWidDate_Leave(object sender, EventArgs e)
        {
            dtpSurRufDate.Value = dtpWidDate.Value;
        }

    }

}
