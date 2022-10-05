using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Richmond
{
    public partial class M2Go : Form
    {
        private string tableLinks = "FROM[ZYGO$Sales Header] sh " +
                "INNER JOIN[ZYGO$Sales Line] sl on sh.[No_] = sl.[Document No_] " +
                "INNER JOIN[ZYGO$Sales Invoice Header] sih on sih.[Order No_] = sh.[No_] " +
                "INNER JOIN [ZYGO$Sales Invoice Line] sil on sih.[No_] = sil.[Document No_] and sil.[SO Line No_] = sl.[SO Line No_] " +
                "LEFT JOIN [ZYGO$Item] i on sil.No_ = i.No_ ";
        private object shipmentTotal;
        private int daysinShipments = 0;
        private string start;
        private string end;
        private decimal balanceToShip = 0;
        private decimal SixDayForecast = 0;
        private string endofmonth;
        private decimal balanceToShipDays = 0;
        //private start;

        public M2Go()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string dpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dpath = Path.Combine(dpath, "MonthToGo.csv");
            File.WriteAllText(dpath, "MTG \"Month To Go\" Month of " + DateTime.Now.ToString("MMMM") + Environment.NewLine + Environment.NewLine);
            File.AppendAllText(dpath, "Shipments Invoiced Month to Date" + Environment.NewLine);
            File.AppendAllText(dpath, "Description, Planner, ID, QTY, Unit Price, Total Price, Ship Date, " +
                "Orig Ship Date, PO, SO, Line #, Status" + Environment.NewLine);

            SqlConnection cnxn = new SqlConnection("server = PA-Hor-AS408.ametek.com; password = 2018#ameteK; " +
                                  "user = navdb_read; database = ZYGO-NAV-PROD;");

            SqlConnection cnxnAFE = new SqlConnection("server = CT-MID-SQL01; password = Read+Write!; " +
                                  "user = readWrite; database = AccessFrontends;");

            SqlCommand cmd = new SqlCommand(
                "SELECT " +
                "REPLACE(sil.Description, ',', ' ') " +                        //0
                ",LEFT(i.[Buyer Planner Code], 1) + RIGHT(i.[Buyer Planner Code], 1) [Planner] " +                //1
                ",'' " +                                  //2 
                ",CAST(FORMAT(sil.Quantity,'###') as varchar(3)) QTY" +                          //3
                ",sil.[Unit Price] " +                      //4
                ",sil.[Amount Including VAT] [Total Price] " +            //5
                ",CAST(FORMAT(sil.[Shipment Date], 'MM/dd/yy') as varchar(8)) " +                   //6
                ",CAST(FORMAT(sl.[Orig_ Promised Delivery Date], 'MM/dd/yy') as varchar(8)) [Orig Ship Date] " +     //7
                ",CAST(sh.[External Document No_] as varchar(30)) [PO]" +            //8
                ",CAST(sh.No_ as varchar(10)) [SO] " +                                //9
                ",CAST(sil.[SO Line No_] as varchar(4)) [Line #]" +                     //10
                ",'' " +                              //11
                tableLinks +
                "WHERE " +
                "sil.[Shipment Date] > DATEADD(d, 1, EOMONTH(DATEADD(m, -1, GETDATE()))) AND sil.[Shipment Date] < GETDATE() " +
                "AND sil.[Location Code] = 'RIC' " +
                "AND sil.Quantity > 0 " +
                "AND sil.[SO Line No_] < 500 " +
                "ORDER BY sil.[Shipment Date]", cnxn);

            cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            try
            {
                while (dr.Read())
                {

                    File.AppendAllText(dpath,
                        dr.GetString(0) + "," +
                        dr.GetString(1) + "," +
                        dr.GetString(2) + "," +
                        dr.GetString(3) + "," +
                        dr.GetDecimal(4) + "," +
                        dr.GetDecimal(5) + "," +
                        dr.GetString(6) + "," +
                        dr.GetString(7) + "," +
                        dr.GetString(8) + "," +
                        dr.GetString(9) + "," +
                        dr.GetString(10) + "," +
                        dr.GetString(11) + Environment.NewLine);

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            cmd = new SqlCommand(
                "SELECT " +
                "SUM(sil.[Amount Including VAT]) " +
                tableLinks +
                "WHERE " +
                "sil.[Shipment Date] > DATEADD(d, 1, EOMONTH(DATEADD(m, -1, GETDATE()))) AND sil.[Shipment Date] < GETDATE() " +
                "AND sil.[Location Code] = 'RIC' " +
                "AND sil.Quantity > 0 " +
                "AND sil.[SO Line No_] < 500 ", cnxn);
            try
            {
                cnxn.Open();
                shipmentTotal = cmd.ExecuteScalar();
                File.AppendAllText(dpath, ",,,,," + shipmentTotal.ToString() + Environment.NewLine);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            /*
             * 
             * Days in Shipments
             * 
             * */

            cmd = new SqlCommand(
                "SELECT " +
                "COALESCE(SUM(IsWorkDay),0) " +
                "FROM WorkDayCalendar " +
                "WHERE " +
                "dt > DATEADD(d, 1, EOMONTH(DATEADD(m, -1, GETDATE()))) AND dt < (GETDATE()-1) " 
                , cnxnAFE);
            try
            {
                cnxnAFE.Open();
                daysinShipments = (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxnAFE.Close();
            }

            /*
             *  Sales forecasts need to be broken up into weeks
             *  use WorkDayCalendar for this
             * */

            SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT dtWeek FROM WorkDayCalendar WHERE dtMonth = DATEPART(mm, GETDATE()) AND " +
                "IsWorkDay = 1 AND DATEPART(yy,dt) = DATEPART(yy,GETDATE()) AND dt > GETDATE() ORDER BY dtWeek", cnxnAFE);

            DataTable dt = new DataTable();

            try
            {
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxnAFE.Close();
            }


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmd = new SqlCommand("SELECT CAST(FORMAT(MIN(dt),'MM/dd/yy') as varchar(8)) FROM WorkDayCalendar WHERE dtWeek = " + dt.Rows[i][0].ToString() + " " +
                    "and IsWorkDay = 1 and DATEPART(yy, dt) = DATEPART(yy, GETDATE()) " +
                    "AND dtMonth =  DATEPART(mm, GETDATE()) and IsWorkDay = 1 and DATEPART(yy, dt) = DATEPART(yy, GETDATE())", cnxnAFE);

                // start

                try
                {
                    cnxnAFE.Open();
                    start = (string)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxnAFE.Close();
                }

                /*  end date    */

                cmd = new SqlCommand("SELECT CAST(FORMAT(MAX(dt),'MM/dd/yy') as varchar(8)) FROM WorkDayCalendar WHERE dtWeek = " + dt.Rows[i][0].ToString() + " " +
                    "and IsWorkDay = 1 and DATEPART(yy, dt) = DATEPART(yy, GETDATE()) " +
                    "AND dtMonth =  DATEPART(mm, GETDATE()) and IsWorkDay = 1 and DATEPART(yy, dt) = DATEPART(yy, GETDATE())", cnxnAFE);

                try
                {
                    cnxnAFE.Open();
                    end = (string)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxnAFE.Close();
                }

                File.AppendAllText(dpath, Environment.NewLine);
                File.AppendAllText(dpath, "Shipments for " + start + " - " + end + Environment.NewLine);
                File.AppendAllText(dpath, "Description, Planner, ID, QTY, Unit Price, Total Price, Ship Date, " +
                "Orig Ship Date, PO, SO, Line #, Status" + Environment.NewLine);

                cmd = new SqlCommand(
                    "SELECT " +
                    "REPLACE(sl.Description, ',', ' ') " +
                    ", COALESCE(LEFT(i.[Buyer Planner Code], 1) + RIGHT(i.[Buyer Planner Code], 1), 'No Planner') [Planner] " +
                    ",'' " +                                  
                    ",CAST(FORMAT(sl.[Outstanding Quantity],'###') as varchar(3)) " +
                    ", sl.[Unit Price] " +
                    ", sl.[Amount Including VAT] " +
                    ", CAST(FORMAT(sl.[Shipment Date], 'MM/dd/yy') as varchar(8)) " +
                    ", CAST(FORMAT(sl.[Orig_ Promised Delivery Date], 'MM/dd/yy') as varchar(8)) " +
                    ", CAST(sh.[External Document No_] as varchar(30)) " +
                    ", CAST(sh.No_ as varchar(10)) " +
                    ", RTRIM(CAST(sl.[SO Line No_] as varchar(4))) " +
                    ",'' " +
                    "FROM[ZYGO$Sales Line] sl " +
                    "INNER JOIN[ZYGO$Sales Header] sh ON sh.No_ = sl.[Document No_] " +
                    "LEFT JOIN[ZYGO$Item] i on sl.No_ = i.No_ " +
                    "WHERE " +
                    "sl.[Shipment Date] >= '" + start + "' AND sl.[Shipment Date] <= '" + end + "'" +
                    "AND sl.[Location Code] = 'RIC' " +
                    "AND sl.[SO Line No_] < 500 " +
                    "AND sl.[Outstanding Quantity] > 0 " +
                    "ORDER BY sl.[Shipment Date]"
                    , cnxn);

                cnxn.Open();
                dr = cmd.ExecuteReader();

                DataTable t = new DataTable();
                t.Load(dr);

                dr = cmd.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {

                        File.AppendAllText(dpath,
                            dr.GetString(0) + "," +
                            dr.GetString(1) + "," +
                            dr.GetString(2) + "," +
                            dr.GetString(3) + "," +
                            dr.GetDecimal(4) + "," +
                            dr.GetDecimal(5) + "," +
                            dr.GetString(6) + "," +
                            dr.GetString(7) + "," +
                            dr.GetString(8) + "," +
                            dr.GetString(9) + "," +
                            dr.GetString(10) +
                            Environment.NewLine);

                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }

                cmd = new SqlCommand(
                "SELECT " +
                "SUM(sl.[Amount Including VAT]) " +
                "FROM[ZYGO$Sales Line] sl " +
                "WHERE " +
                "sl.[Shipment Date] >= '" + start + "' AND sl.[Shipment Date] <= '" + end + "'"  +
                "AND sl.[Location Code] = 'RIC' " +
                "AND sl.[Outstanding Quantity] > 0 " +
                "AND sl.[SO Line No_] < 500 ", cnxn);
                try
                {
                    cnxn.Open();
                    decimal monthTotal = (decimal)cmd.ExecuteScalar();
                    File.AppendAllText(dpath, ",,,,," + monthTotal.ToString() + Environment.NewLine);
                    balanceToShip = balanceToShip + monthTotal;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }

                endofmonth = end;
            }

            /*
             * 
             * balance to ship days
             * 
             * */

            cmd = new SqlCommand("SELECT (SELECT dtIndex from workdaycalendar where dt = '" + endofmonth + "') " +
                " - (select dtindex from WorkDayCalendar where dt = CONVERT(varchar, GETDATE() - 1, 1))", cnxnAFE);

            try
            {
                cnxnAFE.Open();
                balanceToShipDays = Convert.ToDecimal(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxnAFE.Close();
            }

            /*
             * 
             * revenue next six days
             * 
             * */

            cmd = new SqlCommand("SELECT dt from workdaycalendar where dtIndex = CAST((Select dtindex from workdaycalendar where dt = CONVERT(varchar, GETDATE(), 1)) as int) + 6 ", cnxnAFE);

            try
            {
                cnxnAFE.Open();
                end = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxnAFE.Close();
            }

            cmd = new SqlCommand(
                "SELECT " +
                "SUM(sl.[Amount Including VAT]) " +
                "FROM[ZYGO$Sales Line] sl " +
                "WHERE " +
                "sl.[Shipment Date] >( GETDATE() - 1) AND sl.[Shipment Date] < '" + end + "'" +
                "AND sl.[Location Code] = 'RIC' " +
                "AND sl.[Outstanding Quantity] > 0 " +
                "AND sl.[SO Line No_] < 500 ", cnxn);
            try
            {
                cnxn.Open();
                SixDayForecast = (decimal)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            string space = ",,,,,,,,,,,";
                        
            File.AppendAllText(dpath, Environment.NewLine);
            File.AppendAllText(dpath, Environment.NewLine);
            File.AppendAllText(dpath, space + ", Total Invoiced " + DateTime.Now.ToString("MMMM") + Environment.NewLine);
            if (daysinShipments > 0)
            {
                File.AppendAllText(dpath, space + ", Total Shipped," + shipmentTotal + ", Daily Average, " + (Decimal.Round(((decimal)shipmentTotal / daysinShipments), 2)).ToString() + Environment.NewLine);
            }
            else
            {
                File.AppendAllText(dpath, space + ", Total Shipped," + shipmentTotal + ", Daily Average, Can't calculate - no complete days available " + Environment.NewLine);
            }
                File.AppendAllText(dpath, space + ", Revenue next 6 days," + SixDayForecast.ToString() + ", Daily Average, " + (Decimal.Round((SixDayForecast / 6), 2)).ToString() + Environment.NewLine);
            File.AppendAllText(dpath, space + ", Balance to ship for Month," + balanceToShip.ToString() + ", Daily Average, " + (Decimal.Round((balanceToShip / balanceToShipDays), 2)).ToString() + Environment.NewLine);
            File.AppendAllText(dpath, space + ", MONTHLY GOAL DATA, MONTHLY TARGET GOAL, $2000000" + Environment.NewLine);
            File.AppendAllText(dpath, space + ",, MONTHLY SHIPMENTS + FORECAST, " + ((decimal)shipmentTotal + balanceToShip).ToString() + Environment.NewLine);
            File.AppendAllText(dpath, space + ",,,DELTA, " + ((decimal)2000000 - ((decimal)shipmentTotal + balanceToShip)).ToString() + Environment.NewLine);

            
        }

        
    }
}
