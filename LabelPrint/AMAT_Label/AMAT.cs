using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;


namespace AMAT_Label
{
    public partial class AMAT : Form
    {
        public AMAT()
        {
            InitializeComponent();
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\labels\generic\genericlabel.txt",
               "Copies \t PartNo \t Description \t SN \t QTY \t REV \t PartXofY" + Environment.NewLine);

            File.AppendAllText(@"C:\labels\generic\genericlabel.txt", tbLabelQuantity.Text.Trim() + 
                "\t 0240-B9850 \t\t \t \t Qty:  1 \t" +
                " \t Part: 1 of 1");

            System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Seagull" +
               "\\Bartender Suite\\bartend.exe",
                "/P /X /F=\\\\zygocorp\\departments\\shiprcvg\\labels\\labelformats\\zebrageneric1amattext_sn17.btw /d=" +
               "c:\\labels\\generic\\genericlabel.txt");
            Thread.Sleep(5 * 1000);

            this.Close();
        }

         private void bExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
