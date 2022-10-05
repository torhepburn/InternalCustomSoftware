using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace CapacityCalendar
{
    public partial class CapacityCalendar : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        //DataTable dt;
        DataTable dt2;
        
        public CapacityCalendar()
        {
            InitializeComponent();
            //CultureInfo _culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            //CultureInfo _uiculture = (CultureInfo)CultureInfo.CurrentUICulture.Clone();
            //_culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
            //_uiculture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
            //System.Threading.Thread.CurrentThread.CurrentCulture = _culture;
            //System.Threading.Thread.CurrentThread.CurrentUICulture = _uiculture;
        }

        private void CapacityCalendar_Load(object sender, EventArgs e)
        {
            rbDays.Checked = true;
            
        }

        private void bFilter_Click(object sender, EventArgs e)
        {
            if (rbDays.Checked)
            {
                g.granularity = "DAYS";
                g.granularFactor = 1;
                g.startDate = startCalendar.SelectionStart;
                g.endDate = endCalendar.SelectionStart;
            }
            else if (rbWeeks.Checked)
            {
                g.granularity = "WEEKS";
                g.granularFactor = 5;
                //get the number day of the week for start date
                int DayCount = (int)startCalendar.SelectionStart.DayOfWeek;
                //subtract the number day of the week to get to the first day of the week
                g.startDate = startCalendar.SelectionStart.AddDays(-(DayCount - 1));
                //get the number day of the week for end date
                DayCount = (int)endCalendar.SelectionStart.DayOfWeek;
                g.endDate = endCalendar.SelectionStart.AddDays(7-DayCount);
            }
            else if (rbMonths.Checked)
            {
                g.granularity = "MONTHS";
                g.granularFactor = 30;
                g.startDate = new DateTime
                    (startCalendar.SelectionStart.Year, startCalendar.SelectionStart.Month, 1);
                var startd = new DateTime(endCalendar.SelectionStart.Year, 
                    endCalendar.SelectionStart.Month, 1);
                
                if (startd.Month == 12)
                {
                    g.endDate = new DateTime(startd.Year, startd.Month, 31);
                }
                else
                {
                    g.endDate = startd.AddMonths(1).AddDays(-1);
                }
            }
            else
            {
                g.granularity = "QUARTERS";
                g.granularFactor = 91;
                // start of quarter dates
                int MonthCount = startCalendar.SelectionStart.Month;
                if ( MonthCount < 4 )
                {
                    g.startDate = new DateTime(startCalendar.SelectionStart.Year, 1, 1);
                }
                else if (MonthCount > 3 & MonthCount < 7 )
                {
                    g.startDate = new DateTime(startCalendar.SelectionStart.Year, 4, 1);
                }
                else if (MonthCount > 6 & MonthCount < 10 )
                {
                    g.startDate = new DateTime(startCalendar.SelectionStart.Year, 7, 1);
                }
                else  //(MonthCount > 9 & MonthCount <=12 )
                {
                    g.startDate = new DateTime(startCalendar.SelectionStart.Year, 10, 1);
                }
                // end of quarter dates
                MonthCount = endCalendar.SelectionStart.Month;
                if (MonthCount < 4)
                {
                    g.endDate = new DateTime(endCalendar.SelectionStart.Year, 3, 31);
                }
                else if (MonthCount > 3 & MonthCount < 7)
                {
                    g.endDate = new DateTime(endCalendar.SelectionStart.Year, 6, 30);
                }
                else if (MonthCount > 6 & MonthCount < 10)
                {
                    g.endDate = new DateTime(endCalendar.SelectionStart.Year, 9, 30);
                }
                else  //(MonthCount > 9 & MonthCount <=12 )
                {
                    g.endDate = new DateTime(endCalendar.SelectionStart.Year, 12, 31);
                }
            }

            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter("select (capacity * " + g.granularFactor +
                  ") Capacity, deptcode from tblDept " +
                  @"where deptcode in (" +
                  @" '104', '531', '532', '556', '558', " +
                  @" 'R00', 'R01', 'R02', 'R03', 'R04',  'R05', 'R06', 'R07', 'R08', 'R09', " +
                  @" 'R10', 'R11', 'R20', 'R21', 'R22', 'R23', 'R24', " +
                  @" 'R30','R31', 'R32', 'R33', 'R34', 'R35', 'R36', " +
                  @" 'R40', 'R41', 'R42', 'R43', 'R44',  " +
                  @" 'R50', 'R51', 'R52', 'R53', 'R54', 'R55', 'R56', " +
                  @" 'R60', 'R61', 'R62', 'R70', " +
                  @" 'R80', 'R81', 'R85', 'R88', 'R90', 'R91', 'R99' ) " +
                  "order by deptcode", cnxn);

            try
            {
                dt2 = new DataTable();
                da.Fill(dt2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("dt2 " + ex.ToString());
            }

            if (g.granularFactor == 1)
            {
                da = new SqlDataAdapter
                ("declare @cols varchar(max) " +
                 "declare @query varchar(max) " +
                 "with s1 as " +
                 "( " +
                 "select distinct CONVERT(varchar(10), runningdate, 1) RD " +
                 "from ScheduledRunningDates where " +
                 "runningdate >= '" + g.startDate + "' and RunningDate <= '" + g.endDate + "' " +
                 ") " +
                 "Select @cols = COALESCE( + @cols + '], [', '[') + RD from s1 " +
                 "order by RD " +
                 "set @query = N' " +
                 "select '''' [Capacity (h/day)], * from " +
                 "( " +
                 "select " +
                 "DeptCode, " +
                 "RunningDate, " +
                 "rd.RunTime " +
                 "from ScheduledRunningDates rd " +
                 "where " +
                 @" deptcode in (" +
                 @" ''104'', ''531'', ''532'', ''556'', ''558'', " +
                 @" ''R00'', ''R01'', ''R02'', ''R03'', ''R04'',  ''R05'', ''R06'', ''R07'', ''R08'', ''R09'', " +
                 @" ''R10'', ''R11'', ''R20'', ''R21'', ''R22'', ''R23'', ''R24'', " +
                 @" ''R30'',''R31'', ''R32'', ''R33'', ''R34'', ''R35'', ''R36'', " +
                 @" ''R40'', ''R41'', ''R42'', ''R43'', ''R44'',  " +
                 @" ''R50'', ''R51'', ''R52'', ''R53'', ''R54'', ''R55'', ''R56'', " +
                 @" ''R60'', ''R61'', ''R62'', ''R70'', " +
                 @" ''R80'', ''R81'', ''R85'', ''R88'', ''R90'', ''R91'', ''R99'' )" +
                 ") as s " +
                 "PIVOT " +
                 "( " +
                 "SUM(RunTime) " +
                 "for RunningDate in (' + @cols + ']) " +
                 ") as PVT order by DeptCode' " +
                 "execute(@query)", cnxn);
            }
            else if (g.granularFactor == 5)
            {
                da = new SqlDataAdapter
                ("declare @cols varchar(max) " +
                 "declare @query varchar(max) " +
                 "with s1 as " +
                 "( " +
                 "select distinct CONVERT(varchar, DATENAME(WEEK, RunningDate)) RD," +
                 "DATEPART(WEEK, RunningDate) weeknumber " +
                 "from ScheduledRunningDates where " +
                 "runningdate >= '" + g.startDate + "' and RunningDate <= '" + g.endDate + "' " +
                 ") " +
                 "Select @cols = COALESCE( + @cols + '], [', '[') + RD from s1 " +
                 "order by weeknumber " +
                 "set @query = N' " +
                 "select '''' [Capacity (h/week)], * from " +
                 "( " +
                 "select " +
                 "DeptCode, " +
                 "CONVERT(varchar(2),DATEPART(WEEK,RunningDate)) wk, " +
                 "rd.RunTime " +
                 "from ScheduledRunningDates rd " +
                 "where " +
                 @" deptcode in (" +
                 @" ''104'', ''531'', ''532'', ''556'', ''558'', " +
                 @" ''R00'', ''R01'', ''R02'', ''R03'', ''R04'',  ''R05'', ''R06'', ''R07'', ''R08'', ''R09'', " +
                 @" ''R10'', ''R11'', ''R20'', ''R21'', ''R22'', ''R23'', ''R24'', " +
                 @" ''R30'',''R31'', ''R32'', ''R33'', ''R34'', ''R35'', ''R36'', " +
                 @" ''R40'', ''R41'', ''R42'', ''R43'', ''R44'',  " +
                 @" ''R50'', ''R51'', ''R52'', ''R53'', ''R54'', ''R55'', ''R56'', " +
                 @" ''R60'', ''R61'', ''R62'', ''R70'', " +
                 @" ''R80'', ''R81'', ''R85'', ''R88'', ''R90'', ''R91'', ''R99'' )" +
                 ") as s " +
                 "PIVOT " +
                 "( " +
                 "SUM(RunTime) " +
                 "for wk in (' + @cols + ']) " +
                 ") as PVT order by DeptCode' " +
                 "execute(@query)", cnxn);
            }
            else if (g.granularFactor == 30)
            {
                da = new SqlDataAdapter
                ("declare @cols varchar(max) " +
                 "declare @query varchar(max) " +
                 "with s1 as " +
                 "( " +
                 "select distinct CONVERT(varchar(3), DATENAME(MONTH, RunningDate)) RD," +
                 "DATEPART(mm, RunningDate) MonthNumber " +
                 "from ScheduledRunningDates where " +
                 "runningdate >= '" + g.startDate + "' and RunningDate <= '" + g.endDate + "' " +
                 ") " +
                 "Select @cols = COALESCE( + @cols + '], [', '[') + RD from s1 " +
                 "order by monthnumber " +
                 "set @query = N' " +
                 "select '''' [Capacity (h/month)], * from " +
                 "( " +
                 "select " +
                 "DeptCode, " +
                 "CONVERT(varchar(3),DATENAME(month, DATEADD(month, DATEPART(month,RunningDate), -1))) month, " +
                 "rd.RunTime " +
                 "from ScheduledRunningDates rd " +
                 "where " +
                 @" deptcode in (" +
                 @" ''104'', ''531'', ''532'', ''556'', ''558'', " +
                 @" ''R00'', ''R01'', ''R02'', ''R03'', ''R04'',  ''R05'', ''R06'', ''R07'', ''R08'', ''R09'', " +
                 @" ''R10'', ''R11'', ''R20'', ''R21'', ''R22'', ''R23'', ''R24'', " +
                 @" ''R30'',''R31'', ''R32'', ''R33'', ''R34'', ''R35'', ''R36'', " +
                 @" ''R40'', ''R41'', ''R42'', ''R43'', ''R44'',  " +
                 @" ''R50'', ''R51'', ''R52'', ''R53'', ''R54'', ''R55'', ''R56'', " +
                 @" ''R60'', ''R61'', ''R62'', ''R70'', " +
                 @" ''R80'', ''R81'', ''R85'', ''R88'', ''R90'', ''R91'', ''R99'' )" +
                 ") as s " +
                 "PIVOT " +
                 "( " +
                 "SUM(RunTime) " +
                 "for month in (' + @cols + ']) " +
                 ") as PVT order by DeptCode' " +
                 "execute(@query)", cnxn);
            }
            else //(g.granularFactor == 91)
            {
                da = new SqlDataAdapter
                ("declare @cols varchar(max) " +
                 "declare @query varchar(max) " +
                 "with s1 as " +
                 "( " +
                 "select distinct CONVERT(varchar(3), DATENAME(QUARTER, RunningDate)) RD " +
                 "from ScheduledRunningDates where " +
                 "runningdate >= '" + g.startDate + "' and RunningDate <= '" + g.endDate + "' " +
                 ") " +
                 "Select @cols = COALESCE( + @cols + '], [', '[') + RD from s1 " +
                 "order by RD " +
                 "set @query = N' " +
                 "select '''' [Capacity (h/Quarter)], * from " +
                 "( " +
                 "select " +
                 "DeptCode, " +
                 "CONVERT(varchar(3),DATENAME(quarter, DATEADD(quarter, DATEPART(quarter,RunningDate), -1))) quarter, " +
                 "rd.RunTime " +
                 "from ScheduledRunningDates rd " +
                 "where " +
                 @" deptcode in (" +
                 @" ''104'', ''531'', ''532'', ''556'', ''558'', " +
                 @" ''R00'', ''R01'', ''R02'', ''R03'', ''R04'',  ''R05'', ''R06'', ''R07'', ''R08'', ''R09'', " +
                 @" ''R10'', ''R11'', ''R20'', ''R21'', ''R22'', ''R23'', ''R24'', " +
                 @" ''R30'',''R31'', ''R32'', ''R33'', ''R34'', ''R35'', ''R36'', " +
                 @" ''R40'', ''R41'', ''R42'', ''R43'', ''R44'',  " +
                 @" ''R50'', ''R51'', ''R52'', ''R53'', ''R54'', ''R55'', ''R56'', " +
                 @" ''R60'', ''R61'', ''R62'', ''R70'', " +
                 @" ''R80'', ''R81'', ''R85'', ''R88'', ''R90'', ''R91'', ''R99'' )" +
                 ") as s " +
                 "PIVOT " +
                 "( " +
                 "SUM(RunTime) " +
                 "for quarter in (' + @cols + ']) " +
                 ") as PVT order by DeptCode' " +
                 "execute(@query)", cnxn);
            }
            
            try
            {
                g.dt = new DataTable();
                da.Fill(g.dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //  replace all nulls with zeros so that comparisons can be made
            //  to calculate cell color when overcapacity
            for (int i = 0; i < g.dt.Rows.Count; i++)
            {
                foreach (DataColumn column in g.dt.Columns)
                {
                    if (column.Ordinal > 1)
                    {
                        if (DBNull.Value.Equals(g.dt.Rows[i][column.Ordinal]))
                        {
                            g.dt.Rows[i][column.Ordinal] = 0;
                        }
                        else
                        {
                            //g.dt.Rows[i][column.Ordinal] = Convert.ToDouble(g.dt.Rows[i][column.Ordinal].ToString()) / 60;
                        }
                    }
                }
            }
            
            
            for (int i = 0; i < g.dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt2.Rows.Count; j++ )
                {
                    if (g.dt.Rows[i][1].ToString().Trim() == dt2.Rows[j][1].ToString().Trim())
                    {
                        g.dt.Rows[i][0] = dt2.Rows[j][0].ToString();
                    }
                }
            }

            if ( g.granularFactor == 5 )
            {
                for (int i = 2; i < g.dt.Columns.Count; i++)
                {
                    g.dt.Columns[i].ColumnName = g.startDate.AddDays((i-2) * 7).ToString("MM/dd/yy");
                }
            }

            if (DGV.Columns.Count > 0)
            {
                DGV.Columns[0].Frozen = false;
                DGV.Columns[1].Frozen = false;
            }

            DGV.DataSource = null;
            DGV.DataSource = g.dt;

            foreach (DataGridViewRow gr in DGV.Rows)
            {
                foreach (DataGridViewCell sell in gr.Cells)
                {

                    if (sell.ColumnIndex > 1 & gr.Index < g.dt.Rows.Count)
                    {
                        if (Convert.ToDouble(DGV.Rows[gr.Index].Cells[0].Value.ToString())
                            < Convert.ToDouble(DGV.Rows[gr.Index].Cells[sell.ColumnIndex].Value.ToString()))
                        {
                            DGV.Rows[gr.Index].Cells[sell.ColumnIndex].Style.BackColor = Color.LightBlue;

                        }
                    }
                }
            }


            
            for (int i = 0; i < DGV.Columns.Count; i++)
            {
                DGV.Columns[i].Width = 60;
            }
            DGV.Columns[0].Frozen = true;
            DGV.Columns[1].Frozen = true;

            
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex == -1 && e.ColumnIndex < 8)
            if (e.RowIndex == -1 | e.ColumnIndex == -1)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.workcell = cell.EditedFormattedValue.ToString();

                ChartDisplay c = new ChartDisplay();
                c.ShowDialog();
            }
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
        public static string customer;
        public static string project;
        public static string element;
        public static string item_code;
        public static string jobID;
        public static string partsn;
        public static string opnum;
        public static string partid;
        public static string holdStatusID;
        public static string db = "server = midsql01; password = Read+Write!; " +
                            "user = readwrite; database = OptiTRAK;";

    }

}