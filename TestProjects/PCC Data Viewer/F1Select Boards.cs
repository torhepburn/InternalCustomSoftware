using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PCC_Data_Viewer
{
    public partial class f1_Select_Boards : Form
    {
        private string SQL1 = "([test station] = 'ZMI-4K-ITS' or " +
            "[test station] = 'ZMI-4K-ITS') and ";
        public f1_Select_Boards()
        {
            InitializeComponent();
        }

        private void bCEImcert_Click(object sender, EventArgs e)
        {
            v.select = "[test station] = 'ZMI-TEST-1' and " +
                " [board type] = 'ZMI 4104' and (sn = 618041 " +
                "or sn = 618042 or sn = 9145386) order by id desc";
            f2_View_Data grid = new f2_View_Data();
            grid.Show();
        }

        private void bCEIprod_Click(object sender, EventArgs e)
        {
            v.select = "[test station] = 'ZMI-TEST-1' and " +
                " [board type] = 'ZMI 4104' and (sn != 618041 " +
                " and sn != 618042 and sn != 9145386) order by id desc";
            f2_View_Data grid = new f2_View_Data();
            grid.Show();
        }

        private void bZygoMcert_Click(object sender, EventArgs e)
        {
            v.select = SQL1 +
            " [board type] = 'ZMI 4104' and (sn = 7382437 " +
            "or sn = 7262253 or sn = 7432600) order by id desc";
            f2_View_Data grid = new f2_View_Data();
            grid.Show();
        }

        private void bZygoProd_Click(object sender, EventArgs e)
        {
            v.select = SQL1 +
                "[board type] = 'ZMI 4104' and (sn != 7382437 " +
            "or sn != 7262253 or sn != 7432600) order by id desc";
            f2_View_Data grid = new f2_View_Data();
            grid.Show();
        }

        private void b4004CEImcert_Click(object sender, EventArgs e)
        {

        }

        private void b4004ZygoMcert_Click(object sender, EventArgs e)
        {
            v.select = SQL1 +
            " [board type] = 'ZMI 4004' and (sn = 07171748 " +
            "or sn = 07171756 or sn = 07151655) order by id desc";
            f2_View_Data grid = new f2_View_Data();
            grid.Show();
        }

        private void b4004CEIprod_Click(object sender, EventArgs e)
        {

        }

        private void b4004ZygoProd_Click(object sender, EventArgs e)
        {
            v.select = SQL1 +
                "[board type] = 'ZMI 4004' and (sn != 07171748 " +
            "or sn != 07171756 or sn != 07151655) order by id desc";
            f2_View_Data grid = new f2_View_Data();
            grid.Show();
        }

        private void f1_Select_Boards_Load(object sender, EventArgs e)
        {
            this.Text = "PCC Data Viewer Program v" + Application.ProductVersion.Trim();
        }

       
    }

    public static class v
    {
        public static string select;
    }
}