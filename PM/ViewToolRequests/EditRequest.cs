using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ViewToolRequests
{
    public partial class EditRequest : Form
    {
        SqlConnection cnxn;


        public EditRequest()
        {
            InitializeComponent();
        }

        private void EditRequest_Load(object sender, EventArgs e)
        {
            LID.Text = "Tool Room Request ID #  " + g.ID;

            cnxn = new SqlConnection(g.dbDash);

            SqlCommand cmd = new SqlCommand(
                "SELECT Name FROM " +
                "MIDDB01.Dashboard.dbo.view_employees " +
                "WHERE badgeID is not null " +
                "ORDER BY Name", cnxn);

            try
            {
                cnxn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cbddRequestor.Items.Add(dr["Name"].ToString());
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

            cnxn = new SqlConnection(g.db);

            cmd = new SqlCommand(
                "Select " +
                "priority " +
                ",request_need_date " +
                ",requestor " +
                ",[type] " +
                ",quantity " +
                ",timesavingsestimate " +
                ",costsavingsestimate " +
                ",request_text " +
                "from tool_requests where " +
                "id = " + g.ID + " ", cnxn);

            try
            {
                cnxn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(dr);
                {
                    cbddPriority.Text = table.Rows[0][0].ToString();
                    dtpDateNeeded.Text = table.Rows[0][1].ToString();
                    cbddRequestor.Text = table.Rows[0][2].ToString();
                    cbddType.Text = table.Rows[0][3].ToString();
                    tbQuantity.Text = table.Rows[0][4].ToString();
                    tbTimeSavingsEstimate.Text = table.Rows[0][5].ToString();
                    tbCostSavingsEstimate.Text = table.Rows[0][6].ToString();
                    tbRequest.Text = table.Rows[0][7].ToString();
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

        private void Benter_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter pName = new SqlParameter("@name", SqlDbType.VarChar, 100);
                pName.Value = cbddRequestor.Text.Trim();

                SqlParameter pRequest_Text = new SqlParameter("@request_text", SqlDbType.VarChar, 4000);
                pRequest_Text.Value = tbRequest.Text.Trim();

                SqlCommand cmd = new SqlCommand(
                    "Update Tool_Requests  set " +
                    "priority = '" + cbddPriority.Text.Trim() +
                    "',request_need_date = '" + dtpDateNeeded.Value +
                    "',requestor = " + pName +
                    ",[type] = '" + cbddType.Text.Trim() +
                    "',quantity = '" + tbQuantity.Text.Trim() + 
                    "',timesavingsestimate = '" + tbTimeSavingsEstimate.Text.Trim()  +
                    "',costsavingsestimate = '" + tbCostSavingsEstimate.Text.Trim() +
                    "',revenuesavingsestimate = '" + tbRevenueSavingsEstimate.Text.Trim() +
                    "',request_text = " + pRequest_Text +
                    " where id = " + g.ID + " ", cnxn);

                cnxn.Open();
                cmd.Parameters.Add(pName);
                cmd.Parameters.Add(pRequest_Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            this.Close();
        }

        private void Bexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
