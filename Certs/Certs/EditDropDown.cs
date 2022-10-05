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

namespace Certs
{
    public partial class EditDropDown : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        private string UID = string.Empty;

        public EditDropDown()
        {
            InitializeComponent();
        }

        private void EditDropDown_Load(object sender, EventArgs e)
        {
            bAdd.Text = "ADD " + g.adminTask;
            
            GetData();
        }

        private void GetData()
        {
            cnxn = new SqlConnection(g.db);

            cmd = new SqlCommand(
                "SELECT Value, UID FROM Cert_DropDowns " +
                "WHERE DisplayField = '" + g.adminTask + "'", cnxn);

            try
            {
                cnxn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(dr);

                DGV.DataSource = table;
                DGV.Columns[0].Width = 500;
                DGV.Columns[1].Visible = false;
                DGV.Show();

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

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (tbAdd.Text.Length > 0 & UID == string.Empty)
            {
                SqlParameter pValue = new SqlParameter("@value", SqlDbType.VarChar);
                pValue.Value = tbAdd.Text.Trim();

                cmd = new SqlCommand(
                    "INSERT INTO Cert_DropDowns " +
                    "(DisplayField, Value) values (" +
                    "'" + g.adminTask + "'" +
                    "," + pValue + ")", cnxn);

                try
                {
                    cmd.Parameters.Add(pValue);
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
                    cmd.Parameters.Clear();
                    tbAdd.Text = string.Empty;
                }
                    
                    
            }
            else
            {
                if (tbAdd.Text.Length < 1)
                {
                    MessageBox.Show("Can not add blank entry");
                    tbAdd.Focus();
                }

                if (UID.Length > 0)
                {
                    MessageBox.Show("Can not ADD edited text.");
                    tbAdd.Focus();
                }
            }

            GetData();
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            if (UID.Length > 0)
            {
                SqlParameter pValue = new SqlParameter("@value", SqlDbType.VarChar);
                pValue.Value = tbAdd.Text.Trim();

                cmd = new SqlCommand(
                    "UPDATE Cert_DropDowns " +
                    "SET Value = @value " +
                    "WHERE UID = " + UID + " ", cnxn);

                try
                {
                    cmd.Parameters.Add(pValue);
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
                    cmd.Parameters.Clear();
                    tbAdd.Text = string.Empty;
                }

                GetData();
            }
        }

            

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                tbAdd.Text = cell.EditedFormattedValue.ToString().Trim();

                cell =
                   (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                UID = cell.EditedFormattedValue.ToString().Trim();
                //action();
            }

        }
    }
}
