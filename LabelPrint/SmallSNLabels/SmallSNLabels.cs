using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Data;

namespace SmallSNLabels
{
    public partial class SmallSNLabels : Form
    {
        private string printer;
        private string yy;
        private string part;
        private string nn;
        private string SN;
        private string lambda;
        private string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                            "user = readWrite; database = AccessFrontEnds;";

        SqlConnection cnxn;
        SqlCommand cmd;

        public SmallSNLabels()
        {
            InitializeComponent();
        }

        private void SmallSNLabels_Load(object sender, EventArgs e)
        {
            this.Text = "Small SN Labels version " + Application.ProductVersion;

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

            cnxn = new SqlConnection(db);

            try
            {
                SqlCommand cmd = new SqlCommand(
                 " Select permission, permissionvalue from applicationsetup " +
                 " where application = 'smallsnlabels' and " +
                 " pcid = '" + computername + "' " +
                 " order by permission desc ", cnxn);
                DataTable table = new DataTable();

                cnxn.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();
                table.Load(dr);

              
                if (table.Rows.Count > 0)
                {
                    /*  putting print server into table on CT-MID-SQL11  */
                    //g.printer = "\\\\midprtsrv\\" + table.Rows[0][1].ToString().Trim();
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

            yy = DateTime.Now.Year.ToString().Substring(2,2);
        }

        private void rb00Red_CheckedChanged(object sender, EventArgs e)
        {
            // yy3nnn
            part = "3";
            makeSN();
        }    

        private void rb01Silver_CheckedChanged(object sender, EventArgs e)
        {
            // yynnnn
            part = "0";
            lambda = "/10";
            makeSN();
        }

        private void rb02Gold_CheckedChanged(object sender, EventArgs e)
        {
            //yy1nnn
            part = "1";
            lambda = "/20";
            makeSN();
        }

        private void rb03Green_CheckedChanged(object sender, EventArgs e)
        {
            //yy2nnn
            part = "2";
            lambda = "/40";
            makeSN();
        }

        private void rb04Blue_CheckedChanged(object sender, EventArgs e)
        {
            //yy25nn
            part = "25";
            lambda = "/50";
            makeSN();
        }

        private void rbFreeText_CheckedChanged(object sender, EventArgs e)
        {
            part = "999";
            tbSerialNumber.Text = string.Empty;
        }


        private void makeSN ()
        {
            try
            {
                string SQL = "SELECT serialnumber FROM labels.serialnumberlog " +
                          " WHERE serialnumber like '" + yy + part + "%' ORDER BY serialnumber DESC "; 
                if (part == "2")
                {
                    SQL = "SELECT serialnumber FROM labels.serialnumberlog " +
                " WHERE SUBSTRING(CAST(serialnumber as varchar(6)), 1,3)  = '" + yy + part + "' " +
                " AND SUBSTRING(CAST(serialnumber as varchar(6)), 4,1)  != '5' " +
                " ORDER BY serialnumber DESC ";
                }
                
                cnxn.Open();
                cmd = new SqlCommand(SQL, cnxn);
                object o = cmd.ExecuteScalar();
                cnxn.Close();

                if (o == null)
                {
                    if (part != "25")
                    {
                        nn = "001";
                    }
                    else
                    {
                        nn = "01";
                    }
                }
                else
                {
                    if (part != "25")
                    {
                        nn = (Convert.ToInt32(o) + 1).ToString().Substring(3, 3);
                    }
                    else
                    {
                        nn = (Convert.ToInt32(o) + 1).ToString().Substring(4, 2);
                    }
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

            tbSerialNumber.Text = yy + part + nn;
        }



        private void bPrint_Click(object sender, EventArgs e)
        {
            int start = 0;

            if (rbOne.Checked)
            {
                SN = tbSerialNumber.Text.ToString().Trim();
                sendToPrinter();
            }
            else
            {
                start = Convert.ToInt32(tbSerialNumber.Text.ToString().Trim());
            }

            if ( rbTen.Checked )
            {
                for (int n = 0; n < 10; n++)
                {
                    SN = (start + n).ToString();
                    sendToPrinter();
                }
            }

            if (rbOneHundred.Checked)
            {
                for (int n = 0; n < 100; n++)
                {
                    SN = (start + n).ToString();
                    sendToPrinter();
                }
            }
        }

        private void sendToPrinter()
        {
            Bitmap bzp = Properties.Resource1.zygo_blk_noR_152;
            Bitmap bxp = Properties.Resource1.lamda6;
            //Bitmap bxp = Properties.Resources.ametek_blk_noR_132;

            /*
             *  Add the image to the resources folder or elsewhere, then add the file to the
             *  resourses.resx file and it will take in the file and reclassify it as an image.
             *  It should then be available under properties.resources - the case does matter for 
             *  the image name.
             */

            string str = "\nN\nq100Q50,20\n";

            if (part == "3")
            {
                str += "A10,30,0,4,1,1,N,\"SN " + SN + "\"\n";
                str += "P1\n";
            }
            else if (part != "999")
            {
                str += SendImageToPrinter(70, 5, bxp);
                str += "A5,45,0,4,1,1,N,\"SN " + SN + "\"\n";
                str += "A100,5,0,4,1,1,N,\"" + lambda + "\"\n";
                str += "P1\n";
            }
            else if (part == "999")
            {
                str += SendImageToPrinter(70, 5, bxp);
                str += "A5,45,0,4,1,1,N,\"" + SN + "\"\n";
                str += "P1\n";
            }

            /* labels printed on local printer */
            //RawPrinterHelper.SendStringToPrinter("ZDesigner GK420d", str);
            RawPrinterHelper.SendStringToPrinter(printer, str);
            
            if (part != "999")
            {
                try
                {
                    cmd = new SqlCommand(
                        "INSERT INTO labels.serialnumberlog (" +
                        "SerialNumber) " +
                        "values ( '" + SN + "') ", cnxn);
                    cnxn.Open();
                    cmd.ExecuteNonQuery();
                    cnxn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    cnxn.Close();
                    SN = string.Empty;
                    tbSerialNumber.Text = string.Empty;
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

