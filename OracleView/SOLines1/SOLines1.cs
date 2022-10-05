using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;


namespace SOLines1
{
    class SOLines1
    {
        static OracleConnection conn = new OracleConnection();
        static OracleCommand cmd;
        static OracleDataAdapter da;
        static OracleCommandBuilder cb;
        static DataTable mkTable;
        
        static void Main(string[] args)
        {
            Console.Title = "Canon Sales Data";

            SqlConnection cnxn = new SqlConnection("server=midsql01; user=readwrite; " +
                 "password=Read+Write!; database=accessfrontends;");

            DataTable table = new DataTable();

            SqlDataAdapter Sda = new SqlDataAdapter("select distinct zygo_pn " +
                "from Labels.ZygoAmetekCanonMappings", cnxn);

            Sda.Fill(table);

            string Canon = " ";

            for (int i = 0; i<table.Rows.Count; i++)
            {
                if (i == 0)
                {
                    Canon = Canon + "'" + table.Rows[i][0].ToString();
                }

                Canon = Canon + "', '" + table.Rows[i][0].ToString();
            }

            conn.ConnectionString = "user id=views;" +
                "Password=views;Data Source=//dbserver:1521/mkpd;";

            try
            {
                conn.Open();

                /*
                 * 
                 * select statement failed when o.route value 'sl001' was not capitalized 
                 * 
                 * */

                string sql = "select " +
                             "d.picking_list_number, " +
                             "d.order_no, " +
                             "d.position, " +
                             "d.srno, " +
                             "d.customer, " +
                             "d.item_code, " +
                             "d.ordered_quantity, " +
                             "d.warehouse " +
                             "from views200.sales_deliveries d inner join views200.sales_orders o on d.order_no = o.order_no where " +
                             "(d.customer = '1008JS' or d.customer = '9999AJ') and o.route = 'SL001' and " +
                             "d.item_code not like 'Freight%' and d.item_code in (" + Canon + "')";

                cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                da = new OracleDataAdapter(cmd);
                cb = new OracleCommandBuilder(da);
                mkTable = new DataTable();
                da.Fill(mkTable);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                SqlCommand xcmd = new SqlCommand
                ("DELETE from CANON_SALES_DELIVERIES", cnxn);
                xcmd.Connection.Open();
                xcmd.ExecuteNonQuery();
                xcmd.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            cnxn.Open();
            SqlBulkCopy copy = new SqlBulkCopy(cnxn);
            copy.DestinationTableName = "CANON_SALES_DELIVERIES";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cnxn.Close();
            }

    
            //SALES ORDERS

            try
            {
                conn.Open();

                string sql = "select " +
                             "order_no, " +
                             "[route], " +
                             "customer_po " +
                             "from views200.sales_orders where " +
                             "(customer = '1008JS' or customer = '9999AJ') and route = 'SL001'" ;

                cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                da = new OracleDataAdapter(cmd);
                cb = new OracleCommandBuilder(da);
                mkTable = new DataTable();
                da.Fill(mkTable);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                SqlCommand xcmd = new SqlCommand
                ("DELETE from CANON_SALES_ORDERS", cnxn);
                xcmd.Connection.Open();
                xcmd.ExecuteNonQuery();
                xcmd.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cnxn.Open();
            copy = new SqlBulkCopy(cnxn);
            copy.DestinationTableName = "CANON_SALES_ORDERS";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cnxn.Close();
            }


        }
    }
}