using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.SqlClient;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;


namespace PriceList
{
    public partial class f1_Effective_Date : Form
    {
        private string effectiveDate;
        private string select;
        private string tableName;
        SqlConnection cnxn;
        BindingSource bs = new BindingSource();
        SqlConnection cnxn2;
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

            cnxn = new SqlConnection(g.db);
            SqlCommand cmd = new SqlCommand
                ("delete from itemdata; " +
                 "delete from NAVsalesText; " +
                 "delete from itemText; " +
                 "delete from plistitemsls; " +
                 "delete from pricegroups; " +
                 "delete from pricelistcodes;"
                 , cnxn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            
            effectiveDate = monthCalendar1.SelectionStart.ToString("MM-dd-yyyy");
            monthCalendar1.Hide();

            //progressBar1.Visible = true;
            //progressBar1.Minimum = 0;
            //progressBar1.Maximum = 6;
            //progressBar1.Value = 0;
            //progressBar1.Step = 1;

            //sales price list

            string salesSelect = "FROM [ZYGO$Sales Price] s " +
                "INNER JOIN ZYGO$Item i on " +
                "s.[Item No_] = i.[No_] " +
                "where " +
                "[Signal Code] NOT LIKE 'OBS%' and " +
                "[Starting Date] > '02-06-1995' and " +
                "[Starting Date] <= '" + effectiveDate + "' and " +
                "[Ending Date] >=  '" + effectiveDate + "' ";

            select =
                "SELECT " +
                " [Sales Code] sales_price_list " +
                ",s.[Item No_] item_code " +
                ",[Starting Date] effective_date " +
                ",[Ending Date] expiry_date " +
                ",s.[Unit Price] price " + salesSelect
                ;
                
            tableName = "PListItemSls";

            makeTables();

            select =
                " SELECT " +
                " [No_] item_code " +
                ",[Description] " +
                ",[Product Types] sales_price_group " +
                ",[Product Types] product_type " +
                ",[Item Group Code] item_group " +
                "FROM [ZYGO$Item] " +
                "where [Signal Code] not like 'OBS%'";

            tableName = "ItemData";

            makeTables();


            select =
                "SELECT " +
                "[Code 1] as [item_code] " +
                ",[Line No_] as [LineNo] " +
                ",[Text] [Sales_Text] " +
                "from [ZYGO$Text Module Line] " +
                "where [Print Mgt_ Code] = 'S-ORDERS' and[Table ID] = 27 " +
                "and [Code 1] in (Select [Item No_] " + salesSelect + ") ";

            tableName = "NAVSalesText";

            makeTables();


            select =
                "SELECT " +
                " Code as Price_Group_Code " +
                ",[Description] as Price_Group_Description " +
                "FROM [ZYGO$Product Types]";

            tableName = "PriceGroups";

            makeTables();

            select =
                "SELECT " +
                "Code as Price_List_Code " +
                ",[Description] as Price_List_Description " +
                "FROM [ZYGO$Customer Price Group] " +
                "WHERE [Description] not like 'Obs%' ";
            
            tableName = "PriceListCodes";

            makeTables();

            /* set connection back to CT-MID-SQL01 PriceLists     */

            cnxn = new SqlConnection(g.db);

            try
            {
                cnxn.Open();
                SqlCommand cmd1 = new SqlCommand("spSalesText", cnxn);
                cmd1.CommandType = CommandType.StoredProcedure;
                
                int rowsReturned = cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            /*
            SqlDataAdapter Sda = new SqlDataAdapter
                ("select " +
                 "i.Item_Code " +
                 "from itemcodeclassnotes i " +
                 "left join itemtext t on " +
                 "i.item_code = t.item_code " +
                 "where sales_text is null order by item_code", cnxn);

            DataTable Stable = new DataTable();

            Sda.Fill(Stable);

            if (Stable.Rows.Count > 0)
            {
                bs.DataSource = Stable;
                DGV.DataSource = bs;
                DGV.Show();
                LselectDate.Text = "The items listed below require sales text.";
            }

            cnxn.Open();
            cmd = new SqlCommand("select item_code, sales_text from " +
                "itemtext", cnxn);

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
                    cnxn2 = new SqlConnection(g.db);
                    cnxn2.Open();
                    SqlCommand cmd2 = new SqlCommand(
                        "update itemtext set Sales_text " +
                        "= " + stxt + " where item_code = '" +
                        itemcode + "'", cnxn2);
                    cmd2.Parameters.Add(stxt);
                    int rows = cmd2.ExecuteNonQuery();
                    cnxn2.Close();
                    cmd2.Dispose();
                    flag = "no";
                }
            }
 
            //PriceList p1 = new PriceList();
            //p1.Show();
            */

            //f4_MakePriceList p2 = new f4_MakePriceList();
            //p2.Show();
        }

       
        private void makeTables()
        {
            cnxn = new SqlConnection(g.dbNAV);
            SqlCommand cmd = new SqlCommand(select, cnxn);
            SqlDataAdapter da = new SqlDataAdapter(select, cnxn);
            DataTable table = new DataTable();
            da.Fill(table);

            cnxn2 = new SqlConnection(g.db);

            cnxn2.Open();
            SqlBulkCopy copy = new SqlBulkCopy(cnxn2);
            copy.DestinationTableName = tableName;

            try
            {
                copy.WriteToServer(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn2.Close();
            }

        }

        private void f1_Effective_Date_Load(object sender, EventArgs e)
        {
           
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        


    }

    


}