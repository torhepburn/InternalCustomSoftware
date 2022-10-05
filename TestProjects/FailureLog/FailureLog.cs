using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FailureLog
{
    public partial class FailureLog : Form
    {
        private string[,] failureLog = new string[1000, 3];
        private int failLogIndex = 0;

        
        public FailureLog()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            char[] anyof = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

            string x = File.ReadAllText(@"C:\a\4104 testReport.txt");

            if (x.IndexOf("Test Failed") > -1)
            {
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
                        pointStart += digits;
                        failLogIndex += 1;
                        digits = 0;
                    }
                    start += 1;
                }

                string[] xx2 = new string[500];
                    
                xx2[0] = "618042.00018";
                xx2[1] = "618042.00120";
                xx2[2] = "618042.00121";
                xx2[3] = "618042.00123";
                xx2[4] = "618042.00132";
                xx2[5] = "618042.00133";
                xx2[6] = "618042.00139";
                xx2[7] = "618042.00140";
                xx2[8] = "618042.00142";
                xx2[9] = "618042.00152";
                xx2[10] = "618042.00155";
                xx2[11] = "618042.00156";
                xx2[12] = "618042.00158";
                xx2[13] = "618042.00161";
                xx2[14] = "618042.00162";
                xx2[15] = "618042.00163";
                xx2[16] = "618042.00164";
                xx2[17] = "618042.00165";
                xx2[18] = "618042.00167";
                xx2[19] = "618042.00168";
                xx2[20] = "618042.00169";
                xx2[21] = "618042.00171";
                xx2[22] = "618041.00047";
                xx2[23] = "9145386.00022";
                xx2[24] = "9145386.00030";
                xx2[25] = "618041.00083";
                xx2[26] = "9145386.00031";
                xx2[27] = "618041.00084";
                xx2[28] = "618042.00301";
                xx2[29] = "9145386.00032";
                xx2[30] = "618041.00087";

                int xx = 0;
                while (xx < failLogIndex)
                {
                    int find = Convert.ToInt32(failureLog[xx, 1]);

                    failureLog[xx, 2] = xx2[find];

                    xx++;
                }

                //File.AppendAllText(savePath.Substring(7) + " Failure Report.txt", log + "  " + company +
                //        "  " + boardType + "  test " + test[i] + " failed" + Environment.NewLine);

                //File.AppendAllText(savePath.Substring(7) + " Failure Report.txt", x + Environment.NewLine);
                //int n = 0;
                //while (n < readings)
                //{
                //    File.AppendAllText(savePath.Substring(7) + " Failure Report.txt", n + 1 + ", " + xx2[n] +
                //        "." + xy2[n] + Environment.NewLine);
                //    n++;
                //}
                //File.AppendAllText(savePath.Substring(7) + " Failure Report.txt", Environment.NewLine +
                //    "****************************************" +
                //    "****************************************" + Environment.NewLine);
            }
        }
    }
}
