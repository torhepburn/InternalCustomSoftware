using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;


namespace FileManipulation
{
    public partial class MKLedger : Form
    {
        private int i = 1;
        private string period;
        private string aa;
        private string bb;
        private string cc;
        private decimal dd;

        public MKLedger()
        {
            InitializeComponent();
        }

        private void MKLedger_Load(object sender, EventArgs e)
        {

            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = @"c:\a\";

            StreamReader sr = new StreamReader(path + "mrp-1.pdf");
            //StreamReader sr = new StreamReader(path + "\\201511mkledger.txt");
            //StreamReader sr = new StreamReader("c:\\a\\6306-0310-01_jens_test.csv");

            while (sr.Peek() >= 0)
            {
                string x = sr.ReadLine();

                string y = "6";

                //if (x.Length > 5 && x.Substring(0, 4) == "Zygo")
                //{
                //    period = x.Substring(x.IndexOf("Period") + 7, 4);
                //    if (period.Substring(1, 1) == " ")
                //    {
                //        period = "0" + period.Substring(0, 1);
                //    }
                //}

                //if (x.Length > 5 && x.Substring(0, 4) == "Year")
                //{
                //    period = x.Substring(x.IndexOf(":") + 2, 4) + period;
                //}

                //if (x.Length > 5 && (x.Substring(5,2) == "31" | x.Substring(5,2) == "41"))
                //{
                //    string[] insert = x.Split('|');

                //    aa = insert[0].ToString().Trim();
                //    bb = insert[2].ToString().Trim();
                //    cc = insert[5].ToString().Trim();
                //    cc = cc.Replace(",", "");
                //    if (cc != null && cc.IndexOf("-") > 0)
                //    {
                //        cc = cc.Replace("-", "");
                //        dd = Convert.ToDecimal(cc);
                //        dd = dd * (-1);
                //    }
                //    else if (cc != null & cc!= "")
                //    {
                //        dd = Convert.ToDecimal(cc);
                //    }
                //string dd = insert[5].ToString().Trim();
                    //string ee = insert[6].ToString().Trim();
                    //string ff = insert[7].ToString().Trim();
                //}
                
                //if (aa!= null)
                //{
                //    SqlConnection cnxn = new SqlConnection("server = MIDSQL01; " +
                //    "user id =  views; password = views; database = GeneralLedger;");

                //    SqlCommand cmd = new SqlCommand("Insert into MKLedger " +
                //        "(period, " +
                //        "ledger, " +
                //        "AccountDescription, " +
                //        "TransactionTotal) " +
                //        "values " +
                //        "('" + period + 
                //        "','" + aa + 
                //        "','" + bb + 
                //        "'," + dd + 
                //        " )", cnxn);

                //    cnxn.Open();
                //    int rowsReturned = cmd.ExecuteNonQuery();
                //    cnxn.Close();
                //    aa = null;
                //    bb = null;
                //    cc = null;
                //    dd = 0;
                //}
                    
                
             }
        }
    }
}
