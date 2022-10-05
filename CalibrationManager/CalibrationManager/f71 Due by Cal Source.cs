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
    public partial class f71_Due_by_Cal_Source : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable table;
        BindingSource bs = new BindingSource();
        private string select;
        private string dateB4;
        private string dateAfter;
        private string statusFilter = "One";
         
        public f71_Due_by_Cal_Source()
        {
            InitializeComponent();
        }

        private void f71_Due_by_Cal_Source_Load(object sender, EventArgs e)
        {
            bCalSource.Visible = false;
            
            cnxn = new SqlConnection(g.db);
            
            select = "select StatusCode from status " +
                " order by statuscode";

            cnxn.Open();
            da = new SqlDataAdapter(select, cnxn);
            table = new DataTable();
            da.Fill(table);
            cnxn.Close();
            comboxStatus.DataSource = table;
            comboxStatus.DisplayMember = "StatusCode";

            select = "select distinct d.calsource from calibrationdata d " +
                "inner join equipment e on e.id = d.item  " +
                " inner join status s on e.status = s.statuscode " +
                " where s.statuslive = 'y' order by d.calsource";

            cnxn.Open();
            da = new SqlDataAdapter(select, cnxn);
            table = new DataTable();
            da.Fill(table);
            cnxn.Close();
            comboxCalSource.DataSource = table;
            comboxCalSource.DisplayMember = "CalSource";

            monthCalendarDueAfter.SelectionEnd = new DateTime(1995, 1, 1, 0, 0, 0, 0);
            monthCalendarDueB4.SelectionEnd = new DateTime(2100, 1, 1, 0, 0, 0, 0);
            dateAfter = "1/1/1995";
            dateB4 = "1/1/2100";
        }

        private void bFilter_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("CalibrationManagerReports", cnxn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Facility", SqlDbType.NVarChar).Value = g.facility;
            da.SelectCommand.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = dateAfter;
            da.SelectCommand.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dateB4;
            if (statusFilter == "All")
            {
                da.SelectCommand.Parameters.Add("@Status", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@Status", SqlDbType.NVarChar).Value = comboxStatus.Text.Trim();
            }
            da.SelectCommand.Parameters.Add("@Location", SqlDbType.VarChar).Value = DBNull.Value;
            da.SelectCommand.Parameters.Add("@ID", SqlDbType.NVarChar).Value = DBNull.Value;
            da.SelectCommand.Parameters.Add("@CalibrationSource", SqlDbType.NVarChar).Value = comboxCalSource.Text.Trim();
            da.SelectCommand.Parameters.Add("@Order", SqlDbType.NVarChar).Value = DBNull.Value;
            table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            DGV.Show();
            Lrowcount.Text = "Row Count: " + DGV.RowCount.ToString();
        }

        private void monthCalendarDueAfter_DateChanged(object sender, DateRangeEventArgs e)
        {
            dateAfter  = monthCalendarDueAfter.SelectionStart.ToShortDateString();
        }

        private void monthCalendarDueB4_DateChanged(object sender, DateRangeEventArgs e)
        {
            dateB4 = monthCalendarDueB4.SelectionStart.ToShortDateString();
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            if (statusFilter == "One")
            {
                g.rpt_status = comboxStatus.Text.Trim();
            }
            else
            {
                g.rpt_status = "All";
            }
            g.rpt_CalSource = comboxCalSource.Text.Trim();
            g.rpt_earliestDueDate = dateAfter;
            g.rpt_latestDueDate = dateB4;
            g.rpt_type = "source";
            f53_Report_Due_by_Cal_Source f53 = new f53_Report_Due_by_Cal_Source();
            f53.Show();
        }

        private void monthCalendarDueB4_DateSelected(object sender, DateRangeEventArgs e)
        {
            dateB4 = monthCalendarDueB4.SelectionStart.ToShortDateString();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bStatus_Click(object sender, EventArgs e)
        {
            statusFilter = "All";
            bStatus.BackColor = Color.FromArgb(200, 0, 100);
            comboxStatus.Text = "All";
        }

        private void comboxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bStatus.BackColor = Color.FromArgb(255, 255, 128);
            statusFilter = "One";
        }

        private void bCalSource_Click(object sender, EventArgs e)
        {

        }
    }
}