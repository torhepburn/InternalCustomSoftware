using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Printing;

namespace CalibrationManager
{
    public partial class CustomerOwned_Equipment : Form
    {
        private string select;
        private string[] source = new string[2000];
        private string[] type = new string[2000];
        private string[] user = new string[2000];
        private string[] location = new string[2000];
        private string[] id = new string[2000];
        private string[] sn = new string[2000];
        private string[] manufacturer = new string[2000];
        private string[] description = new string[2000];
        private string[] desc2 = new string[2000];
        private string[] model = new string[2000];
        private string[] status = new string[2000];
        private string[] comments = new string[2000];
        private string[] duedate = new string[2000];
        private string[] caldate = new string[2000];
        private int[] sources = new int[400];
        private int i = 0;
        private int sourceCount = 1;
        private int pagesPrinted = 0;
        private bool sourcePrinted = false;
        private bool typePrinted = false;
        private bool locationPrinted = false;
        private string customer;

        public CustomerOwned_Equipment()
        {
            InitializeComponent();
        }

        private void CustomerOwned_Equipment_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("Select distinct bunitowner from equipment e inner join " +
                 "itemlocation l on e.id = l.il_item where l.il_location " +
                 "like '" + g.facility + "%' and bunitowner != '' " +
                 "and bunitowner is not null order by bunitowner", cnxn);
            DataTable dte = new DataTable();
            da.Fill(dte);
            cbCustomer.DataSource = dte;
            cbCustomer.DisplayMember = "bunitowner";
            cbCustomer.ValueMember = "bunitowner";
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
            if (NumPages == 0) { NumPages = 1; }

            Pen pen = new Pen(Color.Black);
            pen.Width = 1;
            Font arial = new Font("arial", 7, FontStyle.Regular);
            Font title = new Font("arial", 16, FontStyle.Bold);
            Font heading = new Font("arial", 8, FontStyle.Bold);
            Font leaders = new Font("arial", 7, FontStyle.Bold);

            ev.Graphics.DrawString("Calibrated Tools & Equipment owned by " + customer, title, Brushes.Black, 25, 40);
            ev.Graphics.DrawString("Date Printed: " + date, heading, Brushes.Black, 900, 25);
            ev.Graphics.DrawString("Page  " + pageNo + " of " + NumPages, heading, Brushes.Black, 900, 50);

            ev.Graphics.DrawString("ID", heading, Brushes.Black, 25, 80);
            ev.Graphics.DrawString("SN", heading, Brushes.Black, 625, 80);
            ev.Graphics.DrawString("Manufacturer", heading, Brushes.Black, 450, 80);
            ev.Graphics.DrawString("Description", heading, Brushes.Black, 75, 80);
            ev.Graphics.DrawString("Model", heading, Brushes.Black, 700, 80);
            ev.Graphics.DrawString("Status", heading, Brushes.Black, 800, 80);
            ev.Graphics.DrawString("Location", heading, Brushes.Black, 890, 80);
            ev.Graphics.DrawString("Comments", heading, Brushes.Black, 975, 80);

            while (count < linesPerpage && lineNo < i)
            {
 
                ev.Graphics.DrawString(id[lineNo], arial, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString(sn[lineNo], arial, Brushes.Black, 625, linedrop);
                ev.Graphics.DrawString(manufacturer[lineNo], arial, Brushes.Black, 450, linedrop);
                ev.Graphics.DrawString(description[lineNo], arial, Brushes.Black, 75, linedrop);
                ev.Graphics.DrawString(desc2[lineNo], arial, Brushes.Black, 300, linedrop);
                ev.Graphics.DrawString(model[lineNo], arial, Brushes.Black, 700, linedrop);
                ev.Graphics.DrawString(status[lineNo], arial, Brushes.Black, 800, linedrop);
                ev.Graphics.DrawString(location[lineNo], arial, Brushes.Black, 890, linedrop);
                ev.Graphics.DrawString(comments[lineNo], arial, Brushes.Black, 975, linedrop);
              
                //if (source[lineNo] != source[lineNo + 1] && sourcePrinted == true)
                //{
                //    sourcePrinted = false;
                //}

                //if (type[lineNo] != type[lineNo + 1] && typePrinted == true)
                //{
                //    typePrinted = false;
                //}

                //if (location[lineNo] != location[lineNo + 1] && locationPrinted == true)
                //{
                //    locationPrinted = false;
                //}

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

        private void button1_Click(object sender, EventArgs e)
        {
            customer = cbCustomer.Text.Trim();

            select ="  select " +
                    "q.ID, " +
                    "q.[Description], " +
                    "q.desc2, " +
                    "q.SN, " +
                    "q.manuf as [Manufacturer], " +
                    "q.Model, " +
                    "l.il_location as [Location], " +
                    "q.Status, " +
                    "q.Comments " +
                    "from equipment q  " +
                    "left join itemlocation l on " +
                    "q.id = l.il_item " +
                    "where " +
                    "l.il_location like '%" + g.facility + "%' " +
                    "and q.bunitowner like '" + customer + "%' " +
                    " order by q.id";

            SqlConnection cnxn = new SqlConnection(g.db);
            SqlCommand cmd = new SqlCommand(select);
            cmd.Connection = cnxn;
            cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (!dr.IsDBNull(0)) { id[i] = dr.GetString(0).Trim(); }
                if (!dr.IsDBNull(1)) { description[i] = dr.GetString(1).Trim(); }
                if (!dr.IsDBNull(2)) { desc2[i] = dr.GetString(2).Trim(); }
                if (!dr.IsDBNull(3)) { sn[i] = dr.GetString(3).Trim(); }
                if (!dr.IsDBNull(4)) { manufacturer[i] = dr.GetString(4).Trim(); }
                if (!dr.IsDBNull(5)) { model[i] = dr.GetString(5).Trim(); }
                if (!dr.IsDBNull(6)) { location[i] = dr.GetString(6).Trim(); }
                if (!dr.IsDBNull(7)) { status[i] = dr.GetString(7).Trim(); }
                if (!dr.IsDBNull(8)) { comments[i] = dr.GetString(8).Trim(); }
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
    }
}