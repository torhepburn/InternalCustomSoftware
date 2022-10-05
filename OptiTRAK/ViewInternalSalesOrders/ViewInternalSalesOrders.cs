using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ViewInternalSalesOrders
{
    public partial class ViewInternalSalesOrders : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        string db = "server = midsql01; password = Read+Write!; " +
                    "user = readwrite; database = OptiTRAK;";
        
        public ViewInternalSalesOrders()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bItem.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            //this.Text = "F2 " + g.task;

            cnxn = new SqlConnection(db);

            try
            {
                da = new SqlDataAdapter
                ("Select customer_po, order_no, pos, item_code, item_description, " +
                 "pl_dlvry, curr_req_dt, orig_prom_dt, order_date, datagenerated " +
                 "from internal_Sales_Orders where order_no not in " +
                "(select i.ORDER_NO from Internal_Sales_Orders i " +
                " inner join tblSalesOrder s " +
                " on i.ORDER_NO = s.Order_No) " +
                "order by order_no desc", cnxn);
                DataTable table = new DataTable();
                da.Fill(table);
                DGV.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnxn.Close();

            DGV.Columns[0].Width = 100;
            DGV.Columns[1].Width = 75;
            DGV.Columns[2].Width = 50;
            DGV.Columns[3].Width = 150;
            DGV.Columns[4].Width = 180;
            DGV.Columns[5].Width = 100;
            DGV.Columns[9].Width = 150;
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            da = new SqlDataAdapter
                ("Select customer_po, order_no, pos, item_code, item_description, " +
                 "pl_dlvry, curr_req_dt, orig_prom_dt, order_date, datagenerated " +
                 "from internal_Sales_Orders " +
                 "where customer_po like '%" + tbSearchEquipment.Text + "%' " +
                 "or [item_description] like '%" + tbSearchEquipment.Text + "%' " +
                 "or [item_code] like '%" + tbSearchEquipment.Text + "%' " +
                 "order by order_no desc", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            tbSearchEquipment.Text = "";
        }
    }
}
