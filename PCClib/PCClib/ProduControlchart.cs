using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PCClib
{
    public class ProduControlchart
    {
        //private static string fileName;
        private static int SN;
        private static string Rev;
        private static string BoardType;
        private static string TestStation;
        private static int ITSbuildNumber;
        private static string Iteration;
        private static DateTime TestDate;
        private static int BoardPromVer;

        private static bool EPV = false;
        private static bool EPVx = false;
        private static bool EPVx1 = false;
        private static bool EPVx1x7 = false;
        private static bool EPVx1x1 = false;
        private static bool EPVx1x03 = false;

        private static double EPV_FiberPwrMeas_7_uW_Ax1;
        private static int EPV_AcDcOptPwrDiffL2_7_Ax1;
        private static int EPV_CalcProcGainL2_7_Ax1;

        private static double EPV_FiberPwrMeas_1_uW_Ax1;
        private static int EPV_AcDcOptPwrDiffL2_1_Ax1;
        private static int EPV_CalcProcGainL2_1_Ax1;

        private static double EPV_FiberPwrMeas_03_uW_Ax1;
        private static int EPV_AcDcOptPwrDiffL2_03_Ax1;
        private static int EPV_CalcProcGainL2_03_Ax1;


        private static bool EPVx2 = false;
        private static bool EPVx2x7 = false;
        private static bool EPVx2x1 = false;
        private static bool EPVx2x03 = false;

        private static double EPV_FiberPwrMeas_7_uW_Ax2;
        private static int EPV_AcDcOptPwrDiffL2_7_Ax2;
        private static int EPV_CalcProcGainL2_7_Ax2;

        private static double EPV_FiberPwrMeas_1_uW_Ax2;
        private static int EPV_AcDcOptPwrDiffL2_1_Ax2;
        private static int EPV_CalcProcGainL2_1_Ax2;

        private static double EPV_FiberPwrMeas_03_uW_Ax2;
        private static int EPV_AcDcOptPwrDiffL2_03_Ax2;
        private static int EPV_CalcProcGainL2_03_Ax2;


        private static bool EPVx3 = false;
        private static bool EPVx3x7 = false;
        private static bool EPVx3x1 = false;
        private static bool EPVx3x03 = false;

        private static double EPV_FiberPwrMeas_7_uW_Ax3;
        private static int EPV_AcDcOptPwrDiffL2_7_Ax3;
        private static int EPV_CalcProcGainL2_7_Ax3;

        private static double EPV_FiberPwrMeas_1_uW_Ax3;
        private static int EPV_AcDcOptPwrDiffL2_1_Ax3;
        private static int EPV_CalcProcGainL2_1_Ax3;

        private static double EPV_FiberPwrMeas_03_uW_Ax3;
        private static int EPV_AcDcOptPwrDiffL2_03_Ax3;
        private static int EPV_CalcProcGainL2_03_Ax3;


        private static bool EPVx4 = false;
        private static bool EPVx4x7 = false;
        private static bool EPVx4x1 = false;
        private static bool EPVx4x03 = false;

        private static double EPV_FiberPwrMeas_7_uW_Ax4;
        private static double EPV_AcDcOptPwrDiffL2_7_Ax4;
        private static double EPV_CalcProcGainL2_7_Ax4;

        private static double EPV_FiberPwrMeas_1_uW_Ax4;
        private static double EPV_AcDcOptPwrDiffL2_1_Ax4;
        private static double EPV_CalcProcGainL2_1_Ax4;

        private static double EPV_FiberPwrMeas_03_uW_Ax4;
        private static double EPV_AcDcOptPwrDiffL2_03_Ax4;
        private static double EPV_CalcProcGainL2_03_Ax4;


        private static bool AD = false;
        private static bool ADdone = false;
        
        private static double AD5V_Digital_PS;
        private static double AD5V_Digital_PS_Ripple;
        private static string AD_Test_Result;

        private static bool DA = false;
        private static bool DAdone = false;
        private static bool DAmeasD = false;
        
        private static string DA_Test_Result;
        private static int DA_rfDelay_DAU1;
        private static int DA_rfDelay_DAU2;
        private static int DA_msDelay_DAU1;
        private static int DA_msDelay_DAU2;
        private static int DA_msDelay_DAU3;
        private static int DA_msDelay_DAU4;

        private static bool DNAC = false;
        private static bool DNACdone = false;
        private static bool DNACdnac = false;
        private static bool DNACdnacDone = false;
        private static bool DNACdnacHP = false;
        private static bool DNACdnacHPdone = false;
        private static string DNACdnac_Test_Result;
        private static string DNACdnacHP_Test_Result;

        private static bool DNACx1 = false;
        private static int DNAC_388_SSI_Average_Ax1;
        private static double DNAC_388_Std_Dev_Ax1;
        private static int DNAC_3001_SSI_Average_Ax1;
        private static double DNAC_3001_Std_Dev_Ax1;
        private static int DNAC_3612_SSI_Average_Ax1;
        private static double DNAC_3612_Std_Dev_Ax1;

        private static bool DNACx2 = false;
        private static int DNAC_388_SSI_Average_Ax2;
        private static double DNAC_388_Std_Dev_Ax2;
        private static int DNAC_3001_SSI_Average_Ax2;
        private static double DNAC_3001_Std_Dev_Ax2;
        private static int DNAC_3612_SSI_Average_Ax2;
        private static double DNAC_3612_Std_Dev_Ax2;

        private static bool DNACx3 = false;
        private static int DNAC_388_SSI_Average_Ax3;
        private static double DNAC_388_Std_Dev_Ax3;
        private static int DNAC_3001_SSI_Average_Ax3;
        private static double DNAC_3001_Std_Dev_Ax3;
        private static int DNAC_3612_SSI_Average_Ax3;
        private static double DNAC_3612_Std_Dev_Ax3;

        private static bool DNACx4 = false;
        private static int DNAC_388_SSI_Average_Ax4;
        private static double DNAC_388_Std_Dev_Ax4;
        private static int DNAC_3001_SSI_Average_Ax4;
        private static double DNAC_3001_Std_Dev_Ax4;
        private static int DNAC_3612_SSI_Average_Ax4;
        private static double DNAC_3612_Std_Dev_Ax4;


        private static bool DNAChpx1 = false;
        private static double DNAChp_388_Std_Dev_Ax1;
        private static double DNAChp_3001_Std_Dev_Ax1;
        private static double DNAChp_3612_Std_Dev_Ax1;

        private static bool DNAChpx2 = false;
        private static double DNAChp_388_Std_Dev_Ax2;
        private static double DNAChp_3001_Std_Dev_Ax2;
        private static double DNAChp_3612_Std_Dev_Ax2;

        private static bool DNAChpx3 = false;
        private static double DNAChp_388_Std_Dev_Ax3;
        private static double DNAChp_3001_Std_Dev_Ax3;
        private static double DNAChp_3612_Std_Dev_Ax3;

        private static bool DNAChpx4 = false;
        private static double DNAChp_388_Std_Dev_Ax4;
        private static double DNAChp_3001_Std_Dev_Ax4;
        private static double DNAChp_3612_Std_Dev_Ax4;

        private static bool LIN = false;
        private static bool LINdone = false;

        private static bool LL = false;
        private static bool LLdone = false;
        private static string LL_Test_Result;

        private static bool LINx1 = false;
        private static double LIN_60_MeasPower_Ax1;
        private static int LIN_60_SSI_Average_Ax1;
        private static double LIN_60_Rms_Error_Ax1;
        private static double LIN_10_MeasPower_Ax1;
        private static int LIN_10_SSI_Average_Ax1;
        private static double LIN_10_Rms_Error_Ax1;
        private static double LIN_1_MeasPower_Ax1;
        private static int LIN_1_SSI_Average_Ax1;
        private static double LIN_1_Rms_Error_Ax1;
        private static double LIN_07_MeasPower_Ax1;
        private static int LIN_07_SSI_Average_Ax1;
        private static double LIN_07_Rms_Error_Ax1;

        private static bool LINx2 = false;
        private static double LIN_60_MeasPower_Ax2;
        private static int LIN_60_SSI_Average_Ax2;
        private static double LIN_60_Rms_Error_Ax2;
        private static double LIN_10_MeasPower_Ax2;
        private static int LIN_10_SSI_Average_Ax2;
        private static double LIN_10_Rms_Error_Ax2;
        private static double LIN_1_MeasPower_Ax2;
        private static int LIN_1_SSI_Average_Ax2;
        private static double LIN_1_Rms_Error_Ax2;
        private static double LIN_07_MeasPower_Ax2;
        private static int LIN_07_SSI_Average_Ax2;
        private static double LIN_07_Rms_Error_Ax2;

        private static bool LINx3 = false;
        private static double LIN_60_MeasPower_Ax3;
        private static int LIN_60_SSI_Average_Ax3;
        private static double LIN_60_Rms_Error_Ax3;
        private static double LIN_10_MeasPower_Ax3;
        private static int LIN_10_SSI_Average_Ax3;
        private static double LIN_10_Rms_Error_Ax3;
        private static double LIN_1_MeasPower_Ax3;
        private static int LIN_1_SSI_Average_Ax3;
        private static double LIN_1_Rms_Error_Ax3;
        private static double LIN_07_MeasPower_Ax3;
        private static int LIN_07_SSI_Average_Ax3;
        private static double LIN_07_Rms_Error_Ax3;

        private static bool LINx4 = false;
        private static double LIN_60_MeasPower_Ax4;
        private static int LIN_60_SSI_Average_Ax4;
        private static double LIN_60_Rms_Error_Ax4;
        private static double LIN_10_MeasPower_Ax4;
        private static int LIN_10_SSI_Average_Ax4;
        private static double LIN_10_Rms_Error_Ax4;
        private static double LIN_1_MeasPower_Ax4;
        private static int LIN_1_SSI_Average_Ax4;
        private static double LIN_1_Rms_Error_Ax4;
        private static double LIN_07_MeasPower_Ax4;
        private static int LIN_07_SSI_Average_Ax4;
        private static double LIN_07_Rms_Error_Ax4;

        private static bool LLhp = false;
        private static bool LLhpDone = false;
        private static string LLhp_Test_Result;

        private static double LLhp_2_Rms_Error_Ax1;
        private static double LLhp_2_Rms_Error_Ax2;
        private static double LLhp_2_Rms_Error_Ax3;
        private static double LLhp_2_Rms_Error_Ax4;
        
        private static bool SSI = false;
        private static bool SSIdone = false;

        private static bool SSIx1 = false;
        private static double SSI_1_MeasPower_Ax1;
        private static int SSI_1_SSI_Average_Ax1;
        private static double SSI_60_MeasPower_Ax1;
        private static int SSI_60_SSI_Average_Ax1;
        private static double SSI_138_MeasPower_Ax1;
        private static int SSI_138_SSI_Average_Ax1;

        private static bool SSIx2 = false;
        private static double SSI_1_MeasPower_Ax2;
        private static int SSI_1_SSI_Average_Ax2;
        private static double SSI_60_MeasPower_Ax2;
        private static int SSI_60_SSI_Average_Ax2;
        private static double SSI_138_MeasPower_Ax2;
        private static int SSI_138_SSI_Average_Ax2;

        private static bool SSIx3 = false;
        private static double SSI_1_MeasPower_Ax3;
        private static int SSI_1_SSI_Average_Ax3;
        private static double SSI_60_MeasPower_Ax3;
        private static int SSI_60_SSI_Average_Ax3;
        private static double SSI_138_MeasPower_Ax3;
        private static int SSI_138_SSI_Average_Ax3;

        private static bool SSIx4 = false;
        private static double SSI_1_MeasPower_Ax4;
        private static int SSI_1_SSI_Average_Ax4;
        private static double SSI_60_MeasPower_Ax4;
        private static int SSI_60_SSI_Average_Ax4;
        private static double SSI_138_MeasPower_Ax4;
        private static int SSI_138_SSI_Average_Ax4;
        
        private static bool DArf1 = false;
        private static bool DArf2 = false;
        private static bool DAms1 = false;
        private static bool DAms2 = false;
        private static bool DAms3 = false;
        private static bool DAms4 = false;

        private static bool DNACx1x = false;
        private static bool DNACx2x = false;
        private static bool DNACx3x = false;
        private static bool DNACx4x = false;

        private static bool LINx1x = false;
        private static bool LINx2x = false;
        private static bool LINx3x = false;
        private static bool LINx4x = false;

        private static bool SSIx1x = false;
        private static bool SSIx2x = false;
        private static bool SSIx3x = false;
        private static bool SSIx4x = false;

        
        //used as a flag for graphs - need to 
        //set field to null if no test
        private static bool LLhpx1x = false;
        private static bool LLhpx2x = false;
        private static bool LLhpx3x = false;
        private static bool LLhpx4x = false;


        //private static string s;
        private static int start;
        private static int length;

        private static string SqlError;
        private static string fileName;
        private static string is4K;

        //optional parameter Reason4Test

        public static string Input(string file, string Reason4Test = "Not Known")
        {
            int position = file.LastIndexOf('\\');

            if (position > 0)
            {
                //get file name short
                fileName = file.Substring(position + 1).ToUpper();

                if (fileName.Contains("ZMI-4K-ITS"))
                {
                    is4K = "YES";
                }



                // check to see if file already processed and in database
                SqlCommand cmd = new SqlCommand("Select [xml file name] from dbo.[test data] " +
                    "where [xml file name] = '" + fileName + "'");
                SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL11; user = ReadWrite; " +
                    "password = Read+Write!; database = productioncontrol;");
                cmd.Connection = cnxn;
                cnxn.Open();
                object o = cmd.ExecuteScalar();



                //need to set SqlError to empty string as it gets returned to Michael's program
                //and if the file is already in the database then all that gets returned is
                //this value.
                SqlError = "";

                //if file not in database then add
                if (o == null & is4K == "YES")
                    {
                    string[] readText = File.ReadAllLines(file);

                    /*
                    int x = readText[3].LastIndexOf("<");
                    TestDate = Convert.ToDateTime(readText[3].Substring(11, (x - 11)).Trim());
                    */

                    foreach (string s in readText)
                    {
                        if (s.Length > 30 && s.Substring(3, 9) == "BoardInfo")
                        {
                            processLine("SN=", "Ven", s);
                            SN = Convert.ToInt32(s.Substring(start, length - 1));
                            if (s.IndexOf("KitVersion") == -1)
                            {
                                processLine("Type=", "AssyNum", s);
                            }
                            else
                            {
                                processLine("Type=", "KitVersion", s);
                            }
                            BoardType = s.Substring(start, length - 1);
                            //Minitab needs all the 4104s to be the same board type
                            //so I remove the E from the 4104E.
                            if (BoardType.Length == 9)
                            {
                                BoardType = BoardType.Substring(0, 8);
                            }
                            if (BoardType.Substring(4, 1) != "4")
                            {
                                break;
                            }
                            processLine("BoardAssyRev=", "PromRev", s);
                            Rev = s.Substring(start, length - 1).Trim();

                            processLine("AppBuild=", "StartupDir", s);
                            ITSbuildNumber = Convert.ToInt32(s.Substring(start, length - 1));
                            processLine("Machine=", "CmdLine", s);
                            TestStation = s.Substring(start, length - 1);
                            int find = s.LastIndexOf(".xml");
                            if (s.Substring((find - 1), 1) == "C")
                            {
                                int step1 = s.LastIndexOf("ZMI-TEST");

                                if (step1 > 0)
                                {
                                    Iteration = s.Substring(find - (find - (step1 + 11)),
                                        (find - (step1 + 11)));
                                }
                                else
                                {
                                    step1 = s.LastIndexOf("ZMI-4K");
                                    Iteration = s.Substring(find - (find - (step1 + 11)),
                                    (find - (step1 + 11)));
                                }
                            }
                            else
                            {
                                Iteration = s.Substring(find - 5, 5);
                            }

                            processLine("PromVer=", "YOM", s);
                            if (s.IndexOf("YOM") - s.IndexOf("PromVer=") == 17)
                            {
                                BoardPromVer = Convert.ToInt32(s.Substring(start + 2, 4));
                            }
                            if (s.IndexOf("YOM") - s.IndexOf("PromVer=") == 15)
                            {
                                BoardPromVer = Convert.ToInt32(s.Substring(start, 4));
                            }
                        }

                        if (ADdone == false && AD == false && s.Length > 30)
                        {
                            if (s.Substring(3, 14) == @"Test name=""AD""")
                            {
                                AD = true;
                                continue;
                            }
                        }

                        if (ADdone == false && AD == true && s.Length > 30)
                        {
                            if (s.TrimStart().Substring(0, 7) == @"<Start>")
                            {
                                processLine("<Start>", "</Start>", s);
                                TestDate = Convert.ToDateTime(s.Substring(start - 1, length));
                                continue;
                            }
                        }

                        if (ADdone == false && AD == true && s.Length > 130)
                        {
                            if (s.Substring(42, 11) == "+5V Digital")
                            {
                                processLine("value=", "high", s);
                                AD5V_Digital_PS = Convert.ToDouble(s.Substring(start, length - 1));
                                processLine("ripple=", "status", s);
                                AD5V_Digital_PS_Ripple = Convert.ToDouble(s.Substring(start, length - 1));
                                processLine("Result=", "/>", s);
                                AD_Test_Result = s.Substring(start, length - 1);
                                ADdone = true;
                                continue;
                            }
                        }

                        if (DAdone == false && DA == false && s.Length > 30)
                        {
                            if (s.Substring(3, 19) == @"Test name=""DataAge""")
                            {
                                DA = true;
                                continue;
                            }
                        }

                        if (DAdone == false && DA == true && s.Length > 20)
                        {
                            if (s.Substring(7, 11) == @"Step id=""1""")
                            {
                                processLine("RefDelayDAU=", "EepromResult", s);
                                DA_rfDelay_DAU1 = Convert.ToInt32(s.Substring(start, length - 1));
                                DArf1 = true;
                                continue;
                            }
                            if (s.Substring(7, 11) == @"Step id=""2""")
                            {
                                processLine("RefDelayDAU=", "EepromResult", s);
                                DA_rfDelay_DAU2 = Convert.ToInt32(s.Substring(start, length - 1));
                                DArf2 = true;
                                continue;
                            }

                            if (s.Length > 33)
                            {
                                if (s.Substring(19, 13) == @"Measure Delay")
                                {
                                    DAmeasD = true;
                                    continue;
                                }
                            }
                            if (DAmeasD == true && s.Length > 40)
                            {
                                if (s.Substring(7, 24) == @"Axis id=""1"" APDSerialNum")
                                {
                                    processLine("DataAgeDAU=", "EepromResult", s);
                                    DA_msDelay_DAU1 = Convert.ToInt32(s.Substring(start, length - 1));
                                    DAms1 = true;
                                    continue;
                                }

                                if (s.Substring(7, 24) == @"Axis id=""2"" APDSerialNum")
                                {
                                    processLine("DataAgeDAU=", "EepromResult", s);
                                    DA_msDelay_DAU2 = Convert.ToInt32(s.Substring(start, length - 1));
                                    DAms2 = true;
                                    continue;
                                }

                                if (s.Substring(7, 24) == @"Axis id=""3"" APDSerialNum")
                                {
                                    processLine("DataAgeDAU=", "EepromResult", s);
                                    DA_msDelay_DAU3 = Convert.ToInt32(s.Substring(start, length - 1));
                                    DAms3 = true;
                                    continue;
                                }

                                if (s.Substring(7, 24) == @"Axis id=""4"" APDSerialNum")
                                {
                                    processLine("DataAgeDAU=", "EepromResult", s);
                                    DA_msDelay_DAU4 = Convert.ToInt32(s.Substring(start, length - 1));
                                    DAms4 = true;
                                    continue;
                                }
                            }

                            if (s.Substring(4, 7) == "<Result")
                            {
                                processLine("<Result>", "</Result>", s);
                                DA_Test_Result = s.Substring(start - 1, length + 2);
                                DAdone = true;
                                continue;
                            }

                        }

                        if (DNACdone == false && DNAC == false && s.Length > 30)
                        {
                            if (s.Substring(3, 26) == @"Test name=""DynamicAccuracy")
                            {
                                DNAC = true;
                                continue;
                            }
                        }

                        if (DNACdnacDone == false && DNAC == true && s.Length > 36)
                        {
                            if (s.Substring(5, 31) == @"Subtest name=""Dynamic Accuracy""")
                            {
                                DNACdnac = true;
                                continue;
                            }
                        }

                        if (DNACdnacDone == false && DNACdnac == true)
                        {
                            if (DNACx1 == false && s.Length > 17)
                            {
                                if (s.Substring(7, 10) == @"Axis id=""1")
                                {
                                    DNACx1 = true;
                                    continue;
                                }
                            }

                            if (DNACx1 == true && s.Length > 26)
                            {
                                if (s.Substring(9, 17) == @"Trial FTest=""3880")
                                {
                                    processLine("SSIAverage=", "stdDev=", s);
                                    DNAC_388_SSI_Average_Ax1 = Convert.ToInt32(s.Substring(start, length - 1));
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAC_388_Std_Dev_Ax1 = Convert.ToDouble(s.Substring(start, length - 1));
                                }

                                if (s.Substring(9, 17) == @"Trial FTest=""3001")
                                {
                                    processLine("SSIAverage=", "stdDev=", s);
                                    DNAC_3001_SSI_Average_Ax1 = Convert.ToInt32(s.Substring(start, length - 1));
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAC_3001_Std_Dev_Ax1 = Convert.ToDouble(s.Substring(start, length - 1));
                                }

                                if (s.Substring(9, 17) == @"Trial FTest=""3612")
                                {
                                    processLine("SSIAverage=", "stdDev=", s);
                                    DNAC_3612_SSI_Average_Ax1 = Convert.ToInt32(s.Substring(start, length - 1));
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAC_3612_Std_Dev_Ax1 = Convert.ToDouble(s.Substring(start, length - 1));
                                    DNACx1 = false;
                                    DNACx1x = true;
                                    continue;
                                }
                            }

                            if (DNACx2 == false && s.Length > 17)
                            {
                                if (s.Substring(7, 10) == @"Axis id=""2")
                                {
                                    DNACx2 = true;
                                    continue;
                                }
                            }

                            if (DNACx2 == true && s.Length > 26)
                            {
                                if (s.Substring(9, 17) == @"Trial FTest=""3880")
                                {
                                    processLine("SSIAverage=", "stdDev=", s);
                                    DNAC_388_SSI_Average_Ax2 = Convert.ToInt32(s.Substring(start, length - 1));
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAC_388_Std_Dev_Ax2 = Convert.ToDouble(s.Substring(start, length - 1));
                                }

                                if (s.Substring(9, 17) == @"Trial FTest=""3001")
                                {
                                    processLine("SSIAverage=", "stdDev=", s);
                                    DNAC_3001_SSI_Average_Ax2 = Convert.ToInt32(s.Substring(start, length - 1));
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAC_3001_Std_Dev_Ax2 = Convert.ToDouble(s.Substring(start, length - 1));
                                }

                                if (s.Substring(9, 17) == @"Trial FTest=""3612")
                                {
                                    processLine("SSIAverage=", "stdDev=", s);
                                    DNAC_3612_SSI_Average_Ax2 = Convert.ToInt32(s.Substring(start, length - 1));
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAC_3612_Std_Dev_Ax2 = Convert.ToDouble(s.Substring(start, length - 1));
                                    DNACx2 = false;
                                    DNACx2x = true;
                                    continue;
                                }
                            }

                            if (DNACx3 == false && s.Length > 17)
                            {
                                if (s.Substring(7, 10) == @"Axis id=""3")
                                {
                                    DNACx3 = true;
                                    continue;
                                }
                            }

                            if (DNACx3 == true && s.Length > 26)
                            {
                                if (s.Substring(9, 17) == @"Trial FTest=""3880")
                                {
                                    processLine("SSIAverage=", "stdDev=", s);
                                    DNAC_388_SSI_Average_Ax3 = Convert.ToInt32(s.Substring(start, length - 1));
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAC_388_Std_Dev_Ax3 = Convert.ToDouble(s.Substring(start, length - 1));
                                }

                                if (s.Substring(9, 17) == @"Trial FTest=""3001")
                                {
                                    processLine("SSIAverage=", "stdDev=", s);
                                    DNAC_3001_SSI_Average_Ax3 = Convert.ToInt32(s.Substring(start, length - 1));
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAC_3001_Std_Dev_Ax3 = Convert.ToDouble(s.Substring(start, length - 1));
                                }

                                if (s.Substring(9, 17) == @"Trial FTest=""3612")
                                {
                                    processLine("SSIAverage=", "stdDev=", s);
                                    DNAC_3612_SSI_Average_Ax3 = Convert.ToInt32(s.Substring(start, length - 1));
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAC_3612_Std_Dev_Ax3 = Convert.ToDouble(s.Substring(start, length - 1));
                                    DNACx3 = false;
                                    DNACx3x = true;
                                    continue;
                                }
                            }

                            if (DNACx4 == false && s.Length > 17)
                            {
                                if (s.Substring(7, 10) == @"Axis id=""4")
                                {
                                    DNACx4 = true;
                                    continue;
                                }
                            }

                            if (DNACx4 == true && s.Length > 26)
                            {
                                if (s.Substring(9, 17) == @"Trial FTest=""3880")
                                {
                                    processLine("SSIAverage=", "stdDev=", s);
                                    DNAC_388_SSI_Average_Ax4 = Convert.ToInt32(s.Substring(start, length - 1));
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAC_388_Std_Dev_Ax4 = Convert.ToDouble(s.Substring(start, length - 1));
                                }

                                if (s.Substring(9, 17) == @"Trial FTest=""3001")
                                {
                                    processLine("SSIAverage=", "stdDev=", s);
                                    DNAC_3001_SSI_Average_Ax4 = Convert.ToInt32(s.Substring(start, length - 1));
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAC_3001_Std_Dev_Ax4 = Convert.ToDouble(s.Substring(start, length - 1));
                                }

                                if (s.Substring(9, 17) == @"Trial FTest=""3612")
                                {
                                    processLine("SSIAverage=", "stdDev=", s);
                                    DNAC_3612_SSI_Average_Ax4 = Convert.ToInt32(s.Substring(start, length - 1));
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAC_3612_Std_Dev_Ax4 = Convert.ToDouble(s.Substring(start, length - 1));
                                    DNACx4 = false;
                                    DNACx4x = true;
                                    continue;
                                }
                            }

                            if (s.Length > 14 && s.Substring(7, 6) == "Result")
                            {
                                processLine("<Result>", "</Result>", s);
                                DNACdnac_Test_Result = s.Substring(start - 1, length + 2);
                                DNACdnacDone = true;
                                continue;
                            }
                        }



                        if (DNACdone == false && DNAC == true && s.Length > 41)
                        {
                            if (s.Substring(5, 36) == @"Subtest name=""Dynamic Accuracy (High")
                            {
                                DNACdnacHP = true;
                                continue;
                            }
                        }

                        if (DNACdnacHPdone == false && DNACdnacHP == true)
                        {
                            if (DNACx1 == false && s.Length > 17)
                            {
                                if (s.Substring(7, 10) == @"Axis id=""1")
                                {
                                    DNACx1 = true;
                                    continue;
                                }
                            }

                            if (DNACx1 == true && s.Length > 26)
                            {
                                if (s.Substring(9, 17) == @"Trial FTest=""3880")
                                {
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAChp_388_Std_Dev_Ax1 = Convert.ToDouble(s.Substring(start, length - 1));
                                }

                                if (s.Substring(9, 17) == @"Trial FTest=""3001")
                                {
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAChp_3001_Std_Dev_Ax1 = Convert.ToDouble(s.Substring(start, length - 1));
                                }

                                if (s.Substring(9, 17) == @"Trial FTest=""3612")
                                {
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAChp_3612_Std_Dev_Ax1 = Convert.ToDouble(s.Substring(start, length - 1));
                                    DNACx1 = false;
                                    DNAChpx1 = true;
                                    continue;
                                }
                            }

                            if (DNACx2 == false && s.Length > 17)
                            {
                                if (s.Substring(7, 10) == @"Axis id=""2")
                                {
                                    DNACx2 = true;
                                    continue;
                                }
                            }

                            if (DNACx2 == true && s.Length > 26)
                            {
                                if (s.Substring(9, 17) == @"Trial FTest=""3880")
                                {
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAChp_388_Std_Dev_Ax2 = Convert.ToDouble(s.Substring(start, length - 1));
                                }

                                if (s.Substring(9, 17) == @"Trial FTest=""3001")
                                {
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAChp_3001_Std_Dev_Ax2 = Convert.ToDouble(s.Substring(start, length - 1));
                                }

                                if (s.Substring(9, 17) == @"Trial FTest=""3612")
                                {
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAChp_3612_Std_Dev_Ax2 = Convert.ToDouble(s.Substring(start, length - 1));
                                    DNACx2 = false;
                                    DNAChpx2 = true;
                                    continue;
                                }
                            }

                            if (DNACx3 == false && s.Length > 17)
                            {
                                if (s.Substring(7, 10) == @"Axis id=""3")
                                {
                                    DNACx3 = true;
                                    continue;
                                }
                            }

                            if (DNACx3 == true && s.Length > 26)
                            {
                                if (s.Substring(9, 17) == @"Trial FTest=""3880")
                                {
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAChp_388_Std_Dev_Ax3 = Convert.ToDouble(s.Substring(start, length - 1));
                                }

                                if (s.Substring(9, 17) == @"Trial FTest=""3001")
                                {
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAChp_3001_Std_Dev_Ax3 = Convert.ToDouble(s.Substring(start, length - 1));
                                }

                                if (s.Substring(9, 17) == @"Trial FTest=""3612")
                                {
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAChp_3612_Std_Dev_Ax3 = Convert.ToDouble(s.Substring(start, length - 1));
                                    DNACx3 = false;
                                    DNAChpx3 = true;
                                    continue;
                                }
                            }

                            if (DNACx4 == false && s.Length > 17)
                            {
                                if (s.Substring(7, 10) == @"Axis id=""4")
                                {
                                    DNACx4 = true;
                                    continue;
                                }
                            }

                            if (DNACx4 == true && s.Length > 26)
                            {
                                if (s.Substring(9, 17) == @"Trial FTest=""3880")
                                {
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAChp_388_Std_Dev_Ax4 = Convert.ToDouble(s.Substring(start, length - 1));
                                }

                                if (s.Substring(9, 17) == @"Trial FTest=""3001")
                                {
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAChp_3001_Std_Dev_Ax4 = Convert.ToDouble(s.Substring(start, length - 1));
                                }

                                if (s.Substring(9, 17) == @"Trial FTest=""3612")
                                {
                                    processLine("stdDev=", "stdDevLimit=", s);
                                    DNAChp_3612_Std_Dev_Ax4 = Convert.ToDouble(s.Substring(start, length - 1));
                                    DNACx4 = false;
                                    DNAChpx4 = true;
                                    continue;
                                }
                            }

                            if (s.Length > 14 && s.Substring(7, 6) == "Result")
                            {
                                processLine("<Result>", "</Result>", s);
                                DNACdnacHP_Test_Result = s.Substring(start - 1, length + 2);
                                DNACdnacHPdone = true;
                                DNACdone = true;
                                continue;
                            }

                        }

                        if (LINdone == false && LIN == false && s.Length > 30)
                        {
                            if (s.Substring(3, 20) == @"Test name=""Linearity")
                            {
                                LIN = true;
                                continue;
                            }
                        }

                        if (LINdone == false && LIN == true)
                        {

                            if (LLdone == false && LL == false && s.Length > 33)
                            {
                                if (s.Substring(5, 28) == @"Subtest name=""Linearity Long")
                                {
                                    LL = true;
                                    continue;
                                }
                            }

                            if (LLdone == false && LL == true)
                            {
                                if (LINx1 == false && s.Length > 17)
                                {
                                    if (s.Substring(7, 10) == @"Axis id=""1")
                                    {
                                        LINx1 = true;
                                        LINx1x = true;
                                        continue;
                                    }
                                }

                                if (LINx1 == true && s.Length > 32)
                                {
                                    if (s.Substring(9, 23) == @"Step setPower_uW=""60.00")
                                    {
                                        processLine("measPower_uW=", "ignoreNoise", s);
                                        LIN_60_MeasPower_Ax1 = Convert.ToDouble(s.Substring(start, length - 1));
                                        processLine("ssiAvg=", "calcPower", s);
                                        LIN_60_SSI_Average_Ax1 = Convert.ToInt32(s.Substring(start, length - 1));
                                        processLine("rmsError=", "dft1=", s);
                                        LIN_60_Rms_Error_Ax1 = Convert.ToDouble(s.Substring(start, length - 1));
                                        continue;
                                    }

                                    if (s.Substring(9, 23) == @"Step setPower_uW=""10.00")
                                    {
                                        processLine("measPower_uW=", "ignoreNoise", s);
                                        LIN_10_MeasPower_Ax1 = Convert.ToDouble(s.Substring(start, length - 1));
                                        processLine("ssiAvg=", "calcPower", s);
                                        LIN_10_SSI_Average_Ax1 = Convert.ToInt32(s.Substring(start, length - 1));
                                        processLine("rmsError=", "dft1=", s);
                                        LIN_10_Rms_Error_Ax1 = Convert.ToDouble(s.Substring(start, length - 1));
                                        continue;
                                    }


                                    if (s.Substring(9, 22) == @"Step setPower_uW=""1.00")
                                    {
                                        processLine("measPower_uW=", "ignoreNoise", s);
                                        LIN_1_MeasPower_Ax1 = Convert.ToDouble(s.Substring(start, length - 1));
                                        processLine("ssiAvg=", "calcPower", s);
                                        LIN_1_SSI_Average_Ax1 = Convert.ToInt32(s.Substring(start, length - 1));
                                        processLine("rmsError=", "dft1=", s);
                                        LIN_1_Rms_Error_Ax1 = Convert.ToDouble(s.Substring(start, length - 1));
                                        if (BoardType == "ZMI 4004")
                                        {
                                            LINx1 = false;
                                            LIN_07_MeasPower_Ax1 = 0;
                                            LIN_07_SSI_Average_Ax1 = 0;
                                            LIN_07_Rms_Error_Ax1 = 0;
                                        }
                                        continue;
                                    }


                                    if (s.Substring(9, 22) == @"Step setPower_uW=""0.07")
                                    {
                                        processLine("measPower_uW=", "ignoreNoise", s);
                                        LIN_07_MeasPower_Ax1 = Convert.ToDouble(s.Substring(start, length - 1));
                                        processLine("ssiAvg=", "calcPower", s);
                                        LIN_07_SSI_Average_Ax1 = Convert.ToInt32(s.Substring(start, length - 1));
                                        processLine("rmsError=", "dft1=", s);
                                        LIN_07_Rms_Error_Ax1 = Convert.ToDouble(s.Substring(start, length - 1));
                                        LINx1 = false;
                                        continue;
                                    }
                                }

                                if (LINx2 == false && s.Length > 17)
                                {
                                    if (s.Substring(7, 10) == @"Axis id=""2")
                                    {
                                        LINx2 = true;
                                        LINx2x = true;
                                        continue;
                                    }
                                }

                                if (LINx2 == true && s.Length > 32)
                                {
                                    if (s.Substring(9, 23) == @"Step setPower_uW=""60.00")
                                    {
                                        processLine("measPower_uW=", "ignoreNoise", s);
                                        LIN_60_MeasPower_Ax2 = Convert.ToDouble(s.Substring(start, length - 1));
                                        processLine("ssiAvg=", "calcPower", s);
                                        LIN_60_SSI_Average_Ax2 = Convert.ToInt32(s.Substring(start, length - 1));
                                        processLine("rmsError=", "dft1=", s);
                                        LIN_60_Rms_Error_Ax2 = Convert.ToDouble(s.Substring(start, length - 1));
                                        continue;
                                    }

                                    if (s.Substring(9, 23) == @"Step setPower_uW=""10.00")
                                    {
                                        processLine("measPower_uW=", "ignoreNoise", s);
                                        LIN_10_MeasPower_Ax2 = Convert.ToDouble(s.Substring(start, length - 1));
                                        processLine("ssiAvg=", "calcPower", s);
                                        LIN_10_SSI_Average_Ax2 = Convert.ToInt32(s.Substring(start, length - 1));
                                        processLine("rmsError=", "dft1=", s);
                                        LIN_10_Rms_Error_Ax2 = Convert.ToDouble(s.Substring(start, length - 1));
                                        continue;
                                    }

                                    if (s.Substring(9, 22) == @"Step setPower_uW=""1.00")
                                    {
                                        processLine("measPower_uW=", "ignoreNoise", s);
                                        LIN_1_MeasPower_Ax2 = Convert.ToDouble(s.Substring(start, length - 1));
                                        processLine("ssiAvg=", "calcPower", s);
                                        LIN_1_SSI_Average_Ax2 = Convert.ToInt32(s.Substring(start, length - 1));
                                        processLine("rmsError=", "dft1=", s);
                                        LIN_1_Rms_Error_Ax2 = Convert.ToDouble(s.Substring(start, length - 1));
                                        if (BoardType == "ZMI 4004")
                                        {
                                            LINx2 = false;
                                            LIN_07_MeasPower_Ax2 = 0;
                                            LIN_07_SSI_Average_Ax2 = 0;
                                            LIN_07_Rms_Error_Ax2 = 0;
                                        }
                                        continue;
                                    }

                                    if (s.Substring(9, 22) == @"Step setPower_uW=""0.07")
                                    {
                                        processLine("measPower_uW=", "ignoreNoise", s);
                                        LIN_07_MeasPower_Ax2 = Convert.ToDouble(s.Substring(start, length - 1));
                                        processLine("ssiAvg=", "calcPower", s);
                                        LIN_07_SSI_Average_Ax2 = Convert.ToInt32(s.Substring(start, length - 1));
                                        processLine("rmsError=", "dft1=", s);
                                        LIN_07_Rms_Error_Ax2 = Convert.ToDouble(s.Substring(start, length - 1));
                                        LINx2 = false;
                                        continue;
                                    }
                                }

                                if (LINx3 == false && s.Length > 17)
                                {
                                    if (s.Substring(7, 10) == @"Axis id=""3")
                                    {
                                        LINx3 = true;
                                        LINx3x = true;
                                        continue;
                                    }
                                }

                                if (LINx3 == true && s.Length > 32)
                                {
                                    if (s.Substring(9, 23) == @"Step setPower_uW=""60.00")
                                    {
                                        processLine("measPower_uW=", "ignoreNoise", s);
                                        LIN_60_MeasPower_Ax3 = Convert.ToDouble(s.Substring(start, length - 1));
                                        processLine("ssiAvg=", "calcPower", s);
                                        LIN_60_SSI_Average_Ax3 = Convert.ToInt32(s.Substring(start, length - 1));
                                        processLine("rmsError=", "dft1=", s);
                                        LIN_60_Rms_Error_Ax3 = Convert.ToDouble(s.Substring(start, length - 1));
                                        continue;
                                    }

                                    if (s.Substring(9, 23) == @"Step setPower_uW=""10.00")
                                    {
                                        processLine("measPower_uW=", "ignoreNoise", s);
                                        LIN_10_MeasPower_Ax3 = Convert.ToDouble(s.Substring(start, length - 1));
                                        processLine("ssiAvg=", "calcPower", s);
                                        LIN_10_SSI_Average_Ax3 = Convert.ToInt32(s.Substring(start, length - 1));
                                        processLine("rmsError=", "dft1=", s);
                                        LIN_10_Rms_Error_Ax3 = Convert.ToDouble(s.Substring(start, length - 1));
                                        continue;
                                    }

                                    if (s.Substring(9, 22) == @"Step setPower_uW=""1.00")
                                    {
                                        processLine("measPower_uW=", "ignoreNoise", s);
                                        LIN_1_MeasPower_Ax3 = Convert.ToDouble(s.Substring(start, length - 1));
                                        processLine("ssiAvg=", "calcPower", s);
                                        LIN_1_SSI_Average_Ax3 = Convert.ToInt32(s.Substring(start, length - 1));
                                        processLine("rmsError=", "dft1=", s);
                                        LIN_1_Rms_Error_Ax3 = Convert.ToDouble(s.Substring(start, length - 1));
                                        if (BoardType == "ZMI 4004")
                                        {
                                            LINx3 = false;
                                            LIN_07_MeasPower_Ax3 = 0;
                                            LIN_07_SSI_Average_Ax3 = 0;
                                            LIN_07_Rms_Error_Ax3 = 0;
                                        }
                                        continue;
                                    }

                                    if (s.Substring(9, 22) == @"Step setPower_uW=""0.07")
                                    {
                                        processLine("measPower_uW=", "ignoreNoise", s);
                                        LIN_07_MeasPower_Ax3 = Convert.ToDouble(s.Substring(start, length - 1));
                                        processLine("ssiAvg=", "calcPower", s);
                                        LIN_07_SSI_Average_Ax3 = Convert.ToInt32(s.Substring(start, length - 1));
                                        processLine("rmsError=", "dft1=", s);
                                        LIN_07_Rms_Error_Ax3 = Convert.ToDouble(s.Substring(start, length - 1));
                                        LINx3 = false;
                                        continue;
                                    }
                                }

                                if (LINx4 == false && s.Length > 17)
                                {
                                    if (s.Substring(7, 10) == @"Axis id=""4")
                                    {
                                        LINx4 = true;
                                        LINx4x = true;
                                        continue;
                                    }
                                }

                                if (LINx4 == true && s.Length > 32)
                                {
                                    if (s.Substring(9, 23) == @"Step setPower_uW=""60.00")
                                    {
                                        processLine("measPower_uW=", "ignoreNoise", s);
                                        LIN_60_MeasPower_Ax4 = Convert.ToDouble(s.Substring(start, length - 1));
                                        processLine("ssiAvg=", "calcPower", s);
                                        LIN_60_SSI_Average_Ax4 = Convert.ToInt32(s.Substring(start, length - 1));
                                        processLine("rmsError=", "dft1=", s);
                                        LIN_60_Rms_Error_Ax4 = Convert.ToDouble(s.Substring(start, length - 1));
                                        continue;
                                    }

                                    if (s.Substring(9, 23) == @"Step setPower_uW=""10.00")
                                    {
                                        processLine("measPower_uW=", "ignoreNoise", s);
                                        LIN_10_MeasPower_Ax4 = Convert.ToDouble(s.Substring(start, length - 1));
                                        processLine("ssiAvg=", "calcPower", s);
                                        LIN_10_SSI_Average_Ax4 = Convert.ToInt32(s.Substring(start, length - 1));
                                        processLine("rmsError=", "dft1=", s);
                                        LIN_10_Rms_Error_Ax4 = Convert.ToDouble(s.Substring(start, length - 1));
                                        continue;
                                    }

                                    if (s.Substring(9, 22) == @"Step setPower_uW=""1.00")
                                    {
                                        processLine("measPower_uW=", "ignoreNoise", s);
                                        LIN_1_MeasPower_Ax4 = Convert.ToDouble(s.Substring(start, length - 1));
                                        processLine("ssiAvg=", "calcPower", s);
                                        LIN_1_SSI_Average_Ax4 = Convert.ToInt32(s.Substring(start, length - 1));
                                        processLine("rmsError=", "dft1=", s);
                                        LIN_1_Rms_Error_Ax4 = Convert.ToDouble(s.Substring(start, length - 1));
                                        if (BoardType == "ZMI 4004")
                                        {
                                            LINx4 = false;
                                            LIN_07_MeasPower_Ax4 = 0;
                                            LIN_07_SSI_Average_Ax4 = 0;
                                            LIN_07_Rms_Error_Ax4 = 0;
                                        }
                                        continue;
                                    }

                                    if (s.Substring(9, 22) == @"Step setPower_uW=""0.07")
                                    {
                                        processLine("measPower_uW=", "ignoreNoise", s);
                                        LIN_07_MeasPower_Ax4 = Convert.ToDouble(s.Substring(start, length - 1));
                                        processLine("ssiAvg=", "calcPower", s);
                                        LIN_07_SSI_Average_Ax4 = Convert.ToInt32(s.Substring(start, length - 1));
                                        processLine("rmsError=", "dft1=", s);
                                        LIN_07_Rms_Error_Ax4 = Convert.ToDouble(s.Substring(start, length - 1));
                                        LINx4 = false;
                                        continue;
                                    }
                                }

                                if (s.Length > 14 && s.Substring(7, 6) == "Result")
                                {
                                    processLine("<Result>", "</Result>", s);
                                    LL_Test_Result = s.Substring(start - 1, length + 2);
                                    LLdone = true;
                                    continue;
                                }
                            }

                            if (LLhpDone == false && LLhp == false && s.Length > 33)
                            {
                                if (s.Substring(5, 26) == @"Subtest name=""Lin. Long Hi")
                                {
                                    LLhp = true;
                                    continue;
                                }
                            }

                            if (LLhpDone == false && LLhp == true)
                            {
                                if (LINx1 == false && s.Length > 17)
                                {
                                    if (s.Substring(7, 10) == @"Axis id=""1")
                                    {
                                        LINx1 = true;
                                        continue;
                                    }
                                }

                                if (LINx1 == true && s.Length > 32)
                                {
                                    if (s.Substring(9, 22) == @"Step setPower_uW=""2.00")
                                    {
                                        processLine("rmsError=", "dft1=", s);
                                        LLhp_2_Rms_Error_Ax1 = Convert.ToDouble(s.Substring(start, length - 1));
                                        LLhpx1x = true;
                                        LINx1 = false;
                                        continue;
                                    }
                                }

                                if (LINx2 == false && s.Length > 17)
                                {
                                    if (s.Substring(7, 10) == @"Axis id=""2")
                                    {
                                        LINx2 = true;
                                        continue;
                                    }
                                }

                                if (LINx2 == true && s.Length > 32)
                                {
                                    if (s.Substring(9, 22) == @"Step setPower_uW=""2.00")
                                    {
                                        processLine("rmsError=", "dft1=", s);
                                        LLhp_2_Rms_Error_Ax2 = Convert.ToDouble(s.Substring(start, length - 1));
                                        LLhpx2x = true;
                                        LINx2 = false;
                                        continue;
                                    }
                                }

                                if (LINx3 == false && s.Length > 17)
                                {
                                    if (s.Substring(7, 10) == @"Axis id=""3")
                                    {
                                        LINx3 = true;
                                        continue;
                                    }
                                }

                                if (LINx3 == true && s.Length > 32)
                                {
                                    if (s.Substring(9, 22) == @"Step setPower_uW=""2.00")
                                    {
                                        processLine("rmsError=", "dft1=", s);
                                        LLhp_2_Rms_Error_Ax3 = Convert.ToDouble(s.Substring(start, length - 1));
                                        LLhpx3x = true;
                                        LINx3 = false;
                                        continue;
                                    }
                                }

                                if (LINx4 == false && s.Length > 17)
                                {
                                    if (s.Substring(7, 10) == @"Axis id=""4")
                                    {
                                        LINx4 = true;
                                        continue;
                                    }
                                }

                                if (LINx4 == true && s.Length > 32)
                                {
                                    if (s.Substring(9, 22) == @"Step setPower_uW=""2.00")
                                    {
                                        processLine("rmsError=", "dft1=", s);
                                        LLhp_2_Rms_Error_Ax4 = Convert.ToDouble(s.Substring(start, length - 1));
                                        LLhpx4x = true;
                                        LINx4 = false;
                                        continue;
                                    }
                                }

                                if (s.Length > 14 && s.Substring(7, 6) == "Result")
                                {
                                    processLine("<Result>", "</Result>", s);
                                    LLhp_Test_Result = s.Substring(start - 1, length + 2);
                                    LLhpDone = true;
                                    continue;
                                }

                            }

                            if (LLdone == true && LLhpDone == true)
                            {
                                LINdone = true;
                            }
                        }

                        if (EPV == false && s.Length > 30)
                        {
                            if (s.Substring(3, 23) == @"Test name=""EEPROMVerify")
                            {
                                EPV = true;
                                continue;
                            }
                        }

                        if (EPVx == false && EPV == true && s.Length > 30)
                        {
                            if (s.Substring(5, 25) == @"Subtest name=""AC/DC Power")
                            {
                                EPVx = true;
                                continue;
                            }
                        }

                        if (EPVx1 == false && EPVx == true)
                        {
                            if (s.Substring(7, 10) == @"Axis id=""1")
                            {
                                EPVx1 = true;
                                continue;
                            }
                        }

                        if (EPVx1 == true)
                        {
                            if (EPVx1x7 == false && s.Length > 33 && s.Substring(9, 22) == @"Step FiberPwrSet_uW=""7")
                            {
                                EPVx1x7 = true;

                                processLine("FiberPwrMeas_uW=", "{", s);
                                EPV_FiberPwrMeas_7_uW_Ax1 = Convert.ToDouble(s.Substring(start, length));
                                processLine("AcDcOptPwrDiffL2=", "Calc", s);
                                EPV_AcDcOptPwrDiffL2_7_Ax1 = Convert.ToInt32(s.Substring(start, length - 1));
                                processLine("CalcProcGainL2=", "Status=", s);
                                EPV_CalcProcGainL2_7_Ax1 = Convert.ToInt32(s.Substring(start, length - 1));
                            }

                            if (EPVx1x1 == false && s.Length > 33 && s.Substring(9, 22) == @"Step FiberPwrSet_uW=""1")
                            {
                                EPVx1x1 = true;
                                processLine("FiberPwrMeas_uW=", "{", s);
                                EPV_FiberPwrMeas_1_uW_Ax1 = Convert.ToDouble(s.Substring(start, length));
                                processLine("AcDcOptPwrDiffL2=", "Calc", s);
                                EPV_AcDcOptPwrDiffL2_1_Ax1 = Convert.ToInt32(s.Substring(start, length - 1));
                                processLine("CalcProcGainL2=", "Status=", s);
                                EPV_CalcProcGainL2_1_Ax1 = Convert.ToInt32(s.Substring(start, length - 1));
                            }

                            if (EPVx1x03 == false && s.Length > 33 && s.Substring(9, 24) == @"Step FiberPwrSet_uW=""0.3")
                            {
                                EPVx1x03 = true;
                                processLine("FiberPwrMeas_uW=", "{", s);
                                EPV_FiberPwrMeas_03_uW_Ax1 = Convert.ToDouble(s.Substring(start, length));
                                processLine("AcDcOptPwrDiffL2=", "Calc", s);
                                EPV_AcDcOptPwrDiffL2_03_Ax1 = Convert.ToInt32(s.Substring(start, length - 1));
                                processLine("CalcProcGainL2=", "Status=", s);
                                EPV_CalcProcGainL2_03_Ax1 = Convert.ToInt32(s.Substring(start, length - 1));
                            }
                        }


                        if (EPVx2 == false && EPVx == true && s.Length > 17)
                        {
                            if (s.Substring(7, 10) == @"Axis id=""2")
                            {
                                EPVx2 = true;
                            }
                        }

                        if (EPVx2 == true)
                        {
                            if (EPVx2x7 == false && s.Length > 33 && s.Substring(9, 22) == @"Step FiberPwrSet_uW=""7")
                            {
                                EPVx2x7 = true;

                                processLine("FiberPwrMeas_uW=", "{", s);
                                EPV_FiberPwrMeas_7_uW_Ax2 = Convert.ToDouble(s.Substring(start, length));
                                processLine("AcDcOptPwrDiffL2=", "Calc", s);
                                EPV_AcDcOptPwrDiffL2_7_Ax2 = Convert.ToInt32(s.Substring(start, length - 1));
                                processLine("CalcProcGainL2=", "Status=", s);
                                EPV_CalcProcGainL2_7_Ax2 = Convert.ToInt32(s.Substring(start, length - 1));
                                continue;
                            }

                            if (EPVx2x1 == false && s.Length > 33 && s.Substring(9, 22) == @"Step FiberPwrSet_uW=""1")
                            {
                                EPVx2x1 = true;
                                processLine("FiberPwrMeas_uW=", "{", s);
                                EPV_FiberPwrMeas_1_uW_Ax2 = Convert.ToDouble(s.Substring(start, length));
                                processLine("AcDcOptPwrDiffL2=", "Calc", s);
                                EPV_AcDcOptPwrDiffL2_1_Ax2 = Convert.ToInt32(s.Substring(start, length - 1));
                                processLine("CalcProcGainL2=", "Status=", s);
                                EPV_CalcProcGainL2_1_Ax2 = Convert.ToInt32(s.Substring(start, length - 1));
                                continue;
                            }

                            if (EPVx2x03 == false && s.Length > 33 && s.Substring(9, 24) == @"Step FiberPwrSet_uW=""0.3")
                            {
                                EPVx2x03 = true;
                                processLine("FiberPwrMeas_uW=", "{", s);
                                EPV_FiberPwrMeas_03_uW_Ax2 = Convert.ToDouble(s.Substring(start, length));
                                processLine("AcDcOptPwrDiffL2=", "Calc", s);
                                EPV_AcDcOptPwrDiffL2_03_Ax2 = Convert.ToInt32(s.Substring(start, length - 1));
                                processLine("CalcProcGainL2=", "Status=", s);
                                EPV_CalcProcGainL2_03_Ax2 = Convert.ToInt32(s.Substring(start, length - 1));
                                continue;
                            }
                        }

                        if (EPVx3 == false && EPVx == true && s.Length > 17)
                        {
                            if (s.Substring(7, 10) == @"Axis id=""3")
                            {
                                EPVx3 = true;
                            }
                        }

                        if (EPVx3 == true)
                        {
                            if (EPVx3x7 == false && s.Length > 33 && s.Substring(9, 22) == @"Step FiberPwrSet_uW=""7")
                            {
                                EPVx3x7 = true;

                                processLine("FiberPwrMeas_uW=", "{", s);
                                EPV_FiberPwrMeas_7_uW_Ax3 = Convert.ToDouble(s.Substring(start, length));
                                processLine("AcDcOptPwrDiffL2=", "Calc", s);
                                EPV_AcDcOptPwrDiffL2_7_Ax3 = Convert.ToInt32(s.Substring(start, length - 1));
                                processLine("CalcProcGainL2=", "Status=", s);
                                EPV_CalcProcGainL2_7_Ax3 = Convert.ToInt32(s.Substring(start, length - 1));
                                continue;
                            }

                            if (EPVx3x1 == false && s.Length > 33 && s.Substring(9, 22) == @"Step FiberPwrSet_uW=""1")
                            {
                                EPVx3x1 = true;
                                processLine("FiberPwrMeas_uW=", "{", s);
                                EPV_FiberPwrMeas_1_uW_Ax3 = Convert.ToDouble(s.Substring(start, length));
                                processLine("AcDcOptPwrDiffL2=", "Calc", s);
                                EPV_AcDcOptPwrDiffL2_1_Ax3 = Convert.ToInt32(s.Substring(start, length - 1));
                                processLine("CalcProcGainL2=", "Status=", s);
                                EPV_CalcProcGainL2_1_Ax3 = Convert.ToInt32(s.Substring(start, length - 1));
                                continue;
                            }

                            if (EPVx3x03 == false && s.Length > 33 && s.Substring(9, 24) == @"Step FiberPwrSet_uW=""0.3")
                            {
                                EPVx3x03 = true;
                                processLine("FiberPwrMeas_uW=", "{", s);
                                EPV_FiberPwrMeas_03_uW_Ax3 = Convert.ToDouble(s.Substring(start, length));
                                processLine("AcDcOptPwrDiffL2=", "Calc", s);
                                EPV_AcDcOptPwrDiffL2_03_Ax3 = Convert.ToInt32(s.Substring(start, length - 1));
                                processLine("CalcProcGainL2=", "Status=", s);
                                EPV_CalcProcGainL2_03_Ax3 = Convert.ToInt32(s.Substring(start, length - 1));
                                continue;
                            }
                        }

                        if (EPVx4 == false && EPVx == true && s.Length > 17)
                        {
                            if (s.Substring(7, 10) == @"Axis id=""2")
                            {
                                EPVx4 = true;
                            }
                        }

                        if (EPVx4 == true)
                        {
                            if (EPVx4x7 == false && s.Length > 33 && s.Substring(9, 22) == @"Step FiberPwrSet_uW=""7")
                            {
                                EPVx4x7 = true;

                                processLine("FiberPwrMeas_uW=", "{", s);
                                EPV_FiberPwrMeas_7_uW_Ax4 = Convert.ToDouble(s.Substring(start, length));
                                processLine("AcDcOptPwrDiffL2=", "Calc", s);
                                EPV_AcDcOptPwrDiffL2_7_Ax4 = Convert.ToInt32(s.Substring(start, length - 1));
                                processLine("CalcProcGainL2=", "Status=", s);
                                EPV_CalcProcGainL2_7_Ax4 = Convert.ToInt32(s.Substring(start, length - 1));
                                continue;
                            }

                            if (EPVx4x1 == false && s.Length > 33 && s.Substring(9, 22) == @"Step FiberPwrSet_uW=""1")
                            {
                                EPVx4x1 = true;
                                processLine("FiberPwrMeas_uW=", "{", s);
                                EPV_FiberPwrMeas_1_uW_Ax4 = Convert.ToDouble(s.Substring(start, length));
                                processLine("AcDcOptPwrDiffL2=", "Calc", s);
                                EPV_AcDcOptPwrDiffL2_1_Ax4 = Convert.ToInt32(s.Substring(start, length - 1));
                                processLine("CalcProcGainL2=", "Status=", s);
                                EPV_CalcProcGainL2_1_Ax4 = Convert.ToInt32(s.Substring(start, length - 1));
                                continue;
                            }

                            if (EPVx4x03 == false && s.Length > 33 && s.Substring(9, 24) == @"Step FiberPwrSet_uW=""0.3")
                            {
                                EPVx4x03 = true;
                                processLine("FiberPwrMeas_uW=", "{", s);
                                EPV_FiberPwrMeas_03_uW_Ax4 = Convert.ToDouble(s.Substring(start, length));
                                processLine("AcDcOptPwrDiffL2=", "Calc", s);
                                EPV_AcDcOptPwrDiffL2_03_Ax4 = Convert.ToInt32(s.Substring(start, length - 1));
                                processLine("CalcProcGainL2=", "Status=", s);
                                EPV_CalcProcGainL2_03_Ax4 = Convert.ToInt32(s.Substring(start, length - 1));
                                continue;
                            }
                        }

                        if (SSIdone == false && SSI == false && s.Length > 38)
                        {
                            if (s.Substring(5, 33) == @"Subtest name=""SSI Calibration 40X")
                            {
                                SSI = true;
                                continue;
                            }
                        }

                        if (SSIdone == false && SSI == true)
                        {
                            if (SSIx1 == false && s.Length > 17)
                            {
                                if (s.Substring(7, 10) == @"Axis id=""1")
                                {
                                    SSIx1 = true;
                                    SSIx1x = true;
                                    continue;
                                }
                            }

                            if (SSIx1 == true && s.Length > 34)
                            {
                                if (s.Substring(9, 23) == @"Trial FiberPwrSet=""1.00")
                                {
                                    processLine("FiberPwrMeas=", "MeasBias", s);
                                    SSI_1_MeasPower_Ax1 = Convert.ToDouble(s.Substring(start, length - 1));
                                    processLine("SSIAvg=", "SSILimMin", s);
                                    SSI_1_SSI_Average_Ax1 = Convert.ToInt32(s.Substring(start, length - 1));
                                    continue;
                                }

                                if (s.Substring(9, 24) == @"Trial FiberPwrSet=""60.00")
                                {
                                    processLine("FiberPwrMeas=", "MeasBias", s);
                                    SSI_60_MeasPower_Ax1 = Convert.ToDouble(s.Substring(start, length - 1));
                                    processLine("SSIAvg=", "SSILimMin", s);
                                    SSI_60_SSI_Average_Ax1 = Convert.ToInt32(s.Substring(start, length - 1));
                                    continue;
                                }

                                if (s.Substring(9, 25) == @"Trial FiberPwrSet=""138.00")
                                {
                                    processLine("FiberPwrMeas=", "MeasBias", s);
                                    SSI_138_MeasPower_Ax1 = Convert.ToDouble(s.Substring(start, length - 1));
                                    processLine("SSIAvg=", "SSILimMin", s);
                                    SSI_138_SSI_Average_Ax1 = Convert.ToInt32(s.Substring(start, length - 1));
                                    SSIx1 = false;
                                    continue;
                                }
                            }

                            if (SSIx2 == false && s.Length > 17)
                            {
                                if (s.Substring(7, 10) == @"Axis id=""2")
                                {
                                    SSIx2 = true;
                                    SSIx2x = true;
                                    continue;
                                }
                            }

                            if (SSIx2 == true && s.Length > 34)
                            {
                                if (s.Substring(9, 23) == @"Trial FiberPwrSet=""1.00")
                                {
                                    processLine("FiberPwrMeas=", "MeasBias", s);
                                    SSI_1_MeasPower_Ax2 = Convert.ToDouble(s.Substring(start, length - 1));
                                    processLine("SSIAvg=", "SSILimMin", s);
                                    SSI_1_SSI_Average_Ax2 = Convert.ToInt32(s.Substring(start, length - 1));
                                    continue;
                                }

                                if (s.Substring(9, 24) == @"Trial FiberPwrSet=""60.00")
                                {
                                    processLine("FiberPwrMeas=", "MeasBias", s);
                                    SSI_60_MeasPower_Ax2 = Convert.ToDouble(s.Substring(start, length - 1));
                                    processLine("SSIAvg=", "SSILimMin", s);
                                    SSI_60_SSI_Average_Ax2 = Convert.ToInt32(s.Substring(start, length - 1));
                                    continue;
                                }

                                if (s.Substring(9, 25) == @"Trial FiberPwrSet=""138.00")
                                {
                                    processLine("FiberPwrMeas=", "MeasBias", s);
                                    SSI_138_MeasPower_Ax2 = Convert.ToDouble(s.Substring(start, length - 1));
                                    processLine("SSIAvg=", "SSILimMin", s);
                                    SSI_138_SSI_Average_Ax2 = Convert.ToInt32(s.Substring(start, length - 1));
                                    SSIx2 = false;
                                    continue;
                                }
                            }

                            if (SSIx3 == false && s.Length > 17)
                            {
                                if (s.Substring(7, 10) == @"Axis id=""3")
                                {
                                    SSIx3 = true;
                                    SSIx3x = true;
                                    continue;
                                }
                            }

                            if (SSIx3 == true && s.Length > 34)
                            {
                                if (s.Substring(9, 23) == @"Trial FiberPwrSet=""1.00")
                                {
                                    processLine("FiberPwrMeas=", "MeasBias", s);
                                    SSI_1_MeasPower_Ax3 = Convert.ToDouble(s.Substring(start, length - 1));
                                    processLine("SSIAvg=", "SSILimMin", s);
                                    SSI_1_SSI_Average_Ax3 = Convert.ToInt32(s.Substring(start, length - 1));
                                    continue;
                                }

                                if (s.Substring(9, 24) == @"Trial FiberPwrSet=""60.00")
                                {
                                    processLine("FiberPwrMeas=", "MeasBias", s);
                                    SSI_60_MeasPower_Ax3 = Convert.ToDouble(s.Substring(start, length - 1));
                                    processLine("SSIAvg=", "SSILimMin", s);
                                    SSI_60_SSI_Average_Ax3 = Convert.ToInt32(s.Substring(start, length - 1));
                                    continue;
                                }

                                if (s.Substring(9, 25) == @"Trial FiberPwrSet=""138.00")
                                {
                                    processLine("FiberPwrMeas=", "MeasBias", s);
                                    SSI_138_MeasPower_Ax3 = Convert.ToDouble(s.Substring(start, length - 1));
                                    processLine("SSIAvg=", "SSILimMin", s);
                                    SSI_138_SSI_Average_Ax3 = Convert.ToInt32(s.Substring(start, length - 1));
                                    SSIx3 = false;
                                    continue;
                                }
                            }

                            if (SSIx4 == false && s.Length > 17)
                            {
                                if (s.Substring(7, 10) == @"Axis id=""4")
                                {
                                    SSIx4 = true;
                                    SSIx4x = true;
                                    continue;
                                }
                            }

                            if (SSIx4 == true && s.Length > 34)
                            {
                                if (s.Substring(9, 23) == @"Trial FiberPwrSet=""1.00")
                                {
                                    processLine("FiberPwrMeas=", "MeasBias", s);
                                    SSI_1_MeasPower_Ax4 = Convert.ToDouble(s.Substring(start, length - 1));
                                    processLine("SSIAvg=", "SSILimMin", s);
                                    SSI_1_SSI_Average_Ax4 = Convert.ToInt32(s.Substring(start, length - 1));
                                    continue;
                                }

                                if (s.Substring(9, 24) == @"Trial FiberPwrSet=""60.00")
                                {
                                    processLine("FiberPwrMeas=", "MeasBias", s);
                                    SSI_60_MeasPower_Ax4 = Convert.ToDouble(s.Substring(start, length - 1));
                                    processLine("SSIAvg=", "SSILimMin", s);
                                    SSI_60_SSI_Average_Ax4 = Convert.ToInt32(s.Substring(start, length - 1));
                                    continue;
                                }

                                if (s.Substring(9, 25) == @"Trial FiberPwrSet=""138.00")
                                {
                                    processLine("FiberPwrMeas=", "MeasBias", s);
                                    SSI_138_MeasPower_Ax4 = Convert.ToDouble(s.Substring(start, length - 1));
                                    processLine("SSIAvg=", "SSILimMin", s);
                                    SSI_138_SSI_Average_Ax4 = Convert.ToInt32(s.Substring(start, length - 1));
                                    SSIx4 = false;
                                    continue;
                                }
                            }
                        }

                    }

                    /*
                     *
                     *  first insert for the file, then update for each section in order
                     *  to be able to have location information for the error if there is one
                     * 
                     */
                    string sql = "Insert into dbo.[test data] (" +
                                        "[XML File Name], " +
                                        "SN," +
                                        "Rev, " +
                                        "[Board Type], " +
                                        "[ITS Build Number], " +
                                        "[Test Station], " +
                                        "Iteration, " +
                                        "[Board PromVer]," +
                                        "[test date], " +
                                        "Reason4Test" +
                                        ") values ('" +
                                        fileName + "'," +
                                        SN + ",'" +
                                        Rev + "','" +
                                        BoardType + "'," +
                                        ITSbuildNumber + ",'" +
                                        TestStation + "','" +
                                        Iteration + "'," +
                                        BoardPromVer + ",'" +
                                        TestDate + "','" +
                                        Reason4Test + "')";

                    feedData(sql, "file header");


                    sql = "Update dbo.[test data] set " +
                          "AD = '" + AD + "'," +
                          "[AD Test Result] = '" + AD_Test_Result + "'," +
                          "[AD +5V Digital PS] = " + AD5V_Digital_PS + "," +
                          "[AD +5V Digital PS Ripple] = " + AD5V_Digital_PS_Ripple +
                          " Where [XML File Name] = '" + fileName + "' ";

                    feedData(sql, "AD section");


                    sql = "Update dbo.[test data] set " +
                          "[DA Test Result] = '" + DA_Test_Result + "'," +
                          "[DA RfDelay DAU1] = " + DA_rfDelay_DAU1 + "," +
                          "[DA RfDelay DAU2] = " + DA_rfDelay_DAU2 + "," +
                          "DArf1 = '" + DArf1 + "'," +
                          "DArf2 = '" + DArf2 + "'," +
                          "DAms1 = '" + DAms1 + "'," +
                          "DAms2 = '" + DAms2 + "'," +
                          "DAms3 = '" + DAms3 + "'," +
                          "DAms4 = '" + DAms4 + "'," +
                          "[DA Age DAU1] = " + DA_msDelay_DAU1 + "," +
                          "[DA Age DAU2] = " + DA_msDelay_DAU2 + "," +
                          "[DA Age DAU3] = " + DA_msDelay_DAU3 + "," +
                          "[DA Age DAU4] = " + DA_msDelay_DAU4 +
                          " Where [XML File Name] = '" + fileName + "' ";

                    feedData(sql, "DA section");


                    sql = "Update dbo.[test data] set " +
                           "[DNACdnac Test Result] = '" + DNACdnac_Test_Result + "'," +
                           "DNACx1 = '" + DNACx1x + "'," +
                           "DNACx2 = '" + DNACx2x + "'," +
                           "DNACx3 = '" + DNACx3x + "'," +
                           "DNACx4 = '" + DNACx4x + "'," +
                           "[DNAC 3.88 SSI Average Ax1] = " + DNAC_388_SSI_Average_Ax1 + "," +
                           "[DNAC 3.88 Std Dev Ax1] = " + DNAC_388_Std_Dev_Ax1 + "," +
                           "[DNAC 30.01 SSI Average Ax1] = " + DNAC_3001_SSI_Average_Ax1 + "," +
                          "[DNAC 30.01 Std Dev Ax1] = " + DNAC_3001_Std_Dev_Ax1 + "," +
                          "[DNAC 36.12 SSI Average Ax1] = " + DNAC_3612_SSI_Average_Ax1 + "," +
                          "[DNAC 36.12 Std Dev Ax1] = " + DNAC_3612_Std_Dev_Ax1 + "," +
                          "[DNAC 3.88 SSI Average Ax2] = " + DNAC_388_SSI_Average_Ax2 + "," +
                          "[DNAC 3.88 Std Dev Ax2] = " + DNAC_388_Std_Dev_Ax2 + "," +
                          "[DNAC 30.01 SSI Average Ax2] = " + DNAC_3001_SSI_Average_Ax2 + "," +
                          "[DNAC 30.01 Std Dev Ax2] = " + DNAC_3001_Std_Dev_Ax2 + "," +
                          "[DNAC 36.12 SSI Average Ax2] = " + DNAC_3612_SSI_Average_Ax2 + "," +
                          "[DNAC 36.12 Std Dev Ax2] = " + DNAC_3612_Std_Dev_Ax2 + "," +
                          "[DNAC 3.88 SSI Average Ax3] = " + DNAC_388_SSI_Average_Ax3 + "," +
                          "[DNAC 3.88 Std Dev Ax3] = " + DNAC_388_Std_Dev_Ax3 + "," +
                          "[DNAC 30.01 SSI Average Ax3] = " + DNAC_3001_SSI_Average_Ax3 + "," +
                          "[DNAC 30.01 Std Dev Ax3] = " + DNAC_3001_Std_Dev_Ax3 + "," +
                          "[DNAC 36.12 SSI Average Ax3] = " + DNAC_3612_SSI_Average_Ax3 + "," +
                          "[DNAC 36.12 Std Dev Ax3] = " + DNAC_3612_Std_Dev_Ax3 + "," +
                          "[DNAC 3.88 SSI Average Ax4] = " + DNAC_388_SSI_Average_Ax4 + "," +
                          "[DNAC 3.88 Std Dev Ax4] = " + DNAC_388_Std_Dev_Ax4 + "," +
                          "[DNAC 30.01 SSI Average Ax4] = " + DNAC_3001_SSI_Average_Ax4 + "," +
                          "[DNAC 30.01 Std Dev Ax4] = " + DNAC_3001_Std_Dev_Ax4 + "," +
                          "[DNAC 36.12 SSI Average Ax4] = " + DNAC_3612_SSI_Average_Ax4 + "," +
                           "[DNAC 36.12 Std Dev Ax4] = " + DNAC_3612_Std_Dev_Ax4 +
                           " Where [XML File Name] = '" + fileName + "' ";

                    feedData(sql, "DNAC section");


                    sql = "Update dbo.[test data] set " +
                           "[DNACdnacHP Test Result] = '" + DNACdnacHP_Test_Result + "'," +
                           "[DNAC hp 3.88 Std Dev Ax1] = " + DNAChp_388_Std_Dev_Ax1 + "," +
                           "[DNAC hp 3.88 Std Dev Ax2] = " + DNAChp_388_Std_Dev_Ax2 + "," +
                           "[DNAC hp 3.88 Std Dev Ax3] = " + DNAChp_388_Std_Dev_Ax3 + "," +
                           "[DNAC hp 3.88 Std Dev Ax4] = " + DNAChp_388_Std_Dev_Ax4 + "," +
                           "[DNAC hp 30.01 Std Dev Ax1] = " + DNAChp_3001_Std_Dev_Ax1 + "," +
                           "[DNAC hp 30.01 Std Dev Ax2] = " + DNAChp_3001_Std_Dev_Ax2 + "," +
                           "[DNAC hp 30.01 Std Dev Ax3] = " + DNAChp_3001_Std_Dev_Ax3 + "," +
                           "[DNAC hp 30.01 Std Dev Ax4] = " + DNAChp_3001_Std_Dev_Ax4 + "," +
                           "[DNAC hp 36.12 Std Dev Ax1] = " + DNAChp_3612_Std_Dev_Ax1 + "," +
                           "[DNAC hp 36.12 Std Dev Ax2] = " + DNAChp_3612_Std_Dev_Ax2 + "," +
                           "[DNAC hp 36.12 Std Dev Ax3] = " + DNAChp_3612_Std_Dev_Ax3 + "," +
                           "[DNAC hp 36.12 Std Dev Ax4] = " + DNAChp_3612_Std_Dev_Ax4 + "," +
                           "DNAChpx1 = '" + DNAChpx1 + "'," +
                           "DNAChpx2 = '" + DNAChpx2 + "'," +
                           "DNAChpx3 = '" + DNAChpx3 + "'," +
                           "DNAChpx4 = '" + DNAChpx4 + "'" +
                           " Where [XML File Name] = '" + fileName + "' ";

                    feedData(sql, "DNAC hp section");


                    sql = "Update dbo.[test data] set " +
                          "[LIN Long Test Result] = '" + LL_Test_Result + "', " +
                          "LINx1 = '" + LINx1x + "'," +
                          "LINx2 = '" + LINx2x + "'," +
                          "LINx3 = '" + LINx3x + "'," +
                          "LINx4 = '" + LINx4x + "'," +
                        "[LIN 60 MeasPower Ax1] = " + LIN_60_MeasPower_Ax1 + "," +
                        "[LIN 60 SSI Avg Ax1] = " + LIN_60_SSI_Average_Ax1 + "," +
                        "[LIN 60 Rms Error Ax1] = " + LIN_60_Rms_Error_Ax1 + "," +
                        "[LIN 10 MeasPower Ax1] = " + LIN_10_MeasPower_Ax1 + "," +
                        "[LIN 10 SSI Avg Ax1] = " + LIN_10_SSI_Average_Ax1 + "," +
                        "[LIN 10 Rms Error Ax1] = " + LIN_10_Rms_Error_Ax1 + "," +
                        "[LIN 1 MeasPower Ax1] = " + LIN_1_MeasPower_Ax1 + "," +
                        "[LIN 1 SSI Avg Ax1] = " + LIN_1_SSI_Average_Ax1 + "," +
                        "[LIN 1 Rms Error Ax1] = " + LIN_1_Rms_Error_Ax1 + "," +
                        "[LIN .07 MeasPower Ax1] = " + LIN_07_MeasPower_Ax1 + "," +
                        "[LIN .07 SSI Avg Ax1] = " + LIN_07_SSI_Average_Ax1 + "," +
                        "[LIN .07 Rms Error Ax1] = " + LIN_07_Rms_Error_Ax1 + "," +
                        "[LIN 60 MeasPower Ax2] = " + LIN_60_MeasPower_Ax2 + "," +
                        "[LIN 60 SSI Avg Ax2] = " + LIN_60_SSI_Average_Ax2 + "," +
                        "[LIN 60 Rms Error Ax2] = " + LIN_60_Rms_Error_Ax2 + "," +
                        "[LIN 10 MeasPower Ax2] = " + LIN_10_MeasPower_Ax2 + "," +
                        "[LIN 10 SSI Avg Ax2] = " + LIN_10_SSI_Average_Ax2 + "," +
                        "[LIN 10 Rms Error Ax2] = " + LIN_10_Rms_Error_Ax2 + "," +
                        "[LIN 1 MeasPower Ax2] = " + LIN_1_MeasPower_Ax2 + "," +
                        "[LIN 1 SSI Avg Ax2] = " + LIN_1_SSI_Average_Ax2 + "," +
                        "[LIN 1 Rms Error Ax2] = " + LIN_1_Rms_Error_Ax2 + "," +
                        "[LIN .07 MeasPower Ax2] = " + LIN_07_MeasPower_Ax2 + "," +
                        "[LIN .07 SSI Avg Ax2] = " + LIN_07_SSI_Average_Ax2 + "," +
                        "[LIN .07 Rms Error Ax2] = " + LIN_07_Rms_Error_Ax2 + "," +
                        "[LIN 60 MeasPower Ax3] = " + LIN_60_MeasPower_Ax3 + "," +
                        "[LIN 60 SSI Avg Ax3] = " + LIN_60_SSI_Average_Ax3 + "," +
                        "[LIN 60 Rms Error Ax3] = " + LIN_60_Rms_Error_Ax3 + "," +
                        "[LIN 10 MeasPower Ax3] = " + LIN_10_MeasPower_Ax3 + "," +
                        "[LIN 10 SSI Avg Ax3] = " + LIN_10_SSI_Average_Ax3 + "," +
                        "[LIN 10 Rms Error Ax3] = " + LIN_10_Rms_Error_Ax3 + "," +
                        "[LIN 1 MeasPower Ax3] = " + LIN_1_MeasPower_Ax3 + "," +
                        "[LIN 1 SSI Avg Ax3] = " + LIN_1_SSI_Average_Ax3 + "," +
                        "[LIN 1 Rms Error Ax3] = " + LIN_1_Rms_Error_Ax3 + "," +
                        "[LIN .07 MeasPower Ax3] = " + LIN_07_MeasPower_Ax3 + "," +
                        "[LIN .07 SSI Avg Ax3] = " + LIN_07_SSI_Average_Ax3 + "," +
                        "[LIN .07 Rms Error Ax3] = " + LIN_07_Rms_Error_Ax3 + "," +
                        "[LIN 60 MeasPower Ax4] = " + LIN_60_MeasPower_Ax4 + "," +
                        "[LIN 60 SSI Avg Ax4] = " + LIN_60_SSI_Average_Ax4 + "," +
                        "[LIN 60 Rms Error Ax4] = " + LIN_60_Rms_Error_Ax4 + "," +
                        "[LIN 10 MeasPower Ax4] = " + LIN_10_MeasPower_Ax4 + "," +
                        "[LIN 10 SSI Avg Ax4] = " + LIN_10_SSI_Average_Ax4 + "," +
                        "[LIN 10 Rms Error Ax4] = " + LIN_10_Rms_Error_Ax4 + "," +
                        "[LIN 1 MeasPower Ax4] = " + LIN_1_MeasPower_Ax4 + "," +
                        "[LIN 1 SSI Avg Ax4] = " + LIN_1_SSI_Average_Ax4 + "," +
                        "[LIN 1 Rms Error Ax4] = " + LIN_1_Rms_Error_Ax4 + "," +
                        "[LIN .07 MeasPower Ax4] = " + LIN_07_MeasPower_Ax4 + "," +
                        "[LIN .07 SSI Avg Ax4] = " + LIN_07_SSI_Average_Ax4 + "," +
                        "[LIN .07 Rms Error Ax4] = " + LIN_07_Rms_Error_Ax4 +
                          " Where [XML File Name] = '" + fileName + "' ";

                    feedData(sql, "LIN Long section");


                    sql = "Update dbo.[test data] set " +
                           "[LIN HP 2 Rms Error Ax1] = " + LLhp_2_Rms_Error_Ax1 + "," +
                           "[LIN HP 2 Rms Error Ax2] = " + LLhp_2_Rms_Error_Ax2 + "," +
                           "[LIN HP 2 Rms Error Ax3] = " + LLhp_2_Rms_Error_Ax3 + "," +
                           "[LIN HP 2 Rms Error Ax4] = " + LLhp_2_Rms_Error_Ax4 + "," +
                           "LLHPx1x = '" + LLhpx1x + "'," +
                           "LLHPx2x = '" + LLhpx2x + "'," +
                           "LLHPx3x = '" + LLhpx3x + "'," +
                           "LLHPx4x = '" + LLhpx4x + "'," +
                           "[LLHP Test Result] = '" + LLhp_Test_Result + "'" +
                           " Where [XML File Name] = '" + fileName + "' ";

                    feedData(sql, "LIN Long HP section");


                    sql = "Update dbo.[test data] set " +
                           "[EV PV FiberPwrMeas 7 uW Ax1]  =" + EPV_FiberPwrMeas_7_uW_Ax1 + "," +
                           "[EV PV FiberPwrMeas 1 uW Ax1]  =" + EPV_FiberPwrMeas_1_uW_Ax1 + "," +
                           "[EV PV FiberPwrMeas 0.3 uW Ax1]  =" + EPV_FiberPwrMeas_03_uW_Ax1 + "," +
                           "[EV PV AcDcOptPwrDiffL2 7 Ax1]  =" + EPV_AcDcOptPwrDiffL2_7_Ax1 + "," +
                           "[EV PV AcDcOptPwrDiffL2 1 Ax1]  =" + EPV_AcDcOptPwrDiffL2_1_Ax1 + "," +
                           "[EV PV AcDcOptPwrDiffL2 0.3 Ax1]  =" + EPV_AcDcOptPwrDiffL2_03_Ax1 + "," +
                           "[EV PV CalcProcGainL2 7 Ax1]  =" + EPV_CalcProcGainL2_7_Ax1 + "," +
                           "[EV PV CalcProcGainL2 1 Ax1]  =" + EPV_CalcProcGainL2_1_Ax1 + "," +
                           "[EV PV CalcProcGainL2 0.3 Ax1]  =" + EPV_CalcProcGainL2_03_Ax1 + "," +
                           "[EV PV FiberPwrMeas 7 uW Ax2]  =" + EPV_FiberPwrMeas_7_uW_Ax2 + "," +
                           "[EV PV FiberPwrMeas 1 uW Ax2]  =" + EPV_FiberPwrMeas_1_uW_Ax2 + "," +
                           "[EV PV FiberPwrMeas 0.3 uW Ax2]  =" + EPV_FiberPwrMeas_03_uW_Ax2 + "," +
                           "[EV PV AcDcOptPwrDiffL2 7 Ax2]  =" + EPV_AcDcOptPwrDiffL2_7_Ax2 + "," +
                           "[EV PV AcDcOptPwrDiffL2 1 Ax2]  =" + EPV_AcDcOptPwrDiffL2_1_Ax2 + "," +
                           "[EV PV AcDcOptPwrDiffL2 0.3 Ax2]  =" + EPV_AcDcOptPwrDiffL2_03_Ax2 + "," +
                           "[EV PV CalcProcGainL2 7 Ax2]  =" + EPV_CalcProcGainL2_7_Ax2 + "," +
                           "[EV PV CalcProcGainL2 1 Ax2]  =" + EPV_CalcProcGainL2_1_Ax2 + "," +
                           "[EV PV CalcProcGainL2 0.3 Ax2]  =" + EPV_CalcProcGainL2_03_Ax2 + "," +
                           "[EV PV FiberPwrMeas 7 uW Ax3]  =" + EPV_FiberPwrMeas_7_uW_Ax3 + "," +
                           "[EV PV FiberPwrMeas 1 uW Ax3]  =" + EPV_FiberPwrMeas_1_uW_Ax3 + "," +
                           "[EV PV FiberPwrMeas 0.3 uW Ax3]  =" + EPV_FiberPwrMeas_03_uW_Ax3 + "," +
                           "[EV PV AcDcOptPwrDiffL2 7 Ax3]  =" + EPV_AcDcOptPwrDiffL2_7_Ax3 + "," +
                           "[EV PV AcDcOptPwrDiffL2 1 Ax3]  =" + EPV_AcDcOptPwrDiffL2_1_Ax3 + "," +
                           "[EV PV AcDcOptPwrDiffL2 0.3 Ax3]  =" + EPV_AcDcOptPwrDiffL2_03_Ax3 + "," +
                           "[EV PV CalcProcGainL2 7 Ax3]  =" + EPV_CalcProcGainL2_7_Ax3 + "," +
                           "[EV PV CalcProcGainL2 1 Ax3]  =" + EPV_CalcProcGainL2_1_Ax3 + "," +
                           "[EV PV CalcProcGainL2 0.3 Ax3]  =" + EPV_CalcProcGainL2_03_Ax3 + "," +
                           "[EV PV FiberPwrMeas 7 uW Ax4]  =" + EPV_FiberPwrMeas_7_uW_Ax4 + "," +
                           "[EV PV FiberPwrMeas 1 uW Ax4]  =" + EPV_FiberPwrMeas_1_uW_Ax4 + "," +
                           "[EV PV FiberPwrMeas 0.3 uW Ax4]  =" + EPV_FiberPwrMeas_03_uW_Ax4 + "," +
                           "[EV PV AcDcOptPwrDiffL2 7 Ax4]  =" + EPV_AcDcOptPwrDiffL2_7_Ax4 + "," +
                           "[EV PV AcDcOptPwrDiffL2 1 Ax4]  =" + EPV_AcDcOptPwrDiffL2_1_Ax4 + "," +
                           "[EV PV AcDcOptPwrDiffL2 0.3 Ax4]  =" + EPV_AcDcOptPwrDiffL2_03_Ax4 + "," +
                           "[EV PV CalcProcGainL2 7 Ax4]  =" + EPV_CalcProcGainL2_7_Ax4 + "," +
                           "[EV PV CalcProcGainL2 1 Ax4]  =" + EPV_CalcProcGainL2_1_Ax4 + "," +
                           "[EV PV CalcProcGainL2 0.3 Ax4] =" + EPV_CalcProcGainL2_03_Ax4 + "," +
                           "EVPVx1 = '" + EPVx1 + "'," +
                           "EVPVx2 = '" + EPVx2 + "'," +
                           "EVPVx3 = '" + EPVx3 + "'," +
                           "EVPVx4 = '" + EPVx4 + "'" +
                           " Where [XML File Name] = '" + fileName + "' ";

                    feedData(sql, "EV PV section");


                    sql = "Update dbo.[test data] set " +
                          "[SSI CAL 138 FiberPwrMeas Ax1] =" + SSI_138_MeasPower_Ax1 + "," +
                          "[SSI CAL 138 SSI Avg Ax1] =" + SSI_138_SSI_Average_Ax1 + "," +
                          "[SSI CAL 60 FiberPwrMeas Ax1] =" + SSI_60_MeasPower_Ax1 + "," +
                          "[SSI CAL 60 SSI Avg Ax1] =" + SSI_60_SSI_Average_Ax1 + "," +
                          "[SSI CAL 1 FiberPwrMeas Ax1] =" + SSI_1_MeasPower_Ax1 + "," +
                          "[SSI CAL 1 SSI Avg Ax1] =" + SSI_1_SSI_Average_Ax1 + "," +
                          "[SSI CAL 138 FiberPwrMeas Ax2] =" + SSI_138_MeasPower_Ax2 + "," +
                          "[SSI CAL 138 SSI Avg Ax2] =" + SSI_138_SSI_Average_Ax2 + "," +
                          "[SSI CAL 60 FiberPwrMeas Ax2] =" + SSI_60_MeasPower_Ax2 + "," +
                          "[SSI CAL 60 SSI Avg Ax2] =" + SSI_60_SSI_Average_Ax2 + "," +
                          "[SSI CAL 1 FiberPwrMeas Ax2] =" + SSI_1_MeasPower_Ax2 + "," +
                          "[SSI CAL 1 SSI Avg Ax2] =" + SSI_1_SSI_Average_Ax2 + "," +
                          "[SSI CAL 138 FiberPwrMeas Ax3] =" + SSI_138_MeasPower_Ax3 + "," +
                          "[SSI CAL 138 SSI Avg Ax3] =" + SSI_138_SSI_Average_Ax3 + "," +
                          "[SSI CAL 60 FiberPwrMeas Ax3] =" + SSI_60_MeasPower_Ax3 + "," +
                          "[SSI CAL 60 SSI Avg Ax3] =" + SSI_60_SSI_Average_Ax3 + "," +
                          "[SSI CAL 1 FiberPwrMeas Ax3] =" + SSI_1_MeasPower_Ax3 + "," +
                          "[SSI CAL 1 SSI Avg Ax3] =" + SSI_1_SSI_Average_Ax3 + "," +
                          "[SSI CAL 138 FiberPwrMeas Ax4] =" + SSI_138_MeasPower_Ax4 + "," +
                          "[SSI CAL 138 SSI Avg Ax4] =" + SSI_138_SSI_Average_Ax4 + "," +
                          "[SSI CAL 60 FiberPwrMeas Ax4] =" + SSI_60_MeasPower_Ax4 + "," +
                          "[SSI CAL 60 SSI Avg Ax4] =" + SSI_60_SSI_Average_Ax4 + "," +
                          "[SSI CAL 1 FiberPwrMeas Ax4] =" + SSI_1_MeasPower_Ax4 + "," +
                          "[SSI CAL 1 SSI Avg Ax4] =" + SSI_1_SSI_Average_Ax4 + "," +
                          "SSIx1x ='" + SSIx1x + "'," +
                          "SSIx2x ='" + SSIx2x + "'," +
                          "SSIx3x ='" + SSIx3x + "'," +
                          "SSIx4x ='" + SSIx4x + "'" +
                          " Where [XML File Name] = '" + fileName + "' ";

                    feedData(sql, "SSI CAL section");


                    fileName = null;
                    SN = 0;
                    Rev = null;
                    BoardType = null;
                    ITSbuildNumber = 0;
                    TestStation = null;
                    Iteration = null;
                    BoardPromVer = 0;
                    TestDate = new DateTime();
                    AD_Test_Result = null;
                    AD5V_Digital_PS = 0;
                    AD5V_Digital_PS_Ripple = 0;
                    DA_Test_Result = null;
                    DA_rfDelay_DAU1 = 0;
                    DA_rfDelay_DAU2 = 0;
                    DA_msDelay_DAU1 = 0;
                    DA_msDelay_DAU2 = 0;
                    DA_msDelay_DAU3 = 0;
                    DA_msDelay_DAU4 = 0;
                    DNAC_388_SSI_Average_Ax1 = 0;
                    DNAC_388_Std_Dev_Ax1 = 0;
                    DNAC_3001_SSI_Average_Ax1 = 0;
                    DNAC_3001_Std_Dev_Ax1 = 0;
                    DNAC_3612_SSI_Average_Ax1 = 0;
                    DNAC_3612_Std_Dev_Ax1 = 0;
                    DNAC_388_SSI_Average_Ax2 = 0;
                    DNAC_388_Std_Dev_Ax2 = 0;
                    DNAC_3001_SSI_Average_Ax2 = 0;
                    DNAC_3001_Std_Dev_Ax2 = 0;
                    DNAC_3612_SSI_Average_Ax2 = 0;
                    DNAC_3612_Std_Dev_Ax2 = 0;
                    DNAC_388_SSI_Average_Ax3 = 0;
                    DNAC_388_Std_Dev_Ax3 = 0;
                    DNAC_3001_SSI_Average_Ax3 = 0;
                    DNAC_3001_Std_Dev_Ax3 = 0;
                    DNAC_3612_SSI_Average_Ax3 = 0;
                    DNAC_3612_Std_Dev_Ax3 = 0;
                    DNAC_388_SSI_Average_Ax4 = 0;
                    DNAC_388_Std_Dev_Ax4 = 0;
                    DNAC_3001_SSI_Average_Ax4 = 0;
                    DNAC_3001_Std_Dev_Ax4 = 0;
                    DNAC_3612_SSI_Average_Ax4 = 0;
                    DNAC_3612_Std_Dev_Ax4 = 0;
                    LL_Test_Result = null;
                    LIN_60_MeasPower_Ax1 = 0;
                    LIN_60_SSI_Average_Ax1 = 0;
                    LIN_60_Rms_Error_Ax1 = 0;
                    LIN_10_MeasPower_Ax1 = 0;
                    LIN_10_SSI_Average_Ax1 = 0;
                    LIN_10_Rms_Error_Ax1 = 0;
                    LIN_1_MeasPower_Ax1 = 0;
                    LIN_1_SSI_Average_Ax1 = 0;
                    LIN_1_Rms_Error_Ax1 = 0;
                    LIN_07_MeasPower_Ax1 = 0;
                    LIN_07_SSI_Average_Ax1 = 0;
                    LIN_07_Rms_Error_Ax1 = 0;
                    LIN_60_MeasPower_Ax2 = 0;
                    LIN_60_SSI_Average_Ax2 = 0;
                    LIN_60_Rms_Error_Ax2 = 0;
                    LIN_10_MeasPower_Ax2 = 0;
                    LIN_10_SSI_Average_Ax2 = 0;
                    LIN_10_Rms_Error_Ax2 = 0;
                    LIN_1_MeasPower_Ax2 = 0;
                    LIN_1_SSI_Average_Ax2 = 0;
                    LIN_1_Rms_Error_Ax2 = 0;
                    LIN_07_MeasPower_Ax2 = 0;
                    LIN_07_SSI_Average_Ax2 = 0;
                    LIN_07_Rms_Error_Ax2 = 0;
                    LIN_60_MeasPower_Ax3 = 0;
                    LIN_60_SSI_Average_Ax3 = 0;
                    LIN_60_Rms_Error_Ax3 = 0;
                    LIN_10_MeasPower_Ax3 = 0;
                    LIN_10_SSI_Average_Ax3 = 0;
                    LIN_10_Rms_Error_Ax3 = 0;
                    LIN_1_MeasPower_Ax3 = 0;
                    LIN_1_SSI_Average_Ax3 = 0;
                    LIN_1_Rms_Error_Ax3 = 0;
                    LIN_07_MeasPower_Ax3 = 0;
                    LIN_07_SSI_Average_Ax3 = 0;
                    LIN_07_Rms_Error_Ax3 = 0;
                    LIN_60_MeasPower_Ax4 = 0;
                    LIN_60_SSI_Average_Ax4 = 0;
                    LIN_60_Rms_Error_Ax4 = 0;
                    LIN_10_MeasPower_Ax4 = 0;
                    LIN_10_SSI_Average_Ax4 = 0;
                    LIN_10_Rms_Error_Ax4 = 0;
                    LIN_1_MeasPower_Ax4 = 0;
                    LIN_1_SSI_Average_Ax4 = 0;
                    LIN_1_Rms_Error_Ax4 = 0;
                    LIN_07_MeasPower_Ax4 = 0;
                    LIN_07_SSI_Average_Ax4 = 0;
                    LIN_07_Rms_Error_Ax4 = 0;
                    EPV_FiberPwrMeas_7_uW_Ax1 = 0;
                    EPV_FiberPwrMeas_1_uW_Ax1 = 0;
                    EPV_FiberPwrMeas_03_uW_Ax1 = 0;
                    EPV_AcDcOptPwrDiffL2_7_Ax1 = 0;
                    EPV_AcDcOptPwrDiffL2_1_Ax1 = 0;
                    EPV_AcDcOptPwrDiffL2_03_Ax1 = 0;
                    EPV_CalcProcGainL2_03_Ax1 = 0;
                    EPV_CalcProcGainL2_7_Ax1 = 0;
                    EPV_CalcProcGainL2_1_Ax1 = 0;
                    EPV_FiberPwrMeas_7_uW_Ax2 = 0;
                    EPV_FiberPwrMeas_1_uW_Ax2 = 0;
                    EPV_FiberPwrMeas_03_uW_Ax2 = 0;
                    EPV_AcDcOptPwrDiffL2_7_Ax2 = 0;
                    EPV_AcDcOptPwrDiffL2_1_Ax2 = 0;
                    EPV_AcDcOptPwrDiffL2_03_Ax2 = 0;
                    EPV_CalcProcGainL2_03_Ax2 = 0;
                    EPV_CalcProcGainL2_7_Ax2 = 0;
                    EPV_CalcProcGainL2_1_Ax2 = 0;
                    EPV_FiberPwrMeas_7_uW_Ax3 = 0;
                    EPV_FiberPwrMeas_1_uW_Ax3 = 0;
                    EPV_FiberPwrMeas_03_uW_Ax3 = 0;
                    EPV_AcDcOptPwrDiffL2_7_Ax3 = 0;
                    EPV_AcDcOptPwrDiffL2_1_Ax3 = 0;
                    EPV_AcDcOptPwrDiffL2_03_Ax3 = 0;
                    EPV_CalcProcGainL2_03_Ax3 = 0;
                    EPV_CalcProcGainL2_7_Ax3 = 0;
                    EPV_CalcProcGainL2_1_Ax3 = 0;
                    EPV_FiberPwrMeas_7_uW_Ax4 = 0;
                    EPV_FiberPwrMeas_1_uW_Ax4 = 0;
                    EPV_FiberPwrMeas_03_uW_Ax4 = 0;
                    EPV_AcDcOptPwrDiffL2_7_Ax4 = 0;
                    EPV_AcDcOptPwrDiffL2_1_Ax4 = 0;
                    EPV_AcDcOptPwrDiffL2_03_Ax4 = 0;
                    EPV_CalcProcGainL2_03_Ax4 = 0;
                    EPV_CalcProcGainL2_7_Ax4 = 0;
                    EPV_CalcProcGainL2_1_Ax4 = 0;

                    EPV = false;
                    EPVx = false;
                    EPVx1 = false;
                    EPVx1x7 = false;
                    EPVx1x1 = false;
                    EPVx1x03 = false;

                    EPVx2 = false;
                    EPVx2x7 = false;
                    EPVx2x1 = false;
                    EPVx2x03 = false;

                    EPVx3 = false;
                    EPVx3x7 = false;
                    EPVx3x1 = false;
                    EPVx3x03 = false;

                    EPVx4 = false;
                    EPVx4x7 = false;
                    EPVx4x1 = false;
                    EPVx4x03 = false;

                    AD = false;
                    ADdone = false;

                    DA = false;
                    DAdone = false;
                    DAmeasD = false;

                    DNAC = false;
                    DNACdnac = false;
                    DNACdone = false;

                    DNACx1x = false;
                    DNACx2x = false;
                    DNACx3x = false;
                    DNACx4x = false;

                    LIN = false;
                    LINdone = false;

                    LINx1x = false;
                    LINx2x = false;
                    LINx3x = false;
                    LINx4x = false;

                    DArf1 = false;
                    DArf2 = false;
                    DAms1 = false;
                    DAms2 = false;
                    DAms3 = false;
                    DAms4 = false;

                    SSI_1_MeasPower_Ax1 = 0;
                    SSI_1_SSI_Average_Ax1 = 0;
                    SSI_60_MeasPower_Ax1 = 0;
                    SSI_60_SSI_Average_Ax1 = 0;
                    SSI_138_MeasPower_Ax1 = 0;
                    SSI_138_SSI_Average_Ax1 = 0;
                    SSI_1_MeasPower_Ax2 = 0;
                    SSI_1_SSI_Average_Ax2 = 0;
                    SSI_60_MeasPower_Ax2 = 0;
                    SSI_60_SSI_Average_Ax2 = 0;
                    SSI_138_MeasPower_Ax2 = 0;
                    SSI_138_SSI_Average_Ax2 = 0;
                    SSI_1_MeasPower_Ax3 = 0;
                    SSI_1_SSI_Average_Ax3 = 0;
                    SSI_60_MeasPower_Ax3 = 0;
                    SSI_60_SSI_Average_Ax3 = 0;
                    SSI_138_MeasPower_Ax3 = 0;
                    SSI_138_SSI_Average_Ax3 = 0;
                    SSI_1_MeasPower_Ax4 = 0;
                    SSI_1_SSI_Average_Ax4 = 0;
                    SSI_60_MeasPower_Ax4 = 0;
                    SSI_60_SSI_Average_Ax4 = 0;
                    SSI_138_MeasPower_Ax4 = 0;
                    SSI_138_SSI_Average_Ax4 = 0;
                    SSIx1x = false;
                    SSIx2x = false;
                    SSIx3x = false;
                    SSIx4x = false;

                    DNAChp_388_Std_Dev_Ax1 = 0;
                    DNAChp_388_Std_Dev_Ax2 = 0;
                    DNAChp_388_Std_Dev_Ax3 = 0;
                    DNAChp_388_Std_Dev_Ax4 = 0;
                    DNAChp_3001_Std_Dev_Ax1 = 0;
                    DNAChp_3001_Std_Dev_Ax2 = 0;
                    DNAChp_3001_Std_Dev_Ax3 = 0;
                    DNAChp_3001_Std_Dev_Ax4 = 0;
                    DNAChp_3612_Std_Dev_Ax1 = 0;
                    DNAChp_3612_Std_Dev_Ax2 = 0;
                    DNAChp_3612_Std_Dev_Ax3 = 0;
                    DNAChp_3612_Std_Dev_Ax4 = 0;
                    DNAChpx1 = false;
                    DNAChpx2 = false;
                    DNAChpx3 = false;
                    DNAChpx4 = false;
                    DNACdnac_Test_Result = null;
                    DNACdnacHP_Test_Result = null;
                    DNAC = false;
                    DNACdnacHP = false;
                    DNACdnacHPdone = false;

                    LL_Test_Result = null;
                    LLhp_Test_Result = null;
                    LLhp_2_Rms_Error_Ax1 = 0;
                    LLhp_2_Rms_Error_Ax2 = 0;
                    LLhp_2_Rms_Error_Ax3 = 0;
                    LLhp_2_Rms_Error_Ax4 = 0;

                    LLhpx1x = false;
                    LLhpx2x = false;
                    LLhpx3x = false;
                    LLhpx4x = false;
                    LLhp = false;
                    LLhpDone = false;
                    LLdone = false;

                    Reason4Test = null;
                }
            }
            else
            {
                SqlError = "File Name can not be found.  line 332";
            }

            return SqlError;
        }

        private static void processLine(string tag, string ending, string s)
        {
            int taglength = tag.Length;
            int find = s.IndexOf(tag) + 1;
            int end = s.IndexOf(ending) - 1;
            int error = s.IndexOf("*");
            if (error > 0 && error < end)
            {
                end = error;
            }
            error = 0;
            start = find + taglength;
            length = end - start;
        }

        private static void feedData(string sql, string section)
        {
            SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL11; user = ReadWrite; " +
                "password = Read+Write!; database = productioncontrol;");

            SqlCommand cmd = new SqlCommand(sql, cnxn);

            try
            {
                cnxn.Open();
                int rr = cmd.ExecuteNonQuery();
                if (rr == 1)
                {
                    SqlError = "";
                }
            }
            catch (SqlException ex)
            {
                SqlError = "";
                SqlError = "Problem in " + section + "." + Environment.NewLine +
                    Environment.NewLine + ex.ToString();
                //MessageBox.Show(SqlError);
                if (section != "file header")
                {
                    cmd = new SqlCommand("Delete from [test data] where " +
                        "[XML File Name] = '" + fileName + "'", cnxn);
                    cmd.ExecuteNonQuery();
                }

            }
            finally
            {
                cnxn.Close();
            }

        }
    }
}