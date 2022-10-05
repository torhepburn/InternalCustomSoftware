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

namespace PhoneBook
{
    public partial class F2_AddEdit : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        public F2_AddEdit()
        {
            InitializeComponent();
        }
               
        private void F2_AddEdit_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);

            tbName.Text = g.name;

            if (g.task == "ADD")
            {
                tbADName.Text = g.ADname;
            }

            if (g.task == "EDIT")
            {
                tbExtension.Text = g.extension;
                tbADName.Text = g.ADname;
                cbddLocation.Text = g.location;
            }
        }

        private void Bsave_Click(object sender, EventArgs e)
        {
            if (g.task == "ADD")
            {
                cmd = new SqlCommand();
                
            }

            if (g.task == "EDIT")
            {
                cmd = new SqlCommand(
                    "UPDATE PhoneBook " +
                    "SET name = @name " +
                    ", extension = '" + tbExtension.Text + "' " +
                    ", location = '" + cbddLocation.Text + "' " +
                    "WHERE id = " + g.UID, cnxn);
            }

            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = tbName.Text.Trim();

            try
            {
                cnxn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnxn.Close();
            }
        }
    }
}
