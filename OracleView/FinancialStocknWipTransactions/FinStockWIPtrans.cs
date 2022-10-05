using System;
using System.Collections.Generic;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;

namespace FinancialStocknWipTransactions
{
    class FinStockWIPtrans
    {
        static OracleConnection conn = new OracleConnection();
        static OracleCommand cmd;
        static OracleDataAdapter da;
        static OracleCommandBuilder cb;
        static DataTable mkTable;
        static SqlConnection blCnxn = new SqlConnection
                ("server=midsql01; user=readwrite; " +
                 "password=Read+Write!; database=accessfrontends;");
        static SqlBulkCopy copy = new SqlBulkCopy(blCnxn);
        static SqlCommand xcmd;
        static void Main(string[] args)
        {

            Console.Title = "Update Financial Transactions";

            try
            {
                conn.Open();

                string sql = "select " +
                             //"order_type, " +
                             //"order_number, " +
                             //"position, " +
                             //"transaction_type, " +
                             //"transaction_date, " +
                             //"transaction_time, " +
                             //"serial_number, " +
                             //"to_char(number_of_units), " +
                             //"to_char(amount), " +
                             //"warehouse, " +
                             //"item_code, " +
                             //"financial_trn_processed, " +
                             //"posting_date, " +
                             //"financial_period, " +
                             //"journal, " +
                             //"journal_batch_no, " +
                             //"document_number, " +
                             //"line_number, " +
                             //"debit_ledger_account, " +
                             //"debit_cost_center, " +
                             //"credit_ledger_account, " +
                             //"credit_cost_center, " +
                             //"financial_trn_printed, " +
                             //"scrap_reason_code, " +
                             //"scrap_operation_number, " +
                             //"expense_reason_code, " +
                             //"schedule_number, " +
                             //"manufactured_item_code, " +
                             //"manufactured_item_warehouse, " +
                             //"operation_route, " +
                             //"actual_delivery_date, " +
                             //"work_center, " +
                             //"receipt_number, " +
                             //"date_trans_entered, " +
                             //"time_trans_entered, " +
                             //"user_entered, " +
                             //"item_description, " +
                             "zygo_company_number " +
                             "from views200.financial_stock_and_wip_trans " +
                             "where transaction_date > '05-SEP-2013'";
                             //"where transaction_date > (select sysdate -30 from dual)";

                cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 120;

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

            try
            {
                xcmd = new SqlCommand
                ("delete from mmx_financial_stock_and_wip_trans after_07012011", blCnxn);
                xcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            copy = new SqlBulkCopy(blCnxn);
            copy.DestinationTableName = " mmx_financial_stock_and_wip_trans after_07012011";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //xcmd = new SqlCommand(
            //    "delete from finprojtransactions where " +
            //    "transaction_date > (SELECT DATEADD(dd, -30, GETDATE()))", blCnxn);

            //xcmd.ExecuteNonQuery();

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
