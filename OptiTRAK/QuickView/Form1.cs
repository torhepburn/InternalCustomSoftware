using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuickView
{
    public partial class Form1 : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable table;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Text = "QuickView planner current status plus real time";
            //this.Text = "QuickView Yesterday and Today Actual Work";
            //this.Text = "Closed in OptiTRAK open in Mk";
            //this.Text = "Kanban demand - last column";

            //string db = "server = midsql01; password = Read+Write!; " +
            //                      "user = readwrite; database = GeneralLedger;";

            string db = "server = midsql01; password = Read+Write!; " +
                                 "user = readwrite; database = PM_2015_A;";

            //string db = "server = midsql01; password = Read+Write!; " +
            //                      "user = readwrite; database = OptiTRAK;";
            cnxn = new SqlConnection(db);

            
            //da = new SqlDataAdapter("select * from plannercurrentstatusevaluation " +
            //    "order by mostrecentstart desc ", cnxn);
            //da = new SqlDataAdapter("select * from yesterdayandtoday " +
            //    "order by orderno, step ", cnxn);
            //da = new SqlDataAdapter("select * from closedinoptitrakopeninmk " +
            //    "order by prodordnum ", cnxn);
            //da = new SqlDataAdapter("select * from kbdemand " +
            //    "order by item_code, kb_sequence ", cnxn);
            //da = new SqlDataAdapter("select * from mfdkanbanproduction " +
            //    "order by item_code ", cnxn);
            //da = new SqlDataAdapter("select * from AuditX6RevenueS1 " +
            //        "where description like '%service%' " +
            //        "order by order_number ", cnxn);

            try
            {

                da = new SqlDataAdapter("select * from toolroommonthlysavings " +
                    //"where description like '%service%' " +
                    "order by month ", cnxn);



                da.SelectCommand.CommandTimeout = 200;

                table = new DataTable();
                da.Fill(table);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DGV.DataSource = table;
            DGV.Show();
        }
    }
}
