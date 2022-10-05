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
             txtRefPwrPct.Text =reflectedPowerPercentage;//Display to text box
             txtTranPwrPct.Text = transmittedPowerPercentage;//Display to text box

                if ((powerRatioReflected >= .98) && (powerRatioTransmitted <=.1))//Check for Fold Mirror
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
                
             else if ((powerRatioReflected >= .27) &&(powerRatioTransmitted >= .62))//Check for 33% BS
             {
                 partNumber = "6191-0138-04";
                 _CameraPulse.PulseCamera(1);
                 LoadCameraRecipe();
                 LabelCheck();
                 

             }
             else if ((powerRatioReflected >= .43)&&(powerRatioTransmitted >= .43))//Check for 50% BS
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

                MessageBox.Show("Laser is not stable or locked. Status: " + laserStatus+ "\nDo not perform test until laser is stable and locked (Green OK LED).\nIf problem persists notify ZYGO Manufacturing Engineering.");
        }
                  
            
        

        public double ReflectedPowerRatio()//Function which calculates reflected power relative to input power
        {
            double scaledInputPower = ((1) * (Convert.ToDouble(channel3amplitude)));
            //double scaledInputPower is compensation factor for fixture
            double reflectedPower = Convert.ToDouble(channel2amplitude);
            powerRatioReflected = (reflectedPower*(.83) / scaledInputPower);//.83 is fixture compensation
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
                if (!((output == 2)||(output==3)))
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
   
            }
            
            
        }

        

            
     
        

    
     
   

       

       
    

