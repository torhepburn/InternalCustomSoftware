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

namespace ImagePrint
{
    public partial class Form1 : Form
    {
        SqlCommand cmd;
        SqlConnection cnxn;
        SqlDataReader dr;

        private string db = "server = CT-MID-SQL01; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";
        private string printtext = string.Empty;
        private string longString = string.Empty;
        private int repeat = 30;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = false;
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            //pd.DefaultPageSettings.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            (ppd as Form).WindowState = FormWindowState.Maximized;
            ppd.ShowDialog();
            //Close();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Font arial = new Font("arial", 11, FontStyle.Regular);
            Font smallarial = new Font("arial", 8, FontStyle.Regular);
            Font title = new Font("arial", 18, FontStyle.Bold);
            Font heading = new Font("arial", 12, FontStyle.Bold);
            Font leaders = new Font("arial", 9, FontStyle.Bold);
            Pen pen = new Pen(Color.Black);

            //Image i = Properties.Resources.zygo_logo_smpt3;
            //ev.Graphics.DrawImage(i, 40, 50, i.Width - 70, i.Height - 15);
            //Image ii = Properties.Resources.AME080_RGB28;
            //ev.Graphics.DrawImage(ii, 680, 65, ii.Width - 25, ii.Height - 5);


            //ev.Graphics.DrawString("Zygo Corporation", smallarial, Brushes.Black, 40, 82);
            //ev.Graphics.DrawString("21 Laurel Brook Road", smallarial, Brushes.Black, 40, 97);
            //ev.Graphics.DrawString("Middlefield CT 06455 USA", smallarial, Brushes.Black, 40, 112);
            //ev.Graphics.DrawString("Voice: 860-347-8506", smallarial, Brushes.Black, 40, 127);


            //ev.Graphics.DrawString("Sales - Order Acknowledgement", title, Brushes.Black, 220, 80 + repeat);

            repeat = repeat + 30; ;

            if (repeat < 120)
            {
                ev.HasMorePages = true;
                //pagesPrinted++;
            }
            else
            {
                ev.HasMorePages = false;
                //linedrop = 160;
                //count = 0;
                //pagesPrinted = 0;
                //lineNo = 0;
            }


            /*
            ev.Graphics.DrawLine(pen, 30, 980, 800, 980);

            ev.Graphics.DrawString("Zygo Corporation", smallarial, Brushes.Black, 40, 1000);
            ev.Graphics.DrawString("21 Laurel Brook Road", smallarial, Brushes.Black, 40, 1015);
            ev.Graphics.DrawString("Middlefield CT 06455 USA", smallarial, Brushes.Black, 40, 1030);
            ev.Graphics.DrawString("Voice: 860-347-8506", smallarial, Brushes.Black, 40, 1045);
            */
            

                        cnxn = new SqlConnection(db);

                                    cmd = new SqlCommand
                                        ("SELECT  " +
                                         " [Certification #] " +
                                        " ,[Customer Name] " +
                                        " ,[Customer Address] " +
                                        " ,[Customer PO #] " +
                                        " ,[Test Date2] " +
                                        " ,[Calibration Procedure] " +
                                        " ,[Desc] " +
                                        " ,[P/N] " +
                                        " ,Quantity " +
                                        " ,[Serial #] " +
                                        " ,[Certified Results] " +
                                        " ,[Type of Test Performed] " +
                                        " ,[Reference Standards Used] " +
                                        " ,Temperature " +
                                        " ,RelativeHumidity " +
                                        " ,[Other Pertinent Information] " +
                                        " ,[Other Pertinent Information 2] " +
                                        " ,Name " +
                                        " ,Title " +
                                        " ,Type " +
                                        " ,[Next Calibration Due] " +
                                        " ,[Written By] " +
                                        " ,[Test Date] " +
                                        " ,Date " +
                                        " FROM cc_CofC WHERE [certification #] = 106851"
                                        , cnxn);

                        //cmd = new SqlCommand();
                        //cmd.CommandText = "spCalCert1";
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Connection = cnxn;

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

                    //Image i = Properties.Resources.zygo_logo_smpt3;
                    //ev.Graphics.DrawImage(i, 40, 50, i.Width - 70, i.Height - 15);
                    //Image ii = Properties.Resources.AME080_RGB28;
                    //ev.Graphics.DrawImage(ii, 700, 65, ii.Width - 25, ii.Height - 5);

                    //ev.Graphics.DrawString("Sales - Order Acknowledgement", title, Brushes.Black, 210, 70);


                    Image i = Properties.Resources.zygo_logo_smpt3;
                    ev.Graphics.DrawImage(i, 90, 50, i.Width, i.Height);
                    Image ii = Properties.Resources.AME080_RGB28;
                    ev.Graphics.DrawImage(ii, 598, 65, ii.Width, ii.Height);


                    ev.Graphics.DrawString("Certification of Calibration", title, Brushes.Black, 210, 120);
                        ev.Graphics.DrawString("Certification #:", heading, Brushes.Black, 500, 170);
                                ev.Graphics.DrawString(dr.GetInt32(0).ToString(), arial, Brushes.Black, 625, 172);

                                ev.Graphics.DrawString("Customer Name:", heading, Brushes.Black, 80, 200);
                                ev.Graphics.DrawString(dr.GetString(1), arial, Brushes.Black, 220, 202);

                                ev.Graphics.DrawString("Desc:", heading, Brushes.Black, 500, 200);
                                ev.Graphics.DrawString(dr.GetString(6), arial, Brushes.Black, 550, 202);

                                ev.Graphics.DrawString("Customer Address:", heading, Brushes.Black, 80, 230);
                                if (!dr.IsDBNull(2)) { printtext = dr.GetString(2); } else { printtext = ""; }
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 240, 232);

                                ev.Graphics.DrawString("Customer PO Number:", heading, Brushes.Black, 80, 260);
                                if (!dr.IsDBNull(3)) { printtext = dr.GetString(3); } else { printtext = ""; }
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 265, 262);

                                ev.Graphics.DrawString("P/N:", heading, Brushes.Black, 500, 260);
                                if (!dr.IsDBNull(7)) { printtext = dr.GetString(7); } else { printtext = ""; }
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 540, 261);

                                ev.Graphics.DrawString("Test Date:", heading, Brushes.Black, 80, 290);
                                if (!dr.IsDBNull(22)) { printtext = dr.GetDateTime(22).ToString("MM/dd/yyyy"); } else { printtext = ""; }
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 165, 292);


                                ev.Graphics.DrawString("Serial Number:", heading, Brushes.Black, 500, 290);
                                if (!dr.IsDBNull(9)) { printtext = dr.GetString(9); } else { printtext = ""; }
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 625, 291);

                                ev.Graphics.DrawString("Calibration Procedure:", heading, Brushes.Black, 80, 320);
                                if (!dr.IsDBNull(5)) { printtext = dr.GetString(5); } else { printtext = ""; }
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 265, 322);


                                ev.Graphics.DrawString("Certified Results:", heading, Brushes.Black, 80, 350);
                                //can be three lines of data
                                //word wrap Element
                                //if (!dr.IsDBNull(3))
                                //{
                                //    if (dr.GetString(3).Length > 20)
                                //    {
                                //        int lastword = dr.GetString(3).Substring(0, 20).LastIndexOf(" ");
                                //        //elementname[i] = dr.GetString(3).Substring(0, lastword);
                                //        //elementWrap[i] = dr.GetString(3).Substring(lastword + 1, dr.GetString(3).Length - (lastword + 1));
                                //    }
                                //    else
                                //    {
                                //        //elementname[i] = dr.GetString(3).Trim();
                                //        //elementWrap[i] = "N";
                                //    }
                                //}
                                if (!dr.IsDBNull(10)) { printtext = dr.GetString(10); } else { printtext = ""; }

                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 230, 352);

                                ev.Graphics.DrawString("Next Calibration Due:", heading, Brushes.Black, 80, 410);
                                if (!dr.IsDBNull(20)) { printtext = dr.GetString(20); } else { printtext = ""; }
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 260, 412);


                                ev.Graphics.DrawString("Type of Test Performed:", heading, Brushes.Black, 80, 440);
                                if (!dr.IsDBNull(11)) { printtext = dr.GetString(11); } else { printtext = ""; }
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 280, 442);

                                ev.Graphics.DrawString("Reference Standards Used:", heading, Brushes.Black, 80, 500);
                                if (!dr.IsDBNull(12)) { printtext = dr.GetString(12); } else { printtext = ""; }
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 300, 501);


                                ev.Graphics.DrawString("Test Conditions - Temperature (C):", heading, Brushes.Black, 80, 530);
                                if (!dr.IsDBNull(13)) { printtext = dr.GetString(13); } else { printtext = ""; }
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 365, 532);

                                ev.Graphics.DrawString("Relative Humidity (%):", heading, Brushes.Black, 420, 530);
                                if (!dr.IsDBNull(14)) { printtext = dr.GetString(14); } else { printtext = ""; }
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 605, 532);

                                ev.Graphics.DrawString("Other Pertinent Information:", heading, Brushes.Black, 80, 560);
                                if (!dr.IsDBNull(15)) { printtext = dr.GetString(15); } else { printtext = ""; }
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 315, 562);

                                ev.Graphics.DrawString("Calibration measurements comply with ANSI/NCSL Z540-1,ISO 10012-1 traceable", heading, Brushes.Black, 80, 750);
                                ev.Graphics.DrawString("to NIST.  Interferometers or references used for this test have been calibrated per an", heading, Brushes.Black, 80, 770);
                                ev.Graphics.DrawString("absolute method appropriate for hte specific configuration and alignment necessary", heading, Brushes.Black, 80, 790);
                                ev.Graphics.DrawString("for this item.", heading, Brushes.Black, 80, 810);

                                Image iii = Properties.Resources.Precision_Measurements_Seal;
                                //ev.Graphics.DrawImage(iii, 80, 840, iii.Width-235, iii.Height-250); for quality seal
                                ev.Graphics.DrawImage(iii, 80, 840, iii.Width-20, iii.Height-20);

                                ev.Graphics.DrawString("Signed:_______________________________", heading, Brushes.Black, 400, 850);
                                ev.Graphics.DrawString("Name:", heading, Brushes.Black, 400, 880);
                                if (!dr.IsDBNull(17)) { printtext = dr.GetString(17); } else { printtext = ""; }
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 460, 882);

                                ev.Graphics.DrawString("Title:", heading, Brushes.Black, 400, 910);
                                if (!dr.IsDBNull(18)) { printtext = dr.GetString(18); } else { printtext = ""; }
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 460, 912);

                                ev.Graphics.DrawString("Date:", heading, Brushes.Black, 400, 940);
                                if (!dr.IsDBNull(23)) { printtext = dr.GetDateTime(23).ToString("MM/dd/yyyy"); } else { printtext = ""; }
                                ev.Graphics.DrawString(printtext, arial, Brushes.Black, 460, 942);


                                ev.Graphics.DrawString("Zygo Corporation - Laurel Brook Road - Middlefield CT 06455", smallarial, Brushes.Black, 210, 970);
                                ev.Graphics.DrawString("Telephone 860-347-8506  Main Corporate Fax 860-347-8372", smallarial, Brushes.Black, 210, 990);

                                if (!dr.IsDBNull(23)) { printtext = dr.GetString(21); } else { printtext = ""; }
                                ev.Graphics.DrawString(printtext, smallarial, Brushes.Black, 100, 990);

                                ev.Graphics.DrawString("Zygo grants our customer's approval to reproduce test reports for use in demonstrating the tracesablity of the measurements.", smallarial, Brushes.Black, 120, 1010);

                                ev.Graphics.DrawString("0281-09-99", smallarial, Brushes.Black, 80, 1050);





                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                        cnxn.Close();
                        


        }
    }
}
