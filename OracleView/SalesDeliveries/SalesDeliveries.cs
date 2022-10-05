using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;


namespace SalesDeliveries
{
    class SalesDeliveries
    {
        static OracleConnection conn = new OracleConnection();
        static OracleCommand cmd;
        static OracleDataAdapter da;
        static OracleCommandBuilder cb;
        static DataTable mkTable;

        static void Main(string[] args)
        {
            Console.Title = "Sales Deliveries";

            conn.ConnectionString = "user id=views;" +
                "Password=views;Data Source=//dbserver:1521/mkpd;";

            try
            {
                conn.Open();

                string sql = "select " +
                             "order_no, " +
                             "position, " +
                             "srno, " +
                             "customer, " +
                             "project, " +
                             "item_code, " +
                             "cost_price_component, " +
                             "delivery_date, " +
                             "ordered_quantity, " +
                             "delivered_quantity " +
                             "back_order, " +
                             "recomended_quantity, " +
                             "picking_list_number, " +
                             "dispatch_note_number, " +
                             "invoice_date, " +
                             "invoice, " +
                             "consignment_note_number, " +
                             "sales_status_code, " +
                             "procedure_mask, " +
                             "cost_price, " +
                             "operation_costs, " +
                             "net_goods_amount, " +
                             "order_line_discount_amount, " +
                             "order_discount_amount, " +
                             "revision, " +
                             "contract, " +
                             "position_number, " +
                             "warehouse, " +
                             "line_discount, " +
                             "price, " +
                             "tax_amount, " +
                             "item_description, " +
                             "zygo_company_number, " +
                    "from views200.sales_deliveries";

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

            //try
            //{
            //    SqlCommand xcmd = new SqlCommand
            //    ("delete from salesdeliveries", blCnxn);
            //    xcmd.Connection.Open();
            //    xcmd.ExecuteNonQuery();
            //    xcmd.Connection.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            blCnxn.Open();
            SqlBulkCopy copy = new SqlBulkCopy(blCnxn);
            copy.DestinationTableName = "salesdeliveries";
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
