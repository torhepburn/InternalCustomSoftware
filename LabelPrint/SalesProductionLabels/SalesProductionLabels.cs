using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;

namespace SalesProductionLabels
{
    public partial class SalesProductionLabels : Form
    {
        private string line1;
        private string line2;
        private string line3;
        private string labelQuantity;
        private string quantityPerLabel;
        private int firstLastIndex;
        private int secondLastIndex;
        private bool standard = false;
        private bool custom = false;
        private bool printCheckQty = false;
        private bool multiLevel = false;
        private string iDescription;
        private string dbMID = "user=readWrite; password=Read+Write!; " +
                    "server=CT-MID-SQL11.ametek.com; database=AccessFrontEnds;encrypt=false;";
        public static string dbNAV = "server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
                            "user = navdb_read; database = ZYGO-NAV-PROD;encrypt=false;";
        private string NAVprefix = "ZYGO$";
        private string query = string.Empty;
        private string parent = string.Empty;
        //private string printer = string.Empty;
        private string printer = @"\\CT-MID-PS01\ZEBRASN17";
        private string description = string.Empty;
        private string lineNo;
        private string reference = " WHERE 1=1 ";

        SqlConnection cnxn;
        SqlConnection cnxnInsideLoop;
        SqlDataReader dr;
        SqlDataReader drMulti;
        DataTable dtLines;
        SqlCommand cmd;


        public SalesProductionLabels()
        {
            InitializeComponent();
        }

        private void SalesProductionLabels_Load(object sender, EventArgs e)
        {
            //this.SuspendLayout();
        }

        private void BPrint_Click(object sender, EventArgs e)  //Print button
        {
            tbSalesOrder.Text = tbSalesOrder.Text.Trim().ToUpper();

            /*  This is the selection query for the label 
            *  
            *  It is defined here but not used until the 300s 
            *  where there is a lot of conditional coding going on
            *
            */

            query = "SELECT " +
                    " l.No_ " +
                    ",l.[Description] " +
                    ",l.[Document No_] " +
                    ",CAST(l.[SO Line No_] as varchar(4)) [SO Line No_] " +
                    ",COALESCE(b.[Bin Code],'') " +
                    ",cast(l.[Quantity] as decimal(11,2)) Quantity " +
                    ",l.[No_] " +
                    ",CAST(COALESCE(l.[SO Line No_],0) as varchar(6)) " +
                    "FROM " +
                    "[ZYGO$Sales Line] l " +
                    "INNER JOIN [ZYGO$Item] i " +
                    "ON l.No_ = i.No_ " +
                    "LEFT JOIN [ZYGO$Bin Content] b ON l.No_ = b.[Item No_] " +
                    reference +
                    "AND [Document No_] = '" + tbSalesOrder.Text + "' " + 
                    "AND [SO Line No_] < 400 " +
                    "and b.[Default] = 1 " +
                    "AND b.[Bin Code] NOT LIKE '%MRB%' " +
                    "ORDER BY CAST([SO Line No_] as int) ";

            SqlConnection cnxn = new SqlConnection(dbNAV);

            try
            {
                cmd = new SqlCommand(query, cnxn);

                cmd.Connection = cnxn;

                if (cnxn.State == ConnectionState.Closed)
                {
                    cnxn.Open();
                }

                dr = cmd.ExecuteReader();

                DataTable t = new DataTable();
                t.Load(dr);

                dr = cmd.ExecuteReader();

                QtyGreaterThan1();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            tbSalesOrder.Text = "";

        }

        private void QtyGreaterThan1()
        {
            while (dr.Read())
            {
                iDescription = dr.GetString(1).ToString();

                parseDescription();

                printCheckQty = false;

                //if (dr.GetDecimal(5) > 1)
                //{
                //    //printCheckQty = true;
                //    //check bulk pack
                //    //BulkPack(dr.GetString(0), dr.GetString(1), dr.GetDecimal(5));
                //}
                //else if (dr.GetDecimal(5) < 0)
                //{
                    labelQuantity = "1";
                    quantityPerLabel = dr.GetDecimal(5).ToString();
                //}
                //else
                //{
                //    labelQuantity = "1";
                //    quantityPerLabel = "1";
                //}

                printLabels();
            }
        }


        private void printLabels()
        {
            string str = string.Empty;

            str = string.Empty;


            //string printer = "ZDesigner ZD421-203dpi ZPL";

            str = "\nN\nq609Q203,20\n";
            
            if (printCheckQty)
            {
                str += "A150,20,0,3,1,1,N,\"** CHECK QUANTITY **\"\n";
            }

            str += "A10,60,0,2,1,1,N,\"PN#\"\n";
            str += "B50,55,0,1,2,4,32,B,\"" + dr.GetString(0).ToString() + "\"\n";
            str += "A400,60,0,2,1,1,N,\"" + line1 + "\"\n";
            str += "A400,80,0,2,1,1,N,\"" + line2 + "\"\n";
            str += "A400,100,0,2,1,1,N,\"" + line3 + "\"\n";

            str += "A10,130,0,2,1,1,N,\"OR#\"\n";

            string dropPD = dr.GetString(2).Replace("PD", "");
            str += "B50,125,0,1,2,4,32,B,\"" + dropPD + "\"\n";

            str += "A220,125,0,2,1,1,N,\"POS:" + dr.GetString(3) + "\"\n";


            str += "A350,125,0,2,1,1,N,\"LINE NO:" + dr.GetString(7) + "\"\n";

            str += "A350,145,0,2,1,1,N,\"BIN: " + dr.GetString(4) + "\"\n";
            str += "A220,165,0,2,1,1,N,\"" + DateTime.Now.Date.ToString("MM/dd/yy") + "\"\n";
            str += "A350,165,0,2,1,1,N,\"QTY: " + quantityPerLabel + "\"\n";
            str += "P" + labelQuantity + "\n";

            RawPrinterHelper.SendStringToPrinter(printer, str);

            quantityPerLabel = string.Empty;
            labelQuantity = string.Empty;
        }


        private void parseDescription()
        {
            int descriptionLength = iDescription.Length;

            if (descriptionLength < 15)
            {
                line1 = iDescription.Trim();
                line2 = "";
                line3 = "";
            }
            else   /*   description length is greater than 14   */
            {
                string a = iDescription.Substring(0, 14);

                if (a.LastIndexOf(",") != -1)
                {
                    firstLastIndex = a.LastIndexOf(",");
                    line1 = iDescription.Substring(0, firstLastIndex + 1);
                }
                else if (a.LastIndexOf(" ") != -1)
                {
                    firstLastIndex = a.LastIndexOf(" ");
                    line1 = iDescription.Substring(0, firstLastIndex);
                }
                else
                {
                    line1 = iDescription.Substring(0, 14);
                    firstLastIndex = 13;
                }

                /* if the first character of the second line is a space 
                 * then start at the next character
                 */

                if (iDescription.Length > 15)
                {
                    if (iDescription.Substring(firstLastIndex + 1, 1) == " ")
                        firstLastIndex += 1;
                }


                if (iDescription.Substring(firstLastIndex + 1, descriptionLength - (firstLastIndex + 1)).Length > 14)
                {
                    string b = iDescription.Substring(firstLastIndex + 1, 14);

                    if (b.LastIndexOf(",") != -1)
                    {
                        secondLastIndex = b.LastIndexOf(",");
                        line2 = iDescription.Substring(firstLastIndex + 1, secondLastIndex + 1);
                    }
                    else if (b.LastIndexOf(" ") != -1)
                    {
                        secondLastIndex = b.LastIndexOf(" ");
                        line2 = iDescription.Substring(firstLastIndex + 1, secondLastIndex);
                    }
                    else if (b.ToUpper().LastIndexOf("X") != -1)
                    {
                        secondLastIndex = b.ToUpper().LastIndexOf("X");
                        line2 = iDescription.Substring(firstLastIndex + 1, secondLastIndex);
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
                    line2 = iDescription.Substring(firstLastIndex + 1, descriptionLength - (firstLastIndex + 1));
                    secondLastIndex = -1;
                }

                if (secondLastIndex != -1)
                {
                    line3 = iDescription.Substring(firstLastIndex + secondLastIndex + 2, descriptionLength -
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
                    line1 = iDescription.Substring(0, 14);

                    if (descriptionLength > 28)
                    {
                        line2 = iDescription.Substring(14, 14);
                    }
                    else  //( descriptionLength <= 28 )
                    {
                        line2 = iDescription.Substring(14, descriptionLength - 14);
                    }

                    if (descriptionLength > 28)
                    {
                        line3 = iDescription.Substring(28, descriptionLength - 28);
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
