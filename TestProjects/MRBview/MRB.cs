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


namespace MRBview
{
    public partial class MRB : Form
    {
        private OracleConnection conn = new OracleConnection();
        private OracleCommand cmd;
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        //private DataSet ds;
        DataTable table;
        private string item;
        SqlConnection cnxn;
        SqlCommand SqlCmd;
        DataTable FastTable;
        private string FastID;
        private string FastResponsibleUser;
        DataTable EndTable;
        public MRB()
        {
            InitializeComponent();
        }

        private void MRB_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "user id=views;" +
            "Password=views;Data Source=//dbserver:1521/mkpd;";

            try
            {
                conn.Open();

                string sql = "select  " +
                             "e.name as EmpName, " +
                             "w.item_code, " +
                             "w.item_description, " +
                             "w.warehouse, " +
                             "w.last_trn_date_stk_om_hand, " +
                             "w.stock_on_hand, " +
                             "w.allocated_stock, " +
                             "w.blocked_stock, " +
                             "w.non_nettable_stock_quantity, " +
                             "(w.stock_on_hand * d.standard_cost_price) as Value," +
                             "d.standard_cost_price " +
                             "from views200.item_data_by_warehouse w " +
                             "left join views200.item_data d on " +
                             "w.item_code = d.item_code " +
                             "left join views200.employees e on " +
                             "d.planner_code = e.employee " +
                             "where (w.warehouse like '%MR%' or " +
                             "w.warehouse like '%45') and " +
                             "w.stock_on_hand != 0 " +
                             " order by e.name   ";
                

              
                cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                da = new OracleDataAdapter(cmd);
                cb = new OracleCommandBuilder(da);
                //ds = new DataSet();
                table = new DataTable();

                //da.Fill(ds);
                da.Fill(table);

                table.Columns.Add("FastID", typeof(int));
                table.Columns.Add("FastResponsibleUser", typeof(string));

                EndTable = table.Clone();
                
                //DGV.DataSource = ds.Tables[0];
                //DGV.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Dispose();
            }

            foreach (DataRow row in table.Rows)
            {
                item = row[1].ToString();

                cnxn = new SqlConnection
                    ("server = middbsql\\sql2000; user = views; " +
                     "password = views; database = dashboard;");
                SqlDataAdapter da = new SqlDataAdapter
                    ("select FastId, FastResponsibleUser " +
                     "from view_fast where partnumber = '" +
                    item + "' and faststatus = 'Open'", cnxn);
                FastTable = new DataTable();
                da.Fill(FastTable);
                if (FastTable.Rows.Count > 0)
                {
                    foreach (DataRow FastRow in FastTable.Rows)
                    {
                        FastID = FastRow[0].ToString();
                        FastResponsibleUser = FastRow[1].ToString();
                        row[11] = FastID;
                        row[12] = FastResponsibleUser;

                        DataRow newRow = EndTable.NewRow();
                        newRow.ItemArray = row.ItemArray;
                        EndTable.Rows.Add(newRow);
                    }
                }
                else
                {
                    DataRow newRow = EndTable.NewRow();
                    newRow.ItemArray = row.ItemArray;
                    EndTable.Rows.Add(newRow);
                }
                DGV.DataSource = EndTable;

            }
            
            
           
        }
    }
}