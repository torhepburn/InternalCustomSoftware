using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;

namespace BL_MK
{
    public partial class BLmk : Form
    {
        OracleConnection conn = new OracleConnection();
        OracleCommand cmd;
        OracleDataAdapter da;
        OracleCommandBuilder cb;
        DataTable mkTable;
        
        public BLmk()
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
                             "r.receipt_number, " +
                             "r.item_code, " +
                             "r.item_description as receipt_item_description, " +
                             "l.description as business_line_description " +
                             "from views600.receipts r " +
                             "inner join views600.suppliers s on " +
                             "r.supplier = s.supplier " +
                             "left join views600.Lines_of_Business l on " +
                             "s.line_of_business = l.code " +
                             "where r.receipt_date > '01-JUL-2009'" +
                             "order by receipt_number";

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
                ("server=middbsql; user=views; " +
                 "password=views; database=webtables;");
            

            try
            {
                SqlCommand xcmd = new SqlCommand
                ("delete from backlogmk600", blCnxn);
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
            copy.DestinationTableName = "backlogmk600";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            //200
            try
            {
                conn.Open();

                string sql = "select " +
                             "r.receipt_number, " +
                             "r.item_code, " +
                             "r.item_description as receipt_item_description, " +
                             "l.description as business_line_description " +
                             "from views200.receipts r " +
                             "inner join views200.suppliers s on " +
                             "r.supplier = s.supplier " +
                             "left join views200.Lines_of_Business l on " +
                             "s.line_of_business = l.code " +
                             "where r.receipt_date > '01-JUL-2009'" +
                             "order by receipt_number";

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

            blCnxn = new SqlConnection
                ("server=middbsql; user=views; " +
                 "password=views; database=webtables;");


            try
            {
                SqlCommand xcmd = new SqlCommand
                ("delete from backlogmk200", blCnxn);
                xcmd.Connection.Open();
                xcmd.ExecuteNonQuery();
                xcmd.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            blCnxn.Open();
            copy = new SqlBulkCopy(blCnxn);
            copy.DestinationTableName = "backlogmk200";
            try
            {
                copy.WriteToServer(mkTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            // update tables for commodity class

            SqlCommand cmd1 = new SqlCommand(
                   "CommodityClass", blCnxn);
            cmd1.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            // take care of nulls in report

            cmd1 = new SqlCommand(
                   "rpt200", blCnxn);
            cmd1.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd1.ExecuteNonQuery();
                blCnxn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}