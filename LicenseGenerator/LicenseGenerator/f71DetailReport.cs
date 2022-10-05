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
    public partial class f71DetailReport : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable table;

        public f71DetailReport()
        {
            InitializeComponent();
        }

        private void f71DetailReport_Load(object sender, EventArgs e)
        {
            this.Location = new Point(100, 300);

            cnxn = new SqlConnection(g.db);
            cnxn.Open();

            if (g.task == "Dongle Details")
            {
                SqlCommand cmd = new SqlCommand("LicenseDetailx1", cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DongleID", SqlDbType.NVarChar).Value = g.DongleID;
                cmd.Parameters.Add("@ProductLine", SqlDbType.NVarChar).Value = g.productLine;

                table = new DataTable();
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(table);


                cmd = new SqlCommand("LicenseDetailx2", cnxn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DongleID", SqlDbType.NVarChar).Value = g.DongleID;
                cmd.Parameters.Add("@ProductLine", SqlDbType.NVarChar).Value = g.productLine;

                DataTable dt2 = new DataTable();
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                try
                {
                    da.Fill(dt2);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }


                cnxn.Close();

                foreach (DataRow row in dt2.Rows)
                {
                    table.Rows.Add(row.ItemArray);
                }

            }
            if (g.task == "Customer Details")
            {
                bPrint.Visible = false;
                da = new SqlDataAdapter(
                    "select " +
                    "customerNumber [Customer ID], " +
                    "customerName[Customer Name], " +
                    "dongleID [Dongle ID] from LicenseData where " +
                    "productline = '" + g.productLine + "' and " +
                    "activedemo = '" + g.activeDemo + "' " + 
                    "AND LEN(customername) > 0 " +
                    "order by [Customer Name]", cnxn);
            }

            if (g.task == "Sales Order Details")
            {
                bPrint.Visible = false;
                da = new SqlDataAdapter(
                    "select " +
                    "[Sales Order], " +
                    "[Dongle ID], " +
                    "[Order Date], " +
                    "Owner, " +
                    "[Customer Number], " + 
                    "[Application]  from DongleFullDetails where " +
                    "productline = '" + g.productLine + "' and " +
                    "activedemo = '" + g.activeDemo + "' and " +
                    "[sales order] = '" + g.salesorder + "' " +
                    "order by [Sales Order]", cnxn);
            }

            if (g.task == "Dongle by App")
            {
                bPrint.Visible = false;

                da = new SqlDataAdapter( 
                    "select " +
                    "Application, " +
                    "[Dongle ID], " +
                    "[Start Date], " +
                    "[Expiration Date], " +
                    "License, " +
                    "[Sales Order], " +
                    "[Owner], " +
                    "[Customer Number] " +
                    "from DongleFullDetails where " +
                    "productline = '" + g.productLine + "' and " +
                    "activedemo = '" + g.activeDemo + "' and " +
                    "Application = '" + g.application + "' " +
                    "order by Application", cnxn);
            }
            
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnxn.Close();

            if (g.task == "Dongle Details")
            {
                DGV.DataSource = table;
            }
            else
            {
                DGV.DataSource = dt;
            }
                DGV.Show();
           
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            f61PrintPDF f61 = new f61PrintPDF();
            f61.Show();
        }
    }
}
