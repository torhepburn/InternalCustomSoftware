using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CalibrationManager
{
    public partial class f01_Task : Form
    {
        public f01_Task()
        {
            InitializeComponent();
        }

        private void f01_Task_Load(object sender, EventArgs e)
        {
            g.eBadgeID = "";
            g.room = "";
            g.location = "";
            g.Ldescription = "";
            this.Text = g.item;

            if (g.item == "Room")
            {
                bOwnerUser.Visible = false;
                bLocation.Visible = false;
                this.Size = new Size(571, 330);
            }
            if (g.item == "Equipment")
            {
                LownerButtonWarning.Visible = true;
                bOwnerUser.Text = "USER";
                //this.Size = new Size(571,430);
                
            }
            if (g.item == "Location")
            {
                bOwnerUser.Text = "OWNER";
                bLocation.Visible = false;
                this.Size = new Size(571, 330);
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            g.task = "Add";

            if (g.item == "Equipment")
            {
                f31_EquipmentID f31 = new f31_EquipmentID();
                f31.Show();
            }
            if (g.item == "Location")
            {
                g.location = "";
                g.Ldescription = "";
                f16_Select_Rooms f6 = new f16_Select_Rooms();
                f6.Show();
            }
            if (g.item == "Room")
            {
                f40_Room ar = new f40_Room();
                ar.Show();
            }
            if (g.item == "Report")
            {

            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            g.task = "Delete";

            if (g.item == "Equipment")
            {
                f51_Equipment f5 = new f51_Equipment();
                f5.Show();
            }
            if (g.item == "Location")
            {
                f17a_Select_Bench f7 = new f17a_Select_Bench();
                f7.Show();
            }
            if (g.item == "Room")
            {
                f16_Select_Rooms sr = new f16_Select_Rooms();
                sr.Show();
            }
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            g.task = "Edit";

            if (g.item == "Equipment")
            {
                g.iID = "";
                f51_Equipment f5 = new f51_Equipment();
                f5.Show();
            }
            if (g.item == "Location")
            {
                g.location = "";
                g.Ldescription = "";
                f17a_Select_Bench f7 = new f17a_Select_Bench();
                f7.Show();
            }
            if (g.item == "Room")
            {
                f16_Select_Rooms sr = new f16_Select_Rooms();
                sr.Show();
            }
            if (g.item == "Report")
            {

            }
        }

        private void bOwner_Click(object sender, EventArgs e)
        {
            g.task = "Owner";
            g.iID = "";
            f04_Owner f4 = new f04_Owner();
            f4.Show();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bLocation_Click(object sender, EventArgs e)
        {
            g.task = "Location";
            g.iID = "";
            f04a_Item_Location f4a = new f04a_Item_Location();
            f4a.Show();
        }
    }
}