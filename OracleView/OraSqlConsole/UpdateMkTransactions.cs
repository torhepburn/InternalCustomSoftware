using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace OraSqlConsole
{
    class UpdateMkTransactions
    {
        static OracleConnection conn = new OracleConnection();
        static OracleCommand cmd;
        static OracleDataAdapter da;
        static OracleCommandBuilder cb;
        static DataTable mkTable;
        static SqlCommand xcmd;

        static void Main(string[] args)
        {


            Console.Title = "Update Mk Transactions";

            conn.ConnectionString = "user id=views;" +
                "Password=views;Data Source=//dbserver:1521/mkpd;";

            try
            {
                conn.Open();

                string sql = "select f.project, " +
                             "f.order_type, " +
                             "f.order_number, " +
                             "f.position, " +
                             "f.transaction_type, " +
                             "f.transaction_date, " +
                             "f.transaction_time, " +
                             "f.srno, " +
                             "to_char(f.number_of_units), " +
                             "to_char(f.amount), " +
                             "f.financial_period, " +
                             "f.processing_date, " +
                             "f.cost_price_component, " +
                             "c.cost_type, " +
                             "c.description as CostPriceDesc, " +
                             "f.journal, " +
                             "f.debit_cost_center, " +
                             "f.debit_ledger_account, " +
                             "f.credit_cost_center, " +
                             "credit_ledger_account " +
                             "from views200.financial_project_transactions f left join " +
                             "views200.cost_price_components c on " +
                             "f.cost_price_component = c.cost_price_component " +
                             "where f.transaction_date <= (select sysdate -500 from dual)"; 

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
                File.AppendAllText("c:\\a\\mkerror.txt", ex.Message.ToString());
            }

            SqlConnection blCnxn = new SqlConnection
                ("server=midsql01; user=DatAn1; " +
                 "password=!1Develop; database=generalledger;");
            blCnxn.Open();

            try
            {
                xcmd = new SqlCommand
                ("delete from finprojtranx", blCnxn);
                xcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            SqlBulkCopy copy = new SqlBulkCopy(blCnxn);
            copy.DestinationTableName = "finprojtranx";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //xcmd = new SqlCommand(
            //    "delete from finprojtransactions ", blCnxn);

            //xcmd.ExecuteNonQuery();
            ////blCnxn.Close();

            //xcmd = new SqlCommand(
            //    "insert into finprojtransactions ( " +
            //    "project, " +
            //    "order_type, " +
            //    "order_number, " +
            //    "position, " +
            //    "transaction_type, " +
            //    "transaction_date, " +
            //    "transaction_time, " +
            //    "srno, " +
            //    "number_of_units, " +
            //    "amount, " +
            //    "financial_period, " +
            //    "processing_date, " +
            //    "cost_price_component, " +
            //    "cost_type, " +
            //    "journal, " +
            //    "debit_cost_center, " +
            //    "debit_ledger_account, " +
            //    "credit_cost_center, " +
            //    "credit_ledger_account " +
            //    ") select " +
            //    "project, " +
            //    "order_type, " +
            //    "order_number, " +
            //    "position, " +
            //    "transaction_type, " +
            //    "transaction_date, " +
            //    "transaction_time, " +
            //    "srno, " +
            //    "number_of_units, " +
            //    "amount, " +
            //    "financial_period, " +
            //    "processing_date, " +
            //    "cost_price_component, " +
            //    "cost_type, " +
            //    "journal, " +
            //    "debit_cost_center, " +
            //    "debit_ledger_account, " +
            //    "credit_cost_center, " +
            //    "credit_ledger_account " +
            //    "from mkTransactionsupdate", blCnxn);
            //xcmd.ExecuteNonQuery();
            

        }
    }
}
