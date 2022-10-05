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


namespace ActionRequiredShortPPS
{
    public partial class ActionShortPPS : Form
    {
        private string[] id = new string[20000];
        private string[] lateflag = new string[20000];
        private string[] stkout = new string[20000];
        private string[] itemcode = new string[20000];
        private string[] description = new string[20000];
        private string[] comments = new string[20000];
        private string[] commentWrap = new string[20000];
        private string[] qtyneeded = new string[20000];
        private string[] origdate = new string[20000];
        private string[] reqdate = new string[20000];
        private string[] currduedate = new string[20000];
        private string[] buyer = new string[20000];
        private string[] qty = new string[20000];
        private string[] po = new string[20000];
        private string[] supplier = new string[20000];
        private string[] dateaddedtolist = new string[20000];
        private string[] group = new string[20000];
        private string[] hot = new string[20000];
        private string[] cWrap = new string[20000];
        private string[] dWrap = new string[20000];
        private int i = 0;
        private int statusCount = 1;
        private int pagesPrinted = 0;
        private bool statusPrinted = false;
        private bool typePrinted = false;
        private bool locationPrinted = false;
        private int lineNo = 0;
        DataTable table;
        private System.Windows.Forms.ToolStripButton ToolStripButton;
        PrintPreviewDialog ppd;
        PrintDocument pd;

        public ActionShortPPS()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL01; password = Read+Write!; " +
            SqlConnection cnxn = new SqlConnection("server = MIDSQL01; password = Read+Write!; " +
          "user = readwrite; database = AccessFrontEnds;");

            SqlCommand cmd = new SqlCommand("spShortageReports");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PRODUCTLINE", SqlDbType.NVarChar).Value = "PPS";
            cmd.Parameters.Add("@Action", SqlDbType.NVarChar).Value = -1;
            cmd.Connection = cnxn;

            cnxn.Open();

            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0)) { id[i] = dr.GetInt32(0).ToString(); }
                if (!dr.IsDBNull(1)) { lateflag[i] = dr.GetString(1); }
                if (!dr.IsDBNull(2)) { stkout[i] = dr.GetString(2); }
                if (!dr.IsDBNull(3)) { itemcode[i] = dr.GetString(3); }

                if (!dr.IsDBNull(4)) { description[i] = dr.GetString(4).Trim(); }
                if (!dr.IsDBNull(5)) { comments[i] = dr.GetString(5).Trim(); }
                if (!dr.IsDBNull(6)) { qtyneeded[i] = dr.GetString(6); }

                if (!dr.IsDBNull(7)) { origdate[i] = dr.GetDateTime(7).ToShortDateString(); }
                if (!dr.IsDBNull(8)) { reqdate[i] = dr.GetDateTime(8).ToShortDateString(); }
                if (!dr.IsDBNull(9)) { currduedate[i] = dr.GetDateTime(9).ToShortDateString(); }
                if (!dr.IsDBNull(10)) { buyer[i] = dr.GetString(10); }
                if (!dr.IsDBNull(11)) { qty[i] = dr.GetString(11); }
                if (!dr.IsDBNull(12)) { po[i] = dr.GetString(12); }
                if (!dr.IsDBNull(13)) { supplier[i] = dr.GetString(13); }
                if (!dr.IsDBNull(14))
                {
                    dateaddedtolist[i] = dr.GetDateTime(14).ToShortDateString();
                }
                if (!dr.IsDBNull(15)) { group[i] = dr.GetString(15); }
                if (!dr.IsDBNull(16)) { hot[i] = dr.GetString(16); }

                //word wrap Comments
                if (!dr.IsDBNull(5))
                {
                    if (dr.GetString(5).Length > 40)
                    {
                        string text = dr.GetString(5);
                        text = text.Replace("\r\n", " ");
                        int totalLength = dr.GetString(5).Length;
                        int loops = (totalLength / 40) + 2;

                        int lastword = text.Substring(0, 40).LastIndexOf(" ");
                        comments[i] = text.Substring(0, lastword);
                        cWrap[i] = "Y";
                        i++;

                        for (int n = 1; n < text.Length; n++)
                        {

                            if (text.Length > 40)
                            {
                                text = text.Substring(lastword + 1, (text.Length - (lastword + 1)));
                            }

                            if (text.Length > 40)
                            {
                                lastword = text.Substring(0, 40).LastIndexOf(" ");
                                comments[i] = text.Substring(0, lastword);
                                cWrap[i] = "Y";
                            }
                            else
                            {
                                comments[i] = text;
                                text = "";
                                cWrap[i] = "N";
                            }

                            id[i] = "";
                            // need to make sure that lateflag always has an entry as
                            // lateflag is compared for grouping
                            lateflag[i] = lateflag[i - 1];
                            stkout[i] = "";
                            itemcode[i] = "";
                            description[i] = "";
                            qtyneeded[i] = "";
                            origdate[i] = "";
                            reqdate[i] = "";
                            currduedate[i] = "";
                            buyer[i] = "";
                            qty[i] = "";
                            po[i] = "";
                            supplier[i] = "";
                            dateaddedtolist[i] = "";
                            group[i] = "";
                            hot[i] = "";
                            i++;
                        }
                    }
                    else
                    {
                        comments[i] = dr.GetString(5).Trim();
                        cWrap[i] = "N";
                        i++;
                    }
                }
            }
            cnxn.Close();

            pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = true;
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            directPrint();

            Close();
        }

        private void directPrint()
        {
            try
            {
                PrintDialog pDlg = new PrintDialog();
                // dialog box won't show without this line below.
                pDlg.UseEXDialog = true;
                pDlg.Document = pd;

                if (pDlg.ShowDialog() == DialogResult.OK)
                {
                    pd.Print();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            string date = DateTime.Now.ToString();
            int linedrop = 100;
            int count = 0;
            int linesPerpage = 35;
            //int lineNo = this.pagesPrinted * linesPerpage;
            int pageNo = pagesPrinted + 1;
            double NumPages = Math.Ceiling(((i - 1) / 35.0));
            Pen pen = new Pen(Color.Black);
            pen.Width = 1;
            Font arial = new Font("arial", 6, FontStyle.Regular);
            Font title = new Font("arial", 12, FontStyle.Bold);
            Font heading = new Font("arial", 6, FontStyle.Bold);
            Font leaders = new Font("arial", 6, FontStyle.Bold);

            ev.Graphics.DrawString("ZYGO PPS ACTION REQUIRED SHORTAGE LIST REPORT", title, Brushes.Black, 15, 40);
            ev.Graphics.DrawString("Printed: " + date, heading, Brushes.Black, 800, 25);
            ev.Graphics.DrawString("Page  " + pageNo + " of " + NumPages, heading, Brushes.Black, 800, 50);

            ev.Graphics.DrawString("ID", heading, Brushes.Black, 15, 80);
            ev.Graphics.DrawString("Stk", heading, Brushes.Black, 43, 67);
            ev.Graphics.DrawString("Out?", heading, Brushes.Black, 43, 80);
            ev.Graphics.DrawString("ItemCode", heading, Brushes.Black, 70, 80);
            ev.Graphics.DrawString("Description", heading, Brushes.Black, 138, 80);
            ev.Graphics.DrawString("Comments", heading, Brushes.Black, 300, 80);
            ev.Graphics.DrawString("Rqd Qty", heading, Brushes.Black, 465, 80);
            ev.Graphics.DrawString("Orig Date", heading, Brushes.Black, 515, 80);
            ev.Graphics.DrawString("Req Date", heading, Brushes.Black, 565, 80);
            ev.Graphics.DrawString("Conf Due Date", heading, Brushes.Black, 615, 80);
            ev.Graphics.DrawString("Buyer", heading, Brushes.Black, 700, 80);
            ev.Graphics.DrawString("Qty", heading, Brushes.Black, 775, 80);
            ev.Graphics.DrawString("PO/WO", heading, Brushes.Black, 810, 80);
            ev.Graphics.DrawString("Supplier", heading, Brushes.Black, 850, 80);
            ev.Graphics.DrawString("Date", heading, Brushes.Black, 920, 67);
            ev.Graphics.DrawString("Added", heading, Brushes.Black, 920, 80);
            ev.Graphics.DrawString("Group", heading, Brushes.Black, 980, 80);
            ev.Graphics.DrawString("HOT?", heading, Brushes.Black, 1025, 80);
            ev.Graphics.DrawLine(pen, 15, 95, 1050, 95);

            while (count < linesPerpage && lineNo < i)
            {
                if (statusPrinted == false)
                {
                    linedrop = linedrop + 5;
                    pen.Color = Color.Red;
                    pen.Width = 2;

                    if (lineNo > 2 && group[lineNo - 1] == "Optics")
                    { pen.Color = Color.Blue; }

                    if (group[lineNo + 1] != "Optics")
                    { pen.Color = Color.Red; }

                    ev.Graphics.DrawLine(pen, 15, linedrop, 1050, linedrop);
                    pen.Width = 1;
                    pen.Color = Color.Blue;
                    linedrop = linedrop + 5;
                    ev.Graphics.DrawString("STATUS:  " +
                        lateflag[lineNo], heading, Brushes.Black, 15, linedrop);
                    statusPrinted = true;
                    linedrop = linedrop + 15;
                    count++;
                }

                ev.Graphics.DrawString(id[lineNo], arial, Brushes.Black, 15, linedrop);
                ev.Graphics.DrawString(stkout[lineNo], arial, Brushes.Black, 45, linedrop);
                ev.Graphics.DrawString(itemcode[lineNo], arial, Brushes.Black, 70, linedrop);
                ev.Graphics.DrawString(description[lineNo], arial, Brushes.Black, 138, linedrop);
                ev.Graphics.DrawString(comments[lineNo], arial, Brushes.Black, 300, linedrop);
                ev.Graphics.DrawString(qtyneeded[lineNo], arial, Brushes.Black, 470, linedrop);
                ev.Graphics.DrawString(origdate[lineNo], arial, Brushes.Black, 515, linedrop);
                ev.Graphics.DrawString(reqdate[lineNo], arial, Brushes.Black, 565, linedrop);
                ev.Graphics.DrawString(currduedate[lineNo], arial, Brushes.Black, 615, linedrop);
                ev.Graphics.DrawString(buyer[lineNo], arial, Brushes.Black, 700, linedrop);
                ev.Graphics.DrawString(qty[lineNo], arial, Brushes.Black, 775, linedrop);
                ev.Graphics.DrawString(po[lineNo], arial, Brushes.Black, 810, linedrop);
                ev.Graphics.DrawString(supplier[lineNo], arial, Brushes.Black, 850, linedrop);
                ev.Graphics.DrawString(dateaddedtolist[lineNo], arial, Brushes.Black, 920, linedrop);
                ev.Graphics.DrawString(group[lineNo], arial, Brushes.Black, 980, linedrop);

                if (hot[lineNo] == "HOT")
                {
                    ev.Graphics.DrawString(hot[lineNo], leaders, Brushes.Black, 1025, linedrop);
                }



                if (cWrap[lineNo] == "N")
                {
                    if (lateflag[lineNo] != lateflag[lineNo + 1] && statusPrinted == true)
                    {
                        statusPrinted = false;
                    }

                    if (lateflag[lineNo] == lateflag[lineNo + 1] && statusPrinted == true && group[lineNo] == "Optics")
                    {
                        statusPrinted = false;
                    }

                    pen.Color = Color.Blue;
                    ev.Graphics.DrawLine(pen, 15, linedrop + 14, 1050, linedrop + 14);
                    linedrop = linedrop + 20;
                }
                else
                {
                    linedrop = linedrop + 12;
                }

                lineNo++;
                count++;
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

