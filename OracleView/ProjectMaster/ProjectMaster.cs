using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;


namespace ProjectMaster
{
    class ProjectMaster
    {
        static OracleConnection conn = new OracleConnection();
        static OracleCommand cmd;
        static OracleDataAdapter da;
        static OracleCommandBuilder cb;
        static DataTable mkTable;
                
        static void Main(string[] args)
        {
            Console.Title = "ProjectMaster";
            
            conn.ConnectionString = "user id=views;" +
                "Password=views;Data Source=//dbserver:1521/mkpd;";
            
            try
            {
                conn.Open();

                string sql = "select " +
                             "p.project, " +
                             "p.description, " +
                             "p.description_1, " +
                             "p.description_2, " +
                             "p.description_3, " +
                             //"p.reference, " +
                             "p.project_type, " +
                             "p.project_status, " +
                             "p.project_stage, " +
                             "p.start_date, " +
                             "p.delivery_date, " +
                             "p.project_manager, " +
                             "e.name as EmployeeName, " +
                             "p.customer, " +
                             "c.name as CustomerName, " +
                             "p.spent_hours, " +
                             "p.project_text, " +
                             "p.first_free_item_code as Transferprice " +
                             "from views200.projects p left join " +
                             "views200.customers c on " +
                             "p.customer = c.customer " +
                             "left join views200.employees e on " +
                             "p.project_manager = e.employee " +
                             "where p.project > 0 order by p.project";

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
                ("delete from projectmaster", blCnxn);
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
            copy.DestinationTableName = "projectmaster";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            blCnxn.Close();

            try
            {
                SqlCommand xcmd = new SqlCommand
                ("update projectmaster set FileDate = " +
                 "(select format(getdate(), 'dd-MMM-yy'))", blCnxn);
                xcmd.Connection.Open();
                xcmd.ExecuteNonQuery();
                xcmd.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}