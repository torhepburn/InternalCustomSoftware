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


namespace LOTOview
{
    public partial class LOTOview : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        private string serial;
        private string xtract = @"C:\pm\xtract.pdf";

        public LOTOview()
        {
            InitializeComponent();
        }

        private void LOTOview_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection("server = MIDSQL01; password = views; " +
                                  "user = views; database = PM_2015_A;");

            da = new SqlDataAdapter
                ("Select serial, [Description] from pmequip " +
                 "where loto is not null " + 
                 " order by serial asc", cnxn);

            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;

            DGV.Columns[0].Width = 200;
            DGV.Columns[1].Width = 500;
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
                serial = cell.EditedFormattedValue.ToString().Trim();
                
                selectionChoice();
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter
                ("Select serial, [Description] from pmequip" +
                 " where (serial like '%" + tbSearchEquipment.Text + "%' " +
                 "or [description] like '%" + tbSearchEquipment.Text + "%' )" +
                 "and loto is not null " +
                 " order by serial", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
        }

        private void bItem_Click(object sender, EventArgs e)
        {
            serial = tbSearchEquipment.Text.ToString().Trim().ToUpper();
            tbSearchEquipment.Text = "";
            
            SqlCommand cmd = new SqlCommand
                ("Select serial from pmequip " +
                "where serial = '" + serial + "' and loto is not null", cnxn);
            cnxn.Open();
            object o = cmd.ExecuteScalar();

            if (o == null)
            {
                MessageBox.Show("This item does not exist.");
                tbSearchEquipment.Focus();
            }
            else
            {
                selectionChoice();
            }
        }

        private void selectionChoice()
        {
            System.Diagnostics.Process pdfReader = new System.Diagnostics.Process();
            
            SqlCommand cmd = new SqlCommand
                ("Select LOTO from pmequip where serial = '" + serial + "' and loto is not null", cnxn);
            cnxn.Open();
            object o = cmd.ExecuteScalar();
            cnxn.Close();
            if (o != null)
            {
                cmd = new SqlCommand
                    ("select LOTO from pmequip where serial = '" + serial + "' and loto is not null");
                cmd.Connection = cnxn;
                cnxn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    // read in using GetValue and cast to byte array
                    byte[] xData = (byte[])dr.GetValue(0);

                    // write bytes to disk as file
                    FileStream fs1 = new FileStream
                        (xtract, FileMode.Create, FileAccess.ReadWrite);
                    BinaryWriter bw = new BinaryWriter(fs1);
                    bw.Write(xData);
                    bw.Close();

                    pdfReader = System.Diagnostics.Process.Start(xtract);
                }
                dr.Close();
                cnxn.Close();

            }
            
        }


    }
}
