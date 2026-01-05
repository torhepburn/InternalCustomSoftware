using MetroproXLicenseDLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;


namespace LicenseGenerator
{
    public partial class f5GenerateLicense : Form
    {
        private string ZygoLicense;
        private string owner;
        private string SalesOrder;
        private string appSort1;
        private string appSort2;
        private DateTime endDate;
        private bool MtpLimit = false;
        SqlConnection cnxn;
        SqlDataReader dr;
        MetroproXLicense MX = new MetroproXLicense();
        //private StringBuilder errorMessage;
        //private StringBuilder licenseKey;
        

        public f5GenerateLicense()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            this.Location = new Point(300, 200);

            if (g.productLine == "MTP" || g.productLine == "MX")
            {
                appSort1 = "and application like 'Metro%' ";
                appSort2 = "and application not like 'Metro%' ";
            }
            if (g.productLine == "ZMP")
            {
                appSort1 = "and application like 'ZeMaps%' ";
                appSort2 = "and application not like 'ZeMaps%' ";
            }

            cnxn = new SqlConnection(g.db);

            SqlCommand cmd = new SqlCommand(
                "select application from applications where productline = '" + g.productLine + "' " +
                "and activedemo = '" + g.activeDemo + "' " + appSort1 +
                "order by dbo.sc_sortableversionstring(application) desc ", cnxn);

            DataTable dt = new DataTable();
            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            cmd = new SqlCommand(
                 "select application from applications where productline = '" + g.productLine + "' " +
                "and activedemo = '" + g.activeDemo + "' " + appSort2 +
                "order by application ", cnxn);

            DataTable dt2 = new DataTable();
            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();
                dt2.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            foreach (DataRow row in dt2.Rows)
            {
                dt.Rows.Add(row.ItemArray);
            }
            cbApplication.DataSource = dt;
            cbApplication.DisplayMember = "Application";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            SqlCommand cmd = new SqlCommand("SELECT DISTINCT TRIM(DongleID) FROM LicenseData  " +
                "WHERE TRIM(DongleID) = '" + tbDongle.Text.Trim() + "'", cnxn);

            try
            {
                cnxn.Open();
                object o = cmd.ExecuteScalar();
                cnxn.Close();

                if (o != null)
                {
                    cmd = new SqlCommand("SELECT Blocked " +
                              " FROM LicenseData WHERE TRIM(DongleID) = '" +
                                tbDongle.Text.Trim() + "'", cnxn);

                    DataTable dtbl = new DataTable();

                    try
                    {
                        cnxn.Open();
                        dr = cmd.ExecuteReader();
                        dtbl.Load(dr);
                        cnxn.Close();

                        if (dtbl.Rows[0][0].ToString().Trim().ToUpper() != "YES")
                        {
                            makeLicense();
                        }
                        else
                        {
                            MessageBox.Show("Customer is blocked - contact Sharon.");
                            this.Close();
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
                else
                {
                    makeLicense();
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

        private void bPrint_Click(object sender, EventArgs e)
        {
            g.DongleID = tbDongle.Text.Trim();

            f61PrintPDF f61 = new f61PrintPDF();
            f61.Show();
        }

        private void bAnother_Click(object sender, EventArgs e)
        {
            cbDuration.Text = "";
            endDate = DateTime.Today;
            label6.Text = "";
        }

        private void makeLicense()
        {
            SqlConnection cnxn2 = new SqlConnection(g.db);

            SqlCommand cmd = new SqlCommand("Select mtplimitapplies FROM Applications " +
                    "WHERE Application = '" + cbApplication.Text.Trim() + "'", cnxn2);

            try
            {
                cnxn2.Open();
                MtpLimit = (bool)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn2.Close();
            }

            if (cbDuration.Text == "14 Days")
            {
                endDate = dtpStart.Value.Date.AddDays(14);
            }
            if (cbDuration.Text == "30 Days")
            {
                endDate = dtpStart.Value.Date.AddMonths(1);
            }
            if (cbDuration.Text == "60 Days")
            {
                endDate = dtpStart.Value.Date.AddMonths(2);
            }
            if (cbDuration.Text == "90 Days")
            {
                endDate = dtpStart.Value.Date.AddMonths(3);
            }
            if (cbDuration.Text == "120 Days")
            {
                endDate = dtpStart.Value.Date.AddMonths(4);
            }
            if (cbDuration.Text == "6 Months")
            {
                endDate = dtpStart.Value.Date.AddMonths(6);
            }
            if (cbDuration.Text == "9 Months")
            {
                endDate = dtpStart.Value.Date.AddMonths(9);
            }
            if (cbDuration.Text == "1 Year")
            {
                endDate = dtpStart.Value.Date.AddYears(1);
            }
            if (cbDuration.Text == "3 Years")
            {
                endDate = dtpStart.Value.Date.AddYears(3);
            }
            if (cbDuration.Text == "5 Years")
            {
                endDate = dtpStart.Value.Date.AddYears(5);
            }
            if (cbDuration.Text == "10 Years")
            {
                endDate = dtpStart.Value.Date.AddYears(10);
            }
            if (cbDuration.Text == "15 Years")
            {
                if (MtpLimit)
                {
                    if (dtpStart.Value.Date.AddYears(15) > Convert.ToDateTime("01-18-2038"))
                    {
                        dtpStart.Value = Convert.ToDateTime("01-18-2023");
                    }
                }

                endDate = dtpStart.Value.Date.AddYears(15);
            }
            if (cbDuration.Text == "20 Years")
            {
                if (MtpLimit)
                {
                    if (dtpStart.Value.Date.AddYears(20) > Convert.ToDateTime("01-18-2038"))
                    {
                        dtpStart.Value = Convert.ToDateTime("01-18-2018");
                    }
                }

                endDate = dtpStart.Value.Date.AddYears(20);
            }
            if (cbDuration.Text == "21 Years")
            {
                if (MtpLimit)
                {
                    if (dtpStart.Value.Date.AddYears(21) > Convert.ToDateTime("01-18-2038"))
                    {
                        dtpStart.Value = Convert.ToDateTime("01-18-2017");
                    }
                }

                endDate = dtpStart.Value.Date.AddYears(21);
            }

            int number;
            bool result = Int32.TryParse(tbSalesOrder.Text.Trim(), out number);
            if (result == true)
            {
                SalesOrder = tbSalesOrder.Text.Trim();
            }
            else
            {
                bool result2 = Int32.TryParse(tbSalesOrder.Text.Substring(2), out number);
                if (result2 == true | tbSalesOrder.Text.ToUpper().Substring(0, 1) == "Z" | tbSalesOrder.Text.ToUpper().Substring(0, 2) == "SO")
                {
                    SalesOrder = tbSalesOrder.Text.Trim().ToUpper();
                    /*   NAV tables require upper case    */
                }
                else
                {
                    SalesOrder = "0";
                    owner = tbSalesOrder.Text.Trim();
                }
            }

            if (cbDuration.Text.Length > 0 && tbSalesOrder.Text.Length > 0)
            {
                if (g.productLine == "MTP")
                {
                    //ZygoLicense = MTP.GenerateMetroproLicenseKey(
                    //tbDongle.Text.Trim(),
                    //cbApplication.Text.Trim(),
                    //dtpStart.Value.Date.ToString("MMM-dd-yyyy"),
                    //endDate.ToString("MMM-dd-yyyy"));
                    var licenseKey = new StringBuilder(20);
                    var errorMessage = new StringBuilder(257);

                    bool ok = MTP.GenerateMetroProLicenseKey(
                    tbDongle.Text.Trim(),
                    cbApplication.Text.Trim(),
                    dtpStart.Value.Date.ToString("MMM-dd-yyyy"),
                    endDate.ToString("MMM-dd-yyyy"),
                    licenseKey,
                    errorMessage
                    );
                    ZygoLicense = licenseKey.ToString();
                }

                if (g.productLine == "MX")
                {
                    ZygoLicense = MX.GenerateMetroproLicenseKey(
                    tbDongle.Text.Trim(),
                    cbApplication.Text.Trim(),
                    dtpStart.Value.ToString(),
                    endDate.ToString());
                }

                if (g.productLine == "ZMP")
                {
                    ZygoLicense = ZMP.GenerateZeMapsLicenseKey(
                    tbDongle.Text.Trim(),
                    cbApplication.Text.Trim(),
                    dtpStart.Value.ToString(),
                    endDate.ToString());
                }

                SqlParameter pOwner = new SqlParameter("@owner", SqlDbType.NChar);
                pOwner.Value = owner;
                if (pOwner.Value is null)
                {
                    pOwner.Value = "";
                }


                cmd = new SqlCommand(
                    "Insert into licensedata (" +
                    "productline, " +
                    "licensenumber, " +
                    "dongleid, " +
                    "application, " +
                    "startdate, " +
                    "expirationdate, " +
                    "salesorder, " +
                    "activedemo, " +
                    "owner) " +
                    "values ('" +
                    g.productLine + "','" +
                    ZygoLicense + "','" +
                    tbDongle.Text.Trim() + "','" +
                    cbApplication.Text.Trim() + "','" +
                    dtpStart.Value + "','" +
                    endDate + "','" +
                    SalesOrder + "','" +
                    g.activeDemo + "'," +
                    pOwner + ")", cnxn2);

                cnxn2.Open();

                try
                {
                    cmd.Parameters.Add(pOwner);
                    int returnd = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cmd.Parameters.Clear();
                    cnxn2.Close();
                }
            }
            else
            {
                MessageBox.Show("Duration and Sales Order boxes require entries.");
                cbDuration.Focus();
            }
            label6.Text = ZygoLicense;
            g.license = ZygoLicense;

            if (SalesOrder != "0")
            {
                cnxn2 = new SqlConnection(g.dbNAV);

                string sql = string.Empty;

                if (SalesOrder.Substring(0, 2) == "SO")
                {
                    sql = "SELECT [Bill-to Customer No_] " +
                   ",CASE " +
                   "   WHEN LEN([End User Customer Name]) < 1 THEN [Bill-to Name] " +
                   "   ELSE [End User Customer Name] " +
                   "END " +
                   ",[Order Date] " +
                   "FROM [ZYGO$Service Header] WHERE No_ = '" + SalesOrder + "'";
                }
                else
                {
                    sql = "SELECT [Sell-to Customer No_] " +
                    ",CASE " +
                    "   WHEN LEN([End User Customer Name]) < 1 THEN [Sell-to Customer Name] " +
                    "   ELSE [End User Customer Name] " +
                    "END " +
                    ",[Order Date] " +
                    "FROM [ZYGO$Sales Header] WHERE No_ = '" + SalesOrder + "'";
                }
                SqlCommand cmd1 = new SqlCommand(sql, cnxn2);

                DataTable dt = new DataTable();

                try
                {
                    cnxn2.Open();
                    dr = cmd1.ExecuteReader();
                    dt.Load(dr);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }

                if (dt.Rows.Count > 0)
                {
                    SqlParameter pCustomerName = new SqlParameter("@customerName", SqlDbType.NChar);
                    pCustomerName.Value = dt.Rows[0][1];
                    cnxn2 = new SqlConnection(g.db);
                    cmd = new SqlCommand("UPDATE LicenseData " +
                        "SET customernumber = '" + dt.Rows[0][0] + "', " +
                        "CustomerName = " + pCustomerName + ", " +
                        "OrderDate = '" + dt.Rows[0][2] + "' " +
                        "WHERE SalesOrder = '" + SalesOrder + "'", cnxn2);

                    try
                    {
                        cnxn2.Open();
                        cmd.Parameters.Add(pCustomerName);
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cmd.Parameters.Clear();
                        cnxn2.Close();
                    }

                }
            }

        }
    }

    public static class ZMP
    {
        [DllImport("ZeMapsLicense.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.BStr)]

        public static extern string GenerateZeMapsLicenseKey(
            [MarshalAs(UnmanagedType.LPStr)] string MachnineIDName,
            [MarshalAs(UnmanagedType.LPStr)] string OptionName,
            [MarshalAs(UnmanagedType.LPStr)] string StartDate,
            [MarshalAs(UnmanagedType.LPStr)] string EndDate);

        public static string GenerateZeMapsLicenseKey(
            string hardwareId, string optionName, DateTime start, DateTime end)
        {
            return GenerateZeMapsLicenseKey(
                hardwareId,
                optionName,
                start.ToString("MM/dd/yyyy").ToUpper(),
                end.ToString("MM/dd/yyyy").ToUpper());
        }
    }

    public static class MTP
    {
        /*
        [DllImport("MetroproLicense.dll", CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.BStr)]

        public static extern string GenerateMetroproLicenseKey(
            [MarshalAs(UnmanagedType.LPStr)] string MachnineIDName,
            [MarshalAs(UnmanagedType.LPStr)] string OptionName,
            [MarshalAs(UnmanagedType.LPStr)] string StartDate,
            [MarshalAs(UnmanagedType.LPStr)] string EndDate);

        public static string GenerateMetroproLicenseKey(
            string hardwareId, string optionName, DateTime start, DateTime end)
        {
            return GenerateMetroproLicenseKey(
                hardwareId,
                optionName,
                start.ToString("MM/dd/yyyy").ToUpper(),
                end.ToString("MM/dd/yyyy").ToUpper());
        }
        */
        [DllImport(
            "MetroProLicenseGeneratorDLL.dll",
            CallingConvention = CallingConvention.Cdecl,
            CharSet = CharSet.Ansi
        )]
        [return: MarshalAs(UnmanagedType.I1)] // C/C++ bool is 1 byte in MSVC

        public static extern bool GenerateMetroProLicenseKey(
            string machineIdName,
            string optionName,
            string startDate,
            string endDate,
            StringBuilder licenseKey,
            StringBuilder errorMessage
        );

    }

    internal static class NativeMethods
    {
        //[DllImport("MetroProLicenseGeneratorDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int Get_MAX_MACHINE_ID_NAME_LEN();

        //[DllImport("MetroProLicenseGeneratorDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int Get_MAX_OPTION_NAME_LEN();

        //[DllImport("MetroProLicenseGeneratorDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int Get_MAX_LICENSE_DATE_LEN();

        //[DllImport("MetroProLicenseGeneratorDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int Get_MAX_LICENSE_KEY_LEN();

        //[DllImport("MetroProLicenseGeneratorDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int Get_MAX_ERROR_MESSAGE_LEN();

        //[DllImport(
        //    "MetroProLicenseGeneratorDLL.dll",
        //    CallingConvention = CallingConvention.Cdecl,
        //    CharSet = CharSet.Ansi
        //)]
        //public static extern string GenerateMetroproLicenseKey(
            //[MarshalAs(UnmanagedType.LPStr)] string MachnineIDName
            //[MarshalAs(UnmanagedType.LPStr)] string OptionName
            //[MarshalAs(UnmanagedType.LPStr)] string StartDate
            //[MarshalAs(UnmanagedType.LPStr)] string EndDate

        //public static string GenerateMetroProLicenseKey(
        //    string hardwareId, string optionName, DateTime start, DateTime end)
        //{
        //    return GenerateMetroProLicenseKey(
        //        string machineIdName,
        //    string optionName,
        //    string startDate,
        //    string endDate);
                
        //}
        
        ////[return: MarshalAs(UnmanagedType.I1)] // C/C++ bool is 1 byte in MSVC
        //public static extern bool GenerateMetroProLicenseKey(
        //    string machineIdName,
        //    string optionName,
        //    string startDate,
        //    string endDate,
        //    StringBuilder licenseKey,
        //    StringBuilder errorMessage
        //);
    }
    
    //internal class Program1
    //{
    //    static int MAX_MACHINE_ID_NAME_LEN;
    //    static int MAX_OPTION_NAME_LEN;
    //    static int MAX_LICENSE_DATE_LEN;
    //    static int MAX_LICENSE_KEY_LEN;
    //    static int MAX_ERROR_MESSAGE_LEN;
    //    static int Main(string[] args)
    //    {
    //        int exitCode = 0;
    //        try
    //        {
    //            /*MAX_MACHINE_ID_NAME_LEN = NativeMethods.Get_MAX_MACHINE_ID_NAME_LEN();
    //            MAX_OPTION_NAME_LEN = NativeMethods.Get_MAX_OPTION_NAME_LEN();
    //            MAX_LICENSE_DATE_LEN = NativeMethods.Get_MAX_LICENSE_DATE_LEN();
    //            MAX_LICENSE_KEY_LEN = NativeMethods.Get_MAX_LICENSE_KEY_LEN();
    //            MAX_ERROR_MESSAGE_LEN = NativeMethods.Get_MAX_ERROR_MESSAGE_LEN();*/

    //            MAX_MACHINE_ID_NAME_LEN = 10;
    //            MAX_OPTION_NAME_LEN = 11;
    //            MAX_LICENSE_DATE_LEN = 11;
    //            MAX_LICENSE_KEY_LEN = 19;
    //            MAX_ERROR_MESSAGE_LEN = 256;


    //            //const string machineIdName = "6680S02722";
    //            //const string optionName = "MetroPro9.1";
    //            //const string startDate = "JAN-01-2015";
    //            //const string endDate = "JAN-01-2035";
    //            //const string expectedLicenseKey = "0130-3668-3130-2604";

    //            var licenseKey = new StringBuilder(MAX_LICENSE_KEY_LEN + 1);
    //            var errorMessage = new StringBuilder(MAX_ERROR_MESSAGE_LEN + 1);
                
    //            bool ok = NativeMethods.GenerateMetroProLicenseKey(
    //                machineIdName,
    //                optionName,
    //                startDate,
    //                endDate,
    //                licenseKey,
    //                errorMessage
    //            );
    //            if (ok)
    //            {
    //                string format = $"{{0,-{MAX_MACHINE_ID_NAME_LEN}}} {{1,-{MAX_OPTION_NAME_LEN}}} {{2,-{MAX_LICENSE_DATE_LEN}}} {{3,-{MAX_LICENSE_DATE_LEN}}} {{4,-{MAX_LICENSE_KEY_LEN}}}";
    //                Console.WriteLine(format, machineIdName, optionName, startDate, endDate, licenseKey);
    //                if (licenseKey.ToString() == expectedLicenseKey)
    //                {
    //                    Console.WriteLine("License generation succeeded and the license key matches the expected value.");
    //                }
    //                else
    //                {
    //                    Console.WriteLine($"License generation succeeded but the license key does NOT match the expected value {expectedLicenseKey}.");
    //                    exitCode = 1;
    //                }

    //            }
    //            else
    //            {
    //                Console.Error.WriteLine($"License generation failed: {errorMessage}");
    //                exitCode = 1;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.Error.WriteLine($"Fatal error: {ex.Message}");
    //            exitCode = 1;
    //        }

    //        Console.WriteLine("Press any key to exit...");
    //        Console.ReadKey(intercept: true); // waits for a key, does not echo it

    //        return exitCode;
    //    }
    //}
}