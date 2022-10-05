using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.SqlClient;
using System.IO;


namespace Certs
{
    public partial class F0281_02B : Form
    {
        SqlCommand cmd;
        SqlConnection cnxn;
        SqlDataReader dr;

        private string printtext = string.Empty;
        private string longString = string.Empty;
        private bool page1printed = false;
        private bool page2printed = false;
        private int linedrop = 200;

        public F0281_02B()
        {
            InitializeComponent();
        }

        private void F0281_02B_Load(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = false;

            pd.DefaultPageSettings.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            string file = "Calibration " + g.certificationNumber + ".pdf";
            string directory = "C:\\A";

            if (Directory.Exists(directory))
            {

                pd.PrinterSettings.PrintToFile = true;
                pd.PrinterSettings.PrintFileName = Path.Combine(directory, file);
                StandardPrintController pc = new StandardPrintController();
                pd.PrintController = pc;

                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                try
                {
                    pd.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                MessageBox.Show("File Printed");
            }
            else
            {
                MessageBox.Show("Need to add folder 'C:\\A'");
                this.Close();
            }

            Close();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Font arial = new Font("arial", 10, FontStyle.Regular);
            Font smallarial = new Font("arial", 8, FontStyle.Regular);
            Font title = new Font("arial", 24, FontStyle.Bold);
            Font heading = new Font("arial", 10, FontStyle.Bold);
            Font topheading = new Font("arial", 12, FontStyle.Bold);
            Font leaders = new Font("arial", 10, FontStyle.Regular);
            Font super = new Font("arial", 6, FontStyle.Regular);
            Pen pen = new Pen(Color.Black);


            cnxn = new SqlConnection(g.db);

            cmd = new SqlCommand
                ("SELECT  " +
        /*0*/   " [Certification #] " +
                " ,[Customer Name] " +
                " ,[Customer PO #] " +
                " ,[Test Date] " +
                " ,[Calibration Procedure] " +
                " ,[Desc] " +           //5
                " ,[P/N] " +
                " ,[Serial #] " +
                " ,[Certified Results] " +
         /*9*/  " ,[Type of Test Performed] " +
                " ,COALESCE([Reference Standards Used],'') + ' ' + COALESCE([Reference Standards Used 2],'') + ' ' + " +
                  "COALESCE([Reference Standards Used 3],'') + ' ' + COALESCE([Reference Standards Used 4],'') " +
                " ,Temperature " +
                " ,RelativeHumidity " +
         /*13*/ " ,[Other Pertinent Information] + COALESCE([Other Pertinent Information 2],'')" +
                " ,Name " +
                " ,Title " +
                ",Date " +
                ",[Written by] " +
                ",[NextCalibrationDue] " +
                ",AsFoundCondition " +
                ",AsLeftcondition " +
                " FROM " + g.dbTable + " WHERE [certification #] = '" + g.certificationNumber + "'"
                , cnxn);

            /*   For testing:  6246 long other texts   100 test company  */


            cnxn.Open();

            try
            {
                dr = cmd.ExecuteReader();
                DataTable t = new DataTable();

                t.Load(dr);

                dr = cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }



            while (dr.Read())
            {
                try
                {
                    Image i = Properties.Resources.zygo_logo_trans_300dpi;
                    ev.Graphics.DrawImage(i, 65, 50, i.Width - 480, i.Height - 120);
                    Image ii = Properties.Resources.AME080_RGB;
                    ev.Graphics.DrawImage(ii, 598, 60, ii.Width - 350, ii.Height - 70);

                    ev.Graphics.DrawString("Certificate of Calibration", title, Brushes.Black, 200, 120);
                    ev.Graphics.DrawString("Certification #:", topheading, Brushes.Black, 300, 170);
                    ev.Graphics.DrawString(dr.GetInt32(0).ToString(), topheading, Brushes.Black, 420, 170);


                    ev.Graphics.DrawString("Customer Name:", heading, Brushes.Black, 55, linedrop);
                    ev.Graphics.DrawString(dr.GetString(1).Trim(), arial, Brushes.Black, 175, linedrop);

                    lines();

                    ev.Graphics.DrawString("Customer PO #:", heading, Brushes.Black, 55, linedrop);
                    if (!dr.IsDBNull(2)) { printtext = dr.GetString(2).Trim(); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 175, linedrop);

                    ev.Graphics.DrawString("Test Date:", heading, Brushes.Black, 500, linedrop);
                    if (!dr.IsDBNull(3)) { printtext = dr.GetDateTime(3).ToString("MM/dd/yyyy"); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 575, linedrop);

                    lines();

                    ev.Graphics.DrawString("Part #:", heading, Brushes.Black, 55, linedrop);
                    if (!dr.IsDBNull(6)) { printtext = dr.GetString(6).Trim(); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 105, linedrop);

                    lines();

                    ev.Graphics.DrawString("Description:", heading, Brushes.Black, 55, linedrop);
                    if (!dr.IsDBNull(5)) { printtext = dr.GetString(5).Trim(); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 145, linedrop);

                    lines();

                    ev.Graphics.DrawString("Serial #:", heading, Brushes.Black, 55, linedrop);
                    if (!dr.IsDBNull(7))
                    {
                        longString = dr.GetString(7).Trim();
                        longString = longString.Replace("\r", "");
                        longString = longString.Replace("\n", " ");

                        printtext = longString;

                        int lastword = 0;
                        int startpoint = 0;
                        int printFlag = 0;
                        int tl = longString.Length;

                        if (longString.Length <= 90)
                        {
                            ev.Graphics.DrawString(printtext, arial, Brushes.Black, 115, linedrop);
                        }
                        else
                        {
                            if (longString.Length > 90)
                            {
                                printtext = longString.Substring(startpoint, 90);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 115, linedrop);
                            }

                            
                            /*  first full line  */
                            if (longString.Length > 186)
                            {
                                lines();
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, 90);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, linedrop);
                                printFlag = 1;
                            }

                            
                            if (printFlag == 0)
                            {
                                lines();
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, longString.Length - startpoint);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, linedrop);
                            }

                            if (printFlag == 1)
                            {
                                lines();
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, longString.Length - startpoint);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, linedrop);
                            }
                        }
                    }

                    lines();

                    ev.Graphics.DrawString("As Found Condition:", heading, Brushes.Black, 55, linedrop);
                    if (!dr.IsDBNull(19)) { printtext = dr.GetString(19).Trim(); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 200, linedrop);
                                       
                    ev.Graphics.DrawString("As Left Condition:", heading, Brushes.Black, 360, linedrop);
                    if (!dr.IsDBNull(20)) { printtext = dr.GetString(20).Trim(); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 490, linedrop);

                    lines();

                    ev.Graphics.DrawString("Test Conditions - Temperature (C):", heading, Brushes.Black, 55, linedrop);
                    if (!dr.IsDBNull(11)) { printtext = dr.GetString(11).Trim(); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 295, linedrop);

                    ev.Graphics.DrawString("Relative Humidity (%):", heading, Brushes.Black, 360, linedrop);
                    if (!dr.IsDBNull(12)) { printtext = dr.GetString(12).Trim(); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 515, linedrop);

                    lines();
                    
                    ev.Graphics.DrawString("Calibration Procedure:", heading, Brushes.Black, 55, linedrop);
                    if (!dr.IsDBNull(4)) { printtext = dr.GetString(4).Trim(); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 215, linedrop);

                    lines();

                    ev.Graphics.DrawString("Certified Results:", heading, Brushes.Black, 55, linedrop);

                    if (!dr.IsDBNull(8))
                    {
                        longString = dr.GetString(8).Trim();
                        longString = longString.Replace("\r", "");
                        longString = longString.Replace("\n", " ");

                        /* the most text here is 255 characters so one line of 80 and two of 105 should do it - we lose 5 characters    */

                        int lastword = 0;
                        int startpoint = 0;
                        int printFlag = 0;


                        if (longString.Length < 100)
                        {
                            printtext = longString;
                            ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 175, linedrop);
                            lines();
                        }
                        else
                        {
                            if (longString.Length > 100)
                            {
                                printtext = longString.Substring(startpoint, 100);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 175, linedrop);
                            }
                            /*  first full line if enough text for three lines */
                            if (longString.Length > 215)
                            {
                                linedrop = linedrop + 20;
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, 115);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, linedrop);
                                printFlag = 1;
                            }

                            /*  if there is more than one line but not three then print the rest of the text  */
                            if (printFlag == 0)
                            {
                                linedrop = linedrop + 20;
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, longString.Length - startpoint);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, linedrop);
                            }

                            /* printing the third line*/
                            if (printFlag == 1)
                            {
                                linedrop = linedrop + 20;
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, longString.Length - startpoint);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, linedrop);
                            }
                        }
                    }

                    lines();

                    ev.Graphics.DrawString("Next Calibration Due:", heading, Brushes.Black, 55, linedrop);
                    if (!dr.IsDBNull(18)) { printtext = dr.GetDateTime(18).ToShortDateString(); } else { printtext = ""; }
                    //if (!dr.IsDBNull(18)) { printtext = dr.GetString(18); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 215, linedrop);

                    lines();

                    ev.Graphics.DrawString("Type of Test Performed:", heading, Brushes.Black, 55, linedrop);


                    if (!dr.IsDBNull(9))
                    {
                        longString = dr.GetString(9).Trim();
                        longString = longString.Replace("\r", "");
                        longString = longString.Replace("\n", " ");

                        printtext = longString;

                        /* the most text here is 255 characters so one line of 80 and two of 105 should do it - we lose 5 characters    */

                        int lastword = 0;
                        int startpoint = 0;
                        int printFlag = 0;

                        if (longString.Length < 81)
                        {
                            ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 220, linedrop);
                            lines();
                        }
                        else
                        {
                            if (longString.Length > 80)
                            {
                                printtext = longString.Substring(startpoint, 80);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 220, linedrop);
                            }
                            /*  first full line  */
                            if (longString.Length > 186)
                            {
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, 105);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, linedrop);
                                printFlag = 1;
                            }


                            if (printFlag == 0)
                            {
                                linedrop = linedrop + 20;
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, longString.Length - startpoint);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, linedrop);
                            }

                            if (printFlag == 1)
                            {
                                linedrop = linedrop + 20;
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, dr.GetString(9).Length - startpoint);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, linedrop);
                            }
                        }
                    }

                    lines();

                    ev.Graphics.DrawString("Reference Standards Used:", heading, Brushes.Black, 55, linedrop);

                    if (!dr.IsDBNull(10))
                    {
                        longString = dr.GetString(10).Trim();
                        longString = longString.Replace("\r", "");
                        longString = longString.Replace("   ", "");
                        longString = longString.Replace("\n", " ");

                        printtext = longString;

                        
                        int lastword = 0;
                        int startpoint = 0;
                        int printFlag = 0;

                        if (longString.Length < 81)
                        {
                            ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 250, linedrop +2);
                        }
                        else
                        {
                            if (longString.Length > 80)
                            {
                                printtext = longString.Substring(startpoint, 80);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 250, linedrop +2);
                            }
                            /*  first full line  */
                            if (longString.Length > 186)
                            {
                                linedrop = linedrop + 20;
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, 105);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, linedrop);
                                printFlag = 1;
                            }


                            if (printFlag == 0)
                            {
                                linedrop = linedrop + 20;
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, longString.Length - startpoint);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, linedrop);
                            }

                            if (printFlag == 1)
                            {
                                linedrop = linedrop + 20;
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, dr.GetString(10).Length - startpoint);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, linedrop);
                            }

                        }

                    }

                    lines();

                    ev.Graphics.DrawString("Other Pertinent Information:", heading, Brushes.Black, 55, linedrop);

                    if (!dr.IsDBNull(13))
                    {
                        longString = dr.GetString(13).Trim();
                        longString = longString.Replace("\r", "");
                        longString = longString.Replace("\n", " ");

                        printtext = longString;
                        
                        /* the most text here is 506 characters so one line of 80 and four of 105 should do it - we lose 5 characters    */

                        int lastword = 0;
                        int startpoint = 0;
                        int printFlag = 0;

                        if (longString.Length <= 80)
                        {
                            ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 252, linedrop);
                        }
                        else
                        {
                            if (longString.Length > 80)
                            {
                                printtext = longString.Substring(startpoint, 80);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 250, linedrop);
                            }
                            /*  first full line  */
                            if (longString.Length > 186)
                            {
                                linedrop = linedrop + 20;
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, 105);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, linedrop);
                                printFlag = 1;
                            }
                            /*  second full line  */

                            if (longString.Length > 291)
                            {
                                linedrop = linedrop + 20;
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, 105);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, linedrop);
                                printFlag = 2;
                            }

                            /*  third full line  */

                            if (longString.Length > 396)
                            {
                                linedrop = linedrop + 20;
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, 105);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, linedrop);
                                printFlag = 3;
                            }
                            /*  fourth full line  */

                            if (dr.GetString(13).Length > 501)
                            {
                                linedrop = linedrop + 20;
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, 115);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, linedrop);
                            }

                            if (printFlag == 0)
                            {
                                linedrop = linedrop + 20;
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, longString.Length - startpoint);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, linedrop);
                            }

                            if (printFlag == 1)
                            {
                                linedrop = linedrop + 20;
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, longString.Length - startpoint);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, linedrop);
                            }

                            if (printFlag == 2)
                            {
                                linedrop = linedrop + 20;
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, longString.Length - startpoint);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, linedrop);
                            }

                            if (printFlag == 3)
                            {
                                linedrop = linedrop + 20;
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, longString.Length - startpoint);
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, linedrop);
                            }
                        }
                    }

                    ev.Graphics.DrawString("Calibration measurements comply with ANSI/CSL Z540-1. Traceable according to the requirement of ISO-17025.", heading, Brushes.Black, 55, 720);
                    ev.Graphics.DrawString("Interferometers or references used for this test have been calibrated per an absolute method appropriate", heading, Brushes.Black, 55, 740);
                    ev.Graphics.DrawString("for the specific configurationand alignment necessary for this item.", heading, Brushes.Black, 55, 760);
                    ev.Graphics.DrawString("", heading, Brushes.Black, 55, 760);

                    Image iii = Properties.Resources.Precision_Measurements_Seal;
                    ev.Graphics.DrawImage(iii, 50, 840, iii.Width - 30, iii.Height - 30);


                    ev.Graphics.DrawString("Signed:_______________________________", heading, Brushes.Black, 250, 850);
                    ev.Graphics.DrawString("Name:", heading, Brushes.Black, 250, 880);
                    if (!dr.IsDBNull(14)) { printtext = dr.GetString(14); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 310, 882);

                    ev.Graphics.DrawString("Title:", heading, Brushes.Black, 250, 910);
                    if (!dr.IsDBNull(15)) { printtext = dr.GetString(15); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 310, 912);

                    ev.Graphics.DrawString("Date:", heading, Brushes.Black, 250, 940);
                    if (!dr.IsDBNull(16)) { printtext = dr.GetDateTime(16).ToString("MM/dd/yyyy"); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 310, 942);

                    if (!dr.IsDBNull(17)) { printtext = dr.GetString(17); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, smallarial, Brushes.Black, 55, 970);

                    ev.Graphics.DrawString("Zygo Corporation - Laurel Brook Road - Middlefield CT 06455", smallarial, Brushes.Black, 210, 970);
                    ev.Graphics.DrawString("Telephone 860-347-8506  Main Corporate Fax 860-347-8372", smallarial, Brushes.Black, 210, 990);

                    //if (!dr.IsDBNull(23)) { printtext = dr.GetString(21); } else { printtext = ""; }
                    //ev.Graphics.DrawString(printtext, smallarial, Brushes.Black, 100, 990);

                    ev.Graphics.DrawString("Zygo grants our customers approval to reproduce test reports, only if reported in full, for use in demonstrating", smallarial, Brushes.Black, 120, 1010);
                    ev.Graphics.DrawString("the traceability of the measurements of the serial numbered item listed in this report.", smallarial, Brushes.Black, 180, 1025);

                    ev.Graphics.DrawString("Form 0281-02b", smallarial, Brushes.Black, 80, 1050);

                    //ev.Graphics.DrawString("X             X", smallarial, Brushes.Black, 340, 950);
                    ev.Graphics.DrawString("Certification Number:", smallarial, Brushes.Black, 340, 1050);
                    ev.Graphics.DrawString(dr.GetInt32(0).ToString(), smallarial, Brushes.Black, 450, 1050);
                    ev.Graphics.DrawString("Page 1 of 1", smallarial, Brushes.Black, 700, 1050);

                    page1printed = true;
                

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {

                }
            }

            cnxn.Close();

            this.Close();
        }

        private void lines()
        {
            linedrop = linedrop + 30;
        }
    }
}
