using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PlannerCurrentStatus
{
    public partial class CurrentStatus : Form
    {
        SqlConnection cnxn;
        DataTable dt;
        SqlDataAdapter da;
                
        public CurrentStatus()
        {
            InitializeComponent();
        }

        private void CurrentStatus_Load(object sender, EventArgs e)
        {
            this.Text = "Current Status v" + Application.ProductVersion;

            cnxn = new SqlConnection(g.db);

            cnxn.Open();
            da = new SqlDataAdapter(g.basicselect + g.basicsort, cnxn);

            griddisplay();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            da = new SqlDataAdapter
                (g.basicselect  +
                "where customer like '%" + tbCustomer.Text.Trim() + "%'  " +
                "and project like '%" + tbProject.Text.Trim() + "%'  " +
                "and elementname like '%" + tbElement.Text.Trim() + "%'  " +
                "and plannerinitials like '%" + tbPlanner.Text.Trim() + "%'  " +
                g.basicsort, cnxn);
            //planner, customer, project, elementname, dbo.sc_sortableversionstring(partsn)", cnxn);

            g.tbSearchCustomer = tbCustomer.Text.Trim();
            g.tbSearchProject = tbProject.Text.Trim();
            g.tbSearchElement = tbElement.Text.Trim();
            g.tbSearchPlanner = tbPlanner.Text.Trim();

            griddisplay();
            
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            ReportForm r = new ReportForm();
            r.ShowDialog();
        }

        private void griddisplay()
        {
            dt = new DataTable();
            da.Fill(dt);

            cnxn.Close();

            DGV.DataSource = dt;

            DGV.Columns[0].Width = 40;
            DGV.Columns[1].Width = 90;
            DGV.Columns[2].Width = 120;
            DGV.Columns[3].Width = 70;
            DGV.Columns[4].Width = 150;
            DGV.Columns[5].Width = 70;
            DGV.Columns[6].Width = 70;
            DGV.Columns[7].Width = 50;
            DGV.Columns[8].Width = 250;
            DGV.Columns[9].Width = 90;
            DGV.Columns[10].Width = 70;
            DGV.Columns[11].Width = 50;
            DGV.Columns[12].Width = 70;
            DGV.Columns[13].Width = 70;
            DGV.Columns[14].Width = 70;
            DGV.Columns[15].Width = 70;
            DGV.Columns[16].Width = 50;
            DGV.Columns[17].Width = 70;

            foreach (DataGridViewRow gr in DGV.Rows)
            {
                if (gr.Cells[9].Value.ToString() == "Waiting")
                {
                    gr.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else if (Convert.ToString(gr.Cells[9].Value) == "Active")
                {
                    gr.DefaultCellStyle.BackColor = Color.Yellow;

                }
                else if (Convert.ToString(gr.Cells[9].Value) == "Complete")
                {
                    gr.DefaultCellStyle.BackColor = Color.Gray;

                }
                else
                {
                    gr.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }

            DGV.Show();

        }

        private void Lplanner_Click(object sender, EventArgs e)
        {

        }

        private void bExplanatoryText_Click(object sender, EventArgs e)
        {
            ExplanatoryText et = new ExplanatoryText();
            et.Show();
        }
    }

    public static class g
    {
        public static string tbSearchCustomer;
        public static string tbSearchProject;
        public static string tbSearchElement;
        public static string tbSearchPlanner;
        public static string customer;
        public static string project;
        public static string element;
        public static string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = OptiTRAK;";
        public static string basicselect = "select " +
                "PlannerInitials as Planner, " +
                "Customer, " +
                "Project, " +
                "SFO, " +
                "ElementName, " +
                "PartSN as ID, " +
                "DeptCode as [Work Center], " +
                "OpNum as [Op Num], " +
                "Description, " +
                "Status, " +
                "convert (char(8),OpStart,1) as Start, " +
                "CycleDays as [Cycle Days], " +
                "convert (char(8),EstDone,1) as [Est Done], " +
                "convert (char(8),PlanDue,1) as [Plan Due], " +
                "convert (char(8),ProjectedShipDate,1) as [Proj Delvry], " +
                "convert (char(8),PlDlvry,1) as [Plan Delvry], " +
                "Delta, " +
                "convert (char(8),Curr_Req_DT,1) as [Current Req] " +
                "from PlannerCurrentStatus ";
        public static string basicsort = "order by planner, customer, " +
            "project, elementname, dbo.sc_sortableversionstring(partsn)";

        //public static string basicsort = "order by costcenter, deptcode, " +
        //    "plandue, elementname, dbo.sc_sortableversionstring(partsn)";


    }
}
