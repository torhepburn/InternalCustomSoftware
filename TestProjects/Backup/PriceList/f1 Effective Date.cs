using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.SqlClient;


namespace PriceList
{
    public partial class f1_Effective_Date : Form
    {
        private string effectiveDate;
        private string select;
        private string tableName;
        private string company;
        private string cnxn = "provider=microsoft.jet.oledb.4.0;" +
            "server=mkpd;DSN=mkpd;uid=views; pwd=views; ";
        SqlConnection SqlCnxn;
        private string SqlDb = "server = middbsql; password = views; user = views; " +
                  "database = pricelists;";
        BindingSource bs = new BindingSource();
        SqlConnection SQLcnxn2;
        SqlParameter stxt;
        private string itemcode;
        private string Stext;
        private string flag;
        
        public f1_Effective_Date()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            LselectDate.Text = "Working";

            SqlCnxn = new SqlConnection(SqlDb);
            SqlCommand cmd = new SqlCommand
                ("delete from itemdata; " +
                 "delete from itemtext; " +
                 "delete from plistitemsls; " +
                 "delete from pricegroups; " +
                 "delete from pricelistcodes", SqlCnxn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            
            effectiveDate = monthCalendar1.SelectionStart.ToString("dd-MMM-yyyy");
            monthCalendar1.Hide();

            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 11;
            progressBar1.Value = 0;
            progressBar1.Step = 1;

            //sales price list

            select =
                "(select " +
                "sales_price_list, " +
                "item_code, " +
                "effective_date, " +
                "expiry_date, " +
                "price, " +
                "Zygo_company_number " +
                "from views600.prices_price_list_and_item_sls " +
                "where item_code not in " +
                "(select item_code from " +
                "views200.prices_price_list_and_item_sls) " +
                "and effective_date > '06-Feb-1995' and " +
                "effective_date < sysdate and " +
                "expiry_date >= sysdate) " +
                "union " +
                "(select " +
                "sales_price_list, " +
                "item_code, " +
                "effective_date, " +
                "expiry_date, " +
                "price, " +
                "Zygo_company_number " +
                "from views200.prices_price_list_and_item_sls " +
                "where " +
                "effective_date > '06-Feb-1995' and " +
                "effective_date <= '" + effectiveDate + "' and " +
                "expiry_date >= sysdate) ";
            tableName = "PListItemSls";

            makeTables();

            progressBar1.PerformStep();

            //Tried to do the same with item_data but timed out or
            // something like that and didn't give a clear message

            company = "200";
            CompanyTables();
            company = "600";
            CompanyTables();

            LselectDate.Text = "Done";

            SqlCnxn = new SqlConnection(SqlDb);

            SqlDataAdapter Sda = new SqlDataAdapter
                ("select " +
                 "i.Item_Code " +

                 "from itemcodeclassnotes i " +
                 "left join itemtext t on " +
                 "i.item_code = t.item_code " +
                 "where sales_text is null", SqlCnxn);

            DataTable Stable = new DataTable();

            Sda.Fill(Stable);

            if (Stable.Rows.Count > 0)
            {
                bs.DataSource = Stable;
                DGV.DataSource = bs;
                DGV.Show();
                LselectDate.Text = "The items listed below require sales text.";
            }

            SqlCnxn = new SqlConnection(SqlDb);
            SqlCnxn.Open();
            cmd = new SqlCommand("select item_code, sales_text from " +
                "itemtext", SqlCnxn);

            SqlDataReader dr;

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                itemcode = dr.GetString(0).Trim();
                Stext = dr.GetString(1);

                while (Stext.IndexOf("\n") > 0)
                {
                    flag = "yes";
                    string nText = Stext.Replace("\n", " ");
                    stxt = new SqlParameter("@Sales_Text", SqlDbType.NVarChar, 500);
                    stxt.Value = nText;
                    Stext = nText;
                }

                while (Stext.IndexOf("|") > 0)
                {
                    flag = "yes";
                    string nText = Stext.Replace("|", "");
                    stxt = new SqlParameter("@Sales_Text", SqlDbType.NVarChar, 500);
                    stxt.Value = nText;
                    Stext = nText;
                }


                if (flag == "yes")
                {
                    SQLcnxn2 = new SqlConnection(SqlDb);
                    SQLcnxn2.Open();
                    SqlCommand cmd2 = new SqlCommand(
                        "update itemtext set Sales_text " +
                        "= " + stxt + " where item_code = '" +
                        itemcode + "'", SQLcnxn2);
                    cmd2.Parameters.Add(stxt);
                    int rows = cmd2.ExecuteNonQuery();
                    SQLcnxn2.Close();
                    cmd2.Dispose();
                    flag = "no";
                }
            }
 

            PriceList p1 = new PriceList();
            p1.Show();
        }

        private void CompanyTables()
        {
            select = "select " +
                "item_code, " +
                "description, " +
                "sales_price_group, " +
                "product_type, " +
                "item_group, " +
                "item_type, " +
                "zygo_company_number " +
                "from views" + company + ".item_data " +
                "where signal_code not like 'OBS%'";
            tableName = "ItemData";

            makeTables();

            // need to use Oracle not SQL functions
            select = "select " +
                "item_code, " +
                "substr(sales_text,1, (Length(sales_text)-4)) as sales_text, " +
                company +
                " from views" + company + ".item_master_text " +
                "where sales_text is not null and item_code " +
                " not like 'FREIGHT%'";
            tableName = "ItemText";

            makeTables();

            select = "select " +
                "code as Price_Group_Code, " +
                "description as Price_Group_Description, " +
                "zygo_company_number " +
                "from views" + company + ".price_groups";
            tableName = "PriceGroups";

            makeTables();

            select = "select " +
                "code as Price_List_Code, " +
                "description as Price_List_Description, " +
                "zygo_company_number " +
                "from views" + company + ".price_lists " +
                "where description not like 'Obs%' ";
            tableName = "PriceListCodes";

            makeTables();
        }
        
        private void makeTables()
        {
            OdbcConnection odBC = new OdbcConnection(cnxn);
            odBC.ConnectionTimeout = 6000;
            OdbcDataAdapter da = new OdbcDataAdapter
               (select, cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            //bs.DataSource = table;
            //DGV.DataSource = bs;
            //DGV.Show();

            SqlCnxn = new SqlConnection(SqlDb);

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
            progressBar1.PerformStep();
        }

        private void f1_Effective_Date_Load(object sender, EventArgs e)
        {
            DGV.Hide();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        


    }

   
}