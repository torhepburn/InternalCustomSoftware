using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace Tools
{
    public partial class F31_Find_Tools : Form
    {
        SqlConnection cnxn;
        private string sGrit;
        private string sDiameter;
        private string sUsableLength;
        private string sType;
        private string sTNumber;
        DataTable dt3;
        private int i = 0;
        private int pagesPrinted = 0;

        public F31_Find_Tools()
        {
            InitializeComponent();
        }

        private void F31_Find_Tools_Load(object sender, EventArgs e)
        {

            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("select distinct tooltype from tools order by tooltype", cnxn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow newRow = dt.NewRow();
            newRow[0] = "";
            dt.Rows.InsertAt(newRow, 0);

            cbddType.DataSource = dt;
            cbddType.DisplayMember = "ToolType";

            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da2 = new SqlDataAdapter
                ("select distinct grit from tools order by grit", cnxn);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            cbddGrit.DataSource = dt2;
            cbddGrit.DisplayMember = "Grit";


            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da10 = new SqlDataAdapter
                ("select distinct ToolNumber from tools t " +
                "inner join toollocation l on " +
                 "t.sn = l.lsn " +
                 " where ToolNumber " +
                 " is not null and LEN(LTRIM(Toolnumber)) > 1 " +
                 " and program = '" + g.program + "' " +
                 " and lfacility = '" + g.facility + "' " +
                 "and status is not null  and status != 'I' " +
                 " order by ToolNumber", cnxn);
            DataTable dt10 = new DataTable();
            da10.Fill(dt10);
            DataRow newRow1 = dt10.NewRow();
            newRow1[0] = "";
            dt10.Rows.InsertAt(newRow1, 0);

            cbddTNumber.DataSource = dt10;
            cbddTNumber.DisplayMember = "ToolNumber";

        }

        private void bFind_Click(object sender, EventArgs e)
        {
            if (cbddType.Text == "")
            {
                sType = " (tooltype like '%e%' or tooltype like '%d%' or tooltype like '%o%') ";
            }
            else
            {
                sType = " tooltype = '" +
                 cbddType.Text + "' ";
            }

            if (tbUsableLength.Text.Length < 1)
            {
                sUsableLength = "";
            }
            else
            {
                sUsableLength = "and usablelength > " +
                    tbUsableLength.Text;
            }


            if (cbddGrit.Text.Length < 1)
            {
                sGrit = "";
            }
            else
            {
                sGrit = "and grit like '" + cbddGrit.Text + "%' ";
            }

            if (tbDiameter.Text.Length < 1)
            {
                sDiameter = "";
            }
            else
            {
                sDiameter = "and  diameter > " + tbDiameter.Text + " - .015 and " +
                 "diameter < " + tbDiameter.Text + " + .015 ";

            }

            if (cbddTNumber.Text.Length < 1)
            {
                sTNumber = "";
            }
            else
            {
                sTNumber = "and toolnumber = '" + cbddTNumber.Text.Trim() + "' ";
            }



            cnxn = new SqlConnection(g.db);
            SqlDataAdapter da3 = new SqlDataAdapter
                ("select " +
                 "tooltype, " +
                 "SN, " +
                 "Diameter , " +
                 "Diameter_M , " +
                 "Grit, " +
                 "NoseRadius , " +
                 "Location, " +
                 "ToolNumber , " +
                 "Angle , " +
                 "UsableLength , " +
                 "UsableLength_M , " +
                 "DiamondLength , " +
                 "DiamondLength_M , " +
                 "PlatedBonded , " +
                 "MountType , " +
                 "ShankDiameter , " +
                 "ShankDiameter_M , " +
                 "ReliefDiameter, " +
                 "ReliefDiameter_M, " +
                 "FlatDiameter , " +
                 "FlatDiameter_M , " +
                 "InnerDiameter, " +
                 "InnerDiameter_M, " +
                 "ColletLength, " +
                 "ColletLength_M, " +
                 "ColletNutSize , " +
                 "ToolHolderType , " +
                 "RefReorderNumber , " +
                 "Status , " +
                 "OldSN , " +
                 "Notes , " +
                 "Supplier, " +
                 "Thickness " +
                 "from tools t " +
                 "inner join toollocation l on " +
                 "t.sn = l.lsn " +
                 "where " +
                 sType +
                 sGrit +
                 sUsableLength +
                 sDiameter +
                 sTNumber +
                 " and program = '" + g.program + "' " +
                 " and lfacility = '" + g.facility + "' " +
                 "and status is not null  and status != 'I' " +
                 "order by diameter,usablelength,grit", cnxn);

            dt3 = new DataTable();

            da3.Fill(dt3);

            DGV.DataSource = dt3;


        }



        private void bExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbddGrit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbUsableLength_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbDiameter_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbddType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            i = dt3.Rows.Count;

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            PrintDialog ptd = new PrintDialog();
            ptd.Document = pd;
            DialogResult result = ptd.ShowDialog();
            if (result == DialogResult.OK)
            {
                pd.Print();
            }
        }


        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            string date = DateTime.Now.ToShortDateString();
            int linedrop = 100;
            int count = 0;
            int linesPerpage = 46;
            int lineNo = this.pagesPrinted * linesPerpage;
            int pageNo = pagesPrinted + 1;
            double NumPages = Math.Ceiling(((i - 1) / 46.0));
            //NumPages = NumPages + 1;
            if (NumPages == 0) { NumPages = 1; }

            Pen pen = new Pen(Color.Black);
            pen.Width = 1;
            Font arial = new Font("arial", 10, FontStyle.Regular);
            Font title = new Font("arial", 30, FontStyle.Regular);
            Font heading = new Font("arial", 16, FontStyle.Bold);
            Font leaders = new Font("arial", 12, FontStyle.Bold);
            Font arial7 = new Font("arial", 7, FontStyle.Regular);

            

                ev.Graphics.DrawString("Date Printed: " + date, arial7, Brushes.Black, 50, 1050);
                ev.Graphics.DrawString("Page  " + pageNo + " of " + NumPages, arial7, Brushes.Black, 700, 1050);
                ev.Graphics.DrawString(dt3.Rows[0][0].ToString(), heading, Brushes.Black, 50, 30);
                
                pen.Width = 2;
                ev.Graphics.DrawLine(pen, 50, 60, 750, 60);

                ev.Graphics.DrawString("SN", leaders, Brushes.Black, 75, 70);
                ev.Graphics.DrawString("Diameter", leaders, Brushes.Black, 270, 70);
                ev.Graphics.DrawString("Diameter_M", leaders, Brushes.Black, 400, 70);
                ev.Graphics.DrawString("Grit", leaders, Brushes.Black, 525, 70);
                ev.Graphics.DrawString("Location", leaders, Brushes.Black, 650, 70);

                while (count < linesPerpage && lineNo < i)
                {

                    ev.Graphics.DrawString(dt3.Rows[lineNo][1].ToString(), arial, Brushes.Black, 75, linedrop);
                    ev.Graphics.DrawString(dt3.Rows[lineNo][2].ToString(), arial, Brushes.Black, 270, linedrop);
                    ev.Graphics.DrawString(dt3.Rows[lineNo][3].ToString(), arial, Brushes.Black, 400, linedrop);
                    ev.Graphics.DrawString(dt3.Rows[lineNo][4].ToString(), arial, Brushes.Black, 525, linedrop);
                    ev.Graphics.DrawString(dt3.Rows[lineNo][6].ToString(), arial, Brushes.Black, 650, linedrop);

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
