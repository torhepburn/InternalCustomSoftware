using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace ZebrasSerialComm
{
    public partial class Form1 : Form
    {
        SerialPort zebrPrinter = new SerialPort("COM9",9600, Parity.None, 8, StopBits.One);
        string partNumber = "6191-0138-01";
        string partName = "33% Beamsplitter";
        string revision = "AD";
        string scannedSerialNumber = "90020614054";
        
        public Form1()
        {
            
            InitializeComponent();
            zebrPrinter.Handshake = Handshake.XOnXOff;
            zebrPrinter.DtrEnable = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zebrPrinter.Close();
            zebrPrinter.Open();
                     
            


            zebrPrinter.WriteLine("^XA^FO25,25^GFA,578,578,17,3KFE01FE3F1FE03FC,7LF01FEFFDFE1IF,"+
                "7LF03LFE3IFC,7LF03LFEJFE,7LF83LFEKF,7LF87RF,007FF7F87IFC7JF1FF8,00FFE3FC7IF83IFE0FF8,"+
                "01FFC3FC7IF83IFC07F8,03FF83FCJF83IFC07F8,03FF01FEFEFF83IFC07FC,07FE01FEFEFF83IFC07F8,"+
                "0FFC00IFEFF83IFC07F8,1FF800IFC7F83IFC07F8,3FFI07FFC7LFE0FF8,7JF87FFC7MF1FF,KF87FF83PF,"+
                "KF83FF81JFEJFE,KF83FF80JFE7IFC,KF81FF007F3FE3IF8,7JF81FFJ03FE0FFE,L01FEJ03FE01F,L01FE0FF83FE,K07FFE07FC7FC,"+
                "K07FFC07JFC,K07FFC07JF8,K07FF803JF8,K07FF001IFE,K07FCI07FFC," +//ZYGO logo bitmap ZPL code from Labelary Online ZPL Viewer
                //Add this code to end of previous string if line needed under ZYGO (,::gSF,:)

                "^FO170,25^ADN,18,10^FD21 Laurel Brook Road^FS"+
                "^FO140,52^ADN,18,10^FDMiddlefield, CT 06455 USA^FS" +

                "^FO450,25^GFA,357,357,17,,001,003801FF807FCJFDJFEJFDFE1FC,003801FF80FFCJFDJFEJFDFE3F8,"+
                "007C01FFC0FFCJFDJFEJFDFE7F,007E01FFC1FFCJFDJFEJFDFEFE,00FE01FFE1FFCJFDJFEJFDIFE,"+
                "00FF01FFE3FFCFEJ03F80FE001IFC,00FF01IF3FFCJFC03F80JFDIF8,007F81IF7FFCJFC03F80JFDIF,007F81LFCJFC03F80JFDIF8,"+
                "003FC1LFCJFC03F80JFDIF8,003FC1LFCJFC03F80JFDIFC,001FE1JFEFCFEJ03F80FE001IFE,0FEFF1FDFFCFCFEJ03F80FE001IFE,"+
                "1FCFF1FDFFCFCJF803F80JF9FEFF,1FC7F9FCFFCFCJFC03F80JFDFE7F8,3F87F9FCFF8FCJFC03F80JFDFE7FC,"+
                "3F83FDFC7F8FCJFC03F80JFDFE3FC,7F03FDFC7F0FCJFC03F80JFDFE3FE,7E01IFC3F0FC7IF803F007IF8FC1FE,^FS"+//AMETEK logo bitmap ZPL Code from Labelary Online ZPL Viewer

                "^FO400,85^ADN,18,10^FD"+partName+"^FS"+
                "^FO15,85^ADN,18,10^FDPN#^FS" +
                "^FO400,120^ADN,18,10^FDRevison: " + revision + "^FS" +
                "^FO55,80^A0,30,28^BCN,26,Y,N,N^FD"+partNumber+"^FS"+
                "^FO15,147^ADN,18,10^FDSN#^FS" +
                "^FO400,155^ADN,18,10^FDQuantity: 1^FS" +
                "^FO55,142^A0,30,28^BCN,26,Y,N,N^FD"+scannedSerialNumber+"^FS^XZ");
            
            
            zebrPrinter.Close();
        }
    }
}
