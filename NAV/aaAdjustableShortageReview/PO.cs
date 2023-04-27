using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace aaAdjustableShortageReview
{
    public partial class PO : Form
    {
        SqlConnection cnxn;
        public PO()
        {
            InitializeComponent();
        }

        private void PO_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.dbNAV);

            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT " +
                "l.[Document No_] [Order No] " +
                ",l.[PO Line No_] [PO Line No] " +
                ",l.[Job No_] [Job No] " +
                ",CONVERT(varchar(10), l.[Orig_ Requested Receipt Date],101) [Orig_ Requested Receipt Date] " +
                ",s.Name Vendor " +
                ",FORMAT(l.Quantity, '##.##') as Quantity " +
                ",CONVERT(varchar(10), l.[Planned Receipt Date],1) [Planned Receipt Date] " +
                ",H.[Purchaser Code] " +
                "FROM [" + g.NAVprefix + "Purchase Line] l " +
                "INNER JOIN [ZYGO$Purchase Header] H on H.No_ = l.[Document No_] " +
                "inner join [" + g.NAVprefix + "Vendor] s on l.[Buy-from Vendor No_] = s.No_ " +
                "WHERE  l.[Outstanding Quantity] > 0 and l.No_ = '" + g.itemCode + "' " +
                "order by l.[Promised Receipt Date] ", cnxn);
                      
            DataTable dt3 = new DataTable();
            dt3.Rows.Add();
            dt3.AcceptChanges();

            try
            {
                da.Fill(dt3);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }
            DGV.DataSource = dt3;

            DGV.Columns[0].Width = 80;
            DGV.Columns[1].Width = 80;
            DGV.Columns[2].Width = 80;
            DGV.Columns[4].Width = 320;
            DGV.Columns[6].Visible = false;
            DGV.Columns[7].Visible = false;
            DGV.Show();

            cnxn.Close();
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
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.PO = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                g.origRqstRcptDate = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[4];
                g.Supplier = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[5];
                g.PoQuantity = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[6];
                g.PlannedReceiptDate = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[7];
                g.PurchaserCode = cell.EditedFormattedValue.ToString().Trim();
            }
            this.Close();
        }
    }
}
