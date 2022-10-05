using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace s1_NAVPriceList
{
    public partial class s1NAV : Form
    {
        public s1NAV()
        {
            InitializeComponent();
        }

        private void s1NAV_Load(object sender, EventArgs e)
        {
            SqlConnection cnxnAFS = new SqlConnection("server = CT-MID-SQL11; password = Read+Write!; user = readwrite; " +
                                  "database = pricelists;");
            SqlConnection cnxnNAV = new SqlConnection("server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
                            "user = navdb_read; database = zygo-nav-prod;");


            SqlCommand cmd = new SqlCommand(
                "CREATE TABLE #ItemText " +
                "( " +
                " [ItemNo] nvarchar(20) " +
                ",[Text] nvarchar(300) " +
                ") " +

                "CREATE TABLE #Temp " +
                "( " +
                " [ItemNo] nvarchar(20) " +
                ",[LineNo] int " +
                ",[Text] nvarchar(100) " +
                ") " +

                "INSERT INTO #Temp " +

                "( " +
                "  [ItemNo] " +
                " , [LineNo] " +
                " , [Text] " +
                ") " +

                "SELECT " +
                "[Code 1] as [itemNo] " +
                ",[Line No_] as [LineNo] " +
                ",[Text] [SalesText] " +
                " from[ZYGO$Text Module Line] " +
                "where[Print Mgt_ Code] = 'S-ORDERS' " +
                "and[Table ID] = 27 " +
                "and[Code 1] in " +
                "(Select DISTINCT[Item No_] " +
                "FROM[ZYGO$Sales Price] s " +
                "INNER JOIN ZYGO$Item i on " +
                "s.[Item No_] = i.[No_] " +
                "where " +
                "[Sales Code] = 'DOM' AND " +
                "[Signal Code] NOT LIKE 'OBS%' and " +
                "[Starting Date] > '02-06-1995' and " +
                "[Starting Date] <= GETDATE() and " +
                "([Ending Date] >= GETDATE() OR " +
                "[Ending Date] is null)) " +


                "declare @item varchar(30) " +
                "declare @line int " +
                "declare @text varchar(100) " +
                "declare @salesText varchar(300) " +
                "declare @tt varchar(4000) " +

                "SET @salesText = '' " +

                "declare itemCursor Cursor for " +

                "select distinct[itemNo] FROM #Temp " +
                "order by[itemNo] " +

                "open itemCursor " +

                "fetch next from itemCursor into @item " +

                "while @@FETCH_STATUS = 0 " +

                "begin " +
                "declare textCursor Cursor for " +
                "SELECT[Text] FROM #Temp WHERE itemNo = @item " +
                "ORDER BY[LineNo] " +

                "OPEN textCursor " +
                "fetch next from textCursor into @text " +
                "while @@FETCH_STATUS = 0 " +
                "begin " +
                "    SET @salesText = @salesText + @text " +
                "fetch next from textCursor into @text " +
                "end " +
                "close textCursor " +
                "deallocate textCursor " +

                "Insert into #ItemText (ItemNo, [Text])  " +
                "EXEC sp_executesql " +
                "N'SELECT @item_p, @text_p', " +
                "N'@item_p varchar(30), @text_p varchar(300)', " +
                "@item, @salesText; " +

                "            SET @salesText = '' " +

                "fetch next from itemCursor into @item " +
                "end " +
                "close itemCursor " +
                "deallocate itemCursor; " +

                "            DROP TABLE #Temp;" +

                "select " +
                "LEFT(i.[Global Dimension 2 Code], 3) " +
                ",sp1.[Sales Code] " +
                ",[Price List ID] [Folder] " +
                ",i.No_[Item Number] " +
                ",i.[Price List Code] " +
                ",[Price List Description] " +
                ",COALESCE([Text],'') [Text] " +
                ",FORMAT(CAST(sp2.[Unit Price] as int), 'C0')[ZAF Price] " +
                ",FORMAT(CAST(sp1.[Unit Price] as int), 'C0')[Unit Price] " +
                ",FORMAT(CAST(i.[Standard Cost] as int), 'C0')[Standard Cost] " +
                "FROM[ZYGO$Item] i " +
                "INNER JOIN[ZYGO$Sales Price] sp1 on sp1.[Item No_] = i.No_ " +
                "INNER JOIN[ZYGO$Sales Price] sp2 on sp2.[Item No_] = i.No_ " +
                "INNER JOIN[ZYGO$Customer Price Group] p ON sp1.[Sales Code] = p.Code " +
                "INNER JOIN[ZYGO$Price List Data] d ON i.[Price List Code] = d.[Price List Code] " +
                "LEFT JOIN #ItemText t ON i.No_ = t.ItemNo COLLATE DATABASE_DEFAULT " +
                "where 1 = 1 " +
                "AND LEN(i.[Price List Code]) > 0 " +
                "AND sp1.[Sales Code] IN('DOM', 'EXP', 'INT') " +
                "AND(sp1.[Ending Date] >= GETDATE() OR sp1.[Ending Date] IS NULL) " +
                "AND sp1.[Starting Date] <= GETDATE() " +
                "AND sp2.[Sales Code] IN('ZAF') " +
                "AND(sp2.[Ending Date] >= GETDATE() OR sp2.[Ending Date] IS NULL) " +
                "AND sp2.[Starting Date] <= GETDATE() " +
                "AND LEFT(i.[Global Dimension 2 Code],3) IN('OPT', 'LAS', 'PPS') " +
                "ORDER BY sp1.[Sales Code], i.[Price List Code], No_ ", cnxnNAV);

            SqlDataReader dr;

            try
            {
                cnxnNAV.Open();
                dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(dr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxnNAV.Close();
            }




        }
    }
}
