using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace COVIDLog
{
    public partial class COVIDLog : Form
    {
        private string AMETEK_ID;
        private DateTime CovidTestDate;
        SqlConnection cnxn;

        public COVIDLog()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Building Entry Log v" + Application.ProductVersion.Trim();

            //numericUpDown1.DecimalPlaces = 1;
            //numericUpDown1.Increment = 0.1M;
            //numericUpDown1.Maximum = 100.6M;
            //numericUpDown1.Minimum = 95M;

            pnlValid.BackColor = Color.Red;

            rbTestDate1.Text = DateTime.Now.AddDays(-1).ToShortDateString();
            rbTestDate2.Text = DateTime.Now.AddDays(-2).ToShortDateString();
            rbTestDate3.Text = DateTime.Now.AddDays(-3).ToShortDateString();
            rbTestDate4.Text = DateTime.Now.AddDays(-4).ToShortDateString();
            rbTestDate5.Text = DateTime.Now.AddDays(-5).ToShortDateString();
            rbTestDate6.Text = DateTime.Now.AddDays(-6).ToShortDateString();
            rbTestDate7.Text = DateTime.Now.AddDays(-7).ToShortDateString();
            rbTestDate8.Text = DateTime.Now.AddDays(-8).ToShortDateString();
            rbTestDate9.Text = DateTime.Now.AddDays(-9).ToShortDateString();
            rbTestDate10.Text = DateTime.Now.AddDays(-10).ToShortDateString();
            rbTestDate11.Text = DateTime.Now.AddDays(-11).ToShortDateString();
            rbTestDate12.Text = DateTime.Now.AddDays(-12).ToShortDateString();
            rbTestDate13.Text = DateTime.Now.AddDays(-13).ToShortDateString();
            rbTestDate14.Text = DateTime.Now.AddDays(-14).ToShortDateString();

            if (Convert.ToDateTime(rbTestDate14.Text ) < Convert.ToDateTime("2021-03-01"))
            {
                rbTestDate14.Visible = false;
            }

            if (Convert.ToDateTime(rbTestDate13.Text) < Convert.ToDateTime("2021-03-01"))
            {
                rbTestDate13.Visible = false;
            }

            if (Convert.ToDateTime(rbTestDate12.Text) < Convert.ToDateTime("2021-03-01"))
            {
                rbTestDate12.Visible = false;
            }

            if (Convert.ToDateTime(rbTestDate10.Text) < Convert.ToDateTime("2021-03-01"))
            {
                rbTestDate10.Visible = false;
            }

            if (Convert.ToDateTime(rbTestDate9.Text) < Convert.ToDateTime("2021-03-01"))
            {
                rbTestDate9.Visible = false;
            }

            if (Convert.ToDateTime(rbTestDate11.Text) < Convert.ToDateTime("2021-03-01"))
            {
                rbTestDate11.Visible = false;
            }

            if (Convert.ToDateTime(rbTestDate8.Text) < Convert.ToDateTime("2021-03-01"))
            {
                rbTestDate8.Visible = false;
            }


            CovidTestDate = System.Convert.ToDateTime("1900-01-01");
            //dtpCovidTestDate.Text = "1900-01-01";

            SqlConnection cnxnDash = new SqlConnection("server = MIDDB01.zygo.com; user = sa; password = serverpwd;database = dashboard;");

            SqlCommand cmd = new SqlCommand
                        ("Select name from view_employees_active order by name ", cnxnDash);

            SqlDataReader dr;

            try
            {
                cnxnDash.Open();

                dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);
                DataRow ddr = dt.NewRow();
                dt.Rows.InsertAt(ddr, 0);
                
                cbddEmployees.DataSource = dt;
                cbddEmployees.DisplayMember = "Name";

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxnDash.Close();
            }

           
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            //if (numericUpDown1.Value < 95.1M)
            //{
            //    MessageBox.Show("Must enter a temperature reading.");
            //    numericUpDown1.Focus();
            //    return;
            //}

            //if (numericUpDown1.Value > 100.4M)
            //{
            //    cbHighTemperature.Checked = true;
            //}
            //else
            //{
            //    cbHighTemperature.Checked = false;
            //}

            


            cnxn = new SqlConnection("server = CT-MID-SQL11; user = readWrite; password = Read+Write!;database = buildinglog ");

            SqlParameter pEmployeeName = new SqlParameter("@employeeName", SqlDbType.VarChar);
            pEmployeeName.Value = tbEmployeeName.Text.Trim();

            SqlParameter pEmployeeNumber = new SqlParameter("@employeeNumber", SqlDbType.Int);
            if (tbEmployeeNumber.Text.Trim().Length > 1)
            {
                pEmployeeNumber.Value = tbEmployeeNumber.Text.Trim();
            }
            else
            {
                pEmployeeNumber.Value = 0;
            }
            //SqlParameter pRequired = new SqlParameter("@required", SqlDbType.Bit);
            //pRequired.Value = cbRequired.Checked;

            SqlParameter pValidTest = new SqlParameter("@validTest", SqlDbType.Bit);
            pValidTest.Value = cbValidCovidTest.Checked;

            SqlParameter pCovidTestDate = new SqlParameter("@covidTestDate", SqlDbType.Date);
            pCovidTestDate.Value = CovidTestDate;

            //SqlParameter pTemperatureReading = new SqlParameter("@temperatureReading", SqlDbType.Decimal);
            //pTemperatureReading.Value = numericUpDown1.Value;

            SqlParameter pHighTemperature = new SqlParameter("@highTemperature", SqlDbType.Bit);
            if (rbHigh.Checked)
            {
                pHighTemperature.Value = true;
            }
            else
            {
                pHighTemperature.Value = false;
            }

            SqlCommand cmd = new SqlCommand(
                    "INSERT INTO CovidLog " +
                    "( " +
                    " EmployeeName " +
                    " ,EmployeeNumber " +
                    //" ,Required " +
                    " ,ValidCovidTest " +
                    " ,CovidTestDate " +
                    //" ,TemperatureReading " +
                    " ,HighTemperature " +
                    " ,LogDate " +
                    " ,AMETEK_ID " +
                    ") " +
                    "VALUES " +
                    "(" +
                    pEmployeeName +
                    "," + pEmployeeNumber +
                    //"," + pRequired +
                    "," + pValidTest +
                    "," + pCovidTestDate +
                    //"," + pTemperatureReading +
                    "," + pHighTemperature +
                    ",'" + DateTime.Now +
                    "','" + AMETEK_ID + 
                    "')", cnxn);

            cnxn.Open();

            cmd.Parameters.Add(pEmployeeName);
            cmd.Parameters.Add(pEmployeeNumber);
            //cmd.Parameters.Add(pRequired);
            cmd.Parameters.Add(pValidTest);
            cmd.Parameters.Add(pCovidTestDate);
            //cmd.Parameters.Add(pTemperatureReading);
            cmd.Parameters.Add(pHighTemperature);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
                cmd.Parameters.Clear();
            }

            tbEmployeeName.Text = string.Empty;
            tbEmployeeNumber.Text = string.Empty;
            rbHigh.Checked = false;
            rbPass.Checked = true;
            CovidTestDate = DateTime.Now.AddDays(-20);
            cbValidCovidTest.Checked = false;
            dtpCovidTestDate.ResetText();
            rbEmployee.Checked = true;
            pnlValid.BackColor = Color.Red;
            cbddEmployees.ResetText();
            rbSelectDate.Checked = true;
            AMETEK_ID = string.Empty;

            Form1_Load(null, EventArgs.Empty);
            //tbEmployeeNumber.Focus();
        }

        private void tbEmployeeNumber_Leave(object sender, EventArgs e)
        {
            if (tbEmployeeNumber.Text.Length > 0)
            {
                SqlConnection cnxnDash = new SqlConnection("server = MIDDB01.zygo.com; user = sa; password = serverpwd;database = dashboard;");

                SqlCommand cmd = new SqlCommand
                            ("Select name, AMETEK_ID from view_employees WHERE BadgeID = " + tbEmployeeNumber.Text.Trim() + "", cnxnDash);

                SqlDataReader dr;

                try
                {
                    cnxnDash.Open();
                    
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        tbEmployeeName.Text = dr.GetString(0);
                        AMETEK_ID = dr.GetString(1).Trim();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxnDash.Close();
                }

                if (rbEmployee.Checked & tbEmployeeName.Text.Length < 1)
                {
                    MessageBox.Show("Employee Badge not found.");
                    tbEmployeeNumber.Text = string.Empty;
                    cbddEmployees.Focus();
                    return;
                }


                cnxn = new SqlConnection("server = CT-MID-SQL11; user = readWrite; password = Read+Write!;database = buildinglog ");
                cmd = new SqlCommand("Select CovidTestDate FROM EmployeeData WHERE AMETEKNumber = " + AMETEK_ID + "", cnxn);

                try
                {
                    cnxn.Open();
                    
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        //if (dr.GetString(0).ToUpper() == "Y")
                        //{
                        //    cbRequired.Checked = true;
                        //}
                        //else
                        //{
                        //    cbRequired.Checked = false;
                        //    MessageBox.Show("Employee NOT required.  Contact Supervisor");
                        //}

                        if (!dr.IsDBNull(0))
                        {
                            CovidTestDate = dr.GetDateTime(0);
                            DisplayTestDate();
                            ValidateTestDate();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }

                
                string name = tbEmployeeName.Text;
                cbddEmployees.SelectedIndex = 0;
                tbEmployeeName.Text = name;
            }
        }

        private void tbEmployeeName_Leave(object sender, EventArgs e)
        {
            if (rbOutsideService.Checked)
            {
                cnxn = new SqlConnection("server = CT-MID-SQL11; user = readWrite; password = Read+Write!;database = buildinglog ");
                SqlCommand cmd = new SqlCommand("Select CovidTestDate, FirstName + ' ' + LastName FROM OutsideServiceEmployees WHERE LastName like '%" + tbEmployeeName.Text + "%' OR " +
                  "FirstName like '%" + tbEmployeeName.Text + "%'", cnxn);

                try
                {
                    cnxn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        //if (dr.GetString(0).ToUpper() == "Y")
                        //{
                        //    cbRequired.Checked = true;
                        //}
                        //else
                        //{
                        //    cbRequired.Checked = false;
                        //    MessageBox.Show("Employee NOT required.  Contact Supervisor");
                        //}

                        tbEmployeeName.Text = dr.GetString(1);

                        if (!dr.IsDBNull(0))
                        {
                            CovidTestDate = dr.GetDateTime(0);
                            DisplayTestDate();
                            ValidateTestDate();
                        }

                        
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }

                
            }
        }

        private void rbOther_CheckedChanged(object sender, EventArgs e)
        {

            if (rbOther.Checked == true)
            {
                dtpCovidTestDate.Visible = true;
            }
            else
            {
                dtpCovidTestDate.Visible = false;
            }
            
        }

        private void rbTestDate1_CheckedChanged(object sender, EventArgs e)
        {
            CovidTestDate = Convert.ToDateTime(rbTestDate1.Text);
            ValidateTestDate();
        }

        private void rbTestDate2_CheckedChanged(object sender, EventArgs e)
        {
            CovidTestDate = Convert.ToDateTime(rbTestDate2.Text);
            ValidateTestDate();
        }

        private void rbTestDate3_CheckedChanged(object sender, EventArgs e)
        {
            CovidTestDate = Convert.ToDateTime(rbTestDate3.Text);
            ValidateTestDate();
        }

        private void rbTestDate4_CheckedChanged(object sender, EventArgs e)
        {
            CovidTestDate = Convert.ToDateTime(rbTestDate4.Text);
            ValidateTestDate();
        }

        private void rbTestDate5_CheckedChanged(object sender, EventArgs e)
        {
            CovidTestDate = Convert.ToDateTime(rbTestDate5.Text);
            ValidateTestDate();
        }

        private void rbTestDate6_CheckedChanged(object sender, EventArgs e)
        {
            CovidTestDate = Convert.ToDateTime(rbTestDate6.Text);
            ValidateTestDate();
        }

        private void rbTestDate7_CheckedChanged(object sender, EventArgs e)
        {
            CovidTestDate = Convert.ToDateTime(rbTestDate7.Text);
            ValidateTestDate();
        }

        private void rbTestDate8_CheckedChanged(object sender, EventArgs e)
        {
            CovidTestDate = Convert.ToDateTime(rbTestDate8.Text);
            ValidateTestDate();
        }

        private void rbTestDate9_CheckedChanged(object sender, EventArgs e)
        {
            CovidTestDate = Convert.ToDateTime(rbTestDate9.Text);
            ValidateTestDate();
        }

        private void rbTestDate10_CheckedChanged(object sender, EventArgs e)
        {
            CovidTestDate = Convert.ToDateTime(rbTestDate10.Text);
            ValidateTestDate();
        }

        private void rbTestDate11_CheckedChanged(object sender, EventArgs e)
        {
            CovidTestDate = Convert.ToDateTime(rbTestDate11.Text);
            ValidateTestDate();
        }

        private void rbTestDate12_CheckedChanged(object sender, EventArgs e)
        {
            CovidTestDate = Convert.ToDateTime(rbTestDate12.Text);
            ValidateTestDate();
        }

        private void rbTestDate13_CheckedChanged(object sender, EventArgs e)
        {
            CovidTestDate = Convert.ToDateTime(rbTestDate13.Text);
            ValidateTestDate();
        }

        private void rbTestDate14_CheckedChanged(object sender, EventArgs e)
        {
            CovidTestDate = Convert.ToDateTime(rbTestDate14.Text);
            ValidateTestDate();
        }

        //private void numericUpDown1_Leave(object sender, EventArgs e)
        //{
        //    if (numericUpDown1.Value > 100.4M)
        //    {
        //        cbHighTemperature.Checked = true;
        //    }
        //    else
        //    {
        //        cbHighTemperature.Checked = false;
        //    }
        //}

        private void ValidateTestDate()
        {
            if (CovidTestDate.Date > DateTime.Now.Date.AddDays(-10))
            {
                if (CovidTestDate > Convert.ToDateTime("2021-02-28"))
                {
                    cbValidCovidTest.Checked = true;
                    pnlValid.BackColor = Color.Green;
                }
                else
                {
                    cbValidCovidTest.Checked = false;
                    pnlValid.BackColor = Color.Red;
                }
            }
            else
            {
                cbValidCovidTest.Checked = false;
                pnlValid.BackColor = Color.Red;
            }

        }

        private void dtpCovidTestDate_ValueChanged(object sender, EventArgs e)
        {
            CovidTestDate = dtpCovidTestDate.Value;

            DisplayTestDate();

            ValidateTestDate();
        }

        private void cbddEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbddEmployees.SelectedIndex > 0)
            {
                tbEmployeeName.Text = cbddEmployees.Text;

                SqlConnection cnxnDash = new SqlConnection("server = MIDDB01.zygo.com; user = sa; password = serverpwd;database = dashboard;");

                SqlCommand cmd1 = new SqlCommand
                            ("Select AMETEK_ID from view_employees WHERE name = '" + tbEmployeeName.Text.Trim() + "'", cnxnDash);

                SqlDataReader dr;

                try
                {
                    cnxnDash.Open();

                    dr = cmd1.ExecuteReader();

                    while (dr.Read())
                    {
                        AMETEK_ID = dr.GetString(0).Trim();
                        tbEmployeeNumber.Text = AMETEK_ID;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxnDash.Close();
                }

                GetCovidTestDate();
            }

        }

        private void GetCovidTestDate()
        {
            SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL11; user = readWrite; password = Read+Write!;database = buildinglog ");
            SqlCommand cmd = new SqlCommand("Select CovidTestDate FROM EmployeeData WHERE AMETEKNumber = " + AMETEK_ID + "", cnxn);
            SqlDataReader dr;

            try
            {
                cnxn.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        CovidTestDate = dr.GetDateTime(0);

                        DisplayTestDate();
                        
                        ValidateTestDate();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }
        }

        private void DisplayTestDate()
        {
            if (Convert.ToDateTime(rbTestDate1.Text) == CovidTestDate)
            {
                rbTestDate1.Checked = true;
            }

            if (Convert.ToDateTime(rbTestDate2.Text) == CovidTestDate)
            {
                rbTestDate2.Checked = true;
            }

            if (Convert.ToDateTime(rbTestDate3.Text) == CovidTestDate)
            {
                rbTestDate3.Checked = true;
            }

            if (Convert.ToDateTime(rbTestDate4.Text) == CovidTestDate)
            {
                rbTestDate4.Checked = true;
            }

            if (Convert.ToDateTime(rbTestDate5.Text) == CovidTestDate)
            {
                rbTestDate5.Checked = true;
            }

            if (Convert.ToDateTime(rbTestDate6.Text) == CovidTestDate)
            {
                rbTestDate6.Checked = true;
            }

            if (Convert.ToDateTime(rbTestDate7.Text) == CovidTestDate)
            {
                rbTestDate7.Checked = true;
            }

            if (Convert.ToDateTime(rbTestDate8.Text) == CovidTestDate)
            {
                rbTestDate8.Checked = true;
            }

            if (Convert.ToDateTime(rbTestDate9.Text) == CovidTestDate)
            {
                rbTestDate9.Checked = true;
            }

            if (Convert.ToDateTime(rbTestDate10.Text) == CovidTestDate)
            {
                rbTestDate10.Checked = true;
            }

            if (Convert.ToDateTime(rbTestDate11.Text) == CovidTestDate)
            {
                rbTestDate11.Checked = true;
            }

            if (Convert.ToDateTime(rbTestDate12.Text) == CovidTestDate)
            {
                rbTestDate12.Checked = true;
            }

            if (Convert.ToDateTime(rbTestDate13.Text) == CovidTestDate)
            {
                rbTestDate13.Checked = true;
            }

            if (Convert.ToDateTime(rbTestDate14.Text) == CovidTestDate)
            {
                rbTestDate14.Checked = true;
            }

        }
    }
}
