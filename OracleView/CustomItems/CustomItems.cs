using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;

namespace CustomItems
{
    class CustomItems
    {
        static OracleConnection conn = new OracleConnection();
        static OracleCommand cmd;
        static OracleDataAdapter da;
        static OracleCommandBuilder cb;
        static DataTable mkTable;
        
        static void Main(string[] args)
        {
            Console.Title = "Custom Items";

            conn.ConnectionString = "user id=views;" +
                "Password=views;Data Source=//dbserver:1521/mkpd;";

            try
            {
                conn.Open();

                string sql = "select " +
                             "'Custom' as ItemType, " +
                             "c.project, " +
                             "c.item_code, " +
                             "c.description as ParentDescription, " +
                             "max(c.purchase_price) as MaxOfPurcahsePrice, " +
                             "max(c.act_cost_price) as MaxOfAct_Cost_Price, " +
                             "c.actual_operation_costs, " +
                             "c.act_material_costs, " +
                             "c.item_description " +
                             "as Description1, " +
                             "c.est_material_costs, " +
                             "c.estimated_operation_costs, " +
                             "c.estimated_cost_price " +
                             "from views200.customized_items c inner join views200.projects p " +
                             "on c.project = p.project group by 'custom', c.project, c.item_code, " +
                             "c.description, c.actual_operation_costs, c.act_material_costs, c.item_description, " +
                             "c.est_material_costs, c.estimated_operation_costs, " +
                             "c.estimated_cost_price";
                                            
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
                ("delete from customitems", blCnxn);
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
            copy.DestinationTableName = "customitems";
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