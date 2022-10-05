using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;


namespace ItemData4Sers
{
    class Program
    {
        static string select;
        static string tableName;
        static string cnxn = "provider=microsoft.jet.oledb.4.0;" +
                "server=mkpd;DSN=mkpd;uid=views; pwd=views; ";
        static SqlConnection SqlCnxn;
        static private string SqlDb = "server = midsql01; password = Read+Write!; user = readwrite; " +
                  "database = pricelists;";
        //BindingSource bs = new BindingSource();
        //SqlConnection SQLcnxn2;
        //SqlParameter stxt;
        //private string itemcode;
        //private string Stext;
        //private string flag;
        
        static void Main(string[] args)
        {
            SqlCnxn = new SqlConnection(SqlDb);
            SqlCommand cmd = new SqlCommand
                ("delete from SER_itemdata; " +
                 "delete from SER_ZAF; " +
                 "delete from SER_ZJV;", SqlCnxn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            select = "select " +
                "item_code, " +
                "description, " +
                "sales_price_group, " +
                "product_type, " +
                "item_group, " +
                "item_type, " +
                "material_costs, " +
                "operation_costs, " +
                "standard_cost_price, " +
                "selling_price " +
                "from views200.item_data " +
                "where (signal_code not like 'OBS%') " +
                " and description not like '%OBS%'";
            tableName = "SER_ItemData";

            makeTables();

            
            select = "select " +
                "item_code, " +
                "Price as transfer " +
                "from views200." +
                "prices_price_list_and_item_sls " +
                "where " +
                "effective_date > '06-Feb-1995' and " +
                "effective_date < sysdate and " +
                "expiry_date >= sysdate and " +
                "sales_price_list = 'ZAF'";

            tableName = "SER_ZAF";

            makeTables();

            select = "select " +
                "item_code, " +
                "Price as ZJV " +
                "from views200." +
                "prices_price_list_and_item_sls " +
                "where " +
                "effective_date > '06-Feb-1995' and " +
                "effective_date < sysdate and " +
                "expiry_date >= sysdate and " +
                "sales_price_list = 'ZJV'";

            tableName = "SER_ZJV";

            makeTables();

        }
        
        static private void makeTables()
        {
            Console.Title = tableName;
            
            OdbcConnection odBC = new OdbcConnection(cnxn);
            odBC.ConnectionTimeout = 6000;
            OdbcDataAdapter da = new OdbcDataAdapter
               (select, cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            
            SqlCnxn = new SqlConnection(SqlDb);

            SqlCnxn.Open();
            SqlBulkCopy copy = new SqlBulkCopy(SqlCnxn);
            copy.DestinationTableName = tableName;

            try
            {
                copy.WriteToServer(table);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            if (tableName == "SER_ItemData")
            {
                SqlCommand cmd = new SqlCommand
                    ("update ser_itemdata set " +
                     "dateupdated = '" + 
                     DateTime.Now + "'", SqlCnxn);
                int rows = cmd.ExecuteNonQuery();
            }

            SqlCnxn.Close();
            
        }
    }

}
        
