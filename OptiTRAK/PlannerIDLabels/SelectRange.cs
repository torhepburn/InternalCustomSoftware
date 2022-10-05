using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace PlannerIDLabels
{
    public partial class SelectRange : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        string db = "server = CT-MID-SQL01; password = Read+Write!; " +
                    "user = readwrite; database = OptiTRAK;";
        private string startSFO;
        private string endSFO;
        private string customer;
        private string elementname;
        private string jobfolder;
        private string sfo;
        private string partsnID;
        private int i = 0;
        private string labelQuantity;
        private string printerLarge;
        private string printerSmall;

        public SelectRange()
        {
            InitializeComponent();
        }

        private void SelectRange_Load(object sender, EventArgs e)
        {
            string computername = Environment.MachineName;

            SqlConnection cnxn1 = new SqlConnection("server = CT-MID-SQL01; password = Read+Write!; " +
                    "user = readwrite; database = AccessFrontEnds;");

            try
            {
                da = new SqlDataAdapter(
                 " Select permission, permissionvalue, pcid from applicationsetup " +
                 " where application = 'optitraklabels' " +
                 " and pcid = '" + computername + "'" +
                 " order by permission ", cnxn1);
                DataTable table = new DataTable();
                da.Fill(table);



                if (table.Rows.Count == 2)
                {
                    if (table.Rows[0][2].ToString().Contains("MID"))
                    {
                        printerLarge = "\\\\midprtsrv\\" + table.Rows[0][1].ToString().Trim();
                        printerSmall = "\\\\midprtsrv\\" + table.Rows[1][1].ToString().Trim();
                    }
                    else
                    {
                        printerLarge = "\\\\ricprintsrv\\" + table.Rows[0][1].ToString().Trim();
                        printerSmall = "\\\\ricprintsrv\\" + table.Rows[1][1].ToString().Trim();
                    }
                }
                else
                {
                    MessageBox.Show("This computer (" + computername + ") does not have permission to use this program.");
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn1.Close();
            }

            rbLarge.Checked = true;
            rbQ1.Checked = true;

            cnxn = new SqlConnection(db);

            try
            {
                da = new SqlDataAdapter
                ("Select prodordnum SFO " +
                 "from tblPartSN p " +
                 "inner join tblJobInfo j on p.jobid = j.jobid " +
                 "where partpoclosed != -1 and jobcomplete != -1 " +
                "order by prodordnum", cnxn);
                DataTable tableStart = new DataTable();
                da.Fill(tableStart);
                DGVstart.DataSource = tableStart;
                DataTable tableEnd = new DataTable();
                da.Fill(tableEnd);
                DGVend.DataSource = tableEnd;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnxn.Close();


            DGVstart.Columns[0].Width = 60;

            DGVend.Columns[0].Width = 60;
        }
            

        private void DGVstart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 1)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGVstart.Rows[e.RowIndex].Cells[0];
                startSFO = cell.EditedFormattedValue.ToString().Trim();
            }
        }

        private void DGVend_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 1)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGVstart.Rows[e.RowIndex].Cells[0];
                endSFO = cell.EditedFormattedValue.ToString().Trim();

                if (string.IsNullOrEmpty(startSFO))
                {
                    MessageBox.Show("Must select a Start SFO first. ");
                    return;
                }
                else
                {
                    SqlConnection cnxn = new SqlConnection(db);

                    SqlCommand cmd = new SqlCommand
                        ("Select Customer, ElementName, PartSN ID, prodordnum SFO, " +
                         "jobfolder " +
                         "from tblPartSN p " +
                         "inner join tblJobInfo j on p.jobid = j.jobid " +
                        "where prodordnum >= " + startSFO +
                        " and prodordnum <= " + endSFO +
                        "and partpoclosed != -1 " +
                        "and jobcomplete != -1 " +
                        "order by prodordnum ", cnxn);

                    cnxn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        if (!dr.IsDBNull(0)) { customer = dr.GetString(0).Trim(); }
                        if (!dr.IsDBNull(1)) { elementname = dr.GetString(1).Trim(); }
                        if (!dr.IsDBNull(2)) { partsnID = dr.GetString(2).Trim(); }
                        if (!dr.IsDBNull(3)) { sfo = dr.GetInt32(3).ToString(); }
                        if (!dr.IsDBNull(4)) { jobfolder = dr.GetString(4).Trim(); }
                        else { jobfolder = ""; }
                        if (jobfolder.IndexOf("\\") > -1)
                        {
                            jobfolder = jobfolder.Replace("\\", "/");
                        }
                        
                    }

                    if (rbQ1.Checked) { labelQuantity = "1";}
                    if (rbQ2.Checked) { labelQuantity = "2";}
                    if (rbQ3.Checked) { labelQuantity = "3";}
                    if (rbQ4.Checked) { labelQuantity = "4";}

                    if (rbSmall.Checked)
                    {
                        string str = "\nN\nq609Q203,20\n";
                        str += "A10,10,0,4,1,1,N,\"" + customer + "\"\n";
                        str += "A350,10,0,4,1,1,N,\"SFO: \"\n";
                        str += "A420,10,0,4,1,1,N,\"" + sfo + "\"\n";
                        str += "A100,80,0,4,1,1,N,\"" + elementname + "\"\n";
                        str += "A10,150,0,4,1,1,N,\"" + jobfolder + "\"\n";
                        str += "A350,150,0,4,1,1,N,\"ID: \"\n";
                        str += "A400,150,0,4,1,1,N,\"" + partsnID + "\"\n";
                        
                        str += "P" + labelQuantity + "\n";
                        RawPrinterHelper.SendStringToPrinter(printerSmall, str);
                    }
                    else
                    {
                        string str = "\nN\nq812Q507,20\n";
                        str += "A20,10,0,4,1,1,N,\"" + customer + "\"\n";
                        str += "A550,10,0,4,1,1,N,\"SFO: \"\n";
                        str += "A620,10,0,4,1,1,N,\"" + sfo + "\"\n";
                        str += "A200,150,0,4,1,1,N,\"" + elementname + "\"\n";
                        str += "A20,300,0,4,1,1,N,\"" + jobfolder + "\"\n";
                        str += "A550,300,0,4,1,1,N,\"ID: \"\n";
                        str += "A620,300,0,4,1,1,N,\"" + partsnID + "\"\n";
                        
                        str += "P" + labelQuantity + "\n";
                        
                        RawPrinterHelper.SendStringToPrinter(printerLarge, str);
                    }
                }
            }
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            Lprinter.Text = "Printing on: " + printerSmall;
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            Lprinter.Text = "Printing on: " + printerLarge;
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