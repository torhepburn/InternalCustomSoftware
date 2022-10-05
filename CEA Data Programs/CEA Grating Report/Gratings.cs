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
using System.Data.OleDb;
using System.IO;


namespace CEA_Grating_Report
{
    public partial class Gratings : Form
    {
        private string CEA_Serial_Number;
        private string Order_Number;
        private string Date_Finished;
        private string Date_Zygo_Send_RCI;
        private string CEA_Answer;
        private string Comments;
        private string Date_Insert_Into_Sirocco;
        private string NCMR_Quantity;
        private string NCMR_Serial_Number;
        private string Shipping_Date_To_Cesta;
        private string Frame_Serial_Number;
        private string Container_Serial_Number;
        private string Slab_Final_Length;
        private string Slab_Final_Width;
        private string Slab_Final_Thickness;
        private string Parallelism_S1_S2;
        private string Power_PV;
        private string RMS_P_10mm;
        private string RMS_P_100mm;
        private string RMS_P_100_33mm;
        private string RMS_P_33_10mm;
        private string RMS_P_10_2_5mm;
        private string Defect_RMS_S11_P2_5;
        private string Defect_RMS_S101_P1;
        private string Defect_RMS_S21_P2_5;
        private string Defect_RMS_S201_P1;
        private string Defect_RMS_S1001_P01;
        private string Defect_RMS_S2001_P01;
        private string PVRI_Model_Used;

        private string[] DesiredDirectory = new string[5];
        private string[] Sfolders = new string[325];
        private bool skip = false;

        private string sN;
        private string sNpath;
        private string[] files = new string[10];
        private int counter;

        object misValue = System.Reflection.Missing.Value;
        
        
        public Gratings()
        {
            InitializeComponent();
        }

        private void Gratings_Load(object sender, EventArgs e)
        {
            DesiredDirectory[0] = @"\\zygocorp\manufacturing\nif\" +
            @"qc inspection reports\cea\CEA Grating Substrates\1 Omega Grating";
            DesiredDirectory[1] = @"\\Zygocorp\manufacturing\NIF\" +
            @"QC Inspection Reports\CEA\CEA Grating Substrates\3 Omega Grating\08-xxxx";
            DesiredDirectory[2] = @"\\Zygocorp\manufacturing\NIF\" +
            @"QC Inspection Reports\CEA\CEA Grating Substrates\3 Omega Grating\09-xxxx";
            DesiredDirectory[3] = @"\\Zygocorp\manufacturing\NIF\" +
            @"QC Inspection Reports\CEA\CEA Grating Substrates\3 Omega Grating\10-xxxx";
            DesiredDirectory[4] = @"\\Zygocorp\manufacturing\NIF\" +
            @"QC Inspection Reports\CEA\CEA Grating Substrates\3 Omega Grating\11-xxxx";

            string[] strArray0 = Directory.GetDirectories(DesiredDirectory[0], "*??-????");
            string[] strArray1 = Directory.GetDirectories(DesiredDirectory[1], "??-????");
            string[] strArray2 = Directory.GetDirectories(DesiredDirectory[2], "??-????");
            string[] strArray3 = Directory.GetDirectories(DesiredDirectory[3], "??-????");
            string[] strArray4 = Directory.GetDirectories(DesiredDirectory[4], "??-????");

            // sourceArray, destinationArray, length
            Array.Copy(strArray0, Sfolders, strArray0.Length);
            //  sourceArray, sourceIndex, destinationArray, destinationIndex, length
            Array.Copy(strArray1, 0, Sfolders, strArray0.Length, strArray1.Length);
            Array.Copy(strArray2, 0, Sfolders, strArray0.Length + strArray1.Length, strArray2.Length);
            Array.Copy(strArray3, 0, Sfolders, strArray0.Length + strArray1.Length + strArray2.Length, strArray3.Length);
            Array.Copy(strArray4, 0, Sfolders, strArray0.Length + strArray1.Length + strArray2.Length + strArray3.Length, strArray4.Length);

            string mark = DateTime.Now.ToString(@"MM-dd-yy");

            File.WriteAllText("C:\\a\\CEAgratings" + mark + "Export.txt", "CEA_Serial_Number, " +
                    "Order Number," +
                    "Date_Finished, Date_Zygo_Send_RCI, CEA_Answer, Comments, Date_Instert_Into_Sirocco," +
                    "NCMR_Quantity, NCMR_Serial_Number,Shipping_Date_To_Cesta, Frame_Serial_Number," +
                    "Container_Serial_Number, Slab_Final_Length,Slab_Final_Width, Slab_Final_Thickness," +
                    "Parallelism_S1_S2, Power_PV, RMS_P_10mm , RMS_P_100mm, RMS_P_100_33mm, RMS_P_33_10mm," +
                    "RMS_P_10_2_5mm, Defect_RMS_S11_P2_5, Defect_RMS_S101_P1, Defect_RMS_S21_P2_5," +
                    "Defect_RMS_S201_P1, Defect_RMS_S1001_P01, Defect_RMS_S2001_P01, " +
                    "PVRI_Model_Used" +
                    Environment.NewLine);

            foreach (string sn in Sfolders)
            {
                sNpath = sn;
                sN = sn.Substring((sn.Length - 7), 7);

                //if (sN == "10-0459" | sN == "10-0460") // | sN == "09-0705" | sN == "09-0703"
                    //| sN == "09-0709" | sN == "09-0704-NEW" )
                if (sN != "99-9999" && sN != "11-1111")
                {
                    files = Directory.GetFiles(sNpath, "PVRI*.xls");

                    if (files.Length == 0)
                    {
                        string[] downOneLevel = Directory.GetDirectories(sNpath, sN + " R*");

                        if (downOneLevel.Length > 0)
                        {
                            files = Directory.GetFiles(downOneLevel[0], "PVRI*.xls");
                        }
                    }

                    if (files.Length != 0)
                    {
                        Microsoft.Office.Interop.Excel.Application oXL;
                        Microsoft.Office.Interop.Excel.Workbook oWB;
                        Microsoft.Office.Interop.Excel.Worksheet oWS;
                        Microsoft.Office.Interop.Excel.Range oRng;

                        oXL = new Microsoft.Office.Interop.Excel.Application();
                        oXL.DisplayAlerts = false;
                        oWB = oXL.Workbooks.Open(files[0],
                                 Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                 Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                 Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                 Missing.Value, Missing.Value);


                        oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Part Description");
                        oRng = oWS.get_Range("D9", "D18");
                        object[,] xlData;
                        xlData = (System.Object[,])oRng.get_Value(misValue);
                        CEA_Serial_Number = xlData[1, 1].ToString().Trim();
                        
                        try
                        {
                            Order_Number = xlData[10, 1].ToString().Trim();
                            if (Order_Number.Length < 1)
                            {
                                File.AppendAllText("c:\\a\\CEAgratingsExport.txt", CEA_Serial_Number + "  Missing Order Number " + Environment.NewLine);
                                oXL.Quit();
                                continue;    //stops this pass through the foreach and goes to the next at the top
                            }
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(sN.ToString() + "  " + ex.ToString());
                            File.AppendAllText("c:\\a\\CEAgratingsExport.txt", CEA_Serial_Number + "  Missing Order Number  " + Environment.NewLine);
                            oXL.Quit();
                            continue;
                        }
                        

                        oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Part Description");
                        oRng = (Microsoft.Office.Interop.Excel.Range)oWS.Cells["24", "C"];
                        PVRI_Model_Used = oRng.get_Value(misValue).ToString();
                        
                        oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Mechanical Inspection");
                        oRng = oWS.get_Range("F7", "F16");

                        xlData = (System.Object[,])oRng.get_Value(misValue);
                        if (xlData[1, 1] != null)
                        {
                            Slab_Final_Length = xlData[1, 1].ToString().Trim();
                        }
                        else
                        {
                            File.AppendAllText("c:\\a\\CEAgratingsExport.txt", CEA_Serial_Number + "  Missing Final Length  " + Environment.NewLine);
                            continue;
                        }
                        Slab_Final_Width = xlData[2, 1].ToString().Trim();
                        Slab_Final_Thickness = xlData[3, 1].ToString().Trim();
                        Parallelism_S1_S2 = xlData[10, 1].ToString().Trim();


                        oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Surface Inspection");
                        oRng = oWS.get_Range("F19", "F22");
                        xlData = (System.Object[,])oRng.get_Value(misValue);

                        oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Anaphase data TWF");
                        oRng = oWS.get_Range("B2", "B24");

                        xlData = (System.Object[,])oRng.get_Value(misValue);
                        if (xlData[1, 1] != null)
                        {
                            Power_PV = xlData[1, 1].ToString().Trim();
                            RMS_P_10mm = xlData[8, 1].ToString().Trim();
                            RMS_P_100mm = xlData[9, 1].ToString().Trim();
                            RMS_P_100_33mm = xlData[10, 1].ToString().Trim();
                            RMS_P_33_10mm = xlData[11, 1].ToString().Trim();
                            RMS_P_10_2_5mm = xlData[12, 1].ToString().Trim();
                            Date_Finished = xlData[23, 1].ToString().Trim();
                        }

                        //if (sN != "07-0317" && sN != "07-0318" && sN != "07-0319" && sN != "07-0320" &&
                        //    sN != "07-0321" && sN != "07-0322" && sN != "07-0323" && sN != "07-0324" &&
                        //    sN != "07-0325" && sN != "07-0326" && sN != "07-0327" && sN != "07-0328" &&
                        //    sN != "07-0329" && sN != "07-0330" && sN != "07-0332" && sN != "07-0333" &&
                        //    sN != "07-0334" && sN != "07-0335" && sN != "07-0336" && sN != "07-0337" &&
                        //    sN != "08-0274" && sN != "08-0275" &&
                        //    sN != "06-0791" && sN != "06-0794" && sN != "06-0795" && sN != "06-0796" && 
                        //    sN != "06-0797" && sN != "06-0798" && sN != "06-0799" && sN != "06-0800" &&
                        //    sN != "07-0308" && sN != "07-0309" && sN != "07-0310" && sN != "07-0311")
                        
                        int numSheets = oWB.Sheets.Count;
                        string tt = oWB.Name.ToString();
                        oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item(7);
                        //Microsoft .Office.Interop .Excel .Worksheet worksheet  = sheets.get_Item(1);
                        string name = oWS.Name;

                        //oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Anaphase data roughness s1_1X");
                        oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item(7);
                        oRng = oWS.get_Range("B13", "B15");
                        if (oWS.Name.ToString().Trim() == "Anaphase data roughness S1") { skip = true; }
                        //if (sN == "09-0683") { skip = true; }

                        xlData = (System.Object[,])oRng.get_Value(misValue);
                        if (xlData[1, 1] != null)
                        {
                            Defect_RMS_S11_P2_5 = xlData[1, 1].ToString().Trim();
                            Defect_RMS_S101_P1 = xlData[3, 1].ToString().Trim();
                        }

                        //oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Anaphase data roughness s2_1X");
                        oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item(9);
                        oRng = oWS.get_Range("B13", "B15");

                        xlData = (System.Object[,])oRng.get_Value(misValue);
                        if (xlData[1, 1] != null)
                        {
                            Defect_RMS_S21_P2_5 = xlData[1, 1].ToString().Trim();
                            Defect_RMS_S201_P1 = xlData[3, 1].ToString().Trim();
                        }

                        //for a single cell:
                        if (skip == false)
                        {
                            oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Surface Inspection");
                            oRng = (Microsoft.Office.Interop.Excel.Range)oWS.Cells["26", "F"];
                            Defect_RMS_S1001_P01 = oRng.get_Value(misValue).ToString();

                            oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Surface Inspection");
                            oRng = (Microsoft.Office.Interop.Excel.Range)oWS.Cells["27", "F"];
                            Defect_RMS_S2001_P01 = oRng.get_Value(misValue).ToString();
                        }
                        else
                        {
                            Defect_RMS_S1001_P01 = "";
                            Defect_RMS_S2001_P01 = "";
                            skip = false;
                        }
                        
                        oXL.Quit();

                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", CEA_Serial_Number + ",");
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Order_Number + ",");
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Date_Finished + ",");
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Date_Zygo_Send_RCI + ",");
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", CEA_Answer + ",");
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Comments + ",");
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Date_Insert_Into_Sirocco + ",");
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", NCMR_Quantity + ",");
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", NCMR_Serial_Number + ",");
                        // I don't know why I put in these if clauses as they don't do anything.
                        if (Shipping_Date_To_Cesta == "") { Shipping_Date_To_Cesta = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Shipping_Date_To_Cesta + ",");
                        if (Frame_Serial_Number == "") { Frame_Serial_Number = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Frame_Serial_Number + ",");
                        if (Container_Serial_Number == "") { Container_Serial_Number = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Container_Serial_Number + ",");
                        if (Slab_Final_Length == "") { Slab_Final_Length = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Slab_Final_Length + ",");
                        if (Slab_Final_Width == "") { Slab_Final_Width = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Slab_Final_Width + ",");
                        if (Slab_Final_Thickness == "") { Slab_Final_Thickness = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Slab_Final_Thickness + ",");
                        if (Parallelism_S1_S2 == "") { Parallelism_S1_S2 = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Parallelism_S1_S2 + ",");
                        if (Power_PV == "") { Power_PV = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Power_PV + ",");
                        if (RMS_P_10mm == "") { RMS_P_10mm = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", RMS_P_10mm + ",");
                        if (RMS_P_100mm == "") { RMS_P_100mm = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", RMS_P_100mm + ",");
                        if (RMS_P_100_33mm == "") { RMS_P_100_33mm = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", RMS_P_100_33mm + ",");
                        if (RMS_P_33_10mm == "") { RMS_P_33_10mm = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", RMS_P_33_10mm + ",");
                        if (RMS_P_10_2_5mm == "") { RMS_P_10_2_5mm = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", RMS_P_10_2_5mm + ",");
                        if (Defect_RMS_S11_P2_5 == "") { Defect_RMS_S11_P2_5 = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Defect_RMS_S11_P2_5 + ",");
                        if (Defect_RMS_S101_P1 == "") { Defect_RMS_S101_P1 = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Defect_RMS_S101_P1 + ",");
                        if (Defect_RMS_S21_P2_5 == "") { Defect_RMS_S21_P2_5 = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Defect_RMS_S21_P2_5 + ",");
                        if (Defect_RMS_S201_P1 == "") { Defect_RMS_S201_P1 = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Defect_RMS_S201_P1 + ",");
                        if (Defect_RMS_S1001_P01 == "") { Defect_RMS_S1001_P01 = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Defect_RMS_S1001_P01 + ",");
                        if (Defect_RMS_S2001_P01 == "") { Defect_RMS_S2001_P01 = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", Defect_RMS_S2001_P01 + ",");
                        if (PVRI_Model_Used == "") { PVRI_Model_Used = ""; }
                        File.AppendAllText("C:\\a\\CEAgratings" + mark + "Export.txt", PVRI_Model_Used + Environment.NewLine);


                        NCMR_Quantity = "";
                        NCMR_Serial_Number = "";
                        Defect_RMS_S11_P2_5 = "";
                        Defect_RMS_S101_P1 = "";
                        Defect_RMS_S21_P2_5 = "";
                        Defect_RMS_S201_P1 = "";
                        Defect_RMS_S1001_P01 = "";
                        Defect_RMS_S2001_P01 = "";
                        PVRI_Model_Used = "";

                        oXL.Quit();

                    }
                }
            }
            Close();
        }
    }
}