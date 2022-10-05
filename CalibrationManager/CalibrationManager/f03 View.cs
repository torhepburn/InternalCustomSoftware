using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CalibrationManager
{
    public partial class f03_View : Form
    {
        private string searchString;
        SqlDataAdapter da;
        DataTable table;
        SqlConnection cnxn;
        string location;
        string id;
        
        public f03_View()
        {
            InitializeComponent();
        }
  
        private void bBenchSearch_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                location = textBox1.Text.ToString().Trim();
            }
            
            displayData();
        }

        private void bIDsearch_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                id = textBox1.Text.ToString().Trim();
            }
            
            displayData();
        }

        private void displayData()
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter("CalibrationManagerReports", cnxn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Facility", SqlDbType.NVarChar).Value = g.facility;
            da.SelectCommand.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DBNull.Value;
            da.SelectCommand.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = DBNull.Value;
            da.SelectCommand.Parameters.Add("@Status", SqlDbType.NVarChar).Value = DBNull.Value;
            da.SelectCommand.Parameters.Add("@Order", SqlDbType.NVarChar).Value = DBNull.Value;
            if (location == null)
            {
                da.SelectCommand.Parameters.Add("@Location", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@Location", SqlDbType.VarChar).Value = location;
            }
            if (id != null)
            {
                da.SelectCommand.Parameters.Add("@ID", SqlDbType.NVarChar).Value = id;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@ID", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            da.SelectCommand.Parameters.Add("@CalibrationSource", SqlDbType.NVarChar).Value = DBNull.Value;
            table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            DGV.Show();
            id = null;
            location = null;
            Lrowcount.Text = "Row Count: " + DGV.RowCount.ToString();
        }

        private void f03_View_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}