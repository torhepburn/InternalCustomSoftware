using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ResourceLoadperDate
{
    public partial class ResourceLoad : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable dt;
        SqlCommand cmd;
        private string db = "server = midsql01; password = Read+Write!; " +
                            "user = readwrite; database = OptiTRAK;";
        public ResourceLoad()
        {
            InitializeComponent();
        }

        private void ResourceLoad_Load(object sender, EventArgs e)
        {
            //cnxn = new SqlConnection(db);

            //da = new SqlDataAdapter(
            //    "select distinct j.JobID, Customer, Project, ElementName, PartDrawingNumber, " +
            //    "PartDrawingRev, TravelerRev from tblJobInfo j " +
            //    "inner join tblPartSN p on j.JobID = p.JobID " +
            //    "where " +
            //    "(JobComplete = 0  and EXISTS " +
            //    "(select jobid from tblworkins where jobid = j.jobid) ) " +
            //    "and EXISTS (select partid from uScheduleStatus where partid = p.partid) " +
            //    "and partpoclosed = 0 " +
            //    "order by customer, project, elementname", cnxn);
            //try
            //{
            //    dt = new DataTable();
            //    da.Fill(dt);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}

            //DGV.DataSource = dt;
            //DGV.Show();
        }

            

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            da = new SqlDataAdapter
                ("select " +
                 "customer, " +
                 "project, " +
                 "elementname, " +
                 "DeptCode WorkCenter, " +
                 "Description, " +
                 "Duedate, " +
                 "CycleDays, " +
                 "CmpAdjDays " +
                 "from uScheduleStatus ss " +
                 "left join tblPartSN p on ss.PartID = p.PartID " +
                 "left join tblJobInfo j on p.JobID = j.JobID " +
                 "left join tblWorkIns w on w.WorkID = ss.WorkID " +
                 "left join tblDept d on w.DeptID = d.DeptID " +
                 "where duedate = ' " + tbSearch.Text.Trim() + "' " +
                 "and PartPOClosed = 0 " +
                 "and JobComplete = 0 " +
                 "order by WorkCenter, customer, project, ElementName", cnxn);
            try
            {
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DGV.DataSource = dt;
            DGV.Show();
        }

    }
}
