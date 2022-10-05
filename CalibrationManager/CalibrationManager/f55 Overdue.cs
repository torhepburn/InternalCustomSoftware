using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Data.SqlClient;

namespace CalibrationManager
{
    public partial class f55_Overdue : Form
    {
        private string select;
        private string[] source = new string[2000];
        private string[] type = new string[2000];
        private string[] user = new string[2000];
        private string[] location = new string[2000];
        private string[] id = new string[2000];
        private string[] sn = new string[2000];
        private string[] description = new string[2000];
        private string[] owner = new string[2000];
        private string[] model = new string[2000];
        private string[] status = new string[2000];
        private string[] interval = new string[2000];
        private string[] duedate = new string[2000];
        private string[] supervisor = new string[2000];
        private int[] sources = new int[400];
        private int i = 0;
        private int sourceCount = 1;
        private int pagesPrinted = 0;
        private bool sourcePrinted = false;
        private bool typePrinted = false;
        private bool locationPrinted = false;
        private string firstOFmonth;
        private string lastOFmonth;
        
        
        public f55_Overdue()
        {
            InitializeComponent();
        }

        private void f55_Overdue_Load(object sender, EventArgs e)
        {
            lastOFmonth = DateTime.Now.ToShortDateString();
            firstOFmonth = "2000-1-1";
            
            select =  " select " +
                        "l.il_location as [Location], " +
                        "q.ID, " +
                        "q.[Description], " +
                        "q.Model, " +
                        "e.name as [User], " +
                        "ee.name as [Owner], " +
                        "eee.name as [Owners Supervisor], " +
                        "d.cal_next as [Cal Due]" +
                        "from calibration.dbo.calibrationdata d " +
                        "left join calibration.dbo.equipment q on " +
                        "d.item = q.id " +
                        "left join calibration.dbo.itemuser u on " +
                        "q.id = u.i_item " +
                        "left join calibration.dbo.itemlocation l on " +
                        "q.id = l.il_item " +
                        "left join " + g.dbDash + " e on " +
                        "u.i_user = e.badgeid " +
                        "left join calibration.dbo.location c on " +
                        "c.l_id = l.il_location " +
                        "left join " + g.dbDash + " ee on " +
                        "c.l_owner = ee.badgeid " +
                        "left join " + g.dbDash + " eee on " +
                        "ee.mysupervisorname = eee.name " +
                        "where d.currenthistory = 'c' " +
                        "and l.il_location like '%" + g.facility + "%' " +
                        " and d.cal_next >= '" + firstOFmonth + "'  " +
                        " and d.cal_next <= '" + lastOFmonth + "'  " +
                        " and q.status = 'active' " +
                         " order by d.cal_next";
          

            SqlConnection cnxn = new SqlConnection(g.db);
            SqlCommand cmd = new SqlCommand(select);
            cmd.Connection = cnxn;
            cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (!dr.IsDBNull(1)) { id[i] = dr.GetString(1).Trim(); }
                if (!dr.IsDBNull(2)) { description[i] = dr.GetString(2).Trim(); }
                if (!dr.IsDBNull(3)) { model[i] = dr.GetString(3).Trim(); }
                if (!dr.IsDBNull(4)) { user[i] = dr.GetString(4).Trim(); }
                if (!dr.IsDBNull(5)) { owner[i] = dr.GetString(5).Trim(); }
                if (!dr.IsDBNull(0)) { location[i] = dr.GetString(0).Trim(); }
                if (!dr.IsDBNull(6)) { supervisor[i] = dr.GetString(6).Trim(); }
                if (!dr.IsDBNull(7)) { duedate[i] = dr.GetDateTime(7).ToShortDateString(); }
                i++;

            }
            cnxn.Close();

            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = true;
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            (ppd as Form).WindowState = FormWindowState.Maximized;
            ppd.ShowDialog();
            Close();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            string date = DateTime.Now.ToShortDateString();
            int linedrop = 100;
            int count = 0;
            int linesPerpage = 68;
            int lineNo = this.pagesPrinted * linesPerpage;
            int pageNo = pagesPrinted + 1;
            double NumPages = Math.Ceiling(((i - 1) / 68.0));

            Pen pen = new Pen(Color.Black);
            pen.Width = 1;
            Font arial = new Font("arial", 7, FontStyle.Regular);
            Font title = new Font("arial", 16, FontStyle.Bold);
            Font heading = new Font("arial", 8, FontStyle.Bold);
            Font leaders = new Font("arial", 7, FontStyle.Bold);

            ev.Graphics.DrawString("Calibrated Tools & Equipment Overdue Report", title, Brushes.Black, 25, 40);
            ev.Graphics.DrawString("Date Printed: " + date, heading, Brushes.Black, 900, 25);
            ev.Graphics.DrawString("Page  " + pageNo + " of " + NumPages, heading, Brushes.Black, 900, 50);

            ev.Graphics.DrawString("ID", heading, Brushes.Black, 25, 80);
            ev.Graphics.DrawString("Description", heading, Brushes.Black,125, 80);
            ev.Graphics.DrawString("Model", heading, Brushes.Black, 425, 80);
            ev.Graphics.DrawString("User", heading, Brushes.Black, 550, 80);
            ev.Graphics.DrawString("Owner", heading, Brushes.Black, 650, 80);
            ev.Graphics.DrawString("Owner's Supervisor", heading, Brushes.Black, 750, 80);
            ev.Graphics.DrawString("Location", heading, Brushes.Black, 900, 80);
            ev.Graphics.DrawString("Cal Due", heading, Brushes.Black, 1000, 80);

            while (count < linesPerpage && lineNo < i)
            {
                ev.Graphics.DrawString(id[lineNo], arial, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString(description[lineNo], arial, Brushes.Black, 125, linedrop);
                ev.Graphics.DrawString(model[lineNo], arial, Brushes.Black, 425, linedrop);
                ev.Graphics.DrawString(user[lineNo], arial, Brushes.Black, 550, linedrop);
                ev.Graphics.DrawString(owner[lineNo], arial, Brushes.Black, 650, linedrop);
                ev.Graphics.DrawString(supervisor[lineNo], arial, Brushes.Black, 750, linedrop);
                ev.Graphics.DrawString(location[lineNo], arial, Brushes.Black, 900, linedrop);
                ev.Graphics.DrawString(duedate[lineNo], arial, Brushes.Black, 1000, linedrop);

                lineNo++;
                count++;
                linedrop = linedrop + 10;
            }

            if (i > lineNo)
            {
                ev.HasMorePages = true;
                pagesPrinted++;
            }
            else
            {
                ev.HasMorePages = false;
                linedrop = 160;
                count = 0;
                pagesPrinted = 0;
                lineNo = 0;
            }
        }
 
    }
}