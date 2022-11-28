using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinterManager
{
    public partial class ActionSelection : Form
    {
        public ActionSelection()
        {
            InitializeComponent();
        }

        private void ActionSelection_Load(object sender, EventArgs e)
        {
            this.Text = "Printer Manager Program v" + Application.ProductVersion.Trim();

            System.Security.Principal.WindowsIdentity userBase;
            userBase = System.Security.Principal.WindowsIdentity.GetCurrent();

            string user = string.Empty;

            if (userBase.Name.IndexOf("Z") == 0)
            {
                user = userBase.Name.ToUpper().Replace("ZYGOMIS\\", "");
            }
            else
            {
                user = userBase.Name.ToUpper().Replace("AMETEK-AD\\", "");
            }

            if (user != "THEPBURN" & user != "THEPBURN-SA" & user != "BPRESTASH" & user != "JEFFERY.PORTER" & user != "RZAYAN" & user != "JDIMAURO" & user != "BPLATOSZ")
            {
                MessageBox.Show("You are not logged in as Thepburn, BPrestash, Jeffery.Porter, RZayan, BPlatosz, or JDiMauro");
                
                this.Close();
            }

        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            g.task = "ADD";
            EditData ed = new EditData();
            ed.ShowDialog();
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            SelectPrinter p = new SelectPrinter();
            g.task = "EDIT";
            p.ShowDialog();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public static class g
    {
        public static string queryBase = "SELECT " +
                "TRIM(PCID) Computer " +
                ",TRIM(UserName) [Log In] " +
                ",TRIM(Application) Application " +
                ",TRIM(PermissionValue) Printer " +
                ",TRIM(Location) Location " +
                ",ID " +
                ",ZPL " +
                "FROM ApplicationSetup ";
        public static string computer;
        public static string login;
        public static string application;
        public static string location;
        public static string ID;
        public static string task;
        public static bool ZPL;
        public static string printer;
        public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";
        
    }
}
