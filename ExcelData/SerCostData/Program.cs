using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;
using System.Data.Odbc;
using System.Data.SqlClient;


namespace SerCostData
{
    class Program
    {
        static string tableName;
        static string cnxn = "provider=microsoft.jet.oledb.4.0;" +
            "server=mkpd;DSN=mkpd;uid=views; pwd=views; ";
        static string select;
        static string SqlDb = "server = midsql01; password = Read+Write!; user = readwrite; " +
                  "database = pricelists;";
 
        static void Main(string[] args)
        {
            Console.Title = "Regenerate SER Cost Data";
            
            SqlConnection SqlCnxn = new SqlConnection(SqlDb);
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

            
            select = "select " +
                " * " +
                "from  " +
                "seritemdata order by item_code";
 
            SqlCnxn = new SqlConnection(SqlDb); 
            SqlDataAdapter da = new SqlDataAdapter(select, SqlCnxn);
            System.Data.DataTable table = new System.Data.DataTable();
            da.Fill(table);
            
            SqlCnxn.Close();

            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel.Workbook oWB;
            Microsoft.Office.Interop.Excel.Worksheet oWS;
            Microsoft.Office.Interop.Excel.Range oRng;

            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.DisplayAlerts = false;

            oWB = oXL.Workbooks.Open(@"\\zygocorp\departments\engineering\sers\mk std item cost data\SerCostData.xlsx",
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value);
            oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("complete list");
            
            oRng = oWS.get_Range("A6", Missing.Value);
            oRng = oRng.get_Resize(table.Rows.Count, table.Columns.Count);

            Microsoft.Office.Interop.Excel.Range columnNameRange;
            columnNameRange = oWS.get_Range("A6", Missing.Value);
            columnNameRange = columnNameRange.get_Resize(1, table.Columns.Count);

            string[] columnNames = new string[table.Columns.Count];

            for (int i = 0; i < table.Columns.Count; i++)
            {

                columnNames[i] = table.Columns[i].ColumnName;
                columnNameRange.set_Value(Missing.Value, columnNames);
            }

            string[,] arr = new string[table.Rows.Count, table.Columns.Count];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    arr[i, j] = table.Rows[i][j].ToString().Trim();
                }
            }
            oRng.set_Value(Missing.Value, arr);
            oWB.Close(true, @"\\zygocorp\departments\engineering\sers\mk std item cost data\SerCostData.xlsx", Missing.Value);

            if (oXL != null)
            {
                oXL.UserControl = false;
                oXL.Quit();
                oXL = null;
            }
        }

        private static void makeTables()
        {
            OdbcConnection odBC = new OdbcConnection(cnxn);
            odBC.ConnectionTimeout = 6000;
            OdbcDataAdapter da = new OdbcDataAdapter
               (select, cnxn);
            System.Data.DataTable table = new System.Data.DataTable();
            da.Fill(table);

            SqlConnection SqlCnxn = new SqlConnection(SqlDb);

            SqlCnxn.Open();
            SqlBulkCopy copy = new SqlBulkCopy(SqlCnxn);
            copy.DestinationTableName = tableName;

            try
            {
                copy.WriteToServer(table);
            }
            catch (Exception ex)
            {
                return;
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
