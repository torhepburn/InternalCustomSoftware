using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQLServerUtility
{
    public partial class InstanceDetails : Form
    {
        SqlDataAdapter da;

        public InstanceDetails()
        {
            InitializeComponent();
        }

        private void InstanceDetails_Load(object sender, EventArgs e)
        {
            label1.Text = "Details for " + g.instance;

            SqlConnection cnxn = new SqlConnection(g.db);

            try
            {
                da = new SqlDataAdapter(
                    "DECLARE @props TABLE (propertyname sysname PRIMARY KEY) " +
                    "INSERT INTO @props(propertyname) " +
                    "SELECT 'ServerName' " +
                    "UNION " +
                    "SELECT 'Edition' " +
                    "UNION " +
                    "SELECT 'InstanceName' " +
                    "UNION " +
                    "SELECT 'FilestreamShareName' " +
                    "UNION " +
                    "SELECT 'ProductVersion'" +
                    "SELECT propertyname, SERVERPROPERTY(propertyname) value FROM @props", cnxn);

                DataTable table = new DataTable();
                da.Fill(table);

                DGV.DataSource = table;
                DGV.Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 | e.ColumnIndex == -1)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.instance = cell.EditedFormattedValue.ToString().Trim();
                //cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                //g.iDescription = cell.EditedFormattedValue.ToString().Trim();
                //cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                //g.iRevision = cell.EditedFormattedValue.ToString().Trim();

                DatabaseDetails dd = new DatabaseDetails();
                dd.ShowDialog();

                //if (g.item == "8040-0130-01" | g.item == "8080-0363-32")
                //{
                //    F2A_Special_SN f2a = new F2A_Special_SN();
                //    f2a.ShowDialog();
                //}
                //else
                //{
                //    F2_Label_Details f2 = new F2_Label_Details();
                //    f2.Show();
                //}
            }
        }
    }
}
