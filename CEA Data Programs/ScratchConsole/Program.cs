using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;

namespace ScratchConsole
{
    class Program
    {
        private static string CEA_Serial_Number;
        private static string Order_Number;
        private static string M7Date;
        private static string OldNewForm;
        private static string S1MaxScratchLength;
        private static string S1MaxScratchLengthComments;
        private static string S1MaxScratchWidth;
        private static string S1MaxScratchWidthComments;
        private static string S1NumberOfScratches;
        private static string S1NumberOfScratchesComments;
        private static string S2MaxScratchLength;
        private static string S2MaxScratchLengthComments;
        private static string S2MaxScratchWidth;
        private static string S2MaxScratchWidthComments;
        private static string S2NumberOfScratches;
        private static string S2NumberOfScratchesComments;
        private static string NumberOfScratches;
        private static string NumberOfScratchesComments;

        private static string sN;
        private static string sNpath;

        static object misValue = System.Reflection.Missing.Value;
        
        
        static void Main(string[] args)
        {
            string[] Sfolders = Directory.GetDirectories(@"\\zygocorp\" +
                @"manufacturing\nif\qc inspection reports\cea\cea\" +
                @"status_5_uploaded_to_CEA","*");

            File.WriteAllText("C:\\a\\ScratchAnalysis.txt", "CEA_Serial_Number; Order Number; " +
                    "M7_Date; S1MaxScratchLength; S1MaxScratchLengthComments; S1MaxScratchWidth; " +
                    "S1MaxScratchWidthComments; S1NumberOfScratches; S1NumberOfScratchesComments; " +
                    "S2MaxScratchLength; S2MaxScratchLengthComments; S2MaxScratchWidth; " +
                    "S2MaxScratchWidthComments; S2NumberOfScratches; S2NumberOfScratchesComments; " +
                    " NumberOfScratches; NumberOfScratchesComments"  + Environment.NewLine);

            foreach (string sn in Sfolders)
            {
                CEA_Serial_Number = "";
                Order_Number = "";
                M7Date = "";
                OldNewForm = "";
                S1MaxScratchLength = "0";
                S1MaxScratchLengthComments = "";
                S1MaxScratchWidth = "0";
                S1MaxScratchWidthComments = "";
                S1NumberOfScratches = "0";
                S1NumberOfScratchesComments = "";
                S2MaxScratchLength = "0";
                S2MaxScratchLengthComments = "";
                S2MaxScratchWidth = "0";
                S2MaxScratchWidthComments = "";
                S2NumberOfScratches = "0";
                S2NumberOfScratchesComments = "";
                NumberOfScratches = "0";
                NumberOfScratchesComments = "";
 
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


                oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Part Description");
                oRng = oWS.get_Range("D9", "D18");
                object[,] xlData;
                xlData = (System.Object[,])oRng.get_Value(misValue);
                CEA_Serial_Number = xlData[1, 1].ToString().Trim();
                Order_Number = xlData[10, 1].ToString().Trim();

                //for a single cell:
                oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Surface inspection");
                oRng = (Microsoft.Office.Interop.Excel.Range)oWS.Cells["7", "M"];
                object cell = oRng.get_Value(misValue);
                if (cell != null)
                {
                    M7Date = oRng.get_Value(misValue).ToString();
                }
                oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Surface inspection");
                oRng = (Microsoft.Office.Interop.Excel.Range)oWS.Cells["57", "B"];
                OldNewForm = oRng.get_Value(misValue).ToString();

                if (OldNewForm.Length > 10)
                {
                    oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Surface inspection");
                    oRng = oWS.get_Range("F58", "J64");
                    xlData = (System.Object[,])oRng.get_Value(misValue);
                    if (xlData[1, 1] != null)
                    {
                        S1NumberOfScratches = xlData[1, 1].ToString().Trim();
                    }
                    if (xlData[1, 5] != null)
                    {
                        S1NumberOfScratchesComments = xlData[1, 5].ToString().Trim();
                    }
                    if (xlData[2, 1] != null)
                    {
                        S1MaxScratchWidth = xlData[2, 1].ToString().Trim();
                    }
                    if (xlData[2, 5] != null)
                    {
                        S1MaxScratchWidthComments = xlData[2, 5].ToString().Trim();
                    }
                    if (xlData[3, 1] != null)
                    {
                        S1MaxScratchLength = xlData[3, 1].ToString().Trim();
                    }
                    if (xlData[3, 5] != null)
                    {
                        S1MaxScratchLengthComments = xlData[3, 5].ToString().Trim();
                    }
                    if (xlData[5, 1] != null)
                    {
                        S2NumberOfScratches = xlData[5, 1].ToString().Trim();
                    }
                    if (xlData[5, 5] != null)
                    {
                        S2NumberOfScratchesComments = xlData[5, 5].ToString().Trim();
                    }

                    if (xlData[6, 1] != null)
                    {
                        S2MaxScratchWidth = xlData[6, 1].ToString().Trim();
                    }
                    if (xlData[6, 5] != null)
                    {
                        S2MaxScratchWidthComments = xlData[6, 5].ToString().Trim();
                    }
                    if (xlData[7, 1] != null)
                    {
                        S2MaxScratchLength = xlData[7, 1].ToString().Trim();
                    }
                    if (xlData[7, 5] != null)
                    {
                        S2MaxScratchLengthComments = xlData[7, 5].ToString().Trim();
                    }
                }
                else
                {
                    oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Surface inspection");
                    oRng = oWS.get_Range("F57", "J59");
                    xlData = (System.Object[,])oRng.get_Value(misValue);
                    if (xlData[1, 1] != null)
                    {
                        S1MaxScratchLength = xlData[1, 1].ToString().Trim();
                    }
                    if (xlData[1, 5] != null)
                    {
                        S1MaxScratchLengthComments = xlData[1, 5].ToString().Trim();
                    }
                    if (xlData[2, 1] != null)
                    {
                        S2MaxScratchLength = xlData[2, 1].ToString().Trim();
                    }
                    if (xlData[2, 5] != null)
                    {
                        S2MaxScratchLengthComments = xlData[2, 5].ToString().Trim();
                    }
                    if (xlData[3, 1] != null)
                    {
                        NumberOfScratches = xlData[3, 1].ToString().Trim();
                    }
                    if (xlData[3, 5] != null)
                    {
                        NumberOfScratchesComments = xlData[3, 5].ToString().Trim();
                    }
                    
                }

                oXL.Quit();
                

                File.AppendAllText("c:\\a\\ScratchAnalysis.txt", CEA_Serial_Number + ";");
                File.AppendAllText("c:\\a\\ScratchAnalysis.txt", Order_Number + ";");
                File.AppendAllText("c:\\a\\ScratchAnalysis.txt", M7Date + ";");
                File.AppendAllText("c:\\a\\ScratchAnalysis.txt", S1MaxScratchLength + ";");
                File.AppendAllText("c:\\a\\ScratchAnalysis.txt", S1MaxScratchLengthComments + ";");
                File.AppendAllText("c:\\a\\ScratchAnalysis.txt", S1MaxScratchWidth + ";");
                File.AppendAllText("c:\\a\\ScratchAnalysis.txt", S1MaxScratchWidthComments + ";");
                File.AppendAllText("c:\\a\\ScratchAnalysis.txt", S1NumberOfScratches + ";");
                File.AppendAllText("c:\\a\\ScratchAnalysis.txt", S1NumberOfScratchesComments + ";");
                File.AppendAllText("c:\\a\\ScratchAnalysis.txt", S2MaxScratchLength + ";");
                File.AppendAllText("c:\\a\\ScratchAnalysis.txt", S2MaxScratchLengthComments + ";");
                File.AppendAllText("c:\\a\\ScratchAnalysis.txt", S2MaxScratchWidth + ";");
                File.AppendAllText("c:\\a\\ScratchAnalysis.txt", S2MaxScratchWidthComments + ";");
                File.AppendAllText("c:\\a\\ScratchAnalysis.txt", S2NumberOfScratches + ";");
                File.AppendAllText("c:\\a\\ScratchAnalysis.txt", S2NumberOfScratchesComments + ";");
                File.AppendAllText("c:\\a\\ScratchAnalysis.txt", NumberOfScratches + ";");
                File.AppendAllText("c:\\a\\ScratchAnalysis.txt", NumberOfScratchesComments + Environment.NewLine);
            }
        }
    }
}
