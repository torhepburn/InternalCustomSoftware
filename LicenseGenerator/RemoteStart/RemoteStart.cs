using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteStart
{
    public partial class RemoteStart : Form
    {
        public RemoteStart()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"\\zygocorp\manufacturing\softwaredistribution\zygo license generator\autolicense.exe");
        }
    }
}
