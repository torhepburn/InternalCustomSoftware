using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OptiTRAK
{
    public partial class F2_Select_Sales_Order : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        string db = "server = midsql01; password = Read+Write!; " +
                    "user = readwrite; database = OptiTRAK;";
        string SQL1 = "Select customer_po Customer, order_no 'Order No', Pos, " +
                 "item_code 'Item Code', item_description 'Item Description', " +
                 "Pl_Dlvry 'Planned Delivery', Curr_Req_Dt 'Current Required Date', " +
                 "Orig_Prom_Dt 'Original Promised Date', " + 
                 "order_date 'Order Date', datagenerated DataDate " +
                 "from internal_Sales_Orders ";

        public F2_Select_Sales_Order()
        {
            InitializeComponent();
        }

        private void F2_Select_Sales_Order_Load(object sender, EventArgs e)
        {
            bItem.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "F2 " + g.task;

            cnxn = new SqlConnection(db);

            try
            {
                da = new SqlDataAdapter
                ( SQL1 + "where order_no not in " +
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

            columns();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            da = new SqlDataAdapter
                (SQL1 +
                 "where (customer_po like '%" + tbSearchEquipment.Text + "%' " +
                 "or [item_description] like '%" + tbSearchEquipment.Text + "%' " +
                 "or [item_code] like '%" + tbSearchEquipment.Text + "%') " +
                 "and order_no not in " +
                "(select i.ORDER_NO from Internal_Sales_Orders i " +
                " inner join tblSalesOrder s " +
                " on i.ORDER_NO = s.Order_No) " +
                 "order by order_no desc", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            tbSearchEquipment.Text = "";

            columns();
        }

        private void bItem_Click(object sender, EventArgs e)
        {

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
                g.orderNo = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.position = cell.EditedFormattedValue.ToString().Trim();

                selectionChoice();
            }
        }

        private void selectionChoice()
        {
            if (g.task == "Delete")
            {
                string message = "Confirm Deletion.";
                string caption = "";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                cnxn = new SqlConnection(g.db);

                SqlCommand cmd = new SqlCommand
                    ("delete from internal_sales_orders " +
                    "where order_no = " + g.orderNo + " and " + 
                    "pos = " + g.position + " ", cnxn);

                cnxn.Open();
                int rowsReturned = cmd.ExecuteNonQuery();
                cnxn.Close();

                try
                {
                    da = new SqlDataAdapter
                    (SQL1 + "where order_no not in " +
                    "(select i.ORDER_NO from Internal_Sales_Orders i " +
                    " inner join tblSalesOrder s " +
                    " on i.ORDER_NO = s.Order_No) " +
                    "order by order_no desc", cnxn);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    DGV.DataSource = table;

                    columns();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                cnxn.Close();

            }
        }

        private void columns()
        {

            DGV.Columns[0].Width = 100;
            DGV.Columns[1].Width = 75;
            DGV.Columns[2].Width = 50;
            DGV.Columns[3].Width = 150;
            DGV.Columns[4].Width = 180;
            DGV.Columns[5].Width = 100;
            DGV.Columns[9].Width = 150;
        }
    }
}
