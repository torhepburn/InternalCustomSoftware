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

namespace TextTest
{
    public partial class EmbeddedText : Form
    {
        public EmbeddedText()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection("server=pa-hor-as408.ametek.com; password=2018#ameteK; " +
                                        "user=navdb_read; database=ZYGO-NAV-PROD;");

            SqlCommand cmd = new SqlCommand(
                "SELECT [FD Blob], [FD Size KB] FROM [ZYGO$Text Module Line] WHERE [Code 1] = '1115-800-003'", cnxn);
            cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
                {
                    byte[] txt = (byte[])dr.GetValue(0);


                }


        }
    }
}
