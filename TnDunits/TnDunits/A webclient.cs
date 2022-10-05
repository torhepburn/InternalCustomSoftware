using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace TnDunits
{
    public partial class A_webclient : Form
    {
        public A_webclient()
        {
            InitializeComponent();
        }

        private void A_webclient_Load(object sender, EventArgs e)
        {
            //using (WebClient client = new WebClient())
           // {
                WebClient client = new WebClient();    
                //string html = client.DownloadString("http://128.1.10.79/current.inc");
                //string html = client.DownloadString("http://128.1.9.225/B/wscacdatatable.htm");
                string html = client.DownloadString("http://128.1.9.225/index.wcr");
                //int r = html.IndexOf("D20");
                //string data = html.Substring((html.IndexOf("D20")+8), 76);
                //byte[] binaryData;
                //binaryData = System.Convert.FromBase64String(data);

                //int T1 = binaryData[26];
                //int T2 = binaryData[27];

                //string THex1 = T1.ToString("x");
                //string THex2 = T2.ToString("x");
                //string T3 = THex2 + THex1;
                //int T4 = Int16.Parse(T3, System.Globalization.NumberStyles.HexNumber);
                //T4 = T4 - 1000;
                //double T5 = T4 * 1.8 + 320;
                //T5 = Math.Abs(T5);
                //string T5A = Convert.ToString(Math.Floor(Convert.ToDecimal(T5) / 10));
                //string T5B = Convert.ToString(Math.Floor(Convert.ToDecimal(T5 % 10)));
                //string T6 = T5A + "." + T5B;

                //int H1 = binaryData[42];
                //int H2 = binaryData[43];

                //string hex1 = H1.ToString("x");
                //string hex2 = H2.ToString("x");
                //string H3 = hex2 + hex1;
                //int H4 = Int16.Parse(H3, System.Globalization.NumberStyles.HexNumber);
                //int H5 = H4 - 1000;
                //H5 = Math.Abs(H5);
                //H5 = Convert.ToInt16(Math.Floor(Convert.ToDecimal(H5) / 10)) ;

           // }


                //string aaa = "this";
                
                //var c = b + a;

                //File.AppendAllText(@"C:\a\24.txt",binaryData[14].ToString() );
                File.AppendAllText(@"C:\a\225.txt",html );

                //var str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                // Get the Unicode value of the character that is at position n.
                //var n = str.charCodeAt(10);
                //int c1;
                //Int16 c1;
                //Int16 c2;
                //Int16 c3;
                //Int16 c4;
                

                //string[] base64DecodeChars = new string[]{"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", 
                //"-1", "-1", "-1", "-1","-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1",
                //"-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1",
                //"-1", "-1", "-1", "-1", "-1", "62", "-1", "-1", "-1", "63", "52", "53", "54", "55", 
                //"56", "57", "58", "59", "60", "61", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "0", "1",
                //"2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", 
                //"18", "19", "20", "21", "22", "23", "24", "25", "-1", "-1", "-1", "-1", "-1", "-1", "26",
                //"27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", 
                //"42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "-1", "-1", "-1", "-1", "-1"};

                
//var base64DecodeChars=new Array(-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,62,-1,-1,-1,63,52,53,54,55,56,57,58,59,60,61,-1,-1,-1,-1,-1,-1,-1,0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,-1,-1,-1,-1,-1,-1,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,-1,-1,-1,-1,-1)

                //Int16[] base64DecodeChars = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
                //                                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
                //                                -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 62, -1, -1, -1, 63, 
                //                                52, 53, 54, 55, 56, 57, 58, 59, 60, 61, -1, -1, -1, -1, -1, -1, 
                //                                -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 
                //                                18, 19, 20, 21, 22, 23, 24, 25, -1, -1, -1, -1, -1, -1, 26, 27, 28, 
                //                                29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 
                //                                46, 47, 48, 49, 50, 51, -1, -1, -1, -1, -1 };
                
                //while (i < len)
                //{
                //    byte[] aa = Encoding.Unicode.GetBytes(html.Substring(i++, 1));
                //    c1 = base64DecodeChars[aa[0]];


                //    while (i < len && c1 == -1)
                //        if (c1 == -1)
                //        {
                //            break;
                //        }

                //    aa = Encoding.Unicode.GetBytes(html.Substring(i++, 1));
                //    c2 = base64DecodeChars[aa[0]];

                //    while (i < len && c2 == -1)
                //    {
                //        if (c2 == -1)
                //        {
                //            break;
                //        }
                //    }

                //    aa = Encoding.Unicode.GetBytes(html.Substring(i++, 1));
                //    c3 = base64DecodeChars[aa[0]];

                //    aa = Encoding.Unicode.GetBytes(html.Substring(i++, 1));
                //    c4 = base64DecodeChars[aa[0]];
                    
                //}

                

                
                 

            
        }
    }
}
