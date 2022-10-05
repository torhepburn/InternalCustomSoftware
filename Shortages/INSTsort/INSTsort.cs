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

namespace INSTsort
{
    public partial class INSTsort : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;

        public INSTsort()
        {
            InitializeComponent();
        }

        private void INSTsort_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection("server = MIDSQL01; password = Read+Write!; " +
                            "user = readwrite; database = AccessFrontEnds;");

            da = new SqlDataAdapter
            (" Select ItemCode [Item Code], [Group], [Buyer],  ID " +
             " FROM shortage_list " +
             " WHERE DateArchived IS NULL " +
             " ORDER BY Buyer desc, ItemCode, ID ", cnxn);


            DataTable table = new DataTable();

            try
            {
                da.Fill(table);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DGV.DataSource = table;

            DGV.Columns[0].Width = 120;
            DGV.Columns[1].Width = 90;
            DGV.Columns[2].Width = 130;
            DGV.Columns[3].Width = 90;

            DGV.Show();
        }
    }
}
