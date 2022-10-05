using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace StatusAdjustmentRequired
{
    public partial class PotentialAdjustments : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;

        public PotentialAdjustments()
        {
            InitializeComponent();
        }

        private void PotentialAdjustments_Load(object sender, EventArgs e)
        {
            this.Text = "Operation did not run one day ago";

            GetData();
        }

        private void GetData()
        {
            cnxn = new SqlConnection(g.db);

            da = new SqlDataAdapter
                ("select * from backonenorun " +
                "order by sfo", cnxn);

            try
            {
                DataTable table = new DataTable();
                da.Fill(table);
                DGV.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            DGV.Show();

            DGV.Columns[0].Width = 40;
            DGV.Columns[1].Width = 60;
            DGV.Columns[2].Width = 40;
            DGV.Columns[3].Width = 70;
            DGV.Columns[4].Width = 70;
            DGV.Columns[5].Width = 70;
            DGV.Columns[6].Width = 70;
            DGV.Columns[7].Width = 70;
            DGV.Columns[8].Width = 70;
            DGV.Columns[9].Width = 150;
            DGV.Columns[10].Width = 150;
            DGV.Columns[11].Width = 60;
            DGV.Columns[12].Width = 60;
            DGV.Columns[13].Visible = false;

            label1.Text = "Count = " + DGV.Rows.Count.ToString();
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 | e.ColumnIndex < 1)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[8];
                g.customer = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[9];
                g.project = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[10];
                g.element = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[12];
                g.item_code = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[13];
                g.jobID = cell.EditedFormattedValue.ToString().Trim();

                MaintainSchedulesLocal ms = new MaintainSchedulesLocal();
                ms.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bData.BackColor = Color.Gray;
            label1.Text = "Updating Data";
            this.Enabled = false;
            SQL();
            return;

        }

        private void SQL()
        {
            cnxn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnxn;
            cmd.CommandText = "spCapacity";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 100;
            cmd.ExecuteNonQuery();
            bData.BackColor = Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.Enabled = true;
        }

    }
}
