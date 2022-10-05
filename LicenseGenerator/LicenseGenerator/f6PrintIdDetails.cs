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


namespace LicenseGenerator
{
    public partial class f6PrintIdDetails : Form
    {
        DataTable table;
        private int i = 0;
        private int pagesPrinted = 0;
        private Image img;
        
        public f6PrintIdDetails()
        {
            InitializeComponent();
        }

        private void f6PrintIdDetails_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(g.db);
            cnxn.Open();
            
            SqlCommand cmd = new SqlCommand("LicenseDataDetailByID", cnxn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DongleID", SqlDbType.NVarChar).Value = g.DongleID;
            cmd.Parameters.Add("@ProductLine", SqlDbType.NVarChar).Value = g.productLine;

            table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(table);

            cnxn.Close();

            i = table.Rows.Count;
            PrintDocument pd = new PrintDocument();
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
            int linedrop = 200;
            int count = 0;
            int linesPerpage = 50;
            int lineNo = this.pagesPrinted * linesPerpage;
            int pageNo = pagesPrinted + 1;
            double NumPages = Math.Ceiling(((i - 1) / 50.0));
            if (NumPages == 0) { NumPages = 1; }

            Pen pen = new Pen(Color.Black);
            pen.Width = 1;
            Font arial = new Font("arial", 10, FontStyle.Regular);
            Font title = new Font("arial", 30, FontStyle.Regular);
            Font heading = new Font("arial", 16, FontStyle.Bold);
            Font leaders = new Font("arial", 12, FontStyle.Bold);
            Font arial7 = new Font("arial", 7, FontStyle.Regular);
            
            if (g.productLine == "MTP")
            {
                img = System.Drawing.Image.FromFile(@"c:\zygo license generator\metropro.jpg");
            }
            if (g.productLine == "MX")
            {
                img = System.Drawing.Image.FromFile(@"c:\zygo license generator\mx.jpg");
            }
            if (g.productLine == "ZMP")
            {
                img = System.Drawing.Image.FromFile(@"c:\zygo license generator\zemaps.jpg");
            }

            ev.Graphics.DrawImage(img, new Point(50, 40));
            ev.Graphics.DrawString("Date Printed: " + date, arial7, Brushes.Black, 50, 1050);
            ev.Graphics.DrawString("Page  " + pageNo + " of " + NumPages, arial7, Brushes.Black, 700, 1050);
            ev.Graphics.DrawString(table.Rows[0][0].ToString(), leaders, Brushes.Black, 50, 115);
            ev.Graphics.DrawString(table.Rows[0][5].ToString(), leaders, Brushes.Black, 300, 115);
            pen.Width = 2;
            ev.Graphics.DrawLine(pen, 50, 140, 750, 140);
            
            ev.Graphics.DrawString("App", heading, Brushes.Black, 75, 150);
            ev.Graphics.DrawString("Start", heading, Brushes.Black, 270, 150);
            ev.Graphics.DrawString("Expire", heading, Brushes.Black, 400, 150);
            ev.Graphics.DrawString("License", heading, Brushes.Black, 525, 150);
            
            while (count < linesPerpage && lineNo < i)
            {

                ev.Graphics.DrawString(table.Rows[lineNo][1].ToString(), arial, Brushes.Black, 75, linedrop);
                ev.Graphics.DrawString(table.Rows[lineNo][2].ToString(), arial, Brushes.Black, 270, linedrop);
                ev.Graphics.DrawString(table.Rows[lineNo][3].ToString(), arial, Brushes.Black, 400, linedrop);
                ev.Graphics.DrawString(table.Rows[lineNo][4].ToString(), arial, Brushes.Black, 525, linedrop);

                lineNo++;
                count++;
                linedrop = linedrop + 25;
            }
            int nextpar = 850;
            int drop = 12;
            if (g.productLine == "MX")
            {
                ev.Graphics.DrawString("The following is a legal agreement between you and ZYGO Corporation.  MxTM (this software) is licensed to you and not sold.  You may use", arial7, Brushes.Black, 50, nextpar);
            }
            if (g.productLine == "MTP")
            {
                ev.Graphics.DrawString("The following is a legal agreement between you and ZYGO Corporation.  MetroProTM (this software) is licensed to you and not sold.  You may use", arial7, Brushes.Black, 50, nextpar);
            }
            if (g.productLine == "ZMP")
            {
                ev.Graphics.DrawString("The following is a legal agreement between you and Zemetrics, Inc., a ZYGO company.  ZeMapsTM (this software) is licensed to you and not sold.  You may use", arial7, Brushes.Black, 50, nextpar);
            }
                nextpar = nextpar + drop;
            ev.Graphics.DrawString("this software only according to the terms of this License.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("1.GRANT OF LICENSE.  You may use this software only on a single computer at a time.  You may not network this software or otherwise use it on ", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("more than one computer or computer terminal at the same time.  The License covers all users on the single system.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("2.OWNERSHIP OF SOFTWARE.  This software is owned by ZYGO and is protected by United States copyright laws and international treaty", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("provisions.  Therefore, you must treat this software like any other copyrighted material.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("3.USE RESTRICTIONS.  You may transfer this software to a hard disk and make copies of this software solely for backup or archival purposes.  You", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("may not alter, modify, or adapt any part of this software or documentation.  This means you may not reverse-engineer, decompile, disassemble", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("this software, or create derivative works from it.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("4.TRANSFER RESTRICTIONS.  This Software is licensed only to you, and may not be transferred to anyone without prior written consent of ZYGO.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("The terms and conditions of this Agreement shall bind any authorized transferee of software.  In no event may you transfer, assign, rent, lease, sell, or", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("otherwise dispose of this software on a temporary or permanent basis except as expressly provided herein.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("5.TERMINATION.  This License is effective until terminated.  This License will terminate automatically without notice from ZYGO if you fail to comply", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("with any provision of this License.  Upon termination you shall destroy the written materials and all copies of this software, including modified copies, if", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("any.", arial7, Brushes.Black, 50, nextpar);
            

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
