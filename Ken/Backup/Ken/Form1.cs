using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.IO;

namespace Ken
{
    public partial class Form1 : Form
    {
        private OracleConnection conn = new OracleConnection();
        private OracleCommand cmd;
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        private DataSet ds;
        private OracleDataReader dr;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "user id=views200;" +
            "Password=views200;Data Source=//dbserver:1521/mkpd;";

            try
            {
                conn.Open();
                
                //string sql = "select distinct " +
                //    "work_center, " +
                //    "item_code, " +
                //    "item_description, " +
                //    "stock_on_hand, " +
                //    "order_no, " +
                //    "ord_order_quantity, " +
                //    "ord_quantity_posted, " +
                //    "ord_total_scrapped, " +
                //    "ord_start_date, " +
                //    "ord_order_status, " +
                //    "ord_project, " +
                //    "ord_rework_production_order, " +
                //    "ord_planned_delivery_date " +
                //    "from views200.production_plan_by_order_addnl " +
                //    "where ord_order_status < 6 and " +
                //    "(work_center = '710' or " +
                //    "work_center = '711' or " +
                //    "work_center = '712' or " +
                //    "work_center = '713' or " +
                //    "work_center = '716' or " +
                //    "work_center = '717' or " +
                //    "work_center = '718' or " +
                //    "work_center = '721' or " +
                //    "work_center = '722' or " +
                //    "work_center = '723' or " +
                //    "work_center = '724' or " +
                //    "work_center = '725' or " +
                //    "work_center = '726' or " +
                //    "work_center = '770')";

                string sql = "Select " +
                    "d.order_no, " +
                    "d.position, " +
                    "d.srno, " +
                    "d.customer, " +
                    "d.item_code, " +
                    "d.ordered_quantity, " +
                    "o.route, " +
                    "o.customer_po " +
                    "from " +
                    "mmx.sales_deliveries d " +
                    "inner join mmx.sales_orders o " +
                    "on d.order_no = o.order_no " +
                    //"where d.picking_list_number = 70851 " +
                    "where d.picking_list_number = 62079";
                    //"where o.route like 'SL%' "; 
                    //"and o.customer_po like '%AMI%' ";

                string rout = "Select * from mmx.routing " +
                    " where manufactured_item like '8070-0102%' " +
                    " order by manufactured_item asc";

                cmd = new OracleCommand(rout, conn);
                //cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                da = new OracleDataAdapter(cmd);
                //cb = new OracleCommandBuilder(da);  not necessary
                ds = new DataSet();

                da.Fill(ds);

                DGV.DataSource = ds.Tables[0];

                dr = cmd.ExecuteReader();

                //if (dr.HasRows)
                //{
                //    while (dr.Read())
                //    {
                //        File.AppendAllText(@"c:\a\ttt.txt", dr.GetString(0).ToString().Trim() + ",");
                //        File.AppendAllText(@"c:\a\ttt.txt", dr.GetString(1).ToString().Trim() + ",");
                //        File.AppendAllText(@"c:\a\ttt.txt", dr.GetString(2).ToString().Trim() + ",");
                //        File.AppendAllText(@"c:\a\ttt.txt", dr.GetString(3).ToString().Trim() + ",");
                //        File.AppendAllText(@"c:\a\ttt.txt", dr.GetString(4).ToString().Trim() + ",");
                //        File.AppendAllText(@"c:\a\ttt.txt", dr.GetString(5).ToString().Trim() + ",");
                //        File.AppendAllText(@"c:\a\ttt.txt", dr.GetString(6).ToString().Trim() + ",");
                //        File.AppendAllText(@"c:\a\ttt.txt", dr.GetString(7).ToString().Trim() + ",");
                //        File.AppendAllText(@"c:\a\ttt.txt", dr.GetString(8).ToString().Trim() + ",");
                //        File.AppendAllText(@"c:\a\ttt.txt", dr.GetString(9).ToString().Trim() + ",");
                //        File.AppendAllText(@"c:\a\ttt.txt", dr.GetString(10).ToString().Trim() + ",");
                //        File.AppendAllText(@"c:\a\ttt.txt", dr.GetString(11).ToString().Trim() + ",");
                //        File.AppendAllText(@"c:\a\ttt.txt", dr.GetString(12).ToString().Trim() + Environment.NewLine);
                //    }
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