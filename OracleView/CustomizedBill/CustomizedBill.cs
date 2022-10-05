using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;

namespace CustomizedBill
{
    class CustomizedBill
    {
        static OracleConnection conn = new OracleConnection();
        static OracleCommand cmd;
        static OracleDataAdapter da;
        static OracleCommandBuilder cb;
        static DataTable mkTable;
        
        static void Main(string[] args)
        {

            Console.Title = "CustomizedBill";
            
            conn.ConnectionString = "user id=views;" +
                "Password=views;Data Source=//dbserver:1521/mkpd;";
            
            try
            {
                conn.Open();

                string sql = "select " +
                             "c.project, " +
                             "c.position, " +
                             "c.manufactured_item as ParentPart, " +
                             "c.item_code, " +
                             "c.item_description, " +
                             "c.net_quantity, " +
                             "c.item_type, " +
                             "i.standard_cost_price, " +
                             "i.material_costs, " +
                             "i.operation_costs " +
                             "from views200.customized_bill_of_material c " +
                             "left join views200.item_data i on c.item_code = i.item_code ";

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
                ("delete from customizedbill", blCnxn);
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
            copy.DestinationTableName = "customizedbill";
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