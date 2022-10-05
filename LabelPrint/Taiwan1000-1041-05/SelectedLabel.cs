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

namespace Taiwan1000_1041_05
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
            this.Text = "1000-1041-05 ID SN Label v" + Application.ProductVersion;
            

            //if (g.freeText)
            //{
                //this.Text = "Enter values prior to printing.";

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

                //tbHertz.Text = g.hertz;
                //tbVolts.Text = g.volts;
                //tbAmps.Text = g.amps;

                tbPartNumber.Focus();
            //}
            //else
            //{
            //    tbPartNumber.Text = g.item;
            //    tbDescription.Text = g.description;
            //    tbHertz.Text = g.hertz;
            //    tbVolts.Text = g.volts;
            //    tbAmps.Text = g.amps;
            //    tbModel.Text = g.model;
            //}
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

            if (tbModel.Text.Length > 20)
            {
                MessageBox.Show("Model text can only be 20 characters long.");
                tbModel.Focus();
                return;
            }

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
            /*  Zygo Logo   */
            ZplBuilder.Append(
            "^FO30,50 ^GFA,2964,2964,38,gL01FFQ03FFC,1TFEJ0JFC0IFE03JFI03JFE,1TFEJ0JFC3JF83JF001LF8,1TFEI01JFCKFE3JF007LFE,1UFI01JF9LF3JF00NF8,1UFI01JFBLFBJF03NFC,1UFI01VF07OF,1UF8003VF0PF8,1UF8003VF1PFC,1UF8003VF3PFC,1UF8007VF3PFE,1UFC007VF7QF,1UFC007gNF,1PFCJFC007gGFC3KF8,K03KF8JFE00OFE0QF00KF8,K03KF07IFE00OF803OFE003JFC,K07JFE07IFE00OF001OFC003JFC,K0KFC03JF01OFI0OF8001JFC,J01KF803JF01NFEI0OF8001JFC,J03KF003JF01NFEI0OF8I0JFE,J07JFE001JF81IFEJFEI07NFJ0JFE,J0KFC001JF83IFEJFEI07NFJ0JFE,I01KF8I0JF83IFEJFEI07NFJ0JFE,I03KFJ0JF83IFCJFEI07NFJ0JFE,I07JFEJ0JFC7IFCJFEI07NFJ0JFE,I0KFCJ07IFC7IFCJFEI07NFJ0JFE,001KF8J07IFC7IF8JFEI07NFJ0JFE,003KFK03IFE7IF8JFEI07NFJ0JFE,007JFEK03IFEJF8JFEI0OFJ0JFE,00KFCK01IFEJF07JFI0OFJ0JFE,01KF8K01NF07JF001OF8I0JFE,03KFL01MFE07JF803OF8001JFC,07JFEM0MFE07JFE07OFC001JFC,0KFCM0MFE03VFC003JFC,1KF8M07LFC03VFE007JF8,1QF807LFC03WF80KF8,3QF803LFC01gJF,3QF803LF800gJF,3QF803LF800RF7PFE,3QF801LFI07QF3PFE,3QF801LFI03QF1PFC,3QF800LFI01LF7JF0PF8,3QF800KFEJ0KFE7JF07OF,3QF800KFEJ07JFC7JF03NFE,3QF8007JFEJ01JF07JF01NFC,3QF8007JFCK0IFC07JF007MF,3QF8003JFCK01FE007JF003LFC,3QF8003JF8P07JFI07KF,U03JF8P07JFJ07IF,U01JF8P07JF,U01JFI07IFEI07JF,U01JFI07JFI0JFE,U03JFI07JFI0JFE,T01JFEI07JF801JFE,R0MFEI07JFE07JFE,R0MFCI03QFC,:R0MF8I03QF8,R0MF8I01QF,R0MFK0QF,R0MFK0PFE,R0LFEK07OFC,R0LFCK03OF8,R0LF8K01NFE,R0KFEM07MF8,R0KFO0LFE,gM0JFC,,:::::iUFC::::^FS");
            /*  Ametek logo */
            ZplBuilder.Append(
            "^FO450,50 ^GFA,775,775,25,,J0C,I01CI01IFM01KFEU01FF80FFE,I01EI03IF8007FFE3LF3MF3LF1FF81FFE,I03EI03IF800IFE3LF3MF3LF1FF83FFC,I03FI03IFC00IFE3LF3MF3LF1FF83FF8,I07FI03IFC01IFE3LF3MF3LF1FF87FF,I07F8003IFE01IFE3LF3MF3LF1FF8FFE,I0FFC003IFE03IFE3LF3MF3LF1FF9FFC,001FFC003JF03IFE3LF3MF3LF1KF8,001FFE003JF07IFE3FF8K01FFC003FF8I01KF,001FFE003JF07IFE3FF8L0FFC003FF8I01KF,I0IF003JF8JFE3LFI0FFC003LF1JFE,I0IF003JF8JFE3LFI0FFC003LF1JFC,I07FF803JFDJFE3LFI0FFC003LF1JFC,I07FF803JFDJFE3LFI0FFC003LF1JFE,I03FFC03OFE3LFI0FFC003LF1JFE,I01FFE03OFE3LFI0FFC003LF1KF,I01FFE03OFE3LFI0FFC003LF1KF8,J0IF03MF7FE3FF8L0FFC003FF8I01KF8,J0IF03FFBJF7FE3FF8L0FFC003FF8I01KFC,07FF7FF83FFBIFE7FE3FF8L0FFC003FF8I01KFE,07FE7FF83FF9IFE7FE3FF8L0FFC003FF8I01FFDFFE,0FFE3FFC3FF9IFC7FE3LFI0FFC003LF1FF8IF,0FFC1FFE3FF9IFC7FE3LFI0FFC003LF1FF8IF8,1FFC1FFE3FF8IF87FE3LFI0FFC003LF1FF87FF8,3FF80IF3FF8IF87FE3LFI0FFC003LF1FF83FFC,3FF80IF3FF87FF07FE3LFI0FFC003LF1FF83FFE,7FF007FFBFF87FF07FE3LFI0FFC003LF1FF81FFE,7FE003FFBFF83FF07FE3LFI0FFC003LF1FF81IF,7FE003KF83FE07FE3LFI0FFC003LF1FF80IF,^ FS");
            /*  CE Mark */
            ZplBuilder.Append(
                "^FO530,250^GFA,1162,1162,14,O07FCS0FF8M01IFCQ01IF8M0JFCQ0JF8L03JFCP07JF8K01KFCO01KF8K03KFCO07KF8K0LFCN01LF8J03LFCN03LF8J07LFCN07LF8J0MFCM01MF8I01MFCM03MF8I07MFCM07MF8I0LF8O0LF8,I0KF8O01KF8,001JFCP03JFC,003JFQ07JF,007IFEQ07IFC,00JF8Q0JF8,00JFQ01IFE,01IFEQ03IFC,03IF8Q03IF8,03IFR07IF,07IFR07FFE,07FFER0IFC,0IFCR0IFC,0IF8Q01IF8,1IF8Q01IF,1IFR01IF,1IFR03FFE,3FFER03FFE,3FFER03FFC,3FFCR07FFC,3FFCR07FF8,7FFCR07FF8,7FF8R07FF8,7FF8R07NF8,7FF8R0OF8,::::::::::7FF8R07NF8,7FF8R07FF8,7FFCR07FF8,3FFCR07FF8,3FFCR07FFC,3FFER03FFC,3FFER03FFE,1IFR03FFE,1IFR01IF,1IF8Q01IF,0IF8Q01IF8,0IFCR0IFC,07FFER0IFC,07IFR07FFE,03IFR07IF,03IF8Q03IF8,01IFEQ03IFC,00JFQ01IFE,00JF8Q0JF8,007IFEQ07IFC,003JFQ07JF,001JFCP03JFC,I0KF8O01KF8,I0LF8O0LF8,I07MFCM07MF8I01MFCM03MF8J0MFCM01MF8J07LFCN07LF8J03LFCN03LF8K0LFCN01LF8K03KFCO07KF8K01KFCO01KF8L03JFCP07JF8M0JFCQ0JF8M01IFCQ01IF8O07FCS0FF8^FS");



            ZplBuilder.Append("^FO20,150^A0N,35,30^FD").Append(tbDescription.Text.Trim()).Append("^FS");

            ZplBuilder.Append("^FO20,190^A0N,35,30^FDPART #^FS");
            ZplBuilder.Append("^FO140,190^A0N,35,30^FD").Append(tbPartNumber.Text.Trim()).Append("^FS");

            ZplBuilder.Append("^FO20,230^A0N,35,30^FDMODEL^FS");
            ZplBuilder.Append("^FO140,230^A0N,35,30^FD").Append(tbModel.Text.Trim()).Append("^FS");

            ZplBuilder.Append("^FO20,270^A0N,35,30^FDS/N^FS");
            ZplBuilder.Append("^FO140,270^A0N,35,30^FD").Append(tbSerialNumber.Text.Trim()).Append("^FS");

            ZplBuilder.Append("^FO400,270^A0N,35,30^FDHz^FS");
            ZplBuilder.Append("^FO440,270^A0N,35,30^FD").Append(tbHertz.Text.Trim()).Append("^FS");

            ZplBuilder.Append("^FO20,310^A0N,35,30^FDVOLTS^FS");
            ZplBuilder.Append("^FO140,310^A0N,35,30^FD").Append(tbVolts.Text.Trim()).Append("^FS");

            ZplBuilder.Append("^FO400,310^A0N,35,30^FDAMPS^FS");
            ZplBuilder.Append("^FO480,310^A0N,35,30^FD").Append(tbAmps.Text.Trim()).Append("^FS");


            ZplBuilder.Append("^FO160,350^A0N,30,40^FDMADE IN TAIWAN^FS");
            
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
            //str += "A150,85,0,4,1,1,N,\"" + tbDescription.Text.Trim() + "\"\n";
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
            //RawPrinterHelper.SendStringToPrinter(g.printer, str);

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
