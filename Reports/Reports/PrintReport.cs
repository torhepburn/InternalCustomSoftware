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


namespace Reports
{
    public partial class PrintReport : Form
    {
        private string[] id = new string[20000];
        private string[] nonprintingid = new string[20000];
        private string[] orderNo = new string[20000];
        private string[] itemCode = new string[20000];
        private string[] orderStatus = new string[20000];
        private string[] warehouse = new string[20000];
        private string[] quantity = new string[20000];
        private string[] productionDT = new string[20000];
        private string[] deliveryDT = new string[20000];
        private string[] kanban = new string[20000];
        private string[] planner = new string[20000];
        private int i = 0;
        private int lineNo = 0;
        private int pagesPrinted = 0;
        DataTable table;
        //PrintDialog pDlg;
        PrintPreviewDialog ppd;
        PrintDocument pd;

        public PrintReport()
        {
            InitializeComponent();
        }

        private void PrintReport_Load(object sender, EventArgs e)
        {
            //SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL01; password = Read+Write!; " +
            SqlConnection cnxn = new SqlConnection(g.db);

            SqlCommand cmd = new SqlCommand(
                " SELECT " +
                " order_no " +
                ",item_code " +
                ",order_status " +
                ",warehouse " +
                ",order_quantity " +
                ",start_date " +
                ",planned_delivery_date " +
                ",CASE  " +
                "   WHEN ASCII(SUBSTRING(item_description, 1, 1)) = 37 THEN 'KB' " +
                "   WHEN ASCII(SUBSTRING(item_description, 1, 1)) != 37 THEN ' ' " +
                "END as Kanban " +
                ", e.Name  " +
                "FROM mmx_production_order_file o " +
                "LEFT JOIN mmx_employees e on o.planner_code = e.employee " +
                "WHERE  " +
                " order_no not like '35%' " +
                "AND order_status = 2 " +
                g.DateRange + g.warehouse +
                "ORDER BY " + g.sortOrder , cnxn);

            cnxn.Open();

            try
            {

                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        orderNo[i] = dr.GetInt32(0).ToString();
                    }

                    if (!dr.IsDBNull(1)) { itemCode[i] = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { orderStatus[i] = dr.GetInt32(2).ToString(); }
                    if (!dr.IsDBNull(3)) { warehouse[i] = dr.GetString(3); }

                    if (!dr.IsDBNull(4)) { quantity[i] = dr.GetInt32(4).ToString().Trim(); }
                    if (!dr.IsDBNull(5)) { productionDT[i] = dr.GetDateTime(5).ToShortDateString(); }
                    if (!dr.IsDBNull(6)) { deliveryDT[i] = dr.GetDateTime(6).ToShortDateString(); }
                    if (!dr.IsDBNull(7)) { kanban[i] = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { planner[i] = dr.GetString(8); }

                    i++;
                            
                    
                    
                }
                cnxn.Close();

                //pDlg = new PrintDialog();
                //pDlg.ShowDialog();


                pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                //directPrint();

                ppd = new PrintPreviewDialog();
                ppd.Document = pd;
                //this.ToolStripButton = new ToolStripButton();
                //this.ToolStripButton.Image = ((System.Windows.Forms.ToolStrip)(ppd.Controls[1])).ImageList.Images[0];
                //this.ToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
                //this.ToolStripButton.Click += new System.EventHandler(printPreview_printClick);
                //((System.Windows.Forms.ToolStrip)(ppd.Controls[1])).Items.RemoveAt(0);
                //((System.Windows.Forms.ToolStrip)(ppd.Controls[1])).Items.Insert(0, ToolStripButton);
                (ppd as Form).WindowState = FormWindowState.Maximized;
                ppd.ShowDialog();

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

        private void printPreview_printClick(object sender, System.EventArgs ee)
        //private void directPrint()
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
            int linesPerpage = 45;
            //int lineNo = this.pagesPrinted * linesPerpage;
            int pageNo = pagesPrinted + 1;
            double NumPages = Math.Ceiling(((i - 1) / 45.0));
            Pen pen = new Pen(Color.Black);
            pen.Width = 1;
            Font arial = new Font("arial", 10, FontStyle.Regular);
            Font title = new Font("arial", 16, FontStyle.Bold);
            Font heading = new Font("arial", 10, FontStyle.Bold);
            Font leaders = new Font("arial", 6, FontStyle.Bold);

            ev.Graphics.DrawString("Planned Deliveries : Production Date <= " + g.endDate, title, Brushes.Black, 25, 40);
            ev.Graphics.DrawString("Printed: " + date, heading, Brushes.Black, 600, 25);
            ev.Graphics.DrawString("Page  " + pageNo + " of " + NumPages, heading, Brushes.Black, 600, 50);
            ev.Graphics.DrawString("Order No", heading, Brushes.Black, 25, 80);
            ev.Graphics.DrawString("Item Code", heading, Brushes.Black, 100, 80);
            ev.Graphics.DrawString("Kanban", heading, Brushes.Black, 190, 80);
            ev.Graphics.DrawString("Status", heading, Brushes.Black, 250, 80);
            ev.Graphics.DrawString("WH", heading, Brushes.Black, 300, 80);
            ev.Graphics.DrawString("Qty", heading, Brushes.Black, 350, 80);
            ev.Graphics.DrawString("Production DT", heading, Brushes.Black, 430, 80);
            ev.Graphics.DrawString("Delivery DT", heading, Brushes.Black, 600, 80);
            ev.Graphics.DrawString("Planner", heading, Brushes.Black, 700, 80);

            while (count < linesPerpage && lineNo < i)
            {
                //if (statusPrinted == false)
                //{
                //    linedrop = linedrop + 5;
                //    pen.Color = Color.Red;
                //    pen.Width = 2;
                //    //if (lineNo > 2 && group[lineNo - 1] == "Optics")
                //    //{ pen.Color = Color.Blue; }
                //    //if (group[lineNo + 1] != "Optics")
                //    //{ pen.Color = Color.Red; }
                //    //ev.Graphics.DrawLine(pen, 15, linedrop, 1050, linedrop);
                //    //pen.Width = 1;
                //    //pen.Color = Color.Blue;
                //    //linedrop = linedrop + 5;
                //    //ev.Graphics.DrawString("STATUS:  " +
                //    //    lateflag[lineNo], heading, Brushes.Black, 15, linedrop);
                //    statusPrinted = true;
                    linedrop = linedrop + 20;
                //    count++;
                //}

                
                    ev.Graphics.DrawString(orderNo[lineNo], arial, Brushes.Black, 25, linedrop);
                    ev.Graphics.DrawString(itemCode[lineNo], arial, Brushes.Black, 100, linedrop);
                    ev.Graphics.DrawString(kanban[lineNo], arial, Brushes.Black, 200, linedrop);
                    ev.Graphics.DrawString(orderStatus[lineNo], arial, Brushes.Black, 270, linedrop);
                    ev.Graphics.DrawString(warehouse[lineNo], arial, Brushes.Black, 300, linedrop);
                    ev.Graphics.DrawString(quantity[lineNo], arial, Brushes.Black, 350, linedrop);
                    ev.Graphics.DrawString(productionDT[lineNo], arial, Brushes.Black, 430, linedrop);
                    ev.Graphics.DrawString(deliveryDT[lineNo], arial, Brushes.Black, 600, linedrop);
                    ev.Graphics.DrawString(planner[lineNo], arial, Brushes.Black, 700, linedrop);
                    //ev.Graphics.DrawString(currduedate[lineNo], arial, Brushes.Black, 615, linedrop);
                    //ev.Graphics.DrawString(buyer[lineNo], arial, Brushes.Black, 700, linedrop);
                    //ev.Graphics.DrawString(qty[lineNo], arial, Brushes.Black, 775, linedrop);
                    //ev.Graphics.DrawString(po[lineNo], arial, Brushes.Black, 810, linedrop);
                    //ev.Graphics.DrawString(supplier[lineNo], arial, Brushes.Black, 850, linedrop);
                    //ev.Graphics.DrawString(dateaddedtolist[lineNo], arial, Brushes.Black, 920, linedrop);
                    //ev.Graphics.DrawString(group[lineNo], arial, Brushes.Black, 980, linedrop);
                    //if (hot[lineNo] == "HOT")
                    //{
                    //    ev.Graphics.DrawString(hot[lineNo], leaders, Brushes.Black, 1025, linedrop);
                    //}
                    //ev.Graphics.DrawString(received[lineNo], arial, Brushes.Black, 665, linedrop);
                    //wholeLinePrinted = true;
                //}
                //else
                //{
                //    ev.Graphics.DrawString(comments[lineNo], arial, Brushes.Black, 300, linedrop);
                //}

                //if (nonprintingid[lineNo] != nonprintingid[lineNo + 1])
                //{

                //    if (lateflag[lineNo] != lateflag[lineNo + 1] && statusPrinted == true)
                //    {
                //        statusPrinted = false;
                //    }

                //    pen.Color = Color.Blue;
                //    ev.Graphics.DrawLine(pen, 15, linedrop + 14, 1050, linedrop + 14);
                //    linedrop = linedrop + 20;
                //    wholeLinePrinted = false;

                //}
                //else
                //{
                //    linedrop = linedrop + 12;
                //}

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
