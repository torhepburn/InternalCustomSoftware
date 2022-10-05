using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CalibrationManager
{
    public partial class f052_Replace_User_Report : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        BindingSource bs = new BindingSource();
                
        public f052_Replace_User_Report()
        {
            InitializeComponent();
        }

        private void f052_Replace_User_Report_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            if (g.task == "ZAMSReport")
            {
                da = new SqlDataAdapter
                    ("Select distinct e.ID, e.[Description] from " +
                     " calibrationdata d left join equipment e on " +
                     " d.item = e.id " +
                     " left join itemuser u on " +
                     " e.id = u.i_item " +
                     " left join itemlocation l on " +
                     " e.id = l.il_item " +
                     " left join " + g.dbDash + " m " +
                     " on u.i_user = m.badgeid " +
                     " where l.il_location like 'ZAMS%' " +
                     " and status = 'ACTIVE' " +
                     " and m.badgeid =  802 " +
                     " order by e.ID asc", cnxn);

                label1.Text = "The following items show the Calibration Coordinator as the user.";
                this.Text = "f052 User Report";
            }
            else if (g.task == "AZTReport")
            {
                da = new SqlDataAdapter
                    ("Select distinct e.ID, e.[Description] from " +
                     " calibrationdata d left join equipment e on " +
                     " d.item = e.id " +
                     " left join itemuser u on " +
                     " e.id = u.i_item " +
                     " left join itemlocation l on " +
                     " e.id = l.il_item " +
                     " left join " + g.dbDash + " m " +
                     " on u.i_user = m.badgeid " +
                     " where l.il_location like 'AZT%' " +
                     " and status = 'ACTIVE' " +
                     " and m.badgeid =  1964 " +
                     " order by e.ID asc", cnxn);

                label1.Text = "The following items show the Calibration Coordinator as the user.";
                this.Text = "f052 User Report";
            }
            else if (g.task == "ZAMSmissing")
            {
                da = new SqlDataAdapter
                    ("Select distinct e.ID, e.[Description] from " +
                     " calibrationdata d left join equipment e on " +
                     " d.item = e.id " +
                     " left join itemuser u on " +
                     " e.id = u.i_item " +
                     " left join itemlocation l on " +
                     " e.id = l.il_item " +
                     " left join " + g.dbDash + " m " +
                     " on u.i_user = m.badgeid " +
                     " where l.il_location like 'ZAMS%' " +
                     " and status = 'ACTIVE' " +
                     " and m.name is null " +
                     " order by e.ID asc", cnxn);
            }
            else if (g.task == "AZTmissing")
            {
                da = new SqlDataAdapter
                    ("Select distinct e.ID, e.[Description] from " +
                     " calibrationdata d left join equipment e on " +
                     " d.item = e.id " +
                     " left join itemuser u on " +
                     " e.id = u.i_item " +
                     " left join itemlocation l on " +
                     " e.id = l.il_item " +
                     " left join " + g.dbDash + " m " +
                     " on u.i_user = m.badgeid " +
                     " where l.il_location like 'AZT%' " +
                     " and status = 'ACTIVE' " +
                     " and m.name is null " +
                     " order by e.ID asc", cnxn);
            }
            else if (g.task == "AZTownerMissing")
            {
                da = new SqlDataAdapter
                    ("Select l.l_id, l.l_description from " +
                     "location l " +
                     " left join " + g.dbDash + " e " +
                     " on l.l_owner = e.badgeid " +
                     " where name is null and l_id like 'AZT%'", cnxn);
            }
            else if (g.task == "AZTownerReport")
            {
                da = new SqlDataAdapter
                    ("Select l.l_id, l.l_description from " +
                     "location l " +
                     " where l_id like 'AZT%' and l_owner = 1964", cnxn);
                label1.Text = "The following locations show the Calibration Coordinator as the owner.";
                this.Text = "f052 Owner Report";
            }
            else if (g.task == "ZAMSownerMissing")
            {
                da = new SqlDataAdapter
                    ("Select l.l_id, l.l_description from " +
                     "location l " +
                     " left join " + g.dbDash + " e " +
                    " on l.l_owner = e.badgeid " +
                     " where name is null and l_id like 'ZAMS%'", cnxn);
            }
            else if (g.task == "ZAMSownerReport")
            {
                da = new SqlDataAdapter
                    ("Select l.l_id, l.l_description from " +
                     "location l " +
                     " where l_id like 'ZAMS%' and l_owner = 802", cnxn);
                label1.Text = "The following locations show the Calibration Coordinator as the owner.";
                this.Text = "f052 Owner Report";
            }


            if (da != null)
            {
                DataTable table = new DataTable();
                da.Fill(table);
                bs.DataSource = table;
                DGV.DataSource = bs;
             }
        }
    }
}