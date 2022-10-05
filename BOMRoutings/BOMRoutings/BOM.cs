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

namespace BOMRoutings
{
    public partial class BOM : Form
    {
        SqlConnection cnxn = new SqlConnection(g.db);
        SqlDataAdapter da;
        DataTable table;

        public BOM()
        {
            InitializeComponent();
        }

        private void BOM_Load(object sender, EventArgs e)
        {
            try
            {
                cnxn.Open();
                da = new SqlDataAdapter(
                    "SELECT " +
                    " [Operation No_] OP " +
                    ",[Work Center No_] WC " +
                    ",[Description] " +
                    ",FORMAT([Setup Time], 'N3') [Setup Time] " +
                    ",FORMAT([Run Time], 'N3') [Run Time]" +
                    " FROM [" + g.NAVprefix + "Routing Line] " +
                    " WHERE [Routing No_] = '" + g.routingNumber + "' " +
                    " AND [Version Code] = 01 ORDER BY [Operation No_]", cnxn);
                table = new DataTable();
                da.Fill(table);
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("BOM Page " + ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            DGV.DataSource = table;
            DGV.Show();
            DGV.Columns[0].Width = 45;
            DGV.Columns[1].Width = 40;

        }
    }
}
