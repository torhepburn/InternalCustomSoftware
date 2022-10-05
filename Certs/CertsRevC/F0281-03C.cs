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


namespace CertsRevC
{
    public partial class F0281_03C : Form
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

        public F0281_03C()
        {
            InitializeComponent();
        }

        private void F0281_03C_Load(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = false;
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            pd.DefaultPageSettings.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            pd.Print();

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
                    " ,REPLACE([Certified Results],'Calibrated Step Height','') + ' ' + COALESCE([Uncertainty],'') " +
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
                    " FROM cc_CofC WHERE [certification #] = '" + g.certificationNumber + "'"
                    , cnxn);

                /*   6246 long other texts   100 test company  */


                cnxn.Open();

                try
                {

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
                        ev.Graphics.DrawImage(ii, 598, 60, ii.Width - 350, ii.Height -70);

                        ev.Graphics.DrawString("Z-LAB", title, Brushes.Black, 350, 50);
                        ev.Graphics.DrawString("_____", title, Brushes.Black, 350, 60);

                        ev.Graphics.DrawString("Certificate of Calibration", title, Brushes.Black, 200, 120);
                        ev.Graphics.DrawString("Certification #:", topheading, Brushes.Black, 300, 170);
                        ev.Graphics.DrawString(dr.GetInt32(0).ToString(), topheading, Brushes.Black, 420, 170);


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


                        ev.Graphics.DrawString("Calibration Procedure:", heading, Brushes.Black, 55, 380);
                        if (!dr.IsDBNull(4)) { printtext = dr.GetString(4); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 215, 380);


                        ev.Graphics.DrawString("Type of Test Performed:", heading, Brushes.Black, 55, 410);

                        if (!dr.IsDBNull(10))
                        {
                            if (dr.GetString(10).Length > 80)
                            {
                                printtext = dr.GetString(10).Substring(0, 80);
                                int lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 225, 410);
                                printtext = dr.GetString(10).Substring(lastword + 1, dr.GetString(10).Length - (lastword + 1));
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, 430);
                            }
                            else
                            {
                                printtext = dr.GetString(10);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 225, 410);
                            }
                            int L = printtext.Length;
                        }
                        else
                        {
                            printtext = "";
                        }

                        ev.Graphics.DrawString("Reference Standards Used:", heading, Brushes.Black, 55, 470);
                        if (!dr.IsDBNull(11))
                        {
                            if (dr.GetString(11).Length > 80)
                            {
                                /*  no reference standards greater than 169 characters for step heights    */
                                printtext = dr.GetString(11).Substring(0, 80);
                                int lastword = printtext.LastIndexOf(" ");
                                printtext = printtext.Substring(0, lastword);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 245, 470);
                                printtext = dr.GetString(11).Substring(lastword + 1, dr.GetString(11).Length - (lastword + 1));
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, 490);
                            }
                            else
                            {
                                printtext = dr.GetString(11);
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 245, 470);
                            }
                            int L = printtext.Length;

                        }
                        else
                        {
                            printtext = "";
                        }

                        ev.Graphics.DrawString("Calibrated Step Height and Uncertainty:", heading, Brushes.Black, 55, 558);
                        if (!dr.IsDBNull(9)) { printtext = dr.GetString(9); } else { printtext = ""; }
                        //ev.Graphics.DrawString(printtext, arial, Brushes.Black, 325, 560);

                        if (!dr.IsDBNull(9))
                        {
                            printtext = dr.GetString(9);

                            /* the most text here is 212 characters so one line of 80 and two of 105 should do it  */

                            int lastword = 0;
                            int startpoint = 0;
                            int printFlag = 0;
                            int remaining = 0;

                            remaining = printtext.Length;

                            if (remaining < 81)
                            {
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 325, 560);
                            }
                            else
                            {
                                if (remaining > 85)
                                {
                                    printtext = dr.GetString(9).Substring(startpoint, 85);
                                    lastword = printtext.LastIndexOf(" ");
                                    printtext = printtext.Substring(0, lastword);
                                    remaining = remaining - lastword;
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 327, 560);
                                }
                                /*  first full line  */
                                if (remaining > 125)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(9).Substring(startpoint, 125);
                                    lastword = printtext.LastIndexOf(" ");
                                    printtext = printtext.Substring(0, lastword);
                                    remaining = remaining - lastword;
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 575);
                                    printFlag = 1;
                                }
                                /*  second full line  */

                                if (remaining > 125)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(9).Substring(startpoint, 105);
                                    lastword = printtext.LastIndexOf(" ");
                                    printtext = printtext.Substring(0, lastword);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 590);
                                    printFlag = 2;
                                }

                                if (remaining < 105 & printFlag == 1)
                                {
                                    printFlag = 2;
                                }

                                if (printFlag == 0)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(9).Substring(startpoint, dr.GetString(9).Length - startpoint);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 575);
                                }
                                
                                if (printFlag == 1)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(9).Substring(startpoint, dr.GetString(9).Length - startpoint);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 575);
                                }

                                if (printFlag == 2)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(9).Substring(startpoint, dr.GetString(9).Length - startpoint);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 590);
                                }

                                //if (printFlag == 3)
                                //{
                                //    startpoint = startpoint + lastword + 1;
                                //    printtext = dr.GetString(14).Substring(startpoint, dr.GetString(9).Length - startpoint);
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

                        ev.Graphics.DrawString("Other Pertinent Information:", heading, Brushes.Black, 55, 608);

                        if (!dr.IsDBNull(14))
                        {
                            printtext = dr.GetString(14);

                            /* the most text here is 506 characters so one line of 80 and four of 105 should do it - we lose 5 characters    */

                            int lastword = 0;
                            int startpoint = 0;
                            int printFlag = 0;

                            if (dr.GetString(14).Length < 81)
                            {
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 252, 610);
                            }
                            else
                            {
                                if (dr.GetString(14).Length > 80)
                                {
                                    printtext = dr.GetString(14).Substring(startpoint, 80);
                                    lastword = printtext.LastIndexOf(" ");
                                    printtext = printtext.Substring(0, lastword);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 250, 610);
                                }
                                /*  first full line  */
                                if (dr.GetString(14).Length > 186)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(14).Substring(startpoint, 105);
                                    lastword = printtext.LastIndexOf(" ");
                                    printtext = printtext.Substring(0, lastword);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 630);
                                    printFlag = 1;
                                }
                                /*  second full line  */

                                if (dr.GetString(14).Length > 291)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(14).Substring(startpoint, 105);
                                    lastword = printtext.LastIndexOf(" ");
                                    printtext = printtext.Substring(0, lastword);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 645);
                                    printFlag = 2;
                                }

                                /*  third full line  */

                                if (dr.GetString(14).Length > 396)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(14).Substring(startpoint, 105);
                                    lastword = printtext.LastIndexOf(" ");
                                    printtext = printtext.Substring(0, lastword);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 660);
                                    printFlag = 3;
                                }
                                /*  fourth full line  */

                                if (dr.GetString(14).Length > 501)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(14).Substring(startpoint, 115);
                                    lastword = printtext.LastIndexOf(" ");
                                    printtext = printtext.Substring(0, lastword);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 675);
                                }

                                if (printFlag == 0)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(14).Substring(startpoint, dr.GetString(14).Length - startpoint);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 630);
                                }

                                if (printFlag == 1)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(14).Substring(startpoint, dr.GetString(14).Length - startpoint);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 645);
                                }

                                if (printFlag == 2)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(14).Substring(startpoint, dr.GetString(14).Length - startpoint);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 660);
                                }

                                if (printFlag == 3)
                                {
                                    startpoint = startpoint + lastword + 1;
                                    printtext = dr.GetString(14).Substring(startpoint, dr.GetString(14).Length - startpoint);
                                    ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 55, 670);
                                }
                            }
                        }

                        ev.Graphics.DrawString("Notes:", heading, Brushes.Black, 55, 680);
                        ev.Graphics.DrawString("- Calibration is ISO-17025 (2017) accredited per A2LA Certificate #5312.01.", smallarial, Brushes.Black, 55, 700);
                        ev.Graphics.DrawString("- Expanded uncertainty (k=2, 95% confidence interval) calculated as the Root Sum Squared of 0.003 μm measurement floor and", smallarial, Brushes.Black, 55, 715);
                        ev.Graphics.DrawString("  0.3% of the reading. i.e. U = √[(0.3%)² + (0.003 μm)²].", smallarial, Brushes.Black, 55, 730);
                        ev.Graphics.DrawString("- Interferometric instrument calibration based on wavelength, traceable by direct realization of the meter via the 0.546074 μm 198Hg emission, ", smallarial, Brushes.Black, 55, 745);
                        ev.Graphics.DrawString("  in compliance with ASME B89.7.5 (2006) and ISO 17025 (2017).", smallarial, Brushes.Black, 55, 760);
                        ev.Graphics.DrawString("- Instrument calibration verified to <0.1% using a 14.5 μm step height standard, certified by the UK National Physical Laboratory (NPL)", smallarial, Brushes.Black, 55, 775);
                        ev.Graphics.DrawString("  to 2nm (k=2), NPL certificate number 12085-49-07 (ZOP0080), dated June 17, 2015.", smallarial, Brushes.Black, 55, 790);
                        ev.Graphics.DrawString("- Step heights calculated according to ASME B46.1.2009 and JCGM 100:2008.", smallarial, Brushes.Black, 55, 805);
                        ev.Graphics.DrawString("- Results and certification apply only to part identified by serial number, listed in this report.", smallarial, Brushes.Black, 55, 820);

                        Image iii = Properties.Resources.Z_Lab;
                        ev.Graphics.DrawImage(iii, 30, 840, iii.Width - 840, iii.Height - 840);

                        Image iv = Properties.Resources.A2LA_accredited_symbol_5312_01_01;
                        ev.Graphics.DrawImage(iv, 600, 850, iv.Width - 640, iv.Height - 540);


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

                        ev.Graphics.DrawString("Form 0281-03c", smallarial, Brushes.Black, 80, 1050);

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
                //byte[] imageBytes = new byte[1000000];
                //Image i2 = Image.FromFile("C:\\A\\png_test.png");
                try
                {/*
                    SqlDataAdapter da = new SqlDataAdapter("SELECT testimage FROM cc_Image WHERE CertificationNumber = " + g.certificationNumber + "", cnxn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    byte[] imageBytes = (byte[])dt.Rows[0][0];

                    //string writefile = @"C:\A\image2.png";

                    //FileStream fs = new FileStream(writefile, FileMode.Create, FileAccess.ReadWrite);
                    //BinaryWriter bw = new BinaryWriter(fs);
                    //bw.Write(imageBytes);
                    //bw.Close();

                    MemoryStream ms = new MemoryStream(imageBytes);
                    Image i3 = Image.FromStream(ms, true, false);

                    //int c = imageBytes.Length;
                    //cmd = new SqlCommand(
                    //"SELECT testimage FROM cc_Image WHERE CertificationNumber = " + g.certificationNumber + "", cnxn);
                    //cnxn.Open();
                    //SqlDataReader dr = cmd.ExecuteReader();
                    //imageBytes = (byte[])dr[0];
*/
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }


                SqlDataAdapter da = new SqlDataAdapter("SELECT testimage FROM cc_Image WHERE CertificationNumber = " + g.certificationNumber + "", cnxn);
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
