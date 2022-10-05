using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;

namespace ActualProdHours
{
    class ActualProdHours
    {
        static OracleConnection conn = new OracleConnection();
        static OracleCommand cmd;
        static OracleDataAdapter da;
        static OracleCommandBuilder cb;
        static DataTable mkTable;

        static void Main(string[] args)
        {
                       Console.Title = "Update Actual Prod Hours";

            conn.ConnectionString = "user id=views;" +
                "Password=views;Data Source=//dbserver:1521/mkpd;";

            try
            {
                conn.Open();

                string sql = "select  " +
                             "production_order, " +
                             "operation, " +
                             "serial_number, " +
                             "task, " +
                             "work_center, " +
                             "machine, " +
                             "to_char(employee_hours), " +
                             "to_char(machine_hours), " +
                             "to_char(wage_costs), " +
                             "to_char(machine_costs), " +
                             "to_char(overhead_costs), " +
                             "to_char(subcontracting_costs), " +
                             "transaction_date " +
                             "from views600.actual_prod_hours";
                             //"from views200.actual_prod_hours " +
                             //"where transaction_date > (select sysdate -30 from dual)";

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
                ("server=midsql01; user=DatAn1; " +
                 "password=!1Develop; database=projects_600;");

            try
            {
                SqlCommand xcmd = new SqlCommand
                ("delete from mkActualProdHoursupdate", blCnxn);
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
            copy.DestinationTableName = "mkActualProdHoursupdate";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            blCnxn.Close();
            
            SqlCommand nCmd = new SqlCommand(
                "delete from ActualProdHours  " +
                //"transaction_date > (SELECT DATEADD(dd, -30, GETDATE()))", blCnxn);
                " ", blCnxn);
            nCmd.Connection.Open();
            nCmd.ExecuteNonQuery();
            blCnxn.Close();

            nCmd = new SqlCommand(
                "Insert into ActualProdHours " +
                "(project, " +
                "order_no, " +
                "operation, " +
                "serial_number, " +
                "task, " +
                "work_center, " +
                "machine, " +
                "employee_hours, " +
                "machine_hours, " +
                "wage_costs, " +
                "machine_costs, " +
                "overhead_costs, " +
                "subcontracting_costs, " +
                "transaction_date " +
                ") select " +
                "p.project, " +
                "h.production_order, " +
                "h.operation, " +
                "h.serial_number, " +
                "h.task, " +
                "h.work_center, " +
                "h.machine, " +
                "h.employee_hours, " +
                "h.machine_hours, " +
                "h.wage_costs, " +
                "h.machine_costs, " +
                "h.overhead_costs, " +
                "h.subcontracting_costs, " +
                "h.transaction_date " +
                "from mkActualProdHoursupdate h " +
                "inner join ProductionOrderFile p on " +
                "p.order_no = h.production_order", blCnxn);
            nCmd.Connection.Open();
            nCmd.ExecuteNonQuery();
            nCmd.Connection.Close();

            nCmd = new SqlCommand(
                "delete from ActualProdHours_Normalized", blCnxn);
            nCmd.Connection.Open();
            nCmd.ExecuteNonQuery();
            blCnxn.Close();

            nCmd = new SqlCommand(
                "Insert into ActualProdHours_Normalized " +
                "(project, " +
                "order_no, " +
                "operation, " +
                "serial_number, " +
                "task, " +
                "work_center, " +
                "machine_e, " +
                "employee_hours_e, " +
                "machine_hours_e, " +
                "wage_costs_e, " +
                "machine_costs_e, " +
                "overhead_costs_e, " +
                "subcontracting_costs_e " +
                ") select " +
                "project, " +
                "order_no, " +
                "operation, " +
                "serial_number, " +
                "task, " +
                "work_center, " +
                "machine, " +
                "employee_hours, " +
                "machine_hours, " +
                "wage_costs, " +
                "machine_costs, " +
                "overhead_costs, " +
                "subcontracting_costs " +
                "from ActualProdHours " +
                "where serial_number = 0", blCnxn);
            nCmd.Connection.Open();
            nCmd.ExecuteNonQuery();
            nCmd.Connection.Close();

            nCmd = new SqlCommand(
                "Update n " +
                "set " + 
                "n.machine_a = h.machine, " +
                "n.employee_hours_a = h.employee_hours, " +
                "n.machine_hours_a = h.machine_hours, " +
                "n.wage_costs_a = h.wage_costs, " +
                "n.machine_costs_a = h.machine_costs, " +
                "n.overhead_costs_a = h.overhead_costs, " +
                "n.subcontracting_costs_a = subcontracting_costs " +
                "from actualprodhours_normalized n " +
                "inner join actualprodhours h on " +
                "(h.operation = n.operation) and " +
                "(h.order_no = n.order_no) " +
                "where h.serial_number = 1", blCnxn);
            nCmd.Connection.Open();
            nCmd.ExecuteNonQuery();
            nCmd.Connection.Close();

            nCmd = new SqlCommand(
            "Insert into ActualProdHours_Normalized " +
            "(project, " +
            "order_no, " +
            "operation, " +
            "task, " +
            "work_center, " +
            "machine_a, " +
            "employee_hours_a, " +
            "machine_hours_a, " +
            "wage_costs_a, " +
            "machine_costs_a, " +
            "overhead_costs_a, " +
            "subcontracting_costs_a " +
            ") select " +
            "h.project, " +
            "h.order_no, " +
            "h.operation, " +
            "h.task, " +
            "h.work_center, " +
            "h.machine, " +
            "h.employee_hours, " +
            "h.machine_hours, " +
            "h.wage_costs, " +
            "h.machine_costs, " +
            "h.overhead_costs, " +
            "h.subcontracting_costs " +
            "from ActualProdHours h " +
            "left join actualprodhours_normalized n " +
            "on (h.operation = n.operation) and " +
            "(h.order_no = n.order_no) " +
            "where n.order_no is null and " +
            "h.serial_number = 1", blCnxn);
            nCmd.Connection.Open();
            nCmd.ExecuteNonQuery();
            nCmd.Connection.Close();

            nCmd = new SqlCommand(
                "Update actualprodhours_normalized " +
                "set " +
                "machine_hours_e = round(machine_hours_e,2), " +
                "machine_hours_a = round(machine_hours_a,2), " +
                "employee_hours_a = round(employee_hours_a,2)" , blCnxn);
            nCmd.Connection.Open();
            nCmd.ExecuteNonQuery();
            nCmd.Connection.Close();

            //modified from Ben becasue the created totals were not
            //available to be computed for the results so taking the 
            //columns which alread exist and calculating from them.
            nCmd = new SqlCommand(
                "Update actualprodhours_normalized " +
                "set " +
                "total_hours_e = employee_hours_e + machine_hours_e, " +
                "wage_and_overhead_costs_e = wage_costs_e + overhead_costs_e, " +
                "total_costs_e = wage_costs_e + overhead_costs_e + " +
                "machine_costs_e + subcontracting_costs_e, " +
                "total_hours_a = employee_hours_a + machine_hours_a, " +
                "wage_and_overhead_costs_a = wage_costs_a + overhead_costs_a, " +
                "total_costs_a = wage_costs_a + overhead_costs_a + " +
                "machine_costs_a + subcontracting_costs_a, " +
                "result_hours = (employee_hours_e + machine_hours_e) - " +
                "(employee_hours_a + machine_hours_a), " +
                "result_amount = (wage_costs_e + overhead_costs_e + " +
                "machine_costs_e + subcontracting_costs_e) - " +
                "(wage_costs_a + overhead_costs_a + " +
                "machine_costs_a + subcontracting_costs_a)", blCnxn);
            nCmd.Connection.Open();
            nCmd.ExecuteNonQuery();
            nCmd.Connection.Close();

            nCmd = new SqlCommand(
               "Update n " +
               "set " +
               "n.description = t.description " +
               "from actualprodhours_normalized n " +
               "inner join tasks t on " +
               "n.task = t.task", blCnxn);
            nCmd.Connection.Open();
            nCmd.ExecuteNonQuery();
            nCmd.Connection.Close();


        }
    }
}