using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace OpticsMethodSheets
{
    public partial class Form1 : Form
    {
        SqlDataAdapter da;
        BindingSource bs = new BindingSource();
        SqlConnection cnxn;
        private string part;
        Microsoft.Office.Interop.Word.Application oWord;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection("server = midsql01; password = Read+Write!; " +
                                  "user = ReadWrite; database = optics;");


            da = new SqlDataAdapter
                ("Select partnumber as 'Part Number' from methodpartdata " +
                 "where partnumber <> '' " +
                 "order by partnumber asc ", cnxn);
            try
            {
                DataTable table = new DataTable();
                da.Fill(table);
                bs.DataSource = table;
                DGV.DataSource = bs;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //oWord = new Microsoft.Office.Interop.Word.Application();
            //oWord.Visible = true;
            //oWord.Documents.Open("c:\\a\\calibration validation.doc");
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 2)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                part = cell.EditedFormattedValue.ToString().Trim();
                
                //selectionChoice();
                //oWord = new Microsoft.Office.Interop.Word.Application();
            }
        }
    }
}
