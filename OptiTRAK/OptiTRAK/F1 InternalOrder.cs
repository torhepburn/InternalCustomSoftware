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
    public partial class f1_AddOrder : Form
    {
        SqlConnection cnxn;
        string db = "server = midsql01; password = Read+Write!; " +
                    "user = readwrite; database = OptiTRAK;";
        SqlCommand cmd;

        public f1_AddOrder()
        {
            InitializeComponent();
        }

        private void f1_AddOrder_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            cmd = new SqlCommand
                    ("Select order_no from uSalesOrder " +
                     "where len(order_no) < 7 and order_no < 980000 " +
                     " order by order_no desc ", cnxn);
            cnxn.Open();
            object so = cmd.ExecuteScalar();
            cnxn.Close();

            int nextSO;
            bool result = int.TryParse(so.ToString(), out nextSO);
            
            cmd = new SqlCommand
                    ("Select order_no from internal_Sales_Orders" +
                     " order by order_no desc ", cnxn);
            cnxn.Open();
            object io = cmd.ExecuteScalar();
            cnxn.Close();

            int nextIO;
            bool resultI = int.TryParse(io.ToString(), out nextIO);

            if (nextSO > nextIO)
            {
                tbOrder.Text = (nextSO + 1).ToString();
            }
            else
            {
                tbOrder.Text = (nextIO + 1).ToString();
            }

            string select = "select distinct customer from uJobInfo " +
                " order by customer";

            cnxn.Open();
            SqlDataAdapter da = new SqlDataAdapter(select, cnxn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnxn.Close();
            cbCustomer.DataSource = dt;
            cbCustomer.DisplayMember = "Customer";

           
        }

        private void bEnterData_Click(object sender, EventArgs e)
        {
            if(tbPosition.Text.Length < 1)
            {
                MessageBox.Show("Must enter a number.");
                tbPosition.Focus();
                return;
            }
            else
            {
                int num;
                bool isNum = int.TryParse(tbPosition.Text.Trim(), out num);
                if(!isNum)
                {
                    MessageBox.Show("Invalid Number");
                    tbPosition.Text = "";
                    tbPosition.Focus();
                    return;
                }
            }
            

            SqlParameter OrderNo = new SqlParameter("@OrderNo", SqlDbType.NVarChar, 10);
                OrderNo.Value = tbOrder.Text.ToString().Trim();

            SqlParameter Customer = new SqlParameter("@Customer", SqlDbType.NVarChar, 50);
            Customer.Value = cbCustomer.Text.ToString().Trim();

            SqlParameter Position = new SqlParameter("@Position", SqlDbType.Int);
            Position.Value = tbPosition.Text.ToString().Trim();

            SqlParameter ItemCode = new SqlParameter("@ItemCode", SqlDbType.NVarChar, 30);
            ItemCode.Value = tbItemCode.Text.ToString().Trim();

            SqlParameter Description = new SqlParameter("@Description", SqlDbType.NVarChar, 50);
            Description.Value = tbItemDescription.Text.ToString().Trim();

            SqlParameter DeliveryDate = new SqlParameter("@DDate", SqlDbType.Date);
            DeliveryDate.Value = dtpPl_Dlvry.Value;

            SqlParameter RequiredDate = new SqlParameter("@RDate", SqlDbType.Date);
            RequiredDate.Value = dtpPl_Dlvry.Value;
             
            SqlParameter PromisedDate = new SqlParameter("@PDate", SqlDbType.Date);
            PromisedDate.Value = dtpPl_Dlvry.Value;
             
            SqlParameter OrderDate = new SqlParameter("@ODate", SqlDbType.Date);
            OrderDate.Value = dtpPl_Dlvry.Value;

            SqlParameter DataGenerated = new SqlParameter("@GDate", SqlDbType.Date);
            DataGenerated.Value = DateTime.Now;

            cnxn = new SqlConnection(db);
            cmd = new SqlCommand("Insert into internal_sales_orders ( " +
                "Customer_PO, " +
                "Order_No, " +
                "POS, " +
                "Item_Code, " +
                "Item_Description, " +
                "Pl_Dlvry, " +
                "Curr_Req_Dt, " +
                "Orig_Prom_dt, " +
                "Order_Date, " +
                "DataGenerated " +
                " )" + 
                "values ( " +
                Customer + ", " +
                OrderNo + ", " +
                Position + ", " +
                ItemCode + ", " +
                Description + ", " +
                DeliveryDate + ", " +
                RequiredDate + ", " +
                PromisedDate + ", " +
                OrderDate + ", " +
                DataGenerated +
                " ) ", cnxn);

            cmd.Parameters.Add(Customer);
            cmd.Parameters.Add(OrderNo);
            cmd.Parameters.Add(Position);
            cmd.Parameters.Add(ItemCode);
            cmd.Parameters.Add(Description);
            cmd.Parameters.Add(DeliveryDate);
            cmd.Parameters.Add(RequiredDate);
            cmd.Parameters.Add(PromisedDate);
            cmd.Parameters.Add(OrderDate);
            cmd.Parameters.Add(DataGenerated);

            cnxn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            cnxn.Close();
            
            cmd.Parameters.Clear();
            tbPosition.Text = "";
            tbPosition.Focus();
           
        }

        private void bNewOrderNumber_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            cmd = new SqlCommand
                    ("Select order_no from uSalesOrder " +
                     " order by order_no desc ", cnxn);
            cnxn.Open();
            object so = cmd.ExecuteScalar();
            cnxn.Close();

            int nextSO;
            bool result = int.TryParse(so.ToString(), out nextSO);

            cmd = new SqlCommand
                    ("Select order_no from internal_Sales_Orders" +
                     " order by order_no desc ", cnxn);
            cnxn.Open();
            object io = cmd.ExecuteScalar();
            cnxn.Close();

            int nextIO;
            bool resultI = int.TryParse(io.ToString(), out nextIO);

            if (nextSO > nextIO)
            {
                tbOrder.Text = (nextSO + 1).ToString();
            }
            else
            {
                tbOrder.Text = (nextIO + 1).ToString();
            }

            string select = "select distinct customer from uJobInfo " +
                " order by customer";

            cnxn.Open();
            SqlDataAdapter da = new SqlDataAdapter(select, cnxn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnxn.Close();
            cbCustomer.DataSource = dt;
            cbCustomer.DisplayMember = "Customer";

            cbCustomer.Text = "";
            tbPosition.Text = "";
            tbPosition.Text = "";
            tbItemCode.Text = "";
            tbItemDescription.Text = "";
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
