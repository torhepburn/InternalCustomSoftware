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
    public partial class f051_Cal_Source_Modification : Form
    {
        SqlDataAdapter da;
        BindingSource bs = new BindingSource();
        SqlConnection cnxn;
       
        
        public f051_Cal_Source_Modification()
        {
            InitializeComponent();
        }

        private void f051_Cal_Source_Modification_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(g.db);
            DGV.Show();
            DGV.DataSource = bs;

            try
            {
                da = new SqlDataAdapter("select distinct d.calsource from " +
                    "calibrationdata d " +
                    "inner join equipment e on e.id = d.item  " +
                    " inner join status s on e.status = s.statuscode " +
                    " where s.statuslive = 'y' and d.calsourcediscontinue = 'N' " +
                    " order by d.calsource", cnxn);
                DataTable table = new DataTable();
                da.Fill(table);
                bs.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnxn.Close();

            DGV.Show();
            DGV.DataSource = bs;
        }
        
        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 3)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                   (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                LCalSource.Text = cell.EditedFormattedValue.ToString().Trim();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand
                ("update calibrationdata set calsourcediscontinue = 'Y' " +
                " where calsource  = '" + LCalSource.Text.ToString().Trim()+ "'", cnxn);

            cnxn.Open();
            int rowsReturned = cmd.ExecuteNonQuery();
            cnxn.Close();
            try
            {
                da = new SqlDataAdapter("select distinct d.calsource from " +
                    "calibrationdata d " +
                    "inner join equipment e on e.id = d.item  " +
                    " inner join status s on e.status = s.statuscode " +
                    " where s.statuslive = 'y' and d.calsourcediscontinue = 'N' " +
                    " order by d.calsource", cnxn);
                DataTable table = new DataTable();
                da.Fill(table);
                bs.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnxn.Close();

            DGV.Refresh();

            LCalSource.Text = "";
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}