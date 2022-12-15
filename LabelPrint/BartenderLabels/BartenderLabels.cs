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
using System.Diagnostics;

namespace BartenderLabels
{
    public partial class BartenderLabels : Form
    {
        public BartenderLabels()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("c:\\a\\NavitarInput.csv");

            while (sr.Peek() >= 0)
            {
                string x = sr.ReadLine();

                File.WriteAllText(@"C:\labels\NTRsn.txt", x);

                
                Process P = new Process();
                P.StartInfo.FileName = @"C:\Program Files (x86)\Seagull\BarTender Suite\bartend.exe";
                P.StartInfo.Arguments = @" /F=C:\labels\navitar1.btw /P /X";
                P.Start();

                System.Threading.Thread.Sleep(5000);
            }
        }
    }
}
