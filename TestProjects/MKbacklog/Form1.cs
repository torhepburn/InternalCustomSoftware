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


namespace MKbacklog
{
    public partial class Form1 : Form
    {
        private OracleConnection conn = new OracleConnection();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "user id=views;" +
                    "password=views;data source=//dbserver:1521/mkpd;";
            
            try
            {
                
                conn.Open();
                //string sql = "select " +
                //             "name from views200.employees where name like '%tor%'";
                //             //"r.receipt_number, " +
                //             //"r.item_description " +
                //            //"l.description " +
                             //"from " +
                             //"views600.receipts r ";
                             //"inner join " +
                             //"views600.suppliers s on " +
                             //"r.supplier = s.supplier " +
                             //"views600.lines_of_business l ";
                             //on" +
                             //"s.line_of_business = l.code " +
                             //"where r.receipt_date > '1/1/2009'";

                string sql = "select  " +
                                  "l.description " +
                                  "from views600.receipts r " +
                                  "inner join views600.suppliers s on " +
                                  "r.supplier = s.supplier " +
                                  "left join views600.Lines_of_Business l on " +
                                  "s.line_of_business = l.code " +
                                  "where r.receipt_number = 92454 ";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                object o = cmd.ExecuteScalar();

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                OracleCommandBuilder cb = new OracleCommandBuilder(da);
                DataTable table = new DataTable();
                da.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}