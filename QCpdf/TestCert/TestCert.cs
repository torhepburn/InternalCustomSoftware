using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using System.Data.SqlClient;

namespace TestCert
{
    public partial class TestCert : Form
    {
        private string[] fileList;
        private string item;
        private string dateID;
        private string existingCert;
        private string certNumber;
        PdfReader pdfReader;
        private int n = 0;
        private string db = "server=CT-MID-SQL01; user = readWrite; pwd = Read+Write!; database= calibration;";

        public TestCert()
        {
            InitializeComponent();
        }

        private void TestCert_Load(object sender, EventArgs e)
        {
            try
            {
                //fileList = Directory.GetFiles(@"\\zygocorp\departments\quality\calibration", "*.pdf");
                fileList = Directory.GetFiles(@"\\zygocorp\departments\quality\quality\tim kyle\calibration\rcca missing certs\2018 certs", "*.pdf");
                //fileList = Directory.GetFiles(@"\\zygocorp\departments\quality\quality\tim kyle\calibration\rcca missing certs\holts missing", "*.pdf");
                //fileList = Directory.GetFiles(@"\\zygocorp\departments\quality\quality\tim kyle\calibration\rcca missing certs\cal tek missing certs", "*.pdf");
                //fileList = Directory.GetFiles(@"C:\A", "PO_600024.pdf");

                for (int i = 0; i < fileList.Length; i++)
                {


                    try
                    {
                        pdfReader = new PdfReader(fileList[i]);
                        File.AppendAllText(@"C:\A\pdfLog.txt",
                                DateTime.Now.ToString() + i.ToString() + " read file " + fileList[i].ToString() + Environment.NewLine);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(i.ToString() + "  PDFreader  " + ex.ToString());
                    }
                    finally
                    {

                    }

                    for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                    {
                        string currentText = string.Empty;

                        try
                        {
                            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                            currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {

                        }

                        currentText = Encoding.UTF8.GetString
                            (ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));

                        currentText = currentText.ToUpper();

                        if (currentText.LastIndexOf("HOLTS") > -1)
                        {
                            //File.AppendAllText(@"C:\A\HoltsLog.txt",
                            //    DateTime.Now.ToString() + i.ToString() + "  " + fileList[i].ToString() + Environment.NewLine);

                            if (currentText.IndexOf("BRIDGEWATER") > -1 | (currentText.IndexOf("WINDSORx") > -1))
                            {
                                if (currentText.IndexOf("ABRASION") > -1)
                                {
                                    string s1 = currentText.Substring((currentText.IndexOf("GAGE ID") + 8), 20);
                                    item = s1.Substring(0, s1.IndexOf(" "));

                                    string s2 = currentText.Substring((currentText.IndexOf("DATE REVIEWED BY") + 17), 20);
                                    dateID = s2.Substring(0, s2.IndexOf("\n"));

                                    string s3 = currentText.Substring((currentText.IndexOf("CERTIFICATE OF CALIBRATION") + 27), 20);
                                    certNumber = s3.Substring(0, s3.IndexOf("\n"));
                                }
                                else if (currentText.IndexOf("THREAD") > -1)
                                {
                                    if (currentText.IndexOf("BRIDGEWATER") > -1)
                                    {
                                        string s1 = currentText.Substring((currentText.IndexOf("BRIDGEWATER") + 12), 50);
                                        string s2 = s1.Substring(s1.IndexOf("\n") + 1, s1.Length - s1.IndexOf("\n") - 1);
                                        string s3 = s2.Substring(s2.IndexOf("\n") + 1, s2.Length - s2.IndexOf("\n") - 1);
                                        string s4 = s3.Substring(s3.IndexOf("\n") + 1, s3.Length - s3.IndexOf("\n") - 1);
                                        item = s4.Substring(0, s4.IndexOf("\n"));

                                        string d1 = currentText.Substring((currentText.LastIndexOf("CALIBRATION DATE") + 17), 100);
                                        string d2 = d1.Substring(d1.IndexOf("\n") + 1, d1.Length - d1.IndexOf("\n") - 1);
                                        string d3 = d2.Substring(d2.IndexOf("\n") + 1, d2.Length - d2.IndexOf("\n") - 1);
                                        dateID = d3.Substring(0, d3.IndexOf("\n"));

                                        string c1 = currentText.Substring((currentText.IndexOf("CERT NUMBER") - 12), 12);
                                        certNumber = c1.Substring(c1.IndexOf("\n") + 1).Trim();
                                    }
                                    else if (currentText.IndexOf("WINDSOR") > -1)
                                    {
                                        if ((currentText.IndexOf("ACCURACY") > -1) & (currentText.IndexOf("IN TOL") > -1))
                                        {
                                            item = currentText.Substring(
                                                        (currentText.IndexOf("ACCURACY") + 9),
                                                        currentText.IndexOf("IN TOL") - (currentText.IndexOf("ACCURACY") + 10));
                                            string W1 = currentText.Substring(currentText.IndexOf("IN TOL") + 13, 50);
                                            certNumber = W1.Substring(0, W1.IndexOf("\n"));

                                            if (currentText.IndexOf("%") > -1)
                                            {
                                                string s1 = currentText.Substring((currentText.IndexOf("%\n") + 2), 10);
                                                dateID = s1.Substring(0, s1.IndexOf("\n"));
                                            }
                                        }
                                    }
                                }
                                else if (currentText.IndexOf("PIN GAGE") > -1)
                                {
                                    string ss1 = currentText.Substring((currentText.IndexOf("CERTIFICATE OF CALIBRATION") + 27), 50);
                                    string ss2 = ss1.Substring(ss1.IndexOf("\n") + 1, ss1.Length - ss1.IndexOf("\n") - 1);
                                    dateID = ss1.Substring(0, ss1.IndexOf("\n"));
                                    certNumber = ss2.Substring(0, ss2.IndexOf("\n"));

                                    if (currentText.IndexOf("06455") > -1)
                                    {
                                        string s1 = currentText.Substring((currentText.IndexOf("06455") + 6), 100);
                                        string s2 = s1.Substring(s1.IndexOf("\n") + 1, s1.Length - s1.IndexOf("\n") - 1);
                                        string s3 = s2.Substring(s2.IndexOf("\n") + 1, s2.Length - s2.IndexOf("\n") - 1);
                                        
                                        item = s3.Substring(0, s3.IndexOf("\n"));
                                    }

                                    if (item.IndexOf(" ") > -1)
                                    {
                                        if (currentText.IndexOf("PIN GAGE") > -1)
                                        {
                                            string s1 = currentText.Substring((currentText.IndexOf("PIN GAGE") + 9), 50);
                                            item = s1.Substring(0, s1.IndexOf("\n"));
                                        }
                                    }

                                    if (CheckDate(dateID))
                                    {

                                    }
                                    else
                                    {
                                        string s1 = currentText.Substring((currentText.IndexOf("%\n") + 2), 100);
                                        string s2 = s1.Substring(s1.IndexOf("\n") + 1, s1.Length - s1.IndexOf("\n") - 1);
                                        string s3 = s2.Substring(s2.IndexOf("\n") + 1, s2.Length - s2.IndexOf("\n") - 1);
                                        string s4 = s3.Substring(s3.IndexOf("\n") + 1, s3.Length - s3.IndexOf("\n") - 1);
                                        string s5 = s4.Substring(s4.IndexOf("\n") + 1, s4.Length - s4.IndexOf("\n") - 1);
                                        dateID = s5.Substring(0, s5.IndexOf("\n"));
                                    }

                                }

                             //   File.AppendAllText(@"C:\A\pdfTEST.txt",
                             //item + " BRIDGEWATER " + Environment.NewLine);


                            }
                            //else if (currentText.IndexOf("WINDSOR") > -1)
                            //{
                            //    File.AppendAllText(@"C:\A\WINDSOR.txt",
                            //  item + " WINDSOR " + Environment.NewLine);
                            //}
                            else if (currentText.IndexOf("ONSITE") > -1)
                            {
                                if (currentText.LastIndexOf("PARALLELISM") > -1)
                                {
                                    if (currentText.LastIndexOf("PARALLELISM\n") == -1)
                                    {
                                        try
                                        {
                                            if (currentText.IndexOf("06455") > -1)
                                            {
                                                string s1 = currentText.Substring((currentText.IndexOf("06455") + 6), 100);
                                                string s2 = s1.Substring(s1.IndexOf("\n") + 1, s1.Length - s1.IndexOf("\n") - 1);
                                                string s3 = s2.Substring(s2.IndexOf("\n") + 1, s2.Length - s2.IndexOf("\n") - 1);
                                                string s4 = s3.Substring(s3.IndexOf("\n") + 1, s3.Length - s3.IndexOf("\n") - 1);
                                                string s5 = s4.Substring(s4.IndexOf("\n") + 1, s4.Length - s4.IndexOf("\n") - 1);
                                                string s6 = s5.Substring(s5.IndexOf("\n") + 1, s5.Length - s5.IndexOf("\n") - 1);

                                                item = s3.Substring(0, s3.IndexOf("\n"));
                                                certNumber = s6.Substring(0, s6.IndexOf("\n"));

                                                string s7 = currentText.Substring((currentText.IndexOf("ONSITE") + 7), 50);
                                                string s8 = s7.Substring(s7.IndexOf("\n") + 1, s7.Length - s7.IndexOf("\n") - 1);

                                                dateID = s8.Substring(0, s8.IndexOf("\n")) + " 00:00:00.000";

                                                if (dateID.IndexOf("/") > -1)
                                                {

                                                }
                                                else
                                                {
                                                    dateID = s5.Substring(0, s5.IndexOf("\n")) + " 00:00:00.000";
                                                }

                                                if (currentText.IndexOf("%\n") > -1)
                                                {
                                                    dateID = currentText.Substring((currentText.IndexOf("%\n") + 2), 10).Trim();
                                                }

                                                if (CheckDate(dateID))
                                                {
                                                    /* can adjsut date if wrong date selected here     */
                                                    dateID = Convert.ToDateTime(dateID).AddDays(1).ToShortDateString();
                                                }
                                                else
                                                {
                                                    item = string.Empty;
                                                }



                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.ToString());
                                        }
                                        finally
                                        {

                                        }


                                        File.AppendAllText(@"C:\A\Parallel1.txt",
                                        DateTime.Now.ToString() + n.ToString() + "  " + fileList[i].ToString() + Environment.NewLine);

                                    }
                                    else if (currentText.LastIndexOf("PARALLELISM\n") > -1)
                                    {

                                        if ((currentText.IndexOf("ACCURACY") > -1) & (currentText.IndexOf("IN TOL") > -1))
                                        {
                                            item = currentText.Substring(
                                                        (currentText.IndexOf("ACCURACY") + 9),
                                                        currentText.IndexOf("IN TOL") - (currentText.IndexOf("ACCURACY") + 10));
                                            string W1 = currentText.Substring(currentText.IndexOf("IN TOL") + 13, 50);
                                            certNumber = W1.Substring(0, W1.IndexOf("\n"));

                                            if (currentText.IndexOf("ONSITE") > -1)
                                            {
                                                string s1 = currentText.Substring((currentText.IndexOf("ONSITE") + 7), 20);
                                                dateID = s1.Substring(0, s1.IndexOf(" "));
                                            }

                                            if (item.Length > 30)
                                            {
                                                string s2 = currentText.Substring((currentText.IndexOf("LINEAR ACCURACY") + 16), 20);
                                                item = s2.Substring(0, s2.IndexOf("\n"));

                                                string s3 = currentText.Substring((currentText.IndexOf("%") + 1), 20);
                                                if (s3.IndexOf("\n") == 0)
                                                {
                                                    s3 = s3.Substring(1, s3.Length - 1);
                                                }
                                                dateID = s3.Substring(0, s3.IndexOf("\n"));

                                                if (CheckDate(dateID))
                                                {

                                                }
                                                else
                                                {
                                                    if (currentText.IndexOf("%\n") > -1)
                                                    {
                                                        dateID = currentText.Substring((currentText.IndexOf("%\n") + 2), 10).Trim();
                                                    }
                                                }

                                                string s4 = currentText.Substring((currentText.IndexOf("ONSITE") + 7), 30);
                                                string s5 = s4.Substring(s4.IndexOf("\n") + 1, s4.Length - s4.IndexOf("\n") - 1);
                                                //string s6 = s5.Substring(s5.IndexOf("\n") + 1, s5.Length - s5.IndexOf("\n") - 1);

                                                certNumber = s5.Substring(0, s5.IndexOf(" "));
                                            }

                                            //if (CheckDate(dateID))
                                            //{
                                            //    /* can adjsut date if wrong date selected here     */
                                            //    dateID = Convert.ToDateTime(dateID).AddDays(1).ToShortDateString();
                                            //}
                                            //else
                                            //{
                                            //    item = string.Empty;
                                            //}

                                            n++;
                                            File.AppendAllText(@"C:\A\Accuracy.txt",
                                            DateTime.Now.ToString() + n.ToString() + "  " + fileList[i].ToString() + Environment.NewLine);



                                        }

                                    }
                                }
                                //else if (currentText.LastIndexOf("BASE FLATNESS") > -1)
                                //{
                                //    n++;
                                //    File.AppendAllText(@"C:\A\Base Flatness.txt",
                                //    DateTime.Now.ToString() + n.ToString() + "  " + fileList[i].ToString() + Environment.NewLine);


                                //}
                                else if (currentText.LastIndexOf("REPEATABILITY\n") > -1)
                                {

                                    int firsttest = currentText.LastIndexOf("REPEATABILITY");
                                    int secondtest = currentText.LastIndexOf("CLOCKWISE ACCURACY");

                                    if (firsttest > secondtest)
                                    {
                                        if (currentText.IndexOf("IN INCHES") > -1)
                                        {
                                            string a = currentText.Substring(currentText.IndexOf("IN INCHES") + 9,
                                                currentText.IndexOf("IN TOLERANCE") - (currentText.IndexOf("IN INCHES") + 9));
                                            string b = a.Substring(a.IndexOf("\n") + 1, a.Length - (a.IndexOf("\n") + 1));
                                            string c = b.Substring(b.IndexOf("\n") + 1, b.Length - (b.IndexOf("\n") + 1));
                                            string d = c.Substring(c.IndexOf("\n") + 1, c.Length - (c.IndexOf("\n") + 1));
                                            item = d.Substring(0, d.IndexOf("\n"));
                                        }
                                        else
                                        {
                                            string a = currentText.Substring(currentText.IndexOf("IN MILLIMETERS") + 14,
                                                currentText.IndexOf("IN TOLERANCE") - (currentText.IndexOf("IN MILLIMETERS") + 14));
                                            string b = a.Substring(a.IndexOf("\n") + 1, a.Length - (a.IndexOf("\n") + 1));
                                            string c = b.Substring(b.IndexOf("\n") + 1, b.Length - (b.IndexOf("\n") + 1));
                                            string d = c.Substring(c.IndexOf("\n") + 1, c.Length - (c.IndexOf("\n") + 1));
                                            item = d.Substring(0, d.IndexOf("\n"));
                                        }
                                        /*
                                        string f = currentText.Substring(currentText.IndexOf("06455") + 6,
                                               currentText.IndexOf("PAGE 1 OF 1") - (currentText.IndexOf("06455")));
*/
                                        string f = currentText.Substring(currentText.IndexOf("06455") + 6,
                                               currentText.IndexOf("PAGE 1 OF 1") - (currentText.IndexOf("06455")));
                                        if (f.Length > 10)
                                        {
                                            string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                            string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                            certNumber = h.Substring(0, h.IndexOf("\n"));
                                        }
                                        else
                                        {
                                            string s1 = currentText.Substring(currentText.IndexOf("INDICATOR") + 10, 12);
                                            certNumber = s1.Substring(0, s1.IndexOf("\n"));
                                        }

                                        if (CheckDate(certNumber))
                                        {
                                            dateID = certNumber;

                                            int a = (currentText.IndexOf("06455"));
                                            int b = (currentText.IndexOf("PAGE 1 OF 1"));

                                            if (b - a > 100)
                                            {
                                                string s1 = currentText.Substring((currentText.IndexOf("06455") + 6), 100);
                                                string s3 = s1.Substring(s1.IndexOf("\n") + 1, s1.Length - s1.IndexOf("\n") - 1);
                                                string s4 = s3.Substring(s3.IndexOf("\n") + 1, s3.Length - s3.IndexOf("\n") - 1);
                                                string s5 = s4.Substring(s4.IndexOf("\n") + 1, s4.Length - s4.IndexOf("\n") - 1);
                                                string s6 = s5.Substring(s5.IndexOf("\n") + 1, s5.Length - s5.IndexOf("\n") - 1);

                                                certNumber = s5.Substring(0, s5.IndexOf("\n"));
                                            }
                                        }
                                        else
                                        {
                                            string j = currentText.Substring(currentText.IndexOf("ONSITE") - 11, 12);

                                            if (j.Substring(0, 1) == "\n")
                                            {
                                                j = j.Substring(1, j.Length - 1);
                                            }
                                            dateID = j.Substring(0, j.IndexOf("\n"));
                                        }


                                        /*
                                        
                                        string j = currentText.Substring(currentText.IndexOf("SPECIFICATIONS") + 15, 20);
                                        dateID = j.Substring(0, j.IndexOf("\n"));
                                        */

                                        /*
                                        string s2 = currentText.Substring(currentText.IndexOf("TOLERANCE") + 10, 12);
                                        dateID = s2.Substring(0, s2.IndexOf("\n"));
                                        */
                                    }
                                    else
                                    {

                                        if (currentText.IndexOf("IN INCHES") > -1)
                                        {
                                            string a = currentText.Substring(currentText.IndexOf("IN INCHES") + 9,
                                                currentText.IndexOf("IN TOLERANCE") - (currentText.IndexOf("IN INCHES") + 9));
                                            string b = a.Substring(a.IndexOf("\n") + 1, a.Length - (a.IndexOf("\n") + 1));
                                            string c = b.Substring(b.IndexOf("\n") + 1, b.Length - (b.IndexOf("\n") + 1));
                                            string d = c.Substring(c.IndexOf("\n") + 1, c.Length - (c.IndexOf("\n") + 1));
                                            item = d.Substring(0, d.IndexOf("\n"));
                                        }
                                        else
                                        {
                                            string a = currentText.Substring(currentText.IndexOf("IN MILLIMETERS") + 14,
                                                currentText.IndexOf("IN TOLERANCE") - (currentText.IndexOf("IN MILLIMETERS") + 14));
                                            string b = a.Substring(a.IndexOf("\n") + 1, a.Length - (a.IndexOf("\n") + 1));
                                            string c = b.Substring(b.IndexOf("\n") + 1, b.Length - (b.IndexOf("\n") + 1));
                                            string d = c.Substring(c.IndexOf("\n") + 1, c.Length - (c.IndexOf("\n") + 1));
                                            item = d.Substring(0, d.IndexOf("\n"));
                                        }

                                        string f = currentText.Substring(currentText.IndexOf("06455") + 6,
                                               currentText.IndexOf("PAGE 1 OF 1") - (currentText.IndexOf("06455")));
                                        string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                        string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                        string h2 = h.Substring(h.IndexOf("\n") + 1, h.Length - (h.IndexOf("\n") + 1));
                                        certNumber = h.Substring(0, h.IndexOf("\n"));

                                        if (CheckDate(certNumber))
                                        {
                                            dateID = certNumber;

                                            certNumber = h2.Substring(0, h2.IndexOf("\n"));
                                        }
                                        else
                                        {
                                            string j = currentText.Substring(currentText.IndexOf("ONSITE") - 11, 12);

                                            if (j.Substring(0, 1) == "\n")
                                            {
                                                j = j.Substring(1, j.Length - 1);
                                            }
                                            dateID = j.Substring(0, j.IndexOf("\n"));
                                        }


                                        if (CheckDate(dateID))
                                        {
                                            /* can adjsut date if wrong date selected here     */
                                            dateID = Convert.ToDateTime(dateID).AddDays(1).ToShortDateString();
                                        }
                                        else
                                        {
                                            item = string.Empty;
                                        }


                                        /*
                                        if (currentText.IndexOf("IN TOLERANCE") > -1)
                                        {
                                            string a = currentText.Substring(currentText.IndexOf("IN INCHES") + 9,
                                                currentText.IndexOf("IN TOLERANCE") - (currentText.IndexOf("IN INCHES") + 9));
                                            string b = a.Substring(a.IndexOf("\n") + 1, a.Length - (a.IndexOf("\n") + 1));
                                            string c = b.Substring(b.IndexOf("\n") + 1, b.Length - (b.IndexOf("\n") + 1));
                                            string d = c.Substring(c.IndexOf("\n") + 1, c.Length - (c.IndexOf("\n") + 1));
                                            item = d.Substring(0, d.IndexOf("\n"));
                                            dateID = c.Substring(0, c.IndexOf("\n"));

                                            
                                            string f = currentText.Substring(currentText.IndexOf("06455") + 6,
                                                currentText.IndexOf("PAGE 1 OF 1") - (currentText.IndexOf("06455")));
                                            string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                            string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                            //dateID = h.Substring(0, h.IndexOf("\n"));
                                            


                                            string s2 = h.Substring(h.IndexOf("\n") + 1, h.Length - h.IndexOf("\n") - 1);

                                            certNumber = s2.Substring(0, s2.IndexOf("\n"));

                                            //string j = currentText.Substring(currentText.LastIndexOf("SPECIFICATIONS") + 15, 12);
                                            //dateID = j.Substring(0, j.IndexOf("\n"));
                                        }
                                        else
                                        {
                                            if (currentText.IndexOf("06455") > -1)
                                            {
                                                string f = currentText.Substring(currentText.IndexOf("06455") + 6,
                                                  currentText.IndexOf("PAGE 1 OF 1") - (currentText.IndexOf("06455")));
                                                string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                                string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                                item = h.Substring(0, h.IndexOf("\n"));
                                            }
                                            else
                                            {
                                                string f = currentText.Substring(currentText.IndexOf("MIDDLEFIELD") + 15,
                                                  currentText.IndexOf("THE MATERIAL") - (currentText.IndexOf("MIDDLEFIELD")));
                                                string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                                string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                                string j = h.Substring(h.IndexOf("\n") + 1, h.Length - (h.IndexOf("\n") + 1));
                                                item = j.Substring(0, j.IndexOf("\n"));
                                            }

                                            string d = currentText.Substring(currentText.LastIndexOf("REVIEWED BY") + 12, 25);
                                            dateID = d.Substring(0, d.IndexOf("\n"));

                                            string a = currentText.Substring(currentText.IndexOf("PASS\n") + 5, 25);
                                            string b = a.Substring(a.IndexOf("\n") + 1, a.Length - (a.IndexOf("\n") + 1));
                                            certNumber = b.Substring(0, b.IndexOf("\n"));
                                        }

                                    


                                        n++;
                                        File.AppendAllText(@"C:\A\repeatability.txt",
                                        DateTime.Now.ToString() + n.ToString() + "  " + fileList[i].ToString() + Environment.NewLine);
                                    */
                                    }
                                }
                                else if (currentText.LastIndexOf("\nLINEAR ACCURACY\n") > -1)
                                {
                                    /*n++;
                                    File.AppendAllText(@"C:\A\lin accuracy.txt",
                                    DateTime.Now.ToString() + n.ToString() + "  " + fileList[i].ToString() + Environment.NewLine);*/

                                    int t1 = currentText.IndexOf("ACCURACY");
                                    int t2 = currentText.IndexOf("IN TOL");

                                    if (t1 < t2)
                                    {

                                        item = currentText.Substring(
                                                    (currentText.IndexOf("ACCURACY") + 9),
                                                    currentText.IndexOf("IN TOL") - (currentText.IndexOf("ACCURACY") + 10));

                                        string W1 = currentText.Substring(currentText.IndexOf("IN TOL") + 13, 50);
                                        certNumber = W1.Substring(0, W1.IndexOf("\n"));

                                        if (currentText.IndexOf("06455") > -1)
                                        {
                                            string s1 = currentText.Substring((currentText.IndexOf("06455") + 6), currentText.Length - currentText.IndexOf("06455") - 6);
                                            string s2 = s1.Substring(s1.IndexOf("\n") + 1, s1.Length - s1.IndexOf("\n") - 1);
                                            string s3 = s2.Substring(s2.IndexOf("\n") + 1, s2.Length - s2.IndexOf("\n") - 1);
                                            string s4 = s3.Substring(s3.IndexOf("\n") + 1, s3.Length - s3.IndexOf("\n") - 1);
                                            string s5 = s4.Substring(s4.IndexOf("\n") + 1, s4.Length - s4.IndexOf("\n") - 1);
                                            dateID = s5.Substring(0, s5.IndexOf("\n"));
                                            //certNumber = s4.Substring(0, s4.IndexOf("\n") - 1);
                                        }

                                        if (CheckDate(dateID))
                                        {

                                        }
                                        else
                                        {
                                            if (currentText.IndexOf("BASE FLATNESS") > -1)
                                            {
                                                string s1 = currentText.Substring(currentText.IndexOf("BASE FLATNESS") - 11, 10);
                                                if (s1.IndexOf("\n") == 0)
                                                {
                                                    dateID = s1.Substring(1, s1.Length - 1);
                                                }
                                            }
                                        }


                                    }
                                    else
                                    {
                                        if (currentText.IndexOf("06455") > -1)
                                        {
                                            string s1 = currentText.Substring((currentText.IndexOf("06455") + 6), currentText.Length - currentText.IndexOf("06455") - 6);
                                            string s2 = s1.Substring(s1.IndexOf("\n") + 1, s1.Length - s1.IndexOf("\n") - 1);
                                            string s3 = s2.Substring(s2.IndexOf("\n") + 1, s2.Length - s2.IndexOf("\n") - 1);
                                            string s4 = s3.Substring(s3.IndexOf("\n") + 1, s3.Length - s3.IndexOf("\n") - 1);
                                            string s5 = s4.Substring(s4.IndexOf("\n") + 1, s4.Length - s4.IndexOf("\n") - 1);
                                            item = s3.Substring(0, s3.IndexOf("\n"));
                                            certNumber = s5.Substring(0, s5.IndexOf("\n"));
                                        }

                                        if(currentText.IndexOf("REVIEWED BY") > -1)
                                        {
                                            string s1 = currentText.Substring((currentText.IndexOf("REVIEWED BY") + 12), currentText.Length - currentText.IndexOf("REVIEWED BY") - 12);
                                            dateID = s1.Substring(0, s1.IndexOf("\n"));
                                        }
                                    }
                                    
                                    
                                    //string s1 = currentText.Substring(currentText.IndexOf("ONSITE") + 7, 50);
                                    //dateID = s1.Substring(0, s1.IndexOf(" "))
                                    //+ " 00:00:00.000";
                                }
                                else if (currentText.IndexOf("ONSITE") > -1)
                                {
                                    string W1 = currentText.Substring(currentText.IndexOf("ONSITE") + 7, 100);
                                    string W2 = W1.Substring(W1.IndexOf("\n") + 1, W1.Length - W1.IndexOf("\n") - 1);
                                    string W3 = W2.Substring(W2.IndexOf("\n") + 1, W2.Length - W2.IndexOf("\n") - 1);
                                    string W4 = W3.Substring(W3.IndexOf("\n") + 1, W3.Length - W3.IndexOf("\n") - 1);


                                    dateID = W3.Substring(0, W3.IndexOf("\n")) + " 00:00:00.000";
                                    item = W4.Substring(0, W4.IndexOf("\n"));

                                    if (currentText.IndexOf("06455") > -1)
                                    {
                                        string s1 = currentText.Substring((currentText.IndexOf("06455") + 6), 100);
                                        string s2 = s1.Substring(s1.IndexOf("\n") + 1, s1.Length - s1.IndexOf("\n") - 1);
                                        string s3 = s2.Substring(s2.IndexOf("\n") + 1, s2.Length - s2.IndexOf("\n") - 1);
                                        string s4 = s3.Substring(s3.IndexOf("\n") + 1, s3.Length - s3.IndexOf("\n") - 1);
                                        certNumber = s4.Substring(0, s4.IndexOf("\n") - 1);
                                    }





                                }
                                else if (currentText.LastIndexOf("REPEATABILITY ACCURACY") > -1)
                                {
                                    n++;
                                    File.AppendAllText(@"C:\A\repeatability accuracy.txt",
                                    DateTime.Now.ToString() + n.ToString() + "  " + fileList[i].ToString() + Environment.NewLine);

                                }
                            }
                            else
                            {
                                if (currentText.LastIndexOf("ANGLE") > -1)
                                {
                                    if (currentText.LastIndexOf("ANGLE IRON") == -1)
                                    {

                                        if (currentText.IndexOf("06455") > -1)
                                        {
                                            string s1 = currentText.Substring((currentText.IndexOf("06455") + 6), currentText.Length - (currentText.IndexOf("06455") - 6));
                                            string s2 = s1.Substring(s1.IndexOf("\n") + 1, s1.Length - s1.IndexOf("\n") - 1);
                                            string s3 = s2.Substring(s2.IndexOf("\n") + 1, s2.Length - s2.IndexOf("\n") - 1);
                                            item = s3.Substring(0, s3.IndexOf("\n"));
                                        }

                                        if (currentText.IndexOf("SPECIFICATIONS") > -1)
                                        {
                                            string s1 = currentText.Substring((currentText.IndexOf("SPECIFICATIONS") + 15), 20);
                                            certNumber = s1.Substring(0, s1.IndexOf("\n"));
                                        }

                                        if (currentText.IndexOf("%") > -1)
                                        {
                                            string s1 = currentText.Substring((currentText.IndexOf("%\n") + 2), 20);
                                            dateID = s1.Substring(0, s1.IndexOf("\n"));
                                        }
                                    }
                                    else
                                    {
                                        if (currentText.IndexOf("WINDSOR") > -1)
                                        {
                                            string s1 = currentText.Substring((currentText.IndexOf("WINDSOR") + 13), 20);
                                            item = s1.Substring(0, s1.IndexOf("\n"));
                                        }

                                        if (currentText.IndexOf("SPECIFICATIONS") > -1)
                                        {
                                            string s1 = currentText.Substring((currentText.LastIndexOf("SPECIFICATIONS") + 15), 20);
                                            dateID = s1.Substring(0, s1.IndexOf("\n"));
                                            dateID = dateID + " 00:00:00.000";
                                        }

                                        if (currentText.IndexOf("06455") > -1)
                                        {
                                            string s1 = currentText.Substring(currentText.IndexOf("06455") + 6, 20);
                                            certNumber = s1.Substring(0, s1.IndexOf(" "));
                                        }
                                    }
                                }
                                else if (currentText.IndexOf("THREAD") > -1)
                                {
                                    if (currentText.IndexOf("BRIDGEWATER") > -1)
                                    {
                                        string s1 = currentText.Substring((currentText.IndexOf("BRIDGEWATER") + 12), 50);
                                        string s2 = s1.Substring(s1.IndexOf("\n") + 1, s1.Length - s1.IndexOf("\n") - 1);
                                        string s3 = s2.Substring(s2.IndexOf("\n") + 1, s2.Length - s2.IndexOf("\n") - 1);
                                        string s4 = s3.Substring(s3.IndexOf("\n") + 1, s3.Length - s3.IndexOf("\n") - 1);
                                        item = s4.Substring(0, s4.IndexOf("\n"));

                                        string d1 = currentText.Substring((currentText.LastIndexOf("CALIBRATION DATE") + 17), 100);
                                        string d2 = d1.Substring(d1.IndexOf("\n") + 1, d1.Length - d1.IndexOf("\n") - 1);
                                        string d3 = d2.Substring(d2.IndexOf("\n") + 1, d2.Length - d2.IndexOf("\n") - 1);
                                        dateID = d3.Substring(0, d3.IndexOf("\n"));

                                        string c1 = currentText.Substring((currentText.IndexOf("CERT NUMBER") - 12), 12);
                                        certNumber = c1.Substring(c1.IndexOf("\n") + 1).Trim();
                                    }
                                    else if (currentText.IndexOf("WINDSOR") > -1)
                                    {
                                        if ((currentText.IndexOf("ACCURACY") > -1) & (currentText.IndexOf("IN TOL") > -1))
                                        {
                                            item = currentText.Substring(
                                                        (currentText.IndexOf("ACCURACY") + 9),
                                                        currentText.IndexOf("IN TOL") - (currentText.IndexOf("ACCURACY") + 10));
                                            string W1 = currentText.Substring(currentText.IndexOf("IN TOL") + 13, 50);
                                            certNumber = W1.Substring(0, W1.IndexOf("\n"));

                                            if (currentText.IndexOf("%") > -1)
                                            {
                                                string s1 = currentText.Substring((currentText.IndexOf("%\n") + 2), 10);
                                                dateID = s1.Substring(0, s1.IndexOf("\n"));
                                            }

                                           
                                        }
                                    }
                                }
                                else if (currentText.IndexOf("PLUG GAGE") > -1)
                                {
                                    string s1 = currentText.Substring((currentText.IndexOf("PLUG GAGE") + 10), 20);
                                    item = s1.Substring(0, s1.IndexOf("\n"));

                                    if (currentText.IndexOf("REVIEWED BY") > -1)
                                    {
                                        string s2 = currentText.Substring((currentText.IndexOf("REVIEWED BY") + 12), 12);
                                        dateID = s2.Substring(0, s2.IndexOf("\n"));
                                    }

                                    if (currentText.IndexOf("CERTIFICATE OF CALIBRATION") > -1)
                                    {
                                        string d1 = currentText.Substring((currentText.LastIndexOf("CERTIFICATE OF CALIBRATION") + 27), 100);
                                        string d2 = d1.Substring(d1.IndexOf("\n") + 1, d1.Length - d1.IndexOf("\n") - 1);
                                        string d3 = d2.Substring(d2.IndexOf("\n") + 1, d2.Length - d2.IndexOf("\n") - 1);
                                        certNumber = d3.Substring(0, d3.IndexOf("\n"));
                                    }
                                }
                                //else if (currentText.IndexOf("THREAD PLUG") > -1)
                                //{
                                //    string s1 = currentText.Substring((currentText.IndexOf("PLUG GAGE") + 10), 20);
                                //    item = s1.Substring(0, s1.IndexOf("\n"));

                                //    if (currentText.IndexOf("REVIEWED BY") > -1)
                                //    {
                                //        string s2 = currentText.Substring((currentText.IndexOf("REVIEWED BY") + 12), 12);
                                //        dateID = s2.Substring(0, s2.IndexOf("\n"));
                                //    }

                                //    if (currentText.IndexOf("CERTIFICATE OF CALIBRATION") > -1)
                                //    {
                                //        string d1 = currentText.Substring((currentText.LastIndexOf("CERTIFICATE OF CALIBRATION") + 27), 100);
                                //        string d2 = d1.Substring(d1.IndexOf("\n") + 1, d1.Length - d1.IndexOf("\n") - 1);
                                //        string d3 = d2.Substring(d2.IndexOf("\n") + 1, d2.Length - d2.IndexOf("\n") - 1);
                                //        certNumber = d3.Substring(0, d3.IndexOf("\n"));
                                //    }
                                //}
                                ////File.AppendAllText(@"C:\A\Unsupported.txt",
                                //DateTime.Now.ToString() + i.ToString() + "  " + fileList[i].ToString() + Environment.NewLine);
                            }
                        }
                    }

                    pdfReader.Close();

                    Thread.Sleep(1000);

                    if (item != null & item != string.Empty & dateID != null & dateID != string.Empty)
                    {
                        int o = 0;
                        object oo = null;
                        SqlConnection cnxn = new SqlConnection(db);
                        cnxn.Open();
                        SqlCommand cmd = new SqlCommand
                            ("select id from calibrationdata where item = '" + item + "' and " +
                             "cal_date = '" + dateID + " ';", cnxn);

                        try
                        {
                            oo = cmd.ExecuteScalar();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {

                        }

                        if (oo is null)
                        {
                            o = 0;
                        }
                        else
                        {
                            o = Convert.ToInt32(oo);
                        }

                        if (o > 0)
                        {
                            //throws an exception if the files is already there so check first.  Just looking for
                            //null did't work but this method does.
                            SqlDataAdapter da = new SqlDataAdapter
                                ("select certpdf from calibrationdata where id = " + o + "", cnxn);

                            DataTable table = new DataTable();
                            da.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                existingCert = table.Rows[0].ItemArray[0].ToString().Trim();
                                //if there is a row with no cert then ""
                                //if there is a row with a cert then something other than null
                                //if there is no row then it works fine - no insert
                            }
                        }

                        if (o > 0 & existingCert == "")
                        {
                            FileStream fs = new FileStream
                                (fileList[i], FileMode.Open, FileAccess.Read);

                            // store the file in an array the length of the file
                            byte[] fileData = new byte[fs.Length];

                            // read the file stream to the array
                            fs.Read(fileData, 0, Convert.ToInt32(fs.Length));

                            //SqlConnection cnxn = new SqlConnection(db);

                            SqlParameter prm1 = new SqlParameter
                                ("@file", SqlDbType.Image, Convert.ToInt32(fs.Length));
                            prm1.Value = fileData;

                            SqlParameter crtNum = new SqlParameter
                            ("@certNo", SqlDbType.VarChar, 50);
                            crtNum.Value = certNumber;

                            cmd = new SqlCommand
                                ("Update Calibrationdata set Certpdf = " + prm1 +
                                 " , yesCertpdf = 'Y', certnum = " + crtNum +
                                 " where id = " + o + " ");
                            cmd.Parameters.Add(prm1);
                            cmd.Parameters.Add(crtNum);
                            cmd.Connection = cnxn;
                            //cnxn.Open();
                            cmd.ExecuteNonQuery();
                            cnxn.Close();
                            fs.Close();
                            // close the file stream

                            cnxn = new SqlConnection(db);
                            cmd = new SqlCommand
                                ("Select Certpdf from calibrationdata " +
                                 " where id = " + o + "", cnxn);

                            cnxn.Open();
                            object success = cmd.ExecuteScalar();
                            if (success != null)
                            {
                                File.Move(fileList[i],
                                    @"\\zygocorp\departments\quality\calibration\uploaded\" + item + ".pdf");
                                File.AppendAllText(@"\\zygocorp\departments\quality\calibration\uploaded\UploadedLog.txt",
                                DateTime.Now.ToString() + " " + item + "  " + dateID + "  Uploaded" + Environment.NewLine);
                                //DialogResult result;
                                //result = MessageBox.Show(" PDF created.");
                            }
                            cnxn.Close();

                            //Close();
                        }
                        else
                        {
                            File.AppendAllText(@"\\zygocorp\departments\quality\calibration\pdfLog.txt",
                                DateTime.Now.ToString() + " Failed to insert pdf for " + item + " on " + dateID + Environment.NewLine);
                        }
                        item = "";
                        dateID = "";
                        certNumber = "";
                        existingCert = default(string);
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("356 " + ex.ToString());
            }
            finally
            {

            }
        }

        protected bool CheckDate(String date)
        {
            try
            {
                DateTime dt = DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected bool CheckCert(String cert)
        {
            if (cert.IndexOf("-") == 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}