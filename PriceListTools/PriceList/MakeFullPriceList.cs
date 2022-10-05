using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PriceList
{
    public partial class MakeFullPriceList : Form
    {
        SqlConnection cnxn;

        public MakeFullPriceList()
        {
            InitializeComponent();
        }

        private void MakeFullPriceList_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
        }

        private void BmakePL_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from FullPriceList", cnxn);
                cnxn.Open();
                cmd.CommandTimeout = 300;   /* timeout in seconds */
                int rowsReturned = cmd.ExecuteNonQuery();
                cnxn.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                SqlCommand cmd = new SqlCommand(
                "insert into FullPriceList " +
                "( " +
                "sales_price_list " +
                ",itemclasscodefolder " +
                ",item_code " +
                ",itemclasscode " +
                ",price_list_description " +
                ",sales_text " +
                ",sales_price_group " +
                ",price) " +
                 "select " +
                "[Sales Code] " +
                ", [Folder] " +
                ", [Item Number] " +
                ", [Price List Code] " +
                ", [Price List Description] " +
                ", COALESCE([Text],'') [Text] " +
                ",Sales_Price_Group " +
                ",[Unit Price] " +
                "FROM [PriceList_s1] i " +
                "LEFT JOIN ItemText t ON [Item Number] = t.ItemNo COLLATE DATABASE_DEFAULT " +
                "UNION " +
                "SELECT " +
                "sales_price_list " +
                ",[Price List ID] " +
                ", item_code " +
                ",[Price List Code] " +
                ",[Price List Description] " +
                ", sales_Text " +
                ",sales_price_group " +
                ",Price " +
                "FROM SSR_Product_List" 
                , cnxn);

                cnxn.Open();
                cmd.CommandTimeout = 300;   /* timeout in seconds */
                int rowsReturned = cmd.ExecuteNonQuery();
                cnxn.Close();
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnxn.Close();
            }

            try
            {
                SqlCommand cmd = new SqlCommand(
                "UPDATE FullPriceList " +
                "SET sales_price_group = 'COMMON - Multiple Product Lines' " +
                "WHERE itemclasscode = 'Common' "
                , cnxn);

                cnxn.Open();
                cmd.CommandTimeout = 300;   /* timeout in seconds */
                int rowsReturned = cmd.ExecuteNonQuery();
                cnxn.Close();
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnxn.Close();
            }

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnxn;
                cmd.CommandText = "QWpricelists";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 600;   /* timeout in seconds */
                cnxn.Open();
                int rowsReturned = cmd.ExecuteNonQuery();
                cnxn.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnxn.Close();
            }

            try
            {
                SqlCommand cmd = new SqlCommand(
                "UPDATE FullPriceList " +
                "update FullPriceList set itemclass = price_list_description "
                , cnxn);

                cnxn.Open();
                cmd.CommandTimeout = 300;   /* timeout in seconds */
                int rowsReturned = cmd.ExecuteNonQuery();
                cnxn.Close();
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnxn.Close();
            }
        }


    }

    public static class g
    {
        //public static string itemCode;
        //public static string ShortageID;
        //public static string ShortageGroup;
        //public static string ProductLine;
        //public static string task;
        //public static string origDelDate = string.Empty;
        //public static string PO;
        //public static string Supplier = string.Empty;
        //public static string PoQuantity = string.Empty;
        //public static string db = "server = CT-MID-SQL01; password = Read+Write!; " +
        public static string db = "server = CT-MID-SQL11.ametek.com; password = Read+Write!; user = readwrite; " +
                                  "database = pricelists;";
        //public static string dbNAV = "server = MIDNAV01; password = views; " +
        //                    "user = views; database = ZYGO-NAV-TEST;";
        public static string dbNAV = "server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
                            "user = navdb_read; database = ZYGO-NAV-PROD;";
        /*public static string dbNAV = "server = pa-hor-as408.ametek.com; password = views; " +
                            "user = views; database = ZYGO-NAV-TEST;";*/
        //public static string NAVprefix = "ZYGO$";
        //public static string NAVprefix = "ZYGO$";
    }
}
