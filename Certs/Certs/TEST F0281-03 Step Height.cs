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
    public partial class F0281_03_Step_Height : Form
    {
        SqlCommand cmd;
        SqlConnection cnxn;
        SqlDataReader dr;

        private string db = "server = CT-MID-SQL01; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";
        private string printtext = string.Empty;
        private string longString = string.Empty;
        private bool page1printed = false;
        private bool page2printed = false;


        public F0281_03_Step_Height()
        {
            InitializeComponent();
        }

        private void F0281_03_Step_Height_Load(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = false;
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            pd.DefaultPageSettings.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            pd.Print();
            /*
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            (ppd as Form).WindowState = FormWindowState.Maximized;
            ppd.ShowDialog();
            */
            //PrintDocument pd2 = new PrintDocument();
            //pd2.DefaultPageSettings.Landscape = true;
            //pd2.PrintPage += new PrintPageEventHandler(pd2_PrintPage);

            //PrintPreviewDialog ppd2 = new PrintPreviewDialog();
            //ppd2.Document = pd2;
            //(ppd2 as Form).WindowState = FormWindowState.Maximized;
            //ppd2.ShowDialog();

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
                    " FROM " + g.dbTable + " WHERE [certification #] = '" + g.certificationNumber + "'"
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
                        Image i = Properties.Resources.zygo_logo_smpt3;
                        ev.Graphics.DrawImage(i, 65, 50, i.Width, i.Height);
                        Image ii = Properties.Resources.AME080_RGB28;
                        ev.Graphics.DrawImage(ii, 598, 65, ii.Width, ii.Height);

                        ev.Graphics.DrawString("Z-LAB", title, Brushes.Black, 350, 50);
                        ev.Graphics.DrawString("_____", title, Brushes.Black, 350, 60);

                        ev.Graphics.DrawString("Certification of Calibration", title, Brushes.Black, 200, 120);
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
                        else { printtext = ""; }

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
                        else { printtext = ""; }
                        //ev.Graphics.DrawString(printtext, arial, Brushes.Black, 245, 470);
                        //ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, 485);
                        //ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, 500);
                        //ev.Graphics.DrawString(printtext, arial, Brushes.Black, 55, 515);

                        ev.Graphics.DrawString("Calibrated Step Height and Uncertainty:", heading, Brushes.Black, 55, 560);
                        if (!dr.IsDBNull(9)) { printtext = dr.GetString(9); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 325, 560);


                        ev.Graphics.DrawString("Other Pertinent Information:", heading, Brushes.Black, 55, 610);

                        if (!dr.IsDBNull(14))
                        {
                            printtext = dr.GetString(14);

                            /* the most text here is 506 characters so one line of 80 and four of 105 should do it - we lose 5 characters    */

                            int lastword = 0;
                            int startpoint = 0;
                            int printFlag = 0;

                            if (dr.GetString(14).Length < 81)
                            {
                                ev.Graphics.DrawString(printtext, leaders, Brushes.Black, 325, 610);
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

                        ev.Graphics.DrawString("Notes:", heading, Brushes.Black, 55, 695);
                        ev.Graphics.DrawString("- Expanded (k=2) uncertainty calculated as the larger of 0.3% or 0.006 micron for thick step height standards (with steps > 1 micron), and the", smallarial, Brushes.Black, 55, 715);
                        ev.Graphics.DrawString("  larger of 0.3% or 0.003 micron for thin step height standards (with steps < 1 micron) expressed in microns.", smallarial, Brushes.Black, 55, 730);
                        ev.Graphics.DrawString("- Interferometric instrument calibration based on wavelength, traceable to the meter via the 0.546074 micron 198Hg emission, ", smallarial, Brushes.Black, 55, 745);
                        ev.Graphics.DrawString("  in compliance with ASME B89.7.5 (2006) and ISO 17025 (2005).", smallarial, Brushes.Black, 55, 760);
                        ev.Graphics.DrawString("- Instrument calibration verified to <0.1% using a 14.5 micron step height standard, certified by the UK National Physical Laboratory (NPL)", smallarial, Brushes.Black, 55, 775);
                        ev.Graphics.DrawString("  to 2nm (k=2), NPL certificate number 12085-49-07 (ZOP0080), dated June 17, 2015.", smallarial, Brushes.Black, 55, 790);
                        ev.Graphics.DrawString("- Step heights calculated according to ASME B46.1.2009 and JCGM 100:2008.", smallarial, Brushes.Black, 55, 805);
                        ev.Graphics.DrawString("- Results and certification apply only to part identified by serial number, listed in this report.", smallarial, Brushes.Black, 55, 820);

                        Image iii = Properties.Resources.Precision_Measurements_Seal;
                        //ev.Graphics.DrawImage(iii, 80, 840, iii.Width - 235, iii.Height - 250); for quality seal

                        ev.Graphics.DrawImage(iii, 80, 840, iii.Width - 20, iii.Height - 20);

                        ev.Graphics.DrawString("Signed:_______________________________", heading, Brushes.Black, 400, 850);
                        ev.Graphics.DrawString("Name:", heading, Brushes.Black, 400, 880);
                        if (!dr.IsDBNull(15)) { printtext = dr.GetString(15); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 460, 882);

                        ev.Graphics.DrawString("Title:", heading, Brushes.Black, 400, 910);
                        if (!dr.IsDBNull(16)) { printtext = dr.GetString(16); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 460, 912);

                        ev.Graphics.DrawString("Date:", heading, Brushes.Black, 400, 940);
                        if (!dr.IsDBNull(19)) { printtext = dr.GetDateTime(19).ToString("MM/dd/yyyy"); } else { printtext = ""; }
                        ev.Graphics.DrawString(printtext, arial, Brushes.Black, 460, 942);


                        ev.Graphics.DrawString("Zygo Corporation - Laurel Brook Road - Middlefield CT 06455", smallarial, Brushes.Black, 210, 970);
                        ev.Graphics.DrawString("Telephone 860-347-8506  Main Corporate Fax 860-347-8372", smallarial, Brushes.Black, 210, 990);

                        //if (!dr.IsDBNull(23)) { printtext = dr.GetString(21); } else { printtext = ""; }
                        //ev.Graphics.DrawString(printtext, smallarial, Brushes.Black, 100, 990);

                        ev.Graphics.DrawString("Zygo grants our customer's approval to reproduce test reports, only if reported in full, for use in demonstrating", smallarial, Brushes.Black, 120, 1010);
                        ev.Graphics.DrawString("the tracesablity of the measurements.", smallarial, Brushes.Black, 320, 1025);

                        ev.Graphics.DrawString("Form 0281-03 B", smallarial, Brushes.Black, 80, 1050);

                        ev.Graphics.DrawString("X             X", smallarial, Brushes.Black, 340, 950);
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


                SqlDataAdapter da = new SqlDataAdapter("SELECT testimage FROM " + g.dbImage + " WHERE CertificationNumber = " + g.certificationNumber + "", cnxn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                byte[] imageBytes = (byte[])dt.Rows[0][0];
                                
                MemoryStream ms = new MemoryStream(imageBytes);
                Image i2 = Image.FromStream(ms, true, false);


                //Image i2 = Image.FromFile("C:\\A\\png_test.png");
                //Image.from

                i2.RotateFlip(RotateFlipType.Rotate270FlipNone);

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

                Rectangle destRect = new Rectangle(20, 150, 585, 500);
                //Rectangle destRect = new Rectangle(20, 20, 650, 1000);
                //RectangleF sourceRect = new RectangleF(0, 0, 650, 900);

                ev.Graphics.DrawImageUnscaledAndClipped(i2, destRect);

                ev.Graphics.DrawString("Certification Number " + g.certificationNumber, arial, Brushes.Black, 50, 1050);
                ev.Graphics.DrawString("Page 2 of 2", arial, Brushes.Black, 650, 1050);
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
