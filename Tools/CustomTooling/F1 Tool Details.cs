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
    public partial class F1_Add_Tool : Form
    {
        SqlConnection cnxn = new SqlConnection(g.db);
        SqlCommand cmd;
        private float FloatValueTransferVariable;

        public F1_Add_Tool()
        {
            InitializeComponent();
        }

        private void F1_Add_Tool_Load(object sender, EventArgs e)
        {
            this.Text = g.task;

            //try
            //{
            //    cnxn.Open();
            //    cmd = new SqlCommand("SELECT cn from applicationsetup a " +
            //        "INNER JOIN EmployeesAmetekAD e ON a.UserName = e.loginName" +
            //        "where Application = 'custom tooling' and permission = 'EDIT' and PermissionValue = 'true'", cnxn);
            //    SqlDataReader dr = cmd.ExecuteReader();
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    cnxn.Close();
            //}

            if (g.task == "Find")
            {
                bEnterTNumberData.Visible = false;
                bCopy.Visible = false;
            }

            if (g.task == "Add")
            {
                dtpDateAssigned.Value = DateTime.Now;

                AddNumber();

                bBack.Location = new Point(500, 30);
                bBack.Width = 80;
                bBack.Height = 550;
                bBack.Text = "E\rr\rr\ro\rr\r\rD\ro\r\rN\ro\rt\r\rA\rd\rd";
            }

            if (g.task == "Edit" | g.task == "Find")
            {
                tbToolNumber.Text = g.toolNumber;

                cnxn = new SqlConnection(g.db);
                cmd = new SqlCommand
               ("Select * from customtooling where toolnumber = '" +
                g.toolNumber + "'", cnxn);
                cnxn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                

                while (dr.Read())
                {
                    if (!dr.IsDBNull(1)) { tbDescription.Text = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { tbRevision.Text = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { cbddDepartment.Text = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { tbPNProduct.Text = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { tbProject.Text = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { cbddEngineer.Text = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { tbQuantity.Text = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { dtpDateAssigned.Text = dr.GetDateTime(8).ToShortDateString(); }
                    if (!dr.IsDBNull(9)) { tbCost.Text = dr.GetDecimal(9).ToString(); }
                    
                }
                cnxn.Close();
            }
        
        }

        private void bEnterTNumberData_Click(object sender, EventArgs e)
        {
            if (g.task == "Add" | g.task == "Edit")
            {
                SqlParameter Revision = new SqlParameter("@Revision", SqlDbType.NVarChar, 2);
                Revision.Value = tbRevision.Text.ToString().Trim();

                SqlParameter Description = new SqlParameter("@Description", SqlDbType.NVarChar, 100);
                Description.Value = tbDescription.Text.ToString().Trim();

                SqlParameter Department = new SqlParameter("@Department", SqlDbType.NVarChar, 50);
                Department.Value = cbddDepartment.Text.ToString().Trim();

                SqlParameter PNProduct = new SqlParameter("@PNProduct", SqlDbType.NVarChar, 50);
                PNProduct.Value = tbPNProduct.Text.ToString().Trim();

                SqlParameter Project = new SqlParameter("@Project", SqlDbType.NVarChar, 50);
                Project.Value = tbProject.Text.ToString().Trim();

                SqlParameter Engineer = new SqlParameter("@Engineer", SqlDbType.NVarChar, 30);
                Engineer.Value = cbddEngineer.Text.ToString().Trim();

                SqlParameter Quantity = new SqlParameter("@Quantity", SqlDbType.NVarChar, 10);
                Quantity.Value = tbQuantity.Text.ToString().Trim();

                SqlParameter DateAssigned = new SqlParameter("@DateAsigned", SqlDbType.Date);
                DateAssigned.Value = dtpDateAssigned.Value;

                SqlParameter Cost = new SqlParameter("@Cost", SqlDbType.Money);
                if (tbCost.Text != "0" && tbCost.Text != null && tbCost.Text != "")
                {
                    bool isNum;
                    isNum = float.TryParse(tbCost.Text, out FloatValueTransferVariable);
                    Cost.Value = FloatValueTransferVariable;
                }
                else
                {
                    Cost.Value = DBNull.Value;
                }

                cnxn = new SqlConnection(g.db);
                cmd = new SqlCommand("Update CustomTooling set " +
                "description = " + Description + ", " +
                "rev = " + Revision + ", " +
                "department = " + Department + ", " +
                "pn_or_product = " + PNProduct + ", " +
                "proj_or_cc = " + Project + ", " +
                "designEngineer = " + Engineer + ", " +
                "qty = " + Quantity + ", " +
                "dateAssigned = " + DateAssigned + ", " +
                "cost = " + Cost + " " +
                "where toolnumber = '" + g.toolNumber + "'", cnxn);

                cmd.Parameters.Add(Description);
                cmd.Parameters.Add(Revision);
                cmd.Parameters.Add(Department);
                cmd.Parameters.Add(PNProduct);
                cmd.Parameters.Add(Project);
                cmd.Parameters.Add(Engineer);
                cmd.Parameters.Add(Quantity);
                cmd.Parameters.Add(DateAssigned);
                cmd.Parameters.Add(Cost);

                cnxn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                cnxn.Close();

                cmd.Parameters.Clear();
            }


            //Close();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            if (g.task == "Add")
            {
                cmd = new SqlCommand
                    ("Delete from customtooling where toolnumber = '" + g.toolNumber + "'", cnxn);
                cnxn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                } 
                
                cnxn.Close();

                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            AddNumber();
            
            SqlParameter Revision = new SqlParameter("@Revision", SqlDbType.NVarChar, 2);
                Revision.Value = tbRevision.Text.ToString().Trim();

                SqlParameter Description = new SqlParameter("@Description", SqlDbType.NVarChar, 100);
                Description.Value = tbDescription.Text.ToString().Trim();

                SqlParameter Department = new SqlParameter("@Department", SqlDbType.NVarChar, 50);
                Department.Value = cbddDepartment.Text.ToString().Trim();

                SqlParameter PNProduct = new SqlParameter("@PNProduct", SqlDbType.NVarChar, 50);
                PNProduct.Value = tbPNProduct.Text.ToString().Trim();

                SqlParameter Project = new SqlParameter("@Project", SqlDbType.NVarChar, 50);
                Project.Value = tbProject.Text.ToString().Trim();

                SqlParameter Engineer = new SqlParameter("@Engineer", SqlDbType.NVarChar, 30);
                Engineer.Value = cbddEngineer.Text.ToString().Trim();

                SqlParameter Quantity = new SqlParameter("@Quantity", SqlDbType.NVarChar, 10);
                Quantity.Value = tbQuantity.Text.ToString().Trim();

                SqlParameter DateAssigned = new SqlParameter("@DateAsigned", SqlDbType.Date);
                DateAssigned.Value = dtpDateAssigned.Value;

                SqlParameter Cost = new SqlParameter("@Cost", SqlDbType.Money);
                if (tbCost.Text != "0" && tbCost.Text != null && tbCost.Text != "")
                {
                    bool isNum;
                    isNum = float.TryParse(tbCost.Text, out FloatValueTransferVariable);
                    Cost.Value = FloatValueTransferVariable;
                }
                else
                {
                    Cost.Value = DBNull.Value;
                }

                cnxn = new SqlConnection(g.db);
                cmd = new SqlCommand("Update CustomTooling set " +
                "description = " + Description + ", " +
                "rev = " + Revision + ", " +
                "department = " + Department + ", " +
                "pn_or_product = " + PNProduct + ", " +
                "proj_or_cc = " + Project + ", " +
                "designEngineer = " + Engineer + ", " +
                "qty = " + Quantity + ", " +
                "dateAssigned = " + DateAssigned + ", " +
                "cost = " + Cost + " " +
                "where toolnumber = '" + g.toolNumber + "'", cnxn);

                cmd.Parameters.Add(Description);
                cmd.Parameters.Add(Revision);
                cmd.Parameters.Add(Department);
                cmd.Parameters.Add(PNProduct);
                cmd.Parameters.Add(Project);
                cmd.Parameters.Add(Engineer);
                cmd.Parameters.Add(Quantity);
                cmd.Parameters.Add(DateAssigned);
                cmd.Parameters.Add(Cost);

                cnxn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                cnxn.Close();

                cmd.Parameters.Clear();
        }

        private void AddNumber()
        {
            SqlCommand cmd = new SqlCommand
                        ("Select top 1 toolnumber from customtooling " +
                        "order by toolnumber desc", cnxn);
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();

            int next = 0;
            bool result = int.TryParse(o.ToString().Remove(0, 1), out next);
            next = next + 1;
            g.toolNumber = "T" + next.ToString();
            
            tbToolNumber.Text = g.toolNumber;

            cmd = new SqlCommand
                ("Insert into customtooling (toolnumber) values ('" + g.toolNumber + "')", cnxn);
            cnxn.Open();
            int rowsReturned = cmd.ExecuteNonQuery();
            cnxn.Close();

            //return;
        }
    }
}
