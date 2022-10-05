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


namespace Certs
{
    public partial class FORM_325B1 : Form
    {
        SqlCommand cmd;
        SqlConnection cnxn;
        SqlDataReader dr;

        private string printtext = string.Empty;
        private string longString = string.Empty;
        private int linedrop = 200;

        public FORM_325B1()
        {
            InitializeComponent();
        }

        private void FORM_325B1_Load(object sender, EventArgs e)
        {
            PrintDialog pdg = new PrintDialog();
            /*  use print dialog box to be able to select printer    */

            if (DialogResult.OK == pdg.ShowDialog())
            {
                PrintDocument pd = new PrintDocument();
                /*  set the document to use the print dialog printer settings   */
                pd.PrinterSettings = pdg.PrinterSettings;
                pd.DefaultPageSettings.Landscape = false;
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                PrintPreviewDialog ppd = new PrintPreviewDialog();
                ppd.Document = pd;
                (ppd as Form).WindowState = FormWindowState.Maximized;

                ppd.ShowDialog();
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
            Font leaders = new Font("arial", 9, FontStyle.Regular);
            Pen pen = new Pen(Color.Black);
            StringFormat alignR = new StringFormat();
            alignR.Alignment = StringAlignment.Far;


            cnxn = new SqlConnection(g.db);

            cmd = new SqlCommand
                ("SELECT " +
            " [Customer Name] " +
            ",[Customer PO #] " +
            ",[OrderNumberZygo] " +
            ",[P/N] " +
            ",[Desc] " +
            ",CustomerPN " +
            ",CustomerPNDescription " +
            ",CustomerRev " +
            ",[Test Date] " +
            ",ThroughTestDate " +
            ",Quantity " +
            ",[Serial #] " +
            ",CASE " +
            "   WHEN LEN(COALESCE(Quanity2,'')) > 0 THEN Quanity2 " +
            "    ELSE Notes " +
            "END Notes " +
            ",[Certified Results] " +
            ",Temperature " +
            ",RelativeHumidity " +
            ",[Other Pertinent Information] " +
            ",[Written by] " +
            ",[Name] " +
            ",[Title] " +
            ",[Date] " +
            ",[Shipped Date] " +
            ",[ZygoSite] " +
            " FROM " + g.dbTable +
            " WHERE [Certification #] = '" + g.certificationNumber + "'" +
            " AND [Type] = 'com' "
            , cnxn);

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
                    Image i = Properties.Resources.zygo_logo_smpt3;
                    ev.Graphics.DrawImage(i, 65, 50, i.Width, i.Height);
                    Image ii = Properties.Resources.AME080_RGB28;
                    ev.Graphics.DrawImage(ii, 625, 65, ii.Width, ii.Height);

                    ev.Graphics.DrawLine(pen, 45, 105, 770, 105);
                    ev.Graphics.DrawLine(pen, 45, 105, 45, 1025);
                    ev.Graphics.DrawLine(pen, 770, 105, 770, 1025);
                    ev.Graphics.DrawLine(pen, 45, 1025, 770, 1025);

                    ev.Graphics.DrawLine(pen, 50, 110, 765, 110);
                    ev.Graphics.DrawLine(pen, 50, 110, 50, 1020);
                    ev.Graphics.DrawLine(pen, 765, 110, 765, 1020);
                    ev.Graphics.DrawLine(pen, 50, 1020, 765, 1020);

                    ev.Graphics.DrawString("Certificate of Compliance", title, Brushes.Black, 200, 120);
                    ev.Graphics.DrawString("Certification #:", topheading, Brushes.Black, 300, 170);
                    ev.Graphics.DrawString(g.certificationNumber, topheading, Brushes.Black, 420, 170);


                    ev.Graphics.DrawString("Customer Name:", heading, Brushes.Black, 55, linedrop);
                    ev.Graphics.DrawString(dr.GetString(0).Trim(), arial, Brushes.Black, 175, linedrop);

                    lines();

                    ev.Graphics.DrawString("Customer PO #:", heading, Brushes.Black, 55, linedrop);
                    if (!dr.IsDBNull(1)) { printtext = dr.GetString(1).Trim(); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 170, linedrop);

                    ev.Graphics.DrawString("Test Date:", heading, Brushes.Black, 475, linedrop);
                    if (!dr.IsDBNull(8)) { printtext = dr.GetDateTime(8).ToString("MM/dd/yyyy"); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 550, linedrop);

                    /*  if there is a through date then add extra text and the date    */
                    if (!dr.IsDBNull(9)) { printtext = " through " + dr.GetDateTime(9).ToString("MM/dd/yyyy"); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 625, linedrop);

                    lines();

                    ev.Graphics.DrawString("Zygo SO #:", heading, Brushes.Black, 475, linedrop);
                    if (!dr.IsDBNull(2)) { printtext = dr.GetString(2).Trim(); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 555, linedrop);

                    ev.Graphics.DrawString("Customer P/N:", heading, Brushes.Black, 55, linedrop);
                    if (!dr.IsDBNull(5)) { printtext = dr.GetString(5).Trim(); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 160, linedrop);

                    lines();

                    ev.Graphics.DrawString("Rev:", heading, Brushes.Black, 55, linedrop);
                    if (!dr.IsDBNull(7)) { printtext = dr.GetString(7).Trim(); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 95, linedrop);

                    lines();

                    ev.Graphics.DrawString("Description:", heading, Brushes.Black, 55, linedrop);

                    if (!dr.IsDBNull(6))
                    {
                        printtext = dr.GetString(6).Trim();
 
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 145, linedrop);
                        
                    }
                    else
                    {
                        printtext = "";

                    }

                    lines();


                    ev.Graphics.DrawString("Quantity:", heading, Brushes.Black, 55, linedrop);
                    if (!dr.IsDBNull(10)) { printtext = dr.GetInt32(10).ToString().Trim(); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 125, linedrop);

                    lines();

                    ev.Graphics.DrawString("Zygo P/N:", heading, Brushes.Black, 55, linedrop);
                    if (!dr.IsDBNull(3)) { printtext = dr.GetString(3).Trim(); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 125, linedrop);

                    lines();

                    ev.Graphics.DrawString("Serial #/Date Code:", heading, Brushes.Black, 55, linedrop);
                    if (!dr.IsDBNull(11)) { printtext = longString; } else { printtext = ""; }


                    if (!dr.IsDBNull(11))
                    {
                        longString = dr.GetString(11).Trim();
                        longString = longString.Replace("\r", "");
                        longString = longString.Replace("\n", " ");

                        printtext = longString;


                        /* the most text here is 255 characters so one line of 80 and two of 105 should do it    */

                        int lastword = 0;
                        int startpoint = 0;
                        int printFlag = 0;
                        int tl = longString.Length;

                        if (longString.Length < 71)
                        {
                            ev.Graphics.DrawString(printtext, arial, Brushes.Black, 185, linedrop);
                        }
                        else
                        {
                            if (longString.Length > 70)
                            {
                                printtext = longString.Substring(startpoint, 70);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 185, linedrop);
                            }

                            lines();

                            /*  first full line  */
                            if (dr.GetString(11).Length > 186)
                            {
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, 90);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, linedrop);
                                printFlag = 1;
                            }

                            lines();
                            
                            if (printFlag == 0)
                            {
                                startpoint = startpoint + lastword + 1;
                                printtext = dr.GetString(11).Substring(startpoint, dr.GetString(11).Length - startpoint);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, linedrop);
                            }

                            if (printFlag == 1)
                            {
                                startpoint = startpoint + lastword + 1;
                                printtext = dr.GetString(11).Substring(startpoint, dr.GetString(11).Length - startpoint);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, linedrop);
                            }
                        }
                    }

                    lines();

                    ev.Graphics.DrawString("Certified Results:", heading, Brushes.Black, 55, linedrop);
                    //if (!dr.IsDBNull(13)) { printtext = dr.GetString(13); } else { printtext = ""; }
                    //ev.Graphics.DrawString(printtext, arial, Brushes.Black, 185, linedrop);

                    if (!dr.IsDBNull(13))
                    {
                        longString = dr.GetString(13).Trim();
                        longString = longString.Replace("\r", "");
                        longString = longString.Replace("\n", " ");

                        printtext = longString;

                        /* the most text here is 255 characters so one line of 80 and two of 105 should do it    */

                        int lastword = 0;
                        int startpoint = 0;
                        int printFlag = 0;
                        int tl = longString.Length;

                        if (longString.Length < 81)
                        {
                            ev.Graphics.DrawString(printtext, arial, Brushes.Black, 180, linedrop);
                        }
                        else
                        {
                            if (longString.Length > 80)
                            {
                                printtext = longString.Substring(startpoint, 80);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 180, linedrop);
                            }

                            linedrop = linedrop + 30;

                            /*  first full line  */
                            if (longString.Length > 186)
                            {
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, 105);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, linedrop);
                                printFlag = 1;
                            }

                            lines();

                            if (printFlag == 0)
                            {
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, longString.Length - startpoint);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, linedrop);
                            }

                            if (printFlag == 1)
                            {
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, longString.Length - startpoint);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, linedrop);
                            }

                            
                        }
                    }

                    lines();
                    lines();
                    
                    ev.Graphics.DrawString("Test Conditions - Temperature (C):", heading, Brushes.Black, 55, linedrop);
                    if (!dr.IsDBNull(14)) { printtext = dr.GetString(14).Trim(); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 290, linedrop);

                    ev.Graphics.DrawString("Relative Humidity (%):", heading, Brushes.Black, 475, linedrop);
                    if (!dr.IsDBNull(15)) { printtext = dr.GetString(15).Trim(); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 630, linedrop);

                    
                    ev.Graphics.DrawString("Other Pertinent Information:", heading, Brushes.Black, 55, 610);

                    if (!dr.IsDBNull(16))
                    {
                        longString = dr.GetString(16).Trim();
                        longString = longString.Replace("\r", "");
                        longString = longString.Replace("\n", " ");

                        printtext = longString;

                        /* the most text here is 506 characters so one line of 80 and four of 105 should do it - we lose 5 characters    */

                        int lastword = 0;
                        int startpoint = 0;
                        int printFlag = 0;

                        if (longString.Length < 61)
                        {
                            ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 250, 610);
                        }
                        else
                        {
                            if (longString.Length >= 60)
                            {
                                printtext = longString.Substring(startpoint, 60);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 250, 610);
                            }
                            /*  first full line  */
                            if (longString.Length > 166)
                            {
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, 105);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, 630);
                                printFlag = 1;
                            }
                            /*  second full line  */

                            if (longString.Length > 271)
                            {
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, 105);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, 645);
                                printFlag = 2;
                            }

                            /*  third full line  */

                            if (longString.Length > 376)
                            {
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, 105);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, 660);
                                printFlag = 3;
                            }
                            /*  fourth full line  */

                            if (longString.Length > 481)
                            {
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, 105);
                                lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, 675);
                            }

                            if (printFlag == 0)
                            {
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, longString.Length - startpoint);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, 630);
                            }

                            if (printFlag == 1)
                            {
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, longString.Length - startpoint);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, 645);
                            }

                            if (printFlag == 2)
                            {
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, longString.Length - startpoint);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, 660);
                            }

                            if (printFlag == 3)
                            {
                                startpoint = startpoint + lastword + 1;
                                printtext = longString.Substring(startpoint, longString.Length - startpoint);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, 670);
                            }
                        }
                    }

                    ev.Graphics.DrawString("We hereby certify that all item(s) shipped against the above purchase order are in ", heading, Brushes.Black, 100, 725);
                    ev.Graphics.DrawString("conformance with the requirements, specifications, and drawings applicable to that ", heading, Brushes.Black, 100, 745);
                    ev.Graphics.DrawString("order at the time of shipment.", heading, Brushes.Black, 100, 765);

                    Image iii = Properties.Resources.Certification_Emblem_QC_Large;
                    ev.Graphics.DrawImage(iii, 100, 795, iii.Width - 235, iii.Height - 250); //for quality seal

                    /*box = new Rectangle(115, 365, 35, 20);
                     * 
                    ev.Graphics.DrawString(aF6[lineNo], A9R, Brushes.Black, box, alignR);
                    */


                    ev.Graphics.DrawString("Signed:_______________________________", heading, Brushes.Black, 400, 800);

                    var box = new Rectangle(350, 830, 100, 20);
                    ev.Graphics.DrawString("Name:", heading, Brushes.Black, box, alignR);
                    if (!dr.IsDBNull(18)) { printtext = dr.GetString(18); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 460, 830);

                    box = new Rectangle(350, 855, 100, 20);
                    ev.Graphics.DrawString("Title:", heading, Brushes.Black, box, alignR);
                    if (!dr.IsDBNull(19)) { printtext = dr.GetString(19); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 460, 855);

                    box = new Rectangle(350, 885, 100, 20);
                    ev.Graphics.DrawString("Date:", heading, Brushes.Black, box, alignR);
                    if (!dr.IsDBNull(20)) { printtext = dr.GetDateTime(20).ToString("MM/dd/yyyy"); } else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 460, 885);

                    box = new Rectangle(350, 915, 100, 20);
                    ev.Graphics.DrawString("Zygo Site:", heading, Brushes.Black, box, alignR);
                    if (!dr.IsDBNull(22))
                    { printtext = dr.GetString(22).ToString(); }
                    else { printtext = ""; }
                    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 460, 915);

                    if (!dr.IsDBNull(17))
                    { ev.Graphics.DrawString(dr.GetString(17).ToString(), smallarial, Brushes.Black, 55, 945); }

                    ev.Graphics.DrawString("Zygo Corporation - Laurel Brook Road - Middlefield CT 06455", smallarial, Brushes.Black, 210, 945);
                    ev.Graphics.DrawString("Telephone 860-347-8506  Main Corporate Fax 860-347-8372", smallarial, Brushes.Black, 210, 965);


                    ev.Graphics.DrawString("Zygo grants our customer's approval to reproduce test reports, only if reported in full, for use in demonstrating", smallarial, Brushes.Black, 120, 985);
                    ev.Graphics.DrawString("the traceablity of the measurements.", smallarial, Brushes.Black, 320, 1000);

                    ev.Graphics.DrawString("FORM-0325B", smallarial, Brushes.Black, 80, 1030);

                    ev.Graphics.DrawString("Certification Number:", smallarial, Brushes.Black, 340, 1030);
                    ev.Graphics.DrawString(g.certificationNumber, smallarial, Brushes.Black, 450, 1030);
                    ev.Graphics.DrawString("Page 1 of 1", smallarial, Brushes.Black, 700, 1030);

                    //page1printed = true;
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

            ev.HasMorePages = false;

            linedrop = 200;

            this.Close();
            //}
        }
        private void lines()
        {
            linedrop = linedrop + 30;
        }


    }
}
