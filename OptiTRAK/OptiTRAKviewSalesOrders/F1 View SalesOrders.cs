using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OptiTRAKviewSalesOrders
{
    public partial class ViewSalesOrders : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        string db = "server = midsql01; password = Read+Write!; " +
                    "user = readwrite; database = OptiTRAK;";
        

        public ViewSalesOrders()
        {
            InitializeComponent();
        }

        private void ViewSalesOrders_Load(object sender, EventArgs e)
        {
            bItem.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            //this.Text = "F2 " + g.task;

            cnxn = new SqlConnection(db);

            try
            {
                da = new SqlDataAdapter
                ("Select SOID, customer_po, order_no, pos, item_code, item_description, " +
                 "pldlvry, curr_req_dt, orig_prom_dt, order_date, datagenerated, soclosed " +
                 "from uSalesOrder order by soid desc", cnxn);
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
            DGV.Columns[1].Width = 150;
            DGV.Columns[2].Width = 75;
            DGV.Columns[3].Width = 40;
            DGV.Columns[4].Width = 150;
            DGV.Columns[5].Width = 100;
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            da = new SqlDataAdapter
                ("Select SOID, customer_po, order_no, pos, item_code, item_description, " +
                 "pldlvry, curr_req_dt, orig_prom_dt, order_date, datagenerated, soclosed " +
                 "from uSalesOrder " + 
                 "where customer_po like '%" + tbSearchEquipment.Text + "%' " +
                 "or [item_description] like '%" + tbSearchEquipment.Text + "%' " +
                 "or [item_code] like '%" + tbSearchEquipment.Text + "%' " +
                 "order by soid desc", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            tbSearchEquipment.Text = "";
        }
    }
}
