using Microsoft.VisualBasic.Logging;
using Mtb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System;
using Microsoft.Data.SqlClient;

namespace MinitabGraphTEST
{
    public partial class Form1 : Form
    {
        SqlCommand cmd;
        SqlConnection cnxn;

        private string[] graph = new string[200];
        private string[] test = new string[200];
        private string[] report = new string[500];
        private int[] promVers = new int[3];
        private string boardType ="4004";
        private string company = "Zygo";
        private string Purpose = "MCert";
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

        private string gClose = "jpeg." + Environment.NewLine;
        //"Replace." + Environment.NewLine +
        //"gman;" + Environment.NewLine +     
        //"Close." + Environment.NewLine;


        private string wClose = "Worksheet;" + Environment.NewLine +
                                "Current;" + Environment.NewLine +
                                "Close;" + Environment.NewLine +
                                "NoPrompt." + Environment.NewLine;


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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cnxn = new SqlConnection
                ("server = CT-MID-SQL11.ametek.com; user = ReadWrite; password = Read+Write!; " +
                 "database = productioncontrol");
            
            string odb1 = @"ODBC; Connect ""Description=ProductionControl;DRIVER=SQL Server;WSID=MIDWS0167;"" &" + Environment.NewLine +
                          @"""SERVER=CT-MID-SQL11.ametek.com;UID=views;PWD=views;APP=Minitab Release 21;""&" + Environment.NewLine +
                          @"""DATABASE=ProductionControl"";" + Environment.NewLine +
                          @"SQLString ""Select sn, [its build number], [Test Date], iteration, "" &" + Environment.NewLine +
                          @""" [board promver], "" &" + Environment.NewLine;

            /*
             * @"""SERVER=CT-MID-SQL11.ametek.com;UID=views;PWD=views;APP=Minitab Release 21;WSID=MIDWS0167;""&" + Environment.NewLine +
            string text = File.ReadAllText("PCCconfigFile.txt");
            text = text.Substring(text.IndexOf("=") + 1, text.Length - (text.IndexOf("=") + 1));
            string savePath = @"Gsave " + text +
                Purpose + @"\" + company + @"\";*/

            //string savePath = @"GSAVE ""\\midfile01.ametek.com\departments\pps\manufacturing\control charts\" +
              //  Purpose + @"\" + company + @"\";
            string savePath = @"GSAVE ""C:\A\";


            
                savePath = savePath + @"4004\ ";

                 /*  ZYGO   */
                
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

                test[97] = "SSI CAL 1 SSI Avg Ax4";

                graph[97] = "Worksheet;" + Environment.NewLine +
                                            "Current;" + Environment.NewLine +
                                            "Close.";
                
                Mtb.Application Mtap = new Mtb.Application();
                Mtb.Project Mtab = Mtap.ActiveProject;
                Mtb.UserInterface mtbUI = Mtap.UserInterface;
                mtbUI.Visible = true;
                //mtbUI.DisplayAlerts = true;

                /*File.WriteAllText(savePath.Substring(7) + " Failure Report.txt", "Failure Report" +
                    Environment.NewLine + Environment.NewLine);
                    
                File.WriteAllText(savePath.Substring(6) + " Failure Report.txt", "Failure Report" +
                    Environment.NewLine + Environment.NewLine);*/

                int i = 5;      // i = number of graphs

                // do while the number of graphs is less than one more than the number of graphs


                while (i < 7)
                {
                    string firstCommand = odb1 +
                           @"""[" + test[i] + @"] "" & " + Environment.NewLine +
                           odb2 +
                           @"""and [" + test[i] + @"] is not null "" & " + Environment.NewLine +
                           odb4;


                    Mtab.ExecuteCommand(firstCommand, Type.Missing);

                    
                    //string mTabCountString = Mtab.Commands.OutputDocument.Text;
                    //char[] anyof = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
                    ////int findex = mTabCountString.IndexOfAny(anyof);
                    //int findex = mTabCountString.IndexOf("=") + 2;

                    //int lindex = mTabCountString.LastIndexOfAny(anyof);
                    //string reading = mTabCountString.Substring(findex, (lindex - findex) + 1);
                    //readings = Convert.ToInt32(reading);

                    //int tikCalc = readings / 5;
                    //int tik2 = 2 * tikCalc;
                    //int tik3 = 3 * tikCalc;
                    //int tik4 = 4 * tikCalc;
                    //int tik5 = 5 * tikCalc;
                    //ticks = "tick " +
                    //    tikCalc.ToString() + " " +
                    //    tik2.ToString() + " " +
                    //    tik3.ToString() + " " +
                    //    tik4.ToString() + " " +
                    //    tik5.ToString();
                    
                    //char[] anyof = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
                    Int32 readings = 1;

                    //get board and run from minitab

                    object xx = Mtab.ActiveWorksheet.Columns.Item("sn").GetData(1, readings);   /*  board    */
                    object xy = Mtab.ActiveWorksheet.Columns.Item("iteration").GetData(1, readings);    /*  run    */

                    double[] xx2 = new double[] { Convert.ToDouble(xx) };    /*  new code as below fails  */
                    //double[] xx2 = (double[])xx;
                    string[] temp = Array.ConvertAll(xx2, new Converter<double, string>(double2string));

                    string[] xy2 = new string[] { Convert.ToString(xy) };      /*  new code as below fails  */
                    //string[] xy2 = (string[])xy;
                    string station = ".ZMI-4K-ITS.";
                    
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

                    
                     graph[i] = @"plot '" + test[i] + @"' * 'test date';" + Environment.NewLine +
                         @"Title ""Engineering 4004"";" + Environment.NewLine +
                         @"Title ""Scatterplot of " + test[i] + @""";" + Environment.NewLine +
                         "Connect 'SN';" + Environment.NewLine +
                         "Symbol 'SN';" + Environment.NewLine + graph[i];
                    



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

        private string double2string(double x)
        {
            return x.ToString();
        }

    }
}
