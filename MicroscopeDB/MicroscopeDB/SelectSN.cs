using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MicroscopeDB
{
    public partial class SelectSN : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        private string SQL = "Select SN, endcustomer [End Customer], id, datecode from microscopedata ";

        public SelectSN()
        {
            InitializeComponent();
        }

        private void SelectSN_Load(object sender, EventArgs e)
        {
            LproductLine.Text = g.ProductLine;

            if (g.task == "Edit")
            {
                rbAPCAL.Visible = false;
                rbATP.Visible = false;
                this.Text = "Select SN to Edit";
            }

            if (g.task == "View")
            {
                rbDelete.Visible = false;
                this.Text = "Select SN to View";
            }

            if (g.task == "Add")
            {
                rbDelete.Visible = false;
                rbAPCAL.Visible = false;
                rbATP.Visible = false;
                rbSystem.Visible = false;
                rbAccessories.Checked = true;
                this.Text = "Select SN for Adding Accessory";
            }



            if (g.ProductLine.Substring(0,6) == "ZeGage" ) //| g.ProductLine == "ZeGagePlus" )
            {
                rbAPCAL.Visible = false;
            }

            getData();
        }

        private void getData()
        {
            cnxn = new SqlConnection(g.db);

            da = new SqlDataAdapter
                (SQL +
                 " where productline = '" + g.ProductLine + "' " +
                 " order by SN DESC", cnxn);


            DataTable table = new DataTable();
            da.Fill(table);

            DGV.DataSource = table;

            DGV.Columns[0].Width = 80;
            DGV.Columns[1].Width = 280;
            DGV.Columns[2].Visible = false;
            DGV.Columns[3].Visible = false;

            DGV.Show();

        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 | e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.serialNumber = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.DataID = Convert.ToInt32(cell.EditedFormattedValue.ToString().Trim());

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                g.DateCode = cell.EditedFormattedValue.ToString().Trim();

                selectionChoice();
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                (SQL +
                 " where productline = '" + g.ProductLine + "' " +
                 " and EndCustomer like '%" + tbSearchEquipment.Text + "%' " +
                 " order by id DESC", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            
            DGV.DataSource = table;

            DGV.Columns[2].Visible = false;
        }

        private void bItem_Click(object sender, EventArgs e)
        {
            g.serialNumber = tbSearchEquipment.Text.ToString().Trim().ToUpper();
            
            cnxn = new SqlConnection(g.db);

            SqlDataAdapter da = new SqlDataAdapter(SQL +
                 " where sn = '" + g.serialNumber + "' ", cnxn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("This item does not exist.");
                tbSearchEquipment.Text = string.Empty;
                tbSearchEquipment.Focus();
            }
            else
            {
                g.DataID = Convert.ToInt32(dt.Rows[0][2].ToString());
                g.DateCode = dt.Rows[0][3].ToString();
                selectionChoice();
            }
        }

        private void selectionChoice()
        {
            if (rbSystem.Checked)
            {
                SystemInfo i = new SystemInfo();
                i.ShowDialog();
            }
            else if (rbAccessories.Checked)
            {
                if (g.task == "Add")
                {
                    AccessoryAddEdit ae = new AccessoryAddEdit();
                    ae.ShowDialog();
                }
                else
                {
                    Accessories a = new Accessories();
                    a.ShowDialog();
                }
            }
            else if (rbATP.Checked)
            {
                ATP t = new ATP();
                t.ShowDialog();
            }
            else if (rbAPCAL.Checked)
            {
                APCAL c = new APCAL();
                c.ShowDialog();
            }
            else if (rbDelete.Checked)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete " + g.serialNumber + "","Delete Item?" ,MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("DELETE from MicroscopeData WHERE SN = '" + g.serialNumber + "'", cnxn);

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
                    }
                    rbDelete.Checked = false;
                    getData();
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbDelete_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDelete.Checked)
            {
                this.BackColor = Color.Red;
            }

            if (rbDelete.Checked == false)
            {
                this.BackColor = Color.FromArgb(120, 190, 140);
            }
        }
    }
}
