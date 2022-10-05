using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CalibrationManager
{
    public partial class f05_Special_Functions : Form
    {
        public f05_Special_Functions()
        {
            InitializeComponent();
        }

        private void bSetCalIntervalbyType_Click(object sender, EventArgs e)
        {
            f63_Calibration_Interval I = new f63_Calibration_Interval();
            I.Show();
            Close();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bCalSource_Click(object sender, EventArgs e)
        {
            f051_Cal_Source_Modification f051 = new f051_Cal_Source_Modification();
            f051.Show();
        }

        private void bCoordinatorUser_Click(object sender, EventArgs e)
        {
            if (g.facility == "ZAMS")
            {
                g.task = "ZAMSReport";
            }
            else if (g.facility == "AZT")
            {
                g.task = "AZTReport";
            }
            f052_Replace_User_Report f052 = new f052_Replace_User_Report();
            f052.Show();
        }

        private void bLocationOwner_Click(object sender, EventArgs e)
        {
            if (g.facility == "ZAMS")
            {
                g.task = "ZAMSownerReport";
            }
            else if (g.facility == "AZT")
            {
                g.task = "AZTownerReport";
            }
            f052_Replace_User_Report f052 = new f052_Replace_User_Report();
            f052.Show();
        }

        private void bAddUser_Click(object sender, EventArgs e)
        {
            g.item = "NewUser";
            f21_Select_Employees f21 = new f21_Select_Employees();
            f21.Show();
        }

        private void bDeleteUser_Click(object sender, EventArgs e)
        {
            f054_Delete_User f54 = new f054_Delete_User();
            f54.Show();
        }

        
    }
}