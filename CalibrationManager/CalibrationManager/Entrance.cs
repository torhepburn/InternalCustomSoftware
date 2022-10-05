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
    public partial class Entrance : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        DataTable table;
        private int coordinator;
        
        public Entrance()
        {
            InitializeComponent();
        }

        private void Entrance_Load(object sender, EventArgs e)
        {
            this.Text = "System Overview v" + Application.ProductVersion;

            System.Security.Principal.WindowsIdentity user;
            user = System.Security.Principal.WindowsIdentity.GetCurrent();

            //if (g.userType.ToUpper() == "SYSTEM")
            //{
            //    cnxn = new SqlConnection(g.db);

            //    da = new SqlDataAdapter
            //        ("Select distinct e.ID, e.[Description] from " +
            //         " calibrationdata d left join equipment e on " +
            //         " d.item = e.id " +
            //         " left join itemuser u on " +
            //         " e.id = u.i_item " +
            //         " left join itemlocation l on " +
            //         " e.id = l.il_item " +
            //         " left join " + g.dbDash + " m " +
            //         " on u.i_user = m.badgeid " +
            //         " where l.il_location like 'ZAMS%' " +
            //         " and status = 'ACTIVE' " +
            //         " and m.name is null " +
            //         " order by e.ID asc", cnxn);
                
            //    table = new DataTable();
            //    da.Fill(table);
            //    if (table.Rows.Count > 0)
            //    {
            //        g.task = "ZAMSmissing";
            //        f052_Replace_User_Report f052 = new f052_Replace_User_Report();
            //        f052.ShowDialog();

            //        coordinator = 802;
            //        fixUser();
            //    }

            //    g.task = "ZAMSownerMissing";
            //    OwnerMissing();
            //    g.task = "";
            //}
            //else if (g.userType.ToUpper() == "SYSTEMAC")
            //{
            //    cnxn = new SqlConnection(g.db);

            //    da = new SqlDataAdapter
            //        ("Select distinct e.ID, e.[Description] from " +
            //         " calibrationdata d left join equipment e on " +
            //         " d.item = e.id " +
            //         " left join itemuser u on " +
            //         " e.id = u.i_item " +
            //         " left join itemlocation l on " +
            //         " e.id = l.il_item " +
            //         " left join  " + g.dbDash + " m " +
            //         " on u.i_user = m.badgeid " +
            //         " where l.il_location like 'AZT%' " +
            //         " and status = 'ACTIVE' " +
            //         " and m.name is null " +
            //         " order by e.ID asc", cnxn);

            //    table = new DataTable();
            //    da.Fill(table);
            //    if (table.Rows.Count > 0)
            //    {
            //        g.task = "AZTmissing";
            //        f052_Replace_User_Report f052 = new f052_Replace_User_Report();
            //        f052.ShowDialog();

            //        coordinator = 1964;
            //        fixUser();
            //    }

            //    g.task = "AZTownerMissing";
            //    OwnerMissing();
            //    g.task = "";

            //    bMiddlefield.Hide();
            //    bRichmond.Hide();
            //}
            //else
            //{
            //    bMiddlefield.Hide();
            //    bRichmond.Hide();
            //    bTucson.Hide();
            //    bCostaMesa.Hide();
            //    LogOn lo = new LogOn();
            //    lo.Show();
            //}
        }
        
        private void bMiddlefield_Click(object sender, EventArgs e)
        {
            g.facility = "ZAMS";
            GetSystem();
        }

        private void bTucson_Click(object sender, EventArgs e)
        {
            g.facility = "AZT";
            GetSystem();
        }

        private void bCostaMesa_Click(object sender, EventArgs e)
        {
            g.facility = "ZEOS";
            GetSystem();
        }

        private void bRichmond_Click(object sender, EventArgs e)
        {
            g.facility = "ZEP";
            GetSystem();
        }

        private void GetSystem()
        {
            f00_Start f = new f00_Start();
            f.Show();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fixUser()
        {
            DataTableReader dtr = table.CreateDataReader();

            while (dtr.Read())
            {
                cnxn = new SqlConnection(g.db);
                
                SqlCommand cmd = new SqlCommand("Update itemuser set " +
                    "i_user = " + coordinator +
                    "where " +
                    "I_item = '" + dtr.GetString(0).Trim() + "'", cnxn);
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();
            }
        }

        private void OwnerMissing()
        {
            da = new SqlDataAdapter("select l_id, e.name from " +
                    " location l " +
                    " left join  " + g.dbDash + " e " +
                    " on l.l_owner = e.badgeid where name is null and l_id not like 'AZT%' ", cnxn);
            table = new DataTable();
            da.Fill(table);
            if (table.Rows.Count > 0)
            {
                f052_Replace_User_Report f052 = new f052_Replace_User_Report();
                f052.Text = "Owner Missing";
                f052.ShowDialog();
            }

            DataTableReader dtr = table.CreateDataReader();

            while (dtr.Read())
            {
                cnxn = new SqlConnection(g.db);

                SqlCommand cmd = new SqlCommand("Update location set " +
                    "l_owner = " + coordinator +
                    "where " +
                    "L_ID = '" + dtr.GetString(0).Trim() + "'", cnxn);
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();
            }
        }
    }
}