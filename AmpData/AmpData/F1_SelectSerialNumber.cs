using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AmpData
{
    public partial class F1_SelectSerialNumber : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        
        public F1_SelectSerialNumber()
        {
            InitializeComponent();
        }

        private void SelectSerialNumber_Load(object sender, EventArgs e)
        {
            this.Text = "Select Serial Number  v" + Application.ProductVersion;
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter("Select [part serial number] from nif_amp_data " +
                 "order by [part serial number]", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            DGV.Columns[0].Width = 160;
            DGV.Show();
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 1)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];

                g.serialNumber = cell.EditedFormattedValue.ToString().Trim();

                F2_Data_Entry_Category f2 = new F2_Data_Entry_Category();
                f2.ShowDialog();
                //this.Close();
            }
        }

        private void bGetItem_Click(object sender, EventArgs e)
        {
            g.serialNumber = tbSearch.Text.ToString().Trim();
            tbSearch.Text = "";
            F2_Data_Entry_Category f2 = new F2_Data_Entry_Category();
            f2.ShowDialog();
        }
    }

    public static class g
    {
        public static string serialNumber;
        //public static string task;
        public static string userType;
        //public static string rpt_type;
        //public static string pdf;
        public static string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = accessfrontends;";
    }

    
}
