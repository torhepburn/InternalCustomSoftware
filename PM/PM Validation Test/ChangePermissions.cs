using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PM_Validation_Test
{
    public partial class ChangePermissions : Form
    {
        SqlConnection cnxn = new SqlConnection("Server = MIDSQL01; database = AccessFrontEnds;" +
            "user = readWrite; password = Read+Write!;");
        private string choice;

        public ChangePermissions()
        {
            InitializeComponent();
        }

        private void ChangePermissions_Load(object sender, EventArgs e)
        {
            callonLoad();
        }
        
        private void callonLoad()
        {
            try
            {
                cnxn.Open();
                SqlCommand cmd = new SqlCommand(
                   " Select PermissionValue FROM ApplicationSetup " +
                   " WHERE " +
                   " Application = 'PM' AND " +
                   " USERID = 1085 AND " +
                   " Permission = 'USERGROUP'", cnxn);

                object o = cmd.ExecuteScalar();
                
                if (o == null)
                {
                    MessageBox.Show("This item does not exist.");

                }
                else
                {
                    label1.Text = "Permission = " + o.ToString();

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
                

        private void bView_Click(object sender, EventArgs e)
        {
            choice = "ViewOnly";
            MakeChange();
            callonLoad();
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            choice = "CanUpdateData";
            MakeChange();
            callonLoad();
        }

        private void bAssign_Click(object sender, EventArgs e)
        {
            choice = "CanAssign";
            MakeChange();
            callonLoad();
        }

        private void bAllSites_Click(object sender, EventArgs e)
        {
            choice = "AllSites";
            MakeChange();
            callonLoad();
        }

        private void MakeChange()
        {
            try
            {
                cnxn.Open();
                SqlCommand cmd = new SqlCommand(
                   " Update MIDSQL01.AccessFrontEnds.dbo.ApplicationSetup set " +
                   "  PermissionValue = '" + choice + "'" +
                   " WHERE " +
                   " Application = 'PM' AND " +
                   " USERID = 1085 AND " +
                   " Permission = 'USERGROUP'", cnxn);

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
        }
    }
}
