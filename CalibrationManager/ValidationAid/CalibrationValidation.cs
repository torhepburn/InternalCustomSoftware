using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ValidationAid
{
    public partial class CalibrationValidation : Form
    {
        SqlConnection cnxn = new SqlConnection(
            "server= midsql01; user = ReadWrite; password" +
            "= Read+Write!; database = Calibration");
        private string userLogon;
        private string permission;
        
        public CalibrationValidation()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Security.Principal.WindowsIdentity user;
            user = System.Security.Principal.WindowsIdentity.GetCurrent();
            userLogon = user.Name.Remove(0,8);

            SqlDataAdapter da = new SqlDataAdapter
                ("Select Name, UserType from accessrights order by name", cnxn);

            DataTable table = new DataTable();
            da.Fill(table);

            DGV.DataSource = table;
        }

        private void rbSystem_CheckedChanged(object sender, EventArgs e)
        {
            permission = "system";
        }

        private void rbSystemAC_CheckedChanged(object sender, EventArgs e)
        {
            permission = "systemAC";
        }

        private void rbFull_CheckedChanged(object sender, EventArgs e)
        {
            permission = "full";
        }

        private void rbViewData_CheckedChanged(object sender, EventArgs e)
        {
            permission = "view+data";
        }

        private void rbLimited_CheckedChanged(object sender, EventArgs e)
        {
            permission = "limited";
        }

        private void bPermissions_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update accessrights " +
                    " set usertype = '" + permission + "'" +
                    " where userlogon = '" + userLogon + "'");
            
            cmd.Connection = cnxn;
            cnxn.Open();
            int rowsReturned = cmd.ExecuteNonQuery();
            cnxn.Close();

            SqlDataAdapter da = new SqlDataAdapter
                ("Select Name, UserType from accessrights order by name", cnxn);

            DataTable table = new DataTable();
            da.Fill(table);

            DGV.DataSource = table;
        }

    }
}
