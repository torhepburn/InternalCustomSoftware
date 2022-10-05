using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiliconExpertBOMList
{
    public partial class BOMList : Form
    {
        SqlConnection cnxn;
        SqlDataReader dr;

        public BOMList()
        {
            InitializeComponent();
        }

        private void BOMList_Load(object sender, EventArgs e)
        {
            this.Text = "Silicon Expert v" + Application.ProductVersion;

            GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbAdd.Text.Length > 0)
            {
                cnxn = new SqlConnection(g.dbDash);

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO SiliconExpertData " +
                    "([Assembly], [Product Group]) values " +
                    "('" + tbAdd.Text.Trim() + "','" + g.ProductGroup + "')", cnxn);

                try
                {
                    cnxn.Open();

                    int x = cmd.ExecuteNonQuery();

                    if (x == 1)
                    {
                        tbAdd.Text = string.Empty;
                        GetData();
                    }
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
            else
            {
                MessageBox.Show("Can not add blank record.");
            }
        }

        private void GetData()
        {
            cnxn = new SqlConnection(g.dbDash);

            SqlCommand cmd = new SqlCommand(
                "SELECT " +
                "Assembly " +
                "FROM SiliconExpertData where [Product Group] = '" + g.ProductGroup + "' " +
                "ORDER BY Assembly", cnxn);

            DataTable table = new DataTable();

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();
                table.Load(dr);
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

            DGV.Columns[0].Width = 120;

            DGV.Show();

            LRecordCount.Text = "RECORD COUNT: " + (DGV.RowCount - 1).ToString();
        }
                

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == -1)
            {
                return;
            }
            else
            {
                if (cbDelete.Checked)
                {
                    DataGridViewTextBoxCell cell =
                        (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                    g.assembly = cell.EditedFormattedValue.ToString().Trim();

                    DialogResult result = MessageBox.Show("Are you sure you want to delete " + g.assembly + "?","DELETE",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        cnxn = new SqlConnection(g.dbDash);

                        SqlCommand cmd = new SqlCommand(
                            "DELETE FROM SiliconExpertData " +
                            "WHERE [Assembly] = '" + g.assembly + "'", cnxn);

                        try
                        {
                            cnxn.Open();
                            cmd.ExecuteNonQuery();
                            cbDelete.Checked = false;
                            GetData();
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

                    if (result == DialogResult.No)
                    {
                        GetData();
                    }

                }
            }
        }
    }
}
