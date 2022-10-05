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
    public partial class f54_List_Format_Report : Form
    {
        private string select;
        private string[] source = new string[20000];
        private string[] type = new string[20000];
        private string[] user = new string[20000];
        private string[] location = new string[20000];
        private string[] id = new string[20000];
        private string[] sn = new string[20000];
        private string[] manufacturer = new string[20000];
        private string[] description = new string[20000];
        private string[] size = new string[20000];
        private string[] model = new string[20000];
        private string[] status = new string[20000];
        private string[] interval = new string[20000];
        private string[] duedate = new string[20000];
        private string[] caldate = new string[20000];
        private int[] sources = new int[4000];
        private int i = 0;
        private int sourceCount = 1;
        private int pagesPrinted = 0;
        private bool sourcePrinted = false;
        private bool typePrinted = false;
        private bool locationPrinted = false;

        public f54_List_Format_Report()
        {
            InitializeComponent();
        }

        private void f54_List_Format_Report_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(g.db);
            cnxn.Open();

            SqlCommand cmd = new SqlCommand("CalibrationManagerReports", cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Facility", SqlDbType.NVarChar).Value = g.facility;
            cmd.Parameters.Add("@Order", SqlDbType.NVarChar).Value = DBNull.Value;
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DBNull.Value;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = DBNull.Value;
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = DBNull.Value;
            cmd.Parameters.Add("@Location", SqlDbType.VarChar).Value = DBNull.Value;
            cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = DBNull.Value;
            cmd.Parameters.Add("@CalibrationSource", SqlDbType.NVarChar).Value = DBNull.Value;
           
            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(6)) { id[i] = dr.GetString(6).Trim(); }
                if (!dr.IsDBNull(9)) { description[i] = dr.GetString(9).Trim(); }
                if (!dr.IsDBNull(7)) { sn[i] = dr.GetString(7).Trim(); }
                if (!dr.IsDBNull(10)) { manufacturer[i] = dr.GetString(10).Trim(); }
                if (!dr.IsDBNull(12)) { size[i] = dr.GetString(12).Trim(); }
                if (!dr.IsDBNull(11)) { model[i] = dr.GetString(11).Trim(); }
                if (!dr.IsDBNull(3)) { type[i] = dr.GetString(3).Trim(); }
                if (!dr.IsDBNull(1)) { interval[i] = dr.GetInt32(1).ToString(); }
                if (!dr.IsDBNull(5)) { location[i] = dr.GetString(5).Trim(); }
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

            ev.Graphics.DrawString("Calibrated Tools & Equipment", title, Brushes.Black, 25, 40);
            ev.Graphics.DrawString("Date Printed: " + date, heading, Brushes.Black, 900, 25);
            ev.Graphics.DrawString("Page  " + pageNo + " of " + NumPages, heading, Brushes.Black, 900, 50);
            
            ev.Graphics.DrawString("ID", heading, Brushes.Black, 125, 80);
            ev.Graphics.DrawString("SN", heading, Brushes.Black, 195, 80);
            ev.Graphics.DrawString("Manufacturer", heading, Brushes.Black, 305, 80);
            ev.Graphics.DrawString("Description", heading, Brushes.Black, 440, 80);
            ev.Graphics.DrawString("Size", heading, Brushes.Black, 675, 80);
            ev.Graphics.DrawString("Model", heading, Brushes.Black, 795, 80);
            ev.Graphics.DrawString("Int", heading, Brushes.Black, 945, 80);
            ev.Graphics.DrawString("Status", heading, Brushes.Black, 1015, 80);


            while (count < linesPerpage && lineNo < i)
            {
                ev.Graphics.DrawString(id[lineNo], arial, Brushes.Black, 125, linedrop);
                ev.Graphics.DrawString(sn[lineNo], arial, Brushes.Black, 195, linedrop);
                ev.Graphics.DrawString(manufacturer[lineNo], arial, Brushes.Black, 305, linedrop);
                ev.Graphics.DrawString(description[lineNo], arial, Brushes.Black, 440, linedrop);
                ev.Graphics.DrawString(size[lineNo], arial, Brushes.Black, 675, linedrop);
                ev.Graphics.DrawString(model[lineNo], arial, Brushes.Black, 795, linedrop);
                ev.Graphics.DrawString(interval[lineNo], arial, Brushes.Black, 945, linedrop);
                ev.Graphics.DrawString(status[lineNo], arial, Brushes.Black, 1015, linedrop);

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