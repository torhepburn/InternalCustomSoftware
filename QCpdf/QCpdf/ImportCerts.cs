using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using System.Data.SqlClient;

namespace QCpdf
{
    public partial class ImportCerts : Form
    {
        private string[] fileList;
        private string item;
        private string dateID;
        private string db = "server=CT-MID-SQL01; user = readWrite; pwd = Read+Write!; database= calibration;";
        private string existingCert;
        private string certNumber;

        public ImportCerts()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //fileList = Directory.GetFiles(@"\\zygocorp\departments\quality\calibration", "*.pdf");
                //fileList = Directory.GetFiles(@"\\zygocorp\departments\quality\quality\tim kyle\calibration\rcca missing certs\2018 certs", "*.pdf");
                fileList = Directory.GetFiles(@"\\zygocorp\departments\quality\quality\tim kyle\calibration\rcca missing certs\holts missing", "*.pdf");
                //fileList = Directory.GetFiles(@"\\zygocorp\departments\quality\quality\tim kyle\calibration\rcca missing certs\cal tek missing certs", "*.pdf");
                //fileList = Directory.GetFiles(@"C:\A", "PO_600024.pdf");

                for (int i = 0; i < fileList.Length; i++)
                {
                    PdfReader pdfReader = new PdfReader(fileList[i]);

                    for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                    {
                        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                        string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);

                        pdfReader.Close();

                        currentText = Encoding.UTF8.GetString
                            (ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));

                        currentText = currentText.ToUpper();

                        if (currentText.LastIndexOf("STANDARD METER LAB.") > -1)
                        {
                            certNumber = currentText.Substring((currentText.LastIndexOf("REPORT:") + 8), 6);
                            item = currentText.Substring((currentText.LastIndexOf("SYSTEM ID:") + 11), 7);


                            string TEST = "A";
                        }

                        if (currentText.LastIndexOf("HOLTS") > -1)
                        {
                            if (currentText.IndexOf("CERT NUMBER") < 1)
                            {
                                if ((currentText.IndexOf("SURFACE PLATE") > -1))
                                {
                                    int NN = (currentText.IndexOf("\nMASTER DUE DATE\n"));

                                    if (currentText.IndexOf("SURFACE PLATE") > (currentText.IndexOf("06455")))
                                    {
                                        string f = currentText.Substring(currentText.IndexOf("CUSTOMER ZYGO") + 14,
                                                currentText.IndexOf("06455") - (currentText.IndexOf("CUSTOMER ZYGO")));
                                        string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                        string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                        certNumber = h.Substring(0, h.IndexOf("\n"));
                                    }
                                    else
                                    {
                                        string f = currentText.Substring(currentText.IndexOf("\nMASTER DUE DATE\n") + 16,
                                            currentText.IndexOf("06455") - (currentText.IndexOf("\nMASTER DUE DATE\n")));
                                        string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                        string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                        certNumber = h.Substring(0, h.IndexOf("\n"));
                                    }

                                    item = currentText.Substring(0, currentText.IndexOf("\n"));

                                    string d = currentText.Substring(currentText.LastIndexOf("HPI-510") + 8, 11);
                                    if (d.IndexOf("\n") < 12)
                                    {
                                        dateID = d.Substring(0, d.IndexOf("\n"));
                                    }
                                    else
                                    {
                                        dateID = d.Substring(0, d.IndexOf(" "));
                                    }


                                }
                                else
                                {
                                    certNumber = currentText.Substring(
                                        (currentText.IndexOf("CERT NO.") + 9),
                                        currentText.IndexOf("ADDRESS MASTER") - (currentText.IndexOf("CERT NO.") + 10));


                                    if (currentText.IndexOf("GAGE TYPE") < currentText.IndexOf("GAGE ID"))
                                    {
                                        item = currentText.Substring(
                                            (currentText.IndexOf("GAGE ID") + 8),
                                            currentText.IndexOf("NIST TRACE #") - (currentText.IndexOf("GAGE ID") + 9));
                                        dateID = currentText.Substring(
                                            (currentText.IndexOf("CALIBRATION DATE") + 17),
                                             currentText.IndexOf("CALIBRATED BY") -
                                             (currentText.IndexOf("CALIBRATION DATE") + 18)) + " 00:00:00.000";
                                    }
                                    else
                                    {
                                        item = currentText.Substring(
                                            (currentText.IndexOf("GAGE ID") + 8),
                                            currentText.IndexOf("MASTER DUE") - (currentText.IndexOf("GAGE ID") + 9));
                                        dateID = currentText.Substring(
                                            (currentText.IndexOf("CALIBRATION DATE") + 17),
                                             currentText.IndexOf("CALIBRATED BY") -
                                             (currentText.IndexOf("CALIBRATION DATE") + 18)) + " 00:00:00.000";
                                    }
                                }
                            }
                            else if (currentText.IndexOf("CERT NUMBER") > 1)
                            {
                                if (currentText.LastIndexOf("PARALLELISM") > -1)
                                {
                                    if (currentText.IndexOf("IN TOLERANCE") > -1)
                                    {
                                        int firsttest = currentText.LastIndexOf("PARALLELISM");
                                        int secondtest = currentText.LastIndexOf("IN TOLERANCE");

                                        if (firsttest < secondtest)
                                        {
                                            string f = currentText.Substring(currentText.IndexOf("06455") + 6,
                                                currentText.IndexOf("ONSITE") - (currentText.IndexOf("06455")));
                                            string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                            string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                            string j = h.Substring(h.IndexOf("\n") + 1, h.Length - (h.IndexOf("\n") + 1));
                                            certNumber = j.Substring(0, j.IndexOf("\n"));

                                            item = h.Substring(0, h.IndexOf("\n"));

                                            string d = currentText.Substring(currentText.LastIndexOf("IN TOLERANCE") + 17, 15);
                                            dateID = d.Substring(0, d.IndexOf("\n"));
                                        }
                                        else
                                        {
                                            string f = currentText.Substring(currentText.IndexOf("06455") + 6,
                                                currentText.IndexOf("ONSITE") - (currentText.IndexOf("06455")));
                                            string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                            string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                            item = h.Substring(0, h.IndexOf("\n"));

                                            string j = currentText.Substring(firsttest + 12,
                                                currentText.LastIndexOf("ZYGO") - (firsttest + 12));
                                            certNumber = j.Substring(j.IndexOf("\n") + 1, j.Length - (j.IndexOf("\n") + 1));

                                            string d = currentText.Substring(currentText.LastIndexOf("REVIEWED BY") + 12, 25);
                                            dateID = d.Substring(0, d.IndexOf("\n"));
                                        }
                                    }
                                    else  //PASS
                                    {
                                        if (currentText.IndexOf("06455") > -1)
                                        {
                                            if (currentText.IndexOf("06455") < currentText.IndexOf("ONSITE"))
                                            {
                                                string f = currentText.Substring(currentText.IndexOf("06455") + 6,
                                                        currentText.IndexOf("ONSITE") - (currentText.IndexOf("06455")));
                                                string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                                string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                                string j = h.Substring(h.IndexOf("\n") + 1, h.Length - (h.IndexOf("\n") + 1));
                                                item = j.Substring(0, j.IndexOf("\n"));

                                                string d = currentText.Substring(currentText.LastIndexOf("REVIEWED BY") + 12, 25);
                                                dateID = d.Substring(0, d.IndexOf("\n"));

                                                string a = currentText.Substring(currentText.IndexOf("PARALLELISM") + 12,
                                                        currentText.IndexOf("ZYGO") - (currentText.IndexOf("PARALLELISM")));
                                                string b = a.Substring(a.IndexOf("\n") + 1, a.Length - (a.IndexOf("\n") + 1));
                                                certNumber = b.Substring(0, b.IndexOf("\n"));
                                            }
                                            else  //currentText.IndexOf("06455") > currentText.IndexOf("ONSITE"))
                                            {
                                                string c = currentText.Substring(currentText.IndexOf("WRITTEN APPROVAL FROM HOLTS PRECISION") + 44, 50);
                                                item = c.Substring(0, c.IndexOf("\n"));

                                                string d = currentText.Substring(currentText.LastIndexOf("REVIEWED BY") + 12, 25);

                                                if (d.IndexOf("\n") < 12)
                                                {
                                                    dateID = d.Substring(0, d.IndexOf("\n"));
                                                }
                                                else
                                                {
                                                    dateID = d.Substring(0, d.IndexOf(" "));
                                                }

                                                string a = currentText.Substring(currentText.IndexOf("PARALLELISM") + 12,
                                                        currentText.IndexOf("ZYGO") - (currentText.IndexOf("PARALLELISM")));
                                                string b = a.Substring(a.IndexOf("\n") + 1, a.Length - (a.IndexOf("\n") + 1));
                                                certNumber = b.Substring(0, b.IndexOf("\n"));

                                            }
                                        }
                                        else
                                        {
                                            string c = currentText.Substring(currentText.IndexOf("WRITTEN APPROVAL FROM HOLTS PRECISION") + 44, 50);
                                            item = c.Substring(0, c.IndexOf("\n"));

                                            string d = currentText.Substring(currentText.LastIndexOf("REVIEWED BY") + 12, 25);

                                            if (d.IndexOf("\n") < 12)
                                            {
                                                dateID = d.Substring(0, d.IndexOf("\n"));
                                            }
                                            else
                                            {
                                                dateID = d.Substring(0, d.IndexOf(" "));
                                            }

                                            string a = currentText.Substring(currentText.IndexOf("PARALLELISM") + 12,
                                                    currentText.IndexOf("ZYGO") - (currentText.IndexOf("PARALLELISM")));
                                            string b = a.Substring(a.IndexOf("\n") + 1, a.Length - (a.IndexOf("\n") + 1));
                                            certNumber = b.Substring(0, b.IndexOf("\n"));
                                        }
                                    }
                                }
                                else if ((currentText.IndexOf("ACCURACY") > -1) & (currentText.IndexOf("IN TOL") > -1))
                                {
                                    item = currentText.Substring(
                                                (currentText.IndexOf("ACCURACY") + 9),
                                                currentText.IndexOf("IN TOL") - (currentText.IndexOf("ACCURACY") + 10));
                                    string W1 = currentText.Substring(currentText.IndexOf("IN TOL") + 13, 50);
                                    certNumber = W1.Substring(0, W1.IndexOf("\n"));

                                    if (currentText.IndexOf("06455") > -1)
                                    {
                                        string s1 = currentText.Substring((currentText.IndexOf("06455") + 6),currentText.Length - currentText.IndexOf("06455") - 6);
                                        string s2 = s1.Substring(s1.IndexOf("\n") + 1, s1.Length - s1.IndexOf("\n") - 1);
                                        string s3 = s2.Substring(s2.IndexOf("\n") + 1, s2.Length - s2.IndexOf("\n") - 1);
                                        string s4 = s3.Substring(s3.IndexOf("\n") + 1, s3.Length - s3.IndexOf("\n") - 1);
                                        string s5 = s4.Substring(s4.IndexOf("\n") + 1, s4.Length - s4.IndexOf("\n") - 1);
                                        dateID = s5.Substring(0, s5.IndexOf("\n"));
                                        //certNumber = s4.Substring(0, s4.IndexOf("\n") - 1);
                                    }

                                    //string s1 = currentText.Substring(currentText.IndexOf("ONSITE") + 7, 50);
                                    //dateID = s1.Substring(0, s1.IndexOf(" "))
                                    //+ " 00:00:00.000";
                                }
                                else if (currentText.IndexOf("ONSITE") > -1 )
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
                                

                            }
                            else if (currentText.LastIndexOf("BASE FLATNESS") > -1)
                            {
                                string nn = currentText.Substring(currentText.IndexOf("BASE FLATNESS") + 14,
                                    (currentText.IndexOf("ZYGO") - (currentText.IndexOf("BASE FLATNESS"))));

                                if (nn.Length < 50)
                                {
                                    string x = currentText.Substring(currentText.IndexOf("CERTIFICATE OF CALIBRATION"),
                                        (currentText.IndexOf("ZYGO") - (currentText.IndexOf("CERTIFICATE OF CALIBRATION"))));

                                    certNumber = x.Substring(x.LastIndexOf("\n") + 1, x.Length - (x.LastIndexOf("\n") + 2));

                                    string a = currentText.Substring(currentText.IndexOf("06455") + 6, 50);
                                    string b = a.Substring(a.IndexOf("\n") + 1, 40);
                                    string c = b.Substring(b.IndexOf("\n") + 1, 20);

                                    item = c.Substring(0, c.IndexOf("\n"));
                                }
                                else
                                {
                                    certNumber = nn.Substring(nn.IndexOf("\n") + 1, nn.IndexOf("\n"));

                                    string a = currentText.Substring(currentText.IndexOf("WRITTEN APPROVAL FROM HOLTS PRECISION") + 44, 50);
                                    item = a.Substring(0, a.IndexOf("\n"));
                                }

                                string d = currentText.Substring(currentText.LastIndexOf("REVIEWED BY") + 12, 25);

                                if (d.IndexOf("\n") < 12)
                                {
                                    dateID = d.Substring(0, d.IndexOf("\n"));
                                }
                                else
                                {
                                    dateID = d.Substring(0, d.IndexOf(" "));
                                }
                            }
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

                                    string f = currentText.Substring(currentText.IndexOf("06455") + 6,
                                           currentText.IndexOf("PAGE 1 OF 1") - (currentText.IndexOf("06455")));
                                    string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                    string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                    certNumber = h.Substring(0, h.IndexOf("\n"));

                                    string j = currentText.Substring(currentText.IndexOf("SPECIFICATIONS") + 15, 12);
                                    dateID = j.Substring(0, j.IndexOf("\n"));
                                }
                                else
                                {
                                    if (currentText.IndexOf("IN TOLERANCE") > -1)
                                    {
                                        string a = currentText.Substring(currentText.IndexOf("IN INCHES") + 9,
                                            currentText.IndexOf("IN TOLERANCE") - (currentText.IndexOf("IN INCHES") + 9));
                                        string b = a.Substring(a.IndexOf("\n") + 1, a.Length - (a.IndexOf("\n") + 1));
                                        string c = b.Substring(b.IndexOf("\n") + 1, b.Length - (b.IndexOf("\n") + 1));
                                        string d = c.Substring(c.IndexOf("\n") + 1, c.Length - (c.IndexOf("\n") + 1));
                                        item = d.Substring(0, d.IndexOf("\n"));

                                        string f = currentText.Substring(currentText.IndexOf("06455") + 6,
                                            currentText.IndexOf("PAGE 1 OF 1") - (currentText.IndexOf("06455")));
                                        string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                        string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                        certNumber = h.Substring(0, h.IndexOf("\n"));

                                        string j = currentText.Substring(currentText.LastIndexOf("SPECIFICATIONS") + 15, 12);
                                        dateID = j.Substring(0, j.IndexOf("\n"));
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
                                }
                            }
                            else if (currentText.LastIndexOf("JAW PARALLELISM") > -1)
                            {
                                if (currentText.IndexOf("06455") > -1)
                                {
                                    string f = currentText.Substring(currentText.IndexOf("06455") + 6,
                                    currentText.IndexOf("ONSITE") - (currentText.IndexOf("06455")));
                                    string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                    string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                    string j = h.Substring(h.IndexOf("\n") + 1, h.Length - (h.IndexOf("\n") + 1));
                                    string k = j.Substring(j.IndexOf("\n") + 1, j.Length - (j.IndexOf("\n") + 1));
                                    certNumber = k.Substring(0, k.IndexOf("\n"));

                                    item = h.Substring(0, h.IndexOf("\n"));
                                }
                                else
                                {
                                    string f = currentText.Substring(currentText.IndexOf("MIDDLEFIELD") + 15,
                                             currentText.IndexOf("THE MATERIAL") - (currentText.IndexOf("MIDDLEFIELD")));
                                    string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                    string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                    string j = h.Substring(h.IndexOf("\n") + 1, h.Length - (h.IndexOf("\n") + 1));
                                    string k = j.Substring(j.IndexOf("\n") + 1, j.Length - (j.IndexOf("\n") + 1));
                                    string l = k.Substring(k.IndexOf("\n") + 1, k.Length - (k.IndexOf("\n") + 1));
                                    certNumber = l.Substring(0, l.IndexOf("\n"));

                                    item = j.Substring(0, j.IndexOf("\n"));

                                }

                                string d = currentText.Substring(currentText.LastIndexOf("REVIEWED BY") + 12, 25);
                                if (d.IndexOf("\n") < 12)
                                {
                                    dateID = d.Substring(0, d.IndexOf("\n"));
                                }
                                else
                                {
                                    dateID = d.Substring(0, d.IndexOf(" "));
                                }
                            }
                            else if (currentText.LastIndexOf("REPEATABILITY ACCURACY") > -1)
                            {
                                int cc = currentText.IndexOf("06455") + 6;

                                int ccc = currentText.IndexOf("\nCALIBRATION DATE\n");
                                string f = currentText.Substring(currentText.IndexOf("06455") + 6,
                                   currentText.IndexOf("\nCALIBRATION DATE\n") - ((currentText.IndexOf("06455") + 6)));
                                string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                string j = h.Substring(h.IndexOf("\n") + 1, h.Length - (h.IndexOf("\n") + 1));
                                string k = j.Substring(j.IndexOf("\n") + 1, j.Length - (j.IndexOf("\n") + 1));
                                certNumber = k.Substring(0, k.IndexOf("\n"));

                                item = h.Substring(0, h.IndexOf("\n"));

                                string d = currentText.Substring(currentText.LastIndexOf("REVIEWED BY") + 12, 25);
                                if (d.IndexOf("\n") < 12)
                                {
                                    dateID = d.Substring(0, d.IndexOf("\n"));
                                }
                                else
                                {
                                    dateID = d.Substring(0, d.IndexOf(" "));
                                }
                            }
                            else if (currentText.LastIndexOf("\nLINEAR ACCURACY\n") > -1)
                            {
                                string c = currentText.Substring(currentText.IndexOf("WRITTEN APPROVAL FROM HOLTS PRECISION") + 44, 50);
                                item = c.Substring(0, c.IndexOf("\n"));


                                string f = currentText.Substring(currentText.IndexOf("\nLINEAR ACCURACY\n") + 16,
                                   currentText.IndexOf("ZYGO") - ((currentText.IndexOf("\nLINEAR ACCURACY\n"))));
                                string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                certNumber = h.Substring(0, h.IndexOf("\n"));

                                string d = currentText.Substring(currentText.LastIndexOf("REVIEWED BY") + 12, 25);
                                if (d.IndexOf("\n") < 12)
                                {
                                    dateID = d.Substring(0, d.IndexOf("\n"));
                                }
                                else
                                {
                                    dateID = d.Substring(0, d.IndexOf(" "));
                                }
                            }

                            /*
                             * if (currentText.IndexOf("CERT NUMBER") < 1)
                            {
                                if ((currentText.IndexOf("SURFACE PLATE") > -1))
                                {
                                    int NN = (currentText.IndexOf("\nMASTER DUE DATE\n"));

                                    if (currentText.IndexOf("SURFACE PLATE") > (currentText.IndexOf("06455")))
                                    {
                                        string f = currentText.Substring(currentText.IndexOf("CUSTOMER ZYGO") + 14,
                                                currentText.IndexOf("06455") - (currentText.IndexOf("CUSTOMER ZYGO")));
                                        string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                        string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                        certNumber = h.Substring(0, h.IndexOf("\n"));
                                    }
                                    else
                                    {
                                        string f = currentText.Substring(currentText.IndexOf("\nMASTER DUE DATE\n") + 16,
                                            currentText.IndexOf("06455") - (currentText.IndexOf("\nMASTER DUE DATE\n")));
                                        string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                        string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                        certNumber = h.Substring(0, h.IndexOf("\n"));
                                    }

                                    item = currentText.Substring(0, currentText.IndexOf("\n"));

                                    string d = currentText.Substring(currentText.LastIndexOf("HPI-510") + 8, 11);
                                    if (d.IndexOf("\n") < 12)
                                    {
                                        dateID = d.Substring(0, d.IndexOf("\n"));
                                    }
                                    else
                                    {
                                        dateID = d.Substring(0, d.IndexOf(" "));
                                    }


                                }
                                else
                                {
                                    certNumber = currentText.Substring(
                                        (currentText.IndexOf("CERT NO.") + 9),
                                        currentText.IndexOf("ADDRESS MASTER") - (currentText.IndexOf("CERT NO.") + 10));


                                    if (currentText.IndexOf("GAGE TYPE") < currentText.IndexOf("GAGE ID"))
                                    {
                                        item = currentText.Substring(
                                            (currentText.IndexOf("GAGE ID") + 8),
                                            currentText.IndexOf("NIST TRACE #") - (currentText.IndexOf("GAGE ID") + 9));
                                        dateID = currentText.Substring(
                                            (currentText.IndexOf("CALIBRATION DATE") + 17),
                                             currentText.IndexOf("CALIBRATED BY") -
                                             (currentText.IndexOf("CALIBRATION DATE") + 18)) + " 00:00:00.000";
                                    }
                                    else
                                    {
                                        item = currentText.Substring(
                                            (currentText.IndexOf("GAGE ID") + 8),
                                            currentText.IndexOf("MASTER DUE") - (currentText.IndexOf("GAGE ID") + 9));
                                        dateID = currentText.Substring(
                                            (currentText.IndexOf("CALIBRATION DATE") + 17),
                                             currentText.IndexOf("CALIBRATED BY") -
                                             (currentText.IndexOf("CALIBRATION DATE") + 18)) + " 00:00:00.000";
                                    }
                                }
                            }
                            else if (currentText.IndexOf("CERT NUMBER") > 1)
                            {
                                if (currentText.LastIndexOf("PARALLELISM") > -1)
                                {
                                    if (currentText.IndexOf("IN TOLERANCE") > -1)
                                    {
                                        int firsttest = currentText.LastIndexOf("PARALLELISM");
                                        int secondtest = currentText.LastIndexOf("IN TOLERANCE");

                                        if (firsttest < secondtest)
                                        {
                                            string f = currentText.Substring(currentText.IndexOf("06455") + 6,
                                                currentText.IndexOf("ONSITE") - (currentText.IndexOf("06455")));
                                            string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                            string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                            string j = h.Substring(h.IndexOf("\n") + 1, h.Length - (h.IndexOf("\n") + 1));
                                            certNumber = j.Substring(0, j.IndexOf("\n"));

                                            item = h.Substring(0, h.IndexOf("\n"));

                                            string d = currentText.Substring(currentText.LastIndexOf("IN TOLERANCE") + 17, 15);
                                            dateID = d.Substring(0, d.IndexOf("\n"));
                                        }
                                        else
                                        {
                                            string f = currentText.Substring(currentText.IndexOf("06455") + 6,
                                                currentText.IndexOf("ONSITE") - (currentText.IndexOf("06455")));
                                            string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                            string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                            item = h.Substring(0, h.IndexOf("\n"));

                                            string j = currentText.Substring(firsttest + 12,
                                                currentText.LastIndexOf("ZYGO") - (firsttest + 12));
                                            certNumber = j.Substring(j.IndexOf("\n") + 1, j.Length - (j.IndexOf("\n") + 1));

                                            string d = currentText.Substring(currentText.LastIndexOf("REVIEWED BY") + 12, 25);
                                            dateID = d.Substring(0, d.IndexOf("\n"));
                                        }
                                    }
                                    else  //PASS
                                    {
                                        if (currentText.IndexOf("06455") > -1)
                                        {
                                            if (currentText.IndexOf("06455") < currentText.IndexOf("ONSITE"))
                                            {
                                                string f = currentText.Substring(currentText.IndexOf("06455") + 6,
                                                        currentText.IndexOf("ONSITE") - (currentText.IndexOf("06455")));
                                                string g = f.Substring(f.IndexOf("\n") + 1, f.Length - (f.IndexOf("\n") + 1));
                                                string h = g.Substring(g.IndexOf("\n") + 1, g.Length - (g.IndexOf("\n") + 1));
                                                string j = h.Substring(h.IndexOf("\n") + 1, h.Length - (h.IndexOf("\n") + 1));
                                                item = j.Substring(0, j.IndexOf("\n"));

                                                string d = currentText.Substring(currentText.LastIndexOf("REVIEWED BY") + 12, 25);
                                                dateID = d.Substring(0, d.IndexOf("\n"));

                                                string a = currentText.Substring(currentText.IndexOf("PARALLELISM") + 12,
                                                        currentText.IndexOf("ZYGO") - (currentText.IndexOf("PARALLELISM")));
                                                string b = a.Substring(a.IndexOf("\n") + 1, a.Length - (a.IndexOf("\n") + 1));
                                                certNumber = b.Substring(0, b.IndexOf("\n"));
                                            }
                                            else  //currentText.IndexOf("06455") > currentText.IndexOf("ONSITE"))
                                            {
                                                string c = currentText.Substring(currentText.IndexOf("WRITTEN APPROVAL FROM HOLTS PRECISION") + 44, 50);
                                                item = c.Substring(0, c.IndexOf("\n"));

                                                string d = currentText.Substring(currentText.LastIndexOf("REVIEWED BY") + 12, 25);

                                                if (d.IndexOf("\n") < 12)
                                                {
                                                    dateID = d.Substring(0, d.IndexOf("\n"));
                                                }
                                                else
                                                {
                                                    dateID = d.Substring(0, d.IndexOf(" "));
                                                }

                                                string a = currentText.Substring(currentText.IndexOf("PARALLELISM") + 12,
                                                        currentText.IndexOf("ZYGO") - (currentText.IndexOf("PARALLELISM")));
                                                string b = a.Substring(a.IndexOf("\n") + 1, a.Length - (a.IndexOf("\n") + 1));
                                                certNumber = b.Substring(0, b.IndexOf("\n"));

                                            }
                                        }
                                        else
                                        {
                                            string c = currentText.Substring(currentText.IndexOf("WRITTEN APPROVAL FROM HOLTS PRECISION") + 44, 50);
                                            item = c.Substring(0, c.IndexOf("\n"));

                                            string d = currentText.Substring(currentText.LastIndexOf("REVIEWED BY") + 12, 25);

                                            if (d.IndexOf("\n") < 12)
                                            {
                                                dateID = d.Substring(0, d.IndexOf("\n"));
                                            }
                                            else
                                            {
                                                dateID = d.Substring(0, d.IndexOf(" "));
                                            }

                                            string a = currentText.Substring(currentText.IndexOf("PARALLELISM") + 12,
                                                    currentText.IndexOf("ZYGO") - (currentText.IndexOf("PARALLELISM")));
                                            string b = a.Substring(a.IndexOf("\n") + 1, a.Length - (a.IndexOf("\n") + 1));
                                            certNumber = b.Substring(0, b.IndexOf("\n"));
                                        }
                                    }
                                }
                            
                             * 
                             * 
                             * */

                        }

                        if (currentText.IndexOf("* DENOTES") < 0)  //cal-tek
                        {
                            if (currentText.LastIndexOf("CAL-TEK") > -1)
                            {
                                if (currentText.LastIndexOf("PASS") != -1)
                                {
                                    int start = currentText.LastIndexOf("PASS") + 5;
                                    string next = currentText.Substring(start, 25);
                                    int end = next.IndexOf(",");
                                    end = end + 6;
                                    dateID = currentText.Substring(start, end);
                                    //use indexof starting with the start position
                                    //string test = currentText.Substring(start, (end - start));

                                    item = currentText.Substring(
                                        (currentText.LastIndexOf("ASSET #:") + 9),
                                        currentText.LastIndexOf("DUE DATE ASSET #") - (currentText.LastIndexOf("ASSET #:") + 10));

                                    certNumber = currentText.Substring(
                                        (currentText.IndexOf("CERTIFICATE NO.") + 16),
                                        currentText.IndexOf("SITE LOCATION:") - (currentText.IndexOf("CERTIFICATE NO.") + 17));
                                }
                                else
                                {
                                    int start = currentText.IndexOf("OF CALIBRATION") + 15;
                                    string next = currentText.Substring(start, 15);
                                    int end = next.IndexOf("\n");
                                    dateID = currentText.Substring(start, end);
                                    //use indexof starting with the start position
                                    //string test = currentText.Substring(start, (end - start));

                                    item = currentText.Substring(
                                        (currentText.IndexOf("\n") + 1),
                                        currentText.IndexOf("PROCEDURE") - (currentText.IndexOf("\n") + 2));

                                    certNumber = currentText.Substring(
                                        (currentText.IndexOf("CERTIFICATE NO.") + 16),
                                        currentText.IndexOf("SITE LOCATION:") - (currentText.IndexOf("CERTIFICATE NO.") + 17));
                                }
                            }
                        }

                        SqlConnection cnxn = new SqlConnection(db);
                        cnxn.Open();
                        SqlCommand cmd = new SqlCommand
                            ("select id from calibrationdata where item = '" + item + "' and " +
                             "cal_date = '" + dateID + " ';", cnxn);

                        int o = (int)cmd.ExecuteScalar();

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

                        


                        if (o > 0  & existingCert == "")
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

                        //File.AppendAllText(@"C:\a\aabpdftest.txt", currentText + Environment.NewLine);
                        //text.Append(currentText);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //StringBuilder text = new StringBuilder();
            ////PdfReader pdfReader = new PdfReader(@"C:\a\zygze553.pdf");
            //PdfReader pdfReader = new PdfReader(@"C:\a\ZOQC995 Caliper .001-8.000.pdf");

            //for (int page = 1; page <= pdfReader.NumberOfPages; page++)
            //{
            //    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
            //    string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);

            //    currentText = Encoding.UTF8.GetString
            //        (ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
            //    File.AppendAllText(@"C:\a\bpdftest.txt", currentText + Environment.NewLine);
            //    //text.Append(currentText);
            //}
            //pdfReader.Close();
        }
    }
}
