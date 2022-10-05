using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CustomTooling
{
    public partial class F2_ToolList : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;

        public F2_ToolList()
        {
            InitializeComponent();
        }

        private void F2_ToolList_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = "F2 " + g.task;

            cnxn = new SqlConnection(g.db);

            viewUpToDate();
            //da = new SqlDataAdapter
            //    ("Select toolnumber, [Description], DesignEngineer, department, " +
            //     "pn_or_product, proj_or_cc from customtooling " +
            //     " order by toolnumber desc", cnxn);
            
            //DataTable table = new DataTable();
            
            //da.Fill(table);
            //DGV.DataSource = table;

            DGV.Columns[0].Width = 100;
            DGV.Columns[1].Width = 250;
            DGV.Columns[2].Width = 200;
            DGV.Columns[3].Width = 150;
            DGV.Columns[4].Width = 200;
            DGV.Columns[5].Width = 100;
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                ("Select toolnumber, [Description], DesignEngineer, department, " +
                 "pn_or_product, proj_or_cc from customtooling " +
                 " where " +
                 " toolnumber like '%" + tbSearchEquipment.Text + "%' " +
                 "or [description] like '%" + tbSearchEquipment.Text + "%' " +
                 "or pn_or_product like '%" + tbSearchEquipment.Text + "%' " +
                 "or department like '%" + tbSearchEquipment.Text + "%' " +
                 "or proj_or_cc like '%" + tbSearchEquipment.Text + "%' " +
                 " order by toolnumber desc", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            tbSearchEquipment.Text = "";
        }

        private void bItem_Click(object sender, EventArgs e)
        {
            g.toolNumber = tbSearchEquipment.Text.ToString().Trim().ToUpper();
            tbSearchEquipment.Text = "";
            cnxn = new SqlConnection(g.db);
            SqlCommand cmd = new SqlCommand
                ("Select toolnumber from customtooling " +
                "where toolnumber = '" + g.toolNumber + "'", cnxn);
            cnxn.Open();
            object o = cmd.ExecuteScalar();

            if (o == null)
            {
                MessageBox.Show("This item does not exist.");
                tbSearchEquipment.Focus();
            }
            else
            {
                F1_Add_Tool f1 = new F1_Add_Tool();
                f1.ShowDialog();
            }
            viewUpToDate();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 6)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.toolNumber = cell.EditedFormattedValue.ToString().Trim();

                F1_Add_Tool f1 = new F1_Add_Tool();
                f1.ShowDialog();
            }
            viewUpToDate();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewUpToDate()
        {
            try
            {
                da = new SqlDataAdapter
                ("Select toolnumber, [Description], DesignEngineer, department, " +
                 "pn_or_product, proj_or_cc from customtooling " +
                 " order by toolnumber desc", cnxn);
                DataTable table = new DataTable();
                da.Fill(table);
                DGV.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnxn.Close();
        }

        
    }
}
