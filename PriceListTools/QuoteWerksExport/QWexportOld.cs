using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace QuoteWerksExport
{
    public partial class QWexportOld : Form
    {
        private string txtLine;
        private string txtDate;
        private string itemclass;
        private string salesText;
        
        public QWexportOld()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            File.Delete(Path.Combine(directory, "DOM_Export.txt"));
            File.Delete(Path.Combine(directory, "EXP_Export.txt"));
            File.Delete(Path.Combine(directory, "INT_Export.txt"));
            //File.Delete(@"\\CT-MID-AS37.zygo.com\datashare\program files\quotewerks\DOM_Export.txt");
            //File.Delete(@"\\CT-MID-AS37.zygo.com\datashare\program files\quotewerks\EXP_Export.txt");
            //File.Delete(@"\\CT-MID-AS37.zygo.com\datashare\program files\quotewerks\INT_Export.txt");

            //File.AppendAllText(Path.Combine(directory, "DOM_Export.txt"), txtLine);


            DateTime tDate = DateTime.Now;
            txtDate = tDate.Date.ToString(@"yyyy-MM-dd");
                //Date.Date.ToString("g");

            SqlConnection cnxn = new SqlConnection(
                "server = CT-MID-SQL11; user = readwrite; " +
                "password = Read+Write!; database = pricelists;");
            cnxn.Open();
            SqlCommand cmd = new SqlCommand("Select * from QWpricelist " +
                "where sales_price_list = 'dom'", cnxn);
            //cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr[4].ToString().IndexOf("\"") != -1)
                {
                    itemclass = dr[4].ToString().Trim().Replace("\"", " IN");
                }
                else
                {
                    itemclass = dr[4].ToString().Trim();
                }

                if (dr[5].ToString().IndexOf("\"") != -1)
                {
                    salesText = dr[5].ToString().Trim().Replace("\"", " IN");
                }
                else
                {
                    salesText = dr[5].ToString().Trim();
                }

                

                txtLine = "\"" + dr[1].ToString().Trim() + "\"|\"" +
                    dr[2].ToString().Trim() + "\"|\"" +
                    dr[3].ToString().Trim() + "\"|\"" +
                    itemclass + "\"|\"" +
                    salesText + "\"|\"" +
                    dr[6].ToString().Trim() + "\"|\"" +
                    dr[7].ToString().Trim() + "\"" + Environment.NewLine;

                //File.AppendAllText(@"\\CT-MID-AS37.zygo.com\datashare\program files\quotewerks\DOM_Export.txt",txtLine);
                //string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                File.AppendAllText(Path.Combine(directory, "DOM_Export.txt"), txtLine);

                //string today = DateTime.Now.ToString("MM-dd-yy hh.mm.ss");
                //string file = "TEST MRP " + g.ReportSelection + today + ".pdf";
                ////string directory = "\\\\MIDFILE01.zygo.com\\departments\\procurement\\purchasing\\mrp_requisitions\\MRP NAV";
                //string directory = "C:\\A";
                ////string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                //PrintDocument pd = new PrintDocument();
                //pd.DefaultPageSettings.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                ////pd.DefaultPageSettings.PrinterSettings.PrinterName = "CutePDF Writer";
                //pd.PrinterSettings.PrintToFile = true;
                ////pd.PrinterSettings.PrintFileName = @"C:\A\MRP " + g.ReportSelection + today + ".pdf";
                //pd.PrinterSettings.PrintFileName = Path.Combine(directory, file);
                ////pd.PrinterSettings.PrintFileName = @"C:\A\MRP.pdf";
                ////pd.DocumentName = @"C\A\MRP " + g.ReportSelection + String.Format("{0:f}", DateTime.Now) + ".pdf";
                ////pd.DocumentName = @"C\A\MRP " + DateTime.Now.ToLongDateString() + ".pdf";
                //StandardPrintController pc = new StandardPrintController();
                //pd.PrintController = pc;
            }
            cnxn.Close();

            cmd = new SqlCommand("Select * from QWpricelist " +
                "where sales_price_list = 'exp'", cnxn);
            cnxn.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr[4].ToString().IndexOf("\"") != -1)
                {
                    itemclass = dr[4].ToString().Trim().Replace("\"", " IN");
                }
                else
                {
                    itemclass = dr[4].ToString().Trim();
                }

                if (dr[5].ToString().IndexOf("\"") != -1)
                {
                    salesText = dr[5].ToString().Trim().Replace("\"", " IN");
                }
                else
                {
                    salesText = dr[5].ToString().Trim();
                }

                txtLine = "\"" + dr[1].ToString().Trim() + "\"|\"" +
                    dr[2].ToString().Trim() + "\"|\"" +
                    dr[3].ToString().Trim() + "\"|\"" +
                    itemclass + "\"|\"" +
                    salesText + "\"|\"" +
                    dr[6].ToString().Trim() + "\"|\"" +
                    dr[7].ToString().Trim() + "\"" + Environment.NewLine;
                //File.AppendAllText(@"\\CT-MID-AS37.zygo.com\datashare\program files\quotewerks\EXP_Export.txt", txtLine);
                //string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                File.AppendAllText(Path.Combine(directory, "EXP_Export.txt"), txtLine);

            }
            cnxn.Close();

            cmd = new SqlCommand("Select * from QWpricelist " +
                "where sales_price_list = 'int'", cnxn);
            cnxn.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr[4].ToString().IndexOf("\"") != -1)
                {
                    itemclass = dr[4].ToString().Trim().Replace("\"", " IN");
                }
                else
                {
                    itemclass = dr[4].ToString().Trim();
                }

                if (dr[5].ToString().IndexOf("\"") != -1)
                {
                    salesText = dr[5].ToString().Trim().Replace("\"", " IN");
                }
                else
                {
                    salesText = dr[5].ToString().Trim();
                }

                txtLine = "\"" + dr[1].ToString().Trim() + "\"|\"" +
                    dr[2].ToString().Trim() + "\"|\"" +
                    dr[3].ToString().Trim() + "\"|\"" +
                    itemclass + "\"|\"" +
                    salesText + "\"|\"" +
                    dr[6].ToString().Trim() + "\"|\"" +
                    dr[7].ToString().Trim() + "\"" + Environment.NewLine;
                //File.AppendAllText(@"\\CT-MID-AS37.zygo.com\datashare\program files\quotewerks\INT_Export.txt", txtLine);
                //string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                File.AppendAllText(Path.Combine(directory, "INT_Export.txt"), txtLine);

            }
            cnxn.Close();
            Close();
        }
        
    }
}
