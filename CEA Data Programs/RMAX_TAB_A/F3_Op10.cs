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
    public partial class F3_Op10 : Form
    {
        SqlConnection cnxn;
        private string op10PF;

        public F3_Op10()
        {
            InitializeComponent();
        }

        private void F3_Op10_Load(object sender, EventArgs e)
        {
            LserialNumber.Text = "Part Serial Number:  " + g.serialNumber;

            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("select " +
                 "op10Length " +
                 ",op10leninsp " +
                 ",convert(varchar,op10lendate, 101) " +
                 ",op10Width " +
                 ",op10widInsp " +
                 ",convert(varchar,op10widdate, 101) " +
                 ",op10Thickness " +
                 ",op10ThickInsp " +
                 ",convert(varchar,op10thickDate, 101) " +
                 "from CEA_RMAX_MIRROR_TAB_A where [part serial number] = " + g.serialNumber + " ", cnxn);

            DataTable table = new DataTable();

            da.Fill(table);

            tbLength.Text = table.Rows[0][0].ToString();
            tbLenInsp.Text = table.Rows[0][1].ToString();

            if (table.Rows[0][2].ToString().Length > 0)
            {
                dtpLenDate.Text = table.Rows[0][2].ToString();
            }

            tbWidth.Text = table.Rows[0][3].ToString();
            tbWidInsp.Text = table.Rows[0][4].ToString();

            if (table.Rows[0][5].ToString().Length > 0)
            {
                dtpWidDate.Text = table.Rows[0][5].ToString();
            }

            tbThickness.Text = table.Rows[0][6].ToString();
            tbThickInsp.Text = table.Rows[0][7].ToString();

            if (table.Rows[0][8].ToString().Length > 0)
            {
                dtpThickDate.Text = table.Rows[0][8].ToString();
            }
        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            if (tbLength.BackColor.G == 200 & tbWidth.BackColor.G == 200 & tbThickness.BackColor.G == 200 )
            {
                op10PF = "PASS";
            }
            else
            {
                op10PF = "FAIL";
                MessageBox.Show("This step does not PASS !");
            }

            try
            {
                cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand
                    ("Update CEA_RMAX_MIRROR_TAB_A set " +
                     "  Op10Length = @Length " +
                     " ,Op10leninsp = @LenInsp " +
                     " ,Op10lendate = @LenDate " +
                     " ,Op10Width = @Width " +
                     " ,Op10widinsp = @WidInsp " +
                     " ,Op10widdate = @WidDate " +
                     " ,Op10Thickness = @Thickness " +
                     " ,Op10thickInsp = @ThickInsp " +
                     " ,Op10thickDate = @ThickDate " +
                     " ,op10pf = '" + op10PF + "' " +
                     " where [part serial number] = " + g.serialNumber + " ", cnxn);

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

                if (tbThickness.Text.Trim().Length > 0)
                {
                    cmd.Parameters.Add("@Thickness", SqlDbType.NChar, 10).Value = tbThickness.Text.Trim();
                }
                else
                {
                    cmd.Parameters.Add("@Thickness", SqlDbType.NChar, 10).Value = "0";
                }

                cmd.Parameters.Add("@ThickInsp", SqlDbType.NChar, 10).Value = tbThickInsp.Text.Trim();
                cmd.Parameters.Add("@ThickDate", SqlDbType.NChar, 10).Value = dtpThickDate.Text.Trim();


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
            g.decimalChecker(tbLength, 613.00M, 612.00M);
        }

        private void tbLenInsp_Leave(object sender, EventArgs e)
        {
            if (tbLenInsp.Text.Length > 0)
            {
                tbWidInsp.Text = tbLenInsp.Text;
                tbThickInsp.Text = tbLenInsp.Text;
            }
        }

        private void dtpLenDate_Leave(object sender, EventArgs e)
        {
            dtpWidDate.Value = dtpLenDate.Value;
            dtpThickDate.Value = dtpLenDate.Value;
        }

        private void tbWidth_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbWidth, 433.00M, 432.00M);
        }

        private void tbThickness_TextChanged(object sender, EventArgs e)
        {
            g.decimalChecker(tbThickness, 85.50M, 84.50M);
        }
    }
}
