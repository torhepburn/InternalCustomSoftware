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

namespace NDA
{
    public partial class RestrictedAccessEmployees : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        private string employee;
        public RestrictedAccessEmployees()
        {
            InitializeComponent();
        }

        private void RestrictedAccessEmployees_Load(object sender, EventArgs e)
        {
            if (g.Task == "ADD")
            {
                g.NDA_ID = "999";
                /*      
                 *  NDA_ID 999 was never used so we use it as a placeholder and then
                 *  replace it with the real value on NDA Data Entry Form Save.
                */
            }
            
            /*
             * 
             * Employee
             * 
             * */
            SqlConnection cnxnDash = new SqlConnection(g.dbDash);

            da = new SqlDataAdapter(
                 "select distinct NAME from view_employees_all " +
                 "where status = 1 " +
                 "order by name ", cnxnDash);

            DataTable dt1 = new DataTable();
            dt1.Rows.Add();
            dt1.AcceptChanges();
            
            try
            {
                da.Fill(dt1);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxnDash.Close();
            }
            cbddZygoEmployee.DataSource = dt1;
            cbddZygoEmployee.DisplayMember = "Name";

            loadGrid();
        }

        private void Badd_Click(object sender, EventArgs e)
        {
            if (cbddZygoEmployee.Text.Length > 0)
            {

                SqlParameter pEmployeeName = new SqlParameter
                    ("@EmployeeName", SqlDbType.NChar);
                pEmployeeName.Value = cbddZygoEmployee.Text;

                cnxn = new SqlConnection(g.db);

                SqlCommand cmd = new SqlCommand(

                    "Insert into RestrictedAccess " +
                    "(NDA_ID " +
                    ",EmployeeName) " +
                    "values (" +
                    g.NDA_ID + "," +
                    pEmployeeName + ")", cnxn);

                cmd.Parameters.Add(pEmployeeName);

                try
                {
                    cnxn.Open();
                    int row = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }

                loadGrid();
            }
        }

        private void loadGrid()
        {
            cnxn = new SqlConnection(g.db);

            da = new SqlDataAdapter(
                 " select EmployeeName from RestrictedAccess " +
                 " WHERE NDA_ID = " + g.NDA_ID + 
                 " order by EmployeeName", cnxn);

            DataTable dt1 = new DataTable();
           

            try
            {
                da.Fill(dt1);
                DGV.DataSource = dt1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }

            DGV.Columns[0].Width = 175;
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                employee = cell.EditedFormattedValue.ToString().Trim();
            }
        }

        private void Bdelete_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            SqlParameter pEmployeeName = new SqlParameter
                ("@EmployeeName", SqlDbType.NChar);
            pEmployeeName.Value = employee;
            
            SqlCommand cmd = new SqlCommand(

                "Delete from RestrictedAccess " +
                "WHERE NDA_ID = " + g.NDA_ID + " " +
                "AND EmployeeName = " + pEmployeeName , cnxn);

            cmd.Parameters.Add(pEmployeeName);
           

            try
            {
                cnxn.Open();
                int row = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            loadGrid();
        }
    }


}
