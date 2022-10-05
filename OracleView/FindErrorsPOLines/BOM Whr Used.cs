using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Ken
{
    public partial class BOM_W : Form
    {
        private OracleConnection conn = new OracleConnection();
        private OracleCommand cmd;
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        private DataSet ds;
        private OracleDataReader dr;
        DataTable schemaTable;
        
        public BOM_W()
        {
            InitializeComponent();
        }

        private void BOM_W_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "user id=views200;" +
            "Password=views200;Data Source=//dbserver:1521/mkpd;";

            try
            {
                conn.Open();

                //DateTime now = DateTime.Now;
                //string date = now.ToString("dd MMM yyyy");


                string sql = "select  " +
                             "* " +
                             " " +
                             "from views200.employees";

                    //" * " +
                    //    "parent_item_code " +
                    //    "parent_item_type, " +
                    //    "parent_item_desc, " +
                    //   // "item_description, " +
                    //   // "signal_code, " +
                    //    "parent_item_code " +


                    //"* from mmx.companies";
                    //" item_code,sales_text " +
                    //"from mmx.item_master_text";


                //"p.item_code, " +
                //"p.sales_price_list,p.price, p.zygo_company_number " +
                //    //" from mmx.item_data where item_code = '1186-300-122'";
                //"from views200.prices_price_list_and_item_sls p " +
                ////"inner join views200.prices_price_list_and_item_sls p " +
                //"where p.effective_date <= '" + date + "' and " +
                //" p.effective_date >= '06 Feb 1995' " +
                //" and p.expiry_date >= '" + date + "'";

                //"from bom.bom_whr_used ";
                //"where parent_item_code " +
                //" like 'PL%'";
                //"from mmx.item_data " +
                //"where " +
                //"(item_type = '2' or " +
                //"item_type = '1')";

                //string sql = "select " +
                //    "item_code, " +
                //    "item_type, " +
                //    "item_desc, " +
                //    "begin_item_code, " +
                //    "begin_item_desc, " +
                //    "bom_seq, " +
                //    "phantom, " +
                //    "phantom_detail_flag, " +
                //    "purch_detail_flag, " +
                //    "net_qty, " +
                //    "stock_on_hand, " +
                //    "allocated_stock, " +
                //    "non_net_stock_on_hand, " +
                //    "stock_on_order, " +
                //    "signal_code, " +
                //    "fixed_lead_time_d, " +
                //    "parent_item_code, " +
                //    "standard_cost_price " +
                //    "from bom.bom_ind_bill " +
                //    "where (begin_item_code " +
                //    "like '6300-0423-%' " +
                //    "and item_type = 'PURCH' " +
                //    "and net_qty <> 0 " +
                //    "and purch_detail_flag = 'N') " +
                //    "or (begin_item_code " +
                //    "like '6300-0423-%' " +
                //    "and item_type = 'MANUF' " +
                //    "and purch_detail_flag = 'N') ";

                //string sql = "select " +
                //    "parent_item_code, " +
                //    "parent_item_desc, " +
                //    "parent_item_type " +
                //    "from bom.bom_whr_used " +
                //    "where begin_item_code " +
                //    " = '6300-2099-01'";


                cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                da = new OracleDataAdapter(cmd);
                cb = new OracleCommandBuilder(da);
                ds = new DataSet();

                da.Fill(ds);

                DGV.DataSource = ds.Tables[0];

                //dr = cmd.ExecuteReader();

                //schemaTable = dr.GetSchemaTable();

                //foreach (DataRow row in schemaTable.Rows)
                //{
                //    object o = row.ItemArray;

                //}


                



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
    }
}