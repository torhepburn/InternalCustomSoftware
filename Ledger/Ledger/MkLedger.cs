using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Ledger
{
    public partial class MkLedger : Form
    {
        private int i = 1;
        private string period;
        private string aa;
        private string bb;
        private string cc;
        private decimal dd;
        SqlConnection cnxn;
        private string resetFlag;
        
        public MkLedger()
        {
            InitializeComponent();
        }

        private void MkLedger_Load(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Ledger Files | *Mkledger*.txt";
            openFileDialog1.ShowDialog();

            cnxn = new SqlConnection("server = MIDSQL01; " +
                        "user id =  views; password = views; database = GeneralLedger;");


            if (openFileDialog1.FileName.Length > 0)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);

                while (sr.Peek() >= 0)
                {
                    string x = sr.ReadLine();

                    if (x.Length > 5 && x.Substring(0, 4) == "Zygo")
                    {
                        period = x.Substring(x.IndexOf("Period") + 7, 4);
                        if (period.Substring(1, 1) == " ")
                        {
                            period = "0" + period.Substring(0, 1);
                        }
                    }

                    if (x.Length > 5 && x.Substring(0, 4) == "Year")
                    {
                        period = x.Substring(x.IndexOf(":") + 2, 4) + period;

                        if (resetFlag != "Done")
                        {
                            SqlCommand cmd = new SqlCommand("Delete from MKLedger where " +
                                "period = '" + period + "' ", cnxn);
                            cnxn.Open();
                            int rowsReturned = cmd.ExecuteNonQuery();
                            cnxn.Close();
                            resetFlag = "Done";
                        }
                    }

                    
                    if (x.Length > 5 && (x.Substring(5, 2) == "31" | x.Substring(5, 2) == "41"))
                    {
                        string[] insert = x.Split('|');

                        aa = insert[0].ToString().Trim();
                        bb = insert[2].ToString().Trim();
                        cc = insert[5].ToString().Trim();
                        cc = cc.Replace(",", "");
                        if (cc != null && cc.IndexOf("-") > 0)
                        {
                            cc = cc.Replace("-", "");
                            dd = Convert.ToDecimal(cc);
                            dd = dd * (-1);
                        }
                        else if (cc != null & cc != "")
                        {
                            dd = Convert.ToDecimal(cc);
                        }
                    }

                    if (aa != null)
                    {
                        SqlCommand cmd = new SqlCommand("Insert into MKLedger " +
                            "(period, " +
                            "ledger, " +
                            "AccountDescription, " +
                            "TransactionTotal) " +
                            "values " +
                            "('" + period +
                            "','" + aa +
                            "','" + bb +
                            "'," + dd +
                            " )", cnxn);
                        cnxn.Open();
                        int rowsReturned = cmd.ExecuteNonQuery();
                        cnxn.Close();
                        aa = null;
                        bb = null;
                        cc = null;
                        dd = 0;
                    }
                }
            }
            resetFlag = "";
            this.Close();
        }
    }
}

