using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CalendarChart
{
    public partial class CalendarChart : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable dt;
        DataTable dt2;
        private string db = "server = midsql01; password = Read+Write!; " +
                            "user = readwrite; database = OptiTRAK;";
        private string[] newRow;
        

        public CalendarChart()
        {
            InitializeComponent();
        }

        private void CalendarChart_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            da = new SqlDataAdapter
                ("with s1 as " +
                 "( " +
                 "select " +
                 "CONVERT(nchar(10), runningdate, 1) RunningDate, " +
                 "d.DeptCode WorkCenter, " +
                 "count(d.deptcode) multiplier " +
                 //"d.DeptDescription " +
                 "from ScheduledRunningDates rd " +
                 "left join uScheduleStatus ss on rd.ssid = ss.ssid " +
                 "left join tblPartSN p on ss.PartID = p.PartID " +
                 "left join tblJobInfo j on p.JobID = j.JobID " +
                 "left join tblWorkIns w on w.WorkID = ss.WorkID " +
                 "left join tblDept d on w.DeptID = d.DeptID " +
                 "where  " +
                 "PartPOClosed = 0 " +
                 "and JobComplete = 0 " +
                 "group by RunningDate, d.DeptCode, D.DeptDescription " +
                 ") " +
                 "select top 20 " +
                 "RunningDate, " +
                 "WorkCenter, " +
                 //"DeptDescription, " +
                 "IIF(Prorate is null, .1, prorate) * (multiplier * 100) PerCentUsed " +
                 "from s1 s left join WorkCenterCapacity c " +
                 "on s.WorkCenter = c.WORK_CENTER " +
                 "where runningDate > GETDATE() " + 
                 "and s.workcenter = 'r07' " +
                 "order by runningdate", cnxn);
            try
            {
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            dt2 = new DataTable();

            DataColumn[] cols =
                {
                    //for (int i = 1; i<20; i++)
                    //{
                    //   new DataColumn(i.ToString(), typeof(string)), 
                    //}
                    new DataColumn("1", typeof(string)),
                    new DataColumn("2", typeof(string)),
                    new DataColumn("3", typeof(string)),
                    new DataColumn("4", typeof(string)),
                    new DataColumn("5", typeof(string)),
                    new DataColumn("6", typeof(string)),
                    new DataColumn("7", typeof(string)),
                    new DataColumn("8", typeof(string)),
                    new DataColumn("9", typeof(string)),
                    new DataColumn("10", typeof(string)),
                    new DataColumn("11", typeof(string)),
                    new DataColumn("12", typeof(string)),
                    new DataColumn("13", typeof(string)),
                    new DataColumn("14", typeof(string)),
                    new DataColumn("15", typeof(string)),
                    new DataColumn("16", typeof(string)),
                    new DataColumn("17", typeof(string)),
                    new DataColumn("18", typeof(string)),
                    new DataColumn("19", typeof(string)),
                    new DataColumn("20", typeof(string))
                };
            
            dt2.Columns.AddRange(cols);

            Object[] rows = {
                                new Object[]{dt.Rows[0][0].ToString(),
                                             dt.Rows[1][0].ToString(),
                                             dt.Rows[2][0].ToString(),
                                             dt.Rows[3][0].ToString(),
                                             dt.Rows[4][0].ToString(),
                                             dt.Rows[5][0].ToString(),
                                             dt.Rows[6][0].ToString(),
                                             dt.Rows[7][0].ToString(),
                                             dt.Rows[8][0].ToString(),
                                             dt.Rows[9][0].ToString(),
                                             dt.Rows[10][0].ToString(),
                                             dt.Rows[11][0].ToString(),
                                             dt.Rows[12][0].ToString(),
                                             dt.Rows[13][0].ToString(),
                                             dt.Rows[14][0].ToString(),
                                             dt.Rows[15][0].ToString(),
                                             dt.Rows[16][0].ToString(),
                                             dt.Rows[17][0].ToString(),
                                             dt.Rows[18][0].ToString(),
                                             dt.Rows[19][0].ToString()},
                                new Object[]{dt.Rows[0][1].ToString(),
                                             dt.Rows[1][1].ToString(),
                                             dt.Rows[2][1].ToString(),
                                             dt.Rows[3][1].ToString(),
                                             dt.Rows[4][1].ToString(),
                                             dt.Rows[5][1].ToString(),
                                             dt.Rows[6][1].ToString(),
                                             dt.Rows[7][1].ToString(),
                                             dt.Rows[8][1].ToString(),
                                             dt.Rows[9][1].ToString(),
                                             dt.Rows[10][1].ToString(),
                                             dt.Rows[11][1].ToString(),
                                             dt.Rows[12][1].ToString(),
                                             dt.Rows[13][1].ToString(),
                                             dt.Rows[14][1].ToString(),
                                             dt.Rows[15][1].ToString(),
                                             dt.Rows[16][1].ToString(),
                                             dt.Rows[17][1].ToString(),
                                             dt.Rows[18][1].ToString(),
                                             dt.Rows[19][1].ToString()},
                                new Object[]{dt.Rows[0][2].ToString(),
                                             dt.Rows[1][2].ToString(),
                                             dt.Rows[2][2].ToString(),
                                             dt.Rows[3][2].ToString(),
                                             dt.Rows[4][2].ToString(),
                                             dt.Rows[5][2].ToString(),
                                             dt.Rows[6][2].ToString(),
                                             dt.Rows[7][2].ToString(),
                                             dt.Rows[8][2].ToString(),
                                             dt.Rows[9][2].ToString(),
                                             dt.Rows[10][2].ToString(),
                                             dt.Rows[11][2].ToString(),
                                             dt.Rows[12][2].ToString(),
                                             dt.Rows[13][2].ToString(),
                                             dt.Rows[14][2].ToString(),
                                             dt.Rows[15][2].ToString(),
                                             dt.Rows[16][2].ToString(),
                                             dt.Rows[17][2].ToString(),
                                             dt.Rows[18][2].ToString(),
                                             dt.Rows[19][2].ToString()},
                                };

            foreach (Object[] row in rows)
            {
                dt2.Rows.Add(row);
            }

                            


            //foreach (DataRow row in dt.Rows)
            //{
            //    newRow = new string[4];
            //    newRow[0] = row[3].ToString();
            //    newRow[1] = row[2].ToString();
            //    newRow[2] = row[1].ToString();
            //    newRow[3] = row[0].ToString();

            //    DataRow nextRow = dt2.NewRow();
            //    nextRow.ItemArray = newRow;
            //    dt2.Rows.Add(newRow);
            //}

            
            DGV.DataSource = dt2;
            DGV.Show();
            for (int i = 0; i<20; i++)
            {
                DGV.Columns[i].Width=60;
            }
            //DGV.Columns[0].Width=60;
        }
    }
}
