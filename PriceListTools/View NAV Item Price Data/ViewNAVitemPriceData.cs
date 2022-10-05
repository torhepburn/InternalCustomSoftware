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


namespace View_NAV_Item_Price_Data
{
    public partial class F1_ViewNAVItemPrice : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        private string Sql =
            "with s1 as " +
            "(Select " +
            " [Item No_][Item Code] " +
            ",[Sales Code][Price List] " +
            ",MAX([Starting Date])[Start Date] " +
            " from[ZYGO$Sales Price] " +
            " GROUP BY[Item No_], [Sales Code] )" +
            "select " +
                "[Item No_] [Item Code] " +
                ",[Sales Code] [Price List] " +
                ",FORMAT([Unit Price], 'C') [Unit Price] " +
                ",CONVERT(varchar(10),[Starting Date], 1) [Start Date] " +
                ",CONVERT(varchar(10),[Ending Date], 101) [Expiration Date] " +
                "from [ZYGO$Sales Price] N " +
            "  Inner join s1 on N.[Item No_] = s1.[Item Code] " +
            "  and N.[Starting Date] = s1.[Start Date] " +
            "  and N.[Sales Code] = s1.[Price List] ";


        public F1_ViewNAVItemPrice()
        {
            InitializeComponent();
        }

        private void F1_ViewNAVItemPrice_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection("server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
                            "user = navdb_read; database = ZYGO-NAV-PROD;");
            
        }

        private void gridData()
        {
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;

            DGV.Columns[0].Width = 120;
            //DGV.Columns[1].Width = 60;
            //DGV.Columns[2].Visible = false;
        }


        private void bSearch_Click(object sender, EventArgs e)
        {
            try
            {
                da = new SqlDataAdapter
               (Sql +
                " where [Item No_] like '%" + tbSearchEquipment.Text.Trim() + "%' "
                , cnxn);

                gridData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("81 " + ex.Message);
            }
            finally
            {
                cnxn.Close();
            }
        }

        private void bItem_Click(object sender, EventArgs e)
        {
            try
            {
                da = new SqlDataAdapter
               (Sql +
                " where [Item No_] = '" + tbSearchEquipment.Text.Trim() + "' "
                , cnxn);

                gridData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("81 " + ex.Message);
            }
            finally
            {
                cnxn.Close();
            }
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
