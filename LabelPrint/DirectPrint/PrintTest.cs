using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace DirectPrint
{
    public partial class PrintTest : Form
    {
        //private string ipAddress = "10.213.68.156";
        //private int port = 9100;


        public PrintTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

        private void bPrint_Click(object sender, EventArgs e)
        {
            /*
             * To use in ZPL the graphic has to be converted to the appropriate code.
             * 
             * There is a website Labelary.com/viewer.html which lets you test out
             * images and it converts them to code for you and then you just paste
             * it in below:
             * 
             * */

            tbDescription.Text = "7702 LASER HD 3mm NARROW";
            tbPartNumber.Text = "8070-0102-02";
            tbModel.Text = "7702";

            //tbDescription.Text = "123456789012345678901234567890";
            //tbPartNumber.Text = "6024-0380-02";

            StringBuilder ZplBuilder = new StringBuilder();

            // Exemple ZPL String
            //ZplBuilder.Append("~WC");   //prints configuration label

            //ZplBuilder.Append("~JC");   //set media sensor calibration

            //ZplBuilder.Append("~JG");   //set manual media calibration

            //ZplBuilder.Append("~WC");

            //ZplBuilder.Append("^LS200");
            ZplBuilder.Append("^LH");  //resets the offset

            ZplBuilder.Append("^XA");   //Start ZPL

            //ZplBuilder.Append("^FS-100");   //Start ZPL
            //Larger sized icons for IDSN Label for GX430
            //ZplBuilder.Append(
            //"^FO50,50 ^GFA,2964,2964,38,gL01FFQ03FFC,1TFEJ0JFC0IFE03JFI03JFE,1TFEJ0JFC3JF83JF001LF8,1TFEI01JFCKFE3JF007LFE,1UFI01JF9LF3JF00NF8,1UFI01JFBLFBJF03NFC,1UFI01VF07OF,1UF8003VF0PF8,1UF8003VF1PFC,1UF8003VF3PFC,1UF8007VF3PFE,1UFC007VF7QF,1UFC007gNF,1PFCJFC007gGFC3KF8,K03KF8JFE00OFE0QF00KF8,K03KF07IFE00OF803OFE003JFC,K07JFE07IFE00OF001OFC003JFC,K0KFC03JF01OFI0OF8001JFC,J01KF803JF01NFEI0OF8001JFC,J03KF003JF01NFEI0OF8I0JFE,J07JFE001JF81IFEJFEI07NFJ0JFE,J0KFC001JF83IFEJFEI07NFJ0JFE,I01KF8I0JF83IFEJFEI07NFJ0JFE,I03KFJ0JF83IFCJFEI07NFJ0JFE,I07JFEJ0JFC7IFCJFEI07NFJ0JFE,I0KFCJ07IFC7IFCJFEI07NFJ0JFE,001KF8J07IFC7IF8JFEI07NFJ0JFE,003KFK03IFE7IF8JFEI07NFJ0JFE,007JFEK03IFEJF8JFEI0OFJ0JFE,00KFCK01IFEJF07JFI0OFJ0JFE,01KF8K01NF07JF001OF8I0JFE,03KFL01MFE07JF803OF8001JFC,07JFEM0MFE07JFE07OFC001JFC,0KFCM0MFE03VFC003JFC,1KF8M07LFC03VFE007JF8,1QF807LFC03WF80KF8,3QF803LFC01gJF,3QF803LF800gJF,3QF803LF800RF7PFE,3QF801LFI07QF3PFE,3QF801LFI03QF1PFC,3QF800LFI01LF7JF0PF8,3QF800KFEJ0KFE7JF07OF,3QF800KFEJ07JFC7JF03NFE,3QF8007JFEJ01JF07JF01NFC,3QF8007JFCK0IFC07JF007MF,3QF8003JFCK01FE007JF003LFC,3QF8003JF8P07JFI07KF,U03JF8P07JFJ07IF,U01JF8P07JF,U01JFI07IFEI07JF,U01JFI07JFI0JFE,U03JFI07JFI0JFE,T01JFEI07JF801JFE,R0MFEI07JFE07JFE,R0MFCI03QFC,:R0MF8I03QF8,R0MF8I01QF,R0MFK0QF,R0MFK0PFE,R0LFEK07OFC,R0LFCK03OF8,R0LF8K01NFE,R0KFEM07MF8,R0KFO0LFE,gM0JFC,,:::::iUFC::::^FS");
            //ZplBuilder.Append(
            //"^FO470,50 ^GFA,775,775,25,,J0C,I01CI01IFM01KFEU01FF80FFE,I01EI03IF8007FFE3LF3MF3LF1FF81FFE,I03EI03IF800IFE3LF3MF3LF1FF83FFC,I03FI03IFC00IFE3LF3MF3LF1FF83FF8,I07FI03IFC01IFE3LF3MF3LF1FF87FF,I07F8003IFE01IFE3LF3MF3LF1FF8FFE,I0FFC003IFE03IFE3LF3MF3LF1FF9FFC,001FFC003JF03IFE3LF3MF3LF1KF8,001FFE003JF07IFE3FF8K01FFC003FF8I01KF,001FFE003JF07IFE3FF8L0FFC003FF8I01KF,I0IF003JF8JFE3LFI0FFC003LF1JFE,I0IF003JF8JFE3LFI0FFC003LF1JFC,I07FF803JFDJFE3LFI0FFC003LF1JFC,I07FF803JFDJFE3LFI0FFC003LF1JFE,I03FFC03OFE3LFI0FFC003LF1JFE,I01FFE03OFE3LFI0FFC003LF1KF,I01FFE03OFE3LFI0FFC003LF1KF8,J0IF03MF7FE3FF8L0FFC003FF8I01KF8,J0IF03FFBJF7FE3FF8L0FFC003FF8I01KFC,07FF7FF83FFBIFE7FE3FF8L0FFC003FF8I01KFE,07FE7FF83FF9IFE7FE3FF8L0FFC003FF8I01FFDFFE,0FFE3FFC3FF9IFC7FE3LFI0FFC003LF1FF8IF,0FFC1FFE3FF9IFC7FE3LFI0FFC003LF1FF8IF8,1FFC1FFE3FF8IF87FE3LFI0FFC003LF1FF87FF8,3FF80IF3FF8IF87FE3LFI0FFC003LF1FF83FFC,3FF80IF3FF87FF07FE3LFI0FFC003LF1FF83FFE,7FF007FFBFF87FF07FE3LFI0FFC003LF1FF81FFE,7FE003FFBFF83FF07FE3LFI0FFC003LF1FF81IF,7FE003KF83FE07FE3LFI0FFC003LF1FF80IF,^ FS");

            //Larger sized icons for IDSN Label for GK420
            //ZplBuilder.Append(
            //"^FO10,35 ^GFA,1378,1378,26,W01FCM0FFC,3OFC003FFC7FF87FF807IF8,3OFE007FFDIFC7FF81JFE,3OFE007MF7FF83KF8,3OFE007PF8LFC,3PF00QF9LFE,3PF00QFBMF,3PF00QFBMF8,3PF00YF8,3LFEIF81UF1IFC,I01IFCIF81LF87LFC0IFC,I03IF87FF81LF03LF807FFC,I07IF07FFC3KFE01LF803FFE,I0IFE03FFC3KFE00LF003FFE,001IFC03FFC3KFC00LF003FFE,003IF801FFE3FFBFFC00LF003FFE,007IF001FFE7FFBFFC00LF003FFE,00IFE001FFE7FF3FFC00LF003FFE,01IFCI0IF7FF3FFC00LF003FFE,03IF8I0LF3FFE01LF003FFE,07IFJ07JFE3FFE01LF003FFE,0IFEJ07JFE3IF03LF803FFE,1IFCJ07JFE1IFC7LF807FFC,3IF8J03JFC1QFC0IFC,7MF83JFC1QFE1IFC,7MF81JF80VF8,7MF81JF807MFBMF8,7MF80JF807MFBMF,7MF80JF003IFEIF9LFE,7MF80JFI0IFCIF8LFC,7MF807IFI07FF8IF83KF8,7MF807FFEI01FC0IF81JFE,7MF803FFEM0IF807IF8,P03FFEM0IF800FFC,P03FFC03FFE01IF8,P03FFC03IF01IF,N0KF803IF03IF,N0KF803NF,N0KF001MFE,:N0JFEI0MFC,N0JFEI07LF8,N0JFCI03LF,N0JFJ01KFC,N0IFCK03JF,X01FE,,::7hOFC,hPFE,::^FS");
            //ZplBuilder.Append(
            //"^FO310,25^GFA,357,357,17,,001,003801FF807FCJFDJFEJFDFE1FC,003801FF80FFCJFDJFEJFDFE3F8,007C01FFC0FFCJFDJFEJFDFE7F,007E01FFC1FFCJFDJFEJFDFEFE,00FE01FFE1FFCJFDJFEJFDIFE,00FF01FFE3FFCFEJ03F80FE001IFC,00FF01IF3FFCJFC03F80JFDIF8,007F81IF7FFCJFC03F80JFDIF,007F81LFCJFC03F80JFDIF8,003FC1LFCJFC03F80JFDIF8,003FC1LFCJFC03F80JFDIFC,001FE1JFEFCFEJ03F80FE001IFE,0FEFF1FDFFCFCFEJ03F80FE001IFE,1FCFF1FDFFCFCJF803F80JF9FEFF,1FC7F9FCFFCFCJFC03F80JFDFE7F8,3F87F9FCFF8FCJFC03F80JFDFE7FC,3F83FDFC7F8FCJFC03F80JFDFE3FC,7F03FDFC7F0FCJFC03F80JFDFE3FE,7E01IFC3F0FC7IF803F007IF8FC1FE,^FS");


            ///*  shipping label logo size    */
            //ZplBuilder.Append("^FO10, 35 ^GFA, 578, 578, 17, 3KFE01FE3F1FE03FC, 7LF01FEFFDFE1IF, 7LF03LFE3IFC, 7LF03LFEJFE, 7LF83LFEKF, 7LF87RF, 007FF7F87IFC7JF1FF8, 00FFE3FC7IF83IFE0FF8, 01FFC3FC7IF83IFC07F8, 03FF83FCJF83IFC07F8, 03FF01FEFEFF83IFC07FC, 07FE01FEFEFF83IFC07F8, 0FFC00IFEFF83IFC07F8, 1FF800IFC7F83IFC07F8, 3FFI07FFC7LFE0FF8, 7JF87FFC7MF1FF, KF87FF83PF, KF83FF81JFEJFE, KF83FF80JFE7IFC, KF81FF007F3FE3IF8, 7JF81FFJ03FE0FFE, L01FEJ03FE01F, L01FE0FF83FE, K07FFE07FC7FC, K07FFC07JFC, K07FFC07JF8, K07FF803JF8, K07FF001IFE, K07FCI07FFC,,::gSF,:^FS");
            //ZplBuilder.Append("^FO420,35^GFA,357,357,17,,001,003801FF807FCJFDJFEJFDFE1FC,003801FF80FFCJFDJFEJFDFE3F8,007C01FFC0FFCJFDJFEJFDFE7F,007E01FFC1FFCJFDJFEJFDFEFE,00FE01FFE1FFCJFDJFEJFDIFE,00FF01FFE3FFCFEJ03F80FE001IFC,00FF01IF3FFCJFC03F80JFDIF8,007F81IF7FFCJFC03F80JFDIF,007F81LFCJFC03F80JFDIF8,003FC1LFCJFC03F80JFDIF8,003FC1LFCJFC03F80JFDIFC,001FE1JFEFCFEJ03F80FE001IFE,0FEFF1FDFFCFCFEJ03F80FE001IFE,1FCFF1FDFFCFCJF803F80JF9FEFF,1FC7F9FCFFCFCJFC03F80JFDFE7F8,3F87F9FCFF8FCJFC03F80JFDFE7FC,3F83FDFC7F8FCJFC03F80JFDFE3FC,7F03FDFC7F0FCJFC03F80JFDFE3FE,7E01IFC3F0FC7IF803F007IF8FC1FE,^FS");

            ///*  text ^A font, orientation, height, width(dots)
            // *  barcode = code 128
            // */

            //ZplBuilder.Append("^FO70,160^A0N,30,25^FDGX430t^FS");
            //ZplBuilder.Append("^FO70,160^A0N,30,25^FDGK420d^FS");
            //ZplBuilder.Append("^FO170,60^A0N,30,25^FD1F, No.26, Chuangye Road, Tainan City 74144 Taiwan^FS");

            //Larger sized icons for IDSN Label for GK420
            //ZplBuilder.Append(
            //"^FO10,50 ^GFA,1378,1378,26,W01FCM0FFC,3OFC003FFC7FF87FF807IF8,3OFE007FFDIFC7FF81JFE,3OFE007MF7FF83KF8,3OFE007PF8LFC,3PF00QF9LFE,3PF00QFBMF,3PF00QFBMF8,3PF00YF8,3LFEIF81UF1IFC,I01IFCIF81LF87LFC0IFC,I03IF87FF81LF03LF807FFC,I07IF07FFC3KFE01LF803FFE,I0IFE03FFC3KFE00LF003FFE,001IFC03FFC3KFC00LF003FFE,003IF801FFE3FFBFFC00LF003FFE,007IF001FFE7FFBFFC00LF003FFE,00IFE001FFE7FF3FFC00LF003FFE,01IFCI0IF7FF3FFC00LF003FFE,03IF8I0LF3FFE01LF003FFE,07IFJ07JFE3FFE01LF003FFE,0IFEJ07JFE3IF03LF803FFE,1IFCJ07JFE1IFC7LF807FFC,3IF8J03JFC1QFC0IFC,7MF83JFC1QFE1IFC,7MF81JF80VF8,7MF81JF807MFBMF8,7MF80JF807MFBMF,7MF80JF003IFEIF9LFE,7MF80JFI0IFCIF8LFC,7MF807IFI07FF8IF83KF8,7MF807FFEI01FC0IF81JFE,7MF803FFEM0IF807IF8,P03FFEM0IF800FFC,P03FFC03FFE01IF8,P03FFC03IF01IF,N0KF803IF03IF,N0KF803NF,N0KF001MFE,:N0JFEI0MFC,N0JFEI07LF8,N0JFCI03LF,N0JFJ01KFC,N0IFCK03JF,X01FE,,::7hOFC,hPFE,::^FS");
            //ZplBuilder.Append(
            //"^FO310,50^GFA,357,357,17,,001,003801FF807FCJFDJFEJFDFE1FC,003801FF80FFCJFDJFEJFDFE3F8,007C01FFC0FFCJFDJFEJFDFE7F,007E01FFC1FFCJFDJFEJFDFEFE,00FE01FFE1FFCJFDJFEJFDIFE,00FF01FFE3FFCFEJ03F80FE001IFC,00FF01IF3FFCJFC03F80JFDIF8,007F81IF7FFCJFC03F80JFDIF,007F81LFCJFC03F80JFDIF8,003FC1LFCJFC03F80JFDIF8,003FC1LFCJFC03F80JFDIFC,001FE1JFEFCFEJ03F80FE001IFE,0FEFF1FDFFCFCFEJ03F80FE001IFE,1FCFF1FDFFCFCJF803F80JF9FEFF,1FC7F9FCFFCFCJFC03F80JFDFE7F8,3F87F9FCFF8FCJFC03F80JFDFE7FC,3F83FDFC7F8FCJFC03F80JFDFE3FC,7F03FDFC7F0FCJFC03F80JFDFE3FE,7E01IFC3F0FC7IF803F007IF8FC1FE,^FS");


            //ZplBuilder.Append("^FO10,120^A0N,23,23^FDDESC.^FS");
            //ZplBuilder.Append("^FO70,120^A0N,23,23^FD").Append(tbDescription.Text.Trim()).Append("^FS");

            //ZplBuilder.Append("^FO10,150^A0N,23,23^FDPART #^FS");
            //ZplBuilder.Append("^FO90,150^A0N,23,23^FD").Append(tbPartNumber.Text.Trim()).Append("^FS");

            //ZplBuilder.Append("^FO10,180^A0N,23,23^FDMODEL^FS");
            //ZplBuilder.Append("^FO90,180^A0N,23,23^FD").Append(tbModel.Text.Trim()).Append("^FS");

            //ZplBuilder.Append("^FO10,210^A0N,23,23^FDS/N^FS");
            //ZplBuilder.Append("^FO70,210^A0N,23,23^FD").Append(tbSerialNumber.Text.Trim()).Append("^FS");

            //ZplBuilder.Append("^FO330,210^A0N,23,23^FDHz^FS");
            //ZplBuilder.Append("^FO350,210^A0N,23,23^FD").Append(tbHertz.Text.Trim()).Append("^FS");

            //ZplBuilder.Append("^FO10,240^A0N,23,23^FDVOLTS^FS");
            //ZplBuilder.Append("^FO70,240^A0N,23,23^FD").Append(tbVolts.Text.Trim()).Append("^FS");

            //ZplBuilder.Append("^FO340,240^A0N,23,23^FDAmps^FS");
            //ZplBuilder.Append("^FO370,240^A0N,23,23^FD").Append(tbAmps.Text.Trim()).Append("^FS");


            ZplBuilder.Append("^FO150,80^A0N,25,30^FD").Append(tbDescription.Text.Trim()).Append("^FS");

            ZplBuilder.Append("^FO150,110^A0N,25,30^FD").Append(tbDescription.Text.Trim()).Append("^FS");


            ZplBuilder.Append("^FO150,150^A0N,20,20^FDMADE IN U.S.A.^FS");

            //ZplBuilder.Append("^FO160,150^A0N,25,20^FDP/N:^FS");
            //ZplBuilder.Append("^FO200,150^A0N,27,24^FD").Append(tbPartNumber.Text.Trim()).Append("^FS");

            //ZplBuilder.Append("^FO400,150^A0N,25,20^FDS/N:^FS");
            //ZplBuilder.Append("^FO440,150^A0N,25,20^FD").Append(tbSerialNumber.Text.Trim()).Append("^FS");


            //ZplBuilder.Append("^FO40,80^A0N,36,20^FDDescription^FS");

            //ZplBuilder.Append("^FO0,0^A0N,36,20^FDPART #^FS");

            //ZplBuilder.Append("^FO40,215^A0N,36,20^FDPART #^FS");
            //ZplBuilder.Append("^FO40,260^A0N,36,20^FDPART #^FS");
            //ZplBuilder.Append("^FO40,305^A0N,36,20^FDPART #^FS");
            //ZplBuilder.Append("^FO40,340^A0N,36,30^FDMade in Taiwan^FS");
            //ZplBuilder.Append("^FO0,306^GD720,166,1,B,L^FS");
            //ZplBuilder.Append("^FO0,306^GD720,166,1,B,R^FS");
            //ZplBuilder.Append("^XZ");
            // End ZPL

            //ZplBuilder.Append("^XA");   //Start ZPL
            //ZplBuilder.Append("^HH");
            //ZplBuilder.Append("^FO40,40^A36,20^FD").Append(DateTime.Now.Date.ToString("MM/dd/yyyy")).Append("^FS");
            //ZplBuilder.Append("^FO0,0^A0N,0,DN,125^FDDESC^FS");
            //ZplBuilder.Append("^FO0,306^GD720,166,1,B,L^FS");
            //ZplBuilder.Append("^FO0,306^GD720,166,1,B,R^FS");
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

            //RawPrinterHelper.SendBytesToPrinter("zebra2.25x1.25", cpUnmanagedBytes, cnLength);
            //RawPrinterHelper.SendBytesToPrinter("ZDesigner GX430t", cpUnmanagedBytes, cnLength);
            //RawPrinterHelper.SendBytesToPrinter("ZDesigner GK420d", cpUnmanagedBytes, cnLength);
            RawPrinterHelper.SendBytesToPrinter(@"\\ct-mid-ps01\zebrasn49", cpUnmanagedBytes, cnLength);
            Marshal.FreeCoTaskMem(cpUnmanagedBytes);
            
            //string str = "^XA^FO20,20^ADN,18,10^FDtor^FS^XZ";


            //int labelQuantity = 1;

            //string str = "\nN\nq609Q203,20\n";
            // str += "A144,10,0,2,1,1,N,\"21 Laurel Brook Road\"\n";
            //str += "A144,35,0,2,1,1,N,\"Middlefield, CT 06455 USA\"\n";
            //str += "A10,70,0,2,1,1,N,\"PN#\"\n";
            //str += "B50,65,0,1,2,4,32,B,\"" + tbPartNumber.Text + "\"\n";
            ////str += "A420,60,0,2,1,1,N,\"" + line1 + "\"\n";
            ////str += "A420,80,0,2,1,1,N,\"" + line2 + "\"\n";
            ////str += "A420,100,0,2,1,1,N,\"" + line3 + "\"\n";
            //str += "A10,140,0,2,1,1,N,\"SN#\"\n";
            //str += "B50,135,0,1,2,4,32,B,\"" + tbSerialNumber.Text + "\"\n";
            //str += "A420,125,0,2,1,1,N,\"" + tbRevision.Text + "\"\n";
            //str += "A420,150,0,2,1,1,N,\"" + tbQty.Text + "\"\n";
            //str += "A420,175,0,2,1,1,N,\"" + tbPartNumber.Text + "\"\n";
            //str += "P" + labelQuantity + "\n";
            //RawPrinterHelper.SendStringToPrinter("ZDesigner GK420d", str);
            /*
           string zplstring =
               "^XA" +
               "^F050,50" +
               "^A0N50, 50" +
               "^FDTest Text^FS" +
               "^XZ";

           try 
           {
               System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
               client.Connect(ipAddress, port);

               System.IO.StreamWriter writer =
                   new System.IO.StreamWriter(client.GetStream());
               writer.Write(zplstring);
               writer.Flush();

               writer.Close();
               client.Close();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());

           }

         */


            //this.Close();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
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



