using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Mtb;
using System.IO;

namespace TestTrigger
{
    public partial class Form1 : Form
    {
        private string file;
        private string company;

        private string[] graph = new string[500];
        private string[] test = new string[200];
        private string boardType;
        private string odb2;
        private string odb3;
        private string log = DateTime.Now.ToShortDateString();

        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand
                ("select top 1 " +
                 "[xml file name], " +
                 "[board type], " +
                 "[test station] from [test data] order by id desc");
            SqlConnection cnxn = new SqlConnection
                ("server = midprj01; user = views; password = views; " +
                 "database = productioncontrol;");
            cmd.Connection = cnxn;
            cnxn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                file = dr.GetString(0).ToString().Trim();
                boardType = dr.GetString(1).ToString().Trim();
                company = dr.GetString(2).ToString().Trim();
            }
            cnxn.Close();

            boardType = boardType.Substring(4, 4);

            if (company.Substring(9, 1) == "1")
            {
                company = "CEI";
            }
            else
            {
                company = "Zygo";
            }

            string c = "jpeg;" + Environment.NewLine +
                       "Replace." + Environment.NewLine;

            string cl = "Worksheet;" + Environment.NewLine +
                        "Current;" + Environment.NewLine +
                        "Close." + Environment.NewLine;

            //break the ODBC connection line for Minitab into three parts - 
            // the common start and end and the unique middle.

            string odb1 = @"ODBC; Connect ""Description=ProductionControl;DRIVER=SQL Server;"" &" + Environment.NewLine +
                          @"""SERVER=MIDPRJ01;UID=views;PWD=views;APP=Minitab Release 16;WSID=MIDWS0167;""&" + Environment.NewLine +
                          @"""DATABASE=ProductionControl""; SQLString ""Select sn, [its build number], "" &" + Environment.NewLine;

            string savePath = @"Gsave ""\\midfile01\departments\pps\mfg\control charts\" +
                company + @"\";

            if (boardType == "4104")
            {
                savePath = savePath + @"4104\4104 ";

                if (company == "CEI")
                {
                    odb2 = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                              @"""where (sn = 618041 or sn = 618042) "" &" + Environment.NewLine +
                              @"""and [board type] = 'zmi 4104'""." + Environment.NewLine +
                              @"Sort c1 c2 c3 c4 c1 c2 c3 c4;" + Environment.NewLine +
                              @"by c3." + Environment.NewLine +
                              @"Count c1." + Environment.NewLine;
                }
                else
                {
                    odb2 = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                                  @"""where (sn = 07382437 or sn = 07262253 or sn = 07432600 "" &" + Environment.NewLine +
                                  @""" or sn = 09145386) "" &" + Environment.NewLine +
                                  @"""and [board type] = 'zmi 4104'""." + Environment.NewLine +
                                  @"Sort c1 c2 c3 c4 c1 c2 c3 c4;" + Environment.NewLine +
                                  @"by c3." + Environment.NewLine +
                                  @"Count c1." + Environment.NewLine;
                }
                
                string b = @"Title ""Engineering 4104"";" + Environment.NewLine +
                       "Title;" + Environment.NewLine +
                       "Connect 'SN';" + Environment.NewLine +
                       "Symbol 'SN';" + Environment.NewLine;

                string q1 = "Exclude;" + Environment.NewLine +
                        @"Where ""'ITS Build Number' < 600"";" + Environment.NewLine +
                        "Test 1 2 3 4 5 6 7 8;" + Environment.NewLine +
                        @"Title ""Quality 4104"";" + Environment.NewLine +
                        "Title;" + Environment.NewLine;

                

                test[1] = "AD +5V Digital PS Ripple";

                graph[1] = odb1 +
                    @"""[AD Test Date], [" + test[1] + @"] "" & " + Environment.NewLine +
                    odb2;

                graph[2] =
                    @"Plot '" + test[1] + @"' * 'AD Test Date';" + Environment.NewLine + b +
                        @"Reference 2 0;" + Environment.NewLine +
                        @"Label ""Lower Specification 0"";" + Environment.NewLine +
                        @"Reference 2 0.05;" + Environment.NewLine +
                        @"Label ""Upper Specification 0.05"";" + Environment.NewLine +
                        savePath + @"Eng " + test[1] + @""";" + Environment.NewLine + c +
                    @"Ichart '" + test[1] + "' ;" + Environment.NewLine + q1 +
                        @"Stamp 'AD Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual " + test[1] + @""";" + Environment.NewLine + c + cl;

                test[2] = "AD +5V Digital PS";

                graph[3] = odb1 +
                    @"""[AD Test Date], [AD +5V Digital PS] "" &" + Environment.NewLine +
                    odb2;

                graph[4] =
                    @"Plot 'AD +5V Digital PS' * 'AD Test Date';" + Environment.NewLine + b +
                            @"Reference 2 4.75;" + Environment.NewLine +
                            @"Label ""Lower Specification 4.75"";" + Environment.NewLine +
                            @"Reference 2 5.25;" + Environment.NewLine +
                            @"Label ""Upper Specification 5.25"";" + Environment.NewLine +
                            savePath + @"Eng AD +5V Digital PS"";" + Environment.NewLine + c +
                    @"Ichart 'AD +5V Digital PS' ;" + Environment.NewLine + q1 +
                            @"Stamp 'AD Test Date' 'ITS Build Number';" + Environment.NewLine +
                            savePath + @"Qual AD +5V Digital PS"";" + Environment.NewLine + c + cl;

                test[3] = "Lin 10 RMS Error Ax1";

                graph[5] = odb1 +
                    @"""[Lin Test Date Ax1], [Lin 10 RMS Error Ax1] "" &" + Environment.NewLine +
                    odb2;

                graph[6] =
                    @"Plot 'Lin 10 RMS Error Ax1' * 'Lin Test Date Ax1';" + Environment.NewLine + b +
                       savePath + @"Eng Lin 10 RMS Error Ax1"";" + Environment.NewLine + c +
                    @"Ichart 'Lin 10 RMS Error Ax1' ;" + Environment.NewLine + q1 +
                       @"Stamp 'Lin Test Date Ax1' 'ITS Build Number';" + Environment.NewLine +
                       savePath + @"Qual Lin 10 RMS Error Ax1"";" + Environment.NewLine + c + cl;

                test[4] = "Lin 1 RMS Error Ax1";

                graph[7] = odb1 +
                    @"""[Lin Test Date Ax1], [Lin 1 RMS Error Ax1] "" &" + Environment.NewLine +
                    odb2;

                graph[8] =
                    @"Plot 'Lin 1 RMS Error Ax1' * 'Lin Test Date Ax1';" + Environment.NewLine + b +
                        savePath + @"Eng Lin 1 RMS Error Ax1"";" + Environment.NewLine + c +
                    @"Ichart 'Lin 1 RMS Error Ax1' ;" + Environment.NewLine + q1 +
                        @"Stamp 'Lin Test Date Ax1' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual Lin 1 RMS Error Ax1"";" + Environment.NewLine + c + cl;

                test[5] = "DNAC 3.88 Std Dev Ax1";

                graph[9] = odb1 +
                    @"""[DNAC Ax1 Test Date], [DNAC 3.88 Std Dev Ax1] "" &" + Environment.NewLine +
                    odb2;

                graph[10] =
                    @"Plot 'DNAC 3.88 Std Dev Ax1' * 'DNAC Ax1 Test Date';" + Environment.NewLine + b +
                        @"Reference 2 0;" + Environment.NewLine +
                        @"Label ""Lower Specification 0"";" + Environment.NewLine +
                        @"Reference 2 1.4;" + Environment.NewLine +
                        @"Label ""Upper Specification 1.4"";" + Environment.NewLine +
                        savePath + @"Eng DNAC 3.88 Std Dev Ax1"";" + Environment.NewLine + c +
                    @"Ichart 'DNAC 3.88 Std Dev Ax1' ;" + Environment.NewLine + q1 +
                        @"Stamp 'DNAC Ax1 Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual DNAC 3.88 Std Dev Ax1"";" + Environment.NewLine + c + cl;

                test[6] = "DNAC 30.01 Std Dev Ax1";

                graph[11] = odb1 +
                    @"""[DNAC Ax1 Test Date], [DNAC 30.01 Std Dev Ax1] "" &" + Environment.NewLine +
                    odb2;

                graph[12] =
                    @"Plot 'DNAC 30.01 Std Dev Ax1' * 'DNAC Ax1 Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng DNAC 30.01 Std Dev Ax1"";" + Environment.NewLine + c +
                    @"Ichart 'DNAC 30.01 Std Dev Ax1' ;" + Environment.NewLine + q1 +
                        @"Stamp 'DNAC Ax1 Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual DNAC 30.01 Std Dev Ax1"";" + Environment.NewLine + c + cl;

                test[7] = "DNAC 36.12 Std Dev Ax1";

                graph[13] =
                    odb1 +
                    @"""[DNAC Ax1 Test Date], [DNAC 36.12 Std Dev Ax1] "" &" + Environment.NewLine +
                    odb2;

                graph[14] =
                    @"Plot 'DNAC 36.12 Std Dev Ax1' * 'DNAC Ax1 Test Date';" + Environment.NewLine + b +
                         savePath + @"Eng DNAC 36.12 Std Dev Ax1"";" + Environment.NewLine + c +
                     @"Ichart 'DNAC 36.12 Std Dev Ax1' ;" + Environment.NewLine + q1 +
                        @"Stamp 'DNAC Ax1 Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual DNAC 36.12 Std Dev Ax1"";" + Environment.NewLine + c + cl;

                test[8] = "DA RfDelay DAU1";

                graph[15] =
                odb1 +
                    @"""[DA Test Date], [DA RfDelay DAU1] "" &" + Environment.NewLine +
                    odb2;

                graph[16] =
                    @"Plot 'DA RfDelay DAU1' * 'DA Test Date';" + Environment.NewLine + b +
                        @"Reference 2 50;" + Environment.NewLine +
                        @"Label ""Lower Specification 50"";" + Environment.NewLine +
                        @"Reference 2 70;" + Environment.NewLine +
                        @"Label ""Upper Specification 70"";" + Environment.NewLine +
                        savePath + @"Eng DA RfDelay DAU1"";" + Environment.NewLine + c +
                    @"Ichart 'DA RfDelay DAU1' ;" + Environment.NewLine + q1 +
                        @"Stamp 'DA Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual DA RfDelay DAU1"";" + Environment.NewLine + c + cl;

                test[9] = "DA RfDelay DAU2";

                graph[17] =
                    odb1 +
                    @"""[DA Test Date], [DA RfDelay DAU2] "" &" + Environment.NewLine +
                    odb2;

                graph[18] =
                    @"Plot 'DA RfDelay DAU2' * 'DA Test Date';" + Environment.NewLine + b +
                        @"Reference 2 50;" + Environment.NewLine +
                        @"Label ""Lower Specification 50"";" + Environment.NewLine +
                        @"Reference 2 70;" + Environment.NewLine +
                        @"Label ""Upper Specification 70"";" + Environment.NewLine +
                        savePath + @"Eng DA RfDelay DAU2"";" + Environment.NewLine + c +
                    @"Ichart 'DA RfDelay DAU2' ;" + Environment.NewLine + q1 +
                        @"Stamp 'DA Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual DA RfDelay DAU2"";" + Environment.NewLine + c + cl;

                test[10] = "DA Age DAU1";
                graph[19] =
                    odb1 +
                    @"""[DA Test Date], [DA Age DAU1] "" &" + Environment.NewLine +
                    odb2;

                graph[20] =
                    @"Plot 'DA Age DAU1' * 'DA Test Date';" + Environment.NewLine +
                        @"Exclude;" + Environment.NewLine +
                        @"Where ""'sn' = 7382437 or 'sn' = 7262253"";" + Environment.NewLine + b +
                        @"Reference 2 1396;" + Environment.NewLine +
                        @"Label ""Lower Specification 1396"";" + Environment.NewLine +
                        @"Reference 2 1462;" + Environment.NewLine +
                        @"Label ""Upper Specification 1462"";" + Environment.NewLine +
                        savePath + @"Eng DA Age DAU1"";" + Environment.NewLine + c +
                    @"Ichart 'DA Age DAU1' ;" + Environment.NewLine + q1 +
                        @"Exclude;" + Environment.NewLine +
                        @"Where ""'sn' = 7382437 or 'sn' = 7262253"";" + Environment.NewLine +
                        @"Stamp 'DA Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual DA Age DAU1"";" + Environment.NewLine + c + cl;

                test[11] = "DA Age DAU1 C";

                graph[21] =
                    odb1 +
                    @"""[DA Test Date], [DA Age DAU1] "" &" + Environment.NewLine +
                    odb2;

                graph[22] =
                    @"Plot 'DA Age DAU1' * 'DA Test Date';" + Environment.NewLine +
                        @"Exclude;" + Environment.NewLine +
                        @"Where ""'sn' = 7432600"";" + Environment.NewLine + b +
                         @"Reference 2 -29258;" + Environment.NewLine +
                        @"Label ""Lower Specification -29258"";" + Environment.NewLine +
                        @"Reference 2 -29324;" + Environment.NewLine +
                        @"Label ""Upper Specification -29324"";" + Environment.NewLine +
                        savePath + @"Eng DA Age DAU1 C"";" + Environment.NewLine + c +
                    @"Ichart 'DA Age DAU1' ;" + Environment.NewLine + q1 +
                        @"Exclude;" + Environment.NewLine +
                        @"Where ""'sn' = 7432600"";" + Environment.NewLine +
                        @"Stamp 'DA Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual DA Age DAU1 C"";" + Environment.NewLine + c + cl;

                test[12] = "SSI PV 7 ACDCDiffL2 Ax1";
                graph[23] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 7 ACDCDiffL2 Ax1] "" &" + Environment.NewLine +
                    odb2;

                graph[24] =
                    @"Plot 'SSI PV 7 ACDCDiffL2 Ax1' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 7 ACDC DiffL2 Ax1"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 7 ACDCDiffL2 Ax1' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 7 ACDCDiffL2 Ax1"";" + Environment.NewLine + c + cl;

                test[13] = "SSI PV 7 ProcGainL2 Ax1";

                graph[25] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 7 ProcGainL2 Ax1] "" &" + Environment.NewLine +
                    odb2;

                graph[26] =
                    @"Plot 'SSI PV 7 ProcGainL2 Ax1' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 7 ProcGainL2 Ax1"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 7 ProcGainL2 Ax1' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 7 ProcGainL2 Ax1"";" + Environment.NewLine + c + cl;

                test[14] = "SSI PV 1 ACDCDiffL2 Ax1";
                graph[27] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 1 ACDCDiffL2 Ax1] "" &" + Environment.NewLine +
                    odb2;

                graph[28] =
                    @"Plot 'SSI PV 1 ACDCDiffL2 Ax1' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 1 ACDC DiffL2 Ax1"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 1 ACDCDiffL2 Ax1' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 1 ACDCDiffL2 Ax1"";" + Environment.NewLine + c + cl;

                test[15] = "SSI PV 1 ProcGainL2 Ax1";
                graph[29] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 1 ProcGainL2 Ax1] "" &" + Environment.NewLine +
                    odb2;

                graph[30] =
                    @"Plot 'SSI PV 1 ProcGainL2 Ax1' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 1 ProcGainL2 Ax1"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 1 ProcGainL2 Ax1' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 1 ProcGainL2 Ax1"";" + Environment.NewLine + c + cl;

                test[16] = "SSI PV 0.3 ACDCDiffL2 Ax1";
                graph[31] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 0.3 ACDCDiffL2 Ax1] "" &" + Environment.NewLine +
                    odb2;

                graph[32] =
                    @"Plot 'SSI PV 0.3 ACDCDiffL2 Ax1' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 0.3 ACDC DiffL2 Ax1"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 0.3 ACDCDiffL2 Ax1' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 0.3 ACDCDiffL2 Ax1"";" + Environment.NewLine + c + cl;

                test[17] = "SSI PV 0.3 ProcGainL2 Ax1";

                graph[33] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 0.3 ProcGainL2 Ax1] "" &" + Environment.NewLine +
                    odb2;

                graph[34] =
                    @"Plot 'SSI PV 0.3 ProcGainL2 Ax1' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 0.3 ProcGainL2 Ax1"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 0.3 ProcGainL2 Ax1' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 0.3 ProcGainL2 Ax1"";" + Environment.NewLine + c + cl;

                test[18] = "SSI PV 7 ACDCDiffL2 Ax2";

                graph[35] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 7 ACDCDiffL2 Ax2] "" &" + Environment.NewLine +
                    odb2;

                graph[36] =
                    @"Plot 'SSI PV 7 ACDCDiffL2 Ax2' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 7 ACDC DiffL2 Ax2"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 7 ACDCDiffL2 Ax2' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 7 ACDCDiffL2 Ax2"";" + Environment.NewLine + c + cl;

                test[19] = "SSI PV 7 ProcGainL2 Ax2";
                graph[37] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 7 ProcGainL2 Ax2] "" &" + Environment.NewLine +
                    odb2;

                graph[38] =
                    @"Plot 'SSI PV 7 ProcGainL2 Ax2' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 7 ProcGainL2 Ax2"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 7 ProcGainL2 Ax2' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 7 ProcGainL2 Ax2"";" + Environment.NewLine + c + cl;

                test[20] = "SSI PV 1 ACDCDiffL2 Ax2";
                graph[39] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 1 ACDCDiffL2 Ax2] "" &" + Environment.NewLine +
                    odb2;

                graph[40] =
                    @"Plot 'SSI PV 1 ACDCDiffL2 Ax2' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 1 ACDC DiffL2 Ax2"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 1 ACDCDiffL2 Ax2' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 1 ACDCDiffL2 Ax2"";" + Environment.NewLine + c + cl;

                test[21] = "SSI PV 1 ProcGainL2 Ax2";
                graph[41] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 1 ProcGainL2 Ax2] "" &" + Environment.NewLine +
                    odb2;

                graph[42] =
                    @"Plot 'SSI PV 1 ProcGainL2 Ax2' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 1 ProcGainL2 Ax2"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 1 ProcGainL2 Ax2' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 1 ProcGainL2 Ax2"";" + Environment.NewLine + c + cl;

                test[22] = "SSI PV 0.3 ACDCDiffL2 Ax2";
                graph[43] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 0.3 ACDCDiffL2 Ax2] "" &" + Environment.NewLine +
                    odb2;

                graph[44] =
                    @"Plot 'SSI PV 0.3 ACDCDiffL2 Ax2' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 0.3 ACDC DiffL2 Ax2"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 0.3 ACDCDiffL2 Ax2' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 0.3 ACDCDiffL2 Ax2"";" + Environment.NewLine + c + cl;

                test[23] = "SSI PV 0.3 ProcGainL2 Ax2";
                graph[45] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 0.3 ProcGainL2 Ax2] "" &" + Environment.NewLine +
                    odb2;

                graph[46] =
                    @"Plot 'SSI PV 0.3 ProcGainL2 Ax2' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 0.3 ProcGainL2 Ax2"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 0.3 ProcGainL2 Ax2' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 0.3 ProcGainL2 Ax2"";" + Environment.NewLine + c + cl;

                test[24] = "SSI PV 7 ACDCDiffL2 Ax3";
                graph[47] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 7 ACDCDiffL2 Ax3] "" &" + Environment.NewLine +
                    odb2;

                graph[48] =
                    @"Plot 'SSI PV 7 ACDCDiffL2 Ax3' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 7 ACDC DiffL2 Ax3"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 7 ACDCDiffL2 Ax3' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 7 ACDCDiffL2 Ax3"";" + Environment.NewLine + c + cl;

                test[25] = "SSI PV 7 ProcGainL2 Ax3";
                graph[49] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 7 ProcGainL2 Ax3] "" &" + Environment.NewLine +
                    odb2;

                graph[50] =
                    @"Plot 'SSI PV 7 ProcGainL2 Ax3' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 7 ProcGainL2 Ax3"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 7 ProcGainL2 Ax3' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 7 ProcGainL2 Ax3"";" + Environment.NewLine + c + cl;

                test[26] = "SSI PV 1 ACDCDiffL2 Ax3";
                graph[51] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 1 ACDCDiffL2 Ax3] "" &" + Environment.NewLine +
                    odb2;

                graph[52] =
                    @"Plot 'SSI PV 1 ACDCDiffL2 Ax3' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 1 ACDC DiffL2 Ax3"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 1 ACDCDiffL2 Ax3' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 1 ACDCDiffL2 Ax3"";" + Environment.NewLine + c + cl;

                test[27] = "SSI PV 1 ProcGainL2 Ax3";
                graph[53] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 1 ProcGainL2 Ax3] "" &" + Environment.NewLine +
                    odb2;

                graph[54] =
                    @"Plot 'SSI PV 1 ProcGainL2 Ax3' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 1 ProcGainL2 Ax3"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 1 ProcGainL2 Ax3' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 1 ProcGainL2 Ax3"";" + Environment.NewLine + c + cl;

                test[28] = "SSI PV 0.3 ACDCDiffL2 Ax3";
                graph[55] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 0.3 ACDCDiffL2 Ax3] "" &" + Environment.NewLine +
                    odb2;

                graph[56] =
                    @"Plot 'SSI PV 0.3 ACDCDiffL2 Ax3' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 0.3 ACDC DiffL2 Ax3"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 0.3 ACDCDiffL2 Ax3' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 0.3 ACDCDiffL2 Ax3"";" + Environment.NewLine + c + cl;

                test[29] = "SSI PV 0.3 ProcGainL2 Ax3";
                graph[57] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 0.3 ProcGainL2 Ax3] "" &" + Environment.NewLine +
                    odb2;

                graph[58] =
                    @"Plot 'SSI PV 0.3 ProcGainL2 Ax3' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 0.3 ProcGainL2 Ax3"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 0.3 ProcGainL2 Ax3' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 0.3 ProcGainL2 Ax3"";" + Environment.NewLine + c + cl;

                test[30] = "SSI PV 7 ACDCDiffL2 Ax4";
                graph[59] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 7 ACDCDiffL2 Ax4] "" &" + Environment.NewLine +
                    odb2;

                graph[60] =
                    @"Plot 'SSI PV 7 ACDCDiffL2 Ax4' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 7 ACDC DiffL2 Ax4"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 7 ACDCDiffL2 Ax4' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 7 ACDCDiffL2 Ax4"";" + Environment.NewLine + c + cl;

                test[31] = "SSI PV 7 ProcGainL2 Ax4";
                graph[61] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 7 ProcGainL2 Ax4] "" &" + Environment.NewLine +
                    odb2;

                graph[62] =
                    @"Plot 'SSI PV 7 ProcGainL2 Ax4' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 7 ProcGainL2 Ax4"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 7 ProcGainL2 Ax4' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 7 ProcGainL2 Ax4"";" + Environment.NewLine + c + cl;

                test[32] = "SSI PV 1 ACDCDiffL2 Ax4";
                graph[63] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 1 ACDCDiffL2 Ax4] "" &" + Environment.NewLine +
                    odb2;

                graph[64] =
                    @"Plot 'SSI PV 1 ACDCDiffL2 Ax4' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 1 ACDC DiffL2 Ax4"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 1 ACDCDiffL2 Ax4' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 1 ACDCDiffL2 Ax4"";" + Environment.NewLine + c + cl;

                test[33] = "SSI PV 1 ProcGainL2 Ax4";
                graph[65] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 1 ProcGainL2 Ax4] "" &" + Environment.NewLine +
                    odb2;

                graph[66] =
                    @"Plot 'SSI PV 1 ProcGainL2 Ax4' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 1 ProcGainL2 Ax4"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 1 ProcGainL2 Ax4' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 1 ProcGainL2 Ax4"";" + Environment.NewLine + c + cl;

                test[34] = "SSI PV 0.3 ACDCDiffL2 Ax4";
                graph[67] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 0.3 ACDCDiffL2 Ax4] "" &" + Environment.NewLine +
                    odb2;

                graph[68] =
                    @"Plot 'SSI PV 0.3 ACDCDiffL2 Ax4' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 0.3 ACDC DiffL2 Ax4"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 0.3 ACDCDiffL2 Ax4' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 0.3 ACDCDiffL2 Ax4"";" + Environment.NewLine + c + cl;

                test[35] = "SSI PV 0.3 ProcGainL2 Ax4";
                graph[69] =
                    odb1 +
                    @"""[SSI PV Test Date], [SSI PV 0.3 ProcGainL2 Ax4] "" &" + Environment.NewLine +
                    odb2;

                graph[70] =
                    @"Plot 'SSI PV 0.3 ProcGainL2 Ax4' * 'SSI PV Test Date';" + Environment.NewLine + b +
                        savePath + @"Eng SSI PV 0.3 ProcGainL2 Ax4"";" + Environment.NewLine + c +
                    @"Ichart 'SSI PV 0.3 ProcGainL2 Ax4' ;" + Environment.NewLine + q1 +
                        @"Stamp 'SSI PV Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual SSI PV 0.3 ProcGainL2 Ax4"";" + Environment.NewLine +
                        @"jpeg;" + Environment.NewLine +
                        @"Replace;" + Environment.NewLine +
                    "Worksheet;" + Environment.NewLine +
                    "Current;" + Environment.NewLine +
                    "Close.";


                Mtb.Application Mtap = new Mtb.Application();
                Mtb.Project Mtab = Mtap.ActiveProject;
                Mtb.UserInterface mtbUI = Mtap.UserInterface;
                mtbUI.Visible = true;
                mtbUI.DisplayAlerts = false;


                int i = 1;      // i = number of graphs
                int ii = 1;     // ii = number of tests

                // do while the number of graphs is less than one more than the number of graphs

                while (i < 71)
                {
                    Mtab.ExecuteCommand(graph[i], Type.Missing);
                    i++;
                    string mTabCountString = Mtab.Commands.OutputDocument.Text;
                    char[] anyof = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
                    int findex = mTabCountString.IndexOfAny(anyof);
                    int lindex = mTabCountString.LastIndexOfAny(anyof);
                    string reading = mTabCountString.Substring(findex, (lindex - findex) + 1);

                    Mtab.Commands.Delete();

                    Mtab.ExecuteCommand(graph[i], Type.Missing);
                    i++;

                    string x = Mtab.Commands.OutputDocument.Text;

                    if (x.IndexOf("Test Failed") > -1)
                    {
                        if (x.IndexOf(reading) > -1)
                        {
                            cmd = new SqlCommand
                                ("Insert into [failure log] " +
                                "([xml file], company, board, test, date) " +
                                 " values ('" +
                                 file + "','" +
                                 company + "','" +
                                 boardType + "','" +
                                 test[ii] + "','" +
                                 log + "')");

                            cmd.Connection = cnxn;
                            cnxn.Open();
                            cmd.ExecuteNonQuery();
                            cnxn.Close();
                        }
                    }
                    Mtab.Commands.Delete();
                    ii++;
                }

                Mtap.Quit();

                Close();

            }
            else
            {
                savePath = savePath + @"4004\4004 ";
                
                string b1 = @"Title ""Engineering 4004"";" + Environment.NewLine +
                       "Title;" + Environment.NewLine +
                       "Connect 'SN';" + Environment.NewLine +
                       "Symbol 'SN';" + Environment.NewLine;

                string q2 = "Exclude;" + Environment.NewLine +
                        @"Where ""'ITS Build Number' < 600"";" + Environment.NewLine +
                        "Test 1 2 3 4 5 6 7 8;" + Environment.NewLine +
                        @"Title ""Quality 4004"";" + Environment.NewLine +
                        "Title;" + Environment.NewLine;

                if (company == "Zygo")
                {
                    odb3 = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                              @"""where (sn = 07151655 or sn = 07171756 or sn = 07171748) "" &" + Environment.NewLine +
                              @"""and [board type] = 'zmi 4004'""." + Environment.NewLine +
                              @"Sort c1 c2 c3 c4 c1 c2 c3 c4;" + Environment.NewLine +
                              @"by c3." + Environment.NewLine +
                              @"Count c1." + Environment.NewLine;
                }
                else
                {
                    odb3 = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                              @"""where (sn = 00618072 or sn = 00618068 or sn = 00618074) "" &" + Environment.NewLine +
                              @"""and [board type] = 'zmi 4004'""." + Environment.NewLine +
                              @"Sort c1 c2 c3 c4 c1 c2 c3 c4;" + Environment.NewLine +
                              @"by c3." + Environment.NewLine +
                              @"Count c1." + Environment.NewLine;
                }
                test[1] = "AD +5V Digital PS";

                graph[1] =
                    odb1 +
                    @"""[AD Test Date], [AD +5V Digital PS] "" &" + Environment.NewLine +
                    odb3;

                graph[2] =
                    @"Plot 'AD +5V Digital PS' * 'AD Test Date';" + Environment.NewLine + b1 +
                            @"Reference 2 4.75;" + Environment.NewLine +
                            @"Label ""Lower Specification 4.75"";" + Environment.NewLine +
                            @"Reference 2 5.25;" + Environment.NewLine +
                            @"Label ""Upper Specification 5.25"";" + Environment.NewLine +
                            savePath + @"4004  Eng AD +5V Digital PS"";" + Environment.NewLine + c +
                    @"Ichart 'AD +5V Digital PS' ;" + Environment.NewLine + q2 +
                            @"Stamp 'AD Test Date' 'ITS Build Number';" + Environment.NewLine +
                            savePath + @"Qual AD +5V Digital PS"";" + Environment.NewLine + c + cl;

                test[2] = "AD +5V Digital PS Ripple";
                graph[3] =
                    odb1 +
                    @"""[AD Test Date], [AD +5V Digital PS Ripple] "" &" + Environment.NewLine +
                    odb3;

                graph[4] =
                    @"Plot 'AD +5V Digital PS Ripple' * 'AD Test Date';" + Environment.NewLine + b1 +
                        @"Reference 2 0;" + Environment.NewLine +
                        @"Label ""Lower Specification 0"";" + Environment.NewLine +
                        @"Reference 2 0.05;" + Environment.NewLine +
                        @"Label ""Upper Specification 0.05"";" + Environment.NewLine +
                        savePath + @"4004  Eng AD +5V Digital PS Ripple"";" + Environment.NewLine + c +
                    @"Ichart 'AD +5V Digital PS Ripple' ;" + Environment.NewLine + q2 +
                        @"Stamp 'AD Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual AD +5V Digital PS Ripple"";" + Environment.NewLine + c + cl;

                test[3] = "DA RfDelay DAU1";
                graph[5] =
                    odb1 +
                    @"""[DA Test Date], [DA RfDelay DAU1] "" &" + Environment.NewLine +
                    odb3;

                graph[6] =
                    @"Plot 'DA RfDelay DAU1' * 'DA Test Date';" + Environment.NewLine + b1 +
                        @"Reference 2 50;" + Environment.NewLine +
                        @"Label ""Lower Specification 50"";" + Environment.NewLine +
                        @"Reference 2 70;" + Environment.NewLine +
                        @"Label ""Upper Specification 70"";" + Environment.NewLine +
                        savePath + @" Eng DA RfDelay DAU1"";" + Environment.NewLine + c +
                    @"Ichart 'DA RfDelay DAU1' ;" + Environment.NewLine + q2 +
                        @"Stamp 'DA Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual DA RfDelay DAU1"";" + Environment.NewLine + c + cl;

                test[4] = "DA RfDelay DAU2";
                graph[7] =
                    odb1 +
                    @"""[DA Test Date], [DA RfDelay DAU2] "" &" + Environment.NewLine +
                    odb3;

                graph[8] =
                    @"Plot 'DA RfDelay DAU2' * 'DA Test Date';" + Environment.NewLine + b1 +
                        @"Reference 2 50;" + Environment.NewLine +
                        @"Label ""Lower Specification 50"";" + Environment.NewLine +
                        @"Reference 2 70;" + Environment.NewLine +
                        @"Label ""Upper Specification 70"";" + Environment.NewLine +
                        savePath + @" Eng DA RfDelay DAU2"";" + Environment.NewLine + c +
                    @"Ichart 'DA RfDelay DAU2' ;" + Environment.NewLine + q2 +
                        @"Stamp 'DA Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual DA RfDelay DAU2"";" + Environment.NewLine + c + cl;

                test[5] = "DA Age DAU1";
                graph[9] =
                    odb1 +
                    @"""[DA Test Date], [DA Age DAU1] "" &" + Environment.NewLine +
                    odb3;

                graph[10] =
                    @"Plot 'DA Age DAU1' * 'DA Test Date';" + Environment.NewLine + b1 +
                        @"Reference 2 1660;" + Environment.NewLine +
                        @"Label ""Lower Specification 1660"";" + Environment.NewLine +
                        @"Reference 2 1720;" + Environment.NewLine +
                        @"Label ""Upper Specification 1720"";" + Environment.NewLine +
                        savePath + @" Eng DA Age DAU1"";" + Environment.NewLine + c +
                    @"Ichart 'DA Age DAU1' ;" + Environment.NewLine + q2 +
                        @"Stamp 'DA Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual DA Age DAU1"";" + Environment.NewLine + c + cl;

                test[6] = "DA Age DAU2";
                graph[11] =
                    odb1 +
                    @"""[DA Test Date], [DA Age DAU2] "" &" + Environment.NewLine +
                    odb3;

                graph[12] =
                    @"Plot 'DA Age DAU2' * 'DA Test Date';" + Environment.NewLine + b1 +
                    //@"Reference 2 -29258;" + Environment.NewLine +
                    //@"Label ""Lower Specification -29258"";" + Environment.NewLine +
                    //@"Reference 2 -29324;" + Environment.NewLine +
                    //@"Label ""Upper Specification -29324"";" + Environment.NewLine +
                        savePath + @" Eng DA Age DAU2"";" + Environment.NewLine + c +
                    @"Ichart 'DA Age DAU2' ;" + Environment.NewLine + q2 +
                        @"Stamp 'DA Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual DA Age DAU2"";" + Environment.NewLine + c + cl;

                test[7] = "DA Age DAU3";
                graph[13] =
                    odb1 +
                    @"""[DA Test Date], [DA Age DAU3] "" &" + Environment.NewLine +
                    odb3;

                graph[14] =
                    @"Plot 'DA Age DAU3' * 'DA Test Date';" + Environment.NewLine + b1 +
                    //@"Reference 2 -29258;" + Environment.NewLine +
                    //@"Label ""Lower Specification -29258"";" + Environment.NewLine +
                    //@"Reference 2 -29324;" + Environment.NewLine +
                    //@"Label ""Upper Specification -29324"";" + Environment.NewLine +
                        savePath + @" Eng DA Age DAU3"";" + Environment.NewLine + c +
                    @"Ichart 'DA Age DAU3' ;" + Environment.NewLine + q2 +
                        @"Stamp 'DA Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual DA Age DAU3"";" + Environment.NewLine + c + cl;

                test[8] = "DA Age DAU4";
                graph[15] =
                    odb1 +
                    @"""[DA Test Date], [DA Age DAU4] "" &" + Environment.NewLine +
                    odb3;

                graph[16] =
                    @"Plot 'DA Age DAU4' * 'DA Test Date';" + Environment.NewLine + b1 +
                    //@"Reference 2 -29258;" + Environment.NewLine +
                    //@"Label ""Lower Specification -29258"";" + Environment.NewLine +
                    //@"Reference 2 -29324;" + Environment.NewLine +
                    //@"Label ""Upper Specification -29324"";" + Environment.NewLine +
                        savePath + @" Eng DA Age DAU4"";" + Environment.NewLine + c +
                    @"Ichart 'DA Age DAU4' ;" + Environment.NewLine + q2 +
                        @"Stamp 'DA Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual DA Age DAU4"";" + Environment.NewLine + c + cl;

                test[9] = "DNAC 3.88 Std Dev Ax1";
                graph[17] =
                     odb1 +
                    @"""[DNAC Ax1 Test Date], [DNAC 3.88 Std Dev Ax1] "" &" + Environment.NewLine +
                    odb3;

                graph[18] =
                    @"Plot 'DNAC 3.88 Std Dev Ax1' * 'DNAC Ax1 Test Date';" + Environment.NewLine + b1 +
                        @"Reference 2 0;" + Environment.NewLine +
                        @"Label ""Lower Specification 0"";" + Environment.NewLine +
                        @"Reference 2 1.4;" + Environment.NewLine +
                        @"Label ""Upper Specification 1.4"";" + Environment.NewLine +
                        savePath + @" Eng DNAC 3.88 Std Dev Ax1"";" + Environment.NewLine + c +
                    @"Ichart 'DNAC 3.88 Std Dev Ax1' ;" + Environment.NewLine + q2 +
                        @"Stamp 'DNAC Ax1 Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual DNAC 3.88 Std Dev Ax1"";" + Environment.NewLine + c + cl;

                test[10] = "DNAC 30.01 Std Dev Ax1";
                graph[19] =
                    odb1 +
                    @"""[DNAC Ax1 Test Date], [DNAC 30.01 Std Dev Ax1] "" &" + Environment.NewLine +
                    odb3;

                graph[20] =
                    @"Plot 'DNAC 30.01 Std Dev Ax1' * 'DNAC Ax1 Test Date';" + Environment.NewLine + b1 +
                        savePath + @" Eng DNAC 30.01 Std Dev Ax1"";" + Environment.NewLine + c +
                    @"Ichart 'DNAC 30.01 Std Dev Ax1' ;" + Environment.NewLine + q2 +
                        @"Stamp 'DNAC Ax1 Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual DNAC 30.01 Std Dev Ax1"";" + Environment.NewLine + c + cl;

                test[11] = "DNAC 36.12 Std Dev Ax1";
                graph[21] =
                    odb1 +
                    @"""[DNAC Ax1 Test Date], [DNAC 36.12 Std Dev Ax1] "" &" + Environment.NewLine +
                    odb3;

                graph[22] =
                    @"Plot 'DNAC 36.12 Std Dev Ax1' * 'DNAC Ax1 Test Date';" + Environment.NewLine + b1 +
                        savePath + @" Eng DNAC 36.12 Std Dev Ax1"";" + Environment.NewLine + c +
                    @"Ichart 'DNAC 36.12 Std Dev Ax1' ;" + Environment.NewLine + q2 +
                        @"Stamp 'DNAC Ax1 Test Date' 'ITS Build Number';" + Environment.NewLine +
                        savePath + @"Qual DNAC 36.12 Std Dev Ax1"";" + Environment.NewLine + c + cl;

                test[12] = "Lin 1 RMS Error Ax1";
                graph[23] =
                    odb1 +
                    @"""[Lin Test Date Ax1], [Lin 1 RMS Error Ax1] "" &" + Environment.NewLine +
                    odb3;

                graph[24] =
                @"Plot 'Lin 1 RMS Error Ax1' * 'Lin Test Date Ax1';" + Environment.NewLine + b1 +
                    savePath + @" Eng Lin 1 RMS Error Ax1"";" + Environment.NewLine + c +
                @"Ichart 'Lin 1 RMS Error Ax1' ;" + Environment.NewLine + q2 +
                    @"Stamp 'Lin Test Date Ax1' 'ITS Build Number';" + Environment.NewLine +
                    savePath + @"Qual Lin 1 RMS Error Ax1"";" + Environment.NewLine + c + cl;

                test[13] = "Lin 1 RMS Error Ax2";
                graph[25] =
                odb1 +
                @"""[Lin Test Date Ax2], [Lin 1 RMS Error Ax2] "" &" + Environment.NewLine +
                odb3;

                graph[26] =
                @"Plot 'Lin 1 RMS Error Ax2' * 'Lin Test Date Ax2';" + Environment.NewLine + b1 +
                    savePath + @" Eng Lin 1 RMS Error Ax2"";" + Environment.NewLine + c +
                @"Ichart 'Lin 1 RMS Error Ax2' ;" + Environment.NewLine + q2 +
                    @"Stamp 'Lin Test Date Ax2' 'ITS Build Number';" + Environment.NewLine +
                    savePath + @"Qual Lin 1 RMS Error Ax2"";" + Environment.NewLine + c + cl;

                test[14] = "Lin 1 RMS Error Ax3";
                graph[27] =
                odb1 +
                @"""[Lin Test Date Ax3], [Lin 1 RMS Error Ax3] "" &" + Environment.NewLine +
                odb3;

                graph[28] =
                @"Plot 'Lin 1 RMS Error Ax3' * 'Lin Test Date Ax3';" + Environment.NewLine + b1 +
                    savePath + @" Eng Lin 1 RMS Error Ax3"";" + Environment.NewLine + c +
                @"Ichart 'Lin 1 RMS Error Ax3' ;" + Environment.NewLine + q2 +
                    @"Stamp 'Lin Test Date Ax3' 'ITS Build Number';" + Environment.NewLine +
                    savePath + @"Qual Lin 1 RMS Error Ax3"";" + Environment.NewLine + c + cl;

                test[15] = "Lin 1 RMS Error Ax4";
                graph[29] =
                odb1 +
                @"""[Lin Test Date Ax4], [Lin 1 RMS Error Ax4] "" &" + Environment.NewLine +
                odb3;

                graph[30] =
                @"Plot 'Lin 1 RMS Error Ax4' * 'Lin Test Date Ax4';" + Environment.NewLine + b1 +
                    savePath + @" Eng Lin 1 RMS Error Ax4"";" + Environment.NewLine + c +
                @"Ichart 'Lin 1 RMS Error Ax4' ;" + Environment.NewLine + q2 +
                    @"Stamp 'Lin Test Date Ax4' 'ITS Build Number';" + Environment.NewLine +
                    savePath + @"Qual Lin 1 RMS Error Ax4"";" + Environment.NewLine + c +
                "Worksheet;" + Environment.NewLine +
                "Current;" + Environment.NewLine +
                "Close.";



                Mtb.Application Mtap = new Mtb.Application();
                Mtb.Project Mtab = Mtap.ActiveProject;
                Mtb.UserInterface mtbUI = Mtap.UserInterface;
                mtbUI.Visible = true;
                mtbUI.DisplayAlerts = false;

                int i = 1;      // i = number of graphs
                int ii = 1;     // ii = number of tests

                // do while the number of graphs is less than one more than the number of graphs

                while (i < 31)
                {
                    Mtab.ExecuteCommand(graph[i], Type.Missing);
                    i++;
                    string mTabCountString = Mtab.Commands.OutputDocument.Text;
                    char[] anyof = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
                    int findex = mTabCountString.IndexOfAny(anyof);
                    int lindex = mTabCountString.LastIndexOfAny(anyof);
                    string reading = mTabCountString.Substring(findex, (lindex - findex) + 1);

                    Mtab.Commands.Delete();

                    Mtab.ExecuteCommand(graph[i], Type.Missing);
                    i++;

                    string x = Mtab.Commands.OutputDocument.Text;

                    if (x.IndexOf("Test Failed") > -1)
                    {
                        if (x.IndexOf(reading) > -1)
                        {
                            cmd = new SqlCommand
                                    ("Insert into [failure log] " +
                                    "([xml file], company, board, test, date) " +
                                     " values ('" +
                                     file + "','" +
                                     company + "','" +
                                     boardType + "','" +
                                     test[ii] + "','" +
                                     log + "')");

                            cmd.Connection = cnxn;
                            cnxn.Open();
                            cmd.ExecuteNonQuery();
                            cnxn.Close();
                        }
                    }
                    Mtab.Commands.Delete();
                    ii++;
                }

                Mtap.Quit();

                Close();
            }
            this.Close();
        }
    }
}