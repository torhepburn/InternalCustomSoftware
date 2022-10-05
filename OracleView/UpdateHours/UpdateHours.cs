using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace UpdateHours
{
    class UpdateHours
    {
        static OracleConnection conn = new OracleConnection();
        static OracleCommand cmd;
        static OracleDataAdapter da;
        static OracleCommandBuilder cb;
        static DataTable mkTable;
        static SqlCommand xcmd;
        static SqlConnection blCnxn = new SqlConnection
                ("server=midsql01; user=DatAn1; " +
                 "password=!1Develop; database=projects;");
        static SqlBulkCopy copy = new SqlBulkCopy(blCnxn);
        
        static void Main(string[] args)
        {
            Console.Title = "Employee Hours";

            try
            {
                conn.ConnectionString = "user id=views;" +
                "Password=views;Data Source=//dbserver:1521/mkpd;";
                
                conn.Open();

                string sql = "select   " +
                             "h.project, " +
                             "h.transaction_type, " +
                             "h.employee, " +
                             "e.name, " +
                             "e.work_center, " +
                             "w.description, " +
                             "h.year, " +
                             "h.week, " +
                             "h.day, " +
                             "h.order_no, " +
                             "h.man_time, " +
                             "h.machine_hours, " +
                             "case when h.employee = 0 " +
                             "then h.machine_hours else " +
                             "h.man_time end as man_machine_time, " +
                             "h.actual_wage_costs, " +
                             "h.actual_overhead_costs, " +
                             "h.production_date " +
                             "from views200.hours_accounting_by_employee h " +
                             "left join views200.employees e on " +
                             "h.employee = e.employee " +
                             "left join views200.work_centers w on " +
                             "e.work_center = w.work_center " +
                             "where h.project > '1' " +
                             "and " +
                             "h.production_date > (select sysdate -30 from dual)";
                
                
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

            blCnxn.Open();
            try
            {
                xcmd = new SqlCommand
                ("delete from hoursupdate", blCnxn);
                xcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                File.AppendAllText(@"c:\a\hours.txt", ex.Message + Environment.NewLine);
            }
            copy = new SqlBulkCopy(blCnxn);
            copy.DestinationTableName = "hoursupdate";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                File.AppendAllText(@"c:\a\hours.txt", ex.Message + Environment.NewLine);
            }

            //xcmd = new SqlCommand("select top 1 production_date " +
            // "from hoursupdate " +
            // "order by production_date asc", blCnxn); ;
            //xcmd.Connection = blCnxn;
            //object o = xcmd.ExecuteScalar();

            //string pdate = o.ToString().Trim();

            //xcmd = new SqlCommand("delete from employeehours where " +
            //    "production_date >= '" + pdate + "' ", blCnxn);
            xcmd = new SqlCommand("delete from employeehours", blCnxn);

            xcmd.ExecuteNonQuery();



            xcmd = new SqlCommand
                ("insert into employeehours (" +
                  "project, " +
                  "transaction_type, " +
                  "employee, " +
                  "[name], " +
                  "work_center, " +
                  "description, " +
                  "[year], " +
                  "[week], " +
                  "[day], " +
                  "order_no, " +
                  "man_time, " +
                  "machine_hours, " +
                  "man_machine_time, " +
                  "actual_wage_costs, " +
                  "actual_overhead_costs, " +
                  "production_date ) " +
                  "select " +
                  "project, " +
                  "transaction_type, " +
                  "employee, " +
                  "[name], " +
                  "work_center, " +
                  "description, " +
                  "[year], " +
                  "[week], " +
                  "[day], " +
                  "order_no, " +
                  "man_time, " +
                  "machine_hours, " +
                  "man_machine_time, " +
                  "actual_wage_costs, " +
                  "actual_overhead_costs, " +
                  "production_date " +
                  "from hoursupdate", blCnxn);
            xcmd.ExecuteNonQuery();

            xcmd = new SqlCommand
            ("update employeehours set last_transaction_date = c.date, " +
             "financial_period = c.financial_period  from employeehours h " +
             "inner join tabcalperiodwk c on " +
             "(h.day = c.mfgday and h.week = c.week and h.year = c.year) " +
                // "where production_date >= '" + pdate + "' ", blCnxn);
             " ", blCnxn);
            xcmd.ExecuteNonQuery();

            xcmd = new SqlCommand("updateprojecthrssumbymonth", blCnxn);
            xcmd.CommandType = CommandType.StoredProcedure;
            xcmd.CommandTimeout = 200;
            xcmd.ExecuteNonQuery();

        }
    }
}
