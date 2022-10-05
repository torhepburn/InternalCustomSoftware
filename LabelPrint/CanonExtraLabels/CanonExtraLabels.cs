using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;

namespace CanonExtraLabels
{
    public partial class CanonExtraLabels : Form
    {
        SqlConnection cnxn;
        SqlDataAdapter da;
        DataTable table;
        private string ZygoPN;
        private string CanonPN;
        private string iDescription;
        private string item;
        private string printQuantity;
        private string printer;
        private string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                            "user = readwrite; database = AccessFrontEnds;";
        private string rootSql = "SELECT " +
                                 "Zygo_PN " +
                                 ",Canon_PN " +
                                 ",Item_Description " +
                                 "FROM [Labels].[ZygoAmetekCanonMappings] ";

        public CanonExtraLabels()
        {
            InitializeComponent();
        }

        private void CanonExtraLabels_Load(object sender, EventArgs e)
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

            SqlConnection cnxn = new SqlConnection(db);

            try
            {
                SqlCommand cmd = new SqlCommand(
                 " Select permission, permissionvalue from applicationsetup " +
                 " where application = 'CANON EXTRA LABELS' and " +
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
                    MessageBox.Show("Either this user " + user + " or this computer (" + computername + ") does not have permission to use this program: CANON EXTRA LABELS.");
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


            this.Text = "Canon Extra Labels v" + Application.ProductVersion.Trim();

            cnxn = new SqlConnection(db);

            try
            {
                cnxn.Open();
                da = new SqlDataAdapter(
                    rootSql + "order by zygo_pn "
                    , cnxn);
                table = new DataTable();
                da.Fill(table);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            DGV.DataSource = table;
            DGV.Show();
            DGV.Columns[0].Width = 100;
            DGV.Columns[1].Width = 150;
            DGV.Columns[2].Width = 240;
        }



        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            da = new SqlDataAdapter
                (rootSql +
                 " where Zygo_pn like '%" + tbSearchPartNumber.Text + "%' " +
                 "or item_description like '%" + tbSearchPartNumber.Text + "%' " +
                 "or Canon_PN like '%" + tbSearchPartNumber.Text + "%' " +
                 " order by zygo_pn", cnxn);
            DataTable table = new DataTable();
            da.Fill(table);
            DGV.DataSource = table;
        }

        private void bItem_Click(object sender, EventArgs e)
        {
            printLabels();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex < 3)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                ZygoPN = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                CanonPN = cell.EditedFormattedValue.ToString().Trim();
                cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                iDescription = cell.EditedFormattedValue.ToString().Trim();

                bItem.Text = "Print: " + ZygoPN;
            }
        }

        private void printLabels()
        {

            if (rb1.Checked)
            {
                printQuantity = "1";
            }

            if (rb5.Checked)
            {
                printQuantity = "5";
            }

            if (rb10.Checked)
            {
                printQuantity = "10";
            }

            if (rb25.Checked)
            {
                printQuantity = "25";
            }

            /*  special labels  */
            //CanonPN = "";
            //ZygoPN = "8070-0278-11";
            //iDescription = "7714 6mm RoHS";
            //ZygoPN = "8070-0278-12";
            //iDescription = "(a)7714 8mm RoHS";

            string str = "\nN\nq609Q203,20\n";
            str += "A60,10,0,3,1,1,N,\"Canon P/N\"\n";
            //str += "A270,10,0,3,1,1,N,\"" + CanonPN + "\"\n";
            str += "LO20,30,600,2\n";
            str += "A60,40,0,3,1,1,N,\"Zygo P/N\"\n";
            str += "A270,40,0,3,1,1,N,\"" + ZygoPN + "\"\n";
            str += "LO20,60,600,2\n";
            str += "A60,70,0,3,1,1,N,\"Description\"\n";
            str += "A270,70,0,3,1,1,N,\"" + iDescription + "\"\n";
            str += "LO20,90,600,2\n";
            str += "A60,100,0,3,1,1,N,\"S/N\"\n";
            str += "LO20,120,600,2\n";
            str += "LO260,10,2,110\n";
            str += "B50,135,0,1,2,4,32,B,\"" + ZygoPN + "\"\n";
            str += "P" + printQuantity + "\n";
            RawPrinterHelper.SendStringToPrinter(printer, str);

            ZygoPN = string.Empty;
            CanonPN = string.Empty;
            iDescription = string.Empty;
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
