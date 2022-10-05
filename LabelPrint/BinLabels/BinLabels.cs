using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Threading;
using System.Runtime.InteropServices;

namespace BinLabels
{
    public partial class BinLabels : Form
    {
        SqlDataReader dr;
        SqlCommand cmd;
        SqlConnection cnxn;
        private string db = "server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
                            "user = navdb_read; database = ZYGO-NAV-PROD;";
        private string printer;


        public BinLabels()
        {
            InitializeComponent();
        }

        private void BinLabels_Load(object sender, EventArgs e)
        {
            this.Text = "Print Bin Labels v" + Application.ProductVersion;

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

            SqlConnection cnxn = new SqlConnection(
                "server = ct-mid-sql11; password = views; user = views; database = accessfrontends;");

            try
            {
                    SqlCommand cmd = new SqlCommand(
                     " Select permission, permissionvalue from applicationsetup " +
                     " where application = 'BINLABELS.EXE' and " +
                     " pcid = '" + computername + "' " +
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
                        MessageBox.Show("Either this user " + user + " or this computer (" + computername + ") does not have permission to use this program.");
                        this.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            
            cmd = new SqlCommand(
                "Select " +
                "[Source No_] " +
                ",[Description] " +
                ",[No_]" +
                ",FORMAT(Quantity, '##0') Quantity " +
                ",[Due Date] " +
                "from [ZYGO$Production Order] " +
                "where " +
                "[No_] >= '" + tbStart.Text.Trim().ToUpper()+
                "' and [No_] <='" + tbEnd.Text.Trim().ToUpper() +
                "' order by [No_]", cnxn);

            DataTable dt = new DataTable();

            try
            {
                cnxn.Open();
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    send2Printer();
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

            if (cbMultiLevel.Checked)
            {
                cmd = new SqlCommand(
                    "SELECT " +
                    "[Item No_]" +
                    ",[Description]" +
                    " ,[Prod_ Order No_] " +
                    ",FORMAT(Quantity, '##0') Quantity" +
                    ",[Due Date]" +
                    "from [ZYGO$Prod_ Order Component] " +
                    "WHERE [Prod_ Order No_] = " +
                    "'" + dt.Rows[0][2].ToString() + "' " +
                    "AND [Item Low-Level Code] > 0 " +
                    "ORDER BY [Item No_]", cnxn);
                try
                {
                    DataTable test = new DataTable();
                    cnxn.Open();
                    dr = cmd.ExecuteReader();
                    test.Load(dr);
                     dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        send2Printer();
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

            tbEnd.Text = "";
            tbStart.Text = "";

            cbMultiLevel.Checked = false;
        }

        private void send2Printer()
        {
            /*
             * This code is for EPL print language
              * 
              * q = set label width in dots (width = Y dimension)
              * Q = set form length in dots (for us 203 dpi and length = X dimension)
              * the 20 is the gap between the labels
              * LO draws a line
              * all the lines need \n at the end to print
              * 
              * */
            string str = "\nN\nq812Q609,203\n";
            str += "A30,20,0,4,1,1,N,\"SFO#\"\n";
            str += "B100,20,0,1,2,4,32,B,\"" + dr.GetString(2) + "\"\n";
            str += "A30,120,0,4,1,1,N,\"PN#\"\n";
            str += "B100,120,0,1,2,4,32,B,\"" + dr.GetString(0) + "\"\n";
            if (cbMultiLevel.Checked)
            {
                str += "A30,200,0,5,1,1,N,\"" + "SUB " + dr.GetString(0) + " SUB" +"\"\n";
            }
            else
            {
                str += "A30,200,0,5,1,1,N,\"" + dr.GetString(0) + "\"\n";
            }
            str += "A30,280,0,3,1,1,N,\"DESC:\"\n";
            str += "A110,280,0,4,1,1,N,\"" + dr.GetString(1) + "\"\n";
            str += "A30,350,0,4,1,1,N,\"BIN: 1 of 1\"\n";
            str += "A350,385,0,4,1,1,N,\"QTY :\"\n";
            str += "A450,385,0,4,1,1,N,\"" + dr.GetString(3) + "\"\n";
            str += "A350,420,0,4,1,1,N,\"START:\"\n";
            str += "A450,420,0,4,1,1,N,\"" + dr.GetDateTime(4).ToShortDateString() + "\"\n";
            str += "A30,500,0,4,1,1,N,\"Pulled by:\"\n";
            str += "A350,500,0,4,1,1,N,\"Pulled on:\"\n";
            str += "LO30,550,800,2\n";
            str += "LO30,700,800,2\n";
            str += "P" + tbLabelQuantity.Text + "\n";
            RawPrinterHelper.SendStringToPrinter(printer, str);
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
