using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustomTooling
{
    public partial class F0_Select_Action : Form
    {
        public F0_Select_Action()
        {
            InitializeComponent();
        }

        private void F0_Select_Action_Load(object sender, EventArgs e)
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

            SqlConnection cnxn = new SqlConnection(g.dbAccess);

            try
            {
                SqlCommand cmd = new SqlCommand(
                 " Select permission, permissionvalue from applicationsetup " +
                 " where application = 'Custom Tooling' and " +
                 " username = '" + user + "' " +
                 " order by permission desc ", cnxn);
                DataTable table = new DataTable();

                cnxn.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();
                table.Load(dr);


                if (table.Rows.Count > 0)
                {
                    g.userPermission = table.Rows[0][1].ToString().Trim();
                }
                else
                {
                    bAdd.Visible = false;
                    bEdit.Visible = false;
                    MessageBox.Show("This user " + user + " does not have permission to edit data with this program: Custom Tooling.");
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


            this.Text = "Custom Tooling Database v" + Application.ProductVersion;
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            g.task = "Add";
            F1_Add_Tool F1 = new F1_Add_Tool();
            F1.ShowDialog();
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            g.task = "Edit";
            F2_ToolList f2 = new F2_ToolList();
            f2.ShowDialog();
        }

        private void bFind_Click(object sender, EventArgs e)
        {
            g.task = "Find";
            F2_ToolList f2 = new F2_ToolList();
            f2.ShowDialog();
        }

        
    }

    //public static class g
    //{
    //    public static string userPermission;
    //    //public static string machineType;

    //    //public static string SN;
    //    //public static string ToolType;
    //    public static string task;
    //    //public static string facility;
    //    //public static string SetUp;

    //    //public static string location;
    //    //public static string Ldescription;
    //    //public static string program;
    //    //public static string Rdescription;
    //    //public static string Rnotes;
    //    //public static int rID;
    //    //public static string eBadgeID;
    //    //public static string iID;
    //    //public static string iDescription;
    //    //public static int internalCalContact;
    //    //public static int cdID;                 //calibration data id
    //    //public static string rpt_status;
    //    //public static string rpt_CalSource;
    //    //public static string rpt_earliestDueDate;
    //    //public static string rpt_latestDueDate;
    //    //public static string rpt_room;
    //    public static string toolNumber;
    //    //public static string grit;
    //    public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
    //                              "user = readwrite; database = OPTICs;";
    //    public static string dbAccess = "server = CT-MID-SQL11; password = Read+Write!; " +
    //                              "user = readwrite; database = AccessFrontEnds;";
    //}
}
