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

namespace SiliconExpertBOMList
{
    public partial class FileList : Form
    {
        public FileList()
        {
            InitializeComponent();
        }

        private void FileList_Load(object sender, EventArgs e)
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
                 " where application = 'Silicon Expert Data' and " +
                 " username = '" + user + "' " +
                 " order by permission desc ", cnxn);
                DataTable table = new DataTable();

                cnxn.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();
                table.Load(dr);


                if (table.Rows.Count > 0)
                {
                    //g.printer = table.Rows[0][1].ToString().Trim();
                }
                else
                {
                    MessageBox.Show("This user " + user + " does not have permission to use this program: SILICON EXPERT DATA.");
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }

            this.Text = "Silicon Expert v" + Application.ProductVersion;
        }

        private void bInstrument_Click(object sender, EventArgs e)
        {
            g.ProductGroup = "INSTRUMENT";
            BOMList b = new BOMList();
            b.ShowDialog();
        }

        private void bPPS_Click(object sender, EventArgs e)
        {
            g.ProductGroup = "PPS";
            BOMList b = new BOMList();
            b.ShowDialog();
        }
    }

    public static class g
    {
        public static string user;
        public static string assembly;
        public static string task;
        public static string ProductGroup;
        public static string db = "server = CT-MID-SQL11; Database = AccessFrontEnds; " +
                            "user = readWrite; password = Read+Write!;";
        public static string dbDash = "server = CT-MID-DB01.ametek.com; Database = Dashboard; " +
                    "user = views; password = views;";
        
    }
}
