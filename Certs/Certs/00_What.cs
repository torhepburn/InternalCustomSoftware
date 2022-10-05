using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Certs
{
    public partial class _00_What : Form
    {
        SqlDataAdapter da;
        SqlConnection cnxn;
        DataTable table;

        public _00_What()
        {
            InitializeComponent();
        }

        private void _00_What_Load(object sender, EventArgs e)
        {
            this.Text = "Certificates of Compliance v" + Application.ProductVersion;

            cnxn = new SqlConnection(g.db);
            da = new SqlDataAdapter
              ("Select " +
               "[Certification #] " +
               ",[Customer Name] " +
               ",[Test Date] " +
               ",[Customer PO #] " +
               "from CC_CofC " +
               "where [Type] = 'com' " +
               "order by [Certification #] desc", cnxn);

            GetData();
        }

        private void GetData()
        {
            table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
            DGV.Columns[0].Width = 120;
            DGV.Columns[1].Width = 250;

            DGV.Show();
        }

        private void bCompliance_Click(object sender, EventArgs e)
        {

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
                g.certificationNumber = cell.EditedFormattedValue.ToString().Trim();


                Form_325B s = new Form_325B();
                s.ShowDialog();
            }
        }
    }
}
