using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace CanonLabelPrint
{
    public partial class Canon9999AJLabels : Form
    {
        SqlConnection cnxn = new SqlConnection(g.db);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable table;
        private object o;
        private string sn;
        private string printQuantity;

        public Canon9999AJLabels()
        {
            InitializeComponent();
        }

        private void CanonLabelList_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void bSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand(
                    "UPDATE labels.canonlabels " +
                    "SET PRINTthis = 1, " +
                    "PRINTextraLabels = 0 " +
                    "where " +
                    "PICKING_LIST_NUMBER = '" + g.pickingListNumber + "'"
                    , cnxn);
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();

                GetData();
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

        private void bClear_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand(
                    "UPDATE labels.canonlabels " +
                    "SET PRINTthis = 0, " +
                    "PRINTextraLabels = 0 " + 
                    "where " +
                    "PICKING_LIST_NUMBER = '" + g.pickingListNumber + "'"
                    , cnxn);
                cnxn.Open();
                cmd.ExecuteNonQuery();
                cnxn.Close();

                GetData();
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

        private void GetData()
        {
            try
            {
                cnxn.Open();
                da = new SqlDataAdapter(
                    "select " +
                    "printThis [Print], " +
                    "PrintExtraLabels, " +
                    "ZygoSN, " +
                    "Barcode [Bar Code], " +
                    "SerializeThis [Serialize], " +
                    "Serialized [Line No], " +
                    "Order_no, " +
                    "position POS, " +
                    "Customer, " +
                    "Item_Code [Item Code], " +
                    "Delivered_quantity [Deliver Qty], " +
                    "Customer_PO [Customer PO], " +
                    "id " +
                    "from labels.CanonLabels " +
                    "where " +
                    "PICKING_LIST_NUMBER = '" + g.pickingListNumber + "' " +
                    "order by position, serialized", cnxn);
                table = new DataTable();
                da.Fill(table);
                cnxn.Close();
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
            DGV.Columns[0].Width = 50;
            DGV.Columns[1].Width = 50;
            DGV.Columns[2].Width = 100;
            DGV.Columns[3].Width = 50;
            DGV.Columns[3].ReadOnly = true;
            DGV.Columns[4].Width = 50;
            DGV.Columns[4].ReadOnly = true;
            DGV.Columns[5].Width = 50;
            DGV.Columns[5].ReadOnly = true;
            DGV.Columns[7].Width = 100;
            DGV.Columns[6].ReadOnly = true;
            DGV.Columns[7].Width = 50;
            DGV.Columns[7].ReadOnly = true;
            DGV.Columns[8].Width = 60;
            DGV.Columns[8].ReadOnly = true;
            DGV.Columns[9].Width = 80;
            DGV.Columns[9].ReadOnly = true;
            DGV.Columns[10].Width = 50;
            DGV.Columns[10].ReadOnly = true;
            DGV.Columns[11].Width = 200;
            DGV.Columns[11].ReadOnly = true;
            DGV.Columns[12].Visible = false;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            // create valid update command
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(table);

            try
            {
                cmd = new SqlCommand(
                        "Select id from labels.canonlabels where " +
                        "picking_list_number = '" + g.pickingListNumber + "' " +
                        "and serializethis = 1 " +
                        "and zygoSN is null " +
                        "and printthis = 1", cnxn);
                cnxn.Open();
                o = cmd.ExecuteScalar();
                cnxn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }

            if (o != null)
            {
                MessageBox.Show("Can't print serialized labels without serial numbers.");
                return;
            }
            else
            {

                try
                {
                    /*
                     *
                     *This data adapter and table are just to make testing easier 
                     * 
                    */

                    /*
                    SqlDataAdapter da = new SqlDataAdapter
                        ("Select " +
                         "IIF(ZygoSN is null, " +
                         "m.Zygo_PN, " +
                         "m.Zygo_PN + " +
                         "' ' + " +
                         "UPPER(ZygoSN)) as Barcode, " +
                         "m.Canon_PN, " +
                         "m.Zygo_PN, " +
                         "m.Item_Description, " +
                         "UPPER(ZygoSN) ZygoSN, " +
                         "SerializeThis, " +
                         "CASE " +
                         "  WHEN PrintExtraLabels = 0 THEN Delivered_Quantity " +
                         "  WHEN PrintExtraLabels > 0 THEN PrintExtraLabels " +
                         "End Delivered_Quantity " +
                         "from labels.CanonLabels l " +
                         "inner join labels.ZygoAmetekCanonMappings m " +
                         "on l.ITEM_CODE = m.Zygo_PN " +
                         "where PICKING_LIST_NUMBER = '" +
                         g.pickingListNumber + "' and printthis = 1" +
                        "order by position desc, serialized desc", cnxn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    */

                    cmd = new SqlCommand
                        ("Select " +
                         "IIF(ZygoSN is null, " +
                         "m.Zygo_PN, " +
                         "m.Zygo_PN + " +
                         "' ' + " +
                         "UPPER(ZygoSN)) as Barcode, " +
                         "m.Canon_PN, " +
                         "m.Zygo_PN, " +
                         "m.Item_Description, " +
                         "UPPER(ZygoSN) ZygoSN, " +
                         "SerializeThis, " +
                         "CASE " +
                         "  WHEN PrintExtraLabels = 0 THEN Delivered_Quantity " +
                         "  WHEN PrintExtraLabels > 0 THEN PrintExtraLabels " +
                         "End Delivered_Quantity " +
                         "from labels.CanonLabels l " +
                         "inner join labels.ZygoAmetekCanonMappings m " +
                         "on  l.ITEM_CODE = m.Zygo_PN " +
                         "where PICKING_LIST_NUMBER = '" +
                         g.pickingListNumber + "' and printthis = 1" +
                        "order by position desc, serialized desc", cnxn);
                    cnxn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        if (!dr.IsDBNull(4))
                        { sn = dr.GetString(4).Trim(); }
                        else
                        { sn = ""; }

                        if (dr.GetBoolean(5) == false)
                        {
                            printQuantity = dr.GetInt32(6).ToString();
                        }
                        else
                        {
                            printQuantity = "1";
                        }

               /*
               * q = set label width in dots (width = Y dimension)
               * Q = set form length in dots (for us 203 dpi and length = X dimension)
               * the 20 is the gap between the labels
               * LO draws a line
               * all the lines need \n at the end to print
               * 
               * */
                        //printQuantity = "1";

                        string str = "\nN\nq609Q203,20\n";
                        str += "A60,10,0,3,1,1,N,\"Canon P/N\"\n";
                        str += "A270,10,0,3,1,1,N,\"" + dr.GetString(1).Trim() + "\"\n";
                        str += "LO20,30,600,2\n";
                        str += "A60,40,0,3,1,1,N,\"Zygo P/N\"\n";
                        str += "A270,40,0,3,1,1,N,\"" + dr.GetString(2).Trim() + "\"\n";
                        str += "LO20,60,600,2\n";
                        str += "A60,70,0,3,1,1,N,\"Description\"\n";
                        str += "A270,70,0,3,1,1,N,\"" + dr.GetString(3).Trim() + "\"\n";
                        str += "LO20,90,600,2\n";
                        str += "A60,100,0,3,1,1,N,\"S/N\"\n";
                        str += "A270,100,0,3,1,1,N,\"" + sn + "\"\n";
                        str += "LO20,120,600,2\n";
                        str += "LO260,10,2,110\n";
                        str += "B50,135,0,1,2,4,32,B,\"" + dr.GetString(0) + "\"\n";
                        str += "P" + printQuantity + "\n";
                        RawPrinterHelper.SendStringToPrinter(g.printer, str);

                    }
                    cnxn.Close();
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
