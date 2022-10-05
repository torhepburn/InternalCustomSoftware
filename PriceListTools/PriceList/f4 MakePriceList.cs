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
    public partial class f4_MakePriceList : Form
    {
        SqlConnection cnxn;

        public f4_MakePriceList()
        {
            InitializeComponent();
        }

        private void f4_MakePriceList_Load(object sender, EventArgs e)
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
                "(price_list_description, " +
                "sales_price_list, " +
                "item_code, " +
                "sales_text, " +
                "itemclasscode, " +
                "itemnotes, " +
                "itemclass, " +
                "sales_price_group, " +
                "itemclasscodefolder, " +
                "price) " +
                 "select " +
                "l.price_list_description " +
                ",p.sales_price_list " +
                ",i.item_code " +
                ",SUBSTRING(t.sales_text, 0, 254) " +
                ",i.itemclasscode " +
                ",i.itemnotes " +
                ",c.itemclass " +
                ",d.sales_price_group " +
                ",c.itemclasscodefolder " +
                ",p.price " +
                "from ItemCodeClassNotes i  " +
                "left join PListItemSls p on p.item_code = i.item_code " +
                "left join itemclasses c on i.itemclasscode = c.itemclasscode " +
                "left join itemdata d on i.item_code = d.item_code " +
                "left join itemtext t on i.item_code = t.item_code " +
                "inner join pricelistcodes l on p.sales_price_list = l.price_list_code " +
                "where i.item_code is not null "
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

            //try
            //{
            //    SqlCommand cmd = new SqlCommand(
            //    "UPDATE FullPriceList " +
            //    "SET sales_price_group = 'COMMON - Multiple Product Lines' " +
            //    "WHERE itemclasscode = 'Common' "
            //    , cnxn);

            //    cnxn.Open();
            //    cmd.CommandTimeout = 300;   /* timeout in seconds */
            //    int rowsReturned = cmd.ExecuteNonQuery();
            //    cnxn.Close();
            //    this.Close();
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //try
            //{
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.Connection = cnxn;
            //    cmd.CommandText = "QWpricelists";
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.CommandTimeout = 600;   /* timeout in seconds */
            //    cnxn.Open();
            //    int rowsReturned = cmd.ExecuteNonQuery();
            //    cnxn.Close();

            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }

    //public static class g
    //{
    //    //public static string itemCode;
    //    //public static string ShortageID;
    //    //public static string ShortageGroup;
    //    //public static string ProductLine;
    //    //public static string task;
    //    //public static string origDelDate = string.Empty;
    //    //public static string PO;
    //    //public static string Supplier = string.Empty;
    //    //public static string PoQuantity = string.Empty;
    //    //public static string db = "server = CT-MID-SQL01; password = Read+Write!; " +
    //    public static string db = "server = CT-MID-SQL11; password = Read+Write!; user = readwrite; " +
    //                              "database = pricelists;";
    //    //public static string dbNAV = "server = MIDNAV01; password = views; " +
    //    //                    "user = views; database = ZYGO-NAV-TEST;";
    //    public static string dbNAV = "server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
    //                        "user = navdb_read; database = ZYGO-NAV-PROD;";
    //    /*public static string dbNAV = "server = pa-hor-as408.ametek.com; password = views; " +
    //                        "user = views; database = ZYGO-NAV-TEST;";*/
    //    //public static string NAVprefix = "ZYGO$";
    //    //public static string NAVprefix = "ZYGO$";
    //}
}