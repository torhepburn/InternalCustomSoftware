using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;


namespace LLNL4XP
{
    public partial class XPLLNL : Form
    {
        private string sn;
        private object a;
        
        public XPLLNL()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection("server = midsql01; password = Read+Write!;" +
            "user = readWrite; database = accessfrontends;");
            SqlCommand cmd = new SqlCommand("select " +
                "[part serial number], " +
                "p1length, " +             //1
                "p1leninsp, " +
                "p1lendate, " +
                "p1surfaceroughness, " +
                "p1surrufinsp, " +         //5
                "p1surrufdate, " +
                "p2width, " +
                "p2widinsp, " +
                "p2widdate, " +
                "p2surfaceroughness, " +   //10
                "p2surrufinsp, " +
                "p2surrufdate, " +
                "p3length, " +
                "p3leninsp, " +
                "p3lendate, " +            //15
                "p3width, " +
                "p3widinsp, " +
                "p3widdate, " +
                "p3thickness, " +
                "p3thickinsp, " +         //20
                "p3thickdate, " +
                "case  " +
                    "when p3edgebevelss1 > p3edgebevelss2 then p3edgebevelss1 " +
                    "else p3edgebevelss2 " +
                "end t, " +
                "p3edgbevinsp, " +
                "p3edgbevdate, " +
                "p3parallelisms1s2, " +   //25
                "p3parssinsp, " +
                "p3parssdate, " +
                "FilteredPV, " +
                "FPVinsp, " +
                "FPVdate, " +           //30
                "RMSpGrad, " +
                "RMSpGinsp, " +
                "RMSpGdate, " +
                "RMSpBand, " +
                "RMSpBandinsp, " +      //35
                "RMSpBanddate, " +
                "RMSpBandWorst, " +
                "RMSpBandWorstinsp, " +
                "RMSpBandWorstdate, " +
                "Ratio, " +             //40
                "Ratioinsp, " +
                "Ratiodate, " +
                "Clp1Claddate, " +
                "Clp1SlabMfg, " +
                "Clp1ReqEpoxy, " +  //45
                "Clp1CementBatchA, " +
                "Clp1ExpirationA, " +
                "Clp1CementBatchB, " +
                "Clp1ExpirationB, " +
                "Clp1DiskStorage, " +   //50
                "Clp1pHacid, " +
                "Clp1pHsilane, " +
                "Clp1CladRoomPartCount, " +
                "Clp1CladRoomRH, " +
                "Clp1Temp15CR, " +  //55
                "Clp1Temp15Refr, " +
                "Clp1Temp15Index, " +
                "Clp1Temp30CR, " +
                "Clp1Temp30Refr, " +
                "Clp1Temp30Index, " +   //60
                "Clp1Temp60CR, " +
                "Clp1Temp60Refr, " +
                "Clp1Temp60Index, " +
                "Clp1PrecureHardness, " +
                "Clp1PostcureHardness, " +  //65
                "Clp2Claddate, " +
                "Clp2SlabMfg, " +
                "Clp2ReqEpoxy, " +
                "Clp2CementBatchA, " +
                "Clp2ExpirationA, " +   //70
                "Clp2CementBatchB, " +
                "Clp2ExpirationB, " +
                "Clp2DiskStorage, " +
                "Clp2pHacid, " +
                "Clp2pHsilane, " +      //75
                "Clp2CladRoomPartCount, " +
                "Clp2CladRoomRH, " +
                "Clp2Temp15CR, " +
                "Clp2Temp15Refr, " +
                "Clp2Temp15Index, " +   //80
                "Clp2Temp30CR, " +
                "Clp2Temp30Refr, " +
                "Clp2Temp30Index, " +
                "Clp2Temp60CR, " +
                "Clp2Temp60Refr, " +    //85
                "Clp2Temp60Index, " +
                "Clp2PrecureHardness, " +
                "Clp2PostcureHardness " +
                "from nif_amp_data order by [part serial number]", cnxn);
            cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (!dr.IsDBNull(0)) { sn = dr.GetInt32(0).ToString(); }

                if (File.Exists(@"\\zygocorp\manufacturing\nif\qc inspection reports\" + sn +
                    @"-1\Z_S_" + sn + "-1_MDML.xls"))
                {

                    Microsoft.Office.Interop.Excel.Application oXL;
                    Workbook oWB;
                    Worksheet oWS;

                    oXL = new Microsoft.Office.Interop.Excel.Application();
                    oXL.DisplayAlerts = false;
                    oXL.AskToUpdateLinks = false;
                    //oXL.Visible = true;
                    oWB = oXL.Workbooks.Open(@"\\zygocorp\manufacturing\nif\qc inspection reports\" + sn +
                        @"-1\Z_S_" + sn + "-1_MDML.xls");
                    //oWB = oXL.Workbooks.Open(@"C:\a\Z_S_" + sn + "-1_MDML.xls");

                    oWS = oWB.Worksheets.get_Item("Mech-Insp");

                    Range r = oWS.get_Range("K11", Missing.Value);

                    if (!dr.IsDBNull(1))
                    {
                        a = dr.GetDecimal(1);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(2))
                    {
                        r = oWS.get_Range("M11", Missing.Value);
                        a = dr.GetString(2);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(3))
                    {
                        r = oWS.get_Range("O11", Missing.Value);
                        a = dr.GetDateTime(3);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(4))
                    {
                        r = oWS.get_Range("K14", Missing.Value);
                        a = dr.GetDecimal(4);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(5))
                    {
                        r = oWS.get_Range("M14", Missing.Value);
                        a = dr.GetString(5);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(6))
                    {
                        r = oWS.get_Range("O14", Missing.Value);
                        a = dr.GetDateTime(6);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(7))
                    {
                        r = oWS.get_Range("K17", Missing.Value);
                        a = dr.GetDecimal(7);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(8))
                    {
                        r = oWS.get_Range("M17", Missing.Value);
                        a = dr.GetString(8);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(9))
                    {
                        r = oWS.get_Range("O17", Missing.Value);
                        a = dr.GetDateTime(9);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(10))
                    {
                        r = oWS.get_Range("K20", Missing.Value);
                        a = dr.GetDecimal(10);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(11))
                    {
                        r = oWS.get_Range("M20", Missing.Value);
                        a = dr.GetString(11);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(12))
                    {
                        r = oWS.get_Range("O20", Missing.Value);
                        a = dr.GetDateTime(12);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(13))
                    {
                        r = oWS.get_Range("K23", Missing.Value);
                        a = dr.GetDecimal(13);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(14))
                    {
                        r = oWS.get_Range("M23", Missing.Value);
                        a = dr.GetString(14);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(15))
                    {
                        r = oWS.get_Range("O23", Missing.Value);
                        a = dr.GetDateTime(15);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(16))
                    {
                        r = oWS.get_Range("K24", Missing.Value);
                        a = dr.GetDecimal(16);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(17))
                    {
                        r = oWS.get_Range("M24", Missing.Value);
                        a = dr.GetString(17);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(18))
                    {
                        r = oWS.get_Range("O24", Missing.Value);
                        a = dr.GetDateTime(18);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(19))
                    {
                        r = oWS.get_Range("K25", Missing.Value);
                        a = dr.GetDecimal(19);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(20))
                    {
                        r = oWS.get_Range("M25", Missing.Value);
                        a = dr.GetString(20);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(21))
                    {
                        r = oWS.get_Range("O25", Missing.Value);
                        a = dr.GetDateTime(21);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(22))
                    {
                        r = oWS.get_Range("K31", Missing.Value);
                        a = dr.GetDecimal(22);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(23))
                    {
                        r = oWS.get_Range("M31", Missing.Value);
                        a = dr.GetString(23);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(24))
                    {
                        r = oWS.get_Range("O31", Missing.Value);
                        a = dr.GetDateTime(24);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(25))
                    {
                        r = oWS.get_Range("K33", Missing.Value);
                        a = dr.GetDecimal(25);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(26))
                    {
                        r = oWS.get_Range("M33", Missing.Value);
                        a = dr.GetString(26);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(27))
                    {
                        r = oWS.get_Range("O33", Missing.Value);
                        a = dr.GetDateTime(27);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(28))
                    {
                        r = oWS.get_Range("K45", Missing.Value);
                        a = dr.GetDecimal(28);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(29))
                    {
                        r = oWS.get_Range("M45", Missing.Value);
                        a = dr.GetString(29);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(30))
                    {
                        r = oWS.get_Range("O45", Missing.Value);
                        a = dr.GetDateTime(30);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(31))
                    {
                        r = oWS.get_Range("K46", Missing.Value);
                        a = dr.GetDecimal(31);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(32))
                    {
                        r = oWS.get_Range("M46", Missing.Value);
                        a = dr.GetString(32);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(33))
                    {
                        r = oWS.get_Range("O46", Missing.Value);
                        a = dr.GetDateTime(33);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(34))
                    {
                        r = oWS.get_Range("K47", Missing.Value);
                        a = dr.GetDecimal(34);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(35))
                    {
                        r = oWS.get_Range("M47", Missing.Value);
                        a = dr.GetString(35);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(36))
                    {
                        r = oWS.get_Range("O47", Missing.Value);
                        a = dr.GetDateTime(36);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(37))
                    {
                        r = oWS.get_Range("K48", Missing.Value);
                        a = dr.GetDecimal(37);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(38))
                    {
                        r = oWS.get_Range("M48", Missing.Value);
                        a = dr.GetString(38);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(39))
                    {
                        r = oWS.get_Range("O48", Missing.Value);
                        a = dr.GetDateTime(39);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(40))
                    {
                        r = oWS.get_Range("K50", Missing.Value);
                        a = dr.GetDecimal(40);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(41))
                    {
                        r = oWS.get_Range("M50", Missing.Value);
                        a = dr.GetString(41);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(42))
                    {
                        r = oWS.get_Range("O50", Missing.Value);
                        a = dr.GetDateTime(42);
                        r.Value = a;
                    }

                    oWS = oWB.Worksheets.get_Item("Cladding");

                    if (!dr.IsDBNull(43))
                    {
                        r = oWS.get_Range("J7", Missing.Value);
                        a = dr.GetDateTime(43);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(44))
                    {
                        r = oWS.get_Range("J8", Missing.Value);
                        a = dr.GetString(44);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(45))
                    {
                        r = oWS.get_Range("J9", Missing.Value);
                        a = dr.GetString(45);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(46))
                    {
                        r = oWS.get_Range("J10", Missing.Value);
                        a = dr.GetString(46);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(47))
                    {
                        r = oWS.get_Range("J11", Missing.Value);
                        a = dr.GetDateTime(47);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(48))
                    {
                        r = oWS.get_Range("J12", Missing.Value);
                        a = dr.GetString(48);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(49))
                    {
                        r = oWS.get_Range("J13", Missing.Value);
                        a = dr.GetDateTime(49);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(50))
                    {
                        r = oWS.get_Range("J14", Missing.Value);
                        a = dr.GetInt32(50);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(51))
                    {
                        r = oWS.get_Range("J15", Missing.Value);
                        a = dr.GetDecimal(51);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(52))
                    {
                        r = oWS.get_Range("J16", Missing.Value);
                        a = dr.GetDecimal(52);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(53))
                    {
                        r = oWS.get_Range("J18", Missing.Value);
                        a = dr.GetInt32(53);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(54))
                    {
                        r = oWS.get_Range("J19", Missing.Value);
                        a = dr.GetDecimal(54);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(55))
                    {
                        r = oWS.get_Range("I22", Missing.Value);
                        a = dr.GetDecimal(55);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(56))
                    {
                        r = oWS.get_Range("J22", Missing.Value);
                        a = dr.GetDecimal(56);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(57))
                    {
                        r = oWS.get_Range("K22", Missing.Value);
                        a = dr.GetDecimal(57);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(58))
                    {
                        r = oWS.get_Range("I23", Missing.Value);
                        a = dr.GetDecimal(58);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(59))
                    {
                        r = oWS.get_Range("J23", Missing.Value);
                        a = dr.GetDecimal(59);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(60))
                    {
                        r = oWS.get_Range("K23", Missing.Value);
                        a = dr.GetDecimal(60);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(61))
                    {
                        r = oWS.get_Range("I24", Missing.Value);
                        a = dr.GetDecimal(61);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(62))
                    {
                        r = oWS.get_Range("J24", Missing.Value);
                        a = dr.GetDecimal(62);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(63))
                    {
                        r = oWS.get_Range("K24", Missing.Value);
                        a = dr.GetDecimal(63);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(64))
                    {
                        r = oWS.get_Range("I28", Missing.Value);
                        a = dr.GetInt32(64);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(65))
                    {
                        r = oWS.get_Range("I29", Missing.Value);
                        a = dr.GetInt32(65);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(66))
                    {
                        r = oWS.get_Range("R7", Missing.Value);
                        a = dr.GetDateTime(66);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(67))
                    {
                        r = oWS.get_Range("R8", Missing.Value);
                        a = dr.GetString(67);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(68))
                    {
                        r = oWS.get_Range("R9", Missing.Value);
                        a = dr.GetString(68);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(69))
                    {
                        r = oWS.get_Range("R10", Missing.Value);
                        a = dr.GetString(69);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(70))
                    {
                        r = oWS.get_Range("R11", Missing.Value);
                        a = dr.GetDateTime(70);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(71))
                    {
                        r = oWS.get_Range("R12", Missing.Value);
                        a = dr.GetString(71);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(72))
                    {
                        r = oWS.get_Range("R13", Missing.Value);
                        a = dr.GetDateTime(72);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(73))
                    {
                        r = oWS.get_Range("R14", Missing.Value);
                        a = dr.GetInt32(73);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(74))
                    {
                        r = oWS.get_Range("R15", Missing.Value);
                        a = dr.GetDecimal(74);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(75))
                    {
                        r = oWS.get_Range("R16", Missing.Value);
                        a = dr.GetDecimal(75);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(76))
                    {
                        r = oWS.get_Range("R18", Missing.Value);
                        a = dr.GetInt32(76);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(77))
                    {
                        r = oWS.get_Range("R19", Missing.Value);
                        a = dr.GetDecimal(77);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(78))
                    {
                        r = oWS.get_Range("Q22", Missing.Value);
                        a = dr.GetDecimal(78);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(79))
                    {
                        r = oWS.get_Range("R22", Missing.Value);
                        a = dr.GetDecimal(79);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(80))
                    {
                        r = oWS.get_Range("S22", Missing.Value);
                        a = dr.GetDecimal(80);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(81))
                    {
                        r = oWS.get_Range("Q23", Missing.Value);
                        a = dr.GetDecimal(81);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(82))
                    {
                        r = oWS.get_Range("R23", Missing.Value);
                        a = dr.GetDecimal(82);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(83))
                    {
                        r = oWS.get_Range("S23", Missing.Value);
                        a = dr.GetDecimal(83);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(84))
                    {
                        r = oWS.get_Range("Q24", Missing.Value);
                        a = dr.GetDecimal(84);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(85))
                    {
                        r = oWS.get_Range("R24", Missing.Value);
                        a = dr.GetDecimal(85);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(86))
                    {
                        r = oWS.get_Range("S24", Missing.Value);
                        a = dr.GetDecimal(86);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(87))
                    {
                        r = oWS.get_Range("Q28", Missing.Value);
                        a = dr.GetInt32(87);
                        r.Value = a;
                    }

                    if (!dr.IsDBNull(88))
                    {
                        r = oWS.get_Range("Q29", Missing.Value);
                        a = dr.GetInt32(88);
                        r.Value = a;
                    }

                    oXL.ActiveWorkbook.Save();
                    oXL.Quit();
                }
                else
                {
                    g.Errors = g.Errors + Environment.NewLine + sn + " Did not load." + Environment.NewLine;

                }
            }  //end dr.read

            if (g.Errors.Length > 0)
            {
                F2_Errors f2 = new F2_Errors();
                f2.ShowDialog();
            }
        }
    }

    public static class g
    {
        public static string Errors;
        //public static string task;
        //public static string userType;
        //public static string rpt_type;
        //public static string pdf;
        //public static string db = "server = midsql01; password = Read+Write!; " +
        // "user = readwrite; database = accessfrontends;";
    }
}
