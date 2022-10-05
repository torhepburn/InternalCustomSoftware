using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace CS_ODBC_connect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string cnxn = "Driver= {sql Server};server=midprj01;DSN=calibration;" +
            //              "uid=views; pwd=views; ";

            string cnxn = "provider=microsoft.jet.oledb.4.0;server=mkpd;DSN=mkpd;" +
                          "uid=views; pwd=views; ";
            OdbcConnection odBC = new OdbcConnection(cnxn);
            odBC.ConnectionTimeout = 3000;
            //odBC.Open();
            
            BindingSource bs = new BindingSource();

                       
            //OdbcDataAdapter da = new OdbcDataAdapter("select * from calibration.dbo.rooms", cnxn);
            //OdbcDataAdapter da = new OdbcDataAdapter("select * from projects where project='273688'", cnxn);


            // Prices Price List and Item SLS

            //OdbcDataAdapter da = new OdbcDataAdapter
            //   ("select " +
            //    "sales_price_list, " +
            //    "item_code, " +
            //    "effective_date, " +
            //    "expiry_date, " +
            //    "price, " +
            //    "Zygo_company_number " +
            //    "from views200.prices_price_list_and_item_sls " +
            //    "where effective_date > '06-Feb-1995' and " +
            //    "expiry_date >= '06-Feb-1995' ", cnxn);


            //// Item Data

            //OdbcDataAdapter da = new OdbcDataAdapter
            //   ("select " +
            //    "item_code, " +
            //    "description, " +
            //    "sales_price_group, " +
            //    "product_type, " +
            //    "item_group, " +
            //    "item_type " +
            //    "from views600.item_data " +
            //    "where signal_code not like 'OBS%'", cnxn);

            //Item Text

            OdbcDataAdapter da = new OdbcDataAdapter
               ("select " +
                "item_code, " +
                "sales_text " +
                "from views200.item_master_text", cnxn);


            ////Price Groups

            //OdbcDataAdapter da = new OdbcDataAdapter
            //   ("select " +
            //    "code as Price_Group_Code, " +
            //    "description as Price_Group_Description, " +
            //    "zygo_company_number " +
            //    "from views600.price_groups", cnxn);


            ////Price Lists

            //OdbcDataAdapter da = new OdbcDataAdapter
            //   ("select " +
            //    "code as Price_List_Code, " +
            //    "description as Price_List_Description, " +
            //    "zygo_company_number " +
            //    "from views600.price_lists " +
            //    "where description not like 'Obs%' ", cnxn);


            ////Product Types

            //OdbcDataAdapter da = new OdbcDataAdapter
            //   ("select " +
            //    "Product_Type, " +
            //    "description as Product_Type_Description, " +
            //    "zygo_company_number " +
            //    "from views200.product_types ", cnxn);

            
            
            //OdbcDataAdapter da = new OdbcDataAdapter("select item_code from bom.bom_ind_bill where item_code = '4022.631.88374'", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            dataGridView1.DataSource = bs;
            dataGridView1.Show();

            SqlConnection SqlCnxn = new SqlConnection
                ("server = middbsql; password = views; user = views; " +
                  "database = pricelists;");
            SqlCnxn.Open();
            SqlBulkCopy copy = new SqlBulkCopy(SqlCnxn);
            copy.DestinationTableName = "ItemText";

            //Price_List_Item_Sls
            //"dbo.ItemData"
            //"dbo.ItemText"
            //"dbo.PriceListCodes"

            try
            {
                copy.WriteToServer(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            ////SqlCommand cmd = new SqlCommand("select * into ItemData from table", SqlCnxn);

            ////SqlCnxn.Open();

            ////int rows = cmd.ExecuteNonQuery();

            SqlCnxn.Close();
            
            //OdbcConnection odBC = new OdbcConnection(cnxn);
            //string insert = "insert into calibration.dbo.rooms (r_Roomnumber, R_description)" +
            //    " values ('1506', 'Temporary')";
            //OdbcCommand cmd = new OdbcCommand(insert);
            //cmd.Connection = odBC;
            //odBC.Open();
            //cmd.ExecuteNonQuery();
            //cmd.Connection.Close();
        }
    }
}