using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KanbanRaw
{
    public partial class RawKbData : Form
    {
        SqlConnection cnxn;
        private string db = "server = midsql01; password = Read+Write!; " +
                            "user = readwrite; database = OptiTRAK;";
        DataTable dt;
        
        public RawKbData()
        {
            InitializeComponent();
        }

        private void RawKbData_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);


            SqlDataAdapter da = new SqlDataAdapter(
                "select * from kanbanraw " +
                "order by dbo.sc_sortableversionstring(partsn)", cnxn);
            //        "deptcode Dept, " +
            //        "Description, " +
            //        "CycleDays Cycle, " +
            //        "CmpAdjDays, " +
            //        "Duedate as 'Est/Act Date', " +
            //        "PlnDueDate PlanDate, " +
            //        "currentrecord, " +
            //        "processstatusid, " +
            //        "opstart " +
            //        "from uScheduleStatus ss " +
            //        "inner join tblWorkIns w on ss.workid = w.workid " +
            //        "inner join tblDept d " +
            //        "on w.deptid = d.deptid " +
            //        "inner join tblpartsn p " +
            //        "on ss.partid = p.partid " +
            //        "where p.jobid = " + g.jobID + " " +
            //        "and partpoclosed = 0 " +
            //        " order by opnum ", cnxn);

           //cnxn.Close();

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
