using System;
using System.Collections.Generic;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;

namespace BacklogMK
{
    class Program
    {
        static OracleConnection conn = new OracleConnection();
        
        static void Main(string[] args)
        {
            conn.ConnectionString = "user id=views; " +
                "password=views; datasource=//dbserver:1521/mkpd;";
            conn.Open();
            string sql = "select " +
                         "r.receipt_number, " +
                         "r.item_description, " +
                         "l.description " +
                         "from views600.receipts r " +
                         "inner join views600.suppliers s on " +
                         "r.supplier = s.supplier " +
                         "left join views600.lines_of_business l on" +
                         "s.line_of_business = l.code " +
                         "where r.receipt_date > '1/1/2009'";
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            OracleCommandBuilder cb = new OracleCommandBuilder(da);
            DataTable table = new DataTable();
            da.Fill(table);

            Console.ReadLine();
        }
    }
}
