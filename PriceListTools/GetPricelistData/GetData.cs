using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GetPricelistData
{
    public partial class GetData : Form
    {
        private string effectiveDate;
        private string select;
        private string tableName;
        SqlConnection cnxn;
        BindingSource bs = new BindingSource();
        SqlConnection cnxn2;

        public GetData()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            LselectDate.Text = "Working";

            cnxn = new SqlConnection(g.db);
            SqlCommand cmd = new SqlCommand
                ("delete from PriceList_s1; " +
                 "delete from PriceListSalesText_s1; " +
                 "delete from itemText; "
                 , cnxn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();


            effectiveDate = monthCalendar1.SelectionStart.ToString("MM-dd-yyyy");
            monthCalendar1.Hide();


            //tableName = "PriceList_s1";

            //MakeTables();

            select =
                "with s1 AS " +
                "( " +
                " SELECT " +
                " [Item No_] " +
                ",[Unit Price] " +
                " FROM[ZYGO$Sales Price] " +
                " WHERE " +
                " [Sales Code] IN('ZAF') " +
                " AND ([Ending Date] >= '" + effectiveDate + "' OR [Ending Date] IS NULL) " +
                " AND [Starting Date] <= '" + effectiveDate + "' " +
                ") " +
                " SELECT " +
                " sp1.[Sales Code] " +
                " ,i.[No_] [Item Number] " +
                " ,i.[Price List Code] " +
                " ,[Price List Description] " +
                " ,COALESCE(CAST(s1.[Unit Price] as int),0) [ZAF Price] " +
                " ,CAST(sp1.[Unit Price] as int) [Unit Price] " +
                " ,CASE " +
                "   WHEN [Global Dimension 2 Code] LIKE 'LASER%' THEN 'Large Aperture Systems' " +
                "   WHEN [Global Dimension 2 Code] = 'CMS LI' THEN 'Large Aperture Systems' " +
                "   WHEN [Global Dimension 2 Code] LIKE 'OPT P%' THEN 'Optical Profilers' " +
                "   WHEN [Global Dimension 2 Code] = 'CMS OP' THEN 'Optical Profilers' " +
                "   WHEN [Global Dimension 2 Code] LIKE 'PPS%' THEN 'Motion Measurement Products' " +
                " END sales_price_group " +
                ",'" + effectiveDate + "' " +
                " FROM [ZYGO$Item] i " +
                " INNER JOIN [ZYGO$Sales Price] sp1 on sp1.[Item No_] = i.No_ " +
                " LEFT JOIN s1 on s1.[Item No_] = i.No_ " +
                " INNER JOIN[ZYGO$Customer Price Group] p ON sp1.[Sales Code] = p.Code " +
                " INNER JOIN[ZYGO$Price List Data] d ON i.[Price List Code] = d.[Price List Code] " +
                " WHERE [Signal Code] not like 'OBS%' " +
                " AND LEN(i.[Price List Code]) > 0 " +
                " AND sp1.[Sales Code] IN('DOM', 'EXP', 'INT','EUR','ZCV','ZJV', 'ZKK', 'DIS') " +
                " AND(sp1.[Ending Date] >= '" + effectiveDate + "' OR sp1.[Ending Date] IS NULL) " +
                " AND sp1.[Starting Date] <= '" + effectiveDate + "' ";

            tableName = "PriceList_s1";

            MakeTables();


            select =
                "SELECT " +
                "[Code 1] as [item_code] " +
                ",[Line No_] as [LineNo] " +
                ",[Text] [Sales_Text] " +
                "from [ZYGO$Text Module Line] " +
                "where [Print Mgt_ Code] = 'S-ORDERS' " +
                "and[Table ID] = 27 " +
                "and [Code 1] in (Select [Item No_] " +
                "FROM [ZYGO$Sales Price] s " +
                "INNER JOIN ZYGO$Item i on " +
                "s.[Item No_] = i.[No_] " +
                "where " +
                "[Signal Code] NOT LIKE 'OBS%' and " +
                "[Starting Date] > '02-06-1995' and " +
                "[Starting Date] <= '" + effectiveDate + "' and " +
                "([Ending Date] >=  '" + effectiveDate + "' OR " +
                " [Ending Date] is null))";

            

            tableName = "PriceListSalesText_s1";
            
            MakeTables();

            /* set connection back to CT-MID-SQL01 PriceLists     */

            cnxn = new SqlConnection(g.db);

            /*  spSalesText gets all text in one field as opposed to different lines of text */

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


            try
            {
                cnxn.Open();
                SqlCommand cmd1 = new SqlCommand("TRUNCATE TABLE FULLPRICELIST", cnxn);
                
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

            try
            {
                cnxn.Open();
                SqlCommand cmd1 = new SqlCommand("spFullPriceList", cnxn);
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


            this.Close();

        }

        private void MakeTables()
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

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetData_Load(object sender, EventArgs e)
        {
            this.Text = "Update Price List Data v" + Application.ProductVersion;
        }
    }

    public static class g
    {
        public static string db = "server = CT-MID-SQL11; password = Read+Write!; user = readwrite; " +
                                  "database = pricelists;";
        public static string dbNAV = "server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
                            "user = navdb_read; database = zygo-nav-prod;";
        
    }
}
