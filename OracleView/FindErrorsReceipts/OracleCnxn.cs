using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Ken
{
    public partial class OracleCnxn : Form
    {
        private OracleConnection conn = new OracleConnection();
        private OracleCommand cmd;
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        DataTable StartTable;
        DataTable EndTable;
        DataTable TempTable;
        private string taReceipt;
        private string Spply_Commodity;
        private string Description;
        
        public OracleCnxn()
        {
            InitializeComponent();
        }

        private void OracleCnxn_Load(object sender, EventArgs e)
        {
            //conn.ConnectionString = "user id=views;" +
            //    "Password=views;Data Source=//dbserver:1521/mkpd;";

            //try
            //{
            //    conn.Open();

            //    string sql = "select  " +
            //                  "l.description " +
            //                  "from views600.receipts r " +
            //                  "inner join views600.suppliers s on " +
            //                  "r.supplier = s.supplier " +
            //                  "left join views600.Lines_of_Business l on " +
            //                  "s.line_of_business = l.code " +
            //                  "where r.receipt_number = 92454";

            //    cmd = new OracleCommand(sql, conn);
            //    cmd.CommandType = CommandType.Text;

            //    object o = cmd.ExecuteScalar();

            //    string rr = o.ToString();

            //    sql = "select  " +
            //          "r.item_description " +
            //          "from views600.receipts r " +
            //          "inner join views600.suppliers s on " +
            //          "r.supplier = s.supplier " +
            //          "left join views600.Lines_of_Business l on " +
            //          "s.line_of_business = l.code " +
            //          "where r.receipt_number = 92454";

            //    cmd = new OracleCommand(sql, conn);
            //    cmd.CommandType = CommandType.Text;

            //    o = cmd.ExecuteScalar();

                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }
    }
}