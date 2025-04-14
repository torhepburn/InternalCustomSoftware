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
using System.Runtime.InteropServices;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;

namespace BinCodeLabels
{
    public partial class BinCodeLabels : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        SqlDataReader dr;
        
        public BinCodeLabels()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Bin Code Labels v" + Application.ProductVersion;

            cnxn = new SqlConnection(g.db);
            DataTable dt1;
            dt1 = new DataTable();

            DataTable dt2;
            dt2 = new DataTable();

            try
            {
                cmd = new SqlCommand("select Code from [ZYGO$Bin] WHERE [Location Code] = '" + g.location + "' ORDER BY [Code]", cnxn);

                cnxn.Open();
                dr = cmd.ExecuteReader();

                dt1.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            cbddStartBinCode.DataSource = dt1;
            cbddStartBinCode.DisplayMember = "Code";


            try
            {
                SqlCommand cmd = new SqlCommand("select Code from [ZYGO$Bin] WHERE [Location Code] = '" + g.location + "' ORDER BY [Code]", cnxn);

                cnxn.Open();
                dr = cmd.ExecuteReader();

                dt2.Load(dr);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            cbddEndBinCode.DataSource = dt2;
            cbddEndBinCode.DisplayMember = "Code";
        }


        private void Bprint_Click(object sender, EventArgs e)
        {
            if (tbFreeText.Text.Length == 0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select Code from [ZYGO$Bin] " +
                        "WHERE Code >= '" + cbddStartBinCode.Text + "' AND " +
                        "Code <= '" + cbddEndBinCode.Text + "' " +
                        "AND [Location Code] = '" + g.location + "' " +
                        "ORDER BY [Code]", cnxn);

                    cnxn.Open();
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        if (rb1.Checked)
                        {
                            printLabel(dr.GetString(0));
                        }

                        if (rb2.Checked)
                        {
                            printLabel(dr.GetString(0));
                            printLabel(dr.GetString(0));
                        }

                        if (rb3.Checked)
                        {
                            printLabel(dr.GetString(0));
                            printLabel(dr.GetString(0));
                            printLabel(dr.GetString(0));
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                }
            }
            else
            {
                if (rb1.Checked)
                {
                    printLabel(tbFreeText.Text.Trim());
                }

                if (rb2.Checked)
                {
                    printLabel(tbFreeText.Text.Trim());
                    printLabel(tbFreeText.Text.Trim());
                }

                if (rb3.Checked)
                {
                    printLabel(tbFreeText.Text.Trim());
                    printLabel(tbFreeText.Text.Trim());
                    printLabel(tbFreeText.Text.Trim());
                }

                tbFreeText.Text = string.Empty;
            }
            

        }

        private void printLabel(string label)
        { 
            StringBuilder ZplBuilder = new StringBuilder();


            // Exemple ZPL String

            //ZplBuilder.Append("~WC");   //prints configuration label

            //ZplBuilder.Append("~JC");   //set media sensor calibration

            ////use Zebra Setup Utilities to set label size if can't get to work with code

            /*  MID-QUALITY CLINIC is the longest bin code  */

            /* code for centering the text above Bin Label  */
            decimal l = (decimal)label.Length;
            decimal m = (l/18);
            decimal n = 140;
            decimal o = (m * n);
            int p = (int)Math.Ceiling(o);
            int q = (140 - p);
            int s = 210 + q;

            string r = s.ToString();

            ZplBuilder.Append("^XA");   //Start ZPL

            //barcode
            ZplBuilder.Append("^FO50,40");
            ZplBuilder.Append("^BXN,8,200");
            ZplBuilder.Append("^FD%B%").Append(label);


            ZplBuilder.Append("^FS");
            ZplBuilder.Append("^FS^FO300,140^A0N,40,40^FDBin Code^FS");
            // the box
            //ZplBuilder.Append("^FO0,30^GB450,150,10^FS");


            ZplBuilder.Append("^FS^FO" + r + ",75^A0N,40,40^FD").Append(label).Append("^FS");

            ZplBuilder.Append("^XZ");
            // End ZPL

            string ZplString = ZplBuilder.ToString();

            MemoryStream lmemStream = new MemoryStream();

            StreamWriter lstreamWriter = new StreamWriter(lmemStream);
            lstreamWriter.Write(ZplString);
            lstreamWriter.Flush();
            lmemStream.Position = 0;

            byte[] byteArray = lmemStream.ToArray();

            IntPtr cpUnmanagedBytes = new IntPtr(0);
            int cnLength = byteArray.Length;
            cpUnmanagedBytes = Marshal.AllocCoTaskMem(cnLength);
            Marshal.Copy(byteArray, 0, cpUnmanagedBytes, cnLength);

            try
            {
                RawPrinterHelper.SendBytesToPrinter(@"\\CT-MID-PS01\ZEBRASN17", cpUnmanagedBytes, cnLength);
                //RawPrinterHelper.SendBytesToPrinter("ZDesigner ZD421-203dpi ZPL", cpUnmanagedBytes, cnLength);
            }
            catch 
            { 
            
            }

            //RawPrinterHelper.SendBytesToPrinter(g.printer, cpUnmanagedBytes, cnLength);
            Marshal.FreeCoTaskMem(cpUnmanagedBytes);

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
    }
}
