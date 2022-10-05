using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace CalendarTest
{
    public partial class _Default : System.Web.UI.Page
    {
        string[,] holidays = new String[13, 32];
        protected DataSet dsHolidays;
        string bay;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            holidays[3, 16] = "Birthday";
            holidays[3, 4] = "Anniversary";

            //Calendar1 .

            if (!IsPostBack)
            {
                Calendar1.VisibleDate = DateTime.Today;
                FillHolidayDataSet();
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            ////display vacation dates in yellow boxes with purple borders
            //Style vacationStyle = new Style();
            //vacationStyle.BackColor = System.Drawing.Color.Yellow;
            //vacationStyle.BorderColor = System.Drawing.Color.Purple;
            //vacationStyle.BorderWidth = 3;

            ////display weekend dates with green backgrounds
            //Style weekendStyle = new Style();
            //weekendStyle.BackColor = System.Drawing.Color.Green;

            ////set vacation dates
            //if ((e.Day.Date >= new DateTime(2012, 03, 23)) &&
            //   (e.Day.Date <= new DateTime(2012, 03, 30)))
            //{
            //    e.Cell.ApplyStyle(vacationStyle);
            //}
            //else if (e.Day.IsWeekend)
            //{
            //    e.Cell.ApplyStyle(weekendStyle);
            //}

            ////set IsSelectable property for specific date
            //DateTime myApppointment = new DateTime(2012, 03, 19);
            //if (e.Day.Date == myApppointment)
            //{
            //    e.Day.IsSelectable = true;
            //}
            //else
            //{
            //    e.Day.IsSelectable = false;
            //}

            //add content to individual days
            string aHoliday;
            DateTime theDate = e.Day.Date;
            aHoliday = holidays[theDate.Month, theDate.Day];
            if (aHoliday != null)
            {
                Label aLabel = new Label();
                aLabel.Text = " <br>" + aHoliday;
                e.Cell.Controls.Add(aLabel);
                e.Cell.Text = "<a href=" + e.SelectUrl + ">" +
                    aHoliday + "</a>";
            }

            //display database data in calendar
            //DateTime nextDate;
            //if (dsHolidays != null)
            //{
            //    foreach (DataRow dsr in dsHolidays.Tables[0].Rows)
            //    {
            //        //nextDate = DateTime.Now;
            //        nextDate = (DateTime)dsr["logdate"];
            //        bay = dsr["bay"].ToString();
            //        if (nextDate == e.Day.Date)
            //        {
            //            e.Cell.BackColor = System.Drawing.Color.Pink;
            //            e.Cell.Text = e.Cell.Text + Environment.NewLine +
            //                bay + Environment.NewLine + dsr["starttime"].ToString() +
            //                Environment.NewLine + dsr["stoptime"].ToString() +
            //                Environment.NewLine + dsr["event"].ToString() +
            //                Environment.NewLine + dsr["equipment"].ToString();
            //        }
            //    }
            //}


        }

        protected DateTime GetFirstDayOfNextMonth()
        {
            int monthNumber, yearNumber;
            if (Calendar1.VisibleDate.Month == 12)
            {
                monthNumber = 1;
                yearNumber = Calendar1.VisibleDate.Year + 1;
            }
            else
            {
                monthNumber = Calendar1.VisibleDate.Month + 1;
                yearNumber = Calendar1.VisibleDate.Year;
            }
            DateTime lastDate = new DateTime(yearNumber, monthNumber, 1);
            return lastDate;
        }

        protected void FillHolidayDataSet()
        {
            DateTime firstDate = new DateTime
                (Calendar1.VisibleDate.Year, Calendar1.VisibleDate.Month, 1);
            DateTime lastDate = GetFirstDayOfNextMonth();
            dsHolidays = GetCurrentMonthData(firstDate, lastDate);
        }

        protected DataSet GetCurrentMonthData
            (DateTime firstDate, DateTime lastDate)
        {
            DataSet dsMonth = new DataSet();
            //ConnectionStringSettings cs;
            //cs = ConfigurationManager.ConnectionStrings
            //    ["ConnectionString1"];
            //String cnxnString = cs.ConnectionString;
            //SqlConnection cnxn = new SqlConnection(cnxnString);
            SqlConnection cnxn = new SqlConnection
               ("server = middbsql; user = views; " +
                "password = views; database = demoroom;");
                //"password = views; database = DemoRoom;");
            String query;
            query = "Select * from events";
                //" [test date] >= '2/25/2012' and [test date] <= '4/1/2012' order by [test date]";
            //query = "Select date from events where " +
            //    " date >= '2/25/2012' and date <= '4/1/2012' order by date";
            
            SqlCommand cmd = new SqlCommand(query, cnxn);
            //cmd.Parameters.Add(new Parameter("@firstDate",
            //    firstDate));
            //cmd.Parameters.Add(new Parameter("@lastDate",
            //    lastDate));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(dsMonth);
            }
            catch { }
            return dsMonth;
            
        }

        

        protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            FillHolidayDataSet();
        }

       
    }
}
