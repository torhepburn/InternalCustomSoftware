using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using bpac;

namespace BrotherPrintTest
{
    public partial class BPacTest : Form
    {
        private string iID;

        public BPacTest()
        {
            InitializeComponent();
        }

        private void BPacTest_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(
            "server = midsql01; password = Read+Write!; " +
                              "user = readwrite; database = calibration;");

            SqlCommand cmd = new SqlCommand(
                "select top 2 e.id from equipment e " +
                "left join ItemLocation l on e.id = l.il_item " +
                "where il_location like 'zep%'  and status <>  'inactive' " +
                "and id > 'sml 1000000' " +
                "order by id", cnxn);
            /*
            SqlCommand cmd = new SqlCommand(
                "select id from RICHMONDLABELS " +
                "order by id", cnxn);
                */
            cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                try
                {
                    iID = dr.GetString(0).Trim();

                    bpac.Document BroDoc = new Document();
                    BroDoc.Open("c:\\calibration\\Barcode.lbl");
                    int index = BroDoc.GetTextIndex("Barcode");
                    BroDoc.SetBarcodeData(0, iID);
                    BroDoc.SetText(index, iID);
                    BroDoc.DoPrint(0, "0");
                    BroDoc.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            cnxn.Close();
        }
    }
}


