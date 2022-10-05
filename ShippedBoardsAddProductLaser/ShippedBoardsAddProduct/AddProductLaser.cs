using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ShippedBoardsAddProduct
{
    public partial class AddProductLaser : Form
    {
        public AddProductLaser()
        {
            InitializeComponent();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnxn = new SqlConnection
                    ("server = CT-MID-SQL11; password = Read+Write!; user = readwrite; " +
                      "database = AccessFrontends;");
                SqlCommand cmd = new SqlCommand("Insert into sernos_lup_product_laser " +
                    "(Item_Model, Item_Description, Item_Code, Item_TabIndex, Item_CheckDeliveries) " +
                    "values (@model, @description, @itemCode, 0, 1)", cnxn);
                cmd.Parameters.Add("@model", SqlDbType.NVarChar, 50).Value = tbModel.Text.Trim();
                cmd.Parameters.Add("@description", SqlDbType.NVarChar, 50).Value = tbDescription.Text.Trim();
                cmd.Parameters.Add("@itemCode", SqlDbType.NVarChar, 40).Value = tbItemCode.Text.Trim();
                cnxn.Open();
                int result = cmd.ExecuteNonQuery();
                cnxn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}
