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
            conn.ConnectionString = "user id=views;" +
                "Password=views;Data Source=//dbserver:1521/mkpd;";

            try
            {
                conn.Open();

                //string sql = "select  " +
                //              "* " +
                //              //"from views200.customized_bill_of_material c " +
                //              " from views200.customized_items c  " +
                //              "where (c.project =  228070) ";

                string sql = "select  " +
                                  "* " +
                    //              "from views200.cost_center ";  //+
                    //              //"where receipt_number = '799668' ";


                //"select  " +
                    //"e.name as Name, " +
                    //"d.item_code, " +
                    // "d.planner_code " + 
                    //"w.item_description, " +
                    //"w.warehouse " +
                    //"w.stock_on_hand as OH, " +
                    //"w.allocated_stock as Allo, " +
                    //"w.blocked_stock as Blkd, " +
                    //"w.non_nettable_stock_quantity as NNet " +
                    //"(w.stock_on_hand * d.standard_cost_price) as Extended_Cost, " +
                    //"d.standard_cost_price as Cost " +
                             "from " + //views200.item_data_by_warehouse w "; 

                             "views200.project_stk_trans_by_item";
                             //"left join 
                //"views200.item_data d ";
                    //"w.item_code = d.item_code " +
                    //"left join views200.employees e on " +
                    //"d.planner_code = e.employee " +
                    //"where d.item_code = '6300-3648-01' ";
                    //"where (w.warehouse like '%MR%' or " +
                    //"w.warehouse like '%45') and " +
                    //"w.stock_on_hand != 0 " +
                    //" order by e.name   ";

                cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                da = new OracleDataAdapter(cmd);
                cb = new OracleCommandBuilder(da);
                //ds = new DataSet();
                table = new DataTable();

                //da.Fill(ds);
                da.Fill(table);

                //DGV.DataSource = ds.Tables[0];
                DGV.DataSource = table;

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