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

namespace _1000_1041_22
{
    public partial class SelectedLabel_4122 : Form
    {
        public SelectedLabel_4122()
        {
            InitializeComponent();
        }

        private void SelectedLabel_4122_Load(object sender, EventArgs e)
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

        private void bPrint_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\labels\generic\IDsnLabel.txt",
              "Copies \t Desc. \t Part# \t Model \t SN \t Hz \t Volts \t Amps" + Environment.NewLine);

            File.AppendAllText(@"C:\labels\generic\IDsnLabel.txt", " 1 \t  DESC. " +
                tbDescription.Text.Trim() + "\t  PART #  " +
                tbPartNumber.Text.Trim() + "\t  MODEL  " +
                tbModel.Text.Trim() + "\t  " +
                tbSerialNumber.Text.Trim().ToUpper() + "\t    Hz  " +
                tbHertz.Text.Trim() + "\t VOLTS  " +
                tbVolts.Text.Trim() + "\t  AMPS " +
                tbAmps.Text.Trim());

            System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Seagull" +
              "\\Bartender Suite\\bartend.exe",
            "/P /X /F=\\\\zygocorp\\departments\\shiprcvg\\labels\\labelformats\\1000-1041-22D_SN20_Win7.btw /d=" +
               "c:\\labels\\generic\\IDsnlabel.txt");


            //System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Seagull" +
            //    "\\Bartender Suite\\bartend.exe",
            //   "/P /X /F=\\\\zygocorp\\departments\\shiprcvg\\labels\\labelformats\\" + g.printer + " /d=" +
            //   "c:\\labels\\generic\\IDsnlabel.txt");

            Thread.Sleep(5 * 1000);
            //tbSerialNumber.Text = "";
            tbSerialNumber.Focus();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            g.freeText = false;
            this.Close();
        }
    }
}
