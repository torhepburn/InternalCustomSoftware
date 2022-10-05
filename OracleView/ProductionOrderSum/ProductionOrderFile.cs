using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;

namespace ProductionOrderSum
{
    class ProductionOrderFile
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

            try
            {
                conn.Open();

                string sql = "select project, " +
                             "order_no, " +
                             "item_code, " +
                             "delivery_date, " +
                             "item_description, " +
                             "order_quantity, " +
                             "cost_price, " +
                             "material_costs, " +
                             "operation_costs, " +
                             "production_year, " +
                             "production_week, " +
                             "hours_printed, " +
                             "order_status, " +
                             "total_scrapped, " +
                             "quantity_posted " +
                             "from views200.production_order_file " +
                             "order by delivery_date DESC ";
                             
                             //"where project > '0'";

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

/*            SqlConnection blCnxn = new SqlConnection
                ("server=middb01; user=DatAn1; " +
                 "password=!1Develop; database=projects;");


            try
            {
                SqlCommand xcmd = new SqlCommand
                ("delete from productionorderfile", blCnxn);
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
            copy.DestinationTableName = "productionorderfile";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
*/

        }
    }
}
