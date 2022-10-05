using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PMManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
                ("server=midprj01; user=views; password=views;" +
                 "database=logsheetsdb");
            SqlDataAdapter da = new SqlDataAdapter
                   ("select " +
                    "[Trouble Severity], " +
                    "[Trouble Repair Category], " +
                    "[Trouble Serial], " +
                    "[Trouble Cost Center], " +
                    "[Trouble Rptd Date], " +
                    "Trouble, " +
                    "ID, " +
                    "[Trouble Rptd By], " +
                    "[Trouble Email], " +
                    "[Trouble Phone] " +
                    " from [repair history from web]", cnxn);

            DataTable table = new DataTable();
            da.Fill(table);

            DGV.DataSource = table;
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                //g.iID = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                //g.iDescription = cell.EditedFormattedValue.ToString().Trim();
            }
        }

       
    }

}