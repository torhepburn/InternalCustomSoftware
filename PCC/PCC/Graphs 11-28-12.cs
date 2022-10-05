using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using Mtb;

namespace PCC
{
    public partial class Graphs_11_28_12 : Form
    {
        private string[] graph = new string[200];
        private string[] test = new string[200];
        private string[] report = new string[500];
        private int[] promVers = new int[3];
        private string boardType;
        private string company;
        private string Purpose;
        private string odb2;
        private string odb4;
        private string odb2a;
        private string odb2b;
        private string odb2c;
        private string odb2d;
        private string log = DateTime.Now.ToShortDateString();
        private double[] xx2 = new double[2000];
        //private string[] xy2 = new string[1000];
        private string[] runs = new string[2000];
        private int readings;
        private string ticks;
        private object t7815;
        private object t7805;
        private object t7803;
        private string firstCommand;
        private string[,] failureLog = new string[150000, 3];
        private int failLogIndex = 0;
        private string[] tdate = new string[2000];

        private string connect = "Connect 'SN';" + Environment.NewLine +
                                 "Symbol 'SN';" + Environment.NewLine;

        private string dateTitle = @"' * 'test date';" + Environment.NewLine +
                                   @"Title ""Engineering 4104"";" + Environment.NewLine +
                                   @"Title ""Scatterplot of ";

        private string gClose = "jpeg;" + Environment.NewLine +
                                "Replace." + Environment.NewLine +
                                "gman;" + Environment.NewLine +
                                "close." + Environment.NewLine;

        private string wClose = "Worksheet;" + Environment.NewLine +
                                "Current;" + Environment.NewLine +
                                "Close." + Environment.NewLine;

        private string v7803 = @" prom 7803"";" + Environment.NewLine;
        private string v7805 = @" prom 7805"";" + Environment.NewLine;
        private string v7815 = @" prom 7815"";" + Environment.NewLine;

        private string DA7803Limits = @"Reference 2 1396;" + Environment.NewLine +
                                      @"Label ""LSpec=1396"";" + Environment.NewLine +
                                      @"Reference 2 1462;" + Environment.NewLine +
                                      @"Label ""USpec=1462"";" + Environment.NewLine;

        private string DA7805Limits = @"Reference 2 -29258;" + Environment.NewLine +
                                      @"Label ""LSpec=-29258"";" + Environment.NewLine +
                                      @"Reference 2 -29324;" + Environment.NewLine +
                                      @"Label ""USpec=-29324"";" + Environment.NewLine;

        private string DA7815Limits = @"Reference 2 -32330;" + Environment.NewLine +
                                      @"Label ""USpec=-32330"";" + Environment.NewLine +
                                      @"Reference 2 -32396;" + Environment.NewLine +
                                      @"Label ""LSpec=-32396"";" + Environment.NewLine;

        private string DNAClimits = @"Reference 2 0;" + Environment.NewLine +
                                    @"Label ""LSpec=0"";" + Environment.NewLine +
                                    @"Reference 2 1.2;" + Environment.NewLine +
                                    @"Label ""USpec=1.2"";" + Environment.NewLine;

        private string LINlimits = @"Reference 2 0.05;" + Environment.NewLine +
                                   @"Label ""LSpec=0.05"";" + Environment.NewLine +
                                   @"Reference 2 1.00;" + Environment.NewLine +
                                   @"Label ""USpec=1.00"";" + Environment.NewLine;

        private string LLHPlimits = @"Reference 2 0.05;" + Environment.NewLine +
                                   @"Label ""LSpec=0.05"";" + Environment.NewLine +
                                   @"Reference 2 0.30;" + Environment.NewLine +
                                   @"Label ""USpec=0.30"";" + Environment.NewLine;


        private string L0U250 = @"Reference 2 0;" + Environment.NewLine +
                                @"Label ""LSpec=0"";" + Environment.NewLine +
                                @"Reference 2 250" + Environment.NewLine +
                                @"Label ""USpec=250"";" + Environment.NewLine;

        private string L6950U7450 = @"Reference 2 6950;" + Environment.NewLine +
                                    @"Label ""LSpec=6950"";" + Environment.NewLine +
                                    @"Reference 2 7450" + Environment.NewLine +
                                    @"Label ""USpec=7450"";" + Environment.NewLine;

        public Graphs_11_28_12(string board, string testStation, string purpose)
        {
            InitializeComponent();
            boardType = board;
            Purpose = purpose;
            if (testStation.Substring(9, 1) == "1")
            {
                company = "CEI";
            }
            else
            {
                company = "Zygo";
            }
        }

        private void Graphs_11_28_12_Load(object sender, EventArgs e)
        {

            SqlConnection cnxn = new SqlConnection
                ("server = CT-MID-SQL11; user = ReadWrite; password = Read+Write!; " +
                 "database = productioncontrol");
           
            //I can't remember exactly but I think that Minitab can't work with
            //zeros and needs a field to be null if the test wasn't performed so
            //I update it here.
            SqlCommand cmd = new SqlCommand
                ("Update [test data] " +
                 "set [ad +5v digital ps] = null, " +
                 "[ad +5v digital ps ripple] = null " +
                 "where AD = 'false';" +
                 "Update [test data] " +
                 "set [da rfdelay dau1] = null " +
                 "where DArf1 = 'false'; " +
                 "Update [test data] " +
                 "set [da rfdelay dau2] = null " +
                 "where DArf2 = 'false'; " +
                 "Update [test data] " +
                 "set [da age dau1] = null " +
                 "where DAms1 = 'false'; " +
                 "Update [test data] " +
                 "set [da age dau2] = null " +
                 "Where DAms2 = 'false'; " +
                 "Update [test data] " +
                 "set [da age dau3] = null " +
                 "Where DAms3 = 'false'; " +
                 "Update [test data] " +
                 "set [da age dau4] = null " +
                 "Where DAms4 = 'false'; " +
                 "Update [test data] " +
                 "set [LIN 10 MeasPower Ax1] = null, " +
                 "[LIN 10 SSI Avg Ax1] = null, " +
                 "[LIN 10 RMS Error Ax1] = null, " +
                 "[LIN 1 MeasPower Ax1] = null, " +
                 "[LIN 1 SSI Avg Ax1] = null, " +
                 "[LIN 1 RMS Error Ax1] = null, " +
                 "[LIN 60 MeasPower Ax1] = null, " +
                 "[LIN 60 SSI Avg Ax1] = null, " +
                 "[LIN 60 RMS Error Ax1] = null, " +
                 "[LIN .07 MeasPower Ax1] = null, " +
                 "[LIN .07 SSI Avg Ax1] = null, " +
                 "[LIN .07 RMS Error Ax1] = null " +
                 "Where LINx1 = 'false'; " +
                 "Update [test data] " +
                 "set [LIN 10 MeasPower Ax2] = null, " +
                 "[LIN 10 SSI Avg Ax2] = null, " +
                 "[LIN 10 RMS Error Ax2] = null, " +
                 "[LIN 60 MeasPower Ax2] = null, " +
                 "[LIN 60 SSI Avg Ax2] = null, " +
                 "[LIN 60 RMS Error Ax2] = null, " +
                 "[LIN 1 MeasPower Ax2] = null, " +
                 "[LIN 1 SSI Avg Ax2] = null, " +
                 "[LIN 1 RMS Error Ax2] = null, " +
                 "[LIN .07 MeasPower Ax2] = null, " +
                 "[LIN .07 SSI Avg Ax2] = null, " +
                 "[LIN .07 RMS Error Ax2] = null " +
                 "Where LINx2 = 'false'; " +
                 "Update [test data] " +
                 "set [LIN 10 MeasPower Ax3] = null, " +
                 "[LIN 10 SSI Avg Ax3] = null, " +
                 "[LIN 10 RMS Error Ax3] = null, " +
                 "[LIN 1 MeasPower Ax3] = null, " +
                 "[LIN 1 SSI Avg Ax3] = null, " +
                 "[LIN 1 RMS Error Ax3] = null, " +
                 "[LIN 60 MeasPower Ax3] = null, " +
                 "[LIN 60 SSI Avg Ax3] = null, " +
                 "[LIN 60 RMS Error Ax3] = null, " +
                 "[LIN .07 MeasPower Ax3] = null, " +
                 "[LIN .07 SSI Avg Ax3] = null, " +
                 "[LIN .07 RMS Error Ax3] = null " +
                 "Where LINx3 = 'false'; " +
                 "Update [test data] " +
                 "set [LIN 10 MeasPower Ax4] = null, " +
                 "[LIN 10 SSI Avg Ax4] = null, " +
                 "[LIN 10 RMS Error Ax4] = null, " +
                 "[LIN 1 MeasPower Ax4] = null, " +
                 "[LIN 1 SSI Avg Ax4] = null, " +
                 "[LIN 1 RMS Error Ax4] = null, " +
                 "[LIN 60 MeasPower Ax4] = null, " +
                 "[LIN 60 SSI Avg Ax4] = null, " +
                 "[LIN 60 RMS Error Ax4] = null, " +
                 "[LIN .07 MeasPower Ax4] = null, " +
                 "[LIN .07 SSI Avg Ax4] = null, " +
                 "[LIN .07 RMS Error Ax4] = null " +
                 "Where LINx4 = 'false'; " +
                 "Update [test data] " +
                 "set [LIN HP 2 Rms Error Ax1] = null " +
                 "Where LLHPx1x = 'false'; " +
                 "Update [test data] " +
                 "set [LIN HP 2 Rms Error Ax2] = null " +
                 "Where LLHPx2x = 'false'; " +
                 "Update [test data] " +
                 "set [LIN HP 2 Rms Error Ax3] = null " +
                 "Where LLHPx3x = 'false'; " +
                 "Update [test data] " +
                 "set [LIN HP 2 Rms Error Ax4] = null " +
                 "Where LLHPx4x = 'false'; " +
                 "Update [test data] " +
                 "set [DNAC 3.88 SSI Average Ax1] = null, " +
                 "[DNAC 3.88 Std Dev Ax1] = null, " +
                 "[DNAC 30.01 SSI Average Ax1] = null, " +
                 "[DNAC 30.01 Std Dev Ax1] = null, " +
                 "[DNAC 36.12 SSI Average Ax1] = null, " +
                 "[DNAC 36.12 Std Dev Ax1] = null " +
                 "Where DNACx1 = 'false'; " +
                 "Update [test data] " +
                 "set [DNAC 3.88 SSI Average Ax2] = null, " +
                 "[DNAC 3.88 Std Dev Ax2] = null, " +
                 "[DNAC 30.01 SSI Average Ax2] = null, " +
                 "[DNAC 30.01 Std Dev Ax2] = null, " +
                 "[DNAC 36.12 SSI Average Ax2] = null, " +
                 "[DNAC 36.12 Std Dev Ax2] = null " +
                 "Where DNACx2 = 'false'; " +
                 "Update [test data] " +
                 "set [DNAC 3.88 SSI Average Ax3] = null, " +
                 "[DNAC 3.88 Std Dev Ax3] = null, " +
                 "[DNAC 30.01 SSI Average Ax3] = null, " +
                 "[DNAC 30.01 Std Dev Ax3] = null, " +
                 "[DNAC 36.12 SSI Average Ax3] = null, " +
                 "[DNAC 36.12 Std Dev Ax3] = null " +
                 "Where DNACx3 = 'false'; " +
                 "Update [test data] " +
                 "set [DNAC 3.88 SSI Average Ax4] = null, " +
                 "[DNAC 3.88 Std Dev Ax4] = null, " +
                 "[DNAC 30.01 SSI Average Ax4] = null, " +
                 "[DNAC 30.01 Std Dev Ax4] = null, " +
                 "[DNAC 36.12 SSI Average Ax4] = null, " +
                 "[DNAC 36.12 Std Dev Ax4] = null " +
                 "Where DNACx4 = 'false'; " +
                 "Update [test data] " +
                 "set [DNAC HP 3.88 Std Dev Ax1] = null, " +
                 "[DNAC HP 30.01 Std Dev Ax1] = null, " +
                 "[DNAC HP 36.12 Std Dev Ax1] = null " +
                 "Where DNAChpx1 = 'false'; " +
                 "Update [test data] " +
                 "set [DNAC HP 3.88 Std Dev Ax2] = null, " +
                 "[DNAC HP 30.01 Std Dev Ax2] = null, " +
                 "[DNAC HP 36.12 Std Dev Ax2] = null " +
                 "Where DNAChpx2 = 'false'; " +
                 "Update [test data] " +
                 "set [DNAC HP 3.88 Std Dev Ax3] = null, " +
                 "[DNAC HP 30.01 Std Dev Ax3] = null, " +
                 "[DNAC HP 36.12 Std Dev Ax3] = null " +
                 "Where DNAChpx3 = 'false'; " +
                 "Update [test data] " +
                 "set [DNAC HP 3.88 Std Dev Ax4] = null, " +
                 "[DNAC HP 30.01 Std Dev Ax4] = null, " +
                 "[DNAC HP 36.12 Std Dev Ax4] = null " +
                 "Where DNAChpx4 = 'false'; " +
                 "Update [test data] " +
                 "set [EV PV FiberPwrMeas 7 uW Ax1] = null, " +
                 "[EV PV FiberPwrMeas 1 uW Ax1] = null, " +
                 "[EV PV FiberPwrMeas 0.3 uW Ax1] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 7 Ax1] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 1 Ax1] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 0.3 Ax1] = null, " +
                 "[EV PV CalcProcGainL2 7 Ax1] = null, " +
                 "[EV PV CalcProcGainL2 1 Ax1] = null, " +
                 "[EV PV CalcProcGainL2 0.3 Ax1] = null " +
                 "Where EVPVx1 = 'false'; " +
                 "Update [test data] " +
                 "set [EV PV FiberPwrMeas 7 uW Ax2] = null, " +
                 "[EV PV FiberPwrMeas 1 uW Ax2] = null, " +
                 "[EV PV FiberPwrMeas 0.3 uW Ax2] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 7 Ax2] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 1 Ax2] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 0.3 Ax2] = null, " +
                 "[EV PV CalcProcGainL2 7 Ax2] = null, " +
                 "[EV PV CalcProcGainL2 1 Ax2] = null, " +
                 "[EV PV CalcProcGainL2 0.3 Ax2] = null " +
                 "Where EVPVx2 = 'false'; " +
                 "Update [test data] " +
                 "set [EV PV FiberPwrMeas 7 uW Ax3] = null, " +
                 "[EV PV FiberPwrMeas 1 uW Ax3] = null, " +
                 "[EV PV FiberPwrMeas 0.3 uW Ax3] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 7 Ax3] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 1 Ax3] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 0.3 Ax3] = null, " +
                 "[EV PV CalcProcGainL2 7 Ax3] = null, " +
                 "[EV PV CalcProcGainL2 1 Ax3] = null, " +
                 "[EV PV CalcProcGainL2 0.3 Ax3] = null " +
                 "Where EVPVx3 = 'false'; " +
                 "Update [test data] " +
                 "set [EV PV FiberPwrMeas 7 uW Ax4] = null, " +
                 "[EV PV FiberPwrMeas 1 uW Ax4] = null, " +
                 "[EV PV FiberPwrMeas 0.3 uW Ax4] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 7 Ax4] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 1 Ax4] = null, " +
                 "[EV PV AcDcOptPwrDiffL2 0.3 Ax4] = null, " +
                 "[EV PV CalcProcGainL2 7 Ax4] = null, " +
                 "[EV PV CalcProcGainL2 1 Ax4] = null, " +
                 "[EV PV CalcProcGainL2 0.3 Ax4] = null " +
                 "Where EVPVx4 = 'false';" +
                 "Update [test data] " +
                 "set [SSI CAL 138 FiberPwrMeas Ax1] = null, " +
                 "[SSI CAL 138 SSI Avg Ax1] = null, " +
                 "[SSI CAL 60 FiberPwrMeas Ax1] = null, " +
                 "[SSI CAL 60 SSI Avg Ax1] = null, " +
                 "[SSI CAL 1 FiberPwrMeas Ax1] = null, " +
                 "[SSI CAL 1 SSI Avg Ax1] = null " +
                 "Where SSIx1x = 'false';" +
                 "Update [test data] " +
                 "set [SSI CAL 138 FiberPwrMeas Ax2] = null, " +
                 "[SSI CAL 138 SSI Avg Ax2] = null, " +
                 "[SSI CAL 60 FiberPwrMeas Ax2] = null, " +
                 "[SSI CAL 60 SSI Avg Ax2] = null, " +
                 "[SSI CAL 1 FiberPwrMeas Ax2] = null, " +
                 "[SSI CAL 1 SSI Avg Ax2] = null " +
                 "Where SSIx2x = 'false';" +
                 "Update [test data] " +
                 "set [SSI CAL 138 FiberPwrMeas Ax3] = null, " +
                 "[SSI CAL 138 SSI Avg Ax3] = null, " +
                 "[SSI CAL 60 FiberPwrMeas Ax3] = null, " +
                 "[SSI CAL 60 SSI Avg Ax3] = null, " +
                 "[SSI CAL 1 FiberPwrMeas Ax3] = null, " +
                 "[SSI CAL 1 SSI Avg Ax3] = null " +
                 "Where SSIx3x = 'false';" +
                 "Update [test data] " +
                 "set [SSI CAL 138 FiberPwrMeas Ax4] = null, " +
                 "[SSI CAL 138 SSI Avg Ax4] = null, " +
                 "[SSI CAL 60 FiberPwrMeas Ax4] = null, " +
                 "[SSI CAL 60 SSI Avg Ax4] = null, " +
                 "[SSI CAL 1 FiberPwrMeas Ax4] = null, " +
                 "[SSI CAL 1 SSI Avg Ax4] = null " +
                 "Where SSIx4x = 'false';", cnxn);

            cnxn.Open();
            cmd.ExecuteNonQuery();
            cnxn.Close();

            string odb1 = @"ODBC; Connect ""Description=ProductionControl;DRIVER=SQL Server;"" &" + Environment.NewLine +
                          @"""SERVER=midsql01;UID=views;PWD=views;APP=Minitab Release 16;WSID=MIDWS0167;""&" + Environment.NewLine +
                          @"""DATABASE=ProductionControl"";" + Environment.NewLine +
                          @"SQLString ""Select sn, [its build number], [Test Date], iteration, "" &" + Environment.NewLine +
                          @""" [board promver], "" &" + Environment.NewLine;

            /*
            string text = File.ReadAllText("PCCconfigFile.txt");
            text = text.Substring(text.IndexOf("=") + 1, text.Length - (text.IndexOf("=") + 1));
            string savePath = @"Gsave " + text +
                Purpose + @"\" + company + @"\";*/
            string savePath = @"Gsave ""\\midfile01\departments\pps\manufacturing\control charts\" +
                Purpose + @"\" + company + @"\";

            if (boardType == "4104")
            {
                savePath = savePath + @"4104\4104 ";

                if (company == "CEI")
                {
                    if (Purpose == "MCert")
                    {
                        cmd = new SqlCommand
                            ("Select sn from [test data] where [board promver] = 7803 " +
                            "and (sn = 618041 or sn = 618042 or sn = 9145386)", cnxn);
                        cnxn.Open();
                        t7803 = cmd.ExecuteScalar();
                        cnxn.Close();

                        cmd = new SqlCommand
                            ("Select sn from [test data] where [board promver] = 7805 " +
                             "and (sn = 618041 or sn = 618042 or sn = 9145386)", cnxn);
                        cnxn.Open();
                        t7805 = cmd.ExecuteScalar();
                        cnxn.Close();


                        odb2a = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                                @"""where (sn = 618041 or sn = 618042 or sn = 9145386) "" &" + Environment.NewLine +
                                @"""and [board promver] = 7803 "" &" + Environment.NewLine;

                        odb2b = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                                @"""where (sn = 618041 or sn = 618042 or sn = 9145386) "" &" + Environment.NewLine +
                                @"""and [board promver] = 7805 "" &" + Environment.NewLine;

                        odb2 = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                                  @"""where (sn = 618041 or sn = 618042 or sn = 9145386) "" &" + Environment.NewLine;

                        cmd = new SqlCommand
                           ("Delete from [failure log] where company = '" + company +
                            "' and board = '" + boardType + "' and " +
                            "([xml file] like '%618041%' or [xml file] like '%618042%' " +
                            "or [xml file] like '%9145386%')", cnxn);
                        cnxn.Open();
                        cmd.ExecuteNonQuery();
                        cnxn.Close();

                    }
                    else
                    {
                        cmd = new SqlCommand
                            ("Select sn from [test data] where [board promver] = 7803 " +
                             "and [test station] = 'zmi-test-1' " +
                             "and (sn != 618041 and sn != 618042 and sn != 9145386)", cnxn);
                        cnxn.Open();
                        t7803 = cmd.ExecuteScalar();
                        cnxn.Close();

                        cmd = new SqlCommand
                            ("Select sn from [test data] where [board promver] = 7805 " +
                             "and [test station] = 'zmi-test-1' " +
                             "and (sn != 618041 and sn != 618042 and sn != 9145386)", cnxn);
                        cnxn.Open();
                        t7805 = cmd.ExecuteScalar();
                        cnxn.Close();

                        odb2a = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                                @"""where (sn != 618041 and sn != 618042 and sn != 9145386) "" &" + Environment.NewLine +
                                @"""and [board promver] = 7803 "" &" + Environment.NewLine;

                        odb2b = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                                @"""where (sn != 618041 and sn != 618042 and sn != 9145386) "" &" + Environment.NewLine +
                                @"""and [board promver] = 7805 "" &" + Environment.NewLine;

                        odb2 = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                               @"""where (sn != 618041 and sn != 618042 and sn != 9145386) "" &" + Environment.NewLine;

                        cmd = new SqlCommand
                           ("Delete from [failure log] where company = '" + company +
                            "' and board = '" + boardType + "' and " +
                            "([xml file] not like '%618041%' and [xml file] not like '%618042%' " +
                            "and [xml file] not like '%9145386%')", cnxn);
                        cnxn.Open();
                        cmd.ExecuteNonQuery();
                        cnxn.Close();
                    }


                    odb4 = @"] is not null "" & " + Environment.NewLine +
                               @"""and [board type] = 'zmi 4104' and [test station] = 'zmi-test-1'""." + Environment.NewLine +
                               @"fdate/time c3;" + Environment.NewLine +
                               @"format(DTm/d/yy)." + Environment.NewLine +
                               @"Sort c1 c2 c3 c4 c5 c6 c1 c2 c3 c4 c5 c6;" + Environment.NewLine +
                               @"by c3." + Environment.NewLine +
                               @"count c1." + Environment.NewLine;
                }
                else     //Zygo
                {
                    if (Purpose == "MCert")
                    {
                        cmd = new SqlCommand
                            ("Select sn from [test data] where [board promver] = 7815 " +
                             "and (sn = 5399446)", cnxn);
                        cnxn.Open();
                        t7815 = cmd.ExecuteScalar();
                        cnxn.Close();

                        cmd = new SqlCommand
                            ("Select sn from [test data] where [board promver] = 7803 " +
                            "and (sn = 07382437 or sn = 07262253 or sn = 07432600)", cnxn);
                        cnxn.Open();
                        t7803 = cmd.ExecuteScalar();
                        cnxn.Close();

                        cmd = new SqlCommand
                            ("Select sn from [test data] where [board promver] = 7805 " +
                             "and (sn = 07382437 or sn = 07262253 or sn = 07432600)", cnxn);
                        cnxn.Open();
                        t7805 = cmd.ExecuteScalar();
                        cnxn.Close();


                        odb2a = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                                @"""where (sn = 07382437 or sn = 07262253 or sn = 07432600) "" &" + Environment.NewLine +
                                @"""and [board promver] = 7803 "" &" + Environment.NewLine;

                        odb2b = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                                @"""where (sn = 07382437 or sn = 07262253 or sn = 07432600) "" &" + Environment.NewLine +
                                @"""and [board promver] = 7805 "" &" + Environment.NewLine;

                        odb2c = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                                @"""where (sn = 5399446) "" &" + Environment.NewLine +
                                @"""and [board promver] = 7815 "" &" + Environment.NewLine;

                        odb2 = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                               @"""where (sn = 07382437 or sn = 07262253 or "" &" + Environment.NewLine +
                               @"""sn = 07432600 or sn = 05399446) "" &" + Environment.NewLine;

                        cmd = new SqlCommand
                           ("Delete from [failure log] where company = '" + company +
                            "' and board = '" + boardType + "' and " +
                            "([xml file] like '%07382437%'or [xml file] like '%07262253%' or " +
                            "[xml file] like '%07432600%' or [xml file] like '%05399446%')", cnxn);
                        cnxn.Open();
                        cmd.ExecuteNonQuery();
                        cnxn.Close();
                    }
                    else
                    {
                        cmd = new SqlCommand
                            ("Select sn from [test data] where [board promver] = 7803 " +
                             "and ([test station] = 'ZMI-4K-ITS' or [test station] = 'zmi-4k-its') " +
                             "and (sn != 07382437 and sn != 07262253 and sn != 07432600)", cnxn);
                        cnxn.Open();
                        t7803 = cmd.ExecuteScalar();
                        cnxn.Close();

                        cmd = new SqlCommand
                            ("Select sn from [test data] where [board promver] = 7805 " +
                             "and ([test station] = 'ZMI-4K-ITS' or [test station] = 'zmi-4k-its') " +
                             "and (sn != 07382437 and sn != 07262253 and sn != 07432600)", cnxn);
                        cnxn.Open();
                        t7805 = cmd.ExecuteScalar();
                        cnxn.Close();

                        cmd = new SqlCommand
                            ("Select sn from [test data] where [board promver] = 7815 " +
                             "and ([test station] = 'ZMI-4K-ITS' or [test station] = 'zmi-4k-its') " +
                             "and (sn != 5399446)", cnxn);
                        cnxn.Open();
                        t7815 = cmd.ExecuteScalar();
                        cnxn.Close();

                        odb2a = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                                @"""where (sn != 07382437 and sn != 07262253 and sn != 07432600) "" &" + Environment.NewLine +
                                @"""and [board promver] = 7803 "" &" + Environment.NewLine;

                        odb2b = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                                @"""where (sn != 07382437 and sn != 07262253 and sn != 07432600) "" &" + Environment.NewLine +
                                @"""and [board promver] = 7805 "" &" + Environment.NewLine;

                        odb2c = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                                @"""where (sn != 5399446) "" &" + Environment.NewLine +
                                @"""and charindex('utc', [xml file name]) > 0 "" &" + Environment.NewLine +
                                @"""and [board promver] = 7815 "" &" + Environment.NewLine;

                        odb2d = odb2c;
                        
                        odb2 = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                               @"""where (sn != 07382437 and sn != 07262253 and "" &" + Environment.NewLine +
                               @"""sn != 07432600 and sn != 05399446) "" &" + Environment.NewLine;

                        cmd = new SqlCommand
                           ("Delete from [failure log] where company = '" + company +
                            "' and board = '" + boardType + "' and " +
                            "([xml file] not like '%07382437%' and [xml file] not like '%07262253%' " +
                            "and [xml file] not like '%07432600%' and [xml file] not like '%05399446%')", cnxn);
                        cnxn.Open();
                        cmd.ExecuteNonQuery();
                        cnxn.Close();
                    }

                    odb4 = @"] is not null "" & " + Environment.NewLine +
                           @"""and [board type] = 'zmi 4104' and "" &" + Environment.NewLine +
                           @"""([test station] = 'ZMI-4K-ITS' or [test station] = 'zmi-4k-its')""." + Environment.NewLine +
                           @"fdate/time c3;" + Environment.NewLine +
                           @"format(DTm/d/yy)." + Environment.NewLine +
                           @"Sort c1 c2 c3 c4 c5 c6 c1 c2 c3 c4 c5 c6;" + Environment.NewLine +
                           @"by c3." + Environment.NewLine +
                           @"Count c1." + Environment.NewLine;
                }

                test[1] = "AD +5V Digital PS Ripple";

                graph[1] = @"Reference 2 0;" + Environment.NewLine +
                           @"Label ""LSpec=0"";" + Environment.NewLine +
                           @"Reference 2 0.05;" + Environment.NewLine +
                           @"Label ""USpec=0.05"";" + Environment.NewLine;

                test[2] = "AD +5V Digital PS";

                graph[2] = @"Reference 2 4.75;" + Environment.NewLine +
                           @"Label ""LSpec=4.75"";" + Environment.NewLine +
                           @"Reference 2 5.25;" + Environment.NewLine +
                           @"Label ""USpec=5.25"";" + Environment.NewLine;

                test[3] = "DA RfDelay DAU1";

                graph[3] = @"Reference 2 50;" + Environment.NewLine +
                            @"Label ""LSpec=50"";" + Environment.NewLine +
                            @"Reference 2 70;" + Environment.NewLine +
                            @"Label ""USpec=70"";" + Environment.NewLine;

                test[4] = "DA RfDelay DAU2";

                graph[4] = graph[3];

                test[5] = "DNAC 3.88 SSI Average Ax1";

                graph[5] = "";

                test[6] = "DNAC 30.01 SSI Average Ax1";

                graph[6] = "";

                test[7] = "DNAC 36.12 SSI Average Ax1";

                graph[7] = "";

                test[8] = "DNAC 3.88 Std Dev Ax1";

                graph[8] = DNAClimits;

                test[9] = "DNAC 30.01 Std Dev Ax1";

                graph[9] = DNAClimits;

                test[10] = "DNAC 36.12 Std Dev Ax1";

                graph[10] = DNAClimits;

                test[11] = "DNAC 3.88 SSI Average Ax2";

                graph[11] = "";

                test[12] = "DNAC 30.01 SSI Average Ax2";

                graph[12] = "";

                test[13] = "DNAC 36.12 SSI Average Ax2";

                graph[13] = "";

                test[14] = "DNAC 3.88 Std Dev Ax2";

                graph[14] = DNAClimits;

                test[15] = "DNAC 30.01 Std Dev Ax2";

                graph[15] = DNAClimits;

                test[16] = "DNAC 36.12 Std Dev Ax2";

                graph[16] = DNAClimits;

                test[17] = "DNAC 3.88 SSI Average Ax3";

                graph[17] = "";

                test[18] = "DNAC 30.01 SSI Average Ax3";

                graph[18] = "";

                test[19] = "DNAC 36.12 SSI Average Ax3";

                graph[19] = "";

                test[20] = "DNAC 3.88 Std Dev Ax3";

                graph[20] = DNAClimits;

                test[21] = "DNAC 30.01 Std Dev Ax3";

                graph[21] = DNAClimits;

                test[22] = "DNAC 36.12 Std Dev Ax3";

                graph[22] = DNAClimits;

                test[23] = "DNAC 3.88 SSI Average Ax4";

                graph[23] = "";

                test[24] = "DNAC 30.01 SSI Average Ax4";

                graph[24] = "";

                test[25] = "DNAC 36.12 SSI Average Ax4";

                graph[25] = "";

                test[26] = "DNAC 3.88 Std Dev Ax4";

                graph[26] = DNAClimits;

                test[27] = "DNAC 30.01 Std Dev Ax4";

                graph[27] = DNAClimits;

                test[28] = "DNAC 36.12 Std Dev Ax4";

                graph[28] = DNAClimits;

                test[29] = "Lin 10 MeasPower Ax1";

                graph[29] = "";

                test[30] = "Lin 1 MeasPower Ax1";

                graph[30] = "";

                test[31] = "Lin .07 MeasPower Ax1";

                graph[31] = "";

                test[32] = "Lin 10 RMS Error Ax1";

                graph[32] = LINlimits;

                test[33] = "Lin 1 RMS Error Ax1";

                graph[33] = LINlimits;

                test[34] = "Lin .07 RMS Error Ax1";

                graph[34] = LINlimits;

                test[35] = "Lin 10 SSI Avg Ax1";

                graph[35] = "";

                test[36] = "Lin 1 SSI Avg Ax1";

                graph[36] = "";

                test[37] = "Lin .07 SSI Avg Ax1";

                graph[37] = "";

                test[38] = "Lin 10 MeasPower Ax2";

                graph[38] = "";

                test[39] = "Lin 1 MeasPower Ax2";

                graph[39] = "";

                test[40] = "Lin .07 MeasPower Ax2";

                graph[40] = "";

                test[41] = "Lin 10 RMS Error Ax2";

                graph[41] = LINlimits;

                test[42] = "Lin 1 RMS Error Ax2";

                graph[42] = LINlimits;

                test[43] = "Lin .07 RMS Error Ax2";

                graph[43] = LINlimits;

                test[44] = "Lin 10 SSI Avg Ax2";

                graph[44] = "";

                test[45] = "Lin 1 SSI Avg Ax2";

                graph[45] = "";

                test[46] = "Lin .07 SSI Avg Ax2";

                graph[46] = "";

                test[47] = "Lin 10 MeasPower Ax3";

                graph[47] = "";

                test[48] = "Lin 1 MeasPower Ax3";

                graph[48] = "";

                test[49] = "Lin .07 MeasPower Ax3";

                graph[49] = "";

                test[50] = "Lin 10 RMS Error Ax3";

                graph[50] = LINlimits;

                test[51] = "Lin 1 RMS Error Ax3";

                graph[51] = LINlimits;

                test[52] = "Lin .07 RMS Error Ax3";

                graph[52] = LINlimits;

                test[53] = "Lin 10 SSI Avg Ax3";

                graph[53] = "";

                test[54] = "Lin 1 SSI Avg Ax3";

                graph[54] = "";

                test[55] = "Lin .07 SSI Avg Ax3";

                graph[55] = "";

                test[56] = "Lin 10 MeasPower Ax4";

                graph[56] = "";

                test[57] = "Lin 1 MeasPower Ax4";

                graph[57] = "";

                test[58] = "Lin .07 MeasPower Ax4";

                graph[58] = "";

                test[59] = "Lin 10 RMS Error Ax4";

                graph[59] = LINlimits;

                test[60] = "Lin 1 RMS Error Ax4";

                graph[60] = LINlimits;

                test[61] = "Lin .07 RMS Error Ax4";

                graph[61] = LINlimits;

                test[62] = "Lin 10 SSI Avg Ax4";

                graph[62] = "";

                test[63] = "Lin 1 SSI Avg Ax4";

                graph[63] = "";

                test[64] = "Lin .07 SSI Avg Ax4";

                graph[64] = "";

                test[65] = @"EV PV FiberPwrMeas 7 uW Ax1";

                graph[65] = "";

                test[66] = @"EV PV FiberPwrMeas 1 uW Ax1";

                graph[66] = "";

                test[67] = @"EV PV FiberPwrMeas 0.3 uW Ax1";

                graph[67] = "";

                test[68] = @"EV PV AcDcOptPwrDiffL2 7 Ax1";

                graph[68] = L0U250;

                test[69] = @"EV PV AcDcOptPwrDiffL2 1 Ax1";

                graph[69] = L0U250;

                test[70] = @"EV PV AcDcOptPwrDiffL2 0.3 Ax1";

                graph[70] = L0U250;

                test[71] = @"EV PV CalcProcGainL2 7 Ax1";

                graph[71] = L6950U7450;

                test[72] = @"EV PV CalcProcGainL2 1 Ax1";

                graph[72] = L6950U7450;

                test[73] = @"EV PV CalcProcGainL2 0.3 Ax1";

                graph[73] = L6950U7450;

                test[74] = @"EV PV AcDcOptPwrDiffL2 7 Ax2";

                graph[74] = L0U250;

                test[75] = @"EV PV AcDcOptPwrDiffL2 1 Ax2";

                graph[75] = L0U250;

                test[76] = @"EV PV AcDcOptPwrDiffL2 0.3 Ax2";

                graph[76] = L0U250;

                test[77] = @"EV PV CalcProcGainL2 7 Ax2";

                graph[77] = L6950U7450;

                test[78] = @"EV PV CalcProcGainL2 1 Ax2";

                graph[78] = L6950U7450;

                test[79] = @"EV PV CalcProcGainL2 0.3 Ax2";

                graph[79] = L6950U7450;

                test[80] = @"EV PV AcDcOptPwrDiffL2 7 Ax3";

                graph[80] = L0U250;

                test[81] = @"EV PV AcDcOptPwrDiffL2 1 Ax3";

                graph[81] = L0U250;

                test[82] = @"EV PV AcDcOptPwrDiffL2 0.3 Ax3";

                graph[82] = L0U250;

                test[83] = @"EV PV CalcProcGainL2 7 Ax3";

                graph[83] = L6950U7450;

                test[84] = @"EV PV CalcProcGainL2 1 Ax3";

                graph[84] = L6950U7450;

                test[85] = @"EV PV CalcProcGainL2 0.3 Ax3";

                graph[85] = L6950U7450;

                test[86] = @"EV PV AcDcOptPwrDiffL2 7 Ax4";

                graph[86] = L0U250;

                test[87] = @"EV PV AcDcOptPwrDiffL2 1 Ax4";

                graph[87] = L0U250;

                test[88] = @"EV PV AcDcOptPwrDiffL2 0.3 Ax4";

                graph[88] = L0U250;

                test[89] = @"EV PV CalcProcGainL2 7 Ax4";

                graph[89] = L6950U7450;

                test[90] = @"EV PV CalcProcGainL2 1 Ax4";

                graph[90] = L6950U7450;

                test[91] = @"EV PV CalcProcGainL2 0.3 Ax4";

                graph[91] = L6950U7450;

                test[92] = "DA Age DAU1";

                graph[92] = DA7803Limits;

                test[93] = "DA Age DAU1";

                graph[93] = DA7805Limits;

                test[94] = "DA Age DAU1";

                graph[94] = DA7815Limits;

                test[95] = "DA Age DAU2";

                graph[95] = DA7803Limits;

                test[96] = "DA Age DAU2";

                graph[96] = DA7805Limits;

                test[97] = "DA Age DAU2";

                graph[97] = DA7815Limits;

                test[98] = "DA Age DAU3";

                graph[98] = DA7803Limits;

                test[99] = "DA Age DAU3";

                graph[99] = DA7805Limits;

                test[100] = "DA Age DAU3";

                graph[100] = DA7815Limits;

                test[101] = "DA Age DAU4";

                graph[101] = DA7803Limits;

                test[102] = "DA Age DAU4";

                graph[102] = DA7805Limits;

                test[103] = "DA Age DAU4";

                graph[103] = DA7815Limits;

                test[104] = "LIN HP 2 Rms Error Ax1";

                graph[104] = LLHPlimits;

                test[105] = "LIN HP 2 Rms Error Ax2";

                graph[105] = LLHPlimits;

                test[106] = "LIN HP 2 Rms Error Ax3";

                graph[106] = LLHPlimits;

                test[107] = "LIN HP 2 Rms Error Ax4";

                graph[107] = LLHPlimits;

                test[108] = "DNAC HP 3.88 Std Dev Ax1";

                graph[108] = DNAClimits;

                test[109] = "DNAC HP 30.01 Std Dev Ax1";

                graph[109] = DNAClimits;

                test[110] = "DNAC HP 36.12 Std Dev Ax1";

                graph[110] = DNAClimits;

                test[111] = "DNAC HP 3.88 Std Dev Ax2";

                graph[111] = DNAClimits;

                test[112] = "DNAC HP 30.01 Std Dev Ax2";

                graph[112] = DNAClimits;

                test[113] = "DNAC HP 36.12 Std Dev Ax2";

                graph[113] = DNAClimits;

                test[114] = "DNAC HP 3.88 Std Dev Ax3";

                graph[114] = DNAClimits;

                test[115] = "DNAC HP 30.01 Std Dev Ax3";

                graph[115] = DNAClimits;

                test[116] = "DNAC HP 36.12 Std Dev Ax3";

                graph[116] = DNAClimits;

                test[117] = "DNAC HP 3.88 Std Dev Ax4";

                graph[117] = DNAClimits;

                test[118] = "DNAC HP 30.01 Std Dev Ax4";

                graph[118] = DNAClimits;

                test[119] = "DNAC HP 36.12 Std Dev Ax4";

                graph[119] = DNAClimits;

                test[120] = @"EV PV CalcProcGainL2 0.3 Ax1";

                graph[120] = L6950U7450 + wClose;

                Mtb.Application Mtap = new Mtb.Application();
                Mtb.Project Mtab = Mtap.ActiveProject;
                Mtb.UserInterface mtbUI = Mtap.UserInterface;
                mtbUI.Visible = true;
                mtbUI.DisplayAlerts = false;

                File.WriteAllText(savePath.Substring(7) + " Failure Report.txt", "Failure Report" +
                    Environment.NewLine + Environment.NewLine);

                int i = 1;      // i = number of graph - needs to start at 1


                while (i < 120)
                {
                    firstCommand = odb1 +
                           @"""[" + test[i] + @"] "" & " + Environment.NewLine +
                           odb2 +
                           @"""and [" + test[i] +
                           odb4;

                    if (i == 92 || i == 95 || i == 98 || i == 101)
                    {
                        if (t7803 != null)
                        {
                            firstCommand = odb1 +
                                           @"""[" + test[i] + @"] "" & " + Environment.NewLine +
                                           odb2a +
                                           @"""and [" + test[i] +
                                           odb4;
                        }
                    }

                    if (i == 93 || i == 96 || i == 99 || i == 102)
                    {
                        if (t7805 != null)
                        {
                            firstCommand = odb1 +
                                           @"""[" + test[i] + @"] "" & " + Environment.NewLine +
                                           odb2b +
                                           @"""and [" + test[i] +
                                           odb4;
                        }
                    }

                    if (i == 94 || i == 97 || i == 100 || i == 103)
                    {
                        if (t7815 != null)
                        {
                            firstCommand = odb1 +
                                           @"""[" + test[i] + @"] "" & " + Environment.NewLine +
                                           odb2c +
                                           @"""and [" + test[i] +
                                           odb4;
                        }
                    }

                    if (i >= 104)
                    {
                        firstCommand = odb1 +
                                       @"""[" + test[i] + @"] "" & " + Environment.NewLine +
                                       odb2c +
                                       @"""and [" + test[i] +
                                       odb4;
                    }

                    Mtab.ExecuteCommand(firstCommand, Type.Missing);

                    string mTabCountString = Mtab.Commands.OutputDocument.Text;
                    char[] anyof = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
                    int findex = mTabCountString.IndexOfAny(anyof);

                    int lindex = mTabCountString.LastIndexOfAny(anyof);
                    string reading = mTabCountString.Substring(findex, (lindex - findex) + 1);
                    readings = Convert.ToInt32(reading);

                    int tikCalc = readings / 5;
                    int tik2 = 2 * tikCalc;
                    int tik3 = 3 * tikCalc;
                    int tik4 = 4 * tikCalc;
                    int tik5 = 5 * tikCalc;
                    ticks = "tick " +
                        tikCalc.ToString() + " " +
                        tik2.ToString() + " " +
                        tik3.ToString() + " " +
                        tik4.ToString() + " " +
                        tik5.ToString();

                    //get board and run from minitab

                    object xx = Mtab.ActiveWorksheet.Columns.Item("sn").GetData(1, readings);
                    object xy = Mtab.ActiveWorksheet.Columns.Item("iteration").GetData(1, readings);

                    double[] xx2 = (double[])xx;
                    string[] temp = Array.ConvertAll(xx2, new Converter<double, string>(double2string));
                    string[] xy2 = (string[])xy;
                    string station;
                    if (company == "Zygo")
                    {
                        station = ".ZMI-4K-ITS.";
                    }
                    else
                    {
                        station = ".ZMI-TEST-1.";
                    }

                    //combine board and run into one array
                    int b = 0;
                    while (b < readings)
                    {
                        if (temp[b].Length == 6)
                        {
                            temp[b] = "00" + temp[b];
                        }
                        if (temp[b].Length == 7)
                        {
                            temp[b] = "0" + temp[b];
                        }

                        runs[b] = "CE." + temp[b] + station + xy2[b];
                        b++;
                    }

                    Mtab.Commands.Delete();

                    if (Purpose == "Production")
                    {
                        graph[i] = @"plot '" + test[i] + @"' * 'test date';" + Environment.NewLine +
                        @"Title ""Engineering 4104"";" + Environment.NewLine +
                        @"Title ""Scatterplot of " + test[i] + @""";" + Environment.NewLine +
                        "Symbol 'SN';" + Environment.NewLine +
                        "nolegend;" + Environment.NewLine + graph[i];
                    }
                    else
                    {
                        if (i == 92 || i == 95 || i == 98 || i == 101)
                        {
                            if (t7803 != null)
                            {
                                graph[i] = @"plot '" +
                                test[i] + dateTitle +
                                test[i] + v7803 +
                                connect + graph[i];
                            }
                        }
                        else if (i == 93 || i == 96 || i == 99 || i == 102)
                        {
                            if (t7805 != null)
                            {
                                graph[i] = @"plot '" +
                                test[i] + dateTitle +
                                test[i] + v7805 +
                                connect + graph[i];
                            }
                        }
                        else if (i == 94 || i == 97 || i == 100 || i == 103)
                        {
                            if (t7815 != null)
                            {
                                graph[i] = @"plot '" +
                                test[i] + dateTitle +
                                test[i] + v7815 +
                                connect + graph[i];
                            }
                        }
                        else
                        {
                            graph[i] = @"plot '" +
                            test[i] + dateTitle +
                            test[i] + @""";" + Environment.NewLine +
                            connect + graph[i];
                        }
                    }

                    if (i == 92 || i == 95 || i == 98 || i == 101)
                    {
                        if (t7803 != null)
                        {
                            graph[i] = graph[i] + savePath + @"Eng " + test[i] + v7803 +
                            gClose +
                            @"Ichart '" + test[i] + "' ;" + Environment.NewLine +
                            "Exclude;" + Environment.NewLine +
                            @"Where ""'ITS Build Number' < 600"";" + Environment.NewLine +
                            "Test 1 2 3 4 5 6 7 8;" + Environment.NewLine +
                            "Scale 1;" + Environment.NewLine +
                            ticks + Environment.NewLine +
                            @"Title ""Quality 4104 prom 7803"";" + Environment.NewLine +
                            "Title;" + Environment.NewLine +
                            @"Stamp 'Test Date' ;" + Environment.NewLine +
                            savePath + @"Qual " + test[i] + v7803 +
                            gClose +
                            wClose;
                        }
                        else
                        {
                            graph[i] = wClose;
                        }
                    }
                    else if (i == 93 || i == 96 || i == 99 || i == 102)
                    {
                        if (t7805 != null)
                        {
                            graph[i] = graph[i] + savePath + @"Eng " + test[i] + v7805 +
                            gClose +
                            @"Ichart '" + test[i] + "' ;" + Environment.NewLine +
                            "Exclude;" + Environment.NewLine +
                            @"Where ""'ITS Build Number' < 600"";" + Environment.NewLine +
                            "Test 1 2 3 4 5 6 7 8;" + Environment.NewLine +
                            @"Title ""Quality 4104 prom 7805"";" + Environment.NewLine +
                            "Scale 1;" + Environment.NewLine +
                            ticks + Environment.NewLine +
                            "Title;" + Environment.NewLine +
                            @"Stamp 'Test Date' ;" + Environment.NewLine +
                            savePath + @"Qual " + test[i] + v7805 +
                            gClose +
                            wClose;
                        }
                        else
                        {
                            graph[i] = wClose;
                        }
                    }
                    else if (i == 94 || i == 97 || i == 100 || i == 103)
                    {
                        if (t7815 != null)
                        {
                            graph[i] =

                            graph[i] + savePath + @"Eng " + test[i] + v7815 +
                            gClose +
                            @"Ichart '" + test[i] + "' ;" + Environment.NewLine +
                            "Exclude;" + Environment.NewLine +
                            @"Where ""'ITS Build Number' < 600"";" + Environment.NewLine +
                            "Test 1 2 3 4 5 6 7 8;" + Environment.NewLine +
                            @"Title ""Quality 4104 prom 7815"";" + Environment.NewLine +
                            "Scale 1;" + Environment.NewLine +
                            ticks + Environment.NewLine +
                            "Title;" + Environment.NewLine +
                            @"Stamp 'Test Date' ;" + Environment.NewLine +
                            savePath + @"Qual " + test[i] + v7815 +
                            gClose +
                            wClose;
                        }
                        else
                        {
                            graph[i] = wClose;
                        }
                    }
                    else
                    {
                        graph[i] = graph[i] + savePath + @"Eng " + test[i] + @""";" + Environment.NewLine +
                            gClose +
                            @"Ichart '" + test[i] + "' ;" + Environment.NewLine +
                            "Exclude;" + Environment.NewLine +
                            @"Where ""'ITS Build Number' < 600"";" + Environment.NewLine +
                            "Test 1 2 3 4 5 6 7 8;" + Environment.NewLine +
                            "Scale 1;" + Environment.NewLine +
                            ticks + Environment.NewLine +
                            @"Title ""Quality 4104"";" + Environment.NewLine +
                            "Title;" + Environment.NewLine +
                            @"Stamp 'Test Date' ;" + Environment.NewLine +
                            savePath + @"Qual " + test[i] + @""";" + Environment.NewLine +
                            gClose +
                            wClose;
                    }

                    Mtab.ExecuteCommand(graph[i], Type.Missing);

                    string x = Mtab.Commands.OutputDocument.Text;

                    if (x.IndexOf("Test Failed") > -1)
                    {
                        File.AppendAllText(savePath.Substring(7) + " Failure Report.txt", log + "  " + company +
                                "  " + boardType + "  test " + test[i] + " failed" + Environment.NewLine);

                        File.AppendAllText(savePath.Substring(7) + " Failure Report.txt", x + Environment.NewLine);

                        int start = 0;
                        int end = x.IndexOf("Excluding");

                        while ((start = x.IndexOf("TEST", start)) != -1)
                        {
                            // identify location of next test
                            int pointStop = x.IndexOf("TEST", start + 1);
                            // if no next test stop at end
                            if (pointStop == -1)
                            {
                                pointStop = end;
                            }
                            // find location of point data
                            int pointStart = x.IndexOf(":", start);
                            int digits = 0;
                            while (((pointStart = x.IndexOfAny(anyof, pointStart)) != -1) && pointStart < pointStop)
                            {
                                int digitPlace = pointStart;
                                int comma = x.IndexOf(",", digitPlace, pointStop - digitPlace);
                                if (comma == -1)
                                {
                                    comma = pointStop;
                                }
                                while (((digitPlace = x.IndexOfAny(anyof, digitPlace)) != -1) && digitPlace < comma)
                                {
                                    digitPlace += 1;
                                    digits++;
                                }

                                // record test number
                                failureLog[failLogIndex, 0] = x.Substring(start, 6);

                                failureLog[failLogIndex, 1] = x.Substring(pointStart, digits);

                                int find = Convert.ToInt32(x.Substring(pointStart, digits));
                                failureLog[failLogIndex, 2] = runs[find - 1];

                                File.AppendAllText(savePath.Substring(7) + " Failure Report.txt",
                                    failureLog[failLogIndex, 0] + "  " +
                                    failureLog[failLogIndex, 1] + "  " +
                                    failureLog[failLogIndex, 2] + Environment.NewLine);

                                cmd = new SqlCommand
                                    ("Insert into [failure log] (" +
                                     "company, " +
                                     "board, " +
                                     "[board test], " +
                                     "[xml file], " +
                                     "[minitab test]) values ('" +
                                     company + "','" +
                                     boardType + "','" +
                                     test[i] + "','" +
                                     failureLog[failLogIndex, 2] + "','" +
                                     failureLog[failLogIndex, 0] + "')", cnxn);
                                cnxn.Open();
                                cmd.ExecuteNonQuery();
                                cnxn.Close();
                                pointStart += digits;
                                failLogIndex += 1;
                                digits = 0;
                            }
                            start += 1;
                        }
                        File.AppendAllText(savePath.Substring(7) + " Failure Report.txt", Environment.NewLine);
                        int n = 0;
                        while (n < readings)
                        {
                            //File.AppendAllText(savePath.Substring(7) + " Failure Report.txt", n + 1 + ", " + xx2[n] +
                            //    "." + xy2[n] + Environment.NewLine);
                            File.AppendAllText(savePath.Substring(7) + " Failure Report.txt", n + 1 + ", " + runs[n] +
                            Environment.NewLine);
                            n++;
                        }
                        File.AppendAllText(savePath.Substring(7) + " Failure Report.txt", Environment.NewLine +
                            "****************************************" +
                            "****************************************" + Environment.NewLine);
                    }

                    Mtab.Commands.Delete();
                    i++;
                }
                Mtap.Quit();
                Mtap = null;
                foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName("mtb"))
                {
                    p.Kill();
                }
                Close();
            }
            else
            {
                savePath = savePath + @"4004\4004 ";

                if (company == "CEI")
                {
                    if (Purpose == "MCert")
                    {
                        odb2 = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                                  @"""where (sn = 618068 or sn = 618072 or sn = 618074) "" &" + Environment.NewLine;
                    }
                    else
                    {
                        odb2 = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                               @"""where (sn != 618067 and sn != 618072 and sn != 618074) "" &" + Environment.NewLine;
                    }


                    odb4 = @"""and [board type] = 'zmi 4004' and [test station] = 'zmi-test-1'""." + Environment.NewLine +
                               @"Sort c1 c2 c3 c4 c5 c6 c1 c2 c3 c4 c5 c6;" + Environment.NewLine +
                               @"by c3." + Environment.NewLine +
                               @"fdate/time c3;" + Environment.NewLine +
                               @"format(DTm/d/yy)." + Environment.NewLine +
                               @"count c1." + Environment.NewLine;
                }
                else
                {
                    if (Purpose == "MCert")
                    {
                        odb2 = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                                  @"""where (sn = 7151655 or sn = 7171748 or sn = 7171756) "" &" + Environment.NewLine;
                    }
                    else
                    {
                        odb2 = @"""from productioncontrol.dbo.[test data] "" &" + Environment.NewLine +
                                      @"""where (sn != 7151655 and sn != 7171748 and sn != 7171756) "" &" + Environment.NewLine;
                    }
                    //minitab is quite finnekey - command line length limited and need to have the right number of quotes
                    //  "" &" for line contination.  Not sure why some lines need three quotes to begin.
                    odb4 = @"""and [board type] = 'zmi 4004' and "" &" + Environment.NewLine +
                              @"""([test station] = 'ZMI-4K-ITS' or [test station] = 'zmi-4k-its')""." + Environment.NewLine +
                              @"Sort c1 c2 c3 c4 c5 c6 c1 c2 c3 c4 c5 c6;" + Environment.NewLine +
                              @"by c3." + Environment.NewLine +
                              @"fdate/time c3;" + Environment.NewLine +
                              @"format(DTm/d/yy)." + Environment.NewLine +
                              @"Count c1." + Environment.NewLine;
                }
                test[5] = "AD +5V Digital PS Ripple";

                graph[5] = @"Reference 2 0;" + Environment.NewLine +
                           @"Label ""LSpec=0"";" + Environment.NewLine +
                           @"Reference 2 0.05;" + Environment.NewLine +
                           @"Label ""USpec=0.05"";" + Environment.NewLine;

                test[6] = "AD +5V Digital PS";

                graph[6] = @"Reference 2 4.75;" + Environment.NewLine +
                           @"Label ""LSpec=4.75"";" + Environment.NewLine +
                           @"Reference 2 5.25;" + Environment.NewLine +
                           @"Label ""USpec=5.25"";" + Environment.NewLine;

                test[7] = "DA Age DAU1";

                graph[7] = @"Reference 2 1657;" + Environment.NewLine +
                           @"Label ""LSpec=1657"";" + Environment.NewLine +
                           @"Reference 2 1723;" + Environment.NewLine +
                           @"Label ""USpec=1723"";" + Environment.NewLine;

                test[8] = "DA Age DAU2";

                graph[8] = @"Reference 2 1657;" + Environment.NewLine +
                           @"Label ""LSpec=1657"";" + Environment.NewLine +
                           @"Reference 2 1723;" + Environment.NewLine +
                           @"Label ""USpec=1723"";" + Environment.NewLine;

                test[9] = "DA Age DAU3";

                graph[9] = @"Reference 2 1657;" + Environment.NewLine +
                           @"Label ""LSpec=1657"";" + Environment.NewLine +
                           @"Reference 2 1723;" + Environment.NewLine +
                           @"Label ""USpec=1723"";" + Environment.NewLine;

                test[10] = "DA Age DAU4";

                graph[10] = @"Reference 2 1657;" + Environment.NewLine +
                           @"Label ""LSpec=1657"";" + Environment.NewLine +
                           @"Reference 2 1723;" + Environment.NewLine +
                           @"Label ""USpec=1723"";" + Environment.NewLine;

                test[11] = "DA RfDelay DAU1";

                graph[11] = @"Reference 2 50;" + Environment.NewLine +
                            @"Label ""LSpec=50"";" + Environment.NewLine +
                            @"Reference 2 70;" + Environment.NewLine +
                            @"Label ""USpec=70"";" + Environment.NewLine;

                test[12] = "DA RfDelay DAU2";

                graph[12] = @"Reference 2 50;" + Environment.NewLine +
                            @"Label ""LSpec=50"";" + Environment.NewLine +
                            @"Reference 2 70;" + Environment.NewLine +
                            @"Label ""USpec=70"";" + Environment.NewLine;

                test[13] = "DNAC 3.88 SSI Average Ax1";

                graph[13] = "";

                test[14] = "DNAC 30.01 SSI Average Ax1";

                graph[14] = "";

                test[15] = "DNAC 36.12 SSI Average Ax1";

                graph[15] = "";

                test[16] = "DNAC 3.88 Std Dev Ax1";

                graph[16] = DNAClimits;

                test[17] = "DNAC 30.01 Std Dev Ax1";

                graph[17] = DNAClimits;

                test[18] = "DNAC 36.12 Std Dev Ax1";

                graph[18] = DNAClimits;

                test[19] = "DNAC 3.88 SSI Average Ax2";

                graph[19] = "";

                test[20] = "DNAC 30.01 SSI Average Ax2";

                graph[20] = "";

                test[21] = "DNAC 36.12 SSI Average Ax2";

                graph[21] = "";

                test[22] = "DNAC 3.88 Std Dev Ax2";

                graph[22] = DNAClimits;

                test[23] = "DNAC 30.01 Std Dev Ax2";

                graph[23] = DNAClimits;

                test[24] = "DNAC 36.12 Std Dev Ax2";

                graph[24] = DNAClimits;

                test[25] = "DNAC 3.88 SSI Average Ax3";

                graph[25] = "";

                test[26] = "DNAC 30.01 SSI Average Ax3";

                graph[26] = "";

                test[27] = "DNAC 36.12 SSI Average Ax3";

                graph[27] = "";

                test[28] = "DNAC 3.88 Std Dev Ax3";

                graph[28] = DNAClimits;

                test[29] = "DNAC 30.01 Std Dev Ax3";

                graph[29] = DNAClimits;

                test[30] = "DNAC 36.12 Std Dev Ax3";

                graph[30] = DNAClimits;

                test[31] = "DNAC 3.88 SSI Average Ax4";

                graph[31] = "";

                test[32] = "DNAC 30.01 SSI Average Ax4";

                graph[32] = "";

                test[33] = "DNAC 36.12 SSI Average Ax4";

                graph[33] = "";

                test[34] = "DNAC 3.88 Std Dev Ax4";

                graph[34] = DNAClimits;

                test[35] = "DNAC 30.01 Std Dev Ax4";

                graph[35] = DNAClimits;

                test[36] = "DNAC 36.12 Std Dev Ax4";

                graph[36] = DNAClimits;

                test[37] = "Lin 10 MeasPower Ax1";

                graph[37] = "";

                test[38] = "Lin 1 MeasPower Ax1";

                graph[38] = "";

                test[39] = "Lin 60 MeasPower Ax1";

                graph[39] = "";

                test[40] = "Lin 10 RMS Error Ax1";

                graph[40] = LINlimits;

                test[41] = "Lin 1 RMS Error Ax1";

                graph[41] = LINlimits;

                test[42] = "Lin 60 RMS Error Ax1";

                graph[42] = LINlimits;

                test[43] = "Lin 10 SSI Avg Ax1";

                graph[43] = "";

                test[44] = "Lin 1 SSI Avg Ax1";

                graph[44] = "";

                test[45] = "Lin 60 SSI Avg Ax1";

                graph[45] = "";

                test[46] = "Lin 10 MeasPower Ax2";

                graph[46] = "";

                test[47] = "Lin 1 MeasPower Ax2";

                graph[47] = "";

                test[48] = "Lin 60 MeasPower Ax2";

                graph[48] = "";

                test[49] = "Lin 10 RMS Error Ax2";

                graph[49] = LINlimits;

                test[50] = "Lin 1 RMS Error Ax2";

                graph[50] = LINlimits;

                test[51] = "Lin 60 RMS Error Ax2";

                graph[51] = LINlimits;

                test[52] = "Lin 10 SSI Avg Ax2";

                graph[52] = "";

                test[53] = "Lin 1 SSI Avg Ax2";

                graph[53] = "";

                test[54] = "Lin 60 SSI Avg Ax2";

                graph[54] = "";

                test[55] = "Lin 10 MeasPower Ax3";

                graph[55] = "";

                test[56] = "Lin 1 MeasPower Ax3";

                graph[56] = "";

                test[57] = "Lin 60 MeasPower Ax3";

                graph[57] = "";

                test[58] = "Lin 10 RMS Error Ax3";

                graph[58] = LINlimits;

                test[59] = "Lin 1 RMS Error Ax3";

                graph[59] = LINlimits;

                test[60] = "Lin 60 RMS Error Ax3";

                graph[60] = LINlimits;

                test[61] = "Lin 10 SSI Avg Ax3";

                graph[61] = "";

                test[62] = "Lin 1 SSI Avg Ax3";

                graph[62] = "";

                test[63] = "Lin 60 SSI Avg Ax3";

                graph[63] = "";

                test[64] = "Lin 10 MeasPower Ax4";

                graph[64] = "";

                test[65] = "Lin 1 MeasPower Ax4";

                graph[65] = "";

                test[66] = "Lin 60 MeasPower Ax4";

                graph[66] = "";

                test[67] = "Lin 10 RMS Error Ax4";

                graph[67] = LINlimits;


                test[68] = "Lin 1 RMS Error Ax4";

                graph[68] = LINlimits;

                test[69] = "Lin 60 RMS Error Ax4";

                graph[69] = LINlimits;

                test[70] = "Lin 10 SSI Avg Ax4";

                graph[70] = "";

                test[71] = "Lin 1 SSI Avg Ax4";

                graph[71] = "";

                test[72] = "Lin 60 SSI Avg Ax4";

                graph[72] = "";

                test[73] = "SSI CAL 138 FiberPwrMeas Ax1";
                graph[73] = "";

                test[74] = "SSI CAL 138 SSI Avg Ax1";
                graph[74] = "";

                test[75] = "SSI CAL 60 FiberPwrMeas Ax1";
                graph[75] = "";

                test[76] = "SSI CAL 60 SSI Avg Ax1";
                graph[76] = "";

                test[77] = "SSI CAL 1 FiberPwrMeas Ax1";
                graph[77] = "";

                test[78] = "SSI CAL 1 SSI Avg Ax1";
                graph[78] = "";

                test[79] = "SSI CAL 138 FiberPwrMeas Ax2";
                graph[79] = "";

                test[80] = "SSI CAL 138 SSI Avg Ax2";
                graph[80] = "";

                test[81] = "SSI CAL 60 FiberPwrMeas Ax2";
                graph[81] = "";

                test[82] = "SSI CAL 60 SSI Avg Ax2";
                graph[82] = "";

                test[83] = "SSI CAL 1 FiberPwrMeas Ax2";
                graph[83] = "";

                test[84] = "SSI CAL 1 SSI Avg Ax2";
                graph[84] = "";

                test[85] = "SSI CAL 138 FiberPwrMeas Ax3";
                graph[85] = "";

                test[86] = "SSI CAL 138 SSI Avg Ax3";
                graph[86] = "";

                test[87] = "SSI CAL 60 FiberPwrMeas Ax3";
                graph[87] = "";

                test[88] = "SSI CAL 60 SSI Avg Ax3";
                graph[88] = "";

                test[89] = "SSI CAL 1 FiberPwrMeas Ax3";
                graph[89] = "";

                test[90] = "SSI CAL 1 SSI Avg Ax3";
                graph[90] = "";

                test[91] = "SSI CAL 138 FiberPwrMeas Ax4";
                graph[91] = "";

                test[92] = "SSI CAL 138 SSI Avg Ax4";
                graph[92] = "";

                test[93] = "SSI CAL 60 FiberPwrMeas Ax4";
                graph[93] = "";

                test[94] = "SSI CAL 60 SSI Avg Ax4";
                graph[94] = "";

                test[95] = "SSI CAL 1 FiberPwrMeas Ax4";
                graph[95] = "";

                test[96] = "SSI CAL 1 SSI Avg Ax4";
                graph[96] = "";

                test[97] = "SSI CAL 1 SSI Avg Ax4";

                graph[97] = "Worksheet;" + Environment.NewLine +
                            "Current;" + Environment.NewLine +
                            "Close.";

                Mtb.Application Mtap = new Mtb.Application();
                Mtb.Project Mtab = Mtap.ActiveProject;
                Mtb.UserInterface mtbUI = Mtap.UserInterface;
                mtbUI.Visible = true;
                mtbUI.DisplayAlerts = false;

                File.WriteAllText(savePath.Substring(7) + " Failure Report.txt", "Failure Report" +
                    Environment.NewLine + Environment.NewLine);
                /*    
                File.WriteAllText(savePath.Substring(6) + " Failure Report.txt", "Failure Report" +
                    Environment.NewLine + Environment.NewLine);*/

                int i = 5;      // i = number of graphs

                // do while the number of graphs is less than one more than the number of graphs


                while (i < 97)
                {
                    string firstCommand = odb1 +
                           @"""[" + test[i] + @"] "" & " + Environment.NewLine +
                           odb2 +
                           @"""and [" + test[i] + @"] is not null "" & " + Environment.NewLine +
                           odb4;


                    Mtab.ExecuteCommand(firstCommand, Type.Missing);


                    string mTabCountString = Mtab.Commands.OutputDocument.Text;
                    char[] anyof = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
                    int findex = mTabCountString.IndexOfAny(anyof);

                    int lindex = mTabCountString.LastIndexOfAny(anyof);
                    string reading = mTabCountString.Substring(findex, (lindex - findex) + 1);
                    readings = Convert.ToInt32(reading);

                    int tikCalc = readings / 5;
                    int tik2 = 2 * tikCalc;
                    int tik3 = 3 * tikCalc;
                    int tik4 = 4 * tikCalc;
                    int tik5 = 5 * tikCalc;
                    ticks = "tick " +
                        tikCalc.ToString() + " " +
                        tik2.ToString() + " " +
                        tik3.ToString() + " " +
                        tik4.ToString() + " " +
                        tik5.ToString();

                    //get board and run from minitab

                    object xx = Mtab.ActiveWorksheet.Columns.Item("sn").GetData(1, readings);
                    object xy = Mtab.ActiveWorksheet.Columns.Item("iteration").GetData(1, readings);

                    double[] xx2 = (double[])xx;
                    string[] temp = Array.ConvertAll(xx2, new Converter<double, string>(double2string));
                    string[] xy2 = (string[])xy;
                    string station;
                    if (company == "Zygo")
                    {
                        station = ".ZMI-4K-ITS.";
                    }
                    else
                    {
                        station = ".ZMI-TEST-1.";
                    }

                    //combine board and run into one array
                    int b = 0;
                    while (b < readings)
                    {
                        if (temp[b].Length == 6)
                        {
                            temp[b] = "00" + temp[b];
                        }
                        if (temp[b].Length == 7)
                        {
                            temp[b] = "0" + temp[b];
                        }

                        runs[b] = "CE." + temp[b] + station + xy2[b];
                        b++;
                    }

                    Mtab.Commands.Delete();

                    if (Purpose == "Production")
                    {
                        graph[i] = @"plot '" + test[i] + @"' * 'test date';" + Environment.NewLine +
                        @"Title ""Engineering 4004"";" + Environment.NewLine +
                        @"Title ""Scatterplot of " + test[i] + @""";" + Environment.NewLine +
                        "Symbol 'SN';" + Environment.NewLine +
                        "nolegend;" + Environment.NewLine + graph[i];
                    }
                    else
                    {
                        graph[i] = @"plot '" + test[i] + @"' * 'test date';" + Environment.NewLine +
                         @"Title ""Engineering 4004"";" + Environment.NewLine +
                         @"Title ""Scatterplot of " + test[i] + @""";" + Environment.NewLine +
                         "Connect 'SN';" + Environment.NewLine +
                         "Symbol 'SN';" + Environment.NewLine + graph[i];
                    }



                    graph[i] = graph[i] + savePath + @"Eng " + test[i] + @""";" + Environment.NewLine +
                        gClose +
                        @"Ichart '" + test[i] + "' ;" + Environment.NewLine +
                        "Exclude;" + Environment.NewLine +
                        @"Where ""'ITS Build Number' < 600"";" + Environment.NewLine +
                        "Test 1 2 3 4 5 6 7 8;" + Environment.NewLine +
                        "Scale 1;" + Environment.NewLine +
                        ticks + Environment.NewLine +
                        @"Title ""Quality 4004"";" + Environment.NewLine +
                        "Title;" + Environment.NewLine +
                        @"Stamp 'Test Date' ;" + Environment.NewLine +
                        savePath + @"Qual " + test[i] + @""";" + Environment.NewLine +
                        gClose +
                        wClose;

                    Mtab.ExecuteCommand(graph[i], Type.Missing);

                    string x = Mtab.Commands.OutputDocument.Text;

                    if (x.IndexOf("Test Failed") > -1)
                    {
                        File.AppendAllText(savePath.Substring(7) + " Failure Report.txt", log + "  " + company +
                                "  " + boardType + "  test " + test[i] + " failed" + Environment.NewLine);

                        File.AppendAllText(savePath.Substring(7) + " Failure Report.txt", x + Environment.NewLine);

                        int start = 0;
                        int end = x.IndexOf("Excluding");

                        while ((start = x.IndexOf("TEST", start)) != -1)
                        {
                            // identify location of next test
                            int pointStop = x.IndexOf("TEST", start + 1);
                            // if no next test stop at end
                            if (pointStop == -1)
                            {
                                pointStop = end;
                            }
                            // find location of point data
                            int pointStart = x.IndexOf(":", start);
                            int digits = 0;
                            while (((pointStart = x.IndexOfAny(anyof, pointStart)) != -1) && pointStart < pointStop)
                            {
                                int digitPlace = pointStart;
                                int comma = x.IndexOf(",", digitPlace, pointStop - digitPlace);
                                if (comma == -1)
                                {
                                    comma = pointStop;
                                }
                                while (((digitPlace = x.IndexOfAny(anyof, digitPlace)) != -1) && digitPlace < comma)
                                {
                                    digitPlace += 1;
                                    digits++;
                                }

                                // record test number
                                failureLog[failLogIndex, 0] = x.Substring(start, 6);

                                failureLog[failLogIndex, 1] = x.Substring(pointStart, digits);

                                int find = Convert.ToInt32(x.Substring(pointStart, digits));
                                failureLog[failLogIndex, 2] = runs[find - 1];

                                File.AppendAllText(savePath.Substring(7) + " Failure Report.txt",
                                    failureLog[failLogIndex, 0] + "  " +
                                    failureLog[failLogIndex, 1] + "  " +
                                    failureLog[failLogIndex, 2] + Environment.NewLine);

                                cmd = new SqlCommand
                                    ("Insert into [failure log] (" +
                                     "company, " +
                                     "board, " +
                                     "[board test], " +
                                     "[xml file], " +
                                     "[minitab test]) values ('" +
                                     company + "','" +
                                     boardType + "','" +
                                     test[i] + "','" +
                                     failureLog[failLogIndex, 2] + "','" +
                                     failureLog[failLogIndex, 0] + "')", cnxn);
                                cnxn.Open();
                                cmd.ExecuteNonQuery();
                                cnxn.Close();
                                pointStart += digits;
                                failLogIndex += 1;
                                digits = 0;
                            }
                            start += 1;
                        }
                        File.AppendAllText(savePath.Substring(7) + " Failure Report.txt", Environment.NewLine);
                        int n = 0;
                        while (n < readings)
                        {
                            //File.AppendAllText(savePath.Substring(7) + " Failure Report.txt", n + 1 + ", " + xx2[n] +
                            //    "." + xy2[n] + Environment.NewLine);
                            File.AppendAllText(savePath.Substring(7) + " Failure Report.txt", n + 1 + ", " + runs[n] +
                            Environment.NewLine);
                            n++;
                        }
                        File.AppendAllText(savePath.Substring(7) + " Failure Report.txt", Environment.NewLine +
                            "****************************************" +
                            "****************************************" + Environment.NewLine);
                    }

                    Mtab.Commands.Delete();
                    i++;
                }
                Mtap.Quit();
                Mtap = null;
                foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName("mtb"))
                {
                    p.Kill();
                }
                Close();
            }
        }

        private string double2string(double x)
        {
            return x.ToString();
        }

        
    }
}