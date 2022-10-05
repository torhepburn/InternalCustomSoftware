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

namespace BuildingentryLog
{
    public partial class BuildingentryLog : Form
    {
        private string AMETEK_ID;
        SqlConnection cnxn;
        
        public BuildingentryLog()
        {
            InitializeComponent();
        }

        private void BuildingentryLog_Load(object sender, EventArgs e)
        {
            this.Text = "Building Entry Log v" + Application.ProductVersion.Trim();

            dtpCovidTestDate.ResetText();
            cbValidCovidTest.Checked = false;
            cbDisplayCalendar.Checked = false;
            tbCovidTestDate.Text = string.Empty;
            tbEmployeeNumber.Text = string.Empty;
            rbHigh.Checked = false;
            rbPass.Checked = true;
            pnlValid.BackColor = Color.Red;
            cbddEmployees.ResetText();
            AMETEK_ID = string.Empty;
            cbddContact.Text = string.Empty;
            cbddContractors.Text = string.Empty;
            tbCompany.Text = string.Empty;
            
            cbDisplayCalendar.CheckAlign = ContentAlignment.MiddleRight;

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

            /*  outside employee drop down  */

            cnxn = new SqlConnection("server = CT-MID-SQL11; user = readWrite; password = Read+Write!;database = buildinglog ");

            try
            {
                cmd = new SqlCommand("SELECT Name FROM Contractors WHERE LEN(Name) > 0 order by name", cnxn);

                cnxn.Open();

                dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);
                DataRow ddr = dt.NewRow();
                dt.Rows.InsertAt(ddr, 0);

                cbddContractors.DataSource = dt;
                cbddContractors.DisplayMember = "Name";
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxnDash.Close();
            }

            /* contact data */
            
            cmd = new SqlCommand
                        ("Select name from view_employees_active order by name ", cnxnDash);

            SqlDataReader dr1;

            try
            {
                cnxnDash.Open();

                dr1 = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr1);
                DataRow ddr = dt.NewRow();
                dt.Rows.InsertAt(ddr, 0);

                cbddContact.DataSource = dt;
                cbddContact.DisplayMember = "Name";
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
            if (tbCovidTestDate.Text.Length < 1)
            {
                MessageBox.Show("Must open calendar and select date for COVID test,");
                cbDisplayCalendar.Checked = true;
                return;
            }

            cnxn = new SqlConnection("server = CT-MID-SQL11; user = readWrite; password = Read+Write!;database = buildinglog ");

            SqlParameter pEmployeeName = new SqlParameter("@employeeName", SqlDbType.VarChar);
            if (cbddEmployees.Text.Length > 0)
            {
                pEmployeeName.Value = cbddEmployees.Text.Trim();
            }

            if (cbddContractors.Text.Length > 0)
            {
                pEmployeeName.Value = cbddContractors.Text.Trim();
            }

            SqlParameter pEmployeeNumber = new SqlParameter("@employeeNumber", SqlDbType.Int);
            if (tbEmployeeNumber.Text.Trim().Length > 1)
            {
                pEmployeeNumber.Value = tbEmployeeNumber.Text.Trim();
            }
            else
            {
                pEmployeeNumber.Value = 0;
            }

            SqlParameter pValidTest = new SqlParameter("@validTest", SqlDbType.Bit);
            pValidTest.Value = cbValidCovidTest.Checked;

            SqlParameter pCovidTestDate = new SqlParameter("@covidTestDate", SqlDbType.Date);
            if (tbCovidTestDate.Text.Length > 0)
            {
                pCovidTestDate.Value = Convert.ToDateTime(tbCovidTestDate.Text);
            }
            else
            {
                pCovidTestDate.Value = DBNull.Value;
            }

            SqlParameter pHighTemperature = new SqlParameter("@highTemperature", SqlDbType.Bit);
            if (rbHigh.Checked)
            {
                pHighTemperature.Value = true;
            }
            else
            {
                pHighTemperature.Value = false;
            }

            SqlParameter pCompany = new SqlParameter("@company", SqlDbType.VarChar);
            if (tbCompany.Text.Length > 0 & cbddContractors.Text.Length > 0)
            {
                pCompany.Value = tbCompany.Text.Trim();
            }
            else
            {
                pCompany.Value = DBNull.Value;
            }

            SqlParameter pContact = new SqlParameter("@contact", SqlDbType.VarChar);
            if (cbddContact.Text.Length > 0 & cbddContractors.Text.Length > 0)
            {
                pContact.Value = cbddContact.Text.Trim();
            }
            else
            {
                pContact.Value = DBNull.Value;
            }

            SqlCommand cmd = new SqlCommand(
                    "INSERT INTO CovidLog " +
                    "( " +
                    " EmployeeName " +
                    " ,EmployeeNumber " +
                    " ,ValidCovidTest " +
                    " ,CovidTestDate " +
                    " ,HighTemperature " +
                    " ,LogDate " +
                    " ,AMETEK_ID " +
                    " ,Company " +
                    " ,ZygoContact " +
                    ") " +
                    "VALUES " +
                    "(" +
                    pEmployeeName +
                    "," + pEmployeeNumber +
                    "," + pValidTest +
                    "," + pCovidTestDate +
                    "," + pHighTemperature +
                    ",'" + DateTime.Now +
                    "','" + AMETEK_ID +
                    "'," + pCompany +
                    "," + pContact +
                    ")", cnxn);

            cnxn.Open();

            cmd.Parameters.Add(pEmployeeName);
            cmd.Parameters.Add(pEmployeeNumber);
            cmd.Parameters.Add(pValidTest);
            cmd.Parameters.Add(pCovidTestDate);
            cmd.Parameters.Add(pHighTemperature);
            cmd.Parameters.Add(pCompany);
            cmd.Parameters.Add(pContact);

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

            tbEmployeeNumber.Focus();

            BuildingentryLog_Load(null, EventArgs.Empty);
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
                        cbddEmployees.Text = dr.GetString(0);
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

                if (cbddEmployees.Text.Length < 1)
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
                        if (!dr.IsDBNull(0))
                        {
                            tbCovidTestDate.Text = dr.GetDateTime(0).ToString("MM/dd/yy");
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

                tbCovidTestDate.Focus();
                //string name = tbEmployeeName.Text;
                //cbddEmployees.SelectedIndex = 0;
                //tbEmployeeName.Text = name;
            }
        }

        private void cbDisplayCalendar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDisplayCalendar.Checked)
            {
                dtpCovidTestDate.Visible = true;
            }
            else
            {
                dtpCovidTestDate.Visible = false;
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
                        tbCovidTestDate.Text = dr.GetDateTime(0).ToString("MM/dd/yy");

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

        private void ValidateTestDate()
        {
            /*
             *  DateTime now = DateTime.Now.AddDays(6);
            int dayOfWeek = (int)now.DayOfWeek;
            dayOfWeek = dayOfWeek == 0 ? 7 : dayOfWeek;
            DateTime startOfWeek = (now.AddDays(1 - (int)now.DayOfWeek)).AddDays(-7);

            DateTime testThu = DateTime.Now.AddDays(3);
            int nn = (int)testThu.DayOfWeek;
            int n = (testThu.DayOfWeek - DayOfWeek.Monday);
            DateTime pWeekMonday = DateTime.Now.AddDays(testThu.DayOfWeek - DayOfWeek.Monday);
            DateTime previousWeekMonday = (DateTime.Now.AddDays(DayOfWeek.Monday - DateTime.Now.DayOfWeek)).AddDays(-7);
             * */
            if (tbCovidTestDate.Text.Length > 1)
            {
                int dayOfWeek = (int)DateTime.Now.DayOfWeek;
                dayOfWeek = dayOfWeek == 0 ? 7 : dayOfWeek;
                DateTime previousWeekMonday = (DateTime.Now.AddDays(1 - dayOfWeek)).AddDays(-7);
               

                if (Convert.ToDateTime(tbCovidTestDate.Text).Date >= previousWeekMonday.Date)
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

        }

       
        private void dtpCovidTestDate_ValueChanged(object sender, EventArgs e)
        {
            if (cbDisplayCalendar.Checked)
            {
                tbCovidTestDate.Text = dtpCovidTestDate.Value.ToString("MM/dd/yy");

                ValidateTestDate();
            }
        }


        private void cbddEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbddEmployees.SelectedIndex > 0)
            {
                ClearContractorData();

                SqlConnection cnxnDash = new SqlConnection("server = MIDDB01.zygo.com; user = sa; password = serverpwd;database = dashboard;");

                SqlCommand cmd1 = new SqlCommand
                            ("Select AMETEK_ID from view_employees WHERE name = '" + cbddEmployees.Text.Trim() + "'", cnxnDash);

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

       
        private void cbddContractors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbddContractors.SelectedIndex > 0)
            {
                cnxn = new SqlConnection("server = CT-MID-SQL11; user = readWrite; password = Read+Write!;database = buildinglog ");

                SqlCommand cmd = new SqlCommand("SELECT Company, Contact, CovidTestDate FROM Contractors WHERE Name = '" + cbddContractors.Text + "'", cnxn);

                SqlDataReader dr;

                if (cbddContractors.Text.Length > 0)
                {
                    try
                    {
                        cnxn.Open();

                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            if (!dr.IsDBNull(0))
                            {
                                tbCompany.Text = dr.GetString(0).Trim();
                            }
                            else
                            {
                                tbCompany.Text = string.Empty;
                            }

                            if (!dr.IsDBNull(1))
                            {
                                cbddContact.Text = dr.GetString(1).Trim();
                            }
                            else
                            {
                                cbddContact.Text = string.Empty;
                            }

                            if (!dr.IsDBNull(2))
                            {
                                tbCovidTestDate.Text = dr.GetDateTime(2).ToString("MM/dd/yy");
                                ValidateTestDate();
                            }
                            else
                            {
                                tbCovidTestDate.Focus();
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

        }

        private void tbEmployeeNumber_Enter(object sender, EventArgs e)
        {
            ClearContractorData();
            ClearDateData();
        }

        private void ClearContractorData()
        {
            cbddContractors.ResetText();
            tbCompany.Text = string.Empty;
            cbddContact.ResetText();
        }

        private void ClearDateData()
        {
            cbDisplayCalendar.Checked = false;
            tbCovidTestDate.Text = string.Empty;
            cbValidCovidTest.Checked = false;
            pnlValid.BackColor = Color.Red;
        }

        private void ClearEmployeeData()
        {
            cbddEmployees.ResetText();
            tbEmployeeNumber.Text = string.Empty;

            cbDisplayCalendar.Checked = false;
            dtpCovidTestDate.ResetText();
            tbCovidTestDate.Text = string.Empty;
            cbValidCovidTest.Checked = false;
            pnlValid.BackColor = Color.Red;
        }

        private void cbddContractors_Enter(object sender, EventArgs e)
        {
            ClearEmployeeData();
        }

        private void tbCompany_Enter(object sender, EventArgs e)
        {
            //ClearEmployeeData();
        }

        private void cbddContact_Enter(object sender, EventArgs e)
        {
            //ClearEmployeeData();
        }
        
    }
}
