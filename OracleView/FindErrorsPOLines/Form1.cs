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
        DataTable schemaTable;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Environment.SetEnvironmentVariable("PATH", Environment.CurrentDirectory +
            //    "\\c:\\a\\oracle;", EnvironmentVariableTarget.Process);
            //Environment.SetEnvironmentVariable("Oracle_Home", Environment.CurrentDirectory +
            //    "\\c:\\a\\oracle", EnvironmentVariableTarget.Process);

            conn.ConnectionString = "user id=views200;" +
            "Password=views200;Data Source=//dbserver:1521/mkpd;";

            //conn.ConnectionString = "data source= (description=(address = (protocol = TCP)" +
            //    "Host=dbserver)(port=1521)(load_balance = on) " +
            //    "(connect_data = (server=dedicated)(service_name=mkpd)" +
            //    "(failover_mode=(type=select)(method=basic)(retries=180)(delay=5))));" +
            //    "user id=views200;Password=views200;";


            try
            {
                conn.Open();
                
                //string sql = "select " +
                    
                //    "begin_item_code, " +
                //    "parent_item_code, " +
                //    "parent_item_type, " +
                //    "parent_item_desc, " +
                //   // "item_description, " +
                //   // "signal_code, " +
                //    "parent_item_code " +
                    
                    
                //    "from bom.bom_whr_used " + 
                //    "where parent_item_code " +
                //    " = '6300-0423-01'";
                //    //"from mmx.item_data " +
                //    //"where " +
                //    //"(item_type = '2' or " +
                //    //"item_type = '1')";

                string sql = "select " +
                    "item_code, " +
                    "item_type, " +
                    "item_desc, " +
                    "begin_item_code, " +
                    "begin_item_desc, " +
                    "bom_seq, " +
                    "phantom, " +
                    "phantom_detail_flag, " +
                    "purch_detail_flag, " +
                    "net_qty, " +
                    "stock_on_hand, " +
                    "allocated_stock, " +
                    "non_net_stock_on_hand, " +
                    "stock_on_order, " +
                    "signal_code, " +
                    "fixed_lead_time_d, " +
                    "parent_item_code, " +
                    "standard_cost_price " +
                    "from bom.bom_ind_bill " +
                    "where (begin_item_code " +
                    "like '6300-0423-%' " +
                    "and item_type = 'PURCH' " +
                    "and net_qty <> 0 " +
                    "and purch_detail_flag = 'N') " +
                    "or (begin_item_code " +
                    "like '6300-0423-%' " +
                    "and item_type = 'MANUF' " +
                    "and purch_detail_flag = 'N') ";

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

                dr = cmd.ExecuteReader();

                //schemaTable = dr.GetSchemaTable();

                //foreach (DataRow row in schemaTable.Rows)
                //{
                //    object o = row.ItemArray;
                   
                //}


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        File.AppendAllText(@"C:\A\BOM.csv", dr.GetString(0).ToString() + ",");
                        File.AppendAllText(@"C:\A\BOM.csv", dr.GetString(1).ToString() + ",");
                        File.AppendAllText(@"C:\A\BOM.csv", dr.GetString(2).ToString() + ",");
                        File.AppendAllText(@"C:\A\BOM.csv", dr.GetString(3).ToString() + ",");
                        File.AppendAllText(@"C:\A\BOM.csv", dr.GetString(4).ToString() + ",");
                        File.AppendAllText(@"C:\A\BOM.csv", dr.GetInt32(5) + ",");
                        if (!dr.IsDBNull(6))
                        { File.AppendAllText(@"C:\A\BOM.csv", dr.GetDecimal(6) + ","); }
                        else { File.AppendAllText(@"C:\A\BOM.csv", ","); }
                        File.AppendAllText(@"C:\A\BOM.csv", dr.GetString(7).ToString() + ",");
                        File.AppendAllText(@"C:\A\BOM.csv", dr.GetString(8).ToString() + ",");
                        if (!dr.IsDBNull(9))
                        { File.AppendAllText(@"C:\A\BOM.csv", dr.GetDecimal(9) + ","); }
                        else { File.AppendAllText(@"C:\A\BOM.csv", ","); }
                        File.AppendAllText(@"C:\A\BOM.csv", dr.GetDecimal(10) + ",");
                        File.AppendAllText(@"C:\A\BOM.csv", dr.GetDecimal(11) + ",");
                        File.AppendAllText(@"C:\A\BOM.csv", dr.GetDecimal(12) + ",");
                        File.AppendAllText(@"C:\A\BOM.csv", dr.GetDecimal(13) + ",");
                        File.AppendAllText(@"C:\A\BOM.csv", dr.GetString(14).ToString() + ",");
                        File.AppendAllText(@"C:\A\BOM.csv", dr.GetDecimal(15) + ",");
                        if (!dr.IsDBNull(16))
                        { File.AppendAllText(@"C:\A\BOM.csv", dr.GetString(16) + ","); }
                        else { File.AppendAllText(@"C:\A\BOM.csv", ","); }
                        File.AppendAllText(@"C:\A\BOM.csv", dr.GetDecimal(17) + ",");
                        File.AppendAllText(@"C:\A\BOM.csv", Environment.NewLine);
                    }
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
    }
}