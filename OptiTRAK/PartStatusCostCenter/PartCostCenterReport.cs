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

namespace PartStatusCostCenter
{
    public partial class PartCostCenterReport : Form
    {
        private string[] costcenter = new string[20000];
        private string[] plannerinitials = new string[20000];
        private string[] customer = new string[20000];
        private string[] project = new string[20000];
        private string[] elementname = new string[20000];
        private string[] elementWrap = new string[20000];
        private string[] partsn = new string[20000];
        private string[] deptcode = new string[20000];
        private string[] deptDescription = new string[20000];
        private string[] description = new string[20000];
        private string[] descriptionWrap = new string[20000];
        private string[] status = new string[20000];
        private string[] opstart = new string[20000];
        private string[] cycledays = new string[20000];
        private string[] estdone = new string[20000];
        private string[] plandue = new string[20000];
        private string[] delta = new string[20000];
        private string[] curr_req_dt = new string[20000];
        private string[] SFO = new string[20000];
        private string[] projDlvr = new string[20000];
        private string[] plnDlvr = new string[20000];
        private string[] op = new string[20000];
        private string[] eWrap = new string[20000];
        private string[] dWrap = new string[20000];
        private int i = 0;
        private int sourceCount = 1;
        private int pagesPrinted = 0;
        private bool sourcePrinted = false;
        private bool typePrinted = false;
        private bool locationPrinted = false;
        private int lineNo = 0;
        


        public PartCostCenterReport()
        {
            InitializeComponent();
        }

        private void PartCostCenterReport_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(g.db);

            SqlCommand cmd = new SqlCommand
                (g.basicselect +
                "where customer like '%" + g.tbSearchCustomer + "%'  " +
                "and project like '%" + g.tbSearchProject + "%'  " +
                "and elementname like '%" + g.tbSearchElement + "%'  " +
                "and plannerinitials like '%" + g.tbSearchPlanner + "%'  " +
                g.basicsort, cnxn);

            cnxn.Open();

            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0)) { costcenter[i] = dr.GetString(0).Trim() + "  " + dr.GetString(19); }
                if (!dr.IsDBNull(1)) { deptcode[i] = dr.GetString(1).Trim(); }
                if (!dr.IsDBNull(2)) { plannerinitials[i] = dr.GetString(2).Trim(); }
                if (!dr.IsDBNull(3)) { customer[i] = dr.GetString(3).Trim(); }
                if (!dr.IsDBNull(4)) { project[i] = dr.GetString(4).Trim(); }
                if (!dr.IsDBNull(5)) { SFO[i] = dr.GetInt32(5).ToString(); }

                if (!dr.IsDBNull(7)) { partsn[i] = dr.GetString(7).Trim(); }
                if (!dr.IsDBNull(8)) { op[i] = dr.GetInt32(8).ToString(); }

                if (!dr.IsDBNull(10)) { status[i] = dr.GetString(10).Trim(); }
                if (!dr.IsDBNull(11)) { opstart[i] = dr.GetString(11); }
                if (!dr.IsDBNull(12)) { cycledays[i] = dr.GetString(12); }
                if (!dr.IsDBNull(13)) { estdone[i] = dr.GetString(13); }
                if (!dr.IsDBNull(14)) { plandue[i] = dr.GetString(14); }
                if (!dr.IsDBNull(15)) { projDlvr[i] = dr.GetString(15); }
                if (!dr.IsDBNull(16)) { plnDlvr[i] = dr.GetString(16); }
                if (!dr.IsDBNull(17))
                {
                    delta[i] = dr.GetInt32(17).ToString();
                }
                else
                {
                    delta[i] = "0";
                }
                if (!dr.IsDBNull(18)) { curr_req_dt[i] = dr.GetString(18); }

                deptDescription[i] = dr.GetString(20); 

                //word wrap Element
                if (!dr.IsDBNull(6))
                {
                    //if (dr.GetString(4).Length > 20)
                    //{
                    //    int lastword = dr.GetString(4).Substring(0, 20).LastIndexOf(" ");
                    //    elementname[i] = dr.GetString(4).Substring(0, lastword);
                    //    eWrap[i] = "Y";
                    //    i++;
                    //    elementname[i] = dr.GetString(4).Substring(lastword + 1, dr.GetString(4).Length - (lastword + 1));
                    //    eWrap[i] = "N";
                    //}
                    //else
                    //{
                    //    elementname[i] = dr.GetString(4).Trim();
                    //    eWrap[i] = "N";
                    //}

                    string dataholder = dr.GetString(4) + " : " + dr.GetString(6);

                    if (dataholder.Length > 20)
                    {
                        int lastword = dataholder.Substring(0, 20).LastIndexOf(" ");
                        elementname[i] = dataholder.Substring(0, lastword);
                        elementWrap[i] = dataholder.Substring(lastword + 1, dataholder.Length - (lastword + 1));
                    }
                    else
                    {
                        elementname[i] = dataholder;
                        elementWrap[i] = "N";
                    }

                    
                    //if (dr.GetString(6).Length > 20)
                    //{
                    //    int lastword = dr.GetString(6).Substring(0, 20).LastIndexOf(" ");
                    //    elementname[i] = dr.GetString(6).Substring(0, lastword);
                    //    elementWrap[i] = dr.GetString(6).Substring(lastword + 1, dr.GetString(6).Length - (lastword + 1));
                    //}
                    //else
                    //{
                    //    elementname[i] = dr.GetString(6).Trim();
                    //    elementWrap[i] = "N";
                    //}

                }
                //else
                //{
                //    eWrap[i] = "N";
                //}

                //word wrap Description
                if (!dr.IsDBNull(9))
                {
                    //if(eWrap[i] == "Y")
                    //{
                    //    i--;
                    //}

                    //if (dr.GetString(8).Length > 32)
                    //{
                    //    int lastword = dr.GetString(8).Substring(0, 32).LastIndexOf(" ");
                    //    description[i] = dr.GetString(8).Substring(0, lastword);
                    //    dWrap[i] = "Y";
                    //    i++;
                    //    description[i] = dr.GetString(8).Substring(lastword + 1, dr.GetString(8).Length - (lastword + 1));
                    //    dWrap[i] = "N";
                    //}
                    //else
                    //{
                    //    description[i] = dr.GetString(8).Trim();
                    //    dWrap[i] = "N";
                    //}

                    //if (eWrap[i] == "Y" & dWrap[i] == "N")
                    //{
                    //    i++;
                    //}

                    if (dr.GetString(9).Length > 32)
                    {
                        int lastword = dr.GetString(9).Substring(0, 32).LastIndexOf(" ");
                        description[i] = dr.GetString(9).Substring(0, lastword);
                        descriptionWrap[i] = dr.GetString(9).Substring(lastword + 1, dr.GetString(9).Length - (lastword + 1));
                    }
                    else
                    {
                        description[i] = dr.GetString(9).Trim();
                        descriptionWrap[i] = "N";
                    }

                }
                //else
                //{
                //    dWrap[i] = "N";
                //}




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
            int linesPerpage = 30;
            //int lineNo = this.pagesPrinted * linesPerpage;
            int pageNo = pagesPrinted + 1;
            double NumPages = Math.Ceiling(((i - 1) / 20.0));
            string penflag = "BK";
            Pen pen = new Pen(Color.Red);
            pen.Width = 1;
            Font arial = new Font("arial", 9, FontStyle.Regular);
            Font title = new Font("arial", 16, FontStyle.Bold);
            Font heading = new Font("arial", 9, FontStyle.Bold);
            Font leaders = new Font("arial", 9, FontStyle.Bold);

            ev.Graphics.DrawString("Part Status by Cost Center", title, Brushes.Black, 25, 40);
            ev.Graphics.DrawString("Printed: " + date, heading, Brushes.Black, 800, 25);
            ev.Graphics.DrawString("Page  " + pageNo + " of " + NumPages, heading, Brushes.Black, 800, 50);

            ev.Graphics.DrawString("Op", heading, Brushes.Black, 745, 65);
            ev.Graphics.DrawString("Op", heading, Brushes.Black, 805, 65);
            ev.Graphics.DrawString("Calc", heading, Brushes.Black, 865, 65);
            ev.Graphics.DrawString("SO", heading, Brushes.Black, 925, 65);
            ev.Graphics.DrawString("SO", heading, Brushes.Black, 1005, 65);


            ev.Graphics.DrawString("Plnr", heading, Brushes.Black, 25, 80);
            ev.Graphics.DrawString("SFO", heading, Brushes.Black, 50, 80);
            ev.Graphics.DrawString("Project : Element", heading, Brushes.Black, 115, 80);
            ev.Graphics.DrawString("ID", heading, Brushes.Black, 250, 80);
            ev.Graphics.DrawString("WC", heading, Brushes.Black, 310, 80);
            ev.Graphics.DrawString("Op", heading, Brushes.Black, 345, 80);
            ev.Graphics.DrawString("Description", heading, Brushes.Black, 380, 80);
            ev.Graphics.DrawString("Status", heading, Brushes.Black, 585, 80);
            ev.Graphics.DrawString("Start", heading, Brushes.Black, 640, 80);
            ev.Graphics.DrawString("Cycle", heading, Brushes.Black, 695, 80);
            ev.Graphics.DrawString("Est Done", heading, Brushes.Black, 745, 80);
            ev.Graphics.DrawString("Plan Due", heading, Brushes.Black, 805, 80);
            ev.Graphics.DrawString("Proj Dlvr", heading, Brushes.Black, 865, 80);
            ev.Graphics.DrawString("Pln Dlvr", heading, Brushes.Black, 925, 80);
            ev.Graphics.DrawString("Dlt", heading, Brushes.Black, 980, 80);
            ev.Graphics.DrawString("Reqd", heading, Brushes.Black, 1005, 80);

            while (count < linesPerpage && lineNo < i)
            {
                //if (lineNo == 0 || eWrap[lineNo] == "N" & dWrap[lineNo] == "N" & eWrap[lineNo -1] == "N" & dWrap[lineNo -1] == "N")  
                //if (lineNo == 0 || elementWrap[lineNo] != "N")  
                //{
                if (costcenter[lineNo] == costcenter[lineNo + 1] && sourcePrinted == false ||
                    costcenter[lineNo] != costcenter[lineNo + 1] && sourcePrinted == false)
                {
                    linedrop = linedrop + 10;
                    ev.Graphics.DrawString("Cost Center:  " +
                        costcenter[lineNo], heading, Brushes.Black, 25, linedrop);
                    sourcePrinted = true;
                    //linedrop = linedrop + 15;
                    count++;
                }

                if (deptcode[lineNo] == deptcode[lineNo + 1] && typePrinted == false ||
                    deptcode[lineNo] != deptcode[lineNo + 1] && typePrinted == false)
                {
                    linedrop = linedrop + 25;
                    count++;
                    ev.Graphics.DrawString("Work Center:  " +
                        deptcode[lineNo] + "  " + deptDescription[lineNo], heading, Brushes.Black, 50, linedrop);
                        
                    typePrinted = true;
                    //locationPrinted = false;
                    linedrop = linedrop + 25;
                    count++;
                }

                //if (project[lineNo] == project[lineNo + 1] && locationPrinted == false ||
                //    project[lineNo] != project[lineNo + 1] && locationPrinted == false)
                //{
                //    //linedrop = linedrop + 5;
                //    ev.Graphics.DrawString("Project:  " +
                //        project[lineNo], heading, Brushes.Black, 250, linedrop);
                //    locationPrinted = true;
                //    linedrop = linedrop + 25;
                //    count++;
                //}
                //}

                ev.Graphics.DrawString(plannerinitials[lineNo], arial, Brushes.Black, 25, linedrop);
                ev.Graphics.DrawString(SFO[lineNo], arial, Brushes.Black, 50, linedrop);
                ev.Graphics.DrawString(elementname[lineNo], arial, Brushes.Black, 105, linedrop);
                if (elementWrap[lineNo] != "N")
                {
                    ev.Graphics.DrawString(elementWrap[lineNo], arial, Brushes.Black, 105, linedrop + 20);
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

                ev.Graphics.DrawString(partsn[lineNo], arial, Brushes.Black, 250, linedrop);
                ev.Graphics.DrawString(deptcode[lineNo], arial, Brushes.Black, 310, linedrop);
                ev.Graphics.DrawString(op[lineNo], arial, Brushes.Black, 345, linedrop);
                ev.Graphics.DrawString(description[lineNo], arial, Brushes.Black, 380, linedrop);
                if (descriptionWrap[lineNo] != "N")
                {
                    ev.Graphics.DrawString(descriptionWrap[lineNo], arial, Brushes.Black, 380, linedrop + 20);
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
                ev.Graphics.DrawString(status[lineNo], arial, Brushes.Black, 585, linedrop);
                ev.Graphics.DrawString(opstart[lineNo], arial, Brushes.Black, 640, linedrop);
                ev.Graphics.DrawString(cycledays[lineNo], arial, Brushes.Black, 695, linedrop);

                //Estimated Done
                if (estdone[lineNo] != null)
                    if ((Convert.ToDateTime(estdone[lineNo].ToString())) < DateTime.Now)
                    {
                        ev.Graphics.DrawString(estdone[lineNo], arial, Brushes.Red, 745, linedrop);
                    }
                    else
                    {
                        ev.Graphics.DrawString(estdone[lineNo], arial, Brushes.Black, 745, linedrop);
                    }

                //Planned Due
                if (plandue[lineNo] != null && ((Convert.ToDateTime(plandue[lineNo].ToString())) < DateTime.Now))
                {
                    ev.Graphics.DrawString(plandue[lineNo], arial, Brushes.Red, 805, linedrop);
                }
                else
                {
                    ev.Graphics.DrawString(plandue[lineNo], arial, Brushes.Black, 805, linedrop);
                }

                //ev.Graphics.DrawString(plandue[lineNo], arial, Brushes.Black, 805, linedrop);

                //Projected Delivery
                if (projDlvr[lineNo] != null && ((Convert.ToDateTime(projDlvr[lineNo].ToString())) > (Convert.ToDateTime(plnDlvr[lineNo].ToString()))))
                {
                    ev.Graphics.DrawString(projDlvr[lineNo], arial, Brushes.Red, 865, linedrop);
                }
                else
                {
                    ev.Graphics.DrawString(projDlvr[lineNo], arial, Brushes.Black, 865, linedrop);
                }

                //Planned Delivery

                int monthNumber = DateTime.Now.Month;
                DateTime quarterStart;
                DateTime quarterEnd;
                
                // start of quarter dates
                if (monthNumber < 4)
                {
                    quarterStart = new DateTime(DateTime.Now.Year, 1, 1);
                }
                else if (monthNumber > 3 & monthNumber < 7)
                {
                    quarterStart = new DateTime(DateTime.Now.Year, 4, 1);
                }
                else if (monthNumber > 6 & monthNumber < 10)
                {
                    quarterStart = new DateTime(DateTime.Now.Year, 7, 1);
                }
                else  //(monthNumber > 9 & monthNumber <=12 )
                {
                    quarterStart = new DateTime(DateTime.Now.Year, 10, 1);
                }
                // end of quarter dates
                if (monthNumber < 4)
                {
                    quarterEnd = new DateTime(DateTime.Now.Year, 3, 31);
                }
                else if (monthNumber > 3 & monthNumber < 7)
                {
                    quarterEnd = new DateTime(DateTime.Now.Year, 6, 30);
                }
                else if (monthNumber > 6 & monthNumber < 10)
                {
                    quarterEnd = new DateTime(DateTime.Now.Year, 9, 30);
                }
                else  //(monthNumber > 9 & monthNumber <=12 )
                {
                    quarterEnd = new DateTime(DateTime.Now.Year, 12, 31);
                }


                if (plnDlvr[lineNo] != null && ((Convert.ToDateTime(plnDlvr[lineNo].ToString())) > (Convert.ToDateTime(curr_req_dt[lineNo].ToString()))))
                {
                    if ((Convert.ToDateTime(plnDlvr[lineNo].ToString())) >= quarterStart & (Convert.ToDateTime(plnDlvr[lineNo].ToString())) <= quarterEnd)
                    {
                        ev.Graphics.DrawString(plnDlvr[lineNo], heading, Brushes.Red, 925, linedrop);
                    }
                    else
                    {
                        ev.Graphics.DrawString(plnDlvr[lineNo], arial, Brushes.Red, 925, linedrop);
                    }
                }
                else
                {
                    if ((Convert.ToDateTime(plnDlvr[lineNo].ToString())) >= quarterStart & (Convert.ToDateTime(plnDlvr[lineNo].ToString())) <= quarterEnd)
                    {
                        ev.Graphics.DrawString(plnDlvr[lineNo], heading, Brushes.Black, 925, linedrop);
                    }
                    else
                    {
                        ev.Graphics.DrawString(plnDlvr[lineNo], arial, Brushes.Black, 925, linedrop);
                    }
                }

                //Delta
                if (delta[lineNo] != null && Convert.ToInt32(delta[lineNo].ToString()) < 0)
                {
                    ev.Graphics.DrawString(delta[lineNo], arial, Brushes.Red, 980, linedrop);
                }
                else
                {
                    ev.Graphics.DrawString(delta[lineNo], arial, Brushes.Black, 980, linedrop);
                }


                ev.Graphics.DrawString(curr_req_dt[lineNo], arial, Brushes.Black, 1005, linedrop);

                //if ((eWrap[lineNo] != null && (eWrap[lineNo].ToString() == "N")) 
                //    && (dWrap[lineNo] != null && dWrap[lineNo].ToString() == "N"))
                if (elementWrap[lineNo] == "N" & descriptionWrap[lineNo] == "N")
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


                if (costcenter[lineNo] != costcenter[lineNo + 1] && sourcePrinted == true)
                {
                    sourcePrinted = false;
                }

                if (deptcode[lineNo] != deptcode[lineNo + 1] && typePrinted == true)
                {
                    typePrinted = false;
                }

                //if (project[lineNo] != project[lineNo + 1] && locationPrinted == true)
                //{
                //    locationPrinted = false;
                //}

                if (elementWrap[lineNo] != "N" | descriptionWrap[lineNo] != "N")
                {
                    count++;
                    linedrop = linedrop + 20;
                }

                lineNo++;
                count++;
                linedrop = linedrop + 20;
                //linedrop = linedrop + 10;
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
