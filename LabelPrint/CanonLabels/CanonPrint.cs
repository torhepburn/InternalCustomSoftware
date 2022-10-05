using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace CanonLabels
{
    public partial class CanonPrint : Form
    {
        public CanonPrint()
        {
            InitializeComponent();
        }

        private void CanonPrint_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\labels\canon\canonlabel.txt",
                "Copies \t BarCode \t Canon_PN \t Zygo_PN \t Item_Description " +
                "\t CanonGlobalCode \t ZygoSN" + Environment.NewLine);

            //    File.WriteAllText(@"C:\labels\generic\genericlabel.txt",
            //   "Copies \t PartNo \t Description \t SN \t QTY \t REV \t PartXofY" + Environment.NewLine);

            File.AppendAllText(@"C:\labels\canon\canonlabel.txt", "1" +
                "\t 911356V592^19201^121 \t BN9-3156 \t 6191-0584-01 \t CWC " +
                "\t 1356V60901 \t 1542-R376 " + Environment.NewLine);
            //    " \t Part: 1 of 1");

            System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Seagull" +
               "\\Bartender Suite\\bartend.exe",
                "/P /X /F=\\\\zygocorp\\departments\\shiprcvg\\labels\\labelformats\\ZebraCanontext_sn22.btw /d=" +
               "c:\\labels\\canon\\canonlabel.txt");
            Thread.Sleep(5 * 1000);
        }

    }
}
