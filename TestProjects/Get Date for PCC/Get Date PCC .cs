using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Get_Date_for_PCC
{
    public partial class fGetDate : Form
    {
        private string fileName;
        private DateTime TestDate;
        private string[] files;
        private int boardpromver;
        
        public fGetDate()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
                ("server = MIDDBSQL\\SQL2000; password = views; " +
                 "user = views; database = dashboard;");
            //SqlCommand cmd = new SqlCommand
            //    ("Select metrologydataid from view_metrologymeasurements " +
            //     "where vendorname like 'cei%' and (serialnumber like " +
            //     "'%618041%' or serialnumber like '%618042%' or " +
            //     "serialnumber like '%9145386%')");

            SqlCommand cmd = new SqlCommand
                ("Select metrologydataid from view_metrologymeasurements " +
                 "where vendorname like 'cei%'");

            
            cmd.Connection = cnxn;
            cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string folder = dr.GetInt32(0).ToString();

                //string path = @"\\zygocorp\Departments\PPS\Manuf_Test\" +
                //@"New_4000_Test_Station\ITS Test folders\MCert\CEI\4100\" +
                //@"CEI MCert May 25 11\Some sample gold board data over a period\";
                
                string path = @"\\middbweb\ddrive\wwwroot\zto\app\metrology\data\" +
                @"documents\" + folder + @"\";

                //get array of xml files from sn folder
                try
                {
                    files = Directory.GetFiles(path, "*.xml");
                    
                }
                catch (Exception ex)
                {
                    continue;
                }

                // find the number of files in the array
                int numberFiles = files.Length;

                for (int nnn = 0; nnn < numberFiles; nnn++)
                {
                    //get file name long
                    string goal = files[nnn];
                    int position = goal.LastIndexOf('\\');
                    //get file name short
                    fileName = goal.Substring(position + 1);

                    string[] readText = File.ReadAllLines(goal);

                    int x = readText[1].LastIndexOf("PromVer");
                    boardpromver = Convert.ToInt32(readText[1].Substring(x + 11,4 ).Trim());

                    SqlConnection cnxn2 = new SqlConnection
                        ("server = midprj01; user = views; password = views; " +
                         "database = productioncontrol;");
                    SqlCommand cmd2 = new SqlCommand
                        ("Update [test data] " +
                        "set [board promver] = " + boardpromver + " where " +
                        "[xml file name] = '" + fileName + "'");
                    cmd2.Connection = cnxn2;
                    cnxn2.Open();
                    cmd2.ExecuteNonQuery();
                    cnxn2.Close();


                }
            }

            cnxn.Close();
        }
    }
}