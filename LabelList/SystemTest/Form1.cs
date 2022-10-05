using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace SystemTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            label1.Text = g.entrant;
            label2.Text = System.Environment.MachineName;

            string installedPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                installedPrinters = PrinterSettings.InstalledPrinters[i];
                comboBox1.Items.Add(installedPrinters);

            }
            string  printers0 = System.Drawing.Printing.PrinterSettings.InstalledPrinters[0];
            string printers1 = System.Drawing.Printing.PrinterSettings.InstalledPrinters[1];
            string printers2 = System.Drawing.Printing.PrinterSettings.InstalledPrinters[2];
            string printers3 = System.Drawing.Printing.PrinterSettings.InstalledPrinters[3];
            string  printers4 = System.Drawing.Printing.PrinterSettings.InstalledPrinters[4];
            string  printers5 = System.Drawing.Printing.PrinterSettings.InstalledPrinters[5];

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public static class g
    {
        public static string entrant;
    }
}
