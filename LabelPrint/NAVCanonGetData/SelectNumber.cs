using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Data.SqlClient;
using System.Diagnostics;


namespace NAVCanonGetData
{
    public partial class SelectNumber : Form
    {
        SqlConnection cnxnNAV = new SqlConnection(g.dbNAV);
        SqlConnection cnxnAFE = new SqlConnection(g.db);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable table;
        //SqlDataReader dr;
        private int multiplier;
        private int position;
        private string SQL1 = "SELECT '     ' + [Document No_] + '              ' + " +
            "CONVERT(varchar, [Planned Shipment Date], 1) " +
            "'SO #    Planned Ship Date' " +
            ",[Document No_] " +
            ",CONVERT(varchar, [Planned Shipment Date], 1)" +
            ",H.[Sell-to Customer No_] " +
            "FROM [" + g.NAVprefix + "Sales Line] L INNER JOIN " +
            "[" + g.NAVprefix + "Sales Header] H ON L.[Document No_] = " +
            "H.No_ WHERE H.[Special Labelling] = 'L001' AND " +
            "(H.[Sell-to Customer No_] IN ('9999AJ', 'C00026') ) " +
            "AND L.[Outstanding Quantity] > 0"
            ;

        private string Canon = " ";

        public SelectNumber()
        {
            InitializeComponent();
        }

        private void SelectNumber_Load(object sender, EventArgs e)
        {
            this.Text = "NAV Canon Label Print Program v" + Application.ProductVersion.Trim();

            /*
             * small local table to capture all the canon part numbers in a string to use
             * in the SQL statement WHERE query.
             * 
             * */

            DataTable table1 = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter
                ("SELECT DISTINCT zygo_pn from Labels.ZygoAmetekCanonMappings ", cnxnAFE);

            sda.Fill(table1);

            for (int i = 0; i < table1.Rows.Count; i++)
            {
                if (i == 0)
                {
                    Canon = Canon + "'" + table1.Rows[i][0].ToString();
                }

                Canon = Canon + "', '" + table1.Rows[i][0].ToString();
            }

            gridData();
        }

        private void gridData()
        {
            // get Canon Sales numbers from Horsham for selection list

            try
            {
                cnxnNAV.Open();
                da = new SqlDataAdapter(SQL1 +
                    "AND L.No_ IN (" + Canon + "') " +
                "GROUP BY L.[Document No_], L.[Planned Shipment Date]" +
                ",H.[Sell-to Customer No_] " +
                "ORDER BY L.[Planned Shipment Date] ", cnxnNAV);
                table = new DataTable();
                da.Fill(table);
                cnxnNAV.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DGV.DataSource = table;
            DGV.Show();
            DGV.Columns[0].Width = 220;
            DGV.Columns[1].Visible = false;
            DGV.Columns[2].Visible = false;
            DGV.Columns[3].Visible = false;
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.SONumber = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.shipmentDate = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                g.customer = cell.EditedFormattedValue.ToString().Trim();

                g.orderplusdate = "order_no = '" + g.SONumber + "' " +
                "AND plannedshipmentdate = '" + g.shipmentDate + "' ";

                //checkFirstUse();
                try
                {
                    cmd = new SqlCommand(
                   "select ID from labels.CanonLabels " +
                   "where " + g.orderplusdate
                   , cnxnAFE);

                    cnxnAFE.Open();
                    object o = cmd.ExecuteScalar();
                    /*  find this*/
                    //MessageBox.Show("This order was previously retrieved.  Using previous data.");
                    //g.alreadyUsed = true;

                    if (o != null)
                    {
                        var result = MessageBox.Show("This order was previously retrieved.  Using previous data.", "Do you want to use this data ?", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            g.alreadyUsed = true;
                        }
                        else
                        {
                            g.alreadyUsed = false;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxnAFE.Close();
                }

                if (g.alreadyUsed != true)
                {
                    try
                    {
                        cmd = new SqlCommand(
                            "SELECT DISTINCT" +
                            " H.No_ " +
                            ",H.[Sell-to Customer No_] Customer " +
                            ",[Special Labelling] " +
                            ",[External Document No_] + '~' + [End User Customer Name] Customer_PO " +
                            ", CASE " +
                            "    WHEN [End User Customer Name] LIKE '%AMI%' THEN 'AMI' " +
                            "    WHEN [End User Customer Name] LIKE '%Uts%' THEN 'Utsunomiya' " +
                            "    WHEN [End User Customer Name] LIKE '%Semi%' THEN 'Semiconductor' " +
                            "    ELSE 'Generic' " +
                            "  END Canon_Subsidiary " +
                            ",[SO Line No_] POSITION " +
                            ",ISNULL([Serial No_],'') SRNO " +
                            ", L.No_ ITEM_CODE " +
                            ", L.Quantity ORDERED_QUANTITY " +
                            "FROM " +
                            "[" + g.NAVprefix + "Sales Line] L LEFT JOIN [" + g.NAVprefix + "Reservation Entry] r " +
                            "on r.[Source ID] = L.[Document No_] AND r.[Source Ref_ No_] = L.[Line No_] " +
                            "INNER JOIN [" + g.NAVprefix + "Sales Header] H on L.[Document No_] = H.No_ " +
                            "WHERE " +
                            " H.[Sell-to Customer No_] IN('1008JS', '9999AJ', 'C00026') " +
                            " AND[Special Labelling] = 'L001' AND L.No_ NOT LIKE 'FR%' " +
                            " AND L.[Planned Delivery Date] = '" + g.shipmentDate + "' " +
                            " AND L.[Document No_] = '" + g.SONumber + "' ", cnxnNAV);
                        cnxnNAV.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            try
                            {
                                cmd = new SqlCommand(
                                    "insert into labels.canonlabels (" +
                                    " ORDER_NO " +
                                    ",POSITION " +
                                    ",SRNO " +
                                    ",CUSTOMER " +
                                    ",ITEM_CODE " +
                                    ",DELIVERED_QUANTITY " +
                                    ",[ROUTE] " +
                                    ",Barcode " +
                                    ",Serialized " +
                                    ",CUSTOMER_PO " +
                                    ",Canon_Subsidiary " +
                                    ",PlannedShipmentDate) " +
                                    "values (" +
                                    "'" + dr.GetString(0) + "', " +
                                    dr.GetInt32(5) + ", " +
                                    "'" + dr.GetString(6) + "', " +
                                    "'" + dr.GetString(1) + "', " +
                                    "'" + dr.GetString(7) + "', " +
                                    dr.GetDecimal(8) + ", " +
                                    "'" + dr.GetString(2) + "', " +
                                    "1, " +
                                    "1, " +                 //the serialized field gives the number of the line and is not what
                                    "'" + dr.GetString(3) + "', " +     // determines whether or not the item is serialized
                                    "'" + dr.GetString(4) + "', " +
                                    "'" + g.shipmentDate + "' )"
                                    , cnxnAFE);
                                cnxnAFE.Open();
                                cmd.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            finally
                            {
                                cnxnAFE.Close();
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxnNAV.Close();
                    }

                    // only labels in ZygoAmetekCanonMapping get barcodes
                    // the difference between old and new is the name of the mapping table

                    try
                    {
                        cmd = new SqlCommand(
                            "UPDATE labels.CanonLabels set barcode = 0 " +
                            "from labels.CanonLabels l " +
                            "left join labels.ZygoAmetekCanonMappings m on " +
                            "l.Canon_Subsidiary = m.Canon_Subsidiary " +
                            "and l.ITEM_CODE = m.Zygo_PN " +
                            "where " + g.orderplusdate +
                            "and m.ID is null", cnxnAFE);
                        cnxnAFE.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxnAFE.Close();
                    }

                    // mark the serilized requirements

                    try
                    {
                        cmd = new SqlCommand(
                            " UPDATE labels.CanonLabels set SerializeThis = m.serialized_YN " +
                            "from labels.CanonLabels l " +
                            "inner join labels.ZygoAmetekCanonMappings m on " +
                            "l.ITEM_CODE = m.Zygo_PN " +
                            "where " + g.orderplusdate, cnxnAFE);
                        cnxnAFE.Open();
                        cmd.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    finally
                    {
                        cnxnAFE.Close();
                    }

                    multipleCopies();
                }
                else
                {
                    try
                    {
                        cmd = new SqlCommand(
                            "UPDATE labels.CanonLabels set SerializeThis = m.serialized_YN " +
                            "from labels.CanonLabels l " +
                            "inner join labels.ZygoAmetekCanonMappings m on " +
                            "l.ITEM_CODE = m.Zygo_PN " +
                            "where " + g.orderplusdate, cnxnAFE);
                        cnxnAFE.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxnAFE.Close();
                    }

                    //multipleCopies();
                }

                //if (g.customer == "1008JS")
                //{
                //    f2OldStyle1008JS cl = new f2OldStyle1008JS();
                //    cl.ShowDialog();
                //}
                //else if (g.customer == "9999AJ" | g.customer == "C00026")
                //{
                //    f29999 cl = new f29999();
                //    cl.ShowDialog();
                //}
            }

        //    private void multipleCopies()
        //{
        //    //make multiple copies of the rows if delivered quantity is > 0 and barcode and serialized 
        //    // non-serialized will rely on delivered quantity to print labels

        //    try
        //    {
        //        cmd = new SqlCommand
        //            ("Select " +
        //             "Order_No, " +
        //             "POSITION, " +
        //             "Barcode, " +
        //             "SerializeThis, " +
        //             "DELIVERED_QUANTITY " +
        //             "from labels.CanonLabels where " + g.orderplusdate +
        //             //"and barcode = 1 " +
        //             "and serializethis = 1");
        //        cmd.Connection = cnxnAFE;
        //        cnxnAFE.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            if (!dr.IsDBNull(4)) { multiplier = dr.GetInt32(4); }
        //            if (!dr.IsDBNull(1)) { position = dr.GetInt32(1); }

        //            for (int i = 2; i <= multiplier; i++)
        //            {
        //                SqlConnection cnxnAFE2 = new SqlConnection(g.db);
        //                SqlCommand cmd2 = new SqlCommand
        //                 ("insert into labels.canonlabels (" +
        //                  "ORDER_NO, " +
        //                  "POSITION, " +
        //                  "SRNO, " +
        //                  "Serialized, " +
        //                  "SerializeThis, " +
        //                  "CUSTOMER, " +
        //                  "ITEM_CODE, " +
        //                  "DELIVERED_QUANTITY, " +
        //                  "[ROUTE], " +
        //                  "Barcode, " +
        //                  "CUSTOMER_PO, " +
        //                  "Canon_Subsidiary " +
        //                  ",plannedshipmentdate) " +
        //                  "select top 1 " +
        //                  "ORDER_NO, " +
        //                  "POSITION, " +
        //                  "SRNO, " +
        //                  i + ", " +
        //                  "1, " +
        //                  "CUSTOMER, " +
        //                  "ITEM_CODE, " +
        //                  "DELIVERED_QUANTITY, " +
        //                  "[ROUTE], " +
        //                  "Barcode, " +
        //                  "CUSTOMER_PO, " +
        //                  "Canon_Subsidiary " +
        //                  ", PlannedShipmentDate " +
        //                  "from labels.CanonLabels " +
        //                  "where " + g.orderplusdate +
        //                  "and position = " + position, cnxnAFE2);
        //                cnxnAFE2.Open();
        //                cmd2.ExecuteNonQuery();
        //                cnxnAFE2.Close();
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        cnxnAFE.Close();
        //    }
        //}
        }
        private void multipleCopies()
        {
            //make multiple copies of the rows if delivered quantity is > 0 and barcode and serialized 
            // non-serialized will rely on delivered quantity to print labels

            try
            {
                cmd = new SqlCommand
                    ("Select " +
                     "Order_No, " +
                     "POSITION, " +
                     "Barcode, " +
                     "SerializeThis, " +
                     "DELIVERED_QUANTITY " +
                     "from labels.CanonLabels where " + g.orderplusdate +
                     //"and barcode = 1 " +
                     "and serializethis = 1");
                cmd.Connection = cnxnAFE;
                cnxnAFE.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (!dr.IsDBNull(4)) { multiplier = dr.GetInt32(4); }
                    if (!dr.IsDBNull(1)) { position = dr.GetInt32(1); }

                    for (int i = 2; i <= multiplier; i++)
                    {
                        SqlConnection cnxnAFE2 = new SqlConnection(g.db);
                        SqlCommand cmd2 = new SqlCommand
                         ("insert into labels.canonlabels (" +
                          "ORDER_NO, " +
                          "POSITION, " +
                          "SRNO, " +
                          "Serialized, " +
                          "SerializeThis, " +
                          "CUSTOMER, " +
                          "ITEM_CODE, " +
                          "DELIVERED_QUANTITY, " +
                          "[ROUTE], " +
                          "Barcode, " +
                          "CUSTOMER_PO, " +
                          "Canon_Subsidiary " +
                          ",plannedshipmentdate) " +
                          "select top 1 " +
                          "ORDER_NO, " +
                          "POSITION, " +
                          "SRNO, " +
                          i + ", " +
                          "1, " +
                          "CUSTOMER, " +
                          "ITEM_CODE, " +
                          "DELIVERED_QUANTITY, " +
                          "[ROUTE], " +
                          "Barcode, " +
                          "CUSTOMER_PO, " +
                          "Canon_Subsidiary " +
                          ", PlannedShipmentDate " +
                          "from labels.CanonLabels " +
                          "where " + g.orderplusdate +
                          "and position = " + position, cnxnAFE2);
                        cnxnAFE2.Open();
                        cmd2.ExecuteNonQuery();
                        cnxnAFE2.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxnAFE.Close();
            }
        }
    }

    public static class g
    {
        public static string SONumber;
        public static string deliveryDate;
        public static string shipmentDate;
        public static bool alreadyUsed;
        public static string printer = @"\\MIDPRTSRV\ZEBRASN17";
        public static string customer;
        public static string orderplusdate;
        //public static int iQuantity;
        //public static string iNumberofBoxes;
        public static string dbNAV = "server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
                           "user = navdb_read; database = ZYGO-NAV-PROD;";
        public static string NAVprefix = "ZYGO$";
        public static string db = "server = CT-MID-SQL01; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";
    }
}
