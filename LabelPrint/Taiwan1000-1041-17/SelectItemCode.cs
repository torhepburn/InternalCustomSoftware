using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taiwan1000_1041_17
{
    public partial class SelectItemCode : Form
    {
        public SelectItemCode()
        {
            InitializeComponent();
        }

        private void SelectItemCode_Load(object sender, EventArgs e)
        {
            this.Text = "Pendant Serial Number Label 1000-1041-17 rev C";
        }

        private void B01_Click(object sender, EventArgs e)
        {
            g.model = "NX2 PENDANT";
            g.item = "6450-8509-01";
            /*  USING VOLTS FIELD FOR REV  */
            //g.volts = "B";
            SelectedLabel4117 s1 = new SelectedLabel4117();
            s1.ShowDialog();
        }

        private void B11_Click(object sender, EventArgs e)
        {
            g.model = "NEXVIEW PENDANT";
            g.item = "6450-8504-04";
            /*  USING VOLTS FIELD FOR REV  */
            //g.volts = "A";
            SelectedLabel4117 s1 = new SelectedLabel4117();
            s1.ShowDialog();
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
        public static string printer;
        //public static string db = "server = midsql01; password = Read+Write!; " +
        //                          "user = readwrite; database = AccessFrontEnds;";
    }
}
