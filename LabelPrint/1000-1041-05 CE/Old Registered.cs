using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;


namespace _1000_1041_05_CE
{
    public partial class Old_Registered : Form
    {
        private string labelQuantity;

        public Old_Registered()
        {
            InitializeComponent();
        }

        private void Old_Registered_Load(object sender, EventArgs e)
        {
            this.Text = "Enter values prior to printing.";

            tbAmps.ReadOnly = false;
            tbDescription.ReadOnly = false;
            tbHertz.ReadOnly = false;
            tbModel.ReadOnly = false;
            tbPartNumber.ReadOnly = false;
            tbVolts.ReadOnly = false;

            tbAmps.BackColor = Color.White;
            tbDescription.BackColor = Color.White;
            tbHertz.BackColor = Color.White;
            tbModel.BackColor = Color.White;
            tbPartNumber.BackColor = Color.White;
            tbVolts.BackColor = Color.White;


        }

        private void bPrint_Click(object sender, EventArgs e)
        {

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
            g.freeText = false;
            this.Close();
        }

        private void bPrint_Click_1(object sender, EventArgs e)
        {
            
        }

        private void bPrint_Click_2(object sender, EventArgs e)
        {
            labelQuantity = "1";

            Bitmap byp = Properties.Resources.CE25;
            Bitmap bzp = Properties.Resources.zygo_blk_R_203;
            Bitmap bxp = Properties.Resources.ametek_blk_noR_132;

            /*
             *  Add the image to the resources folder or elsewhere, then add the file to the
             *  resourses.resx file and it will take in the file and reclassify it as an image.
             *  It should then be available under properties.resources - the case does matter for 
             *  the image name.
             */
            string desc = tbDescription.Text.Replace("\"", "\\\"");
            tbModel.Text = tbModel.Text.Replace("\"", "\\\"");

            //g.printer = "\\\\ct-mid-ps01\\zebrasn48";
            g.printer = "ZDesigner ZD421-203dpi ZPL";


            string str = "\nN\nq456.75Q253.75,20\n";
            //if (g.printer == @"\\CT-MID-PS01\ZEBRASN1" | g.printer == @"\\CT-MID-PS01\ZEBRASN20")
            //{
            str += SendImageToPrinter(20, 15, bzp);
            str += SendImageToPrinter(310, 15, bxp);

            str += SendImageToPrinter(370, 150, byp);
            //str += "A30,85,0,3,1,1,N,\"R®\"\n";
            if (desc.Length > 30)
            {
                str += "A20,85,0,2,1,1,N,\"" + desc + "\"\n";
            }
            else
            {
                str += "A20,85,0,3,1,1,N,\"" + desc + "\"\n";
            }

            //str += "A30,85,0,3,1,1,N,\"DESC.\"\n";
            //str += "A110,85,0,2,1,1,N,\"" + tbDescription.Text.Trim() + "\"\n";
            str += "A20,110,0,3,1,1,N,\"PART#\"\n";
            str += "A100,110,0,3,1,1,N,\"" + tbPartNumber.Text.Trim() + "\"\n";
            str += "A20,135,0,3,1,1,N,\"" + "MODEL" + "\"\n";
            str += "A100,135,0,3,1,1,N,\"" + tbModel.Text.Trim() + "\"\n";
            str += "A20,160,0,3,1,1,N,\"" + "S/N" + "\"\n";
            str += "A80,160,0,3,1,1,N,\"" + tbSerialNumber.Text.Trim() + "\"\n";
            str += "A270,160,0,3,1,1,N,\"Hz\"\n";
            str += "A300,160,0,3,1,1,N,\"" + tbHertz.Text.Trim() + "\"\n";
            str += "A20,185,0,3,1,1,N,\"VOLTS\"\n";
            str += "A100,185,0,3,1,1,N,\"" + tbVolts.Text.Trim() + "\"\n";
            str += "A240,185,0,3,1,1,N,\"AMPS\"\n";
            str += "A310,185,0,3,1,1,N,\"" + tbAmps.Text.Trim() + "\"\n";
            str += "A30,225,0,2,1,1,N,\"MADE IN USA, Middlefield, CT 06455\"\n";
            str += "P" + labelQuantity + "\n";

            RawPrinterHelper.SendStringToPrinter(g.printer, str);

            tbSerialNumber.Text = "";
            tbSerialNumber.Focus();
        }

        private void bExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

