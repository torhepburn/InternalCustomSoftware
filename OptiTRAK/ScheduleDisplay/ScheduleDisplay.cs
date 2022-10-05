using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ScheduleDisplay
{
    public partial class ScheduleDisplay : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        //DataTable dt;
        DataTable dt2;
        
        public ScheduleDisplay()
        {
            InitializeComponent();
        }

        private void ScheduleDisplay_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            //da = new SqlDataAdapter("select distinct " +
            //      "customer, " +
            //      "project, " +
            //      "elementname, " +
            //      "partdrawingnumber + partdrawingrev item_code," +
            //      "partsn, " +
            //      "prodordnum " +
            //      "from  uScheduleStatus ss " +
            //      "inner join tblPartSN p on ss.PartID = p.PartID " +
            //      "inner join tblWorkIns w on ss.WorkID = w.WorkID " +
            //      "inner join tblDept d on w.DeptID = d.DeptID " +
            //      "inner join tblJobInfo j on p.JobID = j.JobID " +
            //      "where partpoclosed = 0 " +
            //      "and JobComplete = 0 " +
            //      "order by customer, project, ElementName, partsn ", cnxn);

            //try
            //{
                dt2 = new DataTable();
            //    da.Fill(dt2);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("dt2 " + ex.ToString());
            //}

            da = new SqlDataAdapter("select * from r1 order by sfo", cnxn);
            //      "customer, " +
            //      "project, " +
            //      "elementname, " +
            //      "partsn, " +
            //      "prodordnum " +
            //      "from  uScheduleStatus ss " +
            //      "inner join tblPartSN p on ss.PartID = p.PartID " +
            //      "inner join tblWorkIns w on ss.WorkID = w.WorkID " +
            //      "inner join tblDept d on w.DeptID = d.DeptID " +
            //      "inner join tblJobInfo j on p.JobID = j.JobID " +
            //      "where partpoclosed = 0 " +
            //      "and JobComplete = 0 " +
            //      "order by customer, project, ElementName, partsn ", cnxn);

            try
            {
                //DataTable dt = new DataTable();
                da.Fill(dt2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("dt " + ex.ToString());
            }

            DGV.DataSource = dt2;

            for (int i = 0; i < DGV.Columns.Count; i++)
            {
                DGV.Columns[i].Width = 60;
            }

            DGV.Show();

        }
    }

    public static class g
    {
        public static DateTime loadDate;
        public static string workcell;
        public static DateTime startDate;
        public static DateTime endDate;
        public static int granularFactor;
        public static string granularity;
        public static DataTable dt;
        public static string db = "server = midsql01; password = Read+Write!; " +
                            "user = readwrite; database = OptiTRAK;";

    }

}
