using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace QuoteWerksServiceExport
{
    public partial class ChooseData : Form
    {
        private string txtLine;
        private string txtDate;
        private string itemclass;
        private string salesText;
        private string directory;

        public ChooseData()
        {
            InitializeComponent();
        }

        private void BItems_Click(object sender, EventArgs e)
        {
            //File.Delete(@"\\CT-MID-AS37.zygo.com\datashare\program files\quotewerks\ServiceItems_Export.txt");
            directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            File.Delete(Path.Combine(directory, "ServiceItems_Export.txt"));

            DateTime tDate = DateTime.Now;
            txtDate = tDate.Date.ToString(@"yyyy-MM-dd");
            //Date.Date.ToString("g");

            SqlConnection cnxn = new SqlConnection(
                "server = CT-MID-SQL11; user = readwrite; " +
                "password = Read+Write!; database = pricelists;");
            cnxn.Open();
            SqlCommand cmd = new SqlCommand("Select * from ServiceSalesPriceList " +
                "where itemclasscode = 'ServiceItems'", cnxn);
            //cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                
                    itemclass = dr[2].ToString().Trim();
                

                if (dr[5].ToString().IndexOf("\"") != -1)
                {
                    salesText = dr[5].ToString().Trim().Replace("\"", " IN");
                }
                else
                {
                    salesText = dr[5].ToString().Trim();
                }



                txtLine = "\"" + dr[0].ToString().Trim() + "\"|\"" +
                    dr[1].ToString().Trim() + "\"|\"" +
                    dr[2].ToString().Trim() + "\"|\"" +
                    itemclass + "\"|\"" +
                    salesText + "\"|\"" +
                    dr[3].ToString().Trim() + "\"|\"" +
                    dr[4].ToString().Trim() + "\"" + Environment.NewLine;

                //File.AppendAllText(@"\\CT-MID-AS37.zygo.com\datashare\program files\quotewerks\ServiceItems_Export.txt", txtLine);
                File.AppendAllText(Path.Combine(directory, "ServiceItems_Export.txt"), txtLine);
            }
            cnxn.Close();
            this.Close();
        }

        private void BContracts_Click(object sender, EventArgs e)
        {
            //File.Delete(@"\\CT-MID-AS37.zygo.com\datashare\program files\quotewerks\ServiceItems_Export.txt");
            directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            File.Delete(Path.Combine(directory, "ServiceContracts_Export.txt"));

            DateTime tDate = DateTime.Now;
            txtDate = tDate.Date.ToString(@"yyyy-MM-dd");
            //Date.Date.ToString("g");

            SqlConnection cnxn = new SqlConnection(
                "server = CT-MID-SQL11; user = readwrite; " +
                "password = Read+Write!; database = pricelists;");
            cnxn.Open();
            SqlCommand cmd = new SqlCommand("Select * from ServiceSalesPricelist " +
                "where itemclasscode = 'ServiceContract'", cnxn);
            //cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                itemclass = dr[2].ToString().Trim();


                if (dr[5].ToString().IndexOf("\"") != -1)
                {
                    salesText = dr[5].ToString().Trim().Replace("\"", " IN");
                }
                else
                {
                    salesText = dr[5].ToString().Trim();
                }



                txtLine = "\"" + dr[0].ToString().Trim() + "\"|\"" +
                    dr[1].ToString().Trim() + "\"|\"" +
                    dr[2].ToString().Trim() + "\"|\"" +
                    itemclass + "\"|\"" +
                    salesText + "\"|\"" +
                    dr[3].ToString().Trim() + "\"|\"" +
                    dr[4].ToString().Trim() + "\"" + Environment.NewLine;

                //File.AppendAllText(@"\\CT-MID-AS37.zygo.com\datashare\program files\quotewerks\ServiceItems_Export.txt", txtLine);
                File.AppendAllText(Path.Combine(directory, "ServiceContracts_Export.txt"), txtLine);
            }
            cnxn.Close();
            this.Close();
        }
    }
}
