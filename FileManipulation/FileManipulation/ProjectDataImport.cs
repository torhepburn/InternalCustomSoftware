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
    public partial class ProjectDataImport : Form
    {
        public ProjectDataImport()
        {
            InitializeComponent();
        }

        private void ProjectDataImport_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("c:\\a\\tabcalperiod.txt");

            while (sr.Peek() >= 0)
            {
                string x = sr.ReadLine();

                string[] insert = x.Split(',');

                string aa = insert[0].ToString().Trim();
                string bb = insert[1].ToString().Trim();
                string cc = insert[2].ToString().Trim();
                //string dd = insert[3].ToString().Trim();
                //string ee = insert[4].ToString().Trim();
                //string ff = insert[5].ToString().Trim();
                //string gg = insert[6].ToString().Trim();
                bb = bb.Trim('"');  //get rid of quotes
                //if (aa == "")
                //{
                //    aa = "0";
                //}
                //if (bb == "")
                //{
                //    bb = "0";
                //}
                //if (cc == "")
                //{
                //    cc = "0";
                //}
                //if (dd == "")
                //{
                //    dd = "0";
                //}
                //if (ee == "")
                //{
                //    ee = "0";
                //}
                //if (ff == "")
                //{
                //    ff = "0";
                //}
                //if (gg == "")
                //{
                //    gg = "0";
                //}
                //else
                //{
                //    gg = gg.Substring(0, 1);
                //}
                SqlConnection cxn = new SqlConnection("server = middbsql; " +
                    "user id = rights; password = readingwriting; database = projects;");

                SqlCommand cmd = new SqlCommand("Insert into tabcalperiod " +
                    "(Financial_Period, " +         //1
                    "CalPeriod, " +
                    "PeriodDate) " +          //3
                    //"InnerDiameter, " +      //4
                    //"shankdiameter, " +
                    //"usablelength, " +      //5
                    //"flatdiameter, " +
                    "values " +
                    "(" +                                //1
                     aa + //insert[0].ToString().Trim() +        
                    ",'" + bb + //insert[1].ToString().Trim() +         //3
                    "','" + cc + //insert[2].ToString().Trim() +
                    //"," + dd + //insert[3].ToString().Trim() +         //5
                    //"," + ee +
                    //"," + ff +
                    ////"," + gg +
                    //",'" + insert[6].ToString().Trim() +
                    //"','" + insert[7].ToString().Trim() +       //7
                    //"','" + insert[8].ToString().Trim() +
                    //"','" + insert[9].ToString().Trim() +         //9

                    //"','" + insert[8].ToString().Trim() +
                    //"','" + gg +         //11PB
                    //"','" + insert[9].ToString().Trim() +
                    //"','" + insert[10].ToString().Trim() +
                    // "','" + insert[12].ToString().Trim() +
                    "' )");

                //SqlCommand cmd = new SqlCommand
                //    ("update equipment set type = 'SWAP' " +
                //     "where id = '" + x + "'", cxn);


                cmd.Connection = cxn;
                cxn.Open();
                int rowsReturned = cmd.ExecuteNonQuery();
                cxn.Close();
            }
        }

    }
 }
