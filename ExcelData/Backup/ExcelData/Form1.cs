using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;

namespace ExcelData
{
    public partial class Form1 : Form
    {
        Microsoft.Office.Interop.Excel.Application oXL;
        Microsoft.Office.Interop.Excel.Workbook oWB;
        Microsoft.Office.Interop.Excel.Worksheet oWS;
        Microsoft.Office.Interop.Excel.Range oRng;

        Microsoft.Office.Interop.Excel.Application oXL1;
        Microsoft.Office.Interop.Excel.Workbook oWB1;
        Microsoft.Office.Interop.Excel.Worksheet oWS1;
        Microsoft.Office.Interop.Excel.Range oRng1;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = true;
            //oXL.DisplayAlerts = false;
            
            oWB = oXL.Workbooks.Open(@"\\zygocorp\departments\finance\" +
                @"month_end_reconcile\reconcile_templates\pivot_table_macros\" +
                @"pps.xlsm",
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value);
            oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("PPS_Master");
            oRng = oWS.get_Range("A1", "T1");
            object[,] xlData;
            xlData = (System.Object[,])oRng.get_Value((System.Reflection.Missing.Value));
            //string a = oWB.Names.Item(11,1, 1).Name.ToString();
            //string b = oWB.Names.Item(69, 1, 1).RefersToR1C1.ToString();

            //
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            oXL1 = new Microsoft.Office.Interop.Excel.Application();
            oXL1.Visible = true;
            //oXL1.DisplayAlerts = false;
            oWB1 = oXL1.Workbooks.Open(@"\\zygocorp\departments\finance\" +
                @"month_end_reconcile\reconcile_templates\" +
                @"zygoproductlinegenerateand reconcile_2012.xlsm",
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value);
            //oWS1 = (Microsoft.Office.Interop.Excel.Worksheet)oWB1.Worksheets.get_Item("summary");
            //string a = oWB1.Names.Item(69, 1, 1).Name.ToString();
            //string b = oWB1.Names.Item(69, 1, 1).RefersToR1C1.ToString();

            //oXL1.Quit();
        }

        private void bCloseExcl_Click(object sender, EventArgs e)
        {
            oXL.Quit();
            oXL1.Quit();
        }
    }
}