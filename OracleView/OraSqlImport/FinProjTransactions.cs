using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using System.Data;


namespace OraSqlImport
{
    public partial class FinProjTransactions : Form
    {
        static OracleConnection conn = new OracleConnection();
        static OracleCommand cmd;
        static OracleDataAdapter da;
        static OracleCommandBuilder cb;
        static DataTable mkTable;
        
        
        public FinProjTransactions()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "user id=views;" +
                "Password=views;Data Source=//dbserver:1521/mkpd;";
            //600
            try
            {
                conn.Open();

                string sql = "select " +
                    "f.project, " +
                    "f.order_type, " +
                    "f.order_number, " +
                    "f.position, " +
                    "f.transaction_type, " +
                    "f.transaction_date, " +
                    "f.transaction_time, " +
                    "f.srno, " +
                    "to_char(f.number_of_units), " + // as number of units, " +
                    "to_char(f.amount), " +
                    "f.financial_period, " +
                    "f.processing_date, " +
                    "f.cost_price_component, " +
                    "c.cost_type, " +
                    "c.description as CostPriceDesc, " +
                    "f.journal, " +
                    "f.debit_cost_center, " +
                    "f.debit_ledger_account, " +
                    "f.credit_cost_center, " +
                    "credit_ledger_account " +
                    "from views200.financial_project_transactions f left join " +
                    "views200.cost_price_components c on " +
                    "f.cost_price_component = c.cost_price_component " +
                    "where f.transaction_date > (select sysdate -30 from dual)";
                            // "to_char(number_of_units) from views200.financial_project_transactions " +
                             //"where transaction_date > (select sysdate -2 from dual)";
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
                MessageBox.Show(ex.Message);
            }

            SqlConnection blCnxn = new SqlConnection
                ("server=middbsql; user=rights; " +
                 "password=readingwriting; database=projects;");


            try
            {
                SqlCommand xcmd = new SqlCommand
                ("delete from mktransactionsupdate", blCnxn);
                xcmd.Connection.Open();
                xcmd.ExecuteNonQuery();
                xcmd.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            blCnxn.Open();
            SqlBulkCopy copy = new SqlBulkCopy(blCnxn);
            copy.DestinationTableName = "mktransactionsupdate";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
