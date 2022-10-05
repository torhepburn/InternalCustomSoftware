using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace PPS_PD_Label_Output
{
    public partial class F1_Start : Form
    {
        SqlConnection cnxn;
        private string board;
        private string boardRev;
        private string firmware;
        private string firmwareRev;

        private string productionOrder;
        public F1_Start()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void bGetData_Click(object sender, EventArgs e)
        {
            int quantity;
            if (Int32.TryParse(tbQuantity.Text.Trim(), out quantity))
            {
               
            }
            else
            {
                MessageBox.Show("Must enter a number.");
                tbQuantity.Text = String.Empty;
                tbQuantity.Focus();
                return;
            }
            
            
            if (tbPDNumber.Text.Length> 0)
            {
                productionOrder = tbPDNumber.Text.Substring(0, tbPDNumber.Text.IndexOf('/')).ToUpper();

                cnxn = new("server=PA-HOR-AS408; user=navdb_read; password=2018#ameteK;" +
                           "database=ZYGO-NAV-PROD; encrypt=false;");

                SqlCommand cmd = new("select " +
                    "pbl.[Production BOM No_] " +
                    ",i.[Revision Level] " +
                    ",pbl.No_ " +
                    ",ii.[Revision Level] " +
                    "from [ZYGO$Prod_ Order Line] pol " +
                    "INNER JOIN[ZYGO$Production BOM Line] pbl ON pol.[Item No_] = pbl.[Production BOM No_] " +
                    "INNER JOIN ZYGO$Item i ON pbl.[Production BOM No_] = i.No_ " +
                    "INNER JOIN ZYGO$Item ii ON pbl.[No_] = ii.No_ " +
                    "WHERE pol.[Prod_ Order No_] = '" + productionOrder + "' " +
                    "AND pbl.No_ LIKE 'SPM%'", cnxn);

                try
                {
                    DataTable table = new DataTable();

                    cnxn.Open();

                    SqlDataReader dr;

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        board = dr.GetString(0).Trim();
                        boardRev = dr.GetString(1).Trim();
                        firmware = dr.GetString(2).Trim();
                        firmwareRev = dr.GetString(3).Trim();
                    }
                    //table.Load(dr);
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    cnxn.Close();

                }

                File.WriteAllText(@"C:\labels\pn.txt", board);
                File.WriteAllText(@"C:\labels\pnREV.txt", boardRev);
                File.WriteAllText(@"C:\labels\fw.txt", firmware);
                File.WriteAllText(@"C:\labels\fwREV.txt", firmwareRev);


                for (int i = 0; i < quantity; i++)
                {
                    Process P = new Process();
                    P.StartInfo.FileName = @"C:\Program Files (x86)\Seagull\BarTender Suite\bartend.exe";
                    P.StartInfo.Arguments = @" /F=C:\labels\pn-fw.btw /P /X";
                    //P.StartInfo.Arguments = @" /F=C:\labels\pn-fw.btw";
                    P.Start();
                }
                //string printer = "ZDesigner GK420t";

                /*

                //string printer = @"\\ct-mid-ps01\zebraSN16";

                string str = "\nN\nq609Q203,20\n";
                //str += SendImageToPrinter(10, 10, bzp);
                //str += SendImageToPrinter(450, 10, bxp);
                //str += "A144,10,0,2,1,1,N,\"21 Laurel Brook Road\"\n";
                //str += "A144,35,0,2,1,1,N,\"Middlefield, CT 06455 USA\"\n";
                //str += "A10,70,0,2,1,1,N,\"PN#\"\n";
                str += "B50,65,0,1,2,4,32,B,\"" + board + "\"\n";
                str += "B400,65,0,1,2,4,32,B,\"" + boardRev + "\"\n";
                //str += "A142,60,0,2,1,1,N,\"" + boardRev + "\"\n";
                //str += "A142,80,0,2,1,1,N,\"" + firmware + "\"\n";
                //str += "A420,100,0,2,1,1,N,\"" + line3 + "\"\n";
                //str += "A10,140,0,2,1,1,N,\"SN#\"\n";
                str += "B50,135,0,1,2,4,32,B,\"" + firmware + "\"\n";
                str += "B400,135,0,1,2,4,32,B,\"" + firmwareRev + "\"\n";
                //str += "A420,125,0,2,1,1,N,\"" + Rev + "\"\n";
                //str += "A420,150,0,2,1,1,N,\"" + Qty + "\"\n";
                //str += "A420,175,0,2,1,1,N,\"" + Part + "\"\n";
                str += "P1\n";
                RawPrinterHelper.SendStringToPrinter(printer, str);

                */

                //StringBuilder ZplBuilder = new StringBuilder();


                // Exemple ZPL String

                ////ZplBuilder.Append("~WC");   //prints configuration label

                ////ZplBuilder.Append("~JC");   //set media sensor calibration

                ////use Zebra Setup Utilities to set label size if can't get to work with code


                //ZplBuilder.Append("^XA");   //Start ZPL

                //barcode
                //ZplBuilder.Append("^FO20,20");
                //ZplBuilder.Append("^BQN,2,4,M");
                //ZplBuilder.Append("^BXN,2,50");
                //ZplBuilder.Append("^FDMA,8020-0104-11");
                //ZplBuilder.Append("^FDMA,KIT 8020-0104-11 REV D SPM8020-9280-01 REV H");
                //ZplBuilder.Append("AQID:").Append(tbAQID.Text.Trim()).Append(";");
                //ZplBuilder.Append("SERIAL:").Append(tbSerialNumber.Text.Trim()).Append(";");
                //ZplBuilder.Append("APO:").Append(tbPO.Text.Trim()).Append(";");
                //ZplBuilder.Append("MODEL:").Append(tbModel.Text.Trim()).Append(";");
                //ZplBuilder.Append("RFID:").Append(tbRFID.Text.Trim()).Append(";");

                //ZplBuilder.Append("^FS");

                //ZplBuilder.Append("^FO60,10^A0N,20,15^FD").Append(board.Trim()).Append("^FS");
                //ZplBuilder.Append("^FO500,100^A0N,35,30^FDAPPLE^FS");
                //ZplBuilder.Append("^FO300,140^A0N,35,30^FDAQID # ").Append(tbAQID.Text.Trim()).Append("^FS");
                //ZplBuilder.Append("^FO300,180^A0N,35,30^FDSERIAL # ").Append(tbSerialNumber.Text.Trim()).Append("^FS");
                //ZplBuilder.Append("^FO300,220^A0N,35,30^FDPO # ").Append(tbPO.Text.Trim()).Append("^FS");
                //ZplBuilder.Append("^FO300,260^A0N,35,30^FDMODEL # ").Append(tbModel.Text.Trim()).Append("^FS");
                //ZplBuilder.Append("^FO300,300^A0N,35,30^FDRFID # ").Append(tbRFID.Text.Trim()).Append("^FS");
                ////ZplBuilder.Append("^FO400,270^A0N,35,30^FDHz^FS");
                //ZplBuilder.Append("^FO440,270^A0N,35,30^FD").Append(tbHertz.Text.Trim()).Append("^FS");

                //ZplBuilder.Append("^FO20,310^A0N,35,30^FDVOLTS^FS");
                //ZplBuilder.Append("^FO140,310^A0N,35,30^FD").Append(tbVolts.Text.Trim()).Append("^FS");

                //ZplBuilder.Append("^FO400,310^A0N,35,30^FDAMPS^FS");
                //ZplBuilder.Append("^FO480,310^A0N,35,30^FD").Append(tbAmps.Text.Trim()).Append("^FS");


                //ZplBuilder.Append("^FO160,350^A0N,30,40^FDMADE IN TAIWAN^FS");
                /*
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

                                RawPrinterHelper.SendBytesToPrinter("ZDesigner GK420t", cpUnmanagedBytes, cnLength);
                                //RawPrinterHelper.SendBytesToPrinter(g.printer, cpUnmanagedBytes, cnLength);
                                Marshal.FreeCoTaskMem(cpUnmanagedBytes);


                                */

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
