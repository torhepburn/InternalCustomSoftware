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

namespace HorshamTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string dbNAV = "server=pa-hor-as408.ametek.com; password=views; " +
                            "user=views; database=ZYGO-NAV-PROD;";
            
            SqlConnection X = new SqlConnection(dbNAV);

            SqlDataAdapter da;

            DataTable dt1;
        
            try
            {
                da = new SqlDataAdapter(
                " select [No_] [Item Code], [Description] FROM [ZYGO$Item] " +
                " ORDER BY [No_]", X);

                try
                {
                    dt1 = new DataTable();
                    da.Fill(dt1);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    X.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
