using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Service
{
    public partial class ServiceContracts : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;

        public ServiceContracts()
        {
            InitializeComponent();
        }

        private void ServiceContracts_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            try
            {
                da = new SqlDataAdapter("select * from Service_Contracts " +
                    "order by substring(contract,1,6)", cnxn);
            }
            catch ( SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DataTable table = new DataTable();
            da.Fill(table);

            DGV.DataSource = table;
            DGV.Show();

            DGV.Columns[0].Width = 200;
            DGV.Columns[1].Width = 75;
            DGV.Columns[2].Width = 60;
            DGV.Columns[3].Width = 60;
            DGV.Columns[4].Width = 60;
            DGV.Columns[5].Width = 70;

            
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 | e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.customer = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.contract = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.type = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                g.location = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[4];
                g.region = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[5];
                g.expiration = cell.EditedFormattedValue.ToString().Trim();

                CoverageDetails cd = new CoverageDetails();
                cd.ShowDialog();
            
            }   
        }
    }

    public static class g
    {
        public static string contract;
        public static string region;
        public static string customer;
        public static string location;
        public static string type;
        public static string expiration;
        public static string sn;
        public static string model;
        public static string holdStatusID;
        public static string partid;
        public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;";

    }
}
