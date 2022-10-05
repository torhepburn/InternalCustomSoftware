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
    public partial class AdminAddUser : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;

        public AdminAddUser()
        {
            InitializeComponent();
        }

        private void AdminAddUser_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            DataTable t = new DataTable();

            if (g.task == "ADD")
            {
                cmd = new SqlCommand(
                    " select cn, loginname FROM [EmployeesAmetekAD] " +
                    " ORDER BY sn", cnxn);

                try
                {
                    t = new DataTable();
                    t.Rows.Add();
                    t.AcceptChanges();
                    cnxn.Open();
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    t.Load(dr);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }

                cbddEmployees.DataSource = t;
                cbddEmployees.DisplayMember = "cn";
                cbddEmployees.ValueMember = "loginname";
            }
            else
            {
                cbddEmployees.Text = g.employeeName;
                cbddPermission.Text = g.permission;
                cbddPermissionValue.Text = g.permissionValue;
            }
            
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (g.task == "ADD")
            {
                cmd = new SqlCommand(
                    "INSERT INTO applicationSetup (" +
                    " Application " +
                    ",UserName" +
                    ",Permission" +
                    ",PermissionValue) values (" +
                    "'CertificationManager.exe','" +
                      cbddEmployees.SelectedValue + "','" +
                      cbddPermission.Text + "','" +
                      cbddPermissionValue.Text + "')", cnxn);
            }
            else
            {
                cmd = new SqlCommand(
                    "UPDATE applicationSetup SET " +
                    "Permission = '" + cbddPermission.Text + "', " +
                    "PermissionValue = '" + cbddPermissionValue.Text + "' " +
                    "WHERE username = '" + g.loginname + "'", cnxn);
            }
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
                g.task = string.Empty;
                g.loginname = string.Empty;
                g.employeeName = string.Empty;
                g.permissionValue = string.Empty;
                this.Close();
            }
        }
    }
}
