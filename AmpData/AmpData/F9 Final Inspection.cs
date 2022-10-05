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
    public partial class F9_Final_Inspection : Form
    {
        SqlConnection cnxn;
        
        public F9_Final_Inspection()
        {
            InitializeComponent();
        }

        private void F9_Final_Inspection_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("select " +
                 "p3thickness , " +
                 "p3thickinsp, " +
                 "convert(varchar,p3thickdate, 101), " +
                 "p3edgebevelsS1, " +
                 "p3edgbevinsp, " +
                 "convert(varchar,p3edgbevdate, 101), " +
                 "p3edgebevelss2 " +
                 "from nif_amp_data where [part serial number] = " + g.serialNumber + " ", cnxn);

            DataTable table = new DataTable();

            da.Fill(table);

            tbThick.Text = table.Rows[0].ItemArray[0].ToString();
            tbThickInsp.Text = table.Rows[0].ItemArray[1].ToString();
            if (table.Rows[0].ItemArray[2].ToString().Length > 0)
            {
                dtpThickDate.Text = table.Rows[0].ItemArray[2].ToString();
            }
            
            tbBevelsS1.Text = table.Rows[0].ItemArray[3].ToString();
            tbBevelsInsp.Text = table.Rows[0].ItemArray[4].ToString();
            if (table.Rows[0].ItemArray[5].ToString().Length > 0)
            {
                dtpBevelsDate.Text = table.Rows[0].ItemArray[5].ToString();
            }
            tbBevelsS2.Text = table.Rows[0].ItemArray[6].ToString();
        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            try
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                    ("Update NIF_AMP_Data set " +
                     "p3thickness = @Thick, " +
                     "p3thickinsp = @ThickInsp, " +
                     "p3thickdate = @ThickDate, " +
                     "p3edgebevelss1 = @Bevelss1, " +
                     "p3edgebevelss2 = @Bevelss2, " +
                     "p3edgbevinsp = @BevInsp, " +
                     "p3edgbevdate = @BevDate " +
                     "where [part serial number] = " + g.serialNumber + " ", cnxn);

                if (tbThick.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@Thick", SqlDbType.NChar, 10).Value = tbThick.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Thick", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@ThickInsp", SqlDbType.NChar, 10).Value = tbThickInsp.Text.Trim();
                cmd.Parameters.Add("@ThickDate", SqlDbType.NChar, 10).Value = dtpThickDate.Text.Trim();

                if (tbBevelsS1.Text.Trim().Length > 0 )
                {
                    cmd.Parameters.Add("@BevelsS1", SqlDbType.NChar, 10).Value = tbBevelsS1.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@BevelsS1", SqlDbType.NChar, 10).Value = "0";
                }

                if ( tbBevelsS2.Text.Length > 0 )
                {
                    cmd.Parameters.Add("@BevelsS2", SqlDbType.NChar, 10).Value = tbBevelsS2.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Bevelss2", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@BevInsp", SqlDbType.NChar, 10).Value = tbBevelsInsp.Text.Trim();
                cmd.Parameters.Add("@BevDate", SqlDbType.NChar, 10).Value = dtpBevelsDate.Text.Trim();

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

        private void tbThick_TextChanged_1(object sender, EventArgs e)
        {
            decimalChecker(tbThick, 41.5M, 40M);
        }

        private void tbBevels_TextChanged_1(object sender, EventArgs e)
        {
            decimalChecker(tbBevelsS1, 5M, 3M);
        }

        private void tbBevelsS2_TextChanged(object sender, EventArgs e)
        {
            decimalChecker(tbBevelsS2, 5M, 3M);
        }

        private void tbThickInsp_Leave(object sender, EventArgs e)
        {
            if (tbThickInsp.Text.Length > 0)
            {
                tbBevelsInsp.Text = tbThickInsp.Text;
            }
        }

        private void dtpThickDate_Leave(object sender, EventArgs e)
        {
            dtpBevelsDate.Value = dtpThickDate.Value;
        }
    }
}
