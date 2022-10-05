using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ListOptiTRAKRoutings
{
    public partial class ListRoutings : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        private string SQL = "Select DISTINCT" +
                             " Customer " +
                             ",Project " +
                             ",ElementName " +
                             ",TravelerRevDate [Traveler Rev Date] " +
                             ",TravelerRev [Traveler Rev]" +
                             " FROM tblJobInfo j " +
                             " INNER JOIN tblWorkIns w on j.JobID = w.JobID " +
                             " WHERE JobComplete = 0 ";
                            
        public ListRoutings()
        {
            InitializeComponent();
        }

        private void ListRoutings_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection("server = CT-MID-SQL01; password = Read+Write!; " +
                                  "user = readwrite; database = OptiTRAK;");
            try
            {
                da = new SqlDataAdapter
                (SQL + " ORDER BY Customer, Project, ElementName", cnxn);
                DataTable table = new DataTable();
                da.Fill(table);
                DGV.DataSource = table;

                DGV.Columns[1].Width = 150;
                DGV.Columns[2].Width = 200;
                DGV.Columns[3].Width = 80;
                DGV.Columns[4].Width = 50;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnxn.Close();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            //cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
                (SQL +
                 " AND (customer like '%" + tbSearchEquipment.Text + "%' " +
                 "or project like '%" + tbSearchEquipment.Text + "%' " +
                 "or elementname like '%" + tbSearchEquipment.Text + "%') " +
                 " ORDER BY Customer, Project, ElementName", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            tbSearchEquipment.Text = "";
        }
    }
}
