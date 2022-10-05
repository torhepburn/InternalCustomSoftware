using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;


namespace ProjectTotal
{
    class ProjectTotal
    {
        static OracleConnection conn = new OracleConnection();
        static OracleCommand cmd;
        static OracleDataAdapter da;
        static OracleCommandBuilder cb;
        static DataTable mkTable;
        static SqlConnection blCnxn = new SqlConnection
                ("server=midsql01; user=DatAn1; " +
                 "password=!1Develop; database=projects;");
        static SqlBulkCopy copy = new SqlBulkCopy(blCnxn);
        static SqlCommand xcmd;

        static void Main(string[] args)
        {
            blCnxn.Open();
                        
            xcmd = new SqlCommand
                ("update updatelog set [start] = " +
                 "(select getdate())", blCnxn);
            xcmd.ExecuteNonQuery();

            conn.ConnectionString = "user id=views;" +
                "Password=views;Data Source=//dbserver:1521/mkpd;";

            ////1

            //Console.Title = "1.  Customers";


            //try
            //{
            //    conn.Open();

            //    string sql = "select " +
            //                 "c.customer, " +
            //                 "c.name, " +
            //                 "c.postal_address, " +
            //                 "c.delivery_address, " +
            //                 "d.address as DelvAddr1, " +
            //                 "d.address_2 as DevlAddr2, " +
            //                 "d.city as DelvCity, " +
            //                 "d.state as DevlState, " +
            //                 "d.country as DelvCountry " +
            //                 "from views200.customers c " +
            //                 "left join views200.customers_postal_addresses p " +
            //                 "on c.postal_address = p.postal_address and " +
            //                 "c.customer = p.customer " +
            //                 "left join views200.delivery_addresses d on " +
            //                 "c.delivery_address = d.delivery_address and " +
            //                 "c.customer = d.customer";

            //    cmd = new OracleCommand(sql, conn);
            //    cmd.CommandType = CommandType.Text;

            //    da = new OracleDataAdapter(cmd);
            //    cb = new OracleCommandBuilder(da);
            //    mkTable = new DataTable();
            //    da.Fill(mkTable);
            //    conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //try
            //{
            //    xcmd = new SqlCommand
            //    ("delete from customers", blCnxn);
            //    xcmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //copy = new SqlBulkCopy(blCnxn);
            //copy.DestinationTableName = "customers";
            //try
            //{
            //    copy.WriteToServer(mkTable);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            ////2

            //Console.Title = "2.  ProjectMaster";

            //try
            //{
            //    conn.Open();

            //    string sql = "select " +
            //                 "p.project, " +
            //                 "p.description, " +
            //                 "p.description_1, " +
            //                 "p.description_2, " +
            //                 "p.description_3, " +
            //                 //"p.reference, " +
            //                 "p.project_type, " +
            //                 "p.project_status, " +
            //                 "p.project_stage, " +
            //                 "p.start_date, " +
            //                 "p.delivery_date, " +
            //                 "p.project_manager, " +
            //                 "e.name as EmployeeName, " +
            //                 "p.customer, " +
            //                 "c.name as CustomerName, " +
            //                 "p.spent_hours, " +
            //                 "p.project_text, " +
            //                 "p.first_free_item_code as Transferprice " +
            //                 "from views200.projects p left join " +
            //                 "views200.customers c on " +
            //                 "p.customer = c.customer " +
            //                 "left join views200.employees e on " +
            //                 "p.project_manager = e.employee " +
            //                 "where p.project > 0 order by p.project";

            //    cmd = new OracleCommand(sql, conn);
            //    cmd.CommandType = CommandType.Text;

            //    da = new OracleDataAdapter(cmd);
            //    cb = new OracleCommandBuilder(da);
            //    mkTable = new DataTable();
            //    da.Fill(mkTable);
            //    conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //try
            //{
            //    xcmd = new SqlCommand
            //    ("delete from projectmaster", blCnxn);
            //    xcmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //copy = new SqlBulkCopy(blCnxn);
            //copy.DestinationTableName = "projectmaster";

            //try
            //{
            //    copy.WriteToServer(mkTable);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //try
            //{
            //    xcmd = new SqlCommand
            //    ("update projectmaster set FileDate = " +
            //     "(select format(getdate(), 'dd-MMM-yy'))", blCnxn);
            //    xcmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            ////3

            //Console.Title = "3.  CustomizedBill";

            //try
            //{
            //    conn.Open();

            //    string sql = "select " +
            //                 "c.project, " +
            //                 "c.position, " +
            //                 "c.manufactured_item as ParentPart, " +
            //                 "c.item_code, " +
            //                 "c.item_description, " +
            //                 "c.net_quantity, " +
            //                 "c.item_type, " +
            //                 "i.standard_cost_price, " +
            //                 "i.material_costs, " +
            //                 "i.operation_costs " +
            //                 "from views200.customized_bill_of_material c " +
            //                 "left join views200.item_data i on c.item_code = i.item_code ";

            //    cmd = new OracleCommand(sql, conn);
            //    cmd.CommandType = CommandType.Text;

            //    da = new OracleDataAdapter(cmd);
            //    cb = new OracleCommandBuilder(da);
            //    mkTable = new DataTable();
            //    da.Fill(mkTable);
            //    conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //try
            //{
            //    xcmd = new SqlCommand
            //    ("delete from customizedbill", blCnxn);
            //    xcmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //copy = new SqlBulkCopy(blCnxn);
            //copy.DestinationTableName = "customizedbill";
            //try
            //{
            //    copy.WriteToServer(mkTable);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            ////4
            //Console.Title = "4.  Custom Items";

            //try
            //{
            //    conn.Open();

            //    string sql = "select " +
            //                 "'Custom' as ItemType, " +
            //                 "c.project, " +
            //                 "c.item_code, " +
            //                 "c.description as ParentDescription, " +
            //                 "max(c.purchase_price) as MaxOfPurcahsePrice, " +
            //                 "max(c.act_cost_price) as MaxOfAct_Cost_Price, " +
            //                 "c.actual_operation_costs, " +
            //                 "c.act_material_costs, " +
            //                 "c.item_description " +
            //                 "as Description1, " +
            //                 "c.est_material_costs, " +
            //                 "c.estimated_operation_costs, " +
            //                 "c.estimated_cost_price " +
            //                 "from views200.customized_items c inner join views200.projects p " +
            //                 "on c.project = p.project group by 'custom', c.project, c.item_code, " +
            //                 "c.description, c.actual_operation_costs, c.act_material_costs, c.item_description, " +
            //                 "c.est_material_costs, c.estimated_operation_costs, " +
            //                 "c.estimated_cost_price";

            //    cmd = new OracleCommand(sql, conn);
            //    cmd.CommandType = CommandType.Text;

            //    da = new OracleDataAdapter(cmd);
            //    cb = new OracleCommandBuilder(da);
            //    mkTable = new DataTable();
            //    da.Fill(mkTable);
            //    conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //try
            //{
            //    xcmd = new SqlCommand
            //    ("delete from customitems", blCnxn);
            //    xcmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //copy = new SqlBulkCopy(blCnxn);
            //copy.DestinationTableName = "customitems";
            //try
            //{
            //    copy.WriteToServer(mkTable);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            ////5
            //Console.Title = "5.  Update Mk Transactions";

            //try
            //{
            //    conn.Open();

            //    string sql = "select f.project, " +
            //                 "f.order_type, " +
            //                 "f.order_number, " +
            //                 "f.position, " +
            //                 "f.transaction_type, " +
            //                 "f.transaction_date, " +
            //                 "f.transaction_time, " +
            //                 "f.srno, " +
            //                 "to_char(f.number_of_units), " +
            //                 "to_char(f.amount), " +
            //                 "f.financial_period, " +
            //                 "f.processing_date, " +
            //                 "f.cost_price_component, " +
            //                 "c.cost_type, " +
            //                 "c.description as CostPriceDesc, " +
            //                 "f.journal, " +
            //                 "f.debit_cost_center, " +
            //                 "f.debit_ledger_account, " +
            //                 "f.credit_cost_center, " +
            //                 "credit_ledger_account " +
            //                 "from views200.financial_project_transactions f left join " +
            //                 "views200.cost_price_components c on " +
            //                 "f.cost_price_component = c.cost_price_component " +
            //                 "where f.transaction_date > (select sysdate -90 from dual)";

            //    cmd = new OracleCommand(sql, conn);
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandTimeout = 300;

            //    da = new OracleDataAdapter(cmd);
            //    cb = new OracleCommandBuilder(da);
            //    mkTable = new DataTable();
            //    da.Fill(mkTable);
            //    conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //try
            //{
            //    xcmd = new SqlCommand
            //    ("delete from mktransactionsupdate", blCnxn);
            //    xcmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //copy = new SqlBulkCopy(blCnxn);
            //copy.DestinationTableName = "mktransactionsupdate";
            //try
            //{
            //    copy.WriteToServer(mkTable);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //xcmd = new SqlCommand(
            //    "delete from finprojtransactions where " +
            //    "transaction_date > (SELECT DATEADD(dd, -90, GETDATE()))", blCnxn);

            //xcmd.CommandTimeout = 300;
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

            //6
            Console.Title = "6.  Sales Order Lines";

            try
            {
                conn.Open();

                string sql = "select " +
                             "l.project                                                                                                          , " +
                             "l.customer, " +
                             "l.order_no, " +
                             "l.position, " +
                             "l.item_code, " +
                             "l.order_date, " +
                             "l.ordered_quantity, " +
                             "l.amount, " +
                             "l.delivery_date, " +
                             "l.delivered_quantity " +
                    "from views200.sales_order_lines l left join" +
                    "(select " +
                    "distinct order_no from views200.sales_deliveries where " +
                    "delivery_date >=(select sysdate -914 from dual) and " +
                    "invoice_date > (select sysdate -914 from dual)) a " +
                    "on l.order_no = a.order_no " +
                    "where (ascii(project) > 0) and (order_date >= (select sysdate -914 from dual) or " +
                    "(ordered_quantity > 0 and order_date between " +
                    "'01-JAN-96' and (select sysdate -915 from dual) " +
                    "and delivered_quantity=0 and back_order >=0) or " +
                    "(order_date between '01-Jan-96' and (select sysdate -915 from dual) " +
                    "and delivered_quantity >0 and delivered_quantity < ordered_quantity " +
                    "and back_order > 0) or a.order_no is not null) order by project";

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

            try
            {
                xcmd = new SqlCommand
                ("delete from solines1", blCnxn);
                xcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            copy = new SqlBulkCopy(blCnxn);
            copy.DestinationTableName = "solines1";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //7
            Console.Title = "7.  Purchase Order Lines";

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

            try
            {
                xcmd = new SqlCommand
                ("delete from poline1", blCnxn);
                xcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            copy = new SqlBulkCopy(blCnxn);
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



            //8
            Console.Title = "8.  Employee Hours";

            try
            {
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
                             "where h.project > '1' and " +
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

            try
            {
                xcmd = new SqlCommand
                ("delete from hoursupdate", blCnxn);
                xcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            }

            xcmd = new SqlCommand("select top 1 production_date " +
             "from hoursupdate " +
             "order by production_date asc", blCnxn); ;
            xcmd.Connection = blCnxn;
            object o = xcmd.ExecuteScalar();

            string pdate = o.ToString().Trim();

            xcmd = new SqlCommand("delete from employeehours where " +
                "production_date >= '" + pdate + "' ", blCnxn);
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
             "financial_period = c.financial_period from employeehours h " +
             "inner join tabcalperiodwk c on " +
             "(h.day = c.mfgday and h.week = c.week and h.year = c.year) " +
             "where production_date >= '" + pdate + "' ", blCnxn);
            xcmd.ExecuteNonQuery();

            xcmd = new SqlCommand("updateprojecthrssumbymonth", blCnxn);
            xcmd.CommandType = CommandType.StoredProcedure;
            xcmd.CommandTimeout = 300;
            xcmd.ExecuteNonQuery();

            //9
            Console.Title = "9.  Actual Material Costs";

            try
            {
                conn.Open();

                string sql = "select " +
                             "project, " +
                             "order_no, " +
                             "position_number, " +
                             "item_code, " +
                             "manufactured_item_code, " +
                             "case when item_type_stand_cust = 1 then 'St' " +
                             "else 'Cu' end as ItemType, " +
                             "actual_quantity, " +
                             "actual_cost_price * actual_quantity as TotalCost, " +
                             "item_description, " +
                             "actual_delivery_date " +
                             "from views200.actual_material_costs " +
                             "where project > '1'";

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

            try
            {
                xcmd = new SqlCommand
                ("delete from actualmaterialcosts", blCnxn);
                xcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            copy = new SqlBulkCopy(blCnxn);
            copy.DestinationTableName = "actualmaterialcosts";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //10
            Console.Title = "10.  Production Orders";

            try
            {
                conn.Open();

                string sql = "select project, " +
                             "order_no, " +
                             "item_code, " +
                             "item_description, " +
                             "order_quantity, " +
                             "cost_price, " +
                             "material_costs, " +
                             "operation_costs, " +
                             "production_year, " +
                             "production_week, " +
                             "hours_printed, " +
                             "order_status, " +
                             "total_scrapped, " +
                             "quantity_posted " +
                             "from views200.production_order_file " +
                             "where project > '0'";

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

            try
            {
                xcmd = new SqlCommand
                ("delete from productionorderfile", blCnxn);
                xcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            copy = new SqlBulkCopy(blCnxn);
            copy.DestinationTableName = "productionorderfile";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //11
            Console.Title = "11.  General Project Costs";

            try
            {
                conn.Open();

                string sql = "select " +
                             "g.project, " +
                             "g.srno, " +
                             "g.description, " +
                             "g.document_number, " +
                             "g.transaction_date, " +
                             "g.cost_price_component, " +
                             "c.description as CostPriceDesc, " +
                             "g.number_of_units, " +
                             "g.amount " +
                             "from views200.general_project_costs g " +
                             "inner join views200.cost_price_components c " +
                             "on g.cost_price_component = c.cost_price_component " +
                             "where g.project > '0'";

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

            try
            {
                xcmd = new SqlCommand
                ("delete from generalprojectcosts", blCnxn);
                xcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            copy = new SqlBulkCopy(blCnxn);
            copy.DestinationTableName = "generalprojectcosts";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //12
            Console.Title = "12.  Tasks";

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
                       
            try
            {
                xcmd = new SqlCommand
                ("delete from Tasks", blCnxn);
                xcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            copy = new SqlBulkCopy(blCnxn);
            copy.DestinationTableName = "Tasks";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //13
            Console.Title = "13.  Actual Prod Hours";

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
                             "from views200.actual_prod_hours " +
                             "where transaction_date > (select sysdate -30 from dual)";

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

            try
            {
                xcmd = new SqlCommand
                ("delete from mkActualProdHoursupdate", blCnxn);
                xcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            copy = new SqlBulkCopy(blCnxn);
            copy.DestinationTableName = "mkActualProdHoursupdate";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            xcmd = new SqlCommand(
                "delete from ActualProdHours where " +
                "transaction_date > (SELECT DATEADD(dd, -30, GETDATE()))", blCnxn);
            xcmd.ExecuteNonQuery();
            
            xcmd = new SqlCommand(
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
            xcmd.ExecuteNonQuery();
            
            xcmd = new SqlCommand(
                "delete from ActualProdHours_Normalized", blCnxn);
            xcmd.ExecuteNonQuery();
            
            xcmd = new SqlCommand(
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
            xcmd.ExecuteNonQuery();
            
            xcmd = new SqlCommand(
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
            xcmd.ExecuteNonQuery();

            xcmd = new SqlCommand(
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
            xcmd.ExecuteNonQuery();

            xcmd = new SqlCommand(
                "Update actualprodhours_normalized " +
                "set " +
                "machine_hours_e = round(machine_hours_e,2), " +
                "machine_hours_a = round(machine_hours_a,2), " +
                "employee_hours_a = round(employee_hours_a,2)", blCnxn);
            xcmd.ExecuteNonQuery();

            //modified from Ben becasue the created totals were not
            //available to be computed for the results so taking the 
            //columns which alread exist and calculating from them.
            xcmd = new SqlCommand(
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
            xcmd.ExecuteNonQuery();

            xcmd = new SqlCommand(
               "Update n " +
               "set " +
               "n.description = t.description " +
               "from actualprodhours_normalized n " +
               "inner join tasks t on " +
               "n.task = t.task", blCnxn);
            xcmd.ExecuteNonQuery();

            //14
            Console.Title = "14.  Project Stock Item Transactions";

            try
            {
                conn.Open();

                string sql = "select  " +
                             "project, " +
                             "custom_item, " +
                             "warehouse, " +
                             "serial_nbr, " +
                             "trans_type, " +
                             "target_project, " +
                             "delivered_qty, " +
                             "target_warehouse, " +
                             "warehouse_order, " +
                             "trans_date, " +
                             "stock_trans, " +
                             "user_trans_entered, " +
                             "custom_item_description, " +
                             "'00.00' as Stock_transfer_cost " +
                             "from views200.project_stk_trans_by_item " +
                             "where project > 1 ";

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
            
            try
            {
                xcmd = new SqlCommand
                ("delete from ProjectStockTransactions", blCnxn);
                xcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            copy = new SqlBulkCopy(blCnxn);
            copy.DestinationTableName = "ProjectStockTransactions";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            //15
            Console.Title = "15.  Project Stock Transfer Cost";
            xcmd = new SqlCommand(
                "delete from zHelper_ProjStockTrans", blCnxn);
            xcmd.ExecuteNonQuery();

            xcmd = new SqlCommand(
                "Insert into zHelper_ProjStockTrans " +
                "(project, " +
                "order_number, " +
                "amount " +
                ") select " +
                "project, " +
                "order_number, " +
                "sum(amount) " +
                "from FinProjTransactions " +
                "where transaction_type = 16 " +
                "group by project, order_number", blCnxn);
            xcmd.ExecuteNonQuery();

            //16
            xcmd = new SqlCommand(
                "Update t " +
                "set " +
                "t.stock_transfer_cost = abs(z.amount) " +
                "from ProjectStockTransactions t " +
                "inner join zhelper_projstocktrans z on " +
                "(t.warehouse_order = z.order_number) and " +
                "(t.project = z.project) ", blCnxn);
            xcmd.ExecuteNonQuery();
            
            //17
            Console.Title = "17.  Project Main Summary";

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
            
            xcmd = new SqlCommand(
                "update projectmainsummary " +
                "set " +
                "transferprice = (case when transferprice is null then 0 else transferprice end), " +
                "materialcost = (case when materialcost is null then 0 else materialcost end), " +
                "purchasecost = (case when purchasecost is null then 0 else purchasecost end), " +
                "onordamt = (case when onordamt is null then 0 else onordamt end), " +
                "laborcost = (case when laborcost is null then 0 else laborcost end), " +
                "stocktransfercost = (case when stocktransfercost is null then 0 else stocktransfercost end), " +
                "subcontractcost = (case when subcontractcost is null then 0 else subcontractcost end), " +
                "totalcost = (case when totalcost is null then 0 else totalcost end), " +
                "openamt = (case when openamt is null then 0 else openamt end), " +
                "COGS = (case when COGS is null then 0 else COGS end), " +
                "sumofamount = (case when sumofamount is null then 0 else sumofamount end), " +
                "finsalesamount = (case when finsalesamount is null then 0 else finsalesamount end), " +
                "fincostamount = (case when fincostamount is null then 0 else fincostamount end)",blCnxn);
            xcmd.ExecuteNonQuery();
            
            //18
            Console.Title = "18.  FinProjTransactions_First";

            xcmd = new SqlCommand(
                "delete from FinProjTransactions_First", blCnxn);
            xcmd.ExecuteNonQuery();

            xcmd = new SqlCommand(
                "Insert into FinProjTransactions_First " +
                "(project, MinOfTransactionDate) " +
                "select project, min(transaction_date) " +
                "from finprojtransactions group by project", blCnxn);
            xcmd.ExecuteNonQuery();

                       xcmd = new SqlCommand(
                "Update f " +
                "set " +
                "f.transaction_type = t.transaction_type " +
                "from finprojtransactions t " +
                "inner join finprojtransactions_first f on " +
                "(t.transaction_date = f.MinOfTransactionDate) and " +
                "(t.project = f.project) ", blCnxn);
            xcmd.ExecuteNonQuery();

            xcmd = new SqlCommand
                ("update updatelog set [end] = " +
                 "(select getdate())", blCnxn);
            xcmd.ExecuteNonQuery();
            
        }
 
    }
}
