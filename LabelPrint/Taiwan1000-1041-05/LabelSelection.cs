using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taiwan1000_1041_05
{
    public partial class LabelSelection : Form
    {
        public LabelSelection()
        {
            InitializeComponent();
        }

        private void LabelSelection_Load(object sender, EventArgs e)
        {
            label1.Text = "Program Version: " + Application.ProductVersion;
            B01.Visible = false;
            B11.Visible = false;
            bFreeText.Text = "Taiwan NV9000";
        }

        private void B01_Click(object sender, EventArgs e)
        {
            g.item = "6311-0100-01";
            g.description = "NEWVIEW 9000 PROFILER SYSTEM";
            g.model = "NEWVIEW 9000";
            g.hertz = @"50/60";
            g.volts = "100-240";
            g.amps = "2";

            SelectedLabel sl = new SelectedLabel();
            sl.ShowDialog();
        }

        private void B11_Click(object sender, EventArgs e)
        {
            g.item = "6311-0100-11";
            g.description = "NV 9K W/O ISOLATION";
            g.model = "NEWVIEW 9000";
            g.hertz = @"50/60";
            g.volts = "100-240";
            g.amps = "2";

            SelectedLabel sl = new SelectedLabel();
            sl.ShowDialog();
        }

        private void bFreeText_Click(object sender, EventArgs e)
        {
            g.freeText = true;
            g.item = "";
            g.description = "";
            g.model = "";
            g.hertz = "";
            g.volts = "";
            g.amps = "";
            SelectedLabel sl = new SelectedLabel();
            sl.ShowDialog();
        }

        
    }

    public static class g
    {
        public static string item;
        public static string description;
        public static string hertz;
        public static string volts;

        public static string amps;
        public static string model;
        public static bool freeText;
        /*  for Taiwan using local printer  */
        public static string printer = "Zebra2.25x1.25";
        //public static string printer = "ZDesigner GX430t";
        //public static string Ldescription;
        //public static string room;
        //public static string Rdescription;
        //public static string Rnotes;
        //public static int rID;
        //public static string eBadgeID;
        //public static string iID;
        //public static string iDescription;
        //public static int internalCalContact;
        //public static int cdID;                 //calibration data id
        //public static string rpt_status;
        //public static string rpt_CalSource;
        //public static string rpt_earliestDueDate;
        //public static string rpt_latestDueDate;
        //public static string rpt_room;
        //public static string rpt_type;
        //public static string pdf;
        //public static string db = "server = CT-MID-SQL01; password = Read+Write!; " +
        //                          "user = readwrite; database = AccessFrontEnds;";
        //public static string dbDash = "[middb01].dashboard.dbo.view_employees";
        //public static string dbDashserver = "server = middb01; password = views; " +
        //                          "user = views; database = dashboard;";
    }
}
