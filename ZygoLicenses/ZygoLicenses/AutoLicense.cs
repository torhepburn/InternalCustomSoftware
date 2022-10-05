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
//using MetroproXLicenseDLL;


namespace ZygoLicenses
{
    public partial class AutoLicense : Form
    {
        //private string timestamp;
        //private string dongleID;
        //private string application;
        //private string customer;
        //private string email;
        //private string ZygoLicense;
        //private string firstName;
        //private string[] lines;
        //SqlConnection cnxn;
        //SqlDataReader dr;
        //SqlDataAdapter da;
        //private string db = "server = CT-MID-SQL01; user = ReadWriteAttach; password = A!!ac8This; " +
        //                    "database = ZygoProductLicenses;";
        ////MetroproXLicense MX = new MetroproXLicense();
        //DataTable dt1;
        //DataTable table;
        //DataTable dt2;
        //private int j = 0;
        //private int pagesPrinted = 0;
        //private int sleepytime = 200;
        //private Image img;
        //private bool detailsNeedPrinting = true;

        public AutoLicense()
        {
            InitializeComponent();
        }

        private void AutoLicense_Load(object sender, EventArgs e)
        {
            WebClient client = new WebClient();

            //    /*
            //     * look for the place where I split the data and put it in an array
            //     * */

            string webdata = client.DownloadString("http://www.zygo.com/zygomxlicense/data1.txt");

            //try
            //{
            //    string webdata = client.DownloadString("http://www.zygo.com/zygomxlicense/data1.txt");

            //   // lines = webdata.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Web Data  " + ex.ToString());
            //}
        }
    }
}
