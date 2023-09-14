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
    public partial class F0281_04B : Form
    {
        SqlCommand cmd;
        SqlConnection cnxn;
        SqlDataReader dr;

        private string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";
        private string printtext = string.Empty;
        private string longString = string.Empty;
        private bool page1printed = false;
        private bool page2printed = false;

        public F0281_04B()
        {
            InitializeComponent();
        }

        private void F0281_04B_Load(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = false;

            pd.DefaultPageSettings.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            string file = "ReferenceSurface " + g.certificationNumber + ".pdf";
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
            Font leaders = new Font("arial", 9, FontStyle.Regular);
            Font super = new Font("arial", 6, FontStyle.Regular);
            Pen pen = new Pen(Color.Black);


            if (!page1printed)
            {
                cnxn = new SqlConnection(db);

                cmd = new SqlCommand
                    ("SELECT  " +
                     " [Certification #] " +
                    " ,[Customer Name] " +
                    " ,[Customer PO #] " +
                    " ,[Test Date] " +
                    " ,[Calibration Procedure] " +
                    " ,[Desc] " +           //5
                    " ,[P/N] " +
                    " ,Quantity " +
                    " ,[Serial #] " +
                    " ,REPLACE([Certified Results],'Reference Surface Figure Error','') + ' ± ' + COALESCE([Uncertainty],'') " +
                    " ,[Type of Test Performed] " +     //10
                    " ,COALESCE([Reference Standards Used],'') + ' ' + COALESCE([Reference Standards Used 2],'') + ' ' + " +
                    "COALESCE([Reference Standards Used 3],'') + ' ' + COALESCE([Reference Standards Used 4],'') " +
                    " ,Temperature " +
                    " ,RelativeHumidity " +
                    " ,[Other Pertinent Information] + COALESCE([Other Pertinent Information 2],'')" +  //14
                    " ,Name " + //15
                    " ,Title " +
                    " ,AsFoundCondition " +
                    ",DateReceived " +          //18
                    ",Date " +
                    ",AsLeftCondition " +
                    " FROM " + g.dbTable + " WHERE [certification #] = '" + g.certificationNumber + "'"
                    , cnxn);

                /*   6246 long other texts   100 test company  */


                cnxn.Open();

                try
                {
                    dr = cmd.ExecuteReader();
                    DataTable ttt = new DataTable();
                    ttt.Load(dr);
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
                        Image i = Properties.Resources.Unified_Zygo_logo_trans_300dpi;
                        ev.Graphics.DrawImage(i, 550, 50, i.Width - 175, i.Height - 86);

                        ev.Graphics.DrawString("Certificate of Compliance", title, Brushes.Black, 50, 60);
                        ev.Graphics.DrawString("Certification #:", topheading, Brushes.Black, 150, 110);
                        ev.Graphics.DrawString(dr.GetInt32(0).ToString(), topheading, Brushes.Black, 270, 110);

                        ev.Graphics.DrawString("Customer Name:", heading, Brushes.Black, 55, 200);
                        ev.Graphics.DrawString(dr.GetString(1), arial, Brushes.Black, 175, 200);


                        ev.Graphics.DrawString("Customer PO #:", heading, Brushes.Black, 55, 230);
                        if (!dr.IsDBNull(2)) { printtext = dr.GetString(2); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 175, 230);

                        ev.Graphics.DrawString("Test Date:", heading, Brushes.Black, 500, 230);
                        if (!dr.IsDBNull(3)) { printtext = dr.GetDateTime(3).ToString("MM/dd/yyyy"); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 575, 230);


                        ev.Graphics.DrawString("Part #:", heading, Brushes.Black, 55, 260);
                        if (!dr.IsDBNull(6)) { printtext = dr.GetString(6); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 105, 260);

                        ev.Graphics.DrawString("Serial #:", heading, Brushes.Black, 500, 260);
                        if (!dr.IsDBNull(8)) { printtext = dr.GetString(8); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 560, 260);


                        ev.Graphics.DrawString("Description:", heading, Brushes.Black, 55, 290);
                        if (!dr.IsDBNull(5)) { printtext = dr.GetString(5); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 145, 290);


                        ev.Graphics.DrawString("Test Temperature (C):", heading, Brushes.Black, 55, 320);
                        if (!dr.IsDBNull(12)) { printtext = dr.GetString(12); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 210, 320);

                        ev.Graphics.DrawString("Relative Humidity (%):", heading, Brushes.Black, 500, 320);
                        if (!dr.IsDBNull(13)) { printtext = dr.GetString(13); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 655, 320);


                        ev.Graphics.DrawString("Date Received:", heading, Brushes.Black, 55, 350);
                        if (!dr.IsDBNull(18)) { printtext = dr.GetDateTime(18).ToShortDateString(); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 160, 350);

                        ev.Graphics.DrawString("As Found Condition:", heading, Brushes.Black, 500, 350);
                        if (!dr.IsDBNull(17)) { printtext = dr.GetString(17); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 640, 350);


                        ev.Graphics.DrawString("As Left Condition:", heading, Brushes.Black, 360, 380);
                        if (!dr.IsDBNull(17)) { printtext = dr.GetString(20); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 500, 380);

                        ev.Graphics.DrawString("Calibration Procedure:", heading, Brushes.Black, 55, 410);
                        if (!dr.IsDBNull(4)) { printtext = dr.GetString(4); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 215, 410);


                        ev.Graphics.DrawString("Type of Test Performed:", heading, Brushes.Black, 55, 440);

                        if (!dr.IsDBNull(10))
                        {
                            if (dr.GetString(10).Length > 80)
                            {
                                printtext = dr.GetString(10).Substring(0, 80);
                                int lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 225, 440);
                                printtext = dr.GetString(10).Substring(lastword + 1, dr.GetString(10).Length - (lastword + 1));
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, 460);
                            }
                            else
                            {
                                printtext = dr.GetString(10);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 225, 440);
                            }
                            int L = printtext.Length;
                        }
                        else
                        {
                            printtext = "";
                        }

                        ev.Graphics.DrawString("Reference Standards Used:", heading, Brushes.Black, 55, 500);
                        if (!dr.IsDBNull(11))
                        {
                            if (dr.GetString(11).Length > 80)
                            {
                                /*  no reference standards greater than 169 characters for step heights    */
                                printtext = dr.GetString(11).Substring(0, 80);
                                int lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 245, 500);
                                printtext = dr.GetString(11).Substring(lastword + 1, dr.GetString(11).Length - (lastword + 1));
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, 520);
                            }
                            else
                            {
                                printtext = dr.GetString(11);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 245, 500);
                            }
                            int L = printtext.Length;

                        }
                        else
                        {
                            printtext = "";
                        }

                        ev.Graphics.DrawString("Calibrated Reference Surface Figure Error and Uncertainty:", heading, Brushes.Black, 55, 558);
                        if (!dr.IsDBNull(9)) { printtext = dr.GetString(9); } else { printtext = ""; }
                        //ev.Graphics.DrawString(printtext, arial, Brushes.Black, 325, 560);±

                        if (!dr.IsDBNull(9))
                        {
                            printtext = dr.GetString(9);

                            /* Nate wants the text split so that it starts out after the heading   */

                            int lastword = 0;
                            int startpoint = 0;
                            int printFlag = 0;
                            int remaining = 0;

                            remaining = printtext.Length;

                            if (remaining < 51)
                            {
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 450, 560);
                            }
                            else
                            {
                                if (remaining > 50)
                                {
                                    printtext = dr.GetString(9).Substring(startpoint, 50);
                                    lastword = printtext.LastIndexOf(" ");
                                    printtext = printtext.Substring(0, lastword);
                                    remaining = remaining - lastword;
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 450, 560);
                                }
                                /*  next segment if a lot of text  */
                                if (remaining > 125)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(9).Substring(startpoint, 125);
                                    lastword = printtext.LastIndexOf(" ");
                                    printtext = printtext.Substring(0, lastword);
                                    remaining = remaining - lastword;
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 590);
                                    printFlag = 1;
                                }
                                //    /*  second full line  */

                                //    if (remaining > 125)
                                //    {
                                //        //startpoint = startpoint + lastword + 1;
                                //        //printtext = dr.GetString(9).Substring(startpoint, 105);
                                //        //lastword = printtext.LastIndexOf(" ");
                                //        //printtext = printtext.Substring(0, lastword);
                                //        //ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 605);
                                //        //printFlag = 2;
                                //    }

                                //    if (remaining < 105 & printFlag == 1)
                                //    {
                                //        printFlag = 2;
                                //    }

                                if (printFlag == 0)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(9).Substring(startpoint, dr.GetString(9).Length - startpoint);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 575);
                                }

                                //    if (printFlag == 1)
                                //    {
                                //        startpoint = startpoint + lastword + 1;
                                //        printtext = dr.GetString(9).Substring(startpoint, dr.GetString(9).Length - startpoint);
                                //        ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 590);
                                //    }

                                //    if (printFlag == 2)
                                //    {
                                //        startpoint = startpoint + lastword + 1;
                                //        printtext = dr.GetString(9).Substring(startpoint, dr.GetString(9).Length - startpoint);
                                //        ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 605);
                                //    }

                                //    //if (printFlag == 3)
                                //    //{
                                //    //    startpoint = startpoint + lastword + 1;
                                //    //    printtext = dr.GetString(14).Substring(startpoint, dr.GetString(9).Length - startpoint);
                                //    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 650);
                                //}
                            }
                        }


                        //if (dr.GetString(9).Length > 80)
                        //{
                        //    /*  no data greater than 212 characters for step heights    */
                        //    printtext = dr.GetString(9).Substring(0, 80);
                        //    int lastword = printtext.LastIndexOf(" ");
                        //    printtext = printtext.Substring(0, lastword);
                        //    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 325, 560);
                        //    printtext = dr.GetString(9).Substring(lastword + 1, dr.GetString(9).Length - (lastword + 1));
                        //    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, 575);
                        //}
                        //else
                        //{
                        //    printtext = dr.GetString(9);
                        //    ev.Graphics.DrawString(printtext, arial, Brushes.Black, 245, 470);
                        //}
                        //int L = printtext.Length;

                        ev.Graphics.DrawString("Other Pertinent Information:", heading, Brushes.Black, 55, 623);

                        if (!dr.IsDBNull(14))
                        {
                            printtext = dr.GetString(14);

                            /* the most text here is 506 characters so one line of 80 and four of 105 should do it - we lose 5 characters    */

                            int lastword = 0;
                            int startpoint = 0;
                            int printFlag = 0;

                            if (dr.GetString(14).Length < 81)
                            {
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 252, 625);
                            }
                            else
                            {
                                if (dr.GetString(14).Length > 80)
                                {
                                    printtext = dr.GetString(14).Substring(startpoint, 80);
                                    lastword = printtext.LastIndexOf(" ");
                                    printtext = printtext.Substring(0, lastword);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 250, 625);
                                }
                                /*  first full line  */
                                if (dr.GetString(14).Length > 186)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(14).Substring(startpoint, 105);
                                    lastword = printtext.LastIndexOf(" ");
                                    printtext = printtext.Substring(0, lastword);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 645);
                                    printFlag = 1;
                                }
                                /*  second full line  */

                                if (dr.GetString(14).Length > 291)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(14).Substring(startpoint, 105);
                                    lastword = printtext.LastIndexOf(" ");
                                    printtext = printtext.Substring(0, lastword);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 660);
                                    printFlag = 2;
                                }

                                /*  third full line  */

                                if (dr.GetString(14).Length > 396)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(14).Substring(startpoint, 105);
                                    lastword = printtext.LastIndexOf(" ");
                                    printtext = printtext.Substring(0, lastword);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 675);
                                    printFlag = 3;
                                }
                                /*  fourth full line  */

                                if (dr.GetString(14).Length > 501)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(14).Substring(startpoint, 115);
                                    lastword = printtext.LastIndexOf(" ");
                                    printtext = printtext.Substring(0, lastword);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 690);
                                }

                                if (printFlag == 0)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(14).Substring(startpoint, dr.GetString(14).Length - startpoint);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 645);
                                }

                                if (printFlag == 1)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(14).Substring(startpoint, dr.GetString(14).Length - startpoint);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 660);
                                }

                                if (printFlag == 2)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(14).Substring(startpoint, dr.GetString(14).Length - startpoint);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 675);
                                }

                                if (printFlag == 3)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(14).Substring(startpoint, dr.GetString(14).Length - startpoint);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 690);
                                }
                            }
                        }

                        ev.Graphics.DrawString("Notes:", heading, Brushes.Black, 55, 700);
                        ev.Graphics.DrawString("- Calibration is ISO-17025:2017 accredited per A2LA Certificate #5312.01.", smallarial, Brushes.Black, 55, 725);
                        ev.Graphics.DrawString("- Interferometric instrument calibration based on wavelength, traceable by direct realization of the meter via the 0.632991 μm HeNe laser emission, ", smallarial, Brushes.Black, 55, 740);
                        ev.Graphics.DrawString("  in compliance with ASME B89.7.5:2006 and ISO 17025:2017.", smallarial, Brushes.Black, 55, 755);
                        ev.Graphics.DrawString("- PVr figure error calculated per ISO-14999-4:2015", smallarial, Brushes.Black, 55, 770);
                        ev.Graphics.DrawString("- Results and certification apply only to part identified by serial number, listed in this report.", smallarial, Brushes.Black, 55, 785);

                        Image iii = Properties.Resources.Z_Lab;
                        ev.Graphics.DrawImage(iii, 30, 840, iii.Width - 840, iii.Height - 840);

                        //Image iv = Properties.Resources.A2LA_accredited_symbol_5312_01_01;
                        //ev.Graphics.DrawImage(iv, 600, 850, iv.Width - 640, iv.Height - 540);


                        ev.Graphics.DrawString("Signed:_______________________________", heading, Brushes.Black, 250, 850);
                        ev.Graphics.DrawString("Name:", heading, Brushes.Black, 250, 880);
                        if (!dr.IsDBNull(15)) { printtext = dr.GetString(15); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 310, 882);

                        ev.Graphics.DrawString("Title:", heading, Brushes.Black, 250, 910);
                        if (!dr.IsDBNull(16)) { printtext = dr.GetString(16); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 310, 912);

                        ev.Graphics.DrawString("Date:", heading, Brushes.Black, 250, 940);
                        if (!dr.IsDBNull(19)) { printtext = dr.GetDateTime(19).ToString("MM/dd/yyyy"); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 310, 942);


                        ev.Graphics.DrawString("Zygo Corporation - Laurel Brook Road - Middlefield CT 06455", smallarial, Brushes.Black, 210, 970);
                        ev.Graphics.DrawString("Telephone 860-347-8506  Main Corporate Fax 860-347-8372", smallarial, Brushes.Black, 210, 990);

                        //if (!dr.IsDBNull(23)) { printtext = dr.GetString(21); } else { printtext = ""; }
                        //ev.Graphics.DrawString(printtext, smallarial, Brushes.Black, 100, 990);

                        ev.Graphics.DrawString("Zygo grants our customers approval to reproduce test reports, only if reported in full, for use in demonstrating", smallarial, Brushes.Black, 120, 1010);
                        ev.Graphics.DrawString("the traceability of the measurements of the serial numbered item listed in this report.", smallarial, Brushes.Black, 180, 1025);

                        ev.Graphics.DrawString("Form 0281-04B", smallarial, Brushes.Black, 80, 1050);

                        //ev.Graphics.DrawString("X             X", smallarial, Brushes.Black, 340, 950);
                        ev.Graphics.DrawString("Certification Number:", smallarial, Brushes.Black, 340, 1050);
                        ev.Graphics.DrawString(dr.GetInt32(0).ToString(), smallarial, Brushes.Black, 450, 1050);
                        ev.Graphics.DrawString("Page 1 of 2", smallarial, Brushes.Black, 700, 1050);

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
            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT testimage FROM " + g.dbImage + " WHERE CertificationNumber = " + g.certificationNumber + "", cnxn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                byte[] imageBytes = (byte[])dt.Rows[0][0];

                MemoryStream ms = new MemoryStream(imageBytes);
                Image i2 = Image.FromStream(ms, true, false);


                //Image i2 = Image.FromFile("C:\\A\\png_test.png");
                /*  Nate Austin email 03-19-20 Rotate 270 and fix cropping  */
                i2.RotateFlip(RotateFlipType.Rotate270FlipNone);
                //i2.RotateFlip(RotateFlipType.Rotate90FlipNone);

                Rectangle m = ev.MarginBounds;

                if ((double)i2.Width / (double)i2.Height > (double)m.Width / (double)m.Height) // image is wider
                {
                    m.Height = (int)((double)i2.Height / (double)i2.Width * (double)m.Width);
                }
                else
                {
                    m.Width = (int)((double)i2.Width / (double)i2.Height * (double)m.Height);
                }

                //ev.Graphics.DrawImage(i2, m);

                Rectangle destRect = new Rectangle(50, 50, 750, 1000);
                //Rectangle destRect = new Rectangle(20, 50, 675, 900);

                //RectangleF sourceRect = new RectangleF(0, 0, 650, 900);
                //ev.Graphics.DrawImageUnscaledAndClipped(i2, destRect);
                //ev.Graphics.DrawImageUnscaled(i2, 35, 20);
                //ev.Graphics.DrawImage(i2, m);
                ev.Graphics.DrawImage(i2, destRect);

                ev.Graphics.DrawString("Certification Number " + g.certificationNumber, arial, Brushes.Black, 50, 1055);
                ev.Graphics.DrawString("Page 2 of 2", arial, Brushes.Black, 650, 1055);
                page2printed = true;
            }

            if (page1printed && !page2printed)
            {
                ev.HasMorePages = true;
            }
            else
            {
                ev.HasMorePages = false;
            }

            this.Close();
        }


    }
}
