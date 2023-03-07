using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Data.Common;
using System.IO;

namespace AVALARA_s1
{
    public partial class AVALARA_State : Form
    {
        SqlDataReader dr;
        

        public AVALARA_State()
        {
            InitializeComponent();
        }

        private void AVALARA_State_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL11; Database = AccessFrontEnds; " +
                            "user = readWrite; password = Read+Write!;");

            SqlConnection cnxn2 = new SqlConnection("server = CT-MID-SQL11; Database = AccessFrontEnds; " +
                            "user = readWrite; password = Read+Write!;");
            
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT [Ship-to County] FROM AVALARA_s1_NAVinvoiceData", cnxn);

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var filePath = string.Empty;
                    filePath = @"c:\A\US DocumentSummaryReport - 2023.02 mod.xlsx";
                    filePath= filePath.Replace("US DocumentSummaryReport", dr.GetString(0).Trim());
                    filePath = filePath.Replace("mod.xlsx", ".xlsx");
                    File.Copy(@"c:\A\US DocumentSummaryReport - 2023.02 mod.xlsx",filePath);

                    Microsoft.Office.Interop.Excel.Application xlappM;
                    Microsoft.Office.Interop.Excel.Workbook wbookM;
                    Microsoft.Office.Interop.Excel.Worksheet wsheetM;

                    xlappM = new Microsoft.Office.Interop.Excel.Application();
                    xlappM.Visible = true;
                    xlappM.DisplayAlerts = false;
                    wbookM = xlappM.Workbooks.Open(filePath);
                    wbookM = xlappM.ActiveWorkbook;
                    wsheetM = xlappM.ActiveSheet;
                    wsheetM.Delete();
                    wsheetM = xlappM.ActiveSheet;

                    wsheetM.Cells[9, 2] = dr.GetString(0).Trim();

                    Microsoft.Office.Interop.Excel.Range range = wsheetM.Range["A15","A500"];
                    Microsoft.Office.Interop.Excel.Range entireRow = range.EntireRow;

                    entireRow.Delete();

                    SqlCommand cmd1 = new SqlCommand(
                       " SELECT " +
                       "  DocumentCode " +
                       ", CustomerNo " +
                       ", DocumentDate " +
                       ", TotalSales " +
                       ", 0.0 " +
                       ",CASE " +
                       "    WHEN [Sales Tax] = 0 THEN Amount" +
                       "    ELSE 0" +
                       "END NonTaxable" +
                       ", CASE WHEN [Sales Tax] > 0 THEN Amount" +
                       "    ELSE 0" +
                       "    END Taxable" +
                       ", [Sales Tax] " +
                       ", [Ship-to Name] " +
                       ", [Ship-to City] " +
                       ", [Ship-to County] " +
                       ", [Location Code] " +
                       " FROM AVALARA_match a " +
                       " LEFT JOIN AVALARA_s1_NAVinvoiceData t ON a.CustomerNo = t.[Customer No] " +
                       " AND a.DocumentCode = t.No_ " +
                       " WHERE[Ship-to County] = '" + dr.GetString(0) + "' " +
                       " ORDER BY[AVALARA Line No] ", cnxn2);

                    string[] aDoc = new string[500];
                    string[] aCust = new string[500];
                    string[] aDate = new string[500];
                    decimal[] aTot = new decimal[500];
                    decimal[] aDisc = new decimal[500];
                    decimal[] aAmountNT = new decimal[500];
                    decimal[] aAmountT = new decimal[500];
                    decimal[] aTax = new decimal[500];
                    string[] aName = new string[500];
                    string[] aCity = new string[500];
                    string[] aState = new string[500];
                    string[] aLoc = new string[500];
                    
                    int i = 0;

                    try
                    {
                        cnxn2.Open();
                        SqlDataReader dr2 = cmd1.ExecuteReader();
                        
                        while (dr2.Read())
                        {
                            

                            aDoc[i] = dr2.GetString(0).Trim();
                            aCust[i] = dr2.GetString(1).Trim();
                            aDate[i] = dr2.GetDateTime(2).ToShortDateString().Trim();
                            aTot[i] = dr2.GetDecimal(3);
                            aDisc[i] = dr2.GetDecimal(4);
                            aAmountNT[i] = dr2.GetDecimal(5);
                            aAmountT[i] = dr2.GetDecimal(6);
                            aTax[i] = dr2.GetDecimal(7);
                            aName[i] = dr2.GetString(8).Trim();
                            aCity[i] = dr2.GetString(9).Trim();
                            aState[i] = dr2.GetString(10).Trim();
                            aLoc[i] = dr2.GetString(11).Trim();
                            i++;
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn2.Close();
                    }

                    for (int n = 0; n < i; n++)
                    {
                        wsheetM.Cells[(15 + n), 1] = aDoc[n];
                        wsheetM.Cells[(15 + n), 2] = aCust[n];
                        wsheetM.Cells[(15 + n), 3] = aDate[n];
                        wsheetM.Cells[(15 + n), 4] = aTot[n];
                        wsheetM.Cells[(15 + n), 5] = aDisc[n];
                        wsheetM.Cells[(15 + n), 6] = aAmountNT[n];
                        wsheetM.Cells[(15 + n), 7] = aAmountT[n];
                        wsheetM.Cells[(15 + n), 8] = aTax[n];
                        wsheetM.Cells[(15 + n), 9] = aName[n];
                        wsheetM.Cells[(15 + n), 10] = aCity[n];
                        wsheetM.Cells[(15 + n), 11] = aState[n];
                        wsheetM.Cells[(15 + n), 12] = aLoc[n];
                    }

                    wsheetM.Cells[(15 + i), 1] = "";

                    cmd1 = new SqlCommand("SELECT " +
                        "SUM(TotalSales) " +
                        ",SUM(CASE " +
                       "    WHEN [Sales Tax] = 0 THEN Amount" +
                       "    ELSE 0" +
                       "END) " +
                       ",SUM(CASE WHEN [Sales Tax] > 0 THEN Amount" +
                       "    ELSE 0" +
                       "    END)" +
                        ",SUM([Sales Tax]) " +
                        "FROM AVALARA_match a " +
                        " LEFT JOIN AVALARA_s1_NAVinvoiceData t ON a.CustomerNo = t.[Customer No] " +
                        " AND a.DocumentCode = t.No_ " +
                        " WHERE[Ship-to County] = '" + dr.GetString(0) + "' ", cnxn2);

                    DataTable dt = new DataTable();

                    try
                    {
                        cnxn2.Open();
                        SqlDataReader dr2 = cmd1.ExecuteReader();

                        dt.Load(dr2);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        cnxn2.Close();
                    }

                    wsheetM.Cells[(15 + i + 2), 1] = "Company Total";
                    wsheetM.Cells[(15 + i + 2), 4] = dt.Rows[0][0].ToString();
                    wsheetM.Cells[(15 + i + 2), 5] = "0.00";
                    wsheetM.Cells[(15 + i + 2), 6] = dt.Rows[0][1].ToString();
                    wsheetM.Cells[(15 + i + 2), 7] = dt.Rows[0][2].ToString();
                    wsheetM.Cells[(15 + i + 2), 8] = dt.Rows[0][3].ToString();

                    wsheetM.Cells[(15 + i + 4), 1] = "Grand Total";
                    wsheetM.Cells[(15 + i + 4), 4] = dt.Rows[0][0].ToString();
                    wsheetM.Cells[(15 + i + 4), 5] = "0.00";
                    wsheetM.Cells[(15 + i + 4), 6] = dt.Rows[0][1].ToString();
                    wsheetM.Cells[(15 + i + 4), 7] = dt.Rows[0][2].ToString();
                    wsheetM.Cells[(15 + i + 4), 8] = dt.Rows[0][3].ToString();

                    wbookM.Save();

                    wbookM.Close(null, null, null);
                    xlappM.Quit();
                    //Microsoft.Office.Interop.Excel = null;
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlappM);

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
            foreach (System.Diagnostics.Process p in process)
            {
                if (!string.IsNullOrEmpty(p.ProcessName))
                {
                    try
                    {
                        p.Kill();
                    }
                    catch { }
                }
            }

            this.Close();
        }
    }
}
