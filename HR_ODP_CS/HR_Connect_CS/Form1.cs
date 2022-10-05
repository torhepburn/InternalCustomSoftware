using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace HR_Connect_CS
{
    public partial class Form1 : Form
    {
        private OracleConnection conn = new OracleConnection();
        private OracleCommand cmd;
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        private DataSet ds;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = "user id=" + tbUserID.Text + ";" +
                "Password=" + tbPassword.Text + ";Data Source=" +
                tbDataSource.Text + ";";
            try
            {
                conn.Open();
                bConnect.Enabled = false;

                string sql = "select department_name from departments " +
                    "where department_id < 100";
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                OracleDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    lbDepartments .Items.Add (dr.GetString(0));
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            //conn.ConnectionString = "user id=" + tbUserID.Text + ";" +
            //   "Password=" + tbPassword.Text + ";Data Source=" +
            //   tbDataSource.Text + ";";
            conn.ConnectionString = "user id=views200;" +
            "Password=views200;Data Source=dbserver/mkpd";
            //"(description=(address=(protocol=tcp)(host=dbserver)(port=1521)" +
            //"(connect_data=(service_name=mkpd)))";
            try
            {
                conn.Open();
                bConnect.Enabled = false;

               //string sql = "select * from bom.bom_whr_used where item_code = '4022.631.88383'";
                string sql = "select distinct " +
                    "work_center, " +
                    "item_code, " +
                    "item_description, " +
                    "stock_on_hand, " +
                    "order_no, " +
                    "ord_order_quantity, " +
                    "ord_quantity_posted, " +
                    "ord_total_scrapped, " +
                    "ord_start_date, " +
                    "ord_order_status, " +
                    "ord_project, " + 
                    "ord_rework_production_order, " + 
                    "ord_planned_delivery_date " +
                    "from views200.production_plan_by_order_addnl " +
                    "where ord_order_status < 6 and " +
                    "(work_center = '710' or " +
                    "work_center = '711' or " +
                    "work_center = '712' or " +
                    "work_center = '713' or " +
                    "work_center = '716' or " +
                    "work_center = '717' or " +
                    "work_center = '718' or " +
                    "work_center = '721' or " +
                    "work_center = '722' or " +
                    "work_center = '723' or " +
                    "work_center = '724' or " +
                    "work_center = '725' or " +
                    "work_center = '726' or " +
                    "work_center = '770')";
                    
                    
                    
   
                cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                da = new OracleDataAdapter(cmd);
                cb = new OracleCommandBuilder(da);
                ds = new DataSet();

                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
               
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