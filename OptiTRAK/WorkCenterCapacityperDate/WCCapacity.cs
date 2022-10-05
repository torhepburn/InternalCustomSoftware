using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkCenterCapacityperDate
{
    public partial class WCCapacity : Form
    {
        public WCCapacity()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            g.loadDate = e.Start;
            DisplayData d = new DisplayData();
            d.Show();
        }

        private void WCCapacity_Load(object sender, EventArgs e)
        {

        }
    }

    public static class g
    {
        public static DateTime loadDate;
        public static string workcell;
        //public static string taskhistory;
        //public static string userType;
        public static string db = "server = midsql01; password = Read+Write!; " +
                            "user = readwrite; database = OptiTRAK;";
        
    }

}
