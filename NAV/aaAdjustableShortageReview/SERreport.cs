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
    public partial class SERreport : Form
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
        private string[] projectDescription = new string[20000];
        private string[] cWrap = new string[20000];
        private string[] dWrap = new string[20000];
        private string[] iWrap = new string[20000];
        private string[] itemStatus = new string[20000];
        private string[] warboardDate = new string[20000];
        private string currentItemStatus;
        private int i = 0;
        private int cWrapStart = 0;
        private int pagesPrinted = 0;
        private bool statusPrinted = false;
        private bool itemStatusPrinted = false;
        private bool wholeLinePrinted = false;
        private bool projectPrinted = false;
        private bool wrapComments = false;
        private int lineNo = 0;
        DataTable table;
        private System.Windows.Forms.ToolStripButton ToolStripButton;
        PrintDialog pDlg;
        PrintPreviewDialog ppd;
        PrintDocument pd;

        public SERreport()
        {
            InitializeComponent();
        }

        private void SERreport_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL01; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;");

            SqlCommand cmd = new SqlCommand("spSERShortagesV01");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnxn;

            cnxn.Open();

            try
            {

                // table for Debugging

                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);


                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        warboardDate[i] = dr.GetDateTime(0).ToString("MMMM");
                    }

                    if (!dr.IsDBNull(1)) { project[i] = dr.GetString(1).ToUpper(); }

                    if (!dr.IsDBNull(2))
                    {
                        id[i] = dr.GetInt32(2).ToString();

                        nonprintingid[i] = dr.GetInt32(2).ToString();
                    }

                    //if (!dr.IsDBNull(3)) { lateflag[i] = dr.GetString(3); }
                    if (!dr.IsDBNull(3)) { inspect[i] = dr.GetString(3); }


                    if (!dr.IsDBNull(7))
                    {
                        if (dr.GetString(7).Length > 4)
                        {
                            qtyneeded[i] = dr.GetString(7).Substring(0, 4);
                        }
                        else
                        {
                            qtyneeded[i] = dr.GetString(7);
                        }
                    }

                    if (!dr.IsDBNull(8)) { origRequestedDate[i] = dr.GetDateTime(8).ToString("MM/dd/yy"); }
                    if (!dr.IsDBNull(9)) { reqdate[i] = dr.GetDateTime(9).ToString("MM/dd/yy"); }
                    if (!dr.IsDBNull(10)) { ConfDueDate[i] = dr.GetDateTime(10).ToString("MM/dd/yy"); }
                    if (!dr.IsDBNull(11)) { IQCCompleteDate[i] = dr.GetDateTime(11).ToString("MM/dd/yy"); }
                    if (!dr.IsDBNull(12)) { buyer[i] = dr.GetString(12); }
                    if (!dr.IsDBNull(13))
                    {
                        if (dr.GetString(13).Length > 4)
                        {
                            qty[i] = dr.GetString(13).Substring(0, 4);
                        }
                        else
                        {
                            qty[i] = dr.GetString(13);
                        }
                    }
                    if (!dr.IsDBNull(14)) { po[i] = dr.GetString(14); }
                    if (!dr.IsDBNull(15)) { supplier[i] = dr.GetString(15); }
                    if (!dr.IsDBNull(16))
                    {
                        dateaddedtolist[i] = dr.GetDateTime(16).ToShortDateString();
                    }
                    if (!dr.IsDBNull(17)) { group[i] = dr.GetString(17); }



                    if (!dr.IsDBNull(18)) { itemStatus[i] = dr.GetString(18); }

                    if (!dr.IsDBNull(19)) { projectDescription[i] = dr.GetString(19); }

                    /*  word wrap Comments  */
                    /*  need to know if the comments are wrapped before checking 
                     *  item number and description as can use the wrap created rows
                     */

                    if (!dr.IsDBNull(6))
                    {
                        if (dr.GetString(6).Length > 40)
                        {
                            string text = dr.GetString(6);
                            text = text.Replace("\r\n", " ");
                            int totalLength = dr.GetString(6).Length;
                            int loops = (totalLength / 40) + 2;

                            int lastword = text.Substring(0, 40).LastIndexOf(" ");
                            comments[i] = text.Substring(0, lastword);
                            wrapComments = true;
                            cWrapStart = i;
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
                                    nonprintingid[i] = dr.GetInt32(2).ToString();
                                }
                                else
                                {
                                    comments[i] = text;
                                    text = "";
                                    nonprintingid[i] = dr.GetInt32(2).ToString();
                                }

                                id[i] = "";
                                // need to make sure that fields below always have an entry as
                                /* they are compared for grouping   */
                                lateflag[i] = lateflag[i - 1];
                                warboardDate[i] = warboardDate[i - 1];
                                project[i] = project[i - 1];
                                /*      */
                                inspect[i] = "";
                                //itemcode[i] = "";
                                //description[i] = "";
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
                        else    /*  dr.GetString(6).Length < 41 */
                        {
                            comments[i] = dr.GetString(6).Trim();
                            wrapComments = false;
                            nonprintingid[i] = dr.GetInt32(2).ToString();
                            i++;
                        }
                    }
                    else
                    {
                        comments[i] = "No Comments Entered";
                        i++;
                    }

                    if (!dr.IsDBNull(4))
                    {
                        if (dr.GetString(4).Length > 12)
                        {
                            if (wrapComments)
                            {
                                itemcode[cWrapStart] = dr.GetString(4).Substring(0, 12);
                                itemcode[cWrapStart + 1] = dr.GetString(4).Substring(12, (dr.GetString(4).Length - 12));
                            }
                            else
                            {
                                itemcode[i] = dr.GetString(4).Substring(0, 12);
                                itemcode[i + 1] = dr.GetString(4).Substring(12, (dr.GetString(4).Length - 12));
                            }
                        }
                        else
                        {
                            if (wrapComments)
                            {
                                itemcode[cWrapStart] = dr.GetString(4);
                            }
                            else
                            {
                                itemcode[i - 1] = dr.GetString(4);
                            }
                        }

                    }

                    if (!dr.IsDBNull(5))
                    {
                        if (dr.GetString(5).Length > 30)
                        {
                            if (wrapComments)
                            {
                                description[cWrapStart] = dr.GetString(5).Substring(0, 30);
                                description[cWrapStart + 1] = dr.GetString(5).Substring(30, (dr.GetString(5).Length - 30));
                            }
                            else
                            {
                                description[i] = dr.GetString(5).Substring(0, 30);
                                description[i + 1] = dr.GetString(5).Substring(30, (dr.GetString(5).Length - 30));
                            }
                        }
                        else
                        {
                            if (wrapComments)
                            {
                                description[cWrapStart] = dr.GetString(5);
                            }
                            else
                            {
                                description[i - 1] = dr.GetString(5);
                            }
                        }
                    }
                }
                cnxn.Close();

                pd = new PrintDocument();
                pd.DefaultPageSettings.Landscape = true;
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                directPrint();
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
            Font title16 = new Font("arial", 16, FontStyle.Bold);
            Font heading = new Font("arial", 6, FontStyle.Bold);
            Font leader10 = new Font("arial", 8, FontStyle.Regular);

            ev.Graphics.DrawString("WARBOARD  -  " + warboardDate[lineNo], title16, Brushes.Black, 15, 25);
            ev.Graphics.DrawString("Printed: " + date, heading, Brushes.Black, 800, 25);
            ev.Graphics.DrawString("ZYGO ACTIVE SHORTAGE LIST REPORT", title, Brushes.Black, 15, 50);
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
                if (projectPrinted == false)
                {
                    itemStatusPrinted = false;

                    linedrop = linedrop + 5;
                    pen.Color = Color.LightBlue;
                    pen.Width = 8;
                    /*   draw line Light Blue line to separate projects   */
                    ev.Graphics.DrawLine(pen, 15, linedrop, 1050, linedrop);
                    linedrop = linedrop + 5;

                    /*  reset line color and width  */
                    pen.Width = 1;
                    pen.Color = Color.Blue;

                    /*  go to nav and get planner and planned ship date  */

                    if (project[lineNo] != null)
                    {

                        SqlConnection cnxnNAV = new SqlConnection("server = pa-hor-AS408.ametek.com; password = 2018#ameteK; " +
                                      "user = navdb_read; database = ZYGO-NAV-PROD;");

                        try
                        {
                            SqlDataAdapter da1 = new SqlDataAdapter(
                                " SELECT " +
                                " [Buyer_Planner Code] " +
                                " ,FORMAT([Planned Shipment Date],'MM-dd-yy') " +
                                " FROM [ZYGO$Job] j INNER JOIN [ZYGO$Sales Line] l on j.No_ = l.[Job No_] " +
                                "WHERE j.No_ = '" + project[lineNo].ToString() + "'", cnxnNAV);
                            table = new DataTable();
                            da1.Fill(table);
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            cnxnNAV.Close();
                        }

                        if (table.Rows.Count > 0)
                        {
                            /*  write text  */
                            ev.Graphics.DrawString("SER:  " +
                                project[lineNo] + "  " + projectDescription[lineNo] +
                                "    " + table.Rows[0][0].ToString() + "  Shipping:  " + table.Rows[0][1].ToString(), title, Brushes.Black, 15, linedrop);
                        }
                        else
                        {
                            /*  write text  */
                            ev.Graphics.DrawString("SER:  " +
                                project[lineNo] + "  " + projectDescription[lineNo], title, Brushes.Black, 15, linedrop);
                        }

                    }
                    else
                    {
                        /*  write text  */
                        ev.Graphics.DrawString("SER:  " +
                            project[lineNo] + "  " + projectDescription[lineNo], title, Brushes.Black, 15, linedrop);

                    }

                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Connection = cnxn;


                    projectPrinted = true;
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
                    if (itemStatus[lineNo] != null && (itemStatus[lineNo].ToString() == "IQC" | itemStatus[lineNo].ToString() == "FAI"))
                    {
                        //linedrop = linedrop + 5;
                        pen.Color = Color.MediumPurple;
                        pen.Width = 5;

                        /*   draw line   */
                        ev.Graphics.DrawLine(pen, 15, linedrop, 150, linedrop);

                        pen.Width = 1;
                        pen.Color = Color.Blue;
                        linedrop = linedrop + 5;
                    }
                    else if (itemStatus[lineNo] != null && (itemStatus[lineNo].ToString() == "FAST"))
                    {
                        //linedrop = linedrop + 5;
                        pen.Color = Color.Salmon;
                        pen.Width = 5;

                        /*   draw line   */
                        ev.Graphics.DrawLine(pen, 15, linedrop, 150, linedrop);

                        pen.Width = 1;
                        pen.Color = Color.Blue;
                        linedrop = linedrop + 5;
                    }
                    else if (itemStatus[lineNo] != null && (itemStatus[lineNo].ToString() == "MOVED"))
                    {
                        //linedrop = linedrop + 5;
                        pen.Color = Color.Green;
                        pen.Width = 5;

                        /*   draw line   */
                        ev.Graphics.DrawLine(pen, 15, linedrop, 150, linedrop);

                        pen.Width = 1;
                        pen.Color = Color.Blue;
                        linedrop = linedrop + 5;

                    }

                    ev.Graphics.DrawString(id[lineNo], arial, Brushes.Black, 15, linedrop);
                    ev.Graphics.DrawString(description[lineNo], arial, Brushes.Black, 138, linedrop);

                    ev.Graphics.DrawString(inspect[lineNo], arial, Brushes.Black, 50, linedrop);


                    if (Convert.ToDateTime(reqdate[lineNo]) < Convert.ToDateTime(ConfDueDate[lineNo]) && (itemStatus[lineNo] != "IQC" & itemStatus[lineNo] != "FAI"))
                    {
                        ev.Graphics.DrawString(itemcode[lineNo], leader10, Brushes.Red, 60, linedrop);
                    }
                    else
                    {
                        ev.Graphics.DrawString(itemcode[lineNo], leader10, Brushes.Black, 60, linedrop);
                    }


                    
                    ev.Graphics.DrawString(comments[lineNo], arial, Brushes.Black, 300, linedrop);
                    ev.Graphics.DrawString(qtyneeded[lineNo], arial, Brushes.Black, 470, linedrop);

                    ev.Graphics.DrawString(reqdate[lineNo], arial, Brushes.Black, 500, linedrop);
                    ev.Graphics.DrawString(origRequestedDate[lineNo], arial, Brushes.Black, 540, linedrop);

                    if (ConfDueDate[lineNo] != null && ConfDueDate[lineNo].ToString().Length > 0)
                    {
                        ev.Graphics.DrawString(ConfDueDate[lineNo], arial, Brushes.Black, 580, linedrop);
                    }
                    else
                    {
                        pen.Color = Color.Orange;
                        pen.Width = 5;

                        /*   draw line   */
                        ev.Graphics.DrawLine(pen, 580, linedrop + 4, 630, linedrop + 4);

                        pen.Width = 1;
                        pen.Color = Color.Blue;
                    }


                    

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
                                ev.Graphics.DrawString(group[lineNo].ToUpper() + "  " + project[lineNo], arial, Brushes.Black, 980, linedrop);
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
                    ev.Graphics.DrawString(itemcode[lineNo], leader10, Brushes.Black, 60, linedrop);
                    ev.Graphics.DrawString(description[lineNo], arial, Brushes.Black, 138, linedrop);
                }

                /*
                 * 
                 * Problem area.  Only printing when more than one line
                 * 
                 * */

                if (nonprintingid[lineNo] != nonprintingid[lineNo + 1])
                {
                    /*  nonprintingid has all the id s on all the lines     */

                    if (project[lineNo] != project[lineNo + 1] && projectPrinted == true)
                    {
                        projectPrinted = false;
                    }

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

                if (warboardDate[lineNo] != warboardDate[lineNo + 1])
                {
                    count = 100;
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
