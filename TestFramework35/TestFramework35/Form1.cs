using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TestFramework35
{
    public partial class Form1 : Form
    {
        SqlConnection cnxn;
        string db = "server = midsql01; password = Read+Write!; " +
                    "user = readwrite; database = OptiTRAK;";
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlParameter Customer = new SqlParameter("@Customer", SqlDbType.NVarChar, 50);
            Customer.Value = tbCustomer.Text.ToString().Trim();

            cnxn = new SqlConnection(db);
            cmd = new SqlCommand("Insert into tblSalesOrder ( " +
                "Customer_PO, " +
                //"Order_No, " +
                //"POS, " +
                //"Item_Code, " +
                //"Item_Description, " +
                //"PlDlvry, " +
                //"Curr_Req_Dt, " +
                //"Orig_Prom_dt, " +
                //"Order_Date, " +
                //"DataGenerated, " +
                "SOClosed )" + 
                "values ( " +
                Customer + ", " +
                //OrderNo + "', " +
                //Position + ", '" +
                //ItemCode + "',' " +
                //Description + "', " +
                //DeliveryDate + ", " +
                //RequiredDate + ", " +
                //PromisedDate + ", " +
                //OrderDate + ", " +
                //DataGenerated + ", " +
                "0 ) ", cnxn);

            cmd.Parameters.Add(Customer);
            //cmd.Parameters.Add(OrderNo);
            //cmd.Parameters.Add(Position);
            //cmd.Parameters.Add(ItemCode);
            //cmd.Parameters.Add(Description);
            //cmd.Parameters.Add(DeliveryDate);
            //cmd.Parameters.Add(RequiredDate);
            //cmd.Parameters.Add(PromisedDate);
            //cmd.Parameters.Add(OrderDate);
            //cmd.Parameters.Add(DataGenerated);

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
           
        


        }
    }
}
