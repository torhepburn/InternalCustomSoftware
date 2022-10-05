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
    public partial class ProductionBomTest : Form
    {
        private OracleConnection conn = new OracleConnection();
        private OracleCommand cmd;
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        private DataSet ds;
        DataTable table;
        
        public ProductionBomTest()
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

                string sql = "select   " +
                    "manufactured_item,  " +
                    "item_code_component, " +
                    "position," +
                    "effective_date " +
                     "from views200.production_BOM " + 
                     "where effective_date < '01-JAN-1754' " +  
                     "order by effective_date";


                cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 1800;
                da = new OracleDataAdapter(cmd);
                cb = new OracleCommandBuilder(da);
                table = new DataTable();

                da.Fill(table);

                File.WriteAllText(@"C:\a\Production BOM.txt", 
                    "Mfd Item - Component - Position - Effective Date" 
                    + Environment.NewLine + Environment.NewLine);

                foreach (DataRow row in table.Rows)
                {
                    File.AppendAllText(@"C:\a\Production BOM.txt",
                        row[0].ToString() + " " +
                        row[1].ToString() + " " +
                        row[2].ToString() + " " +
                        row[3].ToString() + Environment.NewLine);
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