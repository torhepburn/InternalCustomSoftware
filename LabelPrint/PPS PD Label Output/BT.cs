using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PPS_PD_Label_Output
{
    public partial class BT : Form
    {
        public BT()
        {
            InitializeComponent();
        }

        private void BT_Load(object sender, EventArgs e)
        {
            Process P = new Process();
            P.StartInfo.FileName = @"C:\Program Files (x86)\Seagull\BarTender Suite\bartend.exe";
            //P.StartInfo.Arguments = @" /F=pn-sn.btw /P /X";
            P.StartInfo.Arguments = @" /F=C:\labels\pn-fw.btw";
            P.Start();
        }
    }
}
