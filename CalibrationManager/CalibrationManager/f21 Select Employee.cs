using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CalibrationManager
{
    public partial class f21_Select_Employees : Form
    {
        SqlDataAdapter da;
        BindingSource bs = new BindingSource();
        SqlConnection cnxn;
        SqlCommand cmd;
        private string Ename;
        
        public f21_Select_Employees()
        {
            InitializeComponent();
        }

        private void f21_Select_Employees_Load(object sender, EventArgs e)
        {
            getData("Select Name, BadgeID, Email " +
                    " from dbo.view_employees where " +
                    " badgeid > 0 order by name");
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex == -1 && (e.ColumnIndex == -1 | e.ColumnIndex == 0))
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.eBadgeID = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                Ename = cell.EditedFormattedValue.ToString().Trim();

                if (g.item == "Location")
                {
                    cmd = new SqlCommand("Update location " +
                    " set l_owner = " + g.eBadgeID + " where " +
                    " l_id = '" + g.location + "'");

                    cnxn = new SqlConnection(g.db);
                    cmd.Connection = cnxn;
                    cnxn.Open();
                    int rowsReturned = cmd.ExecuteNonQuery();
                    cnxn.Close();
                    g.location = "";
                    Close();
                }
                if (g.item == "EmailOne")
                {
                    f06_Select_Email sem = new f06_Select_Email();
                    sem.Show();
                    Close();
                }
                if (g.item == "Equipment")
                {
                    g.internalCalContact = Convert.ToInt32(g.eBadgeID);
                    Close();
                }
                if (g.item == "NewUser")
                {
                    f053_Access_Rights f053 = new f053_Access_Rights(Ename);
                    f053.Show();
                    Close();
                }
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            getData("Select Name, BadgeID, Email " +
                    " from dbo.view_employees where " +
                    " badgeid > 0 and name like '%" + tbSearch.Text + "%'");
        }

        private void getData(string select)
        {
            cnxn = new SqlConnection
                (g.dbDashserver);
            DGV.Show();
            DGV.DataSource = bs;

            try
            {
                da = new SqlDataAdapter(select, cnxn);
                DataTable table = new DataTable();
                da.Fill(table);
                bs.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            DGV.Columns[1].Visible = false;
            DGV.Columns[2].Visible = false;
        }
    }
}