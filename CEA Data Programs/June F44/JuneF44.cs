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
using System.Data.OleDb;

namespace June_F44
{
     public partial class JuneF44 : Form
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
        private string Power_PV9x;
        private string RMS_P_10mm9x;
        private string F44;

        private bool skip = false;

        private string S5Directory = "\\\\zygocorp\\manufacturing\\nif\\" +
            "qc inspection reports\\cea\\cea\\status_5_uploaded_to_CEA";

        private string sN;
        private string sNpath;

        object misValue = System.Reflection.Missing.Value;
        

        public JuneF44()
        {
            InitializeComponent();
        }

        private void JuneF44_Load(object sender, EventArgs e)
        {
            string[] Sfolders = Directory.GetDirectories(S5Directory,"*" );


            File.WriteAllText("C:\\a\\CEAexport.txt", "CEA_Serial_Number, Order Number," +
                    "Date_Finished, Date_Zygo_Send_RCI, CEA_Answer, Comments, Date_Instert_Into_Sirocco," +
                    "NCMR_Quantity, NCMR_Serial_Number,Shipping_Date_To_Cesta, Frame_Serial_Number," +
                    "Container_Serial_Number, Slab_Final_Length,Slab_Final_Width, Slab_Final_Thickness," +
                    "Parallelism_S1_S2, Power_PV, RMS_P_10mm , RMS_P_100mm, RMS_P_100_33mm, RMS_P_33_10mm," +
                    "RMS_P_10_2_5mm, Defect_RMS_S11_P2_5, Defect_RMS_S101_P1, Defect_RMS_S21_P2_5," +
                    "Defect_RMS_S201_P1, Defect_RMS_S1001_P01, Defect_RMS_S2001_P01, Power_PV9x," +
                    "RMS_P_10mm9x, F44" + Environment.NewLine);
                            
            foreach (string sn in Sfolders)
            {
                //string sn = "\\\\zygocorp\\manufacturing\\nif\\" +
                //"qc inspection reports\\cea\\cea\\status_5_uploaded_to_CEA\\01-0943";
        
                
                sNpath = sn;
                sN = sn.Substring((sn.Length - 7), 7);



                OleDbConnection con = new OleDbConnection();

                con.ConnectionString = "provider=microsoft.jet.oledb.4.0;Data Source= " +
                    "\\\\zygocorp\\manufacturing\\nif\\qc inspection reports\\cea\\cea\\RCI_submit.mdb; " +
                    "Mode=ReadWrite; Persist Security Info=False";

                con.Open();

                OleDbCommand cmd = new OleDbCommand("select * from tbl_ordernumber where o_sn = '" + sN + "'");

                cmd.Connection = con;

                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (!dr.IsDBNull(8))
                        { Date_Zygo_Send_RCI = dr.GetDateTime(8).ToShortDateString().Trim(); }
                        else { Date_Zygo_Send_RCI = ""; }
                        if (!dr.IsDBNull(9))
                        { Shipping_Date_To_Cesta = dr.GetDateTime(9).ToShortDateString().Trim(); }
                        else { Shipping_Date_To_Cesta = ""; }
                        if (!dr.IsDBNull(4))
                        { Frame_Serial_Number = dr.GetString(4).Trim(); }
                        else { Frame_Serial_Number = ""; }
                        if (!dr.IsDBNull(12))
                        { 
                            Container_Serial_Number = dr.GetString(12).Trim();
                            Container_Serial_Number = Container_Serial_Number.Substring(0, 2) +
                                "-" + Container_Serial_Number.Substring(2, 4);
                        }
                        else { Container_Serial_Number = ""; }
                        if (!dr.IsDBNull(13))
                        { NCMR_Serial_Number = dr.GetString(13).Trim(); }
                        else { NCMR_Serial_Number = ""; }

                    }
                }

                NCMR_Serial_Number = NCMR_Serial_Number.Replace(",", " ");

                cmd = new OleDbCommand
                    ("select count(id) from tbl_order_NCMR where N_order_sn = '" + sN + "' and " +
                    " N_Reportable = -1");

                cmd.Connection = con;

                object o = cmd.ExecuteScalar();

                NCMR_Quantity = o.ToString();



                con.Close();



                Microsoft.Office.Interop.Excel.Application oXL;
                Microsoft.Office.Interop.Excel.Workbook oWB;
                Microsoft.Office.Interop.Excel.Worksheet oWS;
                Microsoft.Office.Interop.Excel.Range oRng;

                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.DisplayAlerts = false;
                oWB = oXL.Workbooks.Open(sNpath  + "\\pvri_" + sN + "_zygo_polishing.xls",
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



                oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Mechanical Inspection");
                oRng = oWS.get_Range("F15", "F25");

                xlData = (System.Object[,])oRng.get_Value(misValue);
                Slab_Final_Length = xlData[1, 1].ToString().Trim();
                Slab_Final_Width = xlData[2, 1].ToString().Trim();
                Slab_Final_Thickness = xlData[3, 1].ToString().Trim();
                Parallelism_S1_S2 = xlData[11, 1].ToString().Trim();


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

                int numSheets = oWB.Sheets.Count;
                string tt = oWB.Name.ToString();
                oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item(7);
                //Microsoft .Office.Interop .Excel .Worksheet worksheet  = sheets.get_Item(1);
                string name = oWS.Name;
 
                //oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Anaphase data roughness s1_1X");
                oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item(7);
                oRng = oWS.get_Range("B13", "B15");
                if (oWS.Name.ToString().Trim() == "Anaphase data roughness S1") { skip = true; }

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
                    oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Anaphase data roughness S1_10X");
                    oRng = (Microsoft.Office.Interop.Excel.Range)oWS.Cells["17", "B"];
                    Defect_RMS_S1001_P01 = oRng.get_Value(misValue).ToString();

                    oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Anaphase data roughness S2_10X");
                    oRng = (Microsoft.Office.Interop.Excel.Range)oWS.Cells["17", "B"];
                    Defect_RMS_S2001_P01 = oRng.get_Value(misValue).ToString();
                }
                else
                {
                    Defect_RMS_S1001_P01 = "";
                    Defect_RMS_S2001_P01 = "";
                    skip = false;
                }

                oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Surface inspection");
                oRng = oWS.get_Range("F17", "F44");

                xlData = (System.Object[,])oRng.get_Value(misValue);
                if (xlData[1, 1] != null)
                {
                    Power_PV9x = xlData[1, 1].ToString().Trim();
                    RMS_P_10mm9x = xlData[3, 1].ToString().Trim();
                    F44 = xlData[28, 1].ToString().Trim();
                }
                string test = "test";

                oXL.Quit();

                File.AppendAllText("c:\\a\\ceaExport.txt", CEA_Serial_Number + ",");
                File.AppendAllText("c:\\a\\ceaExport.txt", Order_Number + ",");
                File.AppendAllText("c:\\a\\ceaExport.txt", Date_Finished + ",");
                File.AppendAllText("c:\\a\\ceaExport.txt", Date_Zygo_Send_RCI + ",");
                File.AppendAllText("c:\\a\\ceaExport.txt", CEA_Answer + ",");
                File.AppendAllText("c:\\a\\ceaExport.txt", Comments + ",");
                File.AppendAllText("c:\\a\\ceaExport.txt", Date_Insert_Into_Sirocco + ",");
                File.AppendAllText("c:\\a\\ceaExport.txt", NCMR_Quantity + ",");
                File.AppendAllText("c:\\a\\ceaExport.txt", NCMR_Serial_Number + ",");
                if (Shipping_Date_To_Cesta == "") { Shipping_Date_To_Cesta = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", Shipping_Date_To_Cesta + ",");
                if(Frame_Serial_Number ==""){Frame_Serial_Number = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", Frame_Serial_Number + ",");
                if (Container_Serial_Number == "") { Container_Serial_Number = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", Container_Serial_Number + ",");
                if (Slab_Final_Length == "") { Slab_Final_Length = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", Slab_Final_Length + ",");
                if (Slab_Final_Width == "") { Slab_Final_Width = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", Slab_Final_Width + ",");
                if (Slab_Final_Thickness == "") { Slab_Final_Thickness = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", Slab_Final_Thickness + ",");
                if (Parallelism_S1_S2 == "") {Parallelism_S1_S2 = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", Parallelism_S1_S2 + ",");
                if (Power_PV == "") { Power_PV = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", Power_PV + ",");
                if (RMS_P_10mm == "") { RMS_P_10mm = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", RMS_P_10mm + ",");
                if (RMS_P_100mm == "") { RMS_P_100mm = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", RMS_P_100mm + ",");
                if (RMS_P_100_33mm == "") { RMS_P_100_33mm = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", RMS_P_100_33mm + ",");
                if (RMS_P_33_10mm == "") { RMS_P_33_10mm = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", RMS_P_33_10mm + ",");
                if (RMS_P_10_2_5mm == "") { RMS_P_10_2_5mm = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", RMS_P_10_2_5mm + ",");
                if (Defect_RMS_S11_P2_5 == "") { Defect_RMS_S11_P2_5 = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", Defect_RMS_S11_P2_5 + ",");
                if (Defect_RMS_S101_P1 == "") {Defect_RMS_S101_P1  = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", Defect_RMS_S101_P1 + ",");
                if (Defect_RMS_S21_P2_5 == "") {Defect_RMS_S21_P2_5 = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", Defect_RMS_S21_P2_5 + ",");
                if (Defect_RMS_S201_P1 == "") {Defect_RMS_S201_P1  = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", Defect_RMS_S201_P1 + ",");
                if (Defect_RMS_S1001_P01 == "") {Defect_RMS_S1001_P01  = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", Defect_RMS_S1001_P01 + ",");
                if (Defect_RMS_S2001_P01 == "") {Defect_RMS_S2001_P01  = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", Defect_RMS_S2001_P01 + ",");
                if (Power_PV9x == "") {Power_PV9x = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", Power_PV9x + ",");
                if (RMS_P_10mm9x == "") {RMS_P_10mm9x  = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", RMS_P_10mm9x + ",");
                if (F44 == "") { F44 = ""; }
                File.AppendAllText("c:\\a\\ceaExport.txt", F44 + Environment.NewLine);
            }
 
        }
    }
}