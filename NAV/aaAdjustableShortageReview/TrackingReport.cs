using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Printing;


namespace aaAdjustableShortageReview
{
    public partial class TrackingReport : Form
    {
        private string[] plannerinitials = new string[20000];
        private string[] customer = new string[20000];
        private string[] MkReceiptTransactionID = new string[20000];
        private string[] partNumber = new string[20000];
        private string[] elementWrap = new string[20000];
        private string[] operatorName = new string[20000];
        private string[] Location = new string[20000];
        private string[] MovedToDate = new string[20000];
        private string[] descriptionWrap = new string[20000];
        private string[] MovedToQty = new string[20000];
        private string[] MovedOutDate = new string[20000];
        private string[] MovedOutQty = new string[20000];
        private string[] OriginalQty = new string[20000];
        private string[] receiptNumber = new string[20000];
        private string[] TimeInMin = new string[20000];
        private string[] locationTrackID = new string[20000];
        private string[] InspectionRqd = new string[20000];
        private string[] KanbanXID = new string[20000];
        private string[] RMaID = new string[20000];
        private string[] ServiceID = new string[20000];
        private string[] eWrap = new string[20000];
        private string[] dWrap = new string[20000];
        private int i = 0;
        private int sourceCount = 1;
        private int pagesPrinted = 0;
        private bool sourcePrinted = false;
        private bool trackerIDPrinted = false;
        private bool locationPrinted = false;
        private int lineNo = 0;

        public TrackingReport()
        {
            InitializeComponent();
        }

        private void TrackingReport_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(g.db);

            SqlCommand cmd = new SqlCommand
                ("SELECT " +
                "  MKReceiptTransactionID " +
                " ,PartNumber " +
                " ,OperatorName " +
                " ,Location " +
                " ,MovedToDate " +
                " ,MovedToQty " +
                " ,MovedOutDate " +
                " ,MovedOutQty " +
                " ,OriginalQty " +
                " ,ReceiptNumber " +
                " ,TimeInMin " +
                " ,LocationTrackingID " +
                " ,KanbanTransactionID " +
                " ,RMAItemsNumber " +
                " ,ServiceID " +
                " FROM local_dash_view_tracking t " +
                " WHERE partNumber = '" + g.itemCode + "' " +
                " order by MKReceiptTransactionID desc, movedtodate asc ", cnxn);

            cnxn.Open();

            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0)) { MkReceiptTransactionID[i] = dr.GetInt32(0).ToString().Trim(); }
                if (!dr.IsDBNull(1)) { partNumber[i] = dr.GetString(1).Trim(); }
                if (!dr.IsDBNull(2)) { operatorName[i] = dr.GetString(2).Trim(); }
                if (!dr.IsDBNull(3)) { Location[i] = dr.GetString(3).Trim(); }
                if (!dr.IsDBNull(4)) { MovedToDate[i] = dr.GetDateTime(4).ToString().Trim(); }
                if (!dr.IsDBNull(5)) { MovedToQty[i] = dr.GetDouble(5).ToString(); }
                if (!dr.IsDBNull(6)) { MovedOutDate[i] = dr.GetDateTime(6).ToString().Trim(); }
                if (!dr.IsDBNull(7)) { MovedOutQty[i] = dr.GetDouble(7).ToString(); }
                if (!dr.IsDBNull(8)) { OriginalQty[i] = dr.GetDouble(8).ToString(); }
                if (!dr.IsDBNull(9)) { receiptNumber[i] = dr.GetString(9).Trim(); }
                if (!dr.IsDBNull(10)) { TimeInMin[i] = dr.GetDouble(10).ToString(); }
                if (!dr.IsDBNull(11)) { locationTrackID[i] = dr.GetInt32(11).ToString().Trim(); }
                if (!dr.IsDBNull(12)) { KanbanXID[i] = dr.GetInt32(12).ToString().Trim(); }
                if (!dr.IsDBNull(13)) { RMaID[i] = dr.GetInt32(13).ToString().Trim(); }
                if (!dr.IsDBNull(14)) { ServiceID[i] = dr.GetInt32(14).ToString().Trim(); }

                try
                {

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
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
            string date = DateTime.Now.ToString();
            int linedrop = 100;
            int count = 0;
            int linesPerpage = 25;
            //int lineNo = this.pagesPrinted * linesPerpage;
            int pageNo = pagesPrinted + 1;
            double NumPages = Math.Ceiling(((i - 1) / 20.0));
            string penflag = "BK";
            Pen pen = new Pen(Color.Red);
            pen.Width = 1;
            Font arial = new Font("arial", 7, FontStyle.Regular);
            Font title = new Font("arial", 12, FontStyle.Bold);
            Font heading = new Font("arial", 7, FontStyle.Bold);
            Font leaders = new Font("arial", 9, FontStyle.Bold);

            ev.Graphics.DrawString("Tracking History - by Item Code, Tracking Id and Moved Out Date (Last 90 Days)", title, Brushes.Black, 25, 40);
            ev.Graphics.DrawString("Printed: " + date, heading, Brushes.Black, 800, 25);
            ev.Graphics.DrawString("Page  " + pageNo + " of " + NumPages, heading, Brushes.Black, 800, 50);

            ev.Graphics.DrawString("Item Code", heading, Brushes.Black, 60, 80);
            ev.Graphics.DrawString("Operator", heading, Brushes.Black, 150, 80);
            ev.Graphics.DrawString("Location", heading, Brushes.Black, 240, 80);
            ev.Graphics.DrawString("Moved To Date", heading, Brushes.Black, 390, 80);
            ev.Graphics.DrawString("To Qty", heading, Brushes.Black, 490, 80);
            ev.Graphics.DrawString("Moved Out Date", heading, Brushes.Black, 540, 80);
            ev.Graphics.DrawString("Out Qty", heading, Brushes.Black, 645, 80);
            ev.Graphics.DrawString("Orig Qty", heading, Brushes.Black, 690, 80);
            ev.Graphics.DrawString("MK Rcpt", heading, Brushes.Black, 745, 80);
            ev.Graphics.DrawString("El Time", heading, Brushes.Black, 805, 80);
            ev.Graphics.DrawString("Loc Trk#", heading, Brushes.Black, 850, 80);
            ev.Graphics.DrawString("KB Trn ID", heading, Brushes.Black, 910, 80);
            ev.Graphics.DrawString("RMA Itm#", heading, Brushes.Black, 970, 80);
            ev.Graphics.DrawString("Svc ID", heading, Brushes.Black, 1025, 80);

            while (count < linesPerpage && lineNo < i)
            {
                if (MkReceiptTransactionID[lineNo] == MkReceiptTransactionID[lineNo + 1] && trackerIDPrinted == false)
                /*||
                MkReceiptTransactionID[lineNo] != MkReceiptTransactionID[lineNo + 1] && trackerIDPrinted == false)*/
                {
                    linedrop = linedrop + 10;
                    ev.Graphics.DrawString("Trkr ID:  " +
                        MkReceiptTransactionID[lineNo], heading, Brushes.Black, 25, linedrop);
                    trackerIDPrinted = true;
                    linedrop = linedrop + 20;
                    count++;
                }
                else
                {
                    trackerIDPrinted = false;
                }

                ev.Graphics.DrawString(partNumber[lineNo], arial, Brushes.Black, 60, linedrop);
                ev.Graphics.DrawString(operatorName[lineNo], arial, Brushes.Black, 150, linedrop);
                ev.Graphics.DrawString(Location[lineNo], arial, Brushes.Black, 240, linedrop);
                ev.Graphics.DrawString(MovedToDate[lineNo], arial, Brushes.Black, 390, linedrop);
                ev.Graphics.DrawString(MovedToQty[lineNo], arial, Brushes.Black, 500, linedrop);
                ev.Graphics.DrawString(MovedOutDate[lineNo], arial, Brushes.Black, 540, linedrop);
                ev.Graphics.DrawString(MovedOutQty[lineNo], arial, Brushes.Black, 660, linedrop);
                ev.Graphics.DrawString(OriginalQty[lineNo], arial, Brushes.Black, 700, linedrop);
                ev.Graphics.DrawString(receiptNumber[lineNo], arial, Brushes.Black, 745, linedrop);
                ev.Graphics.DrawString(TimeInMin[lineNo], arial, Brushes.Black, 805, linedrop);
                ev.Graphics.DrawString(locationTrackID[lineNo], arial, Brushes.Black, 850, linedrop);
                ev.Graphics.DrawString(KanbanXID[lineNo], arial, Brushes.Black, 910, linedrop);
                ev.Graphics.DrawString(RMaID[lineNo], arial, Brushes.Black, 970, linedrop);
                ev.Graphics.DrawString(ServiceID[lineNo], arial, Brushes.Black, 1025, linedrop);

                lineNo++;
                count++;
                linedrop = linedrop + 20;
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
