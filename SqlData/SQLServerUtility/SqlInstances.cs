using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;

namespace SQLServerUtility
{
    public partial class SqlInstances : Form
    {
        System.Data.DataTable table;
        private string selection;
        private string computername;
        private string instancename;
        private string loadCount;
        private bool doloadCount = true;

        public SqlInstances()
        {
            InitializeComponent();
        }

        private void SqlInstances_Load(object sender, EventArgs e)
        {
            selection = " 'one' = 'one' ";

            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.HeaderText = "Include";
                column.Name = "include";
                column.CellTemplate = new DataGridViewCheckBoxCell();
            }
            DGV.Columns.Insert(0, column);

            GridData();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 | e.ColumnIndex < 1)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                g.instance = cell.EditedFormattedValue.ToString().Trim();

                DatabaseDetails d = new DatabaseDetails();
                d.ShowDialog();
            }
        }

        private void bFilter_Click(object sender, EventArgs e)
        {
            if (cbEditionExpress.Checked)
            {
                selection += " and skuname not like '%Express%' ";
            }
            

            if (cbEditionDesktopEngine.Checked)
            {
                selection += " and skuname not like '%Desktop%' ";
            }

            if (cbInstanceSQLExpress.Checked)
            {
                selection += " and i.InstanceName not like '%Express%' ";
            }

            if (cbInstanceACT.Checked)
            {
                selection += " and i.InstanceName not like '%ACT%' ";
            }
            
            foreach (DataGridViewRow row in DGV.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["include"].Value);

                if (isSelected)
                {
                    computername += ",'" + Convert.ToString(row.Cells[1].Value) + "'";
                    instancename += ",'" + Convert.ToString(row.Cells[2].Value) + "'";
                }
            }
            
            if ((computername != null) && (computername.Length > 2))
            {
                computername = computername.Substring(1);
                instancename = instancename.Substring(1);
                selection += " and dnshostname in (" + computername + ") " +
                             " and i.instancename in (" + instancename + ")";
            }

            GridData();

            selection = " 'one' = 'one' ";
            computername = null;
            instancename = null;
        }

        private void GridData()
        {
            SqlConnection cnxn = new SqlConnection(g.db);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                "with dbcounts as " +
                    "( " +
                    "select " +
                    "devicenumber, " +
                    "Max(servername) servername, " +
                    "count(dbname) NumberOfDatabases " +
                    "from [SqlServer_Inventory].[DataBaseProperties] " +
                    "group by devicenumber" +
                    ") " +
                    "select " +
                    "DnsHostName ComputerName " +
                    ",i.InstanceName " +
                    ",Servicename " +
                    ",Version " +
                    ",ProductLevel ServicePack " +
                    ",skuname ServerEdition " +
                    ",NumberOfProcessors " +
                    ",NumberOfCores " +
                    ",NumberOfLogicalProcessors " +
                    ",CPU " +
                    ",SystemMemory " +
                    ",c.NumberOfDatabases " +
                    "from [SqlServer_Inventory].[Inventory] i " +
                    "left join [SqlServer_Inventory].[DataBaseServerProperties] p " +
                    "on i.DeviceNumber = p.DeviceNumber " +
                    "left join AllDevices_Assessment.HardwareInventoryEx h " +
                    "on h.DeviceNumber = p.DeviceNumber " +
                    "left join dbcounts c " +
                    "on c.DeviceNumber = p.DeviceNumber " +
                    "where " + selection +
                    "order by dnshostname", cnxn);

                table = new System.Data.DataTable();
                da.Fill(table);

                if (doloadCount)
                {
                    loadCount = table.Rows.Count.ToString();
                    doloadCount = false;
                }

                DGV.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DGV.Columns[0].Width = 50;
            DGV.Columns[1].Width = 120;
            DGV.Columns[2].Width = 100;
            DGV.Columns[3].Width = 80;
            DGV.Show();

            label1.Text = "Count = " + table.Rows.Count.ToString() + " of " + loadCount;
        }

        /// <summary> 
        /// Exports the datagridview values to Excel. 
        /// </summary> 
        private void ExportToExcel()
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

        private void bExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        } 
 
    }

    public static class g
    {
        public static string instance;
        //public static string item;
        //public static string server;
        //public static string iRevision;
        //public static string iSerialNumber;
        //public static string iQuantity;
        //public static string iNumberofBoxes;
        //public static string iLabelQuantity;
        //public static string printer;
        public static string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = ZygoInventory;";
    }
}
