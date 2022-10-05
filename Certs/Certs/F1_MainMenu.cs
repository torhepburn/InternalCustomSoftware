using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Certs
{
    public partial class F1_MainMenu : Form
    {
        public F1_MainMenu()
        {
            InitializeComponent();
        }

        private void F1_MainMenu_Load(object sender, EventArgs e)
        {
            System.Security.Principal.WindowsIdentity userBase;
            userBase = System.Security.Principal.WindowsIdentity.GetCurrent();

            string user = userBase.Name.ToUpper(); ;

            if (userBase.Name.IndexOf("Z") == 0)
            {
                user = userBase.Name.Replace("ZYGOMIS\\", "");
            }
            else
            {
                user = userBase.Name.Replace("AMETEK-AD\\", "");
            }

            string computername = Environment.MachineName;

            SqlConnection cnxn = new SqlConnection(g.db);

            try
            {
                SqlCommand cmd = new SqlCommand(
                 " Select permission, permissionvalue from applicationsetup " +
                 " WHERE application = 'CertificationManager.exe' AND permission = 'Access' " +
                 " AND username = '" + user + "' " +
                 " ORDER BY permission desc ", cnxn);
                DataTable table = new DataTable();

                cnxn.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();
                table.Load(dr);

                if (table.Rows.Count > 0)
                {
                    //g.permission = table.Rows[0][1].ToString().Trim();
                }
                else
                {
                    MessageBox.Show("This user " + user + " does not have permission to use this program: Certification Manager.");
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

            try
            {
                SqlCommand cmd = new SqlCommand(
                 " SELECT permission, permissionvalue FROM applicationsetup " +
                 " WHERE application = 'CertificationManager.exe' AND permission = 'ADMIN' " +
                 " AND username = '" + user + "' " +
                 " ORDER BY permission desc ", cnxn);
                DataTable table = new DataTable();

                cnxn.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();
                table.Load(dr);

                if (table.Rows.Count > 0)
                {
                    g.permission = table.Rows[0][0].ToString().Trim();
                }
                else
                {
                    //MessageBox.Show("Either this user " + user + " does not have permission to use this program: Certification Manager.");
                    //this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }


            this.Text = "Certs v" + Application.ProductVersion;

            //bPrintForm028104.Visible = true;
            if (g.permission == "ADMIN")
            {
                BAdmin.Visible = true;
            }
        }

        private void bAddCalibration_Click(object sender, EventArgs e)
        {
            g.task = "ADD";
            g.certificationNumber = string.Empty;
            g.rpt_type = "CAL";
            AddNewCopy a = new AddNewCopy();
            //EditCalibrationCert a = new EditCalibrationCert();
            a.ShowDialog();
        }

        private void bViewEditPrint_Click(object sender, EventArgs e)
        {
            g.task = "VIEW";
            //g.rpt_type = string.Empty;
            SelectCert s = new SelectCert();
            s.ShowDialog();
        }

        private void bEditCalibration_Click(object sender, EventArgs e)
        {
            g.task = "EDIT";
            g.rpt_type = "CAL";
            g.search = string.Empty;
            g.ISO = string.Empty;
            SelectCert s = new SelectCert();
            s.ShowDialog();
        }

       
        private void bPrintForm0281_Click(object sender, EventArgs e)
        {
            g.task = "PRINT";
            g.rpt_type = "CAL";
            g.ISO="AND ISO17025 = 1 ";
            g.form = "281-03";
            SelectCert s = new SelectCert();
            s.ShowDialog();
        }

        private void bPrintCalibration_Click(object sender, EventArgs e)
        {
            g.task = "PRINT";
            g.rpt_type = "CAL";
            g.form = "281-02";
            SelectCert s = new SelectCert();
            s.ShowDialog();
        }

        private void bAddCompliance_Click(object sender, EventArgs e)
        {
            g.task = "ADD";
            g.certificationNumber = string.Empty;
            g.rpt_type = "COM";
            AddNewCopy a = new AddNewCopy();
            a.ShowDialog();
        }

        private void bEditCompliance_Click(object sender, EventArgs e)
        {
            g.task = "EDIT";
            g.rpt_type = "COM";
            g.search = string.Empty;
            SelectCert s = new SelectCert();
            s.ShowDialog();
        }


        private void bPrintCompliance_Click(object sender, EventArgs e)
        {
            g.task = "PRINT";
            g.rpt_type = "COM";
            SelectCert s = new SelectCert();
            s.ShowDialog();
        }

        private void BAdmin_Click(object sender, EventArgs e)
        {

            AdminChoices c = new AdminChoices();
            c.ShowDialog();
        }

        private void bPrintForm028104_Click(object sender, EventArgs e)
        {
            g.task = "PRINT";
            g.rpt_type = "CAL";
            g.ISO = "AND ISO17025 = 1 ";
            g.form = "281-04";
            SelectCert s = new SelectCert();
            s.ShowDialog();
        }

        private void bCompliancePDF_Click(object sender, EventArgs e)
        {
            g.task = "PRINT";
            g.rpt_type = "COM";
            g.form = "325pdf";
            SelectCert s = new SelectCert();
            s.ShowDialog();
        }
    }

    public static class g
    {
        public static string certificationNumber;
        public static string description;
        public static string task;
        public static string dbTable = "CERT_Data";
        public static string ISO = string.Empty;
        public static string search = string.Empty;
        public static string form = string.Empty;
        public static string dbImage = "CERT_Image";
        public static string subtask;
        public static string newCertNumber;
        public static string adminTask;
        public static string permission;
        public static string permissionValue;
        public static string loginname;
        public static string employeeName;
        //public static string rpt_status;
        //public static string rpt_CalSource;
        //public static string rpt_earliestDueDate;
        //public static string rpt_latestDueDate;
        //public static string rpt_room;
        public static string rpt_type = string.Empty;
        //public static string pdf;
        public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";
        public static string dbNAV = "server = pa-hor-as408.ametek.com; user = navdb_read; password = 2018#ameteK; database = ZYGO-NAV-PROD";
        //public static string dbDashserver = "server = middb01; password = views; " +
        //                          "user = views; database = dashboard;";
    }
}
