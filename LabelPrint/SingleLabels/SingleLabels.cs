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
using System.Data.SqlClient;


namespace SingleLabels
{
    public partial class SingleLabels : Form
    {
        private string labelQuantity;
        private string printer;
        Bitmap bzp = Properties.Resources.zygo_blk_noR_203;
        Bitmap bxp = Properties.Resources.ametek_blk_noR_132;
        private string str = string.Empty;

        public SingleLabels()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Security.Principal.WindowsIdentity userBase;
            userBase = System.Security.Principal.WindowsIdentity.GetCurrent();

            string user = userBase.Name.ToUpper(); ;

            if (userBase.Name.IndexOf("Z") == 0)
            {
                user = userBase.Name.Replace("ZYGOMIS\\", "");
            }
            else
            {
                user = userBase.Name.Replace("AMETEK-AD\\", "");
            }

            string computername = Environment.MachineName;

            SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL11; password = Read+Write!; " +
                                  "user = readwrite; database = AccessFrontEnds;");

            try
            {
                SqlCommand cmd = new SqlCommand(
                 " Select permission, permissionvalue from applicationsetup " +
                 " where (application = '1000-1042-79' or application = 'SingleLabel') and " +
                 " permission = 'printer' AND " +
                 " pcid = '" + computername + "' AND username = '" + user + "' " +
                 " order by permission desc ", cnxn);
                DataTable table = new DataTable();

                cnxn.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();
                table.Load(dr);


                if (table.Rows.Count > 0)
                {
                    printer = table.Rows[0][1].ToString().Trim();
                }
                else
                {
                    MessageBox.Show("Either this user: " + user + " or computer (" + computername + ") does not have permission to use this program: SingleLabel.");
                    this.Close();
                }


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }


            this.Text = "Single Label Selection v." + Application.ProductVersion;

            //string computername = Environment.MachineName;

            //SqlConnection cnxn = new SqlConnection("server = CT-MID-SQL11; password = Read+Write!; " +
            //                      "user = readwrite; database = AccessFrontEnds;");

           

            /* for Taiwan   */
            /*
            //printer = "ZDesigner GX430t";
            printer = "zebra2.25x1.25";
            button1.Visible = false;
            */
            //button1.BackgroundImage = Image.FromFile("C:\\A\\1000-1042-79 sample.tif");
            button1.BackgroundImage = Properties.Resources._1000_1042_79D_sample;

            button1.ImageAlign = ContentAlignment.MiddleCenter;
            button1.FlatStyle = FlatStyle.Flat;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            //button1.Visible = false;
            //label1.Visible = false;

            button2.BackgroundImage = Properties.Resources._1000_1041_08;

            button2.ImageAlign = ContentAlignment.MiddleCenter;
            button2.FlatStyle = FlatStyle.Flat;
            button2.BackgroundImageLayout = ImageLayout.Stretch;

            button3.BackgroundImage = Properties.Resources._1000_1043_24_REV01;

            button3.ImageAlign = ContentAlignment.MiddleCenter;
            button3.FlatStyle = FlatStyle.Flat;
            button3.BackgroundImageLayout = ImageLayout.Stretch;

            //printer = "\\\\midprtsrv\\ZEBRASN6";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //printer = "\\\\ct-mid-ps01\\zebrasn48";
            //if (printer == @"\\CT-MID-PS01\ZEBRASN6")
            //{
            //    /*
            //     * for SN6 works fine after printing bartender label to realign/reset
            //     */
            //    str = "\nN\nq456.75Q253.75,20\n";
            //    str += SendImageToPrinter(10, 15, bzp);
            //    str += SendImageToPrinter(300, 15, bxp);
            //    str += "A10,85,0,3,1,1,N,\"THIS PRODUCT CONFORMS WITH DHHS\"\n";
            //    str += "A10,110,0,3,1,1,N,\"RADIATION PERFORMANCE STANDARD,\"\n";
            //    str += "A20,135,0,3,1,1,N,\"21 CFR CHAPTER I SUBCHAPTER J\"\n";
            //    str += "A50,170,0,2,1,1,N,\"Patents apply to this product.\"\n";
            //    str += "A70,190,0,2,1,1,N,\"See www.zygo.com/patents.\"\n";
            //    //str += "A30,225,0,2,1,1,N,\"MADE IN TAIWAN\"\n";
            //    str += "A20,225,0,2,1,1,N,\"MADE IN USA, Middlefield, CT 06455\"\n";
            //    str += "P" + labelQuantity + "\n";
            //    /**/
            //    }
            //    else if (printer == @"\\CT-MID-PS01\ZEBRASN1" | printer == @"\\CT-MID-PS01\ZEBRASN20")
            //    {
            str = "\nN\nq456.75Q253.75,20\n";
            str += SendImageToPrinter(20, 15, bzp);
            str += SendImageToPrinter(310, 15, bxp);
            str += "A20,85,0,3,1,1,N,\"THIS PRODUCT CONFORMS WITH DHHS\"\n";
            str += "A20,110,0,3,1,1,N,\"RADIATION PERFORMANCE STANDARD,\"\n";
            str += "A30,135,0,3,1,1,N,\"21 CFR CHAPTER I SUBCHAPTER J\"\n";
            str += "A60,170,0,2,1,1,N,\"Patents apply to this product.\"\n";
            str += "A80,190,0,2,1,1,N,\"See www.zygo.com/patents.\"\n";
            str += "A30,225,0,2,1,1,N,\"MADE IN USA, Middlefield, CT 06455\"\n";
            str += "P" + labelQuantity + "\n";




            //}
            /*  modified for SN20    
             printer = "\\\\midprtsrv\\ZEBRASN20";
             
            //printer = "zdesigner TLP 2844";

            str = "\nN\nq456.75Q253.75,20\n";
            str += SendImageToPrinter(10, 15, bzp);
            str += SendImageToPrinter(300, 15, bxp);
            str += "A0,85,0,3,1,1,N,\"THIS PRODUCT CONFORMS WITH DHHS\"\n";
            str += "A5,110,0,3,1,1,N,\"RADIATION PERFORMANCE STANDARD,\"\n";
            str += "A15,135,0,3,1,1,N,\"21 CFR CHAPTER I SUBCHAPTER J\"\n";
            str += "A45,170,0,2,1,1,N,\"Patents apply to this product.\"\n";
            str += "A65,190,0,2,1,1,N,\"See www.zygo.com/patents.\"\n";
            //str += "A30,225,0,2,1,1,N,\"MADE IN TAIWAN\"\n";
            str += "A15,225,0,2,1,1,N,\"MADE IN USA, Middlefield, CT 06455\"\n";
            str += "P" + labelQuantity + "\n";
            */
            printer = "ZDesigner ZD421-203dpi ZPL";
            //printer = "\\\\CT-MID-PS01\\ZEBRASN48";
            ToPrint();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1000-1041-26 Patents Pending Label
            /*
            str = "\nN\nq456.75Q253.75,20\n";
            str += SendImageToPrinter(10, 15, bzp);
            str += SendImageToPrinter(300, 15, bxp);
            str += "A105,90,0,4,1,1,N,\"Patents apply\"\n";
            str += "A85,120,0,4,1,1,N,\"to this product.\"\n";
            str += "A25,150,0,4,1,1,N,\"See www.zygo.com/patents.\"\n";
            str += "A20,225,0,2,1,1,N,\"MADE IN USA, Middlefield, CT 06455\"\n";
            str += "P" + labelQuantity + "\n";
            *//*  ten over  */
            str = "\nN\nq456.75Q253.75,20\n";
            str += SendImageToPrinter(20, 15, bzp);
            str += SendImageToPrinter(310, 15, bxp);
            str += "A115,90,0,4,1,1,N,\"Patents apply\"\n";
            str += "A95,120,0,4,1,1,N,\"to this product.\"\n";
            str += "A35,150,0,4,1,1,N,\"See www.zygo.com/patents.\"\n";
            str += "A30,225,0,2,1,1,N,\"MADE IN USA, Middlefield, CT 06455\"\n";
            str += "P" + labelQuantity + "\n";

            //str = "\nN\nq456.75Q253.75,20\n";
            //str += SendImageToPrinter(30, 15, bzp);
            //str += SendImageToPrinter(520, 15, bxp);
            //str += "A140,100,0,4,1,1,N,\"Patents apply\"\n";
            //str += "A120,150,0,4,1,1,N,\"to this product.\"\n";
            //str += "A50,200,0,4,1,1,N,\"See www.zygo.com/patents.\"\n";
            //str += "A50,325,0,3,1,1,N,\"MADE IN TAIWAN\"\n";
            //str += "P" + labelQuantity + "\n";

            ToPrint();
        }

        private void button3_Click(object sender, EventArgs e)
        {
         /*   str = "\nN\nq456.75Q253.75,20\n";
            str += SendImageToPrinter(10, 15, bzp);
            str += SendImageToPrinter(300, 15, bxp);
            str += "A30,80,0,2,1,1,N,\"COMPLIES WITH 21 CFR 1040-10 &\"\n";
            str += "A30,100,0,2,1,1,N,\"1040-11 EXCEPT FOR CONFORMANCE\"\n";
            str += "A30,120,0,2,1,1,N,\"WITH IEC 60825-1 ED.3. \"\n";
            str += "A30,140,0,2,1,1,N,\"AS DESCRIBED IN LASER NOTICE \"\n";
            str += "A30,160,0,2,1,1,N,\"NO. 56, DATED MAY 8,2019\"\n";
            str += "A45,185,0,2,1,1,N,\"Patents aply to this product.\"\n";
            str += "A65,205,0,2,1,1,N,\"See www.zygo.com/patents.\"\n";
            str += "A15,230,0,2,1,1,N,\"MADE IN USA, Middlefield, CT 06455\"\n";
            str += "P" + labelQuantity + "\n";
         */ /* ten over */
            str = "\nN\nq456.75Q253.75,20\n";
            str += SendImageToPrinter(20, 15, bzp);
            str += SendImageToPrinter(310, 15, bxp);
            str += "A40,80,0,2,1,1,N,\"COMPLIES WITH 21 CFR 1040-10 &\"\n";
            str += "A40,100,0,2,1,1,N,\"1040-11 EXCEPT FOR CONFORMANCE\"\n";
            str += "A40,120,0,2,1,1,N,\"WITH IEC 60825-1 ED.3. \"\n";
            str += "A40,140,0,2,1,1,N,\"AS DESCRIBED IN LASER NOTICE \"\n";
            str += "A40,160,0,2,1,1,N,\"NO. 56, DATED MAY 8,2019\"\n";
            str += "A55,185,0,2,1,1,N,\"Patents aply to this product.\"\n";
            str += "A75,205,0,2,1,1,N,\"See www.zygo.com/patents.\"\n";
            str += "A25,230,0,2,1,1,N,\"MADE IN USA, Middlefield, CT 06455\"\n";
            str += "P" + labelQuantity + "\n";

            ToPrint();
        }

        private void ToPrint()
        {
            labelQuantity = "1";

            Bitmap bzp = Properties.Resources.zygo_blk_noR_203;
            Bitmap bxp = Properties.Resources.ametek_blk_noR_132;

            /*
             *  Add the image to the resources folder or elsewhere, then add the file to the
             *  resourses.resx file and it will take in the file and reclassify it as an image.
             *  It should then be available under properties.resources - the case does matter for 
             *  the image name.
             */

            RawPrinterHelper.SendStringToPrinter(printer, str);

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

        private void button4_Click(object sender, EventArgs e)
        {
            bzp = Properties.Resources.zygo_blk_R_203;

            
            str = "\nN\nq456.75Q253.75,20\n";
            str += SendImageToPrinter(20, 15, bzp);
            str += SendImageToPrinter(310, 15, bxp);
            str += "A20,85,0,3,1,1,N,\"THIS PRODUCT CONFORMS WITH DHHS\"\n";
            str += "A20,110,0,3,1,1,N,\"RADIATION PERFORMANCE STANDARD,\"\n";
            str += "A30,135,0,3,1,1,N,\"21 CFR CHAPTER I SUBCHAPTER J\"\n";
            str += "A60,170,0,2,1,1,N,\"Patents apply to this product.\"\n";
            str += "A80,190,0,2,1,1,N,\"See www.zygo.com/patents.\"\n";
            str += "A30,225,0,2,1,1,N,\"MADE IN USA, Middlefield, CT 06455\"\n";
            str += "P" + labelQuantity + "\n";
            
            
            //printer = "ZDesigner ZD421-203dpi ZPL";
            ToPrint();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            str = "\nN\nq456.75Q253.75,20\n";
            str += "A115,15,0,3,1,1,N,\"ZYGO CORPORATION\"\n";
            str += "A90,40,0,3,1,1,N,\"MIDDLEFIELD,CT 06455\"\n";
            str += "A140,65,0,3,1,1,N,\"MADE IN USA\"\n";
            str += "A20,110,0,3,1,1,N,\"THIS PRODUCT CONFORMS WITH DHHS\"\n";
            str += "A20,135,0,3,1,1,N,\"RADIATION PERFORMANCE STANDARD,\"\n";
            str += "A30,160,0,3,1,1,N,\"21 CFR CHAPTER I SUBCHAPTER J\"\n";
            str += "A60,195,0,2,1,1,N,\"Patents apply to this product.\"\n";
            str += "A80,215,0,2,1,1,N,\"See www.zygo.com/patents.\"\n";

            str += "P" + labelQuantity + "\n";

            //printer = "ZDesigner ZD421-203dpi ZPL";
            //printer = "\\\\CT-MID-PS01\\ZEBRASN48";
            ToPrint();


        }
    }
}

