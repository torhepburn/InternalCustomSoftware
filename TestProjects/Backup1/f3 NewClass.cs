using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PL1
{
    public partial class f3_AssignClass : Form
    {
        BindingSource bs = new BindingSource();
        SqlConnection cnxn;
        
        public f3_AssignClass()
        {
            InitializeComponent();
        }

        private void f3_AssignClass_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection
               ("server = middbsql; password = views; user = views; " +
                 "database = pricelists;");
            DGV.Show();
            DGV.DataSource = bs;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter
               ("select " +
                "ItemClassCode as [Item Class Code], " +
                "ItemClassCodeFolder as [Folder], " +
                "ItemClass as [Item Class] " +
                "from ItemClasses " +
                "order by itemclasscode ", cnxn);
                DataTable table = new DataTable();
                da.Fill(table);
                bs.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            DGV.DataSource = bs;

        }
        private void bEnter_Click(object sender, EventArgs e)
        {
             try
            {
                SqlCommand cmd = new SqlCommand("Insert into ItemClasses " +
                    "(ItemClassCode, ItemClass, ItemClassCodeFolder) values ('" 
                    + tbClassCode.Text.Trim() + "','" +
                    tbClass.Text.Trim() + "','" +
                    tbFolder.Text.Trim() + "')", cnxn);
                cmd.Connection = cnxn;
                cnxn.Open();
                int rowsReturned = cmd.ExecuteNonQuery();
                cnxn.Close();
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}