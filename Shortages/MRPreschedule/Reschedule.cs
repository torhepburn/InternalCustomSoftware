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

namespace MRPreschedule
{
    public partial class Reschedule : Form
    {
        SqlDataReader dr;
        SqlDataReader dr1;
        private string reportCutoffDate = "2023-12-31";
        private int balance = 0;
        private int twoWeekUSE = 0;
        private decimal cost = 0;
        public Reschedule()
        {
            InitializeComponent();
        }

        private void Reschedule_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection("server = pa-hor-as408; password = 2018#ameteK; user = navdb_read; database = ZYGO-NAV-PROD;");
            SqlConnection cnxn1 = new SqlConnection("server = pa-hor-as408; password = 2018#ameteK; user = navdb_read; database = ZYGO-NAV-PROD;");
            SqlConnection cnxn2 = new SqlConnection("server = pa-hor-as408; password = 2018#ameteK; user = navdb_read; database = ZYGO-NAV-PROD;");
            SqlConnection cnxn11 = new SqlConnection("server = CT-MID-SQL11; password = Read+Write!; user = readWrite; database = AccessFrontEnds;");

            SqlCommand cmd10 = new SqlCommand("DELETE FROM MRPresched1", cnxn11);

            cnxn11.Open();

            cmd10.ExecuteNonQuery();

            cnxn11.Close();

            SqlCommand cmd = new SqlCommand(
                "select " +
                " No_ " +
                ",[Standard Cost] " +
                ", CASE " +
                "    WHEN EAU / 26 < 1 THEN 1 " +
                "    WHEN EAU / 26 > 0 THEN EAU / 26 " +
                "  END TwoWeekUSE " +
                "FROM [ZYGO$Item] " +
                "WHERE SIM IN (1, 2, 3) " +
                " AND No_ not like '%FAI%' " +
                " AND F6 != 0 " +
                " AND [Replenishment System] = 0 " +
                //"AND No_ = '6191-1132-02' " +
                "ORDER BY No_ ", cnxn);

            DataTable dt = new DataTable();

            cnxn.Open();
            dr = cmd.ExecuteReader();

            dt.Load(dr);

            dr = cmd.ExecuteReader();



            while (dr.Read())
            {
                cost = dr.GetDecimal(1);
                twoWeekUSE = dr.GetInt32(2);



                SqlCommand cmd2 = new SqlCommand(
                    "SELECT SUM(Quantity) FROM [ZYGO$Warehouse Entry] " +
                    "WHERE [Location Code] not like '%MRB%' " +
                    "AND [Location Code] not like '%SVC%' " +
                    "AND [Item No_] = '" + dr.GetString(0) + "'", cnxn2);
                try
                {
                    cnxn2.Open();
                    object o = cmd2.ExecuteScalar();

                    balance = Convert.ToInt32(o);

                    File.WriteAllText(@"C:\A\debug.txt", balance.ToString() + "    Opening Balance" + Environment.NewLine);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn2.Close();
                }

                SqlCommand xcmd1 = new SqlCommand(
                    "SELECT " +
                    "[Document No_] [Document]" +
                    ", CASE l.[Document Type] " +
                    "	WHEN 1 THEN [Outstanding Quantity] " +
                    "	WHEN 5 THEN [Outstanding Quantity] * -1 " +
                    "END [Quantity] " +
                    ", l.[Expected Receipt Date] [DueDate] " +
                    ",[PO Line No_] [POlineNo]" +

                    ",[Purchaser Code] [Buyer] " +
                    ",[Pay-to Name] [Vendor]" +

                    "FROM [ZYGO$Purchase Line] l " +

                    "INNER JOIN [ZYGO$Purchase Header] h on l.[Document No_] = h.No_ " +

                    "WHERE l.No_ = '" + dr.GetString(0) + "'" +

                    "AND[Outstanding Quantity] > 0 " +

                    //"AND l.[Expected Receipt Date] <= '" + reportCutoffDate  + "'" +

                    "AND[Document No_] NOT LIKE 'KB%' " +

                    "AND[Document No_] NOT LIKE 'R%' " +

                    "UNION ALL " +

                    "select " +

                    "[Prod_ Order No_][Document No_] " +
                    ",[Remaining Quantity] * -1 Quantity " +
                    ",[Due Date] " +
                    ", 0 " +
                    ", '' " +
                    ", '' " +

                    "from [ZYGO$Prod_ Order Component] " +

                    "where " +

                    "Status IN(2, 3) " +

                    "AND[Item No_] = '" + dr.GetString(0) + "'" +

                    "AND[Remaining Quantity] > 0 " +

                //"AND[Due Date] <= '" + reportCutoffDate + "'" +

                "UNION ALL " +
                    /*	Jobs  minus  */

                    "select " +

                    "[Document No_] " +
                    ", Quantity * (-1) Quantity " +
                    ",[Due Date] " +
                    ", 0 " +
                    ", '' " +
                    ", '' " +

                    "FROM [ZYGO$Job Journal Line] " +

                    "WHERE No_ = '" + dr.GetString(0) + "'" +

                    "AND[Journal Template Name] = 'INVREQ' " +

                //"AND[Due Date] <= '" + reportCutoffDate + "'" +

                "UNION ALL " +
                    /*	sales minus	*/

                    "select " +

                    "[Document No_] " +
                    ",[Outstanding Quantity] * (-1) [Quantity] " +
                    ",[Shipment Date] [Due Date] " +
                    ", 0 " +
                    ", '' " +
                    ", '' " +

                    "from " +

                    "[ZYGO$Sales Line] " +

                    "WHERE 1 = 1 " +

                    "	AND [Outstanding Quantity] > 0 " +

                    //"	AND [Shipment Date] <= '" + reportCutoffDate + "'" +

                    "	AND No_ = '" + dr.GetString(0) + "'" +

                "UNION ALL " +

                /*	planned forecast  minus	*/

                "	SELECT " +


                "	'Planning' " +
                    ",[Expected Quantity] * (-1) Quantity " +
                    ",[Due Date] " +
                    ", 0 " +
                    ", '' " +
                    ", '' " +

                "	from[ZYGO$Planning Component] " +

                "	WHERE[Item No_] = '" + dr.GetString(0) + "'" +

                //"	AND[Due Date] <= '" + reportCutoffDate + "'" +

                "UNION ALL " +   /*	MRP	*/


                "	select " +


                "	CASE [Action Message] " +
                "            WHEN 1 THEN 'MRP Add' " +
                "            WHEN 3 THEN 'MRP Resched IN ' + COALESCE([Ref_ Order No_],'') " +
                "        END " +
                    ", Quantity " +
                    ",[Due Date] " +
                    ",COALESCE([Ref_ Line No_]/1000,0) " +
                    ",COALESCE([Buyer Planner Code],'') " +
                    ",COALESCE(v.Name,'') " +

                "	from[ZYGO$Requisition Line] r " +


                "	LEFT JOIN ZYGO$Vendor v ON r.[Supply From] = v.No_ " +

                "	WHERE " +

                "	[Worksheet Template Name] = 'PLANNING' " +

                "	AND[Journal Batch Name] = 'DEFAULT' " +

                "	AND r.[No_] = '" + dr.GetString(0) + "'" +

                "	AND[Action Message] IN (1,3) " +

                // //"	AND[Due Date] <= '" + reportCutoffDate + "'" +

                "UNION ALL " +   /*	MRP	Resched*/


                "	select " +

                "CASE " +
                "  WHEN LEN(COALESCE([Ref_ Order No_],'')) > 0 THEN 'MRP Resched Remove ' + COALESCE([Ref_ Order No_],'') " +
                "  ELSE 'MRP RESCHEDULE' " +
                    "END" +
                    ", Quantity * -1 " +
                    ",COALESCE([Original Due Date],'1900-01-01') " +
                    ",COALESCe([Ref_ Line No_] / 1000,0) " +
                    ",COALESCE([Buyer Planner Code],'') " +
                    ",COALESCE(v.Name,'') " +

                "	from[ZYGO$Requisition Line] r " +


                "	LEFT JOIN ZYGO$Vendor v ON r.[Supply From] = v.No_ " +

                "	WHERE " +

                "	[Worksheet Template Name] = 'PLANNING' " +

                "	AND[Journal Batch Name] = 'DEFAULT' " +

                "	AND r.[No_] = '" + dr.GetString(0) + "'" +

                "	AND[Action Message] = 3 " +

                ////"	AND[Due Date] <= '" + reportCutoffDate + "'" +

                "	ORDER BY [DueDate],[Document No_],[POlineNo]"
                , cnxn1);

                DataTable dtSupply = new DataTable();
                dtSupply.Columns.Add("Document", typeof(string));
                dtSupply.Columns.Add("Quantity", typeof(int));
                dtSupply.Columns.Add("DueDate", typeof(DateTime));
                dtSupply.Columns.Add("POLine", typeof(int));
                dtSupply.Columns.Add("Buyer", typeof(string));
                dtSupply.Columns.Add("Vendor", typeof(string));
                dtSupply.Columns.Add("rescheduleDate", typeof(DateTime));

                DataTable dt1 = new DataTable();

                string item = dr.GetString(0);

                try
                {
                    cnxn1.Open();
                    dr1 = xcmd1.ExecuteReader();

                    dt1.Load(dr1);

                    dr1 = xcmd1.ExecuteReader();

                    while (dr1.Read())
                    {
                        //File.AppendAllText(@"C:\A\debug.txt","                              " + dr1.GetDateTime(2).ToShortDateString() + "    " + dr1.GetString(0) + "    " + dr1.GetDecimal(1).ToString() + Environment.NewLine);
                        /* if supply */
                        if (dr1.GetDecimal(1) > 0)
                        {
                            //if (dr1.GetString(0) == "K006941" & dr1.GetInt32(3) == 20)
                            //{
                            //    string ten = "stop";
                            //}
                            if (balance <= twoWeekUSE)      /*  if balance is less than two weeks use then add the supply to the balance   */
                            {
                                balance += Convert.ToInt32(dr1.GetDecimal(1));
                                File.AppendAllText(@"C:\A\debug.txt", balance.ToString() + "    " + dr1.GetDateTime(2).ToShortDateString() + "    " + dr1.GetString(0) + "    " + dr1.GetDecimal(1).ToString() + Environment.NewLine);
                            }
                            else      /*  if balance is greater than two weeks use then add the order to the reserve supply table   */
                            {
                                string atest = dr1.GetString(0);
                                decimal btest = dr1.GetDecimal(1);
                                string ctest = dr1.GetDateTime(2).ToShortDateString();
                                int dtest = dr1.GetInt32(3);
                                string etest = dr1.GetString(4);
                                string ftest = dr1.GetString(5);
                                dtSupply.Rows.Add(
                                dr1.GetString(0)
                                , Convert.ToInt32(dr1.GetDecimal(1))
                                , dr1.GetDateTime(2)
                                , dr1.GetInt32(3)
                                , dr1.GetString(4)
                                , dr1.GetString(5)
                                , dr1.GetDateTime(2)
                                );
                            }
                            //}
                        }
                        else     /*  if demand  */
                        {
                            if (balance <= twoWeekUSE)
                            {
                                int s = dt1.Rows.Count;
                                //int t = dt1.Rows.IndexOf(row);
                                int r = dtSupply.Rows.Count;

                                if (r > 0)
                                {
                                    cmd10 = new SqlCommand(
                                        "Insert into MRPresched1 (" +
                                        "Item " +
                                        ",Document " +
                                        ",POLine " +
                                        ",Quantity " +
                                        ",DueDate " +
                                        ",rescheduleDate " +
                                        ",Buyer " +
                                        ",Vendor " +
                                        ",[Value] " +
                                        ",TwoWeekUSE " +
                                        ") " +
                                        "values ('" +
                                         dr.GetString(0) + "','" +
                                         dtSupply.Rows[0][0].ToString() + "','" +
                                         dtSupply.Rows[0][3].ToString() + "','" +
                                         dtSupply.Rows[0][1].ToString() + "','" +
                                         dtSupply.Rows[0][2].ToString() + "','" +
                                         dr1.GetDateTime(2).ToShortDateString() + "','" +
                                         dtSupply.Rows[0][4].ToString() + "','" +
                                         dtSupply.Rows[0][5].ToString().Replace(",", " ") + "','" +
                                         (Convert.ToDouble(dtSupply.Rows[0][1].ToString()) * Convert.ToDouble(dr.GetDecimal(1))).ToString() + "','" +
                                         twoWeekUSE.ToString()
                                         + "')"
                                         , cnxn11
                                        );
                                    File.AppendAllText(@"C:\A\debug.txt", " Push out to " + dr1.GetDateTime(2).ToShortDateString() + "    " + dtSupply.Rows[0][0].ToString() + "    " + dtSupply.Rows[0][1].ToString() + "    " + dtSupply.Rows[0][2].ToString() + Environment.NewLine);
                                    try
                                    {
                                        cnxn11.Open();
                                        int a = cmd10.ExecuteNonQuery();
                                    }
                                    catch (SqlException ex)
                                    {

                                        MessageBox.Show(ex.Message);
                                    }
                                    finally
                                    {
                                        cnxn11.Close();
                                    }

                                    balance += Convert.ToInt32(dtSupply.Rows[0][1].ToString());
                                    File.AppendAllText(@"C:\A\debug.txt", balance.ToString() + "    " + dr1.GetDateTime(2).ToShortDateString() + "    " + dr1.GetString(0) + "    " + dr1.GetDecimal(1).ToString() + Environment.NewLine);
                                    dtSupply.Rows.RemoveAt(0);
                                }
                                else
                                {
                                    balance += Convert.ToInt32(dr1.GetDecimal(1));
                                    File.AppendAllText(@"C:\A\debug.txt", balance.ToString() + "    " + dr1.GetDateTime(2).ToShortDateString() + "    " + dr1.GetString(0) + "    " + dr1.GetDecimal(1).ToString() + Environment.NewLine);
                                }

                            }
                            else
                            {
                                balance += Convert.ToInt32(dr1.GetDecimal(1));
                                File.AppendAllText(@"C:\A\debug.txt", balance.ToString() + "    " + dr1.GetDateTime(2).ToShortDateString() + "    " + dr1.GetString(0) + "    " + dr1.GetDecimal(1).ToString() + Environment.NewLine);
                            }
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
            } //end of dr.Read()

            cmd10 = new SqlCommand("Select * FROM MRPresched1 " +
                "where document not like 'PRIR%' " +
                "AND YEAR(DueDate) = '2022' " +
                "AND MONTH(DueDate) <> MONTH(RescheduleDate) " +
                "ORDER BY Item, DueDate"
                , cnxn11);

            cnxn11.Open();

            SqlDataReader drT = cmd10.ExecuteReader();
            DataTable dtt = new DataTable();

            dtt.Load(drT);

            //DataGridView dgv = new DataGridView();
            DGV.DataSource = dtt;

            cnxn11.Close();

            DGV.Show();

            // this.Close();
        }


    }

}
