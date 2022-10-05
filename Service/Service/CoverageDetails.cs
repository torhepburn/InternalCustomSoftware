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
    public partial class CoverageDetails : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable dt;

        public CoverageDetails()
        {
            InitializeComponent();
        }

        private void CoverageDetails_Load(object sender, EventArgs e)
        {
            Lcustomer.Text = "Customer: " + g.customer;
            Lcontract.Text = "Contract #: " +g.contract;
            Lregion.Text = "Region: " + g.region;
            Ltype.Text = "Type: " + g.type;
            Lexpiration.Text = "Expiration: " + g.expiration;
            Llocation.Text = "Location: " + g.location;
            
            cnxn = new SqlConnection(g.db);

            da = new SqlDataAdapter(
                "select description Model, " +
                "Serial_No " +
                "from MMX_EQUIPMENT_MASTER where LTRIM(contract) = '" + g.contract + "'", cnxn);


            try
            {
                dt = new DataTable();

                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DGV.DataSource = dt;

            DGV.Columns[0].Width = 200;

            DGV.Show();
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
                g.model = cell.EditedFormattedValue.ToString();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.sn = cell.EditedFormattedValue.ToString();

                EquipmentHistory h = new EquipmentHistory();
                h.ShowDialog();
            }
        }
    }
}
