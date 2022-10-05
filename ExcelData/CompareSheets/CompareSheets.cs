using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;

namespace CompareSheets
{
    public partial class CompareSheets : Form
    {
        private string Sheet1Field;
        private string Sheet2Field;
        private int rownumber = 1;

        Microsoft.Office.Interop.Excel.Application oXL1;
        Microsoft.Office.Interop.Excel.Workbook oWB1;
        Microsoft.Office.Interop.Excel.Worksheet oWS1;
        Microsoft.Office.Interop.Excel.Range oRng1;

        Microsoft.Office.Interop.Excel.Application oXL2;
        Microsoft.Office.Interop.Excel.Workbook oWB2;
        Microsoft.Office.Interop.Excel.Worksheet oWS2;
        Microsoft.Office.Interop.Excel.Range oRng2;
        
        public CompareSheets()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            oXL1 = new Microsoft.Office.Interop.Excel.Application();
            oXL1.DisplayAlerts = false;
            //oWB1 = oXL1.Workbooks.Open(@"C:\a\Rob\DCD_4-3-12.xlsx",
            oWB1 = oXL1.Workbooks.Open(@"C:\a\Rob\core drills_7.24.12.xls",
            //oWB1 = oXL1.Workbooks.Open(@"C:\a\Rob\bevel tools_7.25.12.xlsx",
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value);

            //oWS1 = (Microsoft.Office.Interop.Excel.Worksheet)oWB1.Worksheets.get_Item("Sheet1");
            oWS1 = (Microsoft.Office.Interop.Excel.Worksheet)oWB1.Worksheets.get_Item("Core Drills");

            oXL2 = new Microsoft.Office.Interop.Excel.Application();
            oXL2.DisplayAlerts = false;
            //oWB2 = oXL1.Workbooks.Open(@"C:\a\Rob\DCD_8.7.12.xlsx",
            oWB2 = oXL1.Workbooks.Open(@"C:\a\Rob\core drills_08.7.12.xls",
            //oWB2 = oXL1.Workbooks.Open(@"C:\a\Rob\bevel tools_8.21.12.xlsx",
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value);

            //oWS2 = (Microsoft.Office.Interop.Excel.Worksheet)oWB2.Worksheets.get_Item("Sheet1");
            oWS2 = (Microsoft.Office.Interop.Excel.Worksheet)oWB2.Worksheets.get_Item("Core Drills");

            //oRng1 = (Microsoft.Office.Interop.Excel.Range)oWS1.Cells["27", "B"];
            //if (oRng1.Value2 == null)
            //{
            //    string x = oRng1.get_Value(Missing.Value).ToString();
            //}

            for (int c = 65; c < 78; c++)
            {
                string column = Convert.ToChar(c).ToString();
                
                for (int i = 1; i < 1606; i++)
                {
                    oRng1 = (Microsoft.Office.Interop.Excel.Range)oWS1.Cells[i.ToString(), column];
                    if (oRng1.Value2 != null)
                    {
                        Sheet1Field = oRng1.get_Value(Missing.Value).ToString();
                    }

                    oRng2 = (Microsoft.Office.Interop.Excel.Range)oWS2.Cells[i.ToString(), column];
                    if (oRng2.Value2 != null)
                    {
                        Sheet2Field = oRng2.get_Value(Missing.Value).ToString();
                    }

                    if ( Sheet1Field != Sheet2Field )
                    {
                        File.AppendAllText(@"C:\a\Rob\datadifferences.txt",column + i + " sh1 " + Sheet1Field + " sh2 " + Sheet2Field + Environment.NewLine);
                    }

                    Sheet1Field = "";
                    Sheet2Field = "";
                }
            }

            //oWB1.Close(true, @"C:\a\Rob\bevel tools_7.25.12.xlsx", Missing.Value);

            //if (oXL1 != null)
            //{
            //    oXL1.UserControl = false;
            //    oXL1.Quit();
            //    oXL1 = null;
            //}

            //oWB2.Close(true, @"C:\a\Rob\bevel tools_8.21.12.xlsx", Missing.Value);

            //if (oXL2 != null)
            //{
            //    oXL2.UserControl = false;
            //    oXL2.Quit();
            //    oXL2 = null;
            //}

            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName("Excel"))
            {
                p.Kill();
            }


        }
    }
}