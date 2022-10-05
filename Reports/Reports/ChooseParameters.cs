using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Reports
{
    public partial class ChooseParameters : Form
    {
        public ChooseParameters()
        {
            InitializeComponent();
        }

        private void ChooseParameters_Load(object sender, EventArgs e)
        {
            this.Text = "Choose Parameters Planned Deliveries v" + Application.ProductVersion;
            rbProductionDate.Checked = true;
            
            SqlConnection cnxn = new SqlConnection(g.db);
            SqlDataAdapter da = new SqlDataAdapter
                ("select distinct warehouse from MMX_PRODUCTION_ORDER_FILE order by warehouse", cnxn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow newRow = dt.NewRow();
            newRow[0] = "";
            dt.Rows.InsertAt(newRow, 0);

            cbddWarehouse.DataSource = dt;
            cbddWarehouse.DisplayMember = "Warehouse";
        }

        private void BviewReport_Click(object sender, EventArgs e)
        {
            if (rbProductionDate.Checked)
            {
                g.sortOrder = "Start_date";
            }
            if (rbItemCode.Checked)
            {
                g.sortOrder = "item_code";
            }
            if(rbDeliveryDate.Checked)
            {
                g.sortOrder = "Planned_Delivery_date";
            }
            if (rbOrderNo.Checked)
            {
                g.sortOrder = "Order_no";
            }
            if (rbPlanner.Checked)
            {
                g.sortOrder = "e.name";
            }
            if (cbDateRange.Checked)
            {
                g.startDate = startCalendar.SelectionStart.ToShortDateString();
                g.endDate = endCalendar.SelectionStart.ToShortDateString();
                g.DateRange = "AND start_date > '" + g.startDate +
                    "' AND start_date < '" + g.endDate + "' ";
            }
            else
            {
                g.DateRange = "AND start_date < GETDATE() + 41 ";
                g.endDate = DateTime.Now.AddDays(41).ToShortDateString();
            }

            if (cbddWarehouse.Text == "")
            {
                g.warehouse = " AND 1=1 ";
            }
            else
            {
                g.warehouse = " AND warehouse = '" + cbddWarehouse.Text + "' ";
            }

            PrintReport p = new PrintReport();
            p.ShowDialog();
        }

        private void cbDateRange_CheckedChanged(object sender, EventArgs e)
        {
            if ( cbDateRange.Checked)
            {
                label2.Visible = true;
                label3.Visible = true;
                startCalendar.Visible = true;
                endCalendar.Visible = true;
            }
            else
            {
                label2.Visible = false;
                label3.Visible = false;
                startCalendar.Visible = false;
                endCalendar.Visible = false;
            }
        }
    }

    public static class g
    {
        public static string sortOrder;
        public static string startDate;
        public static string endDate;
        public static string DateRange;
        public static string warehouse;
        public static string orderNumber;
        public static string task;
        public static string origDelDate;
        public static string PO;
        public static string Supplier;
        public static string PoQuantity;
        public static string db = "server = CT-MID-SQL01; password = Read+Write!; " +
                            "user = readwrite; database = AccessFrontEnds;";
    }
}
