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


namespace Ken
{
    public partial class test : Form
    {
        private OracleConnection conn = new OracleConnection();
        private OracleCommand cmd;
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        private DataSet ds;
        //private DataSet dsFAST;
        DataTable StartTable;
        DataTable EndTable;
        DataTable TempTable;
        private string taReceipt;
        private string Spply_Commodity;
        private string Description;
         
        public test()
        {
            InitializeComponent();
        }

        private void MRB_Load(object sender, EventArgs e)
        {
            //conn.ConnectionString = "user id=views200;" +
            //"Password=views200;Data Source=//dbserver:1521/mkpd;";

            conn.ConnectionString = "user id=views;" +
                "Password=views;Data Source=//dbserver:1521/mkpd;";

            try
            {
                conn.Open();

                string sql = "select  " +
                              "l.description " +
                              "from views600.receipts r " +
                              "inner join views600.suppliers s on " +
                              "r.supplier = s.supplier " +
                              "left join views600.Lines_of_Business l on " +
                              "s.line_of_business = l.code " +
                              "where r.receipt_number = 92454";

                cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                object o = cmd.ExecuteScalar();

                string t = o.ToString();

                sql = "select  " +
                      "r.item_description " +
                      "from views600.receipts r " +
                      "inner join views600.suppliers s on " +
                      "r.supplier = s.supplier " +
                      "left join views600.Lines_of_Business l on " +
                      "s.line_of_business = l.code " +
                      "where r.receipt_number = 92454 ";

                cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                o = cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //try
            //{
            //    conn.Open();

            //    string sql = "select  " +
            //                 "e.name as EmpName, " +
            //                 "w.item_code, " +
            //                 "w.item_description, " +
            //                 "w.warehouse, " +
            //                 "w.last_trn_date_stk_om_hand, " +
            //                 "w.stock_on_hand, " +
            //                 "w.allocated_stock, " +
            //                 "w.blocked_stock, " +
            //                 "w.non_nettable_stock_quantity, " +
            //                 "(w.stock_on_hand * d.standard_cost_price) as Value," +
            //                 "d.standard_cost_price " +
            //                 "from views200.item_data_by_warehouse w " +
            //                 "left join views200.item_data d on " +
            //                 "w.item_code = d.item_code " +
            //                 "left join views200.employees e on " +
            //                 "d.planner_code = e.employee " +
            //                 "where (w.warehouse like '%MR%' or " +
            //                 "w.warehouse like '%45') and " +
            //                 "w.stock_on_hand != 0 " +
            //                 " order by e.name   ";


            //    cmd = new OracleCommand(sql, conn);
            //    cmd.CommandType = CommandType.Text;

            //    da = new OracleDataAdapter(cmd);
            //    cb = new OracleCommandBuilder(da);
            //    ds = new DataSet();

            //    da.Fill(ds);

            //    DGV.DataSource = ds.Tables[0];


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
            //finally
            //{
            //    conn.Dispose();
            //}

            SqlConnection cnxn = new SqlConnection
                ("server = middbsql\\sql2000; user = views; " +
                 "password = views; database = dashboard;");
            SqlDataAdapter Sda = new SqlDataAdapter
                ("select " +
                 "ta.mkreceipttransactionid, " +
                 "ta.PartNumber, " +
                 "ta.order_no as OrdNum, " +
                 "ma.originalQty as RcvdQty, " +
                 "ma.MaintainOperator as Inspector, " +
                 "ma.transactiondate as DateApprvd, " +
                 "ta.receiptnumber_int " +
                 "from [tracking - all] ta " +
                 "inner join view_maintain_approval ma " +
                 "on ta.mkreceipttransactionid = " +
                 "ma.mkreceipttransactionid " +
                 "where  " +
                 "ta.companyID = 600 " +
                 "and ma.transactiondate >= '2009-01-01' " +
                 "group by " +
                 "ta.mkreceipttransactionid, " +
                 "ta.PartNumber, " +
                 "ta.order_no, " +
                 "ma.originalQty, " +
                 "ma.MaintainOperator, " +
                 "ma.transactiondate, " +
                 "ta.receiptnumber_int " +
                 "order by ta.mkreceipttransactionid"
                 , cnxn);

            try
            {
                StartTable = new DataTable();
                Sda.Fill(StartTable);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            StartTable.Columns.Add("Spplr_Commodity", typeof(string));
            StartTable.Columns.Add("Description", typeof(string));

            EndTable = StartTable.Clone();

            foreach (DataRow row in StartTable.Rows)
            {
                taReceipt = row[6].ToString();

                conn.ConnectionString = "user id=views;" +
                "Password=views;Data Source=//dbserver:1521/mkpd;";

                try
                {
                    conn.Open();

                    string sql = "select  " +
                                  "l.description " +
                                  "from views600.receipts r " +
                                  "inner join views600.suppliers s on " +
                                  "r.supplier = s.supplier " +
                                  "left join views600.Lines_of_Business l on " +
                                  "s.line_of_business = l.code " +
                                  "where r.receipt_number = " + taReceipt + " ";

                    cmd = new OracleCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;

                    object o = cmd.ExecuteScalar();

                    row[7] = o.ToString();

                    sql = "select  " +
                          "r.item_description " +
                          "from views600.receipts r " +
                          "inner join views600.suppliers s on " +
                          "r.supplier = s.supplier " +
                          "left join views600.Lines_of_Business l on " +
                          "s.line_of_business = l.code " +
                          "where r.receipt_number = " + taReceipt + " ";

                    cmd = new OracleCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;

                    o = cmd.ExecuteScalar();

                    row[8] = o.ToString();

                    DataRow newRow = EndTable.NewRow();
                    newRow.ItemArray = row.ItemArray;
                    EndTable.Rows.Add(newRow);

                    //da = new OracleDataAdapter(cmd);
                    //cb = new OracleCommandBuilder(da);
                    //TempTable = new DataTable();

                    //da.Fill(TempTable);

                    //Description 

                    //DGV.DataSource = ds.Tables[0];

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    conn.Close();
                }

            }
            DGV.DataSource = EndTable;

            }

        }
    }
