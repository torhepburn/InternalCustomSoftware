using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace CustomIsaacData
{
    public partial class CustomData : Form
    {
        SqlDataReader dr;
        private string[] files;

        private static int SN;
        private static string Rev;
        private static string BoardType;
        private static string TestStation;
        private static int ITSbuildNumber;
        private static string Iteration;
        private static DateTime TestDate;
        private static int BoardPromVer;

        private static bool AD = false;
        private static bool ADdone = false;

        private static double ADm12V_Analog_PS;
        private static double ADm12V_Analog_PS_Ripple;

        private static double ADp10V_Analog_PS;
        private static double ADp10V_Analog_PS_Ripple;

        private static double ADp15V_Analog_PS;
        private static double ADp15V_Analog_PS_Ripple;

        private static double ADm15V_Analog_PS;
        private static double ADm15V_Analog_PS_Ripple;

        private static int start;
        private static int length;

        //private static string SqlError;
        private static string fileName;

        public CustomData()
        {
            InitializeComponent();
        }

        private void CustomData_Load(object sender, EventArgs e)
        {
            SqlConnection cnxn = new SqlConnection
                ("server = MIDSQL01; password = views; " +
                 "user = views; database = productioncontrol;");
            SqlCommand cmd = new SqlCommand
                ("Select metrologydataid from MIDDB01.Dashboard.dbo.view_metrologymeasurements " +
                 "where serialnumber like 'CC%' and description like 'kit inspection " +
                 "and test results%' ");

            try
            {
                cmd.Connection = cnxn;
                cnxn.Open();
                dr = cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            while (dr.Read())
            {
                string folder = dr.GetInt32(0).ToString();

                string path = @"\\middbweb2012\metrologydocuments\" + folder + @"\";


                try
                {
                    if (Directory.Exists(path))
                    {
                        files = Directory.GetFiles(path, "*.xml");
                        string xfile = files[0];

                        string[] readText = File.ReadAllLines(xfile);


                        foreach (string s in readText)
                        {
                            if (s.Length > 30 && s.Substring(3, 9) == "BoardInfo")
                            {
                                processLine("SN=", "Ven", s);
                                SN = Convert.ToInt32(s.Substring(start, length - 1));
                                processLine("BoardAssyRev=", "PromRev", s);
                                Rev = s.Substring(start, length - 1).Trim();
                                processLine("Type=", "AssyNum", s);
                                BoardType = s.Substring(start, length - 1);
                                //Minitab needs all the 4104s to be the same board type
                                //so I remove the E from the 4104E.
                                if (BoardType.Length == 9)
                                {
                                    BoardType = BoardType.Substring(0, 8);
                                }
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

                                fileName = "CC." + Convert.ToString(SN) + "." + TestStation +
                                    "." + Iteration + ".xml";
                            }

                            if (ADdone == false && AD == false && s.Length > 30)
                            {
                                if (s.Substring(3, 14) == @"Test name=""AD""")
                                {
                                    AD = true;
                                    continue;
                                }
                            }

                            if (ADdone == false && AD == true && s.Length > 130)
                            {
                                if (s.Substring(42, 11) == "-12V Analog")
                                {
                                    processLine("value=", "high", s);
                                    ADm12V_Analog_PS = Convert.ToDouble(s.Substring(start, length - 1));
                                    processLine("ripple=", "status", s);
                                    ADm12V_Analog_PS_Ripple = Convert.ToDouble(s.Substring(start, length - 1));
                                    continue;
                                }

                                if (s.Substring(42, 11) == "+10V Analog")
                                {
                                    processLine("value=", "high", s);
                                    ADp10V_Analog_PS = Convert.ToDouble(s.Substring(start, length - 1));
                                    processLine("ripple=", "status", s);
                                    ADp10V_Analog_PS_Ripple = Convert.ToDouble(s.Substring(start, length - 1));
                                    continue;
                                }

                                if (s.Substring(42, 11) == "+15V Analog")
                                {
                                    processLine("value=", "high", s);
                                    ADp15V_Analog_PS = Convert.ToDouble(s.Substring(start, length - 1));
                                    processLine("ripple=", "status", s);
                                    ADp15V_Analog_PS_Ripple = Convert.ToDouble(s.Substring(start, length - 1));
                                    continue;
                                }

                                if (s.Substring(42, 11) == "-15V Analog")
                                {
                                    processLine("value=", "high", s);
                                    ADm15V_Analog_PS = Convert.ToDouble(s.Substring(start, length - 1));
                                    processLine("ripple=", "status", s);
                                    ADm15V_Analog_PS_Ripple = Convert.ToDouble(s.Substring(start, length - 1));

                                    ADdone = true;
                                    continue;

                                }
                            }
                        }

                        SqlConnection cnxn1 = new SqlConnection("server = midsql01; user = ReadWrite; " +
                       "password = Read+Write!; database = productioncontrol;");

                        string sql = "Insert into dbo.AD_Cirtronics (" +
                                    "[XML File Name], " +
                                    "SN," +
                                    "Rev, " +
                                    "[Board Type], " +
                                    "[ITS Build Number], " +
                                    "[Test Station], " +
                                    "Iteration, " +
                                    "[AD +10V Analog PS], " +
                                    "[AD +10V Analog PS Ripple], " +
                                    "[AD -12V Analog PS], " +
                                    "[AD -12V Analog PS Ripple], " +
                                    "[AD +15V Analog PS], " +
                                    "[AD +15V Analog PS Ripple], " +
                                    "[AD -15V Analog PS], " +
                                    "[AD -15V Analog PS Ripple] " +
                                    ") values ('" +
                                    fileName + "'," +
                                    SN + ",'" +
                                    Rev + "','" +
                                    BoardType + "'," +
                                    ITSbuildNumber + ",'" +
                                    TestStation + "','" +
                                    Iteration + "'," +
                                    ADp10V_Analog_PS + "," +
                                    ADp10V_Analog_PS_Ripple + "," +
                                    ADm12V_Analog_PS + "," +
                                    ADm12V_Analog_PS_Ripple + "," +
                                    
                                    ADp15V_Analog_PS + "," +
                                    ADp15V_Analog_PS_Ripple + "," +
                                    ADm15V_Analog_PS + "," +
                                    ADm15V_Analog_PS_Ripple + ")";

                        SqlCommand cmd1 = new SqlCommand(sql, cnxn1);

                        try
                        {
                            cnxn1.Open();
                            int rr = cmd1.ExecuteNonQuery();

                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            cnxn1.Close();
                        }


                        fileName = null;
                        SN = 0;
                        Rev = null;
                        BoardType = null;
                        ITSbuildNumber = 0;
                        TestStation = null;
                        Iteration = null;
                        BoardPromVer = 0;
                        TestDate = new DateTime();
                        //AD_Test_Result = null;

                        ADm12V_Analog_PS = 0;
                        ADm12V_Analog_PS_Ripple = 0;

                        ADp10V_Analog_PS = 0;
                        ADp10V_Analog_PS_Ripple = 0;

                        ADp15V_Analog_PS = 0;
                        ADp15V_Analog_PS_Ripple = 0;

                        ADm15V_Analog_PS = 0;
                        ADm15V_Analog_PS_Ripple = 0;

                        ADdone = false;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    continue;
                }

            }

       

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

        //remember to zero out variables

    }
}
