using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;

namespace Tasks
{
    class Tasks
    {
        static OracleConnection conn = new OracleConnection();
        static OracleCommand cmd;
        static OracleDataAdapter da;
        static OracleCommandBuilder cb;
        static DataTable mkTable;
        static SqlCommand xcmd;

        static void Main(string[] args)
        {
                       
            Console.Title = "Update Tasks";
            
            conn.ConnectionString = "user id=views;" +
                "Password=views;Data Source=//dbserver:1521/mkpd;";
            
            try
            {
                conn.Open();

                string sql = "select  " +
                             "task, " +
                             "description, " +
                             "search_key, " +
                             "task_type, " +
                             "hourly_wage_type, " +
                             "operation_rate_code, " +
                             "work_center, " +
                             "machine, " +
                             "setup_time, " +
                             "run_time, " +
                             "man_occupation, " +
                             "man_occupation_1, " +
                             "operation_overlap, " +
                             "extra_information, " +
                             "subcontracting_rate_factor, " +
                             "text, " +
                             "estimated_hours_needed, " +
                             "zygo_company_number " +
                             "from views200.tasks";

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
                 "password=!1Develop; database=projects;");


            try
            {
                xcmd = new SqlCommand
                ("delete from Tasks", blCnxn);
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
            copy.DestinationTableName = "Tasks";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Title = "Project Main Summary";

            xcmd = new SqlCommand(
                "delete from ProjectMainSummary", blCnxn);
            xcmd.ExecuteNonQuery();

            xcmd = new SqlCommand(
                "Insert into ProjectMainSummary " +
                "(project, " +
                "description, " +
                "description_1, " +
                "description_2, " +
                "description_3, " +
                "project_type, " +
                "project_status, " +
                "project_manager, " +
                "ProjectLeaderName, " +
                "project_stage, " +
                "StatusDesc, " +
                "customer, " +
                "CustomerName, " +
                "spent_hours, " +
                "project_text, " +
                "StartDate, " +
                "DeliveryDate, " +
                "FinishDate, " +
                "TransferPrice, " +
                "FinSalesAmount, " +
                "COGS, " +
                "FinCostAmount, " +
                "MaterialCost, " +
                "PurchaseCost, " +
                "OnOrdAmt, " +
                "LaborCost, " +
                "StockTransferCost, " +
                "SubContractCost, " +
                "TotalCost, " +
                "OpenAmt, " +
                "SumOfAmount, " +
                "TotalCost2, " +
                "DelvCity, " +
                "DelvCountry, " +
                "ConsultLabor, " +
                "ConsultMaterial, " +
                "ConsultTravel, " +
                "ConsultTotal " +
                ") select " +
                "p.project, " +
                "p.description, " +
                "p.description_1, " +
                "p.description_2, " +
                "p.description_3, " +
                "p.project_type, " +
                "p.project_status, " +
                "p.project_manager, " +
                "p.employeename, " +
                "p.project_stage, " +
                "p.projstatusdesc, " +
                "p.customer, " +
                "p.CustomerName, " +
                "p.spent_hours, " +
                "p.project_text, " +
                "p.start_date, " +
                "'', " +
                "'', " +
                "p.TransferPrice, " +
                "f.FinSalesAmount, " +
                "f.COGS, " +
                "f.FinCostAmount, " +
                "f.MaterialCost, " +
                "f.PurchaseCost, " +
                "u.OnOrdAmt, " +
                "f.LaborCost, " +
                "f.StockTransferCost, " +
                "f.SubContractCost, " +
                "f.TotalCost, " +
                "u.sumofopenamt, " +
                "s.sumofamount, " +
                "f.laborcost + f.materialcost + u.onordamt, " +
                "s.delvcity, " +
                "s.DelvCountry, " +
                "f.ConsultLabor, " +
                "f.ConsultMaterial, " +
                "f.ConsultTravel, " +
                "f.ConsultLabor + f.ConsultMaterial + f.ConsultTravel " +
                "from " +
                "tabprojectmaster p " +
                "left join " +
                "qryProjectFinTransSum f on " +
                "p.project = f.project " +
                "left join " +
                "qryProjectSalesOrderSum s " +
                "on p.project = s.project " +
                "left join qryProjectPurchaseOrderSum u " +
                "on p.project = u.project", blCnxn);

            xcmd.CommandTimeout = 60;

            xcmd.ExecuteNonQuery();

            
            blCnxn.Close();
        }
    }
}
