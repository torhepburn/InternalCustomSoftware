using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;


namespace QuickTest
{
    public partial class QuickTest : Form
    {
        private string sN;
        private string sNpath;
        
        object misValue = System.Reflection.Missing.Value;

        private string PVRI;

        public QuickTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] Sfolders = Directory.GetDirectories(@"\\zygocorp\" +
                @"manufacturing\nif\qc inspection reports\cea\cea\" +
                @"status_5_uploaded_to_CEA", "*");

            string stamp = DateTime.Now.ToShortDateString();
            stamp = stamp.Replace("/", "-");

            //File.WriteAllText("C:\\a\\QuickTest " + stamp + ".txt", "CEA_Serial_Number, Version " +
            //        Environment.NewLine);

            foreach (string sn in Sfolders)
            {
                PVRI = "";
                
                sNpath = sn;
                sN = sn.Substring((sn.Length - 7), 7);

                Microsoft.Office.Interop.Excel.Application oXL;
                Microsoft.Office.Interop.Excel.Workbook oWB;
                Microsoft.Office.Interop.Excel.Worksheet oWS;
                Microsoft.Office.Interop.Excel.Range oRng;

                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.DisplayAlerts = false;
                oWB = oXL.Workbooks.Open(sNpath + "\\pvri_" + sN + "_zygo_polishing.xls",
                         Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                         Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                         Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                         Missing.Value, Missing.Value);


                //oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Part Description");
                //oRng = (Microsoft.Office.Interop.Excel.Range)oWS.Cells["24", "D"];
                //object cell = oRng.get_Value(misValue);
                //if (cell != null)
                //{
                //    PVRI = oRng.get_Value(misValue).ToString();
                //}
                //else
                //{
                //    PVRI = "XXXXXXXX";
                //}
                
                oXL.Quit();
                File.AppendAllText("c:\\a\\QuickTest " + stamp + ".txt", sN + Environment.NewLine);
                //File.AppendAllText("c:\\a\\QuickTest " + stamp + ".txt", sN + ",");
                //File.AppendAllText("c:\\a\\QuickTest " + stamp + ".txt", PVRI + Environment.NewLine);
            }
        }
    }
}