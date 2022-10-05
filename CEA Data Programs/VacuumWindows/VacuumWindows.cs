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
using System.Runtime.InteropServices;

namespace VacuumWindows
{
    public partial class Form1 : Form
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
        private int countA = 0;
        private int countB = 0;

        object misValue = System.Reflection.Missing.Value;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DesiredDirectory[0] = @"\\zygocorp\manufacturing\nif\" +
            @"qc inspection reports\cea\CEA Vacuum Window";

            string[] strArray0 = Directory.GetDirectories(DesiredDirectory[0], "CEA-??-????");

            Array.Copy(strArray0, Sfolders, strArray0.Length);

            string mark = DateTime.Now.ToString(@"MM-dd-yy");

            File.WriteAllText("C:\\a\\CEAvacuumWindows" + mark + "Export.txt", "CEA_Serial_Number, Order Number," +
                    "Date_Finished, Date_Zygo_Send_RCI, CEA_Answer, Comments, Date_Instert_Into_Sirocco," +
                    "NCMR_Quantity, NCMR_Serial_Number,Shipping_Date_To_Cesta, Frame_Serial_Number," +
                    "Container_Serial_Number, Slab_Final_Length,Slab_Final_Width, Slab_Final_Thickness," +
                    "Parallelism_S1_S2, Power_PV, RMS_P_10mm , RMS_P_100mm, RMS_P_100_33mm, RMS_P_33_10mm," +
                    "RMS_P_10_2_5mm, Defect_RMS_S11_P2_5, Defect_RMS_S101_P1, Defect_RMS_S21_P2_5," +
                    "Defect_RMS_S201_P1, Defect_RMS_S1001_P01, Defect_RMS_S2001_P01," +
                    "PVRI_Model_Used" +
                    Environment.NewLine);

           

            foreach (string sn in Sfolders)
            {
                if (sn != null)
                {
                    sNpath = sn;
                    sN = sn.Substring((sn.Length - 7), 7);

                    countA = countA++;
                    File.AppendAllText("c:\\a\\VacuumWindowFolderCheck" + mark + ".txt", countA.ToString() + "   " + sn +  Environment.NewLine);

                    if (sN != "99-9999" && sN != "11-1111")
                    {
                        files = Directory.GetFiles(sNpath, "*.xls");
                        //there are both PVRI and RCI titles

                        if (files.Length == 0)
                        {
                            string[] downOneLevel = Directory.GetDirectories(sNpath, sN + " R*");

                            if (downOneLevel.Length > 0)
                            {
                                files = Directory.GetFiles(downOneLevel[0], "*.xls");
                            }
                        }

                        if (files.Length != 0)
                        {
                            /*
                             *  Need to declare workbooks as well as workbook and step through the opening
                             *  in order to be able to close Excel at the end of this loop
                             */
                            _Application oXL;
                            Workbooks oWBS;
                            Workbook oWB;
                            Sheets oS;
                            Worksheet oWS;
                            Range oRng;

                            /*  Excel components explicitly named to that .com can close at the end
                                trying to avoid double dot definitions
                            */

                            oXL = new Microsoft.Office.Interop.Excel.Application();
                            oXL.DisplayAlerts = false;

                            oWBS = oXL.Workbooks;

                            oWB = oWBS.Open(files[0],
                                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                     Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                     Missing.Value, Missing.Value);

                            oS = oWB.Sheets;

                            oWS = oS.Item["Part Description"];

                            oRng = oWS.Range["D9", "D18"];
                            object[,] xlData;
                            xlData = (System.Object[,])oRng.Value[misValue];
                            CEA_Serial_Number = xlData[1, 1].ToString().Trim();

                            countB = countB++;
                            File.AppendAllText("c:\\a\\VacuumWindowFileCheck" + mark + ".txt", countB.ToString() + "   " + sn + Environment.NewLine);

                            try
                            {
                                Order_Number = xlData[10, 1].ToString().Trim();
                                if (Order_Number.Length < 1)
                                {
                                    File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", CEA_Serial_Number + "  Missing Order Number " + Environment.NewLine);
                                    oXL.Quit();
                                    continue;    //stops this pass through the foreach and goes to the next at the top
                                }
                            }
                            catch (Exception ex)
                            {
                                //MessageBox.Show(sN.ToString() + "  " + ex.ToString());
                                File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", CEA_Serial_Number + "  Missing Order Number  " + Environment.NewLine);
                                oXL.Quit();
                                continue;
                            }


                            oWS = oS.Item["Part Description"];
                            oRng = oWS.Cells["24", "C"];
                            PVRI_Model_Used = oRng.Value[misValue].ToString();

                            oWS = oS.Item["Mechanical Inspection"];
                            oRng = oWS.Range["F7", "F16"];

                            xlData = (System.Object[,])oRng.Value[misValue];
                            if (xlData[1, 1] != null)
                            {
                                Slab_Final_Length = xlData[1, 1].ToString().Trim();
                            }
                            else
                            {
                                File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", CEA_Serial_Number + "  Missing Final Length  " + Environment.NewLine);
                                continue;
                            }
                            Slab_Final_Width = xlData[2, 1].ToString().Trim();
                            Slab_Final_Thickness = xlData[3, 1].ToString().Trim();
                            Parallelism_S1_S2 = xlData[10, 1].ToString().Trim();


                            oWS = oS.Item["Surface Inspection"];
                            oRng = oWS.Cells["17", "F"];
                            Date_Finished = oRng.Value[misValue].ToString();

                            

                            if (PVRI_Model_Used.Contains("2017"))
                            {
                                /*
                                 * 
                                 * 
                                 */
                                oRng = oWS.Range["S11", "Z11"];

                                xlData = (System.Object[,])oRng.Value[misValue];

                                Defect_RMS_S11_P2_5 = xlData[1, 1].ToString().Trim();
                                Defect_RMS_S21_P2_5 = xlData[1, 2].ToString().Trim();

                                Defect_RMS_S101_P1 = xlData[1, 3].ToString().Trim();
                                Defect_RMS_S201_P1 = xlData[1, 4].ToString().Trim();

                                Defect_RMS_S1001_P01 = xlData[1, 7].ToString().Trim();
                                Defect_RMS_S2001_P01 = xlData[1, 8].ToString().Trim();
                            }
                            else
                            {
                                //"Anaphase data roughness s1_1X";
                                oWS = oS.Item[7];
                                oRng = oWS.Range["B13", "B15"];
                                if (oWS.Name.ToString().Trim() == "Anaphase data roughness S1") { skip = true; }

                                xlData = (System.Object[,])oRng.Value[misValue];
                                if (xlData[1, 1] != null)
                                {
                                    Defect_RMS_S11_P2_5 = xlData[1, 1].ToString().Trim();
                                    Defect_RMS_S101_P1 = xlData[3, 1].ToString().Trim();
                                }

                                //"Anaphase data roughness s2_1X";
                                oWS = oS.Item[9];
                                oRng = oWS.Range["B13", "B15"];

                                xlData = (System.Object[,])oRng.Value[misValue];
                                if (xlData[1, 1] != null)
                                {
                                    Defect_RMS_S21_P2_5 = xlData[1, 1].ToString().Trim();
                                    Defect_RMS_S201_P1 = xlData[3, 1].ToString().Trim();
                                }

                                //for a single cell:
                                if (skip == false)
                                {
                                    oWS = oS.Item["Surface Inspection"];
                                    oRng = oWS.Cells["26", "F"];
                                    Defect_RMS_S1001_P01 = oRng.Value[misValue].ToString();

                                    oWS = oS.Item["Surface Inspection"];
                                    oRng = oWS.Cells["27", "F"];
                                    Defect_RMS_S2001_P01 = oRng.Value[misValue].ToString();
                                }
                                else
                                {
                                    Defect_RMS_S1001_P01 = "";
                                    Defect_RMS_S2001_P01 = "";
                                    skip = false;
                                }

                            }


                            oWS = oS.Item["Anaphase data TWF"];
                            oRng = oWS.get_Range("B2", "B24");

                            xlData = (System.Object[,])oRng.Value[misValue];
                            if (xlData[1, 1] != null)
                            {
                                Power_PV = xlData[1, 1].ToString().Trim();
                                RMS_P_10mm = xlData[8, 1].ToString().Trim();
                                RMS_P_100mm = xlData[9, 1].ToString().Trim();
                                RMS_P_100_33mm = xlData[10, 1].ToString().Trim();
                                RMS_P_33_10mm = xlData[11, 1].ToString().Trim();
                                RMS_P_10_2_5mm = xlData[12, 1].ToString().Trim();
                            }

                            //CloseExcel(oRng);


                            //CloseExcel(oWS);
                            //CloseExcel(oWSS);
                            //oWB.Close(null, null, null);
                            //CloseExcel(oWB);
                            //oWBS.Close();
                            //CloseExcel(oWBS);
                            oXL.Quit();
                            //CloseExcel(oXL);

                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", CEA_Serial_Number + ",");
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Order_Number + ",");
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Date_Finished + ",");
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Date_Zygo_Send_RCI + ",");
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", CEA_Answer + ",");
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Comments + ",");
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Date_Insert_Into_Sirocco + ",");
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", NCMR_Quantity + ",");
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", NCMR_Serial_Number + ",");
                            // I don't know why I put in these if clauses as they don't do anything.
                            if (Shipping_Date_To_Cesta == "") { Shipping_Date_To_Cesta = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Shipping_Date_To_Cesta + ",");
                            if (Frame_Serial_Number == "") { Frame_Serial_Number = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Frame_Serial_Number + ",");
                            if (Container_Serial_Number == "") { Container_Serial_Number = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Container_Serial_Number + ",");
                            if (Slab_Final_Length == "") { Slab_Final_Length = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Slab_Final_Length + ",");
                            if (Slab_Final_Width == "") { Slab_Final_Width = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Slab_Final_Width + ",");
                            if (Slab_Final_Thickness == "") { Slab_Final_Thickness = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Slab_Final_Thickness + ",");
                            if (Parallelism_S1_S2 == "") { Parallelism_S1_S2 = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Parallelism_S1_S2 + ",");
                            if (Power_PV == "") { Power_PV = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Power_PV + ",");
                            if (RMS_P_10mm == "") { RMS_P_10mm = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", RMS_P_10mm + ",");
                            if (RMS_P_100mm == "") { RMS_P_100mm = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", RMS_P_100mm + ",");
                            if (RMS_P_100_33mm == "") { RMS_P_100_33mm = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", RMS_P_100_33mm + ",");
                            if (RMS_P_33_10mm == "") { RMS_P_33_10mm = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", RMS_P_33_10mm + ",");
                            if (RMS_P_10_2_5mm == "") { RMS_P_10_2_5mm = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", RMS_P_10_2_5mm + ",");
                            if (Defect_RMS_S11_P2_5 == "") { Defect_RMS_S11_P2_5 = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Defect_RMS_S11_P2_5 + ",");
                            if (Defect_RMS_S101_P1 == "") { Defect_RMS_S101_P1 = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Defect_RMS_S101_P1 + ",");
                            if (Defect_RMS_S21_P2_5 == "") { Defect_RMS_S21_P2_5 = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Defect_RMS_S21_P2_5 + ",");
                            if (Defect_RMS_S201_P1 == "") { Defect_RMS_S201_P1 = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Defect_RMS_S201_P1 + ",");
                            if (Defect_RMS_S1001_P01 == "") { Defect_RMS_S1001_P01 = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Defect_RMS_S1001_P01 + ",");
                            if (Defect_RMS_S2001_P01 == "") { Defect_RMS_S2001_P01 = ""; }
                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", Defect_RMS_S2001_P01 + ",");
                            if (PVRI_Model_Used == "") { PVRI_Model_Used = ""; }

                            File.AppendAllText("c:\\a\\CEAvacuumWindows" + mark + "Export.txt", PVRI_Model_Used + Environment.NewLine);


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
                }           //end length test
            }           //end foreach
            //Close();
        }           //end form1


        private void CloseExcel(object o)
        {
            try
            {
                Marshal.FinalReleaseComObject(o);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                o = null;
            }

        }
    }
}

