using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Drawing.Printing;
using System.Data.SqlClient;
using MetroproXLicenseDLL;
using System.IO;


namespace AutoLicense
{
    public partial class s1_WebData : Form
    {
        private string timestamp;
        private string dongleID;
        private string application;
        private string customer;
        private string email;
        private string ZygoLicense;
        private string firstName;
        private string[] lines;
        private int instrumentCount = 0;
        SqlConnection cnxn;
        SqlDataReader dr;
        SqlDataAdapter da;
        private string db = "server = CT-MID-SQL01.zygo.com; user = ReadWriteAttach; password = A!!ac8This; " +
                            "database = ZygoProductLicenses;";
        MetroproXLicense MX = new MetroproXLicense();
        DataTable dt1;
        DataTable table;
        DataTable dt2;
        private int j = 0;
        private int pagesPrinted = 0;
        private int sleepytime = 200;
        private Image img;
        private bool detailsNeedPrinting = true;

        public s1_WebData()
        {
            InitializeComponent();

            /*
             * This is the form the user would fill out to request a license...
                https://www.zygo.com/?/met/MxLicenseRequest.htm

                This is the TSV data file that gets appended with each form submission...
                https://www.zygo.com/zygomxlicense/data1.txt
             * 
             * */
        }

        private void s1_WebData_Load(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\A\writetest.txt", "This works " + Environment.NewLine);
            WebClient client = new WebClient();

            //    /*
            //     * look for the place where I split the data and put it in an array
            //     * */

            try
            {
                string webdata = client.DownloadString("http://www.zygo.com/zygomxlicense/data1.txt");

                lines = webdata.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Web Data  " + ex.ToString());
            }

            /* for debugging set i = 169    */
            for (int i = 169;i < 170; i++)
            //for (int i = 0; i < (lines.Length - 1); i++)
            {
                string line = lines[i];

                if (lines[i].Length > 0)
                {
                    timestamp = line.Substring(0, line.IndexOf("\t"));
                    timestamp = timestamp.Replace("T", " ");
                    timestamp = timestamp.Replace("Z", ".000");

                    cnxn = new SqlConnection(db);
                    
                    SqlCommand cmd = new SqlCommand(
                        "SELECT orderdate FROM " +
                        "LicenseData WHERE " +
                        "orderdate  = '" + timestamp + "'", cnxn);
                    cnxn.Open();
                    object o = cmd.ExecuteScalar();
                    cnxn.Close();

                    /* for debugging set o to null */
                    o = null;

                    File.AppendAllText(@"C:\A\writetest.txt", "104 " + Environment.NewLine);

                    /*
                     * using the order date from the web to make sure only new orders get entered.
                     * if the object is null ( if there is no match on the order date) then generate license and insert into database
                     */

                    if (o == null)
                    {
                        detailsNeedPrinting = true;
                        line = line.Substring(line.IndexOf("\t") + 1, line.Length - line.IndexOf("\t") - 1);
                        dongleID = line.Substring(0, line.IndexOf("\t"));
                        line = line.Substring(line.IndexOf("\t") + 1, line.Length - line.IndexOf("\t") - 1);
                        application = line.Substring(0, line.IndexOf("\t"));
                        line = line.Substring(line.IndexOf("\t") + 1, line.Length - line.IndexOf("\t") - 1);
                        customer = line.Substring(0, line.IndexOf("\t"));

                        SqlParameter pOwner = new SqlParameter("@owner", SqlDbType.NChar);
                        pOwner.Value = customer;
                        if (pOwner.Value is null)
                        {
                            pOwner.Value = "";
                        }

                        line = line.Substring(line.IndexOf("\t") + 1, line.Length - line.IndexOf("\t") - 1);
                        email = line.Substring(0, line.IndexOf("\t"));
                        line = line.Substring(line.IndexOf("\t") + 1, line.Length - line.IndexOf("\t") - 1);
                        firstName = line.Substring(0, line.IndexOf("\t"));

                        application = application.Replace("Mx", "MetroProX");

                        int nn = dongleID.Length;

                        try
                        {
                            ZygoLicense = MX.GenerateMetroproLicenseKey(
                            dongleID,
                            application,
                            DateTime.Now.ToShortDateString(),
                            DateTime.Now.AddYears(1).ToShortDateString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("DLL error  " + ex.ToString());
                        }


                        if (ZygoLicense.Substring(0, 5) == "ERROR")
                        {
                            cnxn.Open();

                            SqlParameter pEmailTo = new SqlParameter("@pEmailTo", SqlDbType.NVarChar);
                            pEmailTo.Value = email;
                            //SqlParameter pEmailCopyTo = new SqlParameter("@pEmailCopyTo", SqlDbType.NVarChar);
                            //pEmailCopyTo.Value = emailcopyto;
                            SqlParameter pEmailSubject = new SqlParameter("@pEmailSubject", SqlDbType.NVarChar);
                            pEmailSubject.Value = "The MX License you requested cannot be generated";

                            SqlParameter pEmailBody = new SqlParameter("@pEmailBody", SqlDbType.NVarChar);
                            pEmailBody.Value = "Dear " + firstName + "," + "</p>" +
                            "<p>Thank you for contacting us regarding your request for the stand-alone data analysis use of Mx software. " +
                            "Unfortunately, we are not able to fulfill your request at this time as " +
                            "the hardware ID that you provided is incorrect.  " +
                            "Please re-submit the form with the hardwqare ID associated with the installation of Mx that " +
                            "you would like to use only for data analysis.</p>" +
                            "<p></p>" +
                            "<p>If you would like to update the Mx software for your metrology system, please contact your Zygo " +
                            "sales representative , or send a message to inquire@zygo.com for assistance.</p>" +
                            "<p></p>" +
                            "<p>Best Regards, </p>" +
                            "<p>ZYGO Customer Support Team</p>";

                            SqlParameter pEmailFrom = new SqlParameter("@pEmailFrom", SqlDbType.NVarChar);
                            pEmailFrom.Value = "inquiry@zygo.com";

                            cmd = new SqlCommand("Insert into EmailNoAttachments " +
                                 " (EmailTo " +
                                 //" ,EmailCopyto " +
                                 " ,EmailSubject " +
                                 " ,EmailBody" +
                                 " ,EmailFrom" +
                                 " ) " +
                                 " values " +
                                 " ( " + pEmailTo +
                                 // " , " + pEmailCopyTo +
                                 " , " + pEmailSubject +
                                 " , " + pEmailBody +
                                 " , " + pEmailFrom +
                                 " )", cnxn);
                            cmd.Parameters.Add(pEmailTo);
                            //cmd.Parameters.Add(pEmailCopyTo);
                            cmd.Parameters.Add(pEmailSubject);
                            cmd.Parameters.Add(pEmailBody);
                            cmd.Parameters.Add(pEmailFrom);

                            try
                            {
                                int rowsReturned = cmd.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            finally
                            {
                                cnxn.Close();
                                cmd.Parameters.Clear();
                            }

                        }
                        else
                        {
                            cmd = new SqlCommand(
                                "INSERT INTO LicenseData (" +
                                "productline " +
                                ",licensenumber " +
                                ",dongleid " +
                                ",application " +
                                ",startdate " +
                                ",expirationdate " +
                                ",salesorder " +
                                ",activedemo " +
                                ",owner" +
                                ",orderdate) " +
                                "values ( " +
                                "'MX'" +
                                ",'" + ZygoLicense +
                                "','" + dongleID +
                                "','" + application +
                                "','" + DateTime.Now.ToShortDateString() +
                                "','" + DateTime.Now.AddYears(1).ToShortDateString() +
                                "','0'," +
                                "'A'," +
                                pOwner +
                                ",'" + timestamp + "')", cnxn);

                            try
                            {
                                cnxn.Open();
                                cmd.Parameters.Add(pOwner);
                                int returnd = cmd.ExecuteNonQuery();
                                File.AppendAllText(@"C:\A\writetest.txt", "245 " + Environment.NewLine);
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show("156 SQL " + ex.ToString());
                            }
                            finally
                            {
                                cmd.Parameters.Clear();
                                cnxn.Close();
                            }

                            /*
                             *  Need to print license to pdf and send to customer or zygo.applications
                             * 
                             */

                            cnxn.Open();

                            string SQLlicenseDetail =
                            "select " +
                            " [Dongle ID] " +
                            ", Application " +
                            ",[Start Date] " +
                            ",[Expiration Date] " +
                            ", License " +
                            "from " +
                            "DongleFullDetails " +
                            "WHERE [Dongle ID] = @DongleID " +
                            "AND ProductLine = 'MX' ";


                            ///*  First get the primary application data so that it is always on the first line     */

                            cmd = new SqlCommand(SQLlicenseDetail +
                                        "AND application like 'Metro%' ORDER by application DESC", cnxn);
                            cmd.Parameters.Add("@DongleID", SqlDbType.NVarChar).Value = dongleID;


                            table = new DataTable();
                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = cmd;
                            da.Fill(table);

                            ///*  Then get the secondary application data    */

                            cmd = new SqlCommand(SQLlicenseDetail +
                                "AND application not like 'Metro%' ORDER by application DESC", cnxn);
                            cmd.Parameters.Add("@DongleID", SqlDbType.NVarChar).Value = dongleID;

                            dt2 = new DataTable();
                            da = new SqlDataAdapter();
                            da.SelectCommand = cmd;

                            try
                            {
                                da.Fill(dt2);
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show("212 SQL " + ex.ToString());
                            }

                            cnxn.Close();

                            cmd = new SqlCommand("Select Top (1) owner from DongleFullDetails WHERE [Dongle ID] = '" + dongleID + "' " +
                                "ORDER BY [Start Date] desc", cnxn);

                            cnxn.Open();

                            try
                            {
                                customer = (string)cmd.ExecuteScalar();
                                File.AppendAllText(@"C:\A\writetest.txt", "318 " + Environment.NewLine);
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show("228 SQL " + ex.ToString());
                            }
                            finally
                            {
                                cnxn.Close();
                            }


                            ///*   then combine the two tables           */

                            foreach (DataRow row in dt2.Rows)
                            {
                                table.Rows.Add(row.ItemArray);
                            }

                            j = table.Rows.Count;
                            
                            PrintDocument pd = new PrintDocument();
                            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                            pd.DefaultPageSettings.PrinterSettings.PrinterName = "Microsoft Print to PDF";

                            /*  the executable runs on CT-MID-NAVREP in the MacroScheduler program
                             *  Bill Bacon runs the program so CT-MID-SQL01\a needed to be shared to 
                             *  Bill with Read/Write permissions
                             */
                            //pd.PrinterSettings.PrintFileName = @"C:\Zygo License Generator\license.pdf";
                            pd.PrinterSettings.PrintFileName = @"\\CT-MID-SQL01.zygo.com\A\license.pdf";
                            pd.PrinterSettings.PrintToFile = true;

                            StandardPrintController pc = new StandardPrintController();
                            pd.PrintController = pc;
                            File.AppendAllText(@"C:\A\writetest.txt", "353 " + Environment.NewLine);

                            try
                            {
                                pd.Print();
                                /* Sleep uses miliseconds.  Add time to let the printing complete  */
                                System.Threading.Thread.Sleep(sleepytime);
                                File.AppendAllText(@"C:\A\writetest.txt", "360 " + Environment.NewLine);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Print  " + ex.ToString());
                            }

                            /*
                             *  If dongle ID is associated with an Instrument license then do not send to customer - 
                             *  send email from zygo.applications@ametek.com
                             *  
                             *  send pdf of license to zygo.applications and local rep
                             *
                             */

                            cmd = new SqlCommand(
                            "SELECT COUNT(application) FROM " +
                            "LicenseData WHERE Application = 'Instrument' AND " +
                            "DongleID  = '" + dongleID + "'", cnxn);
                                                        
                            try
                            {
                                cnxn.Open();
                                instrumentCount = (int)cmd.ExecuteScalar();
                                File.AppendAllText(@"C:\A\writetest.txt", "384 " + Environment.NewLine);
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show("line 374 " + ex.ToString());
                            }
                            finally
                            {
                                cnxn.Close();
                            }
                            //if the object is null then send license to customer

                            if (instrumentCount > 0)
                            {
                                File.AppendAllText(@"C:\A\lftest.txt", instrumentCount.ToString());
                                File.AppendAllText(@"C:\A\writetest.txt", "399 " + Environment.NewLine);

                                cnxn.Open();

                                SqlParameter pEmailTo = new SqlParameter("@pEmailTo", SqlDbType.NVarChar);
                                pEmailTo.Value = email;
                                //SqlParameter pEmailCopyTo = new SqlParameter("@pEmailCopyTo", SqlDbType.NVarChar);
                                //pEmailCopyTo.Value = emailcopyto;
                                SqlParameter pEmailSubject = new SqlParameter("@pEmailSubject", SqlDbType.NVarChar);
                                pEmailSubject.Value = "The MX License you requested cannot be generated";

                                SqlParameter pEmailBody = new SqlParameter("@pEmailBody", SqlDbType.NVarChar);
                                pEmailBody.Value = "Dear " + firstName + "," + "</p>" +
                                "<p>Thank you for contacting us regarding your request for the stand-alone data analysis use of Mx software. " +
                                "Unfortunately, we are not able to fulfill your request at this time as our records indicate that " +
                                "the hardware ID that you provided is associated with a metrology system.  " +
                                "Please re-submit the form with the hardwqare ID associated with the installation of Mx that " +
                                "you would like to use only for data analysis (not connected to a metrology system).</p>" +
                                "<p></p>" +
                                "<p>If you would like to update the Mx software for your metrology system, please contact your Zygo " +
                                "sales representative , or send a message to inquire@zygo.com for assistance.</p>" +
                                "<p></p>" +
                                "<p>Best Regards, </p>" +
                                "<p>ZYGO Customer Support Team</p>";

                                SqlParameter pEmailFrom = new SqlParameter("@pEmailFrom", SqlDbType.NVarChar);
                                pEmailFrom.Value = "inquiry@zygo.com";

                                cmd = new SqlCommand("Insert into EmailNoAttachments " +
                                     " (EmailTo " +
                                     //" ,EmailCopyto " +
                                     " ,EmailSubject " +
                                     " ,EmailBody" +
                                     " ,EmailFrom" +
                                     " ) " +
                                     " values " +
                                     " ( " + pEmailTo +
                                     // " , " + pEmailCopyTo +
                                     " , " + pEmailSubject +
                                     " , " + pEmailBody +
                                     " , " + pEmailFrom +
                                     " )", cnxn);
                                cmd.Parameters.Add(pEmailTo);
                                //cmd.Parameters.Add(pEmailCopyTo);
                                cmd.Parameters.Add(pEmailSubject);
                                cmd.Parameters.Add(pEmailBody);
                                cmd.Parameters.Add(pEmailFrom);

                                try
                                {
                                    int rowsReturned = cmd.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                                finally
                                {
                                    cnxn.Close();
                                    cmd.Parameters.Clear();
                                }

                                /*
                                 * 
                                 * email to inquire with license
                                 * 
                                 */

                                cnxn.Open();

                                //SqlParameter pEmailTo = new SqlParameter("@pEmailTo", SqlDbType.NVarChar);


                                pEmailTo.Value = "inquire@zygo.com";
                                //pEmailTo.Value = "tor.hepburn@ametek.com";

                                //SqlParameter pEmailCopyTo = new SqlParameter("@pEmailCopyTo", SqlDbType.NVarChar);
                                //pEmailCopyTo.Value = emailcopyto;
                                //SqlParameter pEmailSubject = new SqlParameter("@pEmailSubject", SqlDbType.NVarChar);
                                pEmailSubject.Value = "Mx Software License Requested by Customer with Instrument";
                                //SqlParameter pEmailBody = new SqlParameter("@pEmailBody", SqlDbType.NVarChar);
                                pEmailBody.Value = //"Your license number for your Dongle ID " + dongleID + " is:  " + ZygoLicense;

                                "Dear Zygo Applications,</p>" +
                                "<p>Below please find the license information which was requested by " + email + " for a data analysis version of ZYGO's Mx™ software. </p>" +
                                "<html><body><table border='0' cellpadding='1'>" +
                                "<tr><td width ='40' height='50'></td><td width='100'>Hardware ID:     </td><td>" + dongleID + "</td></tr>" +
                                "<tr><td height='40'></td><td>Option:</td><td>" + application + "</td></tr>" +
                                "<tr><td height='40'></td><td>Start Date:</td><td>" + DateTime.Now.ToShortDateString() + "</td></tr>" +
                                "<tr><td height='40'></td><td>End Date:</td><td>" + DateTime.Now.AddYears(1).ToShortDateString() + "</td></tr>" +
                                "<tr><td height='40'></td><td>Key:</td><td>" + ZygoLicense + "</td></tr></tr></table>" +
                                "<p></p>" +
                                "<p>Best Regards, </p>" +
                                "<p>ZYGO Customer Support Team</p>";


                                //SqlParameter pEmailFrom = new SqlParameter("@pEmailFrom", SqlDbType.NVarChar);
                                pEmailFrom.Value = "donotreply@zygo.com";

                                cmd = new SqlCommand("Insert into Email " +
                                     " (EmailTo " +
                                     //" ,EmailCopyto " +
                                     " ,EmailSubject " +
                                     " ,EmailBody" +
                                     " ,EmailFrom) " +
                                     " values " +
                                     " ( " + pEmailTo +
                                     // " , " + pEmailCopyTo +
                                     " , " + pEmailSubject +
                                     " , " + pEmailBody +
                                     " , " + pEmailFrom +
                                     " )", cnxn);
                                cmd.Parameters.Add(pEmailTo);
                                //cmd.Parameters.Add(pEmailCopyTo);
                                cmd.Parameters.Add(pEmailSubject);
                                cmd.Parameters.Add(pEmailBody);
                                cmd.Parameters.Add(pEmailFrom);

                                try
                                {
                                    int rowsReturned = cmd.ExecuteNonQuery();
                                    //File.AppendAllText(@"c:\a\emailSQLtest.txt", emSubject + Environment.NewLine + DateTime.Now.ToString() +
                                    //    emailto + Environment.NewLine);
                                }
                                catch (SqlException ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                                finally
                                {
                                    cnxn.Close();
                                    cmd.Parameters.Clear();
                                }

                            }
                            else
                            {
                                cnxn.Open();

                                SqlParameter pEmailTo = new SqlParameter("@pEmailTo", SqlDbType.NVarChar);
                                pEmailTo.Value = email;
                                //SqlParameter pEmailCopyTo = new SqlParameter("@pEmailCopyTo", SqlDbType.NVarChar);
                                //pEmailCopyTo.Value = emailcopyto;
                                SqlParameter pEmailSubject = new SqlParameter("@pEmailSubject", SqlDbType.NVarChar);
                                pEmailSubject.Value = "Mx Software License You Requested from ZYGO";
                                SqlParameter pEmailBody = new SqlParameter("@pEmailBody", SqlDbType.NVarChar);
                                pEmailBody.Value = //"Your license number for your Dongle ID " + dongleID + " is:  " + ZygoLicense;

                                "Dear " + firstName + "," + "</p>" +
                                "<p>Below please find the license information you requested for a data analysis version of ZYGO's Mx™ software. </p>" +
                                "<html><body><table border='0' cellpadding='1'>" +
                                "<tr><td width ='40' height='50'></td><td width='100'>Hardware ID:     </td><td>" + dongleID + "</td></tr>" +
                                "<tr><td height='40'></td><td>Option:</td><td>" + application + "</td></tr>" +
                                "<tr><td height='40'></td><td>Start Date:</td><td>" + DateTime.Now.ToShortDateString() + "</td></tr>" +
                                "<tr><td height='40'></td><td>End Date:</td><td>" + DateTime.Now.AddYears(1).ToShortDateString() + "</td></tr>" +
                                "<tr><td height='40'></td><td>Key:</td><td>" + ZygoLicense + "</td></tr></tr></table>" +
                                "<p>Please note that a new license will be required beyond this date range or if a different version of " +
                                "Mx software is installed.If you have not already done so, Mx™ software may be downloaded from <a href='https://www.zygo.com/?sup=/resource/software.cgi'>HERE</a>.</p>" +
                                "<p>If you have any questions about the license, please contact Zygo Customer Support:  support@zygo.com</p>" +
                                "<p>or use this <a href='https://www.zygo.com/?/met/support/supform.htm'>form</a>.</p>" +
                                "<p></p>" +
                                "<p>Best Regards, </p>" +
                                "<p>ZYGO Customer Support Team</p>";

                                SqlParameter pEmailFrom = new SqlParameter("@pEmailFrom", SqlDbType.NVarChar);
                                pEmailFrom.Value = "donotreply@zygo.com";

                                cmd = new SqlCommand("Insert into Email " +
                                     " (EmailTo " +
                                     //" ,EmailCopyto " +
                                     " ,EmailSubject " +
                                     " ,EmailBody" +
                                     " ,EmailFrom) " +
                                     " values " +
                                     " ( " + pEmailTo +
                                     // " , " + pEmailCopyTo +
                                     " , " + pEmailSubject +
                                     " , " + pEmailBody +
                                     " , " + pEmailFrom +
                                     " )", cnxn);
                                cmd.Parameters.Add(pEmailTo);
                                //cmd.Parameters.Add(pEmailCopyTo);
                                cmd.Parameters.Add(pEmailSubject);
                                cmd.Parameters.Add(pEmailBody);
                                cmd.Parameters.Add(pEmailFrom);

                                try
                                {
                                    int rowsReturned = cmd.ExecuteNonQuery();
                                    //File.AppendAllText(@"c:\a\emailSQLtest.txt", emSubject + Environment.NewLine + DateTime.Now.ToString() +
                                    //    emailto + Environment.NewLine);
                                }
                                catch (SqlException ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                                finally
                                {
                                    cnxn.Close();
                                    cmd.Parameters.Clear();
                                }
                            }
                        }

                    }
                }
            }

            this.Close();
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            string date = DateTime.Now.ToShortDateString();
            int linedrop = 200;
            int count = 0;
            int linesPerpage = 50;
            int lineNo = this.pagesPrinted * linesPerpage;
            int pageNo = pagesPrinted + 1;
            double NumPages = Math.Ceiling(((j - 1) / 50.0));
            NumPages = NumPages + 1;
            if (NumPages == 0) { NumPages = 1; }

            Pen pen = new Pen(Color.Black);
            pen.Width = 1;
            Font arial = new Font("arial", 10, FontStyle.Regular);
            Font title = new Font("arial", 30, FontStyle.Regular);
            Font heading = new Font("arial", 16, FontStyle.Bold);
            Font leaders = new Font("arial", 12, FontStyle.Bold);
            Font arial7 = new Font("arial", 7, FontStyle.Regular);

            if (detailsNeedPrinting)
            {
                Image i = Properties.Resources.Mx;
                ev.Graphics.DrawImage(i, 65, 35, i.Width / 3, i.Height / 3);

                ev.Graphics.DrawString("Date Printed: " + date, arial7, Brushes.Black, 50, 1050);
                ev.Graphics.DrawString("Page  " + pageNo + " of " + NumPages, arial7, Brushes.Black, 700, 1050);
                ev.Graphics.DrawString(table.Rows[0][0].ToString(), leaders, Brushes.Black, 50, 115);
                ev.Graphics.DrawString(customer, leaders, Brushes.Black, 300, 115);
                pen.Width = 2;
                ev.Graphics.DrawLine(pen, 50, 140, 750, 140);

                ev.Graphics.DrawString("App", heading, Brushes.Black, 75, 150);
                ev.Graphics.DrawString("Start", heading, Brushes.Black, 270, 150);
                ev.Graphics.DrawString("Expire", heading, Brushes.Black, 400, 150);
                ev.Graphics.DrawString("License", heading, Brushes.Black, 525, 150);

                while (count < linesPerpage && lineNo < j)
                {

                    ev.Graphics.DrawString(table.Rows[lineNo][1].ToString(), arial, Brushes.Black, 75, linedrop);
                    ev.Graphics.DrawString(table.Rows[lineNo][2].ToString(), arial, Brushes.Black, 270, linedrop);
                    ev.Graphics.DrawString(table.Rows[lineNo][3].ToString(), arial, Brushes.Black, 400, linedrop);
                    ev.Graphics.DrawString(table.Rows[lineNo][4].ToString(), arial, Brushes.Black, 525, linedrop);

                    lineNo++;
                    count++;
                    linedrop = linedrop + 25;
                }



                if (j > lineNo)
                {
                    ev.HasMorePages = true;
                    pagesPrinted++;
                }
                else
                {
                    ev.HasMorePages = true;
                    linedrop = 160;
                    count = 0;
                    pagesPrinted = 0;
                    lineNo = 0;
                    detailsNeedPrinting = false;
                }
            }
            else
            {
                int nextpar = 100;
                int drop = 12;
                ev.Graphics.DrawString("ZYGO SOFTWARE LICENSE AGREEMENT", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop + drop;
                ev.Graphics.DrawString("PLEASE READ THIS SOFTWARE LICENSE AGREEMENT CAREFULLY BEFORE DOWNLOADING OR USING THE SOFTWARE.", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop + drop;
                ev.Graphics.DrawString(@"BY CLICKING ON THE ""ACCEPT"" BUTTON, OPENING THE PACKAGE, DOWNLOADING THE PRODUCT, OR USING THE EQUIPMENT THAT CONTAINS", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("THIS PRODUCT, YOU ARE CONSENTING TO BE BOUND BY THIS AGREEMENT.  IF YOU DO NOT AGREE TO ALL OF THE TERMS OF THIS AGREEMENT,", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString(@"CLICK THE ""DO NOT ACCEPT"" BUTTON AND THE INSTALLATION PROCESS WILL NOT CONTINUE, RETURN THE PRODUCT TO THE PLACE OF ", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("PURCHASE FOR A FULL REFUND, OR DO NOT DOWNLOAD THE PRODUCT.", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop + drop;
                ev.Graphics.DrawString(@"Single User License Grant:  Zygo Corporation (""Zygo"") and its suppliers grant to Customer (""Customer"") a nonexclusive and nontransferable license to use the Zygo", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString(@"software (""Software"") solely on a single computer owned or leased by Customer or otherwise embedded in equipment provided by Zygo.  Customer may not network", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("this software or use it on more than one computer or computer terminal at the same time.", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop + drop;
                ev.Graphics.DrawString("Customer may make one (1) archival copy of the Software provided Customer affixes to such copy all copyright, confidentiality, and proprietary notices that appear", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("on the original.", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop + drop;
                ev.Graphics.DrawString("EXCEPT AS EXPRESSLY AUTHORIZED ABOVE, CUSTOMER SHALL NOT:  COPY, IN WHOLE OR IN PART, SOFTWARE OR DOCUMENTATION; MODIFY THE", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("SOFTWARE; REVERSE COMPILE OR REVERSE ASSEMBLE ALL OR ANY PORTION OF THE SOFTWARE; OR RENT, LEASE, DISTRIBUTE, SELL, OR CREATE", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("DERIVATIVE WORKS OF THE SOFTWARE.", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop + drop;
                ev.Graphics.DrawString("Customer agrees that aspects of the licensed materials, including hte specific design and structure of individual programs, constitute trade secrets and/or copyrighted", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("material of Zygo.  Customer agrees to not disclose, provide, or otherwise make available such trade secrets or copyrighted material in any form to any third party without", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("prior written consent of Zygo.  Customer agrees to implement reasonable security measures to protect such trade secrets and copyrighted material.  Title to Software", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("and documentation shall remain solely with Zygo.", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop + drop;
                ev.Graphics.DrawString("LIMITED WARRANTY. Zygo warrants that for a period of ninety (90) days from the date of shipment from Zygo:  (i) the media on which the Software is furnished will be", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("free of defects in materials and workmanship under normal use; and (ii) the Software substantially conforms to its published specifications.  Except for the foregoing, the ", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("Software is provided AS IS.  This limited warranty extends only to Customer as the original licensee.  Customer's exclusive remedy and the entire liability of Zygo and its", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("suppliers under this limited warranty will be, at Zygo or its service center's option, repair, replacement, or refund of the Software if reported (or, upon request, returned)", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("to the party supplying the Software to the Customer.  In no event does Zygo warrant that the Software is error free or that the Customer will be able to operate the ", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("Software without problems or interruptions.", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop + drop;
                ev.Graphics.DrawString("This warranty does not apply if the Software (a) has been altered, except by Zygo, (b) has not been installed, operated, repaired, or maintained in accordance with ", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("instructions supplied by Zygo, (c) has been subjected to abnormal physical or electrical stress, misuse, negligence, or accident, or (d) is used in hazardous activities.", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop + drop;
                ev.Graphics.DrawString("DISCLAIMER.  EXCEPT AS SPECIFIED IN THIS WARRANTY, ALL EXPRESS OR IMPLIED CONDITIONS, REPRESENTATIONS, AND WARRANTIES INCLUDING, ", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("WITHOUT LIMITATION, ANY IMPLIED WARRANTY OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, NONINFRINGEMENT OR ARISING FROM", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("A COURSE OF DEALING, USAGE, OR TRADE PRACTICE, ARE HEREBY EXCLUDED TO THE EXTENT ALLOWED BY APPLICABLE LAW.", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop + drop;
                ev.Graphics.DrawString("IN NO EVENT WILL ZYGO OR ITS SUPPLIERS BE LIABLE FOR ANY LOST REVENUE, PROFIT, OR DATA, OR FOR SPECIAL, INDIRECT, CONSEQUENTIAL,", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("INCIDENTAL, OR PUNITIVE DAMAGES HOWEVER CAUSED AND REGARDLESS OF THE THEORY OF LIABILITY ARISING OUT OF THE USE OF OR INABILITY", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("TO USE THE SOFTWARE EVEN IF ZYGO OR ITS SUPPLIERS HAVE BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES.  In no event shall Zygo's or its", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("supppliers' liability to Customer, whether in contract, tort (including negligence), or otherwise, exceed the price paid by Customer.  The foregoing limitations shall apply", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("even if the above-stated waranty fails of its essential purpose.  SOME STATES DO NOT ALLOW LIMITATION OR EXCLUSION OF LIABILITY FOR CONSEQUENTIAL", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("OR INCIDENTIAL DAMAGES.", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop + drop;
                ev.Graphics.DrawString("The above warranty DOES NOT apply to any beta software, any software made available for testing or demonstration purposes, any temporary software modules or any", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("software for which Zygo does not receive a license fee.  All such software products are provided AS IS without any warranty whatsoever.", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop + drop;
                ev.Graphics.DrawString("This License is effective until terminated.  Customer may terminate this License at any time by destroying all copies of Software including any documentation.  This ", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("License will terminate immediately without notice from Zygo if Customer fails to comply with any provision of this License.  Upon termination, Customer must destroy all", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("copies of Software.", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop + drop;
                ev.Graphics.DrawString("Software, including technical data, is subject to U.S. export control laws, including the U.S. Export Administration Act and its associated regulations, and may be subject", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("to export or import regulations in other countries.  Customer agrees to comply strictly with all such regulations and acknowledges that it has the responsibility to obtain", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("licenses to export, re-export, or import Software.", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop + drop;
                ev.Graphics.DrawString("This License shall be governed by and construed in accordance with the laws of the State of Connecticut, United States of America, as if performed wholly within the state", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("and without giving effect to the principles of conflict of law.  If any portion hereof is found to be void or unenforceable, the remainging provisions of this License shall", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("remain in full force and effect.  This License constitutes the entire License between the parties with respece to the use of the Software.", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop + drop;
                ev.Graphics.DrawString("Restricted Rights - Zygo's software is provided to non-DOD agencies with RESTRICTED RIGHTS and its supporting documentation is provided with LIMITED RIGHTS.", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString(@"Use, duplication, or disclosure by the Government is subject to the restrictions as set forth in subparagraph ""C"" of the Commercial Computer Software - Restricted Rights", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("clause at FAR 52.227-19.  In the event the sale is to a DOD agency, the government's rights in software, supporting documentation, and technical data are governed ", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("by the restrictions in the Technical Data Commercial Items clause at DFARS 252.227-7025 and DFARS 227.7202.  Manufacturer is Zygo Corporation, Laurel Brook Rd.,", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop;
                ev.Graphics.DrawString("Middlefield, CT 06455", arial7, Brushes.Black, 50, nextpar);
                nextpar = nextpar + drop + drop;
                ev.Graphics.DrawString("201506", arial7, Brushes.Black, 50, nextpar);
                ev.Graphics.DrawString("Date Printed: " + date, arial7, Brushes.Black, 50, 1050);
                ev.Graphics.DrawString("Page  2 of " + NumPages, arial7, Brushes.Black, 700, 1050);

            }
        }
    }
}
