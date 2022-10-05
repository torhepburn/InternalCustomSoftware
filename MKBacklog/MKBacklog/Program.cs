using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;

namespace MKBacklog
{
    class Program
    {
        static OracleConnection conn = new OracleConnection();
        static OracleCommand cmd;
        static OracleDataAdapter da;
        static OracleCommandBuilder cb;
        static DataTable mkTable;
        
        static void Main(string[] args)
        {
            conn.ConnectionString = "user id=views;" +
                "Password=views;Data Source=//dbserver:1521/mkpd;";
            //600
            try
            {
                conn.Open();

                string sql = "select " +
                             "r.receipt_number, " +
                             "r.item_code, " +
                             "r.item_description as receipt_item_description, " +
                             "l.description as business_line_description " +
                             "from views600.receipts r " +
                             "inner join views600.suppliers s on " +
                             "r.supplier = s.supplier " +
                             "left join views600.Lines_of_Business l on " +
                             "s.line_of_business = l.code " +
                             "where r.receipt_date > '01-JUL-2009'" +
                             "order by receipt_number";

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
                Console.Write(ex.Message);
            }

            SqlConnection blCnxn = new SqlConnection
                ("server=midsql01; user=readwrite; " +
                 "password=Read+Write!; database=webtables;");
            

            try
            {
                SqlCommand xcmd = new SqlCommand
                ("delete from backlogmk600", blCnxn);
                xcmd.Connection.Open();
                xcmd.ExecuteNonQuery();
                xcmd.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
            }
            blCnxn.Open();
            SqlBulkCopy copy = new SqlBulkCopy(blCnxn);
            copy.DestinationTableName = "backlogmk600";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }


            //200
            try
            {
                conn.Open();

                string sql = "select " +
                             "r.receipt_number, " +
                             "r.item_code, " +
                             "r.item_description as receipt_item_description, " +
                             "l.description as business_line_description " +
                             "from views200.receipts r " +
                             "inner join views200.suppliers s on " +
                             "r.supplier = s.supplier " +
                             "left join views200.Lines_of_Business l on " +
                             "s.line_of_business = l.code " +
                             "where r.receipt_date > '01-JUL-2009'" +
                             "order by receipt_number";

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
                Console.Write(ex.Message);
            }

            blCnxn = new SqlConnection
                ("server=midsql01; user=readwrite; " +
                 "password=Read+Write!; database=webtables;");


            try
            {
                SqlCommand xcmd = new SqlCommand
                ("delete from backlogmk200", blCnxn);
                xcmd.Connection.Open();
                xcmd.ExecuteNonQuery();
                xcmd.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
            }
            blCnxn.Open();
            copy = new SqlBulkCopy(blCnxn);
            copy.DestinationTableName = "backlogmk200";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            // update tables for commodity class

            SqlCommand cmd1 = new SqlCommand(
                   "CommodityClass", blCnxn);
            cmd1.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
            }

            // take care of nulls in report

            cmd1 = new SqlCommand(
                   "rpt200", blCnxn);
            cmd1.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd1.CommandTimeout = 120;  //seconds
                cmd1.ExecuteNonQuery();
                blCnxn.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
    }
}
