using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RMAX_TAB_A
{
    public partial class F2_Select_Operation : Form
    {
        public F2_Select_Operation()
        {
            InitializeComponent();
        }

        private void F2_Select_Operation_Load(object sender, EventArgs e)
        {
            bOp20.Visible = false;
            bOp30.Visible = false;
            bOp40.Visible = false;
            bOp45.Visible = false;
            bOp50.Visible = false;
            bOp60.Visible = false;
            bOp70.Visible = false;
            bOp75.Visible = false;
            bOp80.Visible = false;
            bOp90.Visible = false;
            bOp100.Visible = false;

            SqlConnection cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("  select " +
                 "  op10PF " +
                 " ,op20PF " +
                 " ,op30PF " +
                 " ,op40PF " +
                 " ,op45PF " +
                 " ,op50PF " +
                 " ,op60PF " +
                 " ,op70PF " +
                 " ,op75PF " +
                 " ,op80PF " +
                 " ,op90PF " +
                 "from CEA_RMAX_MIRROR_TAB_A where [part serial number] = " + g.serialNumber + " ", cnxn);

            DataTable table = new DataTable();

            da.Fill(table);

            if (table.Rows[0][0].ToString().Trim() == "PASS")
            {
                bOp20.Visible = true;
            }

            if (table.Rows[0].ItemArray[1].ToString().Trim() == "PASS")
            {
                bOp30.Visible = true;
            }

            if (table.Rows[0].ItemArray[2].ToString().Trim() == "PASS")
            {
                bOp40.Visible = true;
            }

            if (table.Rows[0].ItemArray[3].ToString().Trim() == "PASS")
            {
                bOp45.Visible = true;
            }

            if (table.Rows[0].ItemArray[4].ToString().Trim() == "PASS")
            {
                bOp50.Visible = true;
            }

            if (table.Rows[0].ItemArray[5].ToString().Trim() == "PASS")
            {
                bOp60.Visible = true;
            }

            if (table.Rows[0].ItemArray[6].ToString().Trim() == "PASS")
            {
                bOp70.Visible = true;
            }

            if (table.Rows[0].ItemArray[7].ToString().Trim() == "PASS")
            {
                bOp75.Visible = true;
            }

            if (table.Rows[0].ItemArray[8].ToString().Trim() == "PASS")
            {
                bOp80.Visible = true;
            }

            if (table.Rows[0].ItemArray[9].ToString().Trim() == "PASS")
            {
                bOp90.Visible = true;
            }

            if (table.Rows[0].ItemArray[10].ToString().Trim() == "PASS")
            {
                bOp100.Visible = true;
            }


        }

        private void bOp10_Click(object sender, EventArgs e)
        {
            F3_Op10 op10 = new F3_Op10();
            op10.ShowDialog();
        }

        private void bOp20_Click(object sender, EventArgs e)
        {
            F4_Op20 op20 = new F4_Op20();
            op20.ShowDialog();
        }

        private void bOp30_Click(object sender, EventArgs e)
        {
            F5_Op30 op30 = new F5_Op30();
            op30.ShowDialog();
        }

        private void bOp40_Click(object sender, EventArgs e)
        {
            F6_Op40 op40 = new F6_Op40();
            op40.ShowDialog();
        }

        private void bOp45_Click(object sender, EventArgs e)
        {
            F7_Op45 op45 = new F7_Op45();
            op45.ShowDialog();
        }

        private void bOp50_Click(object sender, EventArgs e)
        {
            F8_Op50 op50 = new F8_Op50();
            op50.ShowDialog();
        }

        private void bOp60_Click(object sender, EventArgs e)
        {
            F9_Op60 op60 = new F9_Op60();
            op60.ShowDialog();
        }

        private void bOp70_Click(object sender, EventArgs e)
        {
            F10_Op70 op70 = new F10_Op70();
            op70.ShowDialog();
        }

        private void bOp75_Click(object sender, EventArgs e)
        {
            F11_Op75 op75 = new F11_Op75();
            op75.ShowDialog();
        }

        private void bOp80_Click(object sender, EventArgs e)
        {
            F12_Op80 op80 = new F12_Op80();
            op80.ShowDialog();
        }

        private void bOp90_Click(object sender, EventArgs e)
        {
            F13_Op90 op90 = new F13_Op90();
            op90.ShowDialog();
        }

        private void bOp100_Click(object sender, EventArgs e)
        {
            F14_Op100 op100 = new F14_Op100();
            op100.ShowDialog();
        }

        
    }
}
