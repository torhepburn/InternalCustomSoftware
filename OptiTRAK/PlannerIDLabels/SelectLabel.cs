using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace PlannerIDLabels
{
    public partial class SelectLabel : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        string db = "server = CT-MID-SQL01; password = Read+Write!; " +
                    "user = readwrite; database = OptiTRAK;";
        private string customer;
        private string project;
        private string elementname;
        private string partsnID;
        private string SFO;

        public SelectLabel()
        {
            InitializeComponent();
        }

        private void SelectLabel_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);

            try
            {
                da = new SqlDataAdapter
                ("Select Customer, Project, ElementName, PartSN ID, prodordnum SFO " +
                 "from tblPartSN p " +
                 "inner join tblJobInfo j on p.jobid = j.jobid " +
                 "where partpoclosed != -1 and jobcomplete != -1 " +
                "order by prodordnum", cnxn);
                DataTable table = new DataTable();
                da.Fill(table);
                DGV.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnxn.Close();

            DGV.Columns[0].Width = 100;
            DGV.Columns[1].Width = 150;
            DGV.Columns[2].Width = 150;
            DGV.Columns[3].Width = 40;
            DGV.Columns[4].Width = 60;
            //DGV.Columns[5].Width = 100;
            //DGV.Columns[9].Width = 150;
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            da = new SqlDataAdapter
                ("Select Customer, ElementName, PartSN ID, prodordnum SFO " +
                 "from tblPartSN p " +
                 "inner join tblJobInfo j on p.jobid = j.jobid " +
                 "where customer like '%" + tbSearchEquipment.Text + "%' " +
                 " and partpoclosed != -1 and jobcomplete != -1 " +
                 "or [project] like '%" + tbSearchEquipment.Text + "%' " +
                 "or [elementname] like '%" + tbSearchEquipment.Text + "%' " +
                 "or [prodordnum] like '%" + tbSearchEquipment.Text + "%' " +
                 "order by prodordnum", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            tbSearchEquipment.Text = "";
        }

        private void bItem_Click(object sender, EventArgs e)
        {

        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 1)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                customer = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                project = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                elementname = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[3];
                partsnID = cell.EditedFormattedValue.ToString().Trim();

                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[4];
                SFO = cell.EditedFormattedValue.ToString().Trim();

                

            }
        }
    }
}
