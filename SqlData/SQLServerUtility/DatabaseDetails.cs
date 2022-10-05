using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;

namespace SQLServerUtility
{
    public partial class DatabaseDetails : Form
    {
        System.Data.DataTable table;

        public DatabaseDetails()
        {
            InitializeComponent();
        }

        private void DatabaseDetails_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da;
            SqlConnection cnxn = new SqlConnection(g.db);

            try
            {
            da = new SqlDataAdapter(
                "select " +
                "DbName Name " +
                ",Owner " +
                ",Size " +
                ",CreatedTimestamp DateCreated " +
                ",NumberTables " +
                ",NumberViews " +
                ",NumberSP " +
                ",NumberFunction " +
                "from SqlServer_Inventory.DatabaseProperties " +
                "where servername = '" + g.instance + "' " +
                "order by dbname"

                
                ,cnxn);

                table = new System.Data.DataTable();
                da.Fill(table);

                DGV.DataSource = table;

                DGV.Columns[0].Width = 120;
                DGV.Columns[1].Width = 150;
                DGV.Columns[2].Width = 150;
                DGV.Columns[3].Width = 70;
                DGV.Columns[4].Width = 70;
                DGV.Columns[5].Width = 70;
                DGV.Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bExcel_Click(object sender, EventArgs e)
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ExportedFromDatGrid";


                int cellColumnIndex = 1;

                foreach (DataColumn column in table.Columns)
                {
                    worksheet.Cells[1, cellColumnIndex] = column.ColumnName.ToString();
                    cellColumnIndex++;
                }

                cellColumnIndex = 1;
                int cellRowIndex = 2;
                //Loop through each row and read value from each column. 
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        worksheet.Cells[cellRowIndex, cellColumnIndex] = table.Rows[i].ItemArray[j].ToString();

                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }


                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        }
    }
}
