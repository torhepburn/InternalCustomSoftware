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

namespace Test2
{
    public partial class SelectedPackingList : Form
    {
        SqlDataReader dr;
        SqlCommand cmd;
        SqlConnection cnxn;
        
        public SelectedPackingList()
        {
            InitializeComponent();
        }

        private void SelectedPackingList_Load(object sender, EventArgs e)
        {
            rbCopy.Visible = false;

            GetData();

            DGV.Columns[0].Visible = false;
            DGV.Columns[1].Visible = false;
            DGV.Columns[2].Visible = false;
            DGV.Columns[3].Visible = false;
            DGV.Columns[4].Width = 120;
            DGV.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.Columns[5].Width = 300;
            DGV.Columns[6].Width = 80;
            DGV.Columns[7].Width = 80;
            DGV.Columns[8].Width = 120;
            DGV.Columns[9].Width = 120;
            DGV.Show();
        }

        private void GetData()
        {
            cnxn = new SqlConnection(g.db);

            cmd  = new SqlCommand("SELECT " +
                         "  uid " +
                         ",[documentnumber] " +
                         ",[revision] " +
                         ",[pldescription] " +
                         ",[item_code] [Item Code] " +
                         ",[Description] " +
                         ",[Quantity] " +
                         ",[Boxes] " +
                         ",[Installon] [Install on]" +
                         ",[kitwith] [Kit with] " +
                         "FROM Labels_PackingLists where Documentnumber = '" + g.document + "' " +
                         "AND revision = '" + g.RevToEdit + "'", cnxn);
            
            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                DGV.DataSource = dt;
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

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 10)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.UID = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[4];
                g.itemCode = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[5];
                g.itemDescription = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[6];
                g.iQuantity = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[7];
                g.numberofBoxes = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[8];
                g.installOn = cell.EditedFormattedValue.ToString().Trim();

                cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[9];
                g.kitWith = cell.EditedFormattedValue.ToString().Trim();

                if (rbEdit.Checked)
                {
                    g.task = "EDIT";
                }

                
                if (rbCopy.Checked)
                {
                    g.task = "COPY";
                }

                if (rbDelete.Checked)
                {
                    g.task = "DELETE";

                    DialogResult result = MessageBox.Show("Are you sure you want to delete " + g.itemCode + " ?", "",
                        MessageBoxButtons.YesNo);

                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        try
                        {
                            if (cnxn.State == ConnectionState.Closed)
                            {
                                cnxn.Open();
                            }
                            
                            SqlCommand cmd = new SqlCommand(
                                "DELETE FROM labels_packinglists WHERE UID = " + g.UID
                                , cnxn);
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

                        GetData();
                    }
                                     
                }

                if (g.task == "EDIT")
                {
                    LineData d = new LineData();
                    d.ShowDialog();
                }

                GetData();
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            g.task = "ADD";

            LineData d = new LineData();
            d.ShowDialog();

            GetData();
        }
    }
}
