using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CalibrationManager
{
    public partial class f50_View_Selection : Form
    {
        public f50_View_Selection()
        {
            InitializeComponent();
        }

        private void bEquipment_Click(object sender, EventArgs e)
        {
            g.task = "Equipment";
            g.item = "Reports";
            f51_Equipment f51 = new f51_Equipment();
            f51.Show();
        }

        private void bRooms_Click(object sender, EventArgs e)
        {
            f16ViewRooms V = new f16ViewRooms();
            V.Show();
        }

        private void bDueById_Click(object sender, EventArgs e)
        {
            f03_View f = new f03_View();
            f.Show();
            
        }

        private void bDueByCalSource_Click(object sender, EventArgs e)
        {
            f71_Due_by_Cal_Source s = new f71_Due_by_Cal_Source();
            s.Show();
        }

        private void bStatusCode_Click(object sender, EventArgs e)
        {
            f65_View_Status_Codes f65 = new f65_View_Status_Codes();
            f65.Show();
            
        }

        private void bLocations_Click(object sender, EventArgs e)
        {
            f17a_Select_Bench f17a = new f17a_Select_Bench();
            f17a.Show();
            
        }

        private void bSNLabel_Click(object sender, EventArgs e)
        {
            g.item = "Serial Number Label";
            g.task = "Print";
            f51_Equipment fs = new f51_Equipment();
            fs.Show();
            
        }

        private void bBarCodeLabel_Click(object sender, EventArgs e)
        {
            g.item = "Bar Code Label";
            g.task = "Print";
            f51_Equipment fs = new f51_Equipment();
            fs.Show();
            
        }

        private void bDuebyRoom_Click(object sender, EventArgs e)
        {
            f72_Cal_Due_by_Room rm = new f72_Cal_Due_by_Room();
            rm.Show();
        }

        private void bCert_Click(object sender, EventArgs e)
        {
            g.item = "Cert";
            g.task = "List";
            f51_Equipment eq = new f51_Equipment();
            eq.Show();
        }

        private void bRisk_Click(object sender, EventArgs e)
        {
            g.item = "Risk";
            g.task = "List";
            f51_Equipment eq = new f51_Equipment();
            eq.Show();
        }

        private void bDocs_Click(object sender, EventArgs e)
        {
            g.item = "Docs";
            g.task = "List";
            f51_Equipment eq = new f51_Equipment();
            eq.Show();
        }

        private void bRepair_Click(object sender, EventArgs e)
        {
            g.item = "Repair";
            g.task = "List";
            f51_Equipment eq = new f51_Equipment();
            eq.Show();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bMasterEquipmentList_Click(object sender, EventArgs e)
        {
            f54_List_Format_Report f54 = new f54_List_Format_Report();
            f54.Show();
        }

        private void bCust_Click(object sender, EventArgs e)
        {
            CustomerOwned_Equipment cust = new CustomerOwned_Equipment();
            cust.Show();
        }

        private void bOver_Click(object sender, EventArgs e)
        {
            f55_Overdue f55 = new f55_Overdue();
            f55.Show();
        }

        private void bFindModel_Click(object sender, EventArgs e)
        {
            f73_Model_Search f73 = new f73_Model_Search();
            f73.Show();
        }

        private void bVersionHistory_Click(object sender, EventArgs e)
        {
            f74_Version_History f74 = new f74_Version_History();
            f74.Show();
        }
    }
}