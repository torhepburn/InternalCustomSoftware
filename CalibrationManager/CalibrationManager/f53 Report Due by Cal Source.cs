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
    public partial class f53_Report_Due_by_Cal_Source : Form
    {
        private string select;
        private string [] source = new string[2000];
        private string [] type = new string[2000];
        private string [] user = new string[2000];
        private string [] location = new string[2000];
        private string [] id = new string[2000];
        private string [] sn = new string[2000];
        private string [] manufacturer = new string[2000];
        private string [] description = new string[2000];
        private string [] size = new string[2000];
        private string [] model = new string[2000];
        private string [] status = new string[2000];
        private string [] interval = new string[2000];
        private string [] duedate = new string[2000];
        private string [] caldate = new string[2000];
        private int[] sources = new int[400];
        private int i = 0;
        private int sourceCount = 1;
        private int pagesPrinted = 0;
        private bool sourcePrinted = false;
        private bool typePrinted = false;
        private bool locationPrinted = false;
        private int lineNo = 0;
        private int PlineNo = 0;
        private int Pcount = 0;
        private double NumPages;

        public f53_Report_Due_by_Cal_Source()
        {
            InitializeComponent();
        }

        private void f53_Report_Due_by_Cal_Source_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(g.db);
            cnxn.Open();
            
            SqlCommand cmd = new SqlCommand("CalibrationManagerReports", cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Facility", SqlDbType.NVarChar).Value = g.facility;
            cmd.Parameters.Add("@Order", SqlDbType.NVarChar).Value = "Print";
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = g.rpt_earliestDueDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = g.rpt_latestDueDate;
            if (g.rpt_status == "All")
            {
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = g.rpt_status;
            }
            if (g.rpt_type == "room")
            {
                cmd.Parameters.Add("@Location", SqlDbType.VarChar).Value = g.rpt_room;
            }
            else
            {
                cmd.Parameters.Add("@Location", SqlDbType.VarChar).Value = DBNull.Value;
            }
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = DBNull.Value;
            if (g.rpt_type == "room")
            {
                cmd.Parameters.Add("@CalibrationSource", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@CalibrationSource", SqlDbType.NVarChar).Value = g.rpt_CalSource;
            }
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (!dr.IsDBNull(0)) { duedate[i] = dr.GetDateTime(0).ToShortDateString(); }
                if (!dr.IsDBNull(1)) { interval[i] = dr.GetInt32(1).ToString(); }
                if (!dr.IsDBNull(2)) { caldate[i] = dr.GetDateTime(2).ToShortDateString(); }
                if (!dr.IsDBNull(3)) { type[i] = dr.GetString(3).Trim(); }
                if (!dr.IsDBNull(4)) { user[i] = dr.GetString(4).Trim(); }
                if (!dr.IsDBNull(5)) { location[i] = dr.GetString(5).Trim(); }
                if (!dr.IsDBNull(6)) { id[i] = dr.GetString(6).Trim(); }
                if (!dr.IsDBNull(7)) { sn[i] = dr.GetString(7).Trim(); }
                if (!dr.IsDBNull(10)) { manufacturer[i] = dr.GetString(10).Trim(); }
                if (!dr.IsDBNull(9)) { description[i] = dr.GetString(9).Trim(); }
                if (!dr.IsDBNull(12)) { size[i] = dr.GetString(12).Trim(); }
                if (!dr.IsDBNull(11)) { model[i] = dr.GetString(11).Trim(); }
                if (!dr.IsDBNull(13)) { source[i] = dr.GetString(13).Trim(); }
                if (!dr.IsDBNull(8)) { status[i] = dr.GetString(8).Trim(); }
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
            int linesPerpage = 65;
            double printedLines;
            
            int pageNo = pagesPrinted + 1;
            /*
                Need to know how many pages print in order to get the right number of pages.
                Using same routine as printing below. 
                Everything is based on count.  Using Pcount as preliminary count only in  
                first loop so that it will never change.
            */
            while (PlineNo < i)
            {
                if (source[PlineNo] == source[PlineNo + 1] && sourcePrinted == false ||
                    source[PlineNo] != source[PlineNo + 1] && sourcePrinted == false)
                {
                    sourcePrinted = true;
                    Pcount++;
                }

                if (type[PlineNo] == type[PlineNo + 1] && typePrinted == false ||
                    type[PlineNo] != type[PlineNo + 1] && typePrinted == false)
                {
                    typePrinted = true;
                    locationPrinted = false;
                    Pcount++;
                }

                if (location[PlineNo] == location[PlineNo + 1] && locationPrinted == false ||
                    location[PlineNo] != location[PlineNo + 1] && locationPrinted == false)
                {
                    locationPrinted = true;
                    Pcount++;
                }

                if (source[PlineNo] != source[PlineNo + 1] && sourcePrinted == true)
                {
                    sourcePrinted = false;
                }

                if (type[PlineNo] != type[PlineNo + 1] && typePrinted == true)
                {
                    typePrinted = false;
                }

                if (location[PlineNo] != location[PlineNo + 1] && locationPrinted == true)
                {
                    locationPrinted = false;
                }

                PlineNo++;
                Pcount++;
            }

            printedLines = Convert.ToDouble(Pcount);
            NumPages = Math.Ceiling(printedLines / linesPerpage);

            //File.AppendAllText(@"C:\A\cal.txt", "page no " + pageNo.ToString() + Environment.NewLine);
            //File.AppendAllText(@"C:\A\cal.txt", PlineNo + Environment.NewLine);
            //File.AppendAllText(@"C:\A\cal.txt", "count " + Pcount.ToString() + Environment.NewLine);
            //File.AppendAllText(@"C:\A\cal.txt", "num pages " + NumPages.ToString() + Environment.NewLine + Environment.NewLine);

            Pen pen = new Pen(Color.Black);
            pen.Width = 1;
            Font arial = new Font("arial", 7, FontStyle.Regular);
            Font title = new Font("arial", 16, FontStyle.Bold);
            Font heading = new Font("arial", 8, FontStyle.Bold);
            Font leaders = new Font("arial", 7, FontStyle.Bold);

            ev.Graphics.DrawString("Calibrated Tools & Equipment", title, Brushes.Black, 25, 40);
            ev.Graphics.DrawString("Date Printed: " + date, heading, Brushes.Black, 900, 25);
            ev.Graphics.DrawString("Page  " + pageNo + " of " + NumPages,heading, Brushes.Black, 900, 50);
            ev.Graphics.DrawString("Calibration Due Range: " +
                g.rpt_earliestDueDate + " to " +
                g.rpt_latestDueDate + ":  " + i.ToString() + " items", heading, Brushes.Black, 400, 25);

            ev.Graphics.DrawString("User", heading, Brushes.Black, 25, 80);
            ev.Graphics.DrawString("ID", heading, Brushes.Black, 125, 80);
            ev.Graphics.DrawString("SN", heading, Brushes.Black, 195, 80);
            ev.Graphics.DrawString("Manufacturer", heading, Brushes.Black, 305, 80);
            ev.Graphics.DrawString("Description", heading, Brushes.Black, 440, 80);
            ev.Graphics.DrawString("Size", heading, Brushes.Black, 675, 80);
            ev.Graphics.DrawString("Model", heading, Brushes.Black, 795, 80);
            ev.Graphics.DrawString("Last Cal", heading, Brushes.Black, 890, 80);
            ev.Graphics.DrawString("Int", heading, Brushes.Black, 945, 80);
            ev.Graphics.DrawString("Next Cal", heading, Brushes.Black, 975, 80);
            ev.Graphics.DrawString("Status", heading, Brushes.Black, 1035, 80);

            
            while (count < linesPerpage && lineNo < i)
            {
                if (source[lineNo] == source[lineNo + 1] && sourcePrinted == false ||
                    source[lineNo] != source[lineNo + 1] && sourcePrinted == false)
                {
                    ev.Graphics.DrawString("Calibration Source:  " + 
                        source[lineNo], leaders, Brushes.Black, 25, linedrop);
                    sourcePrinted = true;
                    linedrop = linedrop + 10;
                    count++;
                }

                if (type[lineNo] == type[lineNo + 1] && typePrinted == false ||
                    type[lineNo] != type[lineNo + 1] && typePrinted == false)
                {
                    ev.Graphics.DrawString("Type:  " +
                        type[lineNo], leaders, Brushes.Black, 50, linedrop);
                    typePrinted = true;
                    locationPrinted = false;
                    linedrop = linedrop + 10;
                    count++;
                }

                if (location[lineNo] == location[lineNo + 1] && locationPrinted == false ||
                    location[lineNo] != location[lineNo + 1] && locationPrinted == false)
                {
                    ev.Graphics.DrawString("Location:  " +
                        location[lineNo], leaders, Brushes.Black, 25, linedrop);
                    locationPrinted = true;
                    linedrop = linedrop + 10;
                    count++;
                }

                ev.Graphics.DrawString(user[lineNo], arial, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString(id[lineNo], arial, Brushes.Black, 125, linedrop);
                ev.Graphics.DrawString(sn[lineNo], arial, Brushes.Black, 195, linedrop);
                ev.Graphics.DrawString(manufacturer[lineNo], arial, Brushes.Black, 305, linedrop);
                ev.Graphics.DrawString(description[lineNo], arial, Brushes.Black, 440, linedrop);
                ev.Graphics.DrawString(size[lineNo], arial, Brushes.Black, 675, linedrop);
                ev.Graphics.DrawString(model[lineNo], arial, Brushes.Black, 795, linedrop);
                ev.Graphics.DrawString(caldate[lineNo], arial, Brushes.Black, 890, linedrop);
                ev.Graphics.DrawString(interval[lineNo], arial, Brushes.Black, 945, linedrop);
                ev.Graphics.DrawString(duedate[lineNo], arial, Brushes.Black, 975, linedrop);
                ev.Graphics.DrawString(status[lineNo], arial, Brushes.Black, 1035, linedrop);

                if (source[lineNo] != source[lineNo + 1] && sourcePrinted == true)
                {
                    sourcePrinted = false;
                }

                if (type[lineNo] != type[lineNo + 1] && typePrinted == true)
                {
                    typePrinted = false;
                }

                if (location[lineNo] != location[lineNo + 1] && locationPrinted == true)
                {
                    locationPrinted = false;
                }

                lineNo++;
                linedrop = linedrop + 10;
                count++;
                
            }

            //File.AppendAllText(@"C:\A\cal.txt", "ppd page no " + pageNo.ToString() + Environment.NewLine);
            //File.AppendAllText(@"C:\A\cal.txt", PlineNo + Environment.NewLine);
            //File.AppendAllText(@"C:\A\cal.txt", "ppd count " + count.ToString() + Environment.NewLine);
            //File.AppendAllText(@"C:\A\cal.txt", "ppd num pages " + NumPages.ToString() + Environment.NewLine + Environment.NewLine);


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