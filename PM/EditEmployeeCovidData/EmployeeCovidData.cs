using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EditEmployeeCovidData
{
    public partial class EmployeeCovidData : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        SqlDataReader dr;

        private string AMETEKNumber = string.Empty;

        public EmployeeCovidData()
        {
            InitializeComponent();
        }

        private void EmployeeCovidData_Load(object sender, EventArgs e)
        {
            this.Text = "Employee COVID Data v" + Application.ProductVersion.Trim();
            GetData();
        }

        private void GetData()
        {
            cnxn = new SqlConnection(g.db);
            cmd = new SqlCommand("SELECT " +
                " AMETEKNumber [AMETEK Number] " +
                ",TRIM(FirstName) [First Name] " +
                ",TRIM(LastName) [Last Name] " +
                ",CovidTestDate [COVID Test Date]" +
                "FROM EmployeeData " +
                "ORDER BY LastName ", cnxn);
            try
            {
                cnxn.Open();

                dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);

                DGV.DataSource = dt;
                DGV.Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            try
            {
                cmd = new SqlCommand("SELECT " +
                " AMETEKNumber [AMETEK Number] " +
                ",TRIM(FirstName) [First Name] " +
                ",TRIM(LastName) [Last Name] " +
                ",CovidTestDate [COVID Test Date]" +
                "FROM EmployeeData " +
                "WHERE (AMETEKNUMBER like '%" + tbSearchEquipment.Text + "%'" +
                "OR FirstName like '%" + tbSearchEquipment.Text + "%' " +
                "OR LastName like '%" + tbSearchEquipment.Text + "%') " +
                "ORDER BY LastName ", cnxn);

                cnxn.Open();

                dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);

                DGV.DataSource = dt;
                DGV.Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            //tbSearchEquipment.Text = string.Empty;
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 4)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                tbTestDate.Text = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                AMETEKNumber = cell.EditedFormattedValue.ToString().Trim();

                
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            tbTestDate.Text = monthCalendar1.SelectionStart.ToShortDateString();
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(
                    "UPDATE EmployeeData " +
                    "SET CovidTestDate = '" + tbTestDate.Text.Trim() + "' " +
                    "WHERE AMETEKNumber = '" + AMETEKNumber + "'", cnxn);
        
            cnxn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            //GetData();
        }


        private void bContractors_Click(object sender, EventArgs e)
        {
            Contractors c = new Contractors();
            c.ShowDialog();
        }

        private void tbTestDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbSearchEquipment_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public static class g
    {
        //public static string itemCode;
        //public static string ShortageID;
        //public static string ShortageGroup;
        //public static string ProductLine;
        //public static string task;
        //public static string origRqstRcptDate = string.Empty;
        //public static string PlannedReceiptDate = string.Empty;
        //public static string PO;
        //public static string Supplier = string.Empty;
        //public static string PoQuantity = string.Empty;
        //public static string PurchaserCode = string.Empty;
        //public static string dbDash = "server = MIDDB01.zygo.com; password = views; " +
        //    "user = views; database = Dashboard;";
        public static string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                            "user = readwrite; database = BuildingLog;";
        //public static string dbNAV = "server = pa-hor-as408; password = 2018#ameteK; " +
        //                    "user = navdb_read; database = ZYGO-NAV-PROD;";
        //public static string NAVprefix = "ZYGO$";
    }
}
