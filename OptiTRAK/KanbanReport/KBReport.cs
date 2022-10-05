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

namespace KanbanReport
{
    public partial class KBReport : Form
    {
        private string[] plannerinitials = new string[20000];
        private string[] customer = new string[20000];
        private string[] project = new string[20000];
        private string[] elementname = new string[20000];
        private string[] elementWrap = new string[20000];
        private string[] itemcode = new string[20000];
        private string[] kblocation = new string[20000];
        private string[] locationWrap = new string[20000];
        private string[] WIP = new string[20000];
        private string[] INV = new string[20000];
        private string[] total = new string[20000];
        private string[] min = new string[20000];
        private string[] max = new string[20000];
        private string[] parentitemcode = new string[20];
        private string[] BOMitemcode = new string[20];
        private string[] BOMitem = new string[20];
        private string[] BOMitemWRAP = new string[20];
        private string[] BOMlevel = new string[20];
        private int[] BOMwip = new int[20];
        private int[] BOMinv = new int[20];
        private string[] BOMlocation = new string[20];
        //private int[] BOMtotal = new int[20];
        private int kbtotal;
        private int i = 0;
        private int ii = 0;
        private int sourceCount = 1;
        private int pagesPrinted = 0;
        private bool rawPrinted = false;
        private bool finishedPrinted = false;
        private int lineNo = 0;

        SqlCommand cmd;
        SqlConnection cnxn;
        SqlDataReader dr;

        public KBReport()
        {
            InitializeComponent();
        }

        private void KBReport_Load(object sender, EventArgs e)
        {
            string applicationVersion = Application.ProductVersion.Trim();
            this.Text = "Kanban Report   v" + applicationVersion;
            
            cnxn = new SqlConnection(g.db);

            cmd = new SqlCommand
                ("select  " +
                 "PlannerInitials, " +
                 "Customer, " +
                 "Project, " +
                 "ElementName, " +
                 "Item_Code, " +
                 "KB_location, " +
                 "WIP, " +
                 "INV, " +
                 "WIP + INV Total, " +
                 "KBMin, " +
                 "KBMax " +
                 "from KBinventory i left join  " +
                 "tblJobInfo j " +
                 "on i.Item_Code = j.PartDrawingNumber + j.PartDrawingRev " +
                 "left join tblPlanner p " +
                 "on j.PlannerID = p.PlannerID " +
                 "left join tblkanban k " +
                 "on k.KBLocationName = KB_location and k.JobID = j.JobID " +
                 "where JobComplete = 0 " +
                 "order by PlannerInitials,Item_Code, KB_sequence", cnxn);

            cnxn.Open();

            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                try
                {
                    if (!dr.IsDBNull(0)) { plannerinitials[i] = dr.GetString(0).Trim(); }
                    if (!dr.IsDBNull(1)) { customer[i] = dr.GetString(1).Trim(); }
                    if (!dr.IsDBNull(2)) { project[i] = dr.GetString(2).Trim(); }

                    if (!dr.IsDBNull(4)) { itemcode[i] = dr.GetString(4).Trim(); }
                    if (!dr.IsDBNull(5)) { kblocation[i] = dr.GetString(5).Trim(); }
                    if (!dr.IsDBNull(6)) { WIP[i] = dr.GetInt32(6).ToString(); }
                    if (!dr.IsDBNull(7)) { INV[i] = dr.GetInt32(7).ToString(); }
                    if (!dr.IsDBNull(8)) { total[i] = dr.GetInt32(8).ToString(); }
                    if (!dr.IsDBNull(9)) { min[i] = dr.GetInt32(9).ToString(); }
                    if (!dr.IsDBNull(10)) { max[i] = dr.GetInt32(10).ToString(); }

                    //word wrap Element
                    if (!dr.IsDBNull(3))
                    {
                        if (dr.GetString(3).Length > 20)
                        {
                            int lastword = dr.GetString(3).Substring(0, 20).LastIndexOf(" ");
                            elementname[i] = dr.GetString(3).Substring(0, lastword);
                            elementWrap[i] = dr.GetString(3).Substring(lastword + 1, dr.GetString(3).Length - (lastword + 1));
                        }
                        else
                        {
                            elementname[i] = dr.GetString(3).Trim();
                            elementWrap[i] = "N";
                        }
                    }
                    i++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
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
            int linesPerpage = 40;
            //int lineNo = this.pagesPrinted * linesPerpage;
            int pageNo = pagesPrinted + 1;
            double NumPages = Math.Ceiling(((i - 1) / 24.0));
            string penflag = "BK";
            Pen pen = new Pen(Color.Red);
            Pen Gpen = new Pen(Color.Green);
            Gpen.Width = 3;
            pen.Width = 1;
            Font arial = new Font("arial", 9, FontStyle.Regular);
            Font title = new Font("arial", 16, FontStyle.Bold);
            Font heading = new Font("arial", 9, FontStyle.Bold);
            Font leaders = new Font("arial", 9, FontStyle.Bold);

            ev.Graphics.DrawString("Kanban Report", title, Brushes.Black, 25, 40);
            ev.Graphics.DrawString("Printed: " + date, heading, Brushes.Black, 800, 25);
            ev.Graphics.DrawString("Page  " + pageNo + " of " + NumPages, heading, Brushes.Black, 800, 50);

            ev.Graphics.DrawString("Planner", heading, Brushes.Black, 25, 80);
            ev.Graphics.DrawString("Customer", heading, Brushes.Black, 90, 80);
            ev.Graphics.DrawString("Project", heading, Brushes.Black, 200, 80);
            ev.Graphics.DrawString("Element", heading, Brushes.Black, 300, 80);
            ev.Graphics.DrawString("Part Number", heading, Brushes.Black, 500, 80);
            ev.Graphics.DrawString("Kanban Location", heading, Brushes.Black, 600, 80);
            ev.Graphics.DrawString("WIP", heading, Brushes.Black, 795, 80);
            ev.Graphics.DrawString("Inv", heading, Brushes.Black, 845, 80);
            ev.Graphics.DrawString("Total", heading, Brushes.Black, 890, 80);
            ev.Graphics.DrawString("Min", heading, Brushes.Black, 950, 80);
            ev.Graphics.DrawString("Max", heading, Brushes.Black, 1000, 80);

            while (count < linesPerpage && lineNo < i)
            {
                if (rawPrinted == false)
                {
                    linedrop = linedrop + 10;
                    count++;

                    cmd = new SqlCommand
                    ("select " +
                    "ITEM_CODE, " +
                    "ITEM_DESC, " +
                    "'Raw Material' KanbanLocation, " +
                    "STOCK_ON_ORDER WIP, " + 
                    "STOCK_ON_HAND Inv " +
                    "from AccessFrontEnds.dbo.MMX_BOM_IND_BILL " +
                    "where BEGIN_ITEM_CODE = '" + itemcode[lineNo] + "' " +
                    "and BOM_LEVEL = 1 " + 
                    "order by BEGIN_ITEM_CODE, BOM_LEVEL", cnxn);

                    cnxn.Open();

                    //using MMX_BOM_IND_BILL right now but Bill D says it is updated only once a day.
                    //could use MMX_ITEM_DATA_BY_WAREHOUSE for more up to date data

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        try
                        {
                            if (!dr.IsDBNull(0)) { BOMitemcode[0] = dr.GetString(0).Trim(); }
 
                            //word wrap BOM item
                            if (!dr.IsDBNull(1))
                            {
                                if (dr.GetString(1).Length > 20)
                                {
                                    int lastword = dr.GetString(1).Substring(0, 20).LastIndexOf(" ");
                                    BOMitem[0] = dr.GetString(1).Substring(0, lastword);
                                    BOMitemWRAP[0] = dr.GetString(1).Substring(lastword + 1, dr.GetString(1).Length - (lastword + 1));
                                }
                                else
                                {
                                    BOMitem[0] = dr.GetString(1).Trim();
                                    BOMitemWRAP[0] = "N";
                                }
                            }
                            //if (!dr.IsDBNull(2)) { BOMlocation[0] = dr.GetString(2).Trim(); }
                            if (!dr.IsDBNull(3)) { BOMwip[0] = dr.GetInt32(3); }
                            if (!dr.IsDBNull(4)) { BOMinv[0] = dr.GetInt32(4); }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    cnxn.Close();

                    ev.Graphics.DrawString(plannerinitials[lineNo], arial, Brushes.Black, 35, linedrop);
                    ev.Graphics.DrawString(customer[lineNo], arial, Brushes.Black, 90, linedrop);
                    ev.Graphics.DrawString(project[lineNo], arial, Brushes.Black, 200, linedrop);
                
                    ev.Graphics.DrawString(BOMitem[0], arial, Brushes.Black, 300, linedrop);
                    
                    if (BOMitemWRAP[0] != "N")
                    {
                        ev.Graphics.DrawString(BOMitemWRAP[0], arial, Brushes.Black, 300, linedrop + 20); 
                    }

                    ev.Graphics.DrawString(BOMitemcode[0], arial, Brushes.Black, 500, linedrop);
                    ev.Graphics.DrawString("Raw Material", arial, Brushes.Black, 600, linedrop);
                    ev.Graphics.DrawString(BOMwip[0].ToString(), arial, Brushes.Black, 800, linedrop);
                    
                    
                    //conditional color formatting
                    if (BOMinv[0] < Convert.ToInt32(min[lineNo]))
                    {
                        ev.Graphics.DrawString(BOMinv[0].ToString(), arial, Brushes.Red, 850, linedrop);
                    }
                    else if (BOMinv[0] > Convert.ToInt32(max[lineNo]))
                    {
                        ev.Graphics.DrawString(BOMinv[0].ToString(), arial, Brushes.Orange, 850, linedrop);
                    }
                    else
                    {
                        ev.Graphics.DrawString(BOMinv[0].ToString(), arial, Brushes.Black, 850, linedrop);
                    }


                    if ((BOMwip[0] + BOMinv[0]) < Convert.ToInt32(min[lineNo]))
                    {
                        ev.Graphics.DrawString((BOMwip[0] + BOMinv[0]).ToString(), arial, Brushes.Red, 900, linedrop);
                    }
                    else if ((BOMwip[0] + BOMinv[0]) > Convert.ToInt32(max[lineNo]))
                    {
                        ev.Graphics.DrawString((BOMwip[0] + BOMinv[0]).ToString(), arial, Brushes.Orange, 900, linedrop);
                    }
                    else
                    {
                        ev.Graphics.DrawString((BOMwip[0] + BOMinv[0]).ToString(), arial, Brushes.Black, 900, linedrop);
                    }
                    
                    ev.Graphics.DrawString(min[lineNo], arial, Brushes.Black, 955, linedrop);
                    ev.Graphics.DrawString(max[lineNo], arial, Brushes.Black, 1005, linedrop);

                    if (BOMitemWRAP[0] != "N")
                    {
                        linedrop = linedrop + 20;
                        count++;
                    }

                    ev.Graphics.DrawLine(pen, 25, linedrop + 17, 1050, linedrop + 17);
                    count++;
                    
                    rawPrinted = true;
                }

                if (kblocation[lineNo] != "Raw Material")
                {
                    ev.Graphics.DrawString(plannerinitials[lineNo], arial, Brushes.Black, 35, linedrop);
                    ev.Graphics.DrawString(elementname[lineNo], arial, Brushes.Black, 300, linedrop);

                    if (elementWrap[lineNo] != "N")
                    {
                        ev.Graphics.DrawString(elementWrap[lineNo], arial, Brushes.Black, 300, linedrop + 20);
                        ev.Graphics.DrawLine(pen, 25, linedrop + 37, 1050, linedrop + 37);

                        if (penflag == "BK")
                        {
                            pen = new Pen(Color.Blue);
                            penflag = "BU";
                        }
                        else if (penflag == "BU")
                        {
                            pen = new Pen(Color.Red);
                            penflag = "BK";
                        }
                    }

                    ev.Graphics.DrawString(plannerinitials[lineNo], arial, Brushes.Black, 35, linedrop);
                    ev.Graphics.DrawString(customer[lineNo], arial, Brushes.Black, 90, linedrop);
                    ev.Graphics.DrawString(project[lineNo], arial, Brushes.Black, 200, linedrop);
                    ev.Graphics.DrawString(itemcode[lineNo], arial, Brushes.Black, 500, linedrop);
                    ev.Graphics.DrawString(kblocation[lineNo], arial, Brushes.Black, 600, linedrop);

                    if (kblocation[lineNo] != "Finished Goods")
                    {
                        ev.Graphics.DrawString(WIP[lineNo], arial, Brushes.Black, 800, linedrop);
                    }
                    else
                    {
                        ev.Graphics.DrawString(total[lineNo], arial, Brushes.Black, 800, linedrop);
                    }
                    

                    if (kblocation[lineNo] != "Finished Goods")
                    {
                        //ev.Graphics.DrawString(WIP[lineNo], arial, Brushes.Black, 800, linedrop);

                        //conditional color formatting
                            //INV vs min/max
                        if (Convert.ToInt32(INV[lineNo]) < Convert.ToInt32(min[lineNo]))
                        {
                            ev.Graphics.DrawString(INV[lineNo].ToString(), arial, Brushes.Red, 850, linedrop);
                        }
                        else if (Convert.ToInt32(INV[lineNo]) > Convert.ToInt32(max[lineNo]))
                        {
                            ev.Graphics.DrawString(INV[lineNo].ToString(), arial, Brushes.Orange, 850, linedrop);
                        }
                        else
                        {
                            ev.Graphics.DrawString(INV[lineNo].ToString(), arial, Brushes.Black, 850, linedrop);
                        }

                            //total vs min/max
                        if (Convert.ToInt32(total[lineNo]) < Convert.ToInt32(min[lineNo]))
                        {
                            ev.Graphics.DrawString(total[lineNo].ToString(), arial, Brushes.Red, 900, linedrop);
                        }
                        else if (Convert.ToInt32(total[lineNo]) > Convert.ToInt32(max[lineNo]))
                        {
                            ev.Graphics.DrawString(total[lineNo].ToString(), arial, Brushes.Orange, 900, linedrop);
                        }
                        else
                        {
                            ev.Graphics.DrawString(total[lineNo].ToString(), arial, Brushes.Black, 900, linedrop);
                        }
                    
                        //ev.Graphics.DrawString(INV[lineNo], arial, Brushes.Black, 850, linedrop);
                        //ev.Graphics.DrawString(total[lineNo], arial, Brushes.Black, 900, linedrop);
                    }
                    
                    ev.Graphics.DrawString(min[lineNo], arial, Brushes.Black, 955, linedrop);
                    ev.Graphics.DrawString(max[lineNo], arial, Brushes.Black, 1005, linedrop);

                    if (elementWrap[lineNo] == "N")
                    {
                        ev.Graphics.DrawLine(pen, 25, linedrop + 17, 1050, linedrop + 17);

                        if (penflag == "BK")
                        {
                            pen = new Pen(Color.Blue);
                            penflag = "BU";
                        }
                        else if (penflag == "BU")
                        {
                            pen = new Pen(Color.Red);
                            penflag = "BK";
                        }
                    }

                    if (elementWrap[lineNo] != "N")
                    {
                        linedrop = linedrop + 20;
                        count++;
                    }

                }

                if (itemcode[lineNo] != itemcode[lineNo + 1] && finishedPrinted == false)
                {
                    string MRRinv = "0";

                    cnxn.Open();

                    cmd = new SqlCommand
                        ("SELECT STOCK_ON_HAND FROM AccessFrontEnds.dbo.MMX_ITEM_DATA_BY_WAREHOUSE " +
                         "WHERE warehouse = 'MRR' AND item_code = '" + itemcode[lineNo] + "' ", cnxn);
                    try
                    {
                        object o = cmd.ExecuteScalar();
                        if (o == null)
                        {
                            MRRinv = "0";
                        }
                        else
                        {
                            MRRinv = o.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn.Close();
                    }

                    cnxn.Open();

                    cmd = new SqlCommand
                        ("SELECT SUM(STOCK_ON_HAND) FROM AccessFrontEnds.dbo.MMX_ITEM_DATA_BY_WAREHOUSE " +
                         "WHERE warehouse != 'MRR' AND item_code = '" + itemcode[lineNo] + "' ", cnxn);
                    try
                    {
                        BOMinv[0] = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn.Close();
                    }

                    if (elementWrap[lineNo] != "N")
                    {
                        linedrop = linedrop - 20;
                    }
                    //ev.Graphics.DrawString(BOMwip[0].ToString(), arial, Brushes.Black, 800, linedrop);

                    //conditional color formatting
                    if (BOMinv[0] < Convert.ToInt32(min[lineNo]))
                    {
                        ev.Graphics.DrawString(BOMinv[0].ToString(), arial, Brushes.Red, 850, linedrop);
                    }
                    else if (BOMinv[0] > Convert.ToInt32(max[lineNo]))
                    {
                        ev.Graphics.DrawString(BOMinv[0].ToString(), arial, Brushes.Orange, 850, linedrop);
                    }
                    else
                    {
                        ev.Graphics.DrawString(BOMinv[0].ToString(), arial, Brushes.Black, 850, linedrop);
                    }

                    //totals need to be step total plus inventory
                    if ((BOMinv[0] + Convert.ToInt32(total[lineNo])) < Convert.ToInt32(min[lineNo]))
                    {
                        ev.Graphics.DrawString((BOMinv[0] + Convert.ToInt32(total[lineNo])).ToString(), arial, Brushes.Red, 900, linedrop);
                    }
                    else if (BOMinv[0] > Convert.ToInt32(max[lineNo]))
                    {
                        ev.Graphics.DrawString((BOMinv[0] + Convert.ToInt32(total[lineNo])).ToString(), arial, Brushes.Orange, 900, linedrop);
                    }
                    else
                    {
                        ev.Graphics.DrawString((BOMinv[0] + Convert.ToInt32(total[lineNo])).ToString(), arial, Brushes.Black, 900, linedrop);
                    }


                    linedrop = linedrop + 20;
                    ev.Graphics.DrawString("MRR", arial, Brushes.Black, 600, linedrop);
                    ev.Graphics.DrawString(MRRinv, arial, Brushes.Black, 900, linedrop);
                    count++;

                    //ev.Graphics.DrawString(BOMinv[0].ToString(), arial, Brushes.Black, 850, linedrop);
                    //ev.Graphics.DrawString(BOMinv[0].ToString(), arial, Brushes.Black, 900, linedrop);
                    if (elementWrap[lineNo] != "N")
                    {
                        linedrop = linedrop + 20;
                        count++;
                    }
                    linedrop = linedrop + 15;
                    ev.Graphics.DrawLine(Gpen, 25, linedrop + 20, 1050, linedrop + 20);
                    count++;

                    finishedPrinted = true;
                }

                if (itemcode[lineNo] != itemcode[lineNo + 1] && finishedPrinted == true)
                {
                    rawPrinted = false;
                    finishedPrinted = false;
                }

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

    public static class g
    {
        public static string customer;
        public static string project;
        public static string element;
        public static string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = OptiTRAK;";
    }

}
