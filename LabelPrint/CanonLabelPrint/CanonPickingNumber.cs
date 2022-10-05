using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CanonLabelPrint
{
    public partial class CanonPickingNumber : Form
    {
        SqlConnection cnxn = new SqlConnection(g.db);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable table;
        private int multiplier;
        private int position;
        private string customer;
        private string SQL1 = "select distinct picking_list_number [Picking List Number] " +
                                "from CANON_SALES_DELIVERIES where PICKING_LIST_NUMBER ";

        public CanonPickingNumber()
        {
            InitializeComponent();
        }

        private void Canon_Load(object sender, EventArgs e)
        {
           this.Text = "Canon Label Print Program v" + Application.ProductVersion.Trim();

            gridData();            
        }

        private void gridData()
        {
            // get Canon picking list numbers for selection list

            try
            {
                cnxn.Open();
                da = new SqlDataAdapter(SQL1 +
                    "<> 0 " +
                    "order by PICKING_LIST_NUMBER desc", cnxn);
                table = new DataTable();
                da.Fill(table);
                cnxn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DGV.DataSource = table;
            DGV.Show();
            DGV.Columns[0].Width = 190;

        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                (SQL1 + " <> 0 " +
                 "and picking_list_number like '%" + tbSearchPartNumber.Text + "%' " +
                 "order by PICKING_LIST_NUMBER desc", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
        }

        private void bItem_Click(object sender, EventArgs e)
        {
            g.pickingListNumber = tbSearchPartNumber.Text.ToString().Trim();
            tbSearchPartNumber.Text = "";
            SqlCommand cmd = new SqlCommand(
                 SQL1 + " = '" + g.pickingListNumber + "' " +
                 "and PICKING_LIST_NUMBER <> 0 ", cnxn);
            cnxn = new SqlConnection(g.db);
            cmd.Connection = cnxn;
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();

            if (o == null)
            {
                MessageBox.Show("Not a valid pick number for Canon.");
                return;
            }
            else
            {
                CentralLogic();
            }
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
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.pickingListNumber = cell.EditedFormattedValue.ToString().Trim();

                CentralLogic();
            }
        }

        private void CentralLogic()
        {
            checkFirstUse();

            enterData();

            SqlCommand cmd = new SqlCommand(
                 " SELECT customer from Canon_sales_deliveries where picking_list_number = '" + g.pickingListNumber + "' " , cnxn);
            cnxn = new SqlConnection(g.db);
            cmd.Connection = cnxn;
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();

            g.customer = o.ToString();

            if (g.customer == "1008JS")
            {
                Canon1008JSLabels cl = new Canon1008JSLabels();
                cl.ShowDialog();
            }
            else if (g.customer == "9999AJ")
            {
                Canon9999AJLabels cl = new Canon9999AJLabels();
                cl.ShowDialog();
            }

        }

        private void checkFirstUse()
        {
            try
            {
                cmd = new SqlCommand(
               "select picking_list_number from labels.CanonLabels " +
               "where picking_list_number = '" + g.pickingListNumber + "' "
               , cnxn);

                cnxn.Open();
                object o = cmd.ExecuteScalar();
                cnxn.Close();

                if (o != null)
                {
                    MessageBox.Show("This pick list was previously retrieved.  Using previous data.");
                    g.alreadyUsed = true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void enterData()
        {
            //if picking list number has not been used then pull in the data
            // set all labels to be barcoded

            if (g.customer == "1008JS")
            {
                if (g.alreadyUsed != true)
                {
                    try
                    {
                        cmd = new SqlCommand(
                            "insert into labels.canonlabels (" +
                            "PICKING_LIST_NUMBER, " +
                            "ORDER_NO, " +
                            "POSITION, " +
                            "SRNO, " +
                            "CUSTOMER, " +
                            "ITEM_CODE, " +
                            "DELIVERED_QUANTITY, " +
                            "[ROUTE], " +
                            "WAREHOUSE, " +
                            "Barcode, " +
                            "Serialized, " +
                            "CUSTOMER_PO, " +
                            "Canon_Subsidiary) " +
                            "select " +
                            "d.PICKING_LIST_NUMBER, " +
                            "d.ORDER_NO, " +
                            "d.POSITION, " +
                            "d.SRNO, " +
                            "d.CUSTOMER, " +
                            "d.ITEM_CODE, " +
                            "d.ORDERED_QUANTITY, " +
                            "o.[ROUTE], " +
                            "d.WAREHOUSE, " +
                            "1, " +
                            "1, " +
                            "o.CUSTOMER_PO, " +
                            "IIF(CUSTOMER_PO like '%AMI%' and o.[ROUTE] = 'SL001', 'AMI',  " +
                            "IIF(CUSTOMER_PO like '%Uts%' and o.[ROUTE] = 'SL001', 'Utsunomiya',  " +
                            "IIF(CUSTOMER_PO like '%Semi%' and o.[ROUTE] = 'SL001', 'Semiconductor',  " +
                            "'Generic'))) Canon_Subsidiary " +
                            "from CANON_SALES_ORDERS o " +
                            "inner join CANON_SALES_DELIVERIES d " +
                            "on o.order_no = d.ORDER_NO " +
                            "where " +
                            "PICKING_LIST_NUMBER <> 0 " +
                            "and PICKING_LIST_NUMBER = '" + g.pickingListNumber + "' ", cnxn);
                        cnxn.Open();
                        cmd.ExecuteNonQuery();
                        cnxn.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn.Close();
                    }

                    // get the label type

                    cmd = new SqlCommand(
                        "Select canon_subsidiary from labels.canonlabels where " +
                        "picking_list_number = '" + g.pickingListNumber + "' ", cnxn);
                    cnxn.Open();
                    object o = cmd.ExecuteScalar();
                    cnxn.Close();

                    //if the label type is not generic then update the barcode requirement
                    // if required

                    if (o.ToString().ToUpper().Trim() != "GENERIC")
                    {

                        try
                        {
                            cmd = new SqlCommand(
                                "UPDATE labels.CanonLabels set barcode = 0 " +
                                "from labels.CanonLabels l " +
                                "left join labels.ZygoCanonMappings m on " +
                                "l.Canon_Subsidiary = m.Canon_Subsidiary " +
                                "and l.ITEM_CODE = m.Zygo_PN " +
                                "where l.PICKING_LIST_NUMBER = '" + g.pickingListNumber + "' " +
                                "and m.ID is null", cnxn);
                            cnxn.Open();
                            cmd.ExecuteNonQuery();
                            cnxn.Close();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }

                    // mark the serilized requirements

                    if (o.ToString().ToUpper().Trim() == "GENERIC")
                    {
                        try
                        {
                            cmd = new SqlCommand(
                                "UPDATE labels.CanonLabels set SerializeThis = 1 " +
                                "where PICKING_LIST_NUMBER = '" + g.pickingListNumber + "' "
                                , cnxn);
                            cnxn.Open();
                            cmd.ExecuteNonQuery();
                            cnxn.Close();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    else
                    {
                        try
                        {
                            cmd = new SqlCommand(
                                "UPDATE labels.CanonLabels set serializeThis = m.serialized_YN " +
                                "from labels.CanonLabels l " +
                                "inner join labels.ZygoCanonMappings m on " +
                                "l.Canon_Subsidiary = m.Canon_Subsidiary " +
                                "and l.ITEM_CODE = m.Zygo_PN " +
                                "where l.PICKING_LIST_NUMBER = '" + g.pickingListNumber + "' "
                                , cnxn);
                            cnxn.Open();
                            cmd.ExecuteNonQuery();
                            cnxn.Close();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }

                    //make multiple copies of the rows if delivered quantity is > 0 and barcode and serialized 
                    // non-serialized will rely on delivered quantity to print labels

                    try
                    {
                        cmd = new SqlCommand
                            ("Select " +
                             "PICKING_LIST_NUMBER, " +
                             "POSITION, " +
                             "Barcode, " +
                             "SerializeThis, " +
                             "DELIVERED_QUANTITY " +
                             "from labels.CanonLabels where PICKING_LIST_NUMBER = '" +
                             g.pickingListNumber + "' and barcode = 1 and serializethis = 1");
                        cmd.Connection = cnxn;
                        cnxn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            if (!dr.IsDBNull(4)) { multiplier = dr.GetInt32(4); }
                            if (!dr.IsDBNull(1)) { position = dr.GetInt32(1); }

                            for (int i = 2; i <= multiplier; i++)
                            {
                                SqlConnection cnxn2 = new SqlConnection(g.db);
                                SqlCommand cmd2 = new SqlCommand
                                 ("insert into labels.canonlabels (" +
                                  "PICKING_LIST_NUMBER, " +
                                  "ORDER_NO, " +
                                  "POSITION, " +
                                  "SRNO, " +
                                  "Serialized, " +
                                  "SerializeThis, " +
                                  "CUSTOMER, " +
                                  "ITEM_CODE, " +
                                  "DELIVERED_QUANTITY, " +
                                  "[ROUTE], " +
                                  "WAREHOUSE, " +
                                  "Barcode, " +
                                  "CUSTOMER_PO, " +
                                  "Canon_Subsidiary) " +
                                  "select top 1 " +
                                  "PICKING_LIST_NUMBER, " +
                                  "ORDER_NO, " +
                                  "POSITION, " +
                                  "SRNO, " +
                                  i + ", " +
                                  "1, " +
                                  "CUSTOMER, " +
                                  "ITEM_CODE, " +
                                  "DELIVERED_QUANTITY, " +
                                  "[ROUTE], " +
                                  "WAREHOUSE, " +
                                  "Barcode, " +
                                  "CUSTOMER_PO, " +
                                  "Canon_Subsidiary " +
                                  "from labels.CanonLabels " +
                                  "where picking_list_number = '" + g.pickingListNumber + "' " +
                                  "and position = " + position, cnxn2);
                                cnxn2.Open();
                                cmd2.ExecuteNonQuery();
                                cnxn2.Close();
                            }
                        }
                        cnxn.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                    //AmetekJapan
            }
            {

                if (g.alreadyUsed != true)
                {
                    try
                    {
                        cmd = new SqlCommand(
                            "insert into labels.canonlabels (" +
                            "PICKING_LIST_NUMBER, " +
                            "ORDER_NO, " +
                            "POSITION, " +
                            "SRNO, " +
                            "CUSTOMER, " +
                            "ITEM_CODE, " +
                            "DELIVERED_QUANTITY, " +
                            "[ROUTE], " +
                            "WAREHOUSE, " +
                            "Barcode, " +
                            "Serialized, " +
                            "CUSTOMER_PO, " +
                            "Canon_Subsidiary) " +
                            "select " +
                            "d.PICKING_LIST_NUMBER, " +
                            "d.ORDER_NO, " +
                            "d.POSITION, " +
                            "d.SRNO, " +
                            "d.CUSTOMER, " +
                            "d.ITEM_CODE, " +
                            "d.ORDERED_QUANTITY, " +
                            "o.[ROUTE], " +
                            "d.WAREHOUSE, " +
                            "1, " +
                            "1, " +                 //the serialized field gives the number of the line and is not what
                            "o.CUSTOMER_PO, " +     // determines whether or not the item is serialized
                            "IIF(CUSTOMER_PO like '%AMI%' and o.[ROUTE] = 'SL001', 'AMI',  " +
                            "IIF(CUSTOMER_PO like '%Uts%' and o.[ROUTE] = 'SL001', 'Utsunomiya',  " +
                            "IIF(CUSTOMER_PO like '%Semi%' and o.[ROUTE] = 'SL001', 'Semiconductor',  " +
                            "'Generic'))) Canon_Subsidiary " +
                            "from CANON_SALES_ORDERS o " +
                            "inner join CANON_SALES_DELIVERIES d " +
                            "on o.order_no = d.ORDER_NO " +
                            "where " +
                            "PICKING_LIST_NUMBER <> 0 " +
                            "and PICKING_LIST_NUMBER = '" + g.pickingListNumber + "' ", cnxn);
                        cnxn.Open();
                        cmd.ExecuteNonQuery();
                        cnxn.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn.Close();
                    }

                    // only labels on zygocanonmappings get barcodes

                    try
                    {
                        cmd = new SqlCommand(
                            "UPDATE labels.CanonLabels set barcode = 0 " +
                            "from labels.CanonLabels l " +
                            "left join labels.ZygoAmetekCanonMappings m on " +
                            "l.ITEM_CODE = m.Zygo_PN " +
                            "where l.PICKING_LIST_NUMBER = '" + g.pickingListNumber + "' " +
                            "and m.ID is null", cnxn);
                        cnxn.Open();
                        cmd.ExecuteNonQuery();
                        cnxn.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }


                    // mark the serialized requirements


                    try
                    {
                        cmd = new SqlCommand(
                            "UPDATE labels.CanonLabels set serializeThis = m.serialized_YN " +
                            "from labels.CanonLabels l " +
                            "inner join labels.ZygoAmetekCanonMappings m on " +
                            "l.ITEM_CODE = m.Zygo_PN " +
                            "where l.PICKING_LIST_NUMBER = '" + g.pickingListNumber + "' "
                            , cnxn);
                        cnxn.Open();
                        cmd.ExecuteNonQuery();
                        cnxn.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }


                    //make multiple copies of the rows if delivered quantity is > 0 and barcode and serialized 
                    // non-serialized will rely on delivered quantity to print labels

                    try
                    {
                        cmd = new SqlCommand
                            ("Select " +
                             "PICKING_LIST_NUMBER, " +
                             "POSITION, " +
                             "Barcode, " +
                             "SerializeThis, " +
                             "DELIVERED_QUANTITY " +
                             "from labels.CanonLabels where PICKING_LIST_NUMBER = '" +
                             g.pickingListNumber + "' and barcode = 1 and serializethis = 1");
                        cmd.Connection = cnxn;
                        cnxn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            if (!dr.IsDBNull(4)) { multiplier = dr.GetInt32(4); }
                            if (!dr.IsDBNull(1)) { position = dr.GetInt32(1); }

                            for (int i = 2; i <= multiplier; i++)
                            {
                                SqlConnection cnxn2 = new SqlConnection(g.db);
                                SqlCommand cmd2 = new SqlCommand
                                 ("insert into labels.canonlabels (" +
                                  "PICKING_LIST_NUMBER, " +
                                  "ORDER_NO, " +
                                  "POSITION, " +
                                  "SRNO, " +
                                  "Serialized, " +
                                  "SerializeThis, " +
                                  "CUSTOMER, " +
                                  "ITEM_CODE, " +
                                  "DELIVERED_QUANTITY, " +
                                  "[ROUTE], " +
                                  "WAREHOUSE, " +
                                  "Barcode, " +
                                  "CUSTOMER_PO, " +
                                  "Canon_Subsidiary) " +
                                  "select top 1 " +
                                  "PICKING_LIST_NUMBER, " +
                                  "ORDER_NO, " +
                                  "POSITION, " +
                                  "SRNO, " +
                                  i + ", " +
                                  "1, " +
                                  "CUSTOMER, " +
                                  "ITEM_CODE, " +
                                  "DELIVERED_QUANTITY, " +
                                  "[ROUTE], " +
                                  "WAREHOUSE, " +
                                  "Barcode, " +
                                  "CUSTOMER_PO, " +
                                  "Canon_Subsidiary " +
                                  "from labels.CanonLabels " +
                                  "where picking_list_number = '" + g.pickingListNumber + "' " +
                                  "and position = " + position, cnxn2);
                                cnxn2.Open();
                                cmd2.ExecuteNonQuery();
                                cnxn2.Close();
                            }
                        }
                        cnxn.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            /*
             * 
             * Read the comments below Process.Start to find program code.
             * 
             * */
            Process.Start(@"C:\labels\canon\canonlabeldata\Canon_Label_Data.exe");
            /*
             * This program is in OracleView as it is an extraction program.
             * It writes to AccessFrontEnds.dbo.Canon_Sales_Deliveries
             * and AccessFrontEnds.dbo.Canon_Sales_Orders
             * 
             * refresh data from mk using C# data extraction program.  Dlls need to be 
             * in same folder.
             * 
             *  may need this later:      Thread.Sleep(5000);
            */
            gridData();
            
        }
    }




    public static class g
    {
        public static string pickingListNumber;
        public static bool alreadyUsed;
        public static string LabelType;
        public static string printer = @"\\MIDPRTSRV\ZEBRASN17";
        public static string customer;
        //public static string iQuantity;
        //public static string iNumberofBoxes;
        //public static string iLabelQuantity;
        public static string db = "server = CT-MID-SQL01; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";
    }
}

