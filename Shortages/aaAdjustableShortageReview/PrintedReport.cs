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
    public partial class PrintedReport : Form
    {
        private string[] id = new string[20000];
        private string[] nonprintingid = new string[20000];
        private string[] lateflag = new string[20000];
        private string[] inspect = new string[20000];
        private string[] itemcode = new string[20000];
        private string[] description = new string[20000];
        private string[] comments = new string[20000];
        private string[] commentWrap = new string[20000];
        private string[] qtyneeded = new string[20000];
        private string[] origRequestedDate = new string[20000];
        private string[] reqdate = new string[20000];
        private string[] ConfDueDate = new string[20000];
        private string[] IQCCompleteDate = new string[20000];
        private string[] buyer = new string[20000];
        private string[] qty = new string[20000];
        private string[] po = new string[20000];
        private string[] supplier = new string[20000];
        private string[] dateaddedtolist = new string[20000];
        private string[] group = new string[20000];
        private string[] hot = new string[20000];
        private string[] project = new string[20000];
        private string[] cWrap = new string[20000];
        private string[] dWrap = new string[20000];
        private string[] itemStatus = new string[20000];
        private string currentItemStatus;
        private int i = 0;
        //private int statusCount = 1;
        private int pagesPrinted = 0;
        private bool statusPrinted = false;
        private bool itemStatusPrinted = false;
        private bool wholeLinePrinted = false;
        //private bool idGroup = true;
        private int lineNo = 0;
        DataTable table;
        private System.Windows.Forms.ToolStripButton ToolStripButton;
        PrintDialog pDlg;
        PrintPreviewDialog ppd;
        PrintDocument pd;

        public PrintedReport()
        {
            InitializeComponent();
        }

        private void PrintedReport_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(g.db);
            
            /*  part A for the non IQC data    */
            SqlCommand cmd = new SqlCommand("spShortageReportV05a");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PRODUCTLINE", SqlDbType.NVarChar).Value = g.ProductLine;
            cmd.Parameters.Add("@Action", SqlDbType.NVarChar).Value = DBNull.Value;
            cmd.Connection = cnxn;

            /*  part B for the IQC data    */
            SqlCommand cmd1 = new SqlCommand("spShortageReportV05b");
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("@PRODUCTLINE", SqlDbType.NVarChar).Value = g.ProductLine;
            cmd1.Parameters.Add("@Action", SqlDbType.NVarChar).Value = DBNull.Value;
            cmd1.Connection = cnxn;

            cnxn.Open();

            try
            {
                /*  table A non-IQC data    */
                SqlDataReader sr = cmd.ExecuteReader();
                DataTable dta = new DataTable();
                dta.Load(sr);

                /*  table B IQC data    */
                sr = cmd1.ExecuteReader();
                DataTable dtb = new DataTable();
                dtb.Load(sr);

                /*  merge the two tables a before b  */
                dta.Merge(dtb);
                
                DataTableReader dr = dta.CreateDataReader();

                //dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        id[i] = dr.GetInt32(0).ToString();
                        //if (dr.GetInt32(0).ToString() == "29516")
                        //{
                        //    string xx = "found";
                        //}
                        nonprintingid[i] = dr.GetInt32(0).ToString();
                    }

                    if (!dr.IsDBNull(1)) { lateflag[i] = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { inspect[i] = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { itemcode[i] = dr.GetString(3); }

                    if (!dr.IsDBNull(4)) { description[i] = dr.GetString(4).Trim(); }
                    //if (!dr.IsDBNull(5))
                    //{
                    //    comments[i] = dr.GetString(5).Trim();
                    //}

                    if (!dr.IsDBNull(6))
                    {
                        if (dr.GetString(6).Length > 4)
                        {
                            qtyneeded[i] = dr.GetString(6).Substring(0, 4);
                        }
                        else
                        {
                            qtyneeded[i] = dr.GetString(6);
                        }
                    }

                    if (!dr.IsDBNull(7)) { origRequestedDate[i] = dr.GetDateTime(7).ToString("MM/dd/yy"); }
                    if (!dr.IsDBNull(8)) { reqdate[i] = dr.GetDateTime(8).ToString("MM/dd/yy"); }
                    if (!dr.IsDBNull(9)) { ConfDueDate[i] = dr.GetDateTime(9).ToString("MM/dd/yy"); }
                    if (!dr.IsDBNull(10)) { IQCCompleteDate[i] = dr.GetDateTime(10).ToString("MM/dd/yy"); }
                    if (!dr.IsDBNull(11)) { buyer[i] = dr.GetString(11); }
                    if (!dr.IsDBNull(12))
                    {
                        if (dr.GetString(12).Length > 4)
                        {
                            qty[i] = dr.GetString(12).Substring(0, 4);
                        }
                        else
                        {
                            qty[i] = dr.GetString(12);
                        }
                    }
                    if (!dr.IsDBNull(13)) { po[i] = dr.GetString(13); }
                    if (!dr.IsDBNull(14)) { supplier[i] = dr.GetString(14); }
                    if (!dr.IsDBNull(15))
                    {
                        dateaddedtolist[i] = dr.GetDateTime(15).ToShortDateString();
                    }
                    if (!dr.IsDBNull(16)) { group[i] = dr.GetString(16); }

                    if (!dr.IsDBNull(17)) { project[i] = dr.GetString(17); }

                    if (!dr.IsDBNull(18)) { itemStatus[i] = dr.GetString(18); }

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
                                    nonprintingid[i] = dr.GetInt32(0).ToString();
                                    cWrap[i] = "Y";
                                }
                                else
                                {
                                    comments[i] = text;
                                    text = "";
                                    cWrap[i] = "N";
                                    nonprintingid[i] = dr.GetInt32(0).ToString();
                                }

                                id[i] = "";
                                // need to make sure that lateflag always has an entry as
                                // lateflag is compared for grouping
                                lateflag[i] = lateflag[i - 1];
                                inspect[i] = "";
                                itemcode[i] = "";
                                description[i] = "";
                                qtyneeded[i] = "";
                                origRequestedDate[i] = "";
                                reqdate[i] = "";
                                ConfDueDate[i] = "";
                                IQCCompleteDate[i] = "";
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
                            nonprintingid[i] = dr.GetInt32(0).ToString();
                            i++;
                        }
                    }
                    else
                    {
                        comments[i] = "No Comments Entered";
                        i++;
                    }
                }
                cnxn.Close();


                /*
                 * 
                 * Print Dialog is contained in Direct Print.
                 * 
                //For testing purposes:
                pDlg = new PrintDialog();
                pDlg.ShowDialog();
                */

                pd = new PrintDocument();
                pd.DefaultPageSettings.Landscape = true;
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                directPrint();     /*   this is the spot to uncomment     */

                /*
                 * 
                 * Elaine wants the print dialog box but not the preview.
                 * 
                 * */

                /*  //start debug section
                ppd = new PrintPreviewDialog();
                ppd.Document = pd;
                (ppd as Form).WindowState = FormWindowState.Maximized;
                ppd.ShowDialog();
                */   //end debug section
                //this.ToolStripButton = new ToolStripButton();
                //this.ToolStripButton.Image = ((System.Windows.Forms.ToolStrip)(ppd.Controls[1])).ImageList.Images[0];
                //this.ToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
                //this.ToolStripButton.Click += new System.EventHandler(printPreview_printClick);
                //((System.Windows.Forms.ToolStrip)(ppd.Controls[1])).Items.RemoveAt(0);
                //((System.Windows.Forms.ToolStrip)(ppd.Controls[1])).Items.Insert(0, ToolStripButton);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }

            Close();
        }

        //private void printPreview_printClick(object sender, System.EventArgs ee)
        private void directPrint()
        {
            try
            {

                PrintDialog pDlg = new PrintDialog();
                // dialog box won't show without this line below.
                pDlg.UseEXDialog = true;
                pDlg.Document = pd;

                //pd.PrinterSettings.Collate = true;
                //pd.PrinterSettings.PrinterName = @"\\midprtsrv\inst_iR3235PS";
                //pd.PrinterSettings.PrinterName = @"\\midprtsrv\mktg_iRC3220PS";
                //pd.PrinterSettings.Copies = 2;
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
            double NumPages = Math.Ceiling(((i - 1) / 34.0));
            Pen pen = new Pen(Color.Black);
            pen.Width = 1;
            Font arial = new Font("arial", 6, FontStyle.Regular);
            Font title = new Font("arial", 12, FontStyle.Bold);
            Font heading = new Font("arial", 6, FontStyle.Bold);
            Font leaders = new Font("arial", 6, FontStyle.Bold);

            ev.Graphics.DrawString("ZYGO " + g.ProductLine + " ACTIVE SHORTAGE LIST REPORT", title, Brushes.Black, 15, 40);
            ev.Graphics.DrawString("Printed: " + date, heading, Brushes.Black, 800, 25);
            ev.Graphics.DrawString("Page  " + pageNo + " of " + NumPages, heading, Brushes.Black, 800, 50);

            ev.Graphics.DrawString("ID", heading, Brushes.Black, 15, 80);
            ev.Graphics.DrawString("Insp", heading, Brushes.Black, 43, 67);
            ev.Graphics.DrawString("Code", heading, Brushes.Black, 43, 80);
            ev.Graphics.DrawString("ItemCode", heading, Brushes.Black, 70, 80);
            ev.Graphics.DrawString("Description", heading, Brushes.Black, 138, 80);
            ev.Graphics.DrawString("Comments", heading, Brushes.Black, 300, 80);
            ev.Graphics.DrawString("Rqd Qty", heading, Brushes.Black, 455, 80);
            ev.Graphics.DrawString("Require", heading, Brushes.Black, 500, 80);
            ev.Graphics.DrawString("Request ", heading, Brushes.Black, 540, 80);
            ev.Graphics.DrawString("Promise", heading, Brushes.Black, 580, 80);
            ev.Graphics.DrawString("IQCmplt", heading, Brushes.Black, 620, 80);
            ev.Graphics.DrawString("Buyer", heading, Brushes.Black, 700, 80);
            ev.Graphics.DrawString("Qty", heading, Brushes.Black, 775, 80);
            ev.Graphics.DrawString("PO/WO", heading, Brushes.Black, 810, 80);
            ev.Graphics.DrawString("Supplier", heading, Brushes.Black, 850, 80);
            ev.Graphics.DrawString("Date", heading, Brushes.Black, 920, 67);
            ev.Graphics.DrawString("Added", heading, Brushes.Black, 920, 80);
            ev.Graphics.DrawString("Group", heading, Brushes.Black, 980, 80);
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
                    /*   draw line   */
                    ev.Graphics.DrawLine(pen, 15, linedrop, 1050, linedrop);
                    pen.Width = 1;
                    pen.Color = Color.Blue;
                    linedrop = linedrop + 5;
                    /*  write text  */
                    ev.Graphics.DrawString("STATUS:  " +
                        lateflag[lineNo], heading, Brushes.Black, 15, linedrop);
                    statusPrinted = true;
                    linedrop = linedrop + 15;
                    count++;
                }
                
                if (itemStatusPrinted == false & itemStatus[lineNo] != null)
                {
                    linedrop = linedrop + 5;
                    pen.Color = Color.Green;
                    pen.Width = 2;

                    /*   draw line   */
                    ev.Graphics.DrawLine(pen, 15, linedrop, 1050, linedrop);
                    pen.Width = 1;
                    pen.Color = Color.Blue;
                    linedrop = linedrop + 5;
                    /*  write text  */
                    ev.Graphics.DrawString("Item Status:  " +
                        itemStatus[lineNo], heading, Brushes.Black, 50, linedrop);

                    currentItemStatus = itemStatus[lineNo];
                    itemStatusPrinted = true;

                    linedrop = linedrop + 15;
                    count++;
                }


                if (wholeLinePrinted == false)
                {
                    ev.Graphics.DrawString(id[lineNo], arial, Brushes.Black, 15, linedrop);
                    ev.Graphics.DrawString(inspect[lineNo], arial, Brushes.Black, 50, linedrop);
                    ev.Graphics.DrawString(itemcode[lineNo], arial, Brushes.Black, 70, linedrop);
                    ev.Graphics.DrawString(description[lineNo], arial, Brushes.Black, 138, linedrop);
                    ev.Graphics.DrawString(comments[lineNo], arial, Brushes.Black, 300, linedrop);
                    ev.Graphics.DrawString(qtyneeded[lineNo], arial, Brushes.Black, 470, linedrop);

                    ev.Graphics.DrawString(reqdate[lineNo], arial, Brushes.Black, 500, linedrop);
                    ev.Graphics.DrawString(origRequestedDate[lineNo], arial, Brushes.Black, 540, linedrop);
                    ev.Graphics.DrawString(ConfDueDate[lineNo], arial, Brushes.Black, 580, linedrop);
                    ev.Graphics.DrawString(IQCCompleteDate[lineNo], arial, Brushes.Black, 620, linedrop);
                    ev.Graphics.DrawString(buyer[lineNo], arial, Brushes.Black, 700, linedrop);
                    ev.Graphics.DrawString(qty[lineNo], arial, Brushes.Black, 775, linedrop);
                    ev.Graphics.DrawString(po[lineNo], arial, Brushes.Black, 810, linedrop);
                    ev.Graphics.DrawString(supplier[lineNo], arial, Brushes.Black, 850, linedrop);
                    ev.Graphics.DrawString(dateaddedtolist[lineNo], arial, Brushes.Black, 920, linedrop);

                    try
                    {
                        if (group[lineNo] != null && group[lineNo].Length > 2 && group[lineNo].ToString().ToUpper().Substring(0, 3) == "SER")
                        {
                            if ((group[lineNo].Length > 3 && group[lineNo].ToUpper().Substring(3, 1) != "V") | group[lineNo].Length == 3)
                            {
                                ev.Graphics.DrawString(group[lineNo].ToUpper() + "  " + project[lineNo], arial, Brushes.Red, 980, linedrop);
                                //group is normally 3 or more characters but..07-09-2018 someone made a mistake and it was only 1
                                //and caused an index error
                            }
                            else
                            {
                                ev.Graphics.DrawString(group[lineNo].ToUpper(), arial, Brushes.Black, 980, linedrop);
                            }
                        }
                        else
                        {
                            ev.Graphics.DrawString(group[lineNo], arial, Brushes.Black, 980, linedrop);
                        }

                        if (itemStatus[lineNo] != null)
                        {
                            ev.Graphics.DrawString(itemStatus[lineNo], arial, Brushes.Black, 1000, linedrop + 12);
                        }

                        wholeLinePrinted = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Line 439   " + ex.ToString());
                    }
                }
                else
                {
                    ev.Graphics.DrawString(comments[lineNo], arial, Brushes.Black, 300, linedrop);
                }

                /*
                 * 
                 * Problem area.  Only printing when more than one line
                 * 
                 * */

                if (nonprintingid[lineNo] != nonprintingid[lineNo + 1])
                {
                    /*  nonprintingid has all the id s on all the lines     */

                    if (lateflag[lineNo] != lateflag[lineNo + 1] && statusPrinted == true)
                    {
                        statusPrinted = false;
                    }

                    if (itemStatusPrinted & currentItemStatus != itemStatus[lineNo + 1])
                    {
                        /*  Green line concluding a section    */

                        linedrop = linedrop + 15;
                        pen.Color = Color.Green;
                        pen.Width = 2;

                        /*   draw line   */
                        ev.Graphics.DrawLine(pen, 15, linedrop, 1050, linedrop);
                        pen.Width = 1;
                        pen.Color = Color.Blue;

                        itemStatusPrinted = false;
                    }

                    pen.Color = Color.Blue;
                    ev.Graphics.DrawLine(pen, 15, linedrop + 14, 1050, linedrop + 14);
                    linedrop = linedrop + 20;
                    wholeLinePrinted = false;

                    
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
