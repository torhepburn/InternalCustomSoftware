using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;


namespace PackingListPrint
{
    public partial class PackingListPrinter : Form
    {
        SqlConnection cnxn;
        SqlCommand cmd;
        SqlDataReader dr;
        private string db = "server = CT-MID-SQL11; user = ReadWrite; password = Read+Write!; " +
                            "database = AccessFrontEnds;";
        private string document;
        private string documentDescription;
        private string revision;
        private string flag = "";

        private string itemCode;
        private string iDescription;
        private string iQty;
        private string boxes;
        private int BoxCount;

        private string Part;
        private string line1;
        private string line2;
        private string line3;
        private string labelQuantity;
        private int firstLastIndex;
        private int secondLastIndex;

        private string printer;
        


        public PackingListPrinter()
        {
            InitializeComponent();
        }

        private void PackingListPrinter_Load(object sender, EventArgs e)
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
                cmd = new SqlCommand(
                 " Select permission, permissionvalue from applicationsetup " +
                 " where application = 'PACKINGLISTPRINT' and " +
                 " pcid = '" + computername + "' " +
                 " order by permission desc ", cnxn);
                DataTable table= new DataTable();

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
                    MessageBox.Show("Either this user " + user + " or this computer (" + computername + ") does not have permission to use this program: PackingListPrint.");
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


            this.Text = "Packing List Label Printer  v" + Application.ProductVersion;

            bPrint.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            bBack.Visible = false;

            cnxn = new SqlConnection(db);
            cmd = new SqlCommand(
                "Select distinct documentnumber [Packing List], pldescription [Description], Revision " +
                "from labels_packinglists order by documentnumber, revision ", cnxn);
            System.Data.DataTable dtable = new System.Data.DataTable();

            cnxn.Open();

            dr = cmd.ExecuteReader();

            dtable.Load(dr);
            DGV.DataSource = dtable;
            DGV.Show();

            DGV.Columns[0].Width = 110;
            DGV.Columns[1].Width = 280;
            DGV.Columns[2].Width = 70;
            
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (flag != "selected")
            {
                if (e.RowIndex == -1 && e.ColumnIndex == 1)
                {
                    return;
                }
                else
                {
                    label4.Visible = false;

                    DataGridViewTextBoxCell cell =
                        (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[0];
                    document = cell.EditedFormattedValue.ToString().Trim();

                    cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                    documentDescription = cell.EditedFormattedValue.ToString().Trim();

                    cell = (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[2];
                    revision = cell.EditedFormattedValue.ToString().Trim();

                    bBack.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;

                    label1.Text = document;
                    label2.Text = documentDescription;
                    label3.Text = revision;

                    cnxn = new SqlConnection(db);

                    cmd = new SqlCommand(
                        "Select " +
                        "item_code, " +
                        "description, " +
                        "quantity, " +
                        "boxes " +
                        "from labels_packinglists " +
                        "where documentnumber = '" + document + "' " +
                        "and revision = '" + revision + "' ORDER BY UID ", cnxn);

                    System.Data.DataTable table2 = new System.Data.DataTable();

                    try
                    {
                        cnxn.Open();
                        dr = cmd.ExecuteReader();
                        table2.Load(dr);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Line 156 \n" + ex.ToString());

                    }
                    finally
                    {
                        cnxn.Close();
                    }

                    DGV.DataSource = table2;
                    DGV.Show();

                    DGV.Columns[0].Width = 100;
                    DGV.Columns[1].Width = 200;
                    DGV.Columns[2].Width = 50;
                    DGV.Columns[3].Width = 50;

                    bPrint.Visible = true;
                    flag = "selected";
                }
            }
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            cnxn.Open();
            SqlCommand cmd = new SqlCommand(
                "Select " +
                "COALESCE(item_code,'') " +
                ",COALESCE(description,'') " +
                ",COALESCE(quantity,'0') " +
                ",COALESCE(boxes,'0') " +
                "from labels_packinglists " +
                "where documentnumber = '" + document + "' " +
                "and revision = '" + revision + "' ORDER BY UID ", cnxn);


            try
            {
                dr = cmd.ExecuteReader();
                DataTable t = new DataTable();
                t.Load(dr);
                dr = cmd.ExecuteReader();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            while (dr.Read())
            {
                itemCode = dr.GetString(0).Trim();
                iDescription = dr.GetString(1).Trim();
                iQty = "Qty: " + dr.GetString(2).Trim();
                BoxCount = dr.GetInt32(3);

                if (BoxCount == 1)
                {
                    Part = "Part: 1 of 1";
                    printLabel();
                }

                if (BoxCount == 2)
                {
                    Part = "Part: 1 of 2";
                    printLabel();
                    Part = "Part: 2 of 2"; ;
                    printLabel();
                }

                if (BoxCount == 3)
                {
                    Part = "Part: 1 of 3";
                    printLabel();
                    Part = "Part: 2 of 3";
                    printLabel();
                    Part = "Part: 3 of 3";
                    printLabel();
                }

                if (BoxCount == 4)
                {
                    Part = "Part: 1 of 4";
                    printLabel();
                    Part = "Part: 2 of 4";
                    printLabel();
                    Part = "Part: 3 of 4";
                    printLabel();
                    Part = "Part: 4 of 4";
                    printLabel();
                }

            }

            this.Close();
        }

        private void printLabel()
        {
            //Qty = "Qty: " + tbQty.Text.ToString().Trim();
            //SN = tbSN.Text.ToString().Trim();

            int descriptionLength = iDescription.Length;

            if (descriptionLength < 15)
            {
                line1 = iDescription.Trim();
                line2 = "";
                line3 = "";
            }
            else   /*   description length is greater than 14   */
            {
                //if (g.iDescription.IndexOf(" ") != -1)
                //{
                //if (descriptionLength > 14)
                //{
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
                //}

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

            labelQuantity = "1";

            Bitmap bzp = Properties.Resources.zygo_blk_noR_132;
            Bitmap bxp = Properties.Resources.ametek_blk_noR_132;

            /*
             *  Add the image to the resources folder or elsewhere, then add the file to the
             *  resourses.resx file and it will take in the file and reclassify it as an image.
             *  It should then be available under properties.resources - the case does matter for 
             *  the image name.
             */

            //Bitmap bzp = new Bitmap(@"c:\a\zygo_blk_noR_132.bmp");
            //Bitmap bxp = new Bitmap(@"c:\a\AMETEK_blk_noR_132.bmp");
            //line1 = "4\\\" Colimeter";
            /*  FOR TESTING */
            //printer = @"\\midprtsrv\Zebrasn7";
            //printer = @"\\ct-mid-ps01\zebrasn17";

            string str = "\nN\nq609Q203,20\n";
            str += SendImageToPrinter(10, 5, bzp);
            str += SendImageToPrinter(450, 5, bxp);
            str += "A144,5,0,2,1,1,N,\"21 Laurel Brook Road\"\n";
            str += "A144,30,0,2,1,1,N,\"Middlefield, CT 06455 USA\"\n";
            str += "A10,65,0,2,1,1,N,\"PN#\"\n";
            str += "B50,60,0,1,2,4,32,B,\"" + itemCode + "\"\n";
            str += "A420,55,0,2,1,1,N,\"" + line1 + "\"\n";
            str += "A420,75,0,2,1,1,N,\"" + line2 + "\"\n";
            str += "A420,95,0,2,1,1,N,\"" + line3 + "\"\n";
            str += "A10,135,0,2,1,1,N,\"SN#\"\n";
            str += "A420,120,0,2,1,1,N,\"REV: \"\n";
            str += "A420,145,0,2,1,1,N,\"" + iQty + "\"\n";
            str += "A420,170,0,2,1,1,N,\"" + Part + "\"\n";
            str += "P" + labelQuantity + "\n";
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


        private void bBack_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);
            cmd = new SqlCommand(
                "Select distinct documentnumber [Packing List], pldescription [Description], Revision " +
                "from labels_packinglists order by documentnumber, revision", cnxn);
            System.Data.DataTable table = new System.Data.DataTable();

            cnxn.Open();
            dr = cmd.ExecuteReader();

            table.Load(dr);
            cnxn.Close();
            
            DGV.DataSource = table;
            DGV.Show();

            DGV.Columns[0].Width = 110;
            DGV.Columns[1].Width = 280;
            DGV.Columns[2].Width = 70;

            bPrint.Visible = false;
            flag = "";
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = true;
            bBack.Visible = false;

        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            cnxn = new SqlConnection(db);

            cmd = new SqlCommand
                ("Select distinct documentnumber [Packing List], pldescription [Description], Revision " +
                "from labels_packinglists WHERE " + 
                "Documentnumber LIKE '%" + tbSearchPartNumber.Text + "%' OR " +
                "PLDESCRIPTION LIKE '%" + tbSearchPartNumber.Text + "%' " +
                " order by documentnumber, revision", cnxn);
            DataTable table = new DataTable();

            cnxn.Open();

            dr = cmd.ExecuteReader();

            table.Load(dr);
            cnxn.Close();
            DGV.DataSource = table;
        }

        private void bItem_Click(object sender, EventArgs e)
        {

        }

        private void tbSearchPartNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

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
