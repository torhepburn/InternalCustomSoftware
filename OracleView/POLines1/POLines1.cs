using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;

namespace POLines1
{
    class POLines1
    {
        static OracleConnection conn = new OracleConnection();
        static OracleCommand cmd;
        static OracleDataAdapter da;
        static OracleCommandBuilder cb;
        static DataTable mkTable;
        static SqlCommand xcmd;

        static void Main(string[] args)
        {
            Console.Title = "PO Line1";

            conn.ConnectionString = "user id=views;" +
                "Password=views;Data Source=//dbserver:1521/mkpd;";

            try
            {
                conn.Open();

                string sql = "select " +
                             "p.project, " +
                "p.order_no, " +
                "p.position, " +
                "p.supplier, " +
                "s.name," +
                "p.order_date, " +
                "p.item_code, " +
                "p.total_delivered_quantity, " +
                "p.total_backordered_quantity, " +
                "p.po_line_status, " +
                "p.price, " +
                "p.quantity, " +
                "p.amount, " +
                "p.order_policy, " +
                "p.delivery_date, " +
                "p.delivery_date_2, " +
                "p.delivery_date_confirmed " +
                "from views200.purchase_order_lines p left join views200.suppliers s " +
                "on p.supplier = s.supplier " +
                "where p.project > '1'";         
                    
                    

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
                ("delete from poline1", blCnxn);
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
            copy.DestinationTableName = "poline1";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                xcmd = new SqlCommand
                ("delete from projectpurchaseorders", blCnxn);
                xcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            xcmd = new SqlCommand
                ("insert into projectpurchaseorders (" +
                 "PROJECT, " +
                 "ORDER_NO, " +
                 "POSITION, " +
                 "SUPPLIER, " +
                 "NAME, " +
                 "OrderDate, " +
                 "ITEM_CODE, " +
                 "Item_Description, " +
                 "QtyRecd, " +
                 "SumOfTotal_Backordered_Quantity, " +
                 "PO_LINE_STATUS, " +
                 "MaxOfPrice, " +
                 "QtyOrd, " +
                 "Amount, " +
                 "OrdAmt, " +
                 "MaxOfOrder_Policy, " +
                 "OpenQty, " +
                 "OpenAmt, " +
                 "DELIVERY_DATE, " +
                 "DELIVERY_DATE_2, " +
                 "DELIVERY_DATE_CONFIRMED) " +
                 "select " +
                 "p.PROJECT, " +
                 "p.ORDER_NO, " +
                 "p.POSITION, " +
                 "p.SUPPLIER, " +
                 "p.NAME, " +
                 "MAX(order_date) as OrderDate, " +
                 "p.ITEM_CODE, " +
                 "c.DESCRIPTION as Item_Description, " +
                 "SUM(total_delivered_quantity) as QtyRecd, " +
                 "SUM(TOTAL_BACKORDERED_QUANTITY) as SumOfTotal_Backordered_Quantity, " +
                 "p.PO_LINE_STATUS, " +
                 "MAX(price) as MaxOfPrice, " +
                 "SUM(quantity) as QtyOrd, " +
                 "SUM(total_delivered_quantity * price) as Amount, " +
                 "SUM(amount) as OrdAmt, " +
                 "MAX(ORDER_POLICY) as MaxOfOrder_Policy, " +
                 "Max(CASE " +
                 " when total_delivered_quantity = 0 then quantity " +
                 " when total_delivered_quantity != 0 then total_backordered_quantity " +
                 " end) as OpenQty, " +
                 "MAX(CASE " +
                 " when total_delivered_quantity = 0 then quantity * price " +
                 " when total_delivered_quantity != 0 then total_backordered_quantity * PRICE  " +
                 " end) as OpenAmt, " +
                 "DELIVERY_DATE, " +
                 "DELIVERY_DATE_2, " +
                 "DELIVERY_DATE_CONFIRMED " +
                 "from dbo.POLine1 p left join customItems c on " +
                 "p.ITEM_CODE = c.ITEM_CODE and p.PROJECT = c.PROJECT " +
                 "group by " +
                 "p.PROJECT, " +
                 "p.ORDER_NO, " +
                 "p.POSITION, " +
                 "p.SUPPLIER, " +
                 "p.NAME, " +
                 "p.ITEM_CODE, " +
                 "c.DESCRIPTION, " +
                 "p.PO_LINE_STATUS, " +
                 "p.DELIVERY_DATE, " +
                 "p.DELIVERY_DATE_2, " +
                 "p.DELIVERY_DATE_CONFIRMED", blCnxn);

            xcmd.ExecuteNonQuery();
            


        }
    }
}