using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MicroscopeDB
{
    public partial class Accessories : Form
    {
        private string SQL = "Select " +
                " PartNumber [Part Number] " +
                ",accDescription [Description] " +
                ",accSerialNumber [Serial Number] " +
                ", ID " +
                "FROM MicroscopeAccessories " +
                "WHERE AccessoryType = ";
        public Accessories()
        {
            InitializeComponent();
        }

        private void Accessories_Load(object sender, EventArgs e)
        {
            LproductLine.Text = g.ProductLine;
            LDateCode.Text = g.DateCode + "-";
            Lsn.Text = g.serialNumber;

            gridData();
        }

        private void gridData()
        {
            SqlConnection cnxn = new SqlConnection(g.db);

            SqlDataAdapter da = new SqlDataAdapter(SQL +
                "'Objective' " +
                "AND MicroscopeData_ID = " + g.DataID, cnxn);

            DataTable dt1 = new DataTable();

            da.Fill(dt1);

            DGV1.DataSource = dt1;

            DGV1.Columns[0].Width = 120;
            DGV1.Columns[1].Width = 400;
            DGV1.Columns[2].Width = 150;
            DGV1.Columns[3].Visible = false;
            DGV1.Show();

            da = new SqlDataAdapter(SQL +
                "'Standard' " +
                "AND MicroscopeData_ID = " + g.DataID, cnxn);

            DataTable dt2 = new DataTable();

            da.Fill(dt2);

            DGV2.DataSource = dt2;

            DGV2.Columns[0].Width = 120;
            DGV2.Columns[1].Width = 400;
            DGV2.Columns[2].Width = 150;
            DGV2.Columns[3].Visible = false;
            DGV2.Show();


            da = new SqlDataAdapter(SQL +
               "'Other' " +
               "AND MicroscopeData_ID = " + g.DataID, cnxn);

            DataTable dt3 = new DataTable();

            da.Fill(dt3);

            DGV3.DataSource = dt3;

            DGV3.Columns[0].Width = 120;
            DGV3.Columns[1].Width = 400;
            DGV3.Columns[2].Width = 150;
            DGV3.Columns[3].Visible = false;
            DGV3.Show();

        }

        private void bBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 | e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV1.Rows[e.RowIndex].Cells[3];

                g.AccessoryDataID = Convert.ToInt32(cell.EditedFormattedValue.ToString().Trim());

                taskSelect();
            }
        }

        private void DGV2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 | e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV2.Rows[e.RowIndex].Cells[3];

                g.AccessoryDataID = Convert.ToInt32(cell.EditedFormattedValue.ToString().Trim());

                taskSelect();
            }
        }

        private void DGV3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 | e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV3.Rows[e.RowIndex].Cells[3];

                g.AccessoryDataID = Convert.ToInt32(cell.EditedFormattedValue.ToString().Trim());

                taskSelect();
            }
        }

        private void taskSelect()
        {
            if (g.task == "Edit")
            {
                AccessoryAddEdit ae = new AccessoryAddEdit();
                ae.ShowDialog();

                gridData();
            }
        }
    }
}
