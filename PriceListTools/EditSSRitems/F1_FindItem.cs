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


namespace EditSSRitems
{
    public partial class F1_FindItem : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        private string Sql = String.Empty;

        public F1_FindItem()
        {
            InitializeComponent();
        }

        private void F1_FindItem_Load(object sender, EventArgs e)
        {
            this.Text = "Edit SSR Price List v" + Application.ProductVersion;

            System.Security.Principal.WindowsIdentity userBase;
            userBase = System.Security.Principal.WindowsIdentity.GetCurrent();

            string user = string.Empty;
                        
            user = userBase.Name.ToUpper().Replace("AMETEK-AD\\", "");
            
            if (user != "THEPBURN" & user != "THEPBURN-SA" & user != "KHUGHES")
            {
                MessageBox.Show("You are not logged in as Thepburn, OR KHughes");

                this.Close();
            }

            Sql = "select " +
                "RTRIM(item_code) [Item Code] " +
                ",RTRIM(sales_text) as [Sales Text] " +
                ",sales_price_group " +
                ",[price list code] " +
                ",[price list description] " +
                "from SSR_Product_List " + 
                "group by item_code, sales_text, sales_price_group, [price list code],[price list description] ORDER BY item_code";

            gridData();
        }

        private void gridData()
        {
            cnxn = new SqlConnection(g.db);

            try
            {
                da = new SqlDataAdapter(Sql, cnxn);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("65 " + ex.Message);
            }
            finally
            {

            }

            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;

            DGV.Columns[0].Width =200;
            DGV.Columns[1].Width = 2000;
            DGV.Columns[2].Visible = false;
            DGV.Columns[3].Visible = false;
            DGV.Columns[4].Visible = false;
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            Sql = "select " +
                  "RTRIM(item_code) [Item Code] " +
                  ",RTRIM(sales_text) as [Sales Text] " +
                  ",sales_price_group " +
                  ",[price list code] " +
                  ",[price list description] " +
                  "from SSR_Product_List " +
                  " where item_code like '%" + tbSearchEquipment.Text.Trim() + "%' " +
                  "group by item_code, sales_text, sales_price_group, [price list code], [price list description]";

            gridData();
        }

        private void bItem_Click(object sender, EventArgs e)
        {
            g.itemCode = tbSearchEquipment.Text.ToString().Trim().ToUpper();
            tbSearchEquipment.Text = "";

            try
            {
                SqlDataAdapter da1 = new SqlDataAdapter
                    (Sql +
                    "where item_code = '" + g.itemCode + "'", cnxn);
                DataTable table = new DataTable();
                da1.Fill(table);

                g.itemCode = table.Rows[0][0].ToString().Trim();
                g.salestext = table.Rows[0][1].ToString().Trim();
                g.salespricegroup = table.Rows[0][2].ToString().Trim();

                g.task = "EDIT";
                F2_EditItem f2 = new F2_EditItem();
                f2.ShowDialog();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Item" + ex.Message);
            }
            finally
            {

            }
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.itemCode = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.salestext = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.salespricegroup = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                g.pricelistcode = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[4];
                g.pricelistdescription = cell.EditedFormattedValue.ToString().Trim();

                if (g.task == "DELETE")
                {
                    
                    

                        DialogResult result = MessageBox.Show("Are you sure you want to delete item " + g.itemCode + " ?", "",
                            MessageBoxButtons.YesNo);

                        if (result == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            try
                            {
                                cnxn.Open();
                                SqlCommand cmd = new SqlCommand(
                                    "DELETE FROM SSR_Product_List WHERE Item_Code = '" + g.itemCode + "'"
                                    , cnxn);
                                cmd.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            finally
                            {
                                cnxn.Close();
                            }

                            gridData();
                        }
                    
                }
                else 
                {
                    g.task = "EDIT";
                    F2_EditItem f2 = new F2_EditItem();
                    f2.ShowDialog();
                }
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            g.task = "ADD";
            F2_EditItem f2 = new F2_EditItem();
            f2.ShowDialog();
            g.task = string.Empty;
            gridData();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (LDelete.Visible)
            {
                LDelete.Visible = false;
            }
            else
            {
                LDelete.Visible = true;
                g.task = "DELETE";
            }
        }

        private void F1_FindItem_Activated(object sender, EventArgs e)
        {
            gridData();
        }
    }

    public static class g
    {
        public static string itemCode;
        public static string salestext;
        public static string salespricegroup;
        public static string pricelistcode;
        public static string pricelistdescription;
        public static string task;
        public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                                  "user = readwrite; database = PriceLists;";
        public static string dbNAV = "server = PA-HOR-AS408; password = 2018#ameteK; " +
                                  "user = navdb_read; database = ZYGO-NAV-PROD;";
    }
}
