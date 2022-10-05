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
    public partial class F91_Paralellism : Form
    {
        SqlConnection cnxn;
        
        public F91_Paralellism()
        {
            InitializeComponent();
        }

        private void F91_Paralellism_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("select " +
                 "p3parallelisms1s2, " +
                 "p3parssinsp, " +
                 "convert(varchar, p3parssdate, 101) " +
                 "from nif_amp_data where [part serial number] = " + g.serialNumber + " ", cnxn);

            DataTable table = new DataTable();

            da.Fill(table);

            tbParallelism.Text = table.Rows[0].ItemArray[0].ToString();
            tbParaInsp.Text = table.Rows[0].ItemArray[1].ToString();
            if (table.Rows[0].ItemArray[2].ToString().Length > 0)
            {
                dtpParaDate.Text = table.Rows[0].ItemArray[2].ToString();
            }
        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            try
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                    ("Update NIF_AMP_Data set " +
                     "p3parallelisms1s2 = @Para, " +
                     "p3parssinsp = @ParaInsp, " +
                     "p3parssdate = @ParaDate " +
                     "where [part serial number] = " + g.serialNumber + " ", cnxn);

                if (tbParallelism.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@Para", SqlDbType.NChar, 10).Value = tbParallelism.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Para", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@ParaInsp", SqlDbType.NChar, 10).Value = tbParaInsp.Text.Trim();
                cmd.Parameters.Add("@ParaDate", SqlDbType.NChar, 10).Value = dtpParaDate.Text.Trim();

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

        private void tbParallelism_TextChanged_1(object sender, EventArgs e)
        {
            decimalChecker(tbParallelism, 16M, 0M);
        }

        private void bCalculate_Click(object sender, EventArgs e)
        {
            double p = Convert.ToDouble(tbSeconds.Text);
            double d = 0;

            if (rbShort.Checked == true)
            { d = 458; }
            if(rbLong.Checked == true)
            { d = 808; }
            if (rbDiagonal.Checked == true)
            { d = 930; }
            
            double x = ((p / 3600) * d * (3.141592654/180) * 1000 );
            tbParallelism.Text = x.ToString();
        }
    }
}
