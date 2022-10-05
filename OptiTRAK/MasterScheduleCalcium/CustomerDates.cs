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

namespace MasterScheduleCalcium
{
    public partial class CustomerDates : Form
    {
        SqlConnection cnxn;
        DataTable dt = null;


        public CustomerDates()
        {
            InitializeComponent();
        }

        private void CustomerDates_Load(object sender, EventArgs e)
        {
            
                //  set up the connection

                cnxn = new SqlConnection(g.db);

                //  get the details for the top grid

                SqlDataAdapter da = new SqlDataAdapter(
                    "select " +
                    "CAST(prodordnum as nvarchar(255)) SFO, " +
                    "CONVERT(nvarchar(255), CAST(PLDlvry as date), 101) [Planned Delivery Date], " +
                    "CONVERT(nvarchar(255), CAST(Curr_req_dt as date), 101) [Customer Request Date], " +
                    "CONVERT(nvarchar(255), CAST(orig_prom_dt as date), 101) [Original Promise Date], " +
                    "CONVERT(nvarchar(255), CAST(ProjectedShipDate as date), 101) [Projected Ship Date], " +
                    "CONVERT(nvarchar(255), CAST(partreleasedate as date), 101) [Part Release Date], " +
                    "CAST(partsn as nvarchar(255)) [Part ID], " +
                    "CAST(pstatusdesc as nvarchar(255)) [Hold Status] " +
                    "from tblPartSN p " +
                    "left join tblSalesOrder s on p.soid = s.soid " +
                    "inner join tblJobInfo j on p.jobid = j.jobid " +
                    "left join tblProcessStatus ps on ps.processstatusid = p.holdstatid " +
                    "where partpoclosed = 0 " +
                    "and  j.JobComplete = 0 " +
                    "and p.JobID = " + g.jobID +
                    "order by partsn ", cnxn);

                try
                {
                    dt = new DataTable();
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("MaintianSchedules.cs line 130  " + ex.ToString());
                }

                DGV2.DataSource = dt;

                // set background color if the part is on hold
                for (int i = 0; i < DGV2.RowCount; i++)
                {
                    if (dt.Rows[i][7].ToString().IndexOf("No Hold") == -1)
                    {
                        DGV2.Rows[i].DefaultCellStyle.BackColor = Color.DarkCyan;
                    }
                }

            }
        }
}
