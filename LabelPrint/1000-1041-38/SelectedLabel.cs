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


namespace _1000_1041_38
{
    public partial class SelectedLabel : Form
    {
        private string labelQuantity;

        public SelectedLabel()
        {
            InitializeComponent();
        }

        private void SelectedLabel_Load(object sender, EventArgs e)
        {
            this.Text = "1000-1041-38 ID SN Label v" + Application.ProductVersion;


            if (g.freeText)
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

                tbHertz.Text = g.hertz;
                tbVolts.Text = g.volts;
                tbAmps.Text = g.amps;

                tbPartNumber.Focus();
            }
            else
            {
                tbPartNumber.Text = g.item;
                tbDescription.Text = g.description;
                tbHertz.Text = g.hertz;
                tbVolts.Text = g.volts;
                tbAmps.Text = g.amps;
                tbModel.Text = g.model;
            }
        }



        private void bPrint_Click(object sender, EventArgs e)
        {
            if (tbPartNumber.Text.Length > 20)
            {
                MessageBox.Show("Part Number text can only be 20 characters long.");
                tbPartNumber.Focus();
                return;
            }

            if (tbDescription.Text.Length > 30)
            {
                MessageBox.Show("Description text can only be 30 characters long.");
                tbDescription.Focus();
                return;
            }

            //if (tbModel.Text.Length > 20)
            //{
            //    MessageBox.Show("Model text can only be 20 characters long.");
            //    tbModel.Focus();
            //    return;
            //}

            if (tbSerialNumber.Text.Length > 20)
            {
                MessageBox.Show("Serial Number text can only be 20 characters long.");
                tbSerialNumber.Focus();
                return;
            }

            labelQuantity = "1";

            //g.printer = "ZDesigner GX430t";

            //Bitmap bzp = Properties.Resources.zygo_blk_noR_203;
            //Bitmap bxp = Properties.Resources.ametek_blk_noR_132;

            /*
             *  Add the image to the resources folder or elsewhere, then add the file to the
             *  resourses.resx file and it will take in the file and reclassify it as an image.
             *  It should then be available under properties.resources - the case does matter for 
             *  the image name.
             */

            /*
             * To use in ZPL the graphic has to be converted to the appropriate code.
             * 
             * There is a website Labelary.com/viewer.html which lets you test out
             * images and it converts them to code for you and then you just paste
             * it in below:
             * 
             * */




            StringBuilder ZplBuilder = new StringBuilder();

            // Exemple ZPL String

            ////ZplBuilder.Append("~WC");   //prints configuration label

            ////ZplBuilder.Append("~JC");   //set media sensor calibration

            ////use Zebra Setup Utilities to set label size if can't get to work with code


            ZplBuilder.Append("^XA");   //Start ZPL
                                        //Larger sized icons for IDSN Label for GK420
            //ZplBuilder.Append("^LL0214");

            ZplBuilder.Append(
            "^FO10,20 ^GFA,1378,1378,26,W01FCM0FFC,3OFC003FFC7FF87FF807IF8,3OFE007FFDIFC7FF81JFE,3OFE007MF7FF83KF8,3OFE007PF8LFC,3PF00QF9LFE,3PF00QFBMF,3PF00QFBMF8,3PF00YF8,3LFEIF81UF1IFC,I01IFCIF81LF87LFC0IFC,I03IF87FF81LF03LF807FFC,I07IF07FFC3KFE01LF803FFE,I0IFE03FFC3KFE00LF003FFE,001IFC03FFC3KFC00LF003FFE,003IF801FFE3FFBFFC00LF003FFE,007IF001FFE7FFBFFC00LF003FFE,00IFE001FFE7FF3FFC00LF003FFE,01IFCI0IF7FF3FFC00LF003FFE,03IF8I0LF3FFE01LF003FFE,07IFJ07JFE3FFE01LF003FFE,0IFEJ07JFE3IF03LF803FFE,1IFCJ07JFE1IFC7LF807FFC,3IF8J03JFC1QFC0IFC,7MF83JFC1QFE1IFC,7MF81JF80VF8,7MF81JF807MFBMF8,7MF80JF807MFBMF,7MF80JF003IFEIF9LFE,7MF80JFI0IFCIF8LFC,7MF807IFI07FF8IF83KF8,7MF807FFEI01FC0IF81JFE,7MF803FFEM0IF807IF8,P03FFEM0IF800FFC,P03FFC03FFE01IF8,P03FFC03IF01IF,N0KF803IF03IF,N0KF803NF,N0KF001MFE,:N0JFEI0MFC,N0JFEI07LF8,N0JFCI03LF,N0JFJ01KFC,N0IFCK03JF,X01FE,,::7hOFC,hPFE,::^FS");
            ZplBuilder.Append(
            "^FO310,20^GFA,357,357,17,,001,003801FF807FCJFDJFEJFDFE1FC,003801FF80FFCJFDJFEJFDFE3F8,007C01FFC0FFCJFDJFEJFDFE7F,007E01FFC1FFCJFDJFEJFDFEFE,00FE01FFE1FFCJFDJFEJFDIFE,00FF01FFE3FFCFEJ03F80FE001IFC,00FF01IF3FFCJFC03F80JFDIF8,007F81IF7FFCJFC03F80JFDIF,007F81LFCJFC03F80JFDIF8,003FC1LFCJFC03F80JFDIF8,003FC1LFCJFC03F80JFDIFC,001FE1JFEFCFEJ03F80FE001IFE,0FEFF1FDFFCFCFEJ03F80FE001IFE,1FCFF1FDFFCFCJF803F80JF9FEFF,1FC7F9FCFFCFCJFC03F80JFDFE7F8,3F87F9FCFF8FCJFC03F80JFDFE7FC,3F83FDFC7F8FCJFC03F80JFDFE3FC,7F03FDFC7F0FCJFC03F80JFDFE3FE,7E01IFC3F0FC7IF803F007IF8FC1FE,^FS");


            ZplBuilder.Append("^FO10,90^A0N,20,25^FDDESC.^FS");
            ZplBuilder.Append("^FO72,90^A0N,20,25^FD").Append(tbDescription.Text.Trim()).Append("^FS");

            ZplBuilder.Append("^FO10,120^A0N,20,25^FDPART #^FS");
            ZplBuilder.Append("^FO90,120^A0N,20,20^FD").Append(tbPartNumber.Text.Trim()).Append("^FS");

            ZplBuilder.Append("^FO10,150^A0N,20,25^FDMODEL^FS");
            ZplBuilder.Append("^FO90,150^A0N,20,25^FD").Append(tbModel.Text.Trim()).Append("^FS");

            ZplBuilder.Append("^FO10,180^A0N,20,25^FDS/N^FS");
            ZplBuilder.Append("^FO70,180^A0N,20,25^FD").Append(tbSerialNumber.Text.Trim()).Append("^FS");

            ZplBuilder.Append("^FO350,180^A0N,20,25^FDHz^FS");
            ZplBuilder.Append("^FO378,180^A0N,20,25^FD").Append(tbHertz.Text.Trim()).Append("^FS");

            ZplBuilder.Append("^FO10,210^A0N,20,25^FDVOLTS^FS");
            ZplBuilder.Append("^FO80,210^A0N,20,25^FD").Append(tbVolts.Text.Trim()).Append("^FS");

            ZplBuilder.Append("^FO340,210^A0N,20,25^FDAMPS^FS");
            ZplBuilder.Append("^FO400,210^A0N,20,25^FD").Append(tbAmps.Text.Trim()).Append("^FS");

            ZplBuilder.Append("^FO50,240^A0N,20,23^FDMADE IN USA, MIDDLEFIELD, CT 06455^FS");


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

            RawPrinterHelper.SendBytesToPrinter(g.printer, cpUnmanagedBytes, cnLength);
            Marshal.FreeCoTaskMem(cpUnmanagedBytes);


            //string str = "\nN\nq456.75Q253.75,20\n";
            //str += SendImageToPrinter(40, 15, bzp);
            //str += SendImageToPrinter(520, 15, bxp);
            //str += "A40,85,0,4,1,1,N,\"DESC.\"\n";
            //str += "A40,80,0,3,1,1,N,\"" + tbDescription.Text.Trim() + "\"\n";
            //str += "A40,125,0,4,1,1,N,\"PART#\"\n";
            //str += "A180,125,0,4,1,1,N,\"" + tbPartNumber.Text.Trim() + "\"\n";
            //str += "A40,170,0,4,1,1,N,\"" + "MODEL\"\n";
            //str += "A180,170,0,4,1,1,N,\"" + tbModel.Text.Trim() + "\"\n";
            //str += "A40,215,0,4,1,1,N,\"" + "S/N" + "\"\n";
            //str += "A140,215,0,4,1,1,N,\"" + tbSerialNumber.Text.Trim() + "\"\n";
            //str += "A420,260,0,4,1,1,N,\"Hz\"\n";
            //str += "A500,260,0,4,1,1,N,\"" + tbHertz.Text.Trim() + "\"\n";
            //str += "A40,260,0,4,1,1,N,\"VOLTS\"\n";
            //str += "A180,260,0,4,1,1,N,\"" + tbVolts.Text.Trim() + "\"\n";
            //str += "A420,305,0,4,1,1,N,\"AMPS\"\n";
            //str += "A540,305,0,4,1,1,N,\"" + tbAmps.Text.Trim() + "\"\n";
            //str += "A40,325,0,3,1,1,N,\"MADE IN TAIWAN\"\n";
            //str += "P" + labelQuantity + "\n";
            //RawPrinterHelper.SendStringToPrinter("ZDesigner GX430t", str);

            tbSerialNumber.Text = "";
            tbSerialNumber.Focus();
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
    }
}
