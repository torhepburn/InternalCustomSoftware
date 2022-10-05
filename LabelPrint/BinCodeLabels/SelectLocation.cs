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

namespace BinCodeLabels
{
    public partial class SelectLocation : Form
    {
        SqlConnection cnxn;

        public SelectLocation()
        {
            InitializeComponent();
        }

        private void SelectLocation_Load(object sender, EventArgs e)
        {
            this.Text = "Bin Code Labels v" + Application.ProductVersion;

            cnxn = new SqlConnection(g.db);

            DataTable dt1;
            dt1 = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand("select '' [Location Code] " +
                    "union all " +
                    "SELECT DISTINCT [Location Code] FROM [ZYGO$Bin] ORDER BY [Location Code]", cnxn);
                SqlDataReader dr;

                cnxn.Open();
                dr = cmd.ExecuteReader();

                dt1.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            cbddLocationCode.DataSource = dt1;
            cbddLocationCode.DisplayMember = "Location Code";
        }

        
        private void cbddLocationCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbddLocationCode.SelectedIndex > 0)
            {
                g.location = cbddLocationCode.Text;
                BinCodeLabels b = new BinCodeLabels();
                b.ShowDialog();
            }
        }
    }

    public static class g
    {
        public static string location;
        //public static string item;
        //public static string iDescription;
        //public static string iRevision;
        //public static string editRevision;
        //public static string iSerialNumber;
        //public static string iQuantity;
        //public static string iNumberofBoxes;
        //public static string iLabelQuantity;
        //public static string printer;
        public static string db = "server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
                            "user = navdb_read; database = ZYGO-NAV-PROD;";
        //public static string NAVprefix = "ZYGO$";
    }
}
