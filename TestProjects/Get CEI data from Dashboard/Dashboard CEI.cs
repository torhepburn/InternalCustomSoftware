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

namespace Get_CEI_data_from_Dashboard
{
    public partial class Form1 : Form
    {
        private string fileName;
        private DateTime TestDate;
        private string[] files;
        private int numberFiles;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //error when data with same xml file name already there
            
            SqlConnection cnxn = new SqlConnection
                ("server = MIDDBSQL\\SQL2000; password = views; " +
                 "user = views; database = dashboard;");
            SqlCommand cmd = new SqlCommand
                ("Select metrologydataid from view_metrologymeasurements " +
                 "where documentnumber = '8020-0103-05' and createdbyname " +
                 "= 'giove, tom' and datecreated > '2011-10-04'");
                //("Select metrologydataid from view_metrologymeasurements " +
                //"where vendorname like 'cei%' and documentnumber " +
                //"= '8020-0700-21'");

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
                numberFiles = files.Length;

                for (int nnn = 0; nnn < numberFiles; nnn++)
                {
                    //get file name long
                    string goal = files[nnn];

                    ProduControlchart.Input(goal);
                }
            }
            cnxn.Close();
        }
    }
}