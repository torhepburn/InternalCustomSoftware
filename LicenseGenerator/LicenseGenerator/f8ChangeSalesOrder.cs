using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LicenseGenerator
{
    public partial class f8ChangeSalesOrder : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        private string SalesOrder;
        private string owner;
        
        public f8ChangeSalesOrder()
        {
            InitializeComponent();
        }

        private void f8ChangeSalesOrder_Load(object sender, EventArgs e)
        {
            ToolTip tt1 = new ToolTip();
            tt1.SetToolTip(this.button1, "Enter Sales Order or Owner");
            
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter(
                "select " +
                "salesorder [Sales Order], " +
                "dongleid [Dongle ID] from LicenseData where " +
                "productline = '" + g.productLine + "' and " +
                "activedemo = '" + g.activeDemo + "' and " +
                "dongleid = '" + g.DongleID + "' and " +
                "id = '" + g.uid + "' " + 
                "order by [Sales Order]", cnxn);
            
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnxn.Close();

            LDongleID.Text = dt.Rows[0][1].ToString().Trim();
            LcurrentSO.Text = dt.Rows[0][0].ToString().Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbSalesOrder.Text.Length > 0)
            {
                int number;
                bool result = Int32.TryParse(tbSalesOrder.Text.Trim(), out number);
                if (result == true | tbSalesOrder.Text.ToUpper().Substring(0, 2) == "SO" | tbSalesOrder.Text.ToUpper().Substring(0, 1) == "Z")
                {
                    SalesOrder = tbSalesOrder.Text.Trim().ToUpper();
                }
                else
                {
                    SalesOrder = "0";
                    owner = tbSalesOrder.Text.Trim();
                }


                SqlCommand cmd = new SqlCommand(
                       " Update LicenseData " +
                       " set SalesOrder = '" + SalesOrder + "', " +
                       " owner = '" + owner + "' " +
                       " where id = '" + g.uid + "' ", cnxn);

                cnxn.Open();
                int rowsReturned = cmd.ExecuteNonQuery();
                cnxn.Close();

                cnxn = new SqlConnection(g.dbNAV);

                string sql = string.Empty;

                if (tbSalesOrder.Text.ToUpper().Substring(0, 2) == "SO")
                {
                    sql = "SELECT [Bill-to Customer No_] " +
                   ",CASE " +
                   "   WHEN LEN([End User Customer Name]) < 1 THEN [Bill-to Name] " +
                   "   ELSE [End User Customer Name] " +
                   "END " +
                   ",[Order Date] " +
                   "FROM [ZYGO$Service Header] WHERE No_ = '" + tbSalesOrder.Text.ToUpper() + "'";
                }
                else
                {
                    sql = "SELECT [Sell-to Customer No_] " +
                    ",CASE " +
                    "   WHEN LEN([End User Customer Name]) < 1 THEN [Sell-to Customer Name] " +
                    "   ELSE [End User Customer Name] " +
                    "END " +
                    ",[Order Date] " +
                    "FROM [ZYGO$Sales Header] WHERE No_ = '" + SalesOrder + "'";
                }
                SqlDataAdapter da = new SqlDataAdapter(sql, cnxn);

                DataTable dt = new DataTable();

                try
                {
                    da.Fill(dt);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }

                if (dt.Rows.Count > 0)
                {
                    SqlParameter pCustomerName = new SqlParameter("@customerName", SqlDbType.NChar);
                    pCustomerName.Value = dt.Rows[0][1];
                    cnxn = new SqlConnection(g.db);
                    cmd = new SqlCommand("UPDATE LicenseData " +
                        "SET customernumber = '" + dt.Rows[0][0] + "', " +
                        "CustomerName = " + pCustomerName + ", " +
                        "OrderDate = '" + dt.Rows[0][2] + "' " +
                        "WHERE SalesOrder = '" + SalesOrder + "'", cnxn);

                    try
                    {
                        cnxn.Open();
                        cmd.Parameters.Add(pCustomerName);
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cmd.Parameters.Clear();
                        cnxn.Close();
                    }

                }
            }
            this.Close();
        }

    }
}
