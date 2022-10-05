using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EditNotes
{
    public partial class f2EditItem : Form
    {
        public f2EditItem()
        {
            InitializeComponent();
        }

     
        private void f2EditItem_Load(object sender, EventArgs e)
        {
            label1.Text = "Item Code: " + g.itemCode;
            label2.Text = "Item Class: " + g.itemClass;
            tbItemNotes.Text = g.itemNotes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnxn = new SqlConnection(g.db);
                SqlCommand cmd = new SqlCommand("Update ItemCodeClassNotes " +
                    "set ItemNotes = '" + tbItemNotes.Text.Trim() + "' " +
                    "where item_code = '" + g.itemCode + "'", cnxn);
            
                cnxn.Open();
                int rowsReturned = cmd.ExecuteNonQuery();
                cnxn.Close();
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
