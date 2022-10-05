using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using PCClib;


namespace dllDebug
{
    public partial class Form1 : Form
    {
        private string fileName;
        private DateTime TestDate;
        private string[] files;
        private string[] folders;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string test = ProduControlchart.Input(@"C:\A\AC.17510143.ZMI-4K-ITS.2018-3-17_02-58-28-PM_UTC.xml");
            //string test = ProduControlchart.Input(@"C:\A\AC21070003.ZMI-5K.2021-3-17_04-42-03-PM_UTC.xml");
            //string test = ProduControlchart.Input(@"C:\A\CE.13110569.ZMI-TEST-2.2015-10-5_12-38-26-PM_UTC.xml");
            //string test = ProduControlchart.Input(@"C:\A\AC.20470016.ZMI-4K-ITS.2021-1-5_06-41-42-PM_UTC.xml");
            //string test = ProduControlchart.Input(@"C:\A\AC.20470020.ZMI-4K-ITS.2021-1-5_01-51-09-PM_UTC.xml");
            //string test = ProduControlchart.Input(@"C:\A\AC.20470038.ZMI-4K-ITS.2021-1-5_04-41-29-PM_UTC.xml");
            string test = ProduControlchart.Input(@"C:\A\AC.21190078.ZMI-4K-ITS.2021-9-22_02-37-20-PM_UTC.xml");
            //string test = ProduControlchart.Input(@"\\middbweb2012.zygo.com\metrologydocuments\139022\AC.21290013.ZMI-4K-ITS.2021-9-8_02-27-43-PM_UTC.xml");
            //string test = ProduControlchart.Input(@"\\middbweb2012.zygo.com\metrologydocuments\129970\AC.20470016.ZMI-4K-ITS.2021-1-5_06-41-42-PM_UTC.xml");
            //string test = ProduControlchart.Input(@"\\middbweb2012\metrologydocuments\116814\AC.19360042.ZMI-4K-ITS.2019-10-29_03-26-01-PM_UTC.xml");
            //string test = ProduControlchart.Input(@"\\middbweb2012\metrologydocuments\95623\CE.07382437.ZMI-4K-ITS.2018-4-16_02-03-13-PM_UTC.xml");
            //string test = ProduControlchart.Input(@"\\middbweb2012\metrologydocuments\78068\CC.16392183.ZMI-4K-ITS.2016-12-5_05-14-04-PM_UTC.xml");
            /*
            //http://dashboard-ct.zygo.com/zto/app/Metrology/Data/Documents/95623/CE.07382437.ZMI-4K-ITS.2018-4-16_02-03-13-PM_UTC.xml
            */
            //string test = ProduControlchart.Input(@"\\middbweb2012\metrologydocuments\66247\CE.07262253.ZMI-TEST-2.2015-8-11_12-15-06-PM_UTC.xml");
            //string test = ProduControlchart.Input(@"\\middbweb\ddrive\wwwroot\zto\app\metrology\data\documents\57951\CE.07432600.ZMI-TEST-2.2014-7-22_01-24-05-PM_UTC.xml");
            //string test = ProduControlchart.Input(@"\\middbweb\ddrive\wwwroot\zto\app\metrology\data\documents\57620\CE.07262253.ZMI-TEST-2.2014-7-14_12-25-05-PM_UTC.xml");
            //string test = ProduControlchart.Input(@"\\middbweb\ddrive\wwwroot\zto\app\metrology\data\documents\47539\VS.05399446.ZMI-TEST-2.2013-4-17_11-40-10-AM_UTC.xml");


            // this is the original location of the date on the test station prior to being loaded into Dashboard[middbweb2012]

            //string test = ProduControlchart.Input(@"\\zmi-test-2\its data\test results\zmi 4104E\05399446\VS.05399446.ZMI-TEST-2.2013-4-17_01-20-25-PM_UTC.xml", "Production");




            //string test = ProduControlchart.Input(@"C:\\a\CE.12340099.ZMI-TEST-2.00000.xml");
            //string test = ProduControlchart.Input(@"C:\\a\CE.12480251.ZMI-TEST-2.2013-1-28_06-38-57-PM_UTC.xml", "TEST");

            //string test = ProduControlchart.Input(@"C:\\a\CE.12480256.ZMI-TEST-2.2013-3-6_06-46-21-PM_UTC.xml", "TEST");
            //string test = ProduControlchart.Input(@"C:\\a\CE.12480256.ZMI-TEST-2.2013-3-6_06-47-21-PM_UTC.xml", "TEST");

            //string test = ProduControlchart.Input(@"C:\\a\CE.00618041.ZMI-TEST-1.99999.xml");
            //string test = ProduControlchart.Input(@"C:\\a\CE.07382437.ZMI-TEST-2.91919.xml");

            //SqlConnection cnxn = new SqlConnection
            //    ("server = MIDSQL01; password = views; " +
            //     "user = views; database = productioncontrol;");
            ////SqlCommand cmd = new SqlCommand
            ////    ("Select metrologydataid from view_metrologymeasurements " +
            ////     "where documentnumber " +
            ////     "= '8020-0700-21'");
            //SqlCommand cmd = new SqlCommand
            //    ("select folder from missingpccfoldernumber");

            //try
            //{
            //    cmd.Connection = cnxn;
            //    cnxn.Open();
            //    SqlDataReader dr = cmd.ExecuteReader();

            //    while (dr.Read())
            //    {
            //        string folder = dr.GetInt32(0).ToString();

            //        //string path = @"\\zygocorp\Departments\PPS\Manuf_Test\" +
            //        //@"New_4000_Test_Station\ITS Test folders\MCert\CEI\4100\" +
            //        //@"CEI MCert May 25 11\Some sample gold board data over a period\";

            //        /*string path = @"\\middbweb\ddrive\wwwroot\zto\app\metrology\data\" +
            //        @"documents\" + folder + @"\";
            //            */
            //        //string path = @"C:\a\4004\";

            //        string path = @"\\middbweb2012\metrologydocuments\" + folder + @"\";

            //        /*
            //                        try
            //                        {
            //                            folders = Directory.GetDirectories(path);
            //                        }
            //                        catch (Exception ex)
            //                        {
            //                            MessageBox.Show(ex.ToString());
            //                        }
            //        */
            //        ////get array of xml files from sn folder
            //        try
            //        {
            //            //files = Directory.GetFiles(@"\\zmi-test-2\tor_test_4100e_production", "*.xml");

            //            files = Directory.GetFiles(path, "*.xml");
            //            ProduControlchart.Input(files[0], "Production");
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.ToString());
            //            continue;
            //        }

            //        find the number of files in the array
            //int numberFiles = files.Length;

            //        for (int nnn = 1; nnn < numberFiles; nnn++)
            //        {
            //            //get file name long
            //            string goal = files[nnn];

            //            //    ProduControlchart.Input(goal, "Production");
            //            //}
            //        }
            //        dr.Close();
            //        cnxn.Close();

            //    }
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}



            /*  
             *      when dll goes down and need to find files which were not loaded use SQL
             *      and find the files in MIDDB01.Dashboard.dbo.view_metrologymeasurements
             *      where documentnumber in (look for the 4104 and 4004 numbers: '8020-0700-21',
             *      '8020-0102-02', '8020-0103-05', '8020-0103-08')
             *      Put the documentnumbers in missingpccfoldernumber and follow below
             * 
             */
            /*
           SqlConnection cnxn = new SqlConnection
               ("server = MIDSQL01; password = views; " +
                "user = views; database = productioncontrol;");
           SqlCommand cmd = new SqlCommand
               ("select folder from filetest ORDER BY folder");
           //("select folder from missingpccfoldernumber ORDER BY folder");
           //"select folder from filetest ORDER BY folder");
           try
           {
               cmd.Connection = cnxn;
               cnxn.Open();
               SqlDataReader dr = cmd.ExecuteReader();

               while (dr.Read())
               {
                   string folder = dr.GetInt32(0).ToString();

                   string path = @"\\middbweb2012\metrologydocuments\" + folder + @"\";

                   try
                   {
                       if (Directory.Exists(path))
                       {
                           files = Directory.GetFiles(path, "*.xml");
                           //if there is more than one file then this will need to be adjusted
                           ProduControlchart.Input(files[0], "Production");

                       }

                   }
                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.ToString());
                       continue;
                   }
               }
               dr.Close();
               cnxn.Close();

           }
           catch (SqlException ex)
           {
               MessageBox.Show(ex.ToString());
           }




   */







        }
    }
}