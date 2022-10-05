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

namespace EditEmployeeCovidData
{
    public partial class Contractors : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        SqlDataReader dr;
        private int UID = 0;

        public Contractors()
        {
            InitializeComponent();
        }

        private void Contractors_Load(object sender, EventArgs e)
        {
            bUpdate.BackColor = Color.Gray;
            GetData();
        }

        private void GetData()
        {
            cnxn = new SqlConnection(g.db);
            cmd = new SqlCommand("SELECT " +
                " TRIM(Name) Name " +
                ",TRIM(Company) [Company] " +
                ",TRIM(Contact) [Contact] " +
                ",CovidTestDate [COVID Test Date]" +
                ",ID " +
                "FROM Contractors " +
                "ORDER BY Name ", cnxn);
            try
            {
                cnxn.Open();

                dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);

                DGV.DataSource = dt;

                DGV.Columns[0].Width = 150;
                DGV.Columns[1].Width = 200;
                DGV.Columns[2].Width = 120;
                DGV.Columns[4].Visible = false;
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

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            try
            {
                cmd = new SqlCommand("SELECT " +
                " TRIM(Name) Name " +
                ",TRIM(Company) [Company] " +
                ",TRIM(Contact) [Contact] " +
                ",CovidTestDate [COVID Test Date]" +
                ",ID " +
                "FROM Contractors " +
                "WHERE (Name like '%" + tbSearchEquipment.Text + "%'" +
                "OR Company like '%" + tbSearchEquipment.Text + "%' " +
                "OR Contact like '%" + tbSearchEquipment.Text + "%') " +
                "ORDER BY Name ", cnxn);

                cnxn.Open();

                dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);

                DGV.DataSource = dt;
                DGV.Columns[0].Width = 150;
                DGV.Columns[1].Width = 200;
                DGV.Columns[2].Width = 120;
                DGV.Columns[4].Visible = false;

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

            //tbSearchEquipment.Text = string.Empty;
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 3)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                tbTestDate.Text = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                tbName.Text = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                tbCompany.Text = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                tbContact.Text = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[4];
                UID = Convert.ToInt32(cell.EditedFormattedValue.ToString());
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            tbTestDate.Text = monthCalendar1.SelectionStart.ToShortDateString();
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {

            SqlParameter pName = new SqlParameter("@name", SqlDbType.VarChar);
            pName.Value = tbName.Text;

            SqlParameter pCompany = new SqlParameter("@company", SqlDbType.VarChar);
            pCompany.Value = tbCompany.Text;

            SqlParameter pContact = new SqlParameter("@contact", SqlDbType.VarChar);
            pContact.Value = tbContact.Text;

            if (cbAdd.Checked)
            {
                cmd = new SqlCommand(
                        "INSERT INTO Contractors " +
                        "(Name, Company, Contact, CovidTestDate) VALUES (" +
                        pName +
                        "," + pCompany +
                        "," + pContact +
                        ",'" + tbTestDate.Text.Trim() + "') ", cnxn);
            }
            else
            {
                cmd = new SqlCommand(
                        "UPDATE Contractors " +
                        "SET CovidTestDate = '" + tbTestDate.Text.Trim() + "' " +
                        ",Name = " + pName +
                        ",Company = " + pCompany +
                        ",Contact = " + pContact + " " +
                        "WHERE ID = " + UID + " ", cnxn);
            }

            if (cbDelete.Checked)
            {
                cmd = new SqlCommand(
                            "DELETE FROM Contractors " +
                            "WHERE ID = " + UID + " ", cnxn);
            }

            cnxn.Open();

            try
            {
                cmd.Parameters.Add(pName);
                cmd.Parameters.Add(pCompany);
                cmd.Parameters.Add(pContact);
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
            }



            tbName.Text = string.Empty;
            tbCompany.Text = string.Empty;
            tbContact.Text = string.Empty;
            //tbTestDate.Text = string.Empty;
        }

        private void cbDelete_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDelete.Checked)
            {
                bUpdate.Text = "DELETE";
                bUpdate.BackColor = Color.Red;
            }
            else
            {
                bUpdate.Text = "UPDATE";
                bUpdate.BackColor = Color.Gray;
            }

        }
    }
}
