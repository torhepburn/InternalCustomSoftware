using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MaintainSchedules
{
    public partial class HoldStatusSelector : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;

        public HoldStatusSelector()
        {
            InitializeComponent();
        }

        private void HoldStatusSelector_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable(); ;

            cnxn = new SqlConnection(g.db);

            da = new SqlDataAdapter(
                "select processstatusid, pstatusdesc Status " +
                "from tblProcessStatus " +
                "where processstatusid > 3 " +
                "order by pstatusdesc", cnxn);
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //searchFunction = "";
            }

            DGV.DataSource = dt;

            DGV.Columns[0].Visible = false;
            DGV.Columns[1].Width = 200;
            
            DGV.Show();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 | e.ColumnIndex < 1)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.holdStatusID = cell.EditedFormattedValue.ToString().Trim();

                SqlCommand cmd = new SqlCommand(
                    "update tblPartSN set holdstatid = " + g.holdStatusID + " " +
                    "where PartID = " + g.partid + " ", cnxn);

                try
                {
                    cnxn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                    Close();
                }
            }
        }
    }
}
