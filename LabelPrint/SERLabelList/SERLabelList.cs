using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Drawing.Imaging;
using System.Collections;
using System.Runtime.InteropServices;
using System.Data.SqlClient;



namespace SERLabelList
{
    public partial class SERLabelList : Form
    {
        Microsoft.Office.Interop.Excel.Application oXL;
        Microsoft.Office.Interop.Excel.Workbook oWB;
        Microsoft.Office.Interop.Excel.Worksheet oWS;
        Microsoft.Office.Interop.Excel.Range oRng;
        private int itemCount;
        private int labelSets;
        private string packingList;
        private int pageof;
        private int numberOfLabels;
        private int qty;
        private int labelFactor;
        object[,] xlData;
        object[,] itemCountList;

        private string itemCode;
        private string iDescription;

        private string Project;
        private string Qty;
        private string Part;
        private string SN;
        private string line1;
        private string line2;
        private string line3;
        private string labelQuantity;
        private int firstLastIndex;
        private int secondLastIndex;

        private string printer;
        DataTable table;

        SqlConnection cnxn;
        SqlDataReader dr;
        SqlDataAdapter da;
        private string db = "server = CT-MID-SQL11; user = ReadWrite; password = Read+Write!; " +
                            "database = AccessFrontEnds;";

        public SERLabelList()
        {
            InitializeComponent();
        }

        private void SERLabelList_Load(object sender, EventArgs e)
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
                da = new SqlDataAdapter(
                 " Select permission, permissionvalue from applicationsetup " +
                 " where application = 'serlabellist' and " +
                 " pcid = '" + computername + "' and " +
                 " username = '" + user + "' order by permission desc ", cnxn);
                table = new DataTable();
                da.Fill(table);

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

            }




            openFileDialog1.Filter = "SER Packing List Excel Files|*packing*.xls*";
            openFileDialog1.Title = "Select SER Packing List";
            openFileDialog1.InitialDirectory =
                @"\\zygocorp\projects\";
            openFileDialog1.ShowDialog();
            rb3Labels.Checked = true;
            packingList = openFileDialog1.FileName;

        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = false;

            //oXL.Visible = true;
            //oXL.DisplayAlerts = false;

            oWB = oXL.Workbooks.Open(packingList,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value);
            oWS = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Worksheets.get_Item("Sheet1");
            oRng = oWS.Range["D6:I407"];

            xlData = oRng.get_Value(Missing.Value);
            oRng = oWS.Range["C7:C407"];

            itemCountList = oRng.get_Value(Missing.Value);

            oXL.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL);


            //take array and determine how many items in list
            for (int i = 1; i <= 400; i++)
            {
                try
                {
                    if (itemCountList[i, 1] != null)
                    {
                        //itemCount = Convert.ToInt32(itemCountList[i, 1].ToString());
                        itemCount = i;
                    }
                }
                catch (Exception ex)
                {
                    string news = ex.Message.ToString() + "\n\n Item Number column error";
                    return;
                }
            }

            for (int n = 1; n <= (itemCount + 1); n++)
            {

                if (xlData[1, 1] == null)
                {
                    MessageBox.Show("Either this is not a SER packing list or it " +
                        "is incorrectly formatted. An entry is required in D6.");
                    return;
                }

                if (xlData[1, 1].ToString().Length > 2)
                {
                    //if this is not a ser packing list exit the routine
                    if (xlData[1, 1].ToString().Substring(0, 3) != "SER")
                    {
                        MessageBox.Show("Either this is not a SER packing list or it " +
                            "is incorrectly formatted. D6 requires 'SER' + the SER number.");
                        return;
                    }
                }
                //first label should be the SER number and won't have the
                //same columns of data that the items will have
                if (n == 1)
                {
                    printLabel(n);
                }

                if (n >= 2)
                {
                    pageof = 1;

                    //calculate number of labels needed
                    qty = Convert.ToInt32(xlData[n, 3].ToString());
                    numberOfLabels = Convert.ToInt32(xlData[n, 6].ToString());
                    labelFactor = numberOfLabels / qty;

                    for (int ii = 1; ii <= numberOfLabels; ii++)
                    {
                        if (qty >= numberOfLabels)
                        {
                            printLabel(n);
                            pageof++;
                        }

                        if (qty < numberOfLabels)
                        {
                            if (labelFactor == 1)
                            {
                                pageof = 1;
                                printLabel(n);
                            }

                            if (labelFactor == 2)
                            {
                                pageof = 1;
                                printLabel(n);
                                pageof = 2;
                                printLabel(n);
                                numberOfLabels = numberOfLabels - 2;
                            }

                            if (labelFactor == 3)
                            {
                                pageof = 1;
                                printLabel(n);
                                pageof = 2;
                                printLabel(n);
                                pageof = 3;
                                printLabel(n);
                                numberOfLabels = numberOfLabels - 3;
                            }

                            if (labelFactor == 4)
                            {
                                pageof = 1;
                                printLabel(n);
                                pageof = 2;
                                printLabel(n);
                                pageof = 3;
                                printLabel(n);
                                pageof = 4;
                                printLabel(n);
                                numberOfLabels = numberOfLabels - 4;
                            }

                            if (labelFactor == 5)
                            {
                                pageof = 1;
                                printLabel(n);
                                pageof = 2;
                                printLabel(n);
                                pageof = 3;
                                printLabel(n);
                                pageof = 4;
                                printLabel(n);
                                pageof = 5;
                                printLabel(n);
                                numberOfLabels = numberOfLabels - 5;
                            }

                        }
                    }

                }


            }
            this.BackColor = System.Drawing.Color.Gray;
            this.Close();
        }

        private void printLabel(int n)
        {
            itemCode = "";
            iDescription = "";
            Qty = "";
            Project = "";
            SN = "";

            if (xlData[n, 1] != null)
            { itemCode = xlData[n, 1].ToString().Trim(); }
            if (xlData[n, 2] != null)
            { iDescription = xlData[n, 2].ToString().Trim(); }
            if (xlData[n, 3] != null)
            { Qty = "Qty: " + xlData[n, 3].ToString().Trim(); }
            else
            { Qty = "Qty: "; }
            if (xlData[n, 4] != null)
            { Project = xlData[n, 4].ToString().Trim(); }
            if (xlData[n, 5] != null)
            { SN = xlData[n, 5].ToString().Trim(); }


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

            labelQuantity = labelSets.ToString();

            Bitmap bzp = Properties.Resources.zygo_blk_noR_132;
            Bitmap bxp = Properties.Resources.ametek_blk_noR_132;

            /*
             *  Add the image to the resources folder or elsewhere, then add the file to the
             *  resourses.resx file and it will take in the file and reclassify it as an image.
             *  It should then be available under properties.resources - the case does matter for 
             *  the image name.
             */

            if (itemCode.ToUpper().Substring(0, 3) == "SER")
            {
                string str = "\nN\nq609Q203,20\n";
                str += SendImageToPrinter(10, 10, bzp);
                str += SendImageToPrinter(450, 10, bxp);
                str += "A144,10,0,2,1,1,N,\"21 Laurel Brook Road\"\n";
                str += "A144,35,0,2,1,1,N,\"Middlefield, CT 06455 USA\"\n";
                str += "B50,70,0,1,2,4,32,B,\"" + itemCode + "\"\n";
                str += "P" + labelQuantity + "\n";
                RawPrinterHelper.SendStringToPrinter(printer, str);
                //File.AppendAllText(@"C:\A\sertest.txt", itemCode + Environment.NewLine);

            }
            else
            {
                Part = "Part: " + pageof + " of " + numberOfLabels;

                string str = "\nN\nq609Q203,20\n";
                str += SendImageToPrinter(10, 10, bzp);
                str += SendImageToPrinter(450, 10, bxp);
                str += "A144,10,0,2,1,1,N,\"21 Laurel Brook Road\"\n";
                str += "A144,35,0,2,1,1,N,\"Middlefield, CT 06455 USA\"\n";
                str += "A10,70,0,2,1,1,N,\"PN#\"\n";
                str += "B50,65,0,1,2,4,32,B,\"" + itemCode + "\"\n";
                str += "A420,60,0,2,1,1,N,\"" + line1 + "\"\n";
                str += "A420,80,0,2,1,1,N,\"" + line2 + "\"\n";
                str += "A420,100,0,2,1,1,N,\"" + line3 + "\"\n";
                str += "A10,140,0,2,1,1,N,\"SN#\"\n";
                str += "B50,135,0,1,2,4,32,B,\"" + SN + "\"\n";
                str += "A420,125,0,2,1,1,N,\"" + Project + "\"\n";
                str += "A420,150,0,2,1,1,N,\"" + Qty + "\"\n";
                str += "A420,175,0,2,1,1,N,\"" + Part + "\"\n";
                str += "P" + labelQuantity + "\n";
                RawPrinterHelper.SendStringToPrinter(printer, str);
                //File.AppendAllText(@"C:\A\sertest.txt", itemCode + Environment.NewLine);
            }
        }

        private void rb1Label_CheckedChanged(object sender, EventArgs e)
        {
            if (rb1Label.Checked == true)
            {
                labelSets = 1;
            }
        }

        private void rb3Labels_CheckedChanged(object sender, EventArgs e)
        {
            if (rb3Labels.Checked == true)
            {
                labelSets = 3;
            }
        }

        private void rb4Labels_CheckedChanged(object sender, EventArgs e)
        {
            if (rb4Labels.Checked == true)
            {
                labelSets = 4;
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


        
        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex == -1 && e.ColumnIndex < 8)
            if (e.RowIndex == -1 | e.ColumnIndex == -1)
            {
                return;
            }
            else
            {
                DataGridViewTextBoxCell cell =
                    (DataGridViewTextBoxCell)DGV.Rows[e.RowIndex].Cells[1];
                printer = cell.EditedFormattedValue.ToString();
                label1.Text = "Selected Printer: " + printer;
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
