using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Data.SqlClient;


namespace WordText
{
    public partial class Form1 : Form
    {
        SqlConnection cnxn;
        private string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = OptiTRAK;";
        private string text;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);

            Microsoft.Office.Interop.Word.Application w = new Microsoft.Office.Interop.Word.Application();
            //Microsoft.Office.Interop.Word.Document doc = w.Documents.Open("c:\\a\\c.docx", Type.Missing,
            //    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            //    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            //doc.ActiveWindow.Selection.WholeStory();

            //doc.ActiveWindow.Selection.Copy();

            //string sFileText = doc.Content.Text;

            //doc.Close(Type.Missing, Type.Missing, Type.Missing);


            w.Visible = false;
            //w.DisplayAlerts = false;
            Document d = w.Documents.Open("c:\\a\\c.docx");

            int count = d.Words.Count;
            for (int i = 1; i <= count; i++)
            {
                text += d.Words[i].Text;
            }

            w.Documents.Close(Type.Missing, Type.Missing, Type.Missing);
            w.Quit();


            text = text.Substring(0, text.Length - (text.Length - (text.LastIndexOf("TOTALS"))));
            int a = (text.IndexOf("\r\a")+2);
            string b = text.Substring(1, (text.IndexOf("\r\a")-1));
            string c = text.Substring(a, 5);
            text = text.Substring((text.IndexOf("\r\a") + 2), text.Length - (text.IndexOf("\r\a") + 2));
            text = text.Substring((text.IndexOf("\r\a") + 2), text.Length - (text.IndexOf("\r\a") + 2));
            string cc = text.Substring(0, text.IndexOf("\r\a"));

            SqlCommand cmd = new SqlCommand(
                    "insert into optemp (opnum, description) values (" + b + ",'" + cc + "')", cnxn);
            cnxn.Open();
            cmd.ExecuteNonQuery();
            cnxn.Close();

            try
            {
                while (text.Length > 50)
                {
                    for (int n = 1; n < 8; n++)
                    {
                        text = text.Substring((text.IndexOf("\r\a") + 2), text.Length - (text.IndexOf("\r\a") + 2));
                    }

                    string dd = text.Substring(0, text.IndexOf("\r\a"));
                    text = text.Substring((text.IndexOf("\r\a") + 2), text.Length - (text.IndexOf("\r\a") + 2));
                    text = text.Substring((text.IndexOf("\r\a") + 2), text.Length - (text.IndexOf("\r\a") + 2));
                    string ee = text.Substring(0, text.IndexOf("\r\a"));

                    cmd = new SqlCommand(
                        "insert into optemp (opnum, description) values (" + dd + ",'" + ee + "')", cnxn);
                    cnxn.Open();
                    cmd.ExecuteNonQuery();
                    cnxn.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            
            

        }
    }
}
