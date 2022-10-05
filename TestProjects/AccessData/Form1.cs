using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace AccessData
{
    public partial class Form1 : Form
    {
        OleDbConnection cxn;
        OleDbDataAdapter da;
        private string select;
        private string tableName;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



            select = "select " +
                "ItemClassCode, " +
                "ItemClass, " +
                "ItemClassCodeFolder " +
                "from Item_Classes ";
            tableName = "[ItemClasses]";

            makeTables();


            select = "select " +
                "Item_Code, " +
                "ItemClassCode, " +
                "ItemNotes, " +
                "TradeInValue " +
                "from Item_Code_Class_and_Notes ";
            tableName = "[itemcodeclassnotes]";

            makeTables();

        }

        private void makeTables()
        {

            string db = "provider=microsoft.jet.oledb.4.0;  " +
                         "data source=" + // C:\\Documents and " +
                //             "Settings\\bsilvert\\Desktop\\pricelist\\newpricelist.MDB;";
            "\\\\Midfile01\\Departments\\Sales\\Sales & Marketing Pricelists\\PriceListDB\\mkpricelistmaintnew.mdb;";
            cxn = new OleDbConnection(db);
            da = new OleDbDataAdapter(select, cxn);

            DataTable table = new DataTable();

            da.Fill(table);
          
            SqlConnection SqlCnxn = new SqlConnection
                ("server = middbsql; password = views; user = views; " +
                  "database = pricelists;");
            SqlCnxn.Open();
            SqlBulkCopy copy = new SqlBulkCopy(SqlCnxn);
            copy.DestinationTableName = tableName;

            try
            {
                copy.WriteToServer(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            SqlCnxn.Close();

        }
    }
}