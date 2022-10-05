using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CalibrationManager
{
    
    public partial class f0_Entry_Point : Form
    {
        public f0_Entry_Point()
        {
            InitializeComponent();
        }

        private void f0_Entry_Point_Load(object sender, EventArgs e)
        {
            if (g.userType == "system" | g.userType == "systemAC")
            {
                bSpecial.Visible = true;
            }
        }

        private void bEquipment_Click(object sender, EventArgs e)
        {
            g.item = "Equipment";
            f01_Task T = new f01_Task();
            T.Show();
        }

        private void bLOCATION_Click(object sender, EventArgs e)
        {
            g.item = "Location";
            f01_Task T = new f01_Task();
            T.Show();
        }

        private void bRoom_Click(object sender, EventArgs e)
        {
            g.item = "Room";
            f01_Task T = new f01_Task();
            T.Show();
        }

        private void bSpecial_Click(object sender, EventArgs e)
        {
            f05_Special_Functions s = new f05_Special_Functions();
            s.Show();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

   
    
}