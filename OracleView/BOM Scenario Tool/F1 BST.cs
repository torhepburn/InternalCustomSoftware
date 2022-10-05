using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data.SqlClient;
using System.IO;


namespace BOM_Scenario_Tool
{
    public partial class Form1 : Form
    {
        private OracleConnection conn = new OracleConnection();
        private OracleCommand cmd;
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        DataTable table;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "user id=views200;" +
                "Password=views200;Data Source=//dbserver:1521/mkpd;";

            //try
            //{
            conn.Open();

            //string parentBOM = "'8070-0102-01'";
            //string parentBOM = "'6300-0767-04'";

            string sql = "select   " +

                "item_code, " +
                "item_type, " +
                "item_desc, " +
                "begin_item_code, " +
                "begin_item_desc, " +
                "BOM_seq, " +
                "bom_level, " +
                "mfg_condensed_level_flag, " +
                "phantom, " +
                "phantom_detail_flag, " +
                "purch_detail_flag, " +
                "net_qty, " +
                "ext_net_qty, " +
                "stock_on_hand, " +
                "allocated_stock, " +
                "non_net_stock_on_hand, " +
                ////"(stock_on_hand + stock_on_order)- allocated_stock, " +
                ////"stock_on_hand - non_net_stock_on_hand, " +
                "stock_on_order, " +
                "signal_code, " +
                "fixed_lead_time_d, " +
                "'parent_item_code' " +
                //"standard_cost_price " +
                "from bom.bom_ind_bill " +
                "where " +
                "(item_type = 'PURCH' and " +
                "begin_item_code = '8070-0279-01' " +
                "and purch_detail_flag = 'N' " +
                "and net_qty <> 0) " +
                "or " +
                "(item_type = 'MANUF' and " +
                "begin_item_code = '8070-0279-01'  " +
                "and purch_detail_flag = 'N') order by item_code ";

            cmd = new OracleCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 1800;
            da = new OracleDataAdapter(cmd);
            cb = new OracleCommandBuilder(da);
            table = new DataTable();

            da.Fill(table);

            DGV.DataSource = table;

            //foreach (DataRow row in table.Rows)
            //{
            //    File.AppendAllText(@"C:\a\BOM.txt", 
            //        row[0].ToString() + " " +
            //        row[1].ToString() + " " + 
            //        row[2].ToString() + Environment.NewLine);
            //}

            //    SqlConnection SqlCnxn = new SqlConnection
            //        ("server=midsql01; user=readwrite; password=Read+Write!;" +
            //         "database=AccessFrontEnds");

            //    SqlCnxn.Open();
            //    //SqlCommand cmd1 = new SqlCommand("insert into BST_BOMindBill (item_code) values 'test'", SqlCnxn);
            //    //cmd1.ExecuteNonQuery();

            //    SqlBulkCopy copy = new SqlBulkCopy(SqlCnxn);
            //    copy.DestinationTableName = "BST_BOMindBill";

            //    try
            //    {
            //        copy.WriteToServer(table);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }

            //    SqlCnxn.Close();


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
            //finally
            //{
            //    conn.Dispose();
            //}
            //}

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
        }
    }
}