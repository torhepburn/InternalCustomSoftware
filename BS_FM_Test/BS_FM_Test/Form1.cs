using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TekVISANet;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;





namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        MccDaq.MccBoard DaqBoard = new MccDaq.MccBoard(0);//Instantiating I/O PCBA
        CameraPulse _CameraPulse = new CameraPulse();//Instantiating Camera Pulse Object from CameraPulse Class

        const string tbs1104 = "USB::0x0699::0x03B4::C022189::INSTR";//Identifying oscilloscope address
        VISA tekVISA = new VISA();//Instantiating oscilloscope VISA
        string channel1amplitude, channel2amplitude, channel3amplitude;//Oscilloscope input variable names
        double powerRatioReflected, powerRatioTransmitted;//Declarring Variables or measured values on oscilloscope
        string Filename = @"C:\Users\zygo\Desktop\BS-RM Logfile.txt";//Identifying file path and name for results
        int laserStatus = 0;//Declaring laser status variable
        SerialPort mySerialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);//Constructing serial port to read laser status
        string partNumber = "";//Declaring variable for part number
        string transmittedPowerPercentage, reflectedPowerPercentage;//Declaring variable for displayed power ratios

        private string Rev;
        private string Qty;
        private string Part;
        private string SN;
        private string line1;
        private string line2;
        private string line3;
        private string labelQuantity;
        private int firstLastIndex;
        private int secondLastIndex;
        private string printer = @"\midprtsrv\zebrasn7";

        public void btnTestPart_Click(object sender, EventArgs e)
        {




            btnTestPart.BackColor = Color.LightBlue;
            btnTestPart.Text = ("Testing S/N " + maskedTxtSerialNumber.Text);
            CheckLaserStatus();//Method to assure laser head is stable and locked
            SetUpScope();//Method to set up oscilloscope settings as required by measurement
            ReflectedPowerRatio();//Method to measure and calculate Reflected Power relative to Input Power
            TransmittedPowerRatio();//Method to measure and calculate Transmitted Power relative to Input Power
            transmittedPowerPercentage = (Convert.ToString(Math.Round(powerRatioTransmitted, 4) * 100));//String conversion of rounded Trasmitted Power
            reflectedPowerPercentage = (Convert.ToString(Math.Round(powerRatioReflected, 4) * 100));//String conversion of rounded Reflected Power
            txtRefPwrPct.Text = reflectedPowerPercentage;//Display to text box
            txtTranPwrPct.Text = transmittedPowerPercentage;//Display to text box

            if ((powerRatioReflected >= .98) && (powerRatioTransmitted <= .1))//Check for Fold Mirror
            {
                partNumber = "6191-0138-06";
                _CameraPulse.PulseCamera(3);
                LoadCameraRecipe();
                LabelCheck();

            }
            else if ((powerRatioReflected >= .08) && (powerRatioTransmitted >= .82))//Check for 10% BS
            {
                partNumber = "6191-0138-09";
                _CameraPulse.PulseCamera(5);
                LoadCameraRecipe();
                LabelCheck();
            }
            else if ((powerRatioReflected >= .68) && (powerRatioTransmitted >= .19))//Check for 75% BS
            {
                partNumber = "6191-0138-07";
                _CameraPulse.PulseCamera(4);
                LoadCameraRecipe();
                LabelCheck();

            }

            else if ((powerRatioReflected >= .27) && (powerRatioTransmitted >= .62))//Check for 33% BS
            {
                partNumber = "6191-0138-04";
                _CameraPulse.PulseCamera(1);
                LoadCameraRecipe();
                LabelCheck();


            }
            else if ((powerRatioReflected >= .43) && (powerRatioTransmitted >= .43))//Check for 50% BS
            {
                partNumber = "6191-0138-05";
                _CameraPulse.PulseCamera(2);
                LoadCameraRecipe();
                LabelCheck();

            }





            else//If power ratio not recognized
            {
                MessageBox.Show("Optical Power test FAILS.\nMeasured power does not match any known configurations.");
                btnTestPart.BackColor = Color.Red;
                btnTestPart.Text = ("Part Failed.\nEnter Serial Number of another part above.");
                btnTestPart.Enabled = false;
                maskedTxtSerialNumber.Text = "";
                maskedTxtSerialNumber.BackColor = Color.Yellow;
            }

        }

        public void SetUpScope()//Function to setup and read values from oscilloscope
        {
            tekVISA.Open(tbs1104);
            tekVISA.Write("HORizontal:SECdiv 2.5E-8");
            tekVISA.Write("TRIG:MAI:MOD AUTO;LEV 6.0E-2");
            tekVISA.Write("TRIG:MAI:EDGE:SOU CH3;SLO RIS");

            tekVISA.Write("CH1:COUP AC;POS 2;VOLTS 0.1E0");
            tekVISA.Write("MEASUrement:IMMed:TYPe Pk2Pk;SOURCE CH1;VALUE?");
            tekVISA.Read(out channel1amplitude);

            tekVISA.Write("CH2:COUP AC;POS 0;VOLTS 0.1E0");
            tekVISA.Write("MEASUrement:IMMed:TYPe Pk2Pk;SOURCE CH2;VALUE?");
            tekVISA.Read(out channel2amplitude);

            tekVISA.Write("CH3:COUP AC;POS -2;VOLTS 0.1E0");
            tekVISA.Write("MEASUrement:IMMed:TYPe Pk2Pk;SOURCE CH3;VALUE?");
            tekVISA.Read(out channel3amplitude);

        }

        public void CheckLaserStatus()//Check to see if laser is locked; status 45
        {
            try
            {
                mySerialPort.Close();
                mySerialPort.Open();
                mySerialPort.WriteLine("100\r");//100 is command to check laser status
                laserStatus = Convert.ToInt32(mySerialPort.ReadLine());

            }
            catch (IOException ex)
            {
                MessageBox.Show("Problem communicating with Laser Head. Error:" + ex);
            }


            if (laserStatus != 45)

                MessageBox.Show("Laser is not stable or locked. Status: " + laserStatus + "\nDo not perform test until laser is stable and locked (Green OK LED).\nIf problem persists notify ZYGO Manufacturing Engineering.");
        }




        public double ReflectedPowerRatio()//Function which calculates reflected power relative to input power
        {
            double scaledInputPower = ((1) * (Convert.ToDouble(channel3amplitude)));
            //double scaledInputPower is compensation factor for fixture
            double reflectedPower = Convert.ToDouble(channel2amplitude);
            powerRatioReflected = (reflectedPower * (.83) / scaledInputPower);//.83 is fixture compensation
            return powerRatioReflected;

        }
        public double TransmittedPowerRatio()//Function which calculates transmitted power relative to input power
        {
            double scaledInputPower = ((1) * (Convert.ToDouble(channel3amplitude)));
            //double scaledInputPower is compensation factor for fixture
            double transmittedPower = Convert.ToDouble(channel1amplitude);
            powerRatioTransmitted = (transmittedPower / scaledInputPower);
            return powerRatioTransmitted;

        }



        public void LoadCameraRecipe()//Method to allow sensor to load label recipe
        {
            short output = 0;
            System.Threading.Thread.Sleep(500);//Wait 500mS to allow recipe pulse to to go low for 1 second duty cycle
            DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortCH, out output);
            if (!((output == 2) || (output == 3)))
                MessageBox.Show("Camera configuration not loaded in allotted time./n Please click TEST PART again.");
        }




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }





        private void maskedTxtSerialNumber_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)//Only allows maximum 4-digit serial number
        {
            MessageBox.Show("Only four digits maximum allowed for Serial Number");
        }


        public void LabelCheck()//Function to check label in acccordance with sensor recipe
        {

            btnTestPart.Enabled = false;//Disables button during test
            label2.Visible = true;

            short output;

            System.Threading.Thread.Sleep(2000);//Wait 2 seconds for sensor to output passed signal
            DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortCH, out output);
            if ((output == 1) || (output == 3))//Label Test Passed
            {

                btnTestPart.BackColor = Color.Green;
                btnTestPart.Text = ("Part Number " + partNumber + "\nSerial Number " + maskedTxtSerialNumber.Text + " Passed.\nEnter Serial Number of another part above.");


                try//Writing results to file
                {

                    File.AppendAllText(Filename, "\r\n" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "\tP/N:" + partNumber + "\tS/N:" + maskedTxtSerialNumber.Text + "\tPASS\tReflected Power=" + reflectedPowerPercentage + "\tTransmitted Power= " + transmittedPowerPercentage);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }
            else//Test Failed
            {
                btnTestPart.BackColor = Color.Red;
                btnTestPart.Text = ("Serial Number " + maskedTxtSerialNumber.Text + " Failed.\nEnter Serial Number for another part above.");
                try//Writing results to file
                {

                    File.AppendAllText(Filename, "\r\n" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "\tP/N:" + partNumber + "\tS/N:" + maskedTxtSerialNumber.Text + "\tFAIL\tReflected Power=" + reflectedPowerPercentage + "\tTransmitted Power= " + transmittedPowerPercentage);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            maskedTxtSerialNumber.Text = "";
            maskedTxtSerialNumber.BackColor = Color.Yellow;
        }

        private void maskedTxtSerialNumber_TextChanged(object sender, EventArgs e)
        {

            if (maskedTxtSerialNumber.Text.Length < 4) return;


            maskedTxtSerialNumber.BackColor = Color.White;
            label2.Visible = false;
            btnTestPart.Visible = true;
            btnTestPart.Enabled = true;
            btnTestPart.BackColor = Color.Yellow;
            btnTestPart.Text = "Click Here to Test S/N " + maskedTxtSerialNumber.Text + "";



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void printLabel()
        {
            Qty = "Qty: 1";
            SN = maskedTxtSerialNumber.Text.ToString().Trim();

            int descriptionLength = tbDescription.Text.Length;

            if (descriptionLength > 30)
            {
                tbDescription.Text = tbDescription.Text.Substring(0, 30);
            }


            if (descriptionLength < 15)
            {
                line1 = tbDescription.Text.Trim();
                line2 = "";
                line3 = "";
            }
            else   /*   description length is greater than 14   */
            {
                //if (g.iDescription.IndexOf(" ") != -1)
                //{
                //if (descriptionLength > 14)
                //{
                string a = tbDescription.Text.Substring(0, 14);

                if (a.LastIndexOf(",") != -1)
                {
                    firstLastIndex = a.LastIndexOf(",");
                    line1 = tbDescription.Text.Substring(0, firstLastIndex + 1);
                }
                else if (a.LastIndexOf(" ") != -1)
                {
                    firstLastIndex = a.LastIndexOf(" ");
                    line1 = tbDescription.Text.Substring(0, firstLastIndex);
                }
                else
                {
                    line1 = tbDescription.Text.Substring(0, 14);
                    firstLastIndex = 13;
                }
                //}

                if (tbDescription.Text.Substring(firstLastIndex + 1, descriptionLength - (firstLastIndex + 1)).Length > 14)
                {
                    string b = tbDescription.Text.Substring(firstLastIndex + 1, 14);

                    if (b.LastIndexOf(",") != -1)
                    {
                        secondLastIndex = b.LastIndexOf(",");
                        line2 = tbDescription.Text.Substring(firstLastIndex + 1, secondLastIndex + 1);
                    }
                    else if (b.LastIndexOf(" ") != -1)
                    {
                        secondLastIndex = b.LastIndexOf(" ");
                        line2 = tbDescription.Text.Substring(firstLastIndex + 1, secondLastIndex);
                    }
                    else if (b.ToUpper().LastIndexOf("X") != -1)
                    {
                        secondLastIndex = b.ToUpper().LastIndexOf("X");
                        line2 = tbDescription.Text.Substring(firstLastIndex + 1, secondLastIndex);
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
                    line2 = tbDescription.Text.Substring(firstLastIndex + 1, descriptionLength - (firstLastIndex + 1));
                    secondLastIndex = -1;
                }

                if (secondLastIndex != -1)
                {
                    line3 = tbDescription.Text.Substring(firstLastIndex + secondLastIndex + 2, descriptionLength -
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
                    line1 = tbDescription.Text.Substring(0, 14);

                    if (descriptionLength > 28)
                    {
                        line2 = tbDescription.Text.Substring(14, 14);
                    }
                    else  //( descriptionLength <= 28 )
                    {
                        line2 = tbDescription.Text.Substring(14, descriptionLength - 14);
                    }

                    if (descriptionLength > 28)
                    {
                        line3 = tbDescription.Text.Substring(28, descriptionLength - 28);
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
            labelQuantity = tbLabelQuantity.Text.Trim();
            
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

            string str = "\nN\nq609Q203,20\n";
            str += SendImageToPrinter(10, 10, bzp);
            str += SendImageToPrinter(450, 10, bxp);
            str += "A144,10,0,2,1,1,N,\"21 Laurel Brook Road\"\n";
            str += "A144,35,0,2,1,1,N,\"Middlefield, CT 06455 USA\"\n";
            str += "A10,70,0,2,1,1,N,\"PN#\"\n";
            str += "B50,65,0,1,2,4,32,B,\"" + g.item + "\"\n";
            str += "A420,60,0,2,1,1,N,\"" + line1 + "\"\n";
            str += "A420,80,0,2,1,1,N,\"" + line2 + "\"\n";
            str += "A420,100,0,2,1,1,N,\"" + line3 + "\"\n";
            str += "A10,140,0,2,1,1,N,\"SN#\"\n";
            str += "B50,135,0,1,2,4,32,B,\"" + SN + "\"\n";
            str += "A420,125,0,2,1,1,N,\"" + Rev + "\"\n";
            str += "A420,150,0,2,1,1,N,\"" + Qty + "\"\n";
            str += "A420,175,0,2,1,1,N,\"" + Part + "\"\n";
            str += "P" + labelQuantity + "\n";
            RawPrinterHelper.SendStringToPrinter(g.printer, str);

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

















