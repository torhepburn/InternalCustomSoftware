using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tools
{
    public partial class F1_Start : Form
    {
        public F1_Start()
        {
            InitializeComponent();
        }

        private void F1_Start_Load(object sender, EventArgs e)
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
                 " where application = 'Tools' and " +
                 " pcid = '" + computername + "' " +
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
                    MessageBox.Show("This computer " + computername + " does not have permission to use this program: Tools.");
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


            this.Text = "F1 Tooling Program version " + Application.ProductVersion;

            bAdd.Visible = false;
            bDelete.Visible = false;
            bGridEdit.Visible = false;
            bEditSetup.Visible = false;
            bLocation.Visible = false;
            
            if (g.userType == "facility")
            {
                //bGridEdit.Visible = true;
                bEditSetup.Visible = true;
                bLocation.Visible = true;
                bAdd.Visible = true;
            }

            if (g.program == "CNC")
            {
                this.BackColor = Color.FromArgb(250, 250, 110);
                this.Text = "Choose Task - CNC";
            }

            if (g.program == "LFO")
            {
                this.BackColor = Color.LightSalmon;
                this.Text = "Choose Task - LFO";
            }

            if (g.program == "FX")
            {
                this.BackColor = Color.FromArgb(50, 205, 50);
                this.Text = "Choose Task - Fixtures";
                bFind.Visible = false;
                bEditSetup.Visible = false;
                bLocation.Visible = false;
                bLocate.Visible = false;
            }

            if (g.program == "VC")
            {
                this.BackColor = Color.FromArgb(50, 50, 205);
                this.Text = "Choose Task - Vacuum Chucks";
                bFind.Visible = false;
                bEditSetup.Visible = false;
                bLocation.Visible = false;
                bLocate.Visible = false;
            }

        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            g.task = "Add";

            if (g.program == "FX" | g.program == "VC")
            {
                F4a_AddEditFxVc f = new F4a_AddEditFxVc();
                f.ShowDialog();
            }
            else
            {
                f31_EquipmentID f31 = new f31_EquipmentID();
                f31.ShowDialog();
            }
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            g.task = "Edit";
            F2_Tools f2 = new F2_Tools();
            f2.Show();
        }

        private void bView_Click(object sender, EventArgs e)
        {
            F3_View f3 = new F3_View();
            f3.Show();
        }

        

        private void bExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bFind_Click(object sender, EventArgs e)
        {
            F31_Find_Tools f31 = new F31_Find_Tools();
            f31.Show();
        }

        private void bGridEdit_Click(object sender, EventArgs e)
        {
            Atest f5 = new Atest();
            f5.Show();
        }

        private void bFindTbItem_Click(object sender, EventArgs e)
        {
            g.task = "View";
            g.SN = tbItem.Text.ToUpper().Trim();

            if (g.program == "CNC" | g.program == "LFO")
            {
                F4_Edit f4a = new F4_Edit();
                f4a.Show();
            }
            else
            {
                F4a_AddEditFxVc f4 = new F4a_AddEditFxVc();
                f4.ShowDialog();
            }
            tbItem.Clear();
            
        }

        private void bLocation_Click(object sender, EventArgs e)
        {
            F6_ToolLocation f6 = new F6_ToolLocation();
            f6.Show();
        }

        private void bLocate_Click(object sender, EventArgs e)
        {
            F61_LocateTools f61 = new F61_LocateTools();
            f61.Show();
        }

        private void bEditSetup_Click(object sender, EventArgs e)
        {
            //A2 f7 = new A2();
            //f7.Show();
            A3 f7 = new A3();
            
            f7.Show();
        }
        
    }

    public static class g
    {
        public static string userType;
        //public static string machineType;
        public static string userPermission;
        public static string SN;
        public static string ToolType;
        public static string task;
        public static string facility;
        public static string SetUp;

        public static string location;
        public static string Ldescription;
        public static string program;
        public static string item;
        public static string Rnotes;
        public static int rID;
        public static string machine;
        public static string iID;
        public static string iDescription;
        public static int internalCalContact;
        public static int cdID;                 //calibration data id
        public static string SSmachine;
        public static string SSpartname;
        public static string rpt_earliestDueDate;
        public static string rpt_latestDueDate;
        public static string rpt_room;
        public static string toolNumber;
        public static string grit;
        public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                                  "user = readwrite; database = OPTICs;";
        public static string dbAccess = "server = CT-MID-SQL11; password = Read+Write!; " +
                                 "user = readwrite; database = AccessFrontEnds;";
    }
}