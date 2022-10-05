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
    public partial class f16ViewRooms : Form
    {
        SqlDataAdapter da;
        BindingSource bs = new BindingSource();
        SqlConnection cnxn;
        
        public f16ViewRooms()
        {
            InitializeComponent();
        }

        private void f16ViewRooms_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter(
                "Select r_roomnumber as [Room Number], R_Description as " +
                "Description,  " +
                "R_Notes as Notes from room " +
                " where r_RoomNumber like '" + g.facility + "%' " + 
                " order by r_RoomNumber", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            bs.DataSource = table;
            dataGridView1.DataSource = bs;
            dataGridView1.Show();
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }
}