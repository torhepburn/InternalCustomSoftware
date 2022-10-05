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

namespace OpenPOreports
{
    public partial class OpenPO_Supplier : Form
    {
        SqlConnection cnxn;
        DataTable table;
        private string SQL;

        public OpenPO_Supplier()
        {
            InitializeComponent();
        }

        private void OpenPO_Supplier_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection("server = CT-MID-SQL01; password = Read+Write!; " +
                    "user = readwrite; database = AccessFrontEnds;");

            refresh();
        }

        private void BgetData_Click(object sender, EventArgs e)
        {
            if (tbSupplierName.Text.Length > 0)
            {
                SQL = "AND Supplier_Name like '%" + tbSupplierName.Text.Trim() + "%' ";
            }

            if (tbSupplierNumber.Text.Length > 0)
            {
                SQL += "AND Supplier = " + tbSupplierNumber.Text.Trim() + " ";
            }

            if (tbItemCode.Text.Length > 0)
            {
                SQL += "AND Item_Code like '%" + tbItemCode.Text.Trim() + "%' ";
            }

            if (tbDays.Text.Length > 0)
            {
                SQL += "AND POLineDaysTillDue <= " + tbDays.Text.Trim() ;
            }

            refresh();
        }

        private void refresh()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    " SELECT * " +
                    " FROM Shortages_Open_PO_Lines_Supplier" +
                    " WHERE 1=1 " + SQL + " ", cnxn);

                table = new DataTable();

                da.Fill(table);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }
            DGV.DataSource = table;
            DGV.Show();

        }
    }
}
