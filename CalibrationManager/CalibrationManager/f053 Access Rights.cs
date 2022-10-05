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
    public partial class f053_Access_Rights : Form
    {
        public f053_Access_Rights(string NewPerson)
        {
            InitializeComponent();
            tbUserName.Text = NewPerson;
        }

        private void f053_Access_Rights_Load(object sender, EventArgs e)
        {
            tbUserName.ReadOnly = true;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (tbUserLogin.Text.Length < 1)
            {
                MessageBox.Show("Must enter a User Login.");
                tbUserLogin.Focus();
                return;
            }

            if (ddlUserType.SelectedIndex == -1)
            {
                MessageBox.Show("Must select a User Type.");
                ddlUserType.Focus();
                return;
            }

            if(ddlFacility.SelectedIndex == -1)
            { 
                MessageBox.Show("Must select a facility.");
                ddlFacility.Focus();
                return;
            }
            
            string fac = ddlFacility.SelectedItem.ToString();

            if (fac == "Middlefield")
            { fac = "zams";}
            if (fac == "Tucson")
            { fac = "azt";}
            if (fac == "Irvine")
            { fac = "zeos";}
            if (fac == "Richmond")
            { fac = "ZEP"; }

            

            

            try
            {
                SqlConnection cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand("Insert into AccessRights " +
                    "(UserLogon, UserType, Facility, Name) values ('" +
                    tbUserLogin.Text.Trim() + "','" +
                    ddlUserType.SelectedItem.ToString().Trim() + "','" +
                    fac + "','" +
                    tbUserName.Text.Trim() + "')", cnxn);
                cnxn.Open();
                int rowsReturned = cmd.ExecuteNonQuery();
                cnxn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            this.Close();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
