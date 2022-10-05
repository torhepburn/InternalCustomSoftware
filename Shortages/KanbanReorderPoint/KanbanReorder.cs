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
using System.IO;
using System.Drawing.Printing;

namespace KanbanReorderPoint
{
    public partial class KanbanReorder : Form
    {
        private int KBopen;
        private int KBcalculated;
        private int POquantity;
        private string KBreorder;
        private string itemNumber;
        private int leadTime;
        private bool printed = false;

        public KanbanReorder()
        {
            InitializeComponent();
        }

        private void KanbanReorder_Load(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\A\KanbanTest.csv", "itemNumber,RunoutDate,leadTime,Remaining on Blanket,KBreorder Date " + Environment.NewLine);

            SqlConnection cnxn1 = new SqlConnection("server=pa-hor-as408.ametek.com; password=2018#ameteK; " +
                                        "user=navdb_read; database=ZYGO-NAV-PROD;");

            SqlConnection cnxn2 = new SqlConnection("server=pa-hor-as408.ametek.com; password=2018#ameteK; " +
                                        "user=navdb_read; database=ZYGO-NAV-PROD;");


            SqlCommand cmd = new SqlCommand(
                "WITH s1 AS " +
                "( " +
                "SELECT " +
                "No_ " +
                ", COALESCE(CONVERT(int, CASE " +
                "     WHEN CHARINDEX(CHAR(3), [Lead Time Calculation]) > 0 THEN REPLACE([Lead Time Calculation], CHAR(3), '') " +
                "     END), 0) LeadTime " +
                "FROM ZYGO$Item " +
                "WHERE " +
                "[Selection Code] = 'KBP' " +
                ")" +
                "SELECT " +
                "i.No_" +
                ",LeadTime " +
                "FROM ZYGO$Item i " +
                "LEFT JOIN s1 ON i.No_ = s1.No_ " +
                "WHERE " +
                "[Selection Code] = 'KBP' " +
                "AND CHARINDEX('X', i.No_, 1) = 0" +
                "AND s1.LeadTime < 130 " +
                "AND i.No_ NOT LIKE '%FAI' " +
                "ORDER BY i.No_"
                , cnxn1);

            SqlDataReader dr1;

            try
            {
                cnxn1.Open();
                dr1 = cmd.ExecuteReader();

                while (dr1.Read())
                {
                    itemNumber = dr1.GetString(0);
                    //itemNumber = "1046-480-055";
                    /*  leadtime from NAV is in work days    */
                    leadTime = dr1.GetInt32(1);
                    //leadTime = 30;
                    /*  convert leadtime to days - add back weekends for full weeks -    
                        then add two weeks lead time
                     */
                    leadTime = leadTime + ((leadTime / 5) * 2) + 14;


                    cmd = new SqlCommand("SELECT CONVERT(int, COALESCE(SUM([Outstanding Quantity]),0)) FROM " +
                        "[ZYGO$Purchase Line] WHERE No_ = '" + itemNumber + "' AND [Document Type] = 4", cnxn2);

                    try
                    {
                        cnxn2.Open();
                        object o = cmd.ExecuteScalar();
                        if (o != null)
                        {
                            KBopen = (int)cmd.ExecuteScalar();
                            KBcalculated = KBopen;
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn2.Close();
                    }

                    cmd = new SqlCommand("SELECT CONVERT(int, Quantity), DATEADD(dd, -" + leadTime + ",[Due Date]), [Due Date] FROM [ZYGO$Requisition Line] " +
                        "WHERE No_ = '" + itemNumber + "' AND [Due Date] < '01-01-2030' ORDER BY [Due Date]", cnxn2);

                    SqlDataReader dr;

                    try
                    {
                        cnxn2.Open();
                        dr = cmd.ExecuteReader();

                        DataTable dtt = new DataTable();
                        dtt.Load(dr);

                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            POquantity = dr.GetInt32(0);


                            if (KBcalculated - POquantity > 0)
                            {
                                KBcalculated = KBcalculated - POquantity;
                            }
                            else
                            {
                                if (printed)
                                {

                                }
                                else
                                {
                                    KBreorder = dr.GetDateTime(1).ToShortDateString();
                                    string RunoutDate = dr.GetDateTime(2).ToShortDateString();
                                    File.AppendAllText(@"C:\A\KanbanTest.csv", itemNumber + "," + RunoutDate + "," + leadTime.ToString() + "," + KBopen.ToString() +"," + KBreorder +  Environment.NewLine);
                                    printed = true;
                                }
                            }
                        }

                        printed = false;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn2.Close();
                    }

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn1.Close();
            }



        }
    }
}
