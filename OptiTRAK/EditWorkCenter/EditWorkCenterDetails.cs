using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EditWorkCenter
{
    public partial class EditWorkCenterDetails : Form
    {
        SqlConnection cnxn;
        
        public EditWorkCenterDetails()
        {
            InitializeComponent();
        }

        private void EditWorkCenterDetails_Load(object sender, EventArgs e)
        {
            tbWorkCenter.Text = g.workcell;
            tbWorkCenter.ReadOnly = true;

            cnxn = new SqlConnection(g.db);

            SqlDataAdapter da = new SqlDataAdapter(
                "select " +
                "DeptDescription, " +
                "CostCenter, " +
                "CostCenterDesc, " +
                "Capacity " +
                "from tblDept where DeptCode = '" +
                g.workcell + "'", cnxn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            tbWCdescription.Text = dt.Rows[0][0].ToString();
            tbCostCenter.Text = dt.Rows[0][1].ToString();
            tbCostCenterDescription.Text = dt.Rows[0][2].ToString();
            tbCapacity.Text = dt.Rows[0][3].ToString();
        }

        private void bENTER_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Int32.Parse(tbCapacity.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Must enter a whole number (integer).");
                tbCapacity.Focus();
                return;
            }

            SqlCommand cmd = new SqlCommand(
                "Update tblDept " +
                "set " +
                "DeptDescription = '" + tbWCdescription.Text.Trim() +
                "', CostCenter = '" + tbCostCenter.Text.Trim() +
                "', CostCenterDesc = '" + tbCostCenterDescription.Text.Trim() +
                "', Capacity = " + tbCapacity.Text.Trim() + " " +
                "where DeptCode = '" +
                g.workcell + "'", cnxn);

            try
            {
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            
            this.Close();
        }
    }
}
