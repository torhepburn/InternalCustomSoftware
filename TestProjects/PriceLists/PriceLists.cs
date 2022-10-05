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

namespace PriceLists
{
    public partial class PriceLists : Form
    {
        private OracleConnection conn = new OracleConnection();
        private OracleCommand cmd;
        private OracleDataAdapter da;
        private OracleCommandBuilder cb;
        private OracleDataReader dr;

        SqlConnection cnxn;
        SqlCommand cmdSQL;
        
        private string itemCode;
        private string splist;
        private decimal price;
        private string ZcompanyNumber;
        
        
        public PriceLists()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = "user id=views200;" +
            "Password=views200;Data Source=//dbserver:1521/mkpd;";
            //conn.ConnectionString = "user id=views;" +
            //"Password=views;Data Source=//dbserver:1521/mkpd;";

            try
            {
                conn.Open();

                DateTime now = DateTime.Now;
                string date = now.ToString("dd MMM yyyy");


                string sql = "select  " +
                "item_code, " +
                "sales_price_list, " +
                "price, " +
                "zygo_company_number " +
                "from views200.prices_price_list_and_item_sls  " +
                "where effective_date <= '" + date + "' and " +
                " effective_date >= '06 Feb 1995' " +
                " and expiry_date >= '" + date + "'";

                cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                da = new OracleDataAdapter(cmd);
                cb = new OracleCommandBuilder(da);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    itemCode = dr.GetString(0).Trim();
                    splist = dr.GetString(1).Trim();
                    price = dr.GetDecimal(2);
                    ZcompanyNumber = dr.GetString(3);

                    cmdSQL = new SqlCommand
                        ("Insert into [price list items] " +
                         "([sales price list], [item code], " +
                         "price, [zygo company number]) values " +
                         "('" + splist + "','" +
                         itemCode + "'," +
                         price + ",'" +
                         ZcompanyNumber + "')");

                    cnxn = new SqlConnection
                        ("server = midprj01; password = views; " +
                         "user = views; database = pricelists;");
                    cmdSQL.Connection = cnxn;
                    cnxn.Open();
                    int rr = cmdSQL.ExecuteNonQuery();
                    cnxn.Close();
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

        private void Bitemdata_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = "user id=views200;" +
            "Password=views200;Data Source=//dbserver:1521/mkpd;";
            //conn.ConnectionString = "user id=views;" +
            //"Password=views;Data Source=//dbserver:1521/mkpd;";

            

             try
            {
                conn.Open();

                DateTime now = DateTime.Now;
                string date = now.ToString("dd MMM yyyy");


                string sql = "select  " +
                "item_code, " +
                "description, " +
                "zygo_company_number " +
                "from views200.item_data";
                
                cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                da = new OracleDataAdapter(cmd);
                cb = new OracleCommandBuilder(da);
  
                 
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    SqlParameter Idescription = new SqlParameter("@Idesc", SqlDbType.VarChar, 30);
                    
                    itemCode = dr.GetString(0).Trim();
                    Idescription.Value = dr.GetString(1).Trim();
                    ZcompanyNumber = dr.GetString(2);


                    cmdSQL = new SqlCommand
                        ("Insert into [item descriptions] " +
                         "([item code],[item description], " +
                         "[zygo company number]) values " +
                         "('" + itemCode + "'," +
                         Idescription + ",'" +
                         ZcompanyNumber + "')");

                    cmdSQL.Parameters.Add(Idescription);
                    cnxn = new SqlConnection
                        ("server = midprj01; password = views; " +
                         "user = views; database = pricelists;");
                    cmdSQL.Connection = cnxn;
                    cnxn.Open();
                    int rr = cmdSQL.ExecuteNonQuery();
                    cnxn.Close();
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