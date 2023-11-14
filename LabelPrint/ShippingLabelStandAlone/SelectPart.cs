using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ShippingLabelUSA
{
    public partial class SelectPart : Form
    {
        public SelectPart()
        {
            InitializeComponent();
        }

        private void SelectPart_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            
            string[] lines = File.ReadAllLines(@"C:\A\LabelData.txt");

            g.printer = lines[0].Substring(lines[0].LastIndexOf(",") + 1, (lines[0].Length -1) - (lines[0].LastIndexOf(",")));

            for (int col = 0; col < 3; col++)
                dt.Columns.Add(new DataColumn("Column" + (col + 1).ToString()));


            foreach (string line in lines)
            {
                var cols = line.Split(',');

                DataRow dr = dt.NewRow();
                for (int cIndex = 0; cIndex < 3; cIndex++)
                {
                    dr[cIndex] = cols[cIndex];
                }

                dt.Rows.Add(dr);
            }

            DGV.DataSource = dt;

            DGV.Columns[0].Width = 100;
            DGV.Columns[0].HeaderCell.Value = "PART";
            DGV.Columns[1].Width = 270;
            DGV.Columns[1].HeaderCell.Value = "DESCRIPTION";
            DGV.Columns[2].Width = 50;
            DGV.Columns[2].HeaderCell.Value = "REV";
            
        }

        private void bSearch_Click(object sender, EventArgs e)
        {

        }

        private void bFreeText_Click(object sender, EventArgs e)
        {
            FreeText s = new FreeText();
            s.Show();
        }

        private void bItem_Click(object sender, EventArgs e)
        {

        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 0)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                g.item = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.iDescription = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                g.iRevision = cell.EditedFormattedValue.ToString().Trim();

                F2_LabelDetails f2 = new F2_LabelDetails();
                f2.Show();
            }
        }
    
    }

    public static class g
    {
        public static string user;
        public static string item;
        public static string iDescription;
        public static string iRevision;
        public static string editRevision;
        public static string iSerialNumber;
        public static string iQuantity;
        public static string iNumberofBoxes;
        public static string iLabelQuantity;
        public static string printer;
        
    }
}
