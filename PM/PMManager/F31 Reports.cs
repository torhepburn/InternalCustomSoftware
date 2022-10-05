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

namespace PMManager
{
    public partial class F31_Reports : Form
    {
        SqlDataAdapter da;
        DataTable table;
        private int pagesPrinted = 0;
        private int i;
        private string trouble;
        
        public F31_Reports()
        {
            InitializeComponent();
        }

        private void F31_Reports_Load(object sender, EventArgs e)
        {
            label1.Text = g.PMcategory;
            
            SqlConnection cnxn = new SqlConnection
                ("server=MIDSQL01; user=readWrite; password=Read+Write!; database=PM_2015_A;");

            da = new SqlDataAdapter
                ("(select Serial, " +
                 "trouble_severity Severity, " +
                 "trouble_rptd_date [Date Reported], " +
                 "trouble_rptd_by [Reported By], " +
                 "trouble_assignedto [Assigned To], " +
                 "Trouble, " +
                 "trouble_work_reference_number [Reference Number]" +
                 "from [repair history] where " +
                 "trouble_status = 'Assigned' " +
                 "and trouble_repair_category = '" + g.PMcategory + "' " +
                 "and serial not like '%facility%' " +
                 "and serial not like 'RI-%' " +
                 "and serial not like 'CM-%') " +
                 "union " +
                 "(select " +
                 "[serial] Serial, " +
                 "[severity] Severity, " +
                 "[request_date] [Date Reported], " +
                 "[requestor] [Reported By], " +
                 "'Unassigned' [Assigned To], " +
                 "Trouble, " +
                 "'Unassigned' [Reference Number] " +
                 "from [repair_requests] " +
                 "where " +
                 "[category] != 'Preventive Maintenance') " +
                 "order by [date reported]" , cnxn);
            
            table = new DataTable();
            da.Fill(table);

            dgv.DataSource = table;
                    
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            i = table.Rows.Count;
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            (ppd as Form).WindowState = FormWindowState.Maximized;
            ppd.ShowDialog();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Font arial = new System.Drawing.Font("arial", 8, FontStyle.Regular);
            int lineDrop = 110;
            int count = 0;
            int linesPerPage = 12;
            int lineNo = this.pagesPrinted * linesPerPage;
            ev.Graphics.DrawString(g.PMcategory, arial, Brushes.Black, 25, 40);
            ev.Graphics.DrawString(DateTime.Now.ToString(), arial, Brushes.Black, 650, 40);
            ev.Graphics.DrawString("Serial No.", arial, Brushes.Black, 25, 80);
            ev.Graphics.DrawString("Severity", arial, Brushes.Black, 250, 80);
            ev.Graphics.DrawString("Date Reported", arial, Brushes.Black, 350, 80);
            ev.Graphics.DrawString("Reported By", arial, Brushes.Black, 500, 80);
            ev.Graphics.DrawString("Assigned to", arial, Brushes.Black, 650, 80);                    
    
            while (count < linesPerPage && lineNo < i)
                {
                    ev.Graphics.DrawString(table.Rows[lineNo][0].ToString(), arial, Brushes.Black, 25, lineDrop);
                    ev.Graphics.DrawString(table.Rows[lineNo][1].ToString(), arial, Brushes.Black, 250, lineDrop);
                    ev.Graphics.DrawString(table.Rows[lineNo][2].ToString(), arial, Brushes.Black, 350, lineDrop);
                    ev.Graphics.DrawString(table.Rows[lineNo][3].ToString(), arial, Brushes.Black, 500, lineDrop);
                    ev.Graphics.DrawString(table.Rows[lineNo][4].ToString(), arial, Brushes.Black, 650, lineDrop);
                    trouble = table.Rows[lineNo][5].ToString();
                    trouble = trouble.Replace("\r\n", " ");
                    if (trouble.Length > 145)
                    {
                        int SentEnd = trouble.IndexOf(" ", 135);
                        ev.Graphics.DrawString(trouble.Substring(0, SentEnd), arial, Brushes.Black, 25, (lineDrop + 15));
                        trouble = trouble.Substring((SentEnd + 1), (trouble.Length - (SentEnd + 1)));

                        if (trouble.Length > 145)
                        {
                            SentEnd = trouble.IndexOf(" ", 135);
                            ev.Graphics.DrawString(trouble.Substring(0, SentEnd), arial, Brushes.Black, 25, (lineDrop + 30));
                            trouble = trouble.Substring((SentEnd + 1), (trouble.Length - (SentEnd + 1)));
                            ev.Graphics.DrawString(trouble, arial, Brushes.Black, 25, (lineDrop + 45));
                        }
                        else
                        {
                            ev.Graphics.DrawString(trouble, arial, Brushes.Black, 25, (lineDrop + 30));
                        }
                    }
                    else
                    {
                        ev.Graphics.DrawString(trouble, arial, Brushes.Black, 25, (lineDrop + 15));
                    }
                    
                    lineDrop = lineDrop + 80;
                    count++;
                    lineNo++;
                }

                    if (i > lineNo)
                    {
                        ev.HasMorePages = true;
                        pagesPrinted++;
                    }
                    else
                    {
                        ev.HasMorePages = false;
                        lineDrop = 160;
                        count = 0;
                        pagesPrinted = 0;
                        lineNo = 0;
                    }
                }
            
        }
    }

