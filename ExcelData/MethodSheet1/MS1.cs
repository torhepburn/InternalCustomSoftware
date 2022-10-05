using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;


namespace MethodSheet1
{
    public partial class MS1 : Form
    {
        Microsoft.Office.Interop.Excel.Application oXL1;
        Microsoft.Office.Interop.Excel.Workbook oWB1;
        Microsoft.Office.Interop.Excel.Worksheet oWS1;
        Microsoft.Office.Interop.Excel.Range oRng1;
        private string PartNumber, newMethod, LotSize, ReleaseQty, Yield, Rev;

        public MS1()
        {
            InitializeComponent();
        }

        private void MS1_Load(object sender, EventArgs e)
        {
            tbSearch.Focus();

            oXL1 = new Microsoft.Office.Interop.Excel.Application();
            oXL1.DisplayAlerts = false;
            //oWB1 = oXL1.Workbooks.Open(@"\\zygocorp\Departments\Optics\Opt_Eng\Custom Optics Admin\methodsstandardreleasenewserial.xls",
            oWB1 = oXL1.Workbooks.Open(@"C:\a\Copy of METHODSStandardReleaseNewSerial.xls",
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value);

            oWS1 = (Microsoft.Office.Interop.Excel.Worksheet)oWB1.Worksheets.get_Item("PART DATA");

            oRng1 = (Microsoft.Office.Interop.Excel.Range)oWS1.Columns["B", Type.Missing];

            oRng1 = oWS1.get_Range("B2", "B1000");
            object[,] xlData;
            xlData = (System.Object[,])oRng1.get_Value(Missing.Value);
            PartNumber = xlData[1, 1].ToString().Trim();
                
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

            //foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName("Excel"))
            //{
            //    p.Kill();
            //}

        }

        private void bFind_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Range currentFind = null;
            string sAddress;
            string eAddress;

            oXL1 = new Microsoft.Office.Interop.Excel.Application();
            oXL1.DisplayAlerts = false;
            //oWB1 = oXL1.Workbooks.Open(@"\\zygocorp\Departments\Optics\Opt_Eng\Custom Optics Admin\methodsstandardreleasenewserial.xls",
            oWB1 = oXL1.Workbooks.Open(@"C:\a\Copy of METHODSStandardReleaseNewSerial.xls",
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                     Missing.Value, Missing.Value);
            
            oWS1 = (Microsoft.Office.Interop.Excel.Worksheet)oWB1.Worksheets.get_Item("PART DATA");

            oRng1 = (Microsoft.Office.Interop.Excel.Range)oWS1.Columns["B", Type.Missing];

            currentFind = oRng1.Find(tbSearch.Text.Trim(), 
            Missing.Value,
            Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues,
            Microsoft.Office.Interop.Excel.XlLookAt.xlPart,
            Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows,
            Microsoft.Office.Interop.Excel.XlSearchDirection.xlNext,
            false,
            Missing.Value,
            Missing.Value);

            if (currentFind != null)
            {
                sAddress = currentFind.get_Address(false, false, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, false, false);
                eAddress = "N" + sAddress.TrimStart('B');

                oRng1 = oWS1.get_Range(sAddress, eAddress);
                object[,] xlData;
                xlData = (System.Object[,])oRng1.get_Value(Missing.Value);
                PartNumber = xlData[1, 1].ToString().Trim();
                Rev = xlData[1, 4].ToString().Trim();
                LotSize = xlData[1, 5].ToString().Trim();
                
                newMethod = xlData[1, 11].ToString().Trim();
                //Order_Number = xlData[10, 1].ToString().Trim();artNumber, newMethod, LotSize, ReleaseQty, Yield, Rev;
            }
            else
            {
                MessageBox.Show("Part Number was not found.");
                tbSearch.Text = "";
            }

            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName("Excel"))
            {
                p.Kill();
            }

        }
    }
}
