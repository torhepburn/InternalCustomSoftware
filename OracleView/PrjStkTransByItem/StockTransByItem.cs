using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;

namespace PrjStkTransByItem
{
    class StockTransByItem
    {
        static OracleConnection conn = new OracleConnection();
        static OracleCommand cmd;
        static OracleDataAdapter da;
        static OracleCommandBuilder cb;
        static DataTable mkTable;
        
        static void Main(string[] args)
        {
            Console.Title = "Update StockTransByItem";

            conn.ConnectionString = "user id=views;" +
                "Password=views;Data Source=//dbserver:1521/mkpd;";

            try
            {
                conn.Open();

                string sql = "select  " +
                             "project, " +
                             "custom_item, " +
                             "warehouse, " +
                             "serial_nbr, " +
                             "trans_type, " +
                             "target_project, " +
                             "delivered_qty, " +
                             "target_warehouse, " +
                             "warehouse_order, " +
                             "trans_date, " +
                             "stock_trans, " +
                             "user_trans_entered, " +
                             "custom_item_description " +
                             "from views200.project_stk_trans_by_item " +
                             "where project > '0'";

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

            SqlConnection blCnxn = new SqlConnection
                ("server=middb01; user=DatAn1; " +
                 "password=!1Develop; database=projects;");


            try
            {
                SqlCommand xcmd = new SqlCommand
                ("delete from StockTransByItem", blCnxn);
                xcmd.Connection.Open();
                xcmd.ExecuteNonQuery();
                xcmd.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            blCnxn.Open();
            SqlBulkCopy copy = new SqlBulkCopy(blCnxn);
            copy.DestinationTableName = "StockTransByItem";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            blCnxn.Close();

        }
    }
}
