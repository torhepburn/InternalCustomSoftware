using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices; 
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Collections;

namespace EPL_Printer
{
    public partial class EPL : Form
    {
        BitArray dots = new BitArray(23556);
        MemoryStream ms;
        BinaryWriter bw;
        BinaryReader br;

        public EPL()
        {
            InitializeComponent();
        }

        private void EPL_Load(object sender, EventArgs e)
        {
            
            // open a blank bitmap 10 x 10
            Bitmap bxp = new Bitmap(10, 10);
            
            //use graphics to put someting into the bitmap
            Graphics xGraphics = Graphics.FromImage(bxp);

            xGraphics.FillRectangle(Brushes.Black, 0, 0, 10, 3);
            xGraphics.FillRectangle(Brushes.White, 0, 3, 10, 4);
            xGraphics.FillRectangle(Brushes.Black, 0, 7, 10, 3);

            //save the bitmap
            bxp.Save(@"C:\A\sq.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            
            //Bitmap bp = new Bitmap(@"c:\a\zygo_blk_noR.bmp");
            pictureBox1.Image = bxp; 

            //open the new bitmap as another bitmap
            Bitmap bp = new Bitmap(@"c:\a\sq.bmp");
            
            
            var dots = new BitArray((bp.Width * bp.Height));
            var index = 0;
            File.WriteAllText(@"C:\a\imageRGB.txt", "");
            File.WriteAllText(@"C:\a\imageBits.txt", "");
      
            for (int w = 0; w < bp.Width; w++)
            {
                for (int h = 0; h < bp.Height; h++)
                {
                    //try
                    //{
                        var color = bp.GetPixel(w, h);
                        //GetPixel doesn't work if you LockBits first
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.ToString());
                    //}
                    
                    File.AppendAllText(@"C:\a\imageRGB.txt",
                        index.ToString() + "    " +
                        color.A.ToString() + "    " + 
                        color.R.ToString() + "    " + 
                        color.G.ToString() + "    " + 
                        color.B.ToString() + Environment.NewLine);
                    
                    
                    dots[index] = color.R < 127;

                    File.AppendAllText(@"C:\a\imageBits.txt", 
                        color.R.ToString() + "    " + 
                        dots[index].ToString() + "    " +
                        index.ToString() + Environment.NewLine);
                    
                    index++;
                }
            }
    
            ms = new MemoryStream();
            bw = new BinaryWriter(ms, Encoding.ASCII);

            Rectangle rct = new Rectangle(0, 0, bp.Width, bp.Height);
            BitmapData bData = bp.LockBits(rct, ImageLockMode.ReadWrite, bp.PixelFormat);
            int dbytes = Math.Abs(bData.Stride) + bp.Height;
            //byte[] bValues = new byte[bytes];


            //bw.Write(Encoding.ASCII.GetBytes(string.Format("GW{0},{1},{2},{3},", top, left, bytes, 78)));

            try
            {

                bw.Write(Encoding.ASCII.GetBytes(string.Format("GW{0},{1},{2},{3},",0,0,dbytes,bp.Height)));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            var bytes = (int)Math.Ceiling((double)bData.Width / 8);  
            var canvasWidth = bytes * 8;

            for (int y = 0; y < bp.Height; ++y)
            {
                for (int x = 0; x < canvasWidth; )
                {
                    byte s = 0;

                    for (int b = 0; b < 8; ++b, ++x)
                    {
                        bool v = false;

                        if (x < bp.Width)
                        {
                            int i = (y * bp.Width) + x;
                            v = dots[i];
                        }

                        s |= (byte)((v ? 0 : 1) << (7 - b));
                    }
                    
                    bw.Write(s);
                    //bw.Write(Encoding.ASCII.GetBytes("12345"));
                }
            }

            bw.Write(Encoding.ASCII.GetBytes(Environment.NewLine));
            
            //FileStream fs = new FileStream(@"C:\a\test1.txt", ms.WriteTo(fs));
            //fs.Close();
            //ms.Close();


            string xxx = Encoding.ASCII.GetString(ms.ToArray());

            
             ASCIIEncoding ascii = new ASCIIEncoding();
            br = new BinaryReader(ms, ascii);
            try
            {
                while (br.PeekChar() != -1)
                {
                    string aa = br.ReadString();
                    File.AppendAllText(@"C:\a\imageBr.txt", aa);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            //BinaryReader br = new BinaryReader(ms);
            
            string xx = "test";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Allow the user to select a file.
            OpenFileDialog ofd = new OpenFileDialog();
            if (DialogResult.OK == ofd.ShowDialog(this))
            {
                // Allow the user to select a printer.
                PrintDialog pd = new PrintDialog();
                pd.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
                
                if (DialogResult.OK == pd.ShowDialog(this))
                {
                    // Print the file to the printer.
                    RawPrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, ofd.FileName);

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string bce= "123456789";
            //string s = "N" + Environment.NewLine; // device-dependent string, need a FormFeed?
            ///*
            //s = s + "A50,25,0,1,1,1,N,\"Example 1\"" + Environment.NewLine;
            //s = s + "A50,50,0,2,1,1,N,\"Example 2\"" + Environment.NewLine;
            //s = s + "A50,100,0,3,1,1,N,\"Example 3\"" + Environment.NewLine;
            //s = s + "A50,150,0,4,1,1,N,\"Example 4\"" + Environment.NewLine;
            ////s = s + "A50,200,0,5,1,1,N,\"Example 5\"" + Environment.NewLine;
            //s = s + "P1" + Environment.NewLine;
            //*/
            ////s = s + "A50,25,0,1,1,1,N,\"Example 1\"" + Environment.NewLine;
            //s = s + "B50,50,0,3,2,8,35,B," + Convert.ToChar(34).ToString() + bce +  Convert.ToChar(34).ToString() +  Environment.NewLine;
            ////s = s + "A50,100,0,3,1,1,N,\"Example 3\"" + Environment.NewLine;
            ////s = s + "A50,150,0,4,1,1,N,\"Example 4\"" + Environment.NewLine;
            ////s = s + "A50,200,0,5,1,1,N,\"Example 5\"" + Environment.NewLine;
            //s = s + "P1" + Environment.NewLine;


            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine();
            //sb.AppendLine("N");
            ////sb.AppendLine("q609");
            ////sb.AppendLine("Q203,26");
            //sb.AppendLine(string.Format(CultureInfo.InvariantCulture,
            //    "B100,100,0,2,2,2,100,B,\"{0}\"","123456"));
            ////sb.AppendLine(string.Format(CultureInfo.InvariantCulture,
            ////sb.AppendLine("B10,10,0,0,3,N,200,B,\"22334455\"" );
            //sb.AppendLine("P1");
            ////sb.AppendLine();

            //// Allow the user to select a printer.
            ////PrintDialog pd = new PrintDialog();
            ////pd.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
            ////if (DialogResult.OK == pd.ShowDialog(this))
            ////{
            //    // Send a printer-specific to the printer.
            //    //RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, sb.ToString());
            //    //RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s);
            //    //RawPrinterHelper.SendStringToPrinter("\\\\midprtsrv\\ZebraSN12", s);
            //RawPrinterHelper.SendStringToPrinter("\\\\midprtsrv\\ZebraRichmond1", s);
            ////}
            string printQuantity = "9";
            

            string str = "\nN\nq609Q203,20\n";
            str += "A60,10,0,3,1,1,N,\"Canon P/N\"\n";
            str += "A270,10,0,3,1,1,N,\"GH0-0559\"\n";
            str += "LO20,30,600,2\n";
            str += "A60,40,0,3,1,1,N,\"Zygo P/N\"\n";
            str += "A270,40,0,3,1,1,N,\"1115-800-279\"\n";
            str += "LO20,60,600,2\n";
            str += "A60,70,0,3,1,1,N,\"Description\"\n";
            str += "A270,70,0,3,1,1,N,\"JC4000/2400\"\n";
            str += "LO20,90,600,2\n";
            str += "A60,100,0,3,1,1,N,\"S/N\"\n";
            //str += "A270,100,0,3,1,1,N,\"" + sn + "\"\n";
            str += "LO20,120,600,2\n";
            str += "LO260,10,2,110\n";
            str += "B50,135,0,1,2,4,32,B,\"1115-800-279\"\n";
            str += "P" + printQuantity + "\n";
            RawPrinterHelper.SendStringToPrinter(@"\\midprtsrv\ZebraSN12", str);

            /*  //D = Dennsity a scale of 1-15 can be set
            str = "\nN\nq100Q50,20\n";
            str += "^@\n";
            //str += "D15\n";
            //str += "P1\n";
            */


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
                    for (int x = 0; x < canvasWidth; )       //from left to right
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
/*
        /// <summary>
        /// Gets a <see cref="BitmapData"/> instace for a given image.
        /// </summary>
        /// <param name="bytes">The image data.</param>
        /// <returns>The <see cref="BitmapData"/> instance.</returns>
        private static BitmapData GetBitmapData(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            using (var bitmap = (Bitmap)Bitmap.FromStream(ms))
            {
                var threshold = 127;
                var index = 0;
                var dimensions = bitmap.Width * bitmap.Height;
                var dots = new BitArray(dimensions);

                for (var y = 0; y < bitmap.Height; y++)
                {
                    for (var x = 0; x < bitmap.Width; x++)
                    {
                        var color = bitmap.GetPixel(x, y);
                        var luminance = (int)((color.R * 0.3) + (color.G * 0.59) + (color.B * 0.11));
                        dots[index] = luminance < threshold;
                        index++;
                    }
                }
                
                return new BitmapData()
                {
                    Dots = dots,
                    Height = bitmap.Height,
                    Width = bitmap.Width
                };
            }
        }

        /// <summary>
        /// Inserts a GW command image.
        /// </summary>
        /// <param name="bw">The binary writer.</param>
        /// <param name="top">The top location.</param>
        /// <param name="left">The left location.</param>
        /// <param name="image">The image bytes.</param>
        private static void InsertImage(BinaryWriter bw, int top, int left, byte[] image)
        {
            var encoding = Encoding.ASCII;
            var data = GetBitmapData(image);
            var dots = data.Dots;
            var bytes = (int)Math.Ceiling((double)data.Width / 8);

            bw.Write(encoding.GetBytes(string.Format("GW{0},{1},{2},{3},", top, left, bytes, data.Height)));

            var imageWidth = data.Width;
            var canvasWidth = bytes * 8;

            for (int y = 0; y < data.Height; ++y)
            {
                for (int x = 0; x < canvasWidth; )
                {
                    byte s = 0;

                    for (int b = 0; b < 8; ++b, ++x)
                    {
                        bool v = false;

                        if (x < imageWidth)
                        {
                            int i = (y * data.Width) + x;
                            v = data.Dots[i];
                        }

                        s |= (byte)((v ? 0 : 1) << (7 - b));
                    }

                    bw.Write(s);
                }
            }

            bw.WriteNewLine();
        }

        /// <summary>
        /// Converts an image, represented by the given binary payload, into an EPL document.
        /// </summary>
        /// <param name="source">The image to convert.</param>
        /// <returns>The EPL document payload.</returns>
        internal static byte[] AsEplImageDocument(this byte[] source)
        {
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms, Encoding.ASCII))
            {
                // Clear out any bogus commands
                bw.WriteNewLine();

                // Start a new document
                bw.Write(Encoding.ASCII.GetBytes("N"));
                bw.WriteNewLine();

                // Label width is 4"
                bw.Write(Encoding.ASCII.GetBytes("q812"));
                bw.WriteNewLine();

                // Label height is 6" ... only important in ZB mode
                bw.Write(Encoding.ASCII.GetBytes("Q1218,20"));
                bw.WriteNewLine();

                // From earlier in the article
                InsertImage(bw, 0, 0, source);

                // Print one copy of the label
                bw.Write(Encoding.ASCII.GetBytes("P1,1\n"));
                bw.WriteNewLine();

                bw.Flush();

                return ms.ToArray();
            }
        }
*/
    }
}

	



