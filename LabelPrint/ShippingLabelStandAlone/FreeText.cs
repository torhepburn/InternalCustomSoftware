using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace ShippingLabelUSA
{
    public partial class FreeText : Form
    {
        private string Rev;
        private string Qty;
        private string Part;
        private string SN;
        private string line1;
        private string line2;
        private string line3;
        private string labelQuantity;
        private int firstLastIndex;
        private int secondLastIndex;

        public FreeText()
        {
            InitializeComponent();
        }

        private void FreeText_Load(object sender, EventArgs e)
        {
            tbPartNumber.Focus();
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            g.iRevision = tbRevision.Text.Trim().ToUpper();

            if (g.iRevision.Length > 0)
            {
                Rev = "REV: " + g.iRevision;
            }
            else
            {
                Rev = "REV:";
            }

            if (int.Parse(tbNumberOfBoxes.Text.Trim()) == 1)
            {
                Part = "Part: 1 of 1";
                printLabel();
            }

            if (int.Parse(tbNumberOfBoxes.Text.Trim()) == 2)
            {
                Part = "Part: 1 of 2";
                printLabel();
                Part = "Part: 2 of 2"; ;
                printLabel();
            }

            if (int.Parse(tbNumberOfBoxes.Text.Trim()) == 3)
            {
                Part = "Part: 1 of 3";
                printLabel();
                Part = "Part: 2 of 3";
                printLabel();
                Part = "Part: 3 of 3";
                printLabel();
            }

            if (int.Parse(tbNumberOfBoxes.Text.Trim()) == 4)
            {
                Part = "Part: 1 of 4";
                printLabel();
                Part = "Part: 2 of 4";
                printLabel();
                Part = "Part: 3 of 4";
                printLabel();
                Part = "Part: 4 of 4";
                printLabel();
            }

            if (int.Parse(tbNumberOfBoxes.Text.Trim()) == 5)
            {
                Part = "Part: 1 of 5";
                printLabel();
                Part = "Part: 2 of 5";
                printLabel();
                Part = "Part: 3 of 5";
                printLabel();
                Part = "Part: 4 of 5";
                printLabel();
                Part = "Part: 5 of 5";
                printLabel();
            }

            if (int.Parse(tbNumberOfBoxes.Text.Trim()) == 6)
            {
                Part = "Part: 1 of 6";
                printLabel();
                Part = "Part: 2 of 6";
                printLabel();
                Part = "Part: 3 of 6";
                printLabel();
                Part = "Part: 4 of 6";
                printLabel();
                Part = "Part: 5 of 6";
                printLabel();
                Part = "Part: 6 of 6";
                printLabel();
            }

            if (int.Parse(tbNumberOfBoxes.Text.Trim()) == 7)
            {
                Part = "Part: 1 of 7";
                printLabel();
                Part = "Part: 2 of 7";
                printLabel();
                Part = "Part: 3 of 7";
                printLabel();
                Part = "Part: 4 of 7";
                printLabel();
                Part = "Part: 5 of 7";
                printLabel();
                Part = "Part: 6 of 7";
                printLabel();
                Part = "Part: 7 of 7";
                printLabel();
            }

            if (int.Parse(tbNumberOfBoxes.Text.Trim()) == 8)
            {
                Part = "Part: 1 of 8";
                printLabel();
                Part = "Part: 2 of 8";
                printLabel();
                Part = "Part: 3 of 8";
                printLabel();
                Part = "Part: 4 of 8";
                printLabel();
                Part = "Part: 5 of 8";
                printLabel();
                Part = "Part: 6 of 8";
                printLabel();
                Part = "Part: 7 of 8";
                printLabel();
                Part = "Part: 8 of 8";
                printLabel();
            }

            if (int.Parse(tbNumberOfBoxes.Text.Trim()) == 9)
            {
                Part = "Part: 1 of 9";
                printLabel();
                Part = "Part: 2 of 9";
                printLabel();
                Part = "Part: 3 of 9";
                printLabel();
                Part = "Part: 4 of 9";
                printLabel();
                Part = "Part: 5 of 9";
                printLabel();
                Part = "Part: 6 of 9";
                printLabel();
                Part = "Part: 7 of 9";
                printLabel();
                Part = "Part: 8 of 9";
                printLabel();
                Part = "Part: 9 of 9";
                printLabel();
            }

            if (int.Parse(tbNumberOfBoxes.Text.Trim()) == 10)
            {
                Part = "Part: 1 of 10";
                printLabel();
                Part = "Part: 2 of 10";
                printLabel();
                Part = "Part: 3 of 10";
                printLabel();
                Part = "Part: 4 of 10";
                printLabel();
                Part = "Part: 5 of 10";
                printLabel();
                Part = "Part: 6 of 10";
                printLabel();
                Part = "Part: 7 of 10";
                printLabel();
                Part = "Part: 8 of 10";
                printLabel();
                Part = "Part: 9 of 10";
                printLabel();
                Part = "Part: 10 of 10";
                printLabel();
            }

            tbSN.Text = string.Empty;
            tbPartNumber.Text = string.Empty;
            tbDescription.Text = string.Empty;
            tbRevision.Text = string.Empty;
        }

        private void printLabel()
        {
            g.item = tbPartNumber.Text.Trim();
            g.iDescription = tbDescription.Text.ToUpper().Trim();

            Qty = "Qty: " + tbQty.Text.ToString().Trim();
            SN = tbSN.Text.ToString().Trim();

            int descriptionLength = g.iDescription.Length;

            if (descriptionLength < 15)
            {
                line1 = g.iDescription.Trim();
                line2 = "";
                line3 = "";
            }
            else   /*   description length is greater than 14   */
            {
                //if (g.iDescription.IndexOf(" ") != -1)
                //{
                //if (descriptionLength > 14)
                //{
                string a = g.iDescription.Substring(0, 14);

                if (a.LastIndexOf(",") != -1)
                {
                    firstLastIndex = a.LastIndexOf(",");
                    line1 = g.iDescription.Substring(0, firstLastIndex + 1);
                }
                else if (a.LastIndexOf(" ") != -1)
                {
                    firstLastIndex = a.LastIndexOf(" ");
                    line1 = g.iDescription.Substring(0, firstLastIndex);
                }
                else
                {
                    line1 = g.iDescription.Substring(0, 14);
                    firstLastIndex = 13;
                }
                //}

                if (g.iDescription.Substring(firstLastIndex + 1, descriptionLength - (firstLastIndex + 1)).Length > 14)
                {
                    string b = g.iDescription.Substring(firstLastIndex + 1, 14);

                    if (b.LastIndexOf(",") != -1)
                    {
                        secondLastIndex = b.LastIndexOf(",");
                        line2 = g.iDescription.Substring(firstLastIndex + 1, secondLastIndex + 1);
                    }
                    else if (b.LastIndexOf(" ") != -1)
                    {
                        secondLastIndex = b.LastIndexOf(" ");
                        line2 = g.iDescription.Substring(firstLastIndex + 1, secondLastIndex);
                    }
                    else if (b.ToUpper().LastIndexOf("X") != -1)
                    {
                        secondLastIndex = b.ToUpper().LastIndexOf("X");
                        line2 = g.iDescription.Substring(firstLastIndex + 1, secondLastIndex);
                    }
                    else
                    {
                        secondLastIndex = 13;
                        line2 = b;
                    }

                    if (line2.Substring(0, 1) == " ")
                    {
                        line2 = line2.Trim();
                    }
                }
                else
                {
                    line2 = g.iDescription.Substring(firstLastIndex + 1, descriptionLength - (firstLastIndex + 1));
                    secondLastIndex = -1;
                }

                if (secondLastIndex != -1)
                {
                    line3 = g.iDescription.Substring(firstLastIndex + secondLastIndex + 2, descriptionLength -
                            (firstLastIndex + secondLastIndex + 2));

                    if (line3.Substring(0, 1) == " ")
                    {
                        line3 = line3.Trim();
                    }
                }
                else
                {
                    line3 = "";
                }

                if (line1.Length > 14 | line2.Length > 14 | line3.Length > 14)
                {
                    line1 = g.iDescription.Substring(0, 14);

                    if (descriptionLength > 28)
                    {
                        line2 = g.iDescription.Substring(14, 14);
                    }
                    else  //( descriptionLength <= 28 )
                    {
                        line2 = g.iDescription.Substring(14, descriptionLength - 14);
                    }

                    if (descriptionLength > 28)
                    {
                        line3 = g.iDescription.Substring(28, descriptionLength - 28);
                    }
                }

                if (line1.Length > 0)
                {
                    line1 = line1.Replace("\"", "\\\"");
                }

                if (line2.Length > 0)
                {
                    line2 = line2.Replace("\"", "\\\"");
                }

                if (line3.Length > 0)
                {
                    line3 = line3.Replace("\"", "\\\"");
                }

            }
            labelQuantity = tbLabelQuantity.Text.Trim();

            Bitmap bzp = Properties.Resources.zygo_blk_noR_132;
            Bitmap bxp = Properties.Resources.ametek_blk_noR_132;

            /*
             *  Add the image to the resources folder or elsewhere, then add the file to the
             *  resourses.resx file and it will take in the file and reclassify it as an image.
             *  It should then be available under properties.resources - the case does matter for 
             *  the image name.
             */


            string str = "\nN\nq609Q203,20\n";
            str += SendImageToPrinter(10, 10, bzp);
            str += SendImageToPrinter(450, 10, bxp);
            str += "A144,10,0,2,1,1,N,\"21 Laurel Brook Road\"\n";
            str += "A144,35,0,2,1,1,N,\"Middlefield, CT 06455 USA\"\n";
            str += "A10,70,0,2,1,1,N,\"PN#\"\n";
            str += "B50,65,0,1,2,4,32,B,\"" + g.item + "\"\n";
            str += "A420,60,0,2,1,1,N,\"" + line1 + "\"\n";
            str += "A420,80,0,2,1,1,N,\"" + line2 + "\"\n";
            str += "A420,100,0,2,1,1,N,\"" + line3 + "\"\n";
            str += "A10,140,0,2,1,1,N,\"SN#\"\n";
            str += "B50,135,0,1,2,4,32,B,\"" + SN + "\"\n";
            str += "A290,135,0,2,1,1,N,\"MADE IN\"\n";
            str += "A420,125,0,2,1,1,N,\"" + Rev + "\"\n";
            str += "A315,160,0,2,1,1,N,\"USA\"\n";
            str += "A420,150,0,2,1,1,N,\"" + Qty + "\"\n";
            str += "A420,175,0,2,1,1,N,\"" + Part + "\"\n";
            str += "P" + labelQuantity + "\n";
            RawPrinterHelper.SendStringToPrinter(g.printer, str);

            /**/


            //StringBuilder ZplBuilder = new StringBuilder();

            //// Exemple ZPL String
            ////ZplBuilder.Append("~WC");   //prints configuration label

            ////ZplBuilder.Append("~JC");   //set mdeia sensor calibration
            ////ZplBuilder.Append("~WC");

            //ZplBuilder.Append("^XA");   //Start ZPL

            ///*  shipping label logo size    */
            //ZplBuilder.Append("^FO20, 50 ^GFA, 578, 578, 17, 3KFE01FE3F1FE03FC, 7LF01FEFFDFE1IF, 7LF03LFE3IFC, 7LF03LFEJFE, 7LF83LFEKF, 7LF87RF, 007FF7F87IFC7JF1FF8, 00FFE3FC7IF83IFE0FF8, 01FFC3FC7IF83IFC07F8, 03FF83FCJF83IFC07F8, 03FF01FEFEFF83IFC07FC, 07FE01FEFEFF83IFC07F8, 0FFC00IFEFF83IFC07F8, 1FF800IFC7F83IFC07F8, 3FFI07FFC7LFE0FF8, 7JF87FFC7MF1FF, KF87FF83PF, KF83FF81JFEJFE, KF83FF80JFE7IFC, KF81FF007F3FE3IF8, 7JF81FFJ03FE0FFE, L01FEJ03FE01F, L01FE0FF83FE, K07FFE07FC7FC, K07FFC07JFC, K07FFC07JF8, K07FF803JF8, K07FF001IFE, K07FCI07FFC,,::gSF,:^FS");
            //ZplBuilder.Append("^FO740,50^GFA,357,357,17,,001,003801FF807FCJFDJFEJFDFE1FC,003801FF80FFCJFDJFEJFDFE3F8,007C01FFC0FFCJFDJFEJFDFE7F,007E01FFC1FFCJFDJFEJFDFEFE,00FE01FFE1FFCJFDJFEJFDIFE,00FF01FFE3FFCFEJ03F80FE001IFC,00FF01IF3FFCJFC03F80JFDIF8,007F81IF7FFCJFC03F80JFDIF,007F81LFCJFC03F80JFDIF8,003FC1LFCJFC03F80JFDIF8,003FC1LFCJFC03F80JFDIFC,001FE1JFEFCFEJ03F80FE001IFE,0FEFF1FDFFCFCFEJ03F80FE001IFE,1FCFF1FDFFCFCJF803F80JF9FEFF,1FC7F9FCFFCFCJFC03F80JFDFE7F8,3F87F9FCFF8FCJFC03F80JFDFE7FC,3F83FDFC7F8FCJFC03F80JFDFE3FC,7F03FDFC7F0FCJFC03F80JFDFE3FE,7E01IFC3F0FC7IF803F007IF8FC1FE,^FS");

            ///*  text ^A font, orientation, height, width(dots)
            // *  barcode = code 128
            // */
            //ZplBuilder.Append("^FO170,40^A0N,30,50^FD21 Laurel Brook Road^FS");
            //ZplBuilder.Append("^FO170,70^A0N,30,50^FDMiddlefield, CT 06455 USA^FS");
            //ZplBuilder.Append("^FO20,120^A0N,35,35^FDPN#^FS");
            //ZplBuilder.Append("^FO90,170^A0N,35,50^FD").Append(tbPartNumber.Text.Trim()).Append("^FS");
            //ZplBuilder.Append("^FO90,110^BCN,50,N^FD").Append(tbPartNumber.Text.Trim()).Append("^FS");

            //ZplBuilder.Append("^FO20,220^A0N,35,35^FDSN#^FS");
            //ZplBuilder.Append("^FO90,270^A0N,35,50^FD").Append(tbSN.Text.Trim()).Append("^FS");
            //ZplBuilder.Append("^FO90,210^BCN,50,N^FD").Append(tbSN.Text.Trim()).Append("^FS");

            //ZplBuilder.Append("^FO650,110^A0N,30,30^FD").Append(line1).Append("^FS");
            //ZplBuilder.Append("^FO650,142^A0N,30,30^FD").Append(line2).Append("^FS");
            //ZplBuilder.Append("^FO650,174^A0N,30,30^FD").Append(line3).Append("^FS");
            //ZplBuilder.Append("^FO650,206^A0N,30,30^FD").Append(Rev).Append("^FS");
            //ZplBuilder.Append("^FO650,238^A0N,30,30^FD").Append(Qty).Append("^FS");
            //ZplBuilder.Append("^FO650,270^A0N,30,30^FD").Append(Part).Append("^FS");


            //ZplBuilder.Append("^XZ");

            //string ZplString = ZplBuilder.ToString();

            //MemoryStream lmemStream = new MemoryStream();

            //StreamWriter lstreamWriter = new StreamWriter(lmemStream);
            //lstreamWriter.Write(ZplString);
            //lstreamWriter.Flush();
            //lmemStream.Position = 0;

            //byte[] byteArray = lmemStream.ToArray();

            //IntPtr cpUnmanagedBytes = new IntPtr(0);
            //int cnLength = byteArray.Length;
            //cpUnmanagedBytes = Marshal.AllocCoTaskMem(cnLength);
            //Marshal.Copy(byteArray, 0, cpUnmanagedBytes, cnLength);

            //RawPrinterHelper.SendBytesToPrinter(g.printer, cpUnmanagedBytes, cnLength);
            //Marshal.FreeCoTaskMem(cpUnmanagedBytes);


            /**/
        }

        private static string SendImageToPrinter(int top, int left, System.Drawing.Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms, Encoding.ASCII))
            {
                //we set p3 parameter, remember it is Width of Graphic in bytes,
                //so we divive the width of image and round up of it
                int P3 = (int)Math.Ceiling((double)bitmap.Width / 8);
                bw.Write(Encoding.ASCII.GetBytes(string.Format
                ("GW{0},{1},{2},{3},", top, left, P3, bitmap.Height)));
                //the width of matrix is rounded up multi of 8
                int canvasWidth = P3 * 8;
                //Now we convert image into 2 dimension binary matrix by 2 for loops below,
                //in the range of image, we get colour of pixel of image,
                //calculate the luminance in order to set value of 1 or 0
                //otherwise we set value to 1
                //Because P3 is set to byte (8 bits), so we gather 8 dots of this matrix,
                //convert into a byte then write it to memory by using shift left operator <<
                //e,g 1 << 7  ---> 10000000
                //    1 << 6  ---> 01000000
                //    1 << 3  ---> 00001000
                for (int y = 0; y < bitmap.Height; ++y)     //loop from top to bottom
                {
                    for (int x = 0; x < canvasWidth;)       //from left to right
                    {
                        byte abyte = 0;
                        for (int b = 0; b < 8; ++b, ++x)     //get 8 bits together and write to memory
                        {
                            int dot = 1;                     //set 1 for white,0 for black
                            //pixel still in width of bitmap,
                            //check luminance for white or black, out of bitmap set to white
                            if (x < bitmap.Width)
                            {
                                System.Drawing.Color color = bitmap.GetPixel(x, y);
                                int luminance = (int)((color.R * 0.3) + (color.G * 0.59) + (color.B * 0.11));
                                dot = luminance > 127 ? 1 : 0;
                            }
                            abyte |= (byte)(dot << (7 - b)); //shift left,
                            //then OR together to get 8 bits into a byte
                        }
                        bw.Write(abyte);
                    }
                }
                bw.Write("\n");
                bw.Flush();
                //reset memory
                ms.Position = 0;
                //get encoding, I have no idea why encode page of 1252 works and fails for others
                return Encoding.GetEncoding(1252).GetString(ms.ToArray());
            }
        }

        public class RawPrinterHelper
        {
            // Structure and API declarions:
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public class DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDocName;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pOutputFile;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDataType;
            }
            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

            [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

            // SendBytesToPrinter()
            // When the function is given a printer name and an unmanaged array
            // of bytes, the function sends those bytes to the print queue.
            // Returns true on success, false on failure.
            public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
            {
                Int32 dwError = 0, dwWritten = 0;
                IntPtr hPrinter = new IntPtr(0);
                DOCINFOA di = new DOCINFOA();
                bool bSuccess = false; // Assume failure unless you specifically succeed.

                di.pDocName = "My C#.NET RAW Document";
                di.pDataType = "RAW";

                // Open the printer.
                if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                {
                    // Start a document.
                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                        // Start a page.
                        if (StartPagePrinter(hPrinter))
                        {
                            // Write your bytes.
                            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    ClosePrinter(hPrinter);
                }
                // If you did not succeed, GetLastError may give more information
                // about why not.
                if (bSuccess == false)
                {
                    dwError = Marshal.GetLastWin32Error();
                }
                return bSuccess;
            }

            public static bool SendFileToPrinter(string szPrinterName, string szFileName)
            {
                // Open the file.
                FileStream fs = new FileStream(szFileName, FileMode.Open);
                // Create a BinaryReader on the file.
                BinaryReader br = new BinaryReader(fs);
                // Dim an array of bytes big enough to hold the file's contents.
                Byte[] bytes = new Byte[fs.Length];
                bool bSuccess = false;
                // Your unmanaged pointer.
                IntPtr pUnmanagedBytes = new IntPtr(0);
                int nLength;

                nLength = Convert.ToInt32(fs.Length);
                // Read the contents of the file into the array.
                bytes = br.ReadBytes(nLength);
                // Allocate some unmanaged memory for those bytes.
                pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
                // Copy the managed byte array into the unmanaged array.
                Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
                // Send the unmanaged bytes to the printer.
                bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
                // Free the unmanaged memory that you allocated earlier.
                Marshal.FreeCoTaskMem(pUnmanagedBytes);
                return bSuccess;
            }
            public static bool SendStringToPrinter(string szPrinterName, string szString)
            {
                IntPtr pBytes;
                Int32 dwCount;
                // How many characters are in the string?
                dwCount = (szString.Length + 1) * Marshal.SystemMaxDBCSCharSize;
                // Assume that the printer is expecting ANSI text, and then convert
                // the string to ANSI text.
                pBytes = Marshal.StringToCoTaskMemAnsi(szString);
                // Send the converted ANSI string to the printer.
                SendBytesToPrinter(szPrinterName, pBytes, dwCount);
                Marshal.FreeCoTaskMem(pBytes);
                return true;
            }








        }


        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
