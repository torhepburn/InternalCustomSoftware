using System;
using System.Collections.Generic;
using System.Linq;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;

namespace GeneralProjectCosts
{
    class GeneralProjectCosts
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

                string sql = "select " +
                             "g.project, " +
                             "g.srno, " +
                             "g.description, " +
                             "g.document_number, " +
                             "g.transaction_date, " +
                             "g.cost_price_component, " +
                             "c.description as CostPriceDesc, " +
                             "g.number_of_units, " +
                             "g.amount " +
                             "from views200.general_project_costs g " +
                             "inner join views200.cost_price_components c " +
                             "on g.cost_price_component = c.cost_price_component " +
                             "where g.project > '0'";

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
                ("delete from generalprojectcosts", blCnxn);
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
            copy.DestinationTableName = "generalprojectcosts";
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
