using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;


namespace Customers1
{
    class Customers
    {
        static OracleConnection conn = new OracleConnection();
        static OracleCommand cmd;
        static OracleDataAdapter da;
        static OracleCommandBuilder cb;
        static DataTable mkTable;
        
        static void Main(string[] args)
        {
            Console.Title = "Customers";

            conn.ConnectionString = "user id=views;" +
                "Password=views;Data Source=//dbserver:1521/mkpd;";

            try
            {
                conn.Open();

                string sql = "select " +
                             "c.customer, " +
                             "c.name, " +
                             "c.postal_address, " +
                             "c.delivery_address, " +
                             "d.address as DelvAddr1, " +
                             "d.address_2 as DevlAddr2, " +
                             "d.city as DelvCity, " +
                             "d.state as DevlState, " +
                             "d.country as DelvCountry " +
                             "from views200.customers c " +
                             "left join views200.customers_postal_addresses p " +
                             "on c.postal_address = p.postal_address and " +
                             "c.customer = p.customer " +
                             "left join views200.delivery_addresses d on " +
                             "c.delivery_address = d.delivery_address and " +
                             "c.customer = d.customer";
                //"left join views200.delivery_addresses d " +
                  //           "


                             

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
                ("delete from customers", blCnxn);
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
            copy.DestinationTableName = "customers";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
