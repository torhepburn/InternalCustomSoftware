using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data.SqlClient;
using System.IO;

namespace Ken
{
    public partial class QuickView : Form
    {
        private OracleConnection conn = new OracleConnection();
        private OracleCommand cmd;
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        private DataSet ds;
        DataTable table;
        
        public QuickView()
        {
            InitializeComponent();
        }

        private void QuickView_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "user id=views200;" +
                "Password=views200;Data Source=//dbserver:1521/mkpd;";

            try
            {
                conn.Open();

                //string parentBOM = "'8070-0102-01'";
                //string parentBOM = "'6300-0767-04'";

                string sql =

                "select count(item_code) from views200.actual_material_costs";
                //"select order_no, position, order_line_text from views200.purchase_order_lines where order_no = 436745";
                //"SELECT * from views200.purchase_order_lines where order_no = 510006";

                //"Select * from project_stages";

                        //"select project, " +
                        // "order_no, " +
                        // "order_status, " +
                        // "item_code, " +
                        // "delivery_date, " +
                        // "item_description, " +
                        // "order_quantity, " +
                        // "cost_price, " +
                        // "material_costs, " +
                        // "operation_costs, " +
                        // "production_year, " +
                        // "production_week, " +
                        // "hours_printed, " +
                        // "total_scrapped, " +
                        // "quantity_posted " +
                        // "from views200.production_order_file " +
                        // "where order_no = 374670 ";
                         //" where order_status < 6 " +
                         //"order by delivery_date DESC ";

                //"select " +
                //"d.picking_list_number, d.order_no, d.position, d.srno, d.customer, d.item_code, d.ordered_quantity, d.warehouse" +
                //"o.route " +
                //" from " +
                //"views200.sales_deliveries d " +
                //"inner join " +
                //"views200.sales_orders o " +
                //"on d.order_no = o.order_no " +
                //"where " + //(d.customer = '1008JS' or d.customer = '9999AJ') " +
                //" o.route =  'SL001'";
                //"and d.item_code not like 'Freight%' and d.item_code in ('1115-800-072', '1115-800-072', '1115-800-279', '1115-800-447', '1115-801-115', '1115-801-265', '1115-801-486', '6191-0138-04', '6191-0138-05', '6191-0138-06', '6191-0138-07', '6191-0138-09', '6191-0188-02', '6191-0301-01', '6191-0318-01', '6191-0441-01', '6191-0445-02', '6191-0446-02', '6191-0550-01', '6191-0553-01', '6191-0584-01', '6191-0591-01', '6191-0591-02', '6191-0591-03', '6191-0945-03', '6191-0945-04', '8020-0101-01', '8020-0101-07', '8020-0102-09', '8020-0102-11', '8020-0103-08', '8020-0104-01', '8020-0104-02', '8020-0104-03', '8020-0410-02', '8020-0410-03', '8020-0410-04', '8020-0410-05', '8020-0410-06', '8020-0410-07', '8020-0410-10', '8020-0410-14', '8020-0410-15', '8020-0428-01', '8040-0103-02', '8040-0128-01', '8070-0102-01', '8070-0102-05', '8070-0154-01', '8070-0278-01', '8070-0278-02', '8070-0279-01', '8070-0279-02', '8080-0338-01', '8080-0412-01')";


                //"Select * from views200.machines";
                // "Select count(ledger_account) from views200.Chart_of_accounts order by ledger_account";
                // "select sysdate -30 from dual ";


                /*
                "SELECT " +
                "to_char(ORDER_NO) as ORDER_NO " +
",to_char(POSITION) as POSITION " +
",to_char(SERIAL_NUMBER) as SERIAL_NUMBER " +
",PROJECT " +
",ITEM_CODE " +
",RECEIPT_DATE " +
",to_char(INVOICED_QUANTITY) as INVOICED_QUANTITY " +
",to_char(RECEIPT_NUMBER) as RECEIPT_NUMBER " +
",to_char(DELIVERED_QUANTITY) as DELIVERED_QUANTITY " +
",to_char(BACKORDERED_QUANTITY) as BACKORDERED_QUANTITY " +
",to_char(APPROVED_QUANTITY) as APPROVED_QUANTITY " +
",to_char(REJECTED_QUANTITY) as REJECTED_QUANTITY " +
                    "FROM views200.receipts " +
                    "WHERE receipt_date > (select sysdate - 90 from dual) " +
                    "AND(delivery_status = 1 AND " +
                    "(delivered_quantity - rejected_quantity - approved_quantity <> 0))";


    */
                /*
                "SELECT " +

                "to_char(ORDER_NO) as ORDER_NO " +
                ",to_char(POSITION) as POSITION " +
                ",to_char(SERIAL_NUMBER) as SERIAL_NUMBER " +
                ",SUPPLIER " +
                ",PROJECT " +
                ",ITEM_CODE " +
                ",COST_PRICE_COMPONENT " +
                ",RECEIPT_DATE " +
                ",to_char(INVOICED_QUANTITY) as INVOICED_QUANTITY " +
                ",to_char(INVOICED_AMOUNT) as INVOICED_AMOUNT " +
                ",to_char(DELIVERY_STATUS) as DELIVERY_STATUS " +
                ",to_char(UPDATE_STATUS_ACT_PURC_COSTS) as UPDATE_STATUS_ACT_PURC_COSTS " +
                ",to_char(PRODUCTION_ORDER) as PRODUCTION_ORDER " +
                ",to_char(OPERATION) as OPERATION " +
                ",to_char(ROTATION_NUMBER) as ROTATION_NUMBER " +
                ",to_char(PURCHASE_STATUS_CODE) as PURCHASE_STATUS_CODE " +
                ",PROCEDURE_MASK " +
                ",to_char(RECEIPT_NUMBER) as RECEIPT_NUMBER " +
                ",DISPATCH_NOTE_NUMBER " +
                ",to_char(INVOICE_NUMBER) as INVOICE_NUMBER " +
                ",INVOICE_DATE " +
                ",PLANNED_DELIVERY_DATE " +
                ",to_char(MARKED) as MARKED " +
                ",to_char(QUANTITY_ON_DISPATCH_NOTE) as QUANTITY_ON_DISPATCH_NOTE " +
                ",to_char(DELIVERED_QUANTITY) as DELIVERED_QUANTITY " +
                ",to_char(BACKORDERED_QUANTITY) as BACKORDERED_QUANTITY " +
                ",to_char(APPROVED_QUANTITY) as APPROVED_QUANTITY " +
                ",to_char(REJECTED_QUANTITY) as REJECTED_QUANTITY " +
                ",REASON_FOR_REJECTION " +
                ",to_char(INSPECTION_REPORT_TEXT) as INSPECTION_REPORT_TEXT " +
                ",to_char(COST_PRICE) as COST_PRICE " +
                ",to_char(OPERATION_COSTS) as OPERATION_COSTS " +
                ",to_char(NET_GOODS_AMOUNT) as NET_GOODS_AMOUNT " +
                ",to_char(LINE_ITEM_DISCOUNT_AMOUNT) as LINE_ITEM_DISCOUNT_AMOUNT " +
                ",to_char(ORDER_DISCOUNT_AMOUNT) as ORDER_DISCOUNT_AMOUNT " +
                ",REVISION " +
                ",WAREHOUSE " +
                ",to_char(CONTRACT) as CONTRACT " +
                ",to_char(DISCOUNT) as DISCOUNT " +
                ",to_char(PRICE) as PRICE " +
                ",to_char(POSITION_NUMBER) as POSITION_NUMBER " +
                ",to_char(RECEIPT_PRINTED) as RECEIPT_PRINTED " +
                ",FINANCIAL_REASON " +
                ",to_char(LINE_TYPE) as LINE_TYPE " +
                ",SCHEDULE_NUMBER " +
                ",to_char(TAX_AMOUNT) as TAX_AMOUNT " +
                ",to_char(STANDARD_COST_PRICE) as STANDARD_COST_PRICE " +
                ",ITEM_DESCRIPTION " +
                ",ZYGO_COMPANY_NUMBER " +
                "from views200.receipts ";
                */
                //"select  receipt_date " +
                //"from views200.receipts order by receipt_date desc";
                //"COUNT(order_no) " +
                //",production_date " +
                //"start_date " +
                //",operation " +
                //"project, " +
                //",operation_completed " +
                //"from views200.hours_accounting_by_employee " +

                //"where (order_no > 360000 and order_no < 389999) " +
                //"and (production_date > (select sysdate - 1095 from dual))";
                //"order by operation, operation_completed desc";
                //"where ROWNUM < 6 order by rownum ";

                //"from views200.planned_stock_tran_by_item where order_id in (576889, 576925) and item_code = '6308-1049-01' " +
                //"order by item_code ";
                //"from views200.purchase_order_lines " +
                //"where po_line_status = 1 and total_delivered_quantity <> quantity " +
                //"order by item_code ";

                //"from views200.sales_order_line_history " +
                //"where transaction_date > '15-nov-2016' " +
                //"order by Planned_delivery_date ";
                //// "ASCII(substr(sales_text, 175, 1)) 
                //from views200.item_master_text where item_code = '6550-0461-01'";


                //"ITEM_CODE, " +
                //"ITEM_TYPE, " +
                //"ITEM_DESC, " +
                //"BEGIN_ITEM_CODE, " +
                //"BEGIN_ITEM_DESC, " +
                //"BOM_SEQ, " +
                //"BOM_LEVEL, " +
                //"MFG_CONDENSED_LEVEL_FLAG, " +
                //"PHANTOM, " +
                //"PHANTOM_DETAIL_FLAG, " +
                //"PURCH_DETAIL_FLAG, " +
                //"to_char(NET_QTY) NET_QTY, " +
                //"to_char(EXT_NET_QTY) EXT_NET_QTY, " +
                //"to_char(STOCK_ON_HAND) STOCK_ON_HAND, " +
                //"to_char(ALLOCATED_STOCK) ALLOCATED_STOCK, " +
                //"to_char(STOCK_ON_ORDER) STOCK_ON_ORDER, " +
                //"SIGNAL_CODE, " +
                //"FIXED_LEAD_TIME_D, " +
                //"PARENT_ITEM_CODE, " +
                //"to_char(STANDARD_COST_PRICE) STANDARD_COST_PRICE " +


                //"count(item_code) " +
                //count(order_no)" +
                //"journal, " +
                //"transaction_date " +
                // "journal_number, " +
                // "Booking_posting_date " + 
                //"select trunc(next_day (sysdate, 'sun')-7) from dual";
                //"select *  " +
                //"bom_seq, " +
                //"bom_level, " +
                //"parent_item_code " +
                //"count (begin_item_code) " +
                //"period_number " +
                //"from BOM.BOM_ind_bill " +
                //"where begin_item_code = '4035.200.11102'";

                //"where rownum < 5";
                //"where period_number > 201412";
                //"from views200.Item_Text";
                //"from views200.financial_project_transactions " + 
                //"where journal = '101'";
                //"from views200.material_lines " + 
                //"where order_number = 863265 ";
                //"where production_date > (select sysdate - 400 from dual)";
                //"from views200.posted_ledger_x5transactions " +
                //"where journal_number = '101'";
                //"where booking_posting_date = '1-dec-2014'";
                //"b.parent_item_code " +
                //"from bom.bom_whr_used b " +
                //"inner join views200.item_data i " +
                //"on b.parent_item_code = i.item_code " +
                //"where (b.begin_item_code = " + parentBOM + " and " +
                //"b.saleable_item_flag = 'Y' and " +
                //"b.BOM_seq <> 0 and " +
                //"lower(i.description) like '%obs%') " +
                //"group by b.parent_item_code " +
                //"having upper(b.parent_item_code) not like 'PL%'";

                //string sql = "select lower(description) from views200.item_data " +
                //    "where lower(description)  like '%obs%'";
                //"count(item_code) " +
                // "standard_cost_price, " +
                // "operation_costs, " + 
                // "cumulative_issue " +
                // "ITEM_TYPE, " +

                //int
                //"VAT_CODE, " +
                //"LOT_CONTROL, " +
                //"OUTBOUND_PRIORITY, " +
                //"PERIOD_FOR_SHELF_LIFE, " +
                //"SHELF_LIFE_IN_PERIODS, " +
                //"PICKING_STOCK, " +
                //"INACTIVE_FOR_STOCKTAKING, " +
                //"CUMULATIVE_ISSUE, " +
                //"EXPECTED_ANNUAL_ISSUE_ACT, " +
                //"SAFETY_STOCK, " +
                //"MAXIMUM_STOCK, " +
                //"ORDER_POLICY, " +
                //"ORDER_SYSTEM, " +
                //"ORDER_METHOD, " +
                //"MINIMUM_ORDER_QUANTITY, " +
                //"MAXIMUM_ORDER_QUANTITY, " +
                //"FIXED_ORDER_QUANTITY, " +
                //"ECONOMIC_ORDER_QUANTITY, " +
                //"RE_ORDER_POINT, " +
                //"ORDER_INTERVAL, " +
                //"ORDER_LEAD_TIME, " +
                //"SAFETY_TIME, " +
                //"UPDATE_STOCK_ORDER_DATA, " +
                //"PHANTOM, " +
                //"BOM_UNIT, " +
                //"SCRAP_FACTOR, " +
                //"TIME_FENCE, " +
                //"ROUND_IN_MPS, " +
                //"NET_CHANGE_MRP, " +
                //"LOW_LEVEL_CODE, " +
                //"LOW_LEVEL_CODE_INDICATOR, " +
                //"MRP_INDICATOR, " +
                //"INSPECTION, " +
                //"COST_PRICE_INDICATOR, " +
                //"STOCK_VALUATION, " +
                //"VAT_TYPE_FOR_CANADA, " +
                //"PLANNER_CODE, " +
                //"TAXABLE, " +
                //"REVISION_CONTROL_FLAG, " +
                //"ECO_CONTROL_FLAG, " +
                //"AUTO_PULL_FLAG, " +
                //"COPY_EXACTLY, " +
                //"TEMPORARY_ITEM, " +
                //"USE_LEAD_TIMES, " +
                //"CONSUME_PHANTOM_SU, " +
                //"SAFETYSTOCK_UNIT_L, " +
                //"PRODUCT_CONFIGURED, " +
                //"EACHES_PER_INNERPA, " +
                //"CASE_PACK, " +
                //"EACHES_PER_MASTERC, " +
                //"EACHES_PER_PALLET, " +
                //"BATCH_PICK_ONLY " +
                //float
                //"WEIGHT, " +
                //"TARGET_PRICE_PPV, " +
                //"SLOW_MOVING_PERCENTAGE, " +
                //"SERVICE_LEVEL, " +
                //"STOCK_COSTS_PER_YEAR, " +
                //"STOCK_ON_HAND, " +
                //"BLOCKED_STOCK, " +
                //"STOCK_ON_ORDER, " +
                //"ALLOCATED_STOCK, " +
                //"HISTORICAL_STOCK_BALANCE, " +
                //"NON_NETTABLE_STOCK_QUANTITY, " +
                //"ALLOCATED_FOR_PICKING_LIST, " +
                //"QUOTATION_ALLOCATIONS, " +
                //"ORDER_QUANTITY_MULTIPLE_OF, " +
                //"ORDER_COSTS, " +
                //"PURCHASE_PRICE, " +
                //"AVERAGE_PURCHASE_PRICE, " +
                //"LATEST_PURCHASE_PRICE, " +
                //"CUM_PURC_RECEIPTS, " +
                //"SELLING_PRICE, " +
                //"RECOMMENDED_RETAIL_PRICE, " +
                //"UPPER_MARGIN, " +
                //"LOWER_MARGIN, " +
                //"STANDARD_COST_PRICE, " +
                //"MATERIAL_COSTS, " +
                //"OPERATION_COSTS, " +
                //"ISSUE_MULTIPLE, " +
                //"NON_NETTABLE_STOCK, " +
                //"DISTRIBUTED_STOCK, " +
                //"DRP_NON_NET_STK_ON_HAND, " +
                //"FIXED_LEAD_TIME_D, " +
                //"SUPPLIER_REPLEN_DAYS, " +
                //"UNIT_LEAD_TIME_DA, " +
                //"LAST_PLANNING_QOH, " +
                //"LENGTH_OF_ITEM, " +
                //"HEIGHT_OF_ITEM, " +
                //"WEIGHT_OF_ITEM, " +
                //"WIDTH_OF_ITEM, " +
                //"INNERPACK_LENGTH, " +
                //"INNERPACK_HEIGHT, " +
                //"INNERPACK_WIDTH, " +
                //"INNERPACK_WEIGHT, " +
                //"LENGTH_OF_CASES, " +
                //"HEIGHT_OF_CASES, " +
                //"WIDTH_OF_CASES, " +
                //"WEIGHT_OF_CASES, " +
                //"MASTERCASE_LENGTH, " +
                //"MASTERCASE_HEIGHT, " +
                //"MASTERCASE_WIDTH, " +
                //"MASTERCASE_WEIGHT, " +
                //"LENGTH_OF_PALLET, " +
                //"HEIGHT_OF_PALLET, " +
                //"WIDTH_OF_PALLET, " +
                //"WEIGHT_OF_PALLET " +
                //"receipt_date, " +
                //"invoice_date, " +
                //"planned_delivery_date " +
                //"from views200.receipts " +
                //"where planned_delivery_date < '1-Jan-1753' " +
                //"order by receipt_date ";
                //"serial_no, " +
                //"item_code " +

                //"item_type, " +
                //"item_desc, " +
                //"begin_item_code, " +
                //"begin_item_desc, " +
                //"BOM_seq, " +
                //"bom_level, " + 
                //"mfg_condensed_level_flag, " +
                //"phantom, " +
                //"phantom_detail_flag, " +
                //"purch_detail_flag, " +
                //"net_qty, " +
                //"ext_net_qty, " +
                //"stock_on_hand, " + 
                //"allocated_stock, " + 
                //"non_net_stock_on_hand, " +
                //""
                ////"date_entered " +
                //"from bom.bom_ind_bill " + // +
                //"where item_type = 'PURCH' and " +
                //"begin_item_code = '8020-0102-02'";
                //"where date_modified > '21-Jan-2014'" +
                //" and date_modified < '23-Jan-2014' " +
                //"and left(item_code, 4) = '8070' " +
                ////" where date_entered > '10-May-2014' "; // +
                //"and date_entered < '08-Oct-2011' " +
                //"where date_entered is null ;" +
                //"order by item_code ";
                //"where " +
                // " item_code = '1541-369-080'";
                //" item_code = '1541-391-054'";
                //" item_code = '1288-600-001'";
                //" item_code = '1415-360-005'";
                //"maintenance_start_date, " +
                //"maintenance_end_date, " +
                //"installation_date, " +
                //"warranty_start_date, " +
                //"warranty_expiry_date, " +
                //"suppliers_warranty_start_date, " +
                //"suppliers_warranty_end_date, " +
                //"recording_date_counter_value, " +
                //"previous_reading_date, " +
                //"date_opsal_hours_changed, " +
                //"shipment_date, " +
                //"retired_date, " +
                //"date_record_add " +
                //"from views200.equipment_master " +
                ////"where date_record_add = '19-DEC-2013' " +
                //"order by shipment_date desc";
                //;
                //"count(manufactured_item) " +
                //"order_type, " +
                //"order_number, " +
                //"position, " +
                //"manufactured_item,  " +
                //"item_code_component, " +
                //"position," +
                ////"order_date, " +
                ////"delivery_date, " +
                ////"delivery_date_2, " +
                ////"delivery_date_confirmed, " +
                //"effective_date " +
                ////"supplier, " +
                ////"item_description, " +
                ////"order_policy, " +
                ////"standard_description, " +
                ////"price, " +
                ////"price_unit, " +
                ////"conv_fct_prc_to_stk_unt, " +
                ////"serial_number, " +
                ////"quantity, " +
                ////"purchase_unit, " +
                ////"order_line_text, " +
                ////"to_char(amount), " +
                ////"AMOUNT, " +
                ////"warehouse, " +
                ////"receipt_number " +

                ////"from views200.customer_master ";
                // "from views200.production_BOM " + 
                // "where effective_date < '01-JAN-1754' " +  
                // "order by effective_date";
                ////
                //"order_type, " +
                // "count(order_number) " +
                //"position, " +
                //"transaction_type, " +
                //"transaction_date, " +
                //"transaction_time, " +
                ////"serial_number, " +
                //"to_char(number_of_units), " +
                //"to_char(amount), " +
                //"warehouse, " +
                //"item_code, " +
                //"financial_trn_processed, " +
                //"TO_CHAR(posting_date), " +
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
                //"TO_CHAR(acUtal_delivery_date), " +
                //"work_center, " +
                //"receipt_number, " +
                //"TO_CHAR(date_trans_entered), " +
                //"time_trans_entered, " +
                //"user_entered, " +
                //"item_description, " +
                //"zygo_company_number " +
                // "from views200.financial_stock_and_wip_trans ";
                //"WHERE ROWNUM < 1000 ";
                // "Where transaction_date > (select sysdate -1 from dual)";

                //select =
                //"select " +
                //"sales_price_list, " +
                //"item_code, " +
                //"effective_date, " +
                //"expiry_date, " +
                //"price, " +
                //"Zygo_company_number " +
                //"from views200.prices_price_list_and_item_sls " +
                //"where " +
                //"effective_date >= '01-Aug-2016' and " +
                ////"effective_date <= '" + effectiveDate + "' and " +
                //" sales_price_list = 'EUR' "; //and " +
                ////"item_code = '6500-0106-50' ";
                //////"expiry_date >= sysdate ";




                //select = "select " +
                //"item_code, " +
                //"Case " +
                //" when length(sales_text) > 254 then (substr(sales_text,1,25))" +
                //" else substr(sales_text,1, (Length(sales_text)-4)) " +
                //"end as sales_text" +
                ////"case  " +
                //     //" if length(sales_text) > 254  then result:= substr(sales_text, 1, 254) as sales_text " +
                //     //"    else substr(sales_text,1, (Length(sales_text)-4)) as sales_text, " +
                //     //"end if" +
                //     //"length(sales_text) " +
                //     //"company  " +
                //" from views200.item_master_text " +
                //"where sales_text is not null and item_code " +
                //" not like 'FREIGHT%' "; //and substr(item_code, 1,4) ='6308' ";
                ////"order by length(sales_text)";

                //"h.project, " +
                //    "h.transaction_type, " +
                //    "h.employee, " +
                //    "e.name, " +
                //    "e.work_center, " +
                //    "w.description, " +
                //    "h.year, " +
                //    "h.week, " +
                //    "h.day, " +
                //    "h.order_no, " +
                //    "h.man_time, " +
                //    "h.machine_hours, " +
                //    "case when h.employee = 0 " +
                //    "then h.machine_hours else " +
                //    "h.man_time end as man_machine_time, " +
                //    "h.actual_wage_costs, " +
                //    "h.actual_overhead_costs, " +
                //    "h.production_date " +
                //    "from views200.hours_accounting_by_employee h " +
                //    "left join views200.employees e on " +
                //    "h.employee = e.employee " +
                //    "left join views200.work_centers w on " +
                //    "e.work_center = w.work_center " +
                //    "where h.project > '1' and " +
                //    "h.production_date > (select sysdate -30 from dual)";


                //string sql = "select * from views200.employees order by name";

                //string sql ="select " +
                //    "* from views200.item_data where " +
                //    "item_code like '6%' " +
                //    "order by item_code ";

                //string sql = "select " +
                //            "l.customer, " +
                //           //"c.name, " +
                //            "l.order_no, " +
                //            "l.item_code " +
                //   "from views200.sales_order_lines l " +
                //  //"inner join views200.customers c on " +
                //  // "l.customer = c.customer " +
                //   "where order_no = 227441 " +
                //   "order by order_no";

                //"customer, " +
                //"name from views200.customers order by name";
                // "left join" +
                //"(select " +
                //"distinct order_no from views200.sales_deliveries where " +
                //"delivery_date >=(select sysdate -914 from dual) and " +
                //"invoice_date > (select sysdate -914 from dual)) a " +
                //"on l.order_no = a.order_no " +
                //"where (ascii(project) > 0) and (order_date >= (select sysdate -914 from dual) or " +
                //"(ordered_quantity > 0 and order_date between " +
                //"'01-JAN-96' and (select sysdate -915 from dual) " +
                //"and delivered_quantity=0 and back_order >=0) or " +
                //"(order_date between '01-Jan-96' and (select sysdate -915 from dual) " +
                //"and delivered_quantity >0 and delivered_quantity < ordered_quantity " +
                //"and back_order > 0) or a.order_no is not null) order by order_no";


                //string sql = "select   " +
                //    "* from views200.activity_by_project";

                //"select   " +
                //"h.project, " +
                //"h.transaction_type, " +
                //"h.employee, " +
                //"e.name, " +
                //"e.work_center, " +
                //"w.description, " +
                //"h.year, " +
                //"h.week, " +
                //"h.day, " +
                //"h.order_no, " +
                //"h.man_time, " +
                //"h.machine_hours, " +
                //"case when h.employee = 0 " +
                //"then h.machine_hours else " +
                //"h.man_time end as man_machine_time, " +
                //"h.actual_wage_costs, " +
                //"h.actual_overhead_costs, " +
                //"h.production_date " +
                //"from views200.hours_accounting_by_employee h " +
                //"left join views200.employees e on " +
                //"h.employee = e.employee " +
                //"left join views200.work_centers w on " +
                //"e.work_center = w.work_center " +
                //"where h.employee = 1358 and h.project > '1' and " +
                //"h.production_date > (select sysdate -30 from dual)";

                //"h.project, " +
                //"h.transaction_type, " +
                //"h.employee, " +
                //"e.name, " +
                //"e.work_center, " +
                //"w.description, " +
                //"h.year, " +
                //"h.week, " +
                //"h.day, " +
                //"h.order_no, " +
                //"h.man_time, " +
                //"h.machine_hours, " +
                //"case when h.employee = 0 " +
                //"then h.machine_hours else " +
                //"h.man_time end as man_machine_time, " +
                //"h.actual_wage_costs, " +
                //"h.actual_overhead_costs, " +
                //"h.production_date " +
                //"from views600.hours_accounting_by_employee h " +
                //"left join views600.employees e on " +
                //"h.employee = e.employee " +
                //"left join views600.work_centers w on " +
                //"e.work_center = w.work_center " +
                //"where h.project > '1'";

                //string sql = "select " +
                //    //" project from views600.hours_accounting_by_employee ";
                ////"name from views600.employees";
                //                "description from views600.work_centers";
                //string sql = "select   " +
                //    //              "* " +
                //    "project, " +
                //    "custom_item, " +
                //    "warehouse, " +
                //    "serial_nbr, " +
                //    "trans_type, " +
                //    "target_project, " +
                //    "delivered_qty, " +
                //    "target_warehouse, " +
                //    "warehouse_order, " +
                //    "trans_date, " +
                //    "stock_trans, " +
                //    "user_trans_entered, " +
                //    "custom_item_description, " +
                //    "'00.00' as Stock_transfer_cost " +
                //    "from views600.project_stk_trans_by_item " +
                //    "where project > 1 ";

                // string sql = "select " +
                //             "p.project, " +
                //"p.order_no, " +
                //"p.position, " +
                //"p.supplier, " +
                ////"s.name," +
                //"p.order_date, " +
                //"p.item_code, " +
                //"p.total_delivered_quantity, " +
                //"p.total_backordered_quantity, " +
                //"p.po_line_status, " +
                //"p.price, " +
                //"p.quantity, " +
                //"p.amount, " +
                //"p.order_policy, " +
                //"p.delivery_date, " +
                //"p.delivery_date_2, " +
                //"p.delivery_date_confirmed " +
                //"from views200.purchase_order_lines p " +
                //"where order_no = 930055";
                ////p left join views600.suppliers s " +
                ////"on p.supplier = s.supplier " +
                //"where p.project > '1'";

                //"order_no, " +
                //"item_code, " +
                //"item_description, " +
                //"order_date " +
                //"from views600.purchase_order_lines " +
                //"where supplier = '  9398'";

                //              //"from views600.customized_bill_of_material c " +
                //              " from views600.customized_items c  " +
                //              "where (c.project =  228070) ";

                //string sql = "select   " + //"* " +

                //"to_char(sysdate - 180, 'iw') from dual ";
                //"to_char(sysdate, 'yyyy') from dual";
                //"to_char(to_date((sysdate - 60)), 'w') from dual";

                //"last_transaction_date, " +

                //         "h.project, " +
                //         "h.transaction_type, " +
                //         "h.employee, " +
                //         "e.name, " +
                //         "e.work_center, " +
                //         "w.description, " +
                //         "h.year, " +
                //         "h.week, " +
                //         "h.day, " +
                //         "h.order_no, " +
                //         "h.man_time, " +
                //         "h.machine_hours, " +
                //         "h.actual_wage_costs, " +
                //         "h.actual_overhead_costs, " +
                //         "h.production_date " +
                //         "from views600.hours_accounting_by_employee h " +
                //         "left join views600.employees e on " +
                //         "h.employee = e.employee " +
                //         "left join views600.work_centers w on " +
                //         "e.work_center = w.work_center " +
                //         "where h.project > '1' ";
                //and " +
                //         "h.production_date = '20-Dec-12'";


                //"project, " +
                //"order_no, " +
                //"position_number, " +
                //"item_code, " +
                //"manufactured_item_code, " +
                //"case when item_type_stand_cust = 1 then 'St' " +
                //"else 'Cu' end as ItemType, " +
                //"actual_quantity, " +
                //"actual_cost_price * actual_quantity as TotalCost, " +
                //"item_description, " +
                //"actual_delivery_date " +
                //"from views600.actual_material_costs " +
                //"where project > '1'";

                //"project, " +
                //"transaction_type, " +
                //"employee, " +
                //"year, " +
                //"week, " +
                //"day, " +
                //"order_no, " +
                //"man_time, " +
                //"machine_hours, " +
                //"actual_wage_costs, " +
                //"actual_overhead_costs " +
                //"from views600.hours_accounting_by_employee " +
                //"where project > '0' and last_transaction_date " +
                //" > '19-dec-2012'";

                //"ascii(project), project, order_no 
                //" * from views200.purchase_order_lines " +
                //" where order_no = 542659";
                //"where ascii(project) >0 " +
                //"order by project";
                //"e.name, " +
                //"w.item_code " +
                //"from views600.item_data_by_warehouse w " +
                //"left join views600.item_data d on " +
                //"w.item_code = d.item_code " +
                //"left join views600.employees e on " +
                //"d.planner_code = e.employee " +
                //"where (w.warehouse like '%MR%' or " +
                //"w.warehouse like '%45') and " +
                //"w.stock_on_hand != 0 " +
                //"order by e.name";


                //"l.order_no from views600.sales_order_lines l left join " +
                //"(select " +
                //"distinct order_no from views600.sales_deliveries where " +
                //"delivery_date >=(select sysdate -914 from dual) and " +
                //"invoice_date > (select sysdate -914 from dual)) a " +
                //"on l.order_no = a.order_no" ;

                //"l.order_no, l.position, l.customer, l.project, l.item_code, " +
                //"l.ordered_quantity, l.amount, l.delivery_date, l.delivered_quantity " +
                //"from views600.sales_order_lines l left join" +
                //"(select " +
                //"distinct order_no from views600.sales_deliveries where " +
                //"delivery_date >=(select sysdate -914 from dual) and " +
                //"invoice_date > (select sysdate -914 from dual)) a " +
                //"on l.order_no = a.order_no " +
                //"where order_date >= (select sysdate -914 from dual) or " +
                //"(ordered_quantity > 0 and order_date between " +
                //"'01-JAN-96' and (select sysdate -915 from dual) " +
                //"and delivered_quantity=0 and back_order >=0) or " +
                //"(order_date between '01-Jan-96' and (select sysdate -915 from dual) " +
                //"and delivered_quantity >0 and delivered_quantity < ordered_quantity " +
                //"and back_order > 0) or a.order_no is not null order by project";

                //deliveries
                //"count(order_no) from (select " +
                //"distinct order_no from views600.sales_deliveries where " +
                //"delivery_date >=(select sysdate -914 from dual) and " +
                //"invoice_date > (select sysdate -914 from dual))";

                //"actual_cost_price from views600.actual_material_costs";


                //special oracle date format***** '01-Nov-2012
                //"project from views600.financial_project_transactions " +
                //"where transaction_date > '01-NOV-2012'";

                //"item_code, act_cost_price from views600.customized_items";

                //"p.project, " +
                //"p.order_no, " +
                //"p.position, " +
                //"p.supplier, " +
                //"s.name," +
                //"p.order_date, " +
                //"p.item_code, " +
                //"p.total_delivered_quantity, " +
                //"p.total_backordered_quantity, " +
                //"p.po_line_status, " +
                //"p.price, " +
                //"p.quantity, " +
                //"p.amount, " +
                //"p.order_policy, " +
                //"p.delivery_date, " +
                //"p.delivery_date_2, " +
                //"p.delivery_date_confirmed " +
                //"from views600.purchase_order_lines p left join views600.suppliers s " +
                //"on p.supplier = s.supplier " +
                //    //"left join views600.customized_items c on (p.item_code = c.item_code " +
                //    //"and p.project = c.project) " +
                //"where p.project > '1'" //order by p.order_no"
                // ;

                //"'Custom' as ItemType, c.project, c.item_code, c.description, " +
                //"max(c.purchase_price) as MaxOfPurcahsePrice, " +
                //"max(c.act_cost_price) as MaxOfAct_Cost_Price, " +
                //"c.actual_operation_costs, c.act_material_costs, c.item_description " +
                //"as Description1, c.est_material_costs, c.estimated_operation_costs, " +
                //"c.estimated_cost_price " +
                //"from views600.customized_items c inner join views600.projects p " +
                //"on c.project = p.project group by 'custom', c.project, c.item_code, " +
                //"c.description, c.actual_operation_costs, c.act_material_costs, c.item_description, " +
                //"c.est_material_costs, c.estimated_operation_costs, " +
                //"c.estimated_cost_price "

                //;

                //"c.project, c.position, c.manufactured_item as ParentPart, " +
                //"c.item_code, c.item_description, c.net_quantity, c.item_type, " +
                //"i.standard_cost_price, i.material_costs, i.operation_costs " +
                //"from views600.customized_bill_of_material c " +
                //"left join views600.item_data i on c.item_code = i.item_code "
                //"inner join views600.projects p on c.project = p.project"
                //;
                //"p.project, p.description, p.description_1, p.description_2, " +
                //"p.description_3, p.project_type, p.project_status, p.project_stage, " +
                //"p.start_date, p.delivery_date, p.project_manager, e.name as " +
                //"EmployeeName, p.customer, c.name as CustomerName " +
                //"from views600.projects p left join views600.customers c " +
                //"on p.customer = c.customer left join views600.employees e " +
                //"on p.project_manager = e.employee";



                //"select  " +

                ////8-9-13
                //"e.name as Name, " +
                //"w.item_code, " +
                //"d.planner_code, " +
                //"w.item_description, " +
                //"w.warehouse, " +
                //"w.stock_on_hand as OH, " +
                //"w.allocated_stock as Allo, " +
                //"w.blocked_stock as Blkd, " +
                //"w.non_nettable_stock_quantity as NNet, " +
                //"(w.stock_on_hand * d.standard_cost_price) as Extended_Cost, " +
                //"d.standard_cost_price as Cost " +
                //"from views200.item_data_by_warehouse "  +
                //"where item_code != '1716-000-033' ";  // w " +
                //"left join views200.item_data d " +
                //"on w.item_code = d.item_code " +
                //"left join views200.employees e on " +
                //"d.planner_code = e.employee " +
                //"where " +
                //"(w.warehouse like '%MR%' or w.warehouse like '%45') " +
                //"and w.stock_on_hand !=0 ";

                //         "where c.order_no = 563348";

                ////////         ;

                //"from views200.sales_order_history";
                //"from views200.planned_mrp_stock_movements ";
                //"from views200.hours_accounting_by_employee " +
                //"from BOM.BOM_IND_BILL where begin_item_code = '4035.200.11102' ";
                //"from views200.production_order_file " +
                //"where delivery_date < '1-Jan-1753' " +
                //"order by start_date ";
                //" where order_no = 371058  ";

                cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 1800;
                da = new OracleDataAdapter(cmd);
                cb = new OracleCommandBuilder(da);
                //ds = new DataSet();
                table = new DataTable();

                //da.Fill(ds);
                da.Fill(table);

                //DGV.DataSource = ds.Tables[0];
                DGV.DataSource = table;

                //foreach (DataRow row in table.Rows)
                //{
                //    File.AppendAllText(@"C:\a\BOM.txt", 
                //        row[0].ToString() + " " +
                //        row[1].ToString() + " " + 
                //        row[2].ToString() + Environment.NewLine);
                //}

                //SqlConnection SqlCnxn = new SqlConnection
                //    ("server=middbsql; user=rights; password=readingwriting;" +
                //     "database=projects");

                //    SqlCnxn.Open();
                //    SqlBulkCopy copy = new SqlBulkCopy(SqlCnxn);
                //    copy.DestinationTableName = "CustomItems";

                //    try
                //    {
                //        copy.WriteToServer(table);
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.ToString());
                //    }

                //    SqlCnxn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Dispose();
            }
        }

        //private void makeTables()
        //{
        //    OdbcConnection odBC = new OdbcConnection(cnxn);
        //    odBC.ConnectionTimeout = 6000;
        //    OdbcDataAdapter da = new OdbcDataAdapter
        //       (select, cnxn);
        //    DataTable table = new DataTable();
        //    da.Fill(table);
        //    //bs.DataSource = table;
        //    //DGV.DataSource = bs;
        //    //DGV.Show();

        //    SqlCnxn = new SqlConnection(SqlDb);

        //    SqlCnxn.Open();
        //    SqlBulkCopy copy = new SqlBulkCopy(SqlCnxn);
        //    copy.DestinationTableName = tableName;

        //    try
        //    {
        //        copy.WriteToServer(table);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }

        //    SqlCnxn.Close();
        //    progressBar1.PerformStep();
        //}
    }
}