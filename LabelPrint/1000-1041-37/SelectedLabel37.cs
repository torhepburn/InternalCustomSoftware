using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace _1000_1041_37
{
    public partial class SelectedLabel37 : Form
    {
        private TextBox tbDescription;
        private TextBox tbPartNumber;
        private TextBox tbAmps;
        private TextBox tbVolts;
        private TextBox tbHertz;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox tbModel;
        private TextBox tbSerialNumber;
        private Button bExit;
        private Button bPrint;

        //private TextBox tbDescription;
        //private TextBox tbPartNumber;
        //private TextBox tbAmps;
        //private TextBox tbVolts;
        //private TextBox tbHertz;
        //private Button bExit;
        //private Button bPrint;
        //private Label label10;
        //private Label label9;
        //private Label label8;
        //private Label label7;
        //private Label label6;
        //private Label label5;
        //private Label label4;
        //private TextBox tbModel;
        //private TextBox tbSerialNumber;
        private string labelQuantity;

        public SelectedLabel37()
        {
            InitializeComponent();
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

 
        private void bPrint_Click(object sender, EventArgs e)
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
            string desc = tbDescription.Text.Replace("\"", "\\\"");
            tbModel.Text = tbModel.Text.Replace("\"", "\\\"");

            //g.printer = "ZDesigner GK420t";

            string str = "\nN\nq456.75Q253.75,20\n";
            str += SendImageToPrinter(10, 15, bzp);
            str += SendImageToPrinter(300, 15, bxp);
            //str += "A30,85,0,3,1,1,N,\"DESC.\"\n";

            if (desc.Length > 30)
            {
                str += "A20,85,0,2,1,1,N,\"" + desc + "\"\n";
            }
            else
            {
                str += "A20,85,0,3,1,1,N,\"" + desc + "\"\n";
            }
            str += "A20,110,0,3,1,1,N,\"P/N\"\n";
            str += "A70,110,0,3,1,1,N,\"" + tbPartNumber.Text.Trim() + "\"\n";

            str += "A20,135,0,3,1,1,N,\"" + "MODEL" + "\"\n";
            str += "A100,135,0,3,1,1,N,\"" + tbModel.Text.Trim() + "\"\n";
            /*  custm labels for Dennis below    */
            //str += "A30,110,0,3,1,1,N,\"" + "P/N" +  "\"\n";
            //str += "A80,110,0,3,1,1,N,\"" + tbModel.Text.Trim() + "\"\n";
            //str += "A30,135,0,3,1,1,N,\"" + tbModel.Text.Trim() + "\"\n";
            str += "A20,160,0,3,1,1,N,\"S/N\"\n";
            str += "A70,160,0,3,1,1,N,\"" + tbSerialNumber.Text.Trim() + "\"\n";
            str += "A232,185,0,3,1,1,N,\"AMPS\"\n";
            str += "A298,185,0,3,1,1,N,\"" + tbAmps.Text.Trim() + "\"\n";
            str += "A20,185,0,3,1,1,N,\"VOLTS\"\n";
            str += "A100,185,0,3,1,1,N,\"" + tbVolts.Text.Trim() + "\"\n";
            str += "A260,160,0,3,1,1,N,\"Hz\"\n";
            str += "A300,160,0,3,1,1,N,\"" + tbHertz.Text.Trim() + "\"\n";
            str += "A30,225,0,2,1,1,N,\"MADE IN USA, Middlefield, CT 06455\"\n";
            str += "P" + labelQuantity + "\n";
            RawPrinterHelper.SendStringToPrinter(g.printer, str);

            tbSerialNumber.Text = "";
            tbSerialNumber.Focus();
        }


        private void InitializeComponent()
        {
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbPartNumber = new System.Windows.Forms.TextBox();
            this.tbAmps = new System.Windows.Forms.TextBox();
            this.tbVolts = new System.Windows.Forms.TextBox();
            this.tbHertz = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.tbSerialNumber = new System.Windows.Forms.TextBox();
            this.bExit = new System.Windows.Forms.Button();
            this.bPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbDescription
            // 
            this.tbDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.tbDescription.Location = new System.Drawing.Point(257, 78);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = true;
            this.tbDescription.Size = new System.Drawing.Size(208, 20);
            this.tbDescription.TabIndex = 75;
            // 
            // tbPartNumber
            // 
            this.tbPartNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.tbPartNumber.Location = new System.Drawing.Point(257, 43);
            this.tbPartNumber.Name = "tbPartNumber";
            this.tbPartNumber.ReadOnly = true;
            this.tbPartNumber.Size = new System.Drawing.Size(208, 20);
            this.tbPartNumber.TabIndex = 74;
            // 
            // tbAmps
            // 
            this.tbAmps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.tbAmps.Location = new System.Drawing.Point(257, 242);
            this.tbAmps.Name = "tbAmps";
            this.tbAmps.ReadOnly = true;
            this.tbAmps.Size = new System.Drawing.Size(51, 20);
            this.tbAmps.TabIndex = 73;
            // 
            // tbVolts
            // 
            this.tbVolts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.tbVolts.Location = new System.Drawing.Point(257, 202);
            this.tbVolts.Name = "tbVolts";
            this.tbVolts.ReadOnly = true;
            this.tbVolts.Size = new System.Drawing.Size(51, 20);
            this.tbVolts.TabIndex = 72;
            // 
            // tbHertz
            // 
            this.tbHertz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.tbHertz.Location = new System.Drawing.Point(257, 162);
            this.tbHertz.Name = "tbHertz";
            this.tbHertz.ReadOnly = true;
            this.tbHertz.Size = new System.Drawing.Size(51, 20);
            this.tbHertz.TabIndex = 71;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(106, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 20);
            this.label10.TabIndex = 70;
            this.label10.Text = "Model";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(106, 285);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 20);
            this.label9.TabIndex = 69;
            this.label9.Text = "Serial Number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(106, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 20);
            this.label8.TabIndex = 68;
            this.label8.Text = "Amps";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(106, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 20);
            this.label7.TabIndex = 67;
            this.label7.Text = "Volts";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(106, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 66;
            this.label6.Text = "Hertz (Hz)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(103, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 65;
            this.label5.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(103, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 64;
            this.label4.Text = "Part Number";
            // 
            // tbModel
            // 
            this.tbModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.tbModel.Location = new System.Drawing.Point(257, 121);
            this.tbModel.Name = "tbModel";
            this.tbModel.ReadOnly = true;
            this.tbModel.Size = new System.Drawing.Size(208, 20);
            this.tbModel.TabIndex = 63;
            // 
            // tbSerialNumber
            // 
            this.tbSerialNumber.Location = new System.Drawing.Point(257, 285);
            this.tbSerialNumber.Name = "tbSerialNumber";
            this.tbSerialNumber.Size = new System.Drawing.Size(150, 20);
            this.tbSerialNumber.TabIndex = 62;
            // 
            // bExit
            // 
            this.bExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.bExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.Location = new System.Drawing.Point(286, 343);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(212, 88);
            this.bExit.TabIndex = 77;
            this.bExit.Text = "EXIT";
            this.bExit.UseVisualStyleBackColor = false;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bPrint
            // 
            this.bPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.bPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPrint.Location = new System.Drawing.Point(34, 343);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(212, 88);
            this.bPrint.TabIndex = 76;
            this.bPrint.Text = "PRINT LABEL";
            this.bPrint.UseVisualStyleBackColor = false;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            // 
            // SelectedLabel37
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(569, 486);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.bPrint);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbPartNumber);
            this.Controls.Add(this.tbAmps);
            this.Controls.Add(this.tbVolts);
            this.Controls.Add(this.tbHertz);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbModel);
            this.Controls.Add(this.tbSerialNumber);
            this.Name = "SelectedLabel37";
            this.Load += new System.EventHandler(this.SelectedLabel_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void SelectedLabel_Load_1(object sender, EventArgs e)
        {
            
            if (g.freeText)
            {
                this.Text = "Enter values prior to printing.";

                tbAmps.ReadOnly = false;
                tbDescription.ReadOnly = false;
                tbHertz.ReadOnly = false;
                tbModel.ReadOnly = false;
                tbPartNumber.ReadOnly = false;
                tbVolts.ReadOnly = false;

                tbAmps.BackColor = Color.White;
                tbDescription.BackColor = Color.White;
                tbHertz.BackColor = Color.White;
                tbModel.BackColor = Color.White;
                tbPartNumber.BackColor = Color.White;
                tbVolts.BackColor = Color.White;

            }


            tbPartNumber.Text = g.item;
            tbDescription.Text = g.description;
            tbHertz.Text = g.hertz;
            tbVolts.Text = g.volts;
            tbAmps.Text = g.amps;
            tbModel.Text = g.model;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            g.freeText = false;
            this.Close();
        }
    }
}
