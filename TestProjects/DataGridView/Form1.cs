using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataGridView
{
    public partial class Form1 : Form
    {
        DataTable dt;
        //const int cColWidth = 45;
        //const int cRowHeigth = 45;
        //const int cMaxCell = 9;
        //const int cSidelength = cColWidth * cMaxCell + 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection(
                "Server = CT-MID-sql01; password = Read+Write!; user = readWrite; database = AccessFrontends;");

            SqlDataAdapter da = new SqlDataAdapter("select * from NDA where prodline = 'procurement'", cnxn);

            try
            {
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //int ttt = 2;
            //DataGridViewColumn column = DGV.Columns[ttt];
            //column.DividerWidth = 50;

            //DGV.Columns[4].DividerWidth = 5;

            DGV.DataSource = dt;
            DGV.Show();

            ////DGV = new DataGridView();
            ////DGV.Name = "DGV";
            //DGV.AllowUserToResizeColumns = false;
            ////DGV.AllowUserToResizeRows = false;
            //DGV.AllowUserToAddRows = false;
            //DGV.RowHeadersVisible = false;
            //DGV.ColumnHeadersVisible = false;
            //DGV.GridColor = Color.DarkBlue;
            //DGV.DefaultCellStyle.BackColor = Color.AliceBlue;
            //DGV.ScrollBars = ScrollBars.None;
            //DGV.Size = new Size(cSidelength, cSidelength);
            //DGV.Location = new Point(50, 50);
            //DGV.Font = new System.Drawing.Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            //DGV.ForeColor = Color.DarkBlue;
            //DGV.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //// add 81 cells
            //for (int i = 0; i < cMaxCell; i++)
            //{
            //    DataGridViewTextBoxColumn TxCol = new DataGridViewTextBoxColumn();
            //    TxCol.MaxInputLength = 1;   // only one digit allowed in a cell
            //    DGV.Columns.Add(TxCol);
            //    DGV.Columns[i].Name = "Col " + (i + 1).ToString();
            //    DGV.Columns[i].Width = cColWidth;                
            //    DGV.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
            //    DataGridViewRow row = new DataGridViewRow();
            //    row.Height = cRowHeigth;
            //    DGV.Rows.Add(row);
            //}
            //// mark the 9 square areas consisting of 9 cells
            //DGV.Columns[2].DividerWidth = 2;
            //DGV.Columns[5].DividerWidth = 5;
            //DGV.Rows[2].DividerHeight = 2;
            //DGV.Rows[5].DividerHeight = 2;
            
            ////Controls.Add(DGV);


        }
    }
}
